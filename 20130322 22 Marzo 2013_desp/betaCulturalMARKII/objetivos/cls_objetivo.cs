using System;
using System.Data;
using betaCulturalMARKII.conexionMysql;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web;

namespace betaCulturalMARKII.objetivos{

  public class cls_objetivo{

    public cls_objetivo(){             
    }

    private static int PRIMARIO =   0;
    private static int SECUNDARIO = 0;
    private static int PERMANENTE = 0;
 

    static DataTable td_objetivo_ = new DataTable();
    static DataTable td_objetivo_secundario_ = new DataTable();
    static DataTable td_objetivo_permanente_ = new DataTable();

     private static int IDobj_=0;

      public static void ini_DataTable() {
          try{

               if (HttpContext.Current.Session["td_objetivo_"] == null){

                   td_objetivo_ = new DataTable();   

                    td_objetivo_.Columns.Add("idMatrizIndi");//1
                    td_objetivo_.Columns.Add("IDObj");//->no implementado
                    td_objetivo_.Columns.Add("descObjetivo");//2
                    td_objetivo_.Columns.Add("tipoObjetivo");//3
                    td_objetivo_.Columns.Add("fechaCompro");//4
                    td_objetivo_.Columns.Add("estatusObjetivo");//5
                    td_objetivo_.Columns.Add("porEficacia");//6
                    td_objetivo_.Columns.Add("porEficiencia");//7
                    td_objetivo_.Columns.Add("fechaCumpli");//8
                    td_objetivo_.Columns.Add("semanasAtraso");//9
                    td_objetivo_.Columns.Add("areaOportunidad");//10
                    td_objetivo_.Columns.Add("id_integrante");//11
                    td_objetivo_.Columns.Add("id_equipo");//12

                    HttpContext.Current.Session["td_objetivo_"] = td_objetivo_;

                }else{
                    td_objetivo_ = (DataTable)HttpContext.Current.Session["td_objetivo_"];
                }

              //secundarios
               if (HttpContext.Current.Session["td_objetivo_secundario_"] == null)
               {

                   td_objetivo_secundario_ = new DataTable();

                   td_objetivo_secundario_.Columns.Add("idMatrizIndi");//1
                   td_objetivo_secundario_.Columns.Add("IDObj");//->no implementado
                   td_objetivo_secundario_.Columns.Add("descObjetivo");//2
                   td_objetivo_secundario_.Columns.Add("tipoObjetivo");//3
                   td_objetivo_secundario_.Columns.Add("fechaCompro");//4
                   td_objetivo_secundario_.Columns.Add("estatusObjetivo");//5
                   td_objetivo_secundario_.Columns.Add("porEficacia");//6
                   td_objetivo_secundario_.Columns.Add("porEficiencia");//7
                   td_objetivo_secundario_.Columns.Add("fechaCumpli");//8
                   td_objetivo_secundario_.Columns.Add("semanasAtraso");//9
                   td_objetivo_secundario_.Columns.Add("areaOportunidad");//10
                   td_objetivo_secundario_.Columns.Add("id_integrante");//11
                   td_objetivo_secundario_.Columns.Add("id_equipo");//12

                   HttpContext.Current.Session["td_objetivo_secundario_"] = td_objetivo_secundario_;

               }
               else
               {
                   td_objetivo_secundario_ = (DataTable)HttpContext.Current.Session["td_objetivo_secundario_"];
               }     

              //permanente

               if (HttpContext.Current.Session["td_objetivo_permanente_"] == null)
               {

                   td_objetivo_permanente_ = new DataTable();

                   td_objetivo_permanente_.Columns.Add("idMatrizIndi");//1
                   td_objetivo_permanente_.Columns.Add("IDObj");//->no implementado
                   td_objetivo_permanente_.Columns.Add("descObjetivo");//2
                   td_objetivo_permanente_.Columns.Add("tipoObjetivo");//3
                   td_objetivo_permanente_.Columns.Add("fechaCompro");//4
                   td_objetivo_permanente_.Columns.Add("estatusObjetivo");//5
                   td_objetivo_permanente_.Columns.Add("porEficacia");//6
                   td_objetivo_permanente_.Columns.Add("porEficiencia");//7
                   td_objetivo_permanente_.Columns.Add("fechaCumpli");//8
                   td_objetivo_permanente_.Columns.Add("semanasAtraso");//9
                   td_objetivo_permanente_.Columns.Add("areaOportunidad");//10
                   td_objetivo_permanente_.Columns.Add("id_integrante");//11
                   td_objetivo_permanente_.Columns.Add("id_equipo");//12

                   HttpContext.Current.Session["td_objetivo_permanente_"] = td_objetivo_permanente_;

               }
               else
               {
                   td_objetivo_permanente_ = (DataTable)HttpContext.Current.Session["td_objetivo_permanente_"];
               }     

          }catch(Exception ex_){
              cls_errores.muestraWebError(ex_);
          }//try-catch
        
   }//ini_DataTable
      
