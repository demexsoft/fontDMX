using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using betaCulturalMARKII.empresa;
using System.Data;

namespace betaCulturalMARKII.area
{
    public partial class area : System.Web.UI.Page
    {
        cls_Utilerias Msg = new cls_Utilerias();

        protected void Page_Load(object sender, EventArgs e)
        { try
            {                
                cls_area area = new cls_area();

                switch (Session["compoArea"].ToString())
                {

                    case "TodasArea":
                        tbl_agregarArea.Visible = false;
                        tbl_quitarArea.Visible = true;

                        grd_area.Columns[0].Visible = false;
                        
                        grd_area.DataSource = area.verAreas(cls_acceso.get_ID());
                        grd_area.DataBind();

                        break;
                        
                    case "AddArea":
                        tbl_agregarArea.Visible = true;
                        tbl_quitarArea.Visible = false;

                        combo_Empresa(cls_acceso.get_ID());
                        break;

                    case "Quit":
                        tbl_agregarArea.Visible = false;
                        tbl_quitarArea.Visible = true;

                        grd_area.Columns[0].Visible = true;
                       
                        grd_area.DataSource = area.verAreas(cls_acceso.get_ID());
                        grd_area.DataBind();

                        break;
                }


            }catch (Exception ex_){   

                    ex_.ToString();
                }//try-catch
        }
        protected void combo_Empresa(int IDEmpleado)
        {
            try
            {
                cmb_empresa_area.Items.Clear();
                cls_empresa empresa = new cls_empresa();
                DataTable dt_item_ = empresa.verTodasEmpresas(IDEmpleado);

                for (int countItem = 0; countItem < dt_item_.Rows.Count; countItem++)
                {
                    ListItem item_empresa = new ListItem();

                    item_empresa.Value = (dt_item_.Rows[countItem]["IDEmpresa"]).ToString();
                    item_empresa.Text = (dt_item_.Rows[countItem]["nomEmpresa"]).ToString();
                    cmb_empresa_area.Items.Add(item_empresa);
                }//for

                cmb_empresa_area.SelectedValue = "1";


            }
            catch (Exception ex_)
            {
                ex_.ToString();
            }//try-catch

        }//combo_Empresa

        protected void btn_guardar_areas_Click(object sender, EventArgs e)
        {

            try
            {
                cls_area area = new cls_area();
                if (-100 == area.agregarArea(txt_nombre_area.Text, txt_desc_area.Text, int.Parse(cmb_empresa_area.SelectedValue)))
                {
                    btn_guardar_areas.Text = "ERROR";
                }
                else
                {
                    Msg.ShowMsg(this, "Se guardo el registro.");
                    
                    tbl_agregarArea.Visible = false;
                    tbl_quitarArea.Visible = true;

                    grd_area.Columns[0].Visible = false;

                    grd_area.DataSource = area.verAreas(cls_acceso.get_ID());
                    grd_area.DataBind();

                    //btn_guardar_areas.Enabled = false;

                }



            }
            catch (Exception ex_)
            {

                ex_.ToString();
            }//try-catch

            //btn_guardar_areas_Click
        }
    }
}