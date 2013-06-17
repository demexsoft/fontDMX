using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using betaCulturalMARKII.conexionMysql;
using System.Data;
using System.Web.UI.WebControls;

namespace betaCulturalMARKII.incongruencia
{
    public class cls_incongruencia
    {

        public int agregarIncongruencia(int IDEmpleadoEvaluador, int IDEquipoEvaluador, int IDEquipoEvaluado, int IDResponsable_P, string fecha_P, int modelo_P,
                                        int principio_P, int indicador_P, int origen_P, string evento_P, string impacto_P)
        {

            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            int respuesta = -100;

            try
            {



                SqlParameter[] parametroMySql = new SqlParameter[12];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDEmpleadoEvaluador", SqlDbType.Int);

                parametroMySql[2] = new SqlParameter("@IDEquipoEvaluador", SqlDbType.Int);
                parametroMySql[3] = new SqlParameter("@IDEquipoEvaluado", SqlDbType.Int);

                parametroMySql[4] = new SqlParameter("@IDResponsable", SqlDbType.Int);
                parametroMySql[5] = new SqlParameter("@fecha", SqlDbType.VarChar);
                parametroMySql[6] = new SqlParameter("@modelo", SqlDbType.Int);
                parametroMySql[7] = new SqlParameter("@principio", SqlDbType.Int);
                parametroMySql[8] = new SqlParameter("@indicador", SqlDbType.Int);
                parametroMySql[9] = new SqlParameter("@origen", SqlDbType.Int);
                parametroMySql[10] = new SqlParameter("@evento", SqlDbType.Text);
                parametroMySql[11] = new SqlParameter("@impacto", SqlDbType.Text);


                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;
                parametroMySql[2].Direction = ParameterDirection.Input;
                parametroMySql[3].Direction = ParameterDirection.Input;
                parametroMySql[4].Direction = ParameterDirection.Input;
                parametroMySql[5].Direction = ParameterDirection.Input;
                parametroMySql[6].Direction = ParameterDirection.Input;
                parametroMySql[7].Direction = ParameterDirection.Input;
                parametroMySql[8].Direction = ParameterDirection.Input;
                parametroMySql[9].Direction = ParameterDirection.Input;
                parametroMySql[10].Direction = ParameterDirection.Input;
                parametroMySql[11].Direction = ParameterDirection.Input;


                parametroMySql[1].Value = IDEmpleadoEvaluador;
                parametroMySql[2].Value = IDEquipoEvaluador;
                parametroMySql[3].Value = IDEquipoEvaluado;
                parametroMySql[4].Value = IDResponsable_P;
                parametroMySql[5].Value = fecha_P;
                parametroMySql[6].Value = modelo_P;
                parametroMySql[7].Value = principio_P;
                parametroMySql[8].Value = indicador_P;
                parametroMySql[9].Value = origen_P;
                parametroMySql[10].Value = evento_P;
                parametroMySql[11].Value = impacto_P;

                accesoMysql.fn_getResultado_Command(parametroMySql, "agregarIncidencia");

                respuesta = int.Parse(parametroMySql[0].Value.ToString());


                return respuesta;
            }
            catch (Exception ex_)
            {

                cls_errores.muestraWebError(ex_);
                return respuesta;
            }//try-catch
        }//agregarIncongruencia

        public DataTable verIncongruencias(string strFechaInicial, string strFechaFinal, int IDEquipoEvaluado, int IDprincipio, int IDcausa, int IDModelo)
        {
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            DataTable dt_evaluacion = new DataTable();

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[6];

                parametroMySql[0] = new SqlParameter("@FechaInicial", SqlDbType.VarChar);
                parametroMySql[1] = new SqlParameter("@FechaFinal", SqlDbType.VarChar);
                parametroMySql[2] = new SqlParameter("@IDequipoEvaluado", SqlDbType.Int);
                parametroMySql[3] = new SqlParameter("@id_principio", SqlDbType.Int);
                parametroMySql[4] = new SqlParameter("@id_causa", SqlDbType.Int);
                parametroMySql[5] = new SqlParameter("@id_modelo", SqlDbType.Int);

                parametroMySql[0].Direction = ParameterDirection.Input;
                parametroMySql[1].Direction = ParameterDirection.Input;
                parametroMySql[2].Direction = ParameterDirection.Input;
                parametroMySql[3].Direction = ParameterDirection.Input;
                parametroMySql[4].Direction = ParameterDirection.Input;
                parametroMySql[5].Direction = ParameterDirection.Input;

                parametroMySql[0].Value = strFechaInicial;
                parametroMySql[1].Value = strFechaFinal;
                parametroMySql[2].Value = IDEquipoEvaluado;
                parametroMySql[3].Value = IDprincipio;
                parametroMySql[4].Value = IDcausa;
                parametroMySql[5].Value = IDModelo;

                dt_evaluacion = accesoMysql.fn_getResultado_DataTable(parametroMySql, "verBitacora");

                return dt_evaluacion;
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return dt_evaluacion = new DataTable();
            }//try-catch
        }//verIncongruencias

