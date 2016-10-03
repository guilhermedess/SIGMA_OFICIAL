/*topico 1 - sub 4.3*/

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
        var valor = $("#campoResp7").val().replace(/\D/g, "");
        $("#campoResp7").val(campoFloat(valor));
    })
    $("#campoResp8").keyup(function () {
        var valor = $("#campoResp8").val().replace(/\D/g, "");
        $("#campoResp8").val(campoFloat(valor));
    })
    $("#campoResp9").keyup(function () {
        var valor = $("#campoResp9").val().replace(/\D/g, "");
        $("#campoResp9").val(campoFloat(valor));
    })
    $("#campoResp10").keyup(function () {
        var valor = $("#campoResp10").val().replace(/[^0-9]+/g, '');
        $("#campoResp10").val(valor);
    })
    $("#campoResp11").keyup(function () {
        var valor = $("#campoResp11").val().replace(/\D/g, "");
        $("#campoResp11").val(campoFloat(valor));
    })
    $("#campoResp12").keyup(function () {
        var valor = $("#campoResp12").val().replace(/\D/g, "");
        $("#campoResp12").val(campoFloat(valor));
    })
    $("#campoResp13").keyup(function () {
        var valor = $("#campoResp13").val().replace(/\D/g, "");
        $("#campoResp13").val(campoFloat(valor));
    })
    $("#campoResp14").keyup(function () {
        var valor = $("#campoResp14").val().replace(/[^0-9]+/g, '');
        $("#campoResp14").val(valor);
    })
    $("#campoResp15").keyup(function () {
        var valor = $("#campoResp15").val().replace(/\D/g, "");
        $("#campoResp15").val(campoFloat(valor));
    })
    $("#campoResp16").keyup(function () {
        var valor = $("#campoResp16").val().replace(/\D/g, "");
        $("#campoResp16").val(campoFloat(valor));
    })
    $("#campoResp17").keyup(function () {
        var valor = $("#campoResp17").val().replace(/\D/g, "");
        $("#campoResp17").val(campoFloat(valor));
    })
    $("#campoResp18").keyup(function () {
        var valor = $("#campoResp18").val().replace(/[^0-9]+/g, '');
        $("#campoResp18").val(valor);
    })
    $("#campoResp19").keyup(function () {
        var valor = $("#campoResp19").val().replace(/\D/g, "");
        $("#campoResp19").val(campoFloat(valor));
    })
    $("#campoResp20").keyup(function () {
        var valor = $("#campoResp20").val().replace(/\D/g, "");
        $("#campoResp20").val(campoFloat(valor));
    })
    $("#campoResp21").keyup(function () {
        var valor = $("#campoResp21").val().replace(/\D/g, "");
        $("#campoResp21").val(campoFloat(valor));
    })
    $("#campoResp22").keyup(function () {
        var valor = $("#campoResp22").val().replace(/[^0-9]+/g, '');
        $("#campoResp22").val(valor);
    })
    $("#campoResp23").keyup(function () {
        var valor = $("#campoResp23").val().replace(/\D/g, "");
        $("#campoResp23").val(campoFloat(valor));
    })
    $("#campoResp24").keyup(function () {
        var valor = $("#campoResp24").val().replace(/\D/g, "");
        $("#campoResp24").val(campoFloat(valor));
    })
    $("#campoResp25").keyup(function () {
        var valor = $("#campoResp25").val().replace(/\D/g, "");
        $("#campoResp25").val(campoFloat(valor));
    })
    $("#campoResp26").keyup(function () {
        var valor = $("#campoResp26").val().replace(/\D/g, "");
        $("#campoResp26").val(campoFloat(valor));
    })
    $("#campoResp27").keyup(function () {
        var valor = $("#campoResp27").val().replace(/\D/g, "");
        $("#campoResp27").val(campoFloat(valor));
    })
    $("#campoResp28").keyup(function () {
        var valor = $("#campoResp28").val().replace(/\D/g, "");
        $("#campoResp28").val(campoFloat(valor));
    })
    $("#campoResp29").keyup(function () {
        var valor = $("#campoResp29").val().replace(/\D/g, "");
        $("#campoResp29").val(campoFloat(valor));
    })
    $("#campoResp30").keyup(function () {
        var valor = $("#campoResp30").val().replace(/\D/g, "");
        $("#campoResp30").val(campoFloat(valor));
    })
    $("#campoResp31").keyup(function () {
        var valor = $("#campoResp31").val().replace(/\D/g, "");
        $("#campoResp31").val(campoFloat(valor));
    })
    $("#campoResp32").keyup(function () {
        var valor = $("#campoResp32").val().replace(/\D/g, "");
        $("#campoResp32").val(campoFloat(valor));
    })
});

function campoFloat(valor) {
    valor = valor.replace(/(\d)(\d{8})$/, "$1.$2");
    valor = valor.replace(/(\d)(\d{5})$/, "$1.$2");
    valor = valor.replace(/(\d)(\d{2})$/, "$1,$2");

    return valor;
}

