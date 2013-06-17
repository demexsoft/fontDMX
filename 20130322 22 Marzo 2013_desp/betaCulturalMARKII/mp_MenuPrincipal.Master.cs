using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using betaCulturalMARKII.equipo;
using System.Data;
using betaCulturalMARKII.idioma;

namespace betaCulturalMARKII
{
    public partial class mp_MenuPrincipal : System.Web.UI.MasterPage
    {
        cls_Utilerias Msg = new cls_Utilerias();

        protected void Page_Load(object sender, EventArgs e)
        {                        
            lbl_nombre_equipo.Text = cls_equipo.get_NomEquipo();
            lbl_nombre_empleado.Text = cls_acceso.get_Usuario();
            lbl_nombre_jefe.Text = cls_equipo.get_NomJefeEquipo();


            lbl_lider_general.Text = "<strong>" + Convert.ToString(cls_idioma.get_seleccionDeIdioma().Rows[cls_idioma.get_seleccionDeIdioma().Rows.IndexOf(cls_idioma.get_seleccionDeIdioma().Select("IDMSG='lider_general'")[0])]["STRMSG"]) + "</strong>";
            lbl_equipo_general.Text = "<strong>" + Convert.ToString(cls_idioma.get_seleccionDeIdioma().Rows[cls_idioma.get_seleccionDeIdioma().Rows.IndexOf(cls_idioma.get_seleccionDeIdioma().Select("IDMSG='equipo_general'")[0])]["STRMSG"]) + "</strong>";
            lbl_empleado_general.Text = "<strong>" + Convert.ToString(cls_idioma.get_seleccionDeIdioma().Rows[cls_idioma.get_seleccionDeIdioma().Rows.IndexOf(cls_idioma.get_seleccionDeIdioma().Select("IDMSG='empleado_general'")[0])]["STRMSG"]) + "</strong>";
            //if (cls_configuracion._ADMIN() == cls_acceso.get_Perfil())
            //{

            //    DataRow[] rowIdioma = cls_idioma.get_seleccionDeIdioma().Select("IDMSG='lbl_pefil_general_administrador'");
            //    lbl_pefil_general.Text = "<strong>" + rowIdioma[0]["STRMSG"].ToString() + "</strong>";


            //}
            //else if (cls_configuracion._INTEGRANTE() == cls_acceso.get_Perfil())
            //{




            //}
            //else if (cls_configuracion._LIDER() == cls_acceso.get_Perfil())
            //{



            //}//else
            if (!Page.IsPostBack) 
            {
                ConstruyeMenu();
            }

        }

