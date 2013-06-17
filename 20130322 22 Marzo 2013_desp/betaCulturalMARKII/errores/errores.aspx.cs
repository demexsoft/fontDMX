using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace betaCulturalMARKII
{
    public partial class errores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            iniciaError();

        }

        public void iniciaError(){
            try{

                lblError.Text = cls_errores.get_Error().ToString();

            }catch(Exception ex_){
                ex_.ToString();
            }//try
        
        }

        protected void btn_link_regresar_principal_Click(object sender, EventArgs e)
        {
            
                 Response.Redirect("errores.aspx",false);
        }
    }
}
