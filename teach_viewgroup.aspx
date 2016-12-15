<%@ Page Title="" Language="C#" MasterPageFile="~/Teach_Dashboard.master" AutoEventWireup="true" CodeFile="teach_viewgroup.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style="text-decoration: underline; font-size: x-large; color: #FF0000"><strong>GROUPS</strong></span></p>
    <p>
        &nbsp;</p>
    <p style="margin-left: 40px">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" Height="231px" Width="511px" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="grp_id" HeaderText="grp_id" InsertVisible="False" ReadOnly="True" SortExpression="grp_id" />
                <asp:BoundField DataField="grp_name" HeaderText="grp_name" SortExpression="grp_name" />
                <asp:TemplateField HeaderText="View Group">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="Linkbutton1" CommandArgument='<%#Eval("grp_id") %>' CommandName="VIEW">View Group</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=priyanshsoni\sqlexpress17;Initial Catalog=MinHasti;Integrated Security=True;Pooling=False" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [grp_id], [grp_name] FROM [groups] WHERE ([teach_id] = @teach_id)">
            <SelectParameters>
                <asp:SessionParameter Name="teach_id" SessionField="cod" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </p>
</asp:Content>

