

$(document).ready(function () {

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

                    for (var i = 0; i < response.items.length; i++) {
                        newArray.push(response.items[i].name);
                    }
                    console.log("first fire" +newArray);
                }

            })).then(function () {

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


    //$('.CategoryForm').submit(function (event) {
    //    event.preventDefault();
    //    console.log(($(this).data))
    //    $.ajax({
    //        url: '~/../../Categories/AjaxCreateCategory',
    //        type: 'POST',
    //        dataType: 'json',
    //        data: $(this).serialize(),
    //        success: function (result) {
    //          console.log(result);
    //        }
    //    });
    //    console.log("end");
    //});

    //$('.downvote').submit(function (event) {
    //    event.preventDefault();
    //    console.log("downVote!")
    //    $.ajax({
    //        url: 'Products/Downvote',
    //        type: 'POST',
    //        dataType: 'json',
    //        data: $(this).serialize(),
    //        success: function (result) {
    //            console.log(result);
    //            $('.down-' + result.ProductId).text(result.ProductDownVotes);

    //        }

    //    })
    //})

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


//    $(".fiveStar").hover(
//        function () {
//            $(".oneStar").addClass("selected");
//            $(".twoStar").addClass("selected");
//            $(".threeStar").addClass("selected");
//            $(".fourStar").addClass("selected");
//            $(".fiveStar").addClass("selected");

//        },
//        function () {
//            $(".oneStar").removeClass("selected");
//            $(".twoStar").removeClass("selected");
//            $(".threeStar").removeClass("selected");
//            $(".fourStar").removeClass("selected");
//            $(".fiveStar").removeClass("selected");
//        });

//    $(".fourStar").hover(
//       function () {
//           $(".oneStar").addClass("selected");
//           $(".twoStar").addClass("selected");
//           $(".threeStar").addClass("selected");
//           $(".fourStar").addClass("selected");

//       },
//       function () {
//           $(".oneStar").removeClass("selected");
//           $(".twoStar").removeClass("selected");
//           $(".threeStar").removeClass("selected");
//           $(".fourStar").removeClass("selected");
//           });

//        $(".threeStar").hover(
//       function () {
//           $(".oneStar").addClass("selected");
//           $(".twoStar").addClass("selected");
//           $(".threeStar").addClass("selected");

//       },
//       function () {
//           $(".oneStar").removeClass("selected");
//           $(".twoStar").removeClass("selected");
//           $(".threeStar").removeClass("selected");
//       });

//        $(".twoStar").hover(
//       function () {
//           $(".oneStar").addClass("selected");
//           $(".twoStar").addClass("selected");
//       },
//       function () {
//           $(".oneStar").removeClass("selected");
//           $(".twoStar").removeClass("selected");
//       });

//    $(".oneStar").hover(
//   function () {
//       $(".oneStar").addClass("selected");


//   },
//   function () {
//       $(".oneStar").removeClass("selected");

//   });
});