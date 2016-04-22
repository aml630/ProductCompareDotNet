

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


});