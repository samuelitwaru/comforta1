gx.evt.autoSkip=!1;gx.define("addagbsuppliers",!1,function(){var n,i,t,u,f,r;this.ServerClass="addagbsuppliers";this.PackageName="GeneXus.Programs";this.ServerFullClass="addagbsuppliers.aspx";this.setObjectType("web");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV18LocationAGBSuppliersSDTs=gx.fn.getControlValue("vLOCATIONAGBSUPPLIERSSDTS");this.AV48Customer=gx.fn.getControlValue("vCUSTOMER");this.AV31SupplierAGBOptions=gx.fn.getControlValue("vSUPPLIERAGBOPTIONS")};this.Validv_Gxv6=function(){var n=gx.fn.currentGridRowImpl(35);return this.validCliEvt("Validv_Gxv6",35,function(){try{var n=gx.util.balloon.getNew("LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBEMAIL");if(this.AnyError=0,!gx.util.regExp.isMatch(this.GXV6,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$"))try{n.setError(gx.text.format(gx.getMessage("GXM_DoesNotMatchRegExp"),gx.getMessage("Supplier_Agb Email"),"","","","","","","",""));this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e172o1_client=function(){return this.clearMessages(),gx.json.SDTFromJson(this.AV31SupplierAGBOptions,"undefined",this.COMBO_SUPPLIERAGBOPTIONSContainer.SelectedValue_get),this.refreshOutputs([{av:"AV31SupplierAGBOptions",fld:"vSUPPLIERAGBOPTIONS",pic:""}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e112o2_client=function(){return this.executeServerEvent("'DOBACK'",!0,null,!1,!1)};this.e122o2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e132o2_client=function(){return this.executeServerEvent("'DOINSERTAGBSUPPLIER'",!1,null,!1,!1)};this.e162o2_client=function(){return this.executeServerEvent("VUDELETE.CLICK",!0,arguments[0],!1,!1)};this.e182o2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,26,27,28,29,30,31,32,33,34,36,37,38,39,40,41,42,43,44,45,46,47,48,49,51,53,54,55];this.GXLastCtrlId=55;this.GridsContainer=new gx.grid.grid(this,2,"WbpLvl2",35,"Grids","Grids","GridsContainer",this.CmpContext,this.IsMasterPage,"addagbsuppliers",[],!1,1,!1,!0,0,!0,!1,!1,"CollLocationAGBSuppliersSDT",0,"px",0,"px",gx.getMessage("GXM_newrow"),!0,!1,!1,null,null,!1,"AV18LocationAGBSuppliersSDTs",!1,[1,1,1,1],!1,0,!0,!1);i=this.GridsContainer;i.addSingleLineEdit("Udelete",36,"vUDELETE","",gx.getMessage("Delete item"),"UDelete","char",0,"px",20,20,"start","e162o2_client",[],"Udelete","UDelete",!0,0,!1,!1,"Attribute",0,"WWIconActionColumn");i.addSingleLineEdit("GXV2",37,"LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBID",gx.getMessage("Supplier_Agb Id"),"","Supplier_AgbId","int",0,"px",4,4,"end",null,[],"GXV2","GXV2",!1,0,!1,!1,"Attribute",0,"WWColumn");i.addSingleLineEdit("GXV3",38,"LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBNAME",gx.getMessage("Supplier Name"),"","Supplier_AgbName","svchar",0,"px",40,40,"start",null,[],"GXV3","GXV3",!0,0,!1,!1,"Attribute",0,"WWColumn");i.addSingleLineEdit("GXV4",39,"LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBNUMBER",gx.getMessage("Number"),"","Supplier_AgbNumber","svchar",0,"px",10,10,"start",null,[],"GXV4","GXV4",!0,0,!1,!1,"Attribute",0,"WWColumn");i.addSingleLineEdit("GXV5",40,"LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBKVKNUMBER",gx.getMessage("KvKNumber"),"","Supplier_AgbKvkNumber","svchar",0,"px",8,8,"start",null,[],"GXV5","GXV5",!0,0,!1,!1,"Attribute",0,"WWColumn");i.addSingleLineEdit("GXV6",41,"LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBEMAIL",gx.getMessage("Email"),"","Supplier_AgbEmail","svchar",0,"px",100,80,"start",null,[],"GXV6","GXV6",!0,0,!1,!1,"Attribute",0,"WWColumn");i.addSingleLineEdit("GXV7",42,"LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBPHONE",gx.getMessage("Phone"),"","Supplier_AgbPhone","char",0,"px",20,20,"start",null,[],"GXV7","GXV7",!0,0,!1,!1,"Attribute",0,"WWColumn");i.addSingleLineEdit("GXV8",43,"LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBCONTACTNAME",gx.getMessage("Contact Name"),"","Supplier_AgbContactName","svchar",0,"px",40,40,"start",null,[],"GXV8","GXV8",!0,0,!1,!1,"Attribute",0,"WWColumn");i.addSingleLineEdit("GXV9",44,"LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBPOSTALADDRESS",gx.getMessage("Postal Address"),"","Supplier_AgbPostalAddress","svchar",0,"px",1024,80,"start",null,[],"GXV9","GXV9",!1,0,!1,!1,"Attribute",0,"WWColumn");i.addSingleLineEdit("GXV10",45,"LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBVISITINGADDRESS",gx.getMessage("Visiting Address"),"","Supplier_AgbVisitingAddress","svchar",0,"px",1024,80,"start",null,[],"GXV10","GXV10",!1,0,!1,!1,"Attribute",0,"WWColumn");this.GridsContainer.emptyText=gx.getMessage("");this.setGrid(i);this.COMBO_SUPPLIERAGBOPTIONSContainer=gx.uc.getNew(this,25,21,"BootstrapDropDownOptions","COMBO_SUPPLIERAGBOPTIONSContainer","Combo_supplieragboptions","COMBO_SUPPLIERAGBOPTIONS");t=this.COMBO_SUPPLIERAGBOPTIONSContainer;t.setProp("Class","Class","","char");t.setProp("IconType","Icontype","Image","str");t.setProp("Icon","Icon","","str");t.setProp("Caption","Caption","","str");t.setProp("Tooltip","Tooltip","","str");t.setProp("Cls","Cls","ExtendedCombo AddressAttribute ","str");t.setDynProp("SelectedValue_set","Selectedvalue_set","","char");t.setProp("SelectedValue_get","Selectedvalue_get","","char");t.setDynProp("SelectedText_set","Selectedtext_set","","char");t.setProp("SelectedText_get","Selectedtext_get","","char");t.setDynProp("GAMOAuthToken","Gamoauthtoken","","char");t.setProp("DDOInternalName","Ddointernalname","","char");t.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");t.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");t.setProp("Enabled","Enabled",!0,"bool");t.setProp("Visible","Visible",!0,"bool");t.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");t.setProp("DataListType","Datalisttype","Dynamic","str");t.setProp("AllowMultipleSelection","Allowmultipleselection",!0,"bool");t.setProp("DataListFixedValues","Datalistfixedvalues","","char");t.setProp("IsGridItem","Isgriditem",!1,"bool");t.setProp("HasDescription","Hasdescription",!1,"bool");t.setProp("DataListProc","Datalistproc","AddAgbSuppliersLoadDVCombo","str");t.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix",' "ComboName": "SupplierAGBOptions"',"str");t.setProp("RemoteServicesParameters","Remoteservicesparameters","","str");t.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");t.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!0,"bool");t.setProp("IncludeSelectAllOption","Includeselectalloption",!0,"bool");t.setProp("EmptyItem","Emptyitem",!0,"bool");t.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");t.setProp("HTMLTemplate","Htmltemplate","","str");t.setProp("MultipleValuesType","Multiplevaluestype","Tags","str");t.setProp("LoadingData","Loadingdata","","str");t.setProp("NoResultsFound","Noresultsfound","","str");t.setProp("EmptyItemText","Emptyitemtext","Select AGB Supplier to add","str");t.setProp("OnlySelectedValues","Onlyselectedvalues","","str");t.setProp("SelectAllText","Selectalltext","","str");t.setProp("MultipleValuesSeparator","Multiplevaluesseparator",", ","str");t.setProp("AddNewOptionText","Addnewoptiontext","","str");t.addV2CFunction("AV11DDO_TitleSettingsIcons","vDDO_TITLESETTINGSICONS","SetDropDownOptionsTitleSettingsIcons");t.addC2VFunction(function(n){n.ParentObject.AV11DDO_TitleSettingsIcons=n.GetDropDownOptionsTitleSettingsIcons();gx.fn.setControlValue("vDDO_TITLESETTINGSICONS",n.ParentObject.AV11DDO_TitleSettingsIcons)});t.addV2CFunction("AV32SupplierAGBOptions_Data","vSUPPLIERAGBOPTIONS_DATA","SetDropDownOptionsData");t.addC2VFunction(function(n){n.ParentObject.AV32SupplierAGBOptions_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vSUPPLIERAGBOPTIONS_DATA",n.ParentObject.AV32SupplierAGBOptions_Data)});t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});t.addEventHandler("OnOptionClicked",this.e172o1_client);this.setUserControl(t);this.BTNBACKContainer=gx.uc.getNew(this,50,21,"WWP_IconButton","BTNBACKContainer","Btnback","BTNBACK");u=this.BTNBACKContainer;u.setProp("Enabled","Enabled",!0,"boolean");u.setProp("TooltipText","Tooltiptext","","str");u.setProp("BeforeIconClass","Beforeiconclass","","str");u.setProp("AfterIconClass","Aftericonclass","","str");u.addEventHandler("Event",this.e112o2_client);u.setProp("Caption","Caption",gx.getMessage("Cancel"),"str");u.setProp("Class","Class","BtnDefault","str");u.setProp("Visible","Visible",!0,"bool");u.setC2ShowFunction(function(n){n.show()});this.setUserControl(u);this.BTNENTERContainer=gx.uc.getNew(this,52,21,"WWP_IconButton","BTNENTERContainer","Btnenter","BTNENTER");f=this.BTNENTERContainer;f.setProp("Enabled","Enabled",!0,"boolean");f.setProp("TooltipText","Tooltiptext","","str");f.setProp("BeforeIconClass","Beforeiconclass","","str");f.setProp("AfterIconClass","Aftericonclass","","str");f.addEventHandler("Event",this.e122o2_client);f.setProp("Caption","Caption",gx.getMessage("GX_BtnEnter"),"str");f.setProp("Class","Class","Button","str");f.setProp("Visible","Visible",!0,"bool");f.setC2ShowFunction(function(n){n.show()});this.setUserControl(f);this.GRIDS_EMPOWERERContainer=gx.uc.getNew(this,56,21,"WWP_GridEmpowerer","GRIDS_EMPOWERERContainer","Grids_empowerer","GRIDS_EMPOWERER");r=this.GRIDS_EMPOWERERContainer;r.setProp("Class","Class","","char");r.setProp("Enabled","Enabled",!0,"boolean");r.setDynProp("GridInternalName","Gridinternalname","","char");r.setProp("HasCategories","Hascategories",!1,"bool");r.setProp("InfiniteScrolling","Infinitescrolling","False","str");r.setProp("HasTitleSettings","Hastitlesettings",!1,"bool");r.setProp("HasColumnsSelector","Hascolumnsselector",!1,"bool");r.setProp("HasRowGroups","Hasrowgroups",!1,"bool");r.setProp("FixedColumns","Fixedcolumns","","str");r.setProp("PopoversInGrid","Popoversingrid","","str");r.setProp("Visible","Visible",!0,"bool");r.setC2ShowFunction(function(n){n.show()});this.setUserControl(r);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLECONTENT",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"UNNAMEDTABLE1",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"UNNAMEDTABLE2",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLOCATIONOPTION",fmt:0,gxz:"ZV19LocationOption",gxold:"OV19LocationOption",gxvar:"AV19LocationOption",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"dyncombo",v2v:function(n){n!==undefined&&(gx.O.AV19LocationOption=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV19LocationOption=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("vLOCATIONOPTION",gx.O.AV19LocationOption)},c2v:function(){this.val()!==undefined&&(gx.O.AV19LocationOption=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vLOCATIONOPTION",gx.thousandSeparator)},nac:gx.falseFn};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"SPACER1",format:0,grid:0,ctrltype:"textblock"};n[24]={id:24,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"SPACER2",format:0,grid:0,ctrltype:"textblock"};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"BTNINSERTAGBSUPPLIER",grid:0,evt:"e132o2_client"};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"TABLEGRID",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[36]={id:36,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:35,gxgrid:this.GridsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUDELETE",fmt:1,gxz:"ZV34UDelete",gxold:"OV34UDelete",gxvar:"AV34UDelete",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV34UDelete=n)},v2z:function(n){n!==undefined&&(gx.O.ZV34UDelete=n)},v2c:function(n){gx.fn.setGridControlValue("vUDELETE",n||gx.fn.currentGridRowImpl(35),gx.O.AV34UDelete,1)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV34UDelete=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vUDELETE",n||gx.fn.currentGridRowImpl(35))},nac:gx.falseFn,evt:"e162o2_client"};n[37]={id:37,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,isacc:0,grid:35,gxgrid:this.GridsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBID",fmt:0,gxz:"ZV52GXV2",gxold:"OV52GXV2",gxvar:"GXV2",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.GXV2=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV52GXV2=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBID",n||gx.fn.currentGridRowImpl(35),gx.O.GXV2,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV2=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBID",n||gx.fn.currentGridRowImpl(35),gx.thousandSeparator)},nac:gx.falseFn};n[38]={id:38,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:0,isacc:0,grid:35,gxgrid:this.GridsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBNAME",fmt:0,gxz:"ZV53GXV3",gxold:"OV53GXV3",gxvar:"GXV3",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.GXV3=n)},v2z:function(n){n!==undefined&&(gx.O.ZV53GXV3=n)},v2c:function(n){gx.fn.setGridControlValue("LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBNAME",n||gx.fn.currentGridRowImpl(35),gx.O.GXV3,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV3=this.val(n))},val:function(n){return gx.fn.getGridControlValue("LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBNAME",n||gx.fn.currentGridRowImpl(35))},nac:gx.falseFn};n[39]={id:39,lvl:2,type:"svchar",len:10,dec:0,sign:!1,ro:0,isacc:0,grid:35,gxgrid:this.GridsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBNUMBER",fmt:0,gxz:"ZV54GXV4",gxold:"OV54GXV4",gxvar:"GXV4",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.GXV4=n)},v2z:function(n){n!==undefined&&(gx.O.ZV54GXV4=n)},v2c:function(n){gx.fn.setGridControlValue("LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBNUMBER",n||gx.fn.currentGridRowImpl(35),gx.O.GXV4,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV4=this.val(n))},val:function(n){return gx.fn.getGridControlValue("LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBNUMBER",n||gx.fn.currentGridRowImpl(35))},nac:gx.falseFn};n[40]={id:40,lvl:2,type:"svchar",len:8,dec:0,sign:!1,ro:0,isacc:0,grid:35,gxgrid:this.GridsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBKVKNUMBER",fmt:0,gxz:"ZV55GXV5",gxold:"OV55GXV5",gxvar:"GXV5",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.GXV5=n)},v2z:function(n){n!==undefined&&(gx.O.ZV55GXV5=n)},v2c:function(n){gx.fn.setGridControlValue("LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBKVKNUMBER",n||gx.fn.currentGridRowImpl(35),gx.O.GXV5,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV5=this.val(n))},val:function(n){return gx.fn.getGridControlValue("LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBKVKNUMBER",n||gx.fn.currentGridRowImpl(35))},nac:gx.falseFn};n[41]={id:41,lvl:2,type:"svchar",len:100,dec:0,sign:!1,ro:0,isacc:0,grid:35,gxgrid:this.GridsContainer,fnc:this.Validv_Gxv6,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBEMAIL",fmt:0,gxz:"ZV56GXV6",gxold:"OV56GXV6",gxvar:"GXV6",ucs:[],op:[],ip:[41],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.GXV6=n)},v2z:function(n){n!==undefined&&(gx.O.ZV56GXV6=n)},v2c:function(n){gx.fn.setGridControlValue("LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBEMAIL",n||gx.fn.currentGridRowImpl(35),gx.O.GXV6,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV6=this.val(n))},val:function(n){return gx.fn.getGridControlValue("LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBEMAIL",n||gx.fn.currentGridRowImpl(35))},nac:gx.falseFn};n[42]={id:42,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:35,gxgrid:this.GridsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBPHONE",fmt:0,gxz:"ZV57GXV7",gxold:"OV57GXV7",gxvar:"GXV7",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.GXV7=n)},v2z:function(n){n!==undefined&&(gx.O.ZV57GXV7=n)},v2c:function(n){gx.fn.setGridControlValue("LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBPHONE",n||gx.fn.currentGridRowImpl(35),gx.O.GXV7,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV7=this.val(n))},val:function(n){return gx.fn.getGridControlValue("LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBPHONE",n||gx.fn.currentGridRowImpl(35))},nac:gx.falseFn};n[43]={id:43,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:0,isacc:0,grid:35,gxgrid:this.GridsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBCONTACTNAME",fmt:0,gxz:"ZV58GXV8",gxold:"OV58GXV8",gxvar:"GXV8",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.GXV8=n)},v2z:function(n){n!==undefined&&(gx.O.ZV58GXV8=n)},v2c:function(n){gx.fn.setGridControlValue("LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBCONTACTNAME",n||gx.fn.currentGridRowImpl(35),gx.O.GXV8,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV8=this.val(n))},val:function(n){return gx.fn.getGridControlValue("LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBCONTACTNAME",n||gx.fn.currentGridRowImpl(35))},nac:gx.falseFn};n[44]={id:44,lvl:2,type:"svchar",len:1024,dec:0,sign:!1,ro:0,isacc:0,grid:35,gxgrid:this.GridsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBPOSTALADDRESS",fmt:0,gxz:"ZV59GXV9",gxold:"OV59GXV9",gxvar:"GXV9",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.GXV9=n)},v2z:function(n){n!==undefined&&(gx.O.ZV59GXV9=n)},v2c:function(n){gx.fn.setGridControlValue("LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBPOSTALADDRESS",n||gx.fn.currentGridRowImpl(35),gx.O.GXV9,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV9=this.val(n))},val:function(n){return gx.fn.getGridControlValue("LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBPOSTALADDRESS",n||gx.fn.currentGridRowImpl(35))},nac:gx.falseFn};n[45]={id:45,lvl:2,type:"svchar",len:1024,dec:0,sign:!1,ro:0,isacc:0,grid:35,gxgrid:this.GridsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBVISITINGADDRESS",fmt:0,gxz:"ZV60GXV10",gxold:"OV60GXV10",gxvar:"GXV10",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.GXV10=n)},v2z:function(n){n!==undefined&&(gx.O.ZV60GXV10=n)},v2c:function(n){gx.fn.setGridControlValue("LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBVISITINGADDRESS",n||gx.fn.currentGridRowImpl(35),gx.O.GXV10,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV10=this.val(n))},val:function(n){return gx.fn.getGridControlValue("LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBVISITINGADDRESS",n||gx.fn.currentGridRowImpl(35))},nac:gx.falseFn};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"TABLEACTIONS",grid:0};n[49]={id:49,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,fld:"",grid:0};n[55]={id:55,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};this.AV19LocationOption=0;this.ZV19LocationOption=0;this.OV19LocationOption=0;this.ZV34UDelete="";this.OV34UDelete="";this.ZV52GXV2=0;this.OV52GXV2=0;this.ZV53GXV3="";this.OV53GXV3="";this.ZV54GXV4="";this.OV54GXV4="";this.ZV55GXV5="";this.OV55GXV5="";this.ZV56GXV6="";this.OV56GXV6="";this.ZV57GXV7="";this.OV57GXV7="";this.ZV58GXV8="";this.OV58GXV8="";this.ZV59GXV9="";this.OV59GXV9="";this.ZV60GXV10="";this.OV60GXV10="";this.AV19LocationOption=0;this.AV11DDO_TitleSettingsIcons={Default_fi:"",Filtered_fi:"",SortedASC_fi:"",SortedDSC_fi:"",FilteredSortedASC_fi:"",FilteredSortedDSC_fi:"",OptionSortASC_fi:"",OptionSortDSC_fi:"",OptionApplyFilter_fi:"",OptionFilteringData_fi:"",OptionCleanFilters_fi:"",SelectedOption_fi:"",MultiselOption_fi:"",MultiselSelOption_fi:"",TreeviewCollapse_fi:"",TreeviewExpand_fi:"",FixLeft_fi:"",FixRight_fi:"",OptionGroup_fi:""};this.AV34UDelete="";this.GXV2=0;this.GXV3="";this.GXV4="";this.GXV5="";this.GXV6="";this.GXV7="";this.GXV8="";this.GXV9="";this.GXV10="";this.A55Supplier_AgbId=0;this.A57Supplier_AgbName="";this.AV18LocationAGBSuppliersSDTs=[];this.AV48Customer={CustomerId:0,CustomerKvkNumber:"",CustomerName:"",CustomerPostalAddress:"",CustomerEmail:"",CustomerVisitingAddress:"",CustomerPhone:"",CustomerVatNumber:"",CustomerTypeId:0,CustomerTypeName:"",CustomerLastLine:0,CustomerLastLineLocation:0,Manager:[],Locations:[],Mode:"",Initialized:0,CustomerId_Z:0,CustomerKvkNumber_Z:"",CustomerName_Z:"",CustomerPostalAddress_Z:"",CustomerEmail_Z:"",CustomerVisitingAddress_Z:"",CustomerPhone_Z:"",CustomerVatNumber_Z:"",CustomerTypeId_Z:0,CustomerTypeName_Z:"",CustomerLastLine_Z:0,CustomerLastLineLocation_Z:0};this.AV31SupplierAGBOptions=[];this.Events={e112o2_client:["'DOBACK'",!0],e122o2_client:["ENTER",!0],e132o2_client:["'DOINSERTAGBSUPPLIER'",!0],e162o2_client:["VUDELETE.CLICK",!0],e182o2_client:["CANCEL",!0],e172o1_client:["COMBO_SUPPLIERAGBOPTIONS.ONOPTIONCLICKED",!1]};this.EvtParms.REFRESH=[[{av:"GRIDS_nFirstRecordOnPage"},{av:"GRIDS_nEOF"},{av:"AV18LocationAGBSuppliersSDTs",fld:"vLOCATIONAGBSUPPLIERSSDTS",grid:35,pic:""},{av:"nGXsfl_35_idx",ctrl:"GRID",prop:"GridCurrRow",grid:35},{av:"nRC_GXsfl_35",ctrl:"GRIDS",prop:"GridRC",grid:35},{ctrl:"GRIDS",prop:"Rows"},{ctrl:"vLOCATIONOPTION"},{av:"AV19LocationOption",fld:"vLOCATIONOPTION",pic:"ZZZ9"}],[]];this.EvtParms["GRIDS.LOAD"]=[[],[{av:"AV34UDelete",fld:"vUDELETE",pic:""}]];this.EvtParms["'DOBACK'"]=[[],[]];this.EvtParms.ENTER=[[{av:"AV18LocationAGBSuppliersSDTs",fld:"vLOCATIONAGBSUPPLIERSSDTS",grid:35,pic:""},{av:"nGXsfl_35_idx",ctrl:"GRID",prop:"GridCurrRow",grid:35},{av:"GRIDS_nFirstRecordOnPage"},{av:"nRC_GXsfl_35",ctrl:"GRIDS",prop:"GridRC",grid:35},{ctrl:"vLOCATIONOPTION"},{av:"AV19LocationOption",fld:"vLOCATIONOPTION",pic:"ZZZ9"},{av:"AV48Customer",fld:"vCUSTOMER",pic:""},{av:"GRIDS_nEOF"},{ctrl:"GRIDS",prop:"Rows"}],[{av:"AV48Customer",fld:"vCUSTOMER",pic:""},{av:"AV18LocationAGBSuppliersSDTs",fld:"vLOCATIONAGBSUPPLIERSSDTS",grid:35,pic:""},{av:"nGXsfl_35_idx",ctrl:"GRID",prop:"GridCurrRow",grid:35},{av:"GRIDS_nFirstRecordOnPage"},{av:"nRC_GXsfl_35",ctrl:"GRIDS",prop:"GridRC",grid:35}]];this.EvtParms["'DOINSERTAGBSUPPLIER'"]=[[{av:"AV31SupplierAGBOptions",fld:"vSUPPLIERAGBOPTIONS",pic:""},{av:"AV18LocationAGBSuppliersSDTs",fld:"vLOCATIONAGBSUPPLIERSSDTS",grid:35,pic:""},{av:"nGXsfl_35_idx",ctrl:"GRID",prop:"GridCurrRow",grid:35},{av:"GRIDS_nFirstRecordOnPage"},{av:"nRC_GXsfl_35",ctrl:"GRIDS",prop:"GridRC",grid:35},{av:"GRIDS_nEOF"},{ctrl:"GRIDS",prop:"Rows"},{ctrl:"vLOCATIONOPTION"},{av:"AV19LocationOption",fld:"vLOCATIONOPTION",pic:"ZZZ9"}],[{av:"AV18LocationAGBSuppliersSDTs",fld:"vLOCATIONAGBSUPPLIERSSDTS",grid:35,pic:""},{av:"nGXsfl_35_idx",ctrl:"GRID",prop:"GridCurrRow",grid:35},{av:"GRIDS_nFirstRecordOnPage"},{av:"nRC_GXsfl_35",ctrl:"GRIDS",prop:"GridRC",grid:35},{av:"AV31SupplierAGBOptions",fld:"vSUPPLIERAGBOPTIONS",pic:""}]];this.EvtParms["COMBO_SUPPLIERAGBOPTIONS.ONOPTIONCLICKED"]=[[{av:"this.COMBO_SUPPLIERAGBOPTIONSContainer.SelectedValue_get",ctrl:"COMBO_SUPPLIERAGBOPTIONS",prop:"SelectedValue_get"}],[{av:"AV31SupplierAGBOptions",fld:"vSUPPLIERAGBOPTIONS",pic:""}]];this.EvtParms["VUDELETE.CLICK"]=[[{av:"AV18LocationAGBSuppliersSDTs",fld:"vLOCATIONAGBSUPPLIERSSDTS",grid:35,pic:""},{av:"nGXsfl_35_idx",ctrl:"GRID",prop:"GridCurrRow",grid:35},{av:"GRIDS_nFirstRecordOnPage"},{av:"nRC_GXsfl_35",ctrl:"GRIDS",prop:"GridRC",grid:35},{av:"GRIDS_nEOF"},{ctrl:"GRIDS",prop:"Rows"},{ctrl:"vLOCATIONOPTION"},{av:"AV19LocationOption",fld:"vLOCATIONOPTION",pic:"ZZZ9"}],[{av:"AV18LocationAGBSuppliersSDTs",fld:"vLOCATIONAGBSUPPLIERSSDTS",grid:35,pic:""},{av:"nGXsfl_35_idx",ctrl:"GRID",prop:"GridCurrRow",grid:35},{av:"GRIDS_nFirstRecordOnPage"},{av:"nRC_GXsfl_35",ctrl:"GRIDS",prop:"GridRC",grid:35}]];this.EvtParms.GRIDS_FIRSTPAGE=[[{av:"GRIDS_nFirstRecordOnPage"},{av:"GRIDS_nEOF"},{av:"AV18LocationAGBSuppliersSDTs",fld:"vLOCATIONAGBSUPPLIERSSDTS",grid:35,pic:""},{av:"nGXsfl_35_idx",ctrl:"GRID",prop:"GridCurrRow",grid:35},{av:"nRC_GXsfl_35",ctrl:"GRIDS",prop:"GridRC",grid:35},{ctrl:"GRIDS",prop:"Rows"},{ctrl:"vLOCATIONOPTION"},{av:"AV19LocationOption",fld:"vLOCATIONOPTION",pic:"ZZZ9"}],[]];this.EvtParms.GRIDS_PREVPAGE=[[{av:"GRIDS_nFirstRecordOnPage"},{av:"GRIDS_nEOF"},{av:"AV18LocationAGBSuppliersSDTs",fld:"vLOCATIONAGBSUPPLIERSSDTS",grid:35,pic:""},{av:"nGXsfl_35_idx",ctrl:"GRID",prop:"GridCurrRow",grid:35},{av:"nRC_GXsfl_35",ctrl:"GRIDS",prop:"GridRC",grid:35},{ctrl:"GRIDS",prop:"Rows"},{ctrl:"vLOCATIONOPTION"},{av:"AV19LocationOption",fld:"vLOCATIONOPTION",pic:"ZZZ9"}],[]];this.EvtParms.GRIDS_NEXTPAGE=[[{av:"GRIDS_nFirstRecordOnPage"},{av:"GRIDS_nEOF"},{av:"AV18LocationAGBSuppliersSDTs",fld:"vLOCATIONAGBSUPPLIERSSDTS",grid:35,pic:""},{av:"nGXsfl_35_idx",ctrl:"GRID",prop:"GridCurrRow",grid:35},{av:"nRC_GXsfl_35",ctrl:"GRIDS",prop:"GridRC",grid:35},{ctrl:"GRIDS",prop:"Rows"},{ctrl:"vLOCATIONOPTION"},{av:"AV19LocationOption",fld:"vLOCATIONOPTION",pic:"ZZZ9"}],[]];this.EvtParms.GRIDS_LASTPAGE=[[{av:"GRIDS_nFirstRecordOnPage"},{av:"GRIDS_nEOF"},{av:"AV18LocationAGBSuppliersSDTs",fld:"vLOCATIONAGBSUPPLIERSSDTS",grid:35,pic:""},{av:"nGXsfl_35_idx",ctrl:"GRID",prop:"GridCurrRow",grid:35},{av:"nRC_GXsfl_35",ctrl:"GRIDS",prop:"GridRC",grid:35},{ctrl:"GRIDS",prop:"Rows"},{ctrl:"vLOCATIONOPTION"},{av:"AV19LocationOption",fld:"vLOCATIONOPTION",pic:"ZZZ9"}],[]];this.EvtParms.VALIDV_GXV6=[[{av:"GXV6",fld:"LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBEMAIL",pic:""}],[]];this.EnterCtrl=["BTNENTER"];this.setVCMap("AV18LocationAGBSuppliersSDTs","vLOCATIONAGBSUPPLIERSSDTS",0,"CollLocationAGBSuppliersSDT",0,0);this.setVCMap("AV48Customer","vCUSTOMER",0,"Customer",0,0);this.setVCMap("AV31SupplierAGBOptions","vSUPPLIERAGBOPTIONS",0,"Collint",0,0);this.setVCMap("AV31SupplierAGBOptions","vSUPPLIERAGBOPTIONS",0,"Collint",0,0);i.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grids"});i.addRefreshingParm(this.GXValidFnc[21]);this.addGridBCProperty("Locationagbsupplierssdts",["Supplier_AgbId"],this.GXValidFnc[37],"AV18LocationAGBSuppliersSDTs");this.addGridBCProperty("Locationagbsupplierssdts",["Supplier_AgbName"],this.GXValidFnc[38],"AV18LocationAGBSuppliersSDTs");this.addGridBCProperty("Locationagbsupplierssdts",["Supplier_AgbNumber"],this.GXValidFnc[39],"AV18LocationAGBSuppliersSDTs");this.addGridBCProperty("Locationagbsupplierssdts",["Supplier_AgbKvkNumber"],this.GXValidFnc[40],"AV18LocationAGBSuppliersSDTs");this.addGridBCProperty("Locationagbsupplierssdts",["Supplier_AgbEmail"],this.GXValidFnc[41],"AV18LocationAGBSuppliersSDTs");this.addGridBCProperty("Locationagbsupplierssdts",["Supplier_AgbPhone"],this.GXValidFnc[42],"AV18LocationAGBSuppliersSDTs");this.addGridBCProperty("Locationagbsupplierssdts",["Supplier_AgbContactName"],this.GXValidFnc[43],"AV18LocationAGBSuppliersSDTs");this.addGridBCProperty("Locationagbsupplierssdts",["Supplier_AgbPostalAddress"],this.GXValidFnc[44],"AV18LocationAGBSuppliersSDTs");this.addGridBCProperty("Locationagbsupplierssdts",["Supplier_AgbVisitingAddress"],this.GXValidFnc[45],"AV18LocationAGBSuppliersSDTs");this.Initialize();this.setSDTMapping("GeneXusSecurity\\GAMSession",{User:{sdt:"GeneXusSecurity\\GAMUser"}});this.setSDTMapping("WWPBaseObjects\\DVB_SDTDropDownOptionsTitleSettingsIcons",{Default_fi:{extr:"def"},Filtered_fi:{extr:"fil"},SortedASC_fi:{extr:"asc"},SortedDSC_fi:{extr:"dsc"},FilteredSortedASC_fi:{extr:"fasc"},FilteredSortedDSC_fi:{extr:"fdsc"},OptionSortASC_fi:{extr:"osasc"},OptionSortDSC_fi:{extr:"osdsc"},OptionApplyFilter_fi:{extr:"app"},OptionFilteringData_fi:{extr:"fildata"},OptionCleanFilters_fi:{extr:"cle"},SelectedOption_fi:{extr:"selo"},MultiselOption_fi:{extr:"mul"},MultiselSelOption_fi:{extr:"muls"},TreeviewCollapse_fi:{extr:"tcol"},TreeviewExpand_fi:{extr:"texp"},FixLeft_fi:{extr:"fixl"},FixRight_fi:{extr:"fixr"},OptionGroup_fi:{extr:"og"}});this.setSDTMapping("Customer",{Locations:{sdt:"Customer.Locations"}});this.setSDTMapping("Customer.Locations",{Supplier_Agb:{sdt:"Customer.Locations.Supplier_Agb"}});this.setSDTMapping("WWPBaseObjects\\DVB_SDTComboData.Item",{Title:{extr:"T"},Children:{extr:"C"}})});gx.wi(function(){gx.createParentObj(this.addagbsuppliers)})