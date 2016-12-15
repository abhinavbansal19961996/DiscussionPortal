<%@ Page Title="" Language="C#" MasterPageFile="~/Teach_Dashboard.master" AutoEventWireup="true" CodeFile="stuff.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <br />
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color: #FF0000; text-decoration: underline"><strong>&nbsp;&nbsp;&nbsp;</strong></span><span style="font-size: x-large; color: #FF0000; text-decoration: underline"><strong>GROUP POSTS</strong></span><span style="color: #FF0000; text-decoration: underline"><strong>&nbsp;&nbsp;&nbsp;&nbsp;</strong></span>&nbsp;&nbsp;</p>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style="font-size: x-large"><strong>&nbsp;Announcement:</strong></span></p>
    <p>
&nbsp;<asp:TextBox ID="TextBox1" runat="server" Height="125px" style="margin-left: 64px" TextMode="MultiLine" Width="384px"></asp:TextBox>
    </p>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong><span style="font-size: x-large">&nbsp;&nbsp;&nbsp; File Upload:&nbsp; </span>
        <asp:FileUpload ID="FileUpload1" runat="server" Height="32px" Width="367px" />
&nbsp; </strong></p>
    <p>
        <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong>
        <asp:Button ID="Button1" runat="server" Height="45px" Text="Post" Width="99px" OnClick="Button1_Click" style="font-size: x-large" />
    </p>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource1" GridLines="Vertical" Height="184px" style="font-size: large; margin-left: 62px" Width="353px">
            <AlternatingRowStyle BackColor="Gainsboro" />
            <Columns>
                <asp:BoundField DataField="notes" HeaderText="notes" SortExpression="notes" />
               
                <asp:TemplateField HeaderText="Download Here">
                     <ItemTemplate>  
                       <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandArgument='<%# Eval("file_name") %>' CommandName="Download" Text='<%# Eval("file_name") %>' />  
                     </ItemTemplate>   
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=priyanshsoni\sqlexpress17;Initial Catalog=MinHasti;Integrated Security=True;Pooling=False" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [file_name], [notes] FROM [docs] WHERE ([grp_id] = @grp_id)">
            <SelectParameters>
                <asp:SessionParameter Name="grp_id" SessionField="grp_id" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        &nbsp;</p>
</asp:Content>

