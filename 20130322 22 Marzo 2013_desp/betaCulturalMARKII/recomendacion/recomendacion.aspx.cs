using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using betaCulturalMARKII.equipo;
using System.Data;

namespace betaCulturalMARKII.recomendacion
{
    public partial class recomendacion : System.Web.UI.Page
    {
        cls_Utilerias Msg = new cls_Utilerias();

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                

                switch (Session["compoRecomendacion"].ToString())
                {
                        
                    case "crearRecomendacion":
                        pnl_content_recomendacion.Visible = true;
                    

                        break;
                        
                    case "Add":
                        
                        break;

                    case "Quit":
                     

                        break;
                }

            
            }catch(Exception ex_){
                cls_errores.muestraWebError(ex_);
            }
            
            
            //load
        }

        protected void btn_cancelarEvaluacion_Click(object sender, EventArgs e)
        {
            try
            {
              
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);

            }//try-catch



        }

        protected void dg_equiposCliente_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
               
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);

            }//try-catch

            //dg_equiposCliente_ItemCommand
        }

        protected void dg_equipos_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            try{


            Session["equipoSeleccionado"]= e.Item.Cells[1].Text;
            txt_equipo.Text= e.Item.Cells[2].Text;

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }
        }

        

        protected void btn_img_verEquipo_Click(object sender, ImageClickEventArgs e)
        {
            try{
               

                cls_equipo equipo = new cls_equipo();
                DataTable dt_equipos = equipo.verTodosEquipos(0);

                dg_equipos.DataSource = dt_equipos;
                dg_equipos.DataBind();


              

            
            } catch(Exception ex_){
                cls_errores.muestraWebError(ex_);
            }//try-catch

            //btn_img_verEquipo_Click
        }

        protected void btn_agregarRecomendacion_Click(object sender, EventArgs e)
        {
            try
            {


                if (Session["equipoSeleccionado"].ToString() == "" && txt_situacion.Text == "" && txt_equipo.Text == "" && txt_posibleCausa.Text == "" && txt_propuestaSolucion.Text == "")
                {
                    lbl_aviso_recomendacion.Text = "Revisa tus datos, debe de estar completos-->";

                }
                else
                {
                    cls_recomendacion recomendacion = new cls_recomendacion();

                    int respuesta = recomendacion.agregarRecomendacion(cls_acceso.get_ID(), int.Parse(Session["equipoSeleccionado"].ToString()), txt_fechaRecomendacion.Text,
                                                                       txt_situacion.Text, txt_posibleCausa.Text, txt_propuestaSolucion.Text);

                    if (respuesta == 1)
                    {

                        
                        Msg.ShowMsg(this, "Se guardo con exito.");

                        txt_situacion.Text="";
                        txt_posibleCausa.Text="";
                        txt_propuestaSolucion.Text = "";
                        Session["equipoSeleccionado"] = null;
                        dg_equipos.DataSource = null;
                        dg_equipos.DataBind();
                    }
                    else
                    {
                        Msg.ShowMsg(this, "No se puede agregar la Recomendacion en este momento.");                        

                    }


                }//if-else


            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

            //btn_agregarRecomendacion_Click
        }


//class
    }
}