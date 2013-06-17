using System;
using System.Data;
using betaCulturalMARKII.conexionMysql;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web;

namespace betaCulturalMARKII.equipo
{
    public class cls_equipo
    {

       static DataSet dset_misEquipos;
       static DataTable dt_miembrosDeEquipo= new DataTable(); //empleados a de un equipo

       static int ultimoEquipo_= 0;

       public static void set_ultimoEquipo_(int ultimoEquipo_P)
       {
         HttpContext.Current.Session["ultimoEquipo_"] = ultimoEquipo_P;
       }
       public static int get_ultimoEquipo_()
       {
           return (int)HttpContext.Current.Session["ultimoEquipo_"];
       }



       //Datos de Equipo
       public static int get_IDEquipo()
       {
           return (int)HttpContext.Current.Session["IDequipo"];
       }
       public static void set_IDEquipo(int IDequipoP)
       {
           HttpContext.Current.Session["IDequipo"] = IDequipoP;
       }

       //Nombre del Equipo al que pertenece el empleado que selcciono
       public static string get_NomEquipo()
       {
           string nomEKI = "";
            nomEKI =  (string)HttpContext.Current.Session["NomEquipo"];
            return nomEKI;
       }
       public static void set_NomEquipo(string NomEquipoP)
       {
           HttpContext.Current.Session["NomEquipo"] = NomEquipoP;
       }

       //Datos de Jefe de Equipo
       public static int get_IDJefeEquipo()
       {
           return (int)HttpContext.Current.Session["IDJefeEquipo"];
       }
       public static void set_IDJefeEquipo(int IDJefeEquipoP)
       {
           HttpContext.Current.Session["IDJefeEquipo"] = IDJefeEquipoP;
       }

       //Nombre de jefe del equipo al que pertenece el empleado que selcciono
       public static string get_NomJefeEquipo()
       {
           return (string)HttpContext.Current.Session["NomJefeEquipo"];
       }
       public static void set_NomJefeEquipo(string NomJefeEquipoP)
       {
           HttpContext.Current.Session["NomJefeEquipo"] = NomJefeEquipoP;
       }
       
       public static void ini_DataTable()
       {

           if (dt_miembrosDeEquipo.Columns["idEquipo"] == null)
           {

               dt_miembrosDeEquipo.Columns.Add("idEquipo");//1
               dt_miembrosDeEquipo.Columns.Add("IDempleado");//2
               dt_miembrosDeEquipo.Columns.Add("nombreEmp");//3
               dt_miembrosDeEquipo.Columns.Add("apePat");//4
               dt_miembrosDeEquipo.Columns.Add("apeMat");//5
               dt_miembrosDeEquipo.Columns.Add("area");//6
               
           }
           else
           {

           }//else

       }//ini_DataTable

       public static DataTable get_miembrosDeEquipo()
       {

           return dt_miembrosDeEquipo;
       }
       public static void set_miembrosDeEquipo(DataRow dr_miembrosDeEquipoP)
       {
           dt_miembrosDeEquipo.Rows.Add(dr_miembrosDeEquipoP);
       }

        public static DataSet get_misEquipos() {

            return  dset_misEquipos;
        }//get_misEquipos
        public static void set_misEquipos(int IDempleado)
        {
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();

            try
            {
                SqlParameter[] parametroMySql = new SqlParameter[2];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@idEmpleadoEquipo", SqlDbType.Int);

                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;

                parametroMySql[1].Value = IDempleado;
                dset_misEquipos = accesoMysql.fn_getResultado_DataSet(parametroMySql, "verMisEquipos");
                
                
            }
            catch (Exception ex_)
            {
                
                cls_errores.muestraWebError(ex_);
                
            }//try-catch
            

        }//set_misEquipos




        public DataTable verTodosEquipos(int IDArea)
        {

            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            DataTable dt_equipo = new DataTable();

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[2];
                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDarea", SqlDbType.Int);

                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;

                parametroMySql[1].Value = IDArea;

                dt_equipo = accesoMysql.fn_getResultado_DataTable(parametroMySql, "verEquipos");
                return dt_equipo;
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return dt_equipo = new DataTable();
            }//try-catch
        }//verTodosEquipos

