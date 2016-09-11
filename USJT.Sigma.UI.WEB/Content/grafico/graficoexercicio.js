function drawChartGfc_4_3_ex2() {
    var data = google.visualization.arrayToDataTable([
      ["Element", "Frequência", { role: "style" }],
      ["Branco 33", 33, "#b87333"],
      ["Preto 47", 47, "silver"],
      ["Azul 70", 70, "gold"],
      ["Vermelho 43", 43, "color: #e5e4e2"]
    ]);

    var view = new google.visualization.DataView(data);
    view.setColumns([0, 1,
                     {
                         calc: "stringify",
                         sourceColumn: 1,
                         type: "string",
                         role: "annotation"
                     },
                     2]);

    var options = {
        title: "Frequência Acumulada Percentual(%)",
        width: 600,
        height: 300,
        bar: { groupWidth: "95%" },
        legend: { position: "none" },
    };
    var chart = new google.visualization.ColumnChart(document.getElementById("gfc_4_3_ex2"));
    chart.draw(view, options);
}

function drawChartGfc_4_3_ex2_2() {
    var data = google.visualization.arrayToDataTable([
      ["Element", "Frequência", { role: "style" }],
      ["Branco 99", 99, "#b87333"],
      ["Preto 32", 32, "silver"],
      ["Azul 90", 90, "gold"],
      ["Vermelho 43", 43, "color: #e5e4e2"]
    ]);

    var view = new google.visualization.DataView(data);
    view.setColumns([0, 1,
                     {
                         calc: "stringify",
                         sourceColumn: 1,
                         type: "string",
                         role: "annotation"
                     },
                     2]);

    var options = {
        title: "Frequência Acumulada Percentual(%)",
        width: 600,
        height: 300,
        bar: { groupWidth: "95%" },
        legend: { position: "none" },
    };
    var chart = new google.visualization.ColumnChart(document.getElementById("gfc_4_3_ex2_2"));
    chart.draw(view, options);
}

function drawChartGfc_4_3_ex2_3() {
    var data = google.visualization.arrayToDataTable([
      ["Element", "Frequência", { role: "style" }],
      ["Branco 33", 33, "#b87333"],
      ["Preto 47", 47, "silver"],
      ["Azul 70", 70, "gold"],
      ["Vermelho 100", 100, "color: #e5e4e2"]
    ]);

    var view = new google.visualization.DataView(data);
    view.setColumns([0, 1,
                     {
                         calc: "stringify",
                         sourceColumn: 1,
                         type: "string",
                         role: "annotation"
                     },
                     2]);

    var options = {
        title: "Frequência Acumulada Percentual(%)",
        width: 600,
        height: 300,
        bar: { groupWidth: "95%" },
        legend: { position: "none" },
    };
    var chart = new google.visualization.ColumnChart(document.getElementById("gfc_4_3_ex2_3"));
    chart.draw(view, options);
}

function drawChartGfc_4_3_ex2_4() {
    var data = google.visualization.arrayToDataTable([
      ["Element", "Frequência", { role: "style" }],
      ["Branco 43", 43, "#b87333"],
      ["Preto 57", 57, "silver"],
      ["Azul 69", 69, "gold"],
      ["Vermelho 90", 90, "color: #e5e4e2"]
    ]);

    var view = new google.visualization.DataView(data);
    view.setColumns([0, 1,
                     {
                         calc: "stringify",
                         sourceColumn: 1,
                         type: "string",
                         role: "annotation"
                     },
                     2]);

    var options = {
        title: "Frequência Acumulada Percentual(%)",
        width: 600,
        height: 300,
        bar: { groupWidth: "95%" },
        legend: { position: "none" },
    };
    var chart = new google.visualization.ColumnChart(document.getElementById("gfc_4_3_ex2_4"));
    chart.draw(view, options);
}

