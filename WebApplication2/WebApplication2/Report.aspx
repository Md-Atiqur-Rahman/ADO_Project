<%@ Page Title="Report" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="WebApplication2.About" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Report</h2>
    
    <div class="row">
        <div class="col-md-4"></div>
        <div class="col-md-8">

            <table>
                <tr>

                    <td>
                        <asp:Button ID="btn" runat="server" Text="Show Report" OnClick="btn_Click" />
                        From:
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        To:<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                       
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <%--  <tr>
                     <td>
                <rsweb:ReportViewer ID="ReportViewer2" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="681px">
                    <LocalReport ReportEmbeddedResource="WebApplication2.Report2.rdlc">
                        
                    </LocalReport>
                 
             </rsweb:ReportViewer>
                     </td>
                 </tr>--%>
                <tr>

                    <td>
                        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="681px">
                            <LocalReport ReportEmbeddedResource="WebApplication2.Report1.rdlc" ReportPath="Report1.rdlc">
                                <DataSources>
                                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                                </DataSources>
                            </LocalReport>
                        </rsweb:ReportViewer>
                    </td>
                </tr>
            </table>


        </div>

    </div>
</asp:Content>
