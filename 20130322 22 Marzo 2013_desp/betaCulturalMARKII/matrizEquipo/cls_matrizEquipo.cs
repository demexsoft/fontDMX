using System;
using System.Web;
using System.Data.SqlClient;
using betaCulturalMARKII.conexionMysql;
using System.Data;

namespace betaCulturalMARKII.matrizEquipo
{
    public class cls_matrizEquipo
    {
        //guarda en la sesiòn el ultimo ID de la matriz de equipo
        public static void set_ultimoMatrizEquipo_(int ultimoMatrizEquipo_P)
        {

            HttpContext.Current.Session["ultimoMatrizEquipo_"] = ultimoMatrizEquipo_P;
        }

	//recupera la sesion y la retorna en un  int
        public static int get_ultimoMatrizEquipo_()
        {
            try
            {
                return (int)HttpContext.Current.Session["ultimoMatrizEquipo_"];
            }
            catch (Exception)
            {

                return -1;
            }            
        }

        public int crearMatrizEquipo(int IDempleado, int IDEquipoMatriz, string fechaCreacion,
            string fechaInicio, string fechaFinal)
        {
            int respuesta = -100;
            int ultimo_ID_matrizEquipo = -100;

            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[9];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@ultimoInsertado", SqlDbType.Int);

                parametroMySql[2] = new SqlParameter("@IDempleadoCreador", SqlDbType.Int);
                parametroMySql[3] = new SqlParameter("@IDEquipoMatriz", SqlDbType.Int);
                parametroMySql[4] = new SqlParameter("@fCreacion", SqlDbType.VarChar);
                parametroMySql[5] = new SqlParameter("@fInicio", SqlDbType.VarChar);
                parametroMySql[6] = new SqlParameter("@fTermino", SqlDbType.VarChar);
                parametroMySql[7] = new SqlParameter("@eficacia", SqlDbType.Float);
                parametroMySql[8] = new SqlParameter("@eficiencia", SqlDbType.Float);
                
                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Output;

                parametroMySql[2].Direction = ParameterDirection.Input;
                parametroMySql[3].Direction = ParameterDirection.Input;
                parametroMySql[4].Direction = ParameterDirection.Input;
                parametroMySql[5].Direction = ParameterDirection.Input;
                parametroMySql[6].Direction = ParameterDirection.Input;
                parametroMySql[7].Direction = ParameterDirection.Input;
                parametroMySql[8].Direction = ParameterDirection.Input;

                parametroMySql[2].Value = IDempleado;
                parametroMySql[3].Value = IDEquipoMatriz;
                parametroMySql[4].Value = fechaCreacion;
                parametroMySql[5].Value = fechaInicio;
                parametroMySql[6].Value = fechaFinal;
                parametroMySql[7].Value = 0;
                parametroMySql[8].Value = 0;            
                
                accesoMysql.fn_getResultado_Command(parametroMySql, "crearMatrizEquipo");

                respuesta = int.Parse(parametroMySql[0].Value.ToString());
                ultimo_ID_matrizEquipo = int.Parse(parametroMySql[1].Value.ToString());

                set_ultimoMatrizEquipo_(ultimo_ID_matrizEquipo);

                
                return respuesta;
            }
            catch (Exception ex_)
            {

                cls_errores.muestraWebError(ex_);
                return respuesta;
            }//try-catch

            //crearMatrizEquipo
        }

        public void modificaMatrizEquipo(int IDMatriz, int IDEquipoMatriz, string fechaInicio, string fechaFinal)
        {                     
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[4];

                parametroMySql[0] = new SqlParameter("@IDmatriz", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDEquipo", SqlDbType.Int);
                parametroMySql[2] = new SqlParameter("@fInicio", SqlDbType.VarChar);
                parametroMySql[3] = new SqlParameter("@fTermino", SqlDbType.VarChar);
                

                parametroMySql[0].Direction = ParameterDirection.Input;
                parametroMySql[1].Direction = ParameterDirection.Input;
                parametroMySql[2].Direction = ParameterDirection.Input;
                parametroMySql[3].Direction = ParameterDirection.Input;

                parametroMySql[0].Value = IDMatriz;
                parametroMySql[1].Value = IDEquipoMatriz;
                parametroMySql[2].Value = fechaInicio;
                parametroMySql[3].Value = fechaFinal;

                accesoMysql.fn_getResultado_Command(parametroMySql, "modificarMatrizEquipo");                
                
            }
            catch (Exception ex_)
            {

                cls_errores.muestraWebError(ex_);                
            }//try-catch

            //crearMatrizEquipo
        }

