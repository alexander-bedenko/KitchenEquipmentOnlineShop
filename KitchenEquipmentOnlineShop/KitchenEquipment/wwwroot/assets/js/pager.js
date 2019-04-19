$(document).ready(function () {
    $(document).on("click", "#contentPager a[href]", function () {
        $.ajax({
            url: $(this).attr("href"),
            type: 'GET',
            cache: false,
            success: function (result) {
                $('#ajax-content').html(result);
            }
        });
        return false;
    });
});