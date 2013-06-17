using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using betaCulturalMARKII.conexionMysql;
using System.Data.SqlClient;

namespace betaCulturalMARKII.reunion
{
    public class cls_reunion
    {
        static DataTable dt_miembrosDeJunta = new DataTable(); //empleados a de una reunion
        
        public cls_reunion() {

        }//cls_reunion


        public static void init_reunionIntegrante(){
            try{

                if (HttpContext.Current.Session["dt_miembrosDeJunta"] == null)
                {
                    dt_miembrosDeJunta = new DataTable();

                    dt_miembrosDeJunta.Columns.Add("IDempleado");//1
                    dt_miembrosDeJunta.Columns.Add("nombreEmp");//2
                    dt_miembrosDeJunta.Columns.Add("apePat");//3
                    dt_miembrosDeJunta.Columns.Add("nomArea");//4

                    HttpContext.Current.Session["dt_miembrosDeJunta"] = dt_miembrosDeJunta;
                }
                else
                {
                    dt_miembrosDeJunta = (DataTable)HttpContext.Current.Session["dt_miembrosDeJunta"];
                }//else

            }catch(Exception ex_){
                cls_errores.muestraWebError(ex_);
            }//try-catch

        }//init_reunionIntegrante

        public static void init_calendario_juntas_cerrar() { 
            
              try
            {

               

                


            }catch(Exception ex_){
                cls_errores.muestraWebError(ex_);
            }//try-catch
            
        }//init_calendario_juntas_cerrar


        public static DataTable get_miembrosDeJunta()
        {
            return (DataTable)HttpContext.Current.Session["dt_miembrosDeJunta"]; 
           
        }
        public static void set_miembrosDeJunta(DataRow dr_miembrosDeJuntaP)
        {
            ((DataTable)HttpContext.Current.Session["dt_miembrosDeJunta"]).Rows.Add(dr_miembrosDeJuntaP);      
        }


        public int agregarReunion(int IDEquipo, string fechaCompromisoReunionP, string horaCompromisoReunionP,
                                  string horario, string Lugar  , string asuntoReunionP, int IDempleadoCreadorP)
        {

                 
                 cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
                 int respuesta=-100;
                 //int juntaInsertada = -100;

            try {

                SqlParameter[] parametroMySql = new SqlParameter[9];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);      //1 
                parametroMySql[1] = new SqlParameter("@ultimaJuntaInsertada", SqlDbType.Int); //2 
                parametroMySql[2] = new SqlParameter("@IDEquipo", SqlDbType.Int); //2                 
                parametroMySql[3] = new SqlParameter("@fcompromiso", SqlDbType.VarChar);  //4
                parametroMySql[4] = new SqlParameter("@hcompromiso", SqlDbType.VarChar);  //5
                parametroMySql[5] = new SqlParameter("@d_horario", SqlDbType.VarChar);  //5
                parametroMySql[6] = new SqlParameter("@d_lugar", SqlDbType.VarChar);  //5
                parametroMySql[7] = new SqlParameter("@asunto", SqlDbType.Text);      //6
                parametroMySql[8] = new SqlParameter("@IDEmpleadoCreador", SqlDbType.Int);//7


                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Output;
                parametroMySql[2].Direction = ParameterDirection.Input;
                parametroMySql[3].Direction = ParameterDirection.Input;
                parametroMySql[4].Direction = ParameterDirection.Input;
                parametroMySql[5].Direction = ParameterDirection.Input;
                parametroMySql[6].Direction = ParameterDirection.Input;
                parametroMySql[7].Direction = ParameterDirection.Input;



                parametroMySql[2].Value = IDEquipo;                
                parametroMySql[3].Value = fechaCompromisoReunionP;
                parametroMySql[4].Value = horaCompromisoReunionP;
                parametroMySql[5].Value = horario;
                parametroMySql[6].Value = Lugar;
                parametroMySql[7].Value = asuntoReunionP;
                parametroMySql[8].Value = IDempleadoCreadorP;

                accesoMysql.fn_getResultado_Command(parametroMySql, "crearReunion");
                
                respuesta = int.Parse(parametroMySql[0].Value.ToString());

                return respuesta;

            }catch(Exception ex_){
                cls_errores.muestraWebError(ex_);
                return respuesta;
            }//try-catch

        }//agregarReunion

