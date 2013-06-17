using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using betaCulturalMARKII.conexionMysql;

namespace betaCulturalMARKII.puesto
{
    public class cls_puesto
    {

        public int agregarPuesto(int IDempleado, string nombrePuesto, string desPuesto, int IDempresa)
        {

            int r_store = -100;

            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();


            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[4];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDempleado", SqlDbType.Int);
                parametroMySql[2] = new SqlParameter("@nombrePuesto", SqlDbType.VarChar);
                parametroMySql[3] = new SqlParameter("@desPuesto", SqlDbType.VarChar);
                parametroMySql[4] = new SqlParameter("@IDempresa", SqlDbType.Int);


                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;
                parametroMySql[2].Direction = ParameterDirection.Input;
                parametroMySql[3].Direction = ParameterDirection.Input;
                parametroMySql[4].Direction = ParameterDirection.Input;

                parametroMySql[1].Value = IDempleado;
                parametroMySql[2].Value = nombrePuesto;
                parametroMySql[3].Value = desPuesto;
                parametroMySql[4].Value = IDempresa;


                accesoMysql.fn_getResultado_Command(parametroMySql, "agregarPuesto");

                r_store = int.Parse(parametroMySql[0].Value.ToString());

                return r_store;
            }
            catch (Exception ex_)
            {
                ex_.ToString();

            }//try-catch
            return r_store;
        }//agregarPuesto

        public DataTable verPuestos(int IDEmpleado)
        {

            DataTable dt_puesto = new DataTable();
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[2];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDempleado", SqlDbType.Int);

                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;

                parametroMySql[1].Value = IDEmpleado;

                dt_puesto = accesoMysql.fn_getResultado_DataSet(parametroMySql, "verPuestos").Tables["Table"];

                return dt_puesto;

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);

                return dt_puesto = new DataTable();
            }//try-catch

        }//verPuestos

    }
}