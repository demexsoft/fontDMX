<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="errores.aspx.cs" Inherits="betaCulturalMARKII.errores" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  
    <link href="../estilos/fuentes.css" rel="stylesheet" type="text/css" />
    <link href="../estilos/stilocomponente.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <!--pnl_error_app-->
            <asp:Panel ID="pnl_error_app" runat="server">
               <table>
                    <tr>
                        <td class="textoNormalRojo_">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/imagenesBasicas/botonesImagenes/iconos/errorIcon.png" />
                            <strong>ERROR: </strong> 
                            <asp:Label ID="lblError" CssClass="textoNormalRojo_" runat="server"></asp:Label>
                            <br/>
                            <asp:LinkButton ID="btn_link_regresar_principal" Text="Regresar" CssClass="textoNormalAzul_" runat="server" OnClick="btn_link_regresar_principal_Click"></asp:LinkButton>
                            
                        </td>
                 </tr>
               </table> 
                
            </asp:Panel>

        <!--pnl_error_app-->
        
        

    
    </div>
    </form>
</body>
</html>
