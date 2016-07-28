var tabela = $("#example").dataTable({
    "sDom": "<'dt-wrapper't><'dt-row dt-bottom-row'<'col-sm-6'i><'col-sm-6 text-right'p>>",
    "autoWidth": true,
    "iDisplayLength": 10,
    "aaData": [],
    "aoColumns": [
        { "sTitle": "ID", "mData": "Id", "sWidth": "10%" },
        { "sTitle": "Nome", "mData": "Nome", "sWidth": "40%" },
        { "sTitle": "Sobrenome", "mData": "Sobrenome", "sWidth": "30%" },
        { "sTitle": "CPF", "mData": "CPF", "sWidth": "20%" }
    ],
    "aaSorting": [],
    "oLanguage": {
        "sInfo": "_START_ a _END_ em _TOTAL_ " + "Clientes",
        "sInfoEmpty": "",
        "sEmptyTable": "Não clientes cadastrados",
        "sInfoFiltered": "",
        "sZeroRecords": "Não há registros para o filtro informado",
        "oPaginate": {
            "sFirst": "<<",
            "sLast": ">>",
            "sPrevious": "<",
            "sNext": ">"
        }
    }
});

$("#InscreverSe").on("click", function () {
    $.ajax({
        type: "POST",
        url: "/api/Registros/InscreverSe",
        data: JSON.stringify({
            WebHookUri: "http://localhost:53890/api/webhooks/incoming/custom",
            Secret: "12345678901234567890123456789012",
            Description: "Inscrição I4Pro",
            Filters: ["CriarCliente", "EditarCliente", "ExcluirCliente"]
        }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function () {
            alert("Inscrição realizada");
        },
        error: function (ex) {
            alert(ex.statusText);
        }
    });
});

$("#CancelarInscricao").on("click", function () {
    $.ajax({
        url: "/api/Registros/CancelarInscricao",
        type: "DELETE",
        traditional: true
    }).success(function () {
        alert("Inscrição cancelada");
    }).error(function (ex) {
        alert(ex.statusText);
    });
});

$.ajax({
    url: "/api/Cliente/PesquisarCliente",
    type: "GET",
    traditional: true
}).success(function (data) {
    if (data.length) {
        tabela.fnAddData(data);
    }
}).error(function (ex) {
    alert(ex.statusText);
});