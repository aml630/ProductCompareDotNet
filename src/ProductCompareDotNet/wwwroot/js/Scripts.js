

$(document).ready(function () {
    $(".showSearch").click(function () {
        console.log("click worked")
        $(".bigSearch").show();
        $(".bigAdd").hide();
    })

    $(".showAdd").click(function () {
        $(".bigAdd").show();
        $(".bigSearch").hide();
    })


    $('.CategoryForm').submit(function (event) {
        event.preventDefault();
        console.log(($(this).data))
        $.ajax({
            url: 'Categories/AjaxCreateCategory',
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            success: function (result) {
              console.log(result);
            }
        });
        console.log("end");
    });

});