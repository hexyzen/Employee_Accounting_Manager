<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Seats.aspx.cs" Inherits="OnlineWorker.View.Admin.Seats" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
     <div class="container-fluid">
        <div class="row">

            <div class="col-md-8"><br /><h2 class="text-dark" style="margin-bottom: 30px">Seat Details</h2></div>

        </div>
        <div class="row">
            <div class="col-md-4">

               
                     <div class="mb-3">
    <label for="exampleInputEmail1" class="form-label">Seat Name</label>
    <input type="text" class="form-control" id="SeatNameTb" runat="server">
    
  </div>




                 <div class="mb-3">
    <label for="exampleInputEmail1" class="form-label">Seat Remarks</label>
    <input type="text" class="form-control" id="SeatRemarkTb" runat="server">
    
  </div>
                  
                <label id="ErrMsg" runat="server" class="text-danger"></label><br />
                <asp:Button text="  Edit  " class="btn btn-warning" runat="server" ID="EditBtn" OnClick="EditBtn_Click"/>
                <asp:Button text="  Save  " class="btn btn-success" runat="server" ID="SaveBtn" OnClick="SaveBtn_Click"/>
                <asp:Button text="Delete" class="btn btn-danger" runat="server" ID="DeleteBtn" OnClick="DeleteBtn_Click"/>

            </div>
            <div class="col-md-8">
                <asp:GridView runat="server" class="table table-hover" ID="SeatGV" AutoGenerateSelectButton="True" OnSelectedIndexChanged="SeatGV_SelectedIndexChanged" >

               </asp:GridView>
            </div>

        </div>
    </div>
</asp:Content>
