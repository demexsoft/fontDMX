using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using betaCulturalMARKII.equipo;
using betaCulturalMARKII.idioma;
using betaCulturalMARKII.matrizEquipo;

namespace betaCulturalMARKII.matrizIndiv
{
    public partial class individual_folders_fecha : System.Web.UI.Page
    {

        cls_Utilerias Msg = new cls_Utilerias();

        protected void Page_Load(object sender, EventArgs e)
        {
            try{
                crear_carpetas_meses();
            }catch(Exception ex_){
                cls_errores.muestraWebError(ex_);
            }
            
        }//Page Load
        protected void click_muestraInformacionMes(int mes, int anio)
        {
            try
            {
                

                cls_matrizIndividual matriz = new cls_matrizIndividual();
                lbl_aviso_indicacionesMatrizIndividual.Text = Convert.ToString(cls_idioma.get_seleccionDeIdioma().Rows[cls_idioma.get_seleccionDeIdioma().Rows.IndexOf(cls_idioma.get_seleccionDeIdioma().Select("IDMSG='lbl_aviso_indicacionesMatrizIndividual'")[0])]["STRMSG"]);
                dg_verTodasMatrizesIndividual.DataSource = matriz.verTodasMatrizIndividual(cls_acceso.get_ID(), mes, anio);
                dg_verTodasMatrizesIndividual.DataBind();

                pnl_content_folders.Visible = false;
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch
        }

        static string textComponente;

        public void calendario(TextBox txtboxes)
        {

            textComponente = txtboxes.ID.ToString();


            pnl_content_calendario.Style["left"] = "100px";
            pnl_content_calendario.Style["top"] = "100px";



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

        }

        protected void btn_img_enero_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                int anioNow = DateTime.Now.Year;
                click_muestraInformacionMes(1, anioNow);

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

        }

        protected void btn_img_febrero_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                int anioNow = DateTime.Now.Year;
                click_muestraInformacionMes(2, anioNow);

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

        }

