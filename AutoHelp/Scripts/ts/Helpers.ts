/// <reference path="../typings/toastr/toastr.d.ts" />
module Base {
    "use strict";
    export class Helpers {
        public AjaxService(type: string, url: string, data: any, successFunc?: any, errorFunc?: any, processData?: boolean, async?: boolean): JQueryXHR {

            if (type == "POST")
                data = JSON.stringify(data);

            return $.ajax({
                type: type, //GET or POST or PUT or DELETE verb
                url: url, // Location of the service
                data: data, //Data sent to server
                //traditional: true,
                contentType: "application/json; charset=utf-8", // content type sent to server
                dataType: "json", //Expected data format from server
                processdata: processData != undefined && typeof processData == "boolean" ? processData : true,
                success: successFunc, //On Successfull service call
                error: (jqXHR, textStatus, errorThrown) => {
                    if (errorFunc) {
                        errorFunc(jqXHR);
                    } else {
                        var errMessage = 'Uncaught Error.\n' + jqXHR.responseText + '[' + jqXHR.status + ']';
                        if (jqXHR.status === 0) {
                            errMessage = 'Not connect.\n Verify Network.';
                        } else if (jqXHR.status == 404) {
                            errMessage = 'Requested page not found. [404]';
                        } else if (jqXHR.status == 500) {
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
                async: async != undefined && typeof async == "boolean" ? async : true
            });
        }

        public ForceReloadPage(): void {
            window.location.href = window.location.href;
        }

        public RedirectToUrl(urlto): void {
            window.location.href = urlto;
        }

    }
}

declare var BaseHelpers: Base.Helpers;
