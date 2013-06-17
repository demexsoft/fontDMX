<%@ Page Title="" Language="C#" MasterPageFile="~/mp_MenuPrincipal.Master" AutoEventWireup="true" CodeBehind="grafica.aspx.cs" Inherits="betaCulturalMARKII.graficas.grafica" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_Titulo" runat="server" Text="Our Team KPI’s" CssClass="tituloAzul_"></asp:Label>
            </td>
        </tr>
        <tr>
            <td><br /></td>
        </tr>
        <tr>
            <td align="center">
                <asp:Chart ID="grafic_Overall" runat="server" Width="400px" Height="300px" Palette="BrightPastel" BackColor="Silver" 
                                           BackSecondaryColor="White" BackGradientStyle="TopBottom">
                    <Series>             
                        <asp:Series Name="Series1" ChartType="Bar" ChartArea="ChartArea1" Color="#7f7f7f"></asp:Series>         
                    </Series>         
                    <ChartAreas>             
                        <asp:ChartArea Name="ChartArea1" BackSecondaryColor="White" BackColor="Gainsboro" 
                                        BackGradientStyle="DiagonalLeft">
                        </asp:ChartArea>         
                    </ChartAreas>                                    
                    <BorderSkin SkinStyle="Emboss" />     
                </asp:Chart> 
            </td>
        </tr>
        <tr>
            <td><br /></td>
        </tr>
        <tr>
            <td align="center">
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
    </table>
</asp:Content>
