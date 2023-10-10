
var $divMessages;

 
 $(".Mayuscula").keydown( function(){  
    var value = $(this).val();    
        if(value.length === 1){
            $(this).val(value.toUpperCase());
        }    
   }); 
   

$(".Telefono").mask("999-999-9999");

$(".Cedula").mask("999-9999999-9");
   
function MostrarMensajeSuccess($div, $message)
{   
      $('html, body').animate({scrollTop:0}, 'slow');
    $divMessages = $div;

    $divMessages.html('');

    var $divToApennd = '<div class="alert alert-success alert-dismissable" >'
                       +'<button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>'
                       +'<span> '+ $message +' </span>'
                       + '</div>';
    $divMessages.append($divToApennd);
    $divMessages.show();
    setTimeout("cerrar()", 5000);
}

function MostrarMensajeError($div, $message)
{
    $('html, body').animate({scrollTop:0}, 'slow');
   var $divMessages = $div;

    $divMessages.html('');
    var $divToApennd = '<div class="alert alert-danger alert-dismissable" >'
                       + '<button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>'
                       + '<span> ' + $message + ' </span>'
                       + '</div>';

    $divMessages.append($divToApennd);
    $divMessages.show();


}

function MostrarMensajeInfo($div, $message)
{
     $('html, body').animate({scrollTop:0}, 'slow');
    $divMessages = $div;

    $divMessages.html('');
    var $divToApennd = '<div class="alert alert-info alert-dismissable" >'
                       + '<button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>'
                       + '<span> ' + $message + ' </span>'
                       + '</div>';

    $divMessages.append($divToApennd);
    $divMessages.show();
    setTimeout("cerrar()", 5000);

}

//Cierra todos los alert de notificaciones
function cerrar() {
    $divMessages.hide();
}


$(document).ready(function() {
	
    //$("form").on("submit", function () {
    //    $.blockUI({
    //        css: {
    //            border: 'none',
    //            padding: '15px',
    //            backgroundColor: '#000',
    //            '-webkit-border-radius': '10px',
    //            '-moz-border-radius': '10px',
    //            opacity: .5,
    //            color: '#fff'
    //        },
    //        message: $(".MesajeEspera")
    //    });
    //});

   
	
});

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

function getFechaActual()
{
        var today = new Date();
        var dd = today.getDate();
        var mm = today.getMonth()+1; //January is 0!
        var yyyy = today.getFullYear();

        if(dd<10) {
            dd='0'+dd
        } 

        if(mm<10) {
            mm='0'+mm
        } 

        today = dd+'/'+mm+'/'+yyyy;

        return today;
    
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


function Eliminar(action, id, divMessage)
{
      bootbox.dialog({
        message:getFormulario(),
        title: "<div style='text-align:center; color:blue' > <h3>Muebleria Yovani </h3> </div> ",
        buttons: {
            danger: {
                label: "No Cancelar",
                className: "btn-primary",
                callback: function () {
                    // Example.show("uh oh, look out!");
                }
            },
            main: {
                label: "Confirmar",
                className: "btn-danger",
                callback: function () {
                  var funcion = action;
                  var codigo = id;
                  var div=divMessage;
                   ejecutarAction(funcion,codigo,div);                   
                }
            }
        }
    });
}



function ejecutarAction(action,id,contentDivMessage)
{
      var IsFormValid = $("#frmConfirmarUsuario").valid();
      var datos = $("#frmConfirmarUsuario").formSerializeToJson();

      var nombreUsuario = $("#txtNombreUsuario").val();
      var clave = $("#txtClave").val();

        if (IsFormValid) {

            $.ajax({
                data:{
                    NombreUsuario: nombreUsuario
                   ,Clave :clave
                },
                type: "POST",
                dataType: "json",
                url: ConfirmarUsuarioUrl,
                beforeSend: function (xhr) {

                }
            })
            .done(function (data, textStatus, jqXHR) {

                debugger;

                var datos = data;

                if (datos.Success) {
                    
                        if(id !== undefined && id !== null)
                        {
                            action(id);
                        }else{
                            action();
                        }
                    }else{
                        MostrarMensajeError(contentDivMessage,datos.Message);	
                    }

                if (console && console.log) {
                    console.log("La solicitud se ha completado correctamente.");
                }

            }).fail(function (jqXHR, textStatus, errorThrown) {

          });//Fin de la funcion del ajaxError

        }else{
            MostrarMensajeError(contentDivMessage, "No se ha podido recopilar informacion suficiente para realizar la operación");
        }
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














