using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using betaCulturalMARKII.empleado;

namespace betaCulturalMARKII.acuerdos
{
    public partial class acuerdos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try {

                switch(Session["compoPropuestas"].ToString()){

                    case "agregarPropuestas":

                        pnl_verPropuesta.Visible = false;
                        pnl_agregarPropuesta.Visible = true;

                    break;

                    case "verPropuestas":
                    if (Session["verPropuestas_VER"]!=null)
                    {
                            if (Session["verPropuestas_VER"].ToString() == "true")
                            {
                                verPropuesta();
                                Session["verPropuestas_VER"] = "false";
                            }
                            else {
                               
                            }
                        }
                        
                        pnl_agregarPropuesta.Visible = false;
                        pnl_verPropuesta.Visible = true;
                        

                    break;
                
                }//swtich



            }catch(Exception ex_){
                cls_errores.muestraWebError(ex_);
            }//try-catch

            //Page_Load
        }

        protected void btn_guardarAcuerdo_Click(object sender, EventArgs e)
        {
            try {
                int respuesta = 0;

                cls_acuerdos acuerdo = new cls_acuerdos();
             


                  if (txt_descripcion.Text != "" && txt_descripcion.Text != " ")
                  {


                      if (txt_empleado_propuesta.Text != "")
                      {


                          if (txt_fecha_propuesta.Text != "")
                          {
                              respuesta = acuerdo.agregarAcuerdo(txt_descripcion.Text,
                                                                 txt_fecha_propuesta.Text,
                                                                 int.Parse(Session["empleadoSeleccionado"].ToString()));

                              if (respuesta == 1)
                              {

                                  lbl_avisoAcuerdos.Text = "Acuerdo Agregado";

                                  txt_descripcion.Text = "";
                                  txt_empleado_propuesta.Text = "";
                                  txt_fecha_propuesta.Text = "";

                                  dg_seleccionaEmpleado.DataSource = null;
                                  dg_seleccionaEmpleado.DataBind();


                              }
                              else
                              {

                                  lbl_avisoAcuerdos.Text = "Ha ocurrido un ERROR, no se ha podido agregar";
                              }

                          }
                          else
                          {
                              lbl_avisoAcuerdos.Text = "Selecciona a una Fecha";
                          }

                      }
                      else
                      {
                          lbl_avisoAcuerdos.Text = "Selecciona a un Empleado";
                      }
                  }
                  else
                  {
                      lbl_avisoAcuerdos.Text = "Agrega Una Descripcion";
                  }


                
                    



            }catch(Exception ex_){
                cls_errores.muestraWebError(ex_);
            }//try-catch
            //btn_guardarAcuerdo_Click
        }
      
        protected void dg_seleccionaEmpleado_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
                Session["empleadoSeleccionado"]=int.Parse(e.Item.Cells[1].Text);//1

               txt_empleado_propuesta.Text= e.Item.Cells[2].Text+" "+e.Item.Cells[3].Text+" "+e.Item.Cells[4].Text;
                

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

            //dg_seleccionaEmpleado_ItemCommand
        }

        protected void btn_img_verEmpleadoAgregarEquipo_Click(object sender, ImageClickEventArgs e)
        {
            try
            {


                cls_empleado empleado = new cls_empleado();
                dg_seleccionaEmpleado.DataSource = empleado.verTodosEmpelados(cls_acceso.get_ID());
                dg_seleccionaEmpleado.DataBind();


            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch
            //
        }

        protected void verPropuesta(){
            try{
                cls_acuerdos acuerdos=new cls_acuerdos();

                dg_verPropuesta.DataSource = acuerdos.verAcuerdos();
                dg_verPropuesta.DataBind();
            
            }catch(Exception ex_){
            cls_errores.muestraWebError(ex_);
            }//try-catch
        
        }

        protected void dg_verPropuesta_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            try {
                Session["verPropuestas_VER"] = "false";

                lbl_verEmpleadoPropuesta.Text = e.Item.Cells[5].Text + " " + e.Item.Cells[6].Text + " " + e.Item.Cells[7].Text;
                lbl_verFechaPropuesta.Text = e.Item.Cells[4].Text;
                lbl_verDescipcionPropuesta.Text = e.Item.Cells[2].Text;

            }catch(Exception ex_){
                cls_errores.muestraWebError(ex_);
            }//try-catch

            //dg_verPropuesta_ItemCommand

        }

      
        



    }
}