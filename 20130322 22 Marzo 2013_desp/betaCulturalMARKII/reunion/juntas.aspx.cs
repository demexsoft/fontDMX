using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using betaCulturalMARKII.empleado;
using betaCulturalMARKII.equipo;

namespace betaCulturalMARKII.reunion
{
    public partial class juntas : System.Web.UI.Page
    {        
        cls_empleado objEmpleado = new cls_empleado();
        cls_Utilerias Msg = new cls_Utilerias();
        cls_reunion objReunion = new cls_reunion();
        cls_equipo objEquipo = new cls_equipo();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack) 
                {
                    Msg = (cls_Utilerias)Session["OpcMenu"];
                                       
                    lbl_Titulo.Text = "Establecer calendario";                        
                    InicializaControlesNewJunta();
                    LlenaComboEquipos(0);
                    LlenaGridReuniones(cls_acceso.get_ID(), int.Parse(ddlEquipo.SelectedValue));
                    pnl_JuntasNew.Visible = true;                        
                                        
                }
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }               

        protected void InicializaControlesNewJunta() 
        {
            try
            {
                ctrl_Calenadrio.SelectedDate = ctrl_Calenadrio.TodaysDate;
                txtHoraCompromiso.Text = string.Empty; //DateTime.Now.ToShortTimeString();                                
                txtHorario.Text = string.Empty;
                txtLugar.Text = string.Empty;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        protected void LlenaComboEquipos(int IDArea) 
        {
            try
            {
                DataTable dtEquipos = objEquipo.verTodosEquipos(IDArea);

                if (dtEquipos.Rows.Count > 0) 
                {
                    ddlEquipo.DataSource = dtEquipos;
                    ddlEquipo.DataValueField = "IDEquipo";
                    ddlEquipo.DataTextField = "nomEqui";
                    ddlEquipo.DataBind();
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        protected void LlenaGridReuniones(int EmpleadoID, int EquipoID) 
        {
            try
            {
                DataTable dtReuniones = objReunion.verReunionGral(EmpleadoID, EquipoID);

                if (dtReuniones.Rows.Count > 0)
                {
                    gvFechas.Columns[0].Visible = true;
                    gvFechas.DataSource = dtReuniones;
                    gvFechas.DataBind();
                    gvFechas.Columns[0].Visible = false;
                }
                else 
                {
                    gvFechas.DataSource = null;
                    gvFechas.DataBind();
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        protected void btn_GuardaNewJunta_Click(object sender, EventArgs e)
        {
            try
            {
                int Resp = 0;
                Resp = objReunion.agregarReunion(int.Parse(ddlEquipo.SelectedValue),
                                                 ctrl_Calenadrio.SelectedDate.ToShortDateString(),
                                                 txtHoraCompromiso.Text,
                                                 txtHorario.Text,
                                                 txtLugar.Text,
                                                 string.Empty,
                                                 cls_acceso.get_ID());
                if (Resp.Equals(1))
                {
                    LlenaGridReuniones(cls_acceso.get_ID(), int.Parse(ddlEquipo.SelectedValue));
                    InicializaControlesNewJunta();
                }
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }           

        protected void ctrl_Calenadrio_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        protected void ddlEquipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LlenaGridReuniones(cls_acceso.get_ID(), int.Parse(ddlEquipo.SelectedValue));
            }
            catch 
            {
                
                throw;
            }
        }

        protected void btnEditar_Click(object sender, ImageClickEventArgs e) 
        {
            try
            {
                GridViewRow gRow;
                ImageButton btnEditar;                
                btnEditar = (ImageButton)sender;
                gRow = (GridViewRow)btnEditar.Parent.Parent;

                ((ImageButton)gRow.FindControl("btnAceptar")).Visible = true;
                ((ImageButton)gRow.FindControl("btnCancelar")).Visible = true;

                ((TextBox)gRow.FindControl("txtFecha")).Visible = true;
                ((TextBox)gRow.FindControl("txtFecha")).Text = ((Label)gRow.FindControl("lblFecha")).Text;
                ((Label)gRow.FindControl("lblFecha")).Visible = false;

                ((TextBox)gRow.FindControl("txtHorario")).Visible = true;
                ((TextBox)gRow.FindControl("txtHorario")).Text = ((Label)gRow.FindControl("lblHorario")).Text;
                ((Label)gRow.FindControl("lblHorario")).Visible = false;

                ((TextBox)gRow.FindControl("txtLugar")).Visible = true;
                ((TextBox)gRow.FindControl("txtLugar")).Text = ((Label)gRow.FindControl("lblLugar")).Text;
                ((Label)gRow.FindControl("lblLugar")).Visible = false;

                ((TextBox)gRow.FindControl("txtHcompromiso")).Visible = true;
                ((TextBox)gRow.FindControl("txtHcompromiso")).Text = ((Label)gRow.FindControl("lblHcompromiso")).Text;
                ((Label)gRow.FindControl("lblHcompromiso")).Visible = false;

                ((ImageButton)gRow.FindControl("btnEditar")).Visible = false;
                ((ImageButton)gRow.FindControl("btnEliminar")).Visible = false;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        protected void btnAceptar_Click(object sender, ImageClickEventArgs e)         
        {
            try
            {
                //cls_empleado empleado = new cls_empleado();
                GridViewRow gRow;
                ImageButton btnAceptar;
                btnAceptar = (ImageButton)sender;
                gRow = (GridViewRow)btnAceptar.Parent.Parent;

                int Resp = 0;

                Resp = objReunion.modificarReunion(int.Parse(((Label)gRow.FindControl("ID")).Text),
                                                   int.Parse(ddlEquipo.SelectedValue),
                                                   ((TextBox)gRow.FindControl("txtFecha")).Text,
                                                   ((TextBox)gRow.FindControl("txtHcompromiso")).Text,
                                                   ((TextBox)gRow.FindControl("txtHorario")).Text,
                                                   ((TextBox)gRow.FindControl("txtLugar")).Text,
                                                   string.Empty);
                if (Resp.Equals(1)) 
                {
                    LlenaGridReuniones(cls_acceso.get_ID(), int.Parse(ddlEquipo.SelectedValue));
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        protected void btnEliminar_Click(object sender, ImageClickEventArgs e) 
        {
            try
            {
                GridViewRow gRow;
                ImageButton btnEliminar;
                btnEliminar = (ImageButton)sender;
                gRow = (GridViewRow)btnEliminar.Parent.Parent;

                int Resp = 0;

                Resp = objReunion.quitarReunion(int.Parse(((Label)gRow.FindControl("ID")).Text));

                if (Resp.Equals(1))
                {
                    LlenaGridReuniones(cls_acceso.get_ID(), int.Parse(ddlEquipo.SelectedValue));
                }
                
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        protected void btnCancelar_Click(object sender, ImageClickEventArgs e) 
        {
            try
            {
                GridViewRow gRow;
                ImageButton btnCancelar;
                btnCancelar = (ImageButton)sender;
                gRow = (GridViewRow)btnCancelar.Parent.Parent;

                ((ImageButton)gRow.FindControl("btnEditar")).Visible = true;
                ((ImageButton)gRow.FindControl("btnEliminar")).Visible = true;

                ((Label)gRow.FindControl("lblFecha")).Visible = true;
                ((TextBox)gRow.FindControl("txtFecha")).Text = string.Empty;
                ((TextBox)gRow.FindControl("txtFecha")).Visible = false;

                ((Label)gRow.FindControl("lblHorario")).Visible = true;                
                ((TextBox)gRow.FindControl("txtHorario")).Text = string.Empty;
                ((TextBox)gRow.FindControl("txtHorario")).Visible = false;

                ((Label)gRow.FindControl("lblLugar")).Visible = true;
                ((TextBox)gRow.FindControl("txtLugar")).Text = string.Empty;                
                ((TextBox)gRow.FindControl("txtLugar")).Visible = false;

                ((Label)gRow.FindControl("lblHcompromiso")).Visible = true;
                ((TextBox)gRow.FindControl("txtHcompromiso")).Text = string.Empty;                
                ((TextBox)gRow.FindControl("txtHcompromiso")).Visible = false;

                ((ImageButton)gRow.FindControl("btnAceptar")).Visible = false;
                ((ImageButton)gRow.FindControl("btnCancelar")).Visible = false;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}