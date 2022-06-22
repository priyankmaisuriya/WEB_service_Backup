<%@ Page Language="C#" AutoEventWireup="true" CodeFile="demoemp.aspx.cs" Inherits="demoemp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title></title>

    <%--<style> 
    input[type=text] {
  width: 100%;
  padding: 12px 20px;
  margin: 8px 0;
  box-sizing: border-box;
  border: 3px solid #ccc;
  -webkit-transition: 0.5s;
  transition: 0.5s;
  outline: none;
}

input[type=text]:focus {
  border: 3px solid #555;
}

  input[type=button], input[type=submit], input[type=reset]{ 
    border-style: none;
        border-color: inherit;
        border-width: medium;
        background-color: #04AA6D;
        color: white;
        padding: 16px 32px;
        text-decoration: none;
  margin: 4px 2px 4px 3px;
        cursor: pointer;

 }

</style>--%>
    <link href="StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <div class="container">
        <form id="form1" runat="server">
            <div>
                <div class="row">
                    <div class="col-25">
                        <asp:Label ID="Label2" runat="server" Text="FirstName"></asp:Label> 
                    </div>
                    <div class="col-75">
                        <asp:TextBox ID="txtfname" runat="server" ></asp:TextBox>
                       
                    </div>
                </div>
                 <div class="row">
                    <div class="col-25">
                     <asp:Label ID="Label3" runat="server" Text="LastName"></asp:Label>
                    </div>
                    <div class="col-75">
                        <asp:TextBox ID="txtlname" runat="server"></asp:TextBox>
                    </div>
                </div>
                 <div class="row">
                    <div class="col-25">
                     <asp:Label ID="Label4" runat="server" Text="Gender"></asp:Label>
                    </div>
                    <div class="col-75">
                        <asp:TextBox ID="txtgender" runat="server"></asp:TextBox>
                    </div>
                </div>
                 <div class="row">
                    <div class="col-25">
                     <asp:Label ID="Label5" runat="server" Text="DateOfBirth"></asp:Label>
                    </div>
                    <div class="col-75">
                        <asp:TextBox ID="txtdob" runat="server" ></asp:TextBox>
                    </div>
                </div>
                 <div class="row">
                    <div class="col-25">
                     <asp:Label ID="Label6" runat="server" Text="City"></asp:Label>
                    </div>
                    <div class="col-75">
                          <asp:TextBox ID="txtcity" runat="server"></asp:TextBox>
                    </div>
                </div>
                 <div class="row">
                    <div class="col-25">
                    <asp:Label ID="Label7" runat="server" Text="DateOfJoining"></asp:Label>
                    </div>
                    <div class="col-75">
                          <asp:TextBox ID="txtdoj" runat="server"></asp:TextBox>
                    </div>
                </div>
                 <div class="row">
                    <div class="col-25">
                   <asp:Label ID="Label8" runat="server" Text="Salary"></asp:Label>
                    </div>
                    <div class="col-75">
                          <asp:TextBox ID="txtsalary" runat="server" ></asp:TextBox>
                    </div>
                </div>
                <br />
                  <div class="row">
   <asp:Button ID="submit" runat="server" OnClick="submit_Click" Text="Button"  />
  </div>
         <br />
          
         <br /> 
                <asp:Label ID="lblclear" runat="server" Text="Label"></asp:Label>
        <br />
          
         <br />           
        <asp:Label ID="lbltext" runat="server" Text=""></asp:Label>
      
    
      
        <asp:Panel ID="Panel1" runat="server">
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
        </asp:Panel>
               
            </div>
        </form>
    </div>
</body>
</html>
