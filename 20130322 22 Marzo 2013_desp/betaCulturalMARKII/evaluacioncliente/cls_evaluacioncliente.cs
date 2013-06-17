using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using betaCulturalMARKII.conexionMysql;

namespace betaCulturalMARKII.evaluacioncliente
{
    public class cls_evaluacioncliente
    {
        public int agregarEvaluacionCliente(int IDEmpleado, int IDEquipoEvaluador, int IDEquipoEvaluado, string fecha,
                                           string Descripcion, int IDEval, int IDcausa, int IDConocimiento)
        {

            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            int respuesta = -100;

            try
            {



                SqlParameter[] parametroMySql = new SqlParameter[9];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDEmpleado", SqlDbType.Int);
                parametroMySql[2] = new SqlParameter("@fecha", SqlDbType.VarChar);
                parametroMySql[3] = new SqlParameter("@IDEquipoEvaluado", SqlDbType.Int);
                parametroMySql[4] = new SqlParameter("@IDEquipoEvaluador", SqlDbType.Int);
                parametroMySql[5] = new SqlParameter("@descripcion", SqlDbType.Text);
                parametroMySql[6] = new SqlParameter("@id_evalcliente", SqlDbType.Int);
                parametroMySql[7] = new SqlParameter("@IDECausa", SqlDbType.Int);
                parametroMySql[8] = new SqlParameter("@id_conocimiento", SqlDbType.Int);
                


                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;
                parametroMySql[2].Direction = ParameterDirection.Input;
                parametroMySql[3].Direction = ParameterDirection.Input;
                parametroMySql[4].Direction = ParameterDirection.Input;
                parametroMySql[5].Direction = ParameterDirection.Input;
                parametroMySql[6].Direction = ParameterDirection.Input;
                parametroMySql[7].Direction = ParameterDirection.Input;
                parametroMySql[8].Direction = ParameterDirection.Input;



                parametroMySql[1].Value = IDEmpleado;
                parametroMySql[2].Value = fecha;
                parametroMySql[3].Value = IDEquipoEvaluado;
                parametroMySql[4].Value = IDEquipoEvaluador;
                parametroMySql[5].Value = Descripcion;
                parametroMySql[6].Value = IDEval;
                parametroMySql[7].Value = IDcausa;
                parametroMySql[8].Value = IDConocimiento;


                accesoMysql.fn_getResultado_Command(parametroMySql, "agregarEvaluacion");

                respuesta = int.Parse(parametroMySql[0].Value.ToString());


                return respuesta;
            }
            catch (Exception ex_)
            {

                cls_errores.muestraWebError(ex_);
                return respuesta;
            }//try-catch
        }//agregarEvaluacionCliente

        public DataTable verEvaluacion(string strFechaInicial, string strFechaFinal, int IDEquipoEvaluado, int IDevalcliente, int IDcausa, int IDconocimiento)
        {
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            DataTable dt_evaluacion = new DataTable();

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[6];

                parametroMySql[0] = new SqlParameter("@FechaInicial", SqlDbType.VarChar);
                parametroMySql[1] = new SqlParameter("@FechaFinal", SqlDbType.VarChar);
                parametroMySql[2] = new SqlParameter("@IDequipoEvaluado", SqlDbType.Int);
                parametroMySql[3] = new SqlParameter("@id_evalcliente", SqlDbType.Int);
                parametroMySql[4] = new SqlParameter("@id_causa", SqlDbType.Int);
                parametroMySql[5] = new SqlParameter("@id_conocimiento", SqlDbType.Int);

                parametroMySql[0].Direction = ParameterDirection.Input;
                parametroMySql[1].Direction = ParameterDirection.Input;
                parametroMySql[2].Direction = ParameterDirection.Input;
                parametroMySql[3].Direction = ParameterDirection.Input;
                parametroMySql[4].Direction = ParameterDirection.Input;
                parametroMySql[5].Direction = ParameterDirection.Input;

                parametroMySql[0].Value = strFechaInicial;
                parametroMySql[1].Value = strFechaFinal;
                parametroMySql[2].Value = IDEquipoEvaluado;
                parametroMySql[3].Value = IDevalcliente;
                parametroMySql[4].Value = IDcausa;
                parametroMySql[5].Value = IDconocimiento;

                dt_evaluacion = accesoMysql.fn_getResultado_DataTable(parametroMySql, "verEvaluacionCliente");

                return dt_evaluacion;
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return dt_evaluacion = new DataTable();
            }//try-catch
        }//verEvaluacion
    }
}