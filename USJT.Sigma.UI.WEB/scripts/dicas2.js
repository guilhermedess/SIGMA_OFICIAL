function Dica1B() {
    $("#divDica1B").removeAttr("hidden");
    $("#btnDica1B").attr("id", "btnDica2B");
    $("#btnDica2B").attr("onclick", "Dica2B()");
}

function Dica2B() {
    $("#divDica2B").removeAttr("hidden");
    $("#btnDica2B").attr("id", "btnDica3B");
    $("#btnDica3B").attr("onclick", "Dica3B()");
}

function Dica3B() {
    $("#divDica3B").removeAttr("hidden");
    $("#btnDica3B").prop("disabled", true);
}