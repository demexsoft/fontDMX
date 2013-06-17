using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using betaCulturalMARKII.conexionMysql;
using System.Data;

namespace betaCulturalMARKII.acuerdos
{
    public class cls_acuerdos
    {

        public int agregarAcuerdo( string descripcionAcuerdo, string fechaAcuerdo, int IDEmpleado)
        {

            DataTable dt_objetivoEquipo = new DataTable();
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            int respuesta = -100;
            try
            {


                SqlParameter[] parametroMySql = new SqlParameter[4];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@descripcionAcuerdo", SqlDbType.Text);
                parametroMySql[2] = new SqlParameter("@fechaAcuerdo", SqlDbType.Date);
                parametroMySql[3] = new SqlParameter("@IDEmpelado", SqlDbType.Int);
    

                parametroMySql[0].Direction = ParameterDirection.Output;

                parametroMySql[1].Direction = ParameterDirection.Input;
                parametroMySql[2].Direction = ParameterDirection.Input;
                parametroMySql[3].Direction = ParameterDirection.Input;
                


                parametroMySql[1].Value = descripcionAcuerdo;
                parametroMySql[2].Value = fechaAcuerdo;
                parametroMySql[3].Value = IDEmpleado;
     

                accesoMysql.fn_getResultado_Command(parametroMySql, "agregarAcuerdo");

                respuesta = int.Parse(parametroMySql[0].Value.ToString());



                return respuesta;
            }
            catch (Exception ex_)
            {

                cls_errores.muestraWebError(ex_);
                return -1;
            }//try-catch

        }//agregarObjetivo


        public DataTable verAcuerdos()
        {

            DataTable dt_acuerdos = new DataTable();
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[1];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);

                parametroMySql[0].Direction = ParameterDirection.Output;

                dt_acuerdos = accesoMysql.fn_getResultado_DataTable(parametroMySql, "verAcuerdos");

                return dt_acuerdos;

            }
            catch (Exception ex_)
            {
                ex_.ToString();
                return dt_acuerdos = new DataTable();
            }//try-catch

        }//verAreas












    }//cls_acuerdos
}//betaCulturalMARKII