using System;
using System.Web.UI.WebControls;
using System.Data;
using betaCulturalMARKII.idioma;
using betaCulturalMARKII.empleado;
using System.Globalization;


namespace betaCulturalMARKII.reunion
{
    public partial class junta : System.Web.UI.Page
    {
        cls_Utilerias Msg = new cls_Utilerias();

        protected void Page_Load(object sender, EventArgs e)
        {
           
           try {
               //ver_datos_junta.Visible = false;

               cls_reunion.init_reunionIntegrante();
               lbl_aviso_crearJunta_SINO.Text = "";

                switch (Session["compoJunta"].ToString())
                {

                    case "TodasJuntasMiembro":
                        crearCalendarioJuntasParticipante();
                        tbl_Junta_cerrar.Visible = false;
                        tbl_Junta_crear.Visible = false;
                       
                       break;

                    case "TodasJuntasCreador":
                       crearCalendarioJuntasCreador();
                        tbl_Junta_cerrar.Visible = false;
                        tbl_Junta_crear.Visible = false;
                        
                        break;

                    case "CrearJuntaParticipante":
                       tbl_Junta_cerrar.Visible = false;
                       tbl_Junta_crear.Visible = true;
                       ver_datos_junta.Visible = false;
                       tbl_Junta_Calendario.Visible = false;
                       break;

                    case "CerrarJunta":
                        tbl_Junta_cerrar.Visible = true;

                        tbl_Junta_Calendario.Visible = false;
                        tbl_Junta_crear.Visible = false;

                        break;


                    case "CrearJuntaCreador":
                       
                        tbl_Junta_crear.Visible = true;

                        tbl_Junta_cerrar.Visible = false;
                        ver_datos_junta.Visible = false;
                        tbl_Junta_Calendario.Visible = false;
                        //crearCalendarioJuntasCreador();
                        
                        break;


               
                }

            

            }catch(Exception ex_){
                cls_errores.muestraWebError(ex_);
            }//try-catch



        }//page_load

