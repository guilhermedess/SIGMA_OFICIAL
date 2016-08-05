$(document).ready(function () {
    $("#subAmostragem").toggle();
    $("#subDistribuicao").toggle();
    $("#subMedidasTendencia").toggle();
    $("#subMedidasDispersao").toggle();
    $("#subProbabilidade").toggle();
    $("#progresso").toggle();
});

$(document).ready(function () {
    $("#ocultaAmostragem").click(function () {
        $("#subAmostragem").toggle();
    });
    $("#ocultaDistribuicao").click(function () {
        $("#subDistribuicao").toggle();
    });
    $("#ocultaMedidasTendencia").click(function () {
        $("#subMedidasTendencia").toggle();
    });
    $("#ocultaMedidasDispersao").click(function () {
        $("#subMedidasDispersao").toggle();
    });
    $("#ocultaProbabilidade").click(function () {
        $("#subProbabilidade").toggle();
    });
    $("#ocultaProgresso").click(function () {
        $("#progresso").toggle();
    });
});