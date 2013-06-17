using System;
using System.Data;
using System.Data.SqlClient;
//using System.Data.SqlClient;
using betaCulturalMARKII;

namespace betaCulturalMARKII.conexionMysql
{
    public class cls_acceso_dataMySql : cls_conexionMysql
    {
        public cls_acceso_dataMySql() { 
            //contructor
        
        }//cls_acceso_dataMySql

        public DataSet fn_getResultado_DataSet(SqlParameter[] parametrosP, string str_storedProcedureP)
        {
            DataSet ds = new DataSet();
            SqlConnection cnn = getConnectionMySql();

            try
            {
                ds = ExecuteDataSet(cnn, str_storedProcedureP, parametrosP);

            }//try
            catch (Exception ex_)
            {
                ds = new DataSet();
                ex_.ToString();

            }//catch

            return ds;

        }//fn_getResultado_DataSet


       
        public DataTable fn_getResultado_DataTable(SqlParameter[] parametrosP, string str_storedProcedureP)
        {

            DataTable dt = new DataTable();
            SqlConnection cnn = getConnectionMySql();

            try
            {

                dt = ExecuteDataTable(cnn, str_storedProcedureP, parametrosP);


            }//try
            catch (Exception ex_)
            {
                dt = new DataTable();
                ex_.ToString();

            }//catch

            return dt;

        }//fn_getResultado_DataTable

        public void fn_getResultado_Command(SqlParameter[] parametrosP, string str_storedProcedureP)
        {

            SqlConnection cnn = getConnectionMySql();

            try
            {

                ExecuteCommand(cnn, str_storedProcedureP, parametrosP);


            }//try
            catch (Exception ex_)
            {
            
                
                cls_errores.muestraWebError(ex_);
            }//catch

            

        }//fn_getResultado_Command

    }//clase


}//namespace