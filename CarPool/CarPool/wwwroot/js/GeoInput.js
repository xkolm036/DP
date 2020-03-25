//new geo
$(document).ready(function () {

    $('.adress_inp').on('input', function () {
        if ($(this).val().length > 2) {
            var input = $(this);
            var hiddenDivId = "#";
            hiddenDivId += $(this).attr("data-target");


            $.ajax({ //send request to find city/street
                url: "/Geography/dropDownItems",
                type: "GET",
                data: { geo: $(this).val() },  //data send to controller
                success: function (response) {
                    $(hiddenDivId).removeClass("d-none");
                    $(hiddenDivId).html(response); //fill dropdownItems view

                    $(".hiddenDiv a").click(function () {
                        $(input).val(this.innerText); //Fill city into input
                        $(hiddenDivId).addClass("d-none"); //Hide dropdown on click on city
                    });

                }
            });
        }
    });
});






//When click outside hidden div it hide itsledf
$(document).mouseup(function (e) {

    var container = $(".hiddenDiv");

    if (!container.is(e.target) && container.has(e.target).length === 0) {

        container.addClass("d-none");

    }
});


//on click open hidden div again
$('.adress_inp').click(function () {
    if ($(this).val().length > 2) {
        var hiddenDivId = "#";
        hiddenDivId += $(this).attr("data-target");
        $(hiddenDivId).removeClass("d-none");
    }
});




//select whole text of input on first click
$(document).ready(function () {
    $(".focusSelect:text").focus(function () {
        $(this).select();
    });
});

