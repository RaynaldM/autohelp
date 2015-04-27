/// <reference path="../typings/bootstrap/bootstrap.d.ts" />
/// <reference path="../typings/handlebars/handlebars.d.ts" />
/// <reference path="../typings/extends.d.ts" />
/// <reference path="helpers.ts" />
/// <reference path="base.ts" />

class DllIndexPage extends Base.Page {
    private namespacelistTemplate: HandlebarsTemplateDelegate;
    private typeBaseListTemplate: HandlebarsTemplateDelegate;
    private typeBaseTemplates: any = new Object();
    private ErrorsList: Array<any> = new Array<any>();

    private popTemplate: string;
    private popTemplates: any = new Object();
    private MetaType: Array<string> = new Array("Classes", "Structures", "Interfaces", "Enumerations", "Delegates");
    private MetaSubType: Array<string> = new Array("Methods", "Constructors", "Properties");

    private assemblyData: Array<any> = new Array();

    public Ready(): void {
        toastr.info("Loading data...");
        super.Ready();
        this.popTemplate = $("#poptemplate").html();
        this.namespacelistTemplate = Handlebars.compile($("#namespaces-template").html());
        this.typeBaseListTemplate = Handlebars.compile($("#typebaselist-template").html());
        for (var j = 0; j < this.MetaType.length; j++) {
            this.typeBaseTemplates[this.MetaType[j]] = Handlebars.compile($("#typebase" + this.MetaType[j] + "-template").html());
        }

        for (var i: number = 0; i < this.MetaSubType.length; i++) {
            this.popTemplates[this.MetaSubType[i] + "-Title"] = Handlebars.compile($("#" + this.MetaSubType[i] + "-PopTitle-template").html());
            this.popTemplates[this.MetaSubType[i] + "-Content"] = Handlebars.compile($("#" + this.MetaSubType[i] + "-PopContent-template").html());
        }

        BaseHelpers.AjaxService('GET', this.options.urlGet,
            { id: this.options.DllId },
            (data) => {
                if (data) {
              
                    data.forEach((item) => {
                        item.ClassCount = item.Classes.length;
                        item.StructureCount = item.Structures.length;
                        item.InterfaceCount = item.Interfaces.length;
                        item.EnumerationCount = item.Enumerations.length;
                        item.DelegateCount = item.Delegates.length;
                    });

                    this.assemblyData = data;
                    data = null; // garbage collect

                    this.SetNamespaces(this.assemblyData);
                    this.SetErrorList(this.assemblyData);
                    this.ShowErrorsList();
                } else {
                    toastr.error("No namespaces", "There is no namespaces to parse : Empty DLL");
                }
            })
            .done(() => toastr.success("Data loaded"))
            .fail(() => toastr.error("Data load failed"));
    }

