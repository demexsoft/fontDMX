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
    public partial class equipo : System.Web.UI.Page
    {
        cls_incongruencia objIncongruencia = new cls_incongruencia();

        protected void Page_Load(object sender, EventArgs e)
        {
            try{

                switch (Session["compoEquipo"].ToString())
                {

                    case "todosEquipos":
                        tbl_verTodosEquipos.Visible = true;
                              
                            vista_EquiposEmpleadosAll();


                        break;

                    case "Add":
                        cls_equipo.ini_DataTable();
                        tbl_crearEquipo.Visible = true;

                        cls_area area = new cls_area();
                        DataTable dt_item_ = area.verAreas(cls_acceso.get_ID());
                        objIncongruencia.LlenaCombo_verAreas(dt_item_, cmb_area, false);

                        break;

                    case "Quit":
                        break;
                }

            }catch(Exception ex_){
                cls_errores.muestraWebError(ex_);
            }//try-catch
            
        }//Page_Load


        protected void dg_seleccionaJefe_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
                lbl_IDJefeEquipo.Text = e.Item.Cells[1].Text;
                txt_jefeEquipo.Text = e.Item.Cells[2].Text + " " + e.Item.Cells[3].Text;
                pnl_content_empleadosDisponibles.Visible = false;
                dg_seleccionaEmpleado.Visible = false;
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch
            //dg_seleccionaJefe_ItemCommand
        }

        protected void dg_seleccionaEmpleado_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {

                pnl_content_empleadosDisponibles.Visible = false;

                dg_seleccionaJefe.Visible = false;

                DataRow row = cls_equipo.get_miembrosDeEquipo().NewRow();



                row["IDempleado"] = e.Item.Cells[1].Text;//1
                row["nombreEmp"] = e.Item.Cells[2].Text;//2
                row["apePat"] = e.Item.Cells[3].Text; //4
                row["apeMat"] = e.Item.Cells[4].Text; //5
                row["area"] = e.Item.Cells[8].Text;//8


                cls_equipo.set_miembrosDeEquipo(row);


                dgr_integrantesEquipoAdd.DataSource = cls_equipo.get_miembrosDeEquipo();
                dgr_integrantesEquipoAdd.DataBind();


            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

            //dg_seleccionaEmpleado_ItemCommand
        }

        protected void lnk_cerrar_empleados_disponibles_Click(object sender, EventArgs e)
        {
            try
            {
                pnl_content_empleadosDisponibles.Visible = false;

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

            //lnk_cerrar_empleados_disponibles_Click
        }

        protected void btn_img_verJefeAgregarEquipo_Click(object sender, ImageClickEventArgs e)
        {
            try
            {


                cls_empleado empleado = new cls_empleado();
                dg_seleccionaJefe.DataSource = empleado.verTodosEmpelados(cls_acceso.get_ID());
                dg_seleccionaJefe.DataBind();


                pnl_content_empleadosDisponibles.Visible = true;

                dg_seleccionaJefe.Visible = true;
                dg_seleccionaEmpleado.Visible = false;

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

            //btn_img_verJefeAgregarEquipo_Click
        }



        protected void btn_img_verEmpleadoAgregarEquipo_Click(object sender, ImageClickEventArgs e)
        {
            try
            {


                cls_empleado empleado = new cls_empleado();
                dg_seleccionaEmpleado.DataSource = empleado.verTodosEmpelados(cls_acceso.get_ID());
                dg_seleccionaEmpleado.DataBind();

                pnl_content_equipo.Visible = true;
                pnl_content_empleadosDisponibles.Visible = true;

                dg_seleccionaJefe.Visible = false;
                dg_seleccionaEmpleado.Visible = true;

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

            //btn_img_verEmpleadoAgregarEquipo_Click
        }



        protected void btn_crearEquipo_Click(object sender, EventArgs e)
        {
            try
            {


                cls_equipo equipoNuevo = new cls_equipo();


                int IDJefeEquipo = int.Parse(lbl_IDJefeEquipo.Text);
                int IDarea = int.Parse(cmb_area.SelectedValue.ToString());


                cls_equipo.set_ultimoEquipo_(equipoNuevo.crearEquipo(cls_acceso.get_ID(), txt_atividadEquipoAdd.Text, txt_nombreEquipoAdd.Text, IDJefeEquipo, IDarea));

                if (cls_equipo.get_ultimoEquipo_() == -1)
                {
                    lbl_aviso_mensajeEquipo_Miembro_Equipo.Text = Convert.ToString(cls_idioma.get_seleccionDeIdioma().Rows[cls_idioma.get_seleccionDeIdioma().Rows.IndexOf(cls_idioma.get_seleccionDeIdioma().Select("IDMSG='lbl_aviso_mensajeEquipo_Miembro_EquipoEQUI0'")[0])]["STRMSG"]);

                }
                else
                {


                    for (int contObj = 0; contObj < cls_equipo.get_miembrosDeEquipo().Rows.Count; contObj++)
                    {

                        if (equipoNuevo.agregarMiembroEnEquipo(cls_acceso.get_ID(),
                                                               cls_equipo.get_ultimoEquipo_(),
                                                    int.Parse(cls_equipo.get_miembrosDeEquipo().Rows[contObj]["idEmpleado"].ToString())) == 1)
                        {
                            lbl_aviso_mensajeEquipo_Miembro_Equipo.Text = Convert.ToString(cls_idioma.get_seleccionDeIdioma().Rows[cls_idioma.get_seleccionDeIdioma().Rows.IndexOf(cls_idioma.get_seleccionDeIdioma().Select("IDMSG='lbl_aviso_mensajeEquipo_Miembro_EquipoEQUI1MIEM1'")[0])]["STRMSG"]); ;

                        }
                        else
                        {
                            lbl_aviso_mensajeEquipo_Miembro_Equipo.Text = Convert.ToString(cls_idioma.get_seleccionDeIdioma().Rows[cls_idioma.get_seleccionDeIdioma().Rows.IndexOf(cls_idioma.get_seleccionDeIdioma().Select("IDMSG='lbl_aviso_mensajeEquipo_Miembro_EquipoEQUI1MIEM0'")[0])]["STRMSG"]); ;
                            break;
                        }

                    }//for

                    btn_crearEquipo.Enabled = false;

                    lbl_jefeEquipo.Text = "";
                    txt_atividadEquipoAdd.Text = "";
                    txt_nombreEquipoAdd.Text = "";
                    dg_seleccionaJefe.SelectedIndex = -1;
                    dg_seleccionaEmpleado.SelectedIndex = -1;


                }

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch
            //btn_crearEquipo_Click
        }



        protected void btn_ModificarEquipo_Click(object sender, EventArgs e)
        {
            try
            {




            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);

            }//try-catch

            //btn_ModificarEquipo_Click
        }



        protected void tv_equiposEmpleadosAll_SelectedNodeChanged(object sender, EventArgs e)
        {
            try
            {
                if (tv_equiposEmpleadosAll.SelectedNode.Parent == null)
                {

                    DataTable datosEquipo = new DataTable();

                    int IDEquipo = int.Parse(tv_equiposEmpleadosAll.SelectedNode.Value);

                    tbl_crearEquipo.Visible = true;

                    btn_ModificarEquipo.Visible = true;

                    cls_equipo equipoModificar = new cls_equipo();

                    datosEquipo = equipoModificar.verDatosEquipoID(IDEquipo);

                    txt_nombreEquipoAdd.Text = datosEquipo.Rows[0]["nomEqui"].ToString();
                    txt_atividadEquipoAdd.Text = datosEquipo.Rows[0]["actiEquipo"].ToString();
                    txt_jefeEquipo.Text = datosEquipo.Rows[0]["nomJefe"].ToString();



                }
                else
                {
                    tbl_crearEquipo.Visible = false;
                    txt_nombreEquipoAdd.Text = "";
                    btn_ModificarEquipo.Visible = false;
                }

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-cath
            //tv_equiposEmpleadosAll_SelectedNodeChanged
        }

        public void vista_EquiposEmpleadosAll()
        {
            try
            {

                cls_equipo equipo = new cls_equipo();

                DataTable tbl_empleadoID = equipo.verEmpleadosEnEquipo();
                DataTable tbl_equipoID = equipo.verTodosEquipos(0);

                tbl_empleadoID.TableName = "tbl_empleadoID";
                tbl_equipoID.TableName = "tbl_equipoID";

                //

                DataSet ds = new DataSet();

                ds.Tables.Add(tbl_empleadoID);
                ds.Tables.Add(tbl_equipoID);




                tv_equiposEmpleadosAll.Nodes.Clear();

                for (int padre = 0; padre < ds.Tables["tbl_equipoID"].Rows.Count; padre++)
                {
                    string nombre = ds.Tables["tbl_equipoID"].Rows[padre]["nomEqui"].ToString();
                    string jefeEquipo = ds.Tables["tbl_equipoID"].Rows[padre]["nomJefe"].ToString();

                    TreeNode nodoPadre = new TreeNode("<strong> " + nombre + "</strong> [ " + jefeEquipo + " ] <span class='textoChicoAzul_'>EDITAR</span>");

                    nodoPadre.Value = ds.Tables["tbl_equipoID"].Rows[padre]["IDEquipo"].ToString();

                    for (int hijo = 0; hijo < ds.Tables["tbl_empleadoID"].Rows.Count; hijo++)
                    {
                        if (ds.Tables["tbl_empleadoID"].Rows[hijo]["parentIDEquipo"].ToString() == ds.Tables["tbl_equipoID"].Rows[padre]["IDEquipo"].ToString())
                        {
                            TreeNode nodoHijo = new TreeNode(ds.Tables["tbl_empleadoID"].Rows[hijo]["nom"].ToString());
                            nodoHijo.Value = ds.Tables["tbl_empleadoID"].Rows[hijo]["id_empleado"].ToString();
                            nodoHijo.ImageUrl = "imagenesBasicas/botonesImagenes/iconos/empleadoIcon.png";

                            nodoPadre.ChildNodes.Add(nodoHijo);
                        }//if
                        else
                        {

                        }
                    }//foreach-drHijo
                    nodoPadre.ImageUrl = "imagenesBasicas/botonesImagenes/iconos/equipoico.png";
                    tv_equiposEmpleadosAll.Nodes.Add(nodoPadre);
                }//foreach-drPadre

                tv_equiposEmpleadosAll.ExpandAll();



            }
            catch (Exception ex_)
            {
                ex_.ToString();
            }//try-catch

        }//vista_EquiposEmpleadosAll



    }
}