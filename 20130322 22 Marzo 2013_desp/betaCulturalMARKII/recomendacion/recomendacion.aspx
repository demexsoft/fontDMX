<%@ Page Title="" Language="C#" MasterPageFile="~/mp_MenuPrincipal.Master" AutoEventWireup="true" CodeBehind="recomendacion.aspx.cs" Inherits="betaCulturalMARKII.recomendacion.recomendacion" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            height: 104px;
        }
        .style2
        {
            width: 316px;
        }
        .style3
        {
            height: 104px;
            width: 316px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



       <asp:Panel ID="pnl_content_recomendacion" runat="server" Visible="true">
                               

                                 
                                            <table>
                                            <tr>
                                                <td>
                                                 <asp:Label ID="Label3" runat="server" CssClass="textoEncabezadoGris_" Text="Recomendaciones"></asp:Label>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>

                                                <tr valign="top">
                                                    <td style="width:300px">
                                                    <asp:Label ID="Label83" CssClass="textoNormal_" runat="server" Text="Fecha:"></asp:Label>
                                                    <br />
                                                    <cc1:CalendarExtender runat="server" ID="cln_fechaEvaluacion" runat="server" Format="dd/MM/yyyy" PopupButtonID="btn_img_fechaRecomendacion"
                                         TargetControlID="txt_fechaRecomendacion"></cc1:CalendarExtender>
                                         <asp:ImageButton ID="btn_img_fechaRecomendacion" runat="server" ImageUrl="~/imagenesBasicas/botonesImagenes/iconos/calendario.jpg" />
                                         <asp:TextBox ID="txt_fechaRecomendacion" runat="server"></asp:TextBox>
                                                    
                                         
                                            

                                                    </td>
                                                    <td>
                                                   
                                                        <asp:Label ID="Label1" runat="server" CssClass="textoNormal_" Text="Equipo"></asp:Label><br/>
                                                        <asp:ImageButton ID="btn_img_verEquipo" runat="server" 
                                                            ImageUrl="~/imagenesBasicas/botonesImagenes/equipoico.jpg" 
                                                            onclick="btn_img_verEquipo_Click" style="height: 14px" />                                                        
                                                        <asp:TextBox ID="txt_equipo" runat="server" Width="248px"></asp:TextBox>
                                                        <br/>

                                                    <div id="componente">
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr valign="top">
                                                    <td class="style3">
                                                        <asp:Label ID="Label84" runat="server" CssClass="textoNormal_" 
                                                            Text="Situación"></asp:Label>
                                                            <br/>
                                                        <asp:TextBox ID="txt_situacion" runat="server" Height="76px" 
                                                            TextMode="MultiLine" Width="346px"></asp:TextBox>
                                                        <br/><br/>
                                                        <asp:Label ID="Label85" runat="server" CssClass="textoNormal_" 
                                                            Text="Posible Causa"></asp:Label>
                                                            <br/>
                                                        <asp:TextBox ID="txt_posibleCausa" runat="server" Height="76px" 
                                                            TextMode="MultiLine" Width="346px"></asp:TextBox>
                                                            <br/><br/>
                                                        <asp:Label ID="Label2" runat="server" CssClass="textoNormal_" 
                                                            Text="Propuesta Solución"></asp:Label>
                                                            <br/>
                                                        <asp:TextBox ID="txt_propuestaSolucion" runat="server" Height="76px" 
                                                            TextMode="MultiLine" Width="346px"></asp:TextBox>
                                                    </td>
                                                    <td class="style1">
                                                           
                                                        <asp:DataGrid ID="dg_equipos" runat="server" 
                                                            AutoGenerateColumns="false" BackColor="White" BorderColor="#999999" 
                                                            BorderStyle="Solid" BorderWidth="1px" CssClass="textoNormal_" ForeColor="Black" 
                                                            GridLines="None" onitemcommand="dg_equipos_ItemCommand" 
                                                            ShowHeader="true" Width="250px">
                                                            <Columns>
                                                                <asp:TemplateColumn>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="selectimgbtn" Runat="server" CausesValidation="False" 
                                                                            CommandName="Select" Height="15px" 
                                                                            ImageUrl="~/imagenesBasicas/botonesImagenes/equipoico.jpg" Width="15px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                                <asp:BoundColumn DataField="IDEquipo" Visible="false"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="nomEqui" HeaderText="Nombre" ItemStyle-Width="300px"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="actiEquipo" HeaderText="Actividad" Visible="false">
                                                                </asp:BoundColumn>
                                                                <asp:BoundColumn DataField="nomJefe" HeaderText="Lider" Visible="false"></asp:BoundColumn>
                                                            </Columns>
                                                            <HeaderStyle CssClass="textoNormal_" Width="50px" />
                                                        </asp:DataGrid>
                                                    </td>
                                                </tr>
                                                <tr valign="top">
                                                    <td class="style2">
                                                            <asp:Label ID="lbl_aviso_recomendacion" runat="server" CssClass="textoNormalRojo_" 
                                                                ></asp:Label>
                                                            <br/>
                                                    </td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                                <tr valign="top">
                                                    <td class="style2">
                                                        &nbsp;</td>
                                                    <td>
                                                        <asp:Button ID="btn_agregarRecomendacion" runat="server" Text="Agregar" 
                                                            onclick="btn_agregarRecomendacion_Click" />
                                                        <asp:Button ID="btn_cancelarRecomendacion" runat="server" Text="Cancelar" />
                                                    </td>
                                                </tr>
                                            </table>
                                            
                                        


                                 

                            </asp:Panel>

                        <!--pnl_content_evaluacion--->
</asp:Content>
