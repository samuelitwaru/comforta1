gx.evt.autoSkip=!1;gx.define("productservicetypegeneral",!0,function(n){this.ServerClass="productservicetypegeneral";this.PackageName="GeneXus.Programs";this.ServerFullClass="productservicetypegeneral.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV12IsAuthorized_Update=gx.fn.getControlValue("vISAUTHORIZED_UPDATE");this.AV13IsAuthorized_Delete=gx.fn.getControlValue("vISAUTHORIZED_DELETE")};this.Valid_Productservicetypeid=function(){return this.validCliEvt("Valid_Productservicetypeid",0,function(){try{var n=gx.util.balloon.getNew("PRODUCTSERVICETYPEID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e11231_client=function(){return this.clearMessages(),this.AV12IsAuthorized_Update?this.call("productservicetype.aspx",["UPD",this.A71ProductServiceTypeId],null,["Mode","ProductServiceTypeId"]):(this.addMessage(gx.getMessage("WWP_ActionNoLongerAvailable")),gx.fn.setCtrlProperty("BTNUPDATE","Visible",!1)),this.refreshOutputs([{ctrl:"BTNUPDATE",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e12231_client=function(){return this.clearMessages(),this.AV13IsAuthorized_Delete?this.call("productservicetype.aspx",["DLT",this.A71ProductServiceTypeId],null,["Mode","ProductServiceTypeId"]):(this.addMessage(gx.getMessage("WWP_ActionNoLongerAvailable")),gx.fn.setCtrlProperty("BTNDELETE","Visible",!1)),this.refreshOutputs([{ctrl:"BTNDELETE",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e15232_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e16232_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31];this.GXLastCtrlId=31;t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TABLE",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[9]={id:9,fld:"TRANSACTIONDETAIL_TABLEATTRIBUTES",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"TRANSACTIONDETAIL_TABLEFORM",grid:0};t[13]={id:13,fld:"",grid:0};t[14]={id:14,fld:"",grid:0};t[15]={id:15,fld:"",grid:0};t[16]={id:16,fld:"",grid:0};t[17]={id:17,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTSERVICETYPENAME",fmt:0,gxz:"Z72ProductServiceTypeName",gxold:"O72ProductServiceTypeName",gxvar:"A72ProductServiceTypeName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A72ProductServiceTypeName=n)},v2z:function(n){n!==undefined&&(gx.O.Z72ProductServiceTypeName=n)},v2c:function(){gx.fn.setControlValue("PRODUCTSERVICETYPENAME",gx.O.A72ProductServiceTypeName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A72ProductServiceTypeName=this.val())},val:function(){return gx.fn.getControlValue("PRODUCTSERVICETYPENAME")},nac:gx.falseFn};this.declareDomainHdlr(17,function(){});t[18]={id:18,fld:"",grid:0};t[19]={id:19,fld:"",grid:0};t[20]={id:20,fld:"TRANSACTIONDETAIL_ACTIONSTABLE",grid:0};t[21]={id:21,fld:"",grid:0};t[22]={id:22,fld:"",grid:0};t[23]={id:23,fld:"",grid:0};t[24]={id:24,fld:"",grid:0};t[25]={id:25,fld:"BTNUPDATE",grid:0,evt:"e11231_client"};t[26]={id:26,fld:"",grid:0};t[27]={id:27,fld:"BTNDELETE",grid:0,evt:"e12231_client"};t[28]={id:28,fld:"",grid:0};t[29]={id:29,fld:"",grid:0};t[30]={id:30,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};t[31]={id:31,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Productservicetypeid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTSERVICETYPEID",fmt:0,gxz:"Z71ProductServiceTypeId",gxold:"O71ProductServiceTypeId",gxvar:"A71ProductServiceTypeId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A71ProductServiceTypeId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z71ProductServiceTypeId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("PRODUCTSERVICETYPEID",gx.O.A71ProductServiceTypeId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A71ProductServiceTypeId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("PRODUCTSERVICETYPEID",gx.thousandSeparator)},nac:gx.falseFn};this.declareDomainHdlr(31,function(){});this.A72ProductServiceTypeName="";this.Z72ProductServiceTypeName="";this.O72ProductServiceTypeName="";this.A71ProductServiceTypeId=0;this.Z71ProductServiceTypeId=0;this.O71ProductServiceTypeId=0;this.A72ProductServiceTypeName="";this.A71ProductServiceTypeId=0;this.AV12IsAuthorized_Update=!1;this.AV13IsAuthorized_Delete=!1;this.Events={e15232_client:["ENTER",!0],e16232_client:["CANCEL",!0],e11231_client:["'DOUPDATE'",!1],e12231_client:["'DODELETE'",!1]};this.EvtParms.REFRESH=[[{av:"A71ProductServiceTypeId",fld:"PRODUCTSERVICETYPEID",pic:"ZZZ9"},{av:"AV12IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",pic:"",hsh:!0},{av:"AV13IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",pic:"",hsh:!0}],[]];this.EvtParms["'DOUPDATE'"]=[[{av:"AV12IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",pic:"",hsh:!0},{av:"A71ProductServiceTypeId",fld:"PRODUCTSERVICETYPEID",pic:"ZZZ9"}],[{ctrl:"BTNUPDATE",prop:"Visible"}]];this.EvtParms["'DODELETE'"]=[[{av:"AV13IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",pic:"",hsh:!0},{av:"A71ProductServiceTypeId",fld:"PRODUCTSERVICETYPEID",pic:"ZZZ9"}],[{ctrl:"BTNDELETE",prop:"Visible"}]];this.EvtParms.ENTER=[[],[]];this.EvtParms.VALID_PRODUCTSERVICETYPEID=[[],[]];this.setVCMap("AV12IsAuthorized_Update","vISAUTHORIZED_UPDATE",0,"boolean",4,0);this.setVCMap("AV13IsAuthorized_Delete","vISAUTHORIZED_DELETE",0,"boolean",4,0);this.setVCMap("AV13IsAuthorized_Delete","vISAUTHORIZED_DELETE",0,"boolean",4,0);this.setVCMap("AV12IsAuthorized_Update","vISAUTHORIZED_UPDATE",0,"boolean",4,0);this.Initialize()})