function Dica1D() {
    $("#divDica1D").removeAttr("hidden");
    $("#btnDica1D").attr("id", "btnDica2D");
    $("#btnDica2D").attr("onclick", "Dica2D()");
}               
                
function Dica2D() {
    $("#divDica2D").removeAttr("hidden");
    $("#btnDica2D").attr("id", "btnDica3D");
    $("#btnDica3D").attr("onclick", "Dica3D()");
}               
                
function Dica3D(){
    $("#divDica3D").removeAttr("hidden");
    $("#btnDica3D").prop("disabled", true);
}