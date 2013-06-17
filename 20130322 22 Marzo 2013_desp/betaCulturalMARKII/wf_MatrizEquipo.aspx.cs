using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using betaCulturalMARKII.matrizEquipo;
using betaCulturalMARKII.equipo;
using betaCulturalMARKII.objetivoEquipo;

namespace betaCulturalMARKII
{
    public partial class wf_MatrizEquipo : System.Web.UI.Page
    {
        cls_Utilerias Msg = new cls_Utilerias();
        cls_matrizEquipo objMatrizEquipo = new cls_matrizEquipo();
        cls_objetivoEquipo objObjetivoEquipo = new cls_objetivoEquipo();

        //protected static int IDMatriz;
        protected static int IdEstatusObj;

        protected static int Indice;
        protected static int Divisor;
        protected static double SumEficacia;
        protected static double SumEficiencia;

        protected static int IDobj = 11;
        protected static int IDMat = 12;
        protected static int IDInt = 13;
        protected static int eMail = 14;

        protected static bool BndModificacdion;
        protected static int IDMatriz;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack) 
                {                    
                    Msg = (cls_Utilerias)Session["OpcMenu"];

                    BndModificacdion = false;
                    IdEstatusObj = 0;
                    Divisor = 0;
                    SumEficacia = 0;
                    SumEficiencia = 0;

                    if (cls_acceso.get_Perfil().Equals(3))
                    {
                        CargaMatrizVigenteIntegrante("Matriz Equipo Vigente");                        
                    }
                    else
                    {
                        if (Msg.OpcionMenu == 0)
                        {
                            cls_matrizEquipo.set_ultimoMatrizEquipo_(-1);
                            lbl_Titulo_MatrizEquipo.Text = "Matriz Equipo Nueva";
                            pnlMatrizEquipoNew.Visible = true;
                            pnlFechaMatrizVigente.Visible = false;

                            DataTable DTnull = new DataTable();
                            LlenaGrid(DTnull);
                        }

                        if (Msg.OpcionMenu == 1)
                        {
                            CargaMatrizVigente("Matriz Equipo Vigente");
                        }

                        if (Msg.OpcionMenu == 2)
                        {
                            CargaMatriz("Matriz Equipo");
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }

        protected void LLenaComboIntegrantesEquipo(int IDEquipo, DropDownList ctrDDL) 
        {
            try
            {
                DataTable dtIntegrantes = objMatrizEquipo.verEquipoIntegrantes(IDEquipo);

                if(dtIntegrantes.Rows.Count >0)
                {
                    ctrDDL.DataSource = dtIntegrantes;
                    ctrDDL.DataValueField = "id_empleado";
                    ctrDDL.DataTextField = "d_empleado";
                    ctrDDL.DataBind();
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception (ex.Message);
            }
        }

        protected void CargaMatrizVigente(string Titulo)
        {
            try
            {
                DataTable dtMatrizVigente = new DataTable();
                dtMatrizVigente = objMatrizEquipo.verMatrizEquipoVigente(cls_acceso.get_ID(),cls_equipo.get_IDEquipo());
                if (dtMatrizVigente.Rows.Count > 0)
                {
                    IDMatriz = int.Parse(dtMatrizVigente.Rows[0]["IDMatriz"].ToString());

                    cls_matrizEquipo.set_ultimoMatrizEquipo_(IDMatriz);
                    lbl_Titulo_MatrizEquipo.Text = Titulo;
                    lbl_FechaInicio.Text = DateTime.Parse(dtMatrizVigente.Rows[0]["f_inicio"].ToString()).ToShortDateString();
                    lbl_FechaFin.Text = DateTime.Parse(dtMatrizVigente.Rows[0]["f_final"].ToString()).ToShortDateString();

                    pnlFechaMatrizVigente.Visible = true;
                    pnlMatrizEquipoNew.Visible = false;

                    LlenaGrid(objObjetivoEquipo.verObjetivosMatrizEquipo(cls_acceso.get_ID(),cls_matrizEquipo.get_ultimoMatrizEquipo_()));// IDMatriz));
                }
                else 
                {
                    Msg.ShowMsg(this, "No se cuenta con una Matriz Vigente.");
                    
                    lbl_Titulo_MatrizEquipo.Text = "Matriz Equipo Nueva";
                    pnlMatrizEquipoNew.Visible = true;
                    pnlFechaMatrizVigente.Visible = false;

                    DataTable DTnull = new DataTable();
                    LlenaGrid(DTnull);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        protected void CargaMatrizVigenteIntegrante(string Titulo)
        {
            try
            {
                DataTable dtMatrizVigente = new DataTable();
                dtMatrizVigente = objMatrizEquipo.verMatrizEquipoVigente(cls_acceso.get_ID(), cls_equipo.get_IDEquipo());
                if (dtMatrizVigente.Rows.Count > 0)
                {
                    cls_matrizEquipo.set_ultimoMatrizEquipo_(int.Parse(dtMatrizVigente.Rows[0]["IDMatriz"].ToString()));
                    lbl_Titulo_MatrizEquipo.Text = Titulo;
                    lbl_FechaInicio.Text = DateTime.Parse(dtMatrizVigente.Rows[0]["f_inicio"].ToString()).ToShortDateString();
                    lbl_FechaFin.Text = DateTime.Parse(dtMatrizVigente.Rows[0]["f_final"].ToString()).ToShortDateString();

                    pnlFechaMatrizVigente.Visible = true;
                    pnlMatrizEquipoNew.Visible = false;

                    LlenaGridIntegrante(objObjetivoEquipo.verObjetivosMatrizEquipo(cls_acceso.get_ID(), cls_matrizEquipo.get_ultimoMatrizEquipo_()));// IDMatriz));
                    //LlenaGrid(objObjetivoEquipo.verObjetivosMatrizEquipo(cls_acceso.get_ID(), cls_matrizEquipo.get_ultimoMatrizEquipo_()));// IDMatriz));
                }
                else
                {
                    Msg.ShowMsg(this, "No se cuenta con una Matriz Vigente.");

                    lbl_Titulo_MatrizEquipo.Text = "Matriz Equipo Nueva";
                    pnlMatrizEquipoNew.Visible = true;
                    pnlFechaMatrizVigente.Visible = false;

                    DataTable DTnull = new DataTable();
                    LlenaGrid(DTnull);
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
                dtMatrizVigente = objMatrizEquipo.verMatrizEquipo(cls_matrizEquipo.get_ultimoMatrizEquipo_());
                //IDMatriz = int.Parse(dtMatrizVigente.Rows[0]["IDMatriz"].ToString());
                
                lbl_Titulo_MatrizEquipo.Text = Titulo;
                lbl_FechaInicio.Text = DateTime.Parse(dtMatrizVigente.Rows[0]["f_inicio"].ToString()).ToShortDateString(); ;
                lbl_FechaFin.Text = DateTime.Parse(dtMatrizVigente.Rows[0]["f_final"].ToString()).ToShortDateString();

                pnlFechaMatrizVigente.Visible = true;
                pnlMatrizEquipoNew.Visible = false;

                LlenaGrid_ID(objObjetivoEquipo.verObjetivosMatrizEquipo(cls_acceso.get_ID(),cls_matrizEquipo.get_ultimoMatrizEquipo_()));// IDMatriz));
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
                dt_Modificado.Columns.Add(new DataColumn("d_empleado"));
                dt_Modificado.Columns.Add(new DataColumn("d_email"));

                DataRow dr;

                if (DTbd.Rows.Count > 0)
                {
                    for (int i = 0; i < DTbd.Rows.Count; i++)
                    {
                        dr = dt_Modificado.NewRow();
                        dr["Descripcion"] = DTbd.Rows[i]["descObjetivoEquipo"];

                        if (!string.IsNullOrEmpty(DTbd.Rows[i]["fechaComproEquipo"].ToString()))
                        {
                            dr["f_Compromiso"] = DateTime.Parse(DTbd.Rows[i]["fechaComproEquipo"].ToString()).ToShortDateString();
                        }
                        else 
                        {
                            dr["f_Compromiso"] = string.Empty;
                        }

                        if (int.Parse(DTbd.Rows[i]["estatusObjetivoEquipo"].ToString()) == 0)
                        {
                            dr["obj_Logrado"] = string.Empty;
                        }
                        else
                        {
                            dr["obj_Logrado"] = "SI";
                        }

                        dr["Eficacia"] = DTbd.Rows[i]["porEficaciaEquipo"];

                        if (!string.IsNullOrEmpty(DTbd.Rows[i]["fechaCumpliEquipo"].ToString()))
                        {
                            dr["f_Cumplimiento"] = DateTime.Parse(DTbd.Rows[i]["fechaCumpliEquipo"].ToString()).ToShortDateString();
                        }
                        else 
                        {
                            dr["f_Cumplimiento"] = string.Empty;
                        }

                        string strEficiencia = string.Empty;
                        if (!string.IsNullOrEmpty(DTbd.Rows[i]["porEficienciaEquipo"].ToString()))
                        {
                            double dbEficiencia = double.Parse(DTbd.Rows[i]["porEficienciaEquipo"].ToString());
                            strEficiencia = dbEficiencia.ToString("#0.##");
                        }

                        dr["Eficiencia"] = strEficiencia.ToString();
                        dr["SemanaAtrazo"] = DTbd.Rows[i]["semanasAtrasoEquipo"];
                        dr["Area_Oportunidad"] = DTbd.Rows[i]["areaOportunidadEquipo"];
                        dr["IDobj"] = DTbd.Rows[i]["IDobjEquipo"];
                        dr["IDMat"] = DTbd.Rows[i]["IDMat"];
                        dr["id_integrante"] = DTbd.Rows[i]["id_integranteEquipo"];
                        dr["d_empleado"] = DTbd.Rows[i]["d_empleado"];
                        dr["d_email"] = DTbd.Rows[i]["d_email"];
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
                dr["d_empleado"] = string.Empty;
                dr["d_email"] = string.Empty;
                dt_Modificado.Rows.Add(dr);

                return dt_Modificado;
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
                    //decimal Dias = dtFecha1.DayOfYear - dtFecha2.DayOfYear;
                    decimal Dias = dtFecha2.DayOfYear - dtFecha1.DayOfYear;
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
                        if (cls_matrizEquipo.get_ultimoMatrizEquipo_() == -1)
                        {
                            int Resp = 0;
                            Resp = objMatrizEquipo.crearMatrizEquipo(cls_acceso.get_ID(),
                                                                    cls_equipo.get_IDEquipo(),
                                                                    string.Format("{0:dd}/{0:MM}/{0:yyyy}", DateTime.Now),
                                                                    txt_FechaInicioMatrizNew.Text,
                                                                    txt_FechaFinMatrizNew.Text);
                        }
                        else 
                        {
                            objMatrizEquipo.modificaMatrizEquipo(cls_matrizEquipo.get_ultimoMatrizEquipo_(),
                                                                 cls_equipo.get_IDEquipo(),
                                                                 txt_FechaInicioMatrizNew.Text,
                                                                 txt_FechaFinMatrizNew.Text);
                        }

                        LlenaGrid(objObjetivoEquipo.verObjetivosMatrizEquipo(cls_acceso.get_ID(), cls_matrizEquipo.get_ultimoMatrizEquipo_()));
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
                        if (cls_matrizEquipo.get_ultimoMatrizEquipo_() == -1)
                        {
                            int Resp = 0;
                            Resp = objMatrizEquipo.crearMatrizEquipo(cls_acceso.get_ID(),
                                                                    cls_equipo.get_IDEquipo(),
                                                                    string.Format("{0:dd}/{0:MM}/{0:yyyy}", DateTime.Now),
                                                                    txt_FechaInicioMatrizNew.Text,
                                                                    txt_FechaFinMatrizNew.Text);
                        }
                        else 
                        {
                            objMatrizEquipo.modificaMatrizEquipo(cls_matrizEquipo.get_ultimoMatrizEquipo_(),
                                                                 cls_equipo.get_IDEquipo(),
                                                                 txt_FechaInicioMatrizNew.Text,
                                                                 txt_FechaFinMatrizNew.Text);
                        }
                    }
                    LlenaGrid(objObjetivoEquipo.verObjetivosMatrizEquipo(cls_acceso.get_ID(), cls_matrizEquipo.get_ultimoMatrizEquipo_()));
                }
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }        

        protected void LlenaGrid(DataTable DTbd)
        {
            try
            {
                gv_Objetivos.Visible = true;
                gvMiembro.Visible = false;
                gv_Objetivos.Columns[IDobj].Visible = true;
                gv_Objetivos.Columns[IDMat].Visible = true;
                gv_Objetivos.Columns[IDInt].Visible = true;
                gv_Objetivos.Columns[eMail].Visible = true;
                gv_Objetivos.DataSource = DTModificadoGrid(DTbd);
                gv_Objetivos.DataBind();
                gv_Objetivos.Columns[IDobj].Visible = false;
                gv_Objetivos.Columns[IDMat].Visible = false;
                gv_Objetivos.Columns[IDInt].Visible = false;
                gv_Objetivos.Columns[eMail].Visible = false;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        protected void LlenaGridIntegrante(DataTable DTbd)
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
                dt_Modificado.Columns.Add(new DataColumn("d_email"));

                DataRow dr;

                if (DTbd.Rows.Count > 0)
                {
                    for (int i = 0; i < DTbd.Rows.Count; i++)
                    {
                        dr = dt_Modificado.NewRow();
                        dr["Descripcion"] = DTbd.Rows[i]["descObjetivoEquipo"];

                        if (!string.IsNullOrEmpty(DTbd.Rows[i]["fechaComproEquipo"].ToString()))
                        {
                            dr["f_Compromiso"] = DateTime.Parse(DTbd.Rows[i]["fechaComproEquipo"].ToString()).ToShortDateString();
                        }
                        else
                        {
                            dr["f_Compromiso"] = string.Empty;
                        }

                        if (int.Parse(DTbd.Rows[i]["estatusObjetivoEquipo"].ToString()) == 0)
                        {
                            dr["obj_Logrado"] = string.Empty;
                        }
                        else
                        {
                            dr["obj_Logrado"] = "SI";
                        }

                        dr["Eficacia"] = DTbd.Rows[i]["porEficaciaEquipo"];

                        if (!string.IsNullOrEmpty(DTbd.Rows[i]["fechaCumpliEquipo"].ToString()))
                        {
                            dr["f_Cumplimiento"] = DateTime.Parse(DTbd.Rows[i]["fechaCumpliEquipo"].ToString()).ToShortDateString();
                        }
                        else
                        {
                            dr["f_Cumplimiento"] = string.Empty;
                        }

                        string strEficiencia = string.Empty;
                        if (!string.IsNullOrEmpty(DTbd.Rows[i]["porEficienciaEquipo"].ToString()))
                        {
                            double dbEficiencia = double.Parse(DTbd.Rows[i]["porEficienciaEquipo"].ToString());
                            strEficiencia = dbEficiencia.ToString("#0.##");
                        }

                        dr["Eficiencia"] = strEficiencia.ToString();
                        dr["SemanaAtrazo"] = DTbd.Rows[i]["semanasAtrasoEquipo"];
                        dr["Area_Oportunidad"] = DTbd.Rows[i]["areaOportunidadEquipo"];                        
                        dr["d_email"] = DTbd.Rows[i]["d_email"];
                        dt_Modificado.Rows.Add(dr);
                    }
                }

                gvMiembro.Visible = true;
                gv_Objetivos.Visible = false;
                gvMiembro.Columns[8].Visible = true;                
                gvMiembro.DataSource = dt_Modificado;
                gvMiembro.DataBind();
                gvMiembro.Columns[8].Visible = false;                
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        protected void LlenaGrid_ID(DataTable DTbd)
        {
            try
            {
                gv_Objetivos.Columns[0].Visible = true;
                gv_Objetivos.Columns[IDobj].Visible = true;
                gv_Objetivos.Columns[IDMat].Visible = true;
                gv_Objetivos.Columns[IDInt].Visible = true;
                gv_Objetivos.DataSource = DTModificadoGrid(DTbd);
                gv_Objetivos.DataBind();
                gv_Objetivos.Columns[IDobj].Visible = false;
                gv_Objetivos.Columns[IDMat].Visible = false;
                gv_Objetivos.Columns[IDInt].Visible = false;
                gv_Objetivos.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        protected void btn_Editar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Msg = (cls_Utilerias)Session["OpcMenu"];
                Divisor = 0;
                SumEficacia = 0;
                SumEficiencia = 0;

                GridViewRow gRow;
                ImageButton btn_Editar;
                btn_Editar = (ImageButton)sender;
                gRow = (GridViewRow)btn_Editar.Parent.Parent;
                Indice = gRow.DataItemIndex;

                ((ImageButton)gRow.FindControl("btn_Aceptar")).Visible = true;
                ((ImageButton)gRow.FindControl("btn_Cancelar")).Visible = true;
                if (Msg.OpcionMenu == 0)
                {
                    ((TextBox)gRow.FindControl("txt_Desc")).Visible = true;
                    ((TextBox)gRow.FindControl("txt_Desc")).Text = ((Label)gRow.FindControl("lbl_Desc")).Text;

                    ((TextBox)gRow.FindControl("txt_fCompromiso")).Visible = true;
                    ((TextBox)gRow.FindControl("txt_fCompromiso")).Text = ((Label)gRow.FindControl("lbl_fCompromiso")).Text;
                    ((ImageButton)gRow.FindControl("Fecha1")).Visible = true;

                    DropDownList ddlGenerico = new DropDownList();
                    ddlGenerico = ((DropDownList)gRow.FindControl("ddlIntegrante"));
                    LLenaComboIntegrantesEquipo(cls_equipo.get_IDEquipo(), ddlGenerico);
                    ((DropDownList)gRow.FindControl("ddlIntegrante")).Visible = true;
                    ((Label)gRow.FindControl("lblIntegrante")).Visible = false;

                    ((Label)gRow.FindControl("lbl_Desc")).Visible = false;
                    ((Label)gRow.FindControl("lbl_fCompromiso")).Visible = false;
                }
                else
                {
                    if (string.IsNullOrEmpty(((Label)gRow.FindControl("lbl_Desc")).Text))
                    {
                        ((TextBox)gRow.FindControl("txt_Desc")).Visible = true;
                        ((TextBox)gRow.FindControl("txt_Desc")).Text = ((Label)gRow.FindControl("lbl_Desc")).Text;

                        ((TextBox)gRow.FindControl("txt_fCompromiso")).Visible = true;
                        ((TextBox)gRow.FindControl("txt_fCompromiso")).Text = ((Label)gRow.FindControl("lbl_fCompromiso")).Text;
                        ((ImageButton)gRow.FindControl("Fecha1")).Visible = true;

                        DropDownList ddlGenerico = new DropDownList();
                        ddlGenerico = ((DropDownList)gRow.FindControl("ddlIntegrante"));
                        LLenaComboIntegrantesEquipo(cls_equipo.get_IDEquipo(), ddlGenerico);
                        ((DropDownList)gRow.FindControl("ddlIntegrante")).Visible = true;
                        ((Label)gRow.FindControl("lblIntegrante")).Visible = false;

                        ((Label)gRow.FindControl("lbl_Desc")).Visible = false;
                        ((Label)gRow.FindControl("lbl_fCompromiso")).Visible = false;
                    }
                    else
                    {
                        ((TextBox)gRow.FindControl("txt_fCumplimiento")).Visible = true;
                        ((TextBox)gRow.FindControl("txt_fCumplimiento")).Text = ((Label)gRow.FindControl("lbl_fCumplimiento")).Text;
                        ((ImageButton)gRow.FindControl("Fecha2")).Visible = true;

                        ((TextBox)gRow.FindControl("txt_areasOp")).Visible = true;
                        ((TextBox)gRow.FindControl("txt_areasOp")).Text = ((Label)gRow.FindControl("lbl_areasOp")).Text;

                        ((Label)gRow.FindControl("lbl_fCumplimiento")).Visible = false;
                        ((Label)gRow.FindControl("lbl_areasOp")).Visible = false;
                    }
                }
                ((ImageButton)gRow.FindControl("btn_Editar")).Visible = false;                
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }

        protected void btn_Aceptar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Msg = (cls_Utilerias)Session["OpcMenu"];

                GridViewRow gRow;
                ImageButton btn_Aceptar;
                btn_Aceptar = (ImageButton)sender;
                gRow = (GridViewRow)btn_Aceptar.Parent.Parent;

                DropDownList ddlIntegrante = new DropDownList();
                ddlIntegrante = ((DropDownList)gRow.FindControl("ddlIntegrante"));

                int Resp = 0;
                if (int.Parse(gv_Objetivos.Rows[Indice].Cells[11].Text) == 0)
                {
                    if (!string.IsNullOrEmpty(((TextBox)gRow.FindControl("txt_Desc")).Text.Trim()))
                    {
                        if (!string.IsNullOrEmpty(((TextBox)gRow.FindControl("txt_fCompromiso")).Text.Trim()))
                        {
                            Resp = objObjetivoEquipo.agregarObjetivoEquipo(cls_matrizEquipo.get_ultimoMatrizEquipo_(),//IDMatriz,
                                                                   int.Parse(ddlIntegrante.SelectedValue),
                                                                   1,
                                                                   ((TextBox)gRow.FindControl("txt_Desc")).Text,
                                                                   string.Empty,
                                                                   ((TextBox)gRow.FindControl("txt_fCompromiso")).Text,
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
                    if (Msg.OpcionMenu == 0 && cls_matrizEquipo.get_ultimoMatrizEquipo_() != -1)
                    {
                        Resp = objObjetivoEquipo.editarObjetivoEquipo(cls_matrizEquipo.get_ultimoMatrizEquipo_(),
                                                               int.Parse(gv_Objetivos.Rows[Indice].Cells[10].Text),
                                                               ((TextBox)gRow.FindControl("txt_Desc")).Text,
                                                               ((TextBox)gRow.FindControl("txt_fCompromiso")).Text,
                                                               cls_acceso.get_ID(),
                                                               cls_equipo.get_IDEquipo());
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(((TextBox)gRow.FindControl("txt_fCumplimiento")).Text))
                        {
                            Resp = objObjetivoEquipo.cerrarObjetivoEquipo(int.Parse(gv_Objetivos.Rows[Indice].Cells[11].Text),
                                                                          cls_equipo.get_IDEquipo(),
                                                                          cls_acceso.get_ID(),
                                                                          IdEstatusObj,
                                                                          float.Parse(((Label)gRow.FindControl("lbl_rowEficacia")).Text),
                                                                          float.Parse(((Label)gRow.FindControl("lbl_rowEficencia")).Text),
                                                                          int.Parse(((Label)gRow.FindControl("lbl_SemanaAtrazo")).Text),
                                                                          ((TextBox)gRow.FindControl("txt_areasOp")).Text,
                                                                          ((TextBox)gRow.FindControl("txt_fCumplimiento")).Text);
                        }
                        else
                        {
                            Msg.ShowMsg(this, "Falta la fecha de cumplimiento.");
                        }
                    }                     
                }

                if (Resp == 1)
                {
                    LlenaGrid(objObjetivoEquipo.verObjetivosMatrizEquipo(cls_acceso.get_ID(), cls_matrizEquipo.get_ultimoMatrizEquipo_())); //IDMatriz));
                    BndModificacdion = true;
                }
                else if (Resp == 2) 
                {                    
                    LlenaGrid(objObjetivoEquipo.verObjetivosMatrizEquipo(cls_acceso.get_ID(), cls_matrizEquipo.get_ultimoMatrizEquipo_())); //IDMatriz));
                }
                else
                {
                    Msg.ShowMsg(this, "Erro :" + Resp);
                    BndModificacdion = true;
                }
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }

        protected void btn_Cancelar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                GridViewRow gRow;
                ImageButton btn_Aceptar;
                btn_Aceptar = (ImageButton)sender;
                gRow = (GridViewRow)btn_Aceptar.Parent.Parent;

                ((ImageButton)gRow.FindControl("btn_Editar")).Visible = true;

                ((TextBox)gRow.FindControl("txt_Desc")).Visible = false;
                ((TextBox)gRow.FindControl("txt_Desc")).Text = string.Empty;

                ((TextBox)gRow.FindControl("txt_fCompromiso")).Visible = false;
                ((TextBox)gRow.FindControl("txt_fCompromiso")).Text = string.Empty;
                ((ImageButton)gRow.FindControl("Fecha1")).Visible = false;
                string FechaCompromiso = ((Label)gRow.FindControl("lbl_fCompromiso")).Text;
                
                ((Label)gRow.FindControl("lblIntegrante")).Visible = true;
                ((DropDownList)gRow.FindControl("ddlIntegrante")).Visible = false;

                ((TextBox)gRow.FindControl("txt_fCumplimiento")).Visible = false;
                ((TextBox)gRow.FindControl("txt_fCumplimiento")).Text = string.Empty;
                ((ImageButton)gRow.FindControl("Fecha2")).Visible = false;
                string FechaCumplimiento = ((Label)gRow.FindControl("lbl_fCumplimiento")).Text;

                ((TextBox)gRow.FindControl("txt_areasOp")).Visible = false;
                ((TextBox)gRow.FindControl("txt_areasOp")).Text = string.Empty;

                ((ImageButton)gRow.FindControl("btn_Aceptar")).Visible = false;
                ((ImageButton)gRow.FindControl("btn_Cancelar")).Visible = false;
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

        protected void txt_fCompromiso_TextChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gRow;
                TextBox txt_fCompromiso;
                txt_fCompromiso = (TextBox)sender;
                gRow = (GridViewRow)txt_fCompromiso.Parent.Parent;

                string FechaCompromiso = ((TextBox)gRow.FindControl("txt_fCompromiso")).Text;
                string FechaCumplimiento = ((TextBox)gRow.FindControl("txt_fCumplimiento")).Text;

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

        protected void txt_fCumplimiento_TextChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gRow;
                TextBox txt_fCumplimiento;
                txt_fCumplimiento = (TextBox)sender;
                gRow = (GridViewRow)txt_fCumplimiento.Parent.Parent;


                string FechaCompromiso = ((Label)gRow.FindControl("lbl_fCompromiso")).Text;
                string FechaCumplimiento = ((TextBox)gRow.FindControl("txt_fCumplimiento")).Text.Trim();

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

        protected void gv_ObjetivosPrioritarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lbl_Eficacia = (Label)e.Row.Cells[6].FindControl("lbl_rowEficencia");
                    Label lbl_Eficiencia = (Label)e.Row.Cells[4].FindControl("lbl_rowEficacia");

                    if (!string.IsNullOrEmpty(lbl_Eficacia.Text))
                    {
                        SumEficacia += double.Parse(lbl_Eficacia.Text);
                        Divisor += 1;
                    }
                    if (lbl_Eficiencia != null)
                    {
                        if (!string.IsNullOrEmpty(lbl_Eficiencia.Text))
                        {
                            SumEficiencia += double.Parse(lbl_Eficiencia.Text);
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
                    Table t = (Table)gv_Objetivos.Controls[0];

                    TableCell FileDate = new TableHeaderCell();
                    FileDate.ColumnSpan = 1;
                    row.Cells.Add(FileDate);

                    TableCell cell = new TableHeaderCell();
                    cell.ColumnSpan = 10;
                    cell.Text = "Team Objetives";
                    cell.CssClass = "headerTitleGrid";
                    row.Cells.Add(cell);

                    t.Rows.AddAt(0, row);
                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label PromedioEficiencia = (Label)e.Row.FindControl("lbl_promedioEficencia");
                    Label PromedioEficacia = (Label)e.Row.FindControl("lbl_promedioEficacia");

                    double ResultadoEficiencia = 0;
                    if (PromedioEficiencia != null)
                    {
                        if (Divisor > 0)
                        {
                            ResultadoEficiencia = SumEficacia / Divisor;
                            PromedioEficiencia.Text = ResultadoEficiencia.ToString("##.##") + "%";
                            lbl_Porc_Eficiencia.Text = ResultadoEficiencia.ToString("##.##") + "%";
                        }
                        else
                        {
                            PromedioEficiencia.Text = string.Empty;
                            lbl_Porc_Eficiencia.Text = "0.0";
                        }

                    }

                    double ResultadoEficacia = 0;
                    if (PromedioEficacia != null)
                    {
                        if (SumEficacia > 0)
                        {
                            ResultadoEficacia = SumEficiencia / (gv_Objetivos.Rows.Count - 1);
                            PromedioEficacia.Text = ResultadoEficacia.ToString("##.##") + "%";
                            lbl_Porc_Eficacia.Text = ResultadoEficacia.ToString("##.##") + "%";
                        }
                        else
                        {
                            PromedioEficacia.Text = string.Empty;
                            lbl_Porc_Eficacia.Text = "0.0";
                        }
                    }
                    
                    double ResultadoEfectividad = (ResultadoEficacia + ResultadoEficiencia) / 2;
                    if (ResultadoEfectividad > 0)
                    {
                        lbl_Porc_Efectividad.Text = ResultadoEfectividad.ToString("##.##") + "%";
                    }
                    else 
                    {
                        lbl_Porc_Efectividad.Text = "0.0";
                    }
                }
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }

        protected void btn_Salir_Click(object sender, EventArgs e)
        {
            try
            {
                if (BndModificacdion)
                {
                    DataTable dt = objMatrizEquipo.verMailIntregrantesMatriz(IDMatriz);
                    string Mails = string.Empty;
                    if (dt.Rows.Count > 0) 
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (!string.IsNullOrEmpty(dt.Rows[i]["d_email"].ToString()))
                            {
                                Mails = Mails + dt.Rows[i]["d_email"].ToString() + ",";
                            }
                        }
                    }

                    if (!string.IsNullOrEmpty(Mails))
                    {
                        Msg.EnviaMail(Mails.Substring(0,Mails.Length -1), "Notificacion de Matriz de Equipo CSM", "La Matriz de equipo ha sido modificada.");
                    }
                }
                Msg.OpcionMenu = -1;
                Session["OpcMenu"] = Msg;
                Response.Redirect("~/graficas/grafica.aspx", false);
            }
            catch (Exception ex)
            {

                Msg.ShowMsg(this, ex.Message);
            }
        }        
    }
}