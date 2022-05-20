<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="RSSWebBasedTechnologiesHW5.Home" %>
<style>
    .container{
        font-family:Arial;
        font-size:24px;
        margin:25px;
        width:350px;
        height:200px;
    }
    .middle{
        font-family: arial;
        font-size: 24px;
        margin: 25px;
        width:auto;
        height: auto;
        /*outline: dashed 1px black;*/
  /* Setup */
        position: relative;
    }
</style>
<!DOCTYPE html>
<link rel="stylesheet" href='http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css'
    media="screen" />
<script type="text/javascript" src='http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js'></script>
<script type="text/javascript" src='http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js'></script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="middle">
            
        </div>
        <div class="middle">
            <asp:DataList ID="NewsDataList" AlternatingItemStyle-HorizontalAlign="Center" runat="server" CellPadding="4" ForeColor="#333333" Width="686px" RepeatDirection="Horizontal" RepeatColumns="8">
                <HeaderTemplate>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="header" Text="News" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </HeaderTemplate>
                <ItemTemplate>
                    <table border="1">
                        <asp:Label ID="newsTitle" runat="server" Text='<%#Bind("Title") %>'></asp:Label>
                        <asp:Label ID="Label3" runat="server" Text='<%#Bind("NewsID") %>' Visible="false"></asp:Label>
                        <td>
                            <asp:ImageButton ID="newsImage" runat="server" ImageUrl='<%#Bind("ImageUrl") %>' Height="150px" Width="150px" CommandArgument="test" />
                        </td>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </form>
   <footer>

   </footer>
</body>
</html>