        protected void ConstruyeMenu() 
        {
            try
            {
                int nPerfil = cls_acceso.get_Perfil();
                DataSet dsOpcMenu = new DataSet();
                dsOpcMenu = Msg.opcMenu(nPerfil);

                if (dsOpcMenu.Tables.Count == 2) 
                {
                    //OPC CONFIGURACION DEL SISTEMA
                    if (int.Parse(dsOpcMenu.Tables[0].Rows[0]["MenuVisible"].ToString()) == 0)
                    {
                        MnConfiguracionSistema.Visible = false;
                        pnl_Configuracion.Visible = false;
                    }
                    else 
                    {
                        MnConfiguracionSistema.Visible = true;
                        pnl_Configuracion.Visible = true;
                        
                        //NoOPC 1 - 11
                        if (int.Parse(dsOpcMenu.Tables[1].Rows[0]["SubMenuVisible"].ToString()) == 1) { IDSubMenu1.Visible = true; } else { IDSubMenu1.Visible = false; }
                        if (int.Parse(dsOpcMenu.Tables[1].Rows[1]["SubMenuVisible"].ToString()) == 1) { IDSubMenu2.Visible = true; } else { IDSubMenu2.Visible = false; }
                        if (int.Parse(dsOpcMenu.Tables[1].Rows[2]["SubMenuVisible"].ToString()) == 1) { IDSubMenu3.Visible = true; } else { IDSubMenu3.Visible = false; }
                        //if (int.Parse(dsOpcMenu.Tables[1].Rows[3]["SubMenuVisible"].ToString()) == 1) { IDSubMenu4.Visible = true; } else { IDSubMenu4.Visible = false; }
                        //if (int.Parse(dsOpcMenu.Tables[1].Rows[4]["SubMenuVisible"].ToString()) == 1) { IDSubMenu5.Visible = true; } else { IDSubMenu5.Visible = false; }
                        if (int.Parse(dsOpcMenu.Tables[1].Rows[5]["SubMenuVisible"].ToString()) == 1) { IDSubMenu6.Visible = true; } else { IDSubMenu6.Visible = false; }
                        //if (int.Parse(dsOpcMenu.Tables[1].Rows[6]["SubMenuVisible"].ToString()) == 1) { IDSubMenu7.Visible = true; } else { IDSubMenu7.Visible = false; }
                        //if (int.Parse(dsOpcMenu.Tables[1].Rows[7]["SubMenuVisible"].ToString()) == 1) { IDSubMenu8.Visible = true; } else { IDSubMenu8.Visible = false; }
                        //if (int.Parse(dsOpcMenu.Tables[1].Rows[8]["SubMenuVisible"].ToString()) == 1) { IDSubMenu9.Visible = true; } else { IDSubMenu9.Visible = false; }
                        //if (int.Parse(dsOpcMenu.Tables[1].Rows[9]["SubMenuVisible"].ToString()) == 1) { IDSubMenu10.Visible = true; } else { IDSubMenu10.Visible = false; }
                        //if (int.Parse(dsOpcMenu.Tables[1].Rows[10]["SubMenuVisible"].ToString()) == 1) { IDSubMenu11.Visible = true; } else { IDSubMenu11.Visible = false; }
                    }

                    //OPC HERRAMIENTAS DE EQUIPO
                    if (int.Parse(dsOpcMenu.Tables[0].Rows[1]["MenuVisible"].ToString()) == 0)
                    {
                        MnHerramietasEquipo.Visible = false;
                        pnl_HerramientasEquipo.Visible = false;
                    }
                    else 
                    {
                        MnHerramietasEquipo.Visible = true;
                        pnl_HerramientasEquipo.Visible = true;
                        //NoOPC 12 - 17
                        if (int.Parse(dsOpcMenu.Tables[1].Rows[11]["SubMenuVisible"].ToString()) == 1) { IDSubMenu12.Visible = true; } else { IDSubMenu12.Visible = false; }
                        if (int.Parse(dsOpcMenu.Tables[1].Rows[12]["SubMenuVisible"].ToString()) == 1) { IDSubMenu13.Visible = true; } else { IDSubMenu13.Visible = false; }
                        if (int.Parse(dsOpcMenu.Tables[1].Rows[13]["SubMenuVisible"].ToString()) == 1) { IDSubMenu14.Visible = true; } else { IDSubMenu14.Visible = false; }
                        if (int.Parse(dsOpcMenu.Tables[1].Rows[14]["SubMenuVisible"].ToString()) == 1) { IDSubMenu15.Visible = true; } else { IDSubMenu15.Visible = false; }
                        //if (int.Parse(dsOpcMenu.Tables[1].Rows[15]["SubMenuVisible"].ToString()) == 1) { IDSubMenu16.Visible = true; } else { IDSubMenu16.Visible = false; }
                        //if (int.Parse(dsOpcMenu.Tables[1].Rows[16]["SubMenuVisible"].ToString()) == 1) { IDSubMenu17.Visible = true; } else { IDSubMenu17.Visible = false; }
                    }

                    //OPC DESEMPAÑO DEL SC
                    if (int.Parse(dsOpcMenu.Tables[0].Rows[2]["MenuVisible"].ToString()) == 0)
                    {
                        MnDesempenoSC.Visible = false;
                        pnl_CSperformance.Visible = false;
                    }
                    else 
                    {
                        MnDesempenoSC.Visible = true;
                        pnl_CSperformance.Visible = true;
                        //NoOPC 18 - 21
                        if (int.Parse(dsOpcMenu.Tables[1].Rows[17]["SubMenuVisible"].ToString()) == 1) { IDSubMenu18.Visible = true; } else { IDSubMenu18.Visible = false; }
                        //if (int.Parse(dsOpcMenu.Tables[1].Rows[18]["SubMenuVisible"].ToString()) == 1) { IDSubMenu19.Visible = true; } else { IDSubMenu19.Visible = false; }
                        //if (int.Parse(dsOpcMenu.Tables[1].Rows[19]["SubMenuVisible"].ToString()) == 1) { IDSubMenu20.Visible = true; } else { IDSubMenu20.Visible = false; }
                        //if (int.Parse(dsOpcMenu.Tables[1].Rows[20]["SubMenuVisible"].ToString()) == 1) { IDSubMenu21.Visible = true; } else { IDSubMenu21.Visible = false; }
                    }

                    //OPC HERRAMIENTAS INDIVIDUAL
                    if (int.Parse(dsOpcMenu.Tables[0].Rows[3]["MenuVisible"].ToString()) == 0)
                    {
                        MnHerramietasIndividual.Visible = false;
                        pnl_Individuales.Visible = false;                        
                    }
                    else 
                    {
                        MnHerramietasIndividual.Visible = true;
                        pnl_Individuales.Visible = true;
                        //NoOPC 22 - 23
                        if (int.Parse(dsOpcMenu.Tables[1].Rows[21]["SubMenuVisible"].ToString()) == 1) { IDSubMenu22.Visible = true; } else { IDSubMenu22.Visible = false; }
                        if (int.Parse(dsOpcMenu.Tables[1].Rows[22]["SubMenuVisible"].ToString()) == 1) { IDSubMenu23.Visible = true; } else { IDSubMenu23.Visible = false; }
                    }

                    //OPC CSM DASHBOARD
                    if (int.Parse(dsOpcMenu.Tables[0].Rows[4]["MenuVisible"].ToString()) == 0)
                    {
                        MnCSMDashboard.Visible = false;
                    }
                    else 
                    {
                        MnCSMDashboard.Visible = true;
                    }


                    //if (nPerfil == 3) 
                    //{
                    //    btn_img_matrizEquipoVigente.Visible=false;
                    //    Label50.Visible = false;
                    //}
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        protected void btn_lnk_menu_Click(object sender, EventArgs e)
        {
            try
            {

                
                Response.Redirect("~/graficas/grafica.aspx", false);
                Session["muestraGrafica"] = "admin";

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
                Response.Redirect("~/Default.aspx", false);

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

        }





        protected void btn_img_empresaConfiguracion_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                CollapsiblePanelExtender2.Collapsed = true;
                CollapsiblePanelExtender2.ClientState = "true";
                CollapsiblePanelExtender3.Collapsed = true;
                CollapsiblePanelExtender3.ClientState = "true";
                CollapsiblePanelExtender4.Collapsed = true;
                CollapsiblePanelExtender4.ClientState = "true";
                //CollapsiblePanelExtender5.Collapsed = true;
                //CollapsiblePanelExtender5.ClientState = "true";
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }

        protected void btn_img_herramientasEquipo_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                CollapsiblePanelExtender1.Collapsed = true;
                CollapsiblePanelExtender1.ClientState = "true";
                CollapsiblePanelExtender3.Collapsed = true;
                CollapsiblePanelExtender3.ClientState = "true";
                CollapsiblePanelExtender4.Collapsed = true;
                CollapsiblePanelExtender4.ClientState = "true";
                //CollapsiblePanelExtender5.Collapsed = true;
                //CollapsiblePanelExtender5.ClientState = "true";
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }

        protected void btn_img_performance_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                CollapsiblePanelExtender1.Collapsed = true;
                CollapsiblePanelExtender1.ClientState = "true";
                CollapsiblePanelExtender2.Collapsed = true;
                CollapsiblePanelExtender2.ClientState = "true";
                CollapsiblePanelExtender4.Collapsed = true;
                CollapsiblePanelExtender4.ClientState = "true";
                //CollapsiblePanelExtender5.Collapsed = true;
                //CollapsiblePanelExtender5.ClientState = "true";
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }

        protected void btn_img_individual_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                CollapsiblePanelExtender1.Collapsed = true;
                CollapsiblePanelExtender1.ClientState = "true";
                CollapsiblePanelExtender2.Collapsed = true;
                CollapsiblePanelExtender2.ClientState = "true";
                CollapsiblePanelExtender3.Collapsed = true;
                CollapsiblePanelExtender3.ClientState = "true";
                //CollapsiblePanelExtender5.Collapsed = true;
                //CollapsiblePanelExtender5.ClientState = "true";
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }

