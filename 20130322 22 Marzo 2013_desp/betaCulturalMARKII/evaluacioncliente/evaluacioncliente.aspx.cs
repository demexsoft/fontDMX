using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using betaCulturalMARKII.equipo;
using betaCulturalMARKII.incongruencia;

namespace betaCulturalMARKII.evaluacioncliente
{
    public partial class evaluacioncliente : System.Web.UI.Page
    {
        cls_evaluacioncliente objevaluacioncliente = new cls_evaluacioncliente();        
        cls_Utilerias Msg = new cls_Utilerias();
        cls_equipo objEquipo = new cls_equipo();
        cls_incongruencia objIncongruencia = new cls_incongruencia();

        private static DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    
                    lbl_Titulo.Text = "Evaluación Interna";
                    dt = new DataTable();
                    dt = objEquipo.verTodosEquipos(0);
                    objEquipo.LlenaCombo_verTodosEquipos(dt, ddl_Equipo, false);

                    DataTable dt2;
                    dt2 = new DataTable();
                    dt2 = objIncongruencia.verConocimiento();
                    objIncongruencia.LlenaCombo_verConocimiento(dt2, ddl_conocimiento);

                    objIncongruencia.LlenaCombo_verOrigenProblema(objIncongruencia.verOrigenProblema(cls_acceso.get_ID()), ddl_causa, false);

                    objIncongruencia.LlenaCombo_verEvaluar(objIncongruencia.verEvaluar(), ddl_Evaluar, false);

                    
                }
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }


        protected void btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                int Resp = -1;


                int Evaluacion = int.Parse(ddl_conocimiento.SelectedValue);

                if (Evaluacion <= 3)
                {
                    if (txt_Recomendacion.Text.Trim().Length == 0)
                    {
                        Msg.ShowMsg(this, "Debe capturar una recomendación");
                        return;
                    }
                }

                Resp = objevaluacioncliente.agregarEvaluacionCliente(cls_acceso.get_ID() ,
                                                                     cls_equipo.get_IDEquipo(),
                                                                     int.Parse(ddl_Equipo.SelectedValue),
                                                                     txt_Fecha.Text.Trim(),  
                                                                     txt_Recomendacion.Text.Trim(),
                                                                     int.Parse(ddl_Evaluar.SelectedValue),
                                                                     int.Parse(ddl_causa.SelectedValue),
                                                                     int.Parse(ddl_conocimiento.SelectedValue));

                if (Resp > 0)
                {
                    Msg.ShowMsg(this, "Se guardo con exito.");
                    txt_Fecha.Text = string.Empty;
                    txt_Recomendacion.Text = string.Empty;
                }
                else
                {
                    Msg.ShowMsg(this, "Error al intentar guardar");
                }

            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }

        protected void btn_Salir_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/graficas/grafica.aspx", false);
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }

        protected void txt_Fecha_TextChanged(object sender, EventArgs e)
        {

        }

    }
}