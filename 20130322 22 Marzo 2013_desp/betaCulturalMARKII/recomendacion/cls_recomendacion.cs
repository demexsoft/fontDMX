using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using betaCulturalMARKII.conexionMysql;
using System.Data;

namespace betaCulturalMARKII.recomendacion
{
    public class cls_recomendacion
    {



        public int agregarRecomendacion(int IDIntegrante_p, int IDResponsable_p, string fecha_p,
                                        string situacion_p, string causa_p, string solucion_p)
        {

            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            
            int respuesta = -100;

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[7];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDIntegrante", SqlDbType.Int);
                parametroMySql[2] = new SqlParameter("@IDResponsable", SqlDbType.Int);
                parametroMySql[3] = new SqlParameter("@fecha", SqlDbType.VarChar);
                parametroMySql[4] = new SqlParameter("@situacion", SqlDbType.VarChar);
                parametroMySql[5] = new SqlParameter("@causa", SqlDbType.VarChar);
                parametroMySql[6] = new SqlParameter("@solucion", SqlDbType.VarChar);


                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;
                parametroMySql[2].Direction = ParameterDirection.Input;
                parametroMySql[3].Direction = ParameterDirection.Input;
                parametroMySql[4].Direction = ParameterDirection.Input;
                parametroMySql[5].Direction = ParameterDirection.Input;
                parametroMySql[6].Direction = ParameterDirection.Input;


                parametroMySql[1].Value = IDIntegrante_p;
                parametroMySql[2].Value = IDResponsable_p;
                parametroMySql[3].Value = fecha_p;
                parametroMySql[4].Value = situacion_p;
                parametroMySql[5].Value = causa_p;
                parametroMySql[6].Value = solucion_p;

                accesoMysql.fn_getResultado_Command(parametroMySql, "agregarRecomendacion");


                respuesta = int.Parse(parametroMySql[0].Value.ToString());


                return respuesta;
            }
            catch (Exception ex_)
            {

                cls_errores.muestraWebError(ex_);
                return respuesta;
            }//try-catch
        }//agregarEvaluacion

    }//class
}//namespace