        public int modificarReunion(int IDReunion, int IDEquipo, string fechaCompromisoReunionP, string horaCompromisoReunionP,
                                  string horario, string Lugar, string asuntoReunionP)
        {


            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            int respuesta = -100;
            //int juntaInsertada = -100;

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[8];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);      //1 
                parametroMySql[1] = new SqlParameter("@id_reunion", SqlDbType.Int); //2 
                parametroMySql[2] = new SqlParameter("@IDEquipo", SqlDbType.Int); //2                 
                parametroMySql[3] = new SqlParameter("@fcompromiso", SqlDbType.VarChar);  //4
                parametroMySql[4] = new SqlParameter("@hcompromiso", SqlDbType.VarChar);  //5
                parametroMySql[5] = new SqlParameter("@d_horario", SqlDbType.VarChar);  //5
                parametroMySql[6] = new SqlParameter("@d_lugar", SqlDbType.VarChar);  //5
                parametroMySql[7] = new SqlParameter("@asunto", SqlDbType.Text);      //60                

                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;
                parametroMySql[2].Direction = ParameterDirection.Input;
                parametroMySql[3].Direction = ParameterDirection.Input;
                parametroMySql[4].Direction = ParameterDirection.Input;
                parametroMySql[5].Direction = ParameterDirection.Input;
                parametroMySql[6].Direction = ParameterDirection.Input;
                parametroMySql[7].Direction = ParameterDirection.Input;


                parametroMySql[1].Value = IDReunion;
                parametroMySql[2].Value = IDEquipo;
                parametroMySql[3].Value = fechaCompromisoReunionP;
                parametroMySql[4].Value = horaCompromisoReunionP;
                parametroMySql[5].Value = horario;
                parametroMySql[6].Value = Lugar;
                parametroMySql[7].Value = asuntoReunionP;

                accesoMysql.fn_getResultado_Command(parametroMySql, "modificarReunion");

                respuesta = int.Parse(parametroMySql[0].Value.ToString());

