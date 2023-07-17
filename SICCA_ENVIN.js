

/*USO DE LAS CSS DESDE AQUI: https://www.w3schools.com/Css/css3_variables_javascript.asp 
        <script>
        // Get the root element
        var r = document.querySelector(':root');

        // Create a function for getting a variable value
        function myFunction_get() {
          // Get the styles (properties and values) for the root
          var rs = getComputedStyle(r);
          // Alert the value of the --blue variable
          alert("The value of --blue is: " + rs.getPropertyValue('--blue'));
        }

        // Create a function for setting a variable value
        function myFunction_set() {
          // Set the value of variable --blue to another value (in this case "lightblue")
          r.style.setProperty('--blue', 'lightblue');
        }
        </script>
 * 
 * */
var r = document.querySelector(':root');
var elementosCSS = getComputedStyle(r);

var color_estadoSinValidar = elementosCSS.getPropertyValue('--color_estadoSinValidar');
var color_estadoValidado = elementosCSS.getPropertyValue('--color_estadoValidado');
var color_estadoRegistradoEnEnvin = elementosCSS.getPropertyValue('--color_estadoRegistradoEnEnvin');
var color_estadoBorrado = elementosCSS.getPropertyValue('--color_estadoBorrado');

var pacienteActual = getPaciente();




function getEstadoInforme   (estadoInforme) {
    var estadoInformeRes = "";
    switch (estadoInforme) {
        case 1:
            estadoInformeRes = "Sin Validar";
            break;
        case 2:
            estadoInformeRes = "Validado";
            break;
        case 3:
            estadoInformeRes = "Registrado en ENVIN";
            break;
        default:
            estadoInformeRes = null;
    }
    return estadoInformeRes;
}


function addHTML_Botones_navegacion(idPaginaActiva) {//idpagina activa es para poner la clase active en el boton de la pagina actual -> 1:ficha de ingreso, 2: fact riesgo individual, 3:antibioticos, 4: infecciones
    var str = "";
    if (idPaginaActiva == 1) {
         str = '<div class="btn-group btn-group-sm" role="group">'
            + '    <a  id="botonesLink_FichaDeIngreso" class="btn btn-navegacionSilink me-1 botonesLink active" onclick="onClick_FichaDeIngreso()" href="#" aria-current="page">Ficha De Ingreso</a>'
            + '    <a  id="botonesLink_ViewFactoresRiesgoIndividual" class="btn btn-navegacionSilink me-1 botonesLink" onclick="onClick_ViewFactoresRiesgoIndividual()" href="#">Factores de riesgo individuales</a>'
            + '    <a  id="botonesLink_ViewAntibioticos" class="btn btn-navegacionSilink me-1 botonesLink" onclick="onClick_ViewAntibioticos()" href="#">Antibióticos</a>'
            + '    <a  id="botonesLink_Infecciones" class="btn btn-navegacionSilink me-1 botonesLink" onclick="onClick_Infecciones()" href="#">Infecciones</a>'
            + '</div>';
    }
    if (idPaginaActiva == 2) {
         str = '<div class="btn-group btn-group-sm" role="group">'
            + '    <a  id="botonesLink_FichaDeIngreso" class="btn btn-navegacionSilink me-1 botonesLink" onclick="onClick_FichaDeIngreso()" href="#" aria-current="page">Ficha De Ingreso</a>'
             + '    <a  id="botonesLink_ViewFactoresRiesgoIndividual" class="btn btn-navegacionSilink me-1 botonesLink active" onclick="onClick_ViewFactoresRiesgoIndividual()" href="#">Factores de riesgo individuales</a>'
             + '    <a  id="botonesLink_ViewAntibioticos" class="btn btn-navegacionSilink me-1 botonesLink" onclick="onClick_ViewAntibioticos()" href="#">Antibióticos</a>'
            + '    <a  id="botonesLink_Infecciones" class="btn btn-navegacionSilink me-1 botonesLink" onclick="onClick_Infecciones()" href="#">Infecciones</a>'
            + '</div>';
    }
    if (idPaginaActiva == 3) {
         str = '<div class="btn-group btn-group-sm" role="group">'
            + '    <a  id="botonesLink_FichaDeIngreso" class="btn btn-navegacionSilink me-1 botonesLink" onclick="onClick_FichaDeIngreso()" href="#" aria-current="page">Ficha De Ingreso</a>'
            + '    <a  id="botonesLink_ViewFactoresRiesgoIndividual" class="btn btn-navegacionSilink me-1 botonesLink" onclick="onClick_ViewFactoresRiesgoIndividual()" href="#">Factores de riesgo individuales</a>'
             + '    <a  id="botonesLink_ViewAntibioticos" class="btn btn-navegacionSilink me-1 botonesLink active" onclick="onClick_ViewAntibioticos()" href="#">Antibióticos</a>'
            + '    <a  id="botonesLink_Infecciones" class="btn btn-navegacionSilink me-1 botonesLink" onclick="onClick_Infecciones()" href="#">Infecciones</a>'
            + '</div>';
    }
    if (idPaginaActiva == 4) {
         str = '<div class="btn-group btn-group-sm" role="group">'
            + '    <a  id="botonesLink_FichaDeIngreso" class="btn btn-navegacionSilink me-1 botonesLink" onclick="onClick_FichaDeIngreso()" href="#" aria-current="page">Ficha De Ingreso</a>'
            + '    <a  id="botonesLink_ViewFactoresRiesgoIndividual" class="btn btn-navegacionSilink me-1 botonesLink" onclick="onClick_ViewFactoresRiesgoIndividual()" href="#">Factores de riesgo individuales</a>'
             + '    <a  id="botonesLink_ViewAntibioticos" class="btn btn-navegacionSilink me-1 botonesLink" onclick="onClick_ViewAntibioticos()" href="#">Antibióticos</a>'
             + '    <a  id="botonesLink_Infecciones" class="btn btn-navegacionSilink me-1 botonesLink active" onclick="onClick_Infecciones()" href="#">Infecciones</a>'
            + '</div>';
    }
    return str;
}

