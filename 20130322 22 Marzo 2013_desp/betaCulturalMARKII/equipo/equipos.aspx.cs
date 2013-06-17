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
    public partial class equipos : System.Web.UI.Page
    {
        protected static bool esLider;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) 
            {
                esLider = false;
                VerMisEquipos();
                LlenaGridEmpleados();
            }
        }

        protected void VerMisEquipos() 
        {
            try
            {
                ctrEquipo.Nodes.Clear();
                cls_equipo equipo = new cls_equipo();
                DataTable tbl_empleadoID = equipo.verEmpleadosEnEquipo();
                DataTable tbl_equipoID = equipo.verTodosEquipos(0);

                TreeNode Abuelo;
                TreeNode Padre;
                TreeNode Hijo;

                if (tbl_equipoID.Rows.Count > 0) 
                {
                    for (int i = 0; i < tbl_equipoID.Rows.Count; i++)
                    {
                        Abuelo = new TreeNode();
                        Abuelo.Value = tbl_equipoID.Rows[i]["IDEquipo"].ToString();
                        Abuelo.Text = tbl_equipoID.Rows[i]["nomEqui"].ToString();

                        Padre = new TreeNode();
                        Padre.Value = tbl_equipoID.Rows[i]["jefeEqui"].ToString();
                        Padre.Text = tbl_equipoID.Rows[i]["nomJefe"].ToString();
                        Padre.SelectAction = TreeNodeSelectAction.None;

                        DataRow[] drHijos = tbl_empleadoID.Select("parentIDEquipo = " + tbl_equipoID.Rows[i]["IDEquipo"].ToString());

                        for (int j = 0; j < drHijos.Length; j++)
                        {
                            Hijo = new TreeNode();
                            Hijo.Value = drHijos[j].ItemArray[0].ToString();
                            Hijo.Text = drHijos[j].ItemArray[1].ToString() + " " + drHijos[j].ItemArray[2].ToString();

                            Padre.ChildNodes.Add(Hijo);                            
                        }                        

                        Abuelo.ChildNodes.Add(Padre);
                        ctrEquipo.Nodes.Add(Abuelo);
                        ctrEquipo.ExpandAll();
                    }
                }

            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
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

        protected void gvEmpleados_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#79b9fb'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));
                e.Row.Style["cursor"] = "hand";
            }
        }

        protected void ctrEquipo_SelectedNodeChanged(object sender, EventArgs e)
        {
                   
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            cls_equipo objEquipo = new cls_equipo();
            int Resp = 0;

            if (ctrEquipo.SelectedNode.Selected.Equals(true))
            {
                if (esLider)
                {
                    if (!int.Parse(ctrEquipo.Nodes[0].ChildNodes[0].Value).Equals(int.Parse(gvEmpleados.SelectedRow.Cells[0].Text)))
                    {
                        Resp = objEquipo.modificarEquipoYLider(int.Parse(ctrEquipo.SelectedNode.Value), ctrEquipo.SelectedNode.Text, int.Parse(gvEmpleados.SelectedRow.Cells[0].Text));
                    }
                    esLider = false;
                }
                else
                {
                    bool YaExite = false;
                    for (int i = 0; i < ctrEquipo.SelectedNode.ChildNodes[0].ChildNodes.Count; i++)
                    {
                        if (int.Parse(ctrEquipo.SelectedNode.ChildNodes[0].ChildNodes[0].Value).Equals(int.Parse(gvEmpleados.SelectedRow.Cells[0].Text)))
                        {
                            YaExite = true;
                        }                        
                    }

                    if (!YaExite)
                    {
                        Resp = objEquipo.agregarMiembroEnEquipo(cls_acceso.get_ID(), int.Parse(ctrEquipo.SelectedNode.Value), int.Parse(gvEmpleados.SelectedRow.Cells[0].Text));
                    }
                }

                if (Resp.Equals(1))
                {
                    VerMisEquipos();
                }
            }
        }

        protected void btnQuit_Click(object sender, EventArgs e)
        {
            cls_equipo objEquipo = new cls_equipo();
            int Resp = 0;
            if (ctrEquipo.SelectedNode.Parent == null) 
            {
                Resp = objEquipo.quitarEquipo(int.Parse(ctrEquipo.SelectedNode.Value));
            }
            else
            {
                Resp = objEquipo.quitarMiembroEnEquipo(int.Parse(ctrEquipo.SelectedNode.Parent.Parent.Value), int.Parse(ctrEquipo.SelectedNode.Value));
            }

            if (Resp.Equals(1)) 
            {
                VerMisEquipos();
            }
        }

        protected void chbLider_CheckedChanged(object sender, EventArgs e)
        {   
            //esLider = true;     
            CheckBox chladentro;
            chladentro = (CheckBox)sender;
            if (chladentro.Checked) 
            {
                esLider = true;
            }
            else
            {
                esLider= false;
            }
            GridViewRow gvrow;
            gvrow = (GridViewRow)chladentro.Parent.Parent;
            if (HayOtro(gvrow.DataItemIndex))
            {
                LimpiaChecks(gvrow.DataItemIndex);
            }            
        }

        protected bool HayOtro(int index)
        {
            try
            {
                bool resultado = false;
                foreach (GridViewRow item in gvEmpleados.Rows)
                {
                    CheckBox chk;                   
                    chk = (CheckBox)item.Cells[1].FindControl("chbLider");

                    if (chk!=null)
                    {
                        if (chk.Checked && (item.DataItemIndex!=index))
                        {
                            resultado=true;
                        }
                    }
                }
                return resultado;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        protected void LimpiaChecks(int index)
        {
            try
            {
                 foreach (GridViewRow item in gvEmpleados.Rows)
                {
                    CheckBox chk;                   
                    chk = (CheckBox)item.Cells[1].FindControl("chbLider");

                    if (chk!=null)
                    {
                        if (item.DataItemIndex!=index)
                        {
                            chk.Checked = false;
                        }                      
                    }                   
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}