<%@ Page Title="" Language="C#" MasterPageFile="~/mp_MenuPrincipal.Master" AutoEventWireup="true" CodeBehind="equipo.aspx.cs" Inherits="betaCulturalMARKII.equipo.equipo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        
        <asp:Panel ID="pnl_content_equipo" runat="server">

                     <asp:Label ID="lbl_titulo_content_equipo" Text="Equipo" CssClass="tituloAzul_" runat="server"></asp:Label>
                    

                    <!--Trae todos los empleados disponibles para ser seleccionados-->
                    <!--pnl_content_empleadosDisponibles--->
                    <asp:Panel ID="pnl_content_empleadosDisponibles"  CssClass="pnl_content_empleadosDisponibles" Visible="false" runat="server">
                    <!--Selecciona Jefe de Equipo-->
                         <asp:DataGrid ID="dg_seleccionaJefe" runat="server"  
                                     BackColor="White" BorderColor="#999999"  
                                     BorderStyle="Solid" BorderWidth="1px" ForeColor="Black" 
                                     ShowHeader="true" ShowFooter="true" GridLines="None" CellPadding="4" CssClass="resultTable"
                                     HeaderStyle-BorderWidth="1px"  
                                    AutoGenerateColumns="false" Width="100%"  AlternatingItemStyle-BackColor="#D5F7FF"
                             onitemcommand="dg_seleccionaJefe_ItemCommand">
                                                        
                            <Columns>
                                                            
                                    <asp:TemplateColumn>
                                        <ItemTemplate>
                                            <asp:ImageButton id="selectimgbtn" Height="15px"  Width="15px" Runat="server" CommandName="Select" CausesValidation="False" 
                                                    ImageUrl="~/imagenesBasicas/botonesImagenes/iconos/jefeEquipo.jpg">
                                            </asp:ImageButton>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                                         
                                        
                                    <asp:BoundColumn  DataField="IDempleado" Visible="false">            </asp:BoundColumn>
                                    <asp:BoundColumn DataField="nombreEmp"   HeaderText="Nombre">        </asp:BoundColumn>
                                    <asp:BoundColumn DataField="apePat"      HeaderText="Paterno">   </asp:BoundColumn>
                                    <asp:BoundColumn DataField="apeMat"      HeaderText="Materno">   </asp:BoundColumn>
                                    <asp:BoundColumn DataField="fechaAlta"   HeaderText="Fecha Alta">    </asp:BoundColumn>
					                <asp:BoundColumn DataField="nomPuesto"  HeaderText="Puesto">        </asp:BoundColumn>
                                    <asp:BoundColumn DataField="nomEmpresa"  HeaderText="Empresa">       </asp:BoundColumn>
                                    <asp:BoundColumn DataField="nomArea"     HeaderText="Area">          </asp:BoundColumn>

                              
                                                         
                        </Columns>
                        
                                <FooterStyle CssClass="footerGrid" />
                                <HeaderStyle CssClass="headerGrid" Height="30px" />
                                <ItemStyle CssClass="itemGrid" Wrap="true" /> 
                                <SelectedItemStyle BackColor="#d4d4d4" Font-Bold="True" />
                                <PagerStyle ForeColor="#ffffff" BackColor="#3b3b3b" Font-Size="11px"/>
                                <AlternatingItemStyle BackColor="#e5e5e5" />
            
      </asp:DataGrid> 
                                    <!--Selecciona Empleado-->
                         <asp:DataGrid ID="dg_seleccionaEmpleado" runat="server" BackColor="White" BorderColor="#999999" 
                                                    BorderStyle="Solid" BorderWidth="1px" ForeColor="Black" 
                                                    ShowHeader="true" ShowFooter="true" GridLines="None" CellPadding="4" CssClass="resultTable" 
                                    AutoGenerateColumns="false"  Width="100%"  AlternatingItemStyle-BackColor="#D5F7FF"
                             onitemcommand="dg_seleccionaEmpleado_ItemCommand">
                                                        
                <Columns>
                                                            
                <asp:TemplateColumn>
                    <ItemTemplate>
                        <asp:ImageButton id="selectimgbtn" Height="15px"  Width="15px" Runat="server" CommandName="Select" CausesValidation="False" 
                                ImageUrl="~/imagenesBasicas/botonesImagenes/iconos/empleadoIcon.jpg">
                        </asp:ImageButton>
                    </ItemTemplate>
                </asp:TemplateColumn>
                                                         
                                        
                <asp:BoundColumn  DataField="IDempleado" Visible="false">            </asp:BoundColumn>
                <asp:BoundColumn DataField="nombreEmp"   HeaderText="Nombre">        </asp:BoundColumn>
                <asp:BoundColumn DataField="apePat"      HeaderText="Paterno">   </asp:BoundColumn>
                <asp:BoundColumn DataField="apeMat"      HeaderText="Materno">   </asp:BoundColumn>
                <asp:BoundColumn DataField="fechaAlta"   HeaderText="Fecha Alta">    </asp:BoundColumn>
				<asp:BoundColumn DataField="nomPuesto"  HeaderText="Puesto">        </asp:BoundColumn>
                <asp:BoundColumn DataField="nomEmpresa"  HeaderText="Empresa">       </asp:BoundColumn>
                <asp:BoundColumn DataField="nomArea"     HeaderText="Area">          </asp:BoundColumn>
                                                         
            </Columns>
             
             
    <FooterStyle CssClass="footerGrid" />
    <HeaderStyle CssClass="headerGrid" Height="30px" />
    <ItemStyle CssClass="itemGrid" Wrap="true" /> 
    <SelectedItemStyle BackColor="#d4d4d4" Font-Bold="True" />
    <PagerStyle ForeColor="#ffffff" BackColor="#3b3b3b" Font-Size="11px"/>
    <AlternatingItemStyle BackColor="#e5e5e5" />