        public DataTable verTodasMatrizEquipo(int IDEmpleado,int IDEquipo,int mes, int anio)
        {
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            DataTable dt_matriz_equipo = new DataTable();

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[5];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDEmpleado", SqlDbType.Int);
                parametroMySql[2] = new SqlParameter("@IDEquipo", SqlDbType.Int);
                parametroMySql[3] = new SqlParameter("@mes", SqlDbType.Int);
                parametroMySql[4] = new SqlParameter("@anio", SqlDbType.Int);

                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;
                parametroMySql[2].Direction = ParameterDirection.Input;
                parametroMySql[3].Direction = ParameterDirection.Input;
                parametroMySql[4].Direction = ParameterDirection.Input;

                parametroMySql[1].Value = IDEmpleado;
                parametroMySql[2].Value = IDEquipo;
                parametroMySql[3].Value = mes;
                parametroMySql[4].Value = anio;

                dt_matriz_equipo = accesoMysql.fn_getResultado_DataTable(parametroMySql, "verTodasMatrizEquipo");

                return dt_matriz_equipo;
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return dt_matriz_equipo = new DataTable();
            }//try-catch
        }//verTodasMatrizEquipo

        public DataTable verMatrizEquipoPeriodo(int IDEmpleado, int IDEquipo, string fechaInicio, string fechaFinal)
        {
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            DataTable dt_matriz_equipo = new DataTable();

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[5];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDEmpleado", SqlDbType.Int);
                parametroMySql[2] = new SqlParameter("@IDEquipo", SqlDbType.Int);
                parametroMySql[3] = new SqlParameter("@fechaInicio", SqlDbType.VarChar);
                parametroMySql[4] = new SqlParameter("@fechaFinal", SqlDbType.VarChar);

                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;
                parametroMySql[2].Direction = ParameterDirection.Input;
                parametroMySql[3].Direction = ParameterDirection.Input;
                parametroMySql[4].Direction = ParameterDirection.Input;

                parametroMySql[1].Value = IDEmpleado;
                parametroMySql[2].Value = IDEquipo;
                parametroMySql[3].Value = fechaInicio;
                parametroMySql[4].Value = fechaFinal;

                dt_matriz_equipo = accesoMysql.fn_getResultado_DataTable(parametroMySql, "verTodasMatrizEquipoporPeriodo");

                return dt_matriz_equipo;
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return dt_matriz_equipo = new DataTable();
            }//try-catch
        }//verTodasMatrizEquipo

        public DataTable verMatrizEquipoVigente(int IDEmpleado, int IDEquipo)
        {
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            DataTable dt_matriz_equipo = new DataTable();

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[3];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDEmpleado", SqlDbType.Int);
                parametroMySql[2] = new SqlParameter("@IDEquipo", SqlDbType.Int);

                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;
                parametroMySql[2].Direction = ParameterDirection.Input;

                parametroMySql[1].Value = IDEmpleado;
                parametroMySql[2].Value = IDEquipo;

                dt_matriz_equipo = accesoMysql.fn_getResultado_DataTable(parametroMySql, "verMatrizEquipoVigente");

                return dt_matriz_equipo;
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return dt_matriz_equipo = new DataTable();
            }//try-catch
        }//verTodasMatrizEquipo   

        public DataTable verMatrizEquipo(int IDmatriz)
        {
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            DataTable dt_matriz_equipo = new DataTable();

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[2];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDmatriz", SqlDbType.Int);

                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;

                parametroMySql[1].Value = IDmatriz;

                dt_matriz_equipo = accesoMysql.fn_getResultado_DataTable(parametroMySql, "verMatrizEquipoXID");

                return dt_matriz_equipo;
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return dt_matriz_equipo = new DataTable();
            }//try-catch
        }

        public DataTable verEquipoIntegrantes(int IDEquipo)
        {
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            DataTable dt_Integrantes_Equipo = new DataTable();

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[2];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDEquipo", SqlDbType.Int);

                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;

                parametroMySql[1].Value = IDEquipo;

                dt_Integrantes_Equipo = accesoMysql.fn_getResultado_DataTable(parametroMySql, "verEquipoIntegrantes");

                return dt_Integrantes_Equipo;
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return dt_Integrantes_Equipo = new DataTable();
            }//try-catch
        }

        public DataTable verMailIntregrantesMatriz(int IDMatriz)
        {

            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            DataTable dt_DatosEquipo = new DataTable();

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[1];

                parametroMySql[0] = new SqlParameter("@IDMatriz", SqlDbType.Int);
                parametroMySql[0].Direction = ParameterDirection.Input;
                parametroMySql[0].Value = IDMatriz;


                dt_DatosEquipo = accesoMysql.fn_getResultado_DataTable(parametroMySql, "verEmpleadosDeMatrizEquipo");

                return dt_DatosEquipo;

            }
            catch (Exception ex_)
            {

                cls_errores.muestraWebError(ex_);
                return dt_DatosEquipo = new DataTable();

            }//try-catch        
        }

        //public cls_matrizEquipo() 
        //{

        //}

        //public int crearMatrizEuipo(int IDempleado, int IDempleadoRevisor, int IDequipoMatriz, string fechaCreacion,
        //                                 string fechaInicio, string fechaFinal)
        //{
        //    int r_store = -100;
        //    int ultimo_ID_matriz = -100;
        //    cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();

        //    try
        //    {
        //        SqlParameter[] parametroMySql = new SqlParameter[9];
        //        /*
        //         OUT r_store INT,OUT ultimoInsertado INT,IN IDempleadoCreador varchar(200),IN IDEquipoMatriz INT, 
        //         * IN  fCreacion DATE,IN  fInicio DATE, IN  fTermino DATE, eficacia FLOAT , eficiencia  FLOAT
        //         */
        //        parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
        //        parametroMySql[1] = new SqlParameter("@ultimoInsertado", SqlDbType.Int);
        //        parametroMySql[2] = new SqlParameter("@IDempleadoCreador", SqlDbType.Int);
        //        parametroMySql[3] = new SqlParameter("@IDEquipoMatriz", SqlDbType.Int);
        //        parametroMySql[4] = new SqlParameter("@fCreacion", SqlDbType.VarChar);
        //        parametroMySql[5] = new SqlParameter("@eficacia", SqlDbType.Float);
        //        parametroMySql[6] = new SqlParameter("@eficiencia", SqlDbType.Float);
        //        parametroMySql[7] = new SqlParameter("@fInicio", SqlDbType.Date);
        //        parametroMySql[8] = new SqlParameter("@fTermino", SqlDbType.Date);

        //        parametroMySql[0].Direction = ParameterDirection.Output;
        //        parametroMySql[1].Direction = ParameterDirection.Output;

        //        parametroMySql[2].Direction = ParameterDirection.Input;
        //        parametroMySql[3].Direction = ParameterDirection.Input;
        //        parametroMySql[4].Direction = ParameterDirection.Input;
        //        parametroMySql[5].Direction = ParameterDirection.Input;
        //        parametroMySql[6].Direction = ParameterDirection.Input;
        //        parametroMySql[7].Direction = ParameterDirection.Input;
        //        parametroMySql[8].Direction = ParameterDirection.Input;


        //        parametroMySql[2].Value = IDempleado;
        //        parametroMySql[3].Value = IDempleadoRevisor;
        //        parametroMySql[4].Value = fechaCreacion;
        //        parametroMySql[5].Value = 0;
        //        parametroMySql[6].Value = 0;
        //        parametroMySql[7].Value = fechaInicio;
        //        parametroMySql[8].Value = fechaFinal;

        //        accesoMysql.fn_getResultado_Command(parametroMySql, "crearMatrizEquipo");


        //        r_store = int.Parse(parametroMySql[0].Value.ToString());
        //        ultimo_ID_matriz = int.Parse(parametroMySql[1].Value.ToString());

        //        //set_ultimoMatriz_(ultimo_ID_matriz);

        //        return r_store;

        //    }
        //    catch (Exception ex_)
        //    {

        //        cls_errores.muestraWebError(ex_);
        //        return r_store;
        //    }//try-catch

        //    //crearMatrizindividual
        //}

        //public DataTable verTodasMatrizEquipoVigente(int IDEmpleado, int IDEquipo)
        //{

        //    cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
        //    DataTable dt_matriz = new DataTable();

        //    try
        //    {

        //        SqlParameter[] parametroMySql = new SqlParameter[3];

        //        parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
        //        parametroMySql[1] = new SqlParameter("@IDEmpleado", SqlDbType.Int);
        //        parametroMySql[2] = new SqlParameter("@IDEquipo", SqlDbType.Int);

        //        parametroMySql[0].Direction = ParameterDirection.Output;
        //        parametroMySql[1].Direction = ParameterDirection.Input;
        //        parametroMySql[2].Direction = ParameterDirection.Input;

        //        parametroMySql[1].Value = IDEmpleado;
        //        parametroMySql[2].Value = IDEquipo;

        //        dt_matriz = accesoMysql.fn_getResultado_DataTable(parametroMySql, "verMatrizEquipoVigente");

        //        return dt_matriz;
        //    }
        //    catch (Exception ex_)
        //    {
        //        cls_errores.muestraWebError(ex_);
        //        return dt_matriz = new DataTable();
        //    }
        //}

        //public DataTable verObjetivosEmpleado(int IDEmpleado, int IDMatriz)
        //{

        //    DataTable dt_objetivos = new DataTable();
        //    cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            
        //    try
        //    {

        //        SqlParameter[] parametroMySql = new SqlParameter[3];

        //        parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
        //        parametroMySql[1] = new SqlParameter("@IDempleado", SqlDbType.Int);
        //        parametroMySql[2] = new SqlParameter("@IDMatriz", SqlDbType.Int);
        //        //parametroMySql[3] = new SqlParameter("@IDtipoObjetivo", SqlDbType.Int);

        //        parametroMySql[0].Direction = ParameterDirection.Output;
        //        parametroMySql[1].Direction = ParameterDirection.Input;
        //        parametroMySql[2].Direction = ParameterDirection.Input;
        //        //parametroMySql[3].Direction = ParameterDirection.Input;


        //        parametroMySql[1].Value = IDEmpleado;
        //        parametroMySql[2].Value = IDMatriz;
        //        //parametroMySql[3].Value = IDtipoObjetivo;

        //        dt_objetivos = accesoMysql.fn_getResultado_DataTable(parametroMySql, "verObjetivosMatrizEquipo");


        //        return dt_objetivos;
        //    }
        //    catch (Exception ex_)
        //    {
        //        cls_errores.muestraWebError(ex_);
        //        return dt_objetivos = new DataTable();

        //    } //try-catch

        //}//verObjetivo

        //public int agregarObjetivoEquipo(int IDMatriz, int IDEmpleado, int tipoObj, int statusObjetivo, decimal eficacia, 
        //                                 decimal eficiencia, int semanasAtraso, string descripcionObj, string areaOporObj, 
        //                                 string compromisoObj, int IDEquipo)
        //{            
        //    DataTable dt_objetivo = new DataTable();
        //    cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
        //    int respuesta = -100;
        //    try
        //    {
        //        SqlParameter[] parametroMySql = new SqlParameter[12];

        //        parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
        //        parametroMySql[1] = new SqlParameter("@IDmatriz", SqlDbType.Int);
        //        parametroMySql[2] = new SqlParameter("@descripcionObj", SqlDbType.Text);
        //        parametroMySql[3] = new SqlParameter("@IDtipoObjetivo", SqlDbType.Int);
        //        parametroMySql[4] = new SqlParameter("@fechaCompromiso", SqlDbType.Date);
        //        parametroMySql[5] = new SqlParameter("@statusObjetivo", SqlDbType.Int);
        //        parametroMySql[6] = new SqlParameter("@eficacia", SqlDbType.Decimal);
        //        parametroMySql[7] = new SqlParameter("@eficiencia", SqlDbType.Decimal);
        //        parametroMySql[8] = new SqlParameter("@semanaAtraso", SqlDbType.Int);
        //        parametroMySql[9] = new SqlParameter("@areaOportunidad", SqlDbType.Text);
        //        parametroMySql[10] = new SqlParameter("@IDEmpleado", SqlDbType.Int);
        //        parametroMySql[11] = new SqlParameter("@IDequipo", SqlDbType.Int);

        //        parametroMySql[0].Direction = ParameterDirection.Output;

        //        parametroMySql[1].Direction = ParameterDirection.Input;
        //        parametroMySql[2].Direction = ParameterDirection.Input;
        //        parametroMySql[3].Direction = ParameterDirection.Input;
        //        parametroMySql[4].Direction = ParameterDirection.Input;
        //        parametroMySql[5].Direction = ParameterDirection.Input;
        //        parametroMySql[6].Direction = ParameterDirection.Input;
        //        parametroMySql[7].Direction = ParameterDirection.Input;
        //        parametroMySql[8].Direction = ParameterDirection.Input;
        //        parametroMySql[9].Direction = ParameterDirection.Input;
        //        parametroMySql[10].Direction = ParameterDirection.Input;
        //        parametroMySql[11].Direction = ParameterDirection.Input;


        //        parametroMySql[1].Value = IDMatriz;
        //        parametroMySql[2].Value = descripcionObj;
        //        parametroMySql[3].Value = tipoObj;
        //        parametroMySql[4].Value = compromisoObj;
        //        parametroMySql[5].Value = statusObjetivo;
        //        parametroMySql[6].Value = eficacia;
        //        parametroMySql[7].Value = eficiencia;
        //        parametroMySql[8].Value = semanasAtraso;
        //        parametroMySql[9].Value = areaOporObj;
        //        parametroMySql[10].Value = IDEmpleado;
        //        parametroMySql[11].Value = IDEquipo;

        //        accesoMysql.fn_getResultado_Command(parametroMySql, "agregarObjetivoEquipo");

        //        respuesta = int.Parse(parametroMySql[0].Value.ToString());



        //        return respuesta;
        //    }
        //    catch (Exception ex_)
        //    {
        //        cls_errores.muestraWebError(ex_);
        //        return -1;
        //    }
        //}

        //public int cerrarObjetivoEquipo(int IDObjetivo, int IDEquipo, int IDEmpleado, int estatusObj, decimal eficaciaObj,
        //                          decimal eficienciaObj, int semanaAtraso, string areaOporObj, string cumplimientoObj)
        //{

        //    DataTable dt_objetivo = new DataTable();
        //    cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
        //    int respuesta;
        //    try
        //    {

        //        SqlParameter[] parametroMySql = new SqlParameter[10];
                
        //        parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int); //1
        //        parametroMySql[1] = new SqlParameter("@IDObjetivo", SqlDbType.Int); //2
        //        parametroMySql[2] = new SqlParameter("@statusObjetivo", SqlDbType.Int); //3
        //        parametroMySql[3] = new SqlParameter("@eficacia", SqlDbType.Float); //4
        //        parametroMySql[4] = new SqlParameter("@eficiencia", SqlDbType.Float); //5
        //        parametroMySql[5] = new SqlParameter("@fechaCumplimiento", SqlDbType.Date);//6
        //        parametroMySql[6] = new SqlParameter("@semanaAtraso", SqlDbType.Int); //7
        //        parametroMySql[7] = new SqlParameter("@areaOportunidad", SqlDbType.Text);//8
        //        parametroMySql[8] = new SqlParameter("@IDempleado", SqlDbType.Int);//9
        //        parametroMySql[9] = new SqlParameter("@IDequipo", SqlDbType.Int);//10

        //        parametroMySql[0].Direction = ParameterDirection.Output;

        //        parametroMySql[1].Direction = ParameterDirection.Input;
        //        parametroMySql[2].Direction = ParameterDirection.Input;
        //        parametroMySql[3].Direction = ParameterDirection.Input;
        //        parametroMySql[4].Direction = ParameterDirection.Input;
        //        parametroMySql[5].Direction = ParameterDirection.Input;
        //        parametroMySql[6].Direction = ParameterDirection.Input;
        //        parametroMySql[7].Direction = ParameterDirection.Input;
        //        parametroMySql[8].Direction = ParameterDirection.Input;
        //        parametroMySql[9].Direction = ParameterDirection.Input;

        //        parametroMySql[1].Value = IDObjetivo;
        //        parametroMySql[2].Value = estatusObj;
        //        parametroMySql[3].Value = eficaciaObj;
        //        parametroMySql[4].Value = eficienciaObj;
        //        parametroMySql[5].Value = cumplimientoObj;
        //        parametroMySql[6].Value = semanaAtraso;
        //        parametroMySql[7].Value = areaOporObj;
        //        parametroMySql[8].Value = IDEmpleado;
        //        parametroMySql[9].Value = IDEquipo;

        //        accesoMysql.fn_getResultado_Command(parametroMySql, "cerrarObjetivoEquipo");
        //        respuesta = int.Parse(parametroMySql[0].Value.ToString());

        //        return respuesta;
        //    }
        //    catch (Exception ex_)
        //    {
        //        cls_errores.muestraWebError(ex_);
        //        return -1;
        //    }
        //}
    }
}