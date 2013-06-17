using System;
using betaCulturalMARKII.conexionMysql;
using System.Data;
using System.Data.SqlClient;
//using System.Data.SqlClient;

namespace betaCulturalMARKII.graficas
{
    public class cls_grafica : cls_conexionMysql
    {
       
        public DataTable gr_DataTable(SqlParameter[] parametrosP, string str_storedProcedureP){
            
            DataTable dt = new DataTable();
            SqlConnection cnn = getConnectionMySql();

            try {
                
                dt = ExecuteDataTable(cnn, str_storedProcedureP, parametrosP);

            }catch(Exception ex_){
                cls_errores.muestraWebError(ex_);
                 dt = new DataTable();
                
            }//try-catch
             return dt;

            //objetGrafica_DataTableivos
        }

        public DataTable ver_datos_Grafica_objetivos(int IDEmpleado, int IDequipo, string tipoGrafica, string fechaInicio, string fechaFin)
        {
            DataTable dt_objetivos = new DataTable();
            cls_grafica accesoMysql = new cls_grafica();

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[6];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);

                parametroMySql[1] = new SqlParameter("@IDempleado", SqlDbType.Int);
                parametroMySql[2] = new SqlParameter("@IDequipo", SqlDbType.Int);
                parametroMySql[3] = new SqlParameter("@tipoGrafica", SqlDbType.VarChar);
                parametroMySql[4] = new SqlParameter("@fechaIni", SqlDbType.VarChar);
                parametroMySql[5] = new SqlParameter("@fechaFin", SqlDbType.VarChar);



                parametroMySql[0].Direction = ParameterDirection.Output;

                parametroMySql[1].Direction = ParameterDirection.Input;
                parametroMySql[2].Direction = ParameterDirection.Input;
                parametroMySql[3].Direction = ParameterDirection.Input;
                parametroMySql[4].Direction = ParameterDirection.Input;
                parametroMySql[5].Direction = ParameterDirection.Input;


                parametroMySql[1].Value = IDEmpleado;
                parametroMySql[2].Value = IDequipo;
                parametroMySql[3].Value = tipoGrafica;
                parametroMySql[4].Value = fechaInicio;
                parametroMySql[5].Value = fechaFin;

                dt_objetivos = accesoMysql.gr_DataTable(parametroMySql, "graficaObjetivo");

                return dt_objetivos;
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return dt_objetivos = new DataTable();

            } //try-catch