        protected void crearCalendarioJuntasParticipante()
        {
            //Funcion para crear un calendario para ver consultar las juntas QUE el usuario ha Creado 

            DataTable todasLasjuntasMes = new DataTable();
            cls_reunion reunion = new cls_reunion();

            try
            {
                //instancia todas las reuniones las q el usuario es Miembro
                todasLasjuntasMes = reunion.visualizarReunionesMiembro(cls_acceso.get_ID());

                int mesNow = DateTime.Now.Month;
                int diaNow = DateTime.Now.Day;
                int anioNow = DateTime.Now.Year;

                DateTime fecha = new DateTime(anioNow, mesNow, diaNow);


                int corX = 0;
                int corY = 20;


                int diaSemana = 1;

                int dia_semana = (int)fecha.DayOfWeek;
                int dia_numero = DateTime.Now.Day;


                Label[] lblDiasem = new Label[7];

                int lblDiasem_corX = 0;

                for (int nom_dia = 0; nom_dia < lblDiasem.Length; nom_dia++)
                {


                    lblDiasem[nom_dia] = new Label();


                    lblDiasem[nom_dia].ID = "lblDiasem" + (nom_dia + 1);
                    lblDiasem[nom_dia].CssClass = "titulo_Dia_nombre";
                    pnl_calendario.Controls.Add(lblDiasem[nom_dia]);
                    lblDiasem[nom_dia].Style["left"] = lblDiasem_corX + "px";
                    lblDiasem_corX += 105;

                    CultureInfo ci = new CultureInfo("Es-Es");
                    lblDiasem[nom_dia].Text = ci.DateTimeFormat.GetDayName(new DateTime(anioNow, mesNow, (nom_dia + 1)).DayOfWeek).ToUpper();


                }



                //Crea Vista de Dia con numero de Dia
                Panel[] pnlDia = new Panel[35];
                Label[] lblDia = new Label[35];

                //Contiene todas las juntas del mes, crear las del Dia en turno
                Label[] lblReunionPorDia = new Label[todasLasjuntasMes.Rows.Count];

                string asuntosDelDiaarray = "";
                string horaCompoarray = "";
                string horaRealarray = "";


                int totalDiasMes = DateTime.DaysInMonth(anioNow, mesNow);





                for (int dia = 0; dia < pnlDia.Length; dia++)
                {
                    //Crea el panel del dia y la etiqueta del dia
                    pnlDia[dia] = new Panel();
                    lblDia[dia] = new Label();

                    lblDia[dia].ID = ("lblDia") + (dia + 1);

                    //Asigna el ID para el panel del dia
                    pnlDia[dia].ID = ("pnlDia") + (dia + 1);

                    //cambia el color para señalar el dia de HOY
                    if (dia_numero == dia)
                    {
                        pnlDia[dia - 1].BackColor = System.Drawing.Color.Silver;

                    }
                    else
                    {
                        pnlDia[dia].BackColor = System.Drawing.Color.White;
                    }//else


                    //asigana los estilos para el formato actual hoja:stilocomponente.css
                    pnlDia[dia].CssClass = "calendario_Dias";
                    lblDia[dia].CssClass = "calendario_Dias_numero";

                    string fecha_compromiso = "";

                    //cordenadas del titulo de junta
                    int espacioY = 18;
                    int TitulocorY = espacioY;

                    for (int junta = 0; junta < todasLasjuntasMes.Rows.Count; junta++)
                    {
                        string diaFormato = "";
                        string mesFormato = "";

                        fecha_compromiso = todasLasjuntasMes.Rows[junta]["fComp"].ToString();

                        //Crea el numero de 01 a  09 para comparar el dia ya q el formato de la fecha llega en 1
                        if (dia < 10)
                        {
                            diaFormato = "0" + dia;

                        }
                        else
                        {
                            diaFormato = "" + dia;

                        }//else
                        //Crea el numero de 01 a  09 para comparar el mes ya q el formato de la fecha llega en 1
                        if (mesNow < 10)
                        {
                            mesFormato = "0" + mesNow;
                        }
                        else
                        {
                            mesFormato = "" + mesNow;
                        }//else


                        //Compara la fecha completa dia mes año, contra el campo guardado
                        if (fecha_compromiso == diaFormato + "/" + mesFormato + "/" + anioNow)
                        {
                            lblReunionPorDia[junta] = new Label();

                            lblReunionPorDia[junta].CssClass = "titulo_junta_Dia";

                            //asigna los valores en atributos del componente, para mostrar mandarlo a funcion en el "JS muestraCompletaJunta"
                            //lblReunionPorDia es la JUNTA dentro del DIA.

                            //agrega titulo de cada una de las juntas agregadas al dia
                            //Si el asunto es mayor a 15 caracteres, optiene solo caracteres para mostrar
                            int limiteCadenaTitulo = 16;
                            if (todasLasjuntasMes.Rows[junta]["asunto"].ToString().ToString().Length > limiteCadenaTitulo)
                            {
                                lblReunionPorDia[junta].Text = todasLasjuntasMes.Rows[junta]["asunto"].ToString().ToString().Substring(0, limiteCadenaTitulo);
                            }
                            else
                            {
                                lblReunionPorDia[junta].Text = todasLasjuntasMes.Rows[junta]["asunto"].ToString().ToString();
                            }

                            lblReunionPorDia[junta].Attributes["texto"] = todasLasjuntasMes.Rows[junta]["asunto"].ToString();

                            lblReunionPorDia[junta].ID = todasLasjuntasMes.Rows[junta]["IDReu"].ToString();

                            lblReunionPorDia[junta].Attributes["horaReal"] = todasLasjuntasMes.Rows[junta]["hReal"].ToString();
                            lblReunionPorDia[junta].Attributes["horaCompromiso"] = todasLasjuntasMes.Rows[junta]["hComp"].ToString();

                            //Cambia el valor de 0 ó 1 del Estado de la Junta por una Leyenda
                            if (todasLasjuntasMes.Rows[junta]["realizadaoNO"].ToString() == "0")
                            {
                                lblReunionPorDia[junta].Attributes["estadoJunta"] = "No Cerrada";

                            }
                            else if (todasLasjuntasMes.Rows[junta]["realizadaoNO"].ToString() == "1")
                            {
                                lblReunionPorDia[junta].Attributes["estadoJunta"] = "Cerrada";
                            }
                            else
                            {
                                lblReunionPorDia[junta].Attributes["estadoJunta"] = "Indifinido";
                            }



                            lblReunionPorDia[junta].Attributes["fechaReal"] = todasLasjuntasMes.Rows[junta]["fReal"].ToString();
                            lblReunionPorDia[junta].Attributes["fechaCompromiso"] = todasLasjuntasMes.Rows[junta]["fComp"].ToString();

                            lblReunionPorDia[junta].Attributes["actividad"] = todasLasjuntasMes.Rows[junta]["asunto"].ToString();
                            lblReunionPorDia[junta].Attributes["concluciones"] = todasLasjuntasMes.Rows[junta]["concluciones"].ToString();




                            //SI SIRVE lblReunionPorDia[junta].ID = "lblReunionPorDia" + junta;
                            //evento
                            lblReunionPorDia[junta].Attributes.Add("onclick", "muestraCompletaJunta('ctl00_ContentPlaceHolder1_" + lblReunionPorDia[junta].ID.ToString() + "');");



                            //Creo UNA cadena con los asuntos del DIA concatenados con un caracter, para enviarlos al JS que los mostrara.
                            asuntosDelDiaarray += todasLasjuntasMes.Rows[junta]["asunto"].ToString() + "|";
                            horaCompoarray += todasLasjuntasMes.Rows[junta]["hComp"].ToString() + "|";
                            horaRealarray += todasLasjuntasMes.Rows[junta]["hReal"].ToString() + "|";


                            //Compara SOLO el DIA dentro de fecha_compromiso contra el diaFormato, para esto. Obtiene
                            //solo el dia, limitado desde indice 0 de la cadena hasta el indice donde este '/' 
                            //ejem. diaFormato 09 == 02 fecha_compromiso SOLO DIA


                            if (diaFormato == fecha_compromiso.Substring(0, fecha_compromiso.IndexOf('/')))
                            {
                                //si es igual, ntoncs agrega los asuntos al mismo dia 
                                lblDia[dia - 1].Attributes["asuntosDelDia"] = asuntosDelDiaarray;
                                lblDia[dia - 1].Attributes["horaComp"] = horaCompoarray;
                                lblDia[dia - 1].Attributes["horaReal"] = horaRealarray;
                                lblDia[dia - 1].Attributes["fechaDelDia"] = diaFormato + "/" + mesFormato + "/" + anioNow;


                                //asuntosDelDiacadena += asuntosDelDiacadena;
                                //lblDia[dia - 1].Attributes.Add("asuntosDelDia", asuntosDelDiacadena);

                            }
                            else
                            {

                            }

                            //Es -1 (menos uno) por q lo genera el indice desde zero, xconsecuencia los componentes son -1 SOLO CONTROLES no dia
                            pnlDia[dia - 1].Controls.Add(lblReunionPorDia[junta]);

                            //configura el titulo de las juntas con un espaciado en Y
                            lblReunionPorDia[junta].Style["top"] = TitulocorY + "px";
                            TitulocorY += espacioY;

                        }//else
                        else
                        {
                            asuntosDelDiaarray = "";
                            horaCompoarray = "";
                            horaRealarray = "";



                        }//else

                    }//for -junta

                    //Agrega click a la etiketa de numero para mostrar las actividades completas de ese dia.
                    //evento
                    lblDia[dia].Attributes.Add("onclick", "muestraTodasJuntasDelDia('ctl00_ContentPlaceHolder1_" + lblDia[dia].ID.ToString() + "');");

                    //Agrega al PanelDia, la etiketa del numero a mostrar del DIA
                    pnlDia[dia].Controls.Add(lblDia[dia]);

                    pnl_calendario.Controls.Add(pnlDia[dia]);
                    //Da formato de siete rectangulos, como siete dias de la semana, los apila en renglones
                    if (diaSemana > 7)
                    {
                        corX = 0;
                        diaSemana = 1;
                        corY += 105;
                    }

                    pnlDia[dia].Style["left"] = corX + "px";
                    pnlDia[dia].Style["top"] = corY + "px";

                    lblDia[dia].Text = (dia + 1).ToString();

                    if (dia >= totalDiasMes)
                    {
                        pnlDia[dia].Visible = false;
                    }

                    if (totalDiasMes <= dia)
                    {
                        pnlDia[dia].Visible = false;
                    }
                    else
                    {
                        pnlDia[dia].Visible = true;

                    }

                    corX += 105;
                    diaSemana++;

                }//for - dia


            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-cath

            //crearCalendarioJuntasParticipante
        }

        protected void crearCalendarioJuntasCreador()
        {
            //Funcion para crear un calendario para ver consultar las juntas QUE el usuario ha Creado 

            DataTable todasLasjuntasMes = new DataTable();
            cls_reunion reunion = new cls_reunion();

            try
            {
                //instancia todas las reuniones las q el usuario ha creado
                todasLasjuntasMes = reunion.visualizarReunionesCreadas(cls_acceso.get_ID());

                int mesNow = DateTime.Now.Month;
                int diaNow = DateTime.Now.Day;
                int anioNow = DateTime.Now.Year;

                DateTime fecha = new DateTime(anioNow, mesNow, diaNow);


                int corX = 0;
                int corY = 20;


                int diaSemana = 1;

                int dia_semana = (int)fecha.DayOfWeek;
                int dia_numero = DateTime.Now.Day;


                Label[] lblDiasem = new Label[7];

                int lblDiasem_corX = 0;

                for (int nom_dia = 0; nom_dia < lblDiasem.Length; nom_dia++)
                {


                    lblDiasem[nom_dia] = new Label();


                    lblDiasem[nom_dia].ID = "lblDiasem" + (nom_dia + 1);
                    lblDiasem[nom_dia].CssClass = "titulo_Dia_nombre";
                    pnl_calendario.Controls.Add(lblDiasem[nom_dia]);
                    lblDiasem[nom_dia].Style["left"] = lblDiasem_corX + "px";
                    lblDiasem_corX += 105;

                    CultureInfo ci = new CultureInfo("Es-Es");
                    lblDiasem[nom_dia].Text = ci.DateTimeFormat.GetDayName(new DateTime(anioNow, mesNow, (nom_dia + 1)).DayOfWeek).ToUpper();


                }



                //Crea Vista de Dia con numero de Dia
                Panel[] pnlDia = new Panel[35];
                Label[] lblDia = new Label[35];

                //Contiene todas las juntas del mes, crear las del Dia en turno
                Label[] lblReunionPorDia = new Label[todasLasjuntasMes.Rows.Count];

                string asuntosDelDiaarray = "";
                string horaCompoarray = "";
                string horaRealarray = "";


                int totalDiasMes = DateTime.DaysInMonth(anioNow, mesNow);





                for (int dia = 0; dia < pnlDia.Length; dia++)
                {
                    //Crea el panel del dia y la etiqueta del dia
                    pnlDia[dia] = new Panel();
                    lblDia[dia] = new Label();

                    lblDia[dia].ID = ("lblDia") + (dia + 1);

                    //Asigna el ID para el panel del dia
                    pnlDia[dia].ID = ("pnlDia") + (dia + 1);

                    //cambia el color para señalar el dia de HOY
                    if (dia_numero == dia)
                    {
                        pnlDia[dia - 1].BackColor = System.Drawing.Color.Silver;

                    }
                    else
                    {
                        pnlDia[dia].BackColor = System.Drawing.Color.White;
                    }//else


                    //asigana los estilos para el formato actual hoja:stilocomponente.css
                    pnlDia[dia].CssClass = "calendario_Dias";
                    lblDia[dia].CssClass = "calendario_Dias_numero";

                    string fecha_compromiso = "";

                    //cordenadas del titulo de junta
                    int espacioY = 18;
                    int TitulocorY = espacioY;

                    for (int junta = 0; junta < todasLasjuntasMes.Rows.Count; junta++)
                    {
                        string diaFormato = "";
                        string mesFormato = "";

                        fecha_compromiso = todasLasjuntasMes.Rows[junta]["fComp"].ToString();

                        //Crea el numero de 01 a  09 para comparar el dia ya q el formato de la fecha llega en 1
                        if (dia < 10)
                        {
                            diaFormato = "0" + dia;

                        }
                        else
                        {
                            diaFormato = "" + dia;

                        }//else
                        //Crea el numero de 01 a  09 para comparar el mes ya q el formato de la fecha llega en 1
                        if (mesNow < 10)
                        {
                            mesFormato = "0" + mesNow;
                        }
                        else
                        {
                            mesFormato = "" + mesNow;
                        }//else


                        //Compara la fecha completa dia mes año, contra el campo guardado
                        if (fecha_compromiso == diaFormato + "/" + mesFormato + "/" + anioNow)
                        {
                            lblReunionPorDia[junta] = new Label();

                            lblReunionPorDia[junta].CssClass = "titulo_junta_Dia";

                            //asigna los valores en atributos del componente, para mostrar mandarlo a funcion en el "JS muestraCompletaJunta"
                            //lblReunionPorDia es la JUNTA dentro del DIA.

                            //agrega titulo de cada una de las juntas agregadas al dia
                            //Si el asunto es mayor a 15 caracteres, optiene solo caracteres para mostrar
                            int limiteCadenaTitulo = 16;
                            if (todasLasjuntasMes.Rows[junta]["asunto"].ToString().ToString().Length > limiteCadenaTitulo)
                            {
                                lblReunionPorDia[junta].Text = todasLasjuntasMes.Rows[junta]["asunto"].ToString().ToString().Substring(0, limiteCadenaTitulo);
                            }
                            else
                            {
                                lblReunionPorDia[junta].Text = todasLasjuntasMes.Rows[junta]["asunto"].ToString().ToString();
                            }

                            lblReunionPorDia[junta].Attributes["texto"] = todasLasjuntasMes.Rows[junta]["asunto"].ToString();

                            lblReunionPorDia[junta].ID = todasLasjuntasMes.Rows[junta]["IDReu"].ToString();

                            lblReunionPorDia[junta].Attributes["horaReal"] = todasLasjuntasMes.Rows[junta]["hReal"].ToString();
                            lblReunionPorDia[junta].Attributes["horaCompromiso"] = todasLasjuntasMes.Rows[junta]["hComp"].ToString();

                            //Cambia el valor de 0 ó 1 del Estado de la Junta por una Leyenda
                            if (todasLasjuntasMes.Rows[junta]["realizadaoNO"].ToString() == "0")
                            {
                                lblReunionPorDia[junta].Attributes["estadoJunta"] = "No Cerrada";

                            }
                            else if (todasLasjuntasMes.Rows[junta]["realizadaoNO"].ToString() == "1")
                            {
                                lblReunionPorDia[junta].Attributes["estadoJunta"] = "Cerrada";
                            }
                            else
                            {
                                lblReunionPorDia[junta].Attributes["estadoJunta"] = "Indifinido";
                            }



                            lblReunionPorDia[junta].Attributes["fechaReal"] = todasLasjuntasMes.Rows[junta]["fReal"].ToString();
                            lblReunionPorDia[junta].Attributes["fechaCompromiso"] = todasLasjuntasMes.Rows[junta]["fComp"].ToString();

                            lblReunionPorDia[junta].Attributes["actividad"] = todasLasjuntasMes.Rows[junta]["asunto"].ToString();
                            lblReunionPorDia[junta].Attributes["concluciones"] = todasLasjuntasMes.Rows[junta]["concluciones"].ToString();




                            //SI SIRVE lblReunionPorDia[junta].ID = "lblReunionPorDia" + junta;
                            //evento
                            lblReunionPorDia[junta].Attributes.Add("onclick", "muestraCompletaJunta('ctl00_ContentPlaceHolder1_" + lblReunionPorDia[junta].ID.ToString() + "');");



                            //Creo UNA cadena con los asuntos del DIA concatenados con un caracter, para enviarlos al JS que los mostrara.
                            asuntosDelDiaarray += todasLasjuntasMes.Rows[junta]["asunto"].ToString() + "|";
                            horaCompoarray += todasLasjuntasMes.Rows[junta]["hComp"].ToString() + "|";
                            horaRealarray += todasLasjuntasMes.Rows[junta]["hReal"].ToString() + "|";


                            //Compara SOLO el DIA dentro de fecha_compromiso contra el diaFormato, para esto. Obtiene
                            //solo el dia, limitado desde indice 0 de la cadena hasta el indice donde este '/' 
                            //ejem. diaFormato 09 == 02 fecha_compromiso SOLO DIA


                            if (diaFormato == fecha_compromiso.Substring(0, fecha_compromiso.IndexOf('/')))
                            {
                                //si es igual, ntoncs agrega los asuntos al mismo dia 
                                lblDia[dia - 1].Attributes["asuntosDelDia"] = asuntosDelDiaarray;
                                lblDia[dia - 1].Attributes["horaComp"] = horaCompoarray;
                                lblDia[dia - 1].Attributes["horaReal"] = horaRealarray;
                                lblDia[dia - 1].Attributes["fechaDelDia"] = diaFormato + "/" + mesFormato + "/" + anioNow;


                                //asuntosDelDiacadena += asuntosDelDiacadena;
                                //lblDia[dia - 1].Attributes.Add("asuntosDelDia", asuntosDelDiacadena);

                            }
                            else
                            {

                            }

                            //Es -1 (menos uno) por q lo genera el indice desde zero, xconsecuencia los componentes son -1 SOLO CONTROLES no dia
                            pnlDia[dia - 1].Controls.Add(lblReunionPorDia[junta]);

                            //configura el titulo de las juntas con un espaciado en Y
                            lblReunionPorDia[junta].Style["top"] = TitulocorY + "px";
                            TitulocorY += espacioY;

                        }//else
                        else
                        {
                            asuntosDelDiaarray = "";
                            horaCompoarray = "";
                            horaRealarray = "";



                        }//else

                    }//for -junta

                    //Agrega click a la etiketa de numero para mostrar las actividades completas de ese dia.
                    //evento
                    lblDia[dia].Attributes.Add("onclick", "muestraTodasJuntasDelDia('ctl00_ContentPlaceHolder1_" + lblDia[dia].ID.ToString() + "');");

                    //Agrega al PanelDia, la etiketa del numero a mostrar del DIA
                    pnlDia[dia].Controls.Add(lblDia[dia]);

                    pnl_calendario.Controls.Add(pnlDia[dia]);
                    //Da formato de siete rectangulos, como siete dias de la semana, los apila en renglones
                    if (diaSemana > 7)
                    {
                        corX = 0;
                        diaSemana = 1;
                        corY += 105;
                    }

                    pnlDia[dia].Style["left"] = corX + "px";
                    pnlDia[dia].Style["top"] = corY + "px";

                    lblDia[dia].Text = (dia + 1).ToString();

                    if (dia >= totalDiasMes)
                    {
                        pnlDia[dia].Visible = false;
                    }

                    if (totalDiasMes <= dia)
                    {
                        pnlDia[dia].Visible = false;
                    }
                    else
                    {
                        pnlDia[dia].Visible = true;

                    }

                    corX += 105;
                    diaSemana++;

                }//for - dia


            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-cath

            //crearCalendarioJuntasParticipante
        }

        protected void btn_cerrar_calendario_juntas_Click(object sender, EventArgs e)
        {
            //Visualizar el calendario de juntas
            try
            {
                tbl_Junta_Calendario.Visible = false;

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

        }

        protected void calendario_juntas_cerrar_SelectionChanged(object sender, EventArgs e)
        {
            //evento para el Calendario de CERRAR junta optiene el dia, mostrara todas las juntas del dia seleccionado
            try
            {
                //??? String formatoFecha="yyyy/MM/dd";
                string formatoFecha = "dd/MM/yyyy";

                DataTable juntasMesCerrar = new DataTable();

                juntasMesCerrar.Columns.Add("IDReu");
                juntasMesCerrar.Columns.Add("fComp");
                juntasMesCerrar.Columns.Add("asunto");
                juntasMesCerrar.Columns.Add("hComp");



                cls_reunion reunion = new cls_reunion();


                string strQry = calendario_juntas_cerrar.SelectedDate.ToString(formatoFecha);

                DataRow[] rowCerrar;

                rowCerrar = reunion.visualizarReunionesCreadas(cls_acceso.get_ID()).Select("fComp='" + strQry + "'");

                for (int i = 0; i < rowCerrar.Length; i++)
                {
                    juntasMesCerrar.Rows.Add(rowCerrar[i][0], rowCerrar[i][2], rowCerrar[i][3], rowCerrar[i][5]);
                }

                dg_junta_cerrar_selecion.DataSource = juntasMesCerrar;
                dg_junta_cerrar_selecion.DataBind();



                // juntasMesCerrar.Rows.IndexOf(juntasMesCerrar.Select("fComp ='"+strQry+"'")[1]);


            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

            //calendario_juntas_cerrar_SelectionChanged
        }

        protected void btn_crear_junta_Click(object sender, EventArgs e)
        {
            //Visualizar los controles para agregar Una Nueva Junta
            try
            {

                cls_reunion junta = new cls_reunion();
                String formatoFecha = "yyyy-MM-dd";



                //if (junta.agregarReunion(cls_acceso.get_ID(), cls_reunion.get_miembrosDeJunta(), txt_asunto_ParaJunta_crear.Text,
                //   DateTime.Now.ToString(formatoFecha), calendario_juntas.SelectedDate.ToString(formatoFecha), txt_horaCompromiso_junta_crea.Text) == 1)
                //{



                //    txt_asunto_ParaJunta_crear.Text = "";
                //    txt_horaCompromiso_junta_crea.Text = "";

                //    lbl_aviso_Empleados_incluidos_Junta.Visible = false;

                //    dg_empleado_seleciona_junta.DataSource = null;
                //    dg_empleado_seleciona_junta.DataBind();

                //    dg_empleado_para_junta_crea.DataSource = null;
                //    dg_empleado_para_junta_crea.DataBind();

                //    btn_crear_junta.Enabled = false;

                //    lbl_aviso_crearJunta_SINO.Text = Convert.ToString(cls_idioma.get_seleccionDeIdioma().Rows[cls_idioma.get_seleccionDeIdioma().Rows.IndexOf(cls_idioma.get_seleccionDeIdioma().Select("IDMSG='lbl_aviso_crearJunta_SI'")[0])]["STRMSG"]); ;


                //}
                //else
                //{
                //    lbl_aviso_crearJunta_SINO.Text = Convert.ToString(cls_idioma.get_seleccionDeIdioma().Rows[cls_idioma.get_seleccionDeIdioma().Rows.IndexOf(cls_idioma.get_seleccionDeIdioma().Select("IDMSG='lbl_aviso_crearJunta_NO'")[0])]["STRMSG"]); ;

                //}

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

        }

        protected void btn_cerrarJunta_junta_Click(object sender, EventArgs e)
        {
            try
            {

                cls_reunion reunion = new cls_reunion();
                string fechaJuntaCierre = "";
                string horaJuntaCierre = "";

                if (SienFechaJunta.Checked)
                {
                    fechaJuntaCierre= lbl_fecha_compromiso_cerrar_junta.Text;                  
                }
                else
                {
                    fechaJuntaCierre = txt_fechaReal_cerrar_junta.Text;
                }


                if (SienHoraJunta.Checked)
                {
                    horaJuntaCierre = lbl_hora_compromiso_cerrar_junta.Text;
                }
                else
                {
                    horaJuntaCierre = txt_horaReal_cerrar_junta.Text;
                }


                if (txt_conclucion_cerrar_junta.Text != "" && txt_conclucion_cerrar_junta.Text != " ")
                {

                    int respuesta = reunion.cerrarReunion(int.Parse(lbl_KEY_cerrar_junta.Text), txt_conclucion_cerrar_junta.Text,
                                   fechaJuntaCierre, horaJuntaCierre, cls_acceso.get_ID());



                    if (respuesta == 1)
                    {

                        lbl_KEY_cerrar_junta.Text = "";
                        lbl_aviso_concluciones_cerrar_junta.Text = "";
                        txt_fechaReal_cerrar_junta.Text = "";
                        txt_horaReal_cerrar_junta.Text = "";
                        dg_junta_cerrar_selecion.DataSource = null;
                        dg_junta_cerrar_selecion.DataBind();
                        txt_conclucion_cerrar_junta.Text = null;
                        txt_asunto_cerrar_junta.Text = null;
                        SienHoraJunta.Checked = true;
                        SienFechaJunta.Checked = true;
                        lbl_aviso_cerrarJunta_junta.Text = Convert.ToString(cls_idioma.get_seleccionDeIdioma().Rows[cls_idioma.get_seleccionDeIdioma().Rows.IndexOf(cls_idioma.get_seleccionDeIdioma().Select("IDMSG='lbl_aviso_cerrarJunta_junta'")[0])]["STRMSG"]);
                        btn_cerrarJunta_junta.Visible = false;
                        Msg.ShowMsg(this, "Se cerró con éxito.");

                        //Response.Redirect("~/graficas/grafica.aspx", false);

                    }
                    else
                    {
                        lbl_aviso_cerrarJunta_junta.Text = "HA OCURRIDO UN ERROR";

                    }

                }
                else {
                    lbl_aviso_cerrarJunta_junta.Text = "Es necesario una conclusión para cerrar la Junta";
                
                }


            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

            //dg_junta_cerrar_selecion_ItemCommand
        }

        protected void dg_junta_cerrar_selecion_ItemCommand(object sender, DataGridCommandEventArgs e)
        {
            try
            {
                lbl_KEY_cerrar_junta.Text = e.Item.Cells[1].Text; //IDReu
                lbl_fecha_compromiso_cerrar_junta.Text = e.Item.Cells[2].Text;//fComp
                txt_asunto_cerrar_junta.Text = e.Item.Cells[3].Text; //asunto  
                lbl_hora_compromiso_cerrar_junta.Text = e.Item.Cells[4].Text; //hComp


            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

            //dg_junta_cerrar_selecion_ItemCommand
        }

        protected void btn_img_empleado_ver_grid_junta_crea_Click(object sender, EventArgs e)
        {
            try
            {

                cls_empleado empleado = new cls_empleado();



                dg_empleado_seleciona_junta.DataSource = empleado.verTodosEmpelados(cls_acceso.get_ID());
                dg_empleado_seleciona_junta.DataBind();


            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

            //btn_img_empleado_ver_grid_junta_crea_Click
        }

        protected void dg_empleado_seleciona_junta_ItemCommand(object sender, DataGridCommandEventArgs e)
        {

            try
            {

                lbl_aviso_Empleados_incluidos_Junta.Text = "<strong>" + Convert.ToString(cls_idioma.get_seleccionDeIdioma().Rows[cls_idioma.get_seleccionDeIdioma().Rows.IndexOf(cls_idioma.get_seleccionDeIdioma().Select("IDMSG='lbl_aviso_Empleados_incluidos_Junta'")[0])]["STRMSG"]) + "</strong>";

                DataRow row = cls_reunion.get_miembrosDeJunta().NewRow();

                row["IDempleado"] = e.Item.Cells[1].Text;
                row["nombreEmp"] = e.Item.Cells[2].Text;
                row["apePat"] = e.Item.Cells[3].Text;
                row["nomArea"] = e.Item.Cells[4].Text;

                cls_reunion.set_miembrosDeJunta(row);

                dg_empleado_para_junta_crea.DataSource = cls_reunion.get_miembrosDeJunta();
                dg_empleado_para_junta_crea.DataBind();

                btn_crear_junta.Enabled = true;

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

            //dg_empleado_seleciona_junta_ItemCommand
        }

        protected void dg_empleado_para_junta_crea_ItemCommand(object sender, DataGridCommandEventArgs e)
        {

            try
            {

                cls_reunion.get_miembrosDeJunta().Rows[e.Item.ItemIndex].Delete();

                cls_reunion.get_miembrosDeJunta().AcceptChanges();

                dg_empleado_para_junta_crea.DataSource = cls_reunion.get_miembrosDeJunta();
                dg_empleado_para_junta_crea.DataBind();

                if (cls_reunion.get_miembrosDeJunta().Rows.Count <= 0)
                {
                    btn_crear_junta.Enabled = false;
                }
                else
                {
                    btn_crear_junta.Enabled = true;
                }


            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

            //dg_empleado_seleciona_junta_ItemCommand
        }

        protected void SienFechaJunta_CheckedChanged(object sender, EventArgs e)
        {
            try {

                if (SienFechaJunta.Checked)
                {
                    lbl_aviso_fechaReal_cerrar_junta.Visible = false;
                    txt_fechaReal_cerrar_junta.Visible = false;
                    validator_txt_fechaReal_cerrar_junta.Visible = false;
                }
                else {
                    lbl_aviso_fechaReal_cerrar_junta.Visible = true;
                    txt_fechaReal_cerrar_junta.Visible = true;
                    validator_txt_fechaReal_cerrar_junta.Visible = true;
                }

            }catch(Exception ex_){
                cls_errores.muestraWebError(ex_);
            }//try-catch
            //SienFechaJunta_CheckedChanged
        }

        protected void SienHoraJunta_CheckedChanged(object sender, EventArgs e)
        {
            try {
                if (SienHoraJunta.Checked)
                {
                lbl_aviso_horaReal_cerrar_junta.Visible = false;
                txt_horaReal_cerrar_junta.Visible = false;
                validator_horaReal_cerrar_junta.Visible = false;
                }else{
                   lbl_aviso_horaReal_cerrar_junta.Visible = true;
                txt_horaReal_cerrar_junta.Visible = true;
                validator_horaReal_cerrar_junta.Visible = true;
                
                }
            }catch(Exception ex_){
                cls_errores.muestraWebError(ex_);
            }//try-catch
            //SienFechaJunta_CheckedChanged
        }




    }
}