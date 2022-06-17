<%@ Page Title="TestTypeUI" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestTypeUI.aspx.cs" Inherits="DCBMS.UI.TestTypeUI" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" runat="server" media="screen" href="~/css/styles.css" />
    <link href="custom.css" rel="stylesheet" />
    <div class="content">
        <div class="row">
        <div class="col-md-4 col-md-offset-2">
          <div class="panel panel-default">
            <div class="panel-heading">
                <h4>Test Type Setup</h4>
            </div>
            <div class="panel-body">
                        <label class="col-md-4 control-label">Type Name</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txt_TypeName" runat="server" class="form-control"></asp:TextBox>
                            
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Type Name cannot be blank" ControlToValidate="txt_TypeName" ForeColor="Red"></asp:RequiredFieldValidator>
                         </div>
                   
                          <div class="col-md-2 col-md-offset-9 mt-5">
                             <asp:Button ID="btn_submit" runat="server" Text="Save" class="btn btn-default" OnClick="btn_submit_Click"/>
                          </div>
               
            </div>
            <div class="panel-footer">
                <asp:Label ID="lbl_OprartionMessage" runat="server" Text="Label"></asp:Label>

            </div>
          </div>
            <div class="panel panel-default">
            <div class="panel-heading">
                <div class="panel-body">
                    <asp:GridView ID="gv" runat="server" AutoGenerateColumns="false">

                        <Columns>
    <asp:TemplateField HeaderText = "SL" ItemStyle-Width="100">
        <ItemTemplate>
                                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
        </ItemTemplate>
    </asp:TemplateField>
                             <asp:BoundField DataField="TypeName" HeaderText="Type Name" ItemStyle-Width="100" SortExpression="type" />
   
</Columns>

                    </asp:GridView>
                    </div>
                </div>
          </div>
        </div>
   
        
    </div>
    </div>
    


  
</asp:Content>
