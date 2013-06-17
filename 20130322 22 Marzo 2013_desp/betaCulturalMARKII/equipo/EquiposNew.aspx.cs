using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using betaCulturalMARKII.empleado;
using betaCulturalMARKII.idioma;
using betaCulturalMARKII.incongruencia;
using betaCulturalMARKII.area;

namespace betaCulturalMARKII.equipo
{
    public partial class EquiposNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LlenaComboEmpleados();
                LlenaGridEmpleados();
                LlenaComboArea();
            }
        }

        protected void LlenaComboEmpleados() 
        {
            cls_empleado empleado = new cls_empleado();
            DataTable dt = empleado.verTodosEmpelados(cls_acceso.get_ID());
            ListItem Lista;
            ddlLider.Items.Clear();
            
            if (dt.Rows.Count > 0)
            {                                                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Lista = new ListItem();
                    Lista.Value = dt.Rows[i]["IDEmpleado"].ToString();
                    Lista.Text = dt.Rows[i]["nombreEmp"].ToString() + " " + dt.Rows[i]["apePat"].ToString();
                    ddlLider.Items.Add(Lista);
                }
            }
            else 
            {
                Lista = new ListItem();
                Lista.Value = "-1";
                Lista.Text = "Sin Datos";
                ddlLider.Items.Add(Lista);
                
            }
        }

        protected void LlenaComboArea() 
        {
            try
            {
                cls_area objArea = new cls_area();
                DataTable dtArea = objArea.verAreas(cls_acceso.get_ID());

                ddlArea.DataSource = dtArea;
                ddlArea.DataValueField = "IDarea";
                ddlArea.DataTextField = "nomArea";
                ddlArea.DataBind();
            }
            catch 
            {
                
                throw;
            }
        }
        protected void LlenaGridEmpleados()
        {
            cls_empleado empleado = new cls_empleado();
            DataTable dt = empleado.verTodosEmpelados(cls_acceso.get_ID());

            if (dt.Rows.Count > 0)
            {
                gvEmpleados.Columns[0].Visible = true;
                gvEmpleados.DataSource = dt;
                gvEmpleados.DataBind();
                gvEmpleados.Columns[0].Visible = false;
            }
            else
            {
                gvEmpleados.DataSource = null;
                gvEmpleados.DataBind();
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                cls_equipo equipoNuevo = new cls_equipo();
                CheckBox chkGrid;
                int Resp = -1;
                cls_equipo.set_ultimoEquipo_(equipoNuevo.crearEquipo(cls_acceso.get_ID(), txtDescripcion.Text, txtNombre.Text, int.Parse(ddlLider.SelectedValue), int.Parse(ddlArea.SelectedValue)));
                int IDE = cls_equipo.get_ultimoEquipo_();
                if (cls_equipo.get_ultimoEquipo_() > -1)
                {
                    foreach (GridViewRow item in gvEmpleados.Rows)
                    {
                        chkGrid = (CheckBox)item.Cells[1].FindControl("chbLider");
                        if (chkGrid != null) 
                        {
                            if (chkGrid.Checked) 
                            {
                                Resp = equipoNuevo.agregarMiembroEnEquipo(cls_acceso.get_ID(),
                                                             cls_equipo.get_ultimoEquipo_(),
                                                             int.Parse(item.Cells[0].Text));  
                            }
                        }                        
                    }

                    if (Resp == 1)
                    {
                        Response.Redirect("~/equipo/equipos.aspx", false);
                    }
                }
            }
            catch 
            {
                
                throw;
            }
        }
    }
}