        public DataTable ver_misEquipos(int idEmpleadoEquipo)
        {
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            DataTable dt_empleadoequipo = new DataTable();

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[2];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@idEmpleadoEquipo", SqlDbType.Int);

                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;

                parametroMySql[1].Value = idEmpleadoEquipo;
                dt_empleadoequipo = accesoMysql.fn_getResultado_DataTable(parametroMySql, "verMisEquipos");

                return dt_empleadoequipo;
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return dt_empleadoequipo = new DataTable();
            }//try-catch

        }//ver_misEquipos

        public DataTable verEmpleadosEnEquipo()
        {            
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            DataTable dt_empleadoequipo = new DataTable();

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[1];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[0].Direction = ParameterDirection.Output;
                

                
                dt_empleadoequipo = accesoMysql.fn_getResultado_DataTable(parametroMySql, "verEmpleadoEnEquipo");

                return dt_empleadoequipo;
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return dt_empleadoequipo = new DataTable();
            }//try-catch
        
        }

        public void vista_MisEquipos(Panel div_componente_P, string treeViewDespliega)
        {
            try
            {
                DataTable dt_item_ = verTodosEquipos(0);
                ((TreeView)div_componente_P.FindControl(treeViewDespliega)).Nodes.Clear();

                for (int countItem = 0; countItem < dt_item_.Rows.Count; countItem++)
                {
                    TreeNode nodo_equipo = new TreeNode();

                    nodo_equipo.Text = (dt_item_.Rows[countItem]["nomEqui"]).ToString();
                    nodo_equipo.Value = (dt_item_.Rows[countItem]["IDEquipo"]).ToString();
                    nodo_equipo.ImageUrl = "imagenesBasicas/botonesImagenes/equipoico.png";

                    ((TreeView)div_componente_P.FindControl(treeViewDespliega)).Nodes.Add(nodo_equipo);

                }//for

            }
            catch (Exception ex_)
            {
                ex_.ToString();
            }//try-catch
        
        }

        public DataTable verDatosEquipoID(int IDEquipo) {

            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            DataTable dt_DatosEquipo = new DataTable();

            try {

                SqlParameter[] parametroMySql = new SqlParameter[2];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDEquipo", SqlDbType.Int);
                

                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;

                parametroMySql[1].Value = IDEquipo;


                dt_DatosEquipo = accesoMysql.fn_getResultado_DataTable(parametroMySql, "verDatosEquipoID");

                return dt_DatosEquipo;

            }catch(Exception ex_){

                cls_errores.muestraWebError(ex_);
                return dt_DatosEquipo = new DataTable();

            }//try-catch        
        }//verDatosEquipoID

        public void misEquipos(Panel div_componente_P, string treeViewDespliega)
        {
            try
            {

                cls_equipo equipo = new cls_equipo();

                DataTable tbl_empleadoID = equipo.verEmpleadosEnEquipo();
                DataTable tbl_equipoID = equipo.verTodosEquipos(0);

                tbl_empleadoID.TableName = "tbl_empleadoID";
                tbl_equipoID.TableName = "tbl_equipoID";

                //

                DataSet ds = new DataSet();

                ds.Tables.Add(tbl_empleadoID);
                ds.Tables.Add(tbl_equipoID);




                ((TreeView)div_componente_P.FindControl(treeViewDespliega)).Nodes.Clear();

                for (int padre = 0; padre < ds.Tables["tbl_equipoID"].Rows.Count; padre++)
                {
                    string nombre = ds.Tables["tbl_equipoID"].Rows[padre]["nomEqui"].ToString();
                    string jefeEquipo = ds.Tables["tbl_equipoID"].Rows[padre]["nomJefe"].ToString();

                    TreeNode nodoPadre = new TreeNode("<strong> " + nombre + "</strong> [ " + jefeEquipo + " ] <span class='textoChicoAzul_'>EDITAR</span>");

                    nodoPadre.Value = ds.Tables["tbl_equipoID"].Rows[padre]["IDEquipo"].ToString();

                    for (int hijo = 0; hijo < ds.Tables["tbl_empleadoID"].Rows.Count; hijo++)
                    {
                        if (ds.Tables["tbl_empleadoID"].Rows[hijo]["parentIDEquipo"].ToString() == ds.Tables["tbl_equipoID"].Rows[padre]["IDEquipo"].ToString())
                        {
                            TreeNode nodoHijo = new TreeNode(ds.Tables["tbl_empleadoID"].Rows[hijo]["nom"].ToString());
                            nodoHijo.Value = ds.Tables["tbl_empleadoID"].Rows[hijo]["id_empleado"].ToString();
                            nodoHijo.ImageUrl = "imagenesBasicas/botonesImagenes/iconos/empleadoIcon.png";

                            nodoPadre.ChildNodes.Add(nodoHijo);
                        }//if
                        else
                        {

                        }
                    }//foreach-drHijo
                    nodoPadre.ImageUrl = "imagenesBasicas/botonesImagenes/iconos/equipoico.png";
                    ((TreeView)div_componente_P.FindControl(treeViewDespliega)).Nodes.Add(nodoPadre);
                }//foreach-drPadre

                ((TreeView)div_componente_P.FindControl(treeViewDespliega)).ExpandAll();



            }
            catch (Exception ex_)
            {
                ex_.ToString();
            }//try-catch

        }//vista_EquiposEmpleadosAll

        public void vista_EquiposEmpleadosAll( Panel div_componente_P, string treeViewDespliega)
        {
            try
            {

                cls_equipo equipo = new cls_equipo();

                DataTable tbl_empleadoID = equipo.verEmpleadosEnEquipo();
                DataTable tbl_equipoID = equipo.verTodosEquipos(0);

                tbl_empleadoID.TableName = "tbl_empleadoID";
                tbl_equipoID.TableName = "tbl_equipoID";

                //

                DataSet ds = new DataSet();

                ds.Tables.Add(tbl_empleadoID);
                ds.Tables.Add(tbl_equipoID);




                ((TreeView)div_componente_P.FindControl(treeViewDespliega)).Nodes.Clear();

                for (int padre = 0; padre < ds.Tables["tbl_equipoID"].Rows.Count; padre++)
                {
                    string nombre = ds.Tables["tbl_equipoID"].Rows[padre]["nomEqui"].ToString();
                    string jefeEquipo = ds.Tables["tbl_equipoID"].Rows[padre]["nomJefe"].ToString();

                    TreeNode nodoPadre = new TreeNode("<strong> "+ nombre + "</strong> [ " + jefeEquipo + " ] <span class='textoChicoAzul_'>EDITAR</span>");

                    nodoPadre.Value = ds.Tables["tbl_equipoID"].Rows[padre]["IDEquipo"].ToString();

                    for (int hijo = 0; hijo < ds.Tables["tbl_empleadoID"].Rows.Count; hijo++)
                    {
                        if (ds.Tables["tbl_empleadoID"].Rows[hijo]["parentIDEquipo"].ToString() == ds.Tables["tbl_equipoID"].Rows[padre]["IDEquipo"].ToString())
                        {
                            TreeNode nodoHijo = new TreeNode(ds.Tables["tbl_empleadoID"].Rows[hijo]["nom"].ToString());
                            nodoHijo.Value = ds.Tables["tbl_empleadoID"].Rows[hijo]["id_empleado"].ToString();
                            nodoHijo.ImageUrl = "imagenesBasicas/botonesImagenes/iconos/empleadoIcon.png";

                            nodoPadre.ChildNodes.Add(nodoHijo);
                        }//if
                        else
                        {

                        }
                    }//foreach-drHijo
                    nodoPadre.ImageUrl = "imagenesBasicas/botonesImagenes/iconos/equipoico.png";
                    ((TreeView)div_componente_P.FindControl(treeViewDespliega)).Nodes.Add(nodoPadre);
                }//foreach-drPadre

                ((TreeView)div_componente_P.FindControl(treeViewDespliega)).ExpandAll();
               


            }
            catch (Exception ex_)
            {
                ex_.ToString();
            }//try-catch

        }//vista_EquiposEmpleadosAll

        public int agregarMiembroEnEquipo( int IDEmpleadoCreador,int IDEquipo, int IDMiembro) {
            
                DataTable dt_objetivo = new DataTable();
                cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
                int respuesta;

            try{

                SqlParameter[] parametroMySql = new SqlParameter[4];

                parametroMySql[0] = new SqlParameter("@r_store",           SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDempleadoCreador", SqlDbType.Int);
                parametroMySql[2] = new SqlParameter("@IDEmpleadoMiembro", SqlDbType.Int);
                parametroMySql[3] = new SqlParameter("@IDEquipo",          SqlDbType.Int);

                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;
                parametroMySql[2].Direction = ParameterDirection.Input;
                parametroMySql[3].Direction = ParameterDirection.Input;

                parametroMySql[1].Value = IDEmpleadoCreador;
                parametroMySql[2].Value = IDMiembro;
                parametroMySql[3].Value = IDEquipo;

                accesoMysql.fn_getResultado_Command(parametroMySql, "agregarMiembroEnEquipo");

                respuesta = int.Parse(parametroMySql[0].Value.ToString());

                return respuesta;

            }catch(Exception ex_){
                
                cls_errores.muestraWebError(ex_);
                return -1;

            }//try-catch
        
        }//agregarEquipo

        public int quitarMiembroEnEquipo(int IDEquipo, int IDMiembro)
        {

            DataTable dt_objetivo = new DataTable();
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            int respuesta;

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[3];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDempleado", SqlDbType.Int);                
                parametroMySql[2] = new SqlParameter("@IDEquipo", SqlDbType.Int);

                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;
                parametroMySql[2].Direction = ParameterDirection.Input;                
                
                parametroMySql[1].Value = IDMiembro;
                parametroMySql[2].Value = IDEquipo;

                accesoMysql.fn_getResultado_Command(parametroMySql, "quitarEmpeladoDeEquipo");

                respuesta = int.Parse(parametroMySql[0].Value.ToString());

                return respuesta;

            }
            catch (Exception ex_)
            {

                cls_errores.muestraWebError(ex_);
                return -1;

            }//try-catch

        }

        public int modificarEquipoYLider(int IDEquipo, string NombreEquipo, int IDEmpleadoLider)
        {

            DataTable dt_objetivo = new DataTable();
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            int respuesta;

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[4];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@IDEquipo", SqlDbType.Int);
                parametroMySql[2] = new SqlParameter("@d_equipo", SqlDbType.VarChar);
                parametroMySql[3] = new SqlParameter("@id_empleadoLider", SqlDbType.Int);
                

                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;
                parametroMySql[2].Direction = ParameterDirection.Input;
                parametroMySql[3].Direction = ParameterDirection.Input;

                parametroMySql[1].Value = IDEquipo;
                parametroMySql[2].Value = NombreEquipo;
                parametroMySql[3].Value = IDEmpleadoLider;

                accesoMysql.fn_getResultado_Command(parametroMySql, "modificarEquipoYLider");

                respuesta = int.Parse(parametroMySql[0].Value.ToString());

                return respuesta;

            }
            catch (Exception ex_)
            {

                cls_errores.muestraWebError(ex_);
                return -1;

            }//try-catch
        }

        public int crearEquipo(int IDempleadoCreador, string ActividadEquipo, string NombreEquipo, int IDempleadoJefe, int IDarea)
        {
            int r_store = -100;
            int ultimo_ID_Equipo;

            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[7];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);
                parametroMySql[1] = new SqlParameter("@ultimoInsertadoEquipo", SqlDbType.Int);
                parametroMySql[2] = new SqlParameter("@IDempleadoCreador", SqlDbType.Int);
                parametroMySql[3] = new SqlParameter("@actividadEquipo", SqlDbType.Text);
                parametroMySql[4] = new SqlParameter("@nombreEquipo", SqlDbType.Text);
                parametroMySql[5] = new SqlParameter("@IDempleadoJefe", SqlDbType.Int);
                parametroMySql[6] = new SqlParameter("@IDarea", SqlDbType.Int);
                
                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Output;

                parametroMySql[2].Direction = ParameterDirection.Input;
                parametroMySql[3].Direction = ParameterDirection.Input;
                parametroMySql[4].Direction = ParameterDirection.Input;
                parametroMySql[5].Direction = ParameterDirection.Input;
                parametroMySql[6].Direction = ParameterDirection.Input;

                parametroMySql[2].Value = IDempleadoCreador;
                parametroMySql[3].Value = ActividadEquipo;
                parametroMySql[4].Value = NombreEquipo;
                parametroMySql[5].Value = IDempleadoJefe;
                parametroMySql[6].Value = IDarea;

                accesoMysql.fn_getResultado_Command(parametroMySql, "crearEquipo");

                r_store = int.Parse(parametroMySql[0].Value.ToString());
                ultimo_ID_Equipo = int.Parse(parametroMySql[1].Value.ToString());

                return ultimo_ID_Equipo;

            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return r_store;
            }//try-catch

            //crearEquipo
        }

        public void LlenaCombo_verTodosEquipos(DataTable dt_Name, DropDownList ddl_Name, bool RenglonBlanco)
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
                        Lista.Text = dt_Name.Rows[i]["nomEqui"].ToString();
                        Lista.Value = dt_Name.Rows[i]["IDEquipo"].ToString();

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
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public int quitarEquipo(int IDEquipo)
        {

            DataTable dt_objetivo = new DataTable();
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            int respuesta;

            try
            {

                SqlParameter[] parametroMySql = new SqlParameter[2];

                parametroMySql[0] = new SqlParameter("@r_store", SqlDbType.Int);                
                parametroMySql[1] = new SqlParameter("@IDEquipo", SqlDbType.Int);

                parametroMySql[0].Direction = ParameterDirection.Output;
                parametroMySql[1].Direction = ParameterDirection.Input;                
                
                parametroMySql[1].Value = IDEquipo;

                accesoMysql.fn_getResultado_Command(parametroMySql, "quitarEquipo");

                respuesta = int.Parse(parametroMySql[0].Value.ToString());

                return respuesta;

            }
            catch (Exception ex_)
            {

                cls_errores.muestraWebError(ex_);
                return -1;

            }//try-catch

        }

    }//cls_equipo
}//betaCultural