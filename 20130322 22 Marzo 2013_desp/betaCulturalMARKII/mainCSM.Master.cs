using System;
using System.Web.UI;
using betaCulturalMARKII.equipo;
using betaCulturalMARKII.idioma;
using System.Data;

namespace betaCulturalMARKII
{
    public partial class mainCSM : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (cls_acceso.get_Pass() == "" || cls_acceso.get_Pass() == " " || cls_acceso.get_Usuario() == "" || cls_acceso.get_Usuario() == " ")
                {
                    Response.Redirect("Default.aspx", false);

                }
                else
                {

                    if ((string)Session["gsUsuarioCul"] == "" || Session["gsPassCul"] == null || cls_acceso.get_Usuario() == null || cls_acceso.get_Pass() == null)
                    {
                        Response.Redirect("Default.aspx", false);
                    }
                    else
                    {


                       lbl_nombre_equipo.Text =cls_equipo.get_NomEquipo();
                        lbl_nombre_empleado.Text = cls_acceso.get_Usuario();
                        lbl_nombre_jefe.Text = cls_equipo.get_NomJefeEquipo();


                        lbl_lider_general.Text = "<strong>" + Convert.ToString(cls_idioma.get_seleccionDeIdioma().Rows[cls_idioma.get_seleccionDeIdioma().Rows.IndexOf(cls_idioma.get_seleccionDeIdioma().Select("IDMSG='lider_general'")[0])]["STRMSG"]) + "</strong>";
                        lbl_equipo_general.Text = "<strong>" + Convert.ToString(cls_idioma.get_seleccionDeIdioma().Rows[cls_idioma.get_seleccionDeIdioma().Rows.IndexOf(cls_idioma.get_seleccionDeIdioma().Select("IDMSG='equipo_general'")[0])]["STRMSG"]) + "</strong>";
                        lbl_empleado_general.Text = "<strong>" + Convert.ToString(cls_idioma.get_seleccionDeIdioma().Rows[cls_idioma.get_seleccionDeIdioma().Rows.IndexOf(cls_idioma.get_seleccionDeIdioma().Select("IDMSG='empleado_general'")[0])]["STRMSG"]) + "</strong>";

                       

                        //if (cls_configuracion._ADMIN() == cls_acceso.get_Perfil())
                        //{



                        //    pnl_content_configuracion.Visible = false;


                        //    // DataRow[] rowCerrar = cls_configuracion.getPerfiles().Select("idPermiso='" + cls_acceso.get_Perfil() + "'");
                        //    //lbl_pefil_general.Text = rowCerrar[0][0].ToString();

                        //    DataRow[] rowIdioma = cls_idioma.get_seleccionDeIdioma().Select("IDMSG='lbl_pefil_general_administrador'");
                        //    lbl_pefil_general.Text = "<strong>" + rowIdioma[0]["STRMSG"].ToString() + "</strong>";


                        //}
                        //else if (cls_configuracion._INTEGRANTE() == cls_acceso.get_Perfil())
                        //{




                        //}
                        //else if (cls_configuracion._LIDER() == cls_acceso.get_Perfil())
                        //{



                        //}//else
                        

                    }//if-else null


                }//if-else

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }

        }

        protected void btn_img_empresaConfiguracion_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Response.Redirect("~/empleado/empleado.aspx", false);
                pnl_content_configuracion.Visible = true;
                pnl_content_teamTool.Visible = false;
                pnl_content_controles_individuales.Visible = false;
                pnl_content_performed.Visible = false;



            }
            catch (Exception ex_)
            {

                cls_errores.muestraWebError(ex_);

            }//try-catch

            //btn_img_empresaConfiguracion_Click
        }

        protected void btn_img_herramientasEquipo_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                tbl_config_empresa.Visible = false;
                pnl_content_configuracion.Visible = false;
                pnl_content_teamTool.Visible = true;
                pnl_content_controles_individuales.Visible = false;
                pnl_content_performed.Visible = false;

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

            //btn_img_herramientasEquipo_Click
        }


        protected void btn_img_performance_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                pnl_content_configuracion.Visible = false;
                pnl_content_teamTool.Visible = false;
                pnl_content_controles_individuales.Visible = false;

                pnl_content_performed.Visible = true;



            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

            //btn_img_performance_Click
        }

        protected void btn_img_individual_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                pnl_content_configuracion.Visible = false;
                pnl_content_teamTool.Visible = false;
                pnl_content_controles_individuales.Visible = true;

                pnl_content_performed.Visible = false;




            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

            //btn_img_empresaConfiguracion_Click
        }
        protected void btn_link_ver_DashBoard_Click(object sender, EventArgs e)
        {
            try
            {

                pnl_content_configuracion.Visible = false;
                pnl_content_teamTool.Visible = false;
                pnl_content_controles_individuales.Visible = false;

                pnl_content_performed.Visible = false;


            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

            //btn_link_ver_DashBoard_Click
        }

        protected void btn_img_matrizEquipoVigente_Click(object sender, ImageClickEventArgs e)
        {
            try
            {



            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch


            //btn_img_matrizEquipoVigente_Click
        }
        protected void btn_img_miMatrizVigente_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Response.Redirect("~/matrizIndiv/matrizIndividual.aspx",false);
                Session["compoMatrizIndividual"] = "vigente";
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

            //btn_img_miMatrizVigente_Click
        }
        protected void btn_img_crearEquipo_Click(object sender, ImageClickEventArgs e)
        {
            try
            {


            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch
        }
        protected void btn_agregarEmpleado_Click(object sender, ImageClickEventArgs e)
        {

            try
            {





            }
            catch (Exception ex_)
            {

                cls_errores.muestraWebError(ex_);
            }//try-catch


            //btn_agregarEmpleado_Click
        }

        protected void btn_quitarEmpleado_Click(object sender, ImageClickEventArgs e)
        {
            try
            {


            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch


            //btn_quitarEmpleado_Click
        }
        protected void btn_img_agregarArea_Click(object sender, ImageClickEventArgs e)
        {

            try
            {


            }
            catch (Exception ex_)
            {
                ex_.ToString();

            }//try-catch

            //btn_img_agregarArea_Click
        }
        protected void btn_img_todasAreas_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

            //btn_img_todasAreas_Click
        }

        protected void btn_img_quitarArea_Click(object sender, ImageClickEventArgs e)
        {
            try
            {




            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch
        }
        protected void btn_guardar_areas_Click(object sender, EventArgs e)
        {

            try
            {




            }
            catch (Exception ex_)
            {

                ex_.ToString();
            }//try-catch

            //btn_guardar_areas_Click
        }
        protected void btn_img_agregarIncongruencias_Click(object sender, EventArgs e)
        {
            try
            {



            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

            //btn_img_agregarIncongruencias_Click
        }
        protected void btn_img_recomendaciones_Click(object sender, EventArgs e)
        {
            try
            {




            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

        }
        protected void btn_img_graficas_Click(object sender, ImageClickEventArgs e)
        {
            try
            {


            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

            //btn_img_graficas_Click
        }

        protected void btn_img_misJuntasMiembro_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Response.Redirect("~/reunion/junta.aspx",false);
                tbl_herramientas_equipo.Visible = true;
                tbl_config_empresa.Visible = false;


            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch
            //btn_img_misJuntasMiembro_Click
        }

        protected void btn_img_juntasCreadas_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch
            //btn_img_juntasCreadas_Click
        }



        protected void btn_img_crearJunta_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

            //btn_img_crearJunta_Click
        }

        protected void btn_img_cerrarJunta_Click(object sender, ImageClickEventArgs e)
        {
            try
            {


            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

        }

        protected void btn_img_equipos_Click(object sender, ImageClickEventArgs e)
        {
            try
            {


            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

        }
        protected void btn_img_todasMatrices_equipo_Click(object sender, ImageClickEventArgs e)
        {
            try
            {


            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

            //voidbtn_img_todasMatrices_equipo_Click
        }
        protected void btn_img_crearMatrizEquipo_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

            //btn_img_crarMatrizEquipo_Click
        }
        protected void btn_img_matrices_todas_Click(object sender, EventArgs e)
        {
            try
            {



            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

            //btn_img_matrices_todas_Click
        }
        protected void btn_img_crearMatriz_Click(object sender, ImageClickEventArgs e)
        {
            try
            {




            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }

            //btn_img_crearMatriz_Click
        }


        protected void btn_img_objetivosEquipo_Click(object sender, ImageClickEventArgs e)
        {

            try
            {

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

            //btn_img_objetivosEquipo_Click
        }
        protected void btn_img_evalucacionCliente_Click(object sender, EventArgs e)
        {
            try
            {


            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

            //btn_img_evalucacionCliente_Click
        }



        protected void btn_lnk_menu_Click(object sender, EventArgs e)
        {
            try
            {



            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

            //btn_lnk_menu_Click
        }


        protected void btn_lnk_salir_Click(object sender, EventArgs e)
        {
            try
            {



                cls_acceso.set_ID(0);
                cls_acceso.set_Pass(null);
                cls_acceso.set_Usuario(null);

                cls_equipo.set_IDEquipo(0);
                cls_equipo.set_IDJefeEquipo(0);
                cls_equipo.set_misEquipos(0);
                cls_equipo.set_NomEquipo(null);
                cls_equipo.set_ultimoEquipo_(0);


                Session.Remove("gsPassCul");
                Session.Remove("gsUsuarioCul");


                System.GC.Collect();


                Response.ClearContent();
                Response.Redirect("Default.aspx", false);

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

        }

       



    }
}
