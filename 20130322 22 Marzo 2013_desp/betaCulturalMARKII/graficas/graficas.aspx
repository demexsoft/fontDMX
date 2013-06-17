<%@ Page Title="" Language="C#" MasterPageFile="~/mp_CSMDashboard.Master" AutoEventWireup="true" CodeBehind="graficas.aspx.cs" 
Inherits="betaCulturalMARKII.graficas.graficas" EnableEventValidation="false" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td>
                <asp:Label ID="lbl_Titulo" runat="server" Text="[lbl_Titulo]" CssClass="tituloAzul_"></asp:Label>
            </td>
        </tr>
        <tr>
            <td><br /></td>
        </tr>
        <tr>
            <td>                
                

                <asp:Panel ID="pnl_EffectivenessEfficiency" runat="server">
                    <table width="100%">                        
                        <tr>
                            <td colspan="2">
                                <table width="600px" style="background-color:#456F97; border-color:White;">
                                    <tr>
                                        <td>
                                            <asp:Button ID="btn_EntireOrganization2" runat="server" 
                                                Text="Entire Organization" CssClass="btn_Azul" 
                                                onclick="btn_EntireOrganization2_Click" />
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddl_PerSpecificUnit2" runat="server" Width="150px" 
                                                onselectedindexchanged="ddl_PerSpecificUnit2_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddl_PerSpecificTeam2" runat="server" Width="150px" 
                                                onselectedindexchanged="ddl_PerSpecificTeam2_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Button ID="btn_GeneralComparative2" runat="server" Text="General Comparative" CssClass="btn_Azul" />
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddl_ComparativeUnit" runat="server" Width="150px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2"><br /></td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Chart ID="grafic_EffectivenessEfficiency" runat="server" Width="300px" Height="250px" Palette="BrightPastel" BackColor="Silver" 
                                           BackSecondaryColor="White" BackGradientStyle="TopBottom">
                                    <Series>             
                                        <asp:Series Name="Series1" ChartType="Bar" ChartArea="ChartArea1" IsValueShownAsLabel="true"></asp:Series>         
                                    </Series>         
                                    <ChartAreas>             
                                        <asp:ChartArea Name="ChartArea1" BackSecondaryColor="White" BackColor="Gainsboro" 
                                                       BackGradientStyle="DiagonalLeft">
                                        </asp:ChartArea>         
                                    </ChartAreas>         
                                    <Titles>             
                                        <asp:Title Text="Effectiveness/Efficiency" />
                                    </Titles>         
                                    <BorderSkin SkinStyle="Emboss" />     
                                 </asp:Chart> 
                            </td>
                            <td valign="top">
                                <asp:Chart ID="grafic_ObjectivesArchieved" runat="server" Width="300px" Height="250px" Palette="BrightPastel" BackColor="Silver" 
                                           BackSecondaryColor="White" BackGradientStyle="TopBottom">
                                    <Series>             
                                        <asp:Series Name="Prioritary" ChartType="Column" ChartArea="ChartArea1" IsValueShownAsLabel="true"></asp:Series>
                                        <asp:Series Name="Secundary" ChartType="Column" ChartArea="ChartArea1" Color="Blue" IsValueShownAsLabel="true"></asp:Series>
                                        <asp:Series Name="Permanent" ChartType="Column" ChartArea="ChartArea1" Color="Orange" IsValueShownAsLabel="true"></asp:Series>         
                                    </Series>
                                    <Legends>
                                        <asp:Legend Name="Legend1"></asp:Legend>
                                    </Legends>         
                                    <ChartAreas>             
                                        <asp:ChartArea Name="ChartArea1" BackSecondaryColor="White" BackColor="Gainsboro" 
                                                       BackGradientStyle="DiagonalLeft">
                                        </asp:ChartArea>                                        
                                    </ChartAreas>         
                                    <Titles>             
                                        <asp:Title Text="Productivity" />
                                    </Titles>         
                                    <BorderSkin SkinStyle="Emboss" />     
                                 </asp:Chart>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Chart ID="grafic_EffectivenessHistorical" runat="server" Width="300px" Height="250px" Palette="BrightPastel" BackColor="Silver" 
                                           BackSecondaryColor="White" BackGradientStyle="TopBottom">
                                    <Series>             
                                        <asp:Series Name="Efficiency" ChartType="Line" ChartArea="ChartArea1" Color="GreenYellow" IsValueShownAsLabel="true"></asp:Series>
                                        <asp:Series Name="Effectiveness" ChartType="Line" ChartArea="ChartArea1" Color="Blue" IsValueShownAsLabel="true"></asp:Series>
                                        <asp:Series Name="Overall" ChartType="Line" ChartArea="ChartArea1" Color="OrangeRed" IsValueShownAsLabel="true"></asp:Series>
                                    </Series>
                                    <Legends>
                                        <asp:Legend Name="Legend1"></asp:Legend>
                                    </Legends>         
                                    <ChartAreas>             
                                        <asp:ChartArea Name="ChartArea1" BackSecondaryColor="White" BackColor="Gainsboro" 
                                                       BackGradientStyle="DiagonalLeft">
                                        </asp:ChartArea>         
                                    </ChartAreas>         
                                    <Titles>             
                                        <asp:Title Text="Performance historical" />
                                    </Titles>         
                                    <BorderSkin SkinStyle="Emboss" />     
                                 </asp:Chart>
                            </td>
                            <td valign="top" align="left">
                                <asp:GridView ID="gv_ProductivitiDate" runat="server" AutoGenerateColumns="false" 
                                              CellPadding="4" CssClass="resultTable" GridLines="None" 
                                    onrowcreated="gv_ProductivitiDate_RowCreated">
                                    <Columns>
                                        <asp:BoundField DataField="X" HeaderStyle-Width="100px"></asp:BoundField>
                                        <asp:BoundField DataField="Y" HeaderStyle-Width="100px"></asp:BoundField>                                        
                                    </Columns>
                                    <FooterStyle CssClass="footerGrid" />
                                    <HeaderStyle CssClass="headerGrid" Height="30px" />
                                    <RowStyle CssClass="itemGrid" Wrap="true" /> 
                                    <SelectedRowStyle BackColor="#d4d4d4" Font-Bold="True" />
                                    <PagerStyle ForeColor="#ffffff" BackColor="#3b3b3b" Font-Size="11px"/>
                                    <AlternatingRowStyle BackColor="#e5e5e5" />
                                </asp:GridView>                                
                            </td>
                        </tr>
                    </table>
                </asp:Panel>

                <asp:Panel ID="pnl_Overall_Performance" runat="server">
                    <table width="100%">                        
                        <tr>
                            <td colspan="2">
                                <table width="500px" style="background-color:#456F97; border-color:White;">
                                    <tr>
                                        <td>
                                            <asp:Button ID="btn_EntireOrganization1" runat="server" 
                                                Text="Entire Organization" CssClass="btn_Azul" 
                                                onclick="btn_EntireOrganization1_Click" />
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddl_PerSpecificUnit1" runat="server" Width="150px" 
                                                onselectedindexchanged="ddl_PerSpecificUnit1_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddl_PerSpecificTeam1" runat="server" Width="150px" 
                                                onselectedindexchanged="ddl_PerSpecificTeam1_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2"><br /></td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Chart ID="grafic_Overall" runat="server" Width="300px" Height="250px" Palette="BrightPastel" BackColor="Silver" 
                                           BackSecondaryColor="White" BackGradientStyle="TopBottom">
                                    <Series>             
                                        <asp:Series Name="Series1" ChartType="Bar" ChartArea="ChartArea1" IsValueShownAsLabel="true"></asp:Series>         
                                    </Series>         
                                    <ChartAreas>             
                                        <asp:ChartArea Name="ChartArea1" BackSecondaryColor="White" BackColor="Gainsboro" 
                                                       BackGradientStyle="DiagonalLeft">
                                        </asp:ChartArea>         
                                    </ChartAreas>         
                                    <Titles>             
                                        <asp:Title Text="Overall" />
                                    </Titles>         
                                    <BorderSkin SkinStyle="Emboss" />     
                                 </asp:Chart> 
                            </td>
                            <td valign="top">
                                <asp:GridView ID="gv_ForQuarter" runat="server" AutoGenerateColumns="false" 
                                              CellPadding="4" CssClass="resultTable" GridLines="None" 
                                    onrowcreated="gv_ForQuarter_RowCreated">
                                    <Columns>
                                        <asp:BoundField DataField="X" HeaderStyle-Width="100px"></asp:BoundField>
                                        <asp:BoundField DataField="Y" HeaderText="Current" HeaderStyle-Width="100px"></asp:BoundField>
                                        <asp:BoundField DataField="n_target" HeaderText="Target 1Q" HeaderStyle-Width="100px"></asp:BoundField>
                                        <asp:BoundField DataField="Gap" HeaderText="Gap" HeaderStyle-Width="100px"></asp:BoundField>
                                    </Columns>
                                    <FooterStyle CssClass="footerGrid" />
                                    <HeaderStyle CssClass="headerGrid" Height="30px" />
                                    <RowStyle CssClass="itemGrid" Wrap="true" /> 
                                    <SelectedRowStyle BackColor="#d4d4d4" Font-Bold="True" />
                                    <PagerStyle ForeColor="#ffffff" BackColor="#3b3b3b" Font-Size="11px"/>
                                    <AlternatingRowStyle BackColor="#e5e5e5" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Chart ID="grafic_Incidents" runat="server" Width="300px" Height="250px" Palette="BrightPastel" BackColor="Silver" 
                                           BackSecondaryColor="White" BackGradientStyle="TopBottom">
                                    <Series>             
                                        <asp:Series Name="Series1" ChartType="Bar" ChartArea="ChartArea1" Color="#c0504e" IsValueShownAsLabel="true"></asp:Series>         
                                    </Series>         
                                    <ChartAreas>             
                                        <asp:ChartArea Name="ChartArea1" BackSecondaryColor="White" BackColor="Gainsboro" 
                                                       BackGradientStyle="DiagonalLeft">
                                        </asp:ChartArea>         
                                    </ChartAreas>         
                                    <Titles>             
                                        <asp:Title Text="Incidents" />
                                    </Titles>         
                                    <BorderSkin SkinStyle="Emboss" />     
                                 </asp:Chart>
                            </td>
                            <td valign="top">
                                <asp:Chart ID="grafic_Origin" runat="server" Width="300px" Height="250px" Palette="BrightPastel" BackColor="Silver" 
                                           BackSecondaryColor="White" BackGradientStyle="TopBottom">
                                    <Series>             
                                        <asp:Series Name="Series1" ChartType="Bar" ChartArea="ChartArea1" Color="#8064a1" IsValueShownAsLabel="true"></asp:Series>         
                                    </Series>         
                                    <ChartAreas>             
                                        <asp:ChartArea Name="ChartArea1" BackSecondaryColor="White" BackColor="Gainsboro" 
                                                       BackGradientStyle="DiagonalLeft">
                                        </asp:ChartArea>         
                                    </ChartAreas>         
                                    <Titles>             
                                        <asp:Title Text="Probable Source" />
                                    </Titles>         
                                    <BorderSkin SkinStyle="Emboss" />     
                                 </asp:Chart>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnl_Comparatives" runat="server">
                    <table width="100%">                        
                        <tr>
                            <td colspan="2">
                                <table width="500px" style="background-color:#456F97; border-color:White;">
                                    <tr>
                                        <td>
                                            <asp:Button ID="Button1" runat="server" Text="Entire Organization" 
                                                CssClass="btn_Azul" onclick="Button1_Click" />
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddl_PerSpecificUnit3" runat="server" Width="150px" 
                                                onselectedindexchanged="ddl_PerSpecificUnit3_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddl_PerSpecificTeam3" runat="server" Width="150px" 
                                                onselectedindexchanged="ddl_PerSpecificTeam3_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>                                        
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2"><br /></td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Chart ID="grafic_Effectiveness" runat="server" Width="300px" Height="250px" Palette="BrightPastel" BackColor="Silver" 
                                           BackSecondaryColor="White" BackGradientStyle="TopBottom">
                                    <Series>             
                                        <asp:Series Name="Series1" ChartType="Bar" ChartArea="ChartArea1" IsValueShownAsLabel="true"></asp:Series>         
                                    </Series>         
                                    <ChartAreas>             
                                        <asp:ChartArea Name="ChartArea1" BackSecondaryColor="White" BackColor="Gainsboro" 
                                                       BackGradientStyle="DiagonalLeft">
                                        </asp:ChartArea>         
                                    </ChartAreas>         
                                    <Titles>             
                                        <asp:Title Text="Effectiveness" />
                                    </Titles>         
                                    <BorderSkin SkinStyle="Emboss" />     
                                 </asp:Chart> 
                            </td>
                            <td>
                                <asp:Chart ID="grafic_Efficiency" runat="server" Width="300px" Height="250px" Palette="BrightPastel" BackColor="Silver" 
                                           BackSecondaryColor="White" BackGradientStyle="TopBottom">
                                    <Series>             
                                        <asp:Series Name="Series1" ChartType="Bar" ChartArea="ChartArea1" Color="Violet" IsValueShownAsLabel="true"></asp:Series>         
                                    </Series>         
                                    <ChartAreas>             
                                        <asp:ChartArea Name="ChartArea1" BackSecondaryColor="White" BackColor="Gainsboro" 
                                                       BackGradientStyle="DiagonalLeft">
                                        </asp:ChartArea>         
                                    </ChartAreas>         
                                    <Titles>             
                                        <asp:Title Text="Efficiency" />
                                    </Titles>         
                                    <BorderSkin SkinStyle="Emboss" />     
                                 </asp:Chart>
                            </td>                            
                        </tr>                                                
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