function generarLeyenda() {
    var str = '<h5><span class="badge rounded-pill spanEstadoSinValidar me-1" id="spanSinValidar">Sin Validar</span></h5>'
        + '<h5><span class="badge rounded-pill spanEstadoValidado me-1" id="spanValidado">Validado</span></h5> '
        + '<h5><span class="badge rounded-pill spanEstadoRegistrado me-1" id="spanRegistrado">Registrado en ENVIN</span></h5>';
    return str;
}


function fDoneSET_wsENVIN_ActualizarEstadoPaciente (data) {
   // alert("  wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ID  " + data.wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ID);
    if (data.EsCorrecto) {
        var est = getEstadoInforme(data.wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ID);
        setEstadoInforme(est);//seteamos el nuevo estado del informe del paciente
        //borramos el titulo del paciente y ponemos el nuevo estado de informe
        //alert(est);
        $('#barra_izquierda').empty("");
        $('#barra_izquierda').append(generarDatosPacienteTitulo_Estado(pacienteActual, est));
        
    } else {
        alert("Error actualizacion estado del paciente: " + data.MensajeError);
    }
}



function generarDatosPacienteTitulo(pacienteActual) {
    
    var str = '<h6 id="LTitulo" style="margin-bottom: 0rem; font-family: Calibri;">' + pacienteActual.unidad + ' |  NHC: ' + pacienteActual.NHC + ' | ' + pacienteActual.Iniciales + ' | Estado Informe: ' + pacienteActual.estadoInforme + '</h6>';
    
    return str;
}

function generarDatosPacienteTitulo_Estado(pacienteActual,EstadoInforme) {
 
    var str = '<h6 id="LTitulo" style="margin-bottom: 0rem; font-family: Calibri;">' + pacienteActual.unidad + ' |  NHC: ' + pacienteActual.NHC + ' | ' + pacienteActual.Iniciales + ' | Estado Informe: ' + EstadoInforme + '</h6>';

    return str;
}

/******* REGISTRO-DESREGISTRO DEL ENVIN */
//generacion html
function generarBotonRegistroEstadoEnvin(pacienteActual) {
    var str = '<button id="btnRegistroENVIN" type="button" class="btn botonPrincipal btn-sm" onclick="onClickBotonRegistroEnvin(pacienteActual.wsENVIN_Web_Pacientes_ID)" '
        + ' data-bs-toggle="tooltip" data-bs-placement="bottom"  data-bs-custom-class="custom-tooltip"'
        + ' data-bs-title="Este botón sirve para marcar o desmarcar el estado del informe del paciente como `Registrado en ENVIN`. Se deberá clicar cuando ya toda la información sea validada y se tenga que trasladar al ENVIN" >'
        + 'Registrar en ENVIN</button> '
    return str;
}

function generarBotonDeshacerRegistroEstadoEnvin(pacienteActual) {
    var str = '<button id="btnDeshacerRegistroENVIN" type="button" class="btn botonPrincipal btn-sm" onclick="onClickBotonDesRegistroEnvin(pacienteActual.wsENVIN_Web_Pacientes_ID)" '
        + ' data-bs-toggle="tooltip" data-bs-placement="bottom"  data-bs-custom-class="custom-tooltip"'
        + ' data-bs-title="Este botón sirve para marcar o desmarcar el estado del informe del paciente como `Registrado en ENVIN`. Se deberá clicar cuando ya toda la información sea validada y se tenga que trasladar al ENVIN">'
        + 'Desregistrar en ENVIN</button> '

    return str;
}

