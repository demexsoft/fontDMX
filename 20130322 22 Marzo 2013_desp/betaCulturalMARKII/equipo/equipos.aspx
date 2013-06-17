<%@ Page Title="" Language="C#" MasterPageFile="~/mp_MenuPrincipal.Master" AutoEventWireup="true"
    CodeBehind="equipos.aspx.cs" Inherits="betaCulturalMARKII.equipo.equipos" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td colspan="2">
                <asp:Label ID="lbl_titulo_content_equipo" Text="TEAM" CssClass="tituloAzul_" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <br />
            </td>
        </tr>
        <tr>
            <td valign="top">
                <fieldset>
                    <asp:TreeView ID="ctrEquipo" runat="server" ImageSet="Contacts" NodeIndent="10" OnSelectedNodeChanged="ctrEquipo_SelectedNodeChanged">
                        <HoverNodeStyle Font-Underline="False" />
                        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                            NodeSpacing="0px" VerticalPadding="0px" />
                        <ParentNodeStyle Font-Bold="True" ForeColor="#5555DD" />
                        <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                    </asp:TreeView>
                </fieldset>
            </td>
            <td align="center" valign="middle">
                <asp:Button ID="btnAdd" runat="server" Text="<<" OnClick="btnAdd_Click" />
                <br />
                <br />
                <asp:Button ID="btnQuit" runat="server" Text=">>" OnClick="btnQuit_Click" />                
            </td>
            <td align="center">
                <fieldset>
                    <br />
                    <asp:GridView ID="gvEmpleados" runat="server" AutoGenerateColumns="false" ShowFooter="true"
                        CellPadding="4" CssClass="resultTable" GridLines="None" OnRowDataBound="gvEmpleados_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="IDEmpleado" HeaderText="ID" ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-Width="50px">
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Leader" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chbLider" runat="server" oncheckedchanged="chbLider_CheckedChanged" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="nombreEmp" HeaderText="Name" ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-Width="100px">
                            </asp:BoundField>
                            <asp:BoundField DataField="apePat" HeaderText="Last Name" ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-Width="100px">
                            </asp:BoundField>
                            <asp:BoundField DataField="apeMat" HeaderText="Materno" ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-Width="100px">
                            </asp:BoundField>
                            <asp:BoundField DataField="nomPuesto" HeaderText="Puesto" ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-Width="100px">
                            </asp:BoundField>
                            <asp:BoundField DataField="nomArea" HeaderText="Area" ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-Width="100px">
                            </asp:BoundField>
                        </Columns>
                        <FooterStyle CssClass="footerGrid" />
                        <HeaderStyle CssClass="headerGrid" Height="30px" />
                        <RowStyle CssClass="itemGrid" Wrap="true" />
                        <SelectedRowStyle BackColor="#d4d4d4" Font-Bold="True" />
                        <PagerStyle ForeColor="#ffffff" BackColor="#3b3b3b" Font-Size="11px" />
                        <AlternatingRowStyle BackColor="#e5e5e5" />
                    </asp:GridView>
                </fieldset>
            </td>
        </tr>
    </table>
</asp:Content>
