<%@ Page Title="" Language="C#" MasterPageFile="~/Teach_Dashboard.master" AutoEventWireup="true" CodeFile="teach_edtprofile.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Hasti | Profile Details</title>
<link href="../script-css/styles.css" rel="stylesheet" type="text/css" />
</head>

<body>
<div id="header">
	<div class="content">
		<div class="logo"><img src="../images/hastilogof.GIF" alt="" style="height: 138px; width: 315px" /></div>
		<div class="clearfix"></div>
	</div>
</div>
<div id="contentPart" style="height: 575px">
	<h1>Enter your details</h1>
    <p>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </p>
	<table width="100%" border="0" cellspacing="0" cellpadding="8" style="height: 272px">
		<tr>
			<td valign="top" style="text-align: center; width: 15%;">&nbsp;Name:</td>
			<td width="85%" align="left" valign="top">
			    <asp:TextBox ID="txtname" class="field2" runat="server"></asp:TextBox>
			</td>
		</tr>
		
		<tr>
			<td valign="top" style="text-align: center; width: 15%;">Biography:</td>
			<td align="left" valign="top">
                <asp:TextBox ID="txtbio" CssClass="field2" runat="server" Height="163px" Width="362px" TextMode="MultiLine"></asp:TextBox>
            </td>
		</tr>
        <tr>
			<td valign="top" style="text-align: center; width: 15%;">&nbsp;Email:</td>
			<td width="85%" align="left" valign="top">
			    <asp:TextBox ID="txteml" class="field2" runat="server"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td valign="top" style="text-align: center; width: 15%; height: 44px;">Upload Image</td>
			<td align="left" valign="top" style="height: 44px">
                <asp:FileUpload ID="FileUpload1" runat="server" style="margin-left: 0px" Width="300px" />
&nbsp;</td>
		</tr>
		
        <tr>
            <td valign="top" style="text-align: center; width: 15%;">Password:</td>
            <td width="85%" align="left" valign="top">
			    <asp:TextBox ID="txtpwd" class="field2" runat="server" TextMode="Password"></asp:TextBox>
			</td>
        </tr>
        <tr>
            <td style="width: 15%">

            </td>
        </tr>
        <tr>
			<td valign="top" style="text-align: center; width: 15%;"></td>
			<td align="left" valign="top">
                <asp:Button ID="Button1" runat="server" style="font-size: large" Text="Submit" OnClick="Button1_Click"  />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" style="font-size: large" Text="Cancel" OnClick="Button2_Click" />
            </td>
		</tr>
	</table>
</div>
<div id="footer">Copyrights © 2016 Hasti. All Rights Reserved.</div>
</body>
</html>
</asp:Content>

