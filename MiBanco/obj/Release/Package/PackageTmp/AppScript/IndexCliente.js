

$tableCliente = $('#tablaCliente').dataTable({
    paging: true,
    ordering: false,
    searching: true,
    Processing: true,
    serverSide: true,
    paginate: true,
    ajax: {
        url: consultaPaginadaUrl,
        type: 'POST',
        data: function (d) {
            d.Nombre = 'lavadora'
        }
    },
    columns: [
        { 'data': 'Codigo', 'name': 'Codigo', 'sTitle': 'Codigo' },
        { 'data': "Nombre", 'name': 'Nombre', 'sTitle': 'Nombre' },
        { 'data': "Apellido", 'name': 'Apellido', 'sTitle': 'Apellido' },
        { 'data': "NumeroContacto", 'name': 'NumeroContacto', 'sTitle': 'Numero de Contacto' },
        { 'data': "Ocupacion", 'name': 'Ocupacion', 'sTitle': 'Ocupación' },
        { 'data': "Estado", 'name': 'Estado', 'sTitle': 'Estado' },
        {
            sTitle: "Opción",
            'data': 'Codigo',
            bSearchable: false,
            bSortable: false,
            class: 'center',
            "mRender": function (data) {
                var button = '<a class="" href="' + CreateClienteUrl + "?Codigo=" + data + '"> Editar Cliente ' + '</a>';
                return button;
            }
        }
    ],
    lengthMenu: [[5, 10, 25, 50], [5, 10, 25, 50]],
    Length: 5
    //oLanguage: { 'sUrl': dataTableIdiomaURL }
});