function drawChartGfc_4_3_ex4() {
    var data = google.visualization.arrayToDataTable([
      ["Element", "Frequência", { role: "annotation" }],
      ["20 [131; 141[", 20, "20%"],
      ["40 [141; 151[", 40, "silver"],
      ["53.33 [151; 161[", 53.33, "gold"],
      ["100 [161; 171[", 100, "color: #e5e4e2"]
    ]);

    var view = new google.visualization.DataView(data);
    view.setColumns([0, 1,
                     {
                         calc: "stringify",
                         sourceColumn: 1,
                         type: "string",
                         role: "annotation"
                     },
                     2]);

    var options = {
        title: "Frequência Acumulada Percentual(%)",
        width: 600,
        height: 300,
        bar: { groupWidth: "95%" },
        legend: { position: "none" },
    };
    var chart = new google.visualization.ColumnChart(document.getElementById("gfc_4_3_ex4"));
    chart.draw(view, options);
}

function drawChartGfc_5_1_ex1() {
    // Create the data table.
    var data = new google.visualization.DataTable();
    data.addColumn('string', 'Titulo');
    data.addColumn('number', 'Subtitulo');
    data.addRows([
        ['Azul', 15],
        ['Vermelho', 21],
        ['Laranja', 40],
        ['Verde', 15],
        ['Roxo', 9]
    ]);

    // Set chart options
    var options = {
        'backgroundColor.stroke': '#2c3e50', //Default: '#666'
        //'backgroundColor': '#bdc3c7', //Default: 'white'
        'legend': 'left',
        'title': 'Gráfico 1',
        'width': 600,
        'height': 300
    };

    //Instanciar e desenhar o seu gráfico, passando em algumas opções.
    var chart = new google.visualization.PieChart(document.getElementById('gfc_5_1_ex1'));
    chart.draw(data, options);
}

function drawChartGfc_5_1_ex1_2() {
    var data = google.visualization.arrayToDataTable([
      ["Element", "Frequência", { role: "style" }],
      ["Azul 15", 15, "#b87333"],
      ["Vermelho 21", 21, "silver"],
      ["Laranja 40", 40, "gold"],
      ["Verde 15", 15, "gold"],
      ["Roxo 9", 9, "color: #e5e4e2"]
    ]);

    var view = new google.visualization.DataView(data);
    view.setColumns([0, 1,
                     {
                         calc: "stringify",
                         sourceColumn: 1,
                         type: "string",
                         role: "annotation"
                     },
                     2]);

    var options = {
        title: "Gráfico 2",
        width: 600,
        height: 300,
        bar: { groupWidth: "95%" },
        legend: { position: "none" },
    };
    var chart = new google.visualization.ColumnChart(document.getElementById("gfc_5_1_ex1_2"));
    chart.draw(view, options);
}

function drawChartGfc_5_1_ex1_3() {
    //montando o array com os dados
    var data = google.visualization.arrayToDataTable([
      ['Ano', 'Frequência'],
      ['Azul', 15],
      ['Vermelho', 21],
      ['Laranja', 40],
      ['Verde', 15],
      ['Roxo', 9]
    ]);
    //opçoes para o gráfico barras
    //var options = {
    //    title: 'Grafico 3',
    //    width: 600,
    //    height: 300,
    //    vAxis: { title: 'Anos', titleTextStyle: { color: 'red' } }//legenda vertical
    //};
    ////instanciando e desenhando o gráfico barras
    //var barras = new google.visualization.BarChart(document.getElementById('gfc_5_1_ex1_3'));
    //barras.draw(data, options);
    //opções para o gráfico linhas
    var options1 = {
        title: 'Grafico 3',
        hAxis: { title: 'Gráfico', titleTextStyle: { color: 'red' } }//legenda na horizontal
    };
    //instanciando e desenhando o gráfico linhas
    var linhas = new google.visualization.LineChart(document.getElementById('gfc_5_1_ex1_3'));
    linhas.draw(data, options1);

}