                return respuesta;

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return respuesta;
            }//try-catch

        }

        public int quitarReunion(int IDReunion)
        {


            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            int respuesta = -100;
            //int juntaInsertada = -100;

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[2];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);      //1 
                parametroMySql[1] = new SqlParameter("@id_reunion", SqlDbType.Int); //2                 

                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;                

                parametroMySql[1].Value = IDReunion;

                accesoMysql.fn_getResultado_Command(parametroMySql, "quitarReunion");

                respuesta = int.Parse(parametroMySql[0].Value.ToString());

                return respuesta;

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return respuesta;
            }//try-catch

        }

        public DataTable verReunionGral(int IDEmpleado, int IDEquipo)
        {
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            DataTable dsVerReunion = new DataTable();

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[3];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDEmpleado", SqlDbType.Int);
                parametroMySql[2] = new SqlParameter("@IDEquipo", SqlDbType.Int);

                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;
                parametroMySql[2].Direction = ParameterDirection.Input;

                parametroMySql[1].Value = IDEmpleado;
                parametroMySql[2].Value = IDEquipo;

                dsVerReunion = accesoMysql.fn_getResultado_DataTable(parametroMySql, "verReunionGral");

                return dsVerReunion;
            }
            catch (Exception ex_)
            {

                cls_errores.muestraWebError(ex_);

                return dsVerReunion = new DataTable();

            }//try-catch

            //visualizarReunionesCreadas
        }

        public int newReunion(int IDempleadoCreadorP, string asuntoReunionP,string fechaCreacionReunionP, 
                              string fechaCompromisoReunionP, string horaCompromisoReunionP)
        {
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            int respuesta = -100;
            int juntaInsertada = -100;

            try
            {
                SqlParameter[] parametroMySql = new SqlParameter[7];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);      //1 
                parametroMySql[1] = new SqlParameter("@ultimaJuntaInsertada", SqlDbType.Int); //2 
                parametroMySql[2] = new SqlParameter("@fcreacion", SqlDbType.VarChar);    //3
                parametroMySql[3] = new SqlParameter("@fcompromiso", SqlDbType.VarChar);  //4
                parametroMySql[4] = new SqlParameter("@hcompromiso", SqlDbType.VarChar);  //5
                parametroMySql[5] = new SqlParameter("@asunto", SqlDbType.Text);      //6
                parametroMySql[6] = new SqlParameter("@IDEmpleadoCreador", SqlDbType.Int);//7

                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Output;
                parametroMySql[2].Direction = ParameterDirection.Input;
                parametroMySql[3].Direction = ParameterDirection.Input;
                parametroMySql[4].Direction = ParameterDirection.Input;
                parametroMySql[5].Direction = ParameterDirection.Input;
                parametroMySql[6].Direction = ParameterDirection.Input;

                parametroMySql[2].Value = fechaCreacionReunionP;
                parametroMySql[3].Value = fechaCompromisoReunionP;
                parametroMySql[4].Value = horaCompromisoReunionP;
                parametroMySql[5].Value = asuntoReunionP;
                parametroMySql[6].Value = IDempleadoCreadorP;

                accesoMysql.fn_getResultado_Command(parametroMySql, "crearReunion");


                juntaInsertada = int.Parse(parametroMySql[1].Value.ToString());
                respuesta = int.Parse(parametroMySql[0].Value.ToString());

            }
            catch (Exception ex_)
            {

                throw new Exception(ex_.Message);                
            }
            return juntaInsertada;
        }

        public int agregarEmpeladoReunion(int IDReunion, int IDIntegrante)
        {
           
            
                 cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
                int respuesta=-100;

            try {

                SqlParameter[] parametroMySql = new SqlParameter[3];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);      //1 
                parametroMySql[1] = new SqlParameter("@IDReunion", SqlDbType.Int); //2 
                parametroMySql[2] = new SqlParameter("@IDIntegrante", SqlDbType.Int); //2

                parametroMySql[0].Direction = ParameterDirection.Output;

                parametroMySql[1].Direction = ParameterDirection.Input;
                parametroMySql[2].Direction = ParameterDirection.Input;

                parametroMySql[1].Value = IDReunion;
                parametroMySql[2].Value = IDIntegrante;
               
                accesoMysql.fn_getResultado_Command(parametroMySql, "agregarEmpleadoReunion");

               return respuesta = int.Parse(parametroMySql[0].Value.ToString());

            }catch(Exception ex_){
                cls_errores.muestraWebError(ex_);
                return respuesta;
            }//try-catch

        }//agregarEmpeladoReunion


        public int cerrarReunion(int IDReunionP,string conclucionesReunionP,string diaCierreReunion,string horaCierreReunionP,
                                   int IDEmpleadoCierraReunion) {
            
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
                
                int respuesta_store = -100;
            
            try {


                


                SqlParameter[] parametroMySql = new SqlParameter[6];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDreunion", SqlDbType.Int);
                parametroMySql[2] = new SqlParameter("@IDempleado", SqlDbType.Int);
                parametroMySql[3] = new SqlParameter("@diaCierre", SqlDbType.VarChar);
                parametroMySql[4] = new SqlParameter("@horaCierre", SqlDbType.VarChar);
                parametroMySql[5] = new SqlParameter("@conclucionesReunion", SqlDbType.Text);


                parametroMySql[0].Direction = ParameterDirection.Output;

                parametroMySql[1].Direction = ParameterDirection.Input;
                parametroMySql[2].Direction = ParameterDirection.Input;
                parametroMySql[3].Direction = ParameterDirection.Input;
                parametroMySql[4].Direction = ParameterDirection.Input;
                parametroMySql[5].Direction = ParameterDirection.Input;


                parametroMySql[1].Value=IDReunionP;
                parametroMySql[2].Value=IDEmpleadoCierraReunion;
                parametroMySql[3].Value=diaCierreReunion;
                parametroMySql[4].Value=horaCierreReunionP;
                parametroMySql[5].Value = conclucionesReunionP;


                accesoMysql.fn_getResultado_Command(parametroMySql, "cerraCalReunion");

                respuesta_store=int.Parse(parametroMySql[0].Value.ToString());

                return respuesta_store;
            }catch(Exception ex_){

                cls_errores.muestraWebError(ex_);
                return respuesta_store;
            }//try-catch



            //cerrarReunion
        }

        public DataTable visualizarReunionesCreadas(int IDEmpleado)
        {
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            DataTable ds_reunionCreadas = new DataTable();

            try{

                SqlParameter[] parametroMySql = new SqlParameter[2];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDempleadoCreador", SqlDbType.Int);

                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;

                parametroMySql[1].Value = IDEmpleado;
                ds_reunionCreadas = accesoMysql.fn_getResultado_DataTable(parametroMySql, "verReunionPorEmpleadoCreador");

               return ds_reunionCreadas;
            }catch(Exception ex_){

                cls_errores.muestraWebError(ex_);

                return ds_reunionCreadas = new DataTable();

            }//try-catch

            //visualizarReunionesCreadas
        }

        public DataTable verReunionesDia(int IDEmpleado, string Fecha)
        {
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            DataTable dt_reunionCreadas = new DataTable();

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[3];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDEmpleadoCreador", SqlDbType.Int);
                parametroMySql[2] = new SqlParameter("@IDFechaCom", SqlDbType.VarChar);

                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;
                parametroMySql[2].Direction = ParameterDirection.Input;

                parametroMySql[1].Value = IDEmpleado;
                parametroMySql[2].Value = Fecha;

                dt_reunionCreadas = accesoMysql.fn_getResultado_DataTable(parametroMySql, "verReunionPorEmpleadoCreadorporDia");
                
            }
            catch (Exception ex_)
            {

                dt_reunionCreadas = new DataTable();
                throw new Exception(ex_.Message);                
            }

            return dt_reunionCreadas;
        }

        public DataTable verDetalle_ReunionesDia(int IDreunion)
        {
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            DataTable dt_reunionCreadas = new DataTable();

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[1];

                parametroMySql[0] = new SqlParameter("@IDreunion", SqlDbType.Int);                               
                parametroMySql[0].Direction = ParameterDirection.Input;
                parametroMySql[0].Value = IDreunion;

                dt_reunionCreadas = accesoMysql.fn_getResultado_DataTable(parametroMySql, "verReunionDetalle");

            }
            catch (Exception ex_)
            {

                dt_reunionCreadas = new DataTable();
                throw new Exception(ex_.Message);
            }

            return dt_reunionCreadas;
        }
       


        public DataTable visualizarReunionesMiembro(int IDEmpleadoMiembro)
        {
            DataTable ds_reunionMiembro = new DataTable();
                cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();

            try
            {

                 SqlParameter[] parametroMySql = new SqlParameter[2];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDEmpleadoMiembro", SqlDbType.Int);

                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;

                parametroMySql[1].Value = IDEmpleadoMiembro;

                ds_reunionMiembro = accesoMysql.fn_getResultado_DataTable(parametroMySql, "verReunionPorEmpleadoMiembro");

                return ds_reunionMiembro;
            }
            catch (Exception ex_)
            {

                ex_.ToString();
                return ds_reunionMiembro = new DataTable();

            }//try-catch

            //visualizarReunion
        }



    }//cls_reunion
}//betaCultural