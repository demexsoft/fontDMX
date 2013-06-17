<%@ Page Title="" Language="C#" MasterPageFile="~/mp_MenuPrincipal.Master" AutoEventWireup="true" CodeBehind="EquiposNew.aspx.cs" 
Inherits="betaCulturalMARKII.equipo.EquiposNew" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            width: 146px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td>
                <asp:Label ID="lbl_titulo_content_equipo" Text="New Team" CssClass="tituloAzul_" runat="server"></asp:Label>
            </td>
             
        </tr>
        <tr>
            <td>
            </td>
             
        </tr>
        <tr>
            <td>
                <table style="width: 319px">
                    <tr>
                        <td>
                <asp:Label ID="Label3" runat="server" Text="Name" CssClass="textoBOLDNegro_"></asp:Label>
                        </td>
                        <td>
                <asp:TextBox ID="txtNombre" runat="server" Width="200px" CssClass="textoChicoNegro_"></asp:TextBox>
                        </td>
                      
                    </tr>
                    <tr>
                        <td>
                <asp:Label ID="Label4" runat="server" Text="Area" CssClass="textoBOLDNegro_"></asp:Label>
                        </td>
                        <td>
                <asp:DropDownList ID="ddlArea" runat="server" Width="200px" CssClass="textoNormal_">
                </asp:DropDownList>
                        </td>
                      
                    </tr>
                    <tr>
                        <td>
                <asp:Label ID="Label5" runat="server" Text="Description" CssClass="textoBOLDNegro_"></asp:Label>
                        </td>
                        <td>
                <asp:TextBox ID="txtDescripcion" runat="server" Width="200px" CssClass="textoChicoNegro_"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                            ControlToValidate="txtNombre" ValidationGroup="gpoValida">
                </asp:RequiredFieldValidator>
                        </td>
                      
                    </tr>
                    <tr>
                        <td>
                <asp:Label ID="Label1" runat="server" Text="Leader" CssClass="textoBOLDNegro_"></asp:Label>
                        </td>
                        <td>
                <asp:DropDownList ID="ddlLider" runat="server" Width="200px" CssClass="textoNormal_">
                </asp:DropDownList>
                        </td>
                      
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td></td>
                      
                    </tr>
                </table>
                </td>
        </tr>
        <tr>
            <td>
            <asp:Label ID="Label2" runat="server" Text="Members" CssClass="textoBOLDNegro_"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                            ControlToValidate="txtDescripcion" ValidationGroup="gpoValida">
                </asp:RequiredFieldValidator>
                </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvEmpleados" runat="server" AutoGenerateColumns="false" ShowFooter="true"
                        CellPadding="4" CssClass="resultTable" GridLines="None">
                        <Columns>
                            <asp:BoundField DataField="IDEmpleado" HeaderText="ID" ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-Width="50px">
                            </asp:BoundField>
                            <asp:TemplateField HeaderText=" " HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chbLider" runat="server"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="nombreEmp" HeaderText="Nombre" ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-Width="100px">
                            </asp:BoundField>
                            <asp:BoundField DataField="apePat" HeaderText="Paterno" ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-Width="100px">
                            </asp:BoundField>
                            <asp:BoundField DataField="apeMat" HeaderText="Materno" ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-Width="100px">
                            </asp:BoundField>
                            <asp:BoundField DataField="nomPuesto" HeaderText="Puesto" ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-Width="100px">
                            </asp:BoundField>
                            <asp:BoundField DataField="nomArea" HeaderText="Area" ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-Width="100px">
                            </asp:BoundField>
                        </Columns>
                        <FooterStyle CssClass="footerGrid" />
                        <HeaderStyle CssClass="headerGrid" Height="30px" />
                        <RowStyle CssClass="itemGrid" Wrap="true" />
                        <SelectedRowStyle BackColor="#d4d4d4" Font-Bold="True" />
                        <PagerStyle ForeColor="#ffffff" BackColor="#3b3b3b" Font-Size="11px" />
                        <AlternatingRowStyle BackColor="#e5e5e5" />
                    </asp:GridView>
                </td>
               
        </tr>        
     
        <tr>
            <td>
            <br />
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Button ID="btnGuardar" runat="server" Text="Save" CssClass="btn_GrisRedondo" 
                            ValidationGroup="gpoValida" onclick="btnGuardar_Click"/>
                <br /></td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