//AUXILIARES
function ocultarDesocultarBotonesRegistroEnvin() {
    /* alert("cambioVisualizacionRegistroENVIN");*/
    //recorremos todos los controles de la pantalla:
    var pacienteActual = getPaciente();

    if (pacienteActual.estadoInforme == 'Registrado en ENVIN') {//SI ESTA REGISTRADO EN EL ENVIN SE DESHABILITA TODA LA WEB!
        

        //AQUI MOSTRAR OCULTAR EL DE REGISTRAR Y ENSEÑAR EL NUEVO BOTON DE DESHACER
        $("#btnRegistroENVIN").hide();
        $("#btnDeshacerRegistroENVIN").show();
    }
    if (pacienteActual.estadoInforme == 'Validado') {//SI esta validado, se muestra todo y se muestra el boton de registrar

       
        //AQUI MOSTRAR OCULTAR EL DE REGISTRAR Y ENSEÑAR EL NUEVO BOTON DE DESHACER
        $("#btnRegistroENVIN").show();
        $("#btnDeshacerRegistroENVIN").hide();
    }
    if (pacienteActual.estadoInforme == 'Sin Validar') {//SI esta validado, se muestra todo y se muestra el boton de registrar

        //AQUI MOSTRAR OCULTAR EL DE REGISTRAR Y ENSEÑAR EL NUEVO BOTON DE DESHACER
        $("#btnRegistroENVIN").show();
        $("#btnDeshacerRegistroENVIN").hide();
    }


}
function cambioVisualizacionRegistroENVIN() {
   /* alert("cambioVisualizacionRegistroENVIN");*/
    //recorremos todos los controles de la pantalla:
    var pacienteActual = getPaciente();
 
    if (pacienteActual.estadoInforme == 'Registrado en ENVIN') {//SI ESTA REGISTRADO EN EL ENVIN SE DESHABILITA TODA LA WEB!
        $(".controlesARevisar").each(function (i) {

            var id = $(this).attr('id');
            //alert("revision:  " + id);
            //alert("attrr  "+$('#' + id).attr('data-tipo'));
            //para los checkbox
            $('#' + id + 'Si').attr('disabled', true);
            $('#' + id + 'No').attr('disabled', true);

            //para los select y inputs
            $('#' + id).attr('disabled', true);

           
            //para los botones
            $('#' + id).addClass('disabled');
        });
        //AQUI PINTAR EL CIRCULITO DE VALIDACION A Registrado en ENVIN'
        var estilosEstado = obtenerEstiloValidacion(3);
        /* alert("revision:  " + arrayIds);*/
       
        $(".span_validacion").each(function (i) {
            var id = $(this).attr('id');
           /* alert(id + "   " + $('#' + id).css('background-color'));*/
            if ($('#' + id).css('background-color') != 'rgb(0, 0, 0)' && $('#' + id).css('background-color') != 'rgba(0, 0, 0, 0)') {//si tiene circulo de validacion coloreado, entra en el if (CASO PARA FICHA DE INGRESO, COLONIZACION/INFECCION)
                $('#' + id).css({ 'background-color': estilosEstado.strColor });
                $('#' + id).text(estilosEstado.strResultado);
            }
        });

        //AQUI MOSTRAR OCULTAR EL DE REGISTRAR Y ENSEÑAR EL NUEVO BOTON DE DESHACER
        $("#btnRegistroENVIN").hide();
        $("#btnDeshacerRegistroENVIN").show();
    }
    if (pacienteActual.estadoInforme == 'Validado') {//SI esta validado, se muestra todo y se muestra el boton de registrar
      /* console.info('aqui deberia meterse');*/
        $(".controlesARevisar").each(function (i) {

            var id = $(this).attr('id');
            //alert("revision:  " + id);
            //alert("attrr  "+$('#' + id).attr('data-tipo'));
            //para los checkbox
            $('#' + id + 'Si').attr('disabled',false);
            $('#' + id + 'No').attr('disabled', false);

            //para los select y inputs
            $('#' + id).attr('disabled', false);


            //para los botones
            $('#' + id).removeClass('disabled');
        });
        //AQUI PINTAR EL CIRCULITO DE VALIDACION A Registrado en ENVIN'
        var estilosEstado = obtenerEstiloValidacion(2);

        $(".span_validacion").each(function (i) {
            var id = $(this).attr('id');
          /*  alert(id + "   " + $('#' + id).css('background-color'));*/
            if ($('#' + id).css('background-color') != 'rgb(0, 0, 0)' && $('#' + id).css('background-color') != 'rgba(0, 0, 0, 0)') {//si tiene circulo de validacion coloreado, entra en el if (CASO PARA FICHA DE INGRESO, COLONIZACION/INFECCION)
                $('#' + id).css({ 'background-color': estilosEstado.strColor });
                $('#' + id).text(estilosEstado.strResultado);
            }
        });

        //AQUI MOSTRAR OCULTAR EL DE REGISTRAR Y ENSEÑAR EL NUEVO BOTON DE DESHACER
        $("#btnRegistroENVIN").show();
        $("#btnDeshacerRegistroENVIN").hide();
    }
    if (pacienteActual.estadoInforme == 'Sin Validar') {//SI esta validado, se muestra todo y se muestra el boton de registrar
       /* console.info('creo que se esta metiendo aqui');*/
        //AQUI MOSTRAR OCULTAR EL DE REGISTRAR Y ENSEÑAR EL NUEVO BOTON DE DESHACER
        $("#btnRegistroENVIN").show();
        $("#btnDeshacerRegistroENVIN").hide();
    }


}

