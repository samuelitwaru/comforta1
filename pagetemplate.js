gx.evt.autoSkip=!1;gx.define("pagetemplate",!1,function(){this.ServerClass="pagetemplate";this.PackageName="GeneXus.Programs";this.ServerFullClass="pagetemplate.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV7PageTemplateId=gx.fn.getIntegerValue("vPAGETEMPLATEID",gx.thousandSeparator);this.A40000PageTemplateImage_GXI=gx.fn.getControlValue("PAGETEMPLATEIMAGE_GXI");this.Gx_mode=gx.fn.getControlValue("vMODE");this.AV11TrnContext=gx.fn.getControlValue("vTRNCONTEXT")};this.Valid_Pagetemplateid=function(){return this.validCliEvt("Valid_Pagetemplateid",0,function(){try{var n=gx.util.balloon.getNew("PAGETEMPLATEID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e120d2_client=function(){return this.executeServerEvent("AFTER TRN",!0,null,!1,!1)};this.e130d22_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e140d22_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57];this.GXLastCtrlId=57;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLECONTENT",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"UNNAMEDGROUP1",grid:0};n[16]={id:16,fld:"TABLEATTRIBUTES",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"TABLEFORM",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"",grid:0};n[24]={id:24,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PAGETEMPLATENAME",fmt:0,gxz:"Z103PageTemplateName",gxold:"O103PageTemplateName",gxvar:"A103PageTemplateName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A103PageTemplateName=n)},v2z:function(n){n!==undefined&&(gx.O.Z103PageTemplateName=n)},v2c:function(){gx.fn.setControlValue("PAGETEMPLATENAME",gx.O.A103PageTemplateName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A103PageTemplateName=this.val())},val:function(){return gx.fn.getControlValue("PAGETEMPLATENAME")},nac:gx.falseFn};this.declareDomainHdlr(24,function(){});n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"",grid:0};n[28]={id:28,lvl:0,type:"svchar",len:200,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PAGETEMPLATEDESCRIPTION",fmt:0,gxz:"Z106PageTemplateDescription",gxold:"O106PageTemplateDescription",gxvar:"A106PageTemplateDescription",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A106PageTemplateDescription=n)},v2z:function(n){n!==undefined&&(gx.O.Z106PageTemplateDescription=n)},v2c:function(){gx.fn.setControlValue("PAGETEMPLATEDESCRIPTION",gx.O.A106PageTemplateDescription,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A106PageTemplateDescription=this.val())},val:function(){return gx.fn.getControlValue("PAGETEMPLATEDESCRIPTION")},nac:gx.falseFn};this.declareDomainHdlr(28,function(){});n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,lvl:0,type:"vchar",len:2097152,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PAGETEMPLATEHTML",fmt:1,gxz:"Z114PageTemplateHtml",gxold:"O114PageTemplateHtml",gxvar:"A114PageTemplateHtml",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A114PageTemplateHtml=n)},v2z:function(n){n!==undefined&&(gx.O.Z114PageTemplateHtml=n)},v2c:function(){gx.fn.setControlValue("PAGETEMPLATEHTML",gx.O.A114PageTemplateHtml,1);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A114PageTemplateHtml=this.val())},val:function(){return gx.fn.getControlValue("PAGETEMPLATEHTML")},nac:gx.falseFn};this.declareDomainHdlr(33,function(){});n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,lvl:0,type:"vchar",len:2097152,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PAGETEMPLATECSS",fmt:0,gxz:"Z113PageTemplateCSS",gxold:"O113PageTemplateCSS",gxvar:"A113PageTemplateCSS",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A113PageTemplateCSS=n)},v2z:function(n){n!==undefined&&(gx.O.Z113PageTemplateCSS=n)},v2c:function(){gx.fn.setControlValue("PAGETEMPLATECSS",gx.O.A113PageTemplateCSS,0)},c2v:function(){this.val()!==undefined&&(gx.O.A113PageTemplateCSS=this.val())},val:function(){return gx.fn.getControlValue("PAGETEMPLATECSS")},nac:gx.falseFn};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,lvl:0,type:"bits",len:1024,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PAGETEMPLATEIMAGE",fmt:0,gxz:"Z105PageTemplateImage",gxold:"O105PageTemplateImage",gxvar:"A105PageTemplateImage",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A105PageTemplateImage=n)},v2z:function(n){n!==undefined&&(gx.O.Z105PageTemplateImage=n)},v2c:function(){gx.fn.setMultimediaValue("PAGETEMPLATEIMAGE",gx.O.A105PageTemplateImage,gx.O.A40000PageTemplateImage_GXI)},c2v:function(){gx.O.A40000PageTemplateImage_GXI=this.val_GXI();this.val()!==undefined&&(gx.O.A105PageTemplateImage=this.val())},val:function(){return gx.fn.getBlobValue("PAGETEMPLATEIMAGE")},val_GXI:function(){return gx.fn.getControlValue("PAGETEMPLATEIMAGE_GXI")},gxvar_GXI:"A40000PageTemplateImage_GXI",nac:gx.falseFn};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"ACTIONSTABLE",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"BTNTRN_ENTER",grid:0,evt:"e130d22_client",std:"ENTER"};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"BTNTRN_CANCEL",grid:0,evt:"e140d22_client"};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"BTNTRN_DELETE",grid:0,evt:"e150d22_client",std:"DELETE"};n[54]={id:54,fld:"",grid:0};n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};n[57]={id:57,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Pagetemplateid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PAGETEMPLATEID",fmt:0,gxz:"Z102PageTemplateId",gxold:"O102PageTemplateId",gxvar:"A102PageTemplateId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A102PageTemplateId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z102PageTemplateId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("PAGETEMPLATEID",gx.O.A102PageTemplateId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A102PageTemplateId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("PAGETEMPLATEID",gx.thousandSeparator)},nac:gx.falseFn};this.declareDomainHdlr(57,function(){});this.A103PageTemplateName="";this.Z103PageTemplateName="";this.O103PageTemplateName="";this.A106PageTemplateDescription="";this.Z106PageTemplateDescription="";this.O106PageTemplateDescription="";this.A114PageTemplateHtml="";this.Z114PageTemplateHtml="";this.O114PageTemplateHtml="";this.A113PageTemplateCSS="";this.Z113PageTemplateCSS="";this.O113PageTemplateCSS="";this.A40000PageTemplateImage_GXI="";this.A105PageTemplateImage="";this.Z105PageTemplateImage="";this.O105PageTemplateImage="";this.A102PageTemplateId=0;this.Z102PageTemplateId=0;this.O102PageTemplateId=0;this.A40000PageTemplateImage_GXI="";this.AV8WWPContext={UserId:0,UserName:""};this.AV11TrnContext={CallerObject:"",CallerOnDelete:!1,CallerURL:"",TransactionName:"",Attributes:[]};this.AV7PageTemplateId=0;this.AV12WebSession={};this.A102PageTemplateId=0;this.A103PageTemplateName="";this.A106PageTemplateDescription="";this.A114PageTemplateHtml="";this.A113PageTemplateCSS="";this.A105PageTemplateImage="";this.Gx_mode="";this.Events={e120d2_client:["AFTER TRN",!0],e130d22_client:["ENTER",!0],e140d22_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV7PageTemplateId",fld:"vPAGETEMPLATEID",pic:"ZZZ9",hsh:!0}],[]];this.EvtParms.REFRESH=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV11TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0},{av:"AV7PageTemplateId",fld:"vPAGETEMPLATEID",pic:"ZZZ9",hsh:!0},{av:"A102PageTemplateId",fld:"PAGETEMPLATEID",pic:"ZZZ9"}],[]];this.EvtParms["AFTER TRN"]=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV11TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0}],[]];this.EvtParms.VALID_PAGETEMPLATEID=[[],[]];this.EnterCtrl=["BTNTRN_ENTER"];this.setVCMap("AV7PageTemplateId","vPAGETEMPLATEID",0,"int",4,0);this.setVCMap("A40000PageTemplateImage_GXI","PAGETEMPLATEIMAGE_GXI",0,"svchar",2048,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV11TrnContext","vTRNCONTEXT",0,"WWPBaseObjectsWWPTransactionContext",0,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.pagetemplate)})