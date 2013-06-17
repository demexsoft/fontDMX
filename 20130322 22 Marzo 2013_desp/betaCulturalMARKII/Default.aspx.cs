using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using betaCulturalMARKII.idioma;
using betaCulturalMARKII.equipo;


namespace betaCulturalMARKII
{
    public partial class acce : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //LLENADO en dos lineas

                cls_idioma ingles = new cls_idioma();
                ingles.seleccionDeIdioma("ing");
                cls_configuracion.setIdioma("ing");

                if (cls_configuracion.getIdioma() == "") {

                    Response.Redirect("Default.aspx", false);
                
                }
                else
                {
                    Label_ingresar_loggin.Text = Convert.ToString(cls_idioma.get_seleccionDeIdioma().Rows[cls_idioma.get_seleccionDeIdioma().Rows.IndexOf(cls_idioma.get_seleccionDeIdioma().Select("IDMSG='lbl_ingresar_loggin'")[0])]["STRMSG"]);
                    Label_usuario_loggin.Text = "<strong>" + Convert.ToString(cls_idioma.get_seleccionDeIdioma().Rows[cls_idioma.get_seleccionDeIdioma().Rows.IndexOf(cls_idioma.get_seleccionDeIdioma().Select("IDMSG='usuario_loggin'")[0])]["STRMSG"]) + "</strong>";
                    Label_pass_loggin.Text = "<strong>"+Convert.ToString(cls_idioma.get_seleccionDeIdioma().Rows[cls_idioma.get_seleccionDeIdioma().Rows.IndexOf(cls_idioma.get_seleccionDeIdioma().Select("IDMSG='contrasenia_loggin'")[0])]["STRMSG"])+"</strong>";
                

                }//if

            }catch(Exception ex_){
                cls_errores.muestraWebError(ex_);
            }

            
        }

        public void inicializaApp()
        {

            try
            {




            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);


            }//try-catch


        }//inicializaApp


        protected void btn_loggin_Click(object sender, ImageClickEventArgs e)
        {
            cls_acceso acceder = new cls_acceso();
            bool accesoValor = false;
            try
            {
                accesoValor = acceder.accesoAPPbool(txt_usuario.Text, txt_contrasenia.Text);

                if (accesoValor)
                {
                    //Crea secion para usarlas despues en la validacion al entrar 'principalControl'
                    Session["gsUsuarioCul"] = txt_usuario.Text;
                    Session["gsPassCul"] = txt_contrasenia.Text;

                    lbl_aviso_bienvenido_loggin.CssClass = "textoNormalAzul_";
                    cls_equipo.set_misEquipos(cls_acceso.get_ID());

                    lbl_aviso_bienvenido_loggin.Text = Convert.ToString(cls_idioma.get_seleccionDeIdioma().Rows[cls_idioma.get_seleccionDeIdioma().Rows.IndexOf(cls_idioma.get_seleccionDeIdioma().Select("IDMSG='lbl_aviso_bienvenido_loggin'")[0])]["STRMSG"])
                                                       + "&nbsp; <strong>" + Session["gsUsuarioCul"] + "</strong>";
                    lbl_aviso_intruccion_titulo.Text = Convert.ToString(cls_idioma.get_seleccionDeIdioma().Rows[cls_idioma.get_seleccionDeIdioma().Rows.IndexOf(cls_idioma.get_seleccionDeIdioma().Select("IDMSG='lbl_aviso_intruccion_titulo'")[0])]["STRMSG"]);
                    btn_loggin.Visible = false;
                    txt_usuario.Visible = false;
                    txt_contrasenia.Visible = false;

                    //Si existe el empleado a un equipo en cuestion, delo contrario no podra llenarce el grid para la
                    //seleccion del grid
                    if (cls_equipo.get_misEquipos().Tables[0].Rows.Count > 0 && cls_equipo.get_misEquipos().Tables[1].Rows.Count > 0)
                    {

                        lbl_aviso_intruccion_loggin_team.Text = Convert.ToString(cls_idioma.get_seleccionDeIdioma().Rows[cls_idioma.get_seleccionDeIdioma().Rows.IndexOf(cls_idioma.get_seleccionDeIdioma().Select("IDMSG='lbl_aviso_instruccion_loggin_leader'")[0])]["STRMSG"]);
                        lbl_aviso_instruccion_loggin_member.Text = Convert.ToString(cls_idioma.get_seleccionDeIdioma().Rows[cls_idioma.get_seleccionDeIdioma().Rows.IndexOf(cls_idioma.get_seleccionDeIdioma().Select("IDMSG='lbl_aviso_instruccion_loggin_member'")[0])]["STRMSG"]);


                    }
                    else if (cls_equipo.get_misEquipos().Tables[0].Rows.Count == 0 && cls_equipo.get_misEquipos().Tables[1].Rows.Count > 0)
                    {
                        lbl_aviso_instruccion_loggin_member.Text = "";
                        lbl_aviso_intruccion_loggin_team.Text = Convert.ToString(cls_idioma.get_seleccionDeIdioma().Rows[cls_idioma.get_seleccionDeIdioma().Rows.IndexOf(cls_idioma.get_seleccionDeIdioma().Select("IDMSG='lbl_aviso_instruccion_loggin_leader'")[0])]["STRMSG"]);

                    }
                    else if (cls_equipo.get_misEquipos().Tables[0].Rows.Count > 0 && cls_equipo.get_misEquipos().Tables[1].Rows.Count == 0)
                    {
                        lbl_aviso_instruccion_loggin_member.Text = Convert.ToString(cls_idioma.get_seleccionDeIdioma().Rows[cls_idioma.get_seleccionDeIdioma().Rows.IndexOf(cls_idioma.get_seleccionDeIdioma().Select("IDMSG='lbl_aviso_instruccion_loggin_member'")[0])]["STRMSG"]);
                        lbl_aviso_intruccion_loggin_team.Text = "";

                    }
                    else if (cls_equipo.get_misEquipos().Tables[0].Rows.Count == 0 && cls_equipo.get_misEquipos().Tables[1].Rows.Count == 0)
                    {


                        lbl_aviso_instruccion_loggin_member.Text = Convert.ToString(cls_idioma.get_seleccionDeIdioma().Rows[cls_idioma.get_seleccionDeIdioma().Rows.IndexOf(cls_idioma.get_seleccionDeIdioma().Select("IDMSG='sin_equipos_loggin'")[0])]["STRMSG"]);
                        lbl_aviso_intruccion_loggin_team.Text = "";
                    
                    }

                       //Grid empleado
                        dg_view_seleccionaEquipo.DataSource = cls_equipo.get_misEquipos().Tables[0];
                        dg_view_seleccionaEquipo.DataBind();

                        //Grid lider
                        dg_view_seleccionaEquipoJEFE.DataSource = cls_equipo.get_misEquipos().Tables[1];
                        dg_view_seleccionaEquipoJEFE.DataBind();
                    
                   
                   

                    pnl_ini_selecciona_equipo.Visible = true;

                        logo_csm.Visible=false;
                        logo_legal.Visible = false;

                        pnl_ini_loggin_logos.Visible = false;
                }
                else
                {

                    lbl_error_acceso.Text = Convert.ToString(cls_idioma.get_seleccionDeIdioma().Rows[cls_idioma.get_seleccionDeIdioma().Rows.IndexOf(cls_idioma.get_seleccionDeIdioma().Select("IDMSG='error_loggin'")[0])]["STRMSG"]);

                }


            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-cath

            //btn_loggin_Click
        }



        protected void dg_view_seleccionaEquipo_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {


                cls_equipo.set_IDEquipo(int.Parse(e.Item.Cells[1].Text));
                cls_equipo.set_IDJefeEquipo(int.Parse(e.Item.Cells[2].Text));
                cls_equipo.set_NomEquipo(e.Item.Cells[3].Text);
                cls_equipo.set_NomJefeEquipo(e.Item.Cells[4].Text);



                Response.Redirect("~/graficas/grafica.aspx", false);
                Session["muestraGrafica"] = "admin";

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

            //dg_view_seleccionaEquipo_ItemCommand   
        }


        protected void dg_view_seleccionaEquipoJEFE_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {


                cls_equipo.set_IDEquipo(int.Parse(e.Item.Cells[1].Text));
                cls_equipo.set_IDJefeEquipo(int.Parse(e.Item.Cells[2].Text));
                cls_equipo.set_NomEquipo(e.Item.Cells[3].Text);
                cls_equipo.set_NomJefeEquipo(e.Item.Cells[4].Text);



                Response.Redirect("~/graficas/grafica.aspx", false);

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

            //dg_view_seleccionaEquipo_ItemCommand   
        }

        protected void dg_view_seleccionaEquipoJEFE_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
     


        //accesoCultural
    }
}