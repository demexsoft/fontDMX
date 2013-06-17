using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using betaCulturalMARKII.conexionMysql;
using System.Data.SqlClient;

namespace betaCulturalMARKII.perfil
{
    public class cls_perfil
    {

        public DataTable verPerfilesAplicacion(int IDempleado)
        {

            DataTable dt_perfiles = new DataTable();
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[1];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                
                parametroMySql[0].Direction = ParameterDirection.Output;

                dt_perfiles = accesoMysql.fn_getResultado_DataTable(parametroMySql, "verPerfiles");

                return dt_perfiles;
            }
            catch (Exception ex_)
            {
                ex_.ToString();
                return dt_perfiles = new DataTable();
            }

        }//perfilesAplicacion


    
    }//perfil

}//betaCulturalMARKII