<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="OnlineWorker.View.Admin.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        @import url('https://fonts.googleapis.com/css2?family=Poppins:wght@100&display=swap');
        h1{
            font-family: 'Opens Sans', sans-serif;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
    <!-- <h1>Dashboard</h1>-->
    <div class="container-fluid">
        <div class="row" style="height:80px">
            <div class="col-md-3"></div>
             <div class="col-md-8">
                 <div class="row">
   
                     <div class="col-9" style="margin-top: 15px; margin-left: 190px"> <h2 class="text-dark">Dashboard</h2> </div>
                 </div>
                 </div>
             <div class="col-md-1"></div>
        </div>
        <div class="row">
            <div class="col-1 "></div>
            <div class="col-10">
                <div class="row">
                    <div class="col-md-3 bg-danger rounded">
                      <div class="row">
                           <div class="col-md-2"><div class="logo-image">
        <img src="../../Asset/Images/workers1.jpg" 
        style="width: 46px;
        height: 46px;
        border-radius: 50%;
        overflow: hidden;
        margin-top: -6px;">
      </div></div>
                       <div class="col-md-10">
                           <h3 class="text-white">Workers</h3>
                           <h1 class="text-white" runat="server" id="WorkerNumTb">Num</h1>
                       </div>
                      </div>
                        
                    </div>
                    <div class="col-md-1 bg-light">
                  
                    </div>
                    <div class="col-md-3 bg-warning rounded" >
                        <div class="row">
                           <div class="col-md-2"><div class="logo-image">
        <img src="../../Asset/Images/icon_seat.png" 
        style="width: 46px;
        height: 46px;
        border-radius: 50%;
        overflow: hidden;
        margin-top: -6px;">
      </div></div>
                       <div class="col-md-10">
                           <h3 class="text-white">Seats</h3>
                           <h1 class="text-white" runat="server" id="SeatNumTb">Num</h1>
                       </div>
                      </div>
                    </div>
                     <div class="col-md-1 bg-light">
                       
                    </div>
                  
                    <div class="col-md-3 bg-danger rounded">
                         <div class="row">
                           <div class="col-md-2"><div class="logo-image">
        <img src="../../Asset/Images/icon_user.jpg" 
        style="width: 46px;
        height: 46px;
        border-radius: 50%;
        overflow: hidden;
        margin-top: -6px;">
      </div></div>
                       <div class="col-md-10">
                           <h3 class="text-white">Operators</h3>
                           <h1 class="text-white" runat="server" id="OperNumTb">Num</h1>
                       </div>
                      </div>
                    </div>
                     <div class="col-md-1 bg-light">
                      
                    </div>
                </div>
            </div>
            <div class="col-1 "></div>
        </div>
        <div class="row mb-5 mt-5"></div>
        <div class="row">
            <div class="col-1 "></div>
            <div class="col-10">
                <div class="row">
                            <div class="col">
                                   <div  class="mb-2" style="width:250px">   
      <asp:DropDownList ID="OperCb" class="form-control" DataTextField="Colour" ondatabound="MyListDataBound"  runat="server"  ViewStateMode="Enabled" EnableViewState="true" AutoPostBack="True" OnSelectedIndexChanged="OperCb_SelectedIndexChanged"> 
                   <asp:ListItem value="0">0</asp:ListItem>
        
          
      </asp:DropDownList> 

                                   </div>
                            </div>
                            <div class="col"></div>
                            <div class="col"></div>
                        </div>
                <div class="row">
                    <div class="col-md-3 bg-info rounded">
                        
                      <div class="row">
                           <div class="col-md-2"><div class="logo-image">
        <img src="../../Asset/Images/icon_doc.jpg" 
        style="width: 46px;
        height: 46px;
        border-radius: 50%;
        overflow: hidden;
        margin-top: -6px;">
      </div></div>
                       <div class="col-md-10">
                            
                           <h5 class="text-white">Number of pays</h5>
                           <h1 class="text-white" id="AmountSeatTb" runat="server">Num</h1>
                       </div>
                      </div>
                        
                    </div>
                    <div class="col-md-1 bg-light">
                  
                    </div>
                    <div class="col-md-3 bg-secondary rounded">
                        <div class="row">
                           <div class="col-md-2"><div class="logo-image">
        <img src="../../Asset/Images/icon_pay.jpg" 
        style="width: 46px;
        height: 46px;
        border-radius: 50%;
        overflow: hidden;
        margin-top: -6px;">
      </div></div>
                       <div class="col-md-10">
                           <h3 class="text-white">Total Pays</h3>
                           <h1 class="text-white" runat="server" id="TotalTb">Num</h1>
                       </div>
                      </div>
                    </div>
                     <div class="col-md-1 bg-light">
                       
                    </div>
                     <div class="col-md-3 bg-primary rounded">
                         <div class="row">
                           <div class="col-md-2"><img src="../../Asset/Images/Us_dol.png"/></div>
                       <div class="col-md-10">
                           <h3 class="text-white">Finance</h3>
                           <h1 class="text-white h3" id="FinanceTb" runat="server">Num</h1>
                       </div>
                      </div>
                    </div>
                     <div class="col-md-1 bg-light">
                      
                    </div>
                </div>
            </div>
            <div class="col-1 "></div>
        </div>

        <div class="row">
            <div class="col-4"></div>
            <div class="col-4">
                <img src="../../Asset/Images/Agency.jpeg" style="height:250px" />
            </div>

            <div class="col-4"></div>

        </div>

    </div>

</asp:Content>
