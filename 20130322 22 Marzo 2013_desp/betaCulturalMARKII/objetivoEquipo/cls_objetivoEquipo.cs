using System;
using System.Data;
using betaCulturalMARKII.conexionMysql;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web;

namespace betaCulturalMARKII.objetivoEquipo
{
    public class cls_objetivoEquipo
    {

        public cls_objetivoEquipo()
        {

        }//cls_objetivoEquipo

        static DataTable td_objetivoEquipo = new DataTable();

        public static void ini_DataTable()
        {
            try
            {

                if (HttpContext.Current.Session["td_objetivoEquipo"] == null)
                {

                    td_objetivoEquipo = new DataTable();

                    td_objetivoEquipo.Columns.Add("idMatrizEquipo");//1
                    td_objetivoEquipo.Columns.Add("IDObjEquipo");//->no implementado
                    td_objetivoEquipo.Columns.Add("descObjetivoEquipo");//2
                    td_objetivoEquipo.Columns.Add("tipoObjetivoEquipo");//3
                    td_objetivoEquipo.Columns.Add("fechaComproEquipo");//4
                    td_objetivoEquipo.Columns.Add("estatusObjetivoEquipo");//5
                    td_objetivoEquipo.Columns.Add("porEficaciaEquipo");//6
                    td_objetivoEquipo.Columns.Add("porEficienciaEquipo");//7
                    td_objetivoEquipo.Columns.Add("fechaCumpliEquipo");//8
                    td_objetivoEquipo.Columns.Add("semanasAtrasoEquipo");//9
                    td_objetivoEquipo.Columns.Add("areaOportunidadEquipo");//10
                    td_objetivoEquipo.Columns.Add("id_integranteEquipo");//11
                    td_objetivoEquipo.Columns.Add("id_equipo");//12     

                    HttpContext.Current.Session["td_objetivoEquipo"] = td_objetivoEquipo;

                }
                else
                {
                    td_objetivoEquipo = (DataTable)HttpContext.Current.Session["td_objetivoEquipo"];

                }

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch
        }//ini_DataTable

        public static void set_IDobejtivo(int objP)
        {
            HttpContext.Current.Session["IDobjEquipo_"] = objP;

        }

        public static int get_IDobejtivo()
        {

            return (int)HttpContext.Current.Session["IDobjEquipo_"];
        }


        //no sirve
        public static DataTable get_objetivosEquipo()
        {

            return (DataTable)HttpContext.Current.Session["td_objetivoEquipo"];
        }
        //no sirve
        public static void set_objetivosEquipo(DataRow dr_objetivoEquipoP)
        {

            ((DataTable)HttpContext.Current.Session["td_objetivoEquipo"]).Rows.Add(dr_objetivoEquipoP);

        }
        //para limpiar la sesion despues de gurdar todo ... pone datatable en null
        public static void eliminarObjetivosEquipoTodos()
        {
            try
            {

                HttpContext.Current.Session["td_objetivoEquipo"] = new DataTable();


            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

        }//eliminarObjetivosTodos




        public DataTable verObjetivosMatrizEquipo(int IDEmpleado, int IDMatriz)
        {

            DataTable dt_objetivosEquipo = new DataTable();
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[3];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDempleado", SqlDbType.Int);
                parametroMySql[2] = new SqlParameter("@IDMatriz", SqlDbType.Int);


                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;
                parametroMySql[2].Direction = ParameterDirection.Input;



                parametroMySql[1].Value = IDEmpleado;
                parametroMySql[2].Value = IDMatriz;


                dt_objetivosEquipo = accesoMysql.fn_getResultado_DataTable(parametroMySql, "verObjetivosMatrizEquipo");


                return dt_objetivosEquipo;
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return dt_objetivosEquipo = new DataTable();

            } //try-catch

        }//verObjetivo

        public DataTable verObjetivosEquipo(int IDEmpleado, int IDEquipo)
        {

            DataTable dt_objetivosEquipo = new DataTable();
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[3];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDempleado", SqlDbType.Int);
                parametroMySql[2] = new SqlParameter("@IDEquipo", SqlDbType.Int);

                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;
                parametroMySql[2].Direction = ParameterDirection.Input;


                parametroMySql[1].Value = IDEmpleado;
                parametroMySql[2].Value = IDEquipo;

                dt_objetivosEquipo = accesoMysql.fn_getResultado_DataTable(parametroMySql, "verObjetivosEquipo");


                return dt_objetivosEquipo;
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return dt_objetivosEquipo = new DataTable();

            } //try-catch

        }//verObjetivo

