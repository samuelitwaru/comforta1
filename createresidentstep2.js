gx.evt.autoSkip=!1;gx.define("createresidentstep2",!0,function(n){var t,u,i,r;this.ServerClass="createresidentstep2";this.PackageName="GeneXus.Programs";this.ServerFullClass="createresidentstep2.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV30CheckRequiredFieldsResult=gx.fn.getControlValue("vCHECKREQUIREDFIELDSRESULT");this.AV10HasValidationErrors=gx.fn.getControlValue("vHASVALIDATIONERRORS");this.AV25WebSessionKey=gx.fn.getControlValue("vWEBSESSIONKEY");this.AV22ResidentINIndividualSDTs=gx.fn.getControlValue("vRESIDENTININDIVIDUALSDTS");this.AV13PreviousStep=gx.fn.getControlValue("vPREVIOUSSTEP");this.AV6GoingBack=gx.fn.getControlValue("vGOINGBACK")};this.Validv_Residentinindividualgender=function(){return this.validCliEvt("Validv_Residentinindividualgender",0,function(){try{var n=gx.util.balloon.getNew("vRESIDENTININDIVIDUALGENDER");if(this.AnyError=0,!(gx.text.compare(this.AV17ResidentINIndividualGender,"Man")==0||gx.text.compare(this.AV17ResidentINIndividualGender,"Woman")==0||gx.text.compare(this.AV17ResidentINIndividualGender,"Other")==0))try{n.setError(gx.text.format(gx.getMessage("GXSPC_OutOfRange"),gx.getMessage("Resident INIndividual Gender"),"","","","","","","",""));this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Residentinindividualemail=function(){return this.validCliEvt("Validv_Residentinindividualemail",0,function(){try{var n=gx.util.balloon.getNew("vRESIDENTININDIVIDUALEMAIL");if(this.AnyError=0,!gx.util.regExp.isMatch(this.AV16ResidentINIndividualEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$"))try{n.setError(gx.text.format(gx.getMessage("GXM_DoesNotMatchRegExp"),gx.getMessage("Resident INIndividual Email"),"","","","","","","",""));this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Gxv5=function(){var n=gx.fn.currentGridRowImpl(57);return this.validCliEvt("Validv_Gxv5",57,function(){try{var n=gx.util.balloon.getNew("RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALEMAIL");if(this.AnyError=0,!gx.util.regExp.isMatch(this.GXV5,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$"))try{n.setError(gx.text.format(gx.getMessage("GXM_DoesNotMatchRegExp"),gx.getMessage("Resident INIndividual Email"),"","","","","","","",""));this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Gxv8=function(){var n=gx.fn.currentGridRowImpl(57);return this.validCliEvt("Validv_Gxv8",57,function(){try{var n=gx.util.balloon.getNew("RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALGENDER");if(this.AnyError=0,!(gx.text.compare(this.GXV8,"Man")==0||gx.text.compare(this.GXV8,"Woman")==0||gx.text.compare(this.GXV8,"Other")==0))try{n.setError(gx.text.format(gx.getMessage("GXSPC_OutOfRange"),gx.getMessage("Resident INIndividual Gender"),"","","","","","","",""));this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.s142_client=function(){this.AV15ResidentINIndividualBsnNumber="";this.AV18ResidentINIndividualGivenName="";this.AV20ResidentINIndividualLastName="";this.AV16ResidentINIndividualEmail="";this.AV21ResidentINIndividualPhone="";this.AV17ResidentINIndividualGender="";this.AV14ResidentINIndividualAddress=""};this.e112v2_client=function(){return this.executeServerEvent("GRIDSPAGINATIONBAR.CHANGEPAGE",!1,null,!0,!0)};this.e122v2_client=function(){return this.executeServerEvent("GRIDSPAGINATIONBAR.CHANGEROWSPERPAGE",!1,null,!0,!0)};this.e192v2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e132v2_client=function(){return this.executeServerEvent("'WIZARDPREVIOUS'",!1,null,!1,!1)};this.e142v2_client=function(){return this.executeServerEvent("'DONEXT'",!1,null,!1,!1)};this.e152v2_client=function(){return this.executeServerEvent("'DOSAVEINDIVIDUAL'",!1,null,!1,!1)};this.e202v2_client=function(){return this.executeServerEvent("VDELETERECORD.CLICK",!0,arguments[0],!1,!1)};this.e212v2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,58,59,60,61,62,63,64,65,66,67,69,70,71,72,73,74,75,76,77,78,79,80,81];this.GXLastCtrlId=81;this.GridsContainer=new gx.grid.grid(this,2,"WbpLvl2",57,"Grids","Grids","GridsContainer",this.CmpContext,this.IsMasterPage,"createresidentstep2",[],!1,1,!1,!0,0,!1,!1,!1,"CollResidentINIndividualSDT",0,"px",0,"px",gx.getMessage("GXM_newrow"),!0,!1,!1,null,null,!1,"AV22ResidentINIndividualSDTs",!1,[1,1,1,1],!1,0,!0,!1);u=this.GridsContainer;u.addSingleLineEdit("Deleterecord",58,"vDELETERECORD","",gx.getMessage("Delete"),"DeleteRecord","char",0,"px",20,20,"start","e202v2_client",[],"Deleterecord","DeleteRecord",!0,0,!1,!1,"Attribute",0,"WWIconActionColumn");u.addSingleLineEdit("GXV2",59,"RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALBSNNUMBER",gx.getMessage("Bsn Number"),"","ResidentINIndividualBsnNumber","svchar",0,"px",40,40,"start",null,[],"GXV2","GXV2",!0,0,!1,!1,"Attribute",0,"WWColumn");u.addSingleLineEdit("GXV3",60,"RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALGIVENNAME",gx.getMessage("Given Name"),"","ResidentINIndividualGivenName","svchar",0,"px",40,40,"start",null,[],"GXV3","GXV3",!0,0,!1,!1,"Attribute",0,"WWColumn");u.addSingleLineEdit("GXV4",61,"RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALLASTNAME",gx.getMessage("Last Name"),"","ResidentINIndividualLastName","svchar",0,"px",40,40,"start",null,[],"GXV4","GXV4",!0,0,!1,!1,"Attribute",0,"WWColumn");u.addSingleLineEdit("GXV5",62,"RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALEMAIL",gx.getMessage("Email"),"","ResidentINIndividualEmail","svchar",0,"px",100,80,"start",null,[],"GXV5","GXV5",!0,0,!1,!1,"Attribute",0,"WWColumn");u.addSingleLineEdit("GXV6",63,"RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALPHONE",gx.getMessage("Phone"),"","ResidentINIndividualPhone","char",0,"px",20,20,"start",null,[],"GXV6","GXV6",!0,0,!1,!1,"Attribute",0,"WWColumn");u.addSingleLineEdit("GXV7",64,"RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALADDRESS",gx.getMessage("Address"),"","ResidentINIndividualAddress","svchar",0,"px",1024,80,"start",null,[],"GXV7","GXV7",!0,0,!1,!1,"Attribute",0,"WWColumn");u.addComboBox("GXV8",65,"RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALGENDER",gx.getMessage("Gender"),"ResidentINIndividualGender","char",null,0,!0,!1,0,"px","WWColumn");this.GridsContainer.emptyText=gx.getMessage("");this.setGrid(u);this.GRIDSPAGINATIONBARContainer=gx.uc.getNew(this,68,20,"DVelop_DVPaginationBar",this.CmpContext+"GRIDSPAGINATIONBARContainer","Gridspaginationbar","GRIDSPAGINATIONBAR");i=this.GRIDSPAGINATIONBARContainer;i.setProp("Enabled","Enabled",!0,"boolean");i.setProp("Class","Class","PaginationBar","str");i.setProp("ShowFirst","Showfirst",!1,"bool");i.setProp("ShowPrevious","Showprevious",!0,"bool");i.setProp("ShowNext","Shownext",!0,"bool");i.setProp("ShowLast","Showlast",!1,"bool");i.setProp("PagesToShow","Pagestoshow",5,"num");i.setProp("PagingButtonsPosition","Pagingbuttonsposition","Right","str");i.setProp("PagingCaptionPosition","Pagingcaptionposition","Left","str");i.setProp("EmptyGridClass","Emptygridclass","PaginationBarEmptyGrid","str");i.setProp("SelectedPage","Selectedpage","","char");i.setProp("RowsPerPageSelector","Rowsperpageselector",!0,"bool");i.setDynProp("RowsPerPageSelectedValue","Rowsperpageselectedvalue",10,"num");i.setProp("RowsPerPageOptions","Rowsperpageoptions","5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50","str");i.setProp("First","First","First","str");i.setProp("Previous","Previous","WWP_PagingPreviousCaption","str");i.setProp("Next","Next","WWP_PagingNextCaption","str");i.setProp("Last","Last","Last","str");i.setProp("Caption","Caption",gx.getMessage("WWP_PagingCaption"),"str");i.setProp("EmptyGridCaption","Emptygridcaption","WWP_PagingEmptyGridCaption","str");i.setProp("RowsPerPageCaption","Rowsperpagecaption","WWP_PagingRowsPerPage","str");i.addV2CFunction("AV8GridsCurrentPage","vGRIDSCURRENTPAGE","SetCurrentPage");i.addC2VFunction(function(n){n.ParentObject.AV8GridsCurrentPage=n.GetCurrentPage();gx.fn.setControlValue("vGRIDSCURRENTPAGE",n.ParentObject.AV8GridsCurrentPage)});i.addV2CFunction("AV9GridsPageCount","vGRIDSPAGECOUNT","SetPageCount");i.addC2VFunction(function(n){n.ParentObject.AV9GridsPageCount=n.GetPageCount();gx.fn.setControlValue("vGRIDSPAGECOUNT",n.ParentObject.AV9GridsPageCount)});i.setProp("RecordCount","Recordcount","","str");i.setProp("Page","Page","","str");i.addV2CFunction("AV7GridsAppliedFilters","vGRIDSAPPLIEDFILTERS","SetAppliedFilters");i.addC2VFunction(function(n){n.ParentObject.AV7GridsAppliedFilters=n.GetAppliedFilters();gx.fn.setControlValue("vGRIDSAPPLIEDFILTERS",n.ParentObject.AV7GridsAppliedFilters)});i.setProp("Visible","Visible",!0,"bool");i.setProp("Gx Control Type","Gxcontroltype","","int");i.setC2ShowFunction(function(n){n.show()});i.addEventHandler("ChangePage",this.e112v2_client);i.addEventHandler("ChangeRowsPerPage",this.e122v2_client);this.setUserControl(i);this.GRIDS_EMPOWERERContainer=gx.uc.getNew(this,82,20,"WWP_GridEmpowerer",this.CmpContext+"GRIDS_EMPOWERERContainer","Grids_empowerer","GRIDS_EMPOWERER");r=this.GRIDS_EMPOWERERContainer;r.setProp("Class","Class","","char");r.setProp("Enabled","Enabled",!0,"boolean");r.setDynProp("GridInternalName","Gridinternalname","","char");r.setProp("HasCategories","Hascategories",!1,"bool");r.setProp("InfiniteScrolling","Infinitescrolling","False","str");r.setProp("HasTitleSettings","Hastitlesettings",!1,"bool");r.setProp("HasColumnsSelector","Hascolumnsselector",!1,"bool");r.setProp("HasRowGroups","Hasrowgroups",!1,"bool");r.setProp("FixedColumns","Fixedcolumns","","str");r.setProp("PopoversInGrid","Popoversingrid","","str");r.setProp("Visible","Visible",!0,"bool");r.setC2ShowFunction(function(n){n.show()});this.setUserControl(r);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TABLEMAIN",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"TABLECONTENT",grid:0};t[13]={id:13,fld:"",grid:0};t[14]={id:14,fld:"",grid:0};t[15]={id:15,fld:"TABLEATTRIBUTES",grid:0};t[16]={id:16,fld:"",grid:0};t[17]={id:17,fld:"",grid:0};t[18]={id:18,fld:"",grid:0};t[19]={id:19,fld:"",grid:0};t[20]={id:20,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vRESIDENTININDIVIDUALGIVENNAME",fmt:0,gxz:"ZV18ResidentINIndividualGivenName",gxold:"OV18ResidentINIndividualGivenName",gxvar:"AV18ResidentINIndividualGivenName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV18ResidentINIndividualGivenName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV18ResidentINIndividualGivenName=n)},v2c:function(){gx.fn.setControlValue("vRESIDENTININDIVIDUALGIVENNAME",gx.O.AV18ResidentINIndividualGivenName,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV18ResidentINIndividualGivenName=this.val())},val:function(){return gx.fn.getControlValue("vRESIDENTININDIVIDUALGIVENNAME")},nac:gx.falseFn};t[21]={id:21,fld:"",grid:0};t[22]={id:22,fld:"",grid:0};t[23]={id:23,fld:"",grid:0};t[24]={id:24,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vRESIDENTININDIVIDUALLASTNAME",fmt:0,gxz:"ZV20ResidentINIndividualLastName",gxold:"OV20ResidentINIndividualLastName",gxvar:"AV20ResidentINIndividualLastName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV20ResidentINIndividualLastName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV20ResidentINIndividualLastName=n)},v2c:function(){gx.fn.setControlValue("vRESIDENTININDIVIDUALLASTNAME",gx.O.AV20ResidentINIndividualLastName,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV20ResidentINIndividualLastName=this.val())},val:function(){return gx.fn.getControlValue("vRESIDENTININDIVIDUALLASTNAME")},nac:gx.falseFn};t[25]={id:25,fld:"",grid:0};t[26]={id:26,fld:"",grid:0};t[27]={id:27,fld:"",grid:0};t[28]={id:28,fld:"",grid:0};t[29]={id:29,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vRESIDENTININDIVIDUALBSNNUMBER",fmt:0,gxz:"ZV15ResidentINIndividualBsnNumber",gxold:"OV15ResidentINIndividualBsnNumber",gxvar:"AV15ResidentINIndividualBsnNumber",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV15ResidentINIndividualBsnNumber=n)},v2z:function(n){n!==undefined&&(gx.O.ZV15ResidentINIndividualBsnNumber=n)},v2c:function(){gx.fn.setControlValue("vRESIDENTININDIVIDUALBSNNUMBER",gx.O.AV15ResidentINIndividualBsnNumber,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV15ResidentINIndividualBsnNumber=this.val())},val:function(){return gx.fn.getControlValue("vRESIDENTININDIVIDUALBSNNUMBER")},nac:gx.falseFn};t[30]={id:30,fld:"",grid:0};t[31]={id:31,fld:"",grid:0};t[32]={id:32,fld:"",grid:0};t[33]={id:33,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Residentinindividualgender,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vRESIDENTININDIVIDUALGENDER",fmt:0,gxz:"ZV17ResidentINIndividualGender",gxold:"OV17ResidentINIndividualGender",gxvar:"AV17ResidentINIndividualGender",ucs:[],op:[33],ip:[33],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.AV17ResidentINIndividualGender=n)},v2z:function(n){n!==undefined&&(gx.O.ZV17ResidentINIndividualGender=n)},v2c:function(){gx.fn.setComboBoxValue("vRESIDENTININDIVIDUALGENDER",gx.O.AV17ResidentINIndividualGender)},c2v:function(){this.val()!==undefined&&(gx.O.AV17ResidentINIndividualGender=this.val())},val:function(){return gx.fn.getControlValue("vRESIDENTININDIVIDUALGENDER")},nac:gx.falseFn};t[34]={id:34,fld:"",grid:0};t[35]={id:35,fld:"",grid:0};t[36]={id:36,fld:"",grid:0};t[37]={id:37,fld:"",grid:0};t[38]={id:38,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Residentinindividualemail,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vRESIDENTININDIVIDUALEMAIL",fmt:0,gxz:"ZV16ResidentINIndividualEmail",gxold:"OV16ResidentINIndividualEmail",gxvar:"AV16ResidentINIndividualEmail",ucs:[],op:[],ip:[38],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV16ResidentINIndividualEmail=n)},v2z:function(n){n!==undefined&&(gx.O.ZV16ResidentINIndividualEmail=n)},v2c:function(){gx.fn.setControlValue("vRESIDENTININDIVIDUALEMAIL",gx.O.AV16ResidentINIndividualEmail,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV16ResidentINIndividualEmail=this.val())},val:function(){return gx.fn.getControlValue("vRESIDENTININDIVIDUALEMAIL")},nac:gx.falseFn,hasRVFmt:!0};t[39]={id:39,fld:"",grid:0};t[40]={id:40,fld:"",grid:0};t[41]={id:41,fld:"",grid:0};t[42]={id:42,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vRESIDENTININDIVIDUALPHONE",fmt:0,gxz:"ZV21ResidentINIndividualPhone",gxold:"OV21ResidentINIndividualPhone",gxvar:"AV21ResidentINIndividualPhone",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV21ResidentINIndividualPhone=n)},v2z:function(n){n!==undefined&&(gx.O.ZV21ResidentINIndividualPhone=n)},v2c:function(){gx.fn.setControlValue("vRESIDENTININDIVIDUALPHONE",gx.O.AV21ResidentINIndividualPhone,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV21ResidentINIndividualPhone=this.val())},val:function(){return gx.fn.getControlValue("vRESIDENTININDIVIDUALPHONE")},nac:gx.falseFn};t[43]={id:43,fld:"",grid:0};t[44]={id:44,fld:"",grid:0};t[45]={id:45,fld:"",grid:0};t[46]={id:46,fld:"",grid:0};t[47]={id:47,lvl:0,type:"svchar",len:1024,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vRESIDENTININDIVIDUALADDRESS",fmt:0,gxz:"ZV14ResidentINIndividualAddress",gxold:"OV14ResidentINIndividualAddress",gxvar:"AV14ResidentINIndividualAddress",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV14ResidentINIndividualAddress=n)},v2z:function(n){n!==undefined&&(gx.O.ZV14ResidentINIndividualAddress=n)},v2c:function(){gx.fn.setControlValue("vRESIDENTININDIVIDUALADDRESS",gx.O.AV14ResidentINIndividualAddress,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV14ResidentINIndividualAddress=this.val())},val:function(){return gx.fn.getControlValue("vRESIDENTININDIVIDUALADDRESS")},nac:gx.falseFn};t[48]={id:48,fld:"",grid:0};t[49]={id:49,fld:"ACTIONBTNTABLE",grid:0};t[50]={id:50,fld:"",grid:0};t[51]={id:51,fld:"BTNSAVEINDIVIDUAL",grid:0,evt:"e152v2_client"};t[52]={id:52,fld:"",grid:0};t[53]={id:53,fld:"",grid:0};t[54]={id:54,fld:"GRIDSTABLEWITHPAGINATIONBAR",grid:0};t[55]={id:55,fld:"",grid:0};t[56]={id:56,fld:"",grid:0};t[58]={id:58,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:57,gxgrid:this.GridsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDELETERECORD",fmt:1,gxz:"ZV27DeleteRecord",gxold:"OV27DeleteRecord",gxvar:"AV27DeleteRecord",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV27DeleteRecord=n)},v2z:function(n){n!==undefined&&(gx.O.ZV27DeleteRecord=n)},v2c:function(n){gx.fn.setGridControlValue("vDELETERECORD",n||gx.fn.currentGridRowImpl(57),gx.O.AV27DeleteRecord,1)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV27DeleteRecord=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDELETERECORD",n||gx.fn.currentGridRowImpl(57))},nac:gx.falseFn,evt:"e202v2_client"};t[59]={id:59,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:0,isacc:0,grid:57,gxgrid:this.GridsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALBSNNUMBER",fmt:0,gxz:"ZV33GXV2",gxold:"OV33GXV2",gxvar:"GXV2",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.GXV2=n)},v2z:function(n){n!==undefined&&(gx.O.ZV33GXV2=n)},v2c:function(n){gx.fn.setGridControlValue("RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALBSNNUMBER",n||gx.fn.currentGridRowImpl(57),gx.O.GXV2,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV2=this.val(n))},val:function(n){return gx.fn.getGridControlValue("RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALBSNNUMBER",n||gx.fn.currentGridRowImpl(57))},nac:gx.falseFn};t[60]={id:60,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:0,isacc:0,grid:57,gxgrid:this.GridsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALGIVENNAME",fmt:0,gxz:"ZV34GXV3",gxold:"OV34GXV3",gxvar:"GXV3",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.GXV3=n)},v2z:function(n){n!==undefined&&(gx.O.ZV34GXV3=n)},v2c:function(n){gx.fn.setGridControlValue("RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALGIVENNAME",n||gx.fn.currentGridRowImpl(57),gx.O.GXV3,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV3=this.val(n))},val:function(n){return gx.fn.getGridControlValue("RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALGIVENNAME",n||gx.fn.currentGridRowImpl(57))},nac:gx.falseFn};t[61]={id:61,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:0,isacc:0,grid:57,gxgrid:this.GridsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALLASTNAME",fmt:0,gxz:"ZV35GXV4",gxold:"OV35GXV4",gxvar:"GXV4",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.GXV4=n)},v2z:function(n){n!==undefined&&(gx.O.ZV35GXV4=n)},v2c:function(n){gx.fn.setGridControlValue("RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALLASTNAME",n||gx.fn.currentGridRowImpl(57),gx.O.GXV4,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV4=this.val(n))},val:function(n){return gx.fn.getGridControlValue("RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALLASTNAME",n||gx.fn.currentGridRowImpl(57))},nac:gx.falseFn};t[62]={id:62,lvl:2,type:"svchar",len:100,dec:0,sign:!1,ro:0,isacc:0,grid:57,gxgrid:this.GridsContainer,fnc:this.Validv_Gxv5,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALEMAIL",fmt:0,gxz:"ZV36GXV5",gxold:"OV36GXV5",gxvar:"GXV5",ucs:[],op:[],ip:[62],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.GXV5=n)},v2z:function(n){n!==undefined&&(gx.O.ZV36GXV5=n)},v2c:function(n){gx.fn.setGridControlValue("RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALEMAIL",n||gx.fn.currentGridRowImpl(57),gx.O.GXV5,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV5=this.val(n))},val:function(n){return gx.fn.getGridControlValue("RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALEMAIL",n||gx.fn.currentGridRowImpl(57))},nac:gx.falseFn};t[63]={id:63,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:57,gxgrid:this.GridsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALPHONE",fmt:0,gxz:"ZV37GXV6",gxold:"OV37GXV6",gxvar:"GXV6",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.GXV6=n)},v2z:function(n){n!==undefined&&(gx.O.ZV37GXV6=n)},v2c:function(n){gx.fn.setGridControlValue("RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALPHONE",n||gx.fn.currentGridRowImpl(57),gx.O.GXV6,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV6=this.val(n))},val:function(n){return gx.fn.getGridControlValue("RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALPHONE",n||gx.fn.currentGridRowImpl(57))},nac:gx.falseFn};t[64]={id:64,lvl:2,type:"svchar",len:1024,dec:0,sign:!1,ro:0,isacc:0,grid:57,gxgrid:this.GridsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALADDRESS",fmt:0,gxz:"ZV38GXV7",gxold:"OV38GXV7",gxvar:"GXV7",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.GXV7=n)},v2z:function(n){n!==undefined&&(gx.O.ZV38GXV7=n)},v2c:function(n){gx.fn.setGridControlValue("RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALADDRESS",n||gx.fn.currentGridRowImpl(57),gx.O.GXV7,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV7=this.val(n))},val:function(n){return gx.fn.getGridControlValue("RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALADDRESS",n||gx.fn.currentGridRowImpl(57))},nac:gx.falseFn};t[65]={id:65,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:57,gxgrid:this.GridsContainer,fnc:this.Validv_Gxv8,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALGENDER",fmt:0,gxz:"ZV39GXV8",gxold:"OV39GXV8",gxvar:"GXV8",ucs:[],op:[65],ip:[65],nacdep:[],ctrltype:"combo",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.GXV8=n)},v2z:function(n){n!==undefined&&(gx.O.ZV39GXV8=n)},v2c:function(n){gx.fn.setGridComboBoxValue("RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALGENDER",n||gx.fn.currentGridRowImpl(57),gx.O.GXV8)},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV8=this.val(n))},val:function(n){return gx.fn.getGridControlValue("RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALGENDER",n||gx.fn.currentGridRowImpl(57))},nac:gx.falseFn};t[66]={id:66,fld:"",grid:0};t[67]={id:67,fld:"",grid:0};t[69]={id:69,fld:"",grid:0};t[70]={id:70,fld:"",grid:0};t[71]={id:71,fld:"TABLEACTIONS",grid:0};t[72]={id:72,fld:"",grid:0};t[73]={id:73,fld:"",grid:0};t[74]={id:74,fld:"",grid:0};t[75]={id:75,fld:"BTNWIZARDPREVIOUS",grid:0,evt:"e132v2_client"};t[76]={id:76,fld:"",grid:0};t[77]={id:77,fld:"BTNNEXT",grid:0,evt:"e142v2_client"};t[78]={id:78,fld:"",grid:0};t[79]={id:79,fld:"",grid:0};t[80]={id:80,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};t[81]={id:81,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vRESIDENTININDIVIDUALID",fmt:0,gxz:"ZV19ResidentINIndividualId",gxold:"OV19ResidentINIndividualId",gxvar:"AV19ResidentINIndividualId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV19ResidentINIndividualId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV19ResidentINIndividualId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vRESIDENTININDIVIDUALID",gx.O.AV19ResidentINIndividualId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV19ResidentINIndividualId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vRESIDENTININDIVIDUALID",gx.thousandSeparator)},nac:gx.falseFn};this.AV18ResidentINIndividualGivenName="";this.ZV18ResidentINIndividualGivenName="";this.OV18ResidentINIndividualGivenName="";this.AV20ResidentINIndividualLastName="";this.ZV20ResidentINIndividualLastName="";this.OV20ResidentINIndividualLastName="";this.AV15ResidentINIndividualBsnNumber="";this.ZV15ResidentINIndividualBsnNumber="";this.OV15ResidentINIndividualBsnNumber="";this.AV17ResidentINIndividualGender="";this.ZV17ResidentINIndividualGender="";this.OV17ResidentINIndividualGender="";this.AV16ResidentINIndividualEmail="";this.ZV16ResidentINIndividualEmail="";this.OV16ResidentINIndividualEmail="";this.AV21ResidentINIndividualPhone="";this.ZV21ResidentINIndividualPhone="";this.OV21ResidentINIndividualPhone="";this.AV14ResidentINIndividualAddress="";this.ZV14ResidentINIndividualAddress="";this.OV14ResidentINIndividualAddress="";this.ZV27DeleteRecord="";this.OV27DeleteRecord="";this.ZV33GXV2="";this.OV33GXV2="";this.ZV34GXV3="";this.OV34GXV3="";this.ZV35GXV4="";this.OV35GXV4="";this.ZV36GXV5="";this.OV36GXV5="";this.ZV37GXV6="";this.OV37GXV6="";this.ZV38GXV7="";this.OV38GXV7="";this.ZV39GXV8="";this.OV39GXV8="";this.AV19ResidentINIndividualId=0;this.ZV19ResidentINIndividualId=0;this.OV19ResidentINIndividualId=0;this.AV18ResidentINIndividualGivenName="";this.AV20ResidentINIndividualLastName="";this.AV15ResidentINIndividualBsnNumber="";this.AV17ResidentINIndividualGender="";this.AV16ResidentINIndividualEmail="";this.AV21ResidentINIndividualPhone="";this.AV14ResidentINIndividualAddress="";this.AV8GridsCurrentPage=0;this.AV19ResidentINIndividualId=0;this.AV25WebSessionKey="";this.AV13PreviousStep="";this.AV6GoingBack=!1;this.AV27DeleteRecord="";this.GXV2="";this.GXV3="";this.GXV4="";this.GXV5="";this.GXV6="";this.GXV7="";this.GXV8="";this.AV22ResidentINIndividualSDTs=[];this.AV30CheckRequiredFieldsResult=!1;this.AV10HasValidationErrors=!1;this.Events={e112v2_client:["GRIDSPAGINATIONBAR.CHANGEPAGE",!0],e122v2_client:["GRIDSPAGINATIONBAR.CHANGEROWSPERPAGE",!0],e192v2_client:["ENTER",!0],e132v2_client:["'WIZARDPREVIOUS'",!0],e142v2_client:["'DONEXT'",!0],e152v2_client:["'DOSAVEINDIVIDUAL'",!0],e202v2_client:["VDELETERECORD.CLICK",!0],e212v2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRIDS_nFirstRecordOnPage"},{av:"GRIDS_nEOF"},{av:"AV22ResidentINIndividualSDTs",fld:"vRESIDENTININDIVIDUALSDTS",grid:57,pic:""},{av:"nGXsfl_57_idx",ctrl:"GRID",prop:"GridCurrRow",grid:57},{av:"nRC_GXsfl_57",ctrl:"GRIDS",prop:"GridRC",grid:57},{ctrl:"GRIDS",prop:"Rows"},{av:"sPrefix"},{av:"AV10HasValidationErrors",fld:"vHASVALIDATIONERRORS",pic:"",hsh:!0}],[{av:"AV8GridsCurrentPage",fld:"vGRIDSCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV9GridsPageCount",fld:"vGRIDSPAGECOUNT",pic:"ZZZZZZZZZ9"}]];this.EvtParms["GRIDS.LOAD"]=[[],[{av:"AV27DeleteRecord",fld:"vDELETERECORD",pic:""}]];this.EvtParms["GRIDSPAGINATIONBAR.CHANGEPAGE"]=[[{av:"GRIDS_nFirstRecordOnPage"},{av:"GRIDS_nEOF"},{av:"AV22ResidentINIndividualSDTs",fld:"vRESIDENTININDIVIDUALSDTS",grid:57,pic:""},{av:"nGXsfl_57_idx",ctrl:"GRID",prop:"GridCurrRow",grid:57},{av:"nRC_GXsfl_57",ctrl:"GRIDS",prop:"GridRC",grid:57},{ctrl:"GRIDS",prop:"Rows"},{av:"AV10HasValidationErrors",fld:"vHASVALIDATIONERRORS",pic:"",hsh:!0},{av:"sPrefix"},{av:"this.GRIDSPAGINATIONBARContainer.SelectedPage",ctrl:"GRIDSPAGINATIONBAR",prop:"SelectedPage"}],[]];this.EvtParms["GRIDSPAGINATIONBAR.CHANGEROWSPERPAGE"]=[[{av:"GRIDS_nFirstRecordOnPage"},{av:"GRIDS_nEOF"},{av:"AV22ResidentINIndividualSDTs",fld:"vRESIDENTININDIVIDUALSDTS",grid:57,pic:""},{av:"nGXsfl_57_idx",ctrl:"GRID",prop:"GridCurrRow",grid:57},{av:"nRC_GXsfl_57",ctrl:"GRIDS",prop:"GridRC",grid:57},{ctrl:"GRIDS",prop:"Rows"},{av:"AV10HasValidationErrors",fld:"vHASVALIDATIONERRORS",pic:"",hsh:!0},{av:"sPrefix"},{av:"this.GRIDSPAGINATIONBARContainer.RowsPerPageSelectedValue",ctrl:"GRIDSPAGINATIONBAR",prop:"RowsPerPageSelectedValue"}],[{ctrl:"GRIDS",prop:"Rows"}]];this.EvtParms.ENTER=[[{av:"AV30CheckRequiredFieldsResult",fld:"vCHECKREQUIREDFIELDSRESULT",pic:""},{av:"AV10HasValidationErrors",fld:"vHASVALIDATIONERRORS",pic:"",hsh:!0},{av:"AV18ResidentINIndividualGivenName",fld:"vRESIDENTININDIVIDUALGIVENNAME",pic:""},{av:"AV20ResidentINIndividualLastName",fld:"vRESIDENTININDIVIDUALLASTNAME",pic:""},{av:"AV15ResidentINIndividualBsnNumber",fld:"vRESIDENTININDIVIDUALBSNNUMBER",pic:""},{ctrl:"vRESIDENTININDIVIDUALGENDER"},{av:"AV17ResidentINIndividualGender",fld:"vRESIDENTININDIVIDUALGENDER",pic:""},{av:"AV25WebSessionKey",fld:"vWEBSESSIONKEY",pic:""},{av:"AV19ResidentINIndividualId",fld:"vRESIDENTININDIVIDUALID",pic:"ZZZ9"},{av:"AV16ResidentINIndividualEmail",fld:"vRESIDENTININDIVIDUALEMAIL",pic:""},{av:"AV21ResidentINIndividualPhone",fld:"vRESIDENTININDIVIDUALPHONE",pic:""},{av:"AV14ResidentINIndividualAddress",fld:"vRESIDENTININDIVIDUALADDRESS",pic:""},{av:"AV22ResidentINIndividualSDTs",fld:"vRESIDENTININDIVIDUALSDTS",grid:57,pic:""},{av:"nGXsfl_57_idx",ctrl:"GRID",prop:"GridCurrRow",grid:57},{av:"GRIDS_nFirstRecordOnPage"},{av:"nRC_GXsfl_57",ctrl:"GRIDS",prop:"GridRC",grid:57}],[{av:"AV30CheckRequiredFieldsResult",fld:"vCHECKREQUIREDFIELDSRESULT",pic:""}]];this.EvtParms["'WIZARDPREVIOUS'"]=[[{av:"AV25WebSessionKey",fld:"vWEBSESSIONKEY",pic:""},{av:"AV19ResidentINIndividualId",fld:"vRESIDENTININDIVIDUALID",pic:"ZZZ9"},{av:"AV18ResidentINIndividualGivenName",fld:"vRESIDENTININDIVIDUALGIVENNAME",pic:""},{av:"AV20ResidentINIndividualLastName",fld:"vRESIDENTININDIVIDUALLASTNAME",pic:""},{av:"AV15ResidentINIndividualBsnNumber",fld:"vRESIDENTININDIVIDUALBSNNUMBER",pic:""},{ctrl:"vRESIDENTININDIVIDUALGENDER"},{av:"AV17ResidentINIndividualGender",fld:"vRESIDENTININDIVIDUALGENDER",pic:""},{av:"AV16ResidentINIndividualEmail",fld:"vRESIDENTININDIVIDUALEMAIL",pic:""},{av:"AV21ResidentINIndividualPhone",fld:"vRESIDENTININDIVIDUALPHONE",pic:""},{av:"AV14ResidentINIndividualAddress",fld:"vRESIDENTININDIVIDUALADDRESS",pic:""},{av:"AV22ResidentINIndividualSDTs",fld:"vRESIDENTININDIVIDUALSDTS",grid:57,pic:""},{av:"nGXsfl_57_idx",ctrl:"GRID",prop:"GridCurrRow",grid:57},{av:"GRIDS_nFirstRecordOnPage"},{av:"nRC_GXsfl_57",ctrl:"GRIDS",prop:"GridRC",grid:57}],[]];this.EvtParms["'DONEXT'"]=[[{av:"AV25WebSessionKey",fld:"vWEBSESSIONKEY",pic:""},{av:"AV19ResidentINIndividualId",fld:"vRESIDENTININDIVIDUALID",pic:"ZZZ9"},{av:"AV18ResidentINIndividualGivenName",fld:"vRESIDENTININDIVIDUALGIVENNAME",pic:""},{av:"AV20ResidentINIndividualLastName",fld:"vRESIDENTININDIVIDUALLASTNAME",pic:""},{av:"AV15ResidentINIndividualBsnNumber",fld:"vRESIDENTININDIVIDUALBSNNUMBER",pic:""},{ctrl:"vRESIDENTININDIVIDUALGENDER"},{av:"AV17ResidentINIndividualGender",fld:"vRESIDENTININDIVIDUALGENDER",pic:""},{av:"AV16ResidentINIndividualEmail",fld:"vRESIDENTININDIVIDUALEMAIL",pic:""},{av:"AV21ResidentINIndividualPhone",fld:"vRESIDENTININDIVIDUALPHONE",pic:""},{av:"AV14ResidentINIndividualAddress",fld:"vRESIDENTININDIVIDUALADDRESS",pic:""},{av:"AV22ResidentINIndividualSDTs",fld:"vRESIDENTININDIVIDUALSDTS",grid:57,pic:""},{av:"nGXsfl_57_idx",ctrl:"GRID",prop:"GridCurrRow",grid:57},{av:"GRIDS_nFirstRecordOnPage"},{av:"nRC_GXsfl_57",ctrl:"GRIDS",prop:"GridRC",grid:57}],[]];this.EvtParms["'DOSAVEINDIVIDUAL'"]=[[{av:"AV30CheckRequiredFieldsResult",fld:"vCHECKREQUIREDFIELDSRESULT",pic:""},{av:"AV10HasValidationErrors",fld:"vHASVALIDATIONERRORS",pic:"",hsh:!0},{av:"AV22ResidentINIndividualSDTs",fld:"vRESIDENTININDIVIDUALSDTS",grid:57,pic:""},{av:"nGXsfl_57_idx",ctrl:"GRID",prop:"GridCurrRow",grid:57},{av:"GRIDS_nFirstRecordOnPage"},{av:"nRC_GXsfl_57",ctrl:"GRIDS",prop:"GridRC",grid:57},{av:"AV15ResidentINIndividualBsnNumber",fld:"vRESIDENTININDIVIDUALBSNNUMBER",pic:""},{av:"AV18ResidentINIndividualGivenName",fld:"vRESIDENTININDIVIDUALGIVENNAME",pic:""},{av:"AV20ResidentINIndividualLastName",fld:"vRESIDENTININDIVIDUALLASTNAME",pic:""},{av:"AV16ResidentINIndividualEmail",fld:"vRESIDENTININDIVIDUALEMAIL",pic:""},{av:"AV21ResidentINIndividualPhone",fld:"vRESIDENTININDIVIDUALPHONE",pic:""},{ctrl:"vRESIDENTININDIVIDUALGENDER"},{av:"AV17ResidentINIndividualGender",fld:"vRESIDENTININDIVIDUALGENDER",pic:""},{av:"AV14ResidentINIndividualAddress",fld:"vRESIDENTININDIVIDUALADDRESS",pic:""},{av:"GRIDS_nEOF"},{ctrl:"GRIDS",prop:"Rows"},{av:"sPrefix"}],[{av:"AV22ResidentINIndividualSDTs",fld:"vRESIDENTININDIVIDUALSDTS",grid:57,pic:""},{av:"nGXsfl_57_idx",ctrl:"GRID",prop:"GridCurrRow",grid:57},{av:"GRIDS_nFirstRecordOnPage"},{av:"nRC_GXsfl_57",ctrl:"GRIDS",prop:"GridRC",grid:57},{av:"AV30CheckRequiredFieldsResult",fld:"vCHECKREQUIREDFIELDSRESULT",pic:""},{av:"AV15ResidentINIndividualBsnNumber",fld:"vRESIDENTININDIVIDUALBSNNUMBER",pic:""},{av:"AV18ResidentINIndividualGivenName",fld:"vRESIDENTININDIVIDUALGIVENNAME",pic:""},{av:"AV20ResidentINIndividualLastName",fld:"vRESIDENTININDIVIDUALLASTNAME",pic:""},{av:"AV16ResidentINIndividualEmail",fld:"vRESIDENTININDIVIDUALEMAIL",pic:""},{av:"AV21ResidentINIndividualPhone",fld:"vRESIDENTININDIVIDUALPHONE",pic:""},{ctrl:"vRESIDENTININDIVIDUALGENDER"},{av:"AV17ResidentINIndividualGender",fld:"vRESIDENTININDIVIDUALGENDER",pic:""},{av:"AV14ResidentINIndividualAddress",fld:"vRESIDENTININDIVIDUALADDRESS",pic:""}]];this.EvtParms["VDELETERECORD.CLICK"]=[[{av:"AV22ResidentINIndividualSDTs",fld:"vRESIDENTININDIVIDUALSDTS",grid:57,pic:""},{av:"nGXsfl_57_idx",ctrl:"GRID",prop:"GridCurrRow",grid:57},{av:"GRIDS_nFirstRecordOnPage"},{av:"nRC_GXsfl_57",ctrl:"GRIDS",prop:"GridRC",grid:57},{av:"GRIDS_nEOF"},{ctrl:"GRIDS",prop:"Rows"},{av:"sPrefix"},{av:"AV10HasValidationErrors",fld:"vHASVALIDATIONERRORS",pic:"",hsh:!0}],[{av:"AV22ResidentINIndividualSDTs",fld:"vRESIDENTININDIVIDUALSDTS",grid:57,pic:""},{av:"nGXsfl_57_idx",ctrl:"GRID",prop:"GridCurrRow",grid:57},{av:"GRIDS_nFirstRecordOnPage"},{av:"nRC_GXsfl_57",ctrl:"GRIDS",prop:"GridRC",grid:57}]];this.EvtParms.VALIDV_RESIDENTININDIVIDUALGENDER=[[],[]];this.EvtParms.VALIDV_RESIDENTININDIVIDUALEMAIL=[[],[]];this.EvtParms.VALIDV_GXV5=[[{av:"GXV5",fld:"RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALEMAIL",pic:""}],[]];this.EvtParms.VALIDV_GXV8=[[{ctrl:"RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALGENDER"},{av:"GXV8",fld:"RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALGENDER",pic:""}],[{ctrl:"RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALGENDER"},{av:"GXV8",fld:"RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALGENDER",pic:""}]];this.setVCMap("AV30CheckRequiredFieldsResult","vCHECKREQUIREDFIELDSRESULT",0,"boolean",4,0);this.setVCMap("AV10HasValidationErrors","vHASVALIDATIONERRORS",0,"boolean",4,0);this.setVCMap("AV25WebSessionKey","vWEBSESSIONKEY",0,"svchar",40,0);this.setVCMap("AV22ResidentINIndividualSDTs","vRESIDENTININDIVIDUALSDTS",0,"CollResidentINIndividualSDT",0,0);this.setVCMap("AV13PreviousStep","vPREVIOUSSTEP",0,"svchar",40,0);this.setVCMap("AV6GoingBack","vGOINGBACK",0,"boolean",4,0);u.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grids"});u.addRefreshingVar({rfrVar:"AV10HasValidationErrors"});u.addRefreshingParm({rfrVar:"AV10HasValidationErrors"});this.addGridBCProperty("Residentinindividualsdts",["ResidentINIndividualBsnNumber"],this.GXValidFnc[59],"AV22ResidentINIndividualSDTs");this.addGridBCProperty("Residentinindividualsdts",["ResidentINIndividualGivenName"],this.GXValidFnc[60],"AV22ResidentINIndividualSDTs");this.addGridBCProperty("Residentinindividualsdts",["ResidentINIndividualLastName"],this.GXValidFnc[61],"AV22ResidentINIndividualSDTs");this.addGridBCProperty("Residentinindividualsdts",["ResidentINIndividualEmail"],this.GXValidFnc[62],"AV22ResidentINIndividualSDTs");this.addGridBCProperty("Residentinindividualsdts",["ResidentINIndividualPhone"],this.GXValidFnc[63],"AV22ResidentINIndividualSDTs");this.addGridBCProperty("Residentinindividualsdts",["ResidentINIndividualAddress"],this.GXValidFnc[64],"AV22ResidentINIndividualSDTs");this.addGridBCProperty("Residentinindividualsdts",["ResidentINIndividualGender"],this.GXValidFnc[65],"AV22ResidentINIndividualSDTs");this.Initialize()})