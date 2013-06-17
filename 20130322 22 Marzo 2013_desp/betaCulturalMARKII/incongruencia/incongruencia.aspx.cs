using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace betaCulturalMARKII.incongruencia
{
    public partial class incongruencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try{

            cls_incongruencia incongruencia = new cls_incongruencia();


            switch (Session["compoIncongruencia"].ToString())
                {

                    case "TodasIncongruencia":
                        

                        break;
                        
                    case "Add":
                        tbl_incongruencia_agregar.Visible = true;

                        break;

                    case "Quit":
                     

                        break;
                }


            }catch (Exception ex_){   

                    ex_.ToString();
           }//try-catch
        }//load


        protected void btn_img_fechaIncongruencia_Click(object sender, EventArgs e)
        {
            try
            {
                calendario(txt_fecha_incongruencia);
                pnl_content_calendario.Visible = true;

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

            //btn_img_fechaIncongruencia
        }

        protected void lnk_cerrar_panel_calendario_Click(object sender, EventArgs e)
        {
            try
            {
                pnl_content_calendario.Visible = false;
                

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

            //btn_img_fechaIncongruencia
        }

        static string textComponente;

        public void calendario(TextBox txtboxes)
        {

            textComponente = txtboxes.ID.ToString();


            pnl_content_calendario.Style["left"] = "100px";
            pnl_content_calendario.Style["top"] = "100px";



        }


        public void combo_origenProblema()
        {
            try
            {
                cls_incongruencia incongruencia = new cls_incongruencia();
                DataTable dt_item_ =incongruencia. verOrigenProblema(cls_acceso.get_ID());

                cmb_origen_problema_incongruencia.Items.Clear();

                ListItem item_ = new ListItem();

                cmb_origen_problema_incongruencia.Items.Add(item_);

                for (int countItem = 0; countItem < dt_item_.Rows.Count; countItem++)
                {
                    ListItem item_origen = new ListItem();

                    item_origen.Value = (dt_item_.Rows[countItem]["IDProblema"]).ToString();
                    item_origen.Text = (dt_item_.Rows[countItem]["DesProblema"]).ToString();

                    cmb_origen_problema_incongruencia.Items.Add(item_origen);
                }//for




            }
            catch (Exception ex_)
            {

                cls_errores.muestraWebError(ex_);
            }//try-catch

        }//combo_Modelo



    }//class
}