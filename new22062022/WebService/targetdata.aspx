<%@ Page Language="C#" AutoEventWireup="true" CodeFile="targetdata.aspx.cs" Inherits="targetdata" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 725px">
    <asp:Panel ID="GB" runat="server"></asp:Panel>
        <br />
         <asp:Button ID="btnadd" runat="server" Text="Plus" OnClick="btnadd_Click"/>
        <asp:Label ID="Label1" runat="server" Text="Source Database"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="Source Schema"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server" Text="Source Table Name"></asp:Label>
        <br />
        <asp:DropDownList ID="ddsourcedatabase" runat="server" AutoPostBack="True">
            <asp:ListItem>--select source database--</asp:ListItem>
            <asp:ListItem>SQL</asp:ListItem>
            <asp:ListItem>MSSQL</asp:ListItem>
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddsourceschema" runat="server">
            <asp:ListItem>--select source schema--</asp:ListItem>
            <asp:ListItem>KAGGLE</asp:ListItem>
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddsourcetablename" runat="server">
            <asp:ListItem>--select table name--</asp:ListItem>
            <asp:ListItem>order_items</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Target Solution"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label5" runat="server" Text="Target Schema Name"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label6" runat="server" Text="Target Table Name"></asp:Label>
        <br />
        <asp:DropDownList ID="ddtargetsolution" runat="server">
            <asp:ListItem>--select target solution--</asp:ListItem>
            <asp:ListItem>databricks</asp:ListItem>
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddtargetschemaname" runat="server">
            <asp:ListItem>--select target schema--</asp:ListItem>
            <asp:ListItem>default</asp:ListItem>
            <asp:ListItem>bronze</asp:ListItem>
            <asp:ListItem>silver</asp:ListItem>
            <asp:ListItem>gold</asp:ListItem>
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddtargettablename" runat="server">
            <asp:ListItem>--select target table name--</asp:ListItem>
            <asp:ListItem>order_items</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label16" runat="server" Text="Grain Column"></asp:Label>
        <br />
        <asp:DropDownList ID="ddgarincolumn" runat="server">
            <asp:ListItem>--select grain column --</asp:ListItem>
            <asp:ListItem>order_id</asp:ListItem>
            <asp:ListItem>order_item_id</asp:ListItem>
            <asp:ListItem>product_id</asp:ListItem>
            <asp:ListItem>seller_id</asp:ListItem>
            <asp:ListItem>shipping_limit_date</asp:ListItem>
            <asp:ListItem>price</asp:ListItem>
            <asp:ListItem>freight_value</asp:ListItem>
            <asp:ListItem>updated_datetime</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <br />
        <asp:Label ID="Label7" runat="server" Text="Source Column Name"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label8" runat="server" Text="Source Function" ></asp:Label>
        <br />
        <asp:DropDownList ID="ddsourcecolumnname" runat="server" AppendDataBoundItems="true"  OnDataBound="ddsourcecolumnname_DataBound">
        </asp:DropDownList>
        
        <asp:DropDownList ID="ddsourcefunction" runat="server">
            <asp:ListItem>--select source function--</asp:ListItem>
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label9" runat="server" Text="Target Column Name"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label10" runat="server" Text="Target Function"></asp:Label>
        <br />
        <asp:DropDownList ID="ddtargetcolumnname" runat="server">
            <asp:ListItem>--select source column--</asp:ListItem>
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddtargetfunction" runat="server">
            <asp:ListItem>--select target function--</asp:ListItem>
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:ListBox ID="llbsourcecolumnlist" runat="server" Width="195px">
            <asp:ListItem>Source Column List</asp:ListItem>
        </asp:ListBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ListBox ID="llbtargetcolumnlist" runat="server" Width="179px">
            <asp:ListItem>Target Column List</asp:ListItem>
        </asp:ListBox>
        <br />
        <br />
        <asp:Label ID="Label11" runat="server" Text="Source Column Name"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label12" runat="server" Text="Operator"></asp:Label>
        <br />
        <asp:DropDownList ID="ddfsourcecolumnname" runat="server">
            <asp:ListItem Text="--select source column name--" Value="0">--select source column name--</asp:ListItem>
            <asp:ListItem Text="order_id" Value="1">order_id</asp:ListItem>
            <asp:ListItem>order_item_id</asp:ListItem>
            <asp:ListItem>product_id</asp:ListItem>
            <asp:ListItem>seller_id</asp:ListItem>
            <asp:ListItem>shipping_limit_date</asp:ListItem>
            <asp:ListItem>price</asp:ListItem>
            <asp:ListItem>freight_value</asp:ListItem>
            <asp:ListItem>updated_datetime</asp:ListItem>
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddsourceoperator" runat="server">
            <asp:ListItem>--select operator--</asp:ListItem>
            <asp:ListItem>like</asp:ListItem>
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtsourcefilter" runat="server">Filter Value</asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label13" runat="server" Text="Target Column Name"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label14" runat="server" Text="Operator"></asp:Label>
        <br />
        <asp:DropDownList ID="ddftargetcolumnname" runat="server">
            <asp:ListItem>--select target column name--</asp:ListItem>
            <asp:ListItem>order_id</asp:ListItem>
            <asp:ListItem>order_item_id</asp:ListItem>
            <asp:ListItem>product_id</asp:ListItem>
            <asp:ListItem>seller_id</asp:ListItem>
            <asp:ListItem>shipping_limit_date</asp:ListItem>
            <asp:ListItem>price</asp:ListItem>
            <asp:ListItem>freight_value</asp:ListItem>
            <asp:ListItem>updated_datetime</asp:ListItem>
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddtargetoperator" runat="server">
            <asp:ListItem>--select operator--</asp:ListItem>
            <asp:ListItem>like</asp:ListItem>
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txttargetfilter" runat="server">Filter Value</asp:TextBox>
        <br />
        <br />
        <asp:TextBox ID="txtsamplerow" runat="server" TextMode="Number">Sample Row</asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="SUBMIT" Width="168px" />
        <br />
        <br />
        <asp:Label ID="lblresult" runat="server"></asp:Label>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       
        <br />
        <br />
        
    </div>
      <%-- <script>
           $("ddsourcecolumnname").click(function () {
               //alert(this.ddsourcecolumnname);
               alert($(this).attr('id'));

           });


        </script>--%>
       <%-- <script>
$(document).ready(function(){
    $("#myBtn").click(function(){
        var elmId = $("#test").attr("ddsourcecolumnname");
        alert(elmId);
    });
});
</script>--%>
    </form>
    
</body>
</html>
