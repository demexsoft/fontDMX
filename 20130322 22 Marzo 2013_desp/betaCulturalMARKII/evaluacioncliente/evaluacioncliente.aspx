<%@ Page Title="" Language="C#" MasterPageFile="~/mp_MenuPrincipal.Master" AutoEventWireup="true"
    CodeBehind="evaluacioncliente.aspx.cs" Inherits="betaCulturalMARKII.evaluacioncliente.evaluacioncliente"
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="700px" border="0">
        <tr>
            <td colspan="4">
                <asp:Label ID="lbl_Titulo" runat="server" Text="[lbl_Titulo]" CssClass="tituloAzul_"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4">
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Fecha:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_Fecha" runat="server" Width="150px" OnTextChanged="txt_Fecha_TextChanged"></asp:TextBox>
                <asp:ImageButton ID="btnFechaInicio" runat="server" ImageUrl="~/imagenesBasicas/iconos/Calendario2.png" />
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" PopupButtonID="btnFechaInicio"
                    TargetControlID="txt_Fecha">
                </cc1:CalendarExtender>
                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999"
                    TargetControlID="txt_Fecha" MaskType="Date" AcceptAMPM="false">
                </cc1:MaskedEditExtender>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*"
                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"
                    ControlToValidate="txt_Fecha" ValidationGroup="gpoValid">
                </asp:RegularExpressionValidator>
            </td>
            <td align="right">
                <asp:Label ID="Label2" runat="server" Text="Equipo:"></asp:Label>
            </td>
            <td align="right">
                <asp:DropDownList ID="ddl_Equipo" runat="server" Width="150px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Parámetro:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddl_Evaluar" runat="server" Width="150px">
                </asp:DropDownList>
            </td>
            <td align="right">
            </td>
            <td align="right">
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Evaluación:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddl_conocimiento" runat="server" Width="150px">
                </asp:DropDownList>
            </td>
            <td align="right">
                <asp:Label ID="Label6" runat="server" Text="Origen:"></asp:Label>
            </td>
            <td align="right">
                <asp:DropDownList ID="ddl_causa" runat="server" Width="150px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="Label5" runat="server" Text="Recomendación:"></asp:Label>
                <br />
                <asp:TextBox ID="txt_Recomendacion" runat="server" TextMode="MultiLine" Width="700px"
                    Height="100px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="btn_Guardar" runat="server" Text="Guardar" CssClass="btn_GrisRedondo"
                    OnClick="btn_Guardar_Click" ValidationGroup="gpoValid" />
            </td>
            <td>
                <asp:Button ID="btn_Salir" runat="server" Text="Salir" CssClass="btn_GrisRedondo"
                    OnClick="btn_Salir_Click" />
            </td>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