function drawChartGfc_5_1_ex1_4() {
    //montando o array com os dados
    var data = google.visualization.arrayToDataTable([
      ['Ano', 'Frequência'],
      ['Azul', 15],
      ['Vermelho', 21],
      ['Laranja', 40],
      ['Verde', 15],
      ['Roxo', 9]
    ]);
    //opçoes para o gráfico barras
    var options = {
        title: 'Gráfico 4',
         width: 600,
        height: 300,
        vAxis: { title: 'Gráfico', titleTextStyle: { color: 'red' } }//legenda vertical
    };
    ////instanciando e desenhando o gráfico barras
    var barras = new google.visualization.BarChart(document.getElementById('gfc_5_1_ex1_4'));
    barras.draw(data, options);
    //opções para o gráfico linhas
    //var options1 = {
    //    title: 'Performance',
    //    hAxis: { title: 'Anos', titleTextStyle: { color: 'red' } }//legenda na horizontal
    //};
    //instanciando e desenhando o gráfico linhas
    //var linhas = new google.visualization.LineChart(document.getElementById('gfc_5_1_ex1_4'));
    //linhas.draw(data, options1);

}

function drawChartGfc_5_1_ex2() {
    var data = google.visualization.arrayToDataTable([
      ["Element", "Frequência", { role: "style" }],
      ["39", 1, "#b87333"],
      ["38", 10, "silver"],
      ["37", 3, "gold"],
      ["36", 5, "gold"],
      ["35", 6, "gold"]
      
    ]);

    var view = new google.visualization.DataView(data);
    view.setColumns([0, 1,
                     {
                         calc: "stringify",
                         sourceColumn: 1,
                         type: "string",
                         role: "annotation"
                     },
                     2]);

    var options = {
        title: "Frequência  por pontos ou valores",
        width: 600,
        height: 300,
        bar: { groupWidth: "95%" },
        legend: { position: "none" },
        vAxis: { title: 'Frequência', titleTextStyle: { color: 'blue' } },//legenda vertical
        hAxis: { title: 'Tamanho de calçados', titleTextStyle: { color: 'blue' } }//legenda na horizontal
    };
    var chart = new google.visualization.ColumnChart(document.getElementById("gfc_5_1_ex2"));
    chart.draw(view, options);
}

function drawChartGfc_5_1_ex3() {
    var data = google.visualization.arrayToDataTable([
      ["Element", "Nº pessoas", { role: "style" }],
      ["7", 1, "#b87333"],
      ["8", 2, "silver"],
      ["9", 5, "gold"],
      ["10", 8, "gold"],
      ["11", 3, "gold"],
      ["12", 1, "gold"]
    ]);

    var view = new google.visualization.DataView(data);
    view.setColumns([0, 1,
                     {
                         calc: "stringify",
                         sourceColumn: 1,
                         type: "string",
                         role: "annotation"
                     },
                     2]);

    var options = {
        title: "Frequência  por pontos ou valores",
        width: 600,
        height: 300,
        bar: { groupWidth: "95%" },
        legend: { position: "none" },
        vAxis: { title: 'Frequência', titleTextStyle: { color: 'blue' } },//legenda vertical
        hAxis: { title: 'Nº de pessoas com diabetes', titleTextStyle: { color: 'blue' } }//legenda na horizontal
    };
    var chart = new google.visualization.ColumnChart(document.getElementById("gfc_5_1_ex3"));
    chart.draw(view, options);
}

function drawChartGfc_5_1_ex4() {
    var data = google.visualization.arrayToDataTable([
      ["Element", "Alunos", { role: "style" }],
      ["1º 546", 546, "#b87333"],
      ["2º 328", 328, "silver"],
      ["3º 280", 280, "gold"],
      ["4º 120", 120, "gold"]
    ]);

    var view = new google.visualization.DataView(data);
    view.setColumns([0, 1,
                     {
                         calc: "stringify",
                         sourceColumn: 1,
                         type: "string",
                         role: "annotation"
                     },
                     2]);

    var options = {
        title: "Frequência  por pontos ou valores",
        width: 600,
        height: 300,
        bar: { groupWidth: "95%" },
        legend: { position: "none" },
        vAxis: { title: 'Alunos Matriculados', titleTextStyle: { color: 'blue' } },//legenda vertical
        hAxis: { title: 'Trimestre', titleTextStyle: { color: 'blue' } }//legenda na horizontal
    };
    var chart = new google.visualization.ColumnChart(document.getElementById("gfc_5_1_ex4"));
    chart.draw(view, options);
}