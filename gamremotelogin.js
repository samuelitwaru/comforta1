gx.evt.autoSkip=!1;gx.define("gamremotelogin",!1,function(){var n,t;this.ServerClass="gamremotelogin";this.PackageName="GeneXus.Programs";this.ServerFullClass="gamremotelogin.aspx";this.setObjectType("web");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV13IDP_State=gx.fn.getControlValue("vIDP_STATE");this.AV18Language=gx.fn.getControlValue("vLANGUAGE");this.AV30UserRememberMe=gx.fn.getIntegerValue("vUSERREMEMBERME",gx.thousandSeparator)};this.e160u2_client=function(){return this.clearMessages(),this.call("gamrecoverpasswordstep1.aspx",[this.AV13IDP_State],null,["IDP_State"]),this.refreshOutputs([{av:"AV13IDP_State",fld:"vIDP_STATE",pic:""}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e120u2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e140u2_client=function(){return this.executeServerEvent("VLOGONTO.CLICK",!0,null,!1,!0)};this.e170u2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,55,56,57,58];this.GXLastCtrlId=58;this.WWPUTILITIESContainer=gx.uc.getNew(this,54,22,"DVelop_WorkWithPlusUtilities","WWPUTILITIESContainer","Wwputilities","WWPUTILITIES");t=this.WWPUTILITIESContainer;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("EnableAutoUpdateFromDocumentTitle","Enableautoupdatefromdocumenttitle",!1,"bool");t.setProp("EnableFixObjectFitCover","Enablefixobjectfitcover",!0,"bool");t.setProp("EnableFloatingLabels","Enablefloatinglabels",!1,"bool");t.setProp("EmpowerTabs","Empowertabs",!1,"bool");t.setProp("EnableUpdateRowSelectionStatus","Enableupdaterowselectionstatus",!1,"bool");t.setProp("CurrentTab_ReturnUrl","Currenttab_returnurl","","char");t.setProp("EnableConvertComboToBootstrapSelect","Enableconvertcombotobootstrapselect",!0,"bool");t.setProp("AllowColumnResizing","Allowcolumnresizing",!0,"bool");t.setProp("AllowColumnReordering","Allowcolumnreordering",!0,"bool");t.setProp("AllowColumnDragging","Allowcolumndragging",!1,"bool");t.setProp("AllowColumnsRestore","Allowcolumnsrestore",!0,"bool");t.setProp("RestoreColumnsIconClass","Restorecolumnsiconclass","fas fa-undo","str");t.setProp("PagBarIncludeGoTo","Pagbarincludegoto",!1,"bool");t.setProp("ComboLoadType","Comboloadtype","InfiniteScrolling","str");t.setProp("InfiniteScrollingPage","Infinitescrollingpage",10,"num");t.setProp("UpdateButtonText","Updatebuttontext","WWP_ColumnsSelectorButton","str");t.setProp("AddNewOption","Addnewoption","WWP_AddNewOption","str");t.setProp("OnlySelectedValues","Onlyselectedvalues","WWP_OnlySelectedValues","str");t.setProp("MultipleValuesSeparator","Multiplevaluesseparator",", ","str");t.setProp("SelectAll","Selectall","WWP_SelectAll","str");t.setProp("SortASC","Sortasc","WWP_TSSortASC","str");t.setProp("SortDSC","Sortdsc","WWP_TSSortDSC","str");t.setProp("AllowGroupText","Allowgrouptext","WWP_GroupByOption","str");t.setProp("FixLeftText","Fixlefttext","WWP_TSFixLeft","str");t.setProp("FixRightText","Fixrighttext","WWP_TSFixRight","str");t.setProp("LoadingData","Loadingdata","WWP_TSLoading","str");t.setProp("CleanFilter","Cleanfilter","WWP_TSCleanFilter","str");t.setProp("RangeFilterFrom","Rangefilterfrom","WWP_TSFrom","str");t.setProp("RangeFilterTo","Rangefilterto","WWP_TSTo","str");t.setProp("RangePickerInviteMessage","Rangepickerinvitemessage","WWP_TSRangePickerInviteMessage","str");t.setProp("NoResultsFound","Noresultsfound","WWP_TSNoResults","str");t.setProp("SearchButtonText","Searchbuttontext","WWP_TSSearchButtonCaption","str");t.setProp("SearchMultipleValuesButtonText","Searchmultiplevaluesbuttontext","WWP_FilterSelected","str");t.setProp("ColumnSelectorFixedLeftCategory","Columnselectorfixedleftcategory","WWP_ColumnSelectorFixedLeftCategory","str");t.setProp("ColumnSelectorFixedRightCategory","Columnselectorfixedrightcategory","WWP_ColumnSelectorFixedRightCategory","str");t.setProp("ColumnSelectorNotFixedCategory","Columnselectornotfixedcategory","WWP_ColumnSelectorNotFixedCategory","str");t.setProp("ColumnSelectorNoCategoryText","Columnselectornocategorytext","WWP_ColumnSelectorNoCategoryText","str");t.setProp("ColumnSelectorFixedEmpty","Columnselectorfixedempty","WWP_ColumnSelectorFixedEmpty","str");t.setProp("ColumnSelectorRestoreTooltip","Columnselectorrestoretooltip","WWP_SelectColumns_RestoreDefault","str");t.setProp("PagBarGoToCaption","Pagbargotocaption","WWP_PaginationBarGoToCaption","str");t.setProp("PagBarGoToIconClass","Pagbargotoiconclass","fas fa-redo","str");t.setProp("PagBarGoToTooltip","Pagbargototooltip","WWP_PaginationBarGoToTooltip","str");t.setProp("PagBarEmptyFilteredGridCaption","Pagbaremptyfilteredgridcaption","WWP_PaginationBarEmptyFilteredGridCaption","str");t.setProp("IncludeLineSeparator","Includelineseparator",!1,"bool");t.setProp("Visible","Visible",!0,"bool");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TABLELOGINCONTENT",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLELOGIN",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"LOGOLOGIN",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"UNNAMEDTABLE1",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"LOGOAPPCLIENT_CELL",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,lvl:0,type:"bits",len:1024,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLOGOAPPCLIENT",fmt:0,gxz:"ZV20LogoAppClient",gxold:"OV20LogoAppClient",gxvar:"AV20LogoAppClient",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV20LogoAppClient=n)},v2z:function(n){n!==undefined&&(gx.O.ZV20LogoAppClient=n)},v2c:function(){gx.fn.setMultimediaValue("vLOGOAPPCLIENT",gx.O.AV20LogoAppClient,gx.O.AV43Logoappclient_GXI)},c2v:function(){gx.O.AV43Logoappclient_GXI=this.val_GXI();this.val()!==undefined&&(gx.O.AV20LogoAppClient=this.val())},val:function(){return gx.fn.getBlobValue("vLOGOAPPCLIENT")},val_GXI:function(){return gx.fn.getControlValue("vLOGOAPPCLIENT_GXI")},gxvar_GXI:"AV43Logoappclient_GXI",nac:gx.falseFn};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"TBAPPNAME",format:0,grid:0,ctrltype:"textblock"};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,lvl:0,type:"svchar",len:100,dec:60,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLOGONTO",fmt:0,gxz:"ZV21LogOnTo",gxold:"OV21LogOnTo",gxvar:"AV21LogOnTo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.AV21LogOnTo=n)},v2z:function(n){n!==undefined&&(gx.O.ZV21LogOnTo=n)},v2c:function(){gx.fn.setComboBoxValue("vLOGONTO",gx.O.AV21LogOnTo);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV21LogOnTo=this.val())},val:function(){return gx.fn.getControlValue("vLOGONTO")},nac:gx.falseFn,evt:"e140u2_client"};this.declareDomainHdlr(29,function(){});n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,lvl:0,type:"svchar",len:100,dec:60,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSERNAME",fmt:0,gxz:"ZV28UserName",gxold:"OV28UserName",gxvar:"AV28UserName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV28UserName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV28UserName=n)},v2c:function(){gx.fn.setControlValue("vUSERNAME",gx.O.AV28UserName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV28UserName=this.val())},val:function(){return gx.fn.getControlValue("vUSERNAME")},nac:gx.falseFn};this.declareDomainHdlr(33,function(){});n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,lvl:0,type:"char",len:50,dec:0,sign:!1,isPwd:!0,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSERPASSWORD",fmt:0,gxz:"ZV29UserPassword",gxold:"OV29UserPassword",gxvar:"AV29UserPassword",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV29UserPassword=n)},v2z:function(n){n!==undefined&&(gx.O.ZV29UserPassword=n)},v2c:function(){gx.fn.setControlValue("vUSERPASSWORD",gx.O.AV29UserPassword,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV29UserPassword=this.val())},val:function(){return gx.fn.getControlValue("vUSERPASSWORD")},nac:gx.falseFn};this.declareDomainHdlr(37,function(){});n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"TBFORGOTPWD",format:1,grid:0,ctrltype:"textblock"};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"KEEPMELOGGEDIN_CELL",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,lvl:0,type:"boolean",len:4,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vKEEPMELOGGEDIN",fmt:0,gxz:"ZV17KeepMeLoggedIn",gxold:"OV17KeepMeLoggedIn",gxvar:"AV17KeepMeLoggedIn",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",v2v:function(n){n!==undefined&&(gx.O.AV17KeepMeLoggedIn=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV17KeepMeLoggedIn=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setCheckBoxValue("vKEEPMELOGGEDIN",gx.O.AV17KeepMeLoggedIn,!0)},c2v:function(){this.val()!==undefined&&(gx.O.AV17KeepMeLoggedIn=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("vKEEPMELOGGEDIN")},nac:gx.falseFn,values:["true","false"]};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"REMEMBERME_CELL",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,lvl:0,type:"boolean",len:4,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vREMEMBERME",fmt:0,gxz:"ZV22RememberMe",gxold:"OV22RememberMe",gxvar:"AV22RememberMe",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",v2v:function(n){n!==undefined&&(gx.O.AV22RememberMe=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV22RememberMe=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setCheckBoxValue("vREMEMBERME",gx.O.AV22RememberMe,!0)},c2v:function(){this.val()!==undefined&&(gx.O.AV22RememberMe=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("vREMEMBERME")},nac:gx.falseFn,values:["true","false"]};n[49]={id:49,fld:"",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"BTNENTER",grid:0,evt:"e120u2_client",std:"ENTER"};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};n[58]={id:58,lvl:0,type:"svchar",len:2048,dec:250,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vURL",fmt:0,gxz:"ZV27URL",gxold:"OV27URL",gxvar:"AV27URL",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV27URL=n)},v2z:function(n){n!==undefined&&(gx.O.ZV27URL=n)},v2c:function(){gx.fn.setControlValue("vURL",gx.O.AV27URL,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV27URL=this.val())},val:function(){return gx.fn.getControlValue("vURL")},nac:gx.falseFn};this.declareDomainHdlr(58,function(){});this.AV43Logoappclient_GXI="";this.AV20LogoAppClient="";this.ZV20LogoAppClient="";this.OV20LogoAppClient="";this.AV21LogOnTo="";this.ZV21LogOnTo="";this.OV21LogOnTo="";this.AV28UserName="";this.ZV28UserName="";this.OV28UserName="";this.AV29UserPassword="";this.ZV29UserPassword="";this.OV29UserPassword="";this.AV17KeepMeLoggedIn=!1;this.ZV17KeepMeLoggedIn=!1;this.OV17KeepMeLoggedIn=!1;this.AV22RememberMe=!1;this.ZV22RememberMe=!1;this.OV22RememberMe=!1;this.AV27URL="";this.ZV27URL="";this.OV27URL="";this.AV20LogoAppClient="";this.AV21LogOnTo="";this.AV28UserName="";this.AV29UserPassword="";this.AV17KeepMeLoggedIn=!1;this.AV22RememberMe=!1;this.AV27URL="";this.AV13IDP_State="";this.AV18Language="";this.AV30UserRememberMe=0;this.Events={e120u2_client:["ENTER",!0],e140u2_client:["VLOGONTO.CLICK",!0],e170u2_client:["CANCEL",!0],e160u2_client:["'FORGOTPASSWORD'",!1]};this.EvtParms.REFRESH=[[{av:"AV13IDP_State",fld:"vIDP_STATE",pic:""},{av:"AV28UserName",fld:"vUSERNAME",pic:""},{av:"AV17KeepMeLoggedIn",fld:"vKEEPMELOGGEDIN",pic:""},{av:"AV22RememberMe",fld:"vREMEMBERME",pic:""},{av:"AV18Language",fld:"vLANGUAGE",pic:"",hsh:!0},{av:"AV30UserRememberMe",fld:"vUSERREMEMBERME",pic:"Z9",hsh:!0}],[{av:"AV13IDP_State",fld:"vIDP_STATE",pic:""},{av:"AV29UserPassword",fld:"vUSERPASSWORD",pic:""},{av:'gx.fn.getCtrlProperty("TABLELOGIN","Visible")',ctrl:"TABLELOGIN",prop:"Visible"},{av:"AV27URL",fld:"vURL",pic:""},{ctrl:"vLOGONTO"},{av:"AV21LogOnTo",fld:"vLOGONTO",pic:""},{av:"AV22RememberMe",fld:"vREMEMBERME",pic:""},{av:'gx.fn.getCtrlProperty("vKEEPMELOGGEDIN","Visible")',ctrl:"vKEEPMELOGGEDIN",prop:"Visible"},{av:'gx.fn.getCtrlProperty("vREMEMBERME","Visible")',ctrl:"vREMEMBERME",prop:"Visible"}]];this.EvtParms.ENTER=[[{av:"AV17KeepMeLoggedIn",fld:"vKEEPMELOGGEDIN",pic:""},{av:"AV22RememberMe",fld:"vREMEMBERME",pic:""},{av:"AV13IDP_State",fld:"vIDP_STATE",pic:""},{ctrl:"vLOGONTO"},{av:"AV21LogOnTo",fld:"vLOGONTO",pic:""},{av:"AV28UserName",fld:"vUSERNAME",pic:""},{av:"AV29UserPassword",fld:"vUSERPASSWORD",pic:""}],[{av:"AV13IDP_State",fld:"vIDP_STATE",pic:""},{av:"AV29UserPassword",fld:"vUSERPASSWORD",pic:""}]];this.EvtParms["VLOGONTO.CLICK"]=[[{av:"AV18Language",fld:"vLANGUAGE",pic:"",hsh:!0},{ctrl:"vLOGONTO"},{av:"AV21LogOnTo",fld:"vLOGONTO",pic:""}],[{av:'gx.fn.getCtrlProperty("vUSERPASSWORD","Visible")',ctrl:"vUSERPASSWORD",prop:"Visible"},{av:'gx.fn.getCtrlProperty("vUSERPASSWORD","Invitemessage")',ctrl:"vUSERPASSWORD",prop:"Invitemessage"},{ctrl:"BTNENTER",prop:"Caption"},{av:'gx.fn.getCtrlProperty("TBFORGOTPWD","Visible")',ctrl:"TBFORGOTPWD",prop:"Visible"},{av:'gx.fn.getCtrlProperty("vREMEMBERME","Visible")',ctrl:"vREMEMBERME",prop:"Visible"},{av:'gx.fn.getCtrlProperty("vKEEPMELOGGEDIN","Visible")',ctrl:"vKEEPMELOGGEDIN",prop:"Visible"}]];this.EvtParms["'FORGOTPASSWORD'"]=[[{av:"AV13IDP_State",fld:"vIDP_STATE",pic:""}],[{av:"AV13IDP_State",fld:"vIDP_STATE",pic:""}]];this.EnterCtrl=["BTNENTER"];this.setVCMap("AV13IDP_State","vIDP_STATE",0,"char",60,0);this.setVCMap("AV18Language","vLANGUAGE",0,"char",15,0);this.setVCMap("AV30UserRememberMe","vUSERREMEMBERME",0,"int",2,0);this.setVCMap("AV13IDP_State","vIDP_STATE",0,"char",60,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.gamremotelogin)})