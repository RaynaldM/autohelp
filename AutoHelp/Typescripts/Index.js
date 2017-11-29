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
var IndexPage = /** @class */ (function (_super) {
    __extends(IndexPage, _super);
    function IndexPage() {
        var _this = _super !== null && _super.apply(this, arguments) || this;
        _this.assemblies = new Array();
        return _this;
    }
    IndexPage.prototype.Ready = function () {
        _super.prototype.Ready.call(this);
        this.listTemplate = Handlebars.compile($("#list-template").html());
        var _self = this;
        Base.Helpers.AjaxService("GET", this.options.urlFiles, null, function (files) {
            if (files && files.length > 0) {
                _self.setAssemblyMenu(files);
            }
            else {
                toastr.error("No files", "There is no file to parse : Please upload one or more in Admin page");
            }
        });
    };
    IndexPage.prototype.setAssemblyMenu = function (files) {
        var _this = this;
        $("#dlist").html(this.listTemplate(files));
        $(".dllChoice").click(function (event) {
            var name = $(event.currentTarget).attr("id");
            Base.Helpers.RedirectToUrl(_this.options.urlDll + "/" + name);
        });
    };
    return IndexPage;
}(Base.Page));
//# sourceMappingURL=Index.js.map