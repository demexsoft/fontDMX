<%@ Page Title="" Language="C#" MasterPageFile="~/mp_MenuPrincipal.Master" AutoEventWireup="true"
    CodeBehind="wf_MatrizEquipo.aspx.cs" Inherits="betaCulturalMARKII.wf_MatrizEquipo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="950px" border="0">
        <tr>
            <td>
                <asp:Label ID="lbl_Titulo_MatrizEquipo" runat="server" Text="[lbl_Titulo]" CssClass="tituloAzul_" Visible="false"></asp:Label>
                <asp:Label ID="Label6" runat="server" Text="My Team’s Current Matrix " CssClass="tituloAzul_"></asp:Label>
                

            </td>
            <td align="center">
                <h4>
                    % Overall</h4>
            </td>
            <td align="center">
               <h4> % Effectiveness
                    </h4>
            </td>
            <td align="center">
                <h4>
                    % Efficiency</h4>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Panel ID="pnlFechaMatrizVigente" runat="server" Visible="false">
                    <table width="400px">
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label1" runat="server" Text="Objetives From"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lbl_FechaInicio" runat="server" Text="[lbl_FechaInicio]"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="Label2" runat="server" Text="To"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lbl_FechaFin" runat="server" Text="[lbl_FechaFin]"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <br />
                <asp:Panel ID="pnlMatrizEquipoNew" runat="server" Visible="false">
                    <table width="450px">
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label3" runat="server" Text="Objetives From"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:TextBox ID="txt_FechaInicioMatrizNew" runat="server" MaxLength="10" AutoPostBack="true"
                                    Width="70px" OnTextChanged="txt_FechaInicioMatrizNew_TextChanged">
                                </asp:TextBox>
                                <asp:ImageButton ID="btnFechaInicio" runat="server" ImageUrl="~/imagenesBasicas/iconos/Calendario2.png" />
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" PopupButtonID="btnFechaInicio"
                                    TargetControlID="txt_FechaInicioMatrizNew">
                                </cc1:CalendarExtender>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999"
                                    TargetControlID="txt_FechaInicioMatrizNew" MaskType="Date" AcceptAMPM="false">
                                </cc1:MaskedEditExtender>                                
                            </td>
                            <td align="center">
                                <asp:Label ID="Label5" runat="server" Text="To"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:TextBox ID="txt_FechaFinMatrizNew" runat="server" MaxLength="10" AutoPostBack="true"
                                    Width="70px" OnTextChanged="txt_FechaFinMatrizNew_TextChanged">
                                </asp:TextBox>
                                <asp:ImageButton ID="btnFechaFin" runat="server" ImageUrl="~/imagenesBasicas/iconos/Calendario2.png" />
                                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy" PopupButtonID="btnFechaFin"
                                    TargetControlID="txt_FechaFinMatrizNew">
                                </cc1:CalendarExtender>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999"
                                    TargetControlID="txt_FechaFinMatrizNew" MaskType="Date" AcceptAMPM="false">
                                </cc1:MaskedEditExtender>                               
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td align="center">
                <asp:Label ID="lbl_Porc_Efectividad" runat="server" Text="0.0"></asp:Label>
            </td>
            <td align="center">
                <asp:Label ID="lbl_Porc_Eficacia" runat="server" Text="0.0"></asp:Label>
            </td>
            <td align="center">
                <asp:Label ID="lbl_Porc_Eficiencia" runat="server" Text="0.0"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="4">
            
                <asp:GridView ID="gv_Objetivos" runat="server" Width="1000px" AutoGenerateColumns="false"
                    ShowFooter="true" CellPadding="4" CssClass="resultTable" GridLines="None"
                    EmptyDataText = "Empty Data" 
                    OnRowCreated="gv_ObjetivosPrioritarios_RowCreated"
                    OnRowDataBound="gv_ObjetivosPrioritarios_RowDataBound">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="btn_Editar" runat="server" ImageUrl="imagenesBasicas/iconos/edit_black.png"
                                    OnClick="btn_Editar_Click" />
                                <asp:ImageButton ID="btn_Aceptar" runat="server" ImageUrl="imagenesBasicas/iconos/Aceptar.png"
                                    OnClick="btn_Aceptar_Click" Visible="false" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description" HeaderStyle-Width="300px" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lbl_Desc" runat="server" Text='<%# Bind("Descripcion") %>'></asp:Label>
                                <asp:TextBox ID="txt_Desc" runat="server" Visible="false" CssClass="textoChicoNegro_"
                                    Width="280px"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Target Date" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lbl_fCompromiso" runat="server" Text='<%# Bind("f_Compromiso") %>'></asp:Label>
                                <asp:TextBox ID="txt_fCompromiso" runat="server" Visible="false" MaxLength="10" CssClass="textoChicoNegro_"
                                    Width="50px" OnTextChanged="txt_fCompromiso_TextChanged" AutoPostBack="true">
                                </asp:TextBox>
                                <asp:ImageButton ID="Fecha1" runat="server" ImageUrl="~/imagenesBasicas/iconos/Calendario2.png"
                                    Visible="false" />
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" PopupButtonID="Fecha1"
                                    TargetControlID="txt_fCompromiso" OnClientDateSelectionChanged="">
                                </cc1:CalendarExtender>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" Mask="99/99/9999"
                                    TargetControlID="txt_fCompromiso" MaskType="Date" AcceptAMPM="false">
                                </cc1:MaskedEditExtender>                                
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Responsible" HeaderStyle-Width="150px" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblIntegrante" runat="server" Text='<%# Bind("d_empleado") %>'></asp:Label>
                                <asp:DropDownList ID="ddlIntegrante" runat="server" CssClass="textoChicoNegro_" Width="150px"
                                    Visible="false">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Objective achieved" HeaderStyle-Width="70px" ItemStyle-HorizontalAlign="Center"
                            FooterText="Average">
                            <ItemTemplate>
                                <asp:Label ID="lbl_objLogrado" runat="server" Text='<%# Bind("obj_Logrado") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="% Effectiveness" HeaderStyle-Width="70px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lbl_rowEficacia" runat="server" Text='<%# Bind("Eficacia") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lbl_promedioEficacia" runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Completion Date" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center"
                            FooterText="Average">
                            <ItemTemplate>
                                <asp:Label ID="lbl_fCumplimiento" runat="server" Text='<%# Bind("f_Cumplimiento") %>'></asp:Label>
                                <asp:TextBox ID="txt_fCumplimiento" runat="server" Visible="false" MaxLength="10"
                                    CssClass="textoChicoNegro_" Width="50px" OnTextChanged="txt_fCumplimiento_TextChanged"
                                    AutoPostBack="true">
                                </asp:TextBox>
                                <asp:ImageButton ID="Fecha2" runat="server" ImageUrl="~/imagenesBasicas/iconos/Calendario2.png"
                                    Visible="false" />
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" PopupButtonID="Fecha2"
                                    TargetControlID="txt_fCumplimiento">
                                </cc1:CalendarExtender>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" Mask="99/99/9999"
                                    TargetControlID="txt_fCumplimiento" MaskType="Date" AcceptAMPM="false">
                                </cc1:MaskedEditExtender>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="% Efficiency" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lbl_rowEficencia" runat="server" Text='<%# Bind("Eficiencia") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lbl_promedioEficencia" runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Weeks Behind" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lbl_SemanaAtrazo" runat="server" Text='<%# Bind("SemanaAtrazo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Areas for Improvement" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lbl_areasOp" runat="server" Text='<%# Bind("Area_Oportunidad") %>'></asp:Label>
                                <asp:TextBox ID="txt_areasOp" runat="server" Visible="false" CssClass="textoChicoNegro_"
                                    Width="180px"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="btn_Cancelar" runat="server" ImageUrl="imagenesBasicas/iconos/Cancelar.png"
                                    Visible="false" OnClick="btn_Cancelar_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="IDobj" HeaderText="IDobj">
                            <HeaderStyle Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="IDMat" HeaderText="IDMat">
                            <HeaderStyle Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="id_integrante" HeaderText="id_integrante">
                            <HeaderStyle Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="d_email" HeaderText="mail">
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
        <tr>
            <td colspan="4">
                <asp:GridView ID="gvMiembro" runat="server" Width="1000px" AutoGenerateColumns="false"
                    ShowFooter="true" CellPadding="4" CssClass="resultTable" GridLines="None" 
                    EmptyDataText = "Sin Datos" 
                    OnRowCreated="gv_ObjetivosPrioritarios_RowCreated"
                    Visible="false">
                    <Columns>
                        <asp:TemplateField HeaderText="Description" HeaderStyle-Width="300px" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lbl_Desc" runat="server" Text='<%# Bind("Descripcion") %>'></asp:Label>
                                <asp:TextBox ID="txt_Desc" runat="server" Visible="false" CssClass="textoChicoNegro_"
                                    Width="280px"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Target Date" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lbl_fCompromiso" runat="server" Text='<%# Bind("f_Compromiso") %>'></asp:Label>
                                <asp:TextBox ID="txt_fCompromiso" runat="server" Visible="false" MaxLength="10" CssClass="textoChicoNegro_"
                                    Width="50px" OnTextChanged="txt_fCompromiso_TextChanged" AutoPostBack="true">
                                </asp:TextBox>                                
                            </ItemTemplate>
                        </asp:TemplateField>                        
                        <asp:TemplateField HeaderText="Objetive Archieved" HeaderStyle-Width="70px" ItemStyle-HorizontalAlign="Center"
                            FooterText="Average">
                            <ItemTemplate>
                                <asp:Label ID="lbl_objLogrado" runat="server" Text='<%# Bind("obj_Logrado") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="% Effectiveness" HeaderStyle-Width="70px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lbl_rowEficacia" runat="server" Text='<%# Bind("Eficacia") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lbl_promedioEficacia" runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Completion Date" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center"
                            FooterText="Average">
                            <ItemTemplate>
                                <asp:Label ID="lbl_fCumplimiento" runat="server" Text='<%# Bind("f_Cumplimiento") %>'></asp:Label>

                                <asp:TextBox ID="txt_fCumplimiento" runat="server" Visible="false" MaxLength="10"
                                    CssClass="textoChicoNegro_" Width="50px" OnTextChanged="txt_fCumplimiento_TextChanged"
                                    AutoPostBack="true">
                                </asp:TextBox>                                
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="% Efficiency" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lbl_rowEficencia" runat="server" Text='<%# Bind("Eficiencia") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lbl_promedioEficencia" runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Weeks Behind" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lbl_SemanaAtrazo" runat="server" Text='<%# Bind("SemanaAtrazo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Areas de Oportunidad" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lbl_areasOp" runat="server" Text='<%# Bind("Area_Oportunidad") %>'></asp:Label>
                                <asp:TextBox ID="txt_areasOp" runat="server" Visible="false" CssClass="textoChicoNegro_"
                                    Width="180px"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="d_email" HeaderText="mail">
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
        <tr>
            <td>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btn_Salir" runat="server" Text="Save" CssClass="btn_GrisRedondo"
                    OnClick="btn_Salir_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
