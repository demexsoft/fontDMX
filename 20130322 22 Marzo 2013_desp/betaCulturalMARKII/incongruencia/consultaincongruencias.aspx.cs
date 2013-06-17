using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using betaCulturalMARKII.equipo;
using betaCulturalMARKII.incongruencia;

namespace betaCulturalMARKII.incongruencia
{
    public partial class consultaincongruencias : System.Web.UI.Page
    {
        cls_incongruencia objIncongruencia = new cls_incongruencia();
        cls_Utilerias Msg = new cls_Utilerias();
        cls_equipo objEquipo = new cls_equipo();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    lbl_Titulo.Text = "Consulta Bitácora de Incidentes";

                    objEquipo.LlenaCombo_verTodosEquipos(objEquipo.verTodosEquipos(0), ddl_Equipo, true);

                    objIncongruencia.LlenaCombo_verOrigenProblema(objIncongruencia.verOrigenProblema(cls_acceso.get_ID()), ddl_Causa, true);
                    objIncongruencia.LlenaCombo_verPrincipios(objIncongruencia.verPrincipios(), ddl_Principio, true);
                    objIncongruencia.LlenaCombo_verModelo(objIncongruencia.verModelo(cls_acceso.get_ID()), ddl_Modelo, true);



                }
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }

        protected void txt_FechaIni_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_FechaFin_TextChanged(object sender, EventArgs e)
        {

        }



        protected void btn_Buscar_Click(object sender, EventArgs e)
        {
            cls_incongruencia bitacora = new cls_incongruencia();
            DataTable dt = new DataTable();

            dt = bitacora.verIncongruencias(txt_FechaIni.Text,
                                           txt_FechaFin.Text,
                                           int.Parse(ddl_Equipo.SelectedValue),
                                           int.Parse(ddl_Principio.SelectedValue),
                                           int.Parse(ddl_Causa.SelectedValue),
                                           int.Parse(ddl_Modelo.SelectedValue));
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }

        }

    }
}