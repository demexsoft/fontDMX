<%@ Page Title="" Language="C#" MasterPageFile="~/mp_MenuPrincipal.Master" AutoEventWireup="true"
    CodeBehind="consultaincongruencias.aspx.cs" Inherits="betaCulturalMARKII.incongruencia.consultaincongruencias" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            width: 193px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td colspan="6">
                <asp:Label ID="lbl_Titulo" runat="server" Text="Label" CssClass="tituloAzul_" Visible="false"></asp:Label>
                <asp:Label ID="Label7" runat="server" Text="View Incident Log" CssClass="tituloAzul_"></asp:Label>
                
            </td>
        </tr>
        <tr>
            <td>
               
            </td>
        </tr>
        <tr valign="top">
            <td>
                <asp:Label ID="Label4" runat="server" Text="From"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_FechaIni" runat="server" Width="120px" OnTextChanged="txt_FechaIni_TextChanged"></asp:TextBox>
                <asp:ImageButton ID="btnFechaInicio" runat="server" ImageUrl="~/imagenesBasicas/iconos/Calendario2.png" />
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" PopupButtonID="btnFechaInicio"
                    TargetControlID="txt_FechaIni">
                </cc1:CalendarExtender>
                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999"
                    TargetControlID="txt_FechaIni" MaskType="Date" AcceptAMPM="false">
                </cc1:MaskedEditExtender>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*"
                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"
                    ControlToValidate="txt_FechaIni" ValidationGroup="gpoValid">
                </asp:RegularExpressionValidator>
            </td>
            <td>
                <asp:Label ID="Label5" runat="server" Text="To"></asp:Label>
            </td>
            <td class="style2">
                <asp:TextBox ID="txt_FechaFin" runat="server" Width="120px" OnTextChanged="txt_FechaFin_TextChanged"></asp:TextBox>
                <asp:ImageButton ID="btnFechaFin" runat="server" ImageUrl="~/imagenesBasicas/iconos/Calendario2.png" />
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" PopupButtonID="btnFechaFin"
                    TargetControlID="txt_FechaFin">
                </cc1:CalendarExtender>
                <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999"
                    TargetControlID="txt_FechaFin" MaskType="Date" AcceptAMPM="false">
                </cc1:MaskedEditExtender>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*"
                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"
                    ControlToValidate="txt_FechaFin" ValidationGroup="gpoValid">
                </asp:RegularExpressionValidator>
            </td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td colspan="6">
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Team"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddl_Equipo" runat="server" Width="150px">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Indicator"></asp:Label>
            </td>
            <td class="style2">
                <asp:DropDownList ID="ddl_Principio" runat="server" Width="150px">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Model"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddl_Modelo" runat="server" Width="150px">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Probable Source"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddl_Causa" runat="server" Width="150px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td colspan="5">
                <asp:Button ID="btn_Buscar" runat="server" Text="Search" CssClass="btn_GrisRedondo"
                    OnClick="btn_Buscar_Click" ValidationGroup="gpoValid"/>
            </td>
        </tr>
        <tr>
            <td colspan="6">
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:GridView ID="GridView1" runat="server" Width="700px" AutoGenerateColumns="false"
                    ShowFooter="true" CellPadding="4" CssClass="resultTable" GridLines="None" EmptyDataText="No se encontraron concidencias para la busqueda.">
                    <Columns>
                        <asp:BoundField DataField="f_bitacora" HeaderText="Date">
                            <HeaderStyle Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="d_nombreEquipo" HeaderText="Team">
                            <HeaderStyle Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="d_principio" HeaderText="Principio">
                            <HeaderStyle Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="d_modelo" HeaderText="Modelo">
                            <HeaderStyle Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="d_descripcionProblematica" HeaderText="Origen">
                            <HeaderStyle Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="d_evento" HeaderText="Event">
                            <HeaderStyle Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="d_impacto" HeaderText="Impact">
                            <HeaderStyle Width="50px" />
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
    </table>
</asp:Content>
