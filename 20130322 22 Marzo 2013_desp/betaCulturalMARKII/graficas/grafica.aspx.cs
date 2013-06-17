using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Data;
using System.Globalization;
using betaCulturalMARKII.idioma;
using betaCulturalMARKII.equipo;

namespace betaCulturalMARKII.graficas
{
    public partial class grafica : System.Web.UI.Page
    {
        cls_grafica objGrafica = new cls_grafica();
        cls_Utilerias util = new cls_Utilerias();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                GeneraGraficas_OverallPerformance(0,  cls_equipo.get_IDEquipo(), string.Format("{0:dd}/{0:MM}/{0:yyyy}", DateTime.Now));                                                  
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }

        }

        protected void GeneraGraficas_OverallPerformance(int IDarea, int IDequipo, string Fecha)
        {
           
            try
            {

                DataTable dtEfectividad = new DataTable();
                DataTable dtTarget = new DataTable();
                dtEfectividad = objGrafica.ver_graficaEfectividad(IDarea, IDequipo, Fecha, 1);
                dtTarget = objGrafica.ver_graficaGetTarget(DateTime.Now.Year);
                DataView data1 = new DataView(dtEfectividad);

                if (dtEfectividad.Rows.Count > 0)
                {
                    grafic_Overall.Series["Series1"].Points.DataBind(data1, "X", "Y", "");
                    grafic_Overall.Titles.Add(cls_equipo.get_NomEquipo());                                      

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

    }
}