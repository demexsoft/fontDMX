<%@ Page Title="" Language="C#" MasterPageFile="~/mp_MenuPrincipal.Master" AutoEventWireup="true"
    CodeBehind="juntas.aspx.cs" Inherits="betaCulturalMARKII.reunion.juntas" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td colspan="2">
                <asp:Label ID="lbl_Titulo" runat="server" Text="[lbl_Titulo]" CssClass="tituloAzul_"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnl_JuntasNew" runat="server" Visible="false">
                    <table>
                        <tr>
                            <td valign="top">
                                <asp:Calendar ID="ctrl_Calenadrio" runat="server" Width="400px" Height="350px" BackColor="White"
                                    BorderColor="#999999" BorderWidth="2px" Font-Names="Verdana" Font-Size="9pt"
                                    ForeColor="Black" NextPrevFormat="FullMonth" OnSelectionChanged="ctrl_Calenadrio_SelectionChanged">
                                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" BackColor="#00407F" ForeColor="White" />
                                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                                    <OtherMonthDayStyle ForeColor="#999999" />
                                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                    <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="0px" Font-Bold="True"
                                        Font-Size="12pt" ForeColor="#00407F" />
                                    <TodayDayStyle BackColor="#60affd" />
                                    <WeekendDayStyle BackColor="#FFFFCC" />
                                </asp:Calendar>
                            </td>
                            <td valign="top">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label20" runat="server" Text="Equipo:" Font-Bold="true"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlEquipo" runat="server" Width="200px" OnSelectedIndexChanged="ddlEquipo_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text="Hora Compromiso:" Font-Bold="true"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtHoraCompromiso" runat="server" Width="200px"></asp:TextBox>
                                            <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99:99" TargetControlID="txtHoraCompromiso"
                                                MaskType="Time" AcceptAMPM="false">
                                            </cc1:MaskedEditExtender>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                                ControlToValidate="txtHoraCompromiso" ValidationGroup="gpoJunta">
                                            </asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*"
                                                ValidationExpression="^(20|21|22|23|[01]\d|\d)(([:][0-5]\d){1,2})$"
                                                ControlToValidate="txtHoraCompromiso" ValidationGroup="gpoJunta">
                                            </asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text="Horario:" Font-Bold="true"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtHorario" runat="server" Width="200px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                                ControlToValidate="txtHorario" ValidationGroup="gpoJunta">
                                            </asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label4" runat="server" Text="Lugar:" Font-Bold="true"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtLugar" runat="server" Width="200px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                                ControlToValidate="txtLugar" ValidationGroup="gpoJunta">
                                            </asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btn_GuardaNewJunta" runat="server" Text="Guardar" CssClass="btn_GrisRedondo"
                                                OnClick="btn_GuardaNewJunta_Click" ValidationGroup="gpoJunta" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="Label2" runat="server" Text="Reuniones:" Font-Bold="true"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:GridView ID="gvFechas" runat="server" AutoGenerateColumns="false" CellPadding="4"
                                                CssClass="resultTable" GridLines="None" EmptyDataText="Sin fechas.">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="ID" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <asp:Label ID="ID" runat="server" Text='<%# Bind("IDReu") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnEditar" runat="server" ImageUrl="../imagenesBasicas/iconos/edit_black.png"
                                                                OnClick="btnEditar_Click" />
                                                            <asp:ImageButton ID="btnAceptar" runat="server" ImageUrl="../imagenesBasicas/iconos/Aceptar.png"
                                                                OnClick="btnAceptar_Click" Visible="false" ValidationGroup="gpoJuntaEdit" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Fecha" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblFecha" runat="server" Text='<%# Bind("fComp") %>'></asp:Label>
                                                            <asp:TextBox ID="txtFecha" runat="server" Visible="false" CssClass="textoChicoNegro_"
                                                                Width="80px"></asp:TextBox>
                                                            <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" Mask="99/99/9999"
                                                                TargetControlID="txtFecha" MaskType="Date" AcceptAMPM="false">
                                                            </cc1:MaskedEditExtender>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                                                                ControlToValidate="txtFecha" ValidationGroup="gpoJuntaEdit">
                                                            </asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*"
                                                                ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"
                                                                ControlToValidate="txtFecha" ValidationGroup="gpoJuntaEdit">
                                                            </asp:RegularExpressionValidator>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Horario" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblHorario" runat="server" Text='<%# Bind("d_horario") %>'></asp:Label>
                                                            <asp:TextBox ID="txtHorario" runat="server" Visible="false" CssClass="textoChicoNegro_"
                                                                Width="80px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                                                                ControlToValidate="txtHorario" ValidationGroup="gpoJuntaEdit">
                                                            </asp:RequiredFieldValidator>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Lugar" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblLugar" runat="server" Text='<%# Bind("d_lugar") %>'></asp:Label>
                                                            <asp:TextBox ID="txtLugar" runat="server" Visible="false" CssClass="textoChicoNegro_"
                                                                Width="80px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*"
                                                                ControlToValidate="txtLugar" ValidationGroup="gpoJuntaEdit">
                                                            </asp:RequiredFieldValidator>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Hora Compromiso" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblHcompromiso" runat="server" Text='<%# Bind("hComp") %>'></asp:Label>
                                                            <asp:TextBox ID="txtHcompromiso" runat="server" Visible="false" CssClass="textoChicoNegro_"
                                                                Width="80px">
                                                            </asp:TextBox>
                                                            <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99:99" TargetControlID="txtHcompromiso"
                                                                MaskType="Time" AcceptAMPM="false">
                                                            </cc1:MaskedEditExtender>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*"
                                                                ControlToValidate="txtHcompromiso" ValidationGroup="gpoJuntaEdit">
                                                            </asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="*"
                                                                ValidationExpression="^(20|21|22|23|[01]\d|\d)(([:][0-5]\d){1,2})$"
                                                                ControlToValidate="txtHcompromiso" ValidationGroup="gpoJuntaEdit">
                                                            </asp:RegularExpressionValidator>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnCancelar" runat="server" ImageUrl="../imagenesBasicas/iconos/Cancelar.png"
                                                                Visible="false" OnClick="btnCancelar_Click" />
                                                            <asp:ImageButton ID="btnEliminar" runat="server" ImageUrl="../imagenesBasicas/iconos/Eliminar.jpg"
                                                                Visible="true" OnClick="btnEliminar_Click" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
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
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
