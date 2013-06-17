using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using betaCulturalMARKII.objetivoIndiv;
using betaCulturalMARKII.matrizIndiv;
using betaCulturalMARKII.equipo;

namespace betaCulturalMARKII
{
    public partial class wf_MatrizIndividual : System.Web.UI.Page
    {        
        cls_matrizIndividual objMatrizIndividual = new cls_matrizIndividual();
        cls_objetivo objObjetivos = new cls_objetivo();        
        cls_Utilerias Msg = new cls_Utilerias();

        protected static int IDMatriz;
        protected static int IdEstatusObj;

        /*VARIABLES ObjPrioritarios*/
        protected static int Indice_OP;
        protected static int DivisorOP;
        protected static double SumEficaciaOP;
        protected static double SumEficienciaOP;

        /*VARIABLES ObjSecundariios*/
        protected static int Indice_OS;
        protected static int DivisorOS;
        protected static double SumEficaciaOS;
        protected static double SumEficienciaOS;

        /*VARIABLES ObjPermanentes*/
        protected static int Indice_OPe;
        protected static int DivisorOPe;
        protected static double SumEficaciaOPe;
        protected static double SumEficienciaOPe;

        /*INDICE DEL GRID*/
        protected static int IDobj = 10;
        protected static int IDMat = 11;
        protected static int IDInt = 12;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                cls_configuracion.tipoObjetivo();

                if (!Page.IsPostBack) 
                {
                    Msg = (cls_Utilerias)Session["OpcMenu"];

                    IdEstatusObj = 0;

                    DivisorOP = 0;
                    SumEficaciaOP = 0;
                    SumEficienciaOP = 0;

                    DivisorOS = 0;
                    SumEficaciaOS = 0;
                    SumEficienciaOS = 0;

                    DivisorOPe = 0;
                    SumEficaciaOPe = 0;
                    SumEficienciaOPe = 0;                    

                    if (Msg.OpcionMenu == 0)                     
                    {
                        cls_matrizIndividual.set_ultimoMatriz_(-1);
                        lbl_Titulo_MatrizIndividual.Text = "New Matrix Individual";
                        pnlMatrizIndividualNew.Visible = true;
                        pnlFechaMatrizVigente.Visible = false;

                        DataTable DTnull = new DataTable();
                        LlenaGridOP(DTnull);
                        LlenaGridOS(DTnull);
                        LlenaGridOPe(DTnull);
                    }

                    if (Msg.OpcionMenu == 1)
                    {
                        CargaMatrizVigente("Matriz Individual Vigente");
                        //EficienciaEficaciaGral();
                    }

                    if (Msg.OpcionMenu == 2) 
                    {
                        CargaMatriz("Matriz Individual");
                    }
                }
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }

