' Developer Express Code Central Example:
' How to keep a detail ASPxGridView state after a master ASPxGridView was grouped, sorted or filtered
' 
' By default, the master grid doesn't save its detail grid's state after
' operations with data, such as sorting, grouping, filtering. Thus, it should be
' saved manually. To implement this feature, handle the ClientLayout event
' (http://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridViewASPxGridView_ClientLayouttopic)
' and store layout data on the server side. In this example unique session values
' are used. A corresponding session value is cleared if a row is collapsed.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E4604


Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web

Partial Public Class [Default]
	Inherits System.Web.UI.Page
	Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
	   If (Not IsPostBack) Then
			Session.Clear()
	   End If
	End Sub
	Protected Sub DetailGrid_BeforePerformDataSelect(ByVal sender As Object, ByVal e As EventArgs)
		Session("CategoryID") = (CType(sender, ASPxGridView)).GetMasterRowKeyValue()
	End Sub

	Protected Sub DetailGrid_ClientLayout(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxClientLayoutArgs)
		Dim grid As ASPxGridView = TryCast(sender, ASPxGridView)
		Dim key As String = grid.GetMasterRowKeyValue().ToString()
		If e.LayoutMode = DevExpress.Web.ClientLayoutMode.Loading AndAlso Session("DetailGrid" & key) IsNot Nothing Then
			e.LayoutData = CStr(Session("DetailGrid" & key))
		Else
			Session("DetailGrid" & key) = e.LayoutData
		End If

	End Sub

	Protected Sub MasterGrid_DetailRowExpandedChanged(ByVal sender As Object, ByVal e As ASPxGridViewDetailRowEventArgs)
		If e.Expanded = False Then
			Dim key As String = MasterGrid.GetRowValues(e.VisibleIndex, MasterGrid.KeyFieldName).ToString()
			Session("DetailGrid" & key) = Nothing
		End If
	End Sub
End Class