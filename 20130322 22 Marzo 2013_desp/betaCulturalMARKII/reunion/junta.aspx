<%@ Page Title="" Language="C#" MasterPageFile="~/mp_MenuPrincipal.Master" AutoEventWireup="true" CodeBehind="junta.aspx.cs" Inherits="betaCulturalMARKII.reunion.junta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <!--tbl_Junta_Calendario Calendario, para ver las juntas y el detalle de junta-->
    <asp:Table ID="tbl_Junta_Calendario" CssClass="tbl_Junta_Calendario" runat="server">
        <asp:TableRow>
            <asp:TableCell VerticalAlign="Top">
            <table width="740px">
                <tr>
                    <td align="left">
                    <asp:Label ID="lbl_aviso_tituloMesJuntas" Text="Mes de Juntas" CssClass="tituloVentanaGris_" runat="server"></asp:Label>            
                        </td>
                       <td align="right">
                       <asp:Button ID="btn_cerrar_calendario_juntas"  Height="25px" Text="Cerrar" CssClass="textoNormal_" OnClick="btn_cerrar_calendario_juntas_Click"  runat="server" />
                     </td>
                    </tr>
                </table>
                         
             <asp:Panel ID="ver_datos_junta" CssClass="ver_datos_junta" runat="server">
                <br/>
                <br/>
                                    <asp:Label ID="Label45" Text="Datos de Junta" CssClass="tituloVentanaGris_" runat="server"></asp:Label>
                                    <asp:Label ID="Label46" Text="_________________________________________" CssClass="tituloVentanaGris_" runat="server"></asp:Label>
                                    <br/>
                                    <asp:Label ID="Label1" Text="Estado Actual de Junta" CssClass="textoBOLDNegro_" runat="server"></asp:Label>
                                    <asp:TextBox ID="txt_estado_actual_junta" CssClass="textoNormalRojo_" BorderStyle="None" ReadOnly="true" runat="server"></asp:TextBox>
                                    <br/>
                                       <table width="100%">
                                        <tr align="right" valign="top">
                                            <td>
                                              <asp:Label ID="lbl_aviso_fechaComdatosJunta" Text="Fecha Compromiso:" CssClass="textoBOLDNegro_" runat="server"></asp:Label>
                                       <asp:TextBox ID="txt_fechaCompromiso_datosjunta" ReadOnly="true" runat="server" BorderStyle="None"></asp:TextBox>
                                            </td>
                                            <td>
                                            <asp:Label ID="lbl_aviso_horaComdatosJunta" Text="Hora Compromiso:" CssClass="textoBOLDNegro_" runat="server"></asp:Label>
                                       <asp:TextBox ID="txt_horaCompromiso_datosjunta" ReadOnly="true" runat="server" BorderStyle="None"></asp:TextBox><br/>
                                            </td>
                                        </tr>
                                        <tr align="right">
                                              <td>
                                            <asp:Label ID="lbl_aviso_horaRealdatosJunta" Text="Hora Real:" CssClass="textoBOLDNegro_" runat="server"></asp:Label>
                                       <asp:TextBox ID="txt_horaReal_datosjunta" ReadOnly="true" runat="server" BorderStyle="None"></asp:TextBox><br/>
                                            </td>
                                            <td>
                                            <asp:Label ID="lbl_aviso_fechaRealdatosJunta" Text="Fecha Real:" CssClass="textoBOLDNegro_" runat="server"></asp:Label>
                                            <asp:TextBox ID="txt_fechaReal_datosjunta" ReadOnly="true" runat="server" BorderStyle="None"></asp:TextBox>
                                            </td>
                                        
                                        </tr>
                                       </table> 
                                       <br/>
                                       <table>
                                            <tr valign="top">
                                                <td>
                                                    <asp:Label ID="lbl_aviso_actividaddatosJunta" Text="Actividades:" CssClass="textoBOLDNegro_" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txt_actividad_datosjunta" ReadOnly="true" runat="server" TextMode="MultiLine" Width="500px" Height="150px" CssClass="textoNormal_" BorderStyle="None"></asp:TextBox><br/>
                                                </td>
                                            </tr>
                                            <tr valign="top">
                                                <td>
                                                    <asp:Label ID="lbl_aviso_concluciondatosJunta" Text="Concluciones:" CssClass="textoBOLDNegro_" runat="server"></asp:Label>
                                                    
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txt_concluciones_datosjunta" ReadOnly="true" runat="server" TextMode="MultiLine" Width="500px" Height="150px" CssClass="textoNormal_" BorderStyle="None"></asp:TextBox><br/>
                                                </td>
                                            </tr>
                                       </table>
                                     
                                            <input id="btn_cerrar_datosjunta" type="button" onclick="cierraCompletaJunta()" value="cerrar" class="textoNormal_"/>
                                       

                                    </asp:Panel>

            
            <asp:Panel ID="pnl_calendario" CssClass="pnl_calendario" runat="server">
          

           
                <asp:Label ID="lblDiasem0" runat="server" CssClass="titulo_Dia_nombre" Text="Domingo"></asp:Label>
                <asp:Label ID="lblDiasem2" runat="server" CssClass="titulo_Dia_nombre" Text="Lunes"></asp:Label>
                <asp:Label ID="lblDiasem3" runat="server" CssClass="titulo_Dia_nombre" Text="Martes"></asp:Label>
                <asp:Label ID="lblDiasem4" runat="server" CssClass="titulo_Dia_nombre" Text="Miercoles"></asp:Label>
                <asp:Label ID="lblDiasem5" runat="server" CssClass="titulo_Dia_nombre" Text="Jueves"></asp:Label>
                <asp:Label ID="lblDiasem6" runat="server" CssClass="titulo_Dia_nombre" Text="Viernes"></asp:Label>
                <asp:Label ID="lblDiasem7" runat="server" CssClass="titulo_Dia_nombre" Text="Sabado"></asp:Label>
                                    
            </asp:Panel>

                                   
 
                                  
            </asp:TableCell>
        </asp:TableRow>

                            
    </asp:Table>
                       <!--tbl_Junta_Calendario-->
                        
                        <!--tbl_Junta_cerrar-->
                            <asp:Table ID="tbl_Junta_cerrar" runat="server">
                               <asp:TableRow>
                                    <asp:TableCell>

                                         <table>
                                             <tr valign="top">
                                                <td align="right">
                                                 <asp:Calendar ID="calendario_juntas_cerrar" onselectionchanged="calendario_juntas_cerrar_SelectionChanged" runat="server" CssClass="calendario_juntas" BackColor="White" DayStyle-BorderStyle="Solid"  
                                                                TitleFormat="MonthYear" DayStyle-BorderWidth="9px" DayStyle-BorderColor="White" DayStyle-BackColor="#EAEAEA" SelectedDayStyle-BackColor="Olive"  
                                                                SelectedDayStyle-BorderStyle="Outset" DayHeaderStyle-BackColor="#A8B2C5" DayHeaderStyle-BorderColor="#999999" DayHeaderStyle-BorderStyle="None" 
                                                                DayHeaderStyle-BorderWidth="1px" DayNameFormat="Full" SelectedDayStyle-ForeColor="Black">
                                                        <DayStyle CssClass="calendario_juntas_Dias"/>
                                                    </asp:Calendar>
                                                    
                                                    <asp:Label ID="lbl_aviso_cerrarJunta_junta" runat="server" CssClass="textoNormal_"></asp:Label>
                                                    <asp:Button ID="btn_cerrarJunta_junta"  runat="server"  Text="Cerrar Junta" CssClass="textoNormal_" OnClick="btn_cerrarJunta_junta_Click"/>
                                                    
                                                    
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_aviso_disponibles_cerrar_junta" Text="Juntas Disponibles" runat="server" CssClass="textoNormal_"></asp:Label><br/><br/>
                                                     
                                                        <asp:DataGrid ID="dg_junta_cerrar_selecion" runat="server" CssClass="textoNormal_" BackColor="White" BorderColor="#999999" 
                                                            ForeColor="Black" ShowHeader="false" AutoGenerateColumns="false"  Width="260px" OnItemCommand="dg_junta_cerrar_selecion_ItemCommand"
                                                            GridLines="None" AlternatingItemStyle-BackColor="#D5F7FF">
                                                        
                                                    <Columns>

                                                         <asp:TemplateColumn ItemStyle-Width="12px">
                                                           <ItemTemplate>
                                                              <asp:ImageButton id="delimgbtn" Height="12px"  Width="12px" Runat="server" CommandName="Select" CausesValidation="False" 
                                                                            ImageUrl="~/imagenesBasicas/botonesImagenes/iconos/empleadoIcon.jpg">
                                                              </asp:ImageButton>
                                                           </ItemTemplate>
                                                          </asp:TemplateColumn>

                                                            <asp:BoundColumn  DataField="IDReu"  Visible="false">      </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="fComp"  Visible="false" ItemStyle-CssClass="textoNormal_">  </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="asunto" ItemStyle-Width="12px" ItemStyle-Height="10px"  ItemStyle-CssClass="textoNormal_">  </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="hComp" ItemStyle-Width="10px"  ItemStyle-Height="10px"  ItemStyle-CssClass="textoNormal_">  </asp:BoundColumn>
                                                            
                                                         </Columns>

                                                         <HeaderStyle CssClass="headerGrids_" BackColor="#F2F2F2"/>

                                                  </asp:DataGrid>
                                                  <br/>
                                                  
                                                  <table>
                                                    <tr>
                                                        <td>
                                                        <asp:Label ID="lbl_KEY_cerrar_junta" Text="" runat="server" CssClass="textoNormal_" Visible="false"></asp:Label>
                                                            <asp:Label ID="lbl_aviso_fecha_compromiso_cerrar_junta" Text="Fecha Compromiso" runat="server" CssClass="textoNormal_"></asp:Label>
                                                            <br/>
                                                            <asp:Label ID="lbl_fecha_compromiso_cerrar_junta" runat="server" CssClass="textoNormal_"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lbl_aviso_hora_compromiso_cerrar_junta" Text="Hora Compromiso" runat="server" CssClass="textoNormal_"></asp:Label>
                                                            <br/>
                                                            <asp:Label ID="lbl_hora_compromiso_cerrar_junta" runat="server" CssClass="textoNormal_"></asp:Label>
                                                        </td>
                                                    </tr>
                                                      <tr>
                                                        <td>
                                                        <asp:CheckBox ID="SienFechaJunta" AutoPostBack="true" runat="server" Text="Si se realizo en fecha"  oncheckedchanged="SienFechaJunta_CheckedChanged" Checked="true" CssClass="textoNormal_"  />
                                                       
                                                        </td>
                                                        <td>
                                                      
                                                        <asp:CheckBox ID="SienHoraJunta" AutoPostBack="true" runat="server" Text="Si se realizo en hora" oncheckedchanged="SienHoraJunta_CheckedChanged" Checked="true" CssClass="textoNormal_" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lbl_aviso_fechaReal_cerrar_junta" Text="Fecha Real" runat="server" CssClass="textoNormal_" Visible="false"></asp:Label><br/>
                                                            <asp:TextBox ID="txt_fechaReal_cerrar_junta" runat="server" Width="80px" CssClass="textoNormal_" Visible="false"></asp:TextBox><br/>
                                                            <asp:RequiredFieldValidator ID="validator_txt_fechaReal_cerrar_junta" runat="server" ControlToValidate="txt_fechaReal_cerrar_junta" ErrorMessage="Es necesario introducir el dia de la junta" Visible="false" CssClass="textoNormal_"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lbl_aviso_horaReal_cerrar_junta" Text="Hora Real" runat="server" CssClass="textoNormal_" Visible="false"></asp:Label><br/>
                                                            <asp:TextBox ID="txt_horaReal_cerrar_junta" runat="server" Width="80px" CssClass="textoNormal_" Visible="false"></asp:TextBox><br/>
                                                            <asp:RequiredFieldValidator ID="validator_horaReal_cerrar_junta" runat="server" ControlToValidate="txt_horaReal_cerrar_junta" ErrorMessage="Es necesario introducir la hora en que inicio la junta" Visible="false" CssClass="textoNormal_"></asp:RequiredFieldValidator>
                                                       </td>
                                                    </tr>

                                                  
                                                  </table>
                                                     <asp:Label ID="lbl_aviso_asunto_cerrar_junta" Text="Asuntos:" runat="server" CssClass="textoNormal_" ></asp:Label><br/>
                                                    <asp:TextBox ID="txt_asunto_cerrar_junta" runat="server" TextMode="MultiLine" Height="150px" Width="200px"  BorderStyle="Solid" CssClass="textoNormal_" ReadOnly="true"></asp:TextBox><br/>


                                                    <asp:Label ID="lbl_aviso_concluciones_cerrar_junta" Text="Concluciones" runat="server" CssClass="textoNormal_"></asp:Label><br/>
                                                    <asp:TextBox ID="txt_conclucion_cerrar_junta" runat="server" TextMode="MultiLine" Height="150px" Width="200px" CssClass="textoNormal_"></asp:TextBox><br/>
                                                   

                                                </td>
                                            </tr>
                                        </table>

                                    </asp:TableCell>
                               </asp:TableRow>
                            </asp:Table>

                        <!--tbl_Junta_cerrar-->


                         <!--tbl_Junta_crear, para crear una junta-->
                        <asp:Table ID="tbl_Junta_crear" runat="server">
                            <asp:TableRow>
                                <asp:TableCell>
                                    
                                    <table border="1px">
                                        <tr valign="top">
                                            <td align="right">
                                                <asp:Calendar ID="calendario_juntas"  runat="server" CssClass="calendario_juntas" BackColor="White" DayStyle-BorderStyle="Solid"  TitleFormat="MonthYear" DayStyle-BorderWidth="9px" DayStyle-BorderColor="White" DayStyle-BackColor="#EAEAEA" SelectedDayStyle-BackColor="Olive"  SelectedDayStyle-BorderStyle="Outset" DayHeaderStyle-BackColor="#A8B2C5" DayHeaderStyle-BorderColor="#999999" DayHeaderStyle-BorderStyle="None" DayHeaderStyle-BorderWidth="1px" DayNameFormat="Full" SelectedDayStyle-ForeColor="Black">
                                                <DayStyle CssClass="calendario_juntas_Dias"/>
                                                </asp:Calendar>
                                                <asp:Label ID="lbl_aviso_crearJunta_SINO" runat="server" CssClass="textoNormal_"></asp:Label>
                                                <asp:Button ID="btn_crear_junta" Text="Crear Junta" runat="server" CssClass="textoNormal_" OnClick="btn_crear_junta_Click" />
                                                
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_aviso_horaCompromiso_junta_crea" Text="Hora Compromiso:" runat="server" CssClass="textoNormal_"></asp:Label><br/>
                                                <asp:TextBox ID="txt_horaCompromiso_junta_crea" runat="server" CssClass="textoNormal_" Width="70px"></asp:TextBox>
                                                <asp:RangeValidator ID="rangoval_txt_horaCompromiso_junta" runat="server" ControlToValidate="txt_horaCompromiso_junta_crea" ErrorMessage="Introduzca una Hora Valida" MaximumValue="23:00" MinimumValue="00:00" CssClass="textoNormal_"></asp:RangeValidator><br/><br/>
                                                
                                                <asp:Label ID="lbl_asunto_para_junta_crea" Text="Asuntos:" runat="server" CssClass="textoNormal_"></asp:Label><br/>
                                                <asp:TextBox ID="txt_asunto_ParaJunta_crear" TextMode="MultiLine" Height="100px" Width="248px" BorderStyle="Solid" runat="server"></asp:TextBox><br/><br/>
                                                <asp:Label ID="lbl_aviso_empleado_para_junta_crea"  runat="server" CssClass="textoNormalAzul_"></asp:Label>
                                                <asp:ImageButton ID="btn_img_empleado_ver_grid_junta_crea" runat="server" ImageUrl="~/imagenesBasicas/botonesImagenes/iconos/empleadoIcon.jpg" OnClick="btn_img_empleado_ver_grid_junta_crea_Click"/>

                                                <br/>
                                                
                                                <div id="Div1">
                                                <asp:DataGrid ID="dg_empleado_seleciona_junta" runat="server" CssClass="textoNormal_" BackColor="White" BorderColor="#FFFFFF" 
                                                    ForeColor="Black" ShowHeader="false" AutoGenerateColumns="false"  Width="260px"
                                                    onitemcommand="dg_empleado_seleciona_junta_ItemCommand" GridLines="none" AlternatingItemStyle-BackColor="#D5F7FF">
                                                        
                                                    <Columns>

                                                         <asp:TemplateColumn ItemStyle-Width="12px">
                                                           <ItemTemplate>
                                                              <asp:ImageButton id="delimgbtn" Height="12px"  Width="12px" Runat="server" CommandName="Select" CausesValidation="False" 
                                                                            ImageUrl="~/imagenesBasicas/botonesImagenes/iconos/empleadoIcon.jpg">
                                                              </asp:ImageButton>
                                                           </ItemTemplate>
                                                          </asp:TemplateColumn>

                                                         <asp:BoundColumn  DataField="IDempleado"  Visible="false">      </asp:BoundColumn>
                                                         <asp:BoundColumn DataField="nombreEmp" ItemStyle-Width="12px">  </asp:BoundColumn>
                                                         <asp:BoundColumn DataField="apePat" ItemStyle-Width="10px">  </asp:BoundColumn>
                                                         <asp:BoundColumn DataField="nomArea" ItemStyle-Width="10px">    </asp:BoundColumn>
                                                         
                                                    </Columns>

                                                    <HeaderStyle CssClass="headerGrids_" BackColor="#F2F2F2"/>

                                                  </asp:DataGrid>
                                                  </div>
                                                  <br/>
                                                  <asp:Label ID="lbl_aviso_Empleados_incluidos_Junta" runat="server" CssClass="textoNormal_"></asp:Label>
                                            <br/>
                                            <br/>
                                            <asp:DataGrid ID="dg_empleado_para_junta_crea" runat="server" CssClass="textoNormal_" BackColor="White" BorderColor="#999999" 
                                                    ForeColor="Black" ShowHeader="false" AutoGenerateColumns="false"  Width="260px"
                                                    GridLines="None" OnItemCommand="dg_empleado_para_junta_crea_ItemCommand">
                                                        
                                                    <Columns>
                                                        <asp:TemplateColumn ItemStyle-Width="12px">
                                                           <ItemTemplate>
                                                             <asp:Image id="delimgbtn"  Height="12px"  Width="12px" Runat="server" ImageUrl="~/imagenesBasicas/botonesImagenes/iconos/empleadoIcon.jpg"/>
                                                           </ItemTemplate>
                                                        </asp:TemplateColumn>
                                        
                                                         <asp:BoundColumn  DataField="IDempleado"  Visible="false">      </asp:BoundColumn>
                                                         <asp:BoundColumn DataField="nombreEmp" ItemStyle-Width="12px">  </asp:BoundColumn>
                                                         <asp:BoundColumn DataField="apePat" ItemStyle-Width="15px">  </asp:BoundColumn>
                                                         <asp:BoundColumn DataField="nomArea" ItemStyle-Width="10px">    </asp:BoundColumn>

                                                         <asp:TemplateColumn ItemStyle-Width="12px">
                                                           <ItemTemplate>
                                                              <asp:ImageButton id="delete_empledo_junta_crear" Height="12px"  Width="12px" Runat="server" CommandName="Select" CausesValidation="False" 
                                                                            ImageUrl="~/imagenesBasicas/botonesImagenes/iconos/delete.jpg">
                                                              </asp:ImageButton>
                                                           </ItemTemplate>
                                                          </asp:TemplateColumn>
                                                    </Columns>
                 
                                                </asp:DataGrid> 
                                            </td>
                                        </tr>
                                    </table>

                                </asp:TableCell>
                            </asp:TableRow>
                       </asp:Table>


                        <asp:Panel ID="ver_juntas_Dia"  CssClass="ver_juntas_Dia" runat="server">

                             <input id="txt_diaActividadesSeleccionado"  class="tituloNegro_"type="text" style="border:none; background-color:Silver;" readonly="readonly"/>
                                    
                                        <%--Esta tabla se llena en el archivo js_calendario para mostrar el detalle de la junta por dia seleccionado--%>
                                        <table id="tbl_juntasDelDia" class="textoNormal_"  border="1px" cellspacing="0" bordercolor="#999999" width="100%" style="background-color:#FFFFFF">
                                            <tr>
                                                <td class="tituloGris_">
                                                    HORA
                                                </td>
                                                <td class="tituloGris_">
                                                    Fecha
                                                </td>
                                                <td class="tituloGris_">
                                                    Asuntos
                                                </td>
                                            </tr>
                                    </table>
                                    <br/>

                                     <input id="ocultar" type="button" value="CERRA" onclick="ocultarJuntaDia('ver_juntas_Dia');" />

                                </asp:Panel>





</asp:Content>
