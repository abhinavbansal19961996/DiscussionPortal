<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="stulogin.aspx.cs" Inherits="_Default" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <form id="form1" runat="server">
    
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
	<tr>
		<td valign="top">Student ID<br />
            <asp:TextBox ID="txteml" runat="server" class="field"></asp:TextBox>
</td>
	</tr>
	<tr>
		<td height="20" valign="top"></td>
	</tr>
	<tr>
		<td valign="top">Password<br />
            <asp:TextBox ID="txtpwd" runat="server" Class="field" TextMode="Password"></asp:TextBox>
</td>
	</tr>
      
	<tr>
		<td valign="top"><em>Student Sign In Page</em></td>
	</tr>
	<tr>
		<td height="20" valign="top">
            <strong>
            <asp:Button ID="Button1" runat="server" Text="Login" Height="38px" style="font-weight: bold" Width="93px" OnClick="Button1_Click" />
            </strong>
            </td>
	</tr>
	<tr>
		<td valign="top">
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
        </td>
	</tr>




</table>

        </form>


</asp:Content>
