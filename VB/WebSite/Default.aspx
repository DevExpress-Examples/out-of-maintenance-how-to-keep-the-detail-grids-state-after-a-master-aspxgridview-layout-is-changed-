<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		<dx:ASPxGridView ID="MasterGrid" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1"
			KeyFieldName="CategoryID" OnDetailRowExpandedChanged="MasterGrid_DetailRowExpandedChanged">
			<Columns>
				<dx:GridViewCommandColumn VisibleIndex="0">
					<ClearFilterButton Visible="True">
					</ClearFilterButton>
				</dx:GridViewCommandColumn>
				<dx:GridViewDataTextColumn FieldName="CategoryID" ReadOnly="True" 
					VisibleIndex="1">
					<EditFormSettings Visible="False" />
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="CategoryName" VisibleIndex="2">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="3">
				</dx:GridViewDataTextColumn>
			</Columns>
			<Settings ShowFilterRow="True" ShowGroupPanel="True" />
			<SettingsDetail ShowDetailRow="True" />
			<Templates>
				<DetailRow>
					<dx:ASPxGridView ID="DetailGrid" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2"
						KeyFieldName="ProductID" OnBeforePerformDataSelect="DetailGrid_BeforePerformDataSelect"
						OnClientLayout="DetailGrid_ClientLayout">
						<Columns>
							<dx:GridViewDataTextColumn FieldName="ProductID" ReadOnly="True" VisibleIndex="0">
								<EditFormSettings Visible="False" />
							</dx:GridViewDataTextColumn>
							<dx:GridViewDataTextColumn FieldName="ProductName" VisibleIndex="1">
							</dx:GridViewDataTextColumn>
							<dx:GridViewDataTextColumn FieldName="CategoryID" VisibleIndex="2">
							</dx:GridViewDataTextColumn>
							<dx:GridViewDataTextColumn FieldName="UnitPrice" VisibleIndex="3">
							</dx:GridViewDataTextColumn>
						</Columns>
					</dx:ASPxGridView>
					<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
						SelectCommand="SELECT [ProductID], [ProductName], [CategoryID], [UnitPrice] FROM [Alphabetical list of products] WHERE ([CategoryID] = @CategoryID)">
						<SelectParameters>
							<asp:SessionParameter Name="CategoryID" SessionField="CategoryID" Type="Int32" />
						</SelectParameters>
					</asp:SqlDataSource>
				</DetailRow>
			</Templates>
		</dx:ASPxGridView>
		<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
			SelectCommand="SELECT [CategoryID], [CategoryName], [Description] FROM [Categories]">
		</asp:SqlDataSource>
	</div>
	</form>
</body>
</html>