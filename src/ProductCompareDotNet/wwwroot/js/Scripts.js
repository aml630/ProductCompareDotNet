

$(document).ready(function () {

        $(".btn-pref .btn").click(function () {
            $(".btn-pref .btn").removeClass("btn-primary").addClass("btn-default");
            // $(".tab").addClass("active"); // instead of this do the below 
            $(this).removeClass("btn-default").addClass("btn-primary");
        });

    $('#login-form-link').click(function (e) {
        $("#login-form").delay(100).fadeIn(100);
        $("#register-form").fadeOut(100);
        $('#register-form-link').removeClass('active');
        $(this).addClass('active');
        e.preventDefault();
    });
    $('#register-form-link').click(function (e) {
        $("#register-form").delay(100).fadeIn(100);
        $("#login-form").fadeOut(100);
        $('#login-form-link').removeClass('active');
        $(this).addClass('active');
        e.preventDefault();
    });


    $(".questionDiv button").click(function () {
        $(".questionForm").toggle("slow");
     
    })

    $(".reviewDiv button").click(function () {
        $(".reviewForm").toggle("slow");

    })


    //alert("working");
    var newArray = [];
    var timedSearch;

    $("#basics").keypress(function () {
        window.clearTimeout(timedSearch)
        timedSearch = window.setTimeout(keyPressSearch, 1000);

    });


    function keyPressSearch() {
        var input = $("#basics").val();

        if (input !== "") {

            newArray = [];
            console.log("emptied: " +newArray)
            $.when(
            $.ajax({
                url: "http://api.walmartlabs.com/v1/search?query=" + input + "&format=json&apiKey=k2waftsef676thk9khfnevds",
                type: "GET",
                crossDomain: true,
                dataType: "jsonp",
                success: function (response) {
              
                   }
            })).then(function (response) {

                for (var i = 0; i < response.items.length; i++) {
                    newArray.push(response.items[i].name);
                }
                console.log("second fire" + newArray);
                $("#basics").autocomplete({
                    source: newArray
                })
            })
        }
    }





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


    $('.setUpTrue').submit(function (event) {
        event.preventDefault();
        console.log("running");

        $.ajax({
            url: '/../../Products/SetUpTrue/',
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            success: function (result) {
                console.log(result);
                $(".setUpTrueValue").text(result);
            }
        });
    });

    $('.setUpFalse').submit(function (event) {
        event.preventDefault();
        console.log("running");
        $.ajax({
            url: '/../../Products/SetUpFalse/',
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            success: function (result) {
                console.log(result);
                $(".setUpFalseValue").text(result);
            }
        });
    });



    $('.easyUseTrue').submit(function (event) {
        event.preventDefault();
        console.log("running");

        $.ajax({
            url: '/../../Products/EasyUseTrue/',
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            success: function (result) {
                console.log(result);
                $(".easyUseTrueValue").text(result);
            }
        });
    });

    $('.easyUseFalse').submit(function (event) {
        event.preventDefault();
        console.log("running");
        $.ajax({
            url: '/../../Products/EasyUseFalse/',
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            success: function (result) {
                console.log(result);
                $(".easyUseFalseValue").text(result);
            }
        });
    });


    $('.goodValueTrue').submit(function (event) {
        event.preventDefault();
        console.log("running");

        $.ajax({
            url: '/../../Products/GoodValueTrue/',
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            success: function (result) {
                console.log(result);
                $(".goodValueTrueValue").text(result);
            }
        });
    });

    $('.goodValueFalse').submit(function (event) {
        event.preventDefault();
        console.log("running");
        $.ajax({
            url: '/../../Products/GoodValueFalse/',
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            success: function (result) {
                console.log(result);
                $(".goodValueFalseValue").text(result);
            }
        });
    });


    $('.suggestTrue').submit(function (event) {
        event.preventDefault();
        console.log("running");

        $.ajax({
            url: '/../../Products/WouldSuggestTrue/',
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            success: function (result) {
                console.log(result);
                $(".suggestTrueValue").text(result);
            }
        });
    });

    $('.suggestFalse').submit(function (event) {
        event.preventDefault();
        console.log("running");
        $.ajax({
            url: '/../../Products/WouldSuggestFalse/',
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            success: function (result) {
                console.log(result);
                $(".suggestFalseValue").text(result);
            }
        });
    });
    //$('.downvote').submit(function (event, id) {
    //    event.preventDefault();
    //    console.log("downVote!")
    //    $.ajax({
    //        url: 'Products/Downvote',
    //        type: 'POST',
    //        dataType: 'int',
    //        data: id,
    //        success: function (result) {
    //            console.log(result);
    //            $('.down-' + result.ProductId).text(result.ProductDownVotes);

    //        }

    //    })
    //})

    //$('.upvote').submit(function (event) {
    //    event.preventDefault();
    //    console.log("downVote!")
    //    $.ajax({
    //        url: 'Products/Upvote',
    //        type: 'POST',
    //        dataType: 'json',
    //        data: $(this).serialize(),
    //        success: function (result) {
    //            console.log(result);
    //            $('.up-' + result.ProductId).text(result.ProductUpVotes);
    //        }
    //    })
    //})
});