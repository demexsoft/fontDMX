using System;
using betaCulturalMARKII.conexionMysql;
using System.Data.SqlClient;
using System.Data;
using System.Web;

namespace betaCulturalMARKII.empleado
{
    public class cls_empleado
    {


        public static string get_NombreEmpleado(){
            return (string)HttpContext.Current.Session["nombreEmpleado"];
        }
        public static void set_NombreEmpleado(string nombreP)
        {
            HttpContext.Current.Session["nombreEmpleado"] = nombreP;
        }
        public static string get_PaternoEmpleado()
        {
            return (string)HttpContext.Current.Session["paternoEmpleado"];
        }
        public static void set_PaternoEmpleado(string apePatP)
        {
            HttpContext.Current.Session["paternoEmpleado"] = apePatP;
        }

        public static string get_MaternoEmpleado()
        {
            return (string)HttpContext.Current.Session["maternoEmpleado"];
        }
        public static void set_MaternoEmpleado(string apeMatP)
        {
            HttpContext.Current.Session["maternoEmpleado"] = apeMatP;
        }
        public static string get_PuestoEmpleado()
        {
            return (string)HttpContext.Current.Session["puestoEmpleado"];
        }
        public static void set_PuestoEmpleado(string puestoP)
        {
            HttpContext.Current.Session["puestoEmpleado"] = puestoP;
        }
        public static string get_AreaEmpleado()
        {
            return (string)HttpContext.Current.Session["areaEmpleado"];
        }
        public static void set_AreaEmpleado(string areaP)
        {
            HttpContext.Current.Session["areaEmpleado"] = areaP;
        }



        public int agregarEmpleado(string nombre, string paterno,string materno , string fechaAlta, int IDpuesto, int IDempresa, int IDarea,
                                   string Usuario, string Password,string Correo, int IDperfil)
        {
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            DataTable ds_empleado = new DataTable();
            int r_store = -100;
           

            try {
                
                
                SqlParameter [] parametroMySql=new SqlParameter[12];

               parametroMySql[0]=  new SqlParameter("@r_store", SqlDbType.Int);
               parametroMySql[1] = new SqlParameter("@nombre", SqlDbType.VarChar);
               parametroMySql[2] = new SqlParameter("@apePat", SqlDbType.VarChar);
               parametroMySql[3] = new SqlParameter("@apeMat", SqlDbType.VarChar);
               parametroMySql[4] = new SqlParameter("@fechaAlta", SqlDbType.Date);
               parametroMySql[5] = new SqlParameter("@IDpuesto", SqlDbType.Int);
               parametroMySql[6] = new SqlParameter("@IDempresa", SqlDbType.Int);
               parametroMySql[7] = new SqlParameter("@IDarea", SqlDbType.Int);
               parametroMySql[8] = new SqlParameter("@login", SqlDbType.VarChar);
               parametroMySql[9] = new SqlParameter("@pwd", SqlDbType.VarChar);
               parametroMySql[10] = new SqlParameter("@Email", SqlDbType.VarChar);
               parametroMySql[11] = new SqlParameter("@IDperfil", SqlDbType.Int);

                parametroMySql[0].Direction=    ParameterDirection.Output;
                parametroMySql[1].Direction=    ParameterDirection.Input;
                parametroMySql[2].Direction =   ParameterDirection.Input;
                parametroMySql[3].Direction =   ParameterDirection.Input;
                parametroMySql[4].Direction =   ParameterDirection.Input;
                parametroMySql[5].Direction =   ParameterDirection.Input;
                parametroMySql[6].Direction =   ParameterDirection.Input;
                parametroMySql[7].Direction =   ParameterDirection.Input;
                parametroMySql[8].Direction = ParameterDirection.Input;
                parametroMySql[9].Direction = ParameterDirection.Input;
                parametroMySql[10].Direction = ParameterDirection.Input;
                parametroMySql[11].Direction = ParameterDirection.Input;



                parametroMySql[1].Value = nombre;
                parametroMySql[2].Value = paterno;
                parametroMySql[3].Value = materno;
                parametroMySql[4].Value = fechaAlta;
                parametroMySql[5].Value = IDpuesto;
                parametroMySql[6].Value = IDempresa;
                parametroMySql[7].Value = IDarea;
                parametroMySql[8].Value = Usuario;
                parametroMySql[9].Value = Password;
                parametroMySql[10].Value = Correo;
                parametroMySql[11].Value = IDperfil;

                accesoMysql.fn_getResultado_Command(parametroMySql, "agregarEmpleado");

                r_store = int.Parse(parametroMySql[0].Value.ToString());

               
                return r_store;


            }catch(Exception ex_){

                cls_errores.muestraWebError(ex_);
                return r_store;
            }


        }//agregarEmpleado

