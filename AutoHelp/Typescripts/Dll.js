var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var DllIndexPage = (function (_super) {
    __extends(DllIndexPage, _super);
    function DllIndexPage() {
        var _this = _super !== null && _super.apply(this, arguments) || this;
        _this.typeBaseTemplates = new Object();
        _this.errorsList = new Array();
        _this.popTemplates = new Object();
        _this.metaType = new Array("Classes", "Structures", "Interfaces", "Enumerations", "Delegates");
        _this.metaSubType = new Array("Methods", "Constructors", "Properties");
        _this.assemblyData = new Array();
        return _this;
    }
    DllIndexPage.prototype.Ready = function () {
        var _this = this;
        toastr.info("Loading data...");
        _super.prototype.Ready.call(this);
        this.popTemplate = $("#poptemplate").html();
        this.namespacelistTemplate = Handlebars.compile($("#namespaces-template").html());
        this.typeBaseListTemplate = Handlebars.compile($("#typebaselist-template").html());
        for (var j = 0; j < this.metaType.length; j++) {
            this.typeBaseTemplates[this.metaType[j]] = Handlebars.compile($("#typebase" + this.metaType[j] + "-template").html());
        }
        for (var i = 0; i < this.metaSubType.length; i++) {
            this.popTemplates[this.metaSubType[i] + "-Title"] = Handlebars.compile($("#" + this.metaSubType[i] + "-PopTitle-template").html());
            this.popTemplates[this.metaSubType[i] + "-Content"] = Handlebars.compile($("#" + this.metaSubType[i] + "-PopContent-template").html());
        }
        BaseHelpers.AjaxService('GET', this.options.urlGet, { id: this.options.DllId }, function (data) {
            if (data) {
                data.forEach(function (item) {
                    item.ClassCount = item.Classes.length;
                    item.StructureCount = item.Structures.length;
                    item.InterfaceCount = item.Interfaces.length;
                    item.EnumerationCount = item.Enumerations.length;
                    item.DelegateCount = item.Delegates.length;
                });
                _this.assemblyData = data;
                // ReSharper disable once AssignedValueIsNeverUsed
                data = null; // garbage collect
                _this.setNamespaces(_this.assemblyData);
                _this.setErrorList(_this.assemblyData);
                _this.showErrorsList();
            }
            else {
                toastr.error("No namespaces", "There is no namespaces to parse : Empty DLL");
            }
        })
            .done(function () { return toastr.success("Data loaded"); })
            .fail(function () { return toastr.error("Data load failed"); });
    };
    DllIndexPage.prototype.setErrorList = function (data) {
        var _this = this;
        var errorTab = new Array();
        data.forEach(function (item) {
            if (item.LoadError) {
                errorTab.push(item);
            }
            // todo : use .some() & .filter
            for (var h = 0; h < _this.metaType.length; h++) {
                var tab = item[_this.metaType[h]];
                if (tab && tab.length > 0) {
                    tab.forEach(function (itemType) {
                        if (itemType.LoadError) {
                            errorTab.push(itemType);
                        }
                        for (var k = 0; k < _this.metaSubType.length; k++) {
                            var subtab = itemType[_this.metaSubType[k]];
                            if (subtab && subtab.length > 0) {
                                subtab.forEach(function (subItemType) {
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
        errorTab.forEach(function (item) {
            var map = _this.errorsList.map(function (e) {
                return e.message;
            });
            var index = map.indexOf(item.Fullname);
            if (index < 0) {
                _this.errorsList.push({ message: item.Fullname, count: 1 });
            }
            else {
                _this.errorsList[index].count++;
            }
        });
        this.errorsList.sort(function (a, b) {
            if (a.message > b.message)
                return 1;
            if (a.message < b.message)
                return -1;
            return 0;
        });
    };
    DllIndexPage.prototype.showErrorsList = function () {
        if (this.errorsList.length > 0) {
            $("#errorcount").text(this.errorsList.length);
            $("#errornavmenu").removeClass("hidden").show();
            var itemsToAdd = Math.min(this.errorsList.length, 10);
            //var more: boolean = itemsToAdd != this.errorsList.length;
            var template = Handlebars.compile($("#errorlisttemplate").html());
            $("#errornavlist").html(template(this.errorsList.splice(0, itemsToAdd - 1)));
        }
    };
    DllIndexPage.prototype.setNamespaces = function (namespaces) {
        var _this = this;
        // set namespace list template
        $("#nmlist").html(this.namespacelistTemplate(namespaces));
        // and set event on them
        var namespacelink = $("a[data-type]");
        namespacelink.click(function (event) {
            _this.loadTypeBases($(event.currentTarget));
        });
        namespacelink.first().trigger("click");
    };
    DllIndexPage.prototype.loadTypeBases = function (element) {
        var _this = this;
        var name = element.attr("data-id");
        var type = this.metaType[parseInt(element.attr("data-type"))];
        var myArray = this.getNameSpaceData(name);
        if (myArray && myArray[type]) {
            var data = myArray[type];
            if (data) {
                $("#typebasetitle").text(type);
                // set namespace list template
                data.forEach(function (item) {
                    item.namespace = name;
                });
                $("#nmsublist").html(this.typeBaseListTemplate(data));
                var eventItems = $("#nmsublist>.list-group-item");
                eventItems.click(function (event) {
                    eventItems.removeClass("active");
                    var item = $(event.currentTarget);
                    item.addClass("active");
                    _this.loadType(item);
                });
                eventItems.first().trigger("click");
            }
            else {
                toastr.error("No classes", "There is no classes to parse : Empty DLL");
            }
        }
    };
    DllIndexPage.prototype.loadType = function (element) {
        var name = element.attr("data-namespace");
        var type = $("#typebasetitle").text();
        var id = element.attr("data-id");
        var data = this.getTypeBaseClassData(name, id, type);
        if (data) {
            // set namespace list template
            data.namespace = name;
            var tmpl = this.typeBaseTemplates[type];
            var h = tmpl(data);
            $("#typebase").html(h);
            var popoverList = $("a.popoverselect");
            this.setPopOver(popoverList);
        }
        else {
            toastr.error("No classes", "There is no classes to parse : Empty DLL");
        }
    };
    DllIndexPage.prototype.setPopOver = function (element) {
        var self = this;
        element.popover({
            trigger: 'hover',
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
            container: 'body',
            placement: 'left',
            template: this.popTemplate
        });
    };
    DllIndexPage.prototype.getPopOverElement = function (element, contentType) {
        var name = element.attr("data-namespace");
        var subtype = this.metaSubType[parseInt(element.attr("data-subtype"))];
        var type = this.metaType[parseInt(element.attr("data-type"))];
        var methodName = element.attr("data-id");
        var className = element.attr("data-parent");
        var data = this.getSubTypeBase(name, className, methodName, type, subtype);
        if (data) {
            return this.popTemplates[subtype + "-" + contentType](data);
        }
        return "Error";
    };
    DllIndexPage.prototype.getNameSpaceData = function (nameSpace) {
        var myArray = this.assemblyData.filter(function (item) {
            return (item.Name == nameSpace);
        });
        if (myArray && myArray.length == 1) {
            return myArray[0];
        }
        return null;
    };
    DllIndexPage.prototype.getTypeBaseClassData = function (nameSpace, typeName, metaType) {
        var myArray = this.getNameSpaceData(nameSpace);
        if (myArray && myArray[metaType]) {
            var data = myArray[metaType].filter(function (item) {
                return item.Id == typeName;
            })[0];
            return data;
        }
        return null;
    };
    DllIndexPage.prototype.getSubTypeBase = function (nameSpace, typeName, subName, metaType, metaSubType) {
        var data = this.getTypeBaseClassData(nameSpace, typeName, metaType);
        if (data && data[metaSubType]) {
            var myArray = data[metaSubType].filter(function (item) {
                return (item.Id == subName);
            });
            if (myArray && myArray.length == 1) {
                return myArray[0];
            }
        }
        return null;
    };
    return DllIndexPage;
}(Base.Page));
//# sourceMappingURL=Dll.js.map