using System;
using System.Data;
using betaCulturalMARKII.conexionMysql;
using System.Data.SqlClient;

namespace betaCulturalMARKII.idioma
{
    public class cls_idioma
    {

        static DataTable dt_idiomaEsp = new DataTable();

        public void seleccionDeIdioma(string str_idiomaP)
        {   

            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();

            try{

                SqlParameter[] parametroMySql = new SqlParameter[1];

                parametroMySql[0] = new SqlParameter("@str_idioma", SqlDbType.VarChar);

                parametroMySql[0].Direction = ParameterDirection.Input;

                parametroMySql[0].Value = str_idiomaP;


                dt_idiomaEsp = accesoMysql.fn_getResultado_DataTable(parametroMySql, "sp_idioma");




                
            }catch(Exception ex_){

                cls_errores.muestraWebError(ex_);
                
        
            }//try-catch

        }//seleccionDeIdioma


        public static DataTable get_seleccionDeIdioma() {

            try {

                return dt_idiomaEsp;
            }catch(Exception ex_){
                cls_errores.muestraWebError(ex_);
                return dt_idiomaEsp = new DataTable();
            }//try-cath
        
        }


    }//cls_idioma
}//betaCultural