using System;
using System.Data;
using System.Web.UI.WebControls;
using betaCulturalMARKII.conexionMysql;
using System.Data.SqlClient;

namespace betaCulturalMARKII.area
{
    public class cls_area
    {

        public cls_area()
        {

        }//cls_area

        public int agregarArea(string nombreArea, string desArea, int IDempresa)
        {

            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();


            int r_store = -100;

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[4];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@nomArea", SqlDbType.VarChar);
                parametroMySql[2] = new SqlParameter("@desArea", SqlDbType.VarChar);
                parametroMySql[3] = new SqlParameter("@IDempresa", SqlDbType.Int);


                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;
                parametroMySql[2].Direction = ParameterDirection.Input;
                parametroMySql[3].Direction = ParameterDirection.Input;

                parametroMySql[1].Value = nombreArea;
                parametroMySql[2].Value = desArea;
                parametroMySql[3].Value = IDempresa;


                accesoMysql.fn_getResultado_Command(parametroMySql, "agregarArea");


                r_store = int.Parse(parametroMySql[0].Value.ToString());


                return r_store;

            }
            catch (Exception ex_)
            {
                ex_.ToString();
                return r_store;
            }//try-catch


        }//agregarArea


        public int quitarArea(int IDempleado, int IDareaQuitar)
        {

            int r_store = -100;
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[3];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDempleado", SqlDbType.Int);
                parametroMySql[2] = new SqlParameter("@IDareaQuitar", SqlDbType.Int);

                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;
                parametroMySql[2].Direction = ParameterDirection.Input;

                parametroMySql[1].Value = IDempleado;
                parametroMySql[2].Value = IDareaQuitar;

                accesoMysql.fn_getResultado_Command(parametroMySql, "quitarArea");

                r_store = int.Parse(parametroMySql[0].Value.ToString());

                return r_store;
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return r_store;
            }//try-catch


        }//quitarArea



        public DataTable verAreas(int IDEmpleado)
        {

            DataTable dt_area = new DataTable();
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[2];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDempleado", SqlDbType.Int);

                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;

                parametroMySql[1].Value = IDEmpleado;

                dt_area = accesoMysql.fn_getResultado_DataTable(parametroMySql, "verAreas");

                return dt_area;

            }
            catch (Exception ex_)
            {
                ex_.ToString();
                return dt_area = new DataTable();
            }//try-catch

        }//verAreas


        public void combo_Areas(int IDEmpleado, Panel div_componente_P, string comboDespliega)
        {
            try
            {
                DataTable dt_item_ = verAreas(IDEmpleado);

                for (int countItem = 0; countItem < dt_item_.Rows.Count; countItem++)
                {
                    ListItem item_area = new ListItem();

                    item_area.Value = (dt_item_.Rows[countItem]["IDarea"]).ToString();
                    item_area.Text = (dt_item_.Rows[countItem]["nomArea"]).ToString();
                    ((DropDownList)div_componente_P.FindControl(comboDespliega)).Items.Add(item_area);
                }//for

                ((DropDownList)div_componente_P.FindControl(comboDespliega)).SelectedValue = "1";


            }
            catch (Exception ex_)
            {
                ex_.ToString();
            }//try-catch

        }//combo_Areas





    }//cls_area
}//betaCultural