        public DataTable verOrigenProblema(int IDempleado_P)
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


                dt_origenProblema = accesoMysql.fn_getResultado_DataTable(parametroMySql, "seleccionarOrigenProblema");



                return dt_origenProblema;

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return dt_origenProblema = new DataTable();
            }//try-catch
        }//verOrigen

        public DataTable verModelo(int IDempleado_P)
        {

            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            DataTable dt_Modelo = new DataTable();
            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[2];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDempleado", SqlDbType.Int);

                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;

                parametroMySql[1].Value = IDempleado_P;


                dt_Modelo = accesoMysql.fn_getResultado_DataTable(parametroMySql, "seleccionarModelo");



                return dt_Modelo;

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return dt_Modelo = new DataTable();
            }//try-catch
        }//verModelo

        public DataTable verConocimiento()
        {

            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            DataTable dt_Conocimiento = new DataTable();
            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[0];


                dt_Conocimiento = accesoMysql.fn_getResultado_DataTable(parametroMySql, "verConocimiento");



                return dt_Conocimiento;

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return dt_Conocimiento = new DataTable();
            }//try-catch
        }//verConocimiento
       
        public DataTable verEvaluar()
        {

            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            DataTable dt_Evaluar = new DataTable();
            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[0];


                dt_Evaluar = accesoMysql.fn_getResultado_DataTable(parametroMySql, "verEvalClienteCat");



                return dt_Evaluar;

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return dt_Evaluar = new DataTable();
            }//try-catch
        }//verEvaluar

        public DataTable verPrincipios() 
        {
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            DataTable dt_principios = new DataTable();
            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[0];                             
                dt_principios = accesoMysql.fn_getResultado_DataTable(parametroMySql, "verPrincipios");

            }
            catch (Exception ex)
            {
                dt_principios = new DataTable();
                throw new Exception(ex.Message);
            }

            return dt_principios;
        }

        public DataTable verIndicadores(int IDPrincipio) 
        {
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            DataTable dt_Indicadores = new DataTable();
            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[1];

                parametroMySql[0] = new SqlParameter("@IDPrincipio", SqlDbType.Int);                
                parametroMySql[0].Direction = ParameterDirection.Input;               
                parametroMySql[0].Value = IDPrincipio;

                dt_Indicadores = accesoMysql.fn_getResultado_DataTable(parametroMySql, "verIndicadores");

            }
            catch (Exception ex)
            {
                dt_Indicadores = new DataTable();
                throw new Exception(ex.Message);
            }

            return dt_Indicadores;
        }

        public void LlenaCombo_verOrigenProblema(DataTable dt_Name, DropDownList ddl_Name, bool RenglonBlanco)
        {
            ddl_Name.Items.Clear();
            if (dt_Name.Rows.Count > 0)
            {
                ListItem Lista;

                if (RenglonBlanco)
                {
                    Lista = new ListItem();
                    Lista.Text = string.Empty;
                    Lista.Value = "0";

                    ddl_Name.Items.Add(Lista);
                }

                for (int i = 0; i < dt_Name.Rows.Count; i++)
                {
                    Lista = new ListItem();
                    Lista.Text = dt_Name.Rows[i]["DesProblema"].ToString();
                    Lista.Value = dt_Name.Rows[i]["IDProblema"].ToString();

                    ddl_Name.Items.Add(Lista);
                }
            }
            else
            {
                ListItem Lista = new ListItem();
                Lista.Text = " -- SIN DATOS -- ";
                Lista.Value = string.Empty; ;
                ddl_Name.Items.Add(Lista);
            }
        }

        public void LlenaCombo_verModelo(DataTable dt_Name, DropDownList ddl_Name, bool RenglonBlanco)
        {
            try
            {
                ddl_Name.Items.Clear();
                if (dt_Name.Rows.Count > 0)
                {
                    ListItem Lista;

                    if (RenglonBlanco)
                    {
                        Lista = new ListItem();
                        Lista.Text = string.Empty;
                        Lista.Value = "0";

                        ddl_Name.Items.Add(Lista);
                    }

                    for (int i = 0; i < dt_Name.Rows.Count; i++)
                    {
                        Lista = new ListItem();
                        Lista.Text = dt_Name.Rows[i]["DesMod"].ToString();
                        Lista.Value = dt_Name.Rows[i]["IDMod"].ToString();

                        ddl_Name.Items.Add(Lista);
                    }
                }
                else
                {
                    ListItem Lista = new ListItem();
                    Lista.Text = " -- Empty Data -- ";
                    Lista.Value = string.Empty; ;
                    ddl_Name.Items.Add(Lista);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void LlenaCombo_verPrincipios(DataTable dt_Name, DropDownList ddl_Name, bool RenglonBlanco)
        {
            try
            {
                ddl_Name.Items.Clear();
                if (dt_Name.Rows.Count > 0)
                {
                    ListItem Lista;

                    if (RenglonBlanco)
                    {
                        Lista = new ListItem();
                        Lista.Text = string.Empty;
                        Lista.Value = "0";

                        ddl_Name.Items.Add(Lista);
                    }

                    for (int i = 0; i < dt_Name.Rows.Count; i++)
                    {
                        Lista = new ListItem();
                        Lista.Text = dt_Name.Rows[i]["d_nombre"].ToString();
                        Lista.Value = dt_Name.Rows[i]["id_principio"].ToString();

                        ddl_Name.Items.Add(Lista);
                    }
                }
                else
                {
                    ListItem Lista = new ListItem();
                    Lista.Text = " -- Empty Data -- ";
                    Lista.Value = string.Empty; ;
                    ddl_Name.Items.Add(Lista);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void LlenaCombo_verIndicadores(DataTable dt_Name, DropDownList ddl_Name)
        {
            try
            {
                ddl_Name.Items.Clear();
                if (dt_Name.Rows.Count > 0)
                {
                    ListItem Lista;

                    for (int i = 0; i < dt_Name.Rows.Count; i++)
                    {
                        Lista = new ListItem();
                        Lista.Text = dt_Name.Rows[i]["d_descripcionIndicador"].ToString();
                        Lista.Value = dt_Name.Rows[i]["id_indicador"].ToString();

                        ddl_Name.Items.Add(Lista);
                    }
                }
                else
                {
                    ListItem Lista = new ListItem();
                    Lista.Text = " --Empty Data-- ";
                    Lista.Value = string.Empty; ;
                    ddl_Name.Items.Add(Lista);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void LlenaCombo_verConocimiento(DataTable dt_Name, DropDownList ddl_Name)
        {
            try
            {
                ddl_Name.Items.Clear();
                if (dt_Name.Rows.Count > 0)
                {
                    ListItem Lista;

                    for (int i = 0; i < dt_Name.Rows.Count; i++)
                    {
                        Lista = new ListItem();
                        Lista.Text = dt_Name.Rows[i]["id_conocimiento"].ToString();
                        Lista.Value = dt_Name.Rows[i]["id_conocimiento"].ToString();

                        ddl_Name.Items.Add(Lista);
                    }
                }
                else
                {
                    ListItem Lista = new ListItem();
                    Lista.Text = " -- Empty Data -- ";
                    Lista.Value = string.Empty; ;
                    ddl_Name.Items.Add(Lista);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void LlenaCombo_verEvaluar(DataTable dt_Name, DropDownList ddl_Name, bool RenglonBlanco)
        {
            try
            {
                ddl_Name.Items.Clear();
                if (dt_Name.Rows.Count > 0)
                {
                    ListItem Lista;

                    if (RenglonBlanco)
                    {
                        Lista = new ListItem();
                        Lista.Text = string.Empty;
                        Lista.Value = "0";

                        ddl_Name.Items.Add(Lista);
                    }

                    for (int i = 0; i < dt_Name.Rows.Count; i++)
                    {
                        Lista = new ListItem();
                        Lista.Text = dt_Name.Rows[i]["d_evalcliente"].ToString();
                        Lista.Value = dt_Name.Rows[i]["id_evalcliente"].ToString();

                        ddl_Name.Items.Add(Lista);
                    }
                }
                else
                {
                    ListItem Lista = new ListItem();
                    Lista.Text = " -- Empty Data -- ";
                    Lista.Value = string.Empty; ;
                    ddl_Name.Items.Add(Lista);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void LlenaCombo_verAreas(DataTable dt_Name, DropDownList ddl_Name, bool RenglonBlanco)
        {
            try
            {
                ddl_Name.Items.Clear();
                if (dt_Name.Rows.Count > 0)
                {
                    ListItem Lista;

                    if (RenglonBlanco)
                    {
                        Lista = new ListItem();
                        Lista.Text = string.Empty;
                        Lista.Value = "0";

                        ddl_Name.Items.Add(Lista);
                    }

                    for (int i = 0; i < dt_Name.Rows.Count; i++)
                    {
                        Lista = new ListItem();
                        Lista.Text = dt_Name.Rows[i]["nomArea"].ToString();
                        Lista.Value = dt_Name.Rows[i]["IDarea"].ToString();

                        ddl_Name.Items.Add(Lista);
                    }
                }
                else
                {
                    ListItem Lista = new ListItem();
                    Lista.Text = " -- Empty Data -- ";
                    Lista.Value = string.Empty; ;
                    ddl_Name.Items.Add(Lista);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }







    }//cls_incongruencia
}