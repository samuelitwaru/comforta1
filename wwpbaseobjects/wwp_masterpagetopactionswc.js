gx.evt.autoSkip=!1;gx.define("wwpbaseobjects.wwp_masterpagetopactionswc",!0,function(n){var t,i,r;this.ServerClass="wwpbaseobjects.wwp_masterpagetopactionswc";this.PackageName="GeneXus.Programs";this.ServerFullClass="wwpbaseobjects.wwp_masterpagetopactionswc.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){};this.e121i2_client=function(){return this.executeServerEvent("'DOACTIONCHANGEPASSWORD'",!0,null,!1,!1)};this.e131i2_client=function(){return this.executeServerEvent("'DOLOGOUT'",!0,null,!1,!1)};this.e151i2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e161i2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,24,25];this.GXLastCtrlId=25;this.BTNACTIONCHANGEPASSWORDContainer=gx.uc.getNew(this,23,12,"WWP_IconButton",this.CmpContext+"BTNACTIONCHANGEPASSWORDContainer","Btnactionchangepassword","BTNACTIONCHANGEPASSWORD");i=this.BTNACTIONCHANGEPASSWORDContainer;i.setProp("Enabled","Enabled",!0,"boolean");i.setProp("TooltipText","Tooltiptext","","str");i.setProp("BeforeIconClass","Beforeiconclass","fa fa-lock FontIconTopRightActions","str");i.setProp("AfterIconClass","Aftericonclass","","str");i.addEventHandler("Event",this.e121i2_client);i.setProp("Caption","Caption",gx.getMessage("WWP_GAM_ChangePassword"),"str");i.setProp("Class","Class","MasterPageTopActionsOption","str");i.setProp("Visible","Visible",!0,"bool");i.setC2ShowFunction(function(n){n.show()});this.setUserControl(i);this.BTNLOGOUTContainer=gx.uc.getNew(this,26,12,"WWP_IconButton",this.CmpContext+"BTNLOGOUTContainer","Btnlogout","BTNLOGOUT");r=this.BTNLOGOUTContainer;r.setProp("Enabled","Enabled",!0,"boolean");r.setProp("TooltipText","Tooltiptext","","str");r.setProp("BeforeIconClass","Beforeiconclass","fas fa-sign-out-alt FontIconTopRightActions","str");r.setProp("AfterIconClass","Aftericonclass","","str");r.addEventHandler("Event",this.e131i2_client);r.setProp("Caption","Caption",gx.getMessage("WWP_GAM_Logout"),"str");r.setProp("Class","Class","MasterPageTopActionsOption","str");r.setProp("Visible","Visible",!0,"bool");r.setC2ShowFunction(function(n){n.show()});this.setUserControl(r);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TABLEMAIN",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[9]={id:9,fld:"USERINFORMATION",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"",grid:0};t[12]={id:12,lvl:0,type:"bits",len:1024,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSERIMAGE",fmt:0,gxz:"ZV5UserImage",gxold:"OV5UserImage",gxvar:"AV5UserImage",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV5UserImage=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5UserImage=n)},v2c:function(){gx.fn.setMultimediaValue("vUSERIMAGE",gx.O.AV5UserImage,gx.O.AV17Userimage_GXI)},c2v:function(){gx.O.AV17Userimage_GXI=this.val_GXI();this.val()!==undefined&&(gx.O.AV5UserImage=this.val())},val:function(){return gx.fn.getBlobValue("vUSERIMAGE")},val_GXI:function(){return gx.fn.getControlValue("vUSERIMAGE_GXI")},gxvar_GXI:"AV17Userimage_GXI",nac:gx.falseFn};t[13]={id:13,fld:"",grid:0};t[14]={id:14,fld:"UNNAMEDTABLE1",grid:0};t[15]={id:15,fld:"",grid:0};t[16]={id:16,fld:"",grid:0};t[17]={id:17,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSERNAME",fmt:0,gxz:"ZV6UserName",gxold:"OV6UserName",gxvar:"AV6UserName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6UserName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV6UserName=n)},v2c:function(){gx.fn.setControlValue("vUSERNAME",gx.O.AV6UserName,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6UserName=this.val())},val:function(){return gx.fn.getControlValue("vUSERNAME")},nac:gx.falseFn};t[18]={id:18,fld:"",grid:0};t[19]={id:19,fld:"",grid:0};t[20]={id:20,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vROLESDESCRIPTIONS",fmt:0,gxz:"ZV12RolesDescriptions",gxold:"OV12RolesDescriptions",gxvar:"AV12RolesDescriptions",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV12RolesDescriptions=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12RolesDescriptions=n)},v2c:function(){gx.fn.setControlValue("vROLESDESCRIPTIONS",gx.O.AV12RolesDescriptions,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV12RolesDescriptions=this.val())},val:function(){return gx.fn.getControlValue("vROLESDESCRIPTIONS")},nac:gx.falseFn};t[21]={id:21,fld:"",grid:0};t[22]={id:22,fld:"",grid:0};t[24]={id:24,fld:"",grid:0};t[25]={id:25,fld:"",grid:0};this.AV17Userimage_GXI="";this.AV5UserImage="";this.ZV5UserImage="";this.OV5UserImage="";this.AV6UserName="";this.ZV6UserName="";this.OV6UserName="";this.AV12RolesDescriptions="";this.ZV12RolesDescriptions="";this.OV12RolesDescriptions="";this.AV5UserImage="";this.AV6UserName="";this.AV12RolesDescriptions="";this.Events={e121i2_client:["'DOACTIONCHANGEPASSWORD'",!0],e131i2_client:["'DOLOGOUT'",!0],e151i2_client:["ENTER",!0],e161i2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"AV12RolesDescriptions",fld:"vROLESDESCRIPTIONS",pic:""}],[]];this.EvtParms["'DOACTIONCHANGEPASSWORD'"]=[[],[]];this.EvtParms["'DOLOGOUT'"]=[[],[]];this.EvtParms.ENTER=[[],[]];this.Initialize()})