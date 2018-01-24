class AssemblyDetailPage extends Base.Page {
    private namespacelistTemplate: HandlebarsTemplateDelegate;
    private typeBaseListTemplate: HandlebarsTemplateDelegate;
    private typeBaseTemplates: any = new Object();
    private errorsList: Array<any> = new Array<any>();

    private popTemplate: string;
    private popTemplates: any = new Object();
    private metaType: Array<string> = new Array("Classes", "Structures", "Interfaces", "Enumerations", "Delegates");
    private metaSubType: Array<string> = new Array("Methods", "Constructors", "Properties");

    private assemblyData: Array<any> = new Array();

    public Ready(): void {
        toastr.info("Loading data...");
        super.Ready();
        this.popTemplate = $("#poptemplate").html();
        this.namespacelistTemplate = Handlebars.compile($("#namespaces-template").html());
        this.typeBaseListTemplate = Handlebars.compile($("#typebaselist-template").html());

        for (var j = 0; j < this.metaType.length; j++) {
            this.typeBaseTemplates[this.metaType[j]] = Handlebars.compile($("#typebase" + this.metaType[j] + "-template").html());
        }

        for (var i: number = 0; i < this.metaSubType.length; i++) {
            this.popTemplates[this.metaSubType[i] + "-Title"] = Handlebars.compile($("#" + this.metaSubType[i] + "-PopTitle-template").html());
            this.popTemplates[this.metaSubType[i] + "-Content"] = Handlebars.compile($("#" + this.metaSubType[i] + "-PopContent-template").html());
        }

        Base.Helpers.AjaxService("POST", this.options.urlGet + "/" + this.options.DllId,
            null,
            (data) => {
                if (data) {
                    // set title
                    $("#h2name").text(data.Name);
                    $("#h2sname").text(data.FullName);

                    // Cout data
                    data.Namespaces.forEach((item) => {
                        item.ClassCount = item.Classes.length;
                        item.StructureCount = item.Structures.length;
                        item.InterfaceCount = item.Interfaces.length;
                        item.EnumerationCount = item.Enumerations.length;
                        item.DelegateCount = item.Delegates.length;
                    });

                    // copy assembly doc content in cache
                    this.assemblyData = data.Namespaces;
                    // ReSharper disable once AssignedValueIsNeverUsed
                    data = null; // garbage collect

                    this.setNamespaces(this.assemblyData);
                    this.setErrorList(this.assemblyData);
                    this.showErrorsList();
                } else {
                    toastr.error("No namespaces", "There is no namespaces to parse : Empty DLL");
                }
            })
            .done(() => toastr.success("Data loaded"))
            .fail(() => toastr.error("Data load failed"));
    }

    private setErrorList(data: any): void {
        var errorTab: Array<any> = new Array<any>();

        data.forEach((item) => {
            if (item.loadError) {
                errorTab.push(item);
            }

            // todo : use .some() & .filter
            for (let h = 0; h < this.metaType.length; h++) {
                var tab = item[this.metaType[h]];
                if (tab && tab.length > 0) {
                    tab.forEach((itemType) => {
                        if (itemType.LoadError) {
                            errorTab.push(itemType);
                        }
                        for (let k = 0; k < this.metaSubType.length; k++) {
                            var subtab = itemType[this.metaSubType[k]];
                            if (subtab && subtab.length > 0) {
                                subtab.forEach((subItemType) => {
                                    if (subItemType.LoadError) {
                                        errorTab.push(subItemType);
                                    }
                                });
                            }
                        }
                    });
                }

            }
        });

        errorTab.forEach((item) => {
            var map = this.errorsList.map((e) => {
                return e.message;
            });
            var index: number = map.indexOf(item.Fullname);
            if (index < 0) {
                this.errorsList.push({ message: item.Fullname, count: 1 });
            } else {
                this.errorsList[index].count++;
            }
        });
        this.errorsList.sort((a, b) => {
            if (a.message > b.message)
                return 1;
            if (a.message < b.message)
                return -1;
            return 0;
        });
    }

    private showErrorsList(): void {
        if (this.errorsList.length > 0) {
            $("#errorcount").text(this.errorsList.length);
            $("#errornavmenu").removeClass("hidden").show();
            var itemsToAdd: number = Math.min(this.errorsList.length, 10);
            //var more: boolean = itemsToAdd != this.errorsList.length;
            var template: HandlebarsTemplateDelegate = Handlebars.compile($("#errorlisttemplate").html());
            $("#errornavlist").html(template(this.errorsList.splice(0, itemsToAdd - 1)))
                .closest("li").removeClass("invisible").addClass("visible");
        }
    }

    private setNamespaces(namespaces: Array<any>): void {
        // set namespace list template
        $("#nmlist").html(this.namespacelistTemplate(namespaces));

        // and set event on them
        var namespacelink: JQuery = $("a[data-type]");

        namespacelink.unbind("click")
            .on("click", (event: JQueryEventObject) => {
                this.loadTypeBases($(event.currentTarget));
            });

        // Select the first element for the first 
        namespacelink.first().trigger("click");
    }

    private loadTypeBases(element: JQuery): void {
        var name: string = element.attr("data-id");
        $("#selected-namespace").text(name);
        var type: string = this.metaType[parseInt(element.attr("data-type"))];
        var myArray: any = this.getNameSpaceData(name);
        if (myArray && myArray[type]) {
            var data: Array<any> = myArray[type];

            if (data) {
                $("#typebasetitle").text(type);
                // set namespace list template
                data.forEach((item) => {
                    item.namespace = name;
                });

                $("#nmsublist").html(this.typeBaseListTemplate(data));
                var eventItems: JQuery = $("#nmsublist>.list-group-item");
                eventItems.click((event: JQueryEventObject) => {
                    eventItems.removeClass("active");
                    var item: JQuery = $(event.currentTarget);
                    item.addClass("active");
                    this.loadType(item);
                });
                eventItems.first().trigger("click");
            } else {
                toastr.error("No classes", "There is no classes to parse : Empty DLL");
            }
        }
    }

    private loadType(element: JQuery): void {
        var name: string = element.attr("data-namespace");
        var type: string = $("#typebasetitle").text();
        var id: string = element.attr("data-id");
        var data = this.getTypeBaseClassData(name, id, type);
        if (data) {
            // set namespace list template
            data.namespace = name;
            var tmpl = this.typeBaseTemplates[type];
            var h = tmpl(data);
            $("#typebase").html(h);
            var popoverList = $("a.popoverselect");
            this.setPopOver(popoverList);
        } else {
            toastr.error("No classes", "There is no classes to parse : Empty DLL");
        }
    }

    private setPopOver(element: JQuery): void {
        var self = this;
        element.popover({
            trigger: "focus",
            html: true,
            // get the title and content
            // ReSharper disable SuspiciousThisUsage
            title: function () {
                return self.getPopOverElement($(this), "Title");
            },
            content: function () {
                return self.getPopOverElement($(this), "Content");
            },
            // ReSharper restore SuspiciousThisUsage
            container: "body",
            placement: "left",
            template: this.popTemplate
        });
    }

    private getPopOverElement(element: JQuery, contentType: string): string {
        var name: string = element.attr("data-namespace");
        var subtype: string = this.metaSubType[parseInt(element.attr("data-subtype"))];
        var type: string = this.metaType[parseInt(element.attr("data-type"))];
        var methodName: string = element.attr("data-id");
        var className: string = element.attr("data-parent");

        var data = this.getSubTypeBase(name, className, methodName, type, subtype);
        if (data) {
            var templ = this.popTemplates[subtype + "-" + contentType];
            var html = templ(data);
            return html;
        }
        return "Error";
    }

    private getNameSpaceData(nameSpace: string): any {
        var myArray: Array<any> = this.assemblyData.filter((item) => {
            return (item.Name === nameSpace);
        });
        if (myArray && myArray.length === 1) {
            return myArray[0];
        }
        return null;
    }

    private getTypeBaseClassData(nameSpace: string, typeName: string, metaType: string): any {
        var myArray: any = this.getNameSpaceData(nameSpace);
        if (myArray && myArray[metaType]) {
            var data = myArray[metaType].filter((item) => {
                return item.Id === typeName;
            })[0];
            return data;
        }
        return null;
    }

    private getSubTypeBase(nameSpace: string, typeName: string, subName: string, metaType: string, metaSubType: string): any {
        var data = this.getTypeBaseClassData(nameSpace, typeName, metaType);
        if (data && data[metaSubType]) {
            var myArray: Array<any> = data[metaSubType].filter((item) => {
                return (item.Id === subName);
            });
            if (myArray && myArray.length === 1) {
                return myArray[0];
            }
        }
        return null;
    }
}