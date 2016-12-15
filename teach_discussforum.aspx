<%@ Page Title="" Language="C#" MasterPageFile="~/Teach_Dashboard.master" AutoEventWireup="true" CodeFile="teach_discussforum.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p style="font-size: x-large; color: #FF0000">
        &nbsp;</p>
    <p style="font-size: x-large; color: #FF0000">
        <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; WELCOME TO TECHNICAL DISCUSSION FORUM</strong></p>
    <p style="font-size: x-large; color: #FF0000">
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="title" DataValueField="titleid" Height="35px" style="margin-left: 49px" Width="147px">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=priyanshsoni\sqlexpress17;Initial Catalog=MinHasti;Integrated Security=True;Pooling=False" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [titleid], [title] FROM [Title]"></asp:SqlDataSource>
    </p>
    <p style="font-size: x-large; color: #FF0000">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataKeyNames="forumId" DataSourceID="SqlDataSource2" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" style="font-size: large; margin-left: 49px">
            <Columns>
                <asp:TemplateField HeaderText="Question">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Height="100px" Text='<%# Bind("question") %>' TextMode="MultiLine" Width="397px"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="PosterName" HeaderText="PosterName" SortExpression="PosterName" />
                <asp:TemplateField HeaderText="View Comments">
                    <ItemTemplate>
                        <asp:Button ID="Button2" runat="server" CommandName="select" OnClick="Page_Load" Text="View Comments" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="dateTime" HeaderText="dateTime" SortExpression="dateTime" />
            </Columns>
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="Data Source=priyanshsoni\sqlexpress17;Initial Catalog=MinHasti;Integrated Security=True;Pooling=False" ProviderName="System.Data.SqlClient" SelectCommand="SELECT  [forumId],[question], [PosterName], [dateTime] FROM [Forum] WHERE ([titleId] = @titleId)

">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="titleId" PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
    </p>
    <p style="font-size: x-large; color: #FF0000">
        <asp:TextBox ID="TextBox1" runat="server" Height="130px" style="margin-left: 49px" TextMode="MultiLine" Width="371px"></asp:TextBox>
    </p>
    <p style="font-size: x-large; color: #000000">
        <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Name:</strong><asp:TextBox ID="TextBox2" runat="server" Width="162px"></asp:TextBox>
    </p>
    <p style="font-size: x-large; color: #000000">
        <asp:Button ID="Button1" runat="server" Height="32px" OnClick="Button1_Click" style="font-size: x-large; margin-left: 50px" Text="Post " Width="138px" />
    </p>
</asp:Content>

