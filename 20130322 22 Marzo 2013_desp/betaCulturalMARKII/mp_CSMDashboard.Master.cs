using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using betaCulturalMARKII.equipo;
using betaCulturalMARKII.idioma;

namespace betaCulturalMARKII
{
    public partial class mp_CSMDashboard : System.Web.UI.MasterPage
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
        }

        protected void btn_OP_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Msg.OpcionMenu = 1;
                Session["OpcMenu"] = Msg;
                Response.Redirect("~/graficas/graficas.aspx", false);
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }

        protected void btn_EficaciaEficiencia_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Msg.OpcionMenu = 2;
                Session["OpcMenu"] = Msg;
                Response.Redirect("~/graficas/graficas.aspx", false);
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }

        protected void btn_Comparatives_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Msg.OpcionMenu = 3;
                Session["OpcMenu"] = Msg;
                Response.Redirect("~/graficas/graficas.aspx", false);
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }

        protected void btn_lnk_menu_Click(object sender, EventArgs e)
        {
            try 
            {
                Msg.OpcionMenu = -1;
                Session["OpcMenu"] = Msg;
                Response.Redirect("~/graficas/grafica.aspx", false);
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }

        protected void btn_MP_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Msg.OpcionMenu = 4;
                Session["OpcMenu"] = Msg;
                Response.Redirect("~/graficas/graficas.aspx", false);
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }

        }

        protected void btn_lnk_salir_Click(object sender, EventArgs e)
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
    }
}