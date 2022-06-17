<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FindReportByTypeUI.aspx.cs" Inherits="DCBMS.UI.FindReportByTypeUI" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <link rel="stylesheet" runat="server" media="screen" href="~/css/styles.css" />
    <link href="custom.css" rel="stylesheet" />
    <div class="content">
        <div class="row">
        <div class="col-md-8 col-md-offset-2">
          <div class="panel panel-default">
            <div class="panel-heading">
                <h4> Type Wise Report</h4>
            </div>
            <div class="panel-body">
                        <label class="col-md-4 control-label mt-5"> From Date </label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txt_fromDate" runat="server" class="form-control mt-5"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Date cannot be blank" ControlToValidate="txt_fromDate" ForeColor="Red"></asp:RequiredFieldValidator>
                            
                         </div>

                        <label class="col-md-4 control-label mt-5"> To Date </label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txt_todate" runat="server" class="form-control mt-5"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Date cannot be blank" ControlToValidate="txt_todate" ForeColor="Red"></asp:RequiredFieldValidator>
                            
                         </div>
                   
                          <div class="col-md-2 col-md-offset-9 mt-5">
                             <asp:Button ID="btn_search" runat="server" Text="Show" class="btn btn-success" OnClick="btn_search_Click"   />
                          </div>
               
            </div>

              
                    </div>

            <div class="panel panel-default">
            <div class="panel-heading">
                <div class="panel-body">
                    <asp:GridView ID="gv2" runat="server" AutoGenerateColumns="false">

                        <Columns>
    <asp:TemplateField HeaderText = "SL" ItemStyle-Width="100">
        <ItemTemplate>
            <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
        </ItemTemplate>
    </asp:TemplateField>
                             <asp:BoundField DataField="TypeName" HeaderText="Test Type Name" ItemStyle-Width="150" SortExpression="testname" />

                        <asp:BoundField DataField="TotalTestTypeWise" HeaderText="Totall no of Test" ItemStyle-Width="150" SortExpression="fee" />
                        <asp:BoundField DataField="TotallAmount" HeaderText="Totall Amount" ItemStyle-Width="150" SortExpression="type" />
   
</Columns>

                    </asp:GridView>
                    </div>
                </div>
                <br />
                  <h3>
                      <asp:Label ID="lbl_totall" runat="server" Text="Totall"></asp:Label>
                      <asp:TextBox ID="txt_totall" runat="server" ReadOnly="true"></asp:TextBox>
                  </h3>
                <p>
                    <asp:Button ID="btn_Print" runat="server" Text="Print" class="btn btn-danger" OnClick="btn_Print_Click" />
                </p>
                <CR:CrystalReportViewer ID="_crv" runat="server" AutoDataBind="true" />
          </div>
        </div>
   
        
    </div>
    </div>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js" type="text/javascript"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js" type="text/javascript"></script>
    <link href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $("[id*=txt_fromDate]").datepicker({
                
                showOn: 'button',
                buttonImageOnly: true,
                buttonImage: 'image/calendar.png',
                
            });
        });
        $(function () {
            $("[id*=txt_todate]").datepicker({
                
                showOn: 'button',
                buttonImageOnly: true,
                buttonImage: 'image/calendar.png',
                
            });
        });
    </script>
</asp:Content>
