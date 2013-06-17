using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace betaCulturalMARKII
{
    public class cls_datos_globales
    {
        

        public static string FechaHoyYYYYMMDD()
        {
            DateTime Fecha = DateTime.Now;

            return String.Format("{0:yyyy-MM-dd}", Fecha); 

        }
        public static string FechaHoyDDMMYYYY()
        {
            DateTime Fecha = DateTime.Now;

            return  Fecha.Day + "-" + Fecha.Month + "-" +Fecha.Year;
        }
        public static string getFechaYMD(string str_fechaP){

            string str_fecha_formato = "";

            

            return String.Format("{0:yyyy-MM-dd}", str_fechaP);
        }

               
        //metodos para saber que pantalla invoco las carpetas de meses, para 
        //mostrar la informacion ya sea para matriz u objetivos mensuales.
        public static string get_tipoMatrizConsulta(){
            return (string)HttpContext.Current.Session["str_tipoMatrizConsulta"];
        }
        public static void set_tipoMatrizConsulta(string consultaPantalla)
        {
            HttpContext.Current.Session["str_tipoMatrizConsulta"] = consultaPantalla;
        }

    }//cls_datos_globales
}