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
var HomePage = /** @class */ (function (_super) {
    __extends(HomePage, _super);
    function HomePage() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    HomePage.prototype.Ready = function () {
        var _this = this;
        _super.prototype.Ready.call(this);
        this.listTemplate = Handlebars.compile($("#list-template").html());
        toastr.info("Initializing and loading, this could take a moment", "Loading");
        Base.Helpers.AjaxService("GET", this.options.urlFiles, null, function (files) {
            if (files && files.length > 0) {
                $("#dlist").html(_this.listTemplate(files));
                $("#dlist > .card").click(function (event) {
                    var name = $(event.currentTarget).attr("id");
                    Base.Helpers.RedirectToUrl(_this.options.urlDll + "/" + name);
                });
            }
            else {
                toastr.error("No files", "There is no file to parse : Please upload one or more in Admin page");
            }
        });
    };
    return HomePage;
}(Base.Page));
//# sourceMappingURL=Home.js.map