        public DataTable verObjetivosEquipoPorPeriodo(int IDEmpleado, int IDEquipo, string fechaInicio, string fechaFinal)
        {

            DataTable dt_objetivosEquipo = new DataTable();
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[5];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDempleado", SqlDbType.Int);
                parametroMySql[2] = new SqlParameter("@IDEquipo", SqlDbType.Int);
                parametroMySql[3] = new SqlParameter("@fechaInicio", SqlDbType.Date);
                parametroMySql[4] = new SqlParameter("@fechaFinal", SqlDbType.Date);

                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;
                parametroMySql[2].Direction = ParameterDirection.Input;
                parametroMySql[3].Direction = ParameterDirection.Input;
                parametroMySql[4].Direction = ParameterDirection.Input;

                parametroMySql[1].Value = IDEmpleado;
                parametroMySql[2].Value = IDEquipo;
                parametroMySql[3].Value = fechaInicio;
                parametroMySql[4].Value = fechaFinal;

                dt_objetivosEquipo = accesoMysql.fn_getResultado_DataTable(parametroMySql, "verObjetivosEquipoPeriodo");


                return dt_objetivosEquipo;
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return dt_objetivosEquipo = new DataTable();

            } //try-catch

        }//verObjetivosEquipoPorPeriodo
      
        public int agregarObjetivoEquipo(int IDMatriz, int IDEmpleado, int tipoObj, string descripcionObj, string areaOporObj, string compromisoObj, int IDEquipo)
        {

            DataTable dt_objetivoEquipo = new DataTable();
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            int respuesta = -100;
            try
            {


                SqlParameter[] parametroMySql = new SqlParameter[12];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDmatriz", SqlDbType.Int);
                parametroMySql[2] = new SqlParameter("@descripcionObj", SqlDbType.Text);
                parametroMySql[3] = new SqlParameter("@IDtipoObjetivo", SqlDbType.Int);
                parametroMySql[4] = new SqlParameter("@fechaCompromiso", SqlDbType.VarChar);
                parametroMySql[5] = new SqlParameter("@statusObjetivo", SqlDbType.Int);
                parametroMySql[6] = new SqlParameter("@eficacia", SqlDbType.Float);
                parametroMySql[7] = new SqlParameter("@eficiencia", SqlDbType.Float);
                parametroMySql[8] = new SqlParameter("@semanaAtraso", SqlDbType.Int);
                parametroMySql[9] = new SqlParameter("@areaOportunidad", SqlDbType.Text);
                parametroMySql[10] = new SqlParameter("@IDEmpleado", SqlDbType.Int);
                parametroMySql[11] = new SqlParameter("@IDequipo", SqlDbType.Int);

                parametroMySql[0].Direction = ParameterDirection.Output;

                parametroMySql[1].Direction = ParameterDirection.Input;
                parametroMySql[2].Direction = ParameterDirection.Input;
                parametroMySql[3].Direction = ParameterDirection.Input;
                parametroMySql[4].Direction = ParameterDirection.Input;
                parametroMySql[5].Direction = ParameterDirection.Input;
                parametroMySql[6].Direction = ParameterDirection.Input;
                parametroMySql[7].Direction = ParameterDirection.Input;
                parametroMySql[8].Direction = ParameterDirection.Input;
                parametroMySql[9].Direction = ParameterDirection.Input;
                parametroMySql[10].Direction = ParameterDirection.Input;
                parametroMySql[11].Direction = ParameterDirection.Input;


                parametroMySql[1].Value = IDMatriz;
                parametroMySql[2].Value = descripcionObj;
                parametroMySql[3].Value = tipoObj;
                parametroMySql[4].Value = compromisoObj;
                parametroMySql[5].Value = 0;
                parametroMySql[6].Value = 0;
                parametroMySql[7].Value = 0;
                parametroMySql[8].Value = 0;
                parametroMySql[9].Value = areaOporObj;
                parametroMySql[10].Value = IDEmpleado;
                parametroMySql[11].Value = IDEquipo;

                accesoMysql.fn_getResultado_Command(parametroMySql, "agregarObjetivoEquipo");

                respuesta = int.Parse(parametroMySql[0].Value.ToString());



                return respuesta;
            }
            catch (Exception ex_)
            {

                cls_errores.muestraWebError(ex_);
                return -1;
            }//try-catch

        }//agregarObjetivo

