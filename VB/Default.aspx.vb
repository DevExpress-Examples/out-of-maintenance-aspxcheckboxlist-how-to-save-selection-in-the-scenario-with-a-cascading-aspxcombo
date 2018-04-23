Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            Session.Clear()
        End If
        ASPxCheckBoxList1.DataBind()
    End Sub
    Protected Sub ASPxCallbackPanel1_Callback(ByVal sender As Object, ByVal e As DevExpress.Web.CallbackEventArgsBase)
        Dim parameters() As String = e.Parameter.Split("|"c)
        If parameters(0) = "SaveSelections" Then
            Session("Combo" & ASPxComboBox1.Value.ToString()) = parameters
        End If
        ASPxCheckBoxList1.DataBind()
    End Sub
    Protected Sub ASPxCheckBoxList1_DataBinding(ByVal sender As Object, ByVal e As EventArgs)
        ASPxCheckBoxList1.Items.Clear()
        Dim comboValue As String = ASPxComboBox1.Value.ToString()
        If comboValue = "A" Then
            CreateItemsA(comboValue)
        Else
            CreateItemsB(comboValue)
        End If
        If Session("Combo" & comboValue) IsNot Nothing Then
            Dim strArray() As String = DirectCast(Session("Combo" & comboValue), String())
            For i As Integer = 1 To strArray.Length - 1
                ASPxCheckBoxList1.Items(Convert.ToInt32(strArray(i))).Selected = True
            Next i
        End If
    End Sub
    Protected Sub CreateItemsA(ByVal str As String)
        ASPxCheckBoxList1.Items.Add(str & "1")
        ASPxCheckBoxList1.Items.Add(str & "2")
    End Sub
    Protected Sub CreateItemsB(ByVal str As String)
        ASPxCheckBoxList1.Items.Add(str & "1")
        ASPxCheckBoxList1.Items.Add(str & "2")
        ASPxCheckBoxList1.Items.Add(str & "3")
    End Sub
End Class