            //Grafica_objetivos
        }


        public DataTable graficaOrigenProblema(int IDempleado_P)
        {

            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            DataTable dt_origenProblema = new DataTable();
            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[2];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDempleado", SqlDbType.Int);

                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;

                parametroMySql[1].Value = IDempleado_P;


                dt_origenProblema = accesoMysql.fn_getResultado_DataTable(parametroMySql, "graficaOrigenProblema");



                return dt_origenProblema;

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return dt_origenProblema = new DataTable();
            }//try-catch
        }//graficaOrigenProblema

        public DataTable graficaIndicadores(int IDempleado_P)
        {

            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            DataTable dt_origenIncadores = new DataTable();
            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[2];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDempleado", SqlDbType.Int);

                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;

                parametroMySql[1].Value = IDempleado_P;


                dt_origenIncadores = accesoMysql.fn_getResultado_DataTable(parametroMySql, "graficaPrincipiosMiEquipo");



                return dt_origenIncadores;

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return dt_origenIncadores = new DataTable();
            }//try-catch
        }//graficaOrigenProblema




        public DataTable graficaObejtivosEquipo(int IDempleado_P, int IDequipo_P, string rangoInicio_P, string rangoFin_P)
        {
            

            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            DataTable dt_objetivosEquipo = new DataTable();
            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[5];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDempleado", SqlDbType.Int);
                parametroMySql[2] = new SqlParameter("@IDequipo", SqlDbType.Int);
                parametroMySql[3] = new SqlParameter("@rangoInicio", SqlDbType.VarChar);
                parametroMySql[4] = new SqlParameter("@rangoFin", SqlDbType.VarChar);
                

                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;
                parametroMySql[2].Direction = ParameterDirection.Input;
                parametroMySql[3].Direction = ParameterDirection.Input;
                parametroMySql[4].Direction = ParameterDirection.Input;

                parametroMySql[1].Value = IDempleado_P;
                parametroMySql[2].Value = IDequipo_P;
                parametroMySql[3].Value = rangoInicio_P;
                parametroMySql[4].Value = rangoFin_P;


                dt_objetivosEquipo = accesoMysql.fn_getResultado_DataTable(parametroMySql, "graficaObjetivosEquipo");



                return dt_objetivosEquipo;

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return dt_objetivosEquipo = new DataTable();
            }//try-catch
        }//graficaObejtivosEquipo


        public DataTable graficaEfiEfiArea(int IDempleado_P)
        {


            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            DataTable dt_efiArea = new DataTable();
            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[2];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDempleado", SqlDbType.Int);
            


                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;
                

                parametroMySql[1].Value = IDempleado_P;



                dt_efiArea = accesoMysql.fn_getResultado_DataTable(parametroMySql, "graficaEficienciaEficaciaArea");



                return dt_efiArea;

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return dt_efiArea = new DataTable();
            }//try-catch
        }//graficaObejtivosEquipo

        public DataTable ver_graficaEfectividad(int IDArea, int IDequipo, string FechaReferencia, int TipoGrafica)
        {
            DataTable dt_objetivos = new DataTable();
            cls_grafica accesoMysql = new cls_grafica();

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[4];
                
                parametroMySql[0] = new SqlParameter("@IDArea", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDEquipo", SqlDbType.Int);
                parametroMySql[2] = new SqlParameter("@FechaReferencia", SqlDbType.VarChar);
                parametroMySql[3] = new SqlParameter("@GlobalOmes", SqlDbType.Int);                                          
                
                parametroMySql[0].Value = IDArea;
                parametroMySql[1].Value = IDequipo;
                parametroMySql[2].Value = FechaReferencia;
                parametroMySql[3].Value = TipoGrafica;                

                dt_objetivos = accesoMysql.gr_DataTable(parametroMySql, "graficaEfectividad");

                return dt_objetivos;
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return dt_objetivos = new DataTable();

            }            
        }

        public DataTable ver_graficaOrigenes(int IDArea, int IDequipo, string FechaReferencia, int TipoGrafica)
        {
            DataTable dt_objetivos = new DataTable();
            cls_grafica accesoMysql = new cls_grafica();

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[4];

                parametroMySql[0] = new SqlParameter("@IDArea", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDEquipo", SqlDbType.Int);
                parametroMySql[2] = new SqlParameter("@FechaReferencia", SqlDbType.VarChar);
                parametroMySql[3] = new SqlParameter("@GlobalOmes", SqlDbType.Int);                                          

                parametroMySql[0].Value = IDArea;
                parametroMySql[1].Value = IDequipo;
                parametroMySql[2].Value = FechaReferencia;
                parametroMySql[3].Value = TipoGrafica;                

                dt_objetivos = accesoMysql.gr_DataTable(parametroMySql, "graficaOrigenes");

                return dt_objetivos;
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return dt_objetivos = new DataTable();

            }
        }

        public DataTable ver_graficaIncidentes(int IDArea, int IDequipo, string FechaReferencia, int TipoGrafica)
        {
            DataTable dt_objetivos = new DataTable();
            cls_grafica accesoMysql = new cls_grafica();

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[4];

                parametroMySql[0] = new SqlParameter("@IDArea", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDEquipo", SqlDbType.Int);
                parametroMySql[2] = new SqlParameter("@FechaReferencia", SqlDbType.VarChar);
                parametroMySql[3] = new SqlParameter("@GlobalOmes", SqlDbType.Int);

                parametroMySql[0].Value = IDArea;
                parametroMySql[1].Value = IDequipo;
                parametroMySql[2].Value = FechaReferencia;
                parametroMySql[3].Value = TipoGrafica;

                dt_objetivos = accesoMysql.gr_DataTable(parametroMySql, "graficaIncidentes");

                return dt_objetivos;
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return dt_objetivos = new DataTable();

            }
        }

        public DataTable ver_graficaComparativaEfec(int IDArea, int IDequipo, string FechaReferencia, int IndicadorAgraficar)
        {
            DataTable dt_objetivos = new DataTable();
            cls_grafica accesoMysql = new cls_grafica();

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[4];

                parametroMySql[0] = new SqlParameter("@IDArea", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDEquipo", SqlDbType.Int);
                parametroMySql[2] = new SqlParameter("@FechaReferencia", SqlDbType.VarChar);
                parametroMySql[3] = new SqlParameter("@IndicadorAgraficar", SqlDbType.Int);

                parametroMySql[0].Value = IDArea;
                parametroMySql[1].Value = IDequipo;
                parametroMySql[2].Value = FechaReferencia;
                parametroMySql[3].Value = IndicadorAgraficar;

                dt_objetivos = accesoMysql.gr_DataTable(parametroMySql, "graficaComparativaEfec");

                return dt_objetivos;
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return dt_objetivos = new DataTable();

            }
        }

        public DataTable ver_graficaObjsAlcanzados(int IDArea, int IDequipo, string FechaReferencia)
        {
            DataTable dt_objetivos = new DataTable();
            cls_grafica accesoMysql = new cls_grafica();

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[3];

                parametroMySql[0] = new SqlParameter("@IDArea", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDEquipo", SqlDbType.Int);
                parametroMySql[2] = new SqlParameter("@FechaReferencia", SqlDbType.VarChar);

                parametroMySql[0].Value = IDArea;
                parametroMySql[1].Value = IDequipo;
                parametroMySql[2].Value = FechaReferencia;

                dt_objetivos = accesoMysql.gr_DataTable(parametroMySql, "graficaObjsAlcanzados");

                return dt_objetivos;
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return dt_objetivos = new DataTable();

            }
        }

        public DataTable ver_graficaEfectividadHistorica(int IDArea, int IDequipo, string FechaReferencia)
        {
            DataTable dt_objetivos = new DataTable();
            cls_grafica accesoMysql = new cls_grafica();

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[3];

                parametroMySql[0] = new SqlParameter("@IDArea", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDEquipo", SqlDbType.Int);
                parametroMySql[2] = new SqlParameter("@FechaReferencia", SqlDbType.VarChar);

                parametroMySql[0].Value = IDArea;
                parametroMySql[1].Value = IDequipo;
                parametroMySql[2].Value = FechaReferencia;

                dt_objetivos = accesoMysql.gr_DataTable(parametroMySql, "graficaEfectividadHistorica");

                return dt_objetivos;
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return dt_objetivos = new DataTable();

            }
        }

        public DataTable ver_graficaGetTarget(int nYear)
        {
            DataTable dt_objetivos = new DataTable();
            cls_grafica accesoMysql = new cls_grafica();

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[1];
                parametroMySql[0] = new SqlParameter("@nYear", SqlDbType.Int);
                parametroMySql[0].Value = nYear;

                dt_objetivos = accesoMysql.gr_DataTable(parametroMySql, "graficaGetTarget");

                return dt_objetivos;
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return dt_objetivos = new DataTable();

            }
        }



    }//cls_grafica



}//betaCultural