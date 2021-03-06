﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RssView.aspx.cs" Inherits="RSSFeed.RssView" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Rss feed</title>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="Content/bootstrap.min.css" rel="stylesheet">

    <!--[if lt IE 9]>
      <script src="Scripts/html5shiv.min.js"></script>
      <script src="Scripts/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <script src="Scripts/jquery-1.9.1.min.js"></script>
    <script src="Scripts/bootstrap.js"></script>

    <div style="overflow-x: hidden; overflow-y: auto;">
        <form id="form" runat="server">
            <asp:Label runat="server" ID="errorLabel" ForeColor="red" />
            <div class="row">
                <asp:Repeater ID="rssRepeater" runat="server">
                    <ItemTemplate>
                        <div class="col-md-4">
                            <table cellspacing="5" style="height: 180px" class="table-striped table-condensed">
                                <tr>
                                    <td style="width: 30%">
                                        <h5 style="color: #4b0082"><%#Eval("Title")%></h5>
                                    </td>
                                    <td align="right">
                                        <%#Eval("PublishDate")%>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="max-height: 30%">
                                        <%#Eval("Description")%>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td align="right" style="width: 30%">
                                        <a href=' <%#Eval("Link")%>' target="_blank">Read More</a>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </form>
    </div>
</body>
</html>