</asp:DataGrid>

                        <asp:LinkButton ID="lnk_cerrar_empleados_disponibles" OnClick="lnk_cerrar_empleados_disponibles_Click" CssClass="textoNormal_" Text="Cerrar" runat="server"></asp:LinkButton>
                    </asp:Panel>  
                    <!--pnl_content_empleadosDisponibles--->


                        <asp:Table ID="tbl_crearEquipo" runat="server" Visible="false">
                        <asp:TableRow>
                            <asp:TableCell>
                                <table border="0">
                                       <tr>
                                            <td style="width:100px;">
                                                <asp:Label ID="lbl_nombreEquipoAdd" runat="server" Text="Nombre:" ></asp:Label>                                            
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txt_nombreEquipoAdd" runat="server" CssClass="textoNormal_" Width="300px"></asp:TextBox>
                                            </td>
                                       </tr> 
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text="Area: " ></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="cmb_area" CssClass="textoNormal_" runat="server" Width="300px"></asp:DropDownList>
                                            </td>
                                       </tr>                                       
                                       <tr>
                                            <td>
                                                <asp:Label ID="lbl_atividadEquipoAdd" runat="server" Text="Comentario: " ></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txt_atividadEquipoAdd" runat="server" CssClass="textoNormal_" Width="300px"></asp:TextBox>
                                            </td>
                                       </tr>
                                      
                                       <tr>
                                            <td>
                                                <asp:Label ID="lbl_jefeEquipo" runat="server" Text="Lider Equipo:" ></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txt_jefeEquipo" runat="server" CssClass="textoNormal_" Width="300px" ReadOnly="true"></asp:TextBox>
                                                <asp:Label ID="lbl_IDJefeEquipo" runat="server" Visible="false"></asp:Label>
                                                &nbsp<asp:ImageButton ID="btn_img_verJefeAgregarEquipo"  runat="server" OnClick="btn_img_verJefeAgregarEquipo_Click" ImageUrl="~/imagenesBasicas/botonesImagenes/iconos/jefeEquipo.jpg" />
                                            </td>
                                       </tr> 
                                       <tr>
                                            <td valign="top">
                                                <asp:Label ID="lbl_integrantesEquipoAdd" runat="server" Text="Integrantes:" ></asp:Label>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="btn_img_verEmpleadoAgregarEquipo"  runat="server" OnClick="btn_img_verEmpleadoAgregarEquipo_Click" ImageUrl="~/imagenesBasicas/botonesImagenes/iconos/empleadoIcon.jpg" />
                                            <br />                                            
                                            <br />
                                            <br />
                                                <asp:DataGrid ID="dgr_integrantesEquipoAdd" runat="server" 
                                                  BackColor="White" BorderColor="#999999"  CssClass="resultTable"
                                                  BorderStyle="Solid" BorderWidth="1px" ForeColor="Black" 
                                                  ShowHeader="true"   HeaderStyle-BorderWidth="1px" ShowFooter="true" GridLines="None" CellPadding="4"
                                                  AutoGenerateColumns="false"  AlternatingItemStyle-BackColor="#D5F7FF"
                                                  Width="590px">                                                     
                                                <Columns>
                                                        <asp:TemplateColumn>
                                                            <ItemTemplate>
                                                                <asp:Image id="img_icon_empleado" Height="15px"  Width="15px" Runat="server" 
                                                                        ImageUrl="~/imagenesBasicas/botonesImagenes/iconos/empleadoIcon.jpg">
                                                                </asp:Image>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        
                                                        <asp:BoundColumn  DataField="idEquipo"   HeaderText="ID Equipo" Visible="false">  </asp:BoundColumn>
                                                        <asp:BoundColumn  DataField="IDempleado" HeaderText="ID Empleado" Visible="false"> </asp:BoundColumn>
                                                        <asp:BoundColumn  DataField="nombreEmp"     HeaderText="Nombre"> </asp:BoundColumn>
                                                        <asp:BoundColumn  DataField="apePat"     HeaderText="Paterno"> </asp:BoundColumn>
                                                        <asp:BoundColumn  DataField="apeMat"     HeaderText="Materno"> </asp:BoundColumn>
                                                        <asp:BoundColumn  DataField="area"     HeaderText="Area"> </asp:BoundColumn>
                                                </Columns>             
                                                <FooterStyle CssClass="footerGrid" />
                                                <HeaderStyle CssClass="headerGrid" Height="30px" />
                                                <ItemStyle CssClass="itemGrid" Wrap="true" /> 
                                                <SelectedItemStyle BackColor="#d4d4d4" Font-Bold="True" />
                                                <PagerStyle ForeColor="#ffffff" BackColor="#3b3b3b" Font-Size="11px"/>
                                                <AlternatingItemStyle BackColor="#e5e5e5" />
         
                                                </asp:DataGrid> 

                                            </td>
                                       </tr> 
                                       <tr>
                                            <td colspan="2" align="right">
                                            <asp:Label ID="lbl_aviso_mensajeEquipo_Miembro_Equipo" CssClass="textoNormalRojo_" runat="server"></asp:Label>
                                                <asp:Button ID="btn_crearEquipo" runat="server" Text="Crear" OnClick="btn_crearEquipo_Click" CssClass="btn_GrisRedondo"/>
                                                <asp:Button ID="btn_ModificarEquipo" runat="server" Text="Guardar Cambios"  OnClick="btn_ModificarEquipo_Click" Visible="false" CssClass="btn_GrisRedondo"/>
                                            </td>
                                       </tr> 
                                </table>
                                
                            </asp:TableCell>
                        
                        </asp:TableRow>
                    
                    </asp:Table>
               
                    
                        <asp:Table ID="tbl_verTodosEquipos" runat="server">
                        <asp:TableRow>
                            <asp:TableCell>
                    
                            

                            <asp:TreeView ID="tv_equiposEmpleadosAll" runat="server" CssClass="textoNormal_" ForeColor="#000000"
                                         onselectednodechanged="tv_equiposEmpleadosAll_SelectedNodeChanged">
                            
                            </asp:TreeView>

                            
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>




                </asp:Panel>



</asp:Content>