    private SetErrorList(data: any): void {
        var errorTab: Array<any> = new Array<any>();

        data.forEach((item) => {
            if (item.LoadError) {
                errorTab.push(item);
            }

            // todo : use .some() & .filter
            for (var h = 0; h < this.MetaType.length; h++) {
                var tab = item[this.MetaType[h]];
                if (tab && tab.length > 0) {
                    tab.forEach((itemType) => {
                        if (itemType.LoadError) {
                            errorTab.push(itemType);
                        }
                        for (var k = 0; k < this.MetaSubType.length; k++) {
                            var subtab = itemType[this.MetaSubType[k]];
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
            var map = this.ErrorsList.map((e) => {
                return e.message;
            });
            var index: number = map.indexOf(item.Fullname);
            if (index < 0) {
                this.ErrorsList.push({ message: item.Fullname, count: 1 });
            } else {
                this.ErrorsList[index].count++;
            }
        });
        this.ErrorsList.sort((a, b) => {
            if (a.message > b.message)
                return 1;
            if (a.message < b.message)
                return -1;
            return 0;
        });
    }

    private ShowErrorsList(): void {
        if (this.ErrorsList.length > 0) {
            $("#errorcount").text(this.ErrorsList.length);
            $("#errornavmenu").removeClass("hidden").show();
            var itemsToAdd: number = Math.min(this.ErrorsList.length, 10);
            var more: boolean = itemsToAdd != this.ErrorsList.length;
            var template: HandlebarsTemplateDelegate = Handlebars.compile($("#errorlisttemplate").html());
            $("#errornavlist").html(template(this.ErrorsList.splice(0, itemsToAdd - 1)));
        }
    }

    private SetNamespaces(namespaces: Array<any>): void {
        // set namespace list template
        $("#nmlist").html(this.namespacelistTemplate(namespaces));

        // and set event on them
        var namespacelink: JQuery = $("a[data-type]");
        namespacelink.click((event: JQueryEventObject) => {
            this.LoadTypeBases($(event.currentTarget));
        });
        namespacelink.first().trigger("click");
    }

    private LoadTypeBases(element: JQuery): void {
        var name: string = element.attr("data-id");
        var type: string = this.MetaType[parseInt(element.attr("data-type"))];
        var myArray: any = this.GetNameSpaceData(name);
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
                    this.LoadType(item);
                });
                eventItems.first().trigger("click");
            } else {
                toastr.error("No classes", "There is no classes to parse : Empty DLL");
            }
        }
    }

    private LoadType(element: JQuery): void {
        var name: string = element.attr("data-namespace");
        var type: string = $("#typebasetitle").text();
        var id: string = element.attr("data-id");
        var data = this.GetTypeBaseClassData(name, id, type);
        if (data) {
            // set namespace list template
            data.namespace = name;
            var tmpl = this.typeBaseTemplates[type];
            var h = tmpl(data);
            $("#typebase").html(h);
            var popoverList = $("a.popoverselect");
            this.SetPopOver(popoverList);
        } else {
            toastr.error("No classes", "There is no classes to parse : Empty DLL");
        }
    }

    private SetPopOver(element: JQuery): void {
        var _this = this;
        element.popover({
            trigger: 'hover',
            html: true,
            // get the title and content
            title: function () {
                return _this.GetPopOverElement($(this), "Title");
            },
            content: function () {
                return _this.GetPopOverElement($(this), "Content");
            },
            container: 'body',
            placement: 'left',
            template: this.popTemplate
        });
    }

    private GetPopOverElement(element: JQuery, contentType: string): string {
        var name: string = element.attr("data-namespace");
        var subtype: string = this.MetaSubType[parseInt(element.attr("data-subtype"))];
        var type: string = this.MetaType[parseInt(element.attr("data-type"))];
        var methodName: string = element.attr("data-id");
        var className: string = element.attr("data-parent");

        var data = this.GetSubTypeBase(name, className, methodName, type, subtype);
        if (data) {
            return this.popTemplates[subtype + "-" + contentType](data);
        }
        return "Error";
    }

    private GetNameSpaceData(nameSpace: string): any {
        var myArray: Array<any> = this.assemblyData.filter((item) => {
            return (item.Name == nameSpace);
        });
        if (myArray && myArray.length == 1) {
            return myArray[0];
        }
        return null;
    }

    private GetTypeBaseClassData(nameSpace: string, typeName: string, metaType: string): any {
        var myArray: any = this.GetNameSpaceData(nameSpace);
        if (myArray && myArray[metaType]) {
            var data = myArray[metaType].filter((item) => {
                return item.Id == typeName;
            })[0];
            return data;
        }
        return null;
    }

    private GetSubTypeBase(nameSpace: string, typeName: string, subName: string, metaType: string, metaSubType: string): any {
        var data = this.GetTypeBaseClassData(nameSpace, typeName, metaType);
        if (data && data[metaSubType]) {
            var myArray: Array<any> = data[metaSubType].filter((item) => {
                return (item.Id == subName);
            });
            if (myArray && myArray.length == 1) {
                return myArray[0];
            }
        }
        return null;
    }
}