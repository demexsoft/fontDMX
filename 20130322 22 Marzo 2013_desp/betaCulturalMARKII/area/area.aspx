<%@ Page Title="" Language="C#" MasterPageFile="~/mp_MenuPrincipal.Master" AutoEventWireup="true" CodeBehind="area.aspx.cs" Inherits="betaCulturalMARKII.area.area" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:Panel ID="pnl_content_area" runat="server" Visible="true">

                    <asp:Label ID="Label19" CssClass="tituloAzul_" runat="server" Text="AREA"></asp:Label>
                    <br/>
                    <br/>
                    <asp:Table ID="tbl_agregarArea" runat="server">
                    <asp:TableRow>
                        <asp:TableCell>
                           

                    <table>
                    
                    <tr>
                        <td>
                            <table width="100%" border="0">
                        <tr>
                            <td>
                                <asp:Label ID="Label16" runat="server" Text="Nombre Area: " CssClass="textoNormal_"></asp:Label>
                                
                            </td>
                            <td>
                                <asp:TextBox ID="txt_nombre_area" runat="server" Width="250" CssClass="textoNormal_"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label17" runat="server" Text="Descripcion Area: " CssClass="textoNormal_"></asp:Label>
                                
                            </td>
                            <td>
                                <asp:TextBox ID="txt_desc_area" runat="server" Width="250" CssClass="textoNormal_"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label18" runat="server" Text="Selecciona Empresa: " CssClass="textoNormal_"></asp:Label>
                                
                            </td>
                            <td>
                                <asp:DropDownList ID="cmb_empresa_area" runat="server" Width="250" CssClass="textoNormal_"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td><br /></td>
                        </tr>
                        <tr>                            
                            <td colspan="2" align="right">
                                <asp:Button ID="btn_guardar_areas" runat="server" CssClass="btn_GrisRedondo" Text="Guardar" onclick="btn_guardar_areas_Click" />
                            </td>
                        </tr>

                    </table>
                        </td>
                    </tr>
                </table>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>

                <asp:Table ID="tbl_quitarArea" runat="server" Visible="false" Width="100%"> 
                    <asp:TableRow>
                        <asp:TableCell>
                <asp:DataGrid ID="grd_area" runat="server" HeaderStyle-Font-Bold="true"  
                        BackColor="White" BorderColor="#999999" BorderStyle="Solid" 
                        BorderWidth="1px" ForeColor="Black" ShowHeader="true" 
                        Width="800px" AlternatingItemStyle-BackColor="#D5F7FF"
                        HeaderStyle-BorderWidth="1px" ShowFooter="true" GridLines="None" CellPadding="4" CssClass="resultTable"   
                        AutoGenerateColumns="false">
                                                        
            <Columns>
                                                            
                    <asp:TemplateColumn>
                        <ItemTemplate>
                            <asp:ImageButton id="delAreaimgbtn" Height="15px"  Width="15px" Runat="server" CommandName="Select" CausesValidation="False" 
                                    ImageUrl="~/imagenesBasicas/botonesImagenes/iconos/delete.jpg">
                            </asp:ImageButton>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                                                         
                                        
                    <asp:BoundColumn  DataField="IDarea"     Visible="false">      </asp:BoundColumn>
                    <asp:BoundColumn DataField="nomArea"     HeaderText="Area" ItemStyle-HorizontalAlign="Left">  </asp:BoundColumn>
                    <asp:BoundColumn DataField="desArea"     HeaderText="Descripcion" ItemStyle-HorizontalAlign="Left"> </asp:BoundColumn>
                    <asp:BoundColumn DataField="nomEmpresa"  HeaderText="Empresa" ItemStyle-HorizontalAlign="Left"> </asp:BoundColumn>
                                                         
                                                         
        </Columns>
             
             
                    <FooterStyle CssClass="footerGrid" />
                    <HeaderStyle CssClass="headerGrid" Height="30px" />
                    <ItemStyle CssClass="itemGrid" Wrap="true" /> 
                    <SelectedItemStyle BackColor="#d4d4d4" Font-Bold="True" />
                    <PagerStyle ForeColor="#ffffff" BackColor="#3b3b3b" Font-Size="11px"/>
                    <AlternatingItemStyle BackColor="#e5e5e5" />
         
                    </asp:DataGrid> 


                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>

                

                    
            </asp:Panel>


</asp:Content>
