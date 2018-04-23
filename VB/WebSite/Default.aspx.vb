Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web.ASPxGridView

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

	Protected Sub DetailGrid_ClientLayout(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxClasses.ASPxClientLayoutArgs)
		Dim grid As ASPxGridView = TryCast(sender, ASPxGridView)
		Dim key As String = grid.GetMasterRowKeyValue().ToString()
		If e.LayoutMode = DevExpress.Web.ASPxClasses.ClientLayoutMode.Loading AndAlso Session("DetailGrid" & key) IsNot Nothing Then
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