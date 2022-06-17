<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaymentUI.aspx.cs" Inherits="DCBMS.UI.PaymentUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" runat="server" media="screen" href="~/css/styles.css" />
    <link href="custom.css" rel="stylesheet" />
    <div class="content">
        <div class="row">
        <div class="col-md-8 col-md-offset-2">
          <div class="panel panel-default">
            <div class="panel-heading">
                <h4>Payment</h4>
            </div>
            <div class="panel-body">
                        <label class="col-md-4 control-label">Mobile No</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txt_mobile" runat="server" class="form-control"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                  ErrorMessage="Mobile Number cannot be blank" ValidationExpression="[0-10]{11}" ControlToValidate="txt_mobile"
                                  ForeColor="Red"></asp:RequiredFieldValidator>
                         </div>
                <asp:Label ID="lbl_message" runat="server" Text=""></asp:Label>
                   
                          <div class="col-md-2 col-md-offset-9 mt-5">
                             <asp:Button ID="btn_search" runat="server" Text="Search" class="btn btn-success" OnClick="btn_search_Click" />
                          </div>

               
            </div>

              <div class="panel-body">

                    <asp:GridView ID="gv" runat="server" AutoGenerateColumns="false">



                         <Columns>
                            <asp:TemplateField HeaderText = "SL" ItemStyle-Width="100">
                                <ItemTemplate>
                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="PatientName" HeaderText="Patient Name" ItemStyle-Width="100" SortExpression="Pname" />

                            <asp:BoundField DataField="MobileNo" HeaderText="Mobile No" ItemStyle-Width="100" SortExpression="mobile" />
                            <asp:BoundField DataField="TestName" HeaderText="Test" ItemStyle-Width="150" SortExpression="test" />
                            <asp:BoundField DataField="Test_Fee" HeaderText="Fee" ItemStyle-Width="150" SortExpression="fee" />
                            <asp:BoundField DataField="PaymentStatus" HeaderText="Payment Status" ItemStyle-Width="150" SortExpression="status" />
   
</Columns>


                    </asp:GridView>
                  <br />
                  <div>
                      <label class="col-md-2 control-label">Totall Taka BDT.=</label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txt_totall" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                  ErrorMessage="Totall cannot be blank" ValidationExpression="[0-10]{11}" ControlToValidate="txt_mobile"
                                  ForeColor="Red"></asp:RequiredFieldValidator>
                         </div>
                      <asp:Label ID="lbl_totall" runat="server" Text=""></asp:Label>
                  </div>
                  

                    </div>

               <div class="panel-body">
                        <label class="col-md-4 control-label">Amount</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txt_amount" runat="server" class="form-control"></asp:TextBox>
                         </div>
                   
                          <div class="col-md-2 col-md-offset-9 mt-5">
                             <asp:Button ID="btn_pay" runat="server" Text="Pay" class="btn btn-primary" OnClick="btn_pay_Click" />
                          </div>
               
            </div>
            <div class="panel-footer">
                

            </div>
          </div>
            <div class="panel panel-default">
            <div class="panel-heading">
                <div>
                    <asp:Label ID="lbl_payMentMessage" runat="server" Text=""></asp:Label>
                </div>
                <div class="panel-body">
                    <asp:GridView ID="gv2" runat="server"></asp:GridView>
                    </div>
                </div>
          </div>
        </div>
   
        
    </div>
    </div>
</asp:Content>
