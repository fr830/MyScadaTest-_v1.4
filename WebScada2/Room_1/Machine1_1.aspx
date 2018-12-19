<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="Machine1_1.aspx.cs" Inherits="WebScada2.Room_1.Machine1" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            font-size: large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <p class="auto-style2">
        <strong><em>Помещение 1. Установка 1. При нажатии кнопок вся страница перегружается целиком. Не используется UpdatePanel</em></strong></p>
    <p>
        Температура на входе -
        <asp:Label ID="LbTemp1" runat="server" Text="<%# temperatura1 %>"></asp:Label>
    &nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="<%#ExceptionT1%>"></asp:Label>
    </p>
    <p>
        Температура на выходе -
        <asp:Label ID="LbTemp2" runat="server" Text="<%# temperatura2 %>"></asp:Label>
    &nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="<%#ExceptionT2%>"></asp:Label>
    </p>
    <p>
        <asp:Button ID="BtnTemperatura" runat="server" Text="Проверить температуру" OnClick="Button3_Click" />
    </p>
    <p>
        График температур от
        <asp:TextBox ID="TbFrom1_1" runat="server" Text="2018-07-24 06:30:00"> </asp:TextBox>
&nbsp;до
        <asp:TextBox ID="TbTo1_1" runat="server" Text="2018-07-24 06:35:00"></asp:TextBox>
    </p>
    <p>
&nbsp;</p>
    <p>
        <asp:Button ID="Button4" runat="server" Text="Построить график" />
    </p>
    <p>
        <asp:Chart ID="Chart2" runat="server" DataSourceID="SqlDataSource1" Width="663px">
            <series>
                <asp:Series ChartType="Line" Name="Series1" XValueMember="Time_data" YValueMembers="T1">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
        </asp:Chart>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Database1ConnectionString %>" SelectCommand="SELECT [Time_data], [T1], [T2] FROM [Table_1] WHERE (([Time_data] &gt; @Time_data) AND ([Time_data] &lt; @Time_data2))">
            <SelectParameters>
                <asp:ControlParameter ControlID="TbFrom1_1" DefaultValue="2018-07-24 06:30:00" Name="Time_data" PropertyName="Text" Type="DateTime" />
                <asp:ControlParameter ControlID="TbTo1_1" DefaultValue="2018-07-24 06:35:00" Name="Time_data2" PropertyName="Text" Type="DateTime" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:Chart ID="Chart3" runat="server" DataSourceID="SqlDataSource1" Width="665px">
            <Series>
                <asp:Series ChartType="Line" Name="Series1" XValueMember="Time_data" YValueMembers="T2">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
&nbsp;</p>
    <p>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataKeyNames="Time_data" DataSourceID="SqlDataSource1" Width="432px">
            <Columns>
                <asp:BoundField DataField="Time_data" HeaderText="Time_data" ReadOnly="True" SortExpression="Time_data" />
                <asp:BoundField DataField="T1" HeaderText="T1" SortExpression="T1" />
                <asp:BoundField DataField="T2" HeaderText="T2" SortExpression="T2" />
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
    </p>
</asp:Content>

