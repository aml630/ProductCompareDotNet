

$(document).ready(function () {
    $(".ShowAll").click(function () {

        $(".productDescription").show()
        $(".Reviews").show()
        $(".QA").show()

    })
    $(".DescriptionButton").click(function () {

        $(".productDescription").show()
        $(".Reviews").hide()
        $(".QA").hide()

    })
    $(".ReviewsButton").click(function () {

        $(".productDescription").hide()
        $(".Reviews").show()
        $(".QA").hide()

    })
    $(".QAButton").click(function () {

        $(".productDescription").hide()
        $(".Reviews").hide()
        $(".QA").show()

    })


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

    $('.downvote').submit(function (event) {
        event.preventDefault();
        console.log("downVote!")
        $.ajax({
            url: 'Products/Downvote',
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            success: function (result) {
                console.log(result);
                $('.down-' + result.ProductId).text(result.ProductDownVotes);

            }

        })
    })

    $('.upvote').submit(function (event) {
        event.preventDefault();
        console.log("downVote!")
        $.ajax({
            url: 'Products/Upvote',
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            success: function (result) {
                console.log(result);
                $('.up-' + result.ProductId).text(result.ProductUpVotes);

            }

        })
    })

});