      public static void set_IDobejtivoIndividual(int objP) {
          HttpContext.Current.Session["IDobj_"] = objP;
      }

      public static int get_IDobejtivoIndividual(){
          return (int)HttpContext.Current.Session["IDobj_"];
      }


      //primarios
        public static DataTable get_objetivos() {
            return (DataTable)HttpContext.Current.Session["td_objetivo_"]; 
        }
        //secundarios
        public static DataTable get_objetivosSecundarios()
        {
            return (DataTable)HttpContext.Current.Session["td_objetivo_secundario_"];
        }
        //permanentes
        public static DataTable get_objetivosPermanentes()
        {
            return (DataTable)HttpContext.Current.Session["td_objetivo_permanente_"];
        }
        //primarios
        public static void set_objetivos(DataRow dr_objetivoP)
        {  
         ((DataTable)HttpContext.Current.Session["td_objetivo_"]).Rows.Add(dr_objetivoP);
        }
        //secundarios
        public static void set_objetivosSecundarios(DataRow dr_objetivoP)
        {  
         ((DataTable)HttpContext.Current.Session["td_objetivo_secundario_"]).Rows.Add(dr_objetivoP);
        }
        //permanentes
        public static void set_objetivosPermanentes(DataRow dr_objetivoP)
        {
            ((DataTable)HttpContext.Current.Session["td_objetivo_permanente_"]).Rows.Add(dr_objetivoP);
        }


        public static void eliminarObjetivosTodos() {
            try {

                
                HttpContext.Current.Session["td_objetivo_"] = new DataTable();
                HttpContext.Current.Session["td_objetivo_secundario_"] = new DataTable();
                HttpContext.Current.Session["td_objetivo_permanente_"] = new DataTable();

            }catch(Exception ex_){
                cls_errores.muestraWebError(ex_);
            }//try-catch
            
        }//eliminarObjetivosTodos




        public static DataTable verObjetivosEmpleado(int IDEmpleado, int IDMatriz, int IDtipoObjetivo)
        {

           DataTable dt_objetivos = new DataTable();
           cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();

           try {

                SqlParameter [] parametroMySql=new SqlParameter[4];

               parametroMySql[0]=  new SqlParameter("@r_store", SqlDbType.Int);
               parametroMySql[1] = new SqlParameter("@IDempleado", SqlDbType.Int);
               parametroMySql[2] = new SqlParameter("@IDMatriz", SqlDbType.Int);
               parametroMySql[3] = new SqlParameter("@IDtipoObjetivo", SqlDbType.Int);

               parametroMySql[0].Direction = ParameterDirection.Output;
               parametroMySql[1].Direction = ParameterDirection.Input;
               parametroMySql[2].Direction = ParameterDirection.Input;
               parametroMySql[3].Direction = ParameterDirection.Input;
               

               parametroMySql[1].Value  =   IDEmpleado;
               parametroMySql[2].Value  =   IDMatriz;
               parametroMySql[3].Value =    IDtipoObjetivo;
               
               dt_objetivos = accesoMysql.fn_getResultado_DataTable(parametroMySql, "verObjetivosEmpleadoMatriz");


               return dt_objetivos;
           }catch(Exception ex_){
               cls_errores.muestraWebError(ex_);
               return dt_objetivos = new DataTable();

           } //try-catch
       
       }//verObjetivo

       public  DataTable verObjetivosEmpleadoTodosEquipo(int IDEmpleado,int IDEquipo)
       {

           DataTable dt_objetivos = new DataTable();
           cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();

           try
           {

               SqlParameter[] parametroMySql = new SqlParameter[3];

               parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
               parametroMySql[1] = new SqlParameter("@IDempleado", SqlDbType.Int);
               parametroMySql[2] = new SqlParameter("@IDEquipo", SqlDbType.Int);

               parametroMySql[0].Direction = ParameterDirection.Output;
               parametroMySql[1].Direction = ParameterDirection.Input;
               parametroMySql[2].Direction = ParameterDirection.Input;


               parametroMySql[1].Value = IDEmpleado;
               parametroMySql[2].Value = IDEquipo;

               dt_objetivos = accesoMysql.fn_getResultado_DataTable(parametroMySql, "verObjetivosEmpleadoTodosEquipo");


               return dt_objetivos;
           }
           catch (Exception ex_)
           {
               cls_errores.muestraWebError(ex_);
               return dt_objetivos = new DataTable();

           } //try-catch

       }//verObjetivo





