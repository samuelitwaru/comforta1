gx.evt.autoSkip=!1;gx.define("wwpbaseobjects.masterpageframe",!1,function(){var i,t,r,n,u;this.ServerClass="wwpbaseobjects.masterpageframe";this.PackageName="GeneXus.Programs";this.ServerFullClass="wwpbaseobjects.masterpageframe.aspx";this.setObjectType("web");this.IsMasterPage=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){};this.e13172_client=function(){return this.executeServerEvent("ENTER_MPAGE",!0,null,!1,!1)};this.e14172_client=function(){return this.executeServerEvent("CANCEL_MPAGE",!0,null,!1,!1)};this.GXValidFnc=[];i=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,13,14,16,17,19,20,22,23,24,25];this.GXLastCtrlId=25;this.UCMESSAGE_MPAGEContainer=gx.uc.getNew(this,12,0,"DVelop_DVMessage","UCMESSAGE_MPAGEContainer","Ucmessage","UCMESSAGE_MPAGE");t=this.UCMESSAGE_MPAGEContainer;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("Width","Width","300","str");t.setProp("MinHeight","Minheight","16","str");t.setProp("StylingType","Stylingtype","fontawesome","str");t.setProp("DefaultMessageType","Defaultmessagetype","notice","str");t.setProp("StopOnError","Stoponerror",!0,"bool");t.setProp("TitleEscape","Titleescape",!1,"bool");t.setProp("TextEscape","Textescape",!1,"bool");t.setProp("ChangeNewLinesToBRs","Changenewlinestobrs",!0,"bool");t.setProp("Hide","Hide",!0,"bool");t.setProp("DelayUntilHide","Delayuntilhide",8e3,"num");t.setProp("MouseHideReset","Mousehidereset",!0,"bool");t.setProp("MessageAdditionalClasses","Messageadditionalclasses","","str");t.setProp("MessageCornerClass","Messagecornerclass","","str");t.setProp("Shadow","Shadow",!0,"bool");t.setProp("Opacity","Opacity","1","str");t.setProp("StackVerticalFirstPos","Stackverticalfirstpos",15,"num");t.setProp("StackHorizontalFirstPos","Stackhorizontalfirstpos",15,"num");t.setProp("StackVerticalSpacing","Stackverticalspacing",15,"num");t.setProp("StackHorizontalSpacing","Stackhorizontalspacing",15,"num");t.setProp("EffectIn","Effectin","fade","str");t.setProp("EffectOut","Effectout","fade","str");t.setProp("AnimationSpeed","Animationspeed",600,"num");t.setProp("StartPosition","Startposition","TopRight","str");t.setProp("NextMessagePosition","Nextmessageposition","down","str");t.setProp("Closer","Closer",!0,"bool");t.setProp("CloserHover","Closerhover",!0,"bool");t.setProp("Sticker","Sticker",!1,"bool");t.setProp("StickerHover","Stickerhover",!0,"bool");t.setProp("LabelCloseButton","Labelclosebutton","Close","str");t.setProp("LabelStickButton","Labelstickbutton","Stick","str");t.setProp("showEvenOnNonblock","Showevenonnonblock",!1,"bool");t.setProp("NonBlock","Nonblock",!1,"bool");t.setProp("NonBlockOpacity","Nonblockopacity",".2","str");t.setProp("EnableHistory","Enablehistory",!0,"bool");t.setProp("Menu","Menu",!1,"bool");t.setProp("FixedMenu","Fixedmenu",!0,"bool");t.setProp("MaxOnScreen","Maxonscreen","Infinity","str");t.setProp("LabelRedisplay","Labelredisplay","Redisplay","str");t.setProp("LabelAll","Labelall","All","str");t.setProp("LabelLast","Labellast","Last","str");t.setProp("Visible","Visible",!0,"bool");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);this.UCTOOLTIP_MPAGEContainer=gx.uc.getNew(this,15,0,"BootstrapTooltip","UCTOOLTIP_MPAGEContainer","Uctooltip","UCTOOLTIP_MPAGE");r=this.UCTOOLTIP_MPAGEContainer;r.setProp("Class","Class","","char");r.setProp("Enabled","Enabled",!0,"boolean");r.setProp("ClassSelector","Classselector","BootstrapTooltip","str");r.setProp("DefaultPosition","Defaultposition","bottom","str");r.setProp("LabelsShowDelay","Labelsshowdelay",300,"num");r.setProp("ButtonsShowDelay","Buttonsshowdelay",300,"num");r.setProp("InputsShowDelay","Inputsshowdelay",300,"num");r.setProp("ImagesShowDelay","Imagesshowdelay",0,"num");r.setProp("HideDelay","Hidedelay",0,"num");r.setProp("Visible","Visible",!0,"bool");r.setC2ShowFunction(function(n){n.show()});this.setUserControl(r);this.WWPUTILITIES_MPAGEContainer=gx.uc.getNew(this,18,0,"DVelop_WorkWithPlusUtilities","WWPUTILITIES_MPAGEContainer","Wwputilities","WWPUTILITIES_MPAGE");n=this.WWPUTILITIES_MPAGEContainer;n.setProp("Class","Class","","char");n.setProp("Enabled","Enabled",!0,"boolean");n.setProp("EnableAutoUpdateFromDocumentTitle","Enableautoupdatefromdocumenttitle",!1,"bool");n.setProp("EnableFixObjectFitCover","Enablefixobjectfitcover",!0,"bool");n.setProp("EnableFloatingLabels","Enablefloatinglabels",!1,"bool");n.setProp("EmpowerTabs","Empowertabs",!0,"bool");n.setProp("EnableUpdateRowSelectionStatus","Enableupdaterowselectionstatus",!0,"bool");n.setProp("CurrentTab_ReturnUrl","Currenttab_returnurl","","char");n.setProp("EnableConvertComboToBootstrapSelect","Enableconvertcombotobootstrapselect",!0,"bool");n.setProp("AllowColumnResizing","Allowcolumnresizing",!0,"bool");n.setProp("AllowColumnReordering","Allowcolumnreordering",!0,"bool");n.setProp("AllowColumnDragging","Allowcolumndragging",!0,"bool");n.setProp("AllowColumnsRestore","Allowcolumnsrestore",!0,"bool");n.setProp("RestoreColumnsIconClass","Restorecolumnsiconclass","fas fa-undo","str");n.setProp("PagBarIncludeGoTo","Pagbarincludegoto",!0,"bool");n.setProp("ComboLoadType","Comboloadtype","InfiniteScrolling","str");n.setProp("InfiniteScrollingPage","Infinitescrollingpage",10,"num");n.setProp("UpdateButtonText","Updatebuttontext","WWP_ColumnsSelectorButton","str");n.setProp("AddNewOption","Addnewoption","WWP_AddNewOption","str");n.setProp("OnlySelectedValues","Onlyselectedvalues","WWP_OnlySelectedValues","str");n.setProp("MultipleValuesSeparator","Multiplevaluesseparator",", ","str");n.setProp("SelectAll","Selectall","WWP_SelectAll","str");n.setProp("SortASC","Sortasc","WWP_TSSortASC","str");n.setProp("SortDSC","Sortdsc","WWP_TSSortDSC","str");n.setProp("AllowGroupText","Allowgrouptext","WWP_GroupByOption","str");n.setProp("FixLeftText","Fixlefttext","WWP_TSFixLeft","str");n.setProp("FixRightText","Fixrighttext","WWP_TSFixRight","str");n.setProp("LoadingData","Loadingdata","WWP_TSLoading","str");n.setProp("CleanFilter","Cleanfilter","WWP_TSCleanFilter","str");n.setProp("RangeFilterFrom","Rangefilterfrom","WWP_TSFrom","str");n.setProp("RangeFilterTo","Rangefilterto","WWP_TSTo","str");n.setProp("RangePickerInviteMessage","Rangepickerinvitemessage","WWP_TSRangePickerInviteMessage","str");n.setProp("NoResultsFound","Noresultsfound","WWP_TSNoResults","str");n.setProp("SearchButtonText","Searchbuttontext","WWP_TSSearchButtonCaption","str");n.setProp("SearchMultipleValuesButtonText","Searchmultiplevaluesbuttontext","WWP_FilterSelected","str");n.setProp("ColumnSelectorFixedLeftCategory","Columnselectorfixedleftcategory","WWP_ColumnSelectorFixedLeftCategory","str");n.setProp("ColumnSelectorFixedRightCategory","Columnselectorfixedrightcategory","WWP_ColumnSelectorFixedRightCategory","str");n.setProp("ColumnSelectorNotFixedCategory","Columnselectornotfixedcategory","WWP_ColumnSelectorNotFixedCategory","str");n.setProp("ColumnSelectorNoCategoryText","Columnselectornocategorytext","WWP_ColumnSelectorNoCategoryText","str");n.setProp("ColumnSelectorFixedEmpty","Columnselectorfixedempty","WWP_ColumnSelectorFixedEmpty","str");n.setProp("ColumnSelectorRestoreTooltip","Columnselectorrestoretooltip","WWP_SelectColumns_RestoreDefault","str");n.setProp("PagBarGoToCaption","Pagbargotocaption","WWP_PaginationBarGoToCaption","str");n.setProp("PagBarGoToIconClass","Pagbargotoiconclass","fas fa-redo","str");n.setProp("PagBarGoToTooltip","Pagbargototooltip","WWP_PaginationBarGoToTooltip","str");n.setProp("PagBarEmptyFilteredGridCaption","Pagbaremptyfilteredgridcaption","WWP_PaginationBarEmptyFilteredGridCaption","str");n.setProp("IncludeLineSeparator","Includelineseparator",!1,"bool");n.setProp("Visible","Visible",!0,"bool");n.setC2ShowFunction(function(n){n.show()});this.setUserControl(n);this.WWPDATEPICKER_MPAGEContainer=gx.uc.getNew(this,21,0,"WWP_DatePicker_UC","WWPDATEPICKER_MPAGEContainer","Wwpdatepicker","WWPDATEPICKER_MPAGE");u=this.WWPDATEPICKER_MPAGEContainer;u.setProp("Class","Class","","char");u.setProp("Enabled","Enabled",!0,"boolean");u.setProp("MinYear","Minyear",1970,"num");u.setProp("MaxYear","Maxyear",2040,"num");u.setProp("Style","Style","Light","str");u.setProp("Visible","Visible",!0,"bool");u.setC2ShowFunction(function(n){n.show()});this.setUserControl(u);i[2]={id:2,fld:"",grid:0};i[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};i[4]={id:4,fld:"",grid:0};i[5]={id:5,fld:"",grid:0};i[6]={id:6,fld:"TABLEMAIN",grid:0};i[7]={id:7,fld:"",grid:0};i[8]={id:8,fld:"",grid:0};i[10]={id:10,fld:"",grid:0};i[11]={id:11,fld:"",grid:0};i[13]={id:13,fld:"",grid:0};i[14]={id:14,fld:"",grid:0};i[16]={id:16,fld:"",grid:0};i[17]={id:17,fld:"",grid:0};i[19]={id:19,fld:"",grid:0};i[20]={id:20,fld:"",grid:0};i[22]={id:22,fld:"",grid:0};i[23]={id:23,fld:"",grid:0};i[24]={id:24,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};i[25]={id:25,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPICKERDUMMYVARIABLE_MPAGE",fmt:0,gxz:"ZV8PickerDummyVariable",gxold:"OV8PickerDummyVariable",gxvar:"AV8PickerDummyVariable",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8PickerDummyVariable=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV8PickerDummyVariable=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vPICKERDUMMYVARIABLE_MPAGE",gx.O.AV8PickerDummyVariable,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV8PickerDummyVariable=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vPICKERDUMMYVARIABLE_MPAGE")},nac:gx.falseFn};this.AV8PickerDummyVariable=gx.date.nullDate();this.Events={e13172_client:["ENTER_MPAGE",!0],e14172_client:["CANCEL_MPAGE",!0]};this.EvtParms.REFRESH_MPAGE=[[],[]];this.EvtParms.ENTER_MPAGE=[[],[]];this.Initialize()});gx.wi(function(){gx.createMasterPage(wwpbaseobjects.masterpageframe)})