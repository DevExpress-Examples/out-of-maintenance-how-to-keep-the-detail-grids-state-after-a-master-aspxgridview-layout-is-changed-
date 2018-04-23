using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxGridView;

public partial class Default : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
       if (!IsPostBack)
            Session.Clear();
    }
    protected void DetailGrid_BeforePerformDataSelect(object sender, EventArgs e)
    {        
        Session["CategoryID"] = ((ASPxGridView)sender).GetMasterRowKeyValue();
    }

    protected void DetailGrid_ClientLayout(object sender, DevExpress.Web.ASPxClasses.ASPxClientLayoutArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        string key = grid.GetMasterRowKeyValue().ToString();
        if (e.LayoutMode == DevExpress.Web.ASPxClasses.ClientLayoutMode.Loading && Session["DetailGrid"+key] != null )
        {
            e.LayoutData = (string)Session["DetailGrid"+key];
        }
        else
        {
            Session["DetailGrid"+key] = e.LayoutData;
        }

    }

    protected void MasterGrid_DetailRowExpandedChanged(object sender, ASPxGridViewDetailRowEventArgs e)
    {
        if (e.Expanded == false)
        {
            string key = MasterGrid.GetRowValues(e.VisibleIndex, MasterGrid.KeyFieldName).ToString();
            Session["DetailGrid" + key] = null;  
        }
    }
}