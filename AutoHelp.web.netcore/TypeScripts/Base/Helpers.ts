module Base {
    "use strict";
    export class Helpers {
        public static AjaxService(type: string, url: string, data: any, successFunc?: any, errorFunc?: any, processData: boolean=true, async: boolean=true): JQueryXHR {

            if (type === "POST")
                data = JSON.stringify(data);

            return $.ajax({
                type: type, //GET or POST or PUT or DELETE verb
                url: url, // Location of the service
                data: data, //Data sent to server
                ////traditional: true,
                contentType: "application/json; charset=utf-8", // content type sent to server
                dataType: "json", //Expected data format from server
                processData: processData,
                success: successFunc, //On Successfull service call
                error: (jqXhr, textStatus, errorThrown) => {
                    if (errorFunc) {
                        errorFunc(jqXhr);
                    } else {
                        var errMessage = 'Uncaught Error.\n' + jqXhr.responseText + '[' + jqXhr.status + ']';
                        if (jqXhr.status === 0) {
                            errMessage = 'Not connect.\n Verify Network.';
                        } else if (jqXhr.status === 404) {
                            errMessage = 'Requested page not found. [404]';
                        } else if (jqXhr.status === 500) {
                            errMessage = 'Internal Server Error [500].';
                        } else if (errorThrown === 'parsererror') {
                            errMessage = 'Requested JSON parse failed.';
                        } else if (errorThrown === 'timeout') {
                            errMessage = 'Time out error.';
                        } else if (errorThrown === 'abort') {
                            errMessage = 'Ajax request aborted.';
                        }
                        alert(errMessage);
                    }
                },
                async: async
            });
        }

        public static ForceReloadPage(): void {
            window.location.href = window.location.href;
        }

        public static RedirectToUrl(urlto): void {
            window.location.href = urlto;
        }

    }
}