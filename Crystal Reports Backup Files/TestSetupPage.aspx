<%@ Page Title="TestSetupPage" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestSetupPage.aspx.cs" Inherits="DCBMS.UI.TestSetupPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" runat="server" media="screen" href="~/css/styles.css" />
    <link href="custom.css" rel="stylesheet" />

    <div class="content">

      
        <div class="row">
            <div class="col-md-6 col-md-offset-2">
                <div class="panel panel-default">
            <div class="panel-heading">
                <h4>Test Setup</h4>
            </div>
            <div class="panel-body">

                        <label class="col-md-4 control-label">Test Name</label>
                        <div class="col-md-8">
                           <asp:TextBox ID="txt_TestName" runat="server" class="form-control"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Test Name cannot be blank" ControlToValidate="txt_TestName" ForeColor="Red"></asp:RequiredFieldValidator>
                         </div>

                        <label class="col-md-4 control-label mt-5">Fee</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txt_fee" runat="server" class="form-control mt-5"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Test Fee cannot be blank" ControlToValidate="txt_fee" ForeColor="Red"></asp:RequiredFieldValidator>
                         </div>

                        <label class="col-md-4 control-label mt-5">Test Type</label>
                        <div class="col-md-8 mt-5">



                            <asp:DropDownList ID="ddl_testType" runat="server">
                                
                            </asp:DropDownList>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Test Type Not selected" ControlToValidate="ddl_testType" ForeColor="Red"></asp:RequiredFieldValidator>
                         </div>
                            
                   
                          <div class="col-md-2 col-md-offset-9 mt-5">
                             <asp:Button ID="btn_submit" runat="server" Text="Save" class="btn btn-default" OnClick="btn_submit_Click"/>
                          </div>
               
            </div>
            <div class="panel-footer">
                
                <asp:Label ID="lbl_oprationMessage" runat="server" Text=""></asp:Label>
            </div>
          </div>
                 <div class="panel panel-default">
            <div class="panel-heading">
                <div class="panel-body">
                    <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False">

                         <Columns>
    <asp:TemplateField HeaderText = "SL" ItemStyle-Width="100">
        <ItemTemplate>
            <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
        </ItemTemplate>
    </asp:TemplateField>
                             <asp:BoundField DataField="TestName" HeaderText="Test Name" SortExpression="testname" />

                        <asp:BoundField DataField="fee" HeaderText="Fee" ItemStyle-Width="100" SortExpression="fee" />
                        <asp:BoundField DataField="TypeName" HeaderText="Test Type" ItemStyle-Width="150" SortExpression="type" />
   
</Columns>

                    </asp:GridView>
                   
                    </div>
                </div>
          </div>
            </div>
        </div>
    </div>
</asp:Content>
