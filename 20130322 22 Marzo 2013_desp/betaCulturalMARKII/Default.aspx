<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="betaCulturalMARKII.acce" Debug="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ACCESO</title>
    <link href="../estilos/stilocomponente.css" rel="stylesheet" type="text/css" />
    <link href="../estilos/fuentes.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 115px;
        }
        .style4
        {
            height: 50px;
            width: 90px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
       

            <asp:Panel ID="pnl_conten_main_log" runat="server">
                <asp:Panel ID="pnl_content_loggin" runat="server">
               <asp:Panel ID="pnl_controls_loggin" runat="server">
               <!--pnl_ini_selecciona_equipo-->
                            <asp:Panel ID="pnl_ini_selecciona_equipo" runat="server" Visible="false" BackColor="White" Width="450px" >
                            <asp:Label ID="lbl_aviso_bienvenido_loggin" runat="server" Text="<strong>nombre Usuario:</strong>" CssClass="textoNormalAzul_"></asp:Label>
                            <br/>
                            <asp:Label ID="lbl_aviso_intruccion_titulo" runat="server" Text="<strong>Selecciona con que equipo quieres iniciar la sesion</strong>" CssClass="textoChicoAzul_"></asp:Label>
                            
                            <br/><br/>
                            <table width="450px" style="background-color:White;">
                                <tr valign="top">
                                    <td> <asp:Label ID="lbl_aviso_intruccion_loggin_team" runat="server" Text="<strong>Selecciona con que equipo quieres iniciar la sesion</strong>" CssClass="textoChicoAzul_"></asp:Label>
                                    
                                    </td>
                                    <td>
                                    <asp:DataGrid ID="dg_view_seleccionaEquipoJEFE" runat="server" 
                                            CssClass="textoNormal_" BackColor="White"
                                                     ForeColor="Black" ShowHeader="false" AutoGenerateColumns="false"  Width="200px" 
                                            onitemcommand="dg_view_seleccionaEquipoJEFE_ItemCommand" 
                                            BorderStyle="None" GridLines="None" 
                                            onselectedindexchanged="dg_view_seleccionaEquipoJEFE_SelectedIndexChanged">
                                                        
                                                    <Columns>
                                                            
                                                         <asp:TemplateColumn>
                                                                <ItemTemplate>
                                                                    <asp:ImageButton id="delimgbtn" Height="15px"  Width="15px" Runat="server" CommandName="Select" CausesValidation="False" 
                                                                            ImageUrl="~/imagenesBasicas/botonesImagenes/iconos/empleadoGraficabadIcon.jpg">
                                                                    </asp:ImageButton>
                                                                </ItemTemplate>
                                                         </asp:TemplateColumn>
                                                         
                                        
                                                   <%--1--%> <asp:BoundColumn   DataField="IDEquipo"     Visible="false">    </asp:BoundColumn>
                                                   <%--2--%> <asp:BoundColumn   DataField="IDJefeEquipo" Visible="false">     </asp:BoundColumn>
                                                   <%--3--%> <asp:BoundColumn   DataField="nomEquipo"    > </asp:BoundColumn>
                                                   <%--4--%> <asp:BoundColumn   DataField="nomJefe"     Visible="false"  >  </asp:BoundColumn>
                                                         
                                                         
                                                </Columns>
             
             
                                            <HeaderStyle CssClass="tituloGris_"  Width="50px"/>
         
                                    </asp:DataGrid>
                                    </td>
                                </tr>
                                <tr valign="top">
                                    <td>
                                   <asp:Label ID="lbl_aviso_instruccion_loggin_member" runat="server" Text="<strong>Selecciona con que equipo quieres iniciar la sesion</strong>" CssClass="textoChicoAzul_"></asp:Label>
                                    </td>
                                    <td><asp:DataGrid ID="dg_view_seleccionaEquipo" runat="server" CssClass="textoNormal_" BackColor="White"
                                                     ForeColor="Black" ShowHeader="false" AutoGenerateColumns="false"  Width="200px" 
                                            onitemcommand="dg_view_seleccionaEquipo_ItemCommand" BorderStyle="None" GridLines="None">
                                                        
                                                    <Columns>
                                                            
                                                         <asp:TemplateColumn>
                                                                <ItemTemplate>
                                                                    <asp:ImageButton id="delimgbtn" Height="15px"  Width="15px" Runat="server" CommandName="Select" CausesValidation="False" 
                                                                            ImageUrl="~/imagenesBasicas/botonesImagenes/iconos/equipoico.jpg">
                                                                    </asp:ImageButton>
                                                                </ItemTemplate>
                                                         </asp:TemplateColumn>
                                                         
                                        
                                                   <%--1--%> <asp:BoundColumn   DataField="IDEquipo"     Visible="false">     </asp:BoundColumn>
                                                   <%--2--%> <asp:BoundColumn   DataField="IDJefeEquipo" Visible="false">     </asp:BoundColumn>
                                                   <%--3--%> <asp:BoundColumn   DataField="nomEquipo"    > </asp:BoundColumn>
                                                   <%--4--%> <asp:BoundColumn   DataField="nomJefe"     Visible="false"  >  </asp:BoundColumn>
                                                         
                                                         
                                                </Columns>
             
             
                                            <HeaderStyle CssClass="tituloGris_"  Width="50px"/>
         
                                    </asp:DataGrid>
                                    
                                    </td>
                                </tr>

                            </table>
                             

                                 
                                    <br/>
                                  

                </asp:Panel>
                <!--pnl_ini_selecciona_equipo--> 

                <asp:Panel ID="pnl_ini_loggin_logos" runat="server">
                
                <table>
                    <tr>
                        <td></td>
                        <td>
                            
                            <asp:Image ID="logo_csm" ImageUrl="imagenesBasicas/logo2013.jpg" runat="server" 
                                Height="139px" Width="178px" />
                        </td>
                        <td>
                        <table class="textoNormal_" width="300px" border="0">
                        
                        <tr>
                            <td>
                               &nbsp&nbsp<asp:Label ID="Label_ingresar_loggin"  Visible="false" runat="server" CssClass="tituloAzul_" Text="Ingresar:"  Height="25px"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>

                            <td>
                            <table>
                                <tr>
                                    <td class="style1">
                                        <asp:Label ID="Label_usuario_loggin" runat="server" CssClass="textoBOLDNegro_" 
                                            Text="Usuario :"></asp:Label>
                                    </td>
                                    <td style="background-repeat:no-repeat; height:50px; width:140px; background-image: url('imagenesBasicas/imgApplicacion/fondoLogin.png');">
                                       &nbsp;<asp:TextBox ID="txt_usuario" runat="server" 
                                             CssClass="textoNormal_" Text="alberto" BorderStyle="None" Width="120px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                               
                            </td>
                            <td rowspan="2" valign="middle">
                                <asp:ImageButton id="btn_loggin" runat="server" onclick="btn_loggin_Click"  ImageUrl="~/imagenesBasicas/btn_Acceso.gif" Width="60px" />
                            </td>                                                      
                        </tr>
                        <tr valign="middle">
                            <td>
                            <table>
                                <tr>
                                    <td class="style4">
                                       <asp:Label ID="Label_pass_loggin" runat="server" CssClass="textoBOLDNegro_" 
                                            Text="Contraseñia :"></asp:Label>
                                    </td>
                                    <td 
                                        style="background-image: url('imagenesBasicas/imgApplicacion/fondoLogin.png'); height:50px; background-repeat:no-repeat; width:140px;">
                                       &nbsp;<asp:TextBox ID="txt_contrasenia" BorderStyle="None" runat="server" CssClass="textoChicoNegro_"
                                            TextMode="Password" Width="120px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                                 &nbsp;&nbsp;&nbsp;
                            </td>
                         
                        </tr>                       
                        <tr>
                            <td>
                                &nbsp&nbsp<asp:Label ID="lbl_error_acceso" runat="server" CssClass="textoNormalRojo_"></asp:Label>                            
                            </td>
                            <td>
                            </td>
                        </tr>
                        
                       
                    </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height:80px;"></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                           
                                <asp:Image ID="logo_legal" ImageUrl="imagenesBasicas/logoCopyrigth.jpg" 
                                    runat="server" Height="92px" Width="310px" />
                            </td>
                          <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            © Alberto Garcia Jurado. Al rights reserverd</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                </asp:Panel>
                        
                       
                </asp:Panel>
           
                </asp:Panel>
                    
            </asp:Panel>
        </div>
    </form>
</body>
</html>