        public int modificaEmpleado(int IDEmpleado, string nombre, string paterno, string materno, string fechaAlta, int IDpuesto, int IDempresa, int IDarea,
                                    string Usuario, string Password,string Correo, int IDperfil)
        {
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            DataTable ds_empleado = new DataTable();
            int r_store = -100;


            try
            {


                SqlParameter[] parametroMySql = new SqlParameter[13];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@id_empleado", SqlDbType.Int);
                parametroMySql[2] = new SqlParameter("@nombre", SqlDbType.VarChar);
                parametroMySql[3] = new SqlParameter("@apePat", SqlDbType.VarChar);
                parametroMySql[4] = new SqlParameter("@apeMat", SqlDbType.VarChar);
                parametroMySql[5] = new SqlParameter("@fechaAlta", SqlDbType.VarChar);
                parametroMySql[6] = new SqlParameter("@IDpuesto", SqlDbType.Int);
                parametroMySql[7] = new SqlParameter("@IDempresa", SqlDbType.Int);
                parametroMySql[8] = new SqlParameter("@IDarea", SqlDbType.Int);
                parametroMySql[9] = new SqlParameter("@login", SqlDbType.VarChar);
                parametroMySql[10] = new SqlParameter("@pwd", SqlDbType.VarChar);
                parametroMySql[11] = new SqlParameter("@Email", SqlDbType.VarChar);
                parametroMySql[12] = new SqlParameter("@IDperfil", SqlDbType.Int);

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
                parametroMySql[12].Direction = ParameterDirection.Input;

                parametroMySql[1].Value = IDEmpleado;
                parametroMySql[2].Value = nombre;
                parametroMySql[3].Value = paterno;
                parametroMySql[4].Value = materno;
                parametroMySql[5].Value = fechaAlta;
                parametroMySql[6].Value = IDpuesto;
                parametroMySql[7].Value = IDempresa;
                parametroMySql[8].Value = IDarea;
                parametroMySql[9].Value = Usuario;
                parametroMySql[10].Value = Password;
                parametroMySql[11].Value = Correo;
                parametroMySql[12].Value = IDperfil;

                accesoMysql.fn_getResultado_Command(parametroMySql, "modificarEmpleado");

                r_store = int.Parse(parametroMySql[0].Value.ToString());


                return r_store;


            }
            catch (Exception ex_)
            {

                cls_errores.muestraWebError(ex_);
                return r_store;
            }


        }//agregarEmpleado

        public DataTable verTodosEmpelados(int IDempleado)
        {

            DataTable dt_empleados = new DataTable();
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();

            try {

                SqlParameter[] parametroMySql = new SqlParameter[2];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDempleado", SqlDbType.Int);

                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;


                parametroMySql[1].Value = IDempleado;

                dt_empleados = accesoMysql.fn_getResultado_DataTable(parametroMySql, "verTodosEmpelados");



                return dt_empleados;
            }catch(Exception ex_){
                ex_.ToString();
                return dt_empleados = new DataTable();
            }


        }//buscarEmpleado

        public int quitarEmpelado(int IDempleado,int IDempleadoQuitar)
        {
            int r_store = -100;
            
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[3];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDempleado", SqlDbType.Int);
                parametroMySql[2] = new SqlParameter("@IDempleadoQuitar", SqlDbType.Int);

                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;
                parametroMySql[2].Direction = ParameterDirection.Input;

                parametroMySql[1].Value = IDempleado;
                parametroMySql[2].Value = IDempleadoQuitar;


                accesoMysql.fn_getResultado_Command(parametroMySql, "quitarEmpelado");


                r_store = int.Parse(parametroMySql[0].Value.ToString());

                return r_store;  


            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return r_store;
            }


        }//quitarEmpelado

        public DataTable verTodosEmpelados_ADMIN(int IDempleado)
        {

            DataTable dt_empleados = new DataTable();
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[2];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDempleado", SqlDbType.Int);

                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;


                parametroMySql[1].Value = IDempleado;

                dt_empleados = accesoMysql.fn_getResultado_DataTable(parametroMySql, "verTodosEmpelados");



                return dt_empleados;
            }
            catch (Exception ex_)
            {
                ex_.ToString();
                return dt_empleados = new DataTable();
            }


        }//buscarEmpleado


        public int creaAccesoSistema(string usuario, string contrasenia, int IDempleado, int IDperfil)
        {
            int r_store = -100;
            
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();

            try {

                SqlParameter[] parametroMySql = new SqlParameter[5];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@usuario", SqlDbType.VarChar);
                parametroMySql[2] = new SqlParameter("@contrasenia", SqlDbType.VarChar);
                parametroMySql[3] = new SqlParameter("@IDempleado", SqlDbType.Int);
                parametroMySql[4] = new SqlParameter("@IDperfil", SqlDbType.Int);
            


                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;
                parametroMySql[2].Direction = ParameterDirection.Input;
                parametroMySql[3].Direction = ParameterDirection.Input;
                parametroMySql[4].Direction = ParameterDirection.Input;


                parametroMySql[1].Value = usuario;
                parametroMySql[2].Value = contrasenia;
                parametroMySql[3].Value = IDempleado;
                parametroMySql[4].Value = IDperfil;


                accesoMysql.fn_getResultado_Command(parametroMySql, "crearAcceso");

                r_store = int.Parse(parametroMySql[0].Value.ToString());



                return r_store;
            }catch(Exception ex_){
                cls_errores.muestraWebError(ex_);
                return r_store;

            }//try-catch
            
        

        }//creaAccesoSistema



    }//cls_empleado
}//betaCultural