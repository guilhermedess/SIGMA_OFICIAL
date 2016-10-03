/*topico 2 - sub 2.1*/

$(document).ready(function () {
    $("#campoResp1").keyup(function () {
        var valor = $("#campoResp1").val().replace(/\D/g, "");
        valor = valor.replace(/(\d)(\d{8})$/, "$1.$2");
        valor = valor.replace(/(\d)(\d{5})$/, "$1.$2");
        valor = valor.replace(/(\d)(\d{2})$/, "$1,$2");
        $("#campoResp1").val(valor);
    })
    $("#campoResp2").keyup(function () {
        var valor = $("#campoResp2").val().replace(/[^a-z.]/g, '');
        $("#campoResp2").val(valor);
    })
    $("#campoResp3").keyup(function () {
        var valor = $("#campoResp3").val().replace(/[^a-z.]/g, '');
        $("#campoResp3").val(valor);
    })
    $("#campoResp4").keyup(function () {
        var valor = $("#campoResp4").val().replace(/[^a-z.]/g, '');
        $("#campoResp4").val(valor);
    })
    $("#campoResp5").keyup(function () {
        var valor = $("#campoResp5").val().replace(/[^a-z.]/g, '');
        $("#campoResp5").val(valor);
    })
    $("#campoResp6").keyup(function () {
        var valor = $("#campoResp6").val().replace(/[^0-9]+/g, '');
        $("#campoResp6").val(valor);
    })
});

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
		            required: true
		        },
		        campoResp3: {
		            required: true
		        },
		        campoResp4: {
		            required: true
		        },
		        campoResp5: {
		            required: true
		        }
		    },
		    messages: {
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
		        }
		    },
		    messages: {
		        campoResp6: {
		            required: "Preencher"
		        }

		    }
		}
	)
});