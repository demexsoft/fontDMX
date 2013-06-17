<%@ Page Title="" Language="C#" MasterPageFile="~/mp_MenuPrincipal.Master" AutoEventWireup="true" CodeBehind="individual_folders_fecha.aspx.cs" Inherits="betaCulturalMARKII.matrizIndiv.individual_folders_fecha" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




 <!--pnl_content_folders--->
    <asp:Panel ID="pnl_content_folders" runat="server" >




     <!--pnl_content_calendario--->
    <asp:Panel ID="pnl_content_calendario" runat="server" Visible="false">
               
               <asp:LinkButton  ID="lnk_cerrar_panel_calendario" runat="server" Text="Cerrar" CssClass="textoNormalBlanco_" OnClick="lnk_cerrar_panel_calendario_Click"></asp:LinkButton>
                <br/>
               <asp:Calendar ID="cln_calendarioGenerico" runat="server"  BorderStyle="Solid" CellPadding="1" 
                                    onselectionchanged="cln_calendarioGenerico_SelectionChanged" >
                    <SelectedDayStyle BackColor="#FF0066" />
                        <WeekendDayStyle Font-Size="8pt"/>
               </asp:Calendar>
               
           </asp:Panel>
    <!--pnl_content_calendario--->


        <table width="100%"  Height="300px">
            <tr  align="center">
                <td>
                                            
                    <asp:ImageButton ID="btn_img_enero" runat="server" 
                        ImageUrl="~/imagenesBasicas/botonesImagenes/iconos/folder.jpg" 
                        onclick="btn_img_enero_Click"/> 
                    <br/>
                    <asp:Label ID="lbl_aviso_enero" runat="server" CssClass="textoChicoAzul_"></asp:Label>

                </td>
                <td>
                    <asp:ImageButton ID="btn_img_febrero" runat="server" 
                        ImageUrl="~/imagenesBasicas/botonesImagenes/iconos/folder.jpg" 
                        onclick="btn_img_febrero_Click"/>
                    <br/>
                    <asp:Label ID="lbl_aviso_febrero" runat="server" CssClass="textoChicoAzul_"></asp:Label>
                </td>
                <td>
                    <asp:ImageButton ID="btn_img_marzo" runat="server" 
                        ImageUrl="~/imagenesBasicas/botonesImagenes/iconos/folder.jpg" 
                        onclick="btn_img_marzo_Click"/>
                    <br/>
                        <asp:Label ID="lbl_aviso_marzo" runat="server" CssClass="textoChicoAzul_"></asp:Label>
                </td>
                <td>
                    <asp:ImageButton ID="btn_img_abril" runat="server" 
                        ImageUrl="~/imagenesBasicas/botonesImagenes/iconos/folder.jpg" 
                        onclick="btn_img_abril_Click"/>
                    <br/>
                    <asp:Label ID="lbl_aviso_abril" runat="server" CssClass="textoChicoAzul_"></asp:Label>
                </td>
                                          
            </tr>
                <tr  align="center">
                <td>
                    <asp:ImageButton ID="btn_img_mayo" runat="server" 
                        ImageUrl="~/imagenesBasicas/botonesImagenes/iconos/folder.jpg" 
                        onclick="btn_img_mayo_Click"/>
                        <br/>
                    <asp:Label ID="lbl_aviso_mayo" runat="server" CssClass="textoChicoAzul_"></asp:Label>
                </td>
                <td>
                    <asp:ImageButton ID="btn_img_junio" runat="server" 
                        ImageUrl="~/imagenesBasicas/botonesImagenes/iconos/folder.jpg" 
                        onclick="btn_img_junio_Click"/>
                        <br/>
                    <asp:Label ID="lbl_aviso_junio" runat="server" CssClass="textoChicoAzul_"></asp:Label>
                </td>
                <td>
                    <asp:ImageButton ID="btn_img_julio" runat="server" 
                        ImageUrl="~/imagenesBasicas/botonesImagenes/iconos/folder.jpg" 
                        onclick="btn_img_julio_Click"/>
                        <br/>
                    <asp:Label ID="lbl_aviso_julio" runat="server" CssClass="textoChicoAzul_"></asp:Label>
                </td>
                <td>
                    <asp:ImageButton ID="btn_img_agosto" runat="server" 
                        ImageUrl="~/imagenesBasicas/botonesImagenes/iconos/folder.jpg" 
                        onclick="btn_img_agosto_Click"/>
                        <br/>
                    <asp:Label ID="lbl_aviso_agosto" runat="server" CssClass="textoChicoAzul_"></asp:Label>
                </td>
            </tr>
            <tr  align="center">
                <td>
                    <asp:ImageButton ID="btn_img_septiembre" runat="server" 
                        ImageUrl="~/imagenesBasicas/botonesImagenes/iconos/folder.jpg" 
                        onclick="btn_img_septiembre_Click"/>
                        <br/>
                    <asp:Label ID="lbl_aviso_septiembre" runat="server" CssClass="textoChicoAzul_"></asp:Label>
                </td>
                <td>
                    <asp:ImageButton ID="btn_img_octubre" runat="server" 
                        ImageUrl="~/imagenesBasicas/botonesImagenes/iconos/folder.jpg" 
                        onclick="btn_img_octubre_Click"/>
                        <br/>
                    <asp:Label ID="lbl_aviso_octubre" runat="server" CssClass="textoChicoAzul_"></asp:Label>
                </td>
                <td>
                    <asp:ImageButton ID="btn_img_noviembre" runat="server" 
                        ImageUrl="~/imagenesBasicas/botonesImagenes/iconos/folder.jpg" 
                        onclick="btn_img_noviembre_Click"/>
                                <br/>
                    <asp:Label ID="lbl_aviso_noviembre" runat="server" CssClass="textoChicoAzul_"></asp:Label>
                </td>
                <td>
                    <asp:ImageButton ID="btn_img_diciembre" runat="server" 
                        ImageUrl="~/imagenesBasicas/botonesImagenes/iconos/folder.jpg" 
                        onclick="btn_img_diciembre_Click"/>
                            <br/>
                    <asp:Label ID="lbl_aviso_diciembre" runat="server" CssClass="textoChicoAzul_"></asp:Label>
                </td>
            </tr>
                                    
        </table>
        <table>
            <tr valign="bottom">
                <td>
                    <asp:Label ID="Label96" Text="Start Date" runat="server" CssClass="textoChicoAzul_"></asp:Label>
                    <br/>                    
                    <asp:TextBox ID="txt_rangoFechas_inicio_matriz" runat="server" CssClass="textoNormal_" ></asp:TextBox> 
                    <asp:ImageButton ID="btnFechaInicio" runat="server" ImageUrl="~/imagenesBasicas/iconos/Calendario2.png" />
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" PopupButtonID="btnFechaInicio"
                    TargetControlID="txt_rangoFechas_inicio_matriz">
                </cc1:CalendarExtender>
                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999"
                    TargetControlID="txt_rangoFechas_inicio_matriz" MaskType="Date" AcceptAMPM="false">
                </cc1:MaskedEditExtender>
                </td>
                <td>
                    <asp:Label ID="Label97" Text="End Date" runat="server" CssClass="textoChicoAzul_"></asp:Label>
                    <br/>                    
                    <asp:TextBox ID="txt_rangoFechas_fin_matriz" runat="server" CssClass="textoNormal_" ></asp:TextBox> 
                    <asp:ImageButton ID="btnFechaFin" runat="server" ImageUrl="~/imagenesBasicas/iconos/Calendario2.png" />
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" PopupButtonID="btnFechaFin"
                        TargetControlID="txt_rangoFechas_fin_matriz">
                    </cc1:CalendarExtender>
                    <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999"
                        TargetControlID="txt_rangoFechas_fin_matriz" MaskType="Date" AcceptAMPM="false">
                    </cc1:MaskedEditExtender>

                </td>
                <td>
                    <asp:Button ID="btn_rangoFechas_buscar_matriz" Text="Search" OnClick="btn_rangoFechas_buscar_matriz_Click" runat="server" CssClass="textoNormal_" /> 

                </td>
            </tr>
        </table>
                                  
    </asp:Panel>
        <!--pnl_content_foldersMatrixIndividual---> 


          
                <asp:Table ID="tbl_verTodasMatrizIndividual" runat="server" CssClass="textoNormal_" >
                    <asp:TableRow>
                        <asp:TableCell>
                        <asp:Label ID="lbl_aviso_indicacionesMatrizIndividual" CssClass="textoNormal_" runat="server"></asp:Label>
                            <asp:DataGrid ID="dg_verTodasMatrizesIndividual" runat="server" CssClass="resultTable"
                                        BorderStyle="None" BorderWidth="0px" ForeColor="Black"  CellPadding="4"
                                        BackColor="White" BorderColor="#999999"                                                     
                                        ShowHeader="true" GridLines="none" 
                                    AutoGenerateColumns="false"  Width="650px" 
                             onitemcommand="dg_verTodasMatrizes_ItemCommand" AlternatingItemStyle-BackColor="#A9EFFE"  DataKeyField="eficiencia" OnItemCreated="dg_verTodasMatrizesIndividual_OnItemCreated" >
                                     <Columns>
                                         <asp:TemplateColumn  HeaderText="Matriz">
                                               <ItemTemplate>
                                                  <asp:ImageButton id="selectimgbtn" Height="15px"  Width="15px" Runat="server" CommandName="Select" CausesValidation="False" 
                                                                            ImageUrl="~/imagenesBasicas/botonesImagenes/iconos/modificar.jpg">
                                                    </asp:ImageButton>
                                                 </ItemTemplate>
                                          </asp:TemplateColumn>

                                             
                                             <%--1--%><asp:BoundColumn   DataField="statusMat"    HeaderText="Estatus"   Visible="false"> </asp:BoundColumn>
                                             <%--2--%><asp:BoundColumn   DataField="IDMatriz"     HeaderText="Matrix"    Visible="false"> </asp:BoundColumn>
                                             <%--3--%><asp:BoundColumn   DataField="IDEmpcreador" HeaderText="Creador"   Visible="false"> </asp:BoundColumn>
                                             <%--4--%><asp:BoundColumn   DataField="IDEmprevi"    HeaderText="JEFE"      Visible="false" HeaderStyle-Width="90px">  </asp:BoundColumn>
                                             <%--5--%><asp:BoundColumn   DataField="nomEmp"       HeaderText="creador" Visible="false"      HeaderStyle-Width="90px"> </asp:BoundColumn>
                                             <%--9--%><asp:BoundColumn   DataField="f_inicio"     HeaderText="Start Date">    </asp:BoundColumn>
                                             <%--10--%><asp:BoundColumn   DataField="f_final"      HeaderText="End Date">      </asp:BoundColumn>
                                             <%--6--%><asp:BoundColumn   DataField="eficiencia"   HeaderText="Effectiveness">   </asp:BoundColumn>
					                         <%--7--%><asp:BoundColumn   DataField="eficacia"     HeaderText="Efficiency">     </asp:BoundColumn>
                                             <%--8--%><asp:BoundColumn   DataField="actividadesrecordar" HeaderText="Actividades Relevantes" Visible="false"></asp:BoundColumn>
                                          <asp:TemplateColumn HeaderText="Overall" ItemStyle-Width="120px" HeaderStyle-HorizontalAlign="Center">
                                               <ItemTemplate>
                                                 <asp:Panel ID="pnl_bar_grafica" runat="server" BorderStyle="Solid" BorderWidth="1px" Width="100px">
                                                 <asp:Image  ID="lbl_grafica_mat_Individual" runat="server"> </asp:Image>
                                                 <asp:Label ID="lbl_PorcEfectividad" runat="server" Text="0%"></asp:Label>
                                                 </asp:Panel>
                                                               
                                          </ItemTemplate>
                                      </asp:TemplateColumn>
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

                <!--tbl MATRIZ INDIVIDUAL-->

</asp:Content>
