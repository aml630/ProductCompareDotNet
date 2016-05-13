

$(document).ready(function () {
    $('.flexdatalist').flexdatalist({
        minLength: 1
    });

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