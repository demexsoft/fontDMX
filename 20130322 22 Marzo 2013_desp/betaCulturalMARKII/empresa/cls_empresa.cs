using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using betaCulturalMARKII.conexionMysql;
using System.Data.SqlClient;

namespace betaCulturalMARKII.empresa
{
    public class cls_empresa
    {
        public int agregarEmpresa(string nombreEmpresaP, string razonSocialP, string descripcionP)
        {

            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();

            int r_store = -100;

            try
            {


                SqlParameter[] parametroMySql = new SqlParameter[4];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@nombreEmpresaP", SqlDbType.VarChar);
                parametroMySql[2] = new SqlParameter("@razonSocialP", SqlDbType.VarChar);
                parametroMySql[3] = new SqlParameter("@descripcionP", SqlDbType.VarChar);

                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;
                parametroMySql[2].Direction = ParameterDirection.Input;
                parametroMySql[3].Direction = ParameterDirection.Input;

                accesoMysql.fn_getResultado_Command(parametroMySql, "agregarEmpresa");


                r_store = int.Parse(parametroMySql[0].Value.ToString());

                return r_store;

            }
            catch (Exception ex_)
            {
                ex_.ToString();

                return r_store;
            }//try-catch
        }//agregarEmpresa



        public DataTable verTodasEmpresas(int IDEmpleado)
        {

            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            DataTable ds_empresa = new DataTable();

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[2];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDEmpleado", SqlDbType.Int);


                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;

                parametroMySql[1].Value = IDEmpleado;


                ds_empresa = accesoMysql.fn_getResultado_DataSet(parametroMySql, "verEmpresas").Tables["Table"];


                return ds_empresa;
            }
            catch (Exception ex_)
            {

                ex_.ToString();
                return ds_empresa = new DataTable();
            }//try-catch
        }//verTodasEmpresas

    }



}