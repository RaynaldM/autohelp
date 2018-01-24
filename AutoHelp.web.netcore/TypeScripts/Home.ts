class HomePage extends Base.Page {
    private listTemplate: HandlebarsTemplateDelegate;

    public Ready(): void {
        super.Ready();
        this.listTemplate = Handlebars.compile($("#list-template").html());
        toastr.info("Initializing and loading, this could take a moment", "Loading");
        Base.Helpers.AjaxService("GET", this.options.urlFiles,
            null, (files: Array<any>) => {
                if (files && files.length > 0) {
                    $("#dlist").html(this.listTemplate(files));
                    $("#dlist > .card").click((event: JQueryEventObject) => {
                        var name: string = $(event.currentTarget).attr("id");
                        Base.Helpers.RedirectToUrl(this.options.urlDll + "/" + name);
                    });
                } else {
                    toastr.error("No files", "There is no file to parse : Please upload one or more in Admin page");
                }
            });
    }
}