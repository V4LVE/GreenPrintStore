(".toggleLoader").on('click', function () {
    $('#loader').show();
    $('#overlay-content').show();
});

(".toggleLoader").click(function () {
    console.log("You clicked the function")
    $('#loader').show();
    $('#overlay-content').show();
});

$(document).ready(function () {
    $('#fadein').hide();
});

$(".fadein").hide().toggle({ effect: "scale", direction: "horizontal", duration: 800 });