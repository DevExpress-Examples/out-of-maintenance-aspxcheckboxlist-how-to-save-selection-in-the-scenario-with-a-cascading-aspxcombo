using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack)
            Session.Clear();
        ASPxCheckBoxList1.DataBind();
    }
    protected void ASPxCallbackPanel1_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e) {
        string[] parameters = e.Parameter.Split('|');
        if (parameters[0] == "SaveSelections") {
            Session["Combo" + ASPxComboBox1.Value.ToString()] = parameters;
        }
        ASPxCheckBoxList1.DataBind();
    }
    protected void ASPxCheckBoxList1_DataBinding(object sender, EventArgs e) {
        ASPxCheckBoxList1.Items.Clear();
        string comboValue = ASPxComboBox1.Value.ToString();
        if (comboValue == "A") {
            CreateItemsA(comboValue);
        } else {
            CreateItemsB(comboValue);
        }
        if (Session["Combo" + comboValue] != null) {
            string[] strArray = (string[])Session["Combo" + comboValue];
            for (int i = 1; i < strArray.Length; i++) {
                ASPxCheckBoxList1.Items[Convert.ToInt32(strArray[i])].Selected = true;
            }
        }
    }
    protected void CreateItemsA(string str) {
        ASPxCheckBoxList1.Items.Add(str + "1");
        ASPxCheckBoxList1.Items.Add(str + "2");
    }
    protected void CreateItemsB(string str) {
        ASPxCheckBoxList1.Items.Add(str + "1");
        ASPxCheckBoxList1.Items.Add(str + "2");
        ASPxCheckBoxList1.Items.Add(str + "3");
    }
}
