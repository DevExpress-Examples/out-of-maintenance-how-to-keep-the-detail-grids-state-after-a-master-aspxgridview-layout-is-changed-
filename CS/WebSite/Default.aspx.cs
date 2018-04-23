// Developer Express Code Central Example:
// How to keep a detail ASPxGridView state after a master ASPxGridView was grouped, sorted or filtered
// 
// By default, the master grid doesn't save its detail grid's state after
// operations with data, such as sorting, grouping, filtering. Thus, it should be
// saved manually. To implement this feature, handle the ClientLayout event
// (http://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridViewASPxGridView_ClientLayouttopic)
// and store layout data on the server side. In this example unique session values
// are used. A corresponding session value is cleared if a row is collapsed.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E4604

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;

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

    protected void DetailGrid_ClientLayout(object sender, DevExpress.Web.ASPxClientLayoutArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        string key = grid.GetMasterRowKeyValue().ToString();
        if (e.LayoutMode == DevExpress.Web.ClientLayoutMode.Loading && Session["DetailGrid"+key] != null )
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