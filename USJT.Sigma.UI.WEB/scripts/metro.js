var activeEl = 0;
$(function () {
    var items = $('.btn-nav');
    $(items[activeEl]).addClass('active');
    $(".btn-nav").click(function () {
        $(items[activeEl]).removeClass('active');
        $(this).addClass('active');
        activeEl = $(".btn-nav").index(this);
    });
});