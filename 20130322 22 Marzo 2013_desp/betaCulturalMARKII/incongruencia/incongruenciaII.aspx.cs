using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using betaCulturalMARKII.equipo;

namespace betaCulturalMARKII.incongruencia
{
    public partial class incongruenciaII : System.Web.UI.Page
    {
        cls_incongruencia objIncongruencia = new cls_incongruencia();
        cls_Utilerias Msg = new cls_Utilerias();
        cls_equipo objEquipo = new cls_equipo();
        
        private static DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    lbl_Titulo.Text = "Acountability Log";
                    dt = new DataTable();
                    dt = objEquipo.verTodosEquipos(0);                    
                    objEquipo.LlenaCombo_verTodosEquipos(objEquipo.verTodosEquipos(0), ddl_Equipo, false);

                    objIncongruencia.LlenaCombo_verOrigenProblema(objIncongruencia.verOrigenProblema(cls_acceso.get_ID()), ddl_Origenprobable, false);
                    objIncongruencia.LlenaCombo_verModelo(objIncongruencia.verModelo(cls_acceso.get_ID()), ddl_Modelo, false);
                    objIncongruencia.LlenaCombo_verPrincipios(objIncongruencia.verPrincipios(), ddl_Principio, false);
                    objIncongruencia.LlenaCombo_verIndicadores(objIncongruencia.verIndicadores(int.Parse(ddl_Principio.SelectedValue)), ddl_Indicador);                


                    DataRow[] dr = dt.Select("IDEquipo = " + ddl_Equipo.SelectedValue);
                    lbl_Responsable.Text = dr[0][4].ToString();
                }
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }

        protected void InicializaControles()
        {
            try
            {
                txt_Fecha.Text = string.Empty;
                txt_Evento.Text = string.Empty;
                txt_Impacto.Text = string.Empty;

                objIncongruencia.LlenaCombo_verOrigenProblema(objIncongruencia.verOrigenProblema(cls_acceso.get_ID()), ddl_Origenprobable, false);
                objIncongruencia.LlenaCombo_verModelo(objIncongruencia.verModelo(cls_acceso.get_ID()), ddl_Modelo, false);
                objIncongruencia.LlenaCombo_verPrincipios(objIncongruencia.verPrincipios(), ddl_Principio, false);
                objIncongruencia.LlenaCombo_verIndicadores(objIncongruencia.verIndicadores(int.Parse(ddl_Principio.SelectedValue)), ddl_Indicador);                

                DataRow[] dr = dt.Select("IDEquipo = " + ddl_Equipo.SelectedValue);
                lbl_Responsable.Text = dr[0][4].ToString();
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }


       
        protected void ddl_Equipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow[] dr = dt.Select("IDEquipo = " + ddl_Equipo.SelectedValue);
                lbl_Responsable.Text = dr[0][4].ToString();
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }

        protected void ddl_Principio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                objIncongruencia.LlenaCombo_verIndicadores(objIncongruencia.verIndicadores(int.Parse(ddl_Principio.SelectedValue)), ddl_Indicador);                
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

                DataRow[] dr = dt.Select("IDEquipo = " + ddl_Equipo.SelectedValue);
                int IDResponsable = int.Parse(dr[0][3].ToString());

                Resp = objIncongruencia.agregarIncongruencia(cls_acceso.get_ID(), 
                                                             cls_equipo.get_IDEquipo(),
                                                             int.Parse(ddl_Equipo.SelectedValue),
                                                             IDResponsable,
                                                             txt_Fecha.Text.Trim(),
                                                             int.Parse(ddl_Modelo.SelectedValue),
                                                             int.Parse(ddl_Principio.SelectedValue),
                                                             int.Parse(ddl_Indicador.SelectedValue),
                                                             int.Parse(ddl_Origenprobable.SelectedValue),
                                                             txt_Evento.Text.Trim(),
                                                             txt_Impacto.Text.Trim());

                if (Resp > 0)
                {
                    Msg.ShowMsg(this, "Save Sucessfully");
                    InicializaControles();
                }
                else 
                {
                    Msg.ShowMsg(this, "ERROR Trying to Save");
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

        protected void btnFechaInicio_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}