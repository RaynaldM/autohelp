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
var ManageIndexPage = /** @class */ (function (_super) {
    __extends(ManageIndexPage, _super);
    function ManageIndexPage() {
        var _this = _super !== null && _super.apply(this, arguments) || this;
        _this.assemblies = new Array();
        return _this;
    }
    ManageIndexPage.prototype.Ready = function () {
        _super.prototype.Ready.call(this);
        this.listTemplate = Handlebars.compile($("#list-template").html());
        this.modalTemplate = Handlebars.compile($("#modal-template").html());
        this.form = $("#mform");
        var data = this.form.serializeArray();
        //$("#save-form").unbind("click")
        //    .on("click",
        //    (e: JQueryEventObject) => {
        //        e.preventDefault();
        //        debugger;
        //        return $.ajax({
        //            type: "POST", //GET or POST or PUT or DELETE verb
        //            url: this.form.attr("action"), // Location of the service
        //            data: data, //Data sent to server
        //            ////traditional: true,
        //            contentType: "multipart/form-data", // content type sent to server
        //            success: ()=> {}, //On Successfull service call
        //            error: (jqXhr, textStatus, errorThrown) => {
        //                    var errMessage = 'Uncaught Error.\n' + jqXhr.responseText + '[' + jqXhr.status + ']';
        //                    if (jqXhr.status === 0) {
        //                        errMessage = 'Not connect.\n Verify Network.';
        //                    } else if (jqXhr.status === 404) {
        //                        errMessage = 'Requested page not found. [404]';
        //                    } else if (jqXhr.status === 500) {
        //                        errMessage = 'Internal Server Error [500].';
        //                    } else if (errorThrown === 'parsererror') {
        //                        errMessage = 'Requested JSON parse failed.';
        //                    } else if (errorThrown === 'timeout') {
        //                        errMessage = 'Time out error.';
        //                    } else if (errorThrown === 'abort') {
        //                        errMessage = 'Ajax request aborted.';
        //                    }
        //                    alert(errMessage);
        //            },
        //            async: true
        //        });
        //        });
        this.SetAssemblyMenu();
    };
    ManageIndexPage.prototype.ResetAssemblyList = function () {
        var _this = this;
        Base.Helpers.AjaxService("GET", this.options.urlReset, null, function () {
            toastr.success("Assembly List Reseted");
            _this.SetAssemblyMenu();
        });
    };
    ManageIndexPage.prototype.SetAssemblyMenu = function () {
        var _this = this;
        Base.Helpers.AjaxService("GET", this.options.urlFiles, null, function (files) {
            if (files && files.length > 0) {
                $("#dlist").html(_this.listTemplate(files));
                $(".dllChoice").click(function (event) {
                    var id = $(event.currentTarget).attr("id");
                    var assembly = files.filter(function (item) { return (item.Id === id); });
                    _this.SetAndOpenDeleteModal(assembly[0]);
                });
            }
            else {
                toastr.error("No files", "There is no file to parse : Please upload one or more in Admin page");
            }
        });
    };
    ManageIndexPage.prototype.SetAndOpenDeleteModal = function (assembly) {
        var _this = this;
        $("#modal-content").html(this.modalTemplate(assembly));
        $("#deleteButton").click(function (event) {
            var id = $(event.currentTarget).attr("data-id");
            Base.Helpers.AjaxService("GET", _this.options.urlFiles, { id: id, deleted: true }, function (result) {
                if (result) {
                    toastr.success("Assembly deleted", "Assembly " + assembly.Fullname + " successfuly deleted");
                    _this.SetAssemblyMenu();
                }
                else {
                    toastr.error("Assembly deleted error", "Impossible to delete this assembly");
                }
            }).always(function () { $("#assModal").modal("hide"); });
        });
        $("#assModal").modal();
    };
    return ManageIndexPage;
}(Base.Page));
//# sourceMappingURL=ManageIndex.js.map