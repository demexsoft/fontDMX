
function mostrarJuntaDia(panelId) {
    try {

        var pnl = document.getElementById('ver_juntas_Dia');
        var cal = document.getElementById('ctl00_ContentPlaceHolder1_calendario_juntas');


        pnl.style.visibility = "visible";
        calendario_juntas.visibility = "visible"
        
       
    }catch(err){
        alert('ERROR '+err);
    
    }

} //mostrarJuntaDia
function ocultarJuntaDia(panelId) {
    try {

        var pnl = document.getElementById('ctl00_ContentPlaceHolder1_ver_juntas_Dia');

        pnl.style.visibility = "hidden";
       

    } catch (err) {
        alert('ERROR ocultarJuntaDia ' + err);

    }

} //mostrarJuntaDia


function muestraCompletaJunta(lblId) {
      try {

           var lblTitulo = document.getElementById(lblId);

          //[lbl897] SI FUNCIONA  lblTitulo.innerText


          var pnlDatosJunta = document.getElementById('ctl00_ContentPlaceHolder1_ver_datos_junta');
          pnlDatosJunta.style.visibility = "visible";


         // pnlDatosJunta.innerHTML = lblTitulo.fecha;
          document.getElementById("ctl00_ContentPlaceHolder1_txt_fechaCompromiso_datosjunta").value = lblTitulo.getAttribute("fechaCompromiso");
          document.getElementById("ctl00_ContentPlaceHolder1_txt_fechaReal_datosjunta").value = lblTitulo.getAttribute("fechaReal");
          document.getElementById("ctl00_ContentPlaceHolder1_txt_estado_actual_junta").value = lblTitulo.getAttribute("estadoJunta");
          

          document.getElementById("ctl00_ContentPlaceHolder1_txt_horaCompromiso_datosjunta").value = lblTitulo.getAttribute("horaCompromiso");
          document.getElementById("ctl00_ContentPlaceHolder1_txt_horaReal_datosjunta").value = lblTitulo.getAttribute("horaReal");

          document.getElementById("ctl00_ContentPlaceHolder1_txt_actividad_datosjunta").value = lblTitulo.getAttribute("actividad");
          document.getElementById("ctl00_ContentPlaceHolder1_txt_concluciones_datosjunta").value = lblTitulo.getAttribute("concluciones");
          
          


    } catch (err) {
          alert('ERROR muestraCompletaJunta' + err);

    }//try-catch
} //muestraCompletaJunta

function cierraCompletaJunta() {
    try {



        var pnlDatosJunta = document.getElementById('ctl00_ContentPlaceHolder1_ver_datos_junta');
        pnlDatosJunta.style.visibility = "hidden";

        // pnlDatosJunta.innerHTML = lblTitulo.fecha;
        document.getElementById("ctl00_ContentPlaceHolder1_txt_fechaCompromiso_datosjunta").value = "";
        document.getElementById("ctl00_ContentPlaceHolder1_txt_fechaReal_datosjunta").value = "";
        document.getElementById("ctl00_ContentPlaceHolder1_txt_estado_actual_junta").value = "";
        

        document.getElementById("ctl00_ContentPlaceHolder1_txt_horaCompromiso_datosjunta").value = "";
        document.getElementById("ctl00_ContentPlaceHolder1_txt_horaReal_datosjunta").value = "";

        document.getElementById("ctl00_ContentPlaceHolder1_txt_actividad_datosjunta").value = "";
        document.getElementById("ctl00_ContentPlaceHolder1_txt_concluciones_datosjunta").value = "";




    } catch (err) {
        alert('ERROR ' + err);

    }//try-catch
} //cierraCompletaJunta

function muestraTodasJuntasDelDia(DiaId) {
    try {

        var pnlJuntasDelDia = document.getElementById('ctl00_ContentPlaceHolder1_ver_juntas_Dia');
        pnlJuntasDelDia.style.visibility = "visible";

        var lblJuntasDelDia = document.getElementById(DiaId);

        var lgrd = document.getElementById('tbl_juntasDelDia');

         //elementos en la tabla para ser borrados del grid
         var tbl_rows = lgrd.childNodes.length - 1;

         //llega hasta uno ya QUE, el titulo es contado como un elemento de la tabla
         if (tbl_rows >= 1) {
             for (var Rm = tbl_rows; Rm > 0; Rm--) {
             //saca el elemento a eliminar
                 var hijo = lgrd.childNodes[Rm];
                 //quita el elemento
                 lgrd.removeChild(hijo);
             } //for


         } else {

         } //remover item en caso de venir sin actividades el dia


         if (lblJuntasDelDia.getAttribute("fechaDelDia") == null) {
             document.getElementById("txt_diaActividadesSeleccionado").value = "Sin Juntas";
         } else {
             document.getElementById("txt_diaActividadesSeleccionado").value = lblJuntasDelDia.getAttribute("fechaDelDia");
         }

       if (lblJuntasDelDia.getAttribute("asuntosdeldia") != null) {
           

          var arrayAsunto = lblJuntasDelDia.getAttribute("asuntosdeldia").split("|");
          var arrayHoraComp = lblJuntasDelDia.getAttribute("horaReal").split("|");
          var arrayHoraReal = lblJuntasDelDia.getAttribute("horaReal").split("|");


           //Crea Tabla de presentacion de juntas del DIA seleccionado
         





               for (var items = 0; items < arrayAsunto.length-1 ; items++) {
                
                   var tr = document.createElement("tr");
                   var cell0 = document.createElement("td");
                   var cell1 = document.createElement("td");
                   var cell2 = document.createElement("td");

                   cell0.innerHTML = arrayHoraReal[items];
                   cell0.setAttribute("class","tituloGris_");
                   cell1.innerHTML = arrayHoraComp[items];
                   cell2.innerHTML = arrayAsunto[items];

                   tr.appendChild(cell0);
                   tr.appendChild(cell1);
                   tr.appendChild(cell2);
                   tr.setAttribute("border", "1px");
                   tr.setAttribute("bordercolor","#999999");
                   lgrd.appendChild(tr);


               } //items

       } else {
               
       
       }//si es nulo
       
       

    } catch (err) {
           alert('ERROR muestraTodasJuntasDelDia' + err);

    }//try-catch
} //muestraTodasJuntasDelDia
