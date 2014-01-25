function showAddRequest(elem) {

    $("#div-container").load($(elem).attr("data-url"), function () {
        var title = $(elem).attr("title");

        $("li.last").removeClass("last").removeClass("active");
        $("span.selected").removeClass("selected")
        $(elem).parent("li").addClass("last active");
        $(elem).parent().find("span.arrow").removeClass("arrow").addClass("selected");
        $("#lnkPageName").text(title);
        if (title =="") $("#tblRequests").dataTable();
    });
}   