<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="Machine1_3.aspx.cs" Inherits="WebScada2.Room_1.Machine3" %>
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
        <strong><em>Помещение 1. Установка 3. Используем UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" </em></strong></p>
    
    <!------>
    <asp:ScriptManager runat="server" />

    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
        Температура на входе -
        <asp:Label ID="LbTemp1_1_3" runat="server"></asp:Label>
        
        <br />
    
        Температура на выходе -
        <asp:Label ID="LbTemp2_1_3" runat="server"></asp:Label>
        
        <br />
    
        <asp:Button ID="BtnTemperatura1_1_3" runat="server" Text="Проверить текущую температуру" OnClick="Button3_Click_1_3" />
    
    </ContentTemplate>
    </asp:UpdatePanel>
    <!---->
    <br />
    <br />
    <p>
        График температур от
        <asp:TextBox ID="TbFrom_1_3" runat="server" Text="2018-07-24 06:30:00"> </asp:TextBox>
до
        <asp:TextBox ID="TbTo_1_3" runat="server" Text="2018-07-24 06:35:00"></asp:TextBox>
    </p>
    <p>
       
        <asp:UpdatePanel ID="UpdatePanel3" UpdateMode="Conditional" runat="server"> 
    <ContentTemplate>
        <asp:Button ID="Button8" Text="Обновить таймер №1" runat="server" OnClick="Button8_Click" />
        <asp:Label runat="server" BackColor="Red" ForeColor="White" ID="Label8" />
        </ContentTemplate>
            </asp:UpdatePanel>


</p>
    <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server"> 
    <ContentTemplate>
        <asp:Button ID="Button4_1_3" runat="server" Text="Построить график" />
    <br />
    
        <asp:Chart ID="Chart4" runat="server" DataSourceID="SqlDataSource1" Width="663px">
            <series>
                <asp:Series ChartType="Line" Name="Series1" XValueMember="Time_data" YValueMembers="R2">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
        </asp:Chart>
       
        <asp:Chart ID="Chart5" runat="server" DataSourceID="SqlDataSource1" Width="665px">
            <Series>
                <asp:Series ChartType="Line" Name="Series1" XValueMember="Time_data" YValueMembers="R3">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>

         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Database1ConnectionString %>" SelectCommand="SELECT [R2], [R3], [Time_data] FROM [Table_1] WHERE (([Time_data] &gt; @Time_data) AND ([Time_data] &lt; @Time_data2))">
            <SelectParameters>
                <asp:ControlParameter ControlID="TbFrom_1_3" DefaultValue="2018-07-24 06:30:00" Name="Time_data" PropertyName="Text" Type="DateTime" />
                <asp:ControlParameter ControlID="TbTo_1_3" DefaultValue="2018-07-24 06:35:00" Name="Time_data2" PropertyName="Text" Type="DateTime" />
            </SelectParameters>
        </asp:SqlDataSource>
        </ContentTemplate>
     </asp:UpdatePanel>

</asp:Content>

