<%@ Page Title="" Language="C#" MasterPageFile="~/View/Operator/OperatorMaster.Master" AutoEventWireup="true" CodeBehind="Billing.aspx.cs" Inherits="OnlineWorker.View.Operator.Billing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function PrintPanel() {
            var PGrid = document.getElementById('<%=BillGV.ClientID %>');
        PGrid.border = 0;
        var Pwin = window.open('', 'PrintGrid', 'left=100,top=100,width=1024,height=768,tollbar=0,scrollbars=1,status=0,resizable=1');
        Pwin.document.write(PGrid.outerHTML);
        Pwin.document.close();
        Pwin.focus();
        Pwin.print();
        Pwin.close();
         
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
                <div class="row">
                    <div class="col">
                        <br />
               <div class="mb-3">
               <label for="exampleInputEmail1" class="form-label">Name</label>
               <input type="text" class="form-control" id="WorkerNameTb" runat="server" > 
               </div>

                <div class="mb-3">
               <label for="exampleInputEmail1" class="form-label">Per hour pay</label>
               <input type="text" class="form-control" id="WorkerPriceTb" runat="server" > 
               </div>

                <div class="mb-3">
               <label for="exampleInputEmail1" class="form-label">Quantity of hours</label>
               <input type="text" class="form-control" id="WorkerQtyTb" runat="server" > 
               </div>
                    </div>
                    <div class="col">
                        <img src="../../Asset/Images/check_dollar_100px.png"/><br /><br /><br /><br />
                         <label id="ErrMsg" runat="server" class="text-danger"></label><br />
                        <asp:Button text="Add To Bill  " class="btn btn-warning" runat="server" ID="AddToBillBtn" OnClick="AddToBillBtn_Click" />
                          <asp:Button text="Reset" class="btn btn-danger" runat="server" ID="ResetBtn" OnClick="ResetBtn_Click"/>
                    </div>
                </div>

                <div class="row">
                    <div class="col">
                         <asp:GridView runat="server" class="table table-hover" ID="WorkerGV" AutoGenerateSelectButton="True" OnSelectedIndexChanged="WorkerGV_SelectedIndexChanged">

                         </asp:GridView>
                    </div>
                </div>
            </div>

             <div class="col-md-7 ">
                 <div class="row">
                    <div class="col-3"> </div>
                    <div class="col"> <h1 class="text-warning pl-2">Billing</h1></div>
                 </div>
                 <div class="row">
                     <asp:GridView ID="BillGV" runat="server" class="table" CellPadding="4" ForeColor="#333333" GridLines="None">
                         <AlternatingRowStyle BackColor="White" />
                         <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                         <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                         <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                         <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                         <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                         <SortedAscendingCellStyle BackColor="#FDF5AC" />
                         <SortedAscendingHeaderStyle BackColor="#4D0000" />
                         <SortedDescendingCellStyle BackColor="#FCF6C0" />
                         <SortedDescendingHeaderStyle BackColor="#820000" />

                     </asp:GridView>
                 </div>
                 <div class="row">
                     <div class="col"></div>
                     <div class="col"><h3 id="GrdTotTb" class="text-danger" runat="server"></h3></div>
                     <div class="col d-grid">  <asp:Button text="Print Bill" class="btn btn-warning btn-block text-white"  OnClientClick="PrintPanel()" ID="PrintBtn"  runat="server" OnClick="PrintBtn_Click"/></div>
                 </div>
             </div>
        </div>
    </div>
</asp:Content>