        protected void btn_link_ver_DashBoard_Click(object sender, EventArgs e)
        {
            try
            {
                //Msg.OpcionMenu = 0;
                //Session["OpcMenu"] = Msg;
                //Response.Redirect("~/graficas/graficas.aspx", false);


                Msg.OpcionMenu = 4;
                Session["OpcMenu"] = Msg;
                Response.Redirect("~/graficas/graficas.aspx", false);
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }


        protected void btn_img_miMatrizVigente_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Msg.OpcionMenu = 1;
                Session["OpcMenu"] = Msg;
                Response.Redirect("~/wf_MatrizIndividual.aspx", false);
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }

        protected void btn_img_matrizEquipoVigente_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Msg.OpcionMenu = 1;
                Session["OpcMenu"] = Msg;
                Response.Redirect("~/wf_MatrizEquipo.aspx", false);
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }

        }

        protected void btn_img_crearMatriz_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Msg.OpcionMenu = 0;
                Session["OpcMenu"] = Msg;
                Response.Redirect("~/wf_MatrizIndividual.aspx", false);
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }

        protected void btn_img_crearEquipo_Click(object sender, ImageClickEventArgs e)
        {


            Response.Redirect("~/equipo/EquiposNew.aspx", false);
            Session["compoEquipo"] = "Add";

        }

        protected void btn_img_equipos_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/equipo/equipos.aspx", false);
            Session["compoEquipo"] = "todosEquipos";
        }

        protected void btn_agregarEmpleado_Click(object sender, ImageClickEventArgs e)
        {
            try {

                Response.Redirect("~/empleado/empleado.aspx", false);
                Session["compoEmpleado"] = "agregarEmpleado";

            }catch(Exception ex_){
                cls_errores.muestraWebError(ex_);
            }//try-catch

        }

        protected void btn_img_verTodosEmpledos_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                Response.Redirect("~/empleado/empleado.aspx", false);
                Session["compoEmpleado"] = "TodosEmpleados";

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch
        }

        protected void btn_quitarEmpleado_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                Response.Redirect("~/empleado/empleado.aspx", false);
                Session["compoEmpleado"] = "QuitarEmpleado";

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);

            }//try-catch
        }

        protected void btn_img_todasAreas_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                Response.Redirect("~/area/area.aspx", false);
                Session["compoArea"] = "TodasArea";

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch


        }

        protected void btn_img_agregarArea_Click(object sender, ImageClickEventArgs e)
        {

            try
            {

                Response.Redirect("~/area/area.aspx", false);
                Session["compoArea"] = "AddArea";

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

        }

        protected void btn_img_quitarArea_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                Response.Redirect("~/area/area.aspx", false);
                Session["compoArea"] = "Quit";

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch


        }

        protected void btn_img_agregarIncongruencias_Click(object sender, ImageClickEventArgs e)
        {

            try
            {
                Msg.OpcionMenu = 1;
                Session["OpcMenu"] = Msg;
                Response.Redirect("~/incongruencia/incongruenciaII.aspx", false);
                //Response.Redirect("~/incongruencia/incongruencia.aspx", false);
                //Session["compoIncongruencia"] = "Add";

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);

            }//try-catch

        }

        protected void btn_img_crearJunta_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Msg.OpcionMenu = 1;
                Session["OpcMenu"] = Msg;
                Response.Redirect("~/reunion/juntas.aspx", false);
                //Session["compoJunta"] = "CrearJuntaCreador";

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);

            }//try-catch
        }

        protected void btn_img_juntasCreadas_Click(object sender, ImageClickEventArgs e)
        {

            try
            {
                Msg.OpcionMenu = 2;
                Session["OpcMenu"] = Msg;
                Response.Redirect("~/reunion/juntas.aspx", false);
                //Session["compoJunta"] = "TodasJuntasCreador";

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);

            }//try-catch

        }

        protected void btn_img_misJuntasMiembro_Click(object sender, ImageClickEventArgs e)
        {

            try
            {

                Response.Redirect("~/reunion/junta.aspx", false);
                Session["compoJunta"] = "TodasJuntasMiembro";

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);

            }//try-catch
        }

        protected void btn_img_cerrarJunta_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Msg.OpcionMenu = 4;
                Session["OpcMenu"] = Msg;
                Response.Redirect("~/reunion/juntas.aspx", false);
                //Session["compoJunta"] = "CerrarJunta";

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);

            }//try-catch

            //btn_img_cerrarJunta_Click
        }

        protected void btn_img_todasMatrices_equipo_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Response.Redirect("~/matrizEquipo/equipo_folders_fecha.aspx", false);
                

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);

            }//try-catch

            //btn_img_todasMatrices_equipo_Click
        }
   


        protected void btn_img_AcuerdosPropuestas_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Response.Redirect("~/acuerdos/acuerdos.aspx", false);
                Session["compoPropuestas"] = "agregarPropuestas";

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);

            }//try-catch

            //btn_img_AcuerdosPropuestas_Click
        }

        protected void btn_img_verAcuerdosPropuestas_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Session["compoPropuestas"] = "verPropuestas";
                Session["verPropuestas_VER"] = "true";
                Response.Redirect("~/acuerdos/acuerdos.aspx", false);
                

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);

            }//try-catch
        }


        protected void btn_img_matrices_todas_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Response.Redirect("~/matrizIndiv/individual_folders_fecha.aspx", false);


            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);

            }//try-catch
        }
        protected void btn_img_objetivosEquipo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/matrizEquipo/objetivos_equipo_periodo.aspx", false);
            

        }


        protected void btn_img_graficas_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Response.Redirect("~/graficas/grafica.aspx", false);
                Session["muestraGrafica"] = "dashboard";


            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);

            }//try-catch


        }



        protected void btn_link_tabIncongruencias_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/graficas/grafica.aspx", false);
            Session["muestraGrafica"] = "incongruencias";
        }

        protected void btn_link_tabPrincipios_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/graficas/grafica.aspx", false);
            Session["muestraGrafica"] = "principios";

        }


        protected void btn_link_btn_link_MisObjetivos_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/graficas/grafica.aspx", false);
            Session["muestraGrafica"] = "objetivos";
        }

        protected void btn_link_tabEficienciaEmpleado_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/graficas/grafica.aspx", false);
            Session["muestraGrafica"] = "eficienciaEmpleado";
        }

        protected void btn_link_tabEficienciaArea_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/graficas/grafica.aspx", false);
            Session["muestraGrafica"] = "eficienciaArea";
        }

        protected void btn_img_crearMatrizEquipo_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Msg.OpcionMenu = 0;
                Session["OpcMenu"] = Msg;
                Response.Redirect("~/wf_MatrizEquipo.aspx", false);
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
            //btn_img_crearMatrizEquipo_Click
        }

        protected void btn_crearUsuario_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                
                Session["compoEmpleado"] = "crearAccesoEmpleado";
                Response.Redirect("~/empleado/empleado.aspx", false);
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
            //btn_crearUsuario_Click

        }

        protected void btn_img_recomendaciones_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                Session["compoRecomendacion"] = "crearRecomendacion";
                Response.Redirect("~/recomendacion/recomendacion.aspx", false);
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
            //btn_img_recomendaciones_Click
        }

        protected void btn_img_evalucacionCliente_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Msg.OpcionMenu = 1;
                Session["OpcMenu"] = Msg;
                Response.Redirect("~/evaluacioncliente/evaluacioncliente.aspx", false);

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);

            }//try-catch

        }

        protected void btn_internal_client_evaluation_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Msg.OpcionMenu = 1;
                Session["OpcMenu"] = Msg;
                Response.Redirect("~/evaluacioncliente/consultaevalcliente.aspx", false);

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);

            }//try-catch
        }

        protected void btn_img_verIncongruencias_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Msg.OpcionMenu = 1;
                Session["OpcMenu"] = Msg;
                Response.Redirect("~/incongruencia/consultaincongruencias.aspx", false);

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);

            }//try-catch
        }        

        

     

        

     

        
       


       


    }
}