gx.evt.autoSkip=!1;gx.define("createresident",!1,function(){this.ServerClass="createresident";this.PackageName="GeneXus.Programs";this.ServerFullClass="createresident.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV13WizardSteps=gx.fn.getControlValue("vWIZARDSTEPS");this.AV12CurrentStepAux=gx.fn.getControlValue("vCURRENTSTEPAUX");this.AV10PreviousStep=gx.fn.getControlValue("vPREVIOUSSTEP");this.AV11CurrentStep=gx.fn.getControlValue("vCURRENTSTEP");this.AV9GoingBack=gx.fn.getControlValue("vGOINGBACK")};this.s112_client=function(){gx.text.compare(this.AV12CurrentStepAux,"Step1")==0?this.createWebComponent("Wizardstepwc","CreateResidentStep1",[this.AV16Pgmname+"_Data",this.AV10PreviousStep,this.AV9GoingBack]):gx.text.compare(this.AV12CurrentStepAux,"Step2")==0?this.createWebComponent("Wizardstepwc","CreateResidentStep2",[this.AV16Pgmname+"_Data",this.AV10PreviousStep,this.AV9GoingBack]):gx.text.compare(this.AV12CurrentStepAux,"Step3")==0?this.createWebComponent("Wizardstepwc","CreateResidentStep3",[this.AV16Pgmname+"_Data",this.AV10PreviousStep,this.AV9GoingBack]):gx.text.compare(this.AV12CurrentStepAux,"Step4")==0&&this.createWebComponent("Wizardstepwc","CreateResidentStep4",[this.AV16Pgmname+"_Data",this.AV10PreviousStep,this.AV9GoingBack])};this.e142t2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e152t2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,12];this.GXLastCtrlId=12;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[12]={id:12,fld:"WIZARDSTEPDESCRIPTION",format:0,grid:0,ctrltype:"textblock"};this.AV10PreviousStep="";this.AV11CurrentStep="";this.AV9GoingBack=!1;this.AV13WizardSteps=[];this.AV12CurrentStepAux="";this.AV16Pgmname="";this.Events={e142t2_client:["ENTER",!0],e152t2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"AV13WizardSteps",fld:"vWIZARDSTEPS",pic:"",hsh:!0},{av:"AV12CurrentStepAux",fld:"vCURRENTSTEPAUX",pic:"",hsh:!0},{av:"AV10PreviousStep",fld:"vPREVIOUSSTEP",pic:"",hsh:!0},{av:"AV11CurrentStep",fld:"vCURRENTSTEP",pic:"",hsh:!0},{av:"AV9GoingBack",fld:"vGOINGBACK",pic:"",hsh:!0}],[{av:'gx.fn.getCtrlProperty("WIZARDSTEPDESCRIPTION","Caption")',ctrl:"WIZARDSTEPDESCRIPTION",prop:"Caption"}]];this.EvtParms.ENTER=[[],[]];this.setVCMap("AV13WizardSteps","vWIZARDSTEPS",0,"CollWWPBaseObjectsWizardSteps.WizardStepsItem",0,0);this.setVCMap("AV12CurrentStepAux","vCURRENTSTEPAUX",0,"svchar",40,0);this.setVCMap("AV10PreviousStep","vPREVIOUSSTEP",0,"svchar",40,0);this.setVCMap("AV11CurrentStep","vCURRENTSTEP",0,"svchar",40,0);this.setVCMap("AV9GoingBack","vGOINGBACK",0,"boolean",4,0);this.Initialize();this.setComponent({id:"STEPTITLES",GXClass:null,Prefix:"W0009",lvl:1});this.setComponent({id:"WIZARDSTEPWC",GXClass:null,Prefix:"W0015",lvl:1})});gx.wi(function(){gx.createParentObj(this.createresident)})