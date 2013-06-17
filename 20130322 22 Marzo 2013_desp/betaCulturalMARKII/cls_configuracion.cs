using System;
using System.Data;
using System.Data.SqlClient;
using betaCulturalMARKII.conexionMysql;
using System.Web;

namespace betaCulturalMARKII
{
    public class cls_configuracion
    {



        public static void setIdioma(string idiomaP)
        {
            try
            {
                HttpContext.Current.Session["str_idioma"] = idiomaP;
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//catch

        }
        public static string getIdioma()
        {
            try
            {

                return (string)HttpContext.Current.Session["str_idioma"];

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return "none";
            }//catch
        }//getIdioma

        protected static DataTable dt_perfil = new DataTable();

        public static void setPerfiles()
        {


            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            try
            {


                SqlParameter[] parametroMySql = new SqlParameter[1];
                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[0].Direction = ParameterDirection.Output;

                dt_perfil = accesoMysql.fn_getResultado_DataTable(parametroMySql, "verPerfiles");

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);

            }//try-catch

        }//getPerfiles
        public static DataTable getPerfiles()
        {
            try
            {


                return dt_perfil;
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return dt_perfil = new DataTable();
            }//try-catch


        }//getPerfiles



        private static string ADMIN = "";
        private static string LIDER = "";
        private static string INTEGRANTE = "";

        public static string _ADMIN()
        {
            try
            {
                DataRow[] rowCerrar;

                rowCerrar = getPerfiles().Select("nomperfil='Administrador'");
                ADMIN = rowCerrar[0][1].ToString();


                return ADMIN;

            }
            catch (Exception ex_)
            {

                cls_errores.muestraWebError(ex_);
                return "none";

            }//catch
        }//_ADMIN

        public static string _LIDER()
        {
            try
            {
                DataRow[] rowCerrar;

                rowCerrar = getPerfiles().Select("nomperfil='lider'");
                LIDER = rowCerrar[0][1].ToString();


                return LIDER;
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return "none";
            }//catch
        }//_ADMIN

        public static string _INTEGRANTE()
        {
            try
            {

                DataRow[] rowCerrar;

                rowCerrar = getPerfiles().Select("nomperfil='integrante'");
                INTEGRANTE = rowCerrar[0][1].ToString();

                return INTEGRANTE;
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return "none";
            }//catch
        }//_ADMIN

        public static void tipoObjetivo()
        {
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            DataTable ds_objetivo = new DataTable();

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[1];
                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[0].Direction = ParameterDirection.Output;
                ds_objetivo = accesoMysql.fn_getResultado_DataSet(parametroMySql, "verTipoObjetivo").Tables["Table"];
                HttpContext.Current.Session["ds_objetivo"] = ds_objetivo;
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

            //tipoObjetivo
        }

       
        public static DataTable get_TodosTiposObjetivos()
        {
            try
            {
                return (DataTable)HttpContext.Current.Session["ds_objetivo"];

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return new DataTable();

            }//try-catch


        }//tipoObjetivo


        public static int get_tipoObjetivo_PRIORITARIO()
        {

            try
            {

                return
               int.Parse(Convert.ToString(get_TodosTiposObjetivos().Rows[get_TodosTiposObjetivos().Rows.IndexOf(get_TodosTiposObjetivos().Select("key_desc='pk_Prioritario'")[0])]["IDObjetivo"]));

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return 0;
            }//try-catch

        }//get_tipoObjetivo_PRIMARIO
        public static int get_tipoObjetivo_SECUNDARIO()
        {

            try
            {

                return
                    int.Parse(Convert.ToString(get_TodosTiposObjetivos().Rows[get_TodosTiposObjetivos().Rows.IndexOf(get_TodosTiposObjetivos().Select("key_desc='pk_Secundario'")[0])]["IDObjetivo"]));
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return 0;
            }//try-catch

        }//get_tipoObjetivo_SECUNDARIO

        public static int get_tipoObjetivo_PERMANENTE()
        {

            try
            {

                return
                    int.Parse(Convert.ToString(get_TodosTiposObjetivos().Rows[get_TodosTiposObjetivos().Rows.IndexOf(get_TodosTiposObjetivos().Select("key_desc='pk_Permanente'")[0])]["IDObjetivo"]));


            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return 0;
            }//try-catch

        }//get_tipoObjetivo_PERMANENTE

        public static int get_tipoObjetivo_EQUIPO()
        {

            try
            {

                return
                    int.Parse(Convert.ToString(get_TodosTiposObjetivos().Rows[get_TodosTiposObjetivos().Rows.IndexOf(get_TodosTiposObjetivos().Select("key_desc='pk_Equipo'")[0])]["IDObjetivo"]));


            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return 0;
            }//try-catch

        }//get_tipoObjetivo_PERMANENTE


    }//cls_configuracion
}//betaCultural
