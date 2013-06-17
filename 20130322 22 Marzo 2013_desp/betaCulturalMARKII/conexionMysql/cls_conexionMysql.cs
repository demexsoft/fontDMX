using System;
//using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using betaCulturalMARKII;

namespace betaCulturalMARKII.conexionMysql
{
    public class cls_conexionMysql
    {

        public cls_conexionMysql() {

        }//cls_conexionMysql

        public SqlConnection getConnectionMySql()
        {
            SqlConnection Cnn = new SqlConnection();
            try
            {
                Cnn.ConnectionString = ConfigurationManager.ConnectionStrings["StrCnnCSM"].ToString();

                return Cnn;
            }
            catch(Exception ex_)
            {
                return Cnn = null;
                throw new Exception(ex_.Message);
            }
            
        }//


        public void ExecuteCommand(SqlConnection Conexion, string str_NombreSP, SqlParameter[] ParametrosSP)
        {


            SqlCommand Cmd = new SqlCommand();

            try
            {
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandTimeout = 120;
                Cmd.Connection = Conexion;
                Cmd.CommandText = str_NombreSP;

                for (int i = 0; i < ParametrosSP.Length; i++)
                {
                    Cmd.Parameters.Add(ParametrosSP[i]);

                }//for

                Cmd.Connection.Open();
                Cmd.ExecuteNonQuery();

            }
            catch (Exception ex_)
            {

                throw new Exception(ex_.Message);
            }//try-catch
            finally
            {
                Conexion.Close();

            }//finally

        }//ExecuteCommand

        protected DataSet ExecuteDataSet(SqlConnection Conexion, string str_NombreSP, SqlParameter[] ParametrosSP)
        {
            DataSet ds = new DataSet();

            SqlCommand Cmd = new SqlCommand();

            try
            {
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandTimeout = 120;
                Cmd.Connection = Conexion;
                Cmd.CommandText = str_NombreSP;

                for (int i = 0; i < ParametrosSP.Length; i++)
                {
                    Cmd.Parameters.Add(ParametrosSP[i]);

                }//for

                Cmd.Connection.Open();
                Cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(Cmd);
                da.Fill(ds);

                return ds;
            }
            catch (Exception ex_)
            {
               
                return ds = new DataSet();
                throw new Exception(ex_.Message);
            }//try-catch
            finally
            {
                Conexion.Close();

            }//finally
        }//ExecuteDataSet
        protected DataTable ExecuteDataTable(SqlConnection Conexion, string str_NombreSP, SqlParameter[] ParametrosSP)
        {
            DataTable dt = new DataTable();
            SqlCommand Cmd = new SqlCommand();

            try
            {
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandTimeout = 120;
                Cmd.Connection = Conexion;
                Cmd.CommandText = str_NombreSP;

                for (int i = 0; i < ParametrosSP.Length; i++)
                {
                    Cmd.Parameters.Add(ParametrosSP[i]);

                }//for

                Cmd.Connection.Open();
                Cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(Cmd);
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex_)
            {
                //cls_errores.muestraWebError(ex_);                 
                return dt = new DataTable();
                throw new Exception(ex_.Message);
            }//try-catch
            finally
            {
                Conexion.Close();

            }//finally
        }//ExecuteDataTable



    }//clase
}//namespace