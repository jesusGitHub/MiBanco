


$(document).ready(function () {

    debugger;

    var Estado = $("#EstadoActivo").val();
    var value = $("#Codigo").val();

    if (Estado == false || Estado == "false" || Estado == "False") {

        if (value != '0') {
            $("#Ajaxformcliente input[type='text']").prop('readonly', true);
            $("#Ajaxformcliente input[type='number']").prop('readonly', true);
        }

    } else {
        $("#Ajaxformcliente input[type='text']").prop('readonly', false);
        $("#Ajaxformcliente input[type='number']").prop('readonly', false);
    }

});



function onSucess(Result) {

    debugger;
    var Value = $("#Codigo").val();
    ShowMessage(Result);


    if (Result.Success) {
        if (Value <= 0)
            document.getElementById("Ajaxformcliente").reset();
    }
}


function onfaile(Result) {
    ShowMessage(Result);
}

function onActivarUuarioSucess(Result) {
    debugger;

    ShowMessage(Result);


    if (Result.Success) {

        document.location.reload();

    }
}



$(document).on("click", "#btnAgregarTarjeta", function () {

    var value = $("#Codigo").val();

    var $modalTarjeta = $("#modalTarjeta");
    var ContentTarjeta = $("#contentPartialTarjeta");
    var datos = { CodigoCliente: value };

    GetPartialViewResultConParametros(GetPartialTarjetaUrl, ContentTarjeta, $modalTarjeta, datos);
});

$(document).on("click", ".btnEditarTarjeta", function () {

    var value = $("#Codigo").val();
    var tarjetaCodigo = $(this).attr("data-Id");

    var $modalTarjeta = $("#modalTarjeta");
    var ContentTarjeta = $("#contentPartialTarjeta");
    var datos = { CodigoCliente: value, CodigoTarjeta: tarjetaCodigo };

    GetPartialViewResultConParametros(GetPartialTarjetaUrl, ContentTarjeta, $modalTarjeta, datos);
});

function onTarjetaSucess(Result) {

    debugger;

    ShowMessage(Result);

    var PartialVew = $("#contentPartialListadoTarjeta")

    if (Result.Success) {

        document.getElementById("Ajaxformtarjeta").reset();
        var value = $("#Codigo").val();
        var datos = { CodigoCliente: value };
        $("#modalTarjeta").modal('hide');

        GetPartialViewResultConParametros(GetPartialListadoTarjetaUrl, PartialVew, null, datos);

    }
}

function onTarjetafaile(Result) {

    ShowMessage(Result);
    $("#modalTarjeta").modal('hide');
}
