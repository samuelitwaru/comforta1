gx.evt.autoSkip=!1;gx.define("amenities",!1,function(){var n,t;this.ServerClass="amenities";this.PackageName="GeneXus.Programs";this.ServerFullClass="amenities.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV7AmenitiesId=gx.fn.getIntegerValue("vAMENITIESID",gx.thousandSeparator);this.AV13Insert_AmenitiesTypeId=gx.fn.getIntegerValue("vINSERT_AMENITIESTYPEID",gx.thousandSeparator);this.A109AmenitiesTypeName=gx.fn.getControlValue("AMENITIESTYPENAME");this.AV23Pgmname=gx.fn.getControlValue("vPGMNAME");this.Gx_mode=gx.fn.getControlValue("vMODE");this.AV11TrnContext=gx.fn.getControlValue("vTRNCONTEXT")};this.Valid_Amenitiesid=function(){return this.validCliEvt("Valid_Amenitiesid",0,function(){try{var n=gx.util.balloon.getNew("AMENITIESID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Amenitiestypeid=function(){return this.validSrvEvt("Valid_Amenitiestypeid",0).then(function(n){return n}.closure(this))};this.Validv_Comboamenitiestypeid=function(){return this.validCliEvt("Validv_Comboamenitiestypeid",0,function(){try{var n=gx.util.balloon.getNew("vCOMBOAMENITIESTYPEID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e130e24_client=function(){return this.clearMessages(),this.AV20ComboAmenitiesTypeId=gx.num.trunc(gx.num.val(this.COMBO_AMENITIESTYPEIDContainer.SelectedValue_get),0),this.refreshOutputs([{av:"AV20ComboAmenitiesTypeId",fld:"vCOMBOAMENITIESTYPEID",pic:"ZZZ9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e120e2_client=function(){return this.executeServerEvent("AFTER TRN",!0,null,!1,!1)};this.e140e24_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e150e24_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51];this.GXLastCtrlId=51;this.COMBO_AMENITIESTYPEIDContainer=gx.uc.getNew(this,31,24,"BootstrapDropDownOptions","COMBO_AMENITIESTYPEIDContainer","Combo_amenitiestypeid","COMBO_AMENITIESTYPEID");t=this.COMBO_AMENITIESTYPEIDContainer;t.setProp("Class","Class","","char");t.setProp("IconType","Icontype","Image","str");t.setProp("Icon","Icon","","str");t.setProp("Caption","Caption","","str");t.setProp("Tooltip","Tooltip","","str");t.setProp("Cls","Cls","ExtendedCombo Attribute","str");t.setDynProp("SelectedValue_set","Selectedvalue_set","","char");t.setProp("SelectedValue_get","Selectedvalue_get","","char");t.setDynProp("SelectedText_set","Selectedtext_set","","char");t.setProp("SelectedText_get","Selectedtext_get","","char");t.setDynProp("GAMOAuthToken","Gamoauthtoken","","char");t.setProp("DDOInternalName","Ddointernalname","","char");t.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");t.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");t.setDynProp("Enabled","Enabled",!0,"bool");t.setProp("Visible","Visible",!0,"bool");t.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");t.setProp("DataListType","Datalisttype","Dynamic","str");t.setProp("AllowMultipleSelection","Allowmultipleselection",!1,"bool");t.setProp("DataListFixedValues","Datalistfixedvalues","","char");t.setProp("IsGridItem","Isgriditem",!1,"bool");t.setProp("HasDescription","Hasdescription",!1,"bool");t.setProp("DataListProc","Datalistproc","AmenitiesLoadDVCombo","str");t.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix",' "ComboName": "AmenitiesTypeId", "TrnMode": "INS", "IsDynamicCall": true, "AmenitiesId": 0',"str");t.setProp("RemoteServicesParameters","Remoteservicesparameters","","str");t.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");t.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!1,"boolean");t.setProp("IncludeSelectAllOption","Includeselectalloption",!1,"boolean");t.setProp("EmptyItem","Emptyitem",!1,"bool");t.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");t.setProp("HTMLTemplate","Htmltemplate","","str");t.setProp("MultipleValuesType","Multiplevaluestype","Text","str");t.setProp("LoadingData","Loadingdata","","str");t.setProp("NoResultsFound","Noresultsfound","","str");t.setProp("EmptyItemText","Emptyitemtext","","char");t.setProp("OnlySelectedValues","Onlyselectedvalues","","char");t.setProp("SelectAllText","Selectalltext","","char");t.setProp("MultipleValuesSeparator","Multiplevaluesseparator","","char");t.setProp("AddNewOptionText","Addnewoptiontext","","str");t.addV2CFunction("AV16DDO_TitleSettingsIcons","vDDO_TITLESETTINGSICONS","SetDropDownOptionsTitleSettingsIcons");t.addC2VFunction(function(n){n.ParentObject.AV16DDO_TitleSettingsIcons=n.GetDropDownOptionsTitleSettingsIcons();gx.fn.setControlValue("vDDO_TITLESETTINGSICONS",n.ParentObject.AV16DDO_TitleSettingsIcons)});t.addV2CFunction("AV15AmenitiesTypeId_Data","vAMENITIESTYPEID_DATA","SetDropDownOptionsData");t.addC2VFunction(function(n){n.ParentObject.AV15AmenitiesTypeId_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vAMENITIESTYPEID_DATA",n.ParentObject.AV15AmenitiesTypeId_Data)});t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});t.addEventHandler("OnOptionClicked",this.e130e24_client);this.setUserControl(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLECONTENT",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"UNNAMEDGROUP1",grid:0};n[16]={id:16,fld:"TABLEATTRIBUTES",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"TABLEFORM",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"",grid:0};n[24]={id:24,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AMENITIESNAME",fmt:0,gxz:"Z110AmenitiesName",gxold:"O110AmenitiesName",gxvar:"A110AmenitiesName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A110AmenitiesName=n)},v2z:function(n){n!==undefined&&(gx.O.Z110AmenitiesName=n)},v2c:function(){gx.fn.setControlValue("AMENITIESNAME",gx.O.A110AmenitiesName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A110AmenitiesName=this.val())},val:function(){return gx.fn.getControlValue("AMENITIESNAME")},nac:gx.falseFn};this.declareDomainHdlr(24,function(){});n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"TABLESPLITTEDAMENITIESTYPEID",grid:0};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"TEXTBLOCKAMENITIESTYPEID",format:0,grid:0,ctrltype:"textblock"};n[30]={id:30,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Amenitiestypeid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AMENITIESTYPEID",fmt:0,gxz:"Z108AmenitiesTypeId",gxold:"O108AmenitiesTypeId",gxvar:"A108AmenitiesTypeId",ucs:[],op:[],ip:[34],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A108AmenitiesTypeId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z108AmenitiesTypeId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("AMENITIESTYPEID",gx.O.A108AmenitiesTypeId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A108AmenitiesTypeId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("AMENITIESTYPEID",gx.thousandSeparator)},nac:function(){return gx.text.compare(this.Gx_mode,"INS")==0&&!(0==this.AV13Insert_AmenitiesTypeId)}};this.declareDomainHdlr(34,function(){});n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"ACTIONSTABLE",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"BTNTRN_ENTER",grid:0,evt:"e140e24_client",std:"ENTER"};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"BTNTRN_CANCEL",grid:0,evt:"e150e24_client"};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"BTNTRN_DELETE",grid:0,evt:"e160e24_client",std:"DELETE"};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};n[49]={id:49,fld:"SECTIONATTRIBUTE_AMENITIESTYPEID",grid:0};n[50]={id:50,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Validv_Comboamenitiestypeid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCOMBOAMENITIESTYPEID",fmt:0,gxz:"ZV20ComboAmenitiesTypeId",gxold:"OV20ComboAmenitiesTypeId",gxvar:"AV20ComboAmenitiesTypeId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV20ComboAmenitiesTypeId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV20ComboAmenitiesTypeId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCOMBOAMENITIESTYPEID",gx.O.AV20ComboAmenitiesTypeId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV20ComboAmenitiesTypeId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCOMBOAMENITIESTYPEID",gx.thousandSeparator)},nac:gx.falseFn};n[51]={id:51,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Amenitiesid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AMENITIESID",fmt:0,gxz:"Z107AmenitiesId",gxold:"O107AmenitiesId",gxvar:"A107AmenitiesId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A107AmenitiesId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z107AmenitiesId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("AMENITIESID",gx.O.A107AmenitiesId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A107AmenitiesId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("AMENITIESID",gx.thousandSeparator)},nac:gx.falseFn};this.declareDomainHdlr(51,function(){});this.A110AmenitiesName="";this.Z110AmenitiesName="";this.O110AmenitiesName="";this.A108AmenitiesTypeId=0;this.Z108AmenitiesTypeId=0;this.O108AmenitiesTypeId=0;this.AV20ComboAmenitiesTypeId=0;this.ZV20ComboAmenitiesTypeId=0;this.OV20ComboAmenitiesTypeId=0;this.A107AmenitiesId=0;this.Z107AmenitiesId=0;this.O107AmenitiesId=0;this.AV8WWPContext={UserId:0,UserName:""};this.AV21GAMSession={};this.AV20ComboAmenitiesTypeId=0;this.AV11TrnContext={CallerObject:"",CallerOnDelete:!1,CallerURL:"",TransactionName:"",Attributes:[]};this.AV24GXV1=0;this.AV13Insert_AmenitiesTypeId=0;this.AV19Combo_DataJson="";this.AV14TrnContextAtt={AttributeName:"",AttributeValue:""};this.AV18ComboSelectedText="";this.AV17ComboSelectedValue="";this.AV7AmenitiesId=0;this.AV12WebSession={};this.A107AmenitiesId=0;this.A108AmenitiesTypeId=0;this.AV23Pgmname="";this.A110AmenitiesName="";this.A109AmenitiesTypeName="";this.AV16DDO_TitleSettingsIcons={Default_fi:"",Filtered_fi:"",SortedASC_fi:"",SortedDSC_fi:"",FilteredSortedASC_fi:"",FilteredSortedDSC_fi:"",OptionSortASC_fi:"",OptionSortDSC_fi:"",OptionApplyFilter_fi:"",OptionFilteringData_fi:"",OptionCleanFilters_fi:"",SelectedOption_fi:"",MultiselOption_fi:"",MultiselSelOption_fi:"",TreeviewCollapse_fi:"",TreeviewExpand_fi:"",FixLeft_fi:"",FixRight_fi:"",OptionGroup_fi:""};this.AV15AmenitiesTypeId_Data=[];this.Gx_mode="";this.Events={e120e2_client:["AFTER TRN",!0],e140e24_client:["ENTER",!0],e150e24_client:["CANCEL",!0],e130e24_client:["COMBO_AMENITIESTYPEID.ONOPTIONCLICKED",!1]};this.EvtParms.ENTER=[[{postForm:!0},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV7AmenitiesId",fld:"vAMENITIESID",pic:"ZZZ9",hsh:!0}],[]];this.EvtParms.REFRESH=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV11TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0},{av:"AV7AmenitiesId",fld:"vAMENITIESID",pic:"ZZZ9",hsh:!0},{av:"A107AmenitiesId",fld:"AMENITIESID",pic:"ZZZ9"}],[]];this.EvtParms["AFTER TRN"]=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV11TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0}],[]];this.EvtParms["COMBO_AMENITIESTYPEID.ONOPTIONCLICKED"]=[[{av:"this.COMBO_AMENITIESTYPEIDContainer.SelectedValue_get",ctrl:"COMBO_AMENITIESTYPEID",prop:"SelectedValue_get"}],[{av:"AV20ComboAmenitiesTypeId",fld:"vCOMBOAMENITIESTYPEID",pic:"ZZZ9"}]];this.EvtParms.VALID_AMENITIESTYPEID=[[{av:"A108AmenitiesTypeId",fld:"AMENITIESTYPEID",pic:"ZZZ9"},{av:"A109AmenitiesTypeName",fld:"AMENITIESTYPENAME",pic:""}],[{av:"A109AmenitiesTypeName",fld:"AMENITIESTYPENAME",pic:""}]];this.EvtParms.VALIDV_COMBOAMENITIESTYPEID=[[],[]];this.EvtParms.VALID_AMENITIESID=[[],[]];this.EnterCtrl=["BTNTRN_ENTER"];this.setVCMap("AV7AmenitiesId","vAMENITIESID",0,"int",4,0);this.setVCMap("AV13Insert_AmenitiesTypeId","vINSERT_AMENITIESTYPEID",0,"int",4,0);this.setVCMap("A109AmenitiesTypeName","AMENITIESTYPENAME",0,"svchar",40,0);this.setVCMap("AV23Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV11TrnContext","vTRNCONTEXT",0,"WWPBaseObjectsWWPTransactionContext",0,0);this.Initialize();this.setSDTMapping("GeneXusSecurity\\GAMSession",{User:{sdt:"GeneXusSecurity\\GAMUser"}});this.setSDTMapping("WWPBaseObjects\\DVB_SDTComboData.Item",{Title:{extr:"T"},Children:{extr:"C"}});this.setSDTMapping("WWPBaseObjects\\WWPTransactionContext",{Attributes:{sdt:"WWPBaseObjects\\WWPTransactionContext.Attribute"}});this.setSDTMapping("WWPBaseObjects\\DVB_SDTDropDownOptionsTitleSettingsIcons",{Default_fi:{extr:"def"},Filtered_fi:{extr:"fil"},SortedASC_fi:{extr:"asc"},SortedDSC_fi:{extr:"dsc"},FilteredSortedASC_fi:{extr:"fasc"},FilteredSortedDSC_fi:{extr:"fdsc"},OptionSortASC_fi:{extr:"osasc"},OptionSortDSC_fi:{extr:"osdsc"},OptionApplyFilter_fi:{extr:"app"},OptionFilteringData_fi:{extr:"fildata"},OptionCleanFilters_fi:{extr:"cle"},SelectedOption_fi:{extr:"selo"},MultiselOption_fi:{extr:"mul"},MultiselSelOption_fi:{extr:"muls"},TreeviewCollapse_fi:{extr:"tcol"},TreeviewExpand_fi:{extr:"texp"},FixLeft_fi:{extr:"fixl"},FixRight_fi:{extr:"fixr"},OptionGroup_fi:{extr:"og"}})});gx.wi(function(){gx.createParentObj(this.amenities)})