        protected void btn_img_marzo_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                int anioNow = DateTime.Now.Year;
                click_muestraInformacionMes(3, anioNow);
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch
        }

        protected void btn_img_abril_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                int anioNow = DateTime.Now.Year;
                click_muestraInformacionMes(4, anioNow);
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

        }

        protected void btn_img_mayo_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                int anioNow = DateTime.Now.Year;
                click_muestraInformacionMes(5, anioNow);
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch
        }

        protected void btn_img_junio_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                int anioNow = DateTime.Now.Year;
                click_muestraInformacionMes(6, anioNow);
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch
        }

        protected void btn_img_julio_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                int anioNow = DateTime.Now.Year;
                click_muestraInformacionMes(7, anioNow);
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch
        }

        protected void btn_img_agosto_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                int anioNow = DateTime.Now.Year;
                click_muestraInformacionMes(8, anioNow);
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch
        }

        protected void btn_img_septiembre_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                int anioNow = DateTime.Now.Year;
                click_muestraInformacionMes(9, anioNow);
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch
        }

        protected void btn_img_octubre_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                int anioNow = DateTime.Now.Year;
                click_muestraInformacionMes(10, anioNow);
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch
        }

        protected void btn_img_noviembre_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                int anioNow = DateTime.Now.Year;
                click_muestraInformacionMes(11, anioNow);
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch
        }

        protected void btn_img_diciembre_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                int anioNow = DateTime.Now.Year;
                click_muestraInformacionMes(12, anioNow);
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch
        }
        protected void cln_calendarioGenerico_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                pnl_content_calendario.Visible = false;
                
                
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch
        }

        protected void btn_img_rangoFechas_inicio_matriz_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                calendario(txt_rangoFechas_inicio_matriz);
                pnl_content_calendario.Visible = true;


            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch
        }

        protected void btn_img_rangoFechas_fin_matriz_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                calendario(txt_rangoFechas_fin_matriz);
                pnl_content_calendario.Visible = true;
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch
        }
        protected void btn_rangoFechas_buscar_matriz_Click(object sender, EventArgs e)
        {
            try
            {
                cls_matrizIndividual matrizIndividual = new cls_matrizIndividual();
                DataTable dt_matriz_individual = new DataTable();

                lbl_aviso_indicacionesMatrizIndividual.Text = Convert.ToString(cls_idioma.get_seleccionDeIdioma().Rows[cls_idioma.get_seleccionDeIdioma().Rows.IndexOf(cls_idioma.get_seleccionDeIdioma().Select("IDMSG='lbl_aviso_indicacionesMatrizIndividual'")[0])]["STRMSG"]);

                dt_matriz_individual = matrizIndividual.verTodasMatrizIndividualPeriodo(cls_acceso.get_ID(), txt_rangoFechas_inicio_matriz.Text, txt_rangoFechas_fin_matriz.Text );
                dg_verTodasMatrizesIndividual.DataSource = dt_matriz_individual;
                dg_verTodasMatrizesIndividual.DataBind();


            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

        }

        protected void dg_verTodasMatrizes_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
                cls_matrizIndividual.set_ultimoMatriz_(int.Parse(e.Item.Cells[2].Text));
                Msg.OpcionMenu = 2;
                Session["OpcMenu"] = Msg;
                Response.Redirect("~/wf_MatrizIndividual.aspx", false);
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch


            //dg_verTodasMatrizes_ItemCommand
        }

        protected void dg_verTodasMatrizesIndividual_OnItemCreated(object sender, DataGridItemEventArgs e)
        {



            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {


                float eficienciaMatriz = float.Parse(dg_verTodasMatrizesIndividual.DataKeys[e.Item.ItemIndex].ToString());

           
                Image lbl_mat = (Image)e.Item.FindControl("lbl_grafica_mat_Individual");

                Label lbl_Efectividad = (Label)e.Item.FindControl("lbl_PorcEfectividad");
                lbl_Efectividad.Text = eficienciaMatriz.ToString("##,##") + "%";


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

        protected void crear_carpetas_meses()
        {


            try
            {


                //pone titulos a las carpetas de los meses


                lbl_aviso_enero.Text = Convert.ToString(cls_idioma.get_seleccionDeIdioma().Rows[cls_idioma.get_seleccionDeIdioma().Rows.IndexOf(cls_idioma.get_seleccionDeIdioma().Select("IDMSG='lbl_aviso_enero'")[0])]["STRMSG"]);
                lbl_aviso_febrero.Text = Convert.ToString(cls_idioma.get_seleccionDeIdioma().Rows[cls_idioma.get_seleccionDeIdioma().Rows.IndexOf(cls_idioma.get_seleccionDeIdioma().Select("IDMSG='lbl_aviso_febrero'")[0])]["STRMSG"]);
                lbl_aviso_marzo.Text = Convert.ToString(cls_idioma.get_seleccionDeIdioma().Rows[cls_idioma.get_seleccionDeIdioma().Rows.IndexOf(cls_idioma.get_seleccionDeIdioma().Select("IDMSG='lbl_aviso_marzo'")[0])]["STRMSG"]);
                lbl_aviso_abril.Text = Convert.ToString(cls_idioma.get_seleccionDeIdioma().Rows[cls_idioma.get_seleccionDeIdioma().Rows.IndexOf(cls_idioma.get_seleccionDeIdioma().Select("IDMSG='lbl_aviso_abril'")[0])]["STRMSG"]);
                lbl_aviso_mayo.Text = Convert.ToString(cls_idioma.get_seleccionDeIdioma().Rows[cls_idioma.get_seleccionDeIdioma().Rows.IndexOf(cls_idioma.get_seleccionDeIdioma().Select("IDMSG='lbl_aviso_mayo'")[0])]["STRMSG"]);
                lbl_aviso_junio.Text = Convert.ToString(cls_idioma.get_seleccionDeIdioma().Rows[cls_idioma.get_seleccionDeIdioma().Rows.IndexOf(cls_idioma.get_seleccionDeIdioma().Select("IDMSG='lbl_aviso_junio'")[0])]["STRMSG"]);
                lbl_aviso_julio.Text = Convert.ToString(cls_idioma.get_seleccionDeIdioma().Rows[cls_idioma.get_seleccionDeIdioma().Rows.IndexOf(cls_idioma.get_seleccionDeIdioma().Select("IDMSG='lbl_aviso_julio'")[0])]["STRMSG"]);
                lbl_aviso_agosto.Text = Convert.ToString(cls_idioma.get_seleccionDeIdioma().Rows[cls_idioma.get_seleccionDeIdioma().Rows.IndexOf(cls_idioma.get_seleccionDeIdioma().Select("IDMSG='lbl_aviso_agosto'")[0])]["STRMSG"]);
                lbl_aviso_septiembre.Text = Convert.ToString(cls_idioma.get_seleccionDeIdioma().Rows[cls_idioma.get_seleccionDeIdioma().Rows.IndexOf(cls_idioma.get_seleccionDeIdioma().Select("IDMSG='lbl_aviso_septiembre'")[0])]["STRMSG"]);
                lbl_aviso_octubre.Text = Convert.ToString(cls_idioma.get_seleccionDeIdioma().Rows[cls_idioma.get_seleccionDeIdioma().Rows.IndexOf(cls_idioma.get_seleccionDeIdioma().Select("IDMSG='lbl_aviso_octubre'")[0])]["STRMSG"]);
                lbl_aviso_noviembre.Text = Convert.ToString(cls_idioma.get_seleccionDeIdioma().Rows[cls_idioma.get_seleccionDeIdioma().Rows.IndexOf(cls_idioma.get_seleccionDeIdioma().Select("IDMSG='lbl_aviso_noviembre'")[0])]["STRMSG"]);
                lbl_aviso_diciembre.Text = Convert.ToString(cls_idioma.get_seleccionDeIdioma().Rows[cls_idioma.get_seleccionDeIdioma().Rows.IndexOf(cls_idioma.get_seleccionDeIdioma().Select("IDMSG='lbl_aviso_diciembre'")[0])]["STRMSG"]);





            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);

            }//try-catch


            //crear_carpetas_meses
        }


    }//class individual_folders_fecha
}