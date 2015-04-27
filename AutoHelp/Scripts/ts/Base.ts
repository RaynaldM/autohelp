/// <reference path="../typings/handlebars/handlebars.d.ts" />
/// <reference path="../typings/toastr/toastr.d.ts" />
module Base {

    export class Page {
        public options: any;

        constructor(opts?: any) {
            this.options = opts;
            toastr.options = {
                "positionClass": "toast-bottom-full-width",
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
            //    $.views.helpers({ timeAgoformat: this.TimeAgoFormat });
            //    $.views.helpers({ calendarformat: this.CalendarFormat });
        }

        //public TimeAgoFormat(value: any): any {
        //    return moment(value).local().fromNow();
        //}

        //public CalendarFormat(value: any): any {
        //    return moment(value).local().calendar();
        //}
    }
}