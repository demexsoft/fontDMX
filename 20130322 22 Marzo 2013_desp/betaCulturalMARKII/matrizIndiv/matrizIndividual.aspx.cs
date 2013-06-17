using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using betaCulturalMARKII.objetivoIndiv;
using System.Data;
using betaCulturalMARKII.idioma;
using betaCulturalMARKII.equipo;

namespace betaCulturalMARKII.matrizIndiv
{
    public partial class matrizIndividual : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cls_configuracion.tipoObjetivo();

            if (Session["compoMatrizIndividual"].ToString() == "vigente") {

                    matrizVigente();
                }

            //Page_Load

        }
        protected void matrizVigente() {
           try {

                DataTable dt_matrizVigente = new DataTable();
                cls_matrizIndividual matriz = new cls_matrizIndividual();

                dt_matrizVigente = matriz.verTodasMatrizIndividualVigente(cls_acceso.get_ID());

                btn_addMatrizIndividual.Visible = false;
                btn_objetivoAddIndividual.Visible = false;
                btn_addObjetivoNuevoIndividual.Visible = true;
                btn_img_CalendarioFin.Enabled = false;
                btn_img_CalendarioInicio.Enabled = false;
                cmb_estatusObjetivo.Enabled = true;

                //IDMatriz
                cls_matrizIndividual.set_ultimoMatriz_(int.Parse(dt_matrizVigente.Rows[0][0].ToString()));

                lbl_proEficienciaAddMatrizIndi.Text = dt_matrizVigente.Rows[0][3].ToString();
                lbl_proEficaciaAddMatrizIndi.Text = dt_matrizVigente.Rows[0][4].ToString();

                txt_fechaInicioAddMatrizIndi.Text = dt_matrizVigente.Rows[0][6].ToString();
                txt_fechaFinalAddMatrizIndi.Text = dt_matrizVigente.Rows[0][7].ToString();

                cls_objetivo.ini_DataTable();
                cls_objetivo objetivo = new cls_objetivo();

                DataTable dt_objetivosPriEmpleadoSelect = new DataTable();
                DataTable dt_objetivosSecEmpleadoSelect = new DataTable();
                DataTable dt_objetivosPerEmpleadoSelect = new DataTable();

                dt_objetivosPriEmpleadoSelect = cls_objetivo.verObjetivosEmpleado(cls_acceso.get_ID(), int.Parse(dt_matrizVigente.Rows[0][0].ToString()), cls_configuracion.get_tipoObjetivo_PRIORITARIO());
                dt_objetivosSecEmpleadoSelect = cls_objetivo.verObjetivosEmpleado(cls_acceso.get_ID(), int.Parse(dt_matrizVigente.Rows[0][0].ToString()), cls_configuracion.get_tipoObjetivo_SECUNDARIO());
                dt_objetivosPerEmpleadoSelect = cls_objetivo.verObjetivosEmpleado(cls_acceso.get_ID(), int.Parse(dt_matrizVigente.Rows[0][0].ToString()), cls_configuracion.get_tipoObjetivo_PERMANENTE());

                dg_objetivosAddMatrizIndi.DataSource = dt_objetivosPriEmpleadoSelect;
                dg_objetivosAddMatrizIndi.DataBind();

                dg_objetivos_secundarios_individuales.DataSource = dt_objetivosSecEmpleadoSelect;
                dg_objetivos_secundarios_individuales.DataBind();

                dg_objetivos_permanentes_individuales.DataSource = dt_objetivosPerEmpleadoSelect;
                dg_objetivos_permanentes_individuales.DataBind();

                cmb_estatusObjetivo.Items.Clear();

                cmb_estatusObjetivo.Items.Add(new ListItem(Convert.ToString(cls_idioma.get_seleccionDeIdioma().Rows[cls_idioma.get_seleccionDeIdioma().Rows.IndexOf(cls_idioma.get_seleccionDeIdioma().Select("IDMSG='cmb_item_objetivo_NO'")[0])]["STRMSG"]), "0"));
                cmb_estatusObjetivo.Items.Add(new ListItem(Convert.ToString(cls_idioma.get_seleccionDeIdioma().Rows[cls_idioma.get_seleccionDeIdioma().Rows.IndexOf(cls_idioma.get_seleccionDeIdioma().Select("IDMSG='cmb_item_objetivo_SI'")[0])]["STRMSG"]), "1"));

                dg_objetivosAddMatrizIndi.Columns[0].Visible = true;
                dg_objetivos_secundarios_individuales.Columns[0].Visible = true;
                dg_objetivos_permanentes_individuales.Columns[0].Visible = true;

                pnl_content_matrizIndividual.Visible = true;
            }catch(Exception ex_){
                   cls_errores.muestraWebError(ex_);    
            
            }//try-catch

            //matrizVigente
        }

        protected void dg_verTodasMatrizes_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {

                btn_addMatrizIndividual.Visible = false;
                btn_objetivoAddIndividual.Visible = false;
                btn_addObjetivoNuevoIndividual.Visible = true;
                btn_img_CalendarioFin.Enabled = false;
                btn_img_CalendarioInicio.Enabled = false;
                cmb_estatusObjetivo.Enabled = true;

                //IDMatriz
                cls_matrizIndividual.set_ultimoMatriz_(int.Parse(e.Item.Cells[2].Text));

                lbl_proEficienciaAddMatrizIndi.Text = e.Item.Cells[6].Text;
                lbl_proEficaciaAddMatrizIndi.Text = e.Item.Cells[7].Text;

                txt_fechaInicioAddMatrizIndi.Text = e.Item.Cells[9].Text;
                txt_fechaFinalAddMatrizIndi.Text = e.Item.Cells[10].Text;


                cls_objetivo.ini_DataTable();

                cls_objetivo objetivo = new cls_objetivo();




                DataTable dt_objetivosPriEmpleadoSelect = new DataTable();
                DataTable dt_objetivosSecEmpleadoSelect = new DataTable();
                DataTable dt_objetivosPerEmpleadoSelect = new DataTable();



                dt_objetivosPriEmpleadoSelect = cls_objetivo.verObjetivosEmpleado(cls_acceso.get_ID(), int.Parse(e.Item.Cells[2].Text), cls_configuracion.get_tipoObjetivo_PRIORITARIO());
                dt_objetivosSecEmpleadoSelect = cls_objetivo.verObjetivosEmpleado(cls_acceso.get_ID(), int.Parse(e.Item.Cells[2].Text), cls_configuracion.get_tipoObjetivo_SECUNDARIO());
                dt_objetivosPerEmpleadoSelect = cls_objetivo.verObjetivosEmpleado(cls_acceso.get_ID(), int.Parse(e.Item.Cells[2].Text), cls_configuracion.get_tipoObjetivo_PERMANENTE());

                dg_objetivosAddMatrizIndi.DataSource = dt_objetivosPriEmpleadoSelect;
                dg_objetivosAddMatrizIndi.DataBind();

                dg_objetivos_secundarios_individuales.DataSource = dt_objetivosSecEmpleadoSelect;
                dg_objetivos_secundarios_individuales.DataBind();

                dg_objetivos_permanentes_individuales.DataSource = dt_objetivosPerEmpleadoSelect;
                dg_objetivos_permanentes_individuales.DataBind();






                cmb_estatusObjetivo.Items.Clear();

                cmb_estatusObjetivo.Items.Add(new ListItem(Convert.ToString(cls_idioma.get_seleccionDeIdioma().Rows[cls_idioma.get_seleccionDeIdioma().Rows.IndexOf(cls_idioma.get_seleccionDeIdioma().Select("IDMSG='cmb_item_objetivo_NO'")[0])]["STRMSG"]), "0"));
                cmb_estatusObjetivo.Items.Add(new ListItem(Convert.ToString(cls_idioma.get_seleccionDeIdioma().Rows[cls_idioma.get_seleccionDeIdioma().Rows.IndexOf(cls_idioma.get_seleccionDeIdioma().Select("IDMSG='cmb_item_objetivo_SI'")[0])]["STRMSG"]), "1"));


                dg_objetivosAddMatrizIndi.Columns[0].Visible = true;
                dg_objetivos_secundarios_individuales.Columns[0].Visible = true;
                dg_objetivos_permanentes_individuales.Columns[0].Visible = true;

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch


            //dg_verTodasMatrizes_ItemCommand
        }
        protected void dg_objetivos_secundarios_individuales_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {

                cls_objetivo.set_IDobejtivoIndividual(int.Parse(e.Item.Cells[1].Text));

                txt_descripcionObjetivoAdd.Text = e.Item.Cells[2].Text;
                txt_areasOportunidadObjetivoAdd.Text = e.Item.Cells[10].Text;
                txt_fechaCompromisoObjetivoAdd.Text = e.Item.Cells[4].Text;

                txt_fechaCumplimientoObjetivoAdd.Text = e.Item.Cells[8].Text;
                lbl_semanaAtrasoObjetivoAdd.Text = e.Item.Cells[9].Text;
                lbl_eficaciaObjetivoAdd.Text = e.Item.Cells[6].Text;
                lbl_eficienciaObjetivoAdd.Text = e.Item.Cells[7].Text;

                btn_addObjetivoNuevoIndividual.Visible = false;



                if (int.Parse(e.Item.Cells[5].Text) == 1)
                {

                    btn_objetivoAddIndividual.Visible = false;
                    btn_addObjetivoNuevoIndividual.Visible = true;
                    btn_addMatrizIndividual.Visible = false;
                    cmb_estatusObjetivo.Enabled = false;
                    btn_cancelarCambioObjetivoIndividual.Visible = false;
                    btn_guardarCambioObjetivoIndividual.Visible = false;



                }
                else
                {

                    cmb_estatusObjetivo.Enabled = true;
                    btn_guardarCambioObjetivoIndividual.Visible = true;
                    btn_cancelarCambioObjetivoIndividual.Visible = true;

                }

                pnl_controles_matrizIndividual.Visible = true;

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

            //dg_objetivosAddMatrizIndi_ItemCommand
        }


        protected void dg_objetivos_permanentes_individuales_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {

               


                cls_objetivo.set_IDobejtivoIndividual(int.Parse(e.Item.Cells[1].Text));

                txt_descripcionObjetivoAdd.Text = e.Item.Cells[2].Text;
                txt_areasOportunidadObjetivoAdd.Text = e.Item.Cells[10].Text;
                txt_fechaCompromisoObjetivoAdd.Text = e.Item.Cells[4].Text;

                txt_fechaCumplimientoObjetivoAdd.Text = e.Item.Cells[8].Text;
                lbl_semanaAtrasoObjetivoAdd.Text = e.Item.Cells[9].Text;
                lbl_eficaciaObjetivoAdd.Text = e.Item.Cells[6].Text;
                lbl_eficienciaObjetivoAdd.Text = e.Item.Cells[7].Text;

                btn_addObjetivoNuevoIndividual.Visible = false;



                if (int.Parse(e.Item.Cells[5].Text) == 1)
                {

                    btn_objetivoAddIndividual.Visible = false;
                    btn_addObjetivoNuevoIndividual.Visible = true;
                    btn_addMatrizIndividual.Visible = false;
                    cmb_estatusObjetivo.Enabled = false;
                    btn_cancelarCambioObjetivoIndividual.Visible = false;
                    btn_guardarCambioObjetivoIndividual.Visible = false;



                }
                else
                {

                    cmb_estatusObjetivo.Enabled = true;
                    btn_guardarCambioObjetivoIndividual.Visible = true;
                    btn_cancelarCambioObjetivoIndividual.Visible = true;

                }
                pnl_controles_matrizIndividual.Visible = true;

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

            //dg_objetivosAddMatrizIndi_ItemCommand
        }



        protected void dg_verTodasMatrizes_OnItemCreated(object sender, DataGridItemEventArgs e)
        {


            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {


                float eficienciaMatriz = float.Parse(dg_verTodasMatrizes.DataKeys[e.Item.ItemIndex].ToString());

                //Label lbl_mat = (Label)e.Item.FindControl("lbl_grafica_mat");
                Image lbl_mat = (Image)e.Item.FindControl("lbl_grafica_mat");

                lbl_mat.Height = 15;
                if (eficienciaMatriz > 101 && eficienciaMatriz <= 210)
                {
                    lbl_mat.Width = 100;

                    lbl_mat.ImageUrl = "~/imagenesBasicas/imagenesDataGrids/barTur.png";
                    // lbl_mat.BackColor = System.Drawing.Color.Pink;
                }
                if (eficienciaMatriz == 100)
                {
                    lbl_mat.Width = 100;

                    // lbl_mat.BackColor = System.Drawing.Color.Green;
                    lbl_mat.ImageUrl = "~/imagenesBasicas/imagenesDataGrids/barVerde.png";
                }

                if (eficienciaMatriz > 80 && eficienciaMatriz <= 99.9)
                {
                    lbl_mat.Width = 85;

                    // lbl_mat.BackColor = System.Drawing.Color.Green;
                    lbl_mat.ImageUrl = "~/imagenesBasicas/imagenesDataGrids/barAzul.png";
                }
                if (eficienciaMatriz > 50 && eficienciaMatriz <= 80)
                {
                    lbl_mat.Width = 70;

                    // lbl_mat.BackColor = System.Drawing.Color.Green;
                    lbl_mat.ImageUrl = "~/imagenesBasicas/imagenesDataGrids/barNaranja.png";
                }
                if (eficienciaMatriz >= 50 && eficienciaMatriz <= 59.9)
                {
                    lbl_mat.Width = 50;

                    // lbl_mat.BackColor = System.Drawing.Color.Green;
                    lbl_mat.ImageUrl = "~/imagenesBasicas/imagenesDataGrids/barNaranja.png";
                }
                if (eficienciaMatriz > 25 && eficienciaMatriz <= 50)
                {
                    lbl_mat.Width = 50;
                    //lbl_mat.BackColor = System.Drawing.Color.Orange;
                    lbl_mat.ImageUrl = "~/imagenesBasicas/imagenesDataGrids/barNaranja.png";

                }
                if (eficienciaMatriz > 1 && eficienciaMatriz <= 25)
                {
                    lbl_mat.Width = 15;
                    // lbl_mat.BackColor = System.Drawing.Color.Yellow;
                    lbl_mat.ImageUrl = "~/imagenesBasicas/imagenesDataGrids/barRoja.png";

                } if (eficienciaMatriz > -1 && eficienciaMatriz <= 0.9)
                {
                    lbl_mat.Width = 4;
                    //lbl_mat.BackColor = System.Drawing.Color.Red;
                    lbl_mat.ImageUrl = "~/imagenesBasicas/imagenesDataGrids/barRoja.png";
                }
                if (eficienciaMatriz > 0.0 && eficienciaMatriz <= 1)
                {
                    lbl_mat.Width = 6;
                    //lbl_mat.BackColor = System.Drawing.Color.Red;
                    lbl_mat.ImageUrl = "~/imagenesBasicas/imagenesDataGrids/barRoja.png";
                }
                if (eficienciaMatriz < -1 && eficienciaMatriz >= -25)
                {
                    lbl_mat.Width = 1;
                    //lbl_mat.BackColor = System.Drawing.Color.Red;
                    lbl_mat.ImageUrl = "~/imagenesBasicas/imagenesDataGrids/barRoja.png";
                }


            }
        }//dg_verTodasMatrizes_OnItemCreated
        
        
        protected void btn_img_CalendarioFin_Click(object sender, EventArgs e)
        {
            try
            {
                calendario(txt_fechaFinalAddMatrizIndi);
                pnl_content_calendario.Visible = true;

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

            //btn_img_CalendarioFin_Click
        }
        protected void agregar_primarios_Click(object sender, EventArgs e)
        {
            try
            {

                pnl_controles_matrizIndividual.Visible = true;
                tbl_objetivos_primarios_empty.Visible = false;

                cls_objetivo objetivo = new cls_objetivo();

                Session["sessionseleccionTipo"] = cls_configuracion.get_tipoObjetivo_PRIORITARIO();

                tbl_objetivos_primarios_empty.Visible = false;

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch
            //agregar_primarios_Click
        }
        protected void agregar_secundarios_Click(object sender, EventArgs e)
        {
            try
            {

                pnl_controles_matrizIndividual.Visible = true;
                tbl_objetivos_secundarios_empty.Visible = false;

                cls_objetivo objetivo = new cls_objetivo();

                Session["sessionseleccionTipo"] = cls_configuracion.get_tipoObjetivo_SECUNDARIO();

                tbl_objetivos_secundarios_empty.Visible = false;

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch
            //agregar_secundarios_Click
        }
        protected void agregar_permanentes_Click(object sender, EventArgs e)
        {
            try
            {
                pnl_controles_matrizIndividual.Visible = true;
                tbl_objetivos_permanentes_empty.Visible = false;


                Session["sessionseleccionTipo"] = cls_configuracion.get_tipoObjetivo_PERMANENTE();

                tbl_objetivos_permanentes_empty.Visible = false;
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch
            //agregar_permanentes_Click
        }

        protected void btn_addMatrizIndividual_Click(object sender, EventArgs e)
        {
            try
            {



                cls_matrizIndividual matIndividual = new cls_matrizIndividual();
                cls_objetivo objetivo = new cls_objetivo();

                if (txt_fechaInicioAddMatrizIndi.Text == "" || txt_fechaFinalAddMatrizIndi.Text == "")
                {
                    lbl_mensajeMatriz_objetivo.Text = "Dede de seleccionar ambas fechas, Fecha Inicio/Final ";

                }
                else
                {


                    matIndividual.crearMatrizindividual(cls_acceso.get_ID(),
                                                        cls_equipo.get_IDJefeEquipo(),
                                                        cls_equipo.get_IDEquipo(),
                                                        cls_datos_globales.FechaHoyYYYYMMDD(), txt_fechaInicioAddMatrizIndi.Text,
                                                        txt_fechaFinalAddMatrizIndi.Text);

                    if (cls_matrizIndividual.get_ultimoMatriz_() == -1)
                    {
                        lbl_mensajeMatriz_objetivo.Text = "[MA0]Matriz No pudo ser creada";

                    }
                    else
                    {


                        for (int contPri = 0; contPri < cls_objetivo.get_objetivos().Rows.Count; contPri++)
                        {

                            if (objetivo.agregarObjetivo(cls_matrizIndividual.get_ultimoMatriz_(),
                                                        cls_acceso.get_ID(),
                                                        int.Parse(cls_objetivo.get_objetivos().Rows[contPri]["tipoObjetivo"].ToString()),
                                                        int.Parse(cls_objetivo.get_objetivos().Rows[contPri]["estatusObjetivo"].ToString()),
                                                        decimal.Parse(cls_objetivo.get_objetivos().Rows[contPri]["porEficacia"].ToString()),
                                                        decimal.Parse(cls_objetivo.get_objetivos().Rows[contPri]["porEficiencia"].ToString()),
                                                        int.Parse(cls_objetivo.get_objetivos().Rows[contPri]["semanasAtraso"].ToString()),
                                                        cls_objetivo.get_objetivos().Rows[contPri]["descObjetivo"].ToString(),
                                                        cls_objetivo.get_objetivos().Rows[contPri]["areaOportunidad"].ToString(),
                                                        cls_datos_globales.getFechaYMD(cls_objetivo.get_objetivos().Rows[contPri]["fechaCompro"].ToString()),
                                                        cls_equipo.get_IDEquipo()
                                 ) == 1)
                            {



                            }
                            else
                            {

                            }

                        }//for-contPri- primarios

                        for (int contSecu = 0; contSecu < cls_objetivo.get_objetivosSecundarios().Rows.Count; contSecu++)
                        {

                            if (objetivo.agregarObjetivo(cls_matrizIndividual.get_ultimoMatriz_(),
                                                        cls_acceso.get_ID(),
                                                        int.Parse(cls_objetivo.get_objetivosSecundarios().Rows[contSecu]["tipoObjetivo"].ToString()),
                                                        int.Parse(cls_objetivo.get_objetivosSecundarios().Rows[contSecu]["estatusObjetivo"].ToString()),
                                                        decimal.Parse(cls_objetivo.get_objetivosSecundarios().Rows[contSecu]["porEficacia"].ToString()),
                                                        decimal.Parse(cls_objetivo.get_objetivosSecundarios().Rows[contSecu]["porEficiencia"].ToString()),
                                                        int.Parse(cls_objetivo.get_objetivosSecundarios().Rows[contSecu]["semanasAtraso"].ToString()),
                                                        cls_objetivo.get_objetivosSecundarios().Rows[contSecu]["descObjetivo"].ToString(),
                                                        cls_objetivo.get_objetivosSecundarios().Rows[contSecu]["areaOportunidad"].ToString(),
                                                        cls_datos_globales.getFechaYMD(cls_objetivo.get_objetivosSecundarios().Rows[contSecu]["fechaCompro"].ToString()),
                                                        cls_equipo.get_IDEquipo()
                                 ) == 1)
                            {



                            }
                            else
                            {




                            }

                        }//for- contSecu- secundarios

                        for (int contPer = 0; contPer < cls_objetivo.get_objetivosPermanentes().Rows.Count; contPer++)
                        {

                            if (objetivo.agregarObjetivo(cls_matrizIndividual.get_ultimoMatriz_(),
                                                        cls_acceso.get_ID(),
                                                        int.Parse(cls_objetivo.get_objetivosPermanentes().Rows[contPer]["tipoObjetivo"].ToString()),
                                                        int.Parse(cls_objetivo.get_objetivosPermanentes().Rows[contPer]["estatusObjetivo"].ToString()),
                                                        decimal.Parse(cls_objetivo.get_objetivosPermanentes().Rows[contPer]["porEficacia"].ToString()),
                                                        decimal.Parse(cls_objetivo.get_objetivosPermanentes().Rows[contPer]["porEficiencia"].ToString()),
                                                        int.Parse(cls_objetivo.get_objetivosPermanentes().Rows[contPer]["semanasAtraso"].ToString()),
                                                        cls_objetivo.get_objetivosPermanentes().Rows[contPer]["descObjetivo"].ToString(),
                                                        cls_objetivo.get_objetivosPermanentes().Rows[contPer]["areaOportunidad"].ToString(),
                                                        cls_datos_globales.getFechaYMD(cls_objetivo.get_objetivosPermanentes().Rows[contPer]["fechaCompro"].ToString()),
                                                        cls_equipo.get_IDEquipo()
                                 ) == 1)
                            {



                            }
                            else
                            {




                            }

                        }//for- contSecu- secundarios



                        lbl_mensajeMatriz_objetivo.Text = "Matriz y Objetivos creados.";


                        dg_objetivosAddMatrizIndi.DataSource = null;
                        dg_objetivosAddMatrizIndi.DataBind();


                        dg_objetivos_secundarios_individuales.DataSource = null;
                        dg_objetivos_secundarios_individuales.DataBind();


                        dg_objetivos_permanentes_individuales.DataSource = null;
                        dg_objetivos_permanentes_individuales.DataBind();


                        txt_fechaInicioAddMatrizIndi.Text = "";
                        txt_fechaFinalAddMatrizIndi.Text = "";
                        btn_objetivoAddIndividual.Enabled = true;


                        txt_fechaInicioAddMatrizIndi.Text = "";
                        txt_fechaFinalAddMatrizIndi.Text = "";
                        txt_fechaCompromisoObjetivoAdd.Text = "";
                        txt_fechaCumplimientoObjetivoAdd.Text = "";



                        pnl_content_calendario.Visible = false;


                    }

                }//IF de fechas




            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

            //btn_addMatrizIndividual_Click
        }

        protected void dg_objetivosAddMatrizIndi_OnItemCreated(object sender, DataGridItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {


                // string id_status = dg_objetivosAddMatrizIndi.DataKeys[e.Item.ItemIndex].ToString();

                //// System.Web.UI.WebControls.Image imagen = (System.Web.UI.WebControls.Image)e.Item.FindControl("img_status_obj");
                // Image imagen = (Image)e.Item.FindControl("img_status_obj");

                // if (id_status == "1")
                // {
                //     imagen.ImageUrl = "~/imagenesBasicas/botonesImagenes/yes_icon.png";
                // }
                // if (id_status == "0")
                // {
                //     imagen.ImageUrl = "~/imagenesBasicas/botonesImagenes/no_icon.png";

                // }//if

            }
        }//GridView3_RowDataBound

        protected void dg_objetivosAddMatrizIndi_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {


                cls_objetivo.set_IDobejtivoIndividual(int.Parse(e.Item.Cells[1].Text));

                txt_descripcionObjetivoAdd.Text = e.Item.Cells[2].Text;
                txt_areasOportunidadObjetivoAdd.Text = e.Item.Cells[10].Text;
                txt_fechaCompromisoObjetivoAdd.Text = e.Item.Cells[4].Text;

                txt_fechaCumplimientoObjetivoAdd.Text = e.Item.Cells[8].Text;
                lbl_semanaAtrasoObjetivoAdd.Text = e.Item.Cells[9].Text;
                lbl_eficaciaObjetivoAdd.Text = e.Item.Cells[6].Text;
                lbl_eficienciaObjetivoAdd.Text = e.Item.Cells[7].Text;

                btn_addObjetivoNuevoIndividual.Visible = false;



                if (int.Parse(e.Item.Cells[5].Text) == 1)
                {

                    btn_objetivoAddIndividual.Visible = false;
                    btn_addObjetivoNuevoIndividual.Visible = true;
                    btn_addMatrizIndividual.Visible = false;
                    cmb_estatusObjetivo.Enabled = false;
                    btn_cancelarCambioObjetivoIndividual.Visible = false;
                    btn_guardarCambioObjetivoIndividual.Visible = false;



                }
                else
                {

                    cmb_estatusObjetivo.Enabled = true;
                    btn_guardarCambioObjetivoIndividual.Visible = true;
                    btn_cancelarCambioObjetivoIndividual.Visible = true;

                }

                pnl_controles_matrizIndividual.Visible = true;


            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

            //dg_objetivosAddMatrizIndi_ItemCommand
        }
         
        protected void btn_cancelarCambioObjetivoIndividual_Click(object sender, EventArgs e)
        {
            try
            {
                txt_fechaCompromisoObjetivoAdd.Text = "";
                txt_fechaCumplimientoObjetivoAdd.Text = "";
                lbl_semanaAtrasoObjetivoAdd.Text = "";
                txt_fechaCumplimientoObjetivoAdd.Text = "";
                txt_areasOportunidadObjetivoAdd.Text = "";
                lbl_eficaciaObjetivoAdd.Text = "";
                lbl_eficienciaObjetivoAdd.Text = "";
                txt_fechaCompromisoObjetivoAdd.Text = "";
                cmb_estatusObjetivo.SelectedIndex = -1;
                txt_descripcionObjetivoAdd.Text = "";


            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch
        }

        protected void btn_guardarCambioObjetivoIndividual_Click(object sender, EventArgs e)
        {
            try
            {
                int eficacia = 0;


                cls_objetivo objetivoIndividual = new cls_objetivo();

                if (int.Parse(cmb_estatusObjetivo.SelectedValue) == 1)
                {
                    eficacia = 100;

                }
                else
                {
                    eficacia = 0;
                }




                string strFecha1 = txt_fechaCompromisoObjetivoAdd.Text;
                string strFecha2 = txt_fechaCumplimientoObjetivoAdd.Text;

                DateTime dtFecha1 = DateTime.Parse(strFecha1);
                DateTime dtFecha2 = DateTime.Parse(strFecha2);

                decimal Dias = dtFecha1.DayOfYear - dtFecha2.DayOfYear;
                decimal Eficiencia = ((Dias / 7) * 100) + 100;


                int SemanasAtraso = int.Parse(Math.Abs(decimal.Round(Dias / 7)).ToString());

                int respuesta = (objetivoIndividual.cerrarObjetivo(cls_objetivo.get_IDobejtivoIndividual(),
                                                  cls_equipo.get_IDEquipo(), cls_acceso.get_ID(),
                                                  int.Parse(cmb_estatusObjetivo.SelectedValue), eficacia, Eficiencia,
                                                  SemanasAtraso, txt_areasOportunidadObjetivoAdd.Text, strFecha2));

                if (respuesta == 1)
                {

                    lbl_mensajeMatriz_objetivo.Text = "Objetivo Modificado";
                }
                else
                {
                    lbl_mensajeMatriz_objetivo.Text = "Ha Ocurrido un ERROR [MODOBJ-00]";

                }


            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch
        }

        protected void btn_addObjetivoNuevoIndividual_Click(object sender, EventArgs e)
        {
            try
            {

                cls_acceso.get_ID();
                cls_objetivo objetivo = new cls_objetivo();

                int eficacia = 0;

                if (int.Parse(cmb_estatusObjetivo.SelectedValue) == 1)
                {
                    eficacia = 100;

                }
                else
                {
                    eficacia = 0;
                }


                string strFecha1 = txt_fechaCompromisoObjetivoAdd.Text;
                //string strFecha2 = txt_fechaCumplimientoObjetivoAdd.Text;

                DateTime dtFecha1 = DateTime.Parse(strFecha1);
                //DateTime dtFecha2 = DateTime.Parse(strFecha2);

                //decimal Dias = dtFecha1.DayOfYear - dtFecha2.DayOfYear;
                //decimal Eficiencia = ((Dias / 7) * 100) + 100;


                //int SemanasAtraso = int.Parse(Math.Abs(decimal.Round(Dias / 7)).ToString());

                if (objetivo.agregarObjetivo(cls_matrizIndividual.get_ultimoMatriz_(),
                                                  cls_acceso.get_ID(),
                                                  cls_objetivo.get_tipoObjetivo_seleccionado(),
                                                  int.Parse(cmb_estatusObjetivo.SelectedValue.ToString()),
                                                  eficacia,
                                                  0,
                                                  0,
                                                  txt_descripcionObjetivoAdd.Text,
                                                  txt_areasOportunidadObjetivoAdd.Text,
                                                  txt_fechaCompromisoObjetivoAdd.Text,
                                                  cls_equipo.get_IDEquipo()) == 1)
                {



                    dg_objetivosAddMatrizIndi.DataSource = null;
                    dg_objetivosAddMatrizIndi.DataBind();


                    lbl_semanaAtrasoObjetivoAdd.Text = "";
                    txt_fechaCumplimientoObjetivoAdd.Text = "";
                    txt_areasOportunidadObjetivoAdd.Text = "";
                    lbl_eficaciaObjetivoAdd.Text = "";
                    lbl_eficienciaObjetivoAdd.Text = "";
                    txt_fechaCompromisoObjetivoAdd.Text = "";
                    txt_descripcionObjetivoAdd.Text = "";
                    cmb_estatusObjetivo.SelectedIndex = -1;



                    btn_objetivoAddIndividual.Enabled = true;
                    lbl_mensajeMatriz_objetivo.Text = "Objetivos creado";

                }
                else
                {
                    lbl_mensajeMatriz_objetivo.Text = "[OBJ0]algun objetivo NO fue agregado correctamente.";

                }//objetivo.agregarObjetivo







            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch


            //btn_addObjetivoNuevoIndividual_Click
        }
  
        protected void btn_objetivoAddIndividual_Click(object sender, EventArgs e)
        {
            try
            {




                int eficacia = 0;

                if (int.Parse(cmb_estatusObjetivo.SelectedValue) == 1)
                {
                    eficacia = 100;

                }
                else
                {
                    eficacia = 0;
                }



                //row["idMatrizIndi"] = cls_matrizIndividual.get_ultimoMatriz_(); //1




                if (cls_objetivo.get_objetivos().Rows.Count >= 1)
                {

                    btn_addMatrizIndividual.Visible = true;
                }
                else
                {
                    btn_addMatrizIndividual.Visible = false;

                }

                if (cls_objetivo.get_tipoObjetivo_seleccionado() == cls_configuracion.get_tipoObjetivo_PRIORITARIO())
                {
                    DataRow row = cls_objetivo.get_objetivos().NewRow();

                    string strFecha1 = txt_fechaCompromisoObjetivoAdd.Text;
                    string strFecha2 = txt_fechaCumplimientoObjetivoAdd.Text;
                    DateTime dtFecha1 = DateTime.Parse(strFecha1);
                    DateTime dtFecha2 = DateTime.Parse(strFecha2);
                    decimal Dias = dtFecha1.DayOfYear - dtFecha2.DayOfYear;
                    decimal Eficiencia = ((Dias / 7) * 100) + 100;
                    int SemanasAtraso = int.Parse(Math.Abs(decimal.Round(Dias / 7)).ToString());


                    row["IDObj"] = txt_descripcionObjetivoAdd.Text; //no es implementado
                    row["descObjetivo"] = txt_descripcionObjetivoAdd.Text; //2
                    row["tipoObjetivo"] = cls_objetivo.get_tipoObjetivo_seleccionado();//3
                    row["fechaCompro"] = txt_fechaCompromisoObjetivoAdd.Text; //4
                    row["estatusObjetivo"] = cmb_estatusObjetivo.SelectedValue; //5
                    row["porEficacia"] = eficacia; //6
                    row["porEficiencia"] = Eficiencia;//7
                    row["fechaCumpli"] = txt_fechaCumplimientoObjetivoAdd.Text;//8
                    row["semanasAtraso"] = SemanasAtraso;//9
                    row["areaOportunidad"] = txt_areasOportunidadObjetivoAdd.Text;//10
                    row["id_integrante"] = cls_acceso.get_ID();//11
                    row["id_equipo"] = cls_equipo.get_IDEquipo();


                    cls_objetivo.set_objetivos(row);


                }
                else if (cls_objetivo.get_tipoObjetivo_seleccionado() == cls_configuracion.get_tipoObjetivo_SECUNDARIO())
                {
                    DataRow row = cls_objetivo.get_objetivosSecundarios().NewRow();

                    string strFecha1 = txt_fechaCompromisoObjetivoAdd.Text;
                    string strFecha2 = txt_fechaCumplimientoObjetivoAdd.Text;
                    DateTime dtFecha1 = DateTime.Parse(strFecha1);
                    DateTime dtFecha2 = DateTime.Parse(strFecha2);
                    decimal Dias = dtFecha1.DayOfYear - dtFecha2.DayOfYear;
                    decimal Eficiencia = ((Dias / 7) * 100) + 100;
                    int SemanasAtraso = int.Parse(Math.Abs(decimal.Round(Dias / 7)).ToString());

                    row["IDObj"] = txt_descripcionObjetivoAdd.Text; //no es implementado
                    row["descObjetivo"] = txt_descripcionObjetivoAdd.Text; //2
                    row["tipoObjetivo"] = cls_objetivo.get_tipoObjetivo_seleccionado();//3
                    row["fechaCompro"] = txt_fechaCompromisoObjetivoAdd.Text; //4
                    row["estatusObjetivo"] = cmb_estatusObjetivo.SelectedValue; //5
                    row["porEficacia"] = eficacia; //6
                    row["porEficiencia"] = Eficiencia;//7
                    row["fechaCumpli"] = txt_fechaCumplimientoObjetivoAdd.Text;//8
                    row["semanasAtraso"] = SemanasAtraso;//9
                    row["areaOportunidad"] = txt_areasOportunidadObjetivoAdd.Text;//10
                    row["id_integrante"] = cls_acceso.get_ID();//11
                    row["id_equipo"] = cls_equipo.get_IDEquipo();


                    cls_objetivo.set_objetivosSecundarios(row);

                }
                else if (cls_objetivo.get_tipoObjetivo_seleccionado() == cls_configuracion.get_tipoObjetivo_PERMANENTE())
                {
                    DataRow row = cls_objetivo.get_objetivosPermanentes().NewRow();

                    string strFecha1 = txt_fechaCompromisoObjetivoAdd.Text;
                    string strFecha2 = txt_fechaCumplimientoObjetivoAdd.Text;
                    DateTime dtFecha1 = DateTime.Parse(strFecha1);
                    DateTime dtFecha2 = DateTime.Parse(strFecha2);
                    decimal Dias = dtFecha1.DayOfYear - dtFecha2.DayOfYear;
                    decimal Eficiencia = ((Dias / 7) * 100) + 100;
                    int SemanasAtraso = int.Parse(Math.Abs(decimal.Round(Dias / 7)).ToString());


                    row["IDObj"] = txt_descripcionObjetivoAdd.Text; //no es implementado
                    row["descObjetivo"] = txt_descripcionObjetivoAdd.Text; //2
                    row["tipoObjetivo"] = cls_objetivo.get_tipoObjetivo_seleccionado();//3
                    row["fechaCompro"] = txt_fechaCompromisoObjetivoAdd.Text; //4
                    row["estatusObjetivo"] = cmb_estatusObjetivo.SelectedValue; //5
                    row["porEficacia"] = eficacia; //6
                    row["porEficiencia"] = Eficiencia;//7
                    row["fechaCumpli"] = txt_fechaCumplimientoObjetivoAdd.Text;//8
                    row["semanasAtraso"] = SemanasAtraso;//9
                    row["areaOportunidad"] = txt_areasOportunidadObjetivoAdd.Text;//10
                    row["id_integrante"] = cls_acceso.get_ID();//11
                    row["id_equipo"] = cls_equipo.get_IDEquipo();


                    cls_objetivo.set_objetivosPermanentes(row);


                }

                dg_objetivosAddMatrizIndi.DataSource = cls_objetivo.get_objetivos();
                dg_objetivosAddMatrizIndi.DataBind();

                dg_objetivos_secundarios_individuales.DataSource = cls_objetivo.get_objetivosSecundarios();
                dg_objetivos_secundarios_individuales.DataBind();


                dg_objetivos_permanentes_individuales.DataSource = cls_objetivo.get_objetivosPermanentes();
                dg_objetivos_permanentes_individuales.DataBind();

                dg_objetivosAddMatrizIndi.Columns[0].Visible = false;
                dg_objetivos_secundarios_individuales.Columns[0].Visible = false;
                dg_objetivos_permanentes_individuales.Columns[0].Visible = false;


                pnl_controles_matrizIndividual.Visible = false;


                tbl_objetivos_primarios_empty.Visible = false;
                tbl_objetivos_secundarios_empty.Visible = false;
                tbl_objetivos_permanentes_empty.Visible = false;
               


                txt_descripcionObjetivoAdd.Text = "";
                lbl_semanaAtrasoObjetivoAdd.Text = "";
                txt_areasOportunidadObjetivoAdd.Text = "";
                lbl_eficaciaObjetivoAdd.Text = "0";
                lbl_eficienciaObjetivoAdd.Text = "0";


            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch



            //btn_objetivoAddIndividual_Click
        }
        static string textComponente;
        public void calendario(TextBox txtboxes)
        {

            textComponente = txtboxes.ID.ToString();


            pnl_content_calendario.Style["left"] = "100px";
            pnl_content_calendario.Style["top"] = "100px";

            //calendario
          }

        protected void btn_img_fechaCumplimientoObjetivoAdd_Click(object sender, EventArgs e)
        {
            try
            {
                calendario(txt_fechaCumplimientoObjetivoAdd);
                pnl_content_calendario.Visible = true;

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }
            //btn_img_fechaCumplimientoObjetivoAdd_Click
        }

        protected void btn_img_Compromiso_Click(object sender, EventArgs e)
        {
            try
            {
                calendario(txt_fechaCompromisoObjetivoAdd);
                pnl_content_calendario.Visible = true;

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }
            //btn_img_Cumplimiento_Click
        }


        protected void btn_img_CalendarioInicio_Click(object sender, EventArgs e)
        {
            try
            {
                pnl_content_calendario.Visible = true;
                calendario(txt_fechaInicioAddMatrizIndi);
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch
            //btn_img_CalendarioInicio_Click
        }
        protected void lnk_cerrar_panel_calendario_Click(object sender, EventArgs e)
        {
            try
            {
                pnl_content_calendario.Visible = false;
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

            //lnk_cerrar_panel_calendario_Click
        }

        protected void cln_calendarioGenerico_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                pnl_content_calendario.Visible = false;
                getDate();
                
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

            //cln_calendarioGenerico_SelectionChanged
        }

        public void getDate()
        {

            string fecha = cln_calendarioGenerico.SelectedDate.ToShortDateString();

            ((TextBox)FindControl(textComponente)).Text = fecha;
            cln_calendarioGenerico.SelectedDates.Clear();
            //getDate
        }


    }
}