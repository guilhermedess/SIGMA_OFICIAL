/*topico 2 - sub 2.2*/

$(document).ready(function () {
    $("#campoResp1").keyup(function () {
        var valor = $("#campoResp1").val().replace(/\D/g, "");
        $("#campoResp1").val(campoFloat(valor));
    })
    $("#campoResp2").keyup(function () {
        var valor = $("#campoResp2").val().replace(/\D/g, "");
        $("#campoResp2").val(campoFloat(valor));
    })
    $("#campoResp3").keyup(function () {
        var valor = $("#campoResp3").val().replace(/\D/g, "");
        $("#campoResp3").val(campoFloat(valor));
    })
    $("#campoResp4").keyup(function () {
        var valor = $("#campoResp4").val().replace(/\D/g, "");
        $("#campoResp4").val(campoFloat(valor));
    })
    $("#campoResp5").keyup(function () {
        var valor = $("#campoResp5").val().replace(/\D/g, "");
        $("#campoResp5").val(campoFloat(valor));
    })
    $("#campoResp6").keyup(function () {
        var valor = $("#campoResp6").val().replace(/\D/g, "");
        $("#campoResp6").val(campoFloat(valor));
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
		            maxlength: 8,
		            minlength: 4
		        }
		    },
		    messages: {
		        campoResp1: {
		            required: "Preencher",
		            maxlength: "Max 9.999,99",
		            minlength: "Min x,xx"
		        }
		    }
		}
	)
});

$().ready(function () {
    var validator = $("#form2").bind("invalid-form.validate", function () {
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
		        campoResp2: {
		            required: true,
		            maxlength: 8,
		            minlength: 4
		        },
		        campoResp3: {
		            required: true,
		            maxlength: 8,
		            minlength: 4
		        },
		        campoResp4: {
		            required: true,
		            maxlength: 8,
		            minlength: 4
		        },
		        campoResp5: {
		            required: true,
		            maxlength: 8,
		            minlength: 4
		        },
		        campoResp6: {
		            required: true,
		            maxlength: 8,
		            minlength: 4
		        }
		    },
		    messages: {
		        campoResp2: {
		            required: "Preencher",
		            maxlength: "Max 9.999,99",
		            minlength: "Min x,xx"
		        },
		        campoResp3: {
		            required: "Preencher",
		            maxlength: "Max 9.999,99",
		            minlength: "Min x,xx"
		        },
		        campoResp4: {
		            required: "Preencher",
		            maxlength: "Max 9.999,99",
		            minlength: "Min x,xx"
		        },
		        campoResp5: {
		            required: "Preencher",
		            maxlength: "Max 9.999,99",
		            minlength: "Min x,xx"
		        },
		        campoResp6: {
		            required: "Preencher",
		            maxlength: "Max 9.999,99",
		            minlength: "Min x,xx"
		        }
		    }
		}
        )
});