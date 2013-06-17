<%@ Page Title="" Language="C#" MasterPageFile="~/mainCSM.Master" AutoEventWireup="true" CodeBehind="matrizIndividual.aspx.cs" Inherits="betaCulturalMARKII.matrizIndiv.matrizIndividual" %>
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
   
   
    <!--pnl_content_matrizIndividual--->
             <asp:Panel ID="pnl_content_matrizIndividual" runat="server" Visible="false">
                    
                    <asp:Table ID="tbl_verMatrizActualIndividual" runat="server">
                        <asp:TableRow>
                            <asp:TableCell>
                            


                            
                            </asp:TableCell>
                        </asp:TableRow>
                    
                    </asp:Table>
                    
                <asp:Table ID="tbl_verTodasMatrizIndividual" runat="server" CssClass="textoNormal_" >
                    <asp:TableRow>
                        <asp:TableCell>
                        <asp:Label ID="lbl_aviso_indicacionesMatrizIndividual" CssClass="textoNormal_" runat="server"></asp:Label>
                            <asp:DataGrid ID="dg_verTodasMatrizes" runat="server" 
                                                    CssClass="textoNormal_" BackColor="White" BorderColor="#999999" 
                                                    BorderStyle="Solid" BorderWidth="2px" ForeColor="Black" 
                                                    ShowHeader="true" GridLines="Both" 
                                    AutoGenerateColumns="false"  Width="650px" 
                             onitemcommand="dg_verTodasMatrizes_ItemCommand" AlternatingItemStyle-BackColor="#A9EFFE"  DataKeyField="eficiencia" OnItemCreated="dg_verTodasMatrizes_OnItemCreated" >
                                     <Columns>
                                         <asp:TemplateColumn  HeaderText="Matriz">
                                               <ItemTemplate>
                                                  <asp:ImageButton id="selectimgbtn" Height="15px"  Width="15px" Runat="server" CommandName="Select" CausesValidation="False" 
                                                                            ImageUrl="~/imagenesBasicas/botonesImagenes/iconos/modificar.jpg">
                                                    </asp:ImageButton>
                                                 </ItemTemplate>
                                          </asp:TemplateColumn>

                                             <%--1--%><asp:BoundColumn   DataField="statusMat"    HeaderText="Estatus"   Visible="false"> </asp:BoundColumn>
                                             <%--2--%><asp:BoundColumn   DataField="IDMatriz"     HeaderText="Matriz"    Visible="false"> </asp:BoundColumn>
                                             <%--3--%><asp:BoundColumn   DataField="IDEmpcreador" HeaderText="Creador"   Visible="false"> </asp:BoundColumn>
                                             <%--4--%><asp:BoundColumn   DataField="IDEmprevi"    HeaderText="JEFE"      Visible="false" HeaderStyle-Width="90px">  </asp:BoundColumn>
                                             <%--5--%><asp:BoundColumn   DataField="nomEmp"       HeaderText="creador" Visible="false"      HeaderStyle-Width="90px"> </asp:BoundColumn>
                                             <%--6--%><asp:BoundColumn   DataField="eficiencia"   HeaderText="Eficiencia">   </asp:BoundColumn>
					                         <%--7--%><asp:BoundColumn   DataField="eficacia"     HeaderText="Eficacia">     </asp:BoundColumn>
                                             <%--8--%><asp:BoundColumn   DataField="actividadesrecordar" HeaderText="Actividades Relevantes" Visible="false"></asp:BoundColumn>
                                             <%--9--%><asp:BoundColumn   DataField="f_inicio"     HeaderText="Fecha Iniciio">    </asp:BoundColumn>
                                             <%--10--%><asp:BoundColumn   DataField="f_final"      HeaderText="Fecha Final">      </asp:BoundColumn>
                                          <asp:TemplateColumn HeaderText="Eficiencia" ItemStyle-Width="120px" HeaderStyle-HorizontalAlign="Center">
                                               <ItemTemplate>
                                                 <asp:Panel ID="pnl_bar_grafica" runat="server" BorderStyle="Solid" BorderWidth="1px" Width="100px">
                                                 <asp:Image  ID="lbl_grafica_mat" runat="server"> </asp:Image>
                                                 </asp:Panel>
                                                               
                                          </ItemTemplate>
                                      </asp:TemplateColumn>
                                     </Columns>
             
             
                                            <HeaderStyle CssClass="textoNormal_"  Width="50px"/>
         
                                    </asp:DataGrid>

                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>

                <!--tbl MATRIZ INDIVIDUAL-->
   
               <asp:Table ID="tbl_addMatrizIndividual" runat="server" CssClass="textoNormal_" >
                        <asp:TableRow>
                            <asp:TableCell>   
                                                    
                                <asp:Label ID="Label32" runat="server" Text="Periodo" CssClass="textoEncabezadoGris_"></asp:Label><br />
                              <table width="100%">
                                <tr valign="top">
                                    <td align="center">
                                     
                                        <asp:Label ID="Label29" runat="server" Text="Cierre Programado"></asp:Label><br />
                                        <asp:ImageButton ID="btn_img_CalendarioFin" OnClick="btn_img_CalendarioFin_Click" runat="server" ImageUrl="~/imagenesBasicas/botonesImagenes/iconos/calendario.jpg" />
                                         <asp:TextBox ID="txt_fechaFinalAddMatrizIndi" runat="server" ReadOnly="true" Width="90px"></asp:TextBox>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="Label13" runat="server" Text="Inicio Programado" ></asp:Label><br />
                                        <asp:ImageButton ID="btn_img_CalendarioInicio" OnClick="btn_img_CalendarioInicio_Click" runat="server" ImageUrl="~/imagenesBasicas/botonesImagenes/iconos/calendario.jpg" />
                                       <asp:TextBox ID="txt_fechaInicioAddMatrizIndi" runat="server" ReadOnly="true" Width="90px"></asp:TextBox>

                                        
                                     </td>
                                    <td align="center">
                                     

                                    </td>
                                      <td align="center">
                                       
                                    </td>
                                </tr>

                                <tr valign="top">
                                    
                                    <td align="center">
                                       
                                    </td>
                                      <td align="center">
                                       
                                    </td>
                                    <td align="center">
                                         <asp:Label ID="Label33" runat="server" Text="% Eficiencia"  CssClass="tituloNegro_"></asp:Label> <br/><br/>
                                        <asp:Label ID="lbl_proEficienciaAddMatrizIndi" runat="server" Width="100px" CssClass="textoBOLDNegro_"></asp:Label>
                                    </td>
                                    <td>
                                    <asp:Label ID="Label34" runat="server" Text="% Eficacia"   CssClass="tituloNegro_"></asp:Label><br/><br/>
                                        <asp:Label ID="lbl_proEficaciaAddMatrizIndi" runat="server" Width="100px" CssClass="textoBOLDNegro_"></asp:Label>
                                      
                                    </td>
                                    
                                </tr>
                              
                            </table>
                                

                            
                           
                                <br/>
                                <asp:Label ID="Label41" runat="server" Text="Objetivos Individuales" CssClass="textoEncabezadoGris_"></asp:Label>
                                <br/>
                                <asp:Label ID="Label76" runat="server" Text="______________________________________________" CssClass="tituloGris_"></asp:Label>
                                <br/>
                    <asp:Table ID="tbl_verObjetivosIndividual" runat="server" Visible="true">
                        <asp:TableRow>
                            <asp:TableCell>
                            



                                    <asp:Label ID="lbl_mensajeMatriz_objetivo" runat="server" CssClass="textoNormal_"></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>


                  <asp:Panel ID="pnl_controles_matrizIndividual" CssClass="pnl_controles_matrizIndividual" runat="server" Visible="false">
                    
                    <table class="textoNormal_" border="1px" width="100%">
                            <tr valign="top">
                            <td>
                            <table width="680px">
                            <tr valign="top">
                            <td>
                                <asp:Label ID="Label36" runat="server" Text="Descripción"></asp:Label><br/>
                                <asp:TextBox ID="txt_descripcionObjetivoAdd" runat="server" Height="40px" TextMode="MultiLine" Width="280px"></asp:TextBox>
                                
                            </td>
                            <td>
                                <asp:Label ID="Label39" runat="server" Text="Objetivo Logrado"></asp:Label>
                                <br/>
                                <asp:DropDownList ID="cmb_estatusObjetivo" runat="server"  Width="50px"></asp:DropDownList>
                            </td>
                            <td>
                             
                                <asp:Label ID="Label38" runat="server" Text="Compromiso"></asp:Label><br/>
                                <asp:ImageButton ID="btn_img_Compromiso" OnClick="btn_img_Compromiso_Click" runat="server" ImageUrl="~/imagenesBasicas/botonesImagenes/iconos/calendario.jpg" />
                                <asp:TextBox ID="txt_fechaCompromisoObjetivoAdd" runat="server" ReadOnly="true" Width="100px"></asp:TextBox>
                              
                                
                                
                            </td>
                            <td>
                              <asp:Label ID="Label42" runat="server" Text="% EFICIENCIA" ></asp:Label><br/>
                                <asp:Label ID="lbl_eficienciaObjetivoAdd" runat="server" Width="100px" Text="0"></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="Label40" runat="server" Text="% EFICACIA"></asp:Label><br/>
                                <asp:Label ID="lbl_eficaciaObjetivoAdd" runat="server" Width="100px" Text="0"></asp:Label>
                            </td>
                            
                          
                            </tr>

             </table>
                                <br/>
                  </td>
                </tr>
                <tr>
                  <td>
                     <table>
                        <tr valign="top">
                          <td>
                            <asp:Label ID="Label44" runat="server" Text="Areas de Oportunidad"></asp:Label><br/>
                            <asp:TextBox ID="txt_areasOportunidadObjetivoAdd" runat="server" Height="40px" TextMode="MultiLine" Width="280px"></asp:TextBox> 
                           </td>
                           <td>
                                <asp:Label ID="lbl_cumplimiento_addMatriz" runat="server" Text="Fecha Cumplimiento"></asp:Label><br/>
                                 <asp:ImageButton ID="btn_img_fechaCumplimientoObjetivoAdd" OnClick="btn_img_fechaCumplimientoObjetivoAdd_Click" runat="server" ImageUrl="~/imagenesBasicas/botonesImagenes/iconos/calendario.jpg" />
                                 <asp:TextBox ID="txt_fechaCumplimientoObjetivoAdd" runat="server" CssClass="textoNormal_" Width="100px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label43" runat="server" Text="Semanas de Atraso"></asp:Label><br/>
                                <asp:Label ID="lbl_semanaAtrasoObjetivoAdd" runat="server" Width="100px"></asp:Label>
                            </td>
                           
                        </tr>
                        <tr>
                             <td>
                              
                                <asp:Button ID="btn_objetivoAddIndividual" runat="server" Text="Aceptar" onclick="btn_objetivoAddIndividual_Click" visible="false" />
                                <asp:Button ID="btn_addObjetivoNuevoIndividual" Text="Aceptar" runat="server" Width="160px" OnClick="btn_addObjetivoNuevoIndividual_Click" visible="false" />
                                
                                <asp:Button ID="btn_guardarCambioObjetivoIndividual" Text="Aceptar" runat="server" Width="100px" OnClick="btn_guardarCambioObjetivoIndividual_Click" visible="false" />
                                <asp:Button ID="btn_cancelarCambioObjetivoIndividual" Text="Cancelar" runat="server" Width="100px" OnClick="btn_cancelarCambioObjetivoIndividual_Click" visible="false" />
                                
                            </td>
                           <td>
                            </td>
                            <td>
                            </td>
                           
                         
                        </tr>
                        
                        </table>

                    
                    </td>

                </tr>
                

            </table>
                            </asp:Panel>
                            <asp:Label ID="Label37" runat="server" Text="Prioritarios"></asp:Label>
                            <br/>
                            <asp:Panel ID="pnl_objetivos_primarios" runat="server" BorderStyle="Solid" Height="120px">

                            <asp:Table ID="tbl_objetivos_primarios_empty" runat="server" Visible="false" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Width="100%">
                                    <asp:TableRow BorderWidth="1px" CssClass="textoNormalAzul_">
                                        <asp:TableCell>
                                                Descripcion
                                        </asp:TableCell>
                                        <asp:TableCell>
                                                
                                        </asp:TableCell>
                                        <asp:TableCell>
                                                    Compromiso
                                        </asp:TableCell>
                                        <asp:TableCell>
                                                Eficacia
                                        </asp:TableCell>
                                        <asp:TableCell>
                                                 Eficiencia
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                                    <asp:LinkButton ID="agregar_primarios" Text="Agregar" runat="server" OnClick="agregar_primarios_Click" CssClass="textoNormalRojo_"> </asp:LinkButton>

                                    <asp:DataGrid ID="dg_objetivosAddMatrizIndi" runat="server" 
                                                    CssClass="textoNormal_" BackColor="White" BorderColor="#999999" 
                                                    BorderStyle="Solid" BorderWidth="2px" ForeColor="Black" 
                                                    ShowHeader="true" GridLines="Both" 
                                    AutoGenerateColumns="false"  Width="700px" 
                             onitemcommand="dg_objetivosAddMatrizIndi_ItemCommand" DataKeys="estatusObjetivo"  DataKeyField="estatusObjetivo"  AlternatingItemStyle-BackColor="#A9EFFE">
                                                        
                                                    <Columns>
                                                            
                                                         <asp:TemplateColumn>
                                                                <ItemTemplate>
                                                                    <asp:ImageButton id="selectimgbtn" Height="15px"  Width="15px" Runat="server" CommandName="Select" CausesValidation="False" 
                                                                            ImageUrl="~/imagenesBasicas/botonesImagenes/iconos/modificar.jpg">
                                                                    </asp:ImageButton>
                                                                </ItemTemplate>
                                                         </asp:TemplateColumn>
                                                         
                                                         <%--1--%><asp:BoundColumn  DataField="IDObj"         HeaderText="ID" Visible="false"> </asp:BoundColumn>
                                                         <%--2--%><asp:BoundColumn  DataField="descObjetivo"  HeaderText="Descripcion"> </asp:BoundColumn>
                                                         <%--3--%><asp:BoundColumn DataField="tipoObjetivo"   HeaderText="tipo" Visible="false">        </asp:BoundColumn>
                                                         <%--4--%><asp:BoundColumn DataField="fechaCompro"    HeaderText="Compromiso" HeaderStyle-Width="90px">       </asp:BoundColumn>
                                                         <%--5--%><asp:BoundColumn DataField="estatusObjetivo" HeaderText="estatus" Visible="false">     </asp:BoundColumn>
                                                         <%--6--%><asp:BoundColumn DataField="porEficacia"    HeaderText="Eficacia">    </asp:BoundColumn>
					                                     <%--7--%><asp:BoundColumn DataField="porEficiencia"  HeaderText="eficiencia">  </asp:BoundColumn>
                                                         <%--8--%><asp:BoundColumn DataField="fechaCumpli"    HeaderText="Cumplimiento"></asp:BoundColumn>
                                                         <%--9--%><asp:BoundColumn DataField="semanasAtraso"  HeaderText="semanas Atraso"></asp:BoundColumn>
                                                         <%--10--%><asp:BoundColumn DataField="areaOportunidad" HeaderText="Oportunidad">  </asp:BoundColumn>
                                                         <%--11--%><asp:BoundColumn DataField="id_integrante"  HeaderText="id Integrante" Visible="false"></asp:BoundColumn>
                                                        
                                                </Columns>

                                            <HeaderStyle CssClass="textoNormalAzul_"  Width="50px"/>
                                    </asp:DataGrid>

                            </asp:Panel>
                            <br/>
                            <asp:Label ID="Label90" runat="server" Text="Secundarios"></asp:Label>
                            <br/>
                            <asp:Panel ID="pnl_objetivos_secundarios" runat="server" BorderStyle="Solid" Height="120px">
                                <asp:Table ID="tbl_objetivos_secundarios_empty" runat="server" Visible="false" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Width="100%">
                                    <asp:TableRow BorderWidth="1px" CssClass="textoNormalAzul_">
                                        <asp:TableCell>
                                                Descripcion
                                        </asp:TableCell>
                                        <asp:TableCell>
                                                
                                        </asp:TableCell>
                                        <asp:TableCell>
                                                    Compromiso
                                        </asp:TableCell>
                                        <asp:TableCell>
                                                Eficacia
                                        </asp:TableCell>
                                        <asp:TableCell>
                                                 Eficiencia
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                                <asp:LinkButton ID="agregar_secundarios" Text="Agregar" OnClick="agregar_secundarios_Click" runat="server" CssClass="textoNormalRojo_"></asp:LinkButton>

                            
                                        <asp:DataGrid ID="dg_objetivos_secundarios_individuales" runat="server" 
                                                    CssClass="textoNormal_" BackColor="White" BorderColor="#999999" 
                                                    BorderStyle="Solid" BorderWidth="2px" ForeColor="Black" 
                                                    ShowHeader="true" GridLines="Both" 
                                    AutoGenerateColumns="false"  Width="700px"  
                             onitemcommand="dg_objetivos_secundarios_individuales_ItemCommand" DataKeys="estatusObjetivo"  DataKeyField="estatusObjetivo"   AlternatingItemStyle-BackColor="#A9EFFE">
                                                       
                                                    <Columns>
                                                    
                                                             
                                                         <asp:TemplateColumn>
                                                                <ItemTemplate>
                                                                    <asp:ImageButton id="selectimgbtn" Height="15px"  Width="15px" Runat="server" CommandName="Select" CausesValidation="False" 
                                                                            ImageUrl="~/imagenesBasicas/botonesImagenes/iconos/modificar.jpg">
                                                                    </asp:ImageButton>
                                                                </ItemTemplate>
                                                         </asp:TemplateColumn>
                                                         
                                                         <%--1--%><asp:BoundColumn  DataField="IDObj"         HeaderText="ID" Visible="false"> </asp:BoundColumn>
                                                         <%--2--%><asp:BoundColumn  DataField="descObjetivo"  HeaderText="Descripcion"> </asp:BoundColumn>
                                                         <%--3--%><asp:BoundColumn DataField="tipoObjetivo"   HeaderText="tipo" Visible="false">        </asp:BoundColumn>
                                                         <%--4--%><asp:BoundColumn DataField="fechaCompro"    HeaderText="Compromiso" HeaderStyle-Width="90px">       </asp:BoundColumn>
                                                         <%--5--%><asp:BoundColumn DataField="estatusObjetivo" HeaderText="estatus" Visible="false">     </asp:BoundColumn>
                                                         <%--6--%><asp:BoundColumn DataField="porEficacia"    HeaderText="Eficacia">    </asp:BoundColumn>
					                                     <%--7--%><asp:BoundColumn DataField="porEficiencia"  HeaderText="eficiencia">  </asp:BoundColumn>
                                                         <%--8--%><asp:BoundColumn DataField="fechaCumpli"    HeaderText="Cumplimiento"></asp:BoundColumn>
                                                         <%--9--%><asp:BoundColumn DataField="semanasAtraso"  HeaderText="semanas Atraso"></asp:BoundColumn>
                                                         <%--10--%><asp:BoundColumn DataField="areaOportunidad" HeaderText="Oportunidad">  </asp:BoundColumn>
                                                         <%--11--%><asp:BoundColumn DataField="id_integrante"  HeaderText="id Integrante" Visible="false"></asp:BoundColumn>
                                                         
                                                        
                                                </Columns>
                                            <HeaderStyle CssClass="textoNormalAzul_"  Width="50px"/>
                                    </asp:DataGrid>
                            </asp:Panel>
                            <br/>
                            <asp:Label ID="Label95" runat="server" Text="Permanentes"></asp:Label>
                            <br/>

                            <asp:Panel ID="pnl_objetivos_permanentes" runat="server" BorderStyle="Solid" Height="120px">
                            <asp:Table ID="tbl_objetivos_permanentes_empty" runat="server" Visible="false" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Width="100%">
                                    <asp:TableRow BorderWidth="1px" CssClass="textoNormalAzul_">
                                        <asp:TableCell>
                                                Descripcion
                                        </asp:TableCell>
                                        <asp:TableCell>
                                                
                                        </asp:TableCell>
                                        <asp:TableCell>
                                                    Compromiso
                                        </asp:TableCell>
                                        <asp:TableCell>
                                                Eficacia
                                        </asp:TableCell>
                                        <asp:TableCell>
                                                 Eficiencia
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>

                            <asp:LinkButton ID="agregar_permanentes" Text="Agregar" runat="server" OnClick="agregar_permanentes_Click" CssClass="textoNormalRojo_"></asp:LinkButton>
                                        <asp:DataGrid ID="dg_objetivos_permanentes_individuales" runat="server" 
                                                    CssClass="textoNormal_" BackColor="White" BorderColor="#999999" 
                                                    BorderStyle="Solid" BorderWidth="2px" ForeColor="Black" 
                                                    ShowHeader="true" GridLines="Both" 
                                    AutoGenerateColumns="false"  Width="700px" 
                             onitemcommand="dg_objetivos_permanentes_individuales_ItemCommand" DataKeys="estatusObjetivo"  DataKeyField="estatusObjetivo"   AlternatingItemStyle-BackColor="#A9EFFE">
                                                        
                                                    <Columns>
                                                            
                                                         <asp:TemplateColumn>
                                                                <ItemTemplate>
                                                                    <asp:ImageButton id="selectimgbtn" Height="15px"  Width="15px" Runat="server" CommandName="Select" CausesValidation="False" 
                                                                            ImageUrl="~/imagenesBasicas/botonesImagenes/iconos/modificar.jpg">
                                                                    </asp:ImageButton>
                                                                </ItemTemplate>
                                                         </asp:TemplateColumn>
                                                         
                                                         <%--1--%><asp:BoundColumn  DataField="IDObj"         HeaderText="ID" Visible="false"> </asp:BoundColumn>
                                                         <%--2--%><asp:BoundColumn  DataField="descObjetivo"  HeaderText="Descripcion"> </asp:BoundColumn>
                                                         <%--3--%><asp:BoundColumn DataField="tipoObjetivo"   HeaderText="tipo" Visible="false">        </asp:BoundColumn>
                                                         <%--4--%><asp:BoundColumn DataField="fechaCompro"    HeaderText="Compromiso" HeaderStyle-Width="90px">       </asp:BoundColumn>
                                                         <%--5--%><asp:BoundColumn DataField="estatusObjetivo" HeaderText="estatus" Visible="false">     </asp:BoundColumn>
                                                         <%--6--%><asp:BoundColumn DataField="porEficacia"    HeaderText="Eficacia">    </asp:BoundColumn>
					                                     <%--7--%><asp:BoundColumn DataField="porEficiencia"  HeaderText="eficiencia">  </asp:BoundColumn>
                                                         <%--8--%><asp:BoundColumn DataField="fechaCumpli"    HeaderText="Cumplimiento"></asp:BoundColumn>
                                                         <%--9--%><asp:BoundColumn DataField="semanasAtraso"  HeaderText="semanas Atraso"></asp:BoundColumn>
                                                         <%--10--%><asp:BoundColumn DataField="areaOportunidad" HeaderText="Oportunidad">  </asp:BoundColumn>
                                                         <%--11--%><asp:BoundColumn DataField="id_integrante"  HeaderText="id Integrante" Visible="false"></asp:BoundColumn>
                                                       

                                                </Columns>
                                            <HeaderStyle CssClass="textoNormalAzul_"  Width="50px"/>
                                    </asp:DataGrid>

                                  
                            </asp:Panel>
                            <br/>
                            <asp:Button ID="btn_addMatrizIndividual" Text="Crear Matriz" runat="server" Width="100px" OnClick="btn_addMatrizIndividual_Click" visible="false"  />
                            </asp:TableCell>
                        </asp:TableRow>
                    
                    </asp:Table>
               
               <!--tbl MATRIZ INDIVIDUAL-->
                    
           </asp:Panel>
    <!--pnl_content_matrizIndividual--->

</asp:Content>
