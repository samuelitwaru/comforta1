/*!   GeneXus .NET 18_0_6-177934 on 11/1/2023 22:38:46.38
*/
gx.evt.autoSkip=!1;gx.define("gxqueryviewerforsd",!1,function(){var t,n;this.ServerClass="gxqueryviewerforsd";this.PackageName="QueryViewer.Services";this.ServerFullClass="gxqueryviewerforsd.aspx";this.setObjectType("web");this.setOnAjaxSessionTimeout("Warn");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.e13052_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e14052_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXLastCtrlId=0;this.QUERYVIEWER1Container=gx.uc.getNew(this,2,0,"QueryViewer","QUERYVIEWER1Container","Queryviewer1","QUERYVIEWER1");n=this.QUERYVIEWER1Container;n.setProp("Enabled","Enabled",!0,"boolean");n.setProp("ObjectId","Objectid","0","str");n.setProp("ObjectType","Objecttype","","str");n.setProp("QueryInfo","Queryinfo","","char");n.setDynProp("IsExternalQuery","Isexternalquery",!1,"boolean");n.setProp("ExternalQueryResult","Externalqueryresult","","char");n.setProp("ObjectInfo","Objectinfo","","char");n.addV2CFunction("AV74Elements","vELEMENTS","SetAxes");n.addC2VFunction(function(n){n.ParentObject.AV74Elements=n.GetAxes();gx.fn.setControlValue("vELEMENTS",n.ParentObject.AV74Elements)});n.setProp("AllowElementsOrderChange","Allowchangeaxesorder",!1,"bool");n.addV2CFunction("AV28Parameters","vPARAMETERS","SetParameters");n.addC2VFunction(function(n){n.ParentObject.AV28Parameters=n.GetParameters();gx.fn.setControlValue("vPARAMETERS",n.ParentObject.AV28Parameters)});n.setDynProp("ObjectName","Objectname","","str");n.setProp("Object","Objectcall","","str");n.setProp("Class","Class","QueryViewer","str");n.setProp("ShrinkToFit","Shrinktofit",!1,"boolean");n.setDynProp("AutoResize","Autoresize",!1,"bool");n.setDynProp("AutoResizeType","Autoresizetype","","char");n.setDynProp("Width","Width","100%","str");n.setDynProp("Height","Height","100%","str");n.setProp("Axes Selectors","Showaxesselectors","","char");n.setProp("FontFamily","Fontfamily","","char");n.setProp("FontSize","Fontsize","","int");n.setProp("FontColor","Fontcolor","","int");n.setDynProp("AutoRefreshGroup","Autorefreshgroup","","str");n.setDynProp("DisableColumnSort","Disablecolumnsort",!1,"bool");n.setDynProp("AllowSelection","Allowselection",!1,"bool");n.setDynProp("RememberLayout","Rememberlayout",!1,"bool");n.setDynProp("ExportToXML","Exporttoxml",!1,"bool");n.setDynProp("ExportToHTML","Exporttohtml",!0,"bool");n.setDynProp("ExportToXLS","Exporttoxls",!1,"bool");n.setDynProp("ExportToXLSX","Exporttoxlsx",!0,"bool");n.setDynProp("ExportToPDF","Exporttopdf",!0,"bool");n.setDynProp("Type","Type","Default","str");n.setDynProp("Title","Title","","str");n.setDynProp("ShowValues","Showvalues",!0,"bool");n.setDynProp("ShowDataAs","Showdataas","Values","str");n.setDynProp("Orientation","Orientation","Horizontal","str");n.setDynProp("IncludeTrend","Includetrend",!1,"bool");n.setDynProp("TrendPeriod","Trendperiod","","char");n.setDynProp("IncludeSparkline","Includesparkline",!1,"bool");n.setDynProp("IncludeMaxAndMin","Includemaxandmin",!1,"bool");n.setProp("MapLibrary","Maplibrary","ECharts","str");n.setDynProp("MapType","Maptype","Choropleth","str");n.setDynProp("Region","Region","World","str");n.setDynProp("Country","Country","","char");n.setDynProp("Continent","Continent","","char");n.setDynProp("ChartType","Charttype","Column","str");n.setDynProp("PlotSeries","Plotseries","InTheSameChart","str");n.setDynProp("XAxisLabels","Xaxislabels","Horizontally","str");n.setDynProp("XAxisIntersectionAtZero","Xaxisintersectionatzero",!1,"bool");n.setDynProp("XAxisTitle","Xaxistitle","","str");n.setDynProp("YAxisTitle","Yaxistitle","","str");n.setDynProp("Paging","Paging",!0,"bool");n.setDynProp("PageSize","Pagesize",20,"num");n.setProp("CurrentPage","Currentpage","","int");n.setDynProp("ShowDataLabelsIn","Showdatalabelsin","Columns","str");n.setDynProp("TotalForRows","Totalforrows","Yes","str");n.setDynProp("TotalForColumns","Totalforcolumns","Yes","str");n.setProp("ItemClickData","Itemclickdata","","str");n.setProp("ItemDoubleClickData","Itemdoubleclickdata","","str");n.setProp("DragAndDropData","Draganddropdata","","str");n.setProp("FilterChangedData","Filterchangeddata","","str");n.setProp("ItemExpandData","Itemexpanddata","","str");n.setProp("ItemCollapseData","Itemcollapsedata","","str");n.setProp("AppSettings","Appsettings","","char");n.setProp("AvoidAutomaticShow","Avoidautomaticshow",!1,"boolean");n.setProp("ExecuteShow","Executeshow",!1,"boolean");n.setProp("ServiceUrl","Serviceurl","","char");n.setProp("GenType","Gentype","net","str");n.setProp("TranslationType","Translationtype","RunTime","str");n.setProp("ApplicationNamespace","Applicationnamespace","QueryViewer.Services","str");n.setProp("ReturnSampleData","Returnsampledata",!1,"boolean");n.setDynProp("ParentPanel","Parentpanel","","char");n.setProp("DesignRenderOutputType","Designrenderoutputtype","","char");n.setProp("Visible","Visible",!0,"bool");n.setC2ShowFunction(function(n){n.show()});this.setUserControl(n);this.AV74Elements=[];this.Events={e13052_client:["ENTER",!0],e14052_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[],[{av:"AV28Parameters",fld:"vPARAMETERS",pic:""},{av:"AV74Elements",fld:"vELEMENTS",pic:""},{av:"this.QUERYVIEWER1Container.ObjectName",ctrl:"QUERYVIEWER1",prop:"ObjectName"},{av:"this.QUERYVIEWER1Container.Type",ctrl:"QUERYVIEWER1",prop:"Type"},{av:"this.QUERYVIEWER1Container.ChartType",ctrl:"QUERYVIEWER1",prop:"ChartType"},{av:"this.QUERYVIEWER1Container.Paging",ctrl:"QUERYVIEWER1",prop:"Paging"},{av:"this.QUERYVIEWER1Container.PageSize",ctrl:"QUERYVIEWER1",prop:"PageSize"},{av:"this.QUERYVIEWER1Container.PlotSeries",ctrl:"QUERYVIEWER1",prop:"PlotSeries"},{av:"this.QUERYVIEWER1Container.XAxisLabels",ctrl:"QUERYVIEWER1",prop:"XAxisLabels"},{av:"this.QUERYVIEWER1Container.XAxisIntersectionAtZero",ctrl:"QUERYVIEWER1",prop:"XAxisIntersectionAtZero"},{av:"this.QUERYVIEWER1Container.ShowValues",ctrl:"QUERYVIEWER1",prop:"ShowValues"},{av:"this.QUERYVIEWER1Container.ShowDataLabelsIn",ctrl:"QUERYVIEWER1",prop:"ShowDataLabelsIn"},{av:"this.QUERYVIEWER1Container.TotalForRows",ctrl:"QUERYVIEWER1",prop:"TotalForRows"},{av:"this.QUERYVIEWER1Container.TotalForColumns",ctrl:"QUERYVIEWER1",prop:"TotalForColumns"},{av:"this.QUERYVIEWER1Container.XAxisTitle",ctrl:"QUERYVIEWER1",prop:"XAxisTitle"},{av:"this.QUERYVIEWER1Container.YAxisTitle",ctrl:"QUERYVIEWER1",prop:"YAxisTitle"},{av:"this.QUERYVIEWER1Container.ShowDataAs",ctrl:"QUERYVIEWER1",prop:"ShowDataAs"},{av:"this.QUERYVIEWER1Container.IncludeTrend",ctrl:"QUERYVIEWER1",prop:"IncludeTrend"},{av:"this.QUERYVIEWER1Container.TrendPeriod",ctrl:"QUERYVIEWER1",prop:"TrendPeriod"},{av:"this.QUERYVIEWER1Container.IncludeSparkline",ctrl:"QUERYVIEWER1",prop:"IncludeSparkline"},{av:"this.QUERYVIEWER1Container.IncludeMaxAndMin",ctrl:"QUERYVIEWER1",prop:"IncludeMaxAndMin"},{av:"this.QUERYVIEWER1Container.Orientation",ctrl:"QUERYVIEWER1",prop:"Orientation"},{av:"this.QUERYVIEWER1Container.MapType",ctrl:"QUERYVIEWER1",prop:"MapType"},{av:"this.QUERYVIEWER1Container.Region",ctrl:"QUERYVIEWER1",prop:"Region"},{av:"this.QUERYVIEWER1Container.Continent",ctrl:"QUERYVIEWER1",prop:"Continent"},{av:"this.QUERYVIEWER1Container.Country",ctrl:"QUERYVIEWER1",prop:"Country"},{av:"this.QUERYVIEWER1Container.AutoRefreshGroup",ctrl:"QUERYVIEWER1",prop:"AutoRefreshGroup"},{av:"this.QUERYVIEWER1Container.Title",ctrl:"QUERYVIEWER1",prop:"Title"},{av:"this.QUERYVIEWER1Container.IsExternalQuery",ctrl:"QUERYVIEWER1",prop:"IsExternalQuery"},{av:"this.QUERYVIEWER1Container.DisableColumnSort",ctrl:"QUERYVIEWER1",prop:"DisableColumnSort"},{av:"this.QUERYVIEWER1Container.AllowSelection",ctrl:"QUERYVIEWER1",prop:"AllowSelection"},{av:"this.QUERYVIEWER1Container.ExportToHTML",ctrl:"QUERYVIEWER1",prop:"ExportToHTML"},{av:"this.QUERYVIEWER1Container.ExportToPDF",ctrl:"QUERYVIEWER1",prop:"ExportToPDF"},{av:"this.QUERYVIEWER1Container.ExportToXLS",ctrl:"QUERYVIEWER1",prop:"ExportToXLS"},{av:"this.QUERYVIEWER1Container.ExportToXLSX",ctrl:"QUERYVIEWER1",prop:"ExportToXLSX"},{av:"this.QUERYVIEWER1Container.ExportToXML",ctrl:"QUERYVIEWER1",prop:"ExportToXML"},{av:"this.QUERYVIEWER1Container.RememberLayout",ctrl:"QUERYVIEWER1",prop:"RememberLayout"},{av:"this.QUERYVIEWER1Container.AutoResize",ctrl:"QUERYVIEWER1",prop:"AutoResize"},{av:"this.QUERYVIEWER1Container.AutoResizeType",ctrl:"QUERYVIEWER1",prop:"AutoResizeType"},{av:"this.QUERYVIEWER1Container.Width",ctrl:"QUERYVIEWER1",prop:"Width"},{av:"this.QUERYVIEWER1Container.Height",ctrl:"QUERYVIEWER1",prop:"Height"},{av:"this.QUERYVIEWER1Container.ParentPanel",ctrl:"QUERYVIEWER1",prop:"ParentPanel"}]];this.EvtParms.ENTER=[[],[]];this.Initialize()});gx.wi(function(){gx.createParentObj(this.gxqueryviewerforsd)})