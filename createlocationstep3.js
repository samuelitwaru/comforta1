gx.evt.autoSkip=!1;gx.define("createlocationstep3",!0,function(n){var t,u,i,r;this.ServerClass="createlocationstep3";this.PackageName="GeneXus.Programs";this.ServerFullClass="createlocationstep3.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV37CheckRequiredFieldsResult=gx.fn.getControlValue("vCHECKREQUIREDFIELDSRESULT");this.AV18HasValidationErrors=gx.fn.getControlValue("vHASVALIDATIONERRORS");this.AV25WebSessionKey=gx.fn.getControlValue("vWEBSESSIONKEY");this.AV20LocationReceptionistSDTs=gx.fn.getControlValue("vLOCATIONRECEPTIONISTSDTS");this.AV26WizardData=gx.fn.getControlValue("vWIZARDDATA");this.AV29CustomerLocation=gx.fn.getControlValue("vCUSTOMERLOCATION");this.AV21MyCustomer=gx.fn.getControlValue("vMYCUSTOMER");this.AV23PreviousStep=gx.fn.getControlValue("vPREVIOUSSTEP");this.AV14GoingBack=gx.fn.getControlValue("vGOINGBACK")};this.Validv_Customerlocationreceptionistemail=function(){return this.validCliEvt("Validv_Customerlocationreceptionistemail",0,function(){try{var n=gx.util.balloon.getNew("vCUSTOMERLOCATIONRECEPTIONISTEMAIL");if(this.AnyError=0,!gx.util.regExp.isMatch(this.AV8CustomerLocationReceptionistEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$"))try{n.setError(gx.text.format(gx.getMessage("GXM_DoesNotMatchRegExp"),gx.getMessage("Customer Location Receptionist Email"),"","","","","","","",""));this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Gxv5=function(){var n=gx.fn.currentGridRowImpl(51);return this.validCliEvt("Validv_Gxv5",51,function(){try{var n=gx.util.balloon.getNew("LOCATIONRECEPTIONISTSDTS__LOCATIONRECEPTIONISTEMAIL");if(this.AnyError=0,!gx.util.regExp.isMatch(this.GXV5,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$"))try{n.setError(gx.text.format(gx.getMessage("GXM_DoesNotMatchRegExp"),gx.getMessage("Location Receptionist Email"),"","","","","","","",""));this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.s152_client=function(){this.AV8CustomerLocationReceptionistEmail="";this.AV9CustomerLocationReceptionistGivenName="";this.AV12CustomerLocationReceptionistLastName="";this.AV13CustomerLocationReceptionistPhone="";this.AV7CustomerLocationReceptionistAddress=""};this.e112q2_client=function(){return this.executeServerEvent("GRIDSPAGINATIONBAR.CHANGEPAGE",!1,null,!0,!0)};this.e122q2_client=function(){return this.executeServerEvent("GRIDSPAGINATIONBAR.CHANGEROWSPERPAGE",!1,null,!0,!0)};this.e192q2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e132q2_client=function(){return this.executeServerEvent("'WIZARDPREVIOUS'",!1,null,!1,!1)};this.e142q2_client=function(){return this.executeServerEvent("'DOFINISH'",!1,null,!1,!1)};this.e152q2_client=function(){return this.executeServerEvent("'DOSAVEACTIONBTN'",!1,null,!1,!1)};this.e202q2_client=function(){return this.executeServerEvent("VDELETERECORD.CLICK",!0,arguments[0],!1,!1)};this.e212q2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,52,53,54,55,56,57,58,59,60,62,63,64,65,66,67,68,69,70,71,72,73,74,75];this.GXLastCtrlId=75;this.GridsContainer=new gx.grid.grid(this,2,"WbpLvl2",51,"Grids","Grids","GridsContainer",this.CmpContext,this.IsMasterPage,"createlocationstep3",[],!1,1,!1,!0,0,!1,!1,!1,"CollLocationReceptionistSDT",0,"px",0,"px",gx.getMessage("GXM_newrow"),!0,!1,!1,null,null,!1,"AV20LocationReceptionistSDTs",!1,[1,1,1,1],!1,0,!0,!1);u=this.GridsContainer;u.addSingleLineEdit("GXV2",52,"LOCATIONRECEPTIONISTSDTS__LOCATIONRECEPTIONISTGIVENNAME",gx.getMessage("Given Name"),"","LocationReceptionistGivenName","svchar",0,"px",40,40,"start",null,[],"GXV2","GXV2",!0,0,!1,!1,"Attribute",0,"WWColumn");u.addSingleLineEdit("GXV3",53,"LOCATIONRECEPTIONISTSDTS__LOCATIONRECEPTIONISTLASTNAME",gx.getMessage("Last Name"),"","LocationReceptionistLastName","svchar",0,"px",40,40,"start",null,[],"GXV3","GXV3",!0,0,!1,!1,"Attribute",0,"WWColumn");u.addSingleLineEdit("GXV4",54,"LOCATIONRECEPTIONISTSDTS__LOCATIONRECEPTIONISTINITIALS",gx.getMessage("Customer Location Receptionist Initials"),"","LocationReceptionistInitials","char",0,"px",20,20,"start",null,[],"GXV4","GXV4",!1,0,!1,!1,"Attribute",0,"WWColumn");u.addSingleLineEdit("GXV5",55,"LOCATIONRECEPTIONISTSDTS__LOCATIONRECEPTIONISTEMAIL",gx.getMessage("Email"),"","LocationReceptionistEmail","svchar",0,"px",100,80,"start",null,[],"GXV5","GXV5",!0,0,!1,!1,"Attribute",0,"WWColumn");u.addSingleLineEdit("GXV6",56,"LOCATIONRECEPTIONISTSDTS__LOCATIONRECEPTIONISTPHONE",gx.getMessage("Phone"),"","LocationReceptionistPhone","char",0,"px",20,20,"start",null,[],"GXV6","GXV6",!0,0,!1,!1,"Attribute",0,"WWColumn");u.addSingleLineEdit("GXV7",57,"LOCATIONRECEPTIONISTSDTS__LOCATIONRECEPTIONISTADDRESS",gx.getMessage("Address"),"","LocationReceptionistAddress","svchar",0,"px",1024,80,"start",null,[],"GXV7","GXV7",!0,0,!1,!1,"Attribute",0,"WWColumn");u.addSingleLineEdit("Deleterecord",58,"vDELETERECORD","",gx.getMessage("Delete Item"),"DeleteRecord","char",0,"px",20,20,"start","e202q2_client",[],"Deleterecord","DeleteRecord",!0,0,!1,!1,"Attribute",0,"WWIconActionColumn");this.GridsContainer.emptyText=gx.getMessage("");this.setGrid(u);this.GRIDSPAGINATIONBARContainer=gx.uc.getNew(this,61,20,"DVelop_DVPaginationBar",this.CmpContext+"GRIDSPAGINATIONBARContainer","Gridspaginationbar","GRIDSPAGINATIONBAR");i=this.GRIDSPAGINATIONBARContainer;i.setProp("Enabled","Enabled",!0,"boolean");i.setProp("Class","Class","PaginationBar","str");i.setProp("ShowFirst","Showfirst",!1,"bool");i.setProp("ShowPrevious","Showprevious",!0,"bool");i.setProp("ShowNext","Shownext",!0,"bool");i.setProp("ShowLast","Showlast",!1,"bool");i.setProp("PagesToShow","Pagestoshow",5,"num");i.setProp("PagingButtonsPosition","Pagingbuttonsposition","Right","str");i.setProp("PagingCaptionPosition","Pagingcaptionposition","Left","str");i.setProp("EmptyGridClass","Emptygridclass","PaginationBarEmptyGrid","str");i.setProp("SelectedPage","Selectedpage","","char");i.setProp("RowsPerPageSelector","Rowsperpageselector",!0,"bool");i.setDynProp("RowsPerPageSelectedValue","Rowsperpageselectedvalue",10,"num");i.setProp("RowsPerPageOptions","Rowsperpageoptions","5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50","str");i.setProp("First","First","First","str");i.setProp("Previous","Previous","WWP_PagingPreviousCaption","str");i.setProp("Next","Next","WWP_PagingNextCaption","str");i.setProp("Last","Last","Last","str");i.setProp("Caption","Caption",gx.getMessage("WWP_PagingCaption"),"str");i.setProp("EmptyGridCaption","Emptygridcaption","No receptionist record added","str");i.setProp("RowsPerPageCaption","Rowsperpagecaption","WWP_PagingRowsPerPage","str");i.addV2CFunction("AV16GridsCurrentPage","vGRIDSCURRENTPAGE","SetCurrentPage");i.addC2VFunction(function(n){n.ParentObject.AV16GridsCurrentPage=n.GetCurrentPage();gx.fn.setControlValue("vGRIDSCURRENTPAGE",n.ParentObject.AV16GridsCurrentPage)});i.addV2CFunction("AV17GridsPageCount","vGRIDSPAGECOUNT","SetPageCount");i.addC2VFunction(function(n){n.ParentObject.AV17GridsPageCount=n.GetPageCount();gx.fn.setControlValue("vGRIDSPAGECOUNT",n.ParentObject.AV17GridsPageCount)});i.setProp("RecordCount","Recordcount","","str");i.setProp("Page","Page","","str");i.addV2CFunction("AV15GridsAppliedFilters","vGRIDSAPPLIEDFILTERS","SetAppliedFilters");i.addC2VFunction(function(n){n.ParentObject.AV15GridsAppliedFilters=n.GetAppliedFilters();gx.fn.setControlValue("vGRIDSAPPLIEDFILTERS",n.ParentObject.AV15GridsAppliedFilters)});i.setProp("Visible","Visible",!0,"bool");i.setProp("Gx Control Type","Gxcontroltype","","int");i.setC2ShowFunction(function(n){n.show()});i.addEventHandler("ChangePage",this.e112q2_client);i.addEventHandler("ChangeRowsPerPage",this.e122q2_client);this.setUserControl(i);this.GRIDS_EMPOWERERContainer=gx.uc.getNew(this,76,20,"WWP_GridEmpowerer",this.CmpContext+"GRIDS_EMPOWERERContainer","Grids_empowerer","GRIDS_EMPOWERER");r=this.GRIDS_EMPOWERERContainer;r.setProp("Class","Class","","char");r.setProp("Enabled","Enabled",!0,"boolean");r.setDynProp("GridInternalName","Gridinternalname","","char");r.setProp("HasCategories","Hascategories",!1,"bool");r.setProp("InfiniteScrolling","Infinitescrolling","False","str");r.setProp("HasTitleSettings","Hastitlesettings",!1,"bool");r.setProp("HasColumnsSelector","Hascolumnsselector",!1,"bool");r.setProp("HasRowGroups","Hasrowgroups",!1,"bool");r.setProp("FixedColumns","Fixedcolumns","","str");r.setProp("PopoversInGrid","Popoversingrid","","str");r.setProp("Visible","Visible",!0,"bool");r.setC2ShowFunction(function(n){n.show()});this.setUserControl(r);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TABLEMAIN",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"TABLECONTENT",grid:0};t[13]={id:13,fld:"",grid:0};t[14]={id:14,fld:"",grid:0};t[15]={id:15,fld:"TABLEATTRIBUTES",grid:0};t[16]={id:16,fld:"",grid:0};t[17]={id:17,fld:"",grid:0};t[18]={id:18,fld:"",grid:0};t[19]={id:19,fld:"",grid:0};t[20]={id:20,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCUSTOMERLOCATIONRECEPTIONISTGIVENNAME",fmt:0,gxz:"ZV9CustomerLocationReceptionistGivenName",gxold:"OV9CustomerLocationReceptionistGivenName",gxvar:"AV9CustomerLocationReceptionistGivenName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV9CustomerLocationReceptionistGivenName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV9CustomerLocationReceptionistGivenName=n)},v2c:function(){gx.fn.setControlValue("vCUSTOMERLOCATIONRECEPTIONISTGIVENNAME",gx.O.AV9CustomerLocationReceptionistGivenName,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV9CustomerLocationReceptionistGivenName=this.val())},val:function(){return gx.fn.getControlValue("vCUSTOMERLOCATIONRECEPTIONISTGIVENNAME")},nac:gx.falseFn};t[21]={id:21,fld:"",grid:0};t[22]={id:22,fld:"",grid:0};t[23]={id:23,fld:"",grid:0};t[24]={id:24,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCUSTOMERLOCATIONRECEPTIONISTLASTNAME",fmt:0,gxz:"ZV12CustomerLocationReceptionistLastName",gxold:"OV12CustomerLocationReceptionistLastName",gxvar:"AV12CustomerLocationReceptionistLastName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV12CustomerLocationReceptionistLastName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12CustomerLocationReceptionistLastName=n)},v2c:function(){gx.fn.setControlValue("vCUSTOMERLOCATIONRECEPTIONISTLASTNAME",gx.O.AV12CustomerLocationReceptionistLastName,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV12CustomerLocationReceptionistLastName=this.val())},val:function(){return gx.fn.getControlValue("vCUSTOMERLOCATIONRECEPTIONISTLASTNAME")},nac:gx.falseFn};t[25]={id:25,fld:"",grid:0};t[26]={id:26,fld:"",grid:0};t[27]={id:27,fld:"",grid:0};t[28]={id:28,fld:"",grid:0};t[29]={id:29,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Customerlocationreceptionistemail,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCUSTOMERLOCATIONRECEPTIONISTEMAIL",fmt:0,gxz:"ZV8CustomerLocationReceptionistEmail",gxold:"OV8CustomerLocationReceptionistEmail",gxvar:"AV8CustomerLocationReceptionistEmail",ucs:[],op:[],ip:[29],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8CustomerLocationReceptionistEmail=n)},v2z:function(n){n!==undefined&&(gx.O.ZV8CustomerLocationReceptionistEmail=n)},v2c:function(){gx.fn.setControlValue("vCUSTOMERLOCATIONRECEPTIONISTEMAIL",gx.O.AV8CustomerLocationReceptionistEmail,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV8CustomerLocationReceptionistEmail=this.val())},val:function(){return gx.fn.getControlValue("vCUSTOMERLOCATIONRECEPTIONISTEMAIL")},nac:gx.falseFn,hasRVFmt:!0};t[30]={id:30,fld:"",grid:0};t[31]={id:31,fld:"",grid:0};t[32]={id:32,fld:"",grid:0};t[33]={id:33,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCUSTOMERLOCATIONRECEPTIONISTPHONE",fmt:0,gxz:"ZV13CustomerLocationReceptionistPhone",gxold:"OV13CustomerLocationReceptionistPhone",gxvar:"AV13CustomerLocationReceptionistPhone",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV13CustomerLocationReceptionistPhone=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13CustomerLocationReceptionistPhone=n)},v2c:function(){gx.fn.setControlValue("vCUSTOMERLOCATIONRECEPTIONISTPHONE",gx.O.AV13CustomerLocationReceptionistPhone,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV13CustomerLocationReceptionistPhone=this.val())},val:function(){return gx.fn.getControlValue("vCUSTOMERLOCATIONRECEPTIONISTPHONE")},nac:gx.falseFn};t[34]={id:34,fld:"",grid:0};t[35]={id:35,fld:"",grid:0};t[36]={id:36,fld:"",grid:0};t[37]={id:37,fld:"",grid:0};t[38]={id:38,lvl:0,type:"svchar",len:1024,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCUSTOMERLOCATIONRECEPTIONISTADDRESS",fmt:0,gxz:"ZV7CustomerLocationReceptionistAddress",gxold:"OV7CustomerLocationReceptionistAddress",gxvar:"AV7CustomerLocationReceptionistAddress",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7CustomerLocationReceptionistAddress=n)},v2z:function(n){n!==undefined&&(gx.O.ZV7CustomerLocationReceptionistAddress=n)},v2c:function(){gx.fn.setControlValue("vCUSTOMERLOCATIONRECEPTIONISTADDRESS",gx.O.AV7CustomerLocationReceptionistAddress,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV7CustomerLocationReceptionistAddress=this.val())},val:function(){return gx.fn.getControlValue("vCUSTOMERLOCATIONRECEPTIONISTADDRESS")},nac:gx.falseFn};t[39]={id:39,fld:"",grid:0};t[40]={id:40,fld:"",grid:0};t[41]={id:41,fld:"",grid:0};t[42]={id:42,fld:"UNNAMEDTABLE2",grid:0};t[43]={id:43,fld:"",grid:0};t[44]={id:44,fld:"BTNSAVEACTIONBTN",grid:0,evt:"e152q2_client"};t[45]={id:45,fld:"",grid:0};t[46]={id:46,fld:"",grid:0};t[47]={id:47,fld:"",grid:0};t[48]={id:48,fld:"GRIDSTABLEWITHPAGINATIONBAR",grid:0};t[49]={id:49,fld:"",grid:0};t[50]={id:50,fld:"",grid:0};t[52]={id:52,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:0,isacc:0,grid:51,gxgrid:this.GridsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LOCATIONRECEPTIONISTSDTS__LOCATIONRECEPTIONISTGIVENNAME",fmt:0,gxz:"ZV40GXV2",gxold:"OV40GXV2",gxvar:"GXV2",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.GXV2=n)},v2z:function(n){n!==undefined&&(gx.O.ZV40GXV2=n)},v2c:function(n){gx.fn.setGridControlValue("LOCATIONRECEPTIONISTSDTS__LOCATIONRECEPTIONISTGIVENNAME",n||gx.fn.currentGridRowImpl(51),gx.O.GXV2,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV2=this.val(n))},val:function(n){return gx.fn.getGridControlValue("LOCATIONRECEPTIONISTSDTS__LOCATIONRECEPTIONISTGIVENNAME",n||gx.fn.currentGridRowImpl(51))},nac:gx.falseFn};t[53]={id:53,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:0,isacc:0,grid:51,gxgrid:this.GridsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LOCATIONRECEPTIONISTSDTS__LOCATIONRECEPTIONISTLASTNAME",fmt:0,gxz:"ZV41GXV3",gxold:"OV41GXV3",gxvar:"GXV3",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.GXV3=n)},v2z:function(n){n!==undefined&&(gx.O.ZV41GXV3=n)},v2c:function(n){gx.fn.setGridControlValue("LOCATIONRECEPTIONISTSDTS__LOCATIONRECEPTIONISTLASTNAME",n||gx.fn.currentGridRowImpl(51),gx.O.GXV3,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV3=this.val(n))},val:function(n){return gx.fn.getGridControlValue("LOCATIONRECEPTIONISTSDTS__LOCATIONRECEPTIONISTLASTNAME",n||gx.fn.currentGridRowImpl(51))},nac:gx.falseFn};t[54]={id:54,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:51,gxgrid:this.GridsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LOCATIONRECEPTIONISTSDTS__LOCATIONRECEPTIONISTINITIALS",fmt:0,gxz:"ZV42GXV4",gxold:"OV42GXV4",gxvar:"GXV4",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.GXV4=n)},v2z:function(n){n!==undefined&&(gx.O.ZV42GXV4=n)},v2c:function(n){gx.fn.setGridControlValue("LOCATIONRECEPTIONISTSDTS__LOCATIONRECEPTIONISTINITIALS",n||gx.fn.currentGridRowImpl(51),gx.O.GXV4,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV4=this.val(n))},val:function(n){return gx.fn.getGridControlValue("LOCATIONRECEPTIONISTSDTS__LOCATIONRECEPTIONISTINITIALS",n||gx.fn.currentGridRowImpl(51))},nac:gx.falseFn};t[55]={id:55,lvl:2,type:"svchar",len:100,dec:0,sign:!1,ro:0,isacc:0,grid:51,gxgrid:this.GridsContainer,fnc:this.Validv_Gxv5,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LOCATIONRECEPTIONISTSDTS__LOCATIONRECEPTIONISTEMAIL",fmt:0,gxz:"ZV43GXV5",gxold:"OV43GXV5",gxvar:"GXV5",ucs:[],op:[],ip:[55],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.GXV5=n)},v2z:function(n){n!==undefined&&(gx.O.ZV43GXV5=n)},v2c:function(n){gx.fn.setGridControlValue("LOCATIONRECEPTIONISTSDTS__LOCATIONRECEPTIONISTEMAIL",n||gx.fn.currentGridRowImpl(51),gx.O.GXV5,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV5=this.val(n))},val:function(n){return gx.fn.getGridControlValue("LOCATIONRECEPTIONISTSDTS__LOCATIONRECEPTIONISTEMAIL",n||gx.fn.currentGridRowImpl(51))},nac:gx.falseFn};t[56]={id:56,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:51,gxgrid:this.GridsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LOCATIONRECEPTIONISTSDTS__LOCATIONRECEPTIONISTPHONE",fmt:0,gxz:"ZV44GXV6",gxold:"OV44GXV6",gxvar:"GXV6",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.GXV6=n)},v2z:function(n){n!==undefined&&(gx.O.ZV44GXV6=n)},v2c:function(n){gx.fn.setGridControlValue("LOCATIONRECEPTIONISTSDTS__LOCATIONRECEPTIONISTPHONE",n||gx.fn.currentGridRowImpl(51),gx.O.GXV6,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV6=this.val(n))},val:function(n){return gx.fn.getGridControlValue("LOCATIONRECEPTIONISTSDTS__LOCATIONRECEPTIONISTPHONE",n||gx.fn.currentGridRowImpl(51))},nac:gx.falseFn};t[57]={id:57,lvl:2,type:"svchar",len:1024,dec:0,sign:!1,ro:0,isacc:0,grid:51,gxgrid:this.GridsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LOCATIONRECEPTIONISTSDTS__LOCATIONRECEPTIONISTADDRESS",fmt:0,gxz:"ZV45GXV7",gxold:"OV45GXV7",gxvar:"GXV7",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.GXV7=n)},v2z:function(n){n!==undefined&&(gx.O.ZV45GXV7=n)},v2c:function(n){gx.fn.setGridControlValue("LOCATIONRECEPTIONISTSDTS__LOCATIONRECEPTIONISTADDRESS",n||gx.fn.currentGridRowImpl(51),gx.O.GXV7,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV7=this.val(n))},val:function(n){return gx.fn.getGridControlValue("LOCATIONRECEPTIONISTSDTS__LOCATIONRECEPTIONISTADDRESS",n||gx.fn.currentGridRowImpl(51))},nac:gx.falseFn};t[58]={id:58,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:51,gxgrid:this.GridsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDELETERECORD",fmt:1,gxz:"ZV34DeleteRecord",gxold:"OV34DeleteRecord",gxvar:"AV34DeleteRecord",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV34DeleteRecord=n)},v2z:function(n){n!==undefined&&(gx.O.ZV34DeleteRecord=n)},v2c:function(n){gx.fn.setGridControlValue("vDELETERECORD",n||gx.fn.currentGridRowImpl(51),gx.O.AV34DeleteRecord,1)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV34DeleteRecord=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDELETERECORD",n||gx.fn.currentGridRowImpl(51))},nac:gx.falseFn,evt:"e202q2_client"};t[59]={id:59,fld:"",grid:0};t[60]={id:60,fld:"",grid:0};t[62]={id:62,fld:"",grid:0};t[63]={id:63,fld:"",grid:0};t[64]={id:64,fld:"TABLEACTIONS",grid:0};t[65]={id:65,fld:"",grid:0};t[66]={id:66,fld:"",grid:0};t[67]={id:67,fld:"",grid:0};t[68]={id:68,fld:"BTNWIZARDPREVIOUS",grid:0,evt:"e132q2_client"};t[69]={id:69,fld:"",grid:0};t[70]={id:70,fld:"BTNFINISH",grid:0,evt:"e142q2_client"};t[71]={id:71,fld:"",grid:0};t[72]={id:72,fld:"",grid:0};t[73]={id:73,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};t[74]={id:74,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCUSTOMERLOCATIONRECEPTIONISTID",fmt:0,gxz:"ZV10CustomerLocationReceptionistId",gxold:"OV10CustomerLocationReceptionistId",gxvar:"AV10CustomerLocationReceptionistId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV10CustomerLocationReceptionistId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV10CustomerLocationReceptionistId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCUSTOMERLOCATIONRECEPTIONISTID",gx.O.AV10CustomerLocationReceptionistId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV10CustomerLocationReceptionistId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCUSTOMERLOCATIONRECEPTIONISTID",gx.thousandSeparator)},nac:gx.falseFn};t[75]={id:75,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCUSTOMERLOCATIONRECEPTIONISTINITIALS",fmt:0,gxz:"ZV11CustomerLocationReceptionistInitials",gxold:"OV11CustomerLocationReceptionistInitials",gxvar:"AV11CustomerLocationReceptionistInitials",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV11CustomerLocationReceptionistInitials=n)},v2z:function(n){n!==undefined&&(gx.O.ZV11CustomerLocationReceptionistInitials=n)},v2c:function(){gx.fn.setControlValue("vCUSTOMERLOCATIONRECEPTIONISTINITIALS",gx.O.AV11CustomerLocationReceptionistInitials,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV11CustomerLocationReceptionistInitials=this.val())},val:function(){return gx.fn.getControlValue("vCUSTOMERLOCATIONRECEPTIONISTINITIALS")},nac:gx.falseFn};this.AV9CustomerLocationReceptionistGivenName="";this.ZV9CustomerLocationReceptionistGivenName="";this.OV9CustomerLocationReceptionistGivenName="";this.AV12CustomerLocationReceptionistLastName="";this.ZV12CustomerLocationReceptionistLastName="";this.OV12CustomerLocationReceptionistLastName="";this.AV8CustomerLocationReceptionistEmail="";this.ZV8CustomerLocationReceptionistEmail="";this.OV8CustomerLocationReceptionistEmail="";this.AV13CustomerLocationReceptionistPhone="";this.ZV13CustomerLocationReceptionistPhone="";this.OV13CustomerLocationReceptionistPhone="";this.AV7CustomerLocationReceptionistAddress="";this.ZV7CustomerLocationReceptionistAddress="";this.OV7CustomerLocationReceptionistAddress="";this.ZV40GXV2="";this.OV40GXV2="";this.ZV41GXV3="";this.OV41GXV3="";this.ZV42GXV4="";this.OV42GXV4="";this.ZV43GXV5="";this.OV43GXV5="";this.ZV44GXV6="";this.OV44GXV6="";this.ZV45GXV7="";this.OV45GXV7="";this.ZV34DeleteRecord="";this.OV34DeleteRecord="";this.AV10CustomerLocationReceptionistId=0;this.ZV10CustomerLocationReceptionistId=0;this.OV10CustomerLocationReceptionistId=0;this.AV11CustomerLocationReceptionistInitials="";this.ZV11CustomerLocationReceptionistInitials="";this.OV11CustomerLocationReceptionistInitials="";this.AV9CustomerLocationReceptionistGivenName="";this.AV12CustomerLocationReceptionistLastName="";this.AV8CustomerLocationReceptionistEmail="";this.AV13CustomerLocationReceptionistPhone="";this.AV7CustomerLocationReceptionistAddress="";this.AV16GridsCurrentPage=0;this.AV10CustomerLocationReceptionistId=0;this.AV11CustomerLocationReceptionistInitials="";this.AV25WebSessionKey="";this.AV23PreviousStep="";this.AV14GoingBack=!1;this.GXV2="";this.GXV3="";this.GXV4="";this.GXV5="";this.GXV6="";this.GXV7="";this.AV34DeleteRecord="";this.AV20LocationReceptionistSDTs=[];this.AV37CheckRequiredFieldsResult=!1;this.AV18HasValidationErrors=!1;this.AV26WizardData={Step1:{CustomerLocationId:0,CustomerLocationEmail:"",CustomerLocationPhone:"",CustomerLocationPostalAddress:"",CustomerLocationVisitingAddress:""},Step2:{Grid:[]},Step3:{CustomerLocationReceptionistId:0,CustomerLocationReceptionistGivenName:"",CustomerLocationReceptionistLastName:"",CustomerLocationReceptionistInitials:"",CustomerLocationReceptionistEmail:"",CustomerLocationReceptionistPhone:"",CustomerLocationReceptionistAddress:"",LocationReceptionistSDTs:[]},AuxiliarData:[]};this.AV29CustomerLocation={CustomerLocationId:0,CustomerLocationVisitingAddress:"",CustomerLocationPostalAddress:"",CustomerLocationEmail:"",CustomerLocationPhone:"",CustomerLocationLastLine:0,Receptionist:[],Supplier_Agb:[],Supplier_Gen:[],Amenities:[],Mode:"",Modified:0,Initialized:0,CustomerLocationId_Z:0,CustomerLocationVisitingAddress_Z:"",CustomerLocationPostalAddress_Z:"",CustomerLocationEmail_Z:"",CustomerLocationPhone_Z:"",CustomerLocationLastLine_Z:0};this.AV21MyCustomer={CustomerId:0,CustomerKvkNumber:"",CustomerName:"",CustomerPostalAddress:"",CustomerEmail:"",CustomerVisitingAddress:"",CustomerPhone:"",CustomerVatNumber:"",CustomerTypeId:0,CustomerTypeName:"",CustomerLastLine:0,CustomerLastLineLocation:0,Manager:[],Locations:[],Mode:"",Initialized:0,CustomerId_Z:0,CustomerKvkNumber_Z:"",CustomerName_Z:"",CustomerPostalAddress_Z:"",CustomerEmail_Z:"",CustomerVisitingAddress_Z:"",CustomerPhone_Z:"",CustomerVatNumber_Z:"",CustomerTypeId_Z:0,CustomerTypeName_Z:"",CustomerLastLine_Z:0,CustomerLastLineLocation_Z:0};this.Events={e112q2_client:["GRIDSPAGINATIONBAR.CHANGEPAGE",!0],e122q2_client:["GRIDSPAGINATIONBAR.CHANGEROWSPERPAGE",!0],e192q2_client:["ENTER",!0],e132q2_client:["'WIZARDPREVIOUS'",!0],e142q2_client:["'DOFINISH'",!0],e152q2_client:["'DOSAVEACTIONBTN'",!0],e202q2_client:["VDELETERECORD.CLICK",!0],e212q2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRIDS_nFirstRecordOnPage"},{av:"GRIDS_nEOF"},{av:"AV20LocationReceptionistSDTs",fld:"vLOCATIONRECEPTIONISTSDTS",grid:51,pic:""},{av:"nGXsfl_51_idx",ctrl:"GRID",prop:"GridCurrRow",grid:51},{av:"nRC_GXsfl_51",ctrl:"GRIDS",prop:"GridRC",grid:51},{ctrl:"GRIDS",prop:"Rows"},{av:"sPrefix"},{av:"AV18HasValidationErrors",fld:"vHASVALIDATIONERRORS",pic:"",hsh:!0}],[{av:"AV16GridsCurrentPage",fld:"vGRIDSCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV17GridsPageCount",fld:"vGRIDSPAGECOUNT",pic:"ZZZZZZZZZ9"}]];this.EvtParms["GRIDS.LOAD"]=[[],[{av:"AV34DeleteRecord",fld:"vDELETERECORD",pic:""}]];this.EvtParms["GRIDSPAGINATIONBAR.CHANGEPAGE"]=[[{av:"GRIDS_nFirstRecordOnPage"},{av:"GRIDS_nEOF"},{av:"AV20LocationReceptionistSDTs",fld:"vLOCATIONRECEPTIONISTSDTS",grid:51,pic:""},{av:"nGXsfl_51_idx",ctrl:"GRID",prop:"GridCurrRow",grid:51},{av:"nRC_GXsfl_51",ctrl:"GRIDS",prop:"GridRC",grid:51},{ctrl:"GRIDS",prop:"Rows"},{av:"AV18HasValidationErrors",fld:"vHASVALIDATIONERRORS",pic:"",hsh:!0},{av:"sPrefix"},{av:"this.GRIDSPAGINATIONBARContainer.SelectedPage",ctrl:"GRIDSPAGINATIONBAR",prop:"SelectedPage"}],[]];this.EvtParms["GRIDSPAGINATIONBAR.CHANGEROWSPERPAGE"]=[[{av:"GRIDS_nFirstRecordOnPage"},{av:"GRIDS_nEOF"},{av:"AV20LocationReceptionistSDTs",fld:"vLOCATIONRECEPTIONISTSDTS",grid:51,pic:""},{av:"nGXsfl_51_idx",ctrl:"GRID",prop:"GridCurrRow",grid:51},{av:"nRC_GXsfl_51",ctrl:"GRIDS",prop:"GridRC",grid:51},{ctrl:"GRIDS",prop:"Rows"},{av:"AV18HasValidationErrors",fld:"vHASVALIDATIONERRORS",pic:"",hsh:!0},{av:"sPrefix"},{av:"this.GRIDSPAGINATIONBARContainer.RowsPerPageSelectedValue",ctrl:"GRIDSPAGINATIONBAR",prop:"RowsPerPageSelectedValue"}],[{ctrl:"GRIDS",prop:"Rows"}]];this.EvtParms.ENTER=[[{av:"AV37CheckRequiredFieldsResult",fld:"vCHECKREQUIREDFIELDSRESULT",pic:""},{av:"AV18HasValidationErrors",fld:"vHASVALIDATIONERRORS",pic:"",hsh:!0},{av:"AV25WebSessionKey",fld:"vWEBSESSIONKEY",pic:""},{av:"AV9CustomerLocationReceptionistGivenName",fld:"vCUSTOMERLOCATIONRECEPTIONISTGIVENNAME",pic:""},{av:"AV12CustomerLocationReceptionistLastName",fld:"vCUSTOMERLOCATIONRECEPTIONISTLASTNAME",pic:""},{av:"AV8CustomerLocationReceptionistEmail",fld:"vCUSTOMERLOCATIONRECEPTIONISTEMAIL",pic:""},{av:"AV13CustomerLocationReceptionistPhone",fld:"vCUSTOMERLOCATIONRECEPTIONISTPHONE",pic:""},{av:"AV10CustomerLocationReceptionistId",fld:"vCUSTOMERLOCATIONRECEPTIONISTID",pic:"ZZZ9"},{av:"AV11CustomerLocationReceptionistInitials",fld:"vCUSTOMERLOCATIONRECEPTIONISTINITIALS",pic:""},{av:"AV7CustomerLocationReceptionistAddress",fld:"vCUSTOMERLOCATIONRECEPTIONISTADDRESS",pic:""},{av:"AV20LocationReceptionistSDTs",fld:"vLOCATIONRECEPTIONISTSDTS",grid:51,pic:""},{av:"nGXsfl_51_idx",ctrl:"GRID",prop:"GridCurrRow",grid:51},{av:"GRIDS_nFirstRecordOnPage"},{av:"nRC_GXsfl_51",ctrl:"GRIDS",prop:"GridRC",grid:51},{av:"AV26WizardData",fld:"vWIZARDDATA",pic:""},{av:"AV29CustomerLocation",fld:"vCUSTOMERLOCATION",pic:""},{av:"AV21MyCustomer",fld:"vMYCUSTOMER",pic:""},{av:"GRIDS_nEOF"},{ctrl:"GRIDS",prop:"Rows"},{av:"sPrefix"}],[{av:"AV37CheckRequiredFieldsResult",fld:"vCHECKREQUIREDFIELDSRESULT",pic:""},{av:"AV26WizardData",fld:"vWIZARDDATA",pic:""},{av:"AV29CustomerLocation",fld:"vCUSTOMERLOCATION",pic:""},{av:"AV21MyCustomer",fld:"vMYCUSTOMER",pic:""},{av:"AV20LocationReceptionistSDTs",fld:"vLOCATIONRECEPTIONISTSDTS",grid:51,pic:""},{av:"nGXsfl_51_idx",ctrl:"GRID",prop:"GridCurrRow",grid:51},{av:"GRIDS_nFirstRecordOnPage"},{av:"nRC_GXsfl_51",ctrl:"GRIDS",prop:"GridRC",grid:51},{av:"AV8CustomerLocationReceptionistEmail",fld:"vCUSTOMERLOCATIONRECEPTIONISTEMAIL",pic:""},{av:"AV9CustomerLocationReceptionistGivenName",fld:"vCUSTOMERLOCATIONRECEPTIONISTGIVENNAME",pic:""},{av:"AV12CustomerLocationReceptionistLastName",fld:"vCUSTOMERLOCATIONRECEPTIONISTLASTNAME",pic:""},{av:"AV13CustomerLocationReceptionistPhone",fld:"vCUSTOMERLOCATIONRECEPTIONISTPHONE",pic:""},{av:"AV7CustomerLocationReceptionistAddress",fld:"vCUSTOMERLOCATIONRECEPTIONISTADDRESS",pic:""}]];this.EvtParms["'WIZARDPREVIOUS'"]=[[{av:"AV25WebSessionKey",fld:"vWEBSESSIONKEY",pic:""},{av:"AV10CustomerLocationReceptionistId",fld:"vCUSTOMERLOCATIONRECEPTIONISTID",pic:"ZZZ9"},{av:"AV9CustomerLocationReceptionistGivenName",fld:"vCUSTOMERLOCATIONRECEPTIONISTGIVENNAME",pic:""},{av:"AV12CustomerLocationReceptionistLastName",fld:"vCUSTOMERLOCATIONRECEPTIONISTLASTNAME",pic:""},{av:"AV11CustomerLocationReceptionistInitials",fld:"vCUSTOMERLOCATIONRECEPTIONISTINITIALS",pic:""},{av:"AV8CustomerLocationReceptionistEmail",fld:"vCUSTOMERLOCATIONRECEPTIONISTEMAIL",pic:""},{av:"AV13CustomerLocationReceptionistPhone",fld:"vCUSTOMERLOCATIONRECEPTIONISTPHONE",pic:""},{av:"AV7CustomerLocationReceptionistAddress",fld:"vCUSTOMERLOCATIONRECEPTIONISTADDRESS",pic:""},{av:"AV20LocationReceptionistSDTs",fld:"vLOCATIONRECEPTIONISTSDTS",grid:51,pic:""},{av:"nGXsfl_51_idx",ctrl:"GRID",prop:"GridCurrRow",grid:51},{av:"GRIDS_nFirstRecordOnPage"},{av:"nRC_GXsfl_51",ctrl:"GRIDS",prop:"GridRC",grid:51}],[{av:"AV26WizardData",fld:"vWIZARDDATA",pic:""}]];this.EvtParms["'DOFINISH'"]=[[{av:"AV20LocationReceptionistSDTs",fld:"vLOCATIONRECEPTIONISTSDTS",grid:51,pic:""},{av:"nGXsfl_51_idx",ctrl:"GRID",prop:"GridCurrRow",grid:51},{av:"GRIDS_nFirstRecordOnPage"},{av:"nRC_GXsfl_51",ctrl:"GRIDS",prop:"GridRC",grid:51},{av:"AV25WebSessionKey",fld:"vWEBSESSIONKEY",pic:""},{av:"AV10CustomerLocationReceptionistId",fld:"vCUSTOMERLOCATIONRECEPTIONISTID",pic:"ZZZ9"},{av:"AV9CustomerLocationReceptionistGivenName",fld:"vCUSTOMERLOCATIONRECEPTIONISTGIVENNAME",pic:""},{av:"AV12CustomerLocationReceptionistLastName",fld:"vCUSTOMERLOCATIONRECEPTIONISTLASTNAME",pic:""},{av:"AV11CustomerLocationReceptionistInitials",fld:"vCUSTOMERLOCATIONRECEPTIONISTINITIALS",pic:""},{av:"AV8CustomerLocationReceptionistEmail",fld:"vCUSTOMERLOCATIONRECEPTIONISTEMAIL",pic:""},{av:"AV13CustomerLocationReceptionistPhone",fld:"vCUSTOMERLOCATIONRECEPTIONISTPHONE",pic:""},{av:"AV7CustomerLocationReceptionistAddress",fld:"vCUSTOMERLOCATIONRECEPTIONISTADDRESS",pic:""},{av:"AV26WizardData",fld:"vWIZARDDATA",pic:""},{av:"AV29CustomerLocation",fld:"vCUSTOMERLOCATION",pic:""},{av:"AV21MyCustomer",fld:"vMYCUSTOMER",pic:""},{av:"GRIDS_nEOF"},{ctrl:"GRIDS",prop:"Rows"},{av:"sPrefix"},{av:"AV18HasValidationErrors",fld:"vHASVALIDATIONERRORS",pic:"",hsh:!0}],[{av:"AV26WizardData",fld:"vWIZARDDATA",pic:""},{av:"AV29CustomerLocation",fld:"vCUSTOMERLOCATION",pic:""},{av:"AV21MyCustomer",fld:"vMYCUSTOMER",pic:""},{av:"AV20LocationReceptionistSDTs",fld:"vLOCATIONRECEPTIONISTSDTS",grid:51,pic:""},{av:"nGXsfl_51_idx",ctrl:"GRID",prop:"GridCurrRow",grid:51},{av:"GRIDS_nFirstRecordOnPage"},{av:"nRC_GXsfl_51",ctrl:"GRIDS",prop:"GridRC",grid:51},{av:"AV8CustomerLocationReceptionistEmail",fld:"vCUSTOMERLOCATIONRECEPTIONISTEMAIL",pic:""},{av:"AV9CustomerLocationReceptionistGivenName",fld:"vCUSTOMERLOCATIONRECEPTIONISTGIVENNAME",pic:""},{av:"AV12CustomerLocationReceptionistLastName",fld:"vCUSTOMERLOCATIONRECEPTIONISTLASTNAME",pic:""},{av:"AV13CustomerLocationReceptionistPhone",fld:"vCUSTOMERLOCATIONRECEPTIONISTPHONE",pic:""},{av:"AV7CustomerLocationReceptionistAddress",fld:"vCUSTOMERLOCATIONRECEPTIONISTADDRESS",pic:""}]];this.EvtParms["'DOSAVEACTIONBTN'"]=[[{av:"AV37CheckRequiredFieldsResult",fld:"vCHECKREQUIREDFIELDSRESULT",pic:""},{av:"AV18HasValidationErrors",fld:"vHASVALIDATIONERRORS",pic:"",hsh:!0},{av:"AV20LocationReceptionistSDTs",fld:"vLOCATIONRECEPTIONISTSDTS",grid:51,pic:""},{av:"nGXsfl_51_idx",ctrl:"GRID",prop:"GridCurrRow",grid:51},{av:"GRIDS_nFirstRecordOnPage"},{av:"nRC_GXsfl_51",ctrl:"GRIDS",prop:"GridRC",grid:51},{av:"AV8CustomerLocationReceptionistEmail",fld:"vCUSTOMERLOCATIONRECEPTIONISTEMAIL",pic:""},{av:"AV9CustomerLocationReceptionistGivenName",fld:"vCUSTOMERLOCATIONRECEPTIONISTGIVENNAME",pic:""},{av:"AV12CustomerLocationReceptionistLastName",fld:"vCUSTOMERLOCATIONRECEPTIONISTLASTNAME",pic:""},{av:"AV11CustomerLocationReceptionistInitials",fld:"vCUSTOMERLOCATIONRECEPTIONISTINITIALS",pic:""},{av:"AV7CustomerLocationReceptionistAddress",fld:"vCUSTOMERLOCATIONRECEPTIONISTADDRESS",pic:""},{av:"AV13CustomerLocationReceptionistPhone",fld:"vCUSTOMERLOCATIONRECEPTIONISTPHONE",pic:""},{av:"GRIDS_nEOF"},{ctrl:"GRIDS",prop:"Rows"},{av:"sPrefix"}],[{av:"AV20LocationReceptionistSDTs",fld:"vLOCATIONRECEPTIONISTSDTS",grid:51,pic:""},{av:"nGXsfl_51_idx",ctrl:"GRID",prop:"GridCurrRow",grid:51},{av:"GRIDS_nFirstRecordOnPage"},{av:"nRC_GXsfl_51",ctrl:"GRIDS",prop:"GridRC",grid:51},{av:"AV37CheckRequiredFieldsResult",fld:"vCHECKREQUIREDFIELDSRESULT",pic:""},{av:"AV8CustomerLocationReceptionistEmail",fld:"vCUSTOMERLOCATIONRECEPTIONISTEMAIL",pic:""},{av:"AV9CustomerLocationReceptionistGivenName",fld:"vCUSTOMERLOCATIONRECEPTIONISTGIVENNAME",pic:""},{av:"AV12CustomerLocationReceptionistLastName",fld:"vCUSTOMERLOCATIONRECEPTIONISTLASTNAME",pic:""},{av:"AV13CustomerLocationReceptionistPhone",fld:"vCUSTOMERLOCATIONRECEPTIONISTPHONE",pic:""},{av:"AV7CustomerLocationReceptionistAddress",fld:"vCUSTOMERLOCATIONRECEPTIONISTADDRESS",pic:""}]];this.EvtParms["VDELETERECORD.CLICK"]=[[{av:"AV20LocationReceptionistSDTs",fld:"vLOCATIONRECEPTIONISTSDTS",grid:51,pic:""},{av:"nGXsfl_51_idx",ctrl:"GRID",prop:"GridCurrRow",grid:51},{av:"GRIDS_nFirstRecordOnPage"},{av:"nRC_GXsfl_51",ctrl:"GRIDS",prop:"GridRC",grid:51},{av:"GRIDS_nEOF"},{ctrl:"GRIDS",prop:"Rows"},{av:"sPrefix"},{av:"AV18HasValidationErrors",fld:"vHASVALIDATIONERRORS",pic:"",hsh:!0}],[{av:"AV20LocationReceptionistSDTs",fld:"vLOCATIONRECEPTIONISTSDTS",grid:51,pic:""},{av:"nGXsfl_51_idx",ctrl:"GRID",prop:"GridCurrRow",grid:51},{av:"GRIDS_nFirstRecordOnPage"},{av:"nRC_GXsfl_51",ctrl:"GRIDS",prop:"GridRC",grid:51}]];this.EvtParms.VALIDV_CUSTOMERLOCATIONRECEPTIONISTEMAIL=[[],[]];this.EvtParms.VALIDV_GXV5=[[{av:"GXV5",fld:"LOCATIONRECEPTIONISTSDTS__LOCATIONRECEPTIONISTEMAIL",pic:""}],[]];this.setVCMap("AV37CheckRequiredFieldsResult","vCHECKREQUIREDFIELDSRESULT",0,"boolean",4,0);this.setVCMap("AV18HasValidationErrors","vHASVALIDATIONERRORS",0,"boolean",4,0);this.setVCMap("AV25WebSessionKey","vWEBSESSIONKEY",0,"svchar",40,0);this.setVCMap("AV20LocationReceptionistSDTs","vLOCATIONRECEPTIONISTSDTS",0,"CollLocationReceptionistSDT",0,0);this.setVCMap("AV26WizardData","vWIZARDDATA",0,"CreateLocationData",0,0);this.setVCMap("AV29CustomerLocation","vCUSTOMERLOCATION",0,"Customer.Locations",0,0);this.setVCMap("AV21MyCustomer","vMYCUSTOMER",0,"Customer",0,0);this.setVCMap("AV23PreviousStep","vPREVIOUSSTEP",0,"svchar",40,0);this.setVCMap("AV14GoingBack","vGOINGBACK",0,"boolean",4,0);u.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grids"});u.addRefreshingVar({rfrVar:"AV18HasValidationErrors"});u.addRefreshingParm({rfrVar:"AV18HasValidationErrors"});this.addGridBCProperty("Locationreceptionistsdts",["LocationReceptionistGivenName"],this.GXValidFnc[52],"AV20LocationReceptionistSDTs");this.addGridBCProperty("Locationreceptionistsdts",["LocationReceptionistLastName"],this.GXValidFnc[53],"AV20LocationReceptionistSDTs");this.addGridBCProperty("Locationreceptionistsdts",["LocationReceptionistInitials"],this.GXValidFnc[54],"AV20LocationReceptionistSDTs");this.addGridBCProperty("Locationreceptionistsdts",["LocationReceptionistEmail"],this.GXValidFnc[55],"AV20LocationReceptionistSDTs");this.addGridBCProperty("Locationreceptionistsdts",["LocationReceptionistPhone"],this.GXValidFnc[56],"AV20LocationReceptionistSDTs");this.addGridBCProperty("Locationreceptionistsdts",["LocationReceptionistAddress"],this.GXValidFnc[57],"AV20LocationReceptionistSDTs");this.Initialize()})