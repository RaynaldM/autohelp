/// <reference path="../../typings/index.d.ts" />
var Base;
(function (Base) {
    var Page = /** @class */ (function () {
        function Page(opts) {
            this.options = opts;
            toastr.options = {
                "positionClass": "toast-bottom-right",
                "timeOut": 3000,
                "onclick": null,
            };
            Handlebars.registerHelper('ifGreater', function (v1, v2, options) {
                if (v1 > v2) {
                    return options.fn(this);
                }
                return options.inverse(this);
            });
        }
        Page.prototype.Ready = function () {
        };
        return Page;
    }());
    Base.Page = Page;
})(Base || (Base = {}));
//# sourceMappingURL=Base.js.map