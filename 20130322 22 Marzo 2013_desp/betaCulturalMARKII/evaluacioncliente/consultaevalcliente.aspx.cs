using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using betaCulturalMARKII.equipo;
using betaCulturalMARKII.incongruencia;

namespace betaCulturalMARKII.evaluacioncliente
{
    public partial class consultaevalcliente : System.Web.UI.Page
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
                    lbl_Titulo.Text = "Consulta de Evaluación";
                    objEquipo.LlenaCombo_verTodosEquipos(objEquipo.verTodosEquipos(0), ddl_Equipo, true);

                    objIncongruencia.LlenaCombo_verOrigenProblema(objIncongruencia.verOrigenProblema(cls_acceso.get_ID()), ddl_Causa, true);
                    objIncongruencia.LlenaCombo_verEvaluar(objIncongruencia.verEvaluar(), ddl_Evaluar, true);
                    

                   
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
            cls_evaluacioncliente evaluacion = new cls_evaluacioncliente();
            DataTable dt = new DataTable();

            dt = evaluacion.verEvaluacion(txt_FechaIni.Text,
                                          txt_FechaFin.Text,
                                          int.Parse(ddl_Equipo.SelectedValue),
                                          int.Parse(ddl_Evaluar.SelectedValue),
                                          int.Parse(ddl_Causa.SelectedValue),
                                          0);
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