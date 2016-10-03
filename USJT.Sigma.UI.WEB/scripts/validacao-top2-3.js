/*topico 2 - sub 3*/

$(document).ready(function () {
    $("#campoResp1").keyup(function () {
        var valor = $("#campoResp1").val().replace(/[^0-9]+/g, '');
        $("#campoResp1").val(valor);
    })
    $("#campoResp2").keyup(function () {
        var valor = $("#campoResp2").val().replace(/[^0-9]+/g, '');
        $("#campoResp2").val(valor);
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
		            required: true
		        }
		    },
		    messages: {
		        campoResp1: {
		            required: "Preencher"
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
		        }
		    },
		    messages: {
		        campoResp2: {
		            required: "Preencher"
		        }
		    }
		}
        )
});