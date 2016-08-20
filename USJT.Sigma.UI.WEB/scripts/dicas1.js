function Dica1A() {
    $("#divDica1A").removeAttr("hidden");
    $("#btnDica1A").attr("id", "btnDica2A");
    $("#btnDica2A").attr("onclick", "Dica2A()");
}

function Dica2A() {
    $("#divDica2A").removeAttr("hidden");
    $("#btnDica2A").attr("id", "btnDica3A");
    $("#btnDica3A").attr("onclick", "Dica3A()");
}

function Dica3A() {
    $("#divDica3A").removeAttr("hidden");
    $("#btnDica3A").prop("disabled", true);
}