
var $divMessages;

 


$(".Telefono").mask("999-999-9999");

$(".Cedula").mask("999-9999999-9");

$(".NumeroTarjeta").mask("9999-9999-9999-9999");
   


//Cierra todos los alert de notificaciones
function cerrar() {
    $divMessages.hide();
}




$(document).ajaxStart(function () {
    $.blockUI({
        css: {
            border: 'none',
            padding: '15px',
            backgroundColor: '#000',
            '-webkit-border-radius': '10px',
            '-moz-border-radius': '10px',
            opacity: .5,
            color: '#fff'
        },
        message: $(".MesajeEspera")
    });
});

$(document).ajaxComplete(function () {
    $.unblockUI();
});

$(document).ajaxStop(function () {
    $.unblockUI();
});

$(document).ajaxError(function (event, jqxhr, settings, thrownError) {
    $.unblockUI();
    if (jqxhr.responseText !== "" && jqxhr.responseText !== null) {
        var arrayResult = JSON.parse("[" + jqxhr.responseText + "]");

        if (arrayResult[0]['LogOnUrl'] !== undefined && arrayResult[0]['LogOnUrl'] !== null) {
            if (arrayResult[0]['LogOnUrl'] === "/Usuario/ErrorView") {
                toastr.warning(arrayResult[0]['Error']);
            }
        }
    }
});


function MuestraMensajeEspera($div)
{

	var $divEspera = $div;
	
	 $(document).ajaxStart(function () {

      $.blockUI({css: { 
            border: 'none', 
            padding: '15px', 
            backgroundColor: '#000', 
            '-webkit-border-radius': '10px', 
            '-moz-border-radius': '10px', 
            opacity: .5, 
            color: '#fff' 
        },
            message: $divEspera
        });

    });

    $(document).ajaxComplete(function () {   	
        $.unblockUI();
    });
	
	
}



$.fn.formSerializeToJson = function(){
    
   var data = {};

    var controls = this.serializeArray();

    $.each(controls, function () {
        
        if (data[this.id] !== undefined) {
            
            if (!data[this.id].push) {
                data[this.name] = [data[this.id]];
            }
            data[this.name].push(this.value || '');
            
        } else {
            data[this.name] = this.value || '';
        }
    });

    return data;    
}

function GetMessageFromList(Mensajes) {
    var mnsj = "";

    if (Mensajes !== undefined && Mensajes !== null)
    {
        for (i = 0; i < Mensajes.length; i++) {
            mnsj += Mensajes[i];
        }
    }

    //Mensajes.forEach(function (element) {
    //    mnsj += element;
    //});
    return mnsj;
}

function ShowMessage(Result, SuccesFunction, FailFunction)
{

    debugger;

    var mensaje = GetMessageFromList(Result.Messages);

    if (Result.Success) {

        if (SuccesFunction !== null && SuccesFunction !== undefined)
            SuccesFunction(Result);
        toastr.success(mensaje, "Completado");
    } else {
        if (FailFunction !== null && FailFunction !== undefined)
            FailFunction();

        if (Result.Warning)
            toastr.warning(mensaje, "Alerta");

        if (Result.Warning === false)
            toastr.error(mensaje, "Error");
    }
}

function GetPartialViewResultConParametros(Url, Content, Modal, Parametros)
{
    debugger;

    $.ajax({
        data: Parametros,
        type: "POST",
        dataType: "html",
        url: Url,
        beforeSend: function (xhr) {
        }
    }).done(function (data, textStatus, jqXHR) {

        Content.html('');
        Content.html(data);

        if (Modal !== null && Modal !== undefined)
            Modal.modal('show');

        $('form').removeData('validator');
        $('form').removeData('unobtrusiveValidation');
        ($.validator).unobtrusive.parse('form');

        $(".Fecha").datepicker({
            inline: true,
            dateFormat: 'dd-mm-yy'
        });

    }).fail(function (jqXHR, textStatus, errorThrown) {

        toastr.error(errorThrown.message, "Error");

    });//Fin del ajax
}














