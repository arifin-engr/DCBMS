<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestEntryUI.aspx.cs" Inherits="DCBMS.UI.TestEntryUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="custom.css" rel="stylesheet" />
    <link href="Content/Site.css" rel="stylesheet" />
   
     <div class="content">

      
        <div class="row">
            <div class="col-md-8 col-md-offset-2">
                <div class="panel panel-default">
            <div class="panel-heading">
                <h4>Test Request Entry</h4>
            </div>
            <div class="panel-body">

                        <label class="col-md-4 control-label">Name Of the Patient</label>
                        <div class="col-md-8">
                           <asp:TextBox ID="txt_PatientName" runat="server" class="form-control"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Patient Name cannot be blank" ControlToValidate="txt_PatientName" ForeColor="Red"></asp:RequiredFieldValidator>
                         </div>

                        <label class="col-md-4 control-label mt-5">Date Of Birth</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txt_dob" runat="server" class="form-control mt-5"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="DOB cannot be blank" ControlToValidate="txt_dob" ForeColor="Red"></asp:RequiredFieldValidator>
                            
                         </div>

                        <label class="col-md-4 control-label mt-5">Mobile No</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txt_mobile" runat="server" class="form-control mt-5"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="MobileNo. cannot be blank" ControlToValidate="txt_mobile" ForeColor="Red"></asp:RequiredFieldValidator>
                         </div>

                        <label class="col-md-4 control-label mt-5">Select Test</label>
                        <div class="col-md-8 mt-5">
                            <asp:DropDownList ID="ddl_test" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_test_SelectedIndexChanged"></asp:DropDownList>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Test not selected" ControlToValidate="ddl_test" ForeColor="Red"></asp:RequiredFieldValidator>
                         </div>

                        <label class="col-md-2 col-md-offset-2 control-label mt-5">Fee</label>
                        <div class="col-md-2">
                            <asp:TextBox ID="txt_Fee" runat="server" AutoPostBack="true" ReadOnly="true" class="form-control mt-5"></asp:TextBox>
                         </div>
                            

                   
                          <div class="col-md-2 col-md-offset-9 mt-5">
                             <asp:Button ID="btn_submit" runat="server" Text="Add" class="btn btn-primary" OnClick="btn_submit_Click" />
                          </div>
               
            </div>
            <div class="panel-footer">
                <asp:Label ID="lbl_operationMessase" runat="server" Text=""></asp:Label>

            </div>
          </div>
                 <div class="panel panel-default">
            
                <div class="panel-body">
                    <asp:GridView ID="gv" runat="server" >
                       <Columns>
    <asp:TemplateField HeaderText = "SL" ItemStyle-Width="100">
        <ItemTemplate>
            <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
        </ItemTemplate>
    </asp:TemplateField>

                       <%-- <asp:BoundField DataField="TestName" HeaderText="Test Name" SortExpression="testname" />
                        <asp:BoundField DataField="fee" HeaderText="Fee" ItemStyle-Width="100" SortExpression="fee" />--%>
                       
   
</Columns>
                    </asp:GridView>
                    <asp:GridView ID="gv2" runat="server"></asp:GridView>
                    </div>
                
          </div>
                
            </div>
        </div>
         <div class="row">
             <div class="col-md-5 col-md-offset-6">
                 <label class=" control-label col-md-2 mt-5">Totall</label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txt_totall" runat="server" AutoPostBack="true" ReadOnly="true" class="form-control mt-5"></asp:TextBox>
                         </div>
                 <asp:Button ID="btn_Save" runat="server" class="btn btn-success mt-5" Text="Save" OnClick="btn_Save_Click" />
             </div>
             

         </div>
    </div>
    
 <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js" type="text/javascript"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js" type="text/javascript"></script>
    <link href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $("[id*=txt_dob]").datepicker({
                
                showOn: 'button',
                buttonImageOnly: true,
                buttonImage: 'image/calendar.png',
                
            });
        });
    </script>
    

</asp:Content>
