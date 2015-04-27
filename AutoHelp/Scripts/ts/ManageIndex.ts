/// <reference path="helpers.ts" />
/// <reference path="base.ts" />
/// <reference path="../typings/handlebars/handlebars.d.ts" />
/// <reference path="../typings/bootstrap/bootstrap.d.ts" />
/// <reference path="../typings/extends.d.ts" />

class ManageIndexPage extends Base.Page {
    private assemblies: Array<any> = new Array();
    private listTemplate: HandlebarsTemplateDelegate;
    private modalTemplate: HandlebarsTemplateDelegate;

    public Ready(): void {
        super.Ready();
        this.listTemplate = Handlebars.compile($("#list-template").html());
        this.modalTemplate = Handlebars.compile($("#modal-template").html());

        this.SetAssemblyMenu();
        $(":file").filestyle();
        var bar: JQuery = $('.bar');
        var percent: JQuery = $('.percent');
        var status: JQuery = $('#status');

        $('form').ajaxForm({
            beforeSend: () => {
                toastr.info("Start uploading");
                status.empty();
                var percentVal: string = '0%';
                bar.width(percentVal);
                percent.html(percentVal);
            },
            uploadProgress: (event, position, total, percentComplete) => {
                var percentVal = percentComplete + '%';
                bar.width(percentVal);
                percent.html(percentVal);
                //console.log(percentVal, position, total);
            },
            success: (result: boolean) => {
                if (result) {
                    var percentVal: string = '100%';
                    bar.width(percentVal);
                    percent.html(percentVal);
                    this.ResetAssemblyList();
                    toastr.success("Uploading done");
                } else {
                    toastr.error("Uploading error");
                }
            },
            complete: (xhr) => {
                status.html(xhr.responseText);
            }
        });
    }

    private ResetAssemblyList(): void {
        BaseHelpers.AjaxService('GET', this.options.urlReset,
            null, (result) => {
                toastr.success("Assembly List Reseted");
                this.SetAssemblyMenu();
            });
    }

    private SetAssemblyMenu(): void {
        BaseHelpers.AjaxService('GET', this.options.urlFiles,
            null, (files) => {
                if (files && files.length > 0) {
                    $("#dlist").html(this.listTemplate(files));
                    $(".dllChoice").click((event: JQueryEventObject) => {
                        var id: string = $(event.currentTarget).attr('id');
                        var assembly: Array<any> = files.filter((item: any) => { return (item.Id == id); });
                        this.SetAndOpenDeleteModal(assembly[0]);
                    });
                } else {
                    toastr.error("No files", "There is no file to parse : Please upload one or more in Admin page");
                }
            });

    }

    private SetAndOpenDeleteModal(assembly: any): void {
        $("#modal-content").html(this.modalTemplate(assembly));
        $("#deleteButton").click((event: JQueryEventObject) => {
            var id: string = $(event.currentTarget).attr('data-id');
            BaseHelpers.AjaxService('GET', this.options.urlFiles,
                { id: id, deleted: true },
                (result) => {
                    if (result) {

                        toastr.success("Assembly deleted", "Assembly " + assembly.Fullname + " successfuly deleted");
                        this.SetAssemblyMenu();
                    } else {
                        toastr.error("Assembly deleted error", "Impossible to delete this assembly");
                    }
                }).always(() => { $('#assModal').modal('hide'); });
        });
        $('#assModal').modal();
    }
}