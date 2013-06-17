<%@ Page Title="" Language="C#" MasterPageFile="~/mp_MenuPrincipal.Master" AutoEventWireup="true" CodeBehind="incongruencia.aspx.cs" Inherits="betaCulturalMARKII.incongruencia.incongruencia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   
     <!--pnl_content_calendario--->
          <asp:Panel ID="pnl_content_calendario" CssClass="pnl_content_calendario" runat="server" Visible="false">
               
               <asp:LinkButton  ID="lnk_cerrar_panel_calendario" runat="server" Text="Cerrar" CssClass="textoNormalBlanco_" OnClick="lnk_cerrar_panel_calendario_Click"></asp:LinkButton>
                <br/>
               <asp:Calendar ID="cln_calendarioGenerico" runat="server"  BorderStyle="Solid" CellPadding="1" 
                                    onselectionchanged="cln_calendarioGenerico_SelectionChanged" >
                    <SelectedDayStyle BackColor="#FF0066" />
                        <WeekendDayStyle Font-Size="8pt"/>
               </asp:Calendar>
               
           </asp:Panel>
          <!--pnl_content_calendario--->


        <asp:Table ID="tbl_incongruencia_agregar" runat="server" Width="590px">
                             <asp:TableRow>
                                <asp:TableCell>
                                <table width="550px">
                                    <tr valign="top">
                                    <td>
                                        <asp:Label ID="Label51" CssClass="textoNormal_" runat="server" Text="Fecha:"></asp:Label>
                                    </td>
                                    <td><asp:ImageButton ID="btn_img_fechaIncongruencia" OnClick="btn_img_fechaIncongruencia_Click" runat="server" ImageUrl="~/imagenesBasicas/botonesImagenes/iconos/calendario.jpg" />
                                        <asp:TextBox ID="txt_fecha_incongruencia" runat="server"></asp:TextBox>
                                    </td>
                                    <td><asp:Label ID="Label11" CssClass="textoNormal_" runat="server" Text="Principio"></asp:Label></td>
                                    <td><asp:DropDownList ID="cmb_principio_incongruencia" runat="server" AutoPostBack="true" onselectedindexchanged="cmb_principio_incongruencia_SelectedIndexChanged" Width="130px"></asp:DropDownList></td>
                                  
                                </tr>
                                <tr valign="top">
                                    <td><asp:Label ID="Label48" CssClass="textoNormal_" runat="server" Text="Modelo"></asp:Label></td>
                                    <td><asp:DropDownList ID="cmb_modelo_incongruencia" runat="server" Width="130px"></asp:DropDownList></td>
                                    <td><asp:Label ID="Label35" CssClass="textoNormal_" runat="server" Text="Indicador"></asp:Label></td>
                                    <td><asp:DropDownList ID="cmb_indicador_incongruencia" runat="server" Width="130px" ></asp:DropDownList></td>
                                    
                                </tr>
                            
                            </table>
                            

                            <table>
                                <tr>
                                    <td>
                                    <table>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="Label53" CssClass="textoNormal_" runat="server" Text="Evento"></asp:Label>
                                        <br/>
                                        <asp:TextBox ID="txt_evento_incogruencia"  runat="server" TextMode="MultiLine" Width="400px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="Label54" CssClass="textoNormal_" runat="server" Text="Impacto"></asp:Label><br/>
                                        <asp:TextBox ID="txt_impacto_incogruencia" runat="server" TextMode="MultiLine" Width="400px"></asp:TextBox>
                                        <br/>
                                        <br/>
                                        <asp:Label ID="Label52" CssClass="textoNormal_" runat="server" Text="Origen" Width="100px"></asp:Label>
                                        <asp:DropDownList ID="cmb_origen_problema_incongruencia" runat="server" Width="150px" ></asp:DropDownList>

                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" align="right">
                                        <asp:Button ID="btn_guardar_incongruencia" Text="Guardar"  CssClass="textoNormal_" runat="server" OnClick="btn_guardar_incongruencia_Click" />
                                        <asp:Button ID="btn_cacelar_incongruencia" Text="Cancelar" CssClass="textoNormal_" runat="server" />
                                        <asp:Label ID="lbl_aviso_incongruencia" CssClass="textoNormalRojo_" runat="server"></asp:Label>
                                  </td>
                                </tr>
                            </table>
                                    </td>
                                    <td valign="top">
                                        <br/><br/>
                                        <asp:Label ID="Label49" CssClass="textoNormal_" runat="server" Text="Responsable"></asp:Label>
                                        <br/>
                                        <br/>
                                        <div id="scrollComponente">
                                            <asp:TreeView ID="tree_responsable_incongruencia" runat="server"  NodeStyle-CssClass="textoNormal_"  SelectedNodeStyle-Font-Bold="true" SelectedNodeStyle-CssClass="textoNormalRojo_"></asp:TreeView>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                            
                            
                           
                            
                            </asp:TableCell>
                         </asp:TableRow>
                    </asp:Table>