        public int editarObjetivoEquipo(int IDMatriz, int IDObjetivo, string descripcionObj, string fechaCompromiso, int IDEmpleado, int IDEquipo)
        {

            DataTable dt_objetivoEquipo = new DataTable();
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            int respuesta = -100;
            try
            {


                SqlParameter[] parametroMySql = new SqlParameter[6];

                parametroMySql[0] = new SqlParameter("@IDMatriz", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDObjetivo", SqlDbType.Int);
                parametroMySql[2] = new SqlParameter("@descripcionObj", SqlDbType.Text);
                parametroMySql[3] = new SqlParameter("@fechaCompromiso", SqlDbType.VarChar);
                parametroMySql[4] = new SqlParameter("@IDEmpleado", SqlDbType.Int);
                parametroMySql[5] = new SqlParameter("@IDEquipo", SqlDbType.Int);                
                
                parametroMySql[0].Direction = ParameterDirection.Input;
                parametroMySql[1].Direction = ParameterDirection.Input;
                parametroMySql[2].Direction = ParameterDirection.Input;
                parametroMySql[3].Direction = ParameterDirection.Input;
                parametroMySql[4].Direction = ParameterDirection.Input;
                parametroMySql[5].Direction = ParameterDirection.Input;
                
                parametroMySql[0].Value = IDMatriz;
                parametroMySql[1].Value = IDObjetivo;
                parametroMySql[2].Value = descripcionObj;
                parametroMySql[3].Value = fechaCompromiso;
                parametroMySql[4].Value = IDEmpleado;
                parametroMySql[5].Value = IDEquipo;

                accesoMysql.fn_getResultado_Command(parametroMySql, "modificarObjetivoEquipo");

                return 1;
            }
            catch (Exception ex_)
            {
                return 2;
                cls_errores.muestraWebError(ex_);                
            }//try-catch

        }



        //al actualizar objetivos
        public int cerrarObjetivoEquipo(int IDObjetivo, int IDEquipo, int IDEmpleado, int estatusObj, float eficaciaObj,
                                  float eficienciaObj, int semanaAtraso, string areaOporObj, string cumplimientoObj)
        {

            DataTable dt_objetivoEquipo = new DataTable();
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            int respuesta;
            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[10];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int); //1
                parametroMySql[1] = new SqlParameter("@IDObjetivo", SqlDbType.Int); //2
                parametroMySql[2] = new SqlParameter("@statusObjetivo", SqlDbType.Int); //3
                parametroMySql[3] = new SqlParameter("@eficacia", SqlDbType.Float); //4
                parametroMySql[4] = new SqlParameter("@eficiencia", SqlDbType.Float); //5
                parametroMySql[5] = new SqlParameter("@fechaCumplimiento", SqlDbType.VarChar);//6
                parametroMySql[6] = new SqlParameter("@semanaAtraso", SqlDbType.Int); //7
                parametroMySql[7] = new SqlParameter("@areaOportunidad", SqlDbType.Text);//8
                parametroMySql[8] = new SqlParameter("@IDempleado", SqlDbType.Int);//9
                parametroMySql[9] = new SqlParameter("@IDequipo", SqlDbType.Int);//10


                parametroMySql[0].Direction = ParameterDirection.Output;

                parametroMySql[1].Direction = ParameterDirection.Input;
                parametroMySql[2].Direction = ParameterDirection.Input;
                parametroMySql[3].Direction = ParameterDirection.Input;
                parametroMySql[4].Direction = ParameterDirection.Input;
                parametroMySql[5].Direction = ParameterDirection.Input;
                parametroMySql[6].Direction = ParameterDirection.Input;
                parametroMySql[7].Direction = ParameterDirection.Input;
                parametroMySql[8].Direction = ParameterDirection.Input;
                parametroMySql[9].Direction = ParameterDirection.Input;



                parametroMySql[1].Value = IDObjetivo;
                parametroMySql[2].Value = estatusObj;
                parametroMySql[3].Value = eficaciaObj;
                parametroMySql[4].Value = eficienciaObj;
                parametroMySql[5].Value = cumplimientoObj;
                parametroMySql[6].Value = semanaAtraso;
                parametroMySql[7].Value = areaOporObj;
                parametroMySql[8].Value = IDEmpleado;
                parametroMySql[9].Value = IDEquipo;


                accesoMysql.fn_getResultado_Command(parametroMySql, "cerrarObjetivoEquipo");

                respuesta = int.Parse(parametroMySql[0].Value.ToString());



                return respuesta;
            }
            catch (Exception ex_)
            {

                cls_errores.muestraWebError(ex_);
                return -1;
            }//try-catch

        }//agregarObjetivo



        //no sirve
        public DataTable tipoObjetivoEquipo()
        {
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            DataTable ds_objetivoEquipo = new DataTable();

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[1];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);

                parametroMySql[0].Direction = ParameterDirection.Output;


                ds_objetivoEquipo = accesoMysql.fn_getResultado_DataSet(parametroMySql, "verTipoObjetivo").Tables["Table"];

                return ds_objetivoEquipo;

            }
            catch (Exception ex_)
            {

                cls_errores.muestraWebError(ex_);
                return ds_objetivoEquipo = new DataTable();

            }//try-catch


        }//tipoObjetivo

        public void combo_TipoObjetivo(Panel div_componente_P, string comboDespliega)
        {
            try
            {
                DataTable dt_item_equipo = tipoObjetivoEquipo();
                ((DropDownList)div_componente_P.FindControl(comboDespliega)).Items.Clear();
                for (int countItem = 0; countItem < dt_item_equipo.Rows.Count; countItem++)
                {
                    ListItem item_empresa = new ListItem();

                    item_empresa.Value = (dt_item_equipo.Rows[countItem]["IDObjetivo"]).ToString();
                    item_empresa.Text = (dt_item_equipo.Rows[countItem]["nomObjetivo"]).ToString();
                    ((DropDownList)div_componente_P.FindControl(comboDespliega)).Items.Add(item_empresa);
                }//for

                ((DropDownList)div_componente_P.FindControl(comboDespliega)).SelectedValue = "1";


            }
            catch (Exception ex_)
            {

                cls_errores.muestraWebError(ex_);
            }//try-catch

        }//combo_TipoObjetivo

    }//cls_objetivo
}