function Medalhas(x) {

    if (x >= 25 && x <= 49) {
        $("#medalhaBronze").attr("src", "/Content/img/Distribuicao/Bronze.png");
    } else {
        if (x >= 50 && x <= 74) {
            $("#medalhaBronze").attr("src", "/Content/img/Distribuicao/Bronze.png");
            $("#medalhaPrata").attr("src", "/Content/img/Distribuicao/Prata.png");
        } else {
            if (x >= 75 && x <= 99) {
                $("#medalhaBronze").attr("src", "/Content/img/Distribuicao/Bronze.png");
                $("#medalhaPrata").attr("src", "/Content/img/Distribuicao/Prata.png");
                $("#medalhaOuro").attr("src", "/Content/img/Distribuicao/Ouro.png");
            } else {
                if (x === 100) {
                    $("#medalhaBronze").attr("src", "/Content/img/Distribuicao/Bronze.png");
                    $("#medalhaPrata").attr("src", "/Content/img/Distribuicao/Prata.png");
                    $("#medalhaOuro").attr("src", "/Content/img/Distribuicao/Ouro.png");
                    $("#medalhaPlatina").attr("src", "/Content/img/Distribuicao/Platina.png");
                }
            }
        }
    }
}