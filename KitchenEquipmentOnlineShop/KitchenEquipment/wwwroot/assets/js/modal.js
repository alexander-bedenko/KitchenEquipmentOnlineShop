$(".viewDialog").on("click", function (event) {
    event.preventDefault();
    return $.get(this.href, function (data) {
        $('#mainDialogContent').html(data);
        $('#mainModal').modal('show');
    });
});
