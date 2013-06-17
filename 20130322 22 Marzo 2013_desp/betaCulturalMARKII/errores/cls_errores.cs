using System;
using System.Web.UI.WebControls;

namespace betaCulturalMARKII
{
    public class cls_errores
    {

        public cls_errores()
        {


        }//cls_errores


        private static Exception exepcionApp;

        public static void set_Error(Exception exep)
        {

            exepcionApp = exep;
        }//set_Error

        public static Exception get_Error()
        {
            return exepcionApp;
        }//verError

        public static void muestraWebError(Exception exep)
        {

            set_Error(exep);
            System.Web.HttpContext.Current.Response.Redirect("~/errores/errores.aspx", false);

        }

    }//cls_errores
}//betaCultural