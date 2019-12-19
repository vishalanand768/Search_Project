<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="searchdata.aspx.cs" Inherits="Search_Project.searchdata" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>Name :</td>
                    <td><asp:TextBox ID="txtname" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td>Age :</td>
                    <td><asp:TextBox ID="txtage" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td>City :</td>
                    <td><asp:TextBox ID="txtcity" runat="server"></asp:TextBox></td>
                </tr>


                <tr>
                    <td>Contact No. :</td>
                    <td><asp:TextBox ID="txtcontact" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td></td>
                    <td><asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click"></asp:Button></td>
                </tr>

                <tr>
                    <td></td>
                    <td><asp:GridView ID="grd" runat="server" OnRowCommand="grd_RowCommand" AutoGenerateColumns="false">
                      <Columns>

                          <asp:TemplateField HeaderText="Name">
                              <ItemTemplate>
                                  <%#Eval("name") %>
                              </ItemTemplate>
                          </asp:TemplateField>

                           <asp:TemplateField HeaderText="Age">
                              <ItemTemplate>
                                  <%#Eval("age") %>
                              </ItemTemplate>
                          </asp:TemplateField>

                           <asp:TemplateField HeaderText="City">
                              <ItemTemplate>
                                  <%#Eval("city") %>
                              </ItemTemplate>
                          </asp:TemplateField>

                           <asp:TemplateField HeaderText="Contact No.">
                              <ItemTemplate>
                                  <%#Eval("contact_no") %>
                              </ItemTemplate>
                          </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                           <asp:Button ID="btndelete" runat="server" Text="Delete" CommandName="A" CommandArgument='<%#Eval("Id") %>' />
                           <asp:Button ID="btnedit" runat="server" Text="Edit" CommandName="B" CommandArgument='<%#Eval("Id") %>' />
                        </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                        </asp:GridView></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
