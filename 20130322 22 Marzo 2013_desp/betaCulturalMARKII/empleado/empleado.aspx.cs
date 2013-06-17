using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using betaCulturalMARKII.conexionMysql;
using betaCulturalMARKII.empresa;
using betaCulturalMARKII.puesto;
using betaCulturalMARKII.area;
using betaCulturalMARKII.perfil;

namespace betaCulturalMARKII.empleado
{
    public partial class empleado : System.Web.UI.Page
    {
        cls_Utilerias Msg = new cls_Utilerias();

        protected void Page_Load(object sender, EventArgs e)
        {
            try {

                if (!Page.IsPostBack)
                {
                    if (Session["compoEmpleado"] != null)
                    {
                        LlenaGridEmpleados(cls_acceso.get_ID());                                                
                    }
                    else
                    {

                        Response.Redirect("~/Default.aspx", false);
                    }
                }                          
            }catch(Exception ex_){
                cls_errores.muestraWebError(ex_);
            }
        }

        protected void LlenaGridEmpleados(int IdUsuario) 
        {
            try
            {
                cls_empleado empleado = new cls_empleado();

                gvEmpleados.Columns[13].Visible = true;
                gvEmpleados.Columns[14].Visible = true;
                gvEmpleados.Columns[15].Visible = true;
                gvEmpleados.Columns[16].Visible = true;
                gvEmpleados.Columns[17].Visible = true;
                gvEmpleados.DataSource = DTmodificadoGrid(empleado.verTodosEmpelados(IdUsuario));
                gvEmpleados.DataBind();
                gvEmpleados.Columns[13].Visible = false;
                gvEmpleados.Columns[14].Visible = false;
                gvEmpleados.Columns[15].Visible = false;
                gvEmpleados.Columns[16].Visible = false;
                gvEmpleados.Columns[17].Visible = false;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        protected DataTable DTmodificadoGrid(DataTable DTbd) 
        {
            try
            {
                DataTable dtModificado = new DataTable();
                dtModificado.Columns.Add(new DataColumn("IDempleado"));
                dtModificado.Columns.Add(new DataColumn("nombreEmp"));
                dtModificado.Columns.Add(new DataColumn("apePat"));
                dtModificado.Columns.Add(new DataColumn("apeMat"));
                dtModificado.Columns.Add(new DataColumn("d_login"));
                dtModificado.Columns.Add(new DataColumn("d_contrasenia"));
                dtModificado.Columns.Add(new DataColumn("d_email"));
                dtModificado.Columns.Add(new DataColumn("fechaAlta"));
                dtModificado.Columns.Add(new DataColumn("IDpuesto"));
                dtModificado.Columns.Add(new DataColumn("IDemp"));
                dtModificado.Columns.Add(new DataColumn("IDarea"));
                dtModificado.Columns.Add(new DataColumn("id_perfil"));
                dtModificado.Columns.Add(new DataColumn("nomEmpresa"));
                dtModificado.Columns.Add(new DataColumn("nomPuesto"));
                dtModificado.Columns.Add(new DataColumn("nomArea"));
                dtModificado.Columns.Add(new DataColumn("d_perfil"));

                DataRow dr;
                if (DTbd.Rows.Count > 0) 
                {
                    foreach (DataRow item in DTbd.Rows)
                    {
                        dr = dtModificado.NewRow();
                        dr["IDempleado"] = item["IDempleado"].ToString();
                        dr["nombreEmp"] = item["nombreEmp"].ToString();
                        dr["apePat"] = item["apePat"].ToString();
                        dr["apeMat"] = item["apeMat"].ToString();
                        dr["d_login"] = item["d_login"].ToString();
                        dr["d_contrasenia"] = item["d_contrasenia"].ToString();
                        dr["d_email"] = item["d_email"].ToString();

                        if (!string.IsNullOrEmpty(item["fechaAlta"].ToString()))
                        {
                            dr["fechaAlta"] = DateTime.Parse(item["fechaAlta"].ToString()).ToShortDateString();
                        }
                        else 
                        {
                            dr["fechaAlta"] = string.Empty;
                        }

                        dr["IDpuesto"] = item["IDpuesto"].ToString();
                        dr["IDemp"] = item["IDemp"].ToString();
                        dr["IDarea"] = item["IDarea"].ToString();
                        dr["id_perfil"] = item["id_perfil"].ToString();
                        dr["nomEmpresa"] = item["nomEmpresa"].ToString();
                        dr["nomPuesto"] = item["nomPuesto"].ToString();
                        dr["nomArea"] = item["nomArea"].ToString();
                        dr["d_perfil"] = item["d_perfil"].ToString();
                        dtModificado.Rows.Add(dr);
                    }

                    dr = dtModificado.NewRow();
                    dr["IDempleado"] = string.Empty;
                    dr["nombreEmp"] = string.Empty;
                    dr["apePat"] = string.Empty;
                    dr["apeMat"] = string.Empty;
                    dr["d_login"] = string.Empty;
                    dr["d_contrasenia"] = string.Empty;
                    dr["d_email"] = string.Empty;
                    dr["fechaAlta"] = string.Empty;
                    dr["IDpuesto"] = string.Empty;
                    dr["IDemp"] = string.Empty;
                    dr["IDarea"] = string.Empty;
                    dr["id_perfil"] = string.Empty;
                    dr["nomEmpresa"] = string.Empty;
                    dr["nomPuesto"] = string.Empty;
                    dr["nomArea"] = string.Empty;
                    dr["d_perfil"] = string.Empty;
                    dtModificado.Rows.Add(dr);
                }

                return dtModificado;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
        
        protected void combo_Areas(int IDEmpleado, DropDownList ddlCtrl)
        {
            try
            {
                ddlCtrl.Items.Clear();                
                cls_area area = new cls_area();
                DataTable dt_item_ = area.verAreas(IDEmpleado);

                for (int countItem = 0; countItem < dt_item_.Rows.Count; countItem++)
                {
                    ListItem item_area = new ListItem();
                    item_area.Value = (dt_item_.Rows[countItem]["IDarea"]).ToString();
                    item_area.Text = (dt_item_.Rows[countItem]["nomArea"]).ToString();
                    ddlCtrl.Items.Add(item_area);                    
                }                
            }
            catch (Exception ex_)
            {
                ex_.ToString();
            }
        }

        protected void combo_Empresa(int IDEmpleado, DropDownList ddlCtrl)
        {
            try
            {
                ddlCtrl.Items.Clear();                
                cls_empresa empresa = new cls_empresa();
                DataTable dt_item_ = empresa.verTodasEmpresas(IDEmpleado);

                for (int countItem = 0; countItem < dt_item_.Rows.Count; countItem++)
                {
                    ListItem item_empresa = new ListItem();
                    item_empresa.Value = (dt_item_.Rows[countItem]["IDEmpresa"]).ToString();
                    item_empresa.Text = (dt_item_.Rows[countItem]["nomEmpresa"]).ToString();
                    ddlCtrl.Items.Add(item_empresa);                    
                }                
            }
            catch (Exception ex_)
            {
                ex_.ToString();
            }
        }

        public void combo_Puesto(int IDEmpleado, DropDownList ddlCtrl)
        {
            try
            {
                ddlCtrl.Items.Clear();
                cls_puesto puesto = new cls_puesto();
                DataTable dt_item_ = puesto.verPuestos(IDEmpleado);

                for (int countItem = 0; countItem < dt_item_.Rows.Count; countItem++)
                {
                    ListItem item_puesto = new ListItem();
                    item_puesto.Value = (dt_item_.Rows[countItem]["IDpuesto"]).ToString();
                    item_puesto.Text = (dt_item_.Rows[countItem]["nomPuesto"]).ToString();
                    ddlCtrl.Items.Add(item_puesto);
                }
            }
            catch (Exception ex_)
            {

                cls_errores.muestraWebError(ex_);
            }
        }

        public void combo_Perfil(int IDEmpleado, DropDownList ddlCtrl)
        {
            try
            {
                ddlCtrl.Items.Clear();
                cls_perfil Perfil = new cls_perfil();
                DataTable dt_item_ = Perfil.verPerfilesAplicacion(IDEmpleado);

                for (int countItem = 0; countItem < dt_item_.Rows.Count; countItem++)
                {
                    ListItem item_puesto = new ListItem();
                    item_puesto.Value = (dt_item_.Rows[countItem]["IDPerfil"]).ToString();
                    item_puesto.Text = (dt_item_.Rows[countItem]["nomperfil"]).ToString();
                    ddlCtrl.Items.Add(item_puesto);
                }
            }
            catch (Exception ex_)
            {

                cls_errores.muestraWebError(ex_);
            }
        }

        protected void btnEditar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                GridViewRow gRow;
                ImageButton btnEditar;
                DropDownList ddlGenerico;
                btnEditar = (ImageButton)sender;
                gRow = (GridViewRow)btnEditar.Parent.Parent;

                ((ImageButton)gRow.FindControl("btnAceptar")).Visible = true;
                ((ImageButton)gRow.FindControl("btnCancelar")).Visible = true;

                ((TextBox)gRow.FindControl("txtNombre")).Visible = true;
                ((TextBox)gRow.FindControl("txtNombre")).Text = ((Label)gRow.FindControl("lblNombre")).Text;
                ((Label)gRow.FindControl("lblNombre")).Visible = false;

                ((TextBox)gRow.FindControl("txtPaterno")).Visible = true;
                ((TextBox)gRow.FindControl("txtPaterno")).Text = ((Label)gRow.FindControl("lblPaterno")).Text;
                ((Label)gRow.FindControl("lblPaterno")).Visible = false;

                ((TextBox)gRow.FindControl("txtMaterno")).Visible = true;
                ((TextBox)gRow.FindControl("txtMaterno")).Text = ((Label)gRow.FindControl("lblMaterno")).Text;
                ((Label)gRow.FindControl("lblMaterno")).Visible = false;

                ((TextBox)gRow.FindControl("txtUsuario")).Visible = true;
                ((TextBox)gRow.FindControl("txtUsuario")).Text = ((Label)gRow.FindControl("lblUsuario")).Text;
                ((Label)gRow.FindControl("lblUsuario")).Visible = false;

                ((TextBox)gRow.FindControl("txtPassword")).Visible = true;
                ((TextBox)gRow.FindControl("txtPassword")).Text = ((Label)gRow.FindControl("lblPassword")).Text;
                ((Label)gRow.FindControl("lblPassword")).Visible = false;

                ((TextBox)gRow.FindControl("txtCorreo")).Visible = true;
                ((TextBox)gRow.FindControl("txtCorreo")).Text = ((Label)gRow.FindControl("lblCorreo")).Text;
                ((Label)gRow.FindControl("lblCorreo")).Visible = false;

                ((TextBox)gRow.FindControl("txtFechaAlta")).Visible = true;
                ((TextBox)gRow.FindControl("txtFechaAlta")).Text = ((Label)gRow.FindControl("lblFechaAlta")).Text;
                ((Label)gRow.FindControl("lblFechaAlta")).Visible = false;
                ((ImageButton)gRow.FindControl("btnFechaAlta")).Visible = true;

                ddlGenerico = new DropDownList();
                ddlGenerico = ((DropDownList)gRow.FindControl("ddlPuesto"));
                combo_Puesto(cls_acceso.get_ID(), ddlGenerico);
                ((DropDownList)gRow.FindControl("ddlPuesto")).Visible = true;
                ((Label)gRow.FindControl("lblPuesto")).Visible = false;
                if (!string.IsNullOrEmpty(((Label)gRow.FindControl("IDpuesto")).Text))
                {
                    ddlGenerico.SelectedValue = ((Label)gRow.FindControl("IDpuesto")).Text;
                }

                ddlGenerico = new DropDownList();
                ddlGenerico = ((DropDownList)gRow.FindControl("ddlEmpresa"));
                combo_Empresa(cls_acceso.get_ID(), ddlGenerico);
                ((DropDownList)gRow.FindControl("ddlEmpresa")).Visible = true;
                ((Label)gRow.FindControl("lblEmpresa")).Visible = false;
                if (!string.IsNullOrEmpty(((Label)gRow.FindControl("IDemp")).Text))
                {
                    ddlGenerico.SelectedValue = ((Label)gRow.FindControl("IDemp")).Text;
                }

                ddlGenerico = new DropDownList();
                ddlGenerico = ((DropDownList)gRow.FindControl("ddlArea"));
                combo_Areas(cls_acceso.get_ID(), ddlGenerico);
                ((DropDownList)gRow.FindControl("ddlArea")).Visible = true;
                ((Label)gRow.FindControl("lblArea")).Visible = false;
                if (!string.IsNullOrEmpty(((Label)gRow.FindControl("IDarea")).Text))
                {
                    ddlGenerico.SelectedValue = ((Label)gRow.FindControl("IDarea")).Text;
                }

                ddlGenerico = new DropDownList();
                ddlGenerico = ((DropDownList)gRow.FindControl("ddlPerfil"));
                combo_Perfil(cls_acceso.get_ID(), ddlGenerico);
                ((DropDownList)gRow.FindControl("ddlPerfil")).Visible = true;
                ((Label)gRow.FindControl("lblPerfil")).Visible = false;
                if (!string.IsNullOrEmpty(((Label)gRow.FindControl("IDperfil")).Text))
                {
                    ddlGenerico.SelectedValue = ((Label)gRow.FindControl("IDperfil")).Text;
                }


                ((ImageButton)gRow.FindControl("btnEditar")).Visible = false;
                ((ImageButton)gRow.FindControl("btnEliminar")).Visible = false;
            }
            catch (Exception ex)
            {
                Msg.ShowMsg(this, ex.Message);
            }
        }

        protected void btnAceptar_Click(object sender, ImageClickEventArgs e) 
        {
            try
            {
                cls_empleado empleado = new cls_empleado();
                GridViewRow gRow;
                ImageButton btnAceptar;
                btnAceptar = (ImageButton)sender;
                gRow = (GridViewRow)btnAceptar.Parent.Parent;

                int Resp = 0;
                DropDownList ddlPuesto = new DropDownList();
                ddlPuesto = ((DropDownList)gRow.FindControl("ddlPuesto"));
                DropDownList ddlEmpresa = new DropDownList();
                ddlEmpresa = ((DropDownList)gRow.FindControl("ddlEmpresa"));
                DropDownList ddlArea = new DropDownList();
                ddlArea = ((DropDownList)gRow.FindControl("ddlArea"));
                DropDownList ddlPerfil = new DropDownList();
                ddlPerfil = ((DropDownList)gRow.FindControl("ddlPerfil"));

                if (!string.IsNullOrEmpty(((Label)gRow.FindControl("IDempleado")).Text))
                {
                    //MODIFICA
                    if (!string.IsNullOrEmpty(((TextBox)gRow.FindControl("txtNombre")).Text) && !string.IsNullOrEmpty(((TextBox)gRow.FindControl("txtPaterno")).Text)) 
                    {
                        Resp = empleado.modificaEmpleado(int.Parse(((Label)gRow.FindControl("IDempleado")).Text),
                                                        ((TextBox)gRow.FindControl("txtNombre")).Text,
                                                        ((TextBox)gRow.FindControl("txtPaterno")).Text,
                                                        ((TextBox)gRow.FindControl("txtMaterno")).Text,
                                                        ((TextBox)gRow.FindControl("txtFechaAlta")).Text,
                                                        int.Parse(ddlPuesto.SelectedValue),
                                                        int.Parse(ddlEmpresa.SelectedValue),
                                                        int.Parse(ddlArea.SelectedValue),
                                                        ((TextBox)gRow.FindControl("txtUsuario")).Text,
                                                        ((TextBox)gRow.FindControl("txtPassword")).Text,
                                                        ((TextBox)gRow.FindControl("txtCorreo")).Text,
                                                        int.Parse(ddlPerfil.SelectedValue));
                    }
                }
                else 
                {
                    //INSERTA
                    if (!string.IsNullOrEmpty(((TextBox)gRow.FindControl("txtNombre")).Text) && !string.IsNullOrEmpty(((TextBox)gRow.FindControl("txtPaterno")).Text))
                    {
                        Resp = empleado.agregarEmpleado(((TextBox)gRow.FindControl("txtNombre")).Text,
                                                        ((TextBox)gRow.FindControl("txtPaterno")).Text,
                                                        ((TextBox)gRow.FindControl("txtMaterno")).Text,
                                                        ((TextBox)gRow.FindControl("txtFechaAlta")).Text,
                                                        int.Parse(ddlPuesto.SelectedValue),
                                                        int.Parse(ddlEmpresa.SelectedValue),
                                                        int.Parse(ddlArea.SelectedValue),
                                                        ((TextBox)gRow.FindControl("txtUsuario")).Text,
                                                        ((TextBox)gRow.FindControl("txtPassword")).Text,
                                                        ((TextBox)gRow.FindControl("txtCorreo")).Text,
                                                        int.Parse(ddlPerfil.SelectedValue));
                    }                                     
                }

                if (Resp.Equals(1))
                {
                    LlenaGridEmpleados(cls_acceso.get_ID());
                }   
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }

        protected void btnEliminar_Click(object sender, ImageClickEventArgs e) 
        {
            try
            {
                cls_empleado empleado = new cls_empleado();
                GridViewRow gRow;
                ImageButton btnEliminar;
                btnEliminar = (ImageButton)sender;
                gRow = (GridViewRow)btnEliminar.Parent.Parent;
                int Resp = 0;

                if (!string.IsNullOrEmpty(((Label)gRow.FindControl("IDempleado")).Text))
                {
                    Resp = empleado.quitarEmpelado(cls_acceso.get_ID(), int.Parse(((Label)gRow.FindControl("IDempleado")).Text));

                    if (Resp.Equals(1))
                    {
                        Msg.ShowMsg(this, "Registro eliminado exitosamente.");
                        LlenaGridEmpleados(cls_acceso.get_ID());
                    }
                    else
                    {
                        Msg.ShowMsg(this, "Error al intentar eliminar.");
                    }
                }
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }
        protected void btnCancelar_Click(object sender, ImageClickEventArgs e) 
        {
            try
            {
                GridViewRow gRow;
                ImageButton btnAceptar;
                btnAceptar = (ImageButton)sender;
                gRow = (GridViewRow)btnAceptar.Parent.Parent;

                ((ImageButton)gRow.FindControl("btnEditar")).Visible = true;
                ((ImageButton)gRow.FindControl("btnEliminar")).Visible = true;

                ((Label)gRow.FindControl("lblNombre")).Visible = true;
                ((TextBox)gRow.FindControl("txtNombre")).Visible = false;
                ((TextBox)gRow.FindControl("txtNombre")).Text = string.Empty;

                ((Label)gRow.FindControl("lblPaterno")).Visible = true;
                ((TextBox)gRow.FindControl("txtPaterno")).Visible = false;
                ((TextBox)gRow.FindControl("txtPaterno")).Text = string.Empty;

                ((Label)gRow.FindControl("lblMaterno")).Visible = true;
                ((TextBox)gRow.FindControl("txtMaterno")).Visible = false;
                ((TextBox)gRow.FindControl("txtMaterno")).Text = string.Empty;

                ((Label)gRow.FindControl("lblUsuario")).Visible = true;                
                ((TextBox)gRow.FindControl("txtUsuario")).Text = string.Empty;
                ((TextBox)gRow.FindControl("txtUsuario")).Visible = false;

                ((Label)gRow.FindControl("lblPassword")).Visible = true;                
                ((TextBox)gRow.FindControl("txtPassword")).Text = string.Empty;
                ((TextBox)gRow.FindControl("txtPassword")).Visible = false;

                ((Label)gRow.FindControl("lblCorreo")).Visible = true;                
                ((TextBox)gRow.FindControl("txtCorreo")).Text = string.Empty;
                ((TextBox)gRow.FindControl("txtCorreo")).Visible = false;

                ((Label)gRow.FindControl("lblFechaAlta")).Visible = true;
                ((TextBox)gRow.FindControl("txtFechaAlta")).Visible = false;
                ((TextBox)gRow.FindControl("txtFechaAlta")).Text = string.Empty;
                ((ImageButton)gRow.FindControl("btnFechaAlta")).Visible = false;

                ((Label)gRow.FindControl("lblPuesto")).Visible = true;
                ((DropDownList)gRow.FindControl("ddlPuesto")).Visible = false;

                ((Label)gRow.FindControl("lblEmpresa")).Visible = true;
                ((DropDownList)gRow.FindControl("ddlEmpresa")).Visible = false;

                ((Label)gRow.FindControl("lblArea")).Visible = true;
                ((DropDownList)gRow.FindControl("ddlArea")).Visible = false;

                ((Label)gRow.FindControl("lblPerfil")).Visible = true;
                ((DropDownList)gRow.FindControl("ddlPerfil")).Visible = false;

                ((ImageButton)gRow.FindControl("btnAceptar")).Visible = false;
                ((ImageButton)gRow.FindControl("btnCancelar")).Visible = false;
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }        
              
    }
}