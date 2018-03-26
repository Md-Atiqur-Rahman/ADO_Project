<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-3"></div>
    <div class="col-md-8">
        <table class="table table-bordered">
            
            <tr>
                <td colspan="2"><h1>Product Informations</h1></td>
            </tr>
            <tr>
                 <td>
                      
                     <asp:Label ID="Label1" runat="server" Text="ID: "></asp:Label> 
                      

                 </td>
                <td style="width: 521px"  >
                    <asp:TextBox ID="TextBox7" runat="server"   ></asp:TextBox>
                    <asp:Button ID="Edit" runat="server" Text="Search" OnClick="Edit_Click" Width="106px"  />
                    <asp:Button ID="delete" runat="server" Text="delete" OnClick="delete_Click" />

                </td>
                
            </tr>
            
            <tr>
                
                <td>Product:</td>
                <td style="width: 521px">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Date:</td>
                <td style="width: 521px">
                    <asp:TextBox ID="TextBox2" runat="server" ></asp:TextBox>
                    <asp:ImageButton ID="ImageButton1" runat="server"  ImageUrl="~/Image/calendar-outline-filled.png"  OnClick="ImageButton1_Click" Height="28px" Width="22px" />
                   <%-- <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>--%>
                       <asp:Calendar ID="Calendar2" runat="server" 
           ShowGridLines="True" OnSelectionChanged="Calendar2_SelectionChanged" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" Width="220px" >

                           <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                           <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                           <OtherMonthDayStyle ForeColor="#CC9966" />

         <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True">
         </SelectedDayStyle>

                           <SelectorStyle BackColor="#FFCC66" />
                           <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                           <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />

      </asp:Calendar>  
                    
                </td>
            </tr>
            <tr><td>Shipping Address</td><td style="width: 521px">
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td></tr>
            <tr><td style="height: 24px">Quantity</td><td style="width: 521px; height: 24px;">
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td></tr>
               <tr><td>Unit Price</td><td style="width: 521px">
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></td></tr>
                <tr><td>Discount</td><td style="width: 521px">
                <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox></td></tr>
            <tr>
                
                
                
                <td  colspan="2">
                <asp:Button ID="Save" runat="server" Text="Save" OnClick="Save_Click"  />
               
               
             
                <asp:Button ID="update" runat="server" Text="update" OnClick="update_Click" />
                </td>
               
            </tr>
          
          
        </table>

         
    </div>
     <div class="col-md-3">    </div>
     <div class="col-md-8">
         
                 <asp:GridView ID="GridView1" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
                     <FooterStyle BackColor="#CCCCCC" />
                     <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                     <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                     <RowStyle BackColor="White" />
                     <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                     <SortedAscendingCellStyle BackColor="#F1F1F1" />
                     <SortedAscendingHeaderStyle BackColor="#808080" />
                     <SortedDescendingCellStyle BackColor="#CAC9C9" />
                     <SortedDescendingHeaderStyle BackColor="#383838" />
                   </asp:GridView>
             
     </div>

</asp:Content>