       public int agregarObjetivo(int IDMatriz,int IDEmpleado, int tipoObj,
                                  int statusObjetivo, decimal eficacia,decimal eficiencia, int semanasAtraso ,
                                  string descripcionObj,string areaOporObj, string compromisoObj, int IDEquipo)
       {

           DataTable dt_objetivo = new DataTable();
           cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
           int respuesta=-100;
           try {


               SqlParameter[] parametroMySql = new SqlParameter[12];

               parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
               parametroMySql[1] = new SqlParameter("@IDmatriz", SqlDbType.Int);
               parametroMySql[2] = new SqlParameter("@descripcionObj", SqlDbType.Text);
               parametroMySql[3] = new SqlParameter("@IDtipoObjetivo", SqlDbType.Int);
               parametroMySql[4] = new SqlParameter("@fechaCompromiso", SqlDbType.Date);
               parametroMySql[5] = new SqlParameter("@statusObjetivo", SqlDbType.Int);
               parametroMySql[6] = new SqlParameter("@eficacia", SqlDbType.Decimal);
               parametroMySql[7] = new SqlParameter("@eficiencia", SqlDbType.Decimal);
               parametroMySql[8] = new SqlParameter("@semanaAtraso", SqlDbType.Int);
               parametroMySql[9] = new SqlParameter("@areaOportunidad", SqlDbType.Text);
               parametroMySql[10] = new SqlParameter("@IDequipoIntegrante", SqlDbType.Int);
               parametroMySql[11] = new SqlParameter("@IDequipo", SqlDbType.Int);
               
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
               

                parametroMySql[1].Value = IDMatriz;
                parametroMySql[2].Value = descripcionObj;
                parametroMySql[3].Value = tipoObj;
                parametroMySql[4].Value = compromisoObj;
                parametroMySql[5].Value = statusObjetivo;
                parametroMySql[6].Value = eficacia;
                parametroMySql[7].Value = eficiencia;
                parametroMySql[8].Value = semanasAtraso;
                parametroMySql[9].Value = areaOporObj;
                parametroMySql[10].Value = IDEmpleado;
                parametroMySql[11].Value = IDEquipo;

                accesoMysql.fn_getResultado_Command(parametroMySql, "agregarObjetivo");

                respuesta = int.Parse(parametroMySql[0].Value.ToString());

              

                return respuesta;
           }catch(Exception ex_){

                cls_errores.muestraWebError(ex_);
               return -1;
           }//try-catch

       }//agregarObjetivo


       public int cerrarObjetivo(int IDObjetivo, int IDEquipo, int IDEmpleado, int estatusObj, decimal eficaciaObj,
                                 decimal eficienciaObj, int semanaAtraso, string areaOporObj, string cumplimientoObj)
       {

           DataTable dt_objetivo = new DataTable();
           cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
           int respuesta;
           try
           {

               SqlParameter[] parametroMySql = new SqlParameter[10];

               parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int); //1
               parametroMySql[1] = new SqlParameter("@IDObjetivo", SqlDbType.Int); //2
               parametroMySql[2] = new SqlParameter("@statusObjetivo", SqlDbType.Int); //3
               parametroMySql[3] = new SqlParameter("@eficacia", SqlDbType.Float); //4
               parametroMySql[4] = new SqlParameter("@eficiencia", SqlDbType.Float); //5
               parametroMySql[5] = new SqlParameter("@fechaCumplimiento", SqlDbType.Date);//6
               parametroMySql[6] = new SqlParameter("@semanaAtraso", SqlDbType.Int); //7
               parametroMySql[7] = new SqlParameter("@areaOportunidad", SqlDbType.Text);//8
               parametroMySql[8] = new SqlParameter("@IDempleado", SqlDbType.Int);//9
               parametroMySql[9] = new SqlParameter("@IDequipo", SqlDbType.Int);//10


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
               


               parametroMySql[1].Value = IDObjetivo;
               parametroMySql[2].Value = estatusObj;
               parametroMySql[3].Value = eficaciaObj;
               parametroMySql[4].Value = eficienciaObj;
               parametroMySql[5].Value = cumplimientoObj;
               parametroMySql[6].Value = semanaAtraso;
               parametroMySql[7].Value = areaOporObj;
               parametroMySql[8].Value = IDEmpleado;
               parametroMySql[9].Value = IDEquipo;
          

               accesoMysql.fn_getResultado_Command(parametroMySql, "cerrarObjetivo");

               respuesta = int.Parse(parametroMySql[0].Value.ToString());



               return respuesta;
           }
           catch (Exception ex_)
           {

               cls_errores.muestraWebError(ex_);
               return -1;
           }//try-catch

       }//agregarObjetivo


       public static void tipoObjetivo()
       {
           cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
           DataTable ds_objetivo= new DataTable();

           try
           {

               SqlParameter[] parametroMySql = new SqlParameter[1];

               parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
               
               parametroMySql[0].Direction = ParameterDirection.Output;

               ds_objetivo= accesoMysql.fn_getResultado_DataSet(parametroMySql, "verTipoObjetivo").Tables["Table"];

               HttpContext.Current.Session["ds_objetivo"] = ds_objetivo;
           }catch(Exception ex_){

                cls_errores.muestraWebError(ex_);
                

           }//try-catch


       }//tipoObjetivo

       






public static int get_tipoObjetivo_seleccionado()
{

    return (int)HttpContext.Current.Session["sessionseleccionTipo"];

}


    }//cls_objetivo


     


}