$().ready(function () {
    var validator = $("#form1").bind("invalid-form.validate", function () {
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
            }
        }
    }
    )
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
            campoResp6: {
                required: true,
                number: true
            },
            campoResp7: {
                required: true,
                maxlength: 8,
                minlength:4
            },
            campoResp8: {
                required: true,
                maxlength: 8,
                minlength: 4
            },
            campoResp9: {
                required: true,
                maxlength: 8,
                minlength: 4
            },
            campoResp10: {
                required: true,
                number: true
            },
            campoResp11: {
                required: true,
                maxlength: 8,
                minlength: 4
            },
            campoResp12: {
                required: true,
                maxlength: 8,
                minlength: 4
            },
            campoResp13: {
                required: true,
                maxlength: 8,
                minlength: 4
            },
            campoResp14: {
                required: true,
                number: true
            },
            campoResp15: {
                required: true,
                maxlength: 8,
                minlength: 4
            },
            campoResp16: {
                required: true,
                maxlength: 8,
                minlength: 4
            },
            campoResp17: {
                required: true,
                maxlength: 8,
                minlength: 4
            },
            campoResp18: {
                required: true,
                number: true
            },
            campoResp19: {
                required: true,
                maxlength: 8,
                minlength: 4
            },
            campoResp20: {
                required: true,
                maxlength: 8,
                minlength: 4
            },
            campoResp21: {
                required: true,
                maxlength: 8,
                minlength: 4
            },
            campoResp22: {
                required: true,
                number: true
            },
            campoResp23: {
                required: true,
                maxlength: 8,
                minlength: 4
            }
        },
        messages: {
            campoResp6: {
                required: "Preencher"
            },
            campoResp7: {
                required: "Preencher",
                maxlength: "Max 9.999,99",
                minlength: "Min x,xx"
            },
            campoResp8: {
                required: "Preencher",
                maxlength: "Max 9.999,99",
                minlength: "Min x,xx"
            },
            campoResp9: {
                required: "Preencher",
                maxlength: "Max 9.999,99",
                minlength: "Min x,xx"
            },
            campoResp10: {
                required: "Preencher"
            },
            campoResp11: {
                required: "Preencher",
                maxlength: "Max 9.999,99",
                minlength: "Min x,xx"
            },
            campoResp12: {
                required: "Preencher",
                maxlength: "Max 9.999,99",
                minlength: "Min x,xx"
            },
            campoResp13: {
                required: "Preencher",
                maxlength: "Max 9.999,99",
                minlength: "Min x,xx"
            },
            campoResp14: {
                required: "Preencher"
            },
            campoResp15: {
                required: "Preencher",
                maxlength: "Max 9.999,99",
                minlength: "Min x,xx"
            },
            campoResp16: {
                required: "Preencher",
                maxlength: "Max 9.999,99",
                minlength: "Min x,xx"
            },
            campoResp17: {
                required: "Preencher",
                maxlength: "Max 9.999,99",
                minlength: "Min x,xx"
            },
            campoResp18: {
                required: "Preencher"
            },
            campoResp19: {
                required: "Preencher",
                maxlength: "Max 9.999,99",
                minlength: "Min x,xx"
            },
            campoResp20: {
                required: "Preencher",
                maxlength: "Max 9.999,99",
                minlength: "Min x,xx"
            },
            campoResp21: {
                required: "Preencher",
                maxlength: "Max 9.999,99",
                minlength: "Min x,xx"
            },
            campoResp22: {
                required: "Preencher"
            },
            campoResp23: {
                required: "Preencher",
                maxlength: "Max 9.999,99",
                minlength: "Min x,xx"
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
            campoResp24: {
                required: true,
                maxlength: 8,
                minlength: 4
            },
            campoResp25: {
                required: true,
                maxlength: 8,
                minlength: 4
            },
            campoResp26: {
                required: true,
                maxlength: 8,
                minlength: 4
            },
            campoResp27: {
                required: true,
                maxlength: 8,
                minlength: 4
            },
            campoResp28: {
                required: true,
                maxlength: 8,
                minlength: 4
            },
            campoResp29: {
                required: true,
                maxlength: 8,
                minlength: 4
            },
            campoResp30: {
                required: true,
                maxlength: 8,
                minlength: 4
            },
            campoResp31: {
                required: true,
                maxlength: 8,
                minlength: 4
            },
            campoResp32: {
                required: true,
                maxlength: 8,
                minlength: 4
            }
        },
        messages: {
            campoResp24: {
                required: "Preencher",
                maxlength: "Max 9.999,99",
                minlength: "Min x,xx"
            },
            campoResp25: {
                required: "Preencher",
                maxlength: "Max 9.999,99",
                minlength: "Min x,xx"
            },
            campoResp26: {
                required: "Preencher",
                maxlength: "Max 9.999,99",
                minlength: "Min x,xx"
            },
            campoResp27: {
                required: "Preencher",
                maxlength: "Max 9.999,99",
                minlength: "Min x,xx"
            },
            campoResp28: {
                required: "Preencher",
                maxlength: "Max 9.999,99",
                minlength: "Min x,xx"
            },
            campoResp29: {
                required: "Preencher",
                maxlength: "Max 9.999,99",
                minlength: "Min x,xx"
            },
            campoResp30: {
                required: "Preencher",
                maxlength: "Max 9.999,99",
                minlength: "Min x,xx"
            },
            campoResp31: {
                required: "Preencher",
                maxlength: "Max 9.999,99",
                minlength: "Min x,xx"
            },
            campoResp32: {
                required: "Preencher",
                maxlength: "Max 9.999,99",
                minlength: "Min x,xx"
            }
        }
    }
    )
});