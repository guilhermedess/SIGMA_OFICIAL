$(document).ready(function () {
    $("#subAmostragem").toggle();
    $("#subDistribuicao").toggle();
    $("#subMedidasPosicao").toggle();
    $("#subMedidasDispersao").toggle();
    $("#subProbabilidade").toggle();
});

$(document).ready(function () {
    $("#ocultaAmostragem").click(function () {
        $("#subAmostragem").toggle();
    });
    $("#ocultaDistribuicao").click(function () {
        $("#subDistribuicao").toggle();
    });
    $("#ocultaMedidasPosicao").click(function () {
        $("#subMedidasPosicao").toggle();
    });
    $("#ocultaMedidasDispersao").click(function () {
        $("#subMedidasDispersao").toggle();
    });
    $("#ocultaProbabilidade").click(function () {
        $("#subProbabilidade").toggle();
    });
});