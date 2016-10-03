/*topico 1 - sub 2*/

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
});

$().ready(function () {
    var validator = $("#form").bind("invalid-form.validate", function () {
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