function cambioVisualizacionRegistroENVIN_Span(spanValidacion) {//esta funcion deriva de la anterior pero pasandole el span de validacion correspondiente (necesaria porque en ficha de ingreso no hay sincronia entre los fdone de los bloques)
    //el span va con hastag en la variable de entrada

    //recorremos todos los controles de la pantalla:
    var pacienteActual = getPaciente();

    if (pacienteActual.estadoInforme == 'Registrado en ENVIN') {//SI ESTA REGISTRADO EN EL ENVIN SE DESHABILITA TODA LA WEB!
        $(".controlesARevisar").each(function (i) {

            var id = $(this).attr('id');
            //alert("revision:  " + id);
            //alert("attrr  "+$('#' + id).attr('data-tipo'));
            //para los checkbox
            $('#' + id + 'Si').attr('disabled', true);
            $('#' + id + 'No').attr('disabled', true);

            //para los select y inputs
            $('#' +id).attr('disabled', true);


            //para los botones
            $('#' + id).addClass('disabled');
        });
        //AQUI PINTAR EL CIRCULITO DE VALIDACION A Registrado en ENVIN'
        var estilosEstado = obtenerEstiloValidacion(3);
        /* alert("revision:  " + arrayIds);*/

       
       /* alert(spanValidacion + "   " + $(spanValidacion).css('background-color'));*/
        if ($(spanValidacion).css('background-color') != 'rgb(0, 0, 0)' && $(spanValidacion).css('background-color') != 'rgba(0, 0, 0, 0)') {//si tiene circulo de validacion coloreado, entra en el if (CASO PARA FICHA DE INGRESO, COLONIZACION/INFECCION)
            /*alert(spanValidacion + "   " + $(spanValidacion).css('background-color'));*/
            $(spanValidacion).css('background-color', estilosEstado.strColor);
            $(spanValidacion).text(estilosEstado.strResultado);
        }
       

        //AQUI MOSTRAR OCULTAR EL DE REGISTRAR Y ENSEÑAR EL NUEVO BOTON DE DESHACER
        $("#btnRegistroENVIN").hide();
        $("#btnDeshacerRegistroENVIN").show();
    }
    if (pacienteActual.estadoInforme == 'Validado') {//SI esta validado, se muestra todo y se muestra el boton de registrar

        $(".controlesARevisar").each(function (i) {

            var id = $(this).attr('id');
            //alert("revision:  " + id);
            //alert("attrr  "+$('#' + id).attr('data-tipo'));
            //para los checkbox
            $('#' + id + 'Si').attr('disabled', false);
            $('#' + id + 'No').attr('disabled', false);

            //para los select y inputs
            $('#' + id).attr('disabled', false);


            //para los botones
            $('#' + id).removeClass('disabled');
        });
        //AQUI PINTAR EL CIRCULITO DE Registrado en ENVIN' A validado
        var estilosEstado = obtenerEstiloValidacion(2);
       /* alert(spanValidacion + "   " + $(spanValidacion).css('background-color'));*/
        if ($(spanValidacion).css('background-color') != 'rgb(0, 0, 0)' && $(spanValidacion).css('background-color') != 'rgba(0, 0, 0, 0)') {//si tiene circulo de validacion coloreado, entra en el if (CASO PARA FICHA DE INGRESO, COLONIZACION/INFECCION)
            /*alert(spanValidacion + "   " + $(spanValidacion).css('background-color'));*/
            $(spanValidacion).css('background-color', estilosEstado.strColor);
            $(spanValidacion).text(estilosEstado.strResultado);
        }

        //AQUI MOSTRAR OCULTAR EL DE REGISTRAR Y ENSEÑAR EL NUEVO BOTON DE DESHACER
        $("#btnRegistroENVIN").show();
        $("#btnDeshacerRegistroENVIN").hide();
    }
    if (pacienteActual.estadoInforme == 'Sin Validar') {//SI esta validado, se muestra todo y se muestra el boton de registrar

        //AQUI MOSTRAR OCULTAR EL DE REGISTRAR Y ENSEÑAR EL NUEVO BOTON DE DESHACER
        $("#btnRegistroENVIN").show();
        $("#btnDeshacerRegistroENVIN").hide();
    }


}


