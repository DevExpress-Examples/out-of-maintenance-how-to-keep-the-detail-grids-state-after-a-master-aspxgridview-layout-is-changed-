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
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.
<Assembly: AssemblyTitle("MasterDetailSort")>
<Assembly: AssemblyDescription("")>
<Assembly: AssemblyConfiguration("")>
<Assembly: AssemblyCompany("")>
<Assembly: AssemblyProduct("MasterDetailSort")>
<Assembly: AssemblyCopyright("Copyright ? 2013")>
<Assembly: AssemblyTrademark("")>
<Assembly: AssemblyCulture("")>

' Setting ComVisible to false makes the types in this assembly not visible 
' to COM components.  If you need to access a type in this assembly from 
' COM, set the ComVisible attribute to true on that type.
<Assembly: ComVisible(False)>

' The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("d0e8e12d-69f1-423e-95c9-bb5845f2b969")>

' Version information for an assembly consists of the following four values:
'
'      Major Version
'      Minor Version 
'      Build Number
'      Revision
'
' You can specify all the values or you can default the Revision and Build Numbers 
' by using the '*' as shown below:
<Assembly: AssemblyVersion("1.0.0.0")>
<Assembly: AssemblyFileVersion("1.0.0.0")>