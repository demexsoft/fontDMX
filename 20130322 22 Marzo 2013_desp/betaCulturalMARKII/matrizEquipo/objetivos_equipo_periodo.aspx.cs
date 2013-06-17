using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using betaCulturalMARKII.equipo;
using betaCulturalMARKII.objetivoEquipo;
using betaCulturalMARKII.idioma;

namespace betaCulturalMARKII.matrizEquipo
{
    public partial class objetivos_equipo_periodo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }//Page_Load

       

        protected void btn_buscar_objetivo_fecha_Click(object sender, EventArgs e)
        {
            try
            {
                cls_objetivoEquipo matrizEquipo = new cls_objetivoEquipo();
                DataTable dt_objetivoEquipoPeriodo = new DataTable();

                dt_objetivoEquipoPeriodo = matrizEquipo.verObjetivosEquipoPorPeriodo(cls_acceso.get_ID(), cls_equipo.get_IDEquipo(), txt_FechaInicioObjetivoEquipo.Text, txt_FechaFinalObjetivoEquipo.Text);
                dg_objetivosEquipo.DataSource = dt_objetivoEquipoPeriodo;
                dg_objetivosEquipo.DataBind();

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch
        }


        protected void dg_objetivosEquipo_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {

                    txt_areasOportunidad_modifica_objEquipo.ReadOnly = false;
                    txt_fecha_cumplimiento_modifica_objEquipo.ReadOnly = false;


                txt_areasOportunidad_modifica_objEquipo.Text = e.Item.Cells[10].Text;
                txt_fecha_cumplimiento_modifica_objEquipo.Text = e.Item.Cells[8].Text;

                lbl_eficacia_modifica_objEquipo.Text = e.Item.Cells[6].Text;
                lbl_eficiencia_modifica_objEquipo.Text = e.Item.Cells[7].Text;

                if (e.Item.Cells[7].Text == "1")
                {
                    lbl_status_objIndividual.Text = Convert.ToString(cls_idioma.get_seleccionDeIdioma().Rows[cls_idioma.get_seleccionDeIdioma().Rows.IndexOf(cls_idioma.get_seleccionDeIdioma().Select("IDMSG='cmb_item_objetivo_SI'")[0])]["STRMSG"]);
                }else {

                    lbl_status_objIndividual.Text = Convert.ToString(cls_idioma.get_seleccionDeIdioma().Rows[cls_idioma.get_seleccionDeIdioma().Rows.IndexOf(cls_idioma.get_seleccionDeIdioma().Select("IDMSG='cmb_item_objetivo_NO'")[0])]["STRMSG"]);
                }




                tbl_objetivosEquipo_ver.Visible = true;


            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch
            // dg_objetivosEquipo_ItemCommand
        }


    }//class
}