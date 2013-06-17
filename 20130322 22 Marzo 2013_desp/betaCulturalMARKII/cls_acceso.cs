using System;
using betaCulturalMARKII.conexionMysql;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using betaCulturalMARKII.empleado;


namespace betaCulturalMARKII
{
    public class cls_acceso
    {
        public cls_acceso(){
         //contructo

        }//cls_acceso

        //Crear las variables para el uso en todo el sitio
     

        //Datos de ID empleado
        public static int get_ID()
        {
            return (int)HttpContext.Current.Session["IDusuario"];
        }
        public static void set_ID(int IDusuarioP)
        {
            HttpContext.Current.Session["IDusuario"] = IDusuarioP;
        }

        public static void set_Perfil(int IDPerfilP)
        {
            HttpContext.Current.Session["IDPerfil"] = IDPerfilP;
        }


        //Datos de usuario
        public static void set_Usuario(string usuarioP)
        {
            HttpContext.Current.Session["usuario"] = usuarioP;
        }

        public static string get_Usuario()
        {
            return (string)HttpContext.Current.Session["usuario"];
        }
        //Datos de password de usuario
        public static void set_Pass(string passP)
        {
            HttpContext.Current.Session["pass"] = passP;
        }

        public static string get_Pass()
        {
            return (string)HttpContext.Current.Session["pass"];
        }

        public static int get_Perfil()
        {
            return (int)HttpContext.Current.Session["IDPerfil"];
        }


        public void agregarAcceso(){

            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
                
            
            try {

                


            }catch(Exception ex_){
                ex_.ToString();
            
            }//try-cath

        }//agregarAcceso

//proporciona acceso a la aplicacion "LOGGIN"

        public void accesoAPP(string  usuP, string passP)
        {
          
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            DataTable dt_datosAcceso = new DataTable();

            try
            {


                SqlParameter[] parametroMySql = new SqlParameter[3];

                parametroMySql[0] = new SqlParameter("@r_store",  SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@usuario",  SqlDbType.VarChar);
                parametroMySql[2] = new SqlParameter("@pass",     SqlDbType.VarChar);

                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;
                parametroMySql[2].Direction = ParameterDirection.Input;



                parametroMySql[1].Value = usuP;
                parametroMySql[2].Value = passP;




                dt_datosAcceso = accesoMysql.fn_getResultado_DataTable(parametroMySql, "seleccionarUsuario");

                if (dt_datosAcceso.Rows.Count == 0) {


                }
                else if (dt_datosAcceso.Rows.Count == 1)
                {

                    cls_acceso.set_Usuario(dt_datosAcceso.Rows[0]["usuario"].ToString());
                    cls_acceso.set_Pass(dt_datosAcceso.Rows[0]["pass"].ToString());
                    cls_acceso.set_ID(int.Parse(dt_datosAcceso.Rows[0]["numempleado"].ToString()));
                    cls_acceso.set_Perfil(int.Parse(dt_datosAcceso.Rows[0]["id_perfil"].ToString()));
                    
                    cls_empleado.set_NombreEmpleado(    dt_datosAcceso.Rows[0]["nombre"].ToString());
                    cls_empleado.set_PaternoEmpleado(   dt_datosAcceso.Rows[0]["paterno"].ToString());
                    cls_empleado.set_MaternoEmpleado(   dt_datosAcceso.Rows[0]["materno"].ToString());
                    cls_empleado.set_PuestoEmpleado(    dt_datosAcceso.Rows[0]["puesto"].ToString());
                    cls_empleado.set_AreaEmpleado(      dt_datosAcceso.Rows[0]["area"].ToString());
                    

                    if(dt_datosAcceso.Rows.Count>0){

                    

                     System.Web.HttpContext.Current.Response.Redirect("principalControl.aspx",false); 
                           
                    }else{
                      
                    }//if else '1'

                }  //if else '0'
            }
            catch (Exception ex_)
            {
                ex_.ToString();

            }//try-cath

        }//accesoAPP


        public Boolean accesoAPPbool(string usuP, string passP)
        {

            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            DataTable dt_datosAcceso = new DataTable();
            Boolean r_acceso = false;

            try
            {


                SqlParameter[] parametroMySql = new SqlParameter[3];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@usuario", SqlDbType.VarChar);
                parametroMySql[2] = new SqlParameter("@pass", SqlDbType.VarChar);

                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;
                parametroMySql[2].Direction = ParameterDirection.Input;

                parametroMySql[1].Value = usuP;
                parametroMySql[2].Value = passP;


                dt_datosAcceso = accesoMysql.fn_getResultado_DataTable(parametroMySql, "seleccionarUsuario");

                if (dt_datosAcceso.Rows.Count == 0)
                {

                  r_acceso=false;

                }else if (dt_datosAcceso.Rows.Count == 1){


                    cls_acceso.set_Usuario(dt_datosAcceso.Rows[0]["usuario"].ToString());
                    cls_acceso.set_Pass(dt_datosAcceso.Rows[0]["pass"].ToString());
                    cls_acceso.set_ID(int.Parse(dt_datosAcceso.Rows[0]["numempleado"].ToString()));
                    cls_acceso.set_Perfil(int.Parse(dt_datosAcceso.Rows[0]["id_perfil"].ToString()));

                    cls_empleado.set_NombreEmpleado(dt_datosAcceso.Rows[0]["nombre"].ToString());
                    cls_empleado.set_PaternoEmpleado(dt_datosAcceso.Rows[0]["paterno"].ToString());
                    cls_empleado.set_MaternoEmpleado(dt_datosAcceso.Rows[0]["materno"].ToString());
                    cls_empleado.set_PuestoEmpleado(dt_datosAcceso.Rows[0]["puesto"].ToString());
                    cls_empleado.set_AreaEmpleado(dt_datosAcceso.Rows[0]["area"].ToString());

                        if (dt_datosAcceso.Rows.Count > 0){
                            
                           
                           r_acceso=true;
                           cls_configuracion.setPerfiles();
                            
                            
                        }
                        else
                        {
                           r_acceso = false;
                        }//if else '1'
                        

                }  //if else '0'

                return r_acceso ;
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return r_acceso ;

            }//try-cath

        }//accesoAPP



    }//cls_acceso

}//betaCultural