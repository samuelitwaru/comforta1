gx.evt.autoSkip=!1;gx.define("productservicetypeww",!1,function(){var t,r,f,i,n,u,e;this.ServerClass="productservicetypeww";this.PackageName="GeneXus.Programs";this.ServerFullClass="productservicetypeww.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV24ManageFiltersExecutionStep=gx.fn.getIntegerValue("vMANAGEFILTERSEXECUTIONSTEP",gx.thousandSeparator);this.AV19ColumnsSelector=gx.fn.getControlValue("vCOLUMNSSELECTOR");this.AV42Pgmname=gx.fn.getControlValue("vPGMNAME");this.AV27TFProductServiceTypeName=gx.fn.getControlValue("vTFPRODUCTSERVICETYPENAME");this.AV28TFProductServiceTypeName_Sel=gx.fn.getControlValue("vTFPRODUCTSERVICETYPENAME_SEL");this.AV14OrderedDsc=gx.fn.getControlValue("vORDEREDDSC");this.AV37IsAuthorized_Update=gx.fn.getControlValue("vISAUTHORIZED_UPDATE");this.AV39IsAuthorized_Delete=gx.fn.getControlValue("vISAUTHORIZED_DELETE");this.AV40IsAuthorized_ProductServiceTypeName=gx.fn.getControlValue("vISAUTHORIZED_PRODUCTSERVICETYPENAME");this.AV11GridState=gx.fn.getControlValue("vGRIDSTATE");this.AV41IsAuthorized_Insert=gx.fn.getControlValue("vISAUTHORIZED_INSERT")};this.s172_client=function(){this.DDO_GRIDContainer.SortedStatus="-1:"+(this.AV14OrderedDsc?"DSC":"ASC")};this.s182_client=function(){this.AV16FilterFullText="";this.AV27TFProductServiceTypeName="";this.AV28TFProductServiceTypeName_Sel="";this.DDO_GRIDContainer.SelectedValue_set="";this.DDO_GRIDContainer.FilteredText_set=""};this.e121n2_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEPAGE",!1,null,!0,!0)};this.e131n2_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!1,null,!0,!0)};this.e141n2_client=function(){return this.executeServerEvent("DDO_GRID.ONOPTIONCLICKED",!1,null,!0,!0)};this.e151n2_client=function(){return this.executeServerEvent("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",!1,null,!0,!0)};this.e111n2_client=function(){return this.executeServerEvent("DDO_MANAGEFILTERS.ONOPTIONCLICKED",!1,null,!0,!0)};this.e161n2_client=function(){return this.executeServerEvent("'DOINSERT'",!1,null,!1,!1)};this.e201n2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e211n2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,24,25,26,27,28,29,30,32,33,34,35,36,38,39,40,41,42,43,45,46,47];this.GXLastCtrlId=47;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",37,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"productservicetypeww",[],!1,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px",gx.getMessage("GXM_newrow"),!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);r=this.GridContainer;r.addSingleLineEdit(71,38,"PRODUCTSERVICETYPEID","","","ProductServiceTypeId","int",0,"px",4,4,"end",null,[],71,"ProductServiceTypeId",!1,0,!1,!1,"Attribute",0,"WWColumn hidden-xs");r.addSingleLineEdit(72,39,"PRODUCTSERVICETYPENAME",gx.getMessage("Name"),"","ProductServiceTypeName","svchar",0,"px",40,40,"start",null,[],72,"ProductServiceTypeName",!0,0,!1,!1,"Attribute",0,"WWColumn");r.addSingleLineEdit("Update",40,"vUPDATE","",gx.getMessage("GXM_update"),"Update","char",0,"px",20,20,"start",null,[],"Update","Update",!0,0,!1,!1,"Attribute",0,"WWIconActionColumn");r.addSingleLineEdit("Delete",41,"vDELETE","",gx.getMessage("GX_BtnDelete"),"Delete","char",0,"px",20,20,"start",null,[],"Delete","Delete",!0,0,!1,!1,"Attribute",0,"WWIconActionColumn");this.GridContainer.emptyText=gx.getMessage("");this.setGrid(r);this.DDO_MANAGEFILTERSContainer=gx.uc.getNew(this,23,0,"BootstrapDropDownOptions","DDO_MANAGEFILTERSContainer","Ddo_managefilters","DDO_MANAGEFILTERS");f=this.DDO_MANAGEFILTERSContainer;f.setProp("Class","Class","","char");f.setProp("Enabled","Enabled",!0,"boolean");f.setProp("IconType","Icontype","FontIcon","str");f.setProp("Icon","Icon","fas fa-filter","str");f.setProp("Caption","Caption","","str");f.setProp("Tooltip","Tooltip","WWP_ManageFiltersTooltip","str");f.setProp("Cls","Cls","ManageFilters","str");f.setProp("ActiveEventKey","Activeeventkey","","char");f.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");f.setProp("DropDownOptionsType","Dropdownoptionstype","Regular","str");f.setProp("Visible","Visible",!0,"bool");f.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");f.addV2CFunction("AV22ManageFiltersData","vMANAGEFILTERSDATA","SetDropDownOptionsData");f.addC2VFunction(function(n){n.ParentObject.AV22ManageFiltersData=n.GetDropDownOptionsData();gx.fn.setControlValue("vMANAGEFILTERSDATA",n.ParentObject.AV22ManageFiltersData)});f.setProp("Gx Control Type","Gxcontroltype","","int");f.setC2ShowFunction(function(n){n.show()});f.addEventHandler("OnOptionClicked",this.e111n2_client);this.setUserControl(f);this.GRIDPAGINATIONBARContainer=gx.uc.getNew(this,44,28,"DVelop_DVPaginationBar","GRIDPAGINATIONBARContainer","Gridpaginationbar","GRIDPAGINATIONBAR");i=this.GRIDPAGINATIONBARContainer;i.setProp("Enabled","Enabled",!0,"boolean");i.setProp("Class","Class","PaginationBar","str");i.setProp("ShowFirst","Showfirst",!1,"bool");i.setProp("ShowPrevious","Showprevious",!0,"bool");i.setProp("ShowNext","Shownext",!0,"bool");i.setProp("ShowLast","Showlast",!1,"bool");i.setProp("PagesToShow","Pagestoshow",5,"num");i.setProp("PagingButtonsPosition","Pagingbuttonsposition","Right","str");i.setProp("PagingCaptionPosition","Pagingcaptionposition","Left","str");i.setProp("EmptyGridClass","Emptygridclass","PaginationBarEmptyGrid","str");i.setProp("SelectedPage","Selectedpage","","char");i.setProp("RowsPerPageSelector","Rowsperpageselector",!0,"bool");i.setDynProp("RowsPerPageSelectedValue","Rowsperpageselectedvalue",10,"num");i.setProp("RowsPerPageOptions","Rowsperpageoptions","5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50","str");i.setProp("First","First","First","str");i.setProp("Previous","Previous","WWP_PagingPreviousCaption","str");i.setProp("Next","Next","WWP_PagingNextCaption","str");i.setProp("Last","Last","Last","str");i.setProp("Caption","Caption",gx.getMessage("WWP_PagingCaption"),"str");i.setProp("EmptyGridCaption","Emptygridcaption","WWP_PagingEmptyGridCaption","str");i.setProp("RowsPerPageCaption","Rowsperpagecaption","WWP_PagingRowsPerPage","str");i.addV2CFunction("AV33GridCurrentPage","vGRIDCURRENTPAGE","SetCurrentPage");i.addC2VFunction(function(n){n.ParentObject.AV33GridCurrentPage=n.GetCurrentPage();gx.fn.setControlValue("vGRIDCURRENTPAGE",n.ParentObject.AV33GridCurrentPage)});i.addV2CFunction("AV34GridPageCount","vGRIDPAGECOUNT","SetPageCount");i.addC2VFunction(function(n){n.ParentObject.AV34GridPageCount=n.GetPageCount();gx.fn.setControlValue("vGRIDPAGECOUNT",n.ParentObject.AV34GridPageCount)});i.setProp("RecordCount","Recordcount","","str");i.setProp("Page","Page","","str");i.addV2CFunction("AV35GridAppliedFilters","vGRIDAPPLIEDFILTERS","SetAppliedFilters");i.addC2VFunction(function(n){n.ParentObject.AV35GridAppliedFilters=n.GetAppliedFilters();gx.fn.setControlValue("vGRIDAPPLIEDFILTERS",n.ParentObject.AV35GridAppliedFilters)});i.setProp("Visible","Visible",!0,"bool");i.setProp("Gx Control Type","Gxcontroltype","","int");i.setC2ShowFunction(function(n){n.show()});i.addEventHandler("ChangePage",this.e121n2_client);i.addEventHandler("ChangeRowsPerPage",this.e131n2_client);this.setUserControl(i);this.DDO_GRIDContainer=gx.uc.getNew(this,48,28,"DDOGridTitleSettingsM","DDO_GRIDContainer","Ddo_grid","DDO_GRID");n=this.DDO_GRIDContainer;n.setProp("Class","Class","","char");n.setProp("Enabled","Enabled",!0,"boolean");n.setProp("IconType","Icontype","Image","str");n.setProp("Icon","Icon","","str");n.setProp("Caption","Caption","","str");n.setProp("Tooltip","Tooltip","","str");n.setProp("Cls","Cls","","str");n.setProp("ActiveEventKey","Activeeventkey","","char");n.setDynProp("FilteredText_set","Filteredtext_set","","char");n.setProp("FilteredText_get","Filteredtext_get","","char");n.setProp("FilteredTextTo_set","Filteredtextto_set","","char");n.setProp("FilteredTextTo_get","Filteredtextto_get","","char");n.setDynProp("SelectedValue_set","Selectedvalue_set","","char");n.setProp("SelectedValue_get","Selectedvalue_get","","char");n.setProp("SelectedText_set","Selectedtext_set","","char");n.setProp("SelectedText_get","Selectedtext_get","","char");n.setProp("SelectedColumn","Selectedcolumn","","char");n.setProp("SelectedColumnFixedFilter","Selectedcolumnfixedfilter","","char");n.setDynProp("GAMOAuthToken","Gamoauthtoken","","char");n.setProp("TitleControlAlign","Titlecontrolalign","","str");n.setProp("Visible","Visible","","str");n.setDynProp("GridInternalName","Gridinternalname","","str");n.setProp("ColumnIds","Columnids","1:ProductServiceTypeName","str");n.setProp("ColumnsSortValues","Columnssortvalues","-1","str");n.setProp("IncludeSortASC","Includesortasc","T","str");n.setProp("IncludeSortDSC","Includesortdsc","","str");n.setProp("AllowGroup","Allowgroup","","str");n.setProp("Fixable","Fixable","T","str");n.setDynProp("SortedStatus","Sortedstatus","","char");n.setProp("IncludeFilter","Includefilter","T","str");n.setProp("FilterType","Filtertype","Character","str");n.setProp("FilterIsRange","Filterisrange","","str");n.setProp("IncludeDataList","Includedatalist","T","str");n.setProp("DataListType","Datalisttype","Dynamic","str");n.setProp("AllowMultipleSelection","Allowmultipleselection","","str");n.setProp("DataListFixedValues","Datalistfixedvalues","","str");n.setProp("DataListProc","Datalistproc","ProductServiceTypeWWGetFilterData","str");n.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");n.setProp("RemoteServicesParameters","Remoteservicesparameters","","str");n.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");n.setProp("FixedFilters","Fixedfilters","","str");n.setProp("Format","Format","","str");n.setProp("SelectedFixedFilter","Selectedfixedfilter","","char");n.setProp("SortASC","Sortasc","","str");n.setProp("SortDSC","Sortdsc","","str");n.setProp("AllowGroupText","Allowgrouptext","","str");n.setProp("LoadingData","Loadingdata","","str");n.setProp("CleanFilter","Cleanfilter","","str");n.setProp("RangeFilterFrom","Rangefilterfrom","","str");n.setProp("RangeFilterTo","Rangefilterto","","str");n.setProp("NoResultsFound","Noresultsfound","","str");n.setProp("SearchButtonText","Searchbuttontext","","str");n.addV2CFunction("AV29DDO_TitleSettingsIcons","vDDO_TITLESETTINGSICONS","SetDropDownOptionsTitleSettingsIcons");n.addC2VFunction(function(n){n.ParentObject.AV29DDO_TitleSettingsIcons=n.GetDropDownOptionsTitleSettingsIcons();gx.fn.setControlValue("vDDO_TITLESETTINGSICONS",n.ParentObject.AV29DDO_TitleSettingsIcons)});n.setC2ShowFunction(function(n){n.show()});n.addEventHandler("OnOptionClicked",this.e141n2_client);this.setUserControl(n);this.DDO_GRIDCOLUMNSSELECTORContainer=gx.uc.getNew(this,49,28,"BootstrapDropDownOptions","DDO_GRIDCOLUMNSSELECTORContainer","Ddo_gridcolumnsselector","DDO_GRIDCOLUMNSSELECTOR");u=this.DDO_GRIDCOLUMNSSELECTORContainer;u.setProp("Class","Class","","char");u.setProp("Enabled","Enabled",!0,"boolean");u.setProp("IconType","Icontype","FontIcon","str");u.setProp("Icon","Icon","fas fa-cog","str");u.setProp("Caption","Caption",gx.getMessage("WWP_EditColumnsCaption"),"str");u.setProp("Tooltip","Tooltip","WWP_EditColumnsTooltip","str");u.setProp("Cls","Cls","ColumnsSelector hidden-xs","str");u.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");u.setProp("DropDownOptionsType","Dropdownoptionstype","GridColumnsSelector","str");u.setProp("Visible","Visible",!0,"bool");u.setDynProp("GridInternalName","Gridinternalname","","char");u.setDynProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");u.setProp("ColumnsSelectorValues","Columnsselectorvalues","","char");u.setProp("UpdateButtonText","Updatebuttontext","","str");u.addV2CFunction("AV29DDO_TitleSettingsIcons","vDDO_TITLESETTINGSICONS","SetDropDownOptionsTitleSettingsIcons");u.addC2VFunction(function(n){n.ParentObject.AV29DDO_TitleSettingsIcons=n.GetDropDownOptionsTitleSettingsIcons();gx.fn.setControlValue("vDDO_TITLESETTINGSICONS",n.ParentObject.AV29DDO_TitleSettingsIcons)});u.addV2CFunction("AV19ColumnsSelector","vCOLUMNSSELECTOR","SetDropDownOptionsData");u.addC2VFunction(function(n){n.ParentObject.AV19ColumnsSelector=n.GetDropDownOptionsData();gx.fn.setControlValue("vCOLUMNSSELECTOR",n.ParentObject.AV19ColumnsSelector)});u.setC2ShowFunction(function(n){n.show()});u.addEventHandler("OnColumnsChanged",this.e151n2_client);this.setUserControl(u);this.GRID_EMPOWERERContainer=gx.uc.getNew(this,50,28,"WWP_GridEmpowerer","GRID_EMPOWERERContainer","Grid_empowerer","GRID_EMPOWERER");e=this.GRID_EMPOWERERContainer;e.setProp("Class","Class","","char");e.setProp("Enabled","Enabled",!0,"boolean");e.setDynProp("GridInternalName","Gridinternalname","","char");e.setProp("HasCategories","Hascategories",!1,"bool");e.setProp("InfiniteScrolling","Infinitescrolling","False","str");e.setProp("HasTitleSettings","Hastitlesettings",!0,"bool");e.setProp("HasColumnsSelector","Hascolumnsselector",!0,"bool");e.setProp("HasRowGroups","Hasrowgroups",!1,"bool");e.setProp("FixedColumns","Fixedcolumns","","str");e.setProp("PopoversInGrid","Popoversingrid","","str");e.setProp("Visible","Visible",!0,"bool");e.setC2ShowFunction(function(n){n.show()});this.setUserControl(e);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TABLEMAIN",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[9]={id:9,fld:"TABLEHEADER",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"TABLEHEADERCONTENT",grid:0};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"TABLEACTIONS",grid:0};t[14]={id:14,fld:"",grid:0};t[15]={id:15,fld:"",grid:0};t[16]={id:16,fld:"",grid:0};t[17]={id:17,fld:"BTNINSERT",grid:0,evt:"e161n2_client"};t[18]={id:18,fld:"",grid:0};t[19]={id:19,fld:"BTNEDITCOLUMNS",grid:0};t[20]={id:20,fld:"",grid:0};t[21]={id:21,fld:"TABLERIGHTHEADER",grid:0};t[22]={id:22,fld:"",grid:0};t[24]={id:24,fld:"",grid:0};t[25]={id:25,fld:"TABLEFILTERS",grid:0};t[26]={id:26,fld:"",grid:0};t[27]={id:27,fld:"",grid:0};t[28]={id:28,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.GridContainer],fld:"vFILTERFULLTEXT",fmt:0,gxz:"ZV16FilterFullText",gxold:"OV16FilterFullText",gxvar:"AV16FilterFullText",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV16FilterFullText=n)},v2z:function(n){n!==undefined&&(gx.O.ZV16FilterFullText=n)},v2c:function(){gx.fn.setControlValue("vFILTERFULLTEXT",gx.O.AV16FilterFullText,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV16FilterFullText=this.val())},val:function(){return gx.fn.getControlValue("vFILTERFULLTEXT")},nac:gx.falseFn};this.declareDomainHdlr(28,function(){});t[29]={id:29,fld:"",grid:0};t[30]={id:30,fld:"",grid:0};t[32]={id:32,fld:"",grid:0};t[33]={id:33,fld:"",grid:0};t[34]={id:34,fld:"GRIDTABLEWITHPAGINATIONBAR",grid:0};t[35]={id:35,fld:"",grid:0};t[36]={id:36,fld:"",grid:0};t[38]={id:38,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:37,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTSERVICETYPEID",fmt:0,gxz:"Z71ProductServiceTypeId",gxold:"O71ProductServiceTypeId",gxvar:"A71ProductServiceTypeId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A71ProductServiceTypeId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z71ProductServiceTypeId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PRODUCTSERVICETYPEID",n||gx.fn.currentGridRowImpl(37),gx.O.A71ProductServiceTypeId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A71ProductServiceTypeId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PRODUCTSERVICETYPEID",n||gx.fn.currentGridRowImpl(37),gx.thousandSeparator)},nac:gx.falseFn};t[39]={id:39,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:37,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTSERVICETYPENAME",fmt:0,gxz:"Z72ProductServiceTypeName",gxold:"O72ProductServiceTypeName",gxvar:"A72ProductServiceTypeName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A72ProductServiceTypeName=n)},v2z:function(n){n!==undefined&&(gx.O.Z72ProductServiceTypeName=n)},v2c:function(n){gx.fn.setGridControlValue("PRODUCTSERVICETYPENAME",n||gx.fn.currentGridRowImpl(37),gx.O.A72ProductServiceTypeName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A72ProductServiceTypeName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PRODUCTSERVICETYPENAME",n||gx.fn.currentGridRowImpl(37))},nac:gx.falseFn};t[40]={id:40,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:37,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUPDATE",fmt:1,gxz:"ZV36Update",gxold:"OV36Update",gxvar:"AV36Update",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV36Update=n)},v2z:function(n){n!==undefined&&(gx.O.ZV36Update=n)},v2c:function(n){gx.fn.setGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(37),gx.O.AV36Update,1)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV36Update=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(37))},nac:gx.falseFn};t[41]={id:41,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:37,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDELETE",fmt:1,gxz:"ZV38Delete",gxold:"OV38Delete",gxvar:"AV38Delete",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV38Delete=n)},v2z:function(n){n!==undefined&&(gx.O.ZV38Delete=n)},v2c:function(n){gx.fn.setGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(37),gx.O.AV38Delete,1)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV38Delete=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(37))},nac:gx.falseFn};t[42]={id:42,fld:"",grid:0};t[43]={id:43,fld:"",grid:0};t[45]={id:45,fld:"",grid:0};t[46]={id:46,fld:"",grid:0};t[47]={id:47,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};this.AV16FilterFullText="";this.ZV16FilterFullText="";this.OV16FilterFullText="";this.Z71ProductServiceTypeId=0;this.O71ProductServiceTypeId=0;this.Z72ProductServiceTypeName="";this.O72ProductServiceTypeName="";this.ZV36Update="";this.OV36Update="";this.ZV38Delete="";this.OV38Delete="";this.AV22ManageFiltersData=[];this.AV16FilterFullText="";this.AV33GridCurrentPage=0;this.AV29DDO_TitleSettingsIcons={Default_fi:"",Filtered_fi:"",SortedASC_fi:"",SortedDSC_fi:"",FilteredSortedASC_fi:"",FilteredSortedDSC_fi:"",OptionSortASC_fi:"",OptionSortDSC_fi:"",OptionApplyFilter_fi:"",OptionFilteringData_fi:"",OptionCleanFilters_fi:"",SelectedOption_fi:"",MultiselOption_fi:"",MultiselSelOption_fi:"",TreeviewCollapse_fi:"",TreeviewExpand_fi:"",FixLeft_fi:"",FixRight_fi:"",OptionGroup_fi:""};this.A71ProductServiceTypeId=0;this.A72ProductServiceTypeName="";this.AV36Update="";this.AV38Delete="";this.AV24ManageFiltersExecutionStep=0;this.AV19ColumnsSelector={Columns:[]};this.AV42Pgmname="";this.AV27TFProductServiceTypeName="";this.AV28TFProductServiceTypeName_Sel="";this.AV14OrderedDsc=!1;this.AV37IsAuthorized_Update=!1;this.AV39IsAuthorized_Delete=!1;this.AV40IsAuthorized_ProductServiceTypeName=!1;this.AV11GridState={CurrentPage:0,OrderedBy:0,OrderedDsc:!1,HidingSearch:0,PageSize:"",CollapsedRecords:"",GroupBy:"",FilterValues:[],DynamicFilters:[]};this.AV41IsAuthorized_Insert=!1;this.Events={e121n2_client:["GRIDPAGINATIONBAR.CHANGEPAGE",!0],e131n2_client:["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!0],e141n2_client:["DDO_GRID.ONOPTIONCLICKED",!0],e151n2_client:["DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",!0],e111n2_client:["DDO_MANAGEFILTERS.ONOPTIONCLICKED",!0],e161n2_client:["'DOINSERT'",!0],e201n2_client:["ENTER",!0],e211n2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"AV24ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV19ColumnsSelector",fld:"vCOLUMNSSELECTOR",pic:""},{ctrl:"GRID",prop:"Rows"},{av:"AV16FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV42Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV27TFProductServiceTypeName",fld:"vTFPRODUCTSERVICETYPENAME",pic:""},{av:"AV28TFProductServiceTypeName_Sel",fld:"vTFPRODUCTSERVICETYPENAME_SEL",pic:""},{av:"AV14OrderedDsc",fld:"vORDEREDDSC",pic:""},{av:"AV37IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",pic:"",hsh:!0},{av:"AV39IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",pic:"",hsh:!0},{av:"AV40IsAuthorized_ProductServiceTypeName",fld:"vISAUTHORIZED_PRODUCTSERVICETYPENAME",pic:"",hsh:!0},{av:"AV41IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0}],[{av:"AV24ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV19ColumnsSelector",fld:"vCOLUMNSSELECTOR",pic:""},{av:'gx.fn.getCtrlProperty("PRODUCTSERVICETYPENAME","Visible")',ctrl:"PRODUCTSERVICETYPENAME",prop:"Visible"},{av:"AV33GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV34GridPageCount",fld:"vGRIDPAGECOUNT",pic:"ZZZZZZZZZ9"},{av:"AV35GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""},{av:"AV37IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",pic:"",hsh:!0},{av:'gx.fn.getCtrlProperty("vUPDATE","Visible")',ctrl:"vUPDATE",prop:"Visible"},{av:"AV39IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",pic:"",hsh:!0},{av:'gx.fn.getCtrlProperty("vDELETE","Visible")',ctrl:"vDELETE",prop:"Visible"},{av:"AV41IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{ctrl:"BTNINSERT",prop:"Visible"},{av:"AV22ManageFiltersData",fld:"vMANAGEFILTERSDATA",pic:""},{av:"AV11GridState",fld:"vGRIDSTATE",pic:""}]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV16FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV24ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV19ColumnsSelector",fld:"vCOLUMNSSELECTOR",pic:""},{av:"AV42Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV27TFProductServiceTypeName",fld:"vTFPRODUCTSERVICETYPENAME",pic:""},{av:"AV28TFProductServiceTypeName_Sel",fld:"vTFPRODUCTSERVICETYPENAME_SEL",pic:""},{av:"AV14OrderedDsc",fld:"vORDEREDDSC",pic:""},{av:"AV37IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",pic:"",hsh:!0},{av:"AV39IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",pic:"",hsh:!0},{av:"AV40IsAuthorized_ProductServiceTypeName",fld:"vISAUTHORIZED_PRODUCTSERVICETYPENAME",pic:"",hsh:!0},{av:"AV41IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{av:"this.GRIDPAGINATIONBARContainer.SelectedPage",ctrl:"GRIDPAGINATIONBAR",prop:"SelectedPage"}],[]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV16FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV24ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV19ColumnsSelector",fld:"vCOLUMNSSELECTOR",pic:""},{av:"AV42Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV27TFProductServiceTypeName",fld:"vTFPRODUCTSERVICETYPENAME",pic:""},{av:"AV28TFProductServiceTypeName_Sel",fld:"vTFPRODUCTSERVICETYPENAME_SEL",pic:""},{av:"AV14OrderedDsc",fld:"vORDEREDDSC",pic:""},{av:"AV37IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",pic:"",hsh:!0},{av:"AV39IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",pic:"",hsh:!0},{av:"AV40IsAuthorized_ProductServiceTypeName",fld:"vISAUTHORIZED_PRODUCTSERVICETYPENAME",pic:"",hsh:!0},{av:"AV41IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{av:"this.GRIDPAGINATIONBARContainer.RowsPerPageSelectedValue",ctrl:"GRIDPAGINATIONBAR",prop:"RowsPerPageSelectedValue"}],[{ctrl:"GRID",prop:"Rows"}]];this.EvtParms["DDO_GRID.ONOPTIONCLICKED"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV16FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV24ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV19ColumnsSelector",fld:"vCOLUMNSSELECTOR",pic:""},{av:"AV42Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV27TFProductServiceTypeName",fld:"vTFPRODUCTSERVICETYPENAME",pic:""},{av:"AV28TFProductServiceTypeName_Sel",fld:"vTFPRODUCTSERVICETYPENAME_SEL",pic:""},{av:"AV14OrderedDsc",fld:"vORDEREDDSC",pic:""},{av:"AV37IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",pic:"",hsh:!0},{av:"AV39IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",pic:"",hsh:!0},{av:"AV40IsAuthorized_ProductServiceTypeName",fld:"vISAUTHORIZED_PRODUCTSERVICETYPENAME",pic:"",hsh:!0},{av:"AV41IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{av:"this.DDO_GRIDContainer.ActiveEventKey",ctrl:"DDO_GRID",prop:"ActiveEventKey"},{av:"this.DDO_GRIDContainer.SelectedColumn",ctrl:"DDO_GRID",prop:"SelectedColumn"},{av:"this.DDO_GRIDContainer.FilteredText_get",ctrl:"DDO_GRID",prop:"FilteredText_get"},{av:"this.DDO_GRIDContainer.SelectedValue_get",ctrl:"DDO_GRID",prop:"SelectedValue_get"}],[{av:"AV14OrderedDsc",fld:"vORDEREDDSC",pic:""},{av:"AV27TFProductServiceTypeName",fld:"vTFPRODUCTSERVICETYPENAME",pic:""},{av:"AV28TFProductServiceTypeName_Sel",fld:"vTFPRODUCTSERVICETYPENAME_SEL",pic:""},{av:"this.DDO_GRIDContainer.SortedStatus",ctrl:"DDO_GRID",prop:"SortedStatus"}]];this.EvtParms["GRID.LOAD"]=[[{av:"AV37IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",pic:"",hsh:!0},{av:"A71ProductServiceTypeId",fld:"PRODUCTSERVICETYPEID",pic:"ZZZ9",hsh:!0},{av:"AV39IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",pic:"",hsh:!0},{av:"AV40IsAuthorized_ProductServiceTypeName",fld:"vISAUTHORIZED_PRODUCTSERVICETYPENAME",pic:"",hsh:!0}],[{av:"AV36Update",fld:"vUPDATE",pic:""},{av:'gx.fn.getCtrlProperty("vUPDATE","Link")',ctrl:"vUPDATE",prop:"Link"},{av:"AV38Delete",fld:"vDELETE",pic:""},{av:'gx.fn.getCtrlProperty("vDELETE","Link")',ctrl:"vDELETE",prop:"Link"},{av:'gx.fn.getCtrlProperty("PRODUCTSERVICETYPENAME","Link")',ctrl:"PRODUCTSERVICETYPENAME",prop:"Link"}]];this.EvtParms["DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV16FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV24ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV19ColumnsSelector",fld:"vCOLUMNSSELECTOR",pic:""},{av:"AV42Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV27TFProductServiceTypeName",fld:"vTFPRODUCTSERVICETYPENAME",pic:""},{av:"AV28TFProductServiceTypeName_Sel",fld:"vTFPRODUCTSERVICETYPENAME_SEL",pic:""},{av:"AV14OrderedDsc",fld:"vORDEREDDSC",pic:""},{av:"AV37IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",pic:"",hsh:!0},{av:"AV39IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",pic:"",hsh:!0},{av:"AV40IsAuthorized_ProductServiceTypeName",fld:"vISAUTHORIZED_PRODUCTSERVICETYPENAME",pic:"",hsh:!0},{av:"AV41IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{av:"this.DDO_GRIDCOLUMNSSELECTORContainer.ColumnsSelectorValues",ctrl:"DDO_GRIDCOLUMNSSELECTOR",prop:"ColumnsSelectorValues"}],[{av:"AV19ColumnsSelector",fld:"vCOLUMNSSELECTOR",pic:""},{av:"AV24ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:'gx.fn.getCtrlProperty("PRODUCTSERVICETYPENAME","Visible")',ctrl:"PRODUCTSERVICETYPENAME",prop:"Visible"},{av:"AV33GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV34GridPageCount",fld:"vGRIDPAGECOUNT",pic:"ZZZZZZZZZ9"},{av:"AV35GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""},{av:"AV37IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",pic:"",hsh:!0},{av:'gx.fn.getCtrlProperty("vUPDATE","Visible")',ctrl:"vUPDATE",prop:"Visible"},{av:"AV39IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",pic:"",hsh:!0},{av:'gx.fn.getCtrlProperty("vDELETE","Visible")',ctrl:"vDELETE",prop:"Visible"},{av:"AV41IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{ctrl:"BTNINSERT",prop:"Visible"},{av:"AV22ManageFiltersData",fld:"vMANAGEFILTERSDATA",pic:""},{av:"AV11GridState",fld:"vGRIDSTATE",pic:""}]];this.EvtParms["DDO_MANAGEFILTERS.ONOPTIONCLICKED"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV16FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV24ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV19ColumnsSelector",fld:"vCOLUMNSSELECTOR",pic:""},{av:"AV42Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV27TFProductServiceTypeName",fld:"vTFPRODUCTSERVICETYPENAME",pic:""},{av:"AV28TFProductServiceTypeName_Sel",fld:"vTFPRODUCTSERVICETYPENAME_SEL",pic:""},{av:"AV14OrderedDsc",fld:"vORDEREDDSC",pic:""},{av:"AV37IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",pic:"",hsh:!0},{av:"AV39IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",pic:"",hsh:!0},{av:"AV40IsAuthorized_ProductServiceTypeName",fld:"vISAUTHORIZED_PRODUCTSERVICETYPENAME",pic:"",hsh:!0},{av:"AV41IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{av:"this.DDO_MANAGEFILTERSContainer.ActiveEventKey",ctrl:"DDO_MANAGEFILTERS",prop:"ActiveEventKey"},{av:"AV11GridState",fld:"vGRIDSTATE",pic:""}],[{av:"AV24ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV11GridState",fld:"vGRIDSTATE",pic:""},{av:"AV14OrderedDsc",fld:"vORDEREDDSC",pic:""},{av:"AV16FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV27TFProductServiceTypeName",fld:"vTFPRODUCTSERVICETYPENAME",pic:""},{av:"AV28TFProductServiceTypeName_Sel",fld:"vTFPRODUCTSERVICETYPENAME_SEL",pic:""},{av:"this.DDO_GRIDContainer.SelectedValue_set",ctrl:"DDO_GRID",prop:"SelectedValue_set"},{av:"this.DDO_GRIDContainer.FilteredText_set",ctrl:"DDO_GRID",prop:"FilteredText_set"},{av:"this.DDO_GRIDContainer.SortedStatus",ctrl:"DDO_GRID",prop:"SortedStatus"},{av:"AV19ColumnsSelector",fld:"vCOLUMNSSELECTOR",pic:""},{av:'gx.fn.getCtrlProperty("PRODUCTSERVICETYPENAME","Visible")',ctrl:"PRODUCTSERVICETYPENAME",prop:"Visible"},{av:"AV33GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV34GridPageCount",fld:"vGRIDPAGECOUNT",pic:"ZZZZZZZZZ9"},{av:"AV35GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""},{av:"AV37IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",pic:"",hsh:!0},{av:'gx.fn.getCtrlProperty("vUPDATE","Visible")',ctrl:"vUPDATE",prop:"Visible"},{av:"AV39IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",pic:"",hsh:!0},{av:'gx.fn.getCtrlProperty("vDELETE","Visible")',ctrl:"vDELETE",prop:"Visible"},{av:"AV41IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{ctrl:"BTNINSERT",prop:"Visible"},{av:"AV22ManageFiltersData",fld:"vMANAGEFILTERSDATA",pic:""}]];this.EvtParms["'DOINSERT'"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV16FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV24ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV19ColumnsSelector",fld:"vCOLUMNSSELECTOR",pic:""},{av:"AV42Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV27TFProductServiceTypeName",fld:"vTFPRODUCTSERVICETYPENAME",pic:""},{av:"AV28TFProductServiceTypeName_Sel",fld:"vTFPRODUCTSERVICETYPENAME_SEL",pic:""},{av:"AV14OrderedDsc",fld:"vORDEREDDSC",pic:""},{av:"AV37IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",pic:"",hsh:!0},{av:"AV39IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",pic:"",hsh:!0},{av:"AV40IsAuthorized_ProductServiceTypeName",fld:"vISAUTHORIZED_PRODUCTSERVICETYPENAME",pic:"",hsh:!0},{av:"AV41IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{av:"A71ProductServiceTypeId",fld:"PRODUCTSERVICETYPEID",pic:"ZZZ9",hsh:!0}],[{av:"AV24ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV19ColumnsSelector",fld:"vCOLUMNSSELECTOR",pic:""},{av:'gx.fn.getCtrlProperty("PRODUCTSERVICETYPENAME","Visible")',ctrl:"PRODUCTSERVICETYPENAME",prop:"Visible"},{av:"AV33GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV34GridPageCount",fld:"vGRIDPAGECOUNT",pic:"ZZZZZZZZZ9"},{av:"AV35GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""},{av:"AV37IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",pic:"",hsh:!0},{av:'gx.fn.getCtrlProperty("vUPDATE","Visible")',ctrl:"vUPDATE",prop:"Visible"},{av:"AV39IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",pic:"",hsh:!0},{av:'gx.fn.getCtrlProperty("vDELETE","Visible")',ctrl:"vDELETE",prop:"Visible"},{av:"AV41IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{ctrl:"BTNINSERT",prop:"Visible"},{av:"AV22ManageFiltersData",fld:"vMANAGEFILTERSDATA",pic:""},{av:"AV11GridState",fld:"vGRIDSTATE",pic:""}]];this.EvtParms.ENTER=[[],[]];this.setVCMap("AV24ManageFiltersExecutionStep","vMANAGEFILTERSEXECUTIONSTEP",0,"int",1,0);this.setVCMap("AV19ColumnsSelector","vCOLUMNSSELECTOR",0,"WWPBaseObjectsWWPColumnsSelector",0,0);this.setVCMap("AV42Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV27TFProductServiceTypeName","vTFPRODUCTSERVICETYPENAME",0,"svchar",40,0);this.setVCMap("AV28TFProductServiceTypeName_Sel","vTFPRODUCTSERVICETYPENAME_SEL",0,"svchar",40,0);this.setVCMap("AV14OrderedDsc","vORDEREDDSC",0,"boolean",4,0);this.setVCMap("AV37IsAuthorized_Update","vISAUTHORIZED_UPDATE",0,"boolean",4,0);this.setVCMap("AV39IsAuthorized_Delete","vISAUTHORIZED_DELETE",0,"boolean",4,0);this.setVCMap("AV40IsAuthorized_ProductServiceTypeName","vISAUTHORIZED_PRODUCTSERVICETYPENAME",0,"boolean",4,0);this.setVCMap("AV11GridState","vGRIDSTATE",0,"WWPBaseObjectsWWPGridState",0,0);this.setVCMap("AV41IsAuthorized_Insert","vISAUTHORIZED_INSERT",0,"boolean",4,0);this.setVCMap("AV24ManageFiltersExecutionStep","vMANAGEFILTERSEXECUTIONSTEP",0,"int",1,0);this.setVCMap("AV19ColumnsSelector","vCOLUMNSSELECTOR",0,"WWPBaseObjectsWWPColumnsSelector",0,0);this.setVCMap("AV42Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV27TFProductServiceTypeName","vTFPRODUCTSERVICETYPENAME",0,"svchar",40,0);this.setVCMap("AV28TFProductServiceTypeName_Sel","vTFPRODUCTSERVICETYPENAME_SEL",0,"svchar",40,0);this.setVCMap("AV14OrderedDsc","vORDEREDDSC",0,"boolean",4,0);this.setVCMap("AV37IsAuthorized_Update","vISAUTHORIZED_UPDATE",0,"boolean",4,0);this.setVCMap("AV39IsAuthorized_Delete","vISAUTHORIZED_DELETE",0,"boolean",4,0);this.setVCMap("AV40IsAuthorized_ProductServiceTypeName","vISAUTHORIZED_PRODUCTSERVICETYPENAME",0,"boolean",4,0);this.setVCMap("AV24ManageFiltersExecutionStep","vMANAGEFILTERSEXECUTIONSTEP",0,"int",1,0);this.setVCMap("AV19ColumnsSelector","vCOLUMNSSELECTOR",0,"WWPBaseObjectsWWPColumnsSelector",0,0);this.setVCMap("AV42Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV27TFProductServiceTypeName","vTFPRODUCTSERVICETYPENAME",0,"svchar",40,0);this.setVCMap("AV28TFProductServiceTypeName_Sel","vTFPRODUCTSERVICETYPENAME_SEL",0,"svchar",40,0);this.setVCMap("AV14OrderedDsc","vORDEREDDSC",0,"boolean",4,0);this.setVCMap("AV37IsAuthorized_Update","vISAUTHORIZED_UPDATE",0,"boolean",4,0);this.setVCMap("AV39IsAuthorized_Delete","vISAUTHORIZED_DELETE",0,"boolean",4,0);this.setVCMap("AV40IsAuthorized_ProductServiceTypeName","vISAUTHORIZED_PRODUCTSERVICETYPENAME",0,"boolean",4,0);r.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});r.addRefreshingVar(this.GXValidFnc[28]);r.addRefreshingVar({rfrVar:"AV24ManageFiltersExecutionStep"});r.addRefreshingVar({rfrVar:"AV19ColumnsSelector"});r.addRefreshingVar({rfrVar:"AV42Pgmname"});r.addRefreshingVar({rfrVar:"AV27TFProductServiceTypeName"});r.addRefreshingVar({rfrVar:"AV28TFProductServiceTypeName_Sel"});r.addRefreshingVar({rfrVar:"AV14OrderedDsc"});r.addRefreshingVar({rfrVar:"AV37IsAuthorized_Update"});r.addRefreshingVar({rfrVar:"AV39IsAuthorized_Delete"});r.addRefreshingVar({rfrVar:"AV40IsAuthorized_ProductServiceTypeName"});r.addRefreshingVar({rfrVar:"AV41IsAuthorized_Insert"});r.addRefreshingParm(this.GXValidFnc[28]);r.addRefreshingParm({rfrVar:"AV24ManageFiltersExecutionStep"});r.addRefreshingParm({rfrVar:"AV19ColumnsSelector"});r.addRefreshingParm({rfrVar:"AV42Pgmname"});r.addRefreshingParm({rfrVar:"AV27TFProductServiceTypeName"});r.addRefreshingParm({rfrVar:"AV28TFProductServiceTypeName_Sel"});r.addRefreshingParm({rfrVar:"AV14OrderedDsc"});r.addRefreshingParm({rfrVar:"AV37IsAuthorized_Update"});r.addRefreshingParm({rfrVar:"AV39IsAuthorized_Delete"});r.addRefreshingParm({rfrVar:"AV40IsAuthorized_ProductServiceTypeName"});r.addRefreshingParm({rfrVar:"AV41IsAuthorized_Insert"});this.Initialize();this.setSDTMapping("WWPBaseObjects\\WWPColumnsSelector.Column",{ColumnName:{extr:"C"},IsVisible:{extr:"V"},DisplayName:{extr:"D"},Order:{extr:"O"},Category:{extr:"G"},Fixed:{extr:"F"}});this.setSDTMapping("WWPBaseObjects\\WWPColumnsSelector",{Columns:{sdt:"WWPBaseObjects\\WWPColumnsSelector.Column"}});this.setSDTMapping("WWPBaseObjects\\WWPGridState",{FilterValues:{sdt:"WWPBaseObjects\\WWPGridState.FilterValue"},DynamicFilters:{sdt:"WWPBaseObjects\\WWPGridState.DynamicFilter"}});this.setSDTMapping("WWPBaseObjects\\WWPGridState.DynamicFilter",{Dsc:{extr:"d"}});this.setSDTMapping("WWPBaseObjects\\DVB_SDTDropDownOptionsTitleSettingsIcons",{Default_fi:{extr:"def"},Filtered_fi:{extr:"fil"},SortedASC_fi:{extr:"asc"},SortedDSC_fi:{extr:"dsc"},FilteredSortedASC_fi:{extr:"fasc"},FilteredSortedDSC_fi:{extr:"fdsc"},OptionSortASC_fi:{extr:"osasc"},OptionSortDSC_fi:{extr:"osdsc"},OptionApplyFilter_fi:{extr:"app"},OptionFilteringData_fi:{extr:"fildata"},OptionCleanFilters_fi:{extr:"cle"},SelectedOption_fi:{extr:"selo"},MultiselOption_fi:{extr:"mul"},MultiselSelOption_fi:{extr:"muls"},TreeviewCollapse_fi:{extr:"tcol"},TreeviewExpand_fi:{extr:"texp"},FixLeft_fi:{extr:"fixl"},FixRight_fi:{extr:"fixr"},OptionGroup_fi:{extr:"og"}});this.setSDTMapping("GeneXusSecurity\\GAMApplication",{Environment:{sdt:"GeneXusSecurity\\GAMApplicationEnvironment"}});this.setSDTMapping("GeneXusSecurity\\GAMSession",{User:{sdt:"GeneXusSecurity\\GAMUser"}});this.setSDTMapping("WWPBaseObjects\\WWPTransactionContext",{Attributes:{sdt:"WWPBaseObjects\\WWPTransactionContext.Attribute"}})});gx.wi(function(){gx.createParentObj(this.productservicetypeww)})