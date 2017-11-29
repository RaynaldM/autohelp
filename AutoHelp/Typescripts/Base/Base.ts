/// <reference path="../../scripts/typings/extends.d.ts" />
module Base {

    export class Page {
        public options: any;

        constructor(opts?: any) {
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

        Ready(): void {
       
        }

    }
}