//FDONES
var fDoneGET_ENVIN_Pacientes_BarraTitulo = function (data) {

    if (data.EsCorrecto) {

        if (data.get_wsENVIN_Web_Pacientes != null) {
            var pac = data.get_wsENVIN_Web_Pacientes[0];

            /* wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ID	EstadoInforme
                                        1	                    Sin Validar
                                        2	                    Validado
                                        3	                    Registrado en ENVIN*/
            if (pac.wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ID == 2) {//si es dos, es que esta validado

                generarModal('confirmacionRegistroEnvinModal', 'Registro en el envin', 'Va a marcar como registrado en el ENVIN el informe del paciente. ¿Desea continuar?', 'btnRegistroEnvin_No', 'No', 'btnRegistroEnvin_Si', 'Si', 0, 1);

                $("#btnRegistroEnvin_Si").click(function () {
                    GetJsonService(ParentUrl + "/ENVIN/SET_Pacientes",
                        {
                            PatientID: pac.PatientID,
                            id_wsLEIRE_Datos_Ingresos: pac.id_wsLEIRE_Datos_Ingresos,
                            NHC: pac.NHC,
                            LogicalUnitID: pac.LogicalUnitID,
                            wsENVIN_Web_Maestro_Pacientes_ORStatus_ID: pac.wsENVIN_Web_Maestro_Pacientes_ORStatus_ID,
                            wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ID: 3,// 3: registrado en el envin
                            EsCargaManual: pac.EsCargaManual,
                            FechaCargaManual: getDateTimeToStringNull_DateTimePickers(pac.FechaCargaManual, "--", true),
                            FirstName: pac.FirstName,
                            LastName: pac.LastName,
                            FechaNacimiento: getDateTimeToStringNull_DateTimePickers(pac.FechaNacimiento, "--", true),
                            wsENVIN_Web_Maestro_Pacientes_Sexo_ID: pac.wsENVIN_Web_Maestro_Pacientes_Sexo_ID,
                            NumHabitacion: pac.NumHabitacion,
                            AddmissionDate: getDateTimeToStringNull_DateTimePickers(pac.AddmissionDate, "--", true),
                            FechaIngresoHospital: getDateTimeToStringNull_DateTimePickers(pac.FechaIngresoHospital, "--", true),
                            DischargeDate: getDateTimeToStringNull_DateTimePickers(pac.DischargeDate, "--", true),
                            FechaAltaHospital: getDateTimeToStringNull_DateTimePickers(pac.FechaAltaHospital, "--", true),
                            Exitus: pac.Exitus,
                            FechaExitus: getDateTimeToStringNull_DateTimePickers(pac.FechaExitus, "--", true),
                            IdUsuarioUltimaModificacion: usuario,
                            wsENVIN_Web_Pacientes_ID: pac.wsENVIN_Web_Pacientes_ID
                        }, fDoneSET_Pacientes_BarraTitulo, ffail);

                    $("#confirmacionRegistroEnvinModal").modal('hide');

                });
            }
            if (pac.wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ID == 1) {
                /*alert("No estan todas las pantallas validadas, no se puede marcar como registrado en el ENVIN");*/
                generarModal('avisoNoValidacion', 'Atención', 'No estan todas las pantallas validadas, no se puede marcar como registrado en el ENVIN', 'btnavisoNoValidacion_Cerrar', 'Cerrar', 'btnavisoNoValidacion_Aceptar', 'Aceptar', 0, 0);

            }
            if (pac.wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ID == 3) {
                /*alert("El paciente ya esta registrado en el envin");*/
                generarModal('avisoPacienteRegistrado', 'Atención', 'El paciente ya esta registrado en el envin', 'btnavisoPacienteRegistrado_Cerrar', 'Cerrar', 'btnavisoPacienteRegistrado_Aceptar', 'Aceptar', 0, 0);

            }
        }


    }
    else {
        alert("Error: " + data.MensajeError);
    }
}


var fDoneSET_Pacientes_BarraTitulo = function (data) {
    if (data.EsCorrecto) {
       
        setEstadoInforme('Registrado en ENVIN');//seteamos el nuevo estado del informe del paciente

        //borramos el titulo del paciente y ponemos el nuevo estado de informe
        $('#barra_izquierda').empty("");
        $('#barra_izquierda').append(generarDatosPacienteTitulo_Estado(pacienteActual, 'Registrado en ENVIN'));

        ////AQUI MOSTRAR EL NUEVO BOTON
        //$("#btnRegistroENVIN").hide();
        //$("#btnDeshacerRegistroENVIN").show();

        alert("Se ha registrado del ENVIN correctamente");

        //si el paciente esta registrado, la informacion la deshabilitaremos
        cambioVisualizacionRegistroENVIN();

       
    } else {
        alert("Error: " + data.MensajeError + "  Funcion: fDoneSET_Pacientes_BarraTitulo");
    }
}


var fDoneGET_ENVIN_Pacientes_BarraTitulo_DesResgistro = function (data) {

    if (data.EsCorrecto) {

        if (data.get_wsENVIN_Web_Pacientes != null) {
            var pac = data.get_wsENVIN_Web_Pacientes[0];

            /* wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ID	EstadoInforme
                                        1	                    Sin Validar
                                        2	                    Validado
                                        3	                    Registrado en ENVIN*/
            if (pac.wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ID == 3) {

                generarModal('confirmacionDesRegistroEnvinModal', 'Desegistro en el envin', 'Va a desmarcar como registrado en el ENVIN el informe del paciente. ¿Desea continuar?', 'btnDesRegistroEnvin_No', 'No', 'btnDesRegistroEnvin_Si', 'Si', 0, 1);

                $("#btnDesRegistroEnvin_Si").click(function () {
                    GetJsonService(ParentUrl + "/ENVIN/SET_Pacientes",
                        {
                            PatientID: pac.PatientID,
                            id_wsLEIRE_Datos_Ingresos: pac.id_wsLEIRE_Datos_Ingresos,
                            NHC: pac.NHC,
                            LogicalUnitID: pac.LogicalUnitID,
                            wsENVIN_Web_Maestro_Pacientes_ORStatus_ID: pac.wsENVIN_Web_Maestro_Pacientes_ORStatus_ID,
                            wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ID: 2,// 2:validado
                            EsCargaManual: pac.EsCargaManual,
                            FechaCargaManual: getDateTimeToStringNull_DateTimePickers(pac.FechaCargaManual, "--", true),
                            FirstName: pac.FirstName,
                            LastName: pac.LastName,
                            FechaNacimiento: getDateTimeToStringNull_DateTimePickers(pac.FechaNacimiento, "--", true),
                            wsENVIN_Web_Maestro_Pacientes_Sexo_ID: pac.wsENVIN_Web_Maestro_Pacientes_Sexo_ID,
                            NumHabitacion: pac.NumHabitacion,
                            AddmissionDate: getDateTimeToStringNull_DateTimePickers(pac.AddmissionDate, "--", true),
                            FechaIngresoHospital: getDateTimeToStringNull_DateTimePickers(pac.FechaIngresoHospital, "--", true),
                            DischargeDate: getDateTimeToStringNull_DateTimePickers(pac.DischargeDate, "--", true),
                            FechaAltaHospital: getDateTimeToStringNull_DateTimePickers(pac.FechaAltaHospital, "--", true),
                            Exitus: pac.Exitus,
                            FechaExitus: getDateTimeToStringNull_DateTimePickers(pac.FechaExitus, "--", true),
                            IdUsuarioUltimaModificacion: usuario,
                            wsENVIN_Web_Pacientes_ID: pac.wsENVIN_Web_Pacientes_ID
                        }, fDoneSET_Pacientes_BarraTitulo_DesResgistro, ffail);

                    $("#confirmacionDesRegistroEnvinModal").modal('hide');

                });
            }
          
        }


    }
    else {
        alert("Error: " + data.MensajeError);
    }
}

var fDoneSET_Pacientes_BarraTitulo_DesResgistro = function (data) {
    if (data.EsCorrecto) {
       
        setEstadoInforme('Validado');//seteamos el nuevo estado del informe del paciente

        //borramos el titulo del paciente y ponemos el nuevo estado de informe
        $('#barra_izquierda').empty("");
        $('#barra_izquierda').append(generarDatosPacienteTitulo_Estado(pacienteActual, 'Validado'));


        ////AQUI MOSTRAR EL NUEVO BOTON
        //$("#btnRegistroENVIN").show();
        //$("#btnDeshacerRegistroENVIN").hide();

        alert("Se ha desregistrado del ENVIN correctamente");


        //habilitamos todo de nuevo();
        cambioVisualizacionRegistroENVIN();

        
    } else {
        alert("Error: " + data.MensajeError + "  Funcion: fDoneSET_Pacientes_BarraTitulo");
    }
}



