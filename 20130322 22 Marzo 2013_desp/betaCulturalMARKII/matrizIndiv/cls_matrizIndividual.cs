using System;
using System.Web;
using System.Data.SqlClient;
using betaCulturalMARKII.conexionMysql;
using System.Data;

namespace betaCulturalMARKII.matrizIndiv
{
    public class cls_matrizIndividual
    {
        public cls_matrizIndividual()
        {
            try 
            { 
            
            }
            catch(Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }

        }//cls_matrizIndividual

        public static void set_ultimoMatriz_(int ultimoMatriz_P){

            HttpContext.Current.Session["ultimoMatriz_"] = ultimoMatriz_P;
        }
        public static int get_ultimoMatriz_()
        {
            try
            {
                return (int)HttpContext.Current.Session["ultimoMatriz_"];
            }
            catch (Exception)
            {

                return -1;
            }            
        }


        public int crearMatrizindividual(int IDempleado, int IDempleadoRevisor, int IDequipoMatriz, string fechaCreacion,
                                         string fechaInicio ,string fechaFinal  )
        {
            int r_store = -100;
            int ultimo_ID_matriz=-100;
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();

            try 
            {
                SqlParameter[] parametroMySql = new SqlParameter[9];

                parametroMySql[0] = new SqlParameter("@r_store",              SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@ultimoInsertado",      SqlDbType.Int);
                parametroMySql[2] = new SqlParameter("@IDempleadoCreador",    SqlDbType.Int);
                parametroMySql[3] = new SqlParameter("@IDempleadoRevisor",    SqlDbType.Int);
                parametroMySql[4] = new SqlParameter("@fechaCreacion",        SqlDbType.VarChar);
                parametroMySql[5] = new SqlParameter("@promedioEficacia",     SqlDbType.Float);
                parametroMySql[6] = new SqlParameter("@promedioEficiencia",   SqlDbType.Float);
                parametroMySql[7] = new SqlParameter("@f_incio",              SqlDbType.VarChar);
                parametroMySql[8] = new SqlParameter("@f_final",              SqlDbType.VarChar);

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
                parametroMySql[3].Value = IDempleadoRevisor;
                parametroMySql[4].Value = fechaCreacion;
                parametroMySql[5].Value = 0;
                parametroMySql[6].Value = 0;
                parametroMySql[7].Value = fechaInicio;
                parametroMySql[8].Value = fechaFinal;

                accesoMysql.fn_getResultado_Command(parametroMySql, "crearMatrizIndividual");


                r_store          = int.Parse(parametroMySql[0].Value.ToString());
                ultimo_ID_matriz = int.Parse(parametroMySql[1].Value.ToString());

                set_ultimoMatriz_(ultimo_ID_matriz);

                return r_store;
  
            }catch(Exception ex_){
                
                cls_errores.muestraWebError(ex_);
                return r_store;
            }//try-catch

        //crearMatrizindividual
        }

        public int modificaMatrizindividual(int IDmatriz, string fInicio, string fTermino)
        {
            int r_store = -100;            
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();

            try
            {
                SqlParameter[] parametroMySql = new SqlParameter[4];

                parametroMySql[0] = new SqlParameter("@IDmatriz", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@fInicio", SqlDbType.VarChar);
                parametroMySql[2] = new SqlParameter("@fTermino", SqlDbType.VarChar);
                parametroMySql[3] = new SqlParameter("@Resp", SqlDbType.Int);

                parametroMySql[0].Value = IDmatriz;
                parametroMySql[1].Value = fInicio;
                parametroMySql[2].Value = fTermino;
                parametroMySql[3].Direction = ParameterDirection.ReturnValue;


                accesoMysql.fn_getResultado_Command(parametroMySql, "modificarMatrizInd");
                r_store = int.Parse(parametroMySql[3].Value.ToString());
                

                return r_store;

            }
            catch (Exception ex_)
            {

                cls_errores.muestraWebError(ex_);
                return r_store;
            }//try-catch

            //crearMatrizindividual
        }

        public DataTable verTodasMatrizIndividual(int IDEmpleado,int mes, int anio)
        {

            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            DataTable dt_matriz = new DataTable();

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[4];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDEmpleado", SqlDbType.Int);
                parametroMySql[2] = new SqlParameter("@mes", SqlDbType.Int);
                parametroMySql[3] = new SqlParameter("@anio", SqlDbType.Int);

                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;
                parametroMySql[2].Direction = ParameterDirection.Input;
                parametroMySql[3].Direction = ParameterDirection.Input;

                parametroMySql[1].Value = IDEmpleado;
                parametroMySql[2].Value = mes;
                parametroMySql[3].Value = anio;

                dt_matriz = accesoMysql.fn_getResultado_DataTable(parametroMySql, "verTodasMatrizIndividual");

                return dt_matriz;
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return dt_matriz = new DataTable();
            }//try-catch
        }//verTodasMatrizIndividual

        public DataTable verTodasMatrizIndividualPeriodo(int IDEmpleado, string fechaInicio, string fechaFinal)
        {

            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            DataTable dt_matriz = new DataTable();

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[4];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDEmpleado", SqlDbType.Int);
                parametroMySql[2] = new SqlParameter("@fechaInicio", SqlDbType.VarChar);
                parametroMySql[3] = new SqlParameter("@fechaFinal", SqlDbType.VarChar);
               

                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;
                parametroMySql[2].Direction = ParameterDirection.Input;
                parametroMySql[3].Direction = ParameterDirection.Input;

                parametroMySql[1].Value = IDEmpleado;
                parametroMySql[2].Value = fechaInicio;
                parametroMySql[3].Value = fechaFinal;

                dt_matriz = accesoMysql.fn_getResultado_DataTable(parametroMySql, "verTodasMatrizIndividualporPeriodo");

                return dt_matriz;
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return dt_matriz = new DataTable();
            }//try-catch
        }//verTodasMatrizIndividual
        

        public DataTable verTodasMatrizIndividualVigente(int IDEmpleado)
        {

            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            DataTable dt_matriz = new DataTable();

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[2];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDEmpleado", SqlDbType.Int);
                

                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;
              

                parametroMySql[1].Value = IDEmpleado;
              

                dt_matriz = accesoMysql.fn_getResultado_DataTable(parametroMySql, "verMatrizIndividualVigente");

                return dt_matriz;
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return dt_matriz = new DataTable();
            }//try-catch
        }//verTodasMatrizIndividual

        public DataTable verMatrizIndividual(int IDmatriz,int IDEmpleado) 
        {
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            DataTable dt_matriz = new DataTable();

            try
            {
                SqlParameter[] parametroMySql = new SqlParameter[3];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDmatriz", SqlDbType.Int);
                parametroMySql[2] = new SqlParameter("@IDEmpleado", SqlDbType.Int);


                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;
                parametroMySql[2].Direction = ParameterDirection.Input;

                parametroMySql[1].Value = IDmatriz;
                parametroMySql[2].Value = IDEmpleado;


                dt_matriz = accesoMysql.fn_getResultado_DataTable(parametroMySql, "verMatrizIndividualXID");

                return dt_matriz;
            }
            catch (Exception ex_)
            {

                cls_errores.muestraWebError(ex_);
                return dt_matriz = new DataTable();
            }
        }

    }
}