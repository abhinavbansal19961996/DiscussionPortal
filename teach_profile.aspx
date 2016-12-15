<%@ Page Title="" Language="C#" MasterPageFile="~/Teach_Dashboard.master" AutoEventWireup="true" CodeFile="teach_profile.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Hasti | Profile Page</title>
<link href="../script-css/styles.css" rel="stylesheet" type="text/css" />
</head>

<body>
<div id="header">
	<div class="content">
		<div class="logo"><img src="../images/hastilogof.GIF" alt="" style="height: 138px; width: 315px" /></div>
		<div class="clearfix"></div>
	</div>
</div>
<div class="profile">
<div class="info">
<h1><asp:Label ID="lb1" runat="server" /></h1>
<h3>Teacher ID : <asp:Label ID="lb2" runat="server" /> </h3>
<h3>Email : <asp:Label ID="lbeml" runat="server" /> </h3>
<asp:Image ID="img2" Width="100px" Height="100px" runat="server" AlternateText="Image not available"/>
<br />    
    <br />
<h3>Biography: <asp:Label ID="lb3" runat="server" /></h3>
 <!--  <img id="img2" src="images/a.jpg" width="300" height="200"/>-->

	
</div>
</div>
</body>
</html>


</asp:Content>

