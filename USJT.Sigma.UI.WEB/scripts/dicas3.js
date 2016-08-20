function Dica1C() {
    $("#divDica1C").removeAttr("hidden");
    $("#btnDica1C").attr("id", "btnDica2C");
    $("#btnDica2C").attr("onclick", "Dica2C()");
}               
                
function Dica2C() {
    $("#divDica2C").removeAttr("hidden");
    $("#btnDica2C").attr("id", "btnDica3C");
    $("#btnDica3C").attr("onclick", "Dica3C()");
}               
                
function Dica3C() {
    $("#divDica3C").removeAttr("hidden");
    $("#btnDica3C").prop("disabled", true);
}