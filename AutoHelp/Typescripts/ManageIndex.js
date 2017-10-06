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
var ManageIndexPage = (function (_super) {
    __extends(ManageIndexPage, _super);
    function ManageIndexPage() {
        var _this = _super !== null && _super.apply(this, arguments) || this;
        _this.assemblies = new Array();
        return _this;
    }
    ManageIndexPage.prototype.Ready = function () {
        var _this = this;
        _super.prototype.Ready.call(this);
        this.listTemplate = Handlebars.compile($("#list-template").html());
        this.modalTemplate = Handlebars.compile($("#modal-template").html());
        this.SetAssemblyMenu();
        $(":file").filestyle();
        var bar = $('.bar');
        var percent = $('.percent');
        var status = $('#status');
        $('form').ajaxForm({
            beforeSend: function () {
                toastr.info("Start uploading");
                status.empty();
                var percentVal = '0%';
                bar.width(percentVal);
                percent.html(percentVal);
            },
            uploadProgress: function (event, position, total, percentComplete) {
                var percentVal = percentComplete + '%';
                bar.width(percentVal);
                percent.html(percentVal);
                //console.log(percentVal, position, total);
            },
            success: function (result) {
                if (result) {
                    var percentVal = '100%';
                    bar.width(percentVal);
                    percent.html(percentVal);
                    _this.ResetAssemblyList();
                    toastr.success("Uploading done");
                }
                else {
                    toastr.error("Uploading error");
                }
            },
            complete: function (xhr) {
                status.html(xhr.responseText);
            }
        });
    };
    ManageIndexPage.prototype.ResetAssemblyList = function () {
        var _this = this;
        BaseHelpers.AjaxService('GET', this.options.urlReset, null, function (result) {
            toastr.success("Assembly List Reseted");
            _this.SetAssemblyMenu();
        });
    };
    ManageIndexPage.prototype.SetAssemblyMenu = function () {
        var _this = this;
        BaseHelpers.AjaxService('GET', this.options.urlFiles, null, function (files) {
            if (files && files.length > 0) {
                $("#dlist").html(_this.listTemplate(files));
                $(".dllChoice").click(function (event) {
                    var id = $(event.currentTarget).attr('id');
                    var assembly = files.filter(function (item) { return (item.Id == id); });
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
            var id = $(event.currentTarget).attr('data-id');
            BaseHelpers.AjaxService('GET', _this.options.urlFiles, { id: id, deleted: true }, function (result) {
                if (result) {
                    toastr.success("Assembly deleted", "Assembly " + assembly.Fullname + " successfuly deleted");
                    _this.SetAssemblyMenu();
                }
                else {
                    toastr.error("Assembly deleted error", "Impossible to delete this assembly");
                }
            }).always(function () { $('#assModal').modal('hide'); });
        });
        $('#assModal').modal();
    };
    return ManageIndexPage;
}(Base.Page));
//# sourceMappingURL=ManageIndex.js.map