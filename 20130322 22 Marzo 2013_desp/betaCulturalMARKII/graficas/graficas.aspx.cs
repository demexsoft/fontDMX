using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using betaCulturalMARKII.incongruencia;
using betaCulturalMARKII.area;
using betaCulturalMARKII.equipo;

namespace betaCulturalMARKII.graficas
{
    public partial class graficas : System.Web.UI.Page
    {
        cls_grafica objGrafica = new cls_grafica();
        cls_Utilerias util = new cls_Utilerias();
        cls_incongruencia objIncongruencia = new cls_incongruencia();
        cls_area objArea = new cls_area();
        cls_equipo objEquipo = new cls_equipo();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    util = (cls_Utilerias)Session["OpcMenu"];

                    if (util.OpcionMenu == 0)
                    {
                        //OPCION 0
                        lbl_Titulo.Text = string.Empty;
                        pnl_Overall_Performance.Visible = false;
                        pnl_EffectivenessEfficiency.Visible = false;
                        pnl_Comparatives.Visible = false;
                    }

                    if (util.OpcionMenu == 1)
                    {
                        //OPCION 1
                        lbl_Titulo.Text = "OVERALL PERFORMANCE";                        
                        GeneraGraficas_OverallPerformance(0, cls_equipo.get_IDEquipo(), 0, string.Format("{0:dd}/{0:MM}/{0:yyyy}", DateTime.Now));
                        objIncongruencia.LlenaCombo_verAreas(objArea.verAreas(cls_acceso.get_ID()), ddl_PerSpecificUnit1, true);
                        objEquipo.LlenaCombo_verTodosEquipos(objEquipo.verTodosEquipos(0), ddl_PerSpecificTeam1, true);                        
                        pnl_Overall_Performance.Visible = true;
                        pnl_EffectivenessEfficiency.Visible = false;
                        pnl_Comparatives.Visible = false;
                    }

                    if (util.OpcionMenu == 2)
                    {
                        //OPCION 2
                        lbl_Titulo.Text = "MONTHLY COMPARATIVES";
                        GeneraGraficas_EffectivenessEfficiency(0, 0, 1, string.Format("{0:dd}/{0:MM}/{0:yyyy}", DateTime.Now));
                        objIncongruencia.LlenaCombo_verAreas(objArea.verAreas(cls_acceso.get_ID()), ddl_PerSpecificUnit2, true);
                        objEquipo.LlenaCombo_verTodosEquipos(objEquipo.verTodosEquipos(0), ddl_PerSpecificTeam2, true);                        
                        pnl_Overall_Performance.Visible = false;
                        pnl_EffectivenessEfficiency.Visible = true;
                        pnl_Comparatives.Visible = false;
                    }

                    if (util.OpcionMenu == 3)
                    {
                        //OPCION 3
                        lbl_Titulo.Text = "OVERALL COMPARATIVES";
                        GeneraGraficas_Comparatives(0, 0, string.Format("{0:dd}/{0:MM}/{0:yyyy}", DateTime.Now));
                        objIncongruencia.LlenaCombo_verAreas(objArea.verAreas(cls_acceso.get_ID()), ddl_PerSpecificUnit3, true);
                        objEquipo.LlenaCombo_verTodosEquipos(objEquipo.verTodosEquipos(0), ddl_PerSpecificTeam3, true);
                        objEquipo.LlenaCombo_verTodosEquipos(objEquipo.verTodosEquipos(0), ddl_PerSpecificTeam3, true);
                        pnl_Overall_Performance.Visible = false;
                        pnl_EffectivenessEfficiency.Visible = false;
                        pnl_Comparatives.Visible = true;
                    }

