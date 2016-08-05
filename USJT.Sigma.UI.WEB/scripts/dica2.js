$(function () {
    $("#dialog2").dialog({
        autoOpen: false,
        show: {
            effect: "blind",
            duration: 1000
        },
        hide: {
            effect: "explode",
            duration: 1000
        }
    });

    $("#dica2").on("click", function () {
        $("#dialog").dialog("close");
        $("#dialog2").dialog("open");
    });
});