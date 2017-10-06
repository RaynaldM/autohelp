var Base;
(function (Base) {
    "use strict";
    var Helpers = (function () {
        function Helpers() {
        }
        Helpers.prototype.AjaxService = function (type, url, data, successFunc, errorFunc, processData, async) {
            if (processData === void 0) { processData = true; }
            if (async === void 0) { async = true; }
            if (type == "POST")
                data = JSON.stringify(data);
            return $.ajax({
                type: type,
                url: url,
                data: data,
                ////traditional: true,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                processData: processData,
                success: successFunc,
                error: function (jqXhr, textStatus, errorThrown) {
                    if (errorFunc) {
                        errorFunc(jqXhr);
                    }
                    else {
                        var errMessage = 'Uncaught Error.\n' + jqXhr.responseText + '[' + jqXhr.status + ']';
                        if (jqXhr.status === 0) {
                            errMessage = 'Not connect.\n Verify Network.';
                        }
                        else if (jqXhr.status == 404) {
                            errMessage = 'Requested page not found. [404]';
                        }
                        else if (jqXhr.status == 500) {
                            errMessage = 'Internal Server Error [500].';
                        }
                        else if (errorThrown === 'parsererror') {
                            errMessage = 'Requested JSON parse failed.';
                        }
                        else if (errorThrown === 'timeout') {
                            errMessage = 'Time out error.';
                        }
                        else if (errorThrown === 'abort') {
                            errMessage = 'Ajax request aborted.';
                        }
                        alert(errMessage);
                    }
                },
                async: async
            });
        };
        Helpers.prototype.ForceReloadPage = function () {
            window.location.href = window.location.href;
        };
        Helpers.prototype.RedirectToUrl = function (urlto) {
            window.location.href = urlto;
        };
        return Helpers;
    }());
    Base.Helpers = Helpers;
})(Base || (Base = {}));
//# sourceMappingURL=Helpers.js.map