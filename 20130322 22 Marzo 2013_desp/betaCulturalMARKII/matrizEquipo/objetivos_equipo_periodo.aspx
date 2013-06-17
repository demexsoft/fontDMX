<%@ Page Title="" Language="C#" MasterPageFile="~/mp_MenuPrincipal.Master" AutoEventWireup="true" CodeBehind="objetivos_equipo_periodo.aspx.cs" Inherits="betaCulturalMARKII.matrizEquipo.objetivos_equipo_periodo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!--pnl_content_fechas--->
      <asp:Panel ID="pnl_content_fechas" runat="server">
        <table>            
              <tr>
                <td>
                <asp:Label ID="lbl_aviso" Text="Fecha Inicio" runat="server" CssClass="textoNormal_"></asp:Label>
                <asp:TextBox ID="txt_FechaInicioObjetivoEquipo" runat="server" MaxLength="10" Width="70px">  </asp:TextBox>
                <asp:ImageButton ID="btnFechaInicio" runat="server" ImageUrl="~/imagenesBasicas/iconos/Calendario2.png" />
                                <cc1:CalendarExtender  ID="clnext_FechaInicio" runat="server" Format="dd/MM/yyyy" PopupButtonID="btnFechaInicio" TargetControlID="txt_FechaInicioObjetivoEquipo">
                                </cc1:CalendarExtender>
                </td>
                <td>
                <asp:Label ID="Label2" Text="Fecha Final" runat="server" CssClass="textoNormal_"></asp:Label>                
                 <asp:TextBox ID="txt_FechaFinalObjetivoEquipo" runat="server" CssClass="textoNormal_"  MaxLength="10" Width="70px"></asp:TextBox>
                 <asp:ImageButton ID="btnFinalInicio" runat="server" ImageUrl="~/imagenesBasicas/iconos/Calendario2.png" />
                                <cc1:CalendarExtender  ID="clnext_FechaIFinal" runat="server" Format="dd/MM/yyyy" PopupButtonID="btnFinalInicio" TargetControlID="txt_FechaFinalObjetivoEquipo">
                                </cc1:CalendarExtender>
                </td>
            </tr>
        </table>
        <asp:Button ID="btn_buscar_objetivo_fecha" Text="Buscar" CssClass="btn_GrisRedondo" 
              runat="server" onclick="btn_buscar_objetivo_fecha_Click" />

        <br/>
        <br/>

              
          
      </asp:Panel>
    <!--pnl_content_fechas--->
        <br/>
        <br/>

<asp:Table ID="tbl_objetivosEquipo_ver" runat="server">
                    
                        <asp:TableRow VerticalAlign="Top" CssClass="textoNormal_">
                            <asp:TableCell>

                                <table  width="600px">
                                <tr>
                                    <td><asp:Label ID="Label15" runat="server" Text="% EFICACIA" Font-Bold="true"></asp:Label><br/>
                                        <asp:Label ID="lbl_eficacia_modifica_objEquipo" runat="server" Width="100px" Text="0"></asp:Label>
                                    </td>
                                    <td><asp:Label ID="Label56" runat="server" Text="% EFICIENCIA" Font-Bold="true"></asp:Label><br/>
                                        <asp:Label ID="lbl_eficiencia_modifica_objEquipo" runat="server" Width="100px" Text="0"></asp:Label>
                                    </td>
                                    <td>
                                     <asp:Label ID="Label61" runat="server" Text="Logrado"></asp:Label>
                                        <br/>
                                     <asp:Label ID="lbl_status_objIndividual" runat="server"></asp:Label>
                                    </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label66" runat="server" Text="Cumplimiento"></asp:Label><br/>                                            
                                            <asp:TextBox ID="txt_fecha_cumplimiento_modifica_objEquipo" runat="server" ReadOnly="true"></asp:TextBox>
                                            <asp:Image ID="img_Cumplimiento_modifica_objEquipo" runat="server" ImageUrl="~/imagenesBasicas/iconos/Calendario2.png" />

                                            <br/>
                                            <br/>
                                            
                                        </td>
                                        <td>
                                            
                                        </td>
                                        <td>
                                            <asp:Label ID="Label68" runat="server" Text="Areas de Oportunidad"></asp:Label><br/>
                                            <asp:TextBox ID="txt_areasOportunidad_modifica_objEquipo" ReadOnly="true" runat="server" Height="40px" TextMode="MultiLine" Width="300px"></asp:TextBox>
                                        </td>
                                </tr>
                               
                                </table>

                                <br/>

                                <asp:DataGrid ID="dg_objetivosEquipo" runat="server" 
                                                    CssClass="textoNormal_" BackColor="White" BorderColor="#999999" 
                                                    BorderStyle="Solid" BorderWidth="2px" ForeColor="Black" AutoGenerateColumns="false"
                                                    ShowHeader="true" GridLines="Both" 
                                                   OnItemCommand="dg_objetivosEquipo_ItemCommand" 
                                                       Width="700px" AlternatingItemStyle-BackColor="#A9EFFE">
                                                        
                                                    <Columns>
                                                            
                                                         <asp:TemplateColumn>
                                                                <ItemTemplate>
                                                                    <asp:ImageButton id="selectimgbtn" Height="15px"  Width="15px" Runat="server" CommandName="Select" CausesValidation="False" 
                                                                            ImageUrl="~/imagenesBasicas/botonesImagenes/iconos/modificar.jpg">
                                                                    </asp:ImageButton>
                                                                </ItemTemplate>
                                                         </asp:TemplateColumn>
                                                         
                                                         <%--1--%><asp:BoundColumn  DataField="IDObjEquipo"         HeaderText="ID" Visible="false"> </asp:BoundColumn>
                                                         <%--2--%><asp:BoundColumn  DataField="descObjetivoEquipo"  HeaderText="Descripcion"> </asp:BoundColumn>
                                                         <%--3--%><asp:BoundColumn DataField="tipoObjetivoEquipo"   HeaderText="tipo" Visible="false">        </asp:BoundColumn>
                                                         <%--4--%><asp:BoundColumn DataField="fechaComproEquipo"    HeaderText="Compromiso" HeaderStyle-Width="90px">       </asp:BoundColumn>
                                                         <%--5--%><asp:BoundColumn DataField="estatusObjetivoEquipo" HeaderText="estatus" Visible="false">     </asp:BoundColumn>
                                                         <%--6--%><asp:BoundColumn DataField="porEficaciaEquipo"    HeaderText="Eficacia">    </asp:BoundColumn>
					                                     <%--7--%><asp:BoundColumn DataField="porEficienciaEquipo"  HeaderText="eficiencia">  </asp:BoundColumn>
                                                         <%--8--%><asp:BoundColumn DataField="fechaCumpliEquipo"    HeaderText="Cumplimiento"></asp:BoundColumn>
                                                         <%--9--%><asp:BoundColumn DataField="semanasAtrasoEquipo"  HeaderText="semanas Atraso"></asp:BoundColumn>
                                                         <%--10--%><asp:BoundColumn DataField="areaOportunidadEquipo" HeaderText="Oportunidad">  </asp:BoundColumn>
                                                         <%--11--%><asp:BoundColumn DataField="id_integranteEquipo"  HeaderText="id Integrante" Visible="false"></asp:BoundColumn>
                                                                                                         
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


</asp:Content>