<!--pnl_content_evaluacion--->
                            <asp:Panel ID="pnl_content_evaluacion" runat="server" Visible="false">
                                <asp:Table ID="tbl_crearAsocioacionEquipo" runat="server" BackColor="Aqua">
                                    <asp:TableRow>
                                        <asp:TableCell>
                                            <!--dg_equiposCliente--->
                                            <asp:DataGrid ID="dg_equiposCliente" runat="server" 
                                                    CssClass="textoNormal_" BackColor="White" BorderColor="#999999" 
                                                    BorderStyle="Solid" BorderWidth="1px" ForeColor="Black" 
                                                    ShowHeader="true" GridLines="Both" 
                                    AutoGenerateColumns="false"  Width="590px" 
                             onitemcommand="dg_equiposCliente_ItemCommand">
                                                        
                                                    <Columns>
                                                            
                                                         <asp:TemplateColumn>
                                                                <ItemTemplate>
                                                                    <asp:ImageButton id="selectimgbtn" Height="15px"  Width="15px" Runat="server" CommandName="Select" CausesValidation="False" 
                                                                            ImageUrl="~/imagenesBasicas/botonesImagenes/iconos/jefeEquipo.jpg">
                                                                    </asp:ImageButton>
                                                                </ItemTemplate>
                                                         </asp:TemplateColumn>
                                                         
                                        
                                                         <asp:BoundColumn  DataField="IDEquipo" Visible="false">            </asp:BoundColumn>
                                                         <asp:BoundColumn DataField="nomEqui"   HeaderText="Nombre">        </asp:BoundColumn>
                                                         <asp:BoundColumn DataField="actiEquipo"      HeaderText="Paterno">   </asp:BoundColumn>
                                                         <asp:BoundColumn DataField="nomJefe"      HeaderText="Materno">   </asp:BoundColumn>
                                          </Columns>
             
             
                                            <HeaderStyle CssClass="textoNormal_"  Width="50px"/>
         
                                    </asp:DataGrid>   
                                    <!--dg_equiposCliente--->
                                    <!--dg_equiposVendor--->

                                                <asp:DataGrid ID="dg_equiposVendor" runat="server" 
                                                    CssClass="textoNormal_" BackColor="White" BorderColor="#999999" 
                                                    BorderStyle="Solid" BorderWidth="1px" ForeColor="Black" 
                                                    ShowHeader="true" GridLines="Both" 
                                    AutoGenerateColumns="false"  Width="590px" 
                             onitemcommand="dg_equiposVendor_ItemCommand">
                                                        
                                                    <Columns>
                                                            
                                                         <asp:TemplateColumn>
                                                                <ItemTemplate>
                                                                    <asp:ImageButton id="selectimgbtn" Height="15px"  Width="15px" Runat="server" CommandName="Select" CausesValidation="False" 
                                                                            ImageUrl="~/imagenesBasicas/botonesImagenes/iconos/jefeEquipo.jpg">
                                                                    </asp:ImageButton>
                                                                </ItemTemplate>
                                                         </asp:TemplateColumn>
                                                         
                                        
                                                         <asp:BoundColumn  DataField="IDEquipo" Visible="false">            </asp:BoundColumn>
                                                         <asp:BoundColumn DataField="nomEqui"   HeaderText="Nombre">        </asp:BoundColumn>
                                                         <asp:BoundColumn DataField="actiEquipo"      HeaderText="Paterno">   </asp:BoundColumn>
                                                         <asp:BoundColumn DataField="nomJefe"      HeaderText="Materno">   </asp:BoundColumn>
                                          </Columns>
             
             
                                            <HeaderStyle CssClass="textoNormal_"  Width="50px"/>
         
                                    </asp:DataGrid>

                                    <!--dg_equiposVendor--->

                                        </asp:TableCell>
                                    </asp:TableRow>
                                 </asp:Table>

                                 <asp:Table ID="tbl_agregarEvaluacionEquipo" runat="server">
                                    <asp:TableRow>
                                        <asp:TableCell>
                                            <table>
                                                <tr>
                                                    <td>
                                                    <asp:Label ID="Label83" CssClass="textoNormal_" runat="server" Text="Fecha:"></asp:Label>
                                            <asp:ImageButton ID="btn_img_fechaEvaluacion" OnClick="btn_img_fechaEvaluacion_Click" runat="server" ImageUrl="~/imagenesBasicas/botonesImagenes/iconos/calendario.jpg" />
                                                    </td>
                                                    <td>
                                                    <asp:Label ID="Label85" CssClass="textoNormal_" runat="server" Text="Recomendacion"></asp:Label>
                                            <asp:TextBox ID="txt_recomendacionEval" runat="server" TextMode="MultiLine" Height="50px" ></asp:TextBox>
                                                    </td>
                                                    <td>
                                                    <asp:DropDownList ID="cmb_causa_eval" runat="server" Width="200px"></asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    <asp:TextBox ID="txt_fechaEvaluacionEquipo" runat="server"></asp:TextBox>
                                                    <asp:Label ID="Label84" CssClass="textoNormal_" runat="server" Text="Posible Causa"></asp:Label>
                                                    </td>
                                                    <td>
                                                    <asp:Label ID="Label86" CssClass="textoNormal_" runat="server" Text="Equipo"></asp:Label>
                                            <asp:DropDownList ID="cmb_equipoSeleccionadoVendor" runat="server" Width="200px"></asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btn_agregarEvaluacion" Text="Agregar" runat="server" OnClick="btn_agregarEvaluacion_Click"/>
                                                        <asp:Button ID="btn_cancelarEvaluacion" Text="Cacelar" runat="server" OnClick="btn_cancelarEvaluacion_Click"/>
                                                    </td>
                                                </tr>
                                            </table>
                                            
                                        </asp:TableCell>
                                    </asp:TableRow>
                                 </asp:Table>


                                  <asp:Table ID="tbl_visualizarEvaluaciones" runat="server">
                                    <asp:TableRow>
                                        <asp:TableCell>


                                        </asp:TableCell>
                                    </asp:TableRow>
                                 </asp:Table>

                            </asp:Panel>

                        <!--pnl_content_evaluacion--->



</asp:Content>
