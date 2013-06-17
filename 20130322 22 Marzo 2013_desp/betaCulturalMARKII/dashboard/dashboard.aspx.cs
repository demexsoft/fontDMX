using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using betaCulturalMARKII.idioma;
using betaCulturalMARKII.graficas;
using System.Data;
using System.Globalization;

namespace betaCulturalMARKII.dashboard
{
    public partial class dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



        }//Page_Load

    


        protected void btn_link_btn_link_tabJutas_Click(object sender, EventArgs e)
        {
            try
            {

                MW_multi_vistas_graficas.ActiveViewIndex = 0;
                // cls_grafica grafica = new cls_grafica();
                // DataTable dt_DataQRY = grafica.ver_datos_Grafica_objetivos(cls_acceso.get_ID(), 0, "objIndividuales","","");


                //chart_juntas.DataSource = dt_DataQRY;
                //chart_juntas.DataBind();

                //chart_juntas.Series["Categories"].XValueMember = "TIPO";
                //chart_juntas.Series["Categories"].YValueMembers = "cantidadObjetivo";
                //chart_juntas.Series["Categories"].Label="#VALY";

                //chart_juntas.BorderlineDashStyle = ChartDashStyle.Solid;
                //chart_juntas.Series["Categories"].BorderWidth = 0;


                int mesNow = DateTime.Now.Month;
                int diaNow = DateTime.Now.Day;
                int anioNow = DateTime.Now.Year;




                DateTime fecha = new DateTime(anioNow, mesNow, diaNow);




                int one = DateTime.Now.Month;
                int anno = anioNow;

                Chart[] grafica = new Chart[12];
                Series[] series = new Series[12];
                ChartArea[] areachar = new ChartArea[12];
                DataTable[] dt_datosGrafica = new DataTable[12];
                cls_grafica[] clsgrafica = new cls_grafica[12];


                for (int meses = 0; meses < 12; meses++)
                {

                    int ultimoDiames = DateTime.DaysInMonth(anno, meses + 1);

                    dt_datosGrafica[meses] = new DataTable();
                    clsgrafica[meses] = new cls_grafica();


                    dt_datosGrafica[meses] = clsgrafica[meses].ver_datos_Grafica_objetivos(cls_acceso.get_ID(), 0, "objMiEquipoMensual", anno + "-" + one + "-01", anno + "-" + one + "-" + ultimoDiames);

                    if (dt_datosGrafica[meses].Rows.Count > 0)
                    {

                        grafica[meses] = new Chart();
                        series[meses] = new Series();
                        areachar[meses] = new ChartArea();

                        areachar[meses].Name = "areachar" + meses;
                        //series

                        series[meses].Name = "cate" + meses;
                        series[meses].ChartType = SeriesChartType.Column;
                        series[meses].ChartArea = "areachar" + meses;

                        //Grafica
                        grafica[meses].Width = 200;
                        grafica[meses].Height = 200;
                        grafica[meses].Titles.Add(CultureInfo.CurrentCulture.DateTimeFormat.MonthNames[one - 1] + " / " + anno);
                        grafica[meses].Series.Add(series[meses]);
                        grafica[meses].ChartAreas.Add(areachar[meses]);


                        grafica[meses].DataSource = dt_datosGrafica[meses];
                        grafica[meses].DataBind();
                        grafica[meses].Series["cate" + meses].XValueMember = "TIPO";
                        grafica[meses].Series["cate" + meses].YValueMembers = "cuantosObjetivos";
                        grafica[meses].Series["cate" + meses].Label = "#VALY";
                        grafica[meses].BorderlineDashStyle = ChartDashStyle.Solid;
                        grafica[meses].Series["cate" + meses].BorderWidth = 0;


                        view_objetivos_grf.Controls.Add(grafica[meses]);
                    }

                    if (one == 1)
                    {

                        anno--;
                        one = 12;
                    }
                    else
                    {
                        one--;
                    }

                }//for







                //chart1.DataSource = grafica2.ver_datos_Grafica_objetivos(cls_acceso.get_ID(), 0, "objMiEquipoMensual", "2011-12-01", "2011-12-31");
                // chart1.DataBind();

                // chart1.Series["Categories"].XValueMember = "TIPO";
                // chart1.Series["Categories"].YValueMembers = "cuantosObjetivos";
                // chart1.Series["Categories"].Label="#VALY";

                // chart1.BorderlineDashStyle = ChartDashStyle.Solid;
                // chart1.Series["Categories"].BorderWidth = 0;



            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

            //btn_link_tabPrincipios_Click
        }

        protected void btn_link_tabPrincipios_Click(object sender, EventArgs e)
        {
            try
            {


                MW_multi_vistas_graficas.ActiveViewIndex = 1;


                cls_grafica graficaPrincipios = new cls_grafica();

                DataTable dt_DataQRY = graficaPrincipios.graficaIndicadores(cls_acceso.get_ID());


                grafica_principios.DataSource = dt_DataQRY;
                grafica_principios.DataBind();


                grafica_principios.Series["serie_principio"].XValueMember = "desPrincipio";
                grafica_principios.Series["serie_principio"].YValueMembers = "cuantosPrincipio";
                grafica_principios.Series["serie_principio"].Label = "#VALY";
                grafica_principios.Series["serie_principio"].BorderWidth = 0;
                grafica_principios.BorderlineDashStyle = ChartDashStyle.Solid;




            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
            }//try-catch

            //btn_link_tabPrincipios_Click
        }

        protected void btn_link_tabIncongruencias_Click(object sender, EventArgs e)
        {

            try
            {
                MW_multi_vistas_graficas.ActiveViewIndex = 2;



                cls_grafica graficaOrigenProblema = new cls_grafica();

                DataTable dt_DataQRY = graficaOrigenProblema.graficaOrigenProblema(cls_acceso.get_ID());


                grafica_origenesProblematica.DataSource = dt_DataQRY;
                grafica_origenesProblematica.DataBind();



                grafica_origenesProblematica.Series["serie_origen"].XValueMember = "desOrigenes";
                grafica_origenesProblematica.Series["serie_origen"].YValueMembers = "cuantosOrigenes";
                grafica_origenesProblematica.Series["serie_origen"].Label = "#VALY";
                grafica_origenesProblematica.Series["serie_origen"].BorderWidth = 0;
                grafica_origenesProblematica.BorderlineDashStyle = ChartDashStyle.Solid;


            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);


            }


        }


    }//class
}//namespace