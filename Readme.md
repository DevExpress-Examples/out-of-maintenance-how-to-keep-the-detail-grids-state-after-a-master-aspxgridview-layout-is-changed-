<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128541538/15.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4604)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
<!-- default file list end -->
# How to keep the detail grids state after a master ASPxGridView layout is changed
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e4604/)**
<!-- run online end -->


<p>By default, the master grid doesn't save its detail grid's state after operations with data, such as sorting, grouping, filtering. Thus, it should be saved manually. </p><p>To implement this feature, handle the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridViewASPxGridView_ClientLayouttopic"><u>ClientLayout event</u></a> and store layout data on the server side. In this example unique session values are used. </p><p>A corresponding session value is cleared if a row is collapsed.</p>

<br/>


