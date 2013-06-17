<%@ Page Title="" Language="C#" MasterPageFile="~/mp_MenuPrincipal.Master" AutoEventWireup="true" CodeBehind="wf_MatrizIndividual.aspx.cs" Inherits="betaCulturalMARKII.wf_MatrizIndividual" MaintainScrollPositionOnPostback="true"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 28px;
        }
        .style2
        {
            width: 117px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="950px">
        <tr>
            <td>
                <asp:Label ID="lbl_Titulo_MatrizIndividual" runat="server" Text="[lbl_Titulo]" CssClass="tituloAzul_" Visible="false"></asp:Label>
                <asp:Label ID="Label4" runat="server" Text="NEW INDIVIDUAL MATRIX " CssClass="tituloAzul_"></asp:Label>
                </td>
            <td align="center"></td>
          
        </tr>
        <tr>
            <td align="left">
                <asp:Panel ID="pnlFechaMatrizVigente" runat="server" Visible="false">                    
                    <table width="400px">                    
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label1" runat="server" Text="Weekly Objectives From"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lbl_FechaInicio" runat="server" Text="[lbl_FechaInicio]"></asp:Label>
                            </td>
                            <td align="center" class="style1">
                                <asp:Label ID="Label2" runat="server" Text="To"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lbl_FechaFin" runat="server" Text="[lbl_FechaFin]"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <br />
                <asp:Panel ID="pnlMatrizIndividualNew" runat="server" Visible="false">                    
                    <table width="450px">                    
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label3" runat="server" Text="Weekly Objectives From"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:TextBox ID="txt_FechaInicioMatrizNew" runat="server" MaxLength="10" AutoPostBack="true"
                                    Width="70px" ontextchanged="txt_FechaInicioMatrizNew_TextChanged">
                                </asp:TextBox>
                                <asp:ImageButton ID="btnFechaInicio" runat="server" ImageUrl="~/imagenesBasicas/iconos/Calendario2.png" />
                                <cc1:CalendarExtender  ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" PopupButtonID="btnFechaInicio"
                                                        TargetControlID="txt_FechaInicioMatrizNew">
                                </cc1:CalendarExtender>
                            </td>
                            <td align="center">
                                <asp:Label ID="Label5" runat="server" Text="To"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:TextBox ID="txt_FechaFinMatrizNew" runat="server" MaxLength="10" 
                                    Width="70px" ontextchanged="txt_FechaFinMatrizNew_TextChanged" AutoPostBack="true">
                                </asp:TextBox>
                                <asp:ImageButton ID="btnFechaFin" runat="server" ImageUrl="~/imagenesBasicas/iconos/Calendario2.png" />
                                <cc1:CalendarExtender  ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy" PopupButtonID="btnFechaFin"
                                                        TargetControlID="txt_FechaFinMatrizNew">
                                </cc1:CalendarExtender>
                            </td>
                            <td>
                                
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td>
                <asp:Label ID="Label9" runat="server" Text="PERFORMANCE<br> FOR THE WEEK"></asp:Label>
            </td>
            <td align="center">
                
                <table style="width: 353px">
                   
                    <tr>
                    <td style="background-color:#00407F"><h4><span class="textoNormalBlanco_">%Overall</span> </h4></td>
                    <td style="background-color:#00407F"><h4><span class="textoNormalBlanco_">%Effectiveness</span></h4></td>
                    <td style="background-color:#00407F"><h4><span class="textoNormalBlanco_">%Efficiency</span></h4></td>
                    </tr>
                    
                    <tr>
                    
                    <td style="background-color:#d4d4d4">
                            <h4><asp:Label ID="lbl_Porc_Efectividad" runat="server" Text="0.0"></asp:Label></h4>
                     </td>
                    <td style="background-color:#d4d4d4">
                            <h4><asp:Label ID="lbl_Porc_Eficacia" runat="server" Text="0.0"></asp:Label></h4>
                    </td>
                    <td style="background-color:#d4d4d4">
                            <h4><asp:Label ID="lbl_Porc_Eficiencia" runat="server" Text="0.0"></asp:Label></h4>                
                    </td>
                    </tr>
                </table>
            </td>
            
        </tr>        
        <tr>
            <td colspan="4"><br /></td>
        </tr>
        <tr>
            <td colspan="4">
              <asp:Label ID="Label6" runat="server" Text="Primary" Visible="false"></asp:Label>                
                <%-- GRID OBJETIVOS PRIORITARIOS --%>
                <asp:GridView ID="gv_ObjetivosPrioritarios" runat="server" Width="1000px" 
                              AutoGenerateColumns="false" ShowFooter="true" PageSize="5"
                              CellPadding="4" CssClass="resultTable" GridLines="None" 
                              onrowcreated="gv_ObjetivosPrioritarios_RowCreated"
                              OnRowDataBound="gv_ObjetivosPrioritarios_RowDataBound">
                    <Columns>                                                
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="btn_EditarOP" runat="server" ImageUrl="imagenesBasicas/iconos/edit_black.png" OnClick="btn_EditarOP_Click" />
                                <asp:ImageButton ID="btn_AceptarOP" runat="server" ImageUrl="imagenesBasicas/iconos/Aceptar.png" OnClick="btn_AceptarOP_Click" Visible="false" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description" HeaderStyle-Width="300px" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lbl_Desc" runat="server" Text='<%# Bind("Descripcion") %>'></asp:Label>
                                <asp:TextBox ID="txt_Desc" runat="server" Visible="false" CssClass="textoChicoNegro_" Width="280px"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
        
                        <asp:TemplateField HeaderText="Target Date" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lbl_fCompromiso" runat="server" Text='<%# Bind("f_Compromiso") %>'></asp:Label>
                                <asp:TextBox ID="txt_fCompromisoOP" runat="server" Visible="false" MaxLength="10" CssClass="textoChicoNegro_" 
                                             Width="50px" OnTextChanged="txt_fCompromisoOP_TextChanged" AutoPostBack="true">
                                </asp:TextBox>
                                <asp:ImageButton ID="Fecha1" runat="server" ImageUrl="~/imagenesBasicas/iconos/Calendario2.png" Visible="false" />
                                <cc1:CalendarExtender  ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" PopupButtonID="Fecha1"
                                                        TargetControlID="txt_fCompromisoOP" OnClientDateSelectionChanged="">
                                </cc1:CalendarExtender>                                
                            </ItemTemplate>
                        </asp:TemplateField>
        
                        <asp:TemplateField HeaderText="Objective achieved" HeaderStyle-Width="70px" ItemStyle-HorizontalAlign="Center" FooterText="Average">
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
        
                        <asp:TemplateField HeaderText="Completion Date" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center" FooterText="Average">
                            <ItemTemplate>
                                <asp:Label ID="lbl_fCumplimiento" runat="server" Text='<%# Bind("f_Cumplimiento") %>'></asp:Label>
                                <asp:TextBox ID="txt_fCumplimientoOP" runat="server" Visible="false" MaxLength="10" CssClass="textoChicoNegro_"  
                                             Width="50px" OnTextChanged="txt_fCumplimientoOP_TextChanged" AutoPostBack="true">
                                </asp:TextBox>  
                                <asp:ImageButton ID="Fecha2" runat="server" ImageUrl="~/imagenesBasicas/iconos/Calendario2.png" Visible="false" />
                                <cc1:CalendarExtender  ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" PopupButtonID="Fecha2"
                                                        TargetControlID="txt_fCumplimientoOP">
                                </cc1:CalendarExtender>
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
                                                                                                                                                                                
                        <asp:TemplateField HeaderText="Areas for improvement" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lbl_areasOp" runat="server" Text='<%# Bind("Area_Oportunidad") %>'></asp:Label>
                                <asp:TextBox ID="txt_areasOp" runat="server" Visible="false" CssClass="textoChicoNegro_"  Width="180px"></asp:TextBox>
                            </ItemTemplate>                        
                        </asp:TemplateField>
        
                        <asp:TemplateField>
                            <ItemTemplate>
                                    <asp:ImageButton ID="btn_CancelarOP" runat="server" ImageUrl="imagenesBasicas/iconos/Cancelar.png" Visible="false" OnClick="btn_CancelarOP_Click"  />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="IDobj" HeaderText ="IDobj">
                            <HeaderStyle Width="50px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="IDMat" HeaderText ="IDMat">
                            <HeaderStyle Width="50px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="id_integrante" HeaderText ="id_integrante">
                            <HeaderStyle Width="50px" />
                        </asp:BoundField>
                                                                                
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
            <td colspan="4"><br /></td>
        </tr>
        <tr>
            <td colspan="4">
            <asp:Label ID="Label7" runat="server" Text="Secondary" Visible="false"></asp:Label>
                <%-- GRID OBJETIVOS SECUNDARIOS--%>
                <asp:GridView ID="gv_ObjetivosSecundarios" runat="server" Width="1000px" 
                              AutoGenerateColumns="false" ShowFooter="true" PageSize="5"
                              CellPadding="4" CssClass="resultTable" GridLines="None" 
                              onrowcreated="gv_ObjetivosSecundarios_RowCreated"
                              OnRowDataBound="gv_ObjetivosSecundarios_RowDataBound" 
                    onselectedindexchanged="gv_ObjetivosSecundarios_SelectedIndexChanged">
                    <Columns>                                                
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="btn_EditarOS" runat="server" ImageUrl="imagenesBasicas/iconos/edit_black.png" OnClick="btn_EditarOS_Click" />
                                <asp:ImageButton ID="btn_AceptarOS" runat="server" ImageUrl="imagenesBasicas/iconos/Aceptar.png" OnClick="btn_AceptarOS_Click" Visible="false" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description" HeaderStyle-Width="300px" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lbl_Desc" runat="server" Text='<%# Bind("Descripcion") %>'></asp:Label>
                                <asp:TextBox ID="txt_Desc" runat="server" Visible="false" CssClass="textoChicoNegro_" Width="280px"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
        
                        <asp:TemplateField HeaderText="Target Date" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lbl_fCompromiso" runat="server" Text='<%# Bind("f_Compromiso") %>'></asp:Label>
                                <asp:TextBox ID="txt_fCompromisoOS" runat="server" Visible="false" MaxLength="10" CssClass="textoChicoNegro_" 
                                             Width="50px" OnTextChanged="txt_fCompromisoOS_TextChanged" AutoPostBack="true">
                                </asp:TextBox>
                                <asp:ImageButton ID="Fecha1" runat="server" ImageUrl="~/imagenesBasicas/iconos/Calendario2.png" Visible="false" />
                                <cc1:CalendarExtender  ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" PopupButtonID="Fecha1"
                                                        TargetControlID="txt_fCompromisoOS" OnClientDateSelectionChanged="">
                                </cc1:CalendarExtender>                                
                            </ItemTemplate>
                        </asp:TemplateField>
        
                        <asp:TemplateField HeaderText="Objective achieved" HeaderStyle-Width="70px" ItemStyle-HorizontalAlign="Center" FooterText="Average">
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
        
                        <asp:TemplateField HeaderText="Completion Date" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center" FooterText="Average">
                            <ItemTemplate>
                                <asp:Label ID="lbl_fCumplimiento" runat="server" Text='<%# Bind("f_Cumplimiento") %>'></asp:Label>
                                <asp:TextBox ID="txt_fCumplimientoOS" runat="server" Visible="false" MaxLength="10" CssClass="textoChicoNegro_"  
                                             Width="50px" OnTextChanged="txt_fCumplimientoOS_TextChanged" AutoPostBack="true">
                                </asp:TextBox>  
                                <asp:ImageButton ID="Fecha2" runat="server" ImageUrl="~/imagenesBasicas/iconos/Calendario2.png" Visible="false" />
                                <cc1:CalendarExtender  ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" PopupButtonID="Fecha2"
                                                        TargetControlID="txt_fCumplimientoOS">
                                </cc1:CalendarExtender>
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
                                                                                                                                                                                
                        <asp:TemplateField HeaderText="Areas for improvement" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lbl_areasOp" runat="server" Text='<%# Bind("Area_Oportunidad") %>'></asp:Label>
                                <asp:TextBox ID="txt_areasOp" runat="server" Visible="false" CssClass="textoChicoNegro_"  Width="180px"></asp:TextBox>
                            </ItemTemplate>                        
                        </asp:TemplateField>
        
                        <asp:TemplateField>
                            <ItemTemplate>
                                    <asp:ImageButton ID="btn_CancelarOS" runat="server" ImageUrl="imagenesBasicas/iconos/Cancelar.png" Visible="false" OnClick="btn_CancelarOS_Click"  />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="IDobj" HeaderText ="IDobj">
                            <HeaderStyle Width="50px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="IDMat" HeaderText ="IDMat">
                            <HeaderStyle Width="50px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="id_integrante" HeaderText ="id_integrante">
                            <HeaderStyle Width="50px" />
                        </asp:BoundField>
                                                        
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
            <td colspan="4"><br /></td>
        </tr>
        <tr>
            <td colspan="4">
            <asp:Label ID="Label8" runat="server" Text="Permanent" Visible="false"></asp:Label>
                <%-- GRID OBJETIVOS PERMANENTES --%>
                <asp:GridView ID="gv_ObjetivosPermanentes" runat="server" Width="1000px" 
                              AutoGenerateColumns="false" ShowFooter="true" PageSize="5"
                              CellPadding="4" CssClass="resultTable" GridLines="None" 
                              onrowcreated="gv_ObjetivosPermanentes_RowCreated"
                              OnRowDataBound="gv_ObjetivosPermanentes_RowDataBound">
                    <Columns>                                                
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="btn_EditarOPe" runat="server" ImageUrl="imagenesBasicas/iconos/edit_black.png" OnClick="btn_EditarOPe_Click" />
                                <asp:ImageButton ID="btn_AceptarOPe" runat="server" ImageUrl="imagenesBasicas/iconos/Aceptar.png" OnClick="btn_AceptarOPe_Click" Visible="false" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description" HeaderStyle-Width="300px" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lbl_Desc" runat="server" Text='<%# Bind("Descripcion") %>'></asp:Label>
                                <asp:TextBox ID="txt_Desc" runat="server" Visible="false" CssClass="textoChicoNegro_" Width="280px"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
        
                        <asp:TemplateField HeaderText="Target Date" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lbl_fCompromiso" runat="server" Text='<%# Bind("f_Compromiso") %>'></asp:Label>
                                <asp:TextBox ID="txt_fCompromisoOPe" runat="server" Visible="false" MaxLength="10" CssClass="textoChicoNegro_" 
                                             Width="50px" OnTextChanged="txt_fCompromisoOPe_TextChanged" AutoPostBack="true">
                                </asp:TextBox>
                                <asp:ImageButton ID="Fecha1" runat="server" ImageUrl="~/imagenesBasicas/iconos/Calendario2.png" Visible="false" />
                                <cc1:CalendarExtender  ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" PopupButtonID="Fecha1"
                                                        TargetControlID="txt_fCompromisoOPe" OnClientDateSelectionChanged="">
                                </cc1:CalendarExtender>                                
                            </ItemTemplate>
                        </asp:TemplateField>
        
                        <asp:TemplateField HeaderText="Objective achieved" HeaderStyle-Width="70px" ItemStyle-HorizontalAlign="Center" FooterText="Average">
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
        
                        <asp:TemplateField HeaderText="Completion Date" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center" FooterText="Average">
                            <ItemTemplate>
                                <asp:Label ID="lbl_fCumplimiento" runat="server" Text='<%# Bind("f_Cumplimiento") %>'></asp:Label>
                                <asp:TextBox ID="txt_fCumplimientoOPe" runat="server" Visible="false" MaxLength="10" CssClass="textoChicoNegro_"  
                                             Width="50px" OnTextChanged="txt_fCumplimientoOPe_TextChanged" AutoPostBack="true">
                                </asp:TextBox>  
                                <asp:ImageButton ID="Fecha2" runat="server" ImageUrl="~/imagenesBasicas/iconos/Calendario2.png" Visible="false" />
                                <cc1:CalendarExtender  ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" PopupButtonID="Fecha2"
                                                        TargetControlID="txt_fCumplimientoOPe">
                                </cc1:CalendarExtender>
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
                                                                                                                                                                                
                        <asp:TemplateField HeaderText="Areas for improvement" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lbl_areasOp" runat="server" Text='<%# Bind("Area_Oportunidad") %>'></asp:Label>
                                <asp:TextBox ID="txt_areasOp" runat="server" Visible="false" CssClass="textoChicoNegro_"  Width="180px"></asp:TextBox>
                            </ItemTemplate>                        
                        </asp:TemplateField>
        
                        <asp:TemplateField>
                            <ItemTemplate>
                                    <asp:ImageButton ID="btn_CancelarOPe" runat="server" ImageUrl="imagenesBasicas/iconos/Cancelar.png" Visible="false" OnClick="btn_CancelarOPe_Click"  />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="IDobj" HeaderText ="IDobj">
                            <HeaderStyle Width="50px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="IDMat" HeaderText ="IDMat">
                            <HeaderStyle Width="50px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="id_integrante" HeaderText ="id_integrante">
                            <HeaderStyle Width="50px" />
                        </asp:BoundField>
                                                        
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
            <td><br /></td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btn_Salir" runat="server" Text="Save" 
                    CssClass="btn_GrisRedondo" onclick="btn_Salir_Click" />                
            </td>
        </tr>
    </table>
</asp:Content>