        #region MetodosGenerales
        protected void CargaMatrizVigente(string Titulo) 
        {
            try
            {
                DataTable dtMatrizVigente = new DataTable();
                dtMatrizVigente = objMatrizIndividual.verTodasMatrizIndividualVigente(cls_acceso.get_ID());

                if (dtMatrizVigente.Rows.Count > 0)
                {
                    IDMatriz = int.Parse(dtMatrizVigente.Rows[0]["IDMatriz"].ToString());

                    Msg = (cls_Utilerias)Session["OpcMenu"];
                    if (Msg.OpcionMenu != 0)
                    {
                        lbl_Titulo_MatrizIndividual.Text = Titulo;
                        lbl_FechaInicio.Text = DateTime.Parse(dtMatrizVigente.Rows[0]["f_inicio"].ToString()).ToShortDateString();
                        lbl_FechaFin.Text = DateTime.Parse(dtMatrizVigente.Rows[0]["f_final"].ToString()).ToShortDateString();

                        pnlFechaMatrizVigente.Visible = true;
                        pnlMatrizIndividualNew.Visible = false;
                    }

                    LlenaGridOP(cls_objetivo.verObjetivosEmpleado(cls_acceso.get_ID(), IDMatriz, cls_configuracion.get_tipoObjetivo_PRIORITARIO()));
                    LlenaGridOS(cls_objetivo.verObjetivosEmpleado(cls_acceso.get_ID(), IDMatriz, cls_configuracion.get_tipoObjetivo_SECUNDARIO()));
                    LlenaGridOPe(cls_objetivo.verObjetivosEmpleado(cls_acceso.get_ID(), IDMatriz, cls_configuracion.get_tipoObjetivo_PERMANENTE()));
                    EficienciaEficaciaGral();
                }
                else 
                {
                    Msg.ShowMsg(this, "No se cuenta con una Matriz Individual Vigente.");

                    cls_matrizIndividual.set_ultimoMatriz_(-1);
                    lbl_Titulo_MatrizIndividual.Text = "Matriz Individual Nueva";
                    pnlMatrizIndividualNew.Visible = true;
                    pnlFechaMatrizVigente.Visible = false;

                    DataTable DTnull = new DataTable();
                    LlenaGridOP(DTnull);
                    LlenaGridOS(DTnull);
                    LlenaGridOPe(DTnull);
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        protected void CargaMatriz(string Titulo)
        {
            try
            {
                DataTable dtMatrizVigente = new DataTable();
                dtMatrizVigente = objMatrizIndividual.verMatrizIndividual(cls_matrizIndividual.get_ultimoMatriz_(), cls_acceso.get_ID());
                IDMatriz = int.Parse(dtMatrizVigente.Rows[0]["IDMatriz"].ToString());

                lbl_Titulo_MatrizIndividual.Text = Titulo;
                lbl_FechaInicio.Text = DateTime.Parse(dtMatrizVigente.Rows[0]["f_inicio"].ToString()).ToShortDateString();
                lbl_FechaFin.Text = DateTime.Parse(dtMatrizVigente.Rows[0]["f_final"].ToString()).ToShortDateString();

                pnlFechaMatrizVigente.Visible = true;
                pnlMatrizIndividualNew.Visible = false;

                LlenaGridOP_ID(cls_objetivo.verObjetivosEmpleado(cls_acceso.get_ID(), IDMatriz, cls_configuracion.get_tipoObjetivo_PRIORITARIO()));
                LlenaGridOS_ID(cls_objetivo.verObjetivosEmpleado(cls_acceso.get_ID(), IDMatriz, cls_configuracion.get_tipoObjetivo_SECUNDARIO()));
                LlenaGridOPe_ID(cls_objetivo.verObjetivosEmpleado(cls_acceso.get_ID(), IDMatriz, cls_configuracion.get_tipoObjetivo_PERMANENTE()));
                EficienciaEficaciaGral();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public DataTable DTModificadoGrid(DataTable DTbd)
        {
            try
            {
                DataTable dt_Modificado = new DataTable();
                dt_Modificado.Columns.Add(new DataColumn("Descripcion"));
                dt_Modificado.Columns.Add(new DataColumn("f_Compromiso"));
                dt_Modificado.Columns.Add(new DataColumn("obj_Logrado"));
                dt_Modificado.Columns.Add(new DataColumn("Eficacia"));
                dt_Modificado.Columns.Add(new DataColumn("f_Cumplimiento"));
                dt_Modificado.Columns.Add(new DataColumn("Eficiencia"));
                dt_Modificado.Columns.Add(new DataColumn("SemanaAtrazo"));
                dt_Modificado.Columns.Add(new DataColumn("Area_Oportunidad"));
                dt_Modificado.Columns.Add(new DataColumn("IDobj"));
                dt_Modificado.Columns.Add(new DataColumn("IDMat"));
                dt_Modificado.Columns.Add(new DataColumn("id_integrante"));

                DataRow dr;
                if (DTbd.Rows.Count > 0) 
                {
                    for (int i = 0; i < DTbd.Rows.Count; i++)
                    {
                        dr = dt_Modificado.NewRow();
                        dr["Descripcion"] = DTbd.Rows[i]["descObjetivo"];
                        if (!string.IsNullOrEmpty(DTbd.Rows[i]["fechaCompro"].ToString()))
                        {
                            dr["f_Compromiso"] = DateTime.Parse(DTbd.Rows[i]["fechaCompro"].ToString()).ToShortDateString();
                        }
                        else 
                        {
                            dr["f_Compromiso"] = string.Empty;
                        }

                        if (int.Parse(DTbd.Rows[i]["estatusObjetivo"].ToString()) == 0)
                        {
                            dr["obj_Logrado"] = string.Empty;
                        }
                        else 
                        {
                            dr["obj_Logrado"] = "SI";
                        }
                        
                        dr["Eficacia"] = DTbd.Rows[i]["porEficacia"];

                        if (!string.IsNullOrEmpty(DTbd.Rows[i]["fechaCumpli"].ToString()))
                        {
                            dr["f_Cumplimiento"] = DateTime.Parse(DTbd.Rows[i]["fechaCumpli"].ToString()).ToShortDateString();
                        }
                        else 
                        {
                            dr["f_Cumplimiento"] = string.Empty;
                        }

                        string strEficiencia = string.Empty;
                        if (!string.IsNullOrEmpty(DTbd.Rows[i]["porEficiencia"].ToString())) 
                        {
                            if (!string.IsNullOrEmpty(DTbd.Rows[i]["fechaCumpli"].ToString()))
                            {
                                double dbEficiencia = double.Parse(DTbd.Rows[i]["porEficiencia"].ToString());
                                strEficiencia = dbEficiencia.ToString("#0.##");
                            }
                        }                        
                        dr["Eficiencia"] = strEficiencia.ToString();
                        dr["SemanaAtrazo"] = DTbd.Rows[i]["semanasAtraso"];
                        dr["Area_Oportunidad"] = DTbd.Rows[i]["areaOportunidad"];
                        dr["IDobj"] = DTbd.Rows[i]["IDobj"];
                        dr["IDMat"] = DTbd.Rows[i]["IDMat"];
                        dr["id_integrante"] = DTbd.Rows[i]["id_integrante"];
                        dt_Modificado.Rows.Add(dr);                        
                    }                    
                }

                dr = dt_Modificado.NewRow();
                dr["Descripcion"] = string.Empty;
                dr["f_Compromiso"] = string.Empty;
                dr["obj_Logrado"] = string.Empty;
                dr["Eficacia"] = string.Empty;
                dr["f_Cumplimiento"] = string.Empty;
                dr["Eficiencia"] = string.Empty;
                dr["SemanaAtrazo"] = string.Empty;
                dr["Area_Oportunidad"] = string.Empty;
                dr["IDobj"] = 0;
                dr["IDMat"] = string.Empty;
                dr["id_integrante"] = string.Empty;
                dt_Modificado.Rows.Add(dr);

                return dt_Modificado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        protected void EficienciaEficaciaGral() 
        {
            try
            {
                double SumatoriaEficacia = SumEficaciaOP + SumEficaciaOS + SumEficaciaOPe;
                int Divisor = DivisorOP + DivisorOS + DivisorOPe;
                double EficaciGral = SumatoriaEficacia / Divisor;
                double SumatoriaEficiencia = SumEficienciaOP + SumEficienciaOS + SumEficienciaOPe;
                double EficacienciaGral = SumatoriaEficiencia / ((gv_ObjetivosPrioritarios.Rows.Count -1) +
                                                                 (gv_ObjetivosSecundarios.Rows.Count -1) +
                                                                 (gv_ObjetivosPermanentes.Rows.Count -1));

                if (EficaciGral > 0 && EficacienciaGral > 0)
                {
                    double EfectividadGral = (EficaciGral + EficacienciaGral) / 2;
                    lbl_Porc_Efectividad.Text = EfectividadGral.ToString("##.##");
                    lbl_Porc_Eficacia.Text = EficaciGral.ToString("##.##");
                    lbl_Porc_Eficiencia.Text = EficacienciaGral.ToString("##.##");
                }
                else 
                {
                    lbl_Porc_Efectividad.Text = "0.0";
                    lbl_Porc_Eficacia.Text = "0.0";
                    lbl_Porc_Eficiencia.Text = "0.0";
                }
                                
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        protected string SemanasAtrazo(string FechaCompromiso, string FechaCumplimiento)
        {
            try
            {
                string Resp = string.Empty;

                if (!string.IsNullOrEmpty(FechaCompromiso) && !string.IsNullOrEmpty(FechaCumplimiento))
                {
                    DateTime dtFecha1 = DateTime.Parse(FechaCompromiso);
                    DateTime dtFecha2 = DateTime.Parse(FechaCumplimiento);
                    decimal Dias = dtFecha1.DayOfYear - dtFecha2.DayOfYear;
                    int SemanasAtrazo = int.Parse(Math.Ceiling(Dias / 7).ToString());
                    Resp = SemanasAtrazo.ToString();
                }

                return Resp;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        protected string Eficiencia(string FechaCompromiso, string FechaCumplimiento)
        {
            try
            {
                string Resp = string.Empty;

                if (!string.IsNullOrEmpty(FechaCompromiso) && !string.IsNullOrEmpty(FechaCumplimiento))
                {
                    DateTime dtFecha1 = DateTime.Parse(FechaCompromiso);
                    DateTime dtFecha2 = DateTime.Parse(FechaCumplimiento);
                    decimal Dias = dtFecha1.DayOfYear - dtFecha2.DayOfYear;
                    decimal Eficiencia = ((Dias / 7) * 100) + 100;
                    Resp = Eficiencia.ToString("#0.##");
                }

                return Resp;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        protected string Eficacia(string FechaCompromiso, string FechaCumplimiento)
        {
            try
            {
                string Resp = string.Empty;

                if (!string.IsNullOrEmpty(FechaCompromiso) && !string.IsNullOrEmpty(FechaCumplimiento))
                {
                    Resp = "100";
                }

                return Resp;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        protected string ObjLogrado(string FechaCompromiso, string FechaCumplimiento)
        {
            try
            {
                string Resp = string.Empty;

                if (!string.IsNullOrEmpty(FechaCompromiso) && !string.IsNullOrEmpty(FechaCumplimiento))
                {
                    Resp = "SI";
                    IdEstatusObj = 1;
                }
                else 
                {
                    IdEstatusObj = 0;
                }

                return Resp;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        protected void txt_FechaInicioMatrizNew_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_FechaInicioMatrizNew.Text.Trim()))
                {
                    if (!string.IsNullOrEmpty(txt_FechaFinMatrizNew.Text.Trim()))
                    {
                        int Resp = 0;
                        if (cls_matrizIndividual.get_ultimoMatriz_() == -1)
                        {                            
                            Resp = objMatrizIndividual.crearMatrizindividual(cls_acceso.get_ID(),
                                                                             cls_equipo.get_IDJefeEquipo(),
                                                                             cls_equipo.get_IDEquipo(),
                                                                             string.Format("{0:dd}/{0:MM}/{0:yyyy}", DateTime.Now),
                                                                             txt_FechaInicioMatrizNew.Text,
                                                                             txt_FechaFinMatrizNew.Text);
                        }
                        else 
                        {
                            Resp = objMatrizIndividual.modificaMatrizindividual(cls_matrizIndividual.get_ultimoMatriz_(),
                                                                                txt_FechaInicioMatrizNew.Text,
                                                                                txt_FechaFinMatrizNew.Text);
                        }

                        CargaMatrizVigente("Matriz Individual Nueva");
                    }                    
                }
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }

        protected void txt_FechaFinMatrizNew_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_FechaInicioMatrizNew.Text.Trim()))
                {
                    if (!string.IsNullOrEmpty(txt_FechaFinMatrizNew.Text.Trim()))
                    {
                        int Resp = 0;
                        if (cls_matrizIndividual.get_ultimoMatriz_() == -1)
                        {
                            Resp = objMatrizIndividual.crearMatrizindividual(cls_acceso.get_ID(),
                                                                             cls_equipo.get_IDJefeEquipo(),
                                                                             cls_equipo.get_IDEquipo(),
                                                                             string.Format("{0:dd}/{0:MM}/{0:yyyy}", DateTime.Now),
                                                                             txt_FechaInicioMatrizNew.Text,
                                                                             txt_FechaFinMatrizNew.Text);
                        }
                        else
                        {
                            Resp = objMatrizIndividual.modificaMatrizindividual(cls_matrizIndividual.get_ultimoMatriz_(),
                                                                                txt_FechaInicioMatrizNew.Text,
                                                                                txt_FechaFinMatrizNew.Text);
                        }
                        CargaMatrizVigente("Matriz Individual Nueva");
                    }
                }
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }
        
        #endregion

        #region gv_ObjetivosPrioritarios

        protected void LlenaGridOP(DataTable DTbd) 
        {
            try 
            {
                gv_ObjetivosPrioritarios.Columns[IDobj].Visible = true;
                gv_ObjetivosPrioritarios.Columns[IDMat].Visible = true;
                gv_ObjetivosPrioritarios.Columns[IDInt].Visible = true;
                gv_ObjetivosPrioritarios.DataSource = DTModificadoGrid(DTbd);
                gv_ObjetivosPrioritarios.DataBind();
                gv_ObjetivosPrioritarios.Columns[IDobj].Visible = false;
                gv_ObjetivosPrioritarios.Columns[IDMat].Visible = false;
                gv_ObjetivosPrioritarios.Columns[IDInt].Visible = false;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        protected void LlenaGridOP_ID(DataTable DTbd)
        {
            try
            {
                gv_ObjetivosPrioritarios.Columns[0].Visible = true;
                gv_ObjetivosPrioritarios.Columns[IDobj].Visible = true;
                gv_ObjetivosPrioritarios.Columns[IDMat].Visible = true;
                gv_ObjetivosPrioritarios.Columns[IDInt].Visible = true;
                gv_ObjetivosPrioritarios.DataSource = DTModificadoGrid(DTbd);
                gv_ObjetivosPrioritarios.DataBind();
                gv_ObjetivosPrioritarios.Columns[IDobj].Visible = false;
                gv_ObjetivosPrioritarios.Columns[IDMat].Visible = false;
                gv_ObjetivosPrioritarios.Columns[IDInt].Visible = false;
                gv_ObjetivosPrioritarios.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        protected void btn_EditarOP_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                DivisorOP = 0;
                SumEficaciaOP = 0;
                SumEficienciaOP = 0;

                GridViewRow gRow;
                ImageButton btn_Editar;
                btn_Editar = (ImageButton)sender;
                gRow = (GridViewRow)btn_Editar.Parent.Parent;
                Indice_OP = gRow.DataItemIndex;

                ((ImageButton)gRow.FindControl("btn_AceptarOP")).Visible = true;
                ((ImageButton)gRow.FindControl("btn_CancelarOP")).Visible = true;
                Msg = (cls_Utilerias)Session["OpcMenu"];
                if (Msg.OpcionMenu == 0) 
                {
                    ((TextBox)gRow.FindControl("txt_Desc")).Visible = true;
                    ((TextBox)gRow.FindControl("txt_Desc")).Text = ((Label)gRow.FindControl("lbl_Desc")).Text;

                    ((TextBox)gRow.FindControl("txt_fCompromisoOP")).Visible = true;
                    ((TextBox)gRow.FindControl("txt_fCompromisoOP")).Text = ((Label)gRow.FindControl("lbl_fCompromiso")).Text;
                    ((ImageButton)gRow.FindControl("Fecha1")).Visible = true;

                    ((Label)gRow.FindControl("lbl_Desc")).Visible = false;
                    ((Label)gRow.FindControl("lbl_fCompromiso")).Visible = false;
                }
                else
                {
                    if (string.IsNullOrEmpty(((Label)gRow.FindControl("lbl_Desc")).Text.Trim()))
                    {
                        ((TextBox)gRow.FindControl("txt_Desc")).Visible = true;
                        ((TextBox)gRow.FindControl("txt_Desc")).Text = ((Label)gRow.FindControl("lbl_Desc")).Text;

                        ((TextBox)gRow.FindControl("txt_fCompromisoOP")).Visible = true;
                        ((TextBox)gRow.FindControl("txt_fCompromisoOP")).Text = ((Label)gRow.FindControl("lbl_fCompromiso")).Text;
                        ((ImageButton)gRow.FindControl("Fecha1")).Visible = true;

                        ((Label)gRow.FindControl("lbl_Desc")).Visible = false;
                        ((Label)gRow.FindControl("lbl_fCompromiso")).Visible = false;
                    }
                    else
                    {
                        ((TextBox)gRow.FindControl("txt_fCumplimientoOP")).Visible = true;
                        ((TextBox)gRow.FindControl("txt_fCumplimientoOP")).Text = ((Label)gRow.FindControl("lbl_fCumplimiento")).Text;
                        ((ImageButton)gRow.FindControl("Fecha2")).Visible = true;

                        ((TextBox)gRow.FindControl("txt_areasOp")).Visible = true;
                        ((TextBox)gRow.FindControl("txt_areasOp")).Text = ((Label)gRow.FindControl("lbl_areasOp")).Text;

                        ((Label)gRow.FindControl("lbl_fCumplimiento")).Visible = false;
                        ((Label)gRow.FindControl("lbl_areasOp")).Visible = false;
                    }
                }

                ((ImageButton)gRow.FindControl("btn_EditarOP")).Visible = false;
                
                
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }

        protected void btn_AceptarOP_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                GridViewRow gRow;
                ImageButton btn_Aceptar;
                btn_Aceptar = (ImageButton)sender;
                gRow = (GridViewRow)btn_Aceptar.Parent.Parent;

                int Resp = 0;
                if (int.Parse(gv_ObjetivosPrioritarios.Rows[Indice_OP].Cells[10].Text) == 0)
                {
                    if (!string.IsNullOrEmpty(((TextBox)gRow.FindControl("txt_Desc")).Text.Trim()))
                    {
                        if (!string.IsNullOrEmpty(((TextBox)gRow.FindControl("txt_fCompromisoOP")).Text.Trim()))
                        {
                            Resp = objObjetivos.agregarObjetivo(IDMatriz,
                                                         cls_acceso.get_ID(),//ID_Empleado
                                                         1 ,
                                                         0, 0, 0, 0,
                                                         ((TextBox)gRow.FindControl("txt_Desc")).Text,
                                                         string.Empty,
                                                         ((TextBox)gRow.FindControl("txt_fCompromisoOP")).Text,
                                                         cls_equipo.get_IDEquipo());
                        }
                        else 
                        {
                            Msg.ShowMsg(this, "Falta la fecha compromiso.");
                        }
                    }
                    else 
                    {
                        Msg.ShowMsg(this, "Falta un la descripcion del objetivo.");
                    }
                }                                   
                else 
                {
                    Msg = (cls_Utilerias)Session["OpcMenu"];
                    if (Msg.OpcionMenu == 0 && cls_matrizIndividual.get_ultimoMatriz_() != -1)
                    {
                        Resp = objObjetivos.modificarObjetivo(cls_matrizIndividual.get_ultimoMatriz_(),
                                                              int.Parse(gv_ObjetivosPrioritarios.Rows[Indice_OP].Cells[10].Text),
                                                              ((TextBox)gRow.FindControl("txt_Desc")).Text,
                                                              ((TextBox)gRow.FindControl("txt_fCompromisoOP")).Text,
                                                              cls_acceso.get_ID(),
                                                              cls_equipo.get_IDEquipo());
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(((TextBox)gRow.FindControl("txt_fCumplimientoOP")).Text.Trim()))
                        {
                            Resp = objObjetivos.cerrarObjetivo(int.Parse(gv_ObjetivosPrioritarios.Rows[Indice_OP].Cells[10].Text),
                                                        cls_equipo.get_IDEquipo(),
                                                        cls_acceso.get_ID(),
                                                        IdEstatusObj,
                                                        decimal.Parse(((Label)gRow.FindControl("lbl_rowEficacia")).Text),
                                                        decimal.Parse(((Label)gRow.FindControl("lbl_rowEficencia")).Text),
                                                        int.Parse(((Label)gRow.FindControl("lbl_SemanaAtrazo")).Text),
                                                        ((TextBox)gRow.FindControl("txt_areasOp")).Text,
                                                        ((TextBox)gRow.FindControl("txt_fCumplimientoOP")).Text);
                        }
                        else
                        {
                            Msg.ShowMsg(this, "Falta la fecha cumplimiento.");
                        }
                    }
                }

                if (Resp == 1)
                {
                    //Msg.ShowMsg(this, "Se guardo con exito");
                    //LlenaGridOP(cls_objetivo.verObjetivosEmpleado(1, IDMatriz, 1));  
                    LlenaGridOP(cls_objetivo.verObjetivosEmpleado(cls_acceso.get_ID(), IDMatriz, cls_configuracion.get_tipoObjetivo_PRIORITARIO()));                    
                }
                else 
                {
                    Msg.ShowMsg(this, "Error :" + Resp);
                }                
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }

        protected void btn_CancelarOP_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                GridViewRow gRow;
                ImageButton btn_Aceptar;
                btn_Aceptar = (ImageButton)sender;
                gRow = (GridViewRow)btn_Aceptar.Parent.Parent;

                ((ImageButton)gRow.FindControl("btn_EditarOP")).Visible = true;

                ((TextBox)gRow.FindControl("txt_Desc")).Visible = false;
                ((TextBox)gRow.FindControl("txt_Desc")).Text = string.Empty;

                ((TextBox)gRow.FindControl("txt_fCompromisoOP")).Visible = false;
                ((TextBox)gRow.FindControl("txt_fCompromisoOP")).Text = string.Empty;
                ((ImageButton)gRow.FindControl("Fecha1")).Visible = false;
                string FechaCompromiso = ((Label)gRow.FindControl("lbl_fCompromiso")).Text;

                ((TextBox)gRow.FindControl("txt_fCumplimientoOP")).Visible = false;
                ((TextBox)gRow.FindControl("txt_fCumplimientoOP")).Text = string.Empty;
                ((ImageButton)gRow.FindControl("Fecha2")).Visible = false;
                string FechaCumplimiento = ((Label)gRow.FindControl("lbl_fCumplimiento")).Text;

                ((TextBox)gRow.FindControl("txt_areasOp")).Visible = false;
                ((TextBox)gRow.FindControl("txt_areasOp")).Text = string.Empty;

                ((ImageButton)gRow.FindControl("btn_AceptarOP")).Visible = false;
                ((ImageButton)gRow.FindControl("btn_CancelarOP")).Visible = false;
                ((Label)gRow.FindControl("lbl_Desc")).Visible = true;
                ((Label)gRow.FindControl("lbl_fCompromiso")).Visible = true;
                ((Label)gRow.FindControl("lbl_fCumplimiento")).Visible = true;
                ((Label)gRow.FindControl("lbl_areasOp")).Visible = true;

                ((Label)gRow.FindControl("lbl_objLogrado")).Text = ObjLogrado(FechaCompromiso,FechaCumplimiento);
                ((Label)gRow.FindControl("lbl_SemanaAtrazo")).Text = SemanasAtrazo(FechaCompromiso, FechaCumplimiento);
                ((Label)gRow.FindControl("lbl_rowEficencia")).Text = Eficiencia(FechaCompromiso, FechaCumplimiento);
                ((Label)gRow.FindControl("lbl_rowEficacia")).Text = Eficacia(FechaCompromiso, FechaCumplimiento);
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }

        protected void txt_fCompromisoOP_TextChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gRow;
                TextBox txt_fCompromiso;
                txt_fCompromiso = (TextBox)sender;
                gRow = (GridViewRow)txt_fCompromiso.Parent.Parent;
                
                string FechaCompromiso = ((TextBox)gRow.FindControl("txt_fCompromisoOP")).Text;
                string FechaCumplimiento = ((TextBox)gRow.FindControl("txt_fCumplimientoOP")).Text;

                ((Label)gRow.FindControl("lbl_objLogrado")).Text = ObjLogrado(FechaCompromiso,FechaCumplimiento);
                ((Label)gRow.FindControl("lbl_SemanaAtrazo")).Text = SemanasAtrazo(FechaCompromiso, FechaCumplimiento);
                ((Label)gRow.FindControl("lbl_rowEficacia")).Text = Eficacia(FechaCompromiso, FechaCumplimiento);
                ((Label)gRow.FindControl("lbl_rowEficencia")).Text = Eficiencia(FechaCompromiso, FechaCumplimiento);

            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }

        protected void txt_fCumplimientoOP_TextChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gRow;
                TextBox txt_fCumplimiento;
                txt_fCumplimiento = (TextBox)sender;
                gRow = (GridViewRow)txt_fCumplimiento.Parent.Parent;


                //string FechaCompromiso = ((TextBox)gRow.FindControl("txt_fCompromisoOP")).Text;
                string FechaCompromiso = ((Label)gRow.FindControl("lbl_fCompromiso")).Text;
                string FechaCumplimiento = ((TextBox)gRow.FindControl("txt_fCumplimientoOP")).Text.Trim();

                ((Label)gRow.FindControl("lbl_objLogrado")).Text = ObjLogrado(FechaCompromiso,FechaCumplimiento);
                ((Label)gRow.FindControl("lbl_SemanaAtrazo")).Text = SemanasAtrazo(FechaCompromiso, FechaCumplimiento);
                ((Label)gRow.FindControl("lbl_rowEficacia")).Text = Eficacia(FechaCompromiso, FechaCumplimiento);
                ((Label)gRow.FindControl("lbl_rowEficencia")).Text = Eficiencia(FechaCompromiso, FechaCumplimiento);
                
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }

        protected void gv_ObjetivosPrioritarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lbl_Eficacia = (Label)e.Row.Cells[6].FindControl("lbl_rowEficencia");
                    Label lbl_Eficiencia = (Label)e.Row.Cells[4].FindControl("lbl_rowEficacia");
                    //int IdEstatusObj = int.Parse(e.Row.Cells[IDobj].Text);

                    if (!string.IsNullOrEmpty(lbl_Eficacia.Text))
                    {
                        SumEficaciaOP += double.Parse(lbl_Eficacia.Text);
                        DivisorOP += 1;
                    }
                    if (lbl_Eficiencia != null)
                    {
                        if (!string.IsNullOrEmpty(lbl_Eficiencia.Text))
                        {
                            SumEficienciaOP += double.Parse(lbl_Eficiencia.Text);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }

        protected void gv_ObjetivosPrioritarios_RowCreated(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    GridViewRow row = new GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Normal);
                    Table t = (Table)gv_ObjetivosPrioritarios.Controls[0];
                    //int IdEstatusObj = int.Parse(e.Row.Cells[IDobj].Text);

                    TableCell FileDate = new TableHeaderCell();
                    FileDate.ColumnSpan = 1;
                    row.Cells.Add(FileDate);

                    TableCell cell = new TableHeaderCell();
                    cell.ColumnSpan = 9;
                    cell.Text = "Primary";
                    cell.CssClass = "headerTitleGrid";
                    row.Cells.Add(cell);

                    t.Rows.AddAt(0, row);
                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label PromedioEficiencia = (Label)e.Row.FindControl("lbl_promedioEficencia");
                    Label PromedioEficacia = (Label)e.Row.FindControl("lbl_promedioEficacia");

                    if (PromedioEficiencia != null)
                    {
                        if (DivisorOP > 0)
                        {
                            double Resultado = SumEficaciaOP / DivisorOP;
                            PromedioEficiencia.Text = Resultado.ToString("#0.##") + "%";
                        }
                        else
                        {
                            PromedioEficiencia.Text = string.Empty;
                        }

                    }
                    if (PromedioEficacia != null)
                    {
                        if (SumEficaciaOP >= 0)
                        {
                            double Resultado = SumEficienciaOP / (gv_ObjetivosPrioritarios.Rows.Count - 1);
                            PromedioEficacia.Text = Resultado.ToString("#0.##") + "%";
                        }
                        else
                        {
                            PromedioEficacia.Text = string.Empty;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }
 
        #endregion

        #region gv_ObjetivosSecundarios
        protected void LlenaGridOS(DataTable DTbd) 
        {
            try
            {
                gv_ObjetivosSecundarios.Columns[IDobj].Visible = true;
                gv_ObjetivosSecundarios.Columns[IDMat].Visible = true;
                gv_ObjetivosSecundarios.Columns[IDInt].Visible = true;
                gv_ObjetivosSecundarios.DataSource = DTModificadoGrid(DTbd); ;
                gv_ObjetivosSecundarios.DataBind();
                gv_ObjetivosSecundarios.Columns[IDobj].Visible = false;
                gv_ObjetivosSecundarios.Columns[IDMat].Visible = false;
                gv_ObjetivosSecundarios.Columns[IDInt].Visible = false;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        protected void LlenaGridOS_ID(DataTable DTbd)
        {
            try
            {
                gv_ObjetivosSecundarios.Columns[0].Visible = true;
                gv_ObjetivosSecundarios.Columns[IDobj].Visible = true;
                gv_ObjetivosSecundarios.Columns[IDMat].Visible = true;
                gv_ObjetivosSecundarios.Columns[IDInt].Visible = true;
                gv_ObjetivosSecundarios.DataSource = DTModificadoGrid(DTbd); ;
                gv_ObjetivosSecundarios.DataBind();
                gv_ObjetivosSecundarios.Columns[IDobj].Visible = false;
                gv_ObjetivosSecundarios.Columns[IDMat].Visible = false;
                gv_ObjetivosSecundarios.Columns[IDInt].Visible = false;
                gv_ObjetivosSecundarios.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {


                throw new Exception(ex.Message);
            }
        }
        protected void btn_EditarOS_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                DivisorOS = 0;
                SumEficaciaOS = 0;
                SumEficienciaOS = 0;

                GridViewRow gRow;
                ImageButton btn_Editar;
                btn_Editar = (ImageButton)sender;
                gRow = (GridViewRow)btn_Editar.Parent.Parent;
                Indice_OS = gRow.DataItemIndex;

                ((ImageButton)gRow.FindControl("btn_AceptarOS")).Visible = true;
                ((ImageButton)gRow.FindControl("btn_CancelarOS")).Visible = true;
                
                Msg = (cls_Utilerias)Session["OpcMenu"];
                if (Msg.OpcionMenu == 0)
                {
                    ((TextBox)gRow.FindControl("txt_Desc")).Visible = true;
                    ((TextBox)gRow.FindControl("txt_Desc")).Text = ((Label)gRow.FindControl("lbl_Desc")).Text;

                    ((TextBox)gRow.FindControl("txt_fCompromisoOS")).Visible = true;
                    ((TextBox)gRow.FindControl("txt_fCompromisoOS")).Text = ((Label)gRow.FindControl("lbl_fCompromiso")).Text;
                    ((ImageButton)gRow.FindControl("Fecha1")).Visible = true;

                    ((Label)gRow.FindControl("lbl_Desc")).Visible = false;
                    ((Label)gRow.FindControl("lbl_fCompromiso")).Visible = false;
                }
                else
                {
                    if (string.IsNullOrEmpty(((Label)gRow.FindControl("lbl_Desc")).Text.Trim()))
                    {
                        ((TextBox)gRow.FindControl("txt_Desc")).Visible = true;
                        ((TextBox)gRow.FindControl("txt_Desc")).Text = ((Label)gRow.FindControl("lbl_Desc")).Text;

                        ((TextBox)gRow.FindControl("txt_fCompromisoOS")).Visible = true;
                        ((TextBox)gRow.FindControl("txt_fCompromisoOS")).Text = ((Label)gRow.FindControl("lbl_fCompromiso")).Text;
                        ((ImageButton)gRow.FindControl("Fecha1")).Visible = true;

                        ((Label)gRow.FindControl("lbl_Desc")).Visible = false;
                        ((Label)gRow.FindControl("lbl_fCompromiso")).Visible = false;
                    }
                    else
                    {
                        ((TextBox)gRow.FindControl("txt_fCumplimientoOS")).Visible = true;
                        ((TextBox)gRow.FindControl("txt_fCumplimientoOS")).Text = ((Label)gRow.FindControl("lbl_fCumplimiento")).Text;
                        ((ImageButton)gRow.FindControl("Fecha2")).Visible = true;

                        ((TextBox)gRow.FindControl("txt_areasOp")).Visible = true;
                        ((TextBox)gRow.FindControl("txt_areasOp")).Text = ((Label)gRow.FindControl("lbl_areasOp")).Text;

                        ((Label)gRow.FindControl("lbl_fCumplimiento")).Visible = false;
                        ((Label)gRow.FindControl("lbl_areasOp")).Visible = false;
                    }
                }

                ((ImageButton)gRow.FindControl("btn_EditarOS")).Visible = false;
                                
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }

        protected void btn_AceptarOS_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                GridViewRow gRow;
                ImageButton btn_Aceptar;
                btn_Aceptar = (ImageButton)sender;
                gRow = (GridViewRow)btn_Aceptar.Parent.Parent;
                
                int Resp = 0;
                if (int.Parse(gv_ObjetivosSecundarios.Rows[Indice_OS].Cells[10].Text) == 0)
                {
                    if (!string.IsNullOrEmpty(((TextBox)gRow.FindControl("txt_Desc")).Text.Trim()))
                    {
                        if (!string.IsNullOrEmpty(((TextBox)gRow.FindControl("txt_fCompromisoOS")).Text.Trim()))
                        {
                            Resp = objObjetivos.agregarObjetivo(IDMatriz,//ID_Matriz
                                                 cls_acceso.get_ID(),//ID_Empleado
                                                 2,
                                                 0, 0, 0, 0,
                                                 ((TextBox)gRow.FindControl("txt_Desc")).Text,
                                                 string.Empty,
                                                 ((TextBox)gRow.FindControl("txt_fCompromisoOS")).Text,
                                                 cls_equipo.get_IDEquipo());
                        }
                        else
                        {
                            Msg.ShowMsg(this, "Falta la fecha compromiso.");
                        }
                    }
                    else
                    {
                        Msg.ShowMsg(this, "Falta un la descripcion del objetivo.");
                    }                    
                }
                else
                {
                    Msg = (cls_Utilerias)Session["OpcMenu"];
                    if (Msg.OpcionMenu == 0 && cls_matrizIndividual.get_ultimoMatriz_() != -1)
                    {
                        Resp = objObjetivos.modificarObjetivo(cls_matrizIndividual.get_ultimoMatriz_(),
                                                             int.Parse(gv_ObjetivosSecundarios.Rows[Indice_OS].Cells[10].Text),
                                                             ((TextBox)gRow.FindControl("txt_Desc")).Text,
                                                             ((TextBox)gRow.FindControl("txt_fCompromisoOS")).Text,
                                                             cls_acceso.get_ID(),
                                                             cls_equipo.get_IDEquipo());
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(((TextBox)gRow.FindControl("txt_fCumplimientoOS")).Text.Trim()))
                        {
                            Resp = objObjetivos.cerrarObjetivo(int.Parse(gv_ObjetivosSecundarios.Rows[Indice_OS].Cells[10].Text),
                                                        cls_equipo.get_IDEquipo(),
                                                        cls_acceso.get_ID(),
                                                        IdEstatusObj,//EstatusObjetivo
                                                        decimal.Parse(((Label)gRow.FindControl("lbl_rowEficacia")).Text),
                                                        decimal.Parse(((Label)gRow.FindControl("lbl_rowEficencia")).Text),
                                                        int.Parse(((Label)gRow.FindControl("lbl_SemanaAtrazo")).Text),
                                                        ((TextBox)gRow.FindControl("txt_areasOp")).Text,
                                                        ((TextBox)gRow.FindControl("txt_fCumplimientoOS")).Text);
                        }
                        else
                        {
                            Msg.ShowMsg(this, "Falta la fecha cumplimiento.");
                        }
                    }
                }

                if (Resp == 1)
                {
                    //Msg.ShowMsg(this, "Se guardo con exito");
                    //LlenaGridOS(cls_objetivo.verObjetivosEmpleado(1, IDMatriz, 2));
                    LlenaGridOS(cls_objetivo.verObjetivosEmpleado(cls_acceso.get_ID(), IDMatriz, cls_configuracion.get_tipoObjetivo_SECUNDARIO()));
                }
                else
                {
                    Msg.ShowMsg(this, "Erro :" + Resp);
                }                
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }

        protected void btn_CancelarOS_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                GridViewRow gRow;
                ImageButton btn_Aceptar;
                btn_Aceptar = (ImageButton)sender;
                gRow = (GridViewRow)btn_Aceptar.Parent.Parent;

                ((ImageButton)gRow.FindControl("btn_EditarOS")).Visible = true;

                ((TextBox)gRow.FindControl("txt_Desc")).Visible = false;
                ((TextBox)gRow.FindControl("txt_Desc")).Text = string.Empty;

                ((TextBox)gRow.FindControl("txt_fCompromisoOS")).Visible = false;
                ((TextBox)gRow.FindControl("txt_fCompromisoOS")).Text = string.Empty;
                ((ImageButton)gRow.FindControl("Fecha1")).Visible = false;
                string FechaCompromiso = ((Label)gRow.FindControl("lbl_fCompromiso")).Text;

                ((TextBox)gRow.FindControl("txt_fCumplimientoOS")).Visible = false;
                ((TextBox)gRow.FindControl("txt_fCumplimientoOS")).Text = string.Empty;
                ((ImageButton)gRow.FindControl("Fecha2")).Visible = false;
                string FechaCumplimiento = ((Label)gRow.FindControl("lbl_fCumplimiento")).Text;

                ((TextBox)gRow.FindControl("txt_areasOp")).Visible = false;
                ((TextBox)gRow.FindControl("txt_areasOp")).Text = string.Empty;

                ((ImageButton)gRow.FindControl("btn_AceptarOS")).Visible = false;
                ((ImageButton)gRow.FindControl("btn_CancelarOS")).Visible = false;
                ((Label)gRow.FindControl("lbl_Desc")).Visible = true;
                ((Label)gRow.FindControl("lbl_fCompromiso")).Visible = true;
                ((Label)gRow.FindControl("lbl_fCumplimiento")).Visible = true;
                ((Label)gRow.FindControl("lbl_areasOp")).Visible = true;

                ((Label)gRow.FindControl("lbl_objLogrado")).Text = ObjLogrado(FechaCompromiso, FechaCumplimiento);
                ((Label)gRow.FindControl("lbl_SemanaAtrazo")).Text = SemanasAtrazo(FechaCompromiso, FechaCumplimiento);
                ((Label)gRow.FindControl("lbl_rowEficencia")).Text = Eficiencia(FechaCompromiso, FechaCumplimiento);
                ((Label)gRow.FindControl("lbl_rowEficacia")).Text = Eficacia(FechaCompromiso, FechaCumplimiento);
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }

        protected void txt_fCompromisoOS_TextChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gRow;
                TextBox txt_fCompromiso;
                txt_fCompromiso = (TextBox)sender;
                gRow = (GridViewRow)txt_fCompromiso.Parent.Parent;

                string FechaCompromiso = ((TextBox)gRow.FindControl("txt_fCompromisoOS")).Text;
                string FechaCumplimiento = ((TextBox)gRow.FindControl("txt_fCumplimientoOS")).Text;

                ((Label)gRow.FindControl("lbl_objLogrado")).Text = ObjLogrado(FechaCompromiso, FechaCumplimiento);
                ((Label)gRow.FindControl("lbl_SemanaAtrazo")).Text = SemanasAtrazo(FechaCompromiso, FechaCumplimiento);
                ((Label)gRow.FindControl("lbl_rowEficacia")).Text = Eficacia(FechaCompromiso, FechaCumplimiento);
                ((Label)gRow.FindControl("lbl_rowEficencia")).Text = Eficiencia(FechaCompromiso, FechaCumplimiento);

            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }

        protected void txt_fCumplimientoOS_TextChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gRow;
                TextBox txt_fCumplimiento;
                txt_fCumplimiento = (TextBox)sender;
                gRow = (GridViewRow)txt_fCumplimiento.Parent.Parent;


                string FechaCompromiso = ((Label)gRow.FindControl("lbl_fCompromiso")).Text;
                string FechaCumplimiento = ((TextBox)gRow.FindControl("txt_fCumplimientoOS")).Text.Trim();

                ((Label)gRow.FindControl("lbl_objLogrado")).Text = ObjLogrado(FechaCompromiso, FechaCumplimiento);
                ((Label)gRow.FindControl("lbl_SemanaAtrazo")).Text = SemanasAtrazo(FechaCompromiso, FechaCumplimiento);
                ((Label)gRow.FindControl("lbl_rowEficacia")).Text = Eficacia(FechaCompromiso, FechaCumplimiento);
                ((Label)gRow.FindControl("lbl_rowEficencia")).Text = Eficiencia(FechaCompromiso, FechaCumplimiento);

            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }

        protected void gv_ObjetivosSecundarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lbl_Eficacia = (Label)e.Row.Cells[6].FindControl("lbl_rowEficencia");
                    Label lbl_Eficiencia = (Label)e.Row.Cells[4].FindControl("lbl_rowEficacia");

                    if (!string.IsNullOrEmpty(lbl_Eficacia.Text))
                    {
                        SumEficaciaOS += double.Parse(lbl_Eficacia.Text);
                        DivisorOS += 1;
                    }
                    if (lbl_Eficiencia != null)
                    {
                        if (!string.IsNullOrEmpty(lbl_Eficiencia.Text))
                        {
                            SumEficienciaOS += double.Parse(lbl_Eficiencia.Text);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }

        protected void gv_ObjetivosSecundarios_RowCreated(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    GridViewRow row = new GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Normal);
                    Table t = (Table)gv_ObjetivosSecundarios.Controls[0];

                    TableCell FileDate = new TableHeaderCell();
                    FileDate.ColumnSpan = 1;
                    row.Cells.Add(FileDate);

                    TableCell cell = new TableHeaderCell();
                    cell.ColumnSpan = 9;
                    cell.Text = "Secondary";
                    cell.CssClass = "headerTitleGrid";
                    row.Cells.Add(cell);

                    t.Rows.AddAt(0, row);
                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label PromedioEficiencia = (Label)e.Row.FindControl("lbl_promedioEficencia");
                    Label PromedioEficacia = (Label)e.Row.FindControl("lbl_promedioEficacia");

                    if (PromedioEficiencia != null)
                    {
                        if (DivisorOS > 0)
                        {
                            double Resultado = SumEficaciaOS / DivisorOS;
                            PromedioEficiencia.Text = Resultado.ToString("#0.##") + "%";
                        }
                        else
                        {
                            PromedioEficiencia.Text = string.Empty;
                        }

                    }
                    if (PromedioEficacia != null)
                    {
                        if (SumEficaciaOS >= 0)
                        {
                            double Resultado = SumEficienciaOS / (gv_ObjetivosSecundarios.Rows.Count - 1);
                            PromedioEficacia.Text = Resultado.ToString("#0.##") + "%";
                        }
                        else
                        {
                            PromedioEficacia.Text = string.Empty;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }
        #endregion

        #region gv_ObjetivosPermanenstes
        protected void LlenaGridOPe(DataTable DTbd)
        {
            try
            {
                gv_ObjetivosPermanentes.Columns[IDobj].Visible = true;
                gv_ObjetivosPermanentes.Columns[IDMat].Visible = true;
                gv_ObjetivosPermanentes.Columns[IDInt].Visible = true;
                gv_ObjetivosPermanentes.DataSource = DTModificadoGrid(DTbd); ;
                gv_ObjetivosPermanentes.DataBind();
                gv_ObjetivosPermanentes.Columns[IDobj].Visible = false;
                gv_ObjetivosPermanentes.Columns[IDMat].Visible = false;
                gv_ObjetivosPermanentes.Columns[IDInt].Visible = false;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        protected void LlenaGridOPe_ID(DataTable DTbd)
        {
            try
            {
                gv_ObjetivosPermanentes.Columns[0].Visible = true;
                gv_ObjetivosPermanentes.Columns[IDobj].Visible = true;
                gv_ObjetivosPermanentes.Columns[IDMat].Visible = true;
                gv_ObjetivosPermanentes.Columns[IDInt].Visible = true;
                gv_ObjetivosPermanentes.DataSource = DTModificadoGrid(DTbd); ;
                gv_ObjetivosPermanentes.DataBind();
                gv_ObjetivosPermanentes.Columns[IDobj].Visible = false;
                gv_ObjetivosPermanentes.Columns[IDMat].Visible = false;
                gv_ObjetivosPermanentes.Columns[IDInt].Visible = false;
                gv_ObjetivosPermanentes.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        protected void btn_EditarOPe_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                DivisorOPe = 0;
                SumEficaciaOPe = 0;
                SumEficienciaOPe = 0;

                GridViewRow gRow;
                ImageButton btn_Editar;
                btn_Editar = (ImageButton)sender;
                gRow = (GridViewRow)btn_Editar.Parent.Parent;
                Indice_OPe = gRow.DataItemIndex;

                ((ImageButton)gRow.FindControl("btn_AceptarOPe")).Visible = true;
                ((ImageButton)gRow.FindControl("btn_CancelarOPe")).Visible = true;

                Msg = (cls_Utilerias)Session["OpcMenu"];
                if (Msg.OpcionMenu == 0)
                {
                    ((TextBox)gRow.FindControl("txt_Desc")).Visible = true;
                    ((TextBox)gRow.FindControl("txt_Desc")).Text = ((Label)gRow.FindControl("lbl_Desc")).Text;

                    ((TextBox)gRow.FindControl("txt_fCompromisoOpe")).Visible = true;
                    ((TextBox)gRow.FindControl("txt_fCompromisoOPe")).Text = ((Label)gRow.FindControl("lbl_fCompromiso")).Text;
                    ((ImageButton)gRow.FindControl("Fecha1")).Visible = true;

                    ((Label)gRow.FindControl("lbl_Desc")).Visible = false;
                    ((Label)gRow.FindControl("lbl_fCompromiso")).Visible = false;
                }
                else
                {
                    if (string.IsNullOrEmpty(((Label)gRow.FindControl("lbl_Desc")).Text.Trim()))
                    {
                        ((TextBox)gRow.FindControl("txt_Desc")).Visible = true;
                        ((TextBox)gRow.FindControl("txt_Desc")).Text = ((Label)gRow.FindControl("lbl_Desc")).Text;

                        ((TextBox)gRow.FindControl("txt_fCompromisoOpe")).Visible = true;
                        ((TextBox)gRow.FindControl("txt_fCompromisoOPe")).Text = ((Label)gRow.FindControl("lbl_fCompromiso")).Text;
                        ((ImageButton)gRow.FindControl("Fecha1")).Visible = true;

                        ((Label)gRow.FindControl("lbl_Desc")).Visible = false;
                        ((Label)gRow.FindControl("lbl_fCompromiso")).Visible = false;
                    }
                    else
                    {
                        ((TextBox)gRow.FindControl("txt_fCumplimientoOPe")).Visible = true;
                        ((TextBox)gRow.FindControl("txt_fCumplimientoOPe")).Text = ((Label)gRow.FindControl("lbl_fCumplimiento")).Text;
                        ((ImageButton)gRow.FindControl("Fecha2")).Visible = true;

                        ((TextBox)gRow.FindControl("txt_areasOp")).Visible = true;
                        ((TextBox)gRow.FindControl("txt_areasOp")).Text = ((Label)gRow.FindControl("lbl_areasOp")).Text;

                        ((Label)gRow.FindControl("lbl_fCumplimiento")).Visible = false;
                        ((Label)gRow.FindControl("lbl_areasOp")).Visible = false;
                    }
                }
                ((ImageButton)gRow.FindControl("btn_EditarOPe")).Visible = false;
                                
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }

        protected void btn_AceptarOPe_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                GridViewRow gRow;
                ImageButton btn_Aceptar;
                btn_Aceptar = (ImageButton)sender;
                gRow = (GridViewRow)btn_Aceptar.Parent.Parent;

                int Resp = 0;
                if (int.Parse(gv_ObjetivosPermanentes.Rows[Indice_OPe].Cells[10].Text) == 0)
                {
                    if (!string.IsNullOrEmpty(((TextBox)gRow.FindControl("txt_Desc")).Text.Trim()))
                    {
                        if (!string.IsNullOrEmpty(((TextBox)gRow.FindControl("txt_fCompromisoOPe")).Text.Trim()))
                        {
                            Resp = objObjetivos.agregarObjetivo(IDMatriz,//ID_Matriz
                                                 cls_acceso.get_ID(),//ID_Empleado
                                                 3,
                                                 0, 0, 0, 0,
                                                 ((TextBox)gRow.FindControl("txt_Desc")).Text,
                                                 string.Empty,
                                                 ((TextBox)gRow.FindControl("txt_fCompromisoOPe")).Text,
                                                 cls_equipo.get_IDEquipo());
                        }
                        else
                        {
                            Msg.ShowMsg(this, "Falta la fecha compromiso.");
                        }
                    }
                    else
                    {
                        Msg.ShowMsg(this, "Falta un la descripcion del objetivo.");
                    }                    
                }
                else
                {
                    Msg = (cls_Utilerias)Session["OpcMenu"];
                    if (Msg.OpcionMenu == 0 && cls_matrizIndividual.get_ultimoMatriz_() != -1)
                    {
                        Resp = objObjetivos.modificarObjetivo(cls_matrizIndividual.get_ultimoMatriz_(),
                                                             int.Parse(gv_ObjetivosPermanentes.Rows[Indice_OPe].Cells[10].Text),
                                                             ((TextBox)gRow.FindControl("txt_Desc")).Text,
                                                             ((TextBox)gRow.FindControl("txt_fCompromisoOPe")).Text,
                                                             cls_acceso.get_ID(),
                                                             cls_equipo.get_IDEquipo());
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(((TextBox)gRow.FindControl("txt_fCumplimientoOPe")).Text.Trim()))
                        {
                            Resp = objObjetivos.cerrarObjetivo(int.Parse(gv_ObjetivosPermanentes.Rows[Indice_OPe].Cells[10].Text),
                                                        cls_equipo.get_IDEquipo(),
                                                        cls_acceso.get_ID(),
                                                        IdEstatusObj,
                                                        decimal.Parse(((Label)gRow.FindControl("lbl_rowEficacia")).Text),
                                                        decimal.Parse(((Label)gRow.FindControl("lbl_rowEficencia")).Text),
                                                        int.Parse(((Label)gRow.FindControl("lbl_SemanaAtrazo")).Text),
                                                        ((TextBox)gRow.FindControl("txt_areasOp")).Text,
                                                        ((TextBox)gRow.FindControl("txt_fCumplimientoOPe")).Text);
                        }
                        else
                        {
                            Msg.ShowMsg(this, "Falta la fecha cumplimiento.");
                        }
                    }
                }

                if (Resp == 1)
                {                                       
                    LlenaGridOPe(cls_objetivo.verObjetivosEmpleado(cls_acceso.get_ID(), IDMatriz, cls_configuracion.get_tipoObjetivo_PERMANENTE()));
                }
                else
                {
                    Msg.ShowMsg(this, "Erro :" + Resp);
                }                                 
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }

        protected void btn_CancelarOPe_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                GridViewRow gRow;
                ImageButton btn_Aceptar;
                btn_Aceptar = (ImageButton)sender;
                gRow = (GridViewRow)btn_Aceptar.Parent.Parent;

                ((ImageButton)gRow.FindControl("btn_EditarOPe")).Visible = true;

                ((TextBox)gRow.FindControl("txt_Desc")).Visible = false;
                ((TextBox)gRow.FindControl("txt_Desc")).Text = string.Empty;

                ((TextBox)gRow.FindControl("txt_fCompromisoOPe")).Visible = false;
                ((TextBox)gRow.FindControl("txt_fCompromisoOPe")).Text = string.Empty;
                ((ImageButton)gRow.FindControl("Fecha1")).Visible = false;
                string FechaCompromiso = ((Label)gRow.FindControl("lbl_fCompromiso")).Text;

                ((TextBox)gRow.FindControl("txt_fCumplimientoOPe")).Visible = false;
                ((TextBox)gRow.FindControl("txt_fCumplimientoOPe")).Text = string.Empty;
                ((ImageButton)gRow.FindControl("Fecha2")).Visible = false;
                string FechaCumplimiento = ((Label)gRow.FindControl("lbl_fCumplimiento")).Text;

                ((TextBox)gRow.FindControl("txt_areasOp")).Visible = false;
                ((TextBox)gRow.FindControl("txt_areasOp")).Text = string.Empty;

                ((ImageButton)gRow.FindControl("btn_AceptarOPe")).Visible = false;
                ((ImageButton)gRow.FindControl("btn_CancelarOPe")).Visible = false;
                ((Label)gRow.FindControl("lbl_Desc")).Visible = true;
                ((Label)gRow.FindControl("lbl_fCompromiso")).Visible = true;
                ((Label)gRow.FindControl("lbl_fCumplimiento")).Visible = true;
                ((Label)gRow.FindControl("lbl_areasOp")).Visible = true;

                ((Label)gRow.FindControl("lbl_objLogrado")).Text = ObjLogrado(FechaCompromiso, FechaCumplimiento);
                ((Label)gRow.FindControl("lbl_SemanaAtrazo")).Text = SemanasAtrazo(FechaCompromiso, FechaCumplimiento);
                ((Label)gRow.FindControl("lbl_rowEficencia")).Text = Eficiencia(FechaCompromiso, FechaCumplimiento);
                ((Label)gRow.FindControl("lbl_rowEficacia")).Text = Eficacia(FechaCompromiso, FechaCumplimiento);
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }

        protected void txt_fCompromisoOPe_TextChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gRow;
                TextBox txt_fCompromiso;
                txt_fCompromiso = (TextBox)sender;
                gRow = (GridViewRow)txt_fCompromiso.Parent.Parent;

                string FechaCompromiso = ((TextBox)gRow.FindControl("txt_fCompromisoOPe")).Text;
                string FechaCumplimiento = ((TextBox)gRow.FindControl("txt_fCumplimientoOPe")).Text;

                ((Label)gRow.FindControl("lbl_objLogrado")).Text = ObjLogrado(FechaCompromiso, FechaCumplimiento);
                ((Label)gRow.FindControl("lbl_SemanaAtrazo")).Text = SemanasAtrazo(FechaCompromiso, FechaCumplimiento);
                ((Label)gRow.FindControl("lbl_rowEficacia")).Text = Eficacia(FechaCompromiso, FechaCumplimiento);
                ((Label)gRow.FindControl("lbl_rowEficencia")).Text = Eficiencia(FechaCompromiso, FechaCumplimiento);

            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }

        protected void txt_fCumplimientoOPe_TextChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gRow;
                TextBox txt_fCumplimiento;
                txt_fCumplimiento = (TextBox)sender;
                gRow = (GridViewRow)txt_fCumplimiento.Parent.Parent;


                string FechaCompromiso = ((Label)gRow.FindControl("lbl_fCompromiso")).Text;
                string FechaCumplimiento = ((TextBox)gRow.FindControl("txt_fCumplimientoOPe")).Text.Trim();

                ((Label)gRow.FindControl("lbl_objLogrado")).Text = ObjLogrado(FechaCompromiso, FechaCumplimiento);
                ((Label)gRow.FindControl("lbl_SemanaAtrazo")).Text = SemanasAtrazo(FechaCompromiso, FechaCumplimiento);
                ((Label)gRow.FindControl("lbl_rowEficacia")).Text = Eficacia(FechaCompromiso, FechaCumplimiento);
                ((Label)gRow.FindControl("lbl_rowEficencia")).Text = Eficiencia(FechaCompromiso, FechaCumplimiento);

            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }

        protected void gv_ObjetivosPermanentes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lbl_Eficacia = (Label)e.Row.Cells[6].FindControl("lbl_rowEficencia");
                    Label lbl_Eficiencia = (Label)e.Row.Cells[4].FindControl("lbl_rowEficacia");

                    if (!string.IsNullOrEmpty(lbl_Eficacia.Text))
                    {
                        SumEficaciaOPe += double.Parse(lbl_Eficacia.Text);
                        DivisorOPe += 1;
                    }
                    if (lbl_Eficiencia != null)
                    {
                        if (!string.IsNullOrEmpty(lbl_Eficiencia.Text))
                        {
                            SumEficienciaOPe += double.Parse(lbl_Eficiencia.Text);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }

        protected void gv_ObjetivosPermanentes_RowCreated(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    GridViewRow row = new GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Normal);
                    Table t = (Table)gv_ObjetivosPermanentes.Controls[0];

                    TableCell FileDate = new TableHeaderCell();
                    FileDate.ColumnSpan = 1;
                    row.Cells.Add(FileDate);

                    TableCell cell = new TableHeaderCell();
                    cell.ColumnSpan = 9;
                    cell.Text = "Permanent";
                    cell.CssClass = "headerTitleGrid";
                    row.Cells.Add(cell);

                    t.Rows.AddAt(0, row);
                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label PromedioEficiencia = (Label)e.Row.FindControl("lbl_promedioEficencia");
                    Label PromedioEficacia = (Label)e.Row.FindControl("lbl_promedioEficacia");

                    if (PromedioEficiencia != null)
                    {
                        if (DivisorOPe > 0)
                        {
                            double Resultado = SumEficaciaOPe / DivisorOPe;
                            PromedioEficiencia.Text = Resultado.ToString("#0.##") + "%";
                        }
                        else
                        {
                            PromedioEficiencia.Text = string.Empty;
                        }

                    }
                    if (PromedioEficacia != null)
                    {
                        if (SumEficaciaOPe >= 0)
                        {
                            double Resultado = SumEficienciaOPe / (gv_ObjetivosPermanentes.Rows.Count - 1);
                            PromedioEficacia.Text = Resultado.ToString("#0.##") + "%";
                        }
                        else
                        {
                            PromedioEficacia.Text = string.Empty;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }
        #endregion

        protected void btn_Salir_Click(object sender, EventArgs e)
        {
            try
            {
                Msg.OpcionMenu = -1;
                Session["OpcMenu"] = Msg;
                Response.Redirect("~/graficas/grafica.aspx", false);
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }

        protected void gv_ObjetivosSecundarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
    }
}