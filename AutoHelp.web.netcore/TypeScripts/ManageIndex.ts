class ManageIndexPage extends Base.Page {
    private assemblies: Array<any> = new Array();
    private listTemplate: HandlebarsTemplateDelegate;
    private modalTemplate: HandlebarsTemplateDelegate;
    private form: JQuery;

    public Ready(): void {
        super.Ready();
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
    }

    private ResetAssemblyList(): void {
        Base.Helpers.AjaxService("GET", this.options.urlReset,
            null, () => {
                toastr.success("Assembly List Reseted");
                this.SetAssemblyMenu();
            });
    }

    private SetAssemblyMenu(): void {
        Base.Helpers.AjaxService("GET", this.options.urlFiles,
            null, (files) => {
                if (files && files.length > 0) {
                    $("#dlist").html(this.listTemplate(files));
                    $(".dllChoice").click((event: JQueryEventObject) => {
                        var id: string = $(event.currentTarget).attr("id");
                        var assembly: Array<any> = files.filter((item: any) => { return (item.Id === id); });
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
            var id: string = $(event.currentTarget).attr("data-id");
            Base.Helpers.AjaxService("GET", this.options.urlFiles,
                { id: id, deleted: true },
                (result) => {
                    if (result) {

                        toastr.success("Assembly deleted", "Assembly " + assembly.Fullname + " successfuly deleted");
                        this.SetAssemblyMenu();
                    } else {
                        toastr.error("Assembly deleted error", "Impossible to delete this assembly");
                    }
                }).always(() => { $("#assModal").modal("hide"); });
        });
        $("#assModal").modal();
    }
}