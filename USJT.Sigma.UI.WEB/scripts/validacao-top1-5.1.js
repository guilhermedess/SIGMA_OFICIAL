/*topico 1 - sub 5.1*/

$(document).ready(function () {
    $("#campoResp1").keyup(function () {
        var valor = $("#campoResp1").val().replace(/[^0-9]+/g, '');
        $("#campoResp1").val(valor);
    })
    $("#campoResp2").keyup(function () {
        var valor = $("#campoResp2").val().replace(/[^0-9]+/g, '');
        $("#campoResp2").val(valor);
    })
    $("#campoResp3").keyup(function () {
        var valor = $("#campoResp3").val().replace(/[^0-9]+/g, '');
        $("#campoResp3").val(valor);
    })
    $("#campoResp4").keyup(function () {
        var valor = $("#campoResp4").val().replace(/[^0-9]+/g, '');
        $("#campoResp4").val(valor);
    })
    $("#campoResp5").keyup(function () {
        var valor = $("#campoResp5").val().replace(/[^0-9]+/g, '');
        $("#campoResp5").val(valor);
    })
    $("#campoResp6").keyup(function () {
        var valor = $("#campoResp6").val().replace(/[^0-9]+/g, '');
        $("#campoResp6").val(valor);
    })
    $("#campoResp7").keyup(function () {
        var valor = $("#campoResp7").val().replace(/[^0-9]+/g, '');
        $("#campoResp7").val(valor);
    })
    $("#campoResp8").keyup(function () {
        var valor = $("#campoResp8").val().replace(/[^0-9]+/g, '');
        $("#campoResp8").val(valor);
    })
    $("#campoResp9").keyup(function () {
        var valor = $("#campoResp9").val().replace(/[^0-9]+/g, '');
        $("#campoResp9").val(valor);
    })
    $("#campoResp10").keyup(function () {
        var valor = $("#campoResp10").val().replace(/[^0-9]+/g, '');
        $("#campoResp10").val(valor);
    })
    $("#campoResp11").keyup(function () {
        var valor = $("#campoResp11").val().replace(/[^0-9]+/g, '');
        $("#campoResp11").val(valor);
    })
    $("#campoResp12").keyup(function () {
        var valor = $("#campoResp12").val().replace(/[^0-9]+/g, '');
        $("#campoResp12").val(valor);
    })
    $("#campoResp13").keyup(function () {
        var valor = $("#campoResp13").val().replace(/[^0-9]+/g, '');
        $("#campoResp13").val(valor);
    })
    $("#campoResp14").keyup(function () {
        var valor = $("#campoResp14").val().replace(/[^0-9]+/g, '');
        $("#campoResp14").val(valor);
    })
});

$().ready(function () {
    var validator = $("#form3").bind("invalid-form.validate", function () {
    }).validate(
    {
        errorElement: "el",
        errorPlacement: function (error, element) {
            element.parent("td").next("td").html(error);
        },
        success: function (label) {
            label.addClass("glyphicon glyphicon-ok").removeClass("error").addClass("ok");
        },
        submitHandler: function (form) {
            form.submit();
        },
        rules: {
            campoResp1: {
                required: true,
                number: true
            },
            campoResp2: {
                required: true,
                number: true
            },
            campoResp3: {
                required: true,
                number: true
            },
            campoResp4: {
                required: true,
                number: true
            },
            campoResp5: {
                required: true,
                number: true
            },
            campoResp6: {
                required: true,
                number: true
            }
        },
        messages: {
            campoResp1: {
                required: "Preencher"
            },
            campoResp2: {
                required: "Preencher"
            },
            campoResp3: {
                required: "Preencher"
            },
            campoResp4: {
                required: "Preencher"
            },
            campoResp5: {
                required: "Preencher"
            },
            campoResp6: {
                required: "Preencher"
            }
        }
    }
	)
});

$().ready(function () {
    var validator = $("#form4").bind("invalid-form.validate", function () {
    }).validate(
    {
        errorElement: "el",
        errorPlacement: function (error, element) {
            element.parent("td").next("td").html(error);
        },
        success: function (label) {
            label.addClass("glyphicon glyphicon-ok").removeClass("error").addClass("ok");
        },
        submitHandler: function (form) {
            form.submit();
        },
        rules: {
            campoResp7: {
                required: true,
                number: true
            },
            campoResp8: {
                required: true,
                number: true
            },
            campoResp9: {
                required: true,
                number: true
            },
            campoResp10: {
                required: true,
                number: true
            },
            campoResp11: {
                required: true,
                number: true
            },
            campoResp12: {
                required: true,
                number: true
            },
            campoResp13: {
                required: true,
                number: true
            },
            campoResp14: {
                required: true,
                number: true
            }
        },
        messages: {
            campoResp7: {
                required: "Preencher"
            },
            campoResp8: {
                required: "Preencher"
            },
            campoResp9: {
                required: "Preencher"
            },
            campoResp10: {
                required: "Preencher"
            },
            campoResp11: {
                required: "Preencher"
            },
            campoResp12: {
                required: "Preencher"
            },
            campoResp13: {
                required: "Preencher"
            },
            campoResp14: {
                required: "Preencher"
            }
        }
    }
	)
});