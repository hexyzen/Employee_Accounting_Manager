<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OnlineWorker.View.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" href="../Asset/Lib/Bootstrap/css/bootstrap.min.css"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
</head>
<body>
 
    <div class="container-fluid">
        <div class="row" style="height:45px"></div>
        <div class="row">
            <div class="col-md-5"></div>
            <div class="col-md-4"><h2 style="margin-bottom: 30px" class="text">Workers Online Manager</h2></div>
        </div>
        <div class="row ">
            <div class="col-md-2"></div>
             <div class="col-md-4 shadow-lg">
                 <img src='@Url.Content("~/Asset/Images/Agency.jpeg")' class="img-fluid "/>
                
                 
             </div>
             <div class="col-md-4 shadow-lg">
                 <h1 class="text-center">Sign In</h1>
             <form runat="server">

                     <div class="mb-3">
    <label for="EmailId" class="form-label">Email</label>
    <input type="email" class="form-control" id="EmailId" runat="server" required="required">
    
  </div>
  <div class="mb-4">
    <label for="UserPasswordTb" class="form-label">Password</label>
    <input type="password" class="form-control" id="UserPasswordTb" runat="server" required="required">
  </div>
  <div class="mb-4 form-group">

    <input type="radio" class="form-check-input" id="SellerRadio" name="Role" runat="server">
    <label class="form-check-label" style="margin-right: 30px"  for="exampleCheck1">Operator</label>
      <input type="radio" class="form-check-input" id="AdminRadio" checked="true" name="Role" runat="server">
    <label class="form-check-label" for="AdminRadio" >Admin</label>
  </div>
                 <div class="mb-4 d-grid">
                     <label id="InfoMsg" runat="server" class="text-danger"></label>
                     
                      <asp:Button text="  Login  " class="btn btn-dark btn-block" runat="server" ID="SaveBtn" OnClick="SaveBtn_Click" />

  </div>
                  
             </form>
                
             </div>
        </div>

    </div>
</body>
</html>
