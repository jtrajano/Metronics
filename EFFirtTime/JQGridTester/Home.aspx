<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="JQGridTester.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>JQGrid Tester</title>
    <link href="content/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="content/ui.jqgrid.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table id="list2"></table>
    <div id="pager2"></div>
    </form>
</body>
</html>
<script src="scripts/jquery-latest.js" type="text/javascript"></script>
<script src="scripts/jquery-ui.js" type="text/javascript"></script>
<script src="scripts/jqgrid/grid.locale-en.js" type="text/javascript"></script>
<script src="scripts/jqgrid/jquery.jqGrid.min.js" type="text/javascript"></script>
<script src="scripts/grid.js" type="text/javascript"></script>
