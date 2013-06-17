<%@ Page Title="" Language="C#" MasterPageFile="~/mp_MenuPrincipal.Master"  AutoEventWireup="true" CodeBehind="acuerdos.aspx.cs" Inherits="betaCulturalMARKII.acuerdos.acuerdos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
<asp:Panel ID="pnl_agregarPropuesta" runat="server">

 <table border="0">
        <tr valign="top">
            <td>            
            <asp:Label ID="lbl_empleado_propuesta" Text="Empleado" runat="server" CssClass="textoNormal_"></asp:Label>            
            <asp:TextBox  ID="txt_empleado_propuesta" runat="server" Width="200px" CssClass="textoNormal_" ReadOnly="true"></asp:TextBox>
            <asp:ImageButton ID="btn_img_verEmpleadoAgregarEquipo"  runat="server" OnClick="btn_img_verEmpleadoAgregarEquipo_Click" ImageUrl="~/imagenesBasicas/botonesImagenes/iconos/empleadoIcon.jpg" />
            </td>
            
            <td align="right">
     
            <asp:Label ID="Label4" Text="Fecha" runat="server" CssClass="textoNormal_"></asp:Label> 
            <asp:TextBox ID="txt_fecha_propuesta" runat="server" Width="100px"></asp:TextBox>
            <asp:ImageButton ID="btnFinalPropuesta" runat="server" ImageUrl="~/imagenesBasicas/iconos/Calendario2.png" />
                <cc1:CalendarExtender  ID="cld_fecha_propuesta" runat="server" Format="dd/MM/yyyy" PopupButtonID="btnFinalPropuesta" TargetControlID="txt_fecha_propuesta">
                </cc1:CalendarExtender>

            </td>
        </tr>
        <tr>
            <td valign="top">
            <asp:Label ID="lbl_descripcion_propuesta"  Text="Descripción" runat="server" CssClass="textoNormal_"></asp:Label>
            </td>
            <td>            
            <asp:TextBox ID="txt_descripcion" TextMode="MultiLine" runat="server" Width="200px" Height="100px" CssClass="textoNormal_"></asp:TextBox>
            </td>            
        </tr>
        <tr>
            <td colspan="2">
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                <asp:Button  ID="btn_guardarAcuerdo" Text="Aceptar" runat="server" 
                    CssClass="btn_GrisRedondo" onclick="btn_guardarAcuerdo_Click"/>    
            </td>
        </tr>
    </table>

    <br/>
            <asp:Label ID="lbl_avisoAcuerdos" runat="server" CssClass="textoNormal_"></asp:Label>
    <br/>
        <asp:DataGrid ID="dg_seleccionaEmpleado" runat="server" 
                      BackColor="White" BorderColor="#999999" HeaderStyle-Font-Bold="true"
                      BorderStyle="Solid" BorderWidth="1px" ForeColor="Black" 
                      ShowHeader="true" ShowFooter="true" GridLines="None" CellPadding="4" CssClass="resultTable"  
                      AutoGenerateColumns="false"  Width="800px"  AlternatingItemStyle-BackColor="#D5F7FF"
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
                    <asp:BoundColumn DataField="nombreEmp"   HeaderText="Nombre" ItemStyle-HorizontalAlign="Left">        </asp:BoundColumn>
                    <asp:BoundColumn DataField="apePat"      HeaderText="Paterno" ItemStyle-HorizontalAlign="Left">   </asp:BoundColumn>
                    <asp:BoundColumn DataField="apeMat"      HeaderText="Materno" ItemStyle-HorizontalAlign="Left">   </asp:BoundColumn>
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

</asp:Panel>

<asp:Panel ID="pnl_verPropuesta" runat="server">
    
   <table>
        <tr valign="top">
            <td>
            <asp:Image ID="ImageButton1"  runat="server" ImageUrl="~/imagenesBasicas/botonesImagenes/iconos/empleadoIcon.jpg" />
                <asp:Label ID="Label1" runat="server" CssClass="textoNormal_" Text="Empleado"></asp:Label>
                <br/>
           <asp:Label  ID="lbl_verEmpleadoPropuesta" runat="server" Width="200px" CssClass="textoNormal_"></asp:Label>
           </td>
            <td>
           
            
            <asp:Image ID="ImageButton2" runat="server" ImageUrl="~/imagenesBasicas/iconos/Calendario2.png" />
            <asp:Label ID="Label3"  Text="Fecha" runat="server" CssClass="textoNormal_"></asp:Label>
            <br />
            <asp:Label ID="lbl_verFechaPropuesta" runat="server"></asp:Label>
            
            </td>
           
        </tr>
        <tr valign="top">
            <td>
            <asp:Label ID="Label2"  Text="Descripción" runat="server" CssClass="textoNormal_"></asp:Label>
            <br/>
                <asp:Label ID="lbl_verDescipcionPropuesta" runat="server" BorderStyle="Solid" 
                    BorderWidth="1px" CssClass="textoNormal_" Height="100px" Width="200px"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            
        </tr>
    </table>

        <asp:DataGrid ID="dg_verPropuesta" runat="server" 
                      BackColor="White" BorderColor="#999999" 
                      BorderStyle="Solid" BorderWidth="1px" ForeColor="Black" 
                      ShowHeader="true" ShowFooter="true" GridLines="None" CellPadding="4" CssClass="resultTable"
                      AutoGenerateColumns="false"  Width="700px"
                      onitemcommand="dg_verPropuesta_ItemCommand" AlternatingItemStyle-BackColor="#D5F7FF">
                                                        
            <Columns>
                                                            
                    <asp:TemplateColumn>
                        <ItemTemplate>
                            <asp:ImageButton id="dgbtnverpropuesta" Height="15px"  Width="15px" Runat="server" CommandName="Select"
                                    ImageUrl="~/imagenesBasicas/botonesImagenes/iconos/empleadoIcon.jpg">
                            </asp:ImageButton>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                                                         
                                        
           <%--1--%><asp:BoundColumn  DataField="IDacuerdo"  Visible="false">            </asp:BoundColumn>
           <%--2--%><asp:BoundColumn  DataField="descripcion"   HeaderText="Descripcion">        </asp:BoundColumn>
           <%--3--%><asp:BoundColumn  DataField="estatus"      HeaderText="Paterno">   </asp:BoundColumn>
           <%--4--%><asp:BoundColumn  DataField="fecha"      HeaderText="fecha">   </asp:BoundColumn>
           <%--5--%><asp:BoundColumn  DataField="empleado"   HeaderText="Empelado">    </asp:BoundColumn>
		   <%--6--%><asp:BoundColumn  DataField="apePat"  HeaderText="Paterno">        </asp:BoundColumn>
           <%--7--%><asp:BoundColumn  DataField="apeMat"  HeaderText="Materno">       </asp:BoundColumn>
           <%--8--%><asp:BoundColumn  DataField="area"     HeaderText="Area">          </asp:BoundColumn>
                    <asp:BoundColumn  DataField="puesto"     HeaderText="Puesto">          </asp:BoundColumn>
                                                         
        </Columns>
             
          <FooterStyle CssClass="footerGrid" />
                <HeaderStyle CssClass="headerGrid" Height="30px" />
                <ItemStyle CssClass="itemGrid" Wrap="true" /> 
                <SelectedItemStyle BackColor="#d4d4d4" Font-Bold="True" />
                <PagerStyle ForeColor="#ffffff" BackColor="#3b3b3b" Font-Size="11px"/>
                <AlternatingItemStyle BackColor="#e5e5e5" />
         
</asp:DataGrid>


</asp:Panel>



</asp:Content>