                    if (util.OpcionMenu == 4)
                    {
                        //OPCION 4
                        lbl_Titulo.Text = "MONTHLY PERFORMANCE";
                        GeneraGraficas_OverallPerformance(0, 0, 1, string.Format("{0:dd}/{0:MM}/{0:yyyy}", DateTime.Now));
                        objIncongruencia.LlenaCombo_verAreas(objArea.verAreas(cls_acceso.get_ID()), ddl_PerSpecificUnit1, true);
                        objEquipo.LlenaCombo_verTodosEquipos(objEquipo.verTodosEquipos(0), ddl_PerSpecificTeam1, true);
                        pnl_Overall_Performance.Visible = true;
                        pnl_EffectivenessEfficiency.Visible = false;
                        pnl_Comparatives.Visible = false;
                    }



                }
            }
            catch (Exception ex)
            {

                util.ShowMsg(this, ex.Message);
            }
        }

        protected void GeneraGraficas_OverallPerformance(int IDarea, int IDequipo, int TipoGrafica, string Fecha) 
        {
            try
            {
                DataTable dtEfectividad = new DataTable();
                DataTable dtTarget = new DataTable();
                dtEfectividad = objGrafica.ver_graficaEfectividad(IDarea, IDequipo, Fecha, TipoGrafica);
                dtTarget = objGrafica.ver_graficaGetTarget(DateTime.Now.Year);
                DataView data1 = new DataView(dtEfectividad);

                if (dtEfectividad.Rows.Count > 0)
                {
                    //grafic_Overall.Titles = "Hola";
                    grafic_Overall.Series["Series1"].Points.DataBind(data1, "X", "Y", "");
                    
                    DataTable dtFinal = new DataTable();
                    dtFinal.Columns.Add(new DataColumn("X"));
                    dtFinal.Columns.Add(new DataColumn("Y"));
                    dtFinal.Columns.Add(new DataColumn("n_target"));
                    dtFinal.Columns.Add(new DataColumn("Gap"));
                    DataRow dr;

                    for (int i = 0; i < dtEfectividad.Rows.Count; i++)
                    {
                        dr = dtFinal.NewRow();
                        double Gap = double.Parse(dtEfectividad.Rows[i]["Y"].ToString()) - double.Parse(dtTarget.Rows[i]["n_target"].ToString());
                        double Y = double.Parse(dtEfectividad.Rows[i]["Y"].ToString());
                        dr["X"] = dtEfectividad.Rows[i]["X"];
                        dr["Y"] = Y.ToString("##.##");
                        dr["n_target"] = dtTarget.Rows[i]["n_target"];
                        dr["Gap"] = Gap.ToString("##.##");
                        dtFinal.Rows.Add(dr);
                    }
                    gv_ForQuarter.DataSource = dtFinal;                    
                    gv_ForQuarter.DataBind();
                }

                DataTable dtIncidentes = new DataTable();
                dtIncidentes = objGrafica.ver_graficaIncidentes(IDarea, IDequipo, Fecha, TipoGrafica);
                DataView data2 = new DataView(dtIncidentes);

                if (dtIncidentes.Rows.Count > 0) 
                {
                    grafic_Incidents.Series["Series1"].Points.DataBind(data2, "X", "Y", "");
                }

                DataTable dtOrigin = new DataTable();
                dtOrigin = objGrafica.ver_graficaOrigenes(IDarea, IDequipo, Fecha, TipoGrafica);
                DataView data3 = new DataView(dtOrigin);

                if (dtOrigin.Rows.Count > 0) 
                {
                    grafic_Origin.Series["Series1"].Points.DataBind(data3, "X", "Y", "");
                }

            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        protected void gv_ForQuarter_RowCreated(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    GridViewRow row = new GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Normal);
                    Table t = (Table)gv_ForQuarter.Controls[0];

                    TableCell FileDate = new TableHeaderCell();
                    FileDate.ColumnSpan = 1;
                    row.Cells.Add(FileDate);

                    TableCell cell = new TableHeaderCell();
                    cell.ColumnSpan = 9;
                    cell.Text = "KPI status from Junary to March";
                    cell.CssClass = "headerTitleGrid";
                    row.Cells.Add(cell);

                    t.Rows.AddAt(0, row);
                }
            }
            catch (Exception ex)
            {

                util.ShowMsg(this, ex.Message);
            }
        }

        protected void GeneraGraficas_EffectivenessEfficiency(int IDarea, int IDequipo, int TipoGrafica, string Fecha) 
        {
            try
            {
                DataTable dtEfectividad = new DataTable();
                dtEfectividad = objGrafica.ver_graficaEfectividad(IDarea, IDequipo, Fecha, TipoGrafica);
                DataView data1 = new DataView(dtEfectividad);                
                grafic_EffectivenessEfficiency.Series["Series1"].Points.DataBind(data1, "X", "Y", "");

                DataTable dt1 = new DataTable();
                dt1 = objGrafica.ver_graficaObjsAlcanzados(IDarea, IDequipo, Fecha);
                DataView dv1 = new DataView(dt1);
                grafic_ObjectivesArchieved.Series["Prioritary"].Points.DataBind(dv1, "Mes", "Prioritarios", "");
                grafic_ObjectivesArchieved.Series["Secundary"].Points.DataBind(dv1, "Mes", "Secundarios", "");
                grafic_ObjectivesArchieved.Series["Permanent"].Points.DataBind(dv1, "Mes", "Permanentes", "");

                DataTable dt2 = new DataTable();
                dt2 = objGrafica.ver_graficaEfectividadHistorica(IDarea, IDequipo, Fecha);
                DataView dv2 = new DataView(dt2);
                grafic_EffectivenessHistorical.Series["Efficiency"].Points.DataBind(dv2, "Mes", "Efficiency", "");
                grafic_EffectivenessHistorical.Series["Effectiveness"].Points.DataBind(dv2, "Mes", "Effectiveness", "");
                grafic_EffectivenessHistorical.Series["Overall"].Points.DataBind(dv2, "Mes", "Overall", "");
                
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        protected void gv_ProductivitiDate_RowCreated(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    GridViewRow row = new GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Normal);
                    Table t = (Table)gv_ProductivitiDate.Controls[0];

                    TableCell FileDate = new TableHeaderCell();
                    FileDate.ColumnSpan = 1;
                    row.Cells.Add(FileDate);

                    TableCell cell = new TableHeaderCell();
                    cell.ColumnSpan = 9;
                    cell.Text = "Productivity to date";
                    cell.CssClass = "headerTitleGrid";
                    row.Cells.Add(cell);

                    t.Rows.AddAt(0, row);
                }
            }
            catch (Exception ex)
            {

                util.ShowMsg(this, ex.Message);
            }
        }

        protected void GeneraGraficas_Comparatives(int IDarea, int IDequipo, string Fecha) 
        {
            try
            {
                DataTable dt1 = new DataTable();
                dt1 = objGrafica.ver_graficaComparativaEfec(IDarea, IDequipo, Fecha, 1);                
                DataView data1 = new DataView(dt1);
                grafic_Effectiveness.Series["Series1"].Points.DataBind(data1, "X", "Y", "");

                DataTable dt2 = new DataTable();
                dt2 = objGrafica.ver_graficaComparativaEfec(IDarea, IDequipo, Fecha, 2);
                DataView data2 = new DataView(dt2);
                grafic_Efficiency.Series["Series1"].Points.DataBind(data2, "X", "Y", "");                                    
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        protected void btn_EntireOrganization1_Click(object sender, EventArgs e)
        {
            try
            {
                int TipoGrafica=0;
                if (util.OpcionMenu == 2 || util.OpcionMenu == 4)       //x mes
                {
                    TipoGrafica = 1;
                }
                GeneraGraficas_OverallPerformance(0, 0, TipoGrafica, string.Format("{0:dd}/{0:MM}/{0:yyyy}", DateTime.Now));
            }
            catch (Exception ex)
            {

                util.ShowMsg(this, ex.Message);
            }
        }

        protected void ddl_PerSpecificUnit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int TipoGrafica = 0;
                if (util.OpcionMenu == 2 || util.OpcionMenu == 4)       //x mes
                {
                    TipoGrafica = 1;
                }
  
                objEquipo.LlenaCombo_verTodosEquipos(objEquipo.verTodosEquipos(int.Parse(ddl_PerSpecificUnit1.SelectedValue)), ddl_PerSpecificTeam1, true);
                GeneraGraficas_OverallPerformance(int.Parse(ddl_PerSpecificUnit1.SelectedValue), int.Parse(ddl_PerSpecificTeam1.SelectedValue), TipoGrafica, string.Format("{0:dd}/{0:MM}/{0:yyyy}", DateTime.Now));
            }
            catch (Exception ex)
            {
                
                util.ShowMsg(this, ex.Message);
            }
        }

        protected void ddl_PerSpecificTeam1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int TipoGrafica = 0;
                if (util.OpcionMenu == 2 || util.OpcionMenu == 4)       //x mes
                {
                    TipoGrafica = 1;
                }

                GeneraGraficas_OverallPerformance(int.Parse(ddl_PerSpecificUnit1.SelectedValue), int.Parse(ddl_PerSpecificTeam1.SelectedValue), TipoGrafica, string.Format("{0:dd}/{0:MM}/{0:yyyy}", DateTime.Now));
            }
            catch (Exception ex)
            {

                util.ShowMsg(this, ex.Message);
            }
        }

        protected void btn_EntireOrganization2_Click(object sender, EventArgs e)
        {
            try
            {
                int TipoGrafica = 0;
                if (util.OpcionMenu == 2 || util.OpcionMenu == 4)       //x mes
                {
                    TipoGrafica = 1;
                }

                GeneraGraficas_EffectivenessEfficiency(0, 0, TipoGrafica, string.Empty);
            }
            catch (Exception ex)
            {
                
                util.ShowMsg(this, ex.Message);
            }
        }

        protected void ddl_PerSpecificUnit2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int TipoGrafica = 0;
                if (util.OpcionMenu == 2 || util.OpcionMenu == 4)       //x mes
                {
                    TipoGrafica = 1;
                }

                objEquipo.LlenaCombo_verTodosEquipos(objEquipo.verTodosEquipos(int.Parse(ddl_PerSpecificUnit2.SelectedValue)), ddl_PerSpecificTeam2, true);
                GeneraGraficas_EffectivenessEfficiency(int.Parse(ddl_PerSpecificUnit2.SelectedValue), int.Parse(ddl_PerSpecificTeam2.SelectedValue), TipoGrafica, string.Format("{0:dd}/{0:MM}/{0:yyyy}", DateTime.Now));
            }
            catch (Exception ex)
            {

                util.ShowMsg(this, ex.Message);
            }
        }

        protected void ddl_PerSpecificTeam2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int TipoGrafica = 0;
                if (util.OpcionMenu == 2 || util.OpcionMenu == 4)       //x mes
                {
                    TipoGrafica = 1;
                }

                GeneraGraficas_EffectivenessEfficiency(int.Parse(ddl_PerSpecificUnit2.SelectedValue), int.Parse(ddl_PerSpecificTeam2.SelectedValue), TipoGrafica, string.Format("{0:dd}/{0:MM}/{0:yyyy}", DateTime.Now));
            }
            catch (Exception ex)
            {
                
                util.ShowMsg(this, ex.Message);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                GeneraGraficas_Comparatives(0, 0, string.Format("{0:dd}/{0:MM}/{0:yyyy}", DateTime.Now));
            }
            catch (Exception ex)
            {

                util.ShowMsg(this, ex.Message);
            }
        }

        protected void ddl_PerSpecificUnit3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                objEquipo.LlenaCombo_verTodosEquipos(objEquipo.verTodosEquipos(int.Parse(ddl_PerSpecificUnit3.SelectedValue)), ddl_PerSpecificTeam3, true);
                GeneraGraficas_Comparatives(int.Parse(ddl_PerSpecificUnit3.SelectedValue), int.Parse(ddl_PerSpecificTeam3.SelectedValue), string.Format("{0:dd}/{0:MM}/{0:yyyy}", DateTime.Now));
            }
            catch (Exception ex)
            {

                util.ShowMsg(this, ex.Message);
            }
        }

        protected void ddl_PerSpecificTeam3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GeneraGraficas_Comparatives(int.Parse(ddl_PerSpecificUnit3.SelectedValue), int.Parse(ddl_PerSpecificTeam3.SelectedValue), string.Format("{0:dd}/{0:MM}/{0:yyyy}", DateTime.Now));
            }
            catch (Exception ex)
            {

                util.ShowMsg(this, ex.Message);
            }
        }
    }
}