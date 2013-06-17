<%@ Page Title="" Language="C#" MasterPageFile="~/mainCSM.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="betaCulturalMARKII.dashboard.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


   <asp:Panel ID="pnl_content_graficas" runat="server">
                   <table width="800px">
                        <tr valign="top">
                            <td style="width:150px">
                                <table class="tablaSubMenu_icono">
                                    <tr class="tdTabla">
                                        <td>
                                         <asp:LinkButton ID="btn_link_tabJutas"  Text="Mis Objetivos" CssClass="textoNormalBlanco_" runat="server" OnClick="btn_link_btn_link_tabJutas_Click"></asp:LinkButton>
                                        
                                        </td>
                                    </tr>
                                </table>
                                <table class="tablaSubMenu_icono">
                                    <tr class="tdTabla">
                                        <td>
                                        <asp:LinkButton ID="btn_link_tabPrincipios" Text="Principios(Mi equipo)" CssClass="textoNormalBlanco_" runat="server" 
                                            OnClick="btn_link_tabPrincipios_Click" ></asp:LinkButton>
                                        </td>
                                    </tr>
                                     </table>
                                      <table class="tablaSubMenu_icono">
                                    <tr class="tdTabla">
                                        <td>
                                        <asp:LinkButton ID="btn_link_tabIncongruencias" Text="Incongruencias" CssClass="textoNormalBlanco_" runat="server" 
                                            OnClick="btn_link_tabIncongruencias_Click" ></asp:LinkButton>
                                        </td>
                                     </tr>
                                </table>

                            </td>
                        
                            <td>
                                <asp:MultiView ID="MW_multi_vistas_graficas" runat="server">
                                   <asp:View ID="view_objetivos_grf" runat="server">
                                   </asp:View>
                                    <asp:View ID="view_principios_grf" runat="server">
                                        <asp:Chart ID="grafica_principios" runat="server" BorderSkin-BackColor="White" ImageStorageMode="UseImageLocation" ImageLocation="~/temporales/ChartPic_#0001.jpg">
                                            <Series>
                                                <asp:Series Name="serie_principio" ChartType="Column" Color="Coral">
                                                </asp:Series>
                                            </Series>
                                            <ChartAreas>
                                                <asp:ChartArea Name="area_principio">
                                                </asp:ChartArea>
                                            </ChartAreas>
                                            <BorderSkin BackColor="White" />
                                        </asp:Chart>
                                        

                                    </asp:View> 
                                    <asp:View ID="view_incongruencias_grf" runat="server">
                                        <asp:Chart ID="grafica_origenesProblematica" runat="server" BorderSkin-BackColor="White">
                                            <Series>
                                                <asp:Series Name="serie_origen" ChartType="Bar">
                                                </asp:Series>
                                            </Series>
                                            <ChartAreas>
                                                <asp:ChartArea Name="area_origen">
                                                </asp:ChartArea>
                                            </ChartAreas>
                                            <BorderSkin BackColor="White" />
                                        </asp:Chart>
                                        
                                    </asp:View>
                                </asp:MultiView>
                            </td>
                        </tr>
                    </table> 
                
                </asp:Panel>

</asp:Content>
