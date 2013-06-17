<%@ Page Title="" Language="C#" MasterPageFile="~/mp_MenuPrincipal.Master" AutoEventWireup="true" CodeBehind="empleado.aspx.cs" Inherits="betaCulturalMARKII.empleado.empleado" EnableEventValidation="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Panel ID="pnl_content_empleado" runat="server">                   
                    <table width="100%">
                        <tr>
                            <td class="tituloTabla">
                                <asp:Label ID="Label20" CssClass="tituloAzul_" runat="server" Text="EMPLOYEE"></asp:Label>
                             </td>
                        </tr>
                        <tr>
                            <td><br /></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gvEmpleados" runat="server" AutoGenerateColumns="false" 
                                              ShowFooter="true" CellPadding="4" CssClass="resultTable" 
                                              GridLines="None">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnEditar" runat="server" ImageUrl="../imagenesBasicas/iconos/edit_black.png" OnClick="btnEditar_Click" />
                                                <asp:ImageButton ID="btnAceptar" runat="server" ImageUrl="../imagenesBasicas/iconos/Aceptar.png" Visible="false" OnClick="btnAceptar_Click"  ValidationGroup="gpoEmpleado"/>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Name" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("nombreEmp") %>'></asp:Label>
                                                <asp:TextBox ID="txtNombre" runat="server" Visible="false" CssClass="textoChicoNegro_" Width="100px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                                 ControlToValidate="txtNombre" ValidationGroup="gpoEmpleado"></asp:RequiredFieldValidator>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Last Name" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPaterno" runat="server" Text='<%# Bind("apePat") %>'></asp:Label>
                                                <asp:TextBox ID="txtPaterno" runat="server" Visible="false" CssClass="textoChicoNegro_" Width="100px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                                 ControlToValidate="txtPaterno" ValidationGroup="gpoEmpleado"></asp:RequiredFieldValidator>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Materno" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMaterno" runat="server" Text='<%# Bind("apeMat") %>'></asp:Label>
                                                <asp:TextBox ID="txtMaterno" runat="server" Visible="false" CssClass="textoChicoNegro_" Width="100px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="User" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUsuario" runat="server" Text='<%# Bind("d_login") %>'></asp:Label>
                                                <asp:TextBox ID="txtUsuario" runat="server" Visible="false" CssClass="textoChicoNegro_" Width="80px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                                 ControlToValidate="txtUsuario" ValidationGroup="gpoEmpleado"></asp:RequiredFieldValidator>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Password" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPassword" runat="server" Text='<%# Bind("d_contrasenia") %>'></asp:Label>
                                                <asp:TextBox ID="txtPassword" runat="server" Visible="false" CssClass="textoChicoNegro_" Width="100px" TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                                                 ControlToValidate="txtPassword" ValidationGroup="gpoEmpleado"></asp:RequiredFieldValidator>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Email" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCorreo" runat="server" Text='<%# Bind("d_email") %>'></asp:Label>
                                                <asp:TextBox ID="txtCorreo" runat="server" Visible="false" CssClass="textoChicoNegro_" Width="100px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                                                 ControlToValidate="txtCorreo" ValidationGroup="gpoEmpleado"></asp:RequiredFieldValidator>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha Alta" HeaderStyle-Width="140px" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFechaAlta" runat="server" Text='<%# Bind("fechaAlta") %>'></asp:Label>
                                                <asp:TextBox ID="txtFechaAlta" runat="server" Visible="false" CssClass="textoChicoNegro_" Width="50px"></asp:TextBox>
                                                <asp:ImageButton ID="btnFechaAlta" runat="server" ImageUrl="~/imagenesBasicas/iconos/Calendario2.png" Visible="false" />
                                                <cc1:CalendarExtender  ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" PopupButtonID="btnFechaAlta"
                                                                        TargetControlID="txtFechaAlta">
                                                </cc1:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*"
                                                 ControlToValidate="txtFechaAlta" ValidationGroup="gpoEmpleado"></asp:RequiredFieldValidator>
                                                 <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server"
                                                 Mask="99/99/9999" TargetControlID="txtFechaAlta" MaskType="Date" AcceptAMPM="false">
                                                </cc1:MaskedEditExtender>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*"
                                                 ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"
                                                 ControlToValidate="txtFechaAlta" ValidationGroup="gpoEmpleado">
                                                </asp:RegularExpressionValidator>                                                
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Puesto" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPuesto" runat="server" Text='<%# Bind("nomPuesto") %>'></asp:Label>
                                                <asp:DropDownList ID="ddlPuesto" runat="server" CssClass="textoChicoNegro_" Width="80px" Visible="false">
                                                </asp:DropDownList>                                                
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Empresa" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEmpresa" runat="server" Text='<%# Bind("nomEmpresa") %>'></asp:Label>
                                                <asp:DropDownList ID="ddlEmpresa" runat="server" CssClass="textoChicoNegro_" Width="100px" Visible="false">
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Area" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <asp:Label ID="lblArea" runat="server" Text='<%# Bind("nomArea") %>'></asp:Label>
                                                <asp:DropDownList ID="ddlArea" runat="server" CssClass="textoChicoNegro_" Width="80px" Visible="false">
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Perfil" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPerfil" runat="server" Text='<%# Bind("d_perfil") %>'></asp:Label>
                                                <asp:DropDownList ID="ddlPerfil" runat="server" CssClass="textoChicoNegro_" Width="80px" Visible="false">
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                    <asp:ImageButton ID="btnCancelar" runat="server" ImageUrl="../imagenesBasicas/iconos/Cancelar.png" Visible="false" OnClick="btnCancelar_Click" />
                                                    <asp:ImageButton ID="btnEliminar" runat="server" ImageUrl="../imagenesBasicas/iconos/Eliminar.jpg" Visible="true" OnClick="btnEliminar_Click" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                    <asp:Label ID="IDpuesto" runat="server" Text='<%# Bind("IDpuesto") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                    <asp:Label ID="IDemp" runat="server" Text='<%# Bind("IDemp") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                    <asp:Label ID="IDarea" runat="server" Text='<%# Bind("IDarea") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                    <asp:Label ID="IDempleado" runat="server" Text='<%# Bind("IDempleado") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                    <asp:Label ID="IDperfil" runat="server" Text='<%# Bind("id_perfil") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>                                                                                                                       
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
</asp:Content>
