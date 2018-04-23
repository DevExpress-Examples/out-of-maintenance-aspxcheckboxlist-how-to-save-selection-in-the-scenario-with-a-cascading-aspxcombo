<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function onSelectedIndexChanged(s, e) {
            var SelectedItems = s.GetSelectedItems();
            var str = "SaveSelections";
            for (var i = 0; i < SelectedItems.length ; i++) 
                str = str + "|" + SelectedItems[i].index;
            panel.PerformCallback(str);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dx:ASPxCallbackPanel ID="ASPxCallbackPanel1" runat="server" Width="200px" ClientInstanceName="panel" OnCallback="ASPxCallbackPanel1_Callback">
                <PanelCollection>
                    <dx:PanelContent>
                        <dx:ASPxComboBox ID="ASPxComboBox1" runat="server" ValueType="System.String">
                            <ClientSideEvents SelectedIndexChanged="function (s, e) { panel.PerformCallback(); }" />
                            <Items>
                                <dx:ListEditItem Value="A" Text="List A" Selected="true" />
                                <dx:ListEditItem Value="B" Text="List B" />
                            </Items>
                        </dx:ASPxComboBox>
                        <dx:ASPxCheckBoxList ID="ASPxCheckBoxList1" runat="server" OnDataBinding="ASPxCheckBoxList1_DataBinding">
                            <ClientSideEvents SelectedIndexChanged="onSelectedIndexChanged" />
                        </dx:ASPxCheckBoxList>
                        <dx:ASPxHyperLink ID="ASPxHyperLink1" runat="server" Text="submit">
                            <ClientSideEvents Click="function (s, e) { panel.PerformCallback(); }" />
                        </dx:ASPxHyperLink>
                    </dx:PanelContent>
                </PanelCollection>
            </dx:ASPxCallbackPanel>
        </div>
    </form>
</body>
</html>