//ONCLICKS
function onClickBotonRegistroEnvin(wsENVIN_Web_Pacientes_ID) {
    //verificamos que esta todo validado, lo cogemos del LS
    GetJsonService(ParentUrl + "/ENVIN/GET_ENVIN_Pacientes",
        {
            wsENVIN_Web_Pacientes_ID: wsENVIN_Web_Pacientes_ID//pacienteActual.wsENVIN_Web_Pacientes_ID
        }, fDoneGET_ENVIN_Pacientes_BarraTitulo, ffail);

}


function onClickBotonDesRegistroEnvin(wsENVIN_Web_Pacientes_ID) {
    //verificamos que esta todo validado, lo cogemos del LS
    GetJsonService(ParentUrl + "/ENVIN/GET_ENVIN_Pacientes",
        {
            wsENVIN_Web_Pacientes_ID: wsENVIN_Web_Pacientes_ID//pacienteActual.wsENVIN_Web_Pacientes_ID
        }, fDoneGET_ENVIN_Pacientes_BarraTitulo_DesResgistro, ffail);

}

//--------------------HTM del MODAL que saldrá como aviso cuando quieras cambiar de página y haya cambios sin guardar
//var dataHeader = '<div class="modal fade modal-dialog-centered modal-dialog-scrollable" id="confirmacionSiCambiosSinGuardar" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true"><div class="modal-dialog modal-dialog-centered"><div class="modal-content"><div class="modal-header"><h1 class="modal-title fs-5" id="staticBackdropLabel">Atención datos sin guardar</h1></div>';
//var dataContent = '<div class="modal-body" id="CSMensaje">Hay cambios sin guardar, ¿desea continuar a la siguiente página sin guardar?</div>';
//var dataFooter = '<div class="modal-footer"><button id="btnNOcontinuar" type="button" class="btn btn-secondary" data-bs-dismiss="modal">No</button><button id="btnSIContinuar" type="button" class="btn btn-primary">Sí, quiero continuar SIN guardar</button></div></div></div></div>';
//var data = dataHeader + dataContent + dataFooter;
//var cambiosSinGuardar;

function showModalDatosSinGuardar() {
    generarModal('confirmacionSiCambiosSinGuardar', 'Atención datos sin guardar', 'Hay cambios sin guardar, ¿desea continuar a la siguiente página sin guardar?', 'btnNOcontinuar', 'No', 'btnSIContinuar', 'Sí, quiero continuar SIN guardar', 0, 1)
}

function onClick_FichaDeIngreso() {
  
   

    //------------ activar modal que si hay cambios sin guardar---------

    var cambiosSinGuardar = getCambiosSinGuardar();
    //alert('hola en LayourPortal: ' + cambiosSinGuardar);
    if (cambiosSinGuardar == true) {
        //alert('hola en LayourPortal dentro del if: ' + cambiosSinGuardar);
        showModalDatosSinGuardar();

        $("#btnNOcontinuar").click(function () {

            $("#confirmacionBorrarATBModal").modal('hide');

        });

        $("#btnSIContinuar").click(function () {
            location.href = ParentUrl + '/ENVIN/FichaDeIngreso';
            //$("#confirmacionBorrarATBModal").modal('hide');
           
        });
    } else {
        location.href = ParentUrl + '/ENVIN/FichaDeIngreso';
        
    }
}

function onClick_ViewFactoresRiesgoIndividual() {
  


    //------------ activar modal que si hay cambios sin guardar---------

    var cambiosSinGuardar = getCambiosSinGuardar();
    //alert('hola en LayourPortal: ' + cambiosSinGuardar);
    if (cambiosSinGuardar == true) {
        //alert('hola en LayourPortal dentro del if: ' + cambiosSinGuardar);
        showModalDatosSinGuardar();

        $("#btnNOcontinuar").click(function () {

            $("#confirmacionSiCambiosSinGuardar").modal('hide');

        });

        $("#btnSIContinuar").click(function () {
            location.href = ParentUrl + '/ENVIN/ViewFactoresRiesgoIndividual';
            //$("#confirmacionBorrarATBModal").modal('hide');
           
        });
    } else {
        location.href = ParentUrl + '/ENVIN/ViewFactoresRiesgoIndividual';
       
    }

}

function onClick_ViewAntibioticos() {


    //------------ activar modal que si hay cambios sin guardar---------

    var cambiosSinGuardar = getCambiosSinGuardar();
    //alert('hola en LayourPortal: ' + cambiosSinGuardar);
    if (cambiosSinGuardar == true) {
        //alert('hola en LayourPortal dentro del if: ' + cambiosSinGuardar);
        showModalDatosSinGuardar();

        $("#btnNOcontinuar").click(function () {

            $("#confirmacionSiCambiosSinGuardar").modal('hide');

        });

        $("#btnSIContinuar").click(function () {
            location.href = ParentUrl + '/ENVIN/ViewAntibioticos';
            //$("#confirmacionBorrarATBModal").modal('hide');
            
        });
    } else {
        location.href = ParentUrl + '/ENVIN/ViewAntibioticos';
       
    }

}

function onClick_Infecciones() {
   

    //------------ activar modal que si hay cambios sin guardar---------

    var cambiosSinGuardar = getCambiosSinGuardar();
    //alert('hola en LayourPortal: ' + cambiosSinGuardar);
    if (cambiosSinGuardar == true) {
        //alert('hola en LayourPortal dentro del if: ' + cambiosSinGuardar);
        showModalDatosSinGuardar();

        $("#btnNOcontinuar").click(function () {
            $("#confirmacionSiCambiosSinGuardar").modal('hide');
        });

        $("#btnSIContinuar").click(function () {
            location.href = ParentUrl + '/ENVIN/ViewInfecciones';
            //$("#confirmacionBorrarATBModal").modal('hide');
           
        });
    } else {
        location.href = ParentUrl + '/ENVIN/ViewInfecciones';
      
    }

}

function setCambiosSinGuardar(bolCambios) {
    cambiosSinGuardar = bolCambios;
}

function getCambiosSinGuardar() {
    return cambiosSinGuardar;
}


//idLinea es el elemento que quieres comprobar (antibiótico, infección...) 
//fechaNula será la fecha que vayamos a definir en BBDD como nula, usamos siempre 1/1/1971
//Se esperan recibir las fechas de la sieguiente manera: 
//FechaValidacion se espera recibir en C# que es como viene de BBDD para evitar que se tenga que convertir en el origen donde se llama a esta función
//fecgaNula se espera que se pase en formato JS --> var fechanula = new Date(1971, 1, 1, 0, 0, 0, 0);
function getEstadoValidacion(usuarioValidacion, fechaValidacion) {

    var objResultado = {
        "strResultado": ""
        , "strColor": ""
    }
    //desde BBDD las fechas nos llegan con formato C# y hay que pasarla a string con la función de arriba getDateTimeToStringNull_DateTimePickers para luego poderla pasar al formato de JS
    var fechaValidacionString = getDateTimeToStringNull_DateTimePickers(fechaValidacion, '--', true);
    var fechaValidacionJS = new Date();
    if (fechaValidacionString != '--') {
        fechaValidacionJS = new Date(fechaValidacionString);
    } else {
        fechaValidacionJS = new Date(1971, 1, 1, 0, 0, 0, 0);
    }


    if (usuarioValidacion != null && usuarioValidacion != "" && fechaValidacionJS != new Date(1971, 1, 1, 0, 0, 0, 0)) {
        objResultado.strResultado = "Validado";
        objResultado.strColor = "yellowgreen";
    } else {
        //faltaría aquí compobar en BBDD que no esté registrado porque en esta parte se queda igual. el registrado se queda reflejado en la tabla pacientes. 

        objResultado.strResultado = "Sin validar";
        objResultado.strColor = "#ffc107";
    }


    return objResultado;
}

//esta funcion nos da los colores y texto de la leyenda para configurar el estilo del elemento, segun el estado del informe del envin (que se lo pasamos como parametro)
/**
 * tabla base de datos de estados informe:
 * wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ID	EstadoInforme
1	Sin Validar
2	Validado
3	Registrado en ENVIN
4   Rojo borrado
 */

function obtenerEstiloValidacion(estado) { //estado 1: sin validar, 2: validado 3: registrado en envin, estado 4: borrado
    var objResultado = {
        "strResultado": ""
        , "strColor": ""
    }

    switch (estado) {
        case 1:
            objResultado.strResultado = "Sin Validar";
            objResultado.strColor = color_estadoSinValidar;
            break;
        case 2:
            objResultado.strResultado = "Validado";
            objResultado.strColor = color_estadoValidado;
            break;
        case 3:
            objResultado.strResultado = "Registrado en ENVIN";
            objResultado.strColor = color_estadoRegistradoEnEnvin;
            break;
        case 4:
            objResultado.strResultado = "Borrado";
            objResultado.strColor = color_estadoBorrado;
            break;
        default:
            alert("no existe el estado: " + estado);

    }
    return objResultado;
}