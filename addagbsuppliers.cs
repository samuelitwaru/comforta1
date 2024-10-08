using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class addagbsuppliers : GXDataArea
   {
      public addagbsuppliers( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public addagbsuppliers( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynavLocationoption = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
            gxfirstwebparm_bkp = gxfirstwebparm;
            gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               dyncall( GetNextPar( )) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vLOCATIONOPTION") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvLOCATIONOPTION2O2( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grids") == 0 )
            {
               gxnrGrids_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grids") == 0 )
            {
               gxgrGrids_refresh_invoke( ) ;
               return  ;
            }
            else
            {
               if ( ! IsValidAjaxCall( false) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = gxfirstwebparm_bkp;
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGrids_newrow_invoke( )
      {
         nRC_GXsfl_35 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_35"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_35_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_35_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_35_idx = GetPar( "sGXsfl_35_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrids_newrow( ) ;
         /* End function gxnrGrids_newrow_invoke */
      }

      protected void gxgrGrids_refresh_invoke( )
      {
         subGrids_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrids_Rows"), "."), 18, MidpointRounding.ToEven));
         dynavLocationoption.FromJSonString( GetNextPar( ));
         AV19LocationOption = (short)(Math.Round(NumberUtil.Val( GetPar( "LocationOption"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrids_refresh( subGrids_Rows, AV19LocationOption) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrids_refresh_invoke */
      }

      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      protected override string ExecutePermissionPrefix
      {
         get {
            return "addagbsuppliers_Execute" ;
         }

      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpage", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpage", new Object[] {context});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      public override short ExecuteStartEvent( )
      {
         PA2O2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2O2( ) ;
         }
         return gxajaxcallmode ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         CloseStyles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 312140), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 312140), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 312140), false, true);
         context.AddJavascriptSource("gxcfg.js", "?"+GetCacheInvalidationToken( ), false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
         {
            context.WriteHtmlText( " dir=\"rtl\" ") ;
         }
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("addagbsuppliers.aspx") +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Locationagbsupplierssdts", AV18LocationAGBSuppliersSDTs);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Locationagbsupplierssdts", AV18LocationAGBSuppliersSDTs);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_35", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_35), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV11DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV11DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSUPPLIERAGBOPTIONS_DATA", AV32SupplierAGBOptions_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSUPPLIERAGBOPTIONS_DATA", AV32SupplierAGBOptions_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vLOCATIONAGBSUPPLIERSSDTS", AV18LocationAGBSuppliersSDTs);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vLOCATIONAGBSUPPLIERSSDTS", AV18LocationAGBSuppliersSDTs);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCUSTOMER", AV48Customer);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCUSTOMER", AV48Customer);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSUPPLIERAGBOPTIONS", AV31SupplierAGBOptions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSUPPLIERAGBOPTIONS", AV31SupplierAGBOptions);
         }
         GxWebStd.gx_hidden_field( context, "GRIDS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRIDS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRIDS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERAGBOPTIONS_Selectedvalue_get", StringUtil.RTrim( Combo_supplieragboptions_Selectedvalue_get));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
         context.WriteHtmlText( "<script type=\"text/javascript\">") ;
         context.WriteHtmlText( "gx.setLanguageCode(\""+context.GetLanguageProperty( "code")+"\");") ;
         if ( ! context.isSpaRequest( ) )
         {
            context.WriteHtmlText( "gx.setDateFormat(\""+context.GetLanguageProperty( "date_fmt")+"\");") ;
            context.WriteHtmlText( "gx.setTimeFormat("+context.GetLanguageProperty( "time_fmt")+");") ;
            context.WriteHtmlText( "gx.setCenturyFirstYear("+40+");") ;
            context.WriteHtmlText( "gx.setDecimalPoint(\""+context.GetLanguageProperty( "decimal_point")+"\");") ;
            context.WriteHtmlText( "gx.setThousandSeparator(\""+context.GetLanguageProperty( "thousand_sep")+"\");") ;
            context.WriteHtmlText( "gx.StorageTimeZone = "+1+";") ;
         }
         context.WriteHtmlText( "</script>") ;
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE2O2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2O2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("addagbsuppliers.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "AddAgbSuppliers" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Add AGB Suppliers", "") ;
      }

      protected void WB2O0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavLocationoption_Internalname, context.GetMessage( "Location Option", ""), "gx-form-item AddressAttributeLabel AttirbuteLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'" + sGXsfl_35_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavLocationoption, dynavLocationoption_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV19LocationOption), 4, 0)), 1, dynavLocationoption_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", dynavLocationoption.Visible, dynavLocationoption.Enabled, 0, 0, 30, "em", 0, "", "", "AddressAttribute Attirbute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "", true, 0, "HLP_AddAgbSuppliers.htm");
            dynavLocationoption.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19LocationOption), 4, 0));
            AssignProp("", false, dynavLocationoption_Internalname, "Values", (string)(dynavLocationoption.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacer1_Internalname, "     ", "", "", lblSpacer1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "MainContainer", 0, "", 1, 1, 0, 0, "HLP_AddAgbSuppliers.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ExtendedComboCell", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_supplieragboptions.SetProperty("Caption", Combo_supplieragboptions_Caption);
            ucCombo_supplieragboptions.SetProperty("Cls", Combo_supplieragboptions_Cls);
            ucCombo_supplieragboptions.SetProperty("AllowMultipleSelection", Combo_supplieragboptions_Allowmultipleselection);
            ucCombo_supplieragboptions.SetProperty("DataListProc", Combo_supplieragboptions_Datalistproc);
            ucCombo_supplieragboptions.SetProperty("DataListProcParametersPrefix", Combo_supplieragboptions_Datalistprocparametersprefix);
            ucCombo_supplieragboptions.SetProperty("IncludeOnlySelectedOption", Combo_supplieragboptions_Includeonlyselectedoption);
            ucCombo_supplieragboptions.SetProperty("MultipleValuesType", Combo_supplieragboptions_Multiplevaluestype);
            ucCombo_supplieragboptions.SetProperty("EmptyItemText", Combo_supplieragboptions_Emptyitemtext);
            ucCombo_supplieragboptions.SetProperty("DropDownOptionsTitleSettingsIcons", AV11DDO_TitleSettingsIcons);
            ucCombo_supplieragboptions.SetProperty("DropDownOptionsData", AV32SupplierAGBOptions_Data);
            ucCombo_supplieragboptions.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_supplieragboptions_Internalname, "COMBO_SUPPLIERAGBOPTIONSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacer2_Internalname, "     ", "", "", lblSpacer2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "MainContainer", 0, "", 1, 1, 0, 0, "HLP_AddAgbSuppliers.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "align-self:flex-start;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsertagbsupplier_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(35), 2, 0)+","+"null"+");", context.GetMessage( "Add", ""), bttBtninsertagbsupplier_Jsonclick, 5, context.GetMessage( "Add new item", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERTAGBSUPPLIER\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_AddAgbSuppliers.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablegrid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders HasGridEmpowerer", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridsContainer.SetWrapped(nGXWrapped);
            StartGridControl35( ) ;
         }
         if ( wbEnd == 35 )
         {
            wbEnd = 0;
            nRC_GXsfl_35 = (int)(nGXsfl_35_idx-1);
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridsContainer.AddObjectProperty("GRIDS_nEOF", GRIDS_nEOF);
               GridsContainer.AddObjectProperty("GRIDS_nFirstRecordOnPage", GRIDS_nFirstRecordOnPage);
               AV51GXV1 = nGXsfl_35_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grids", GridsContainer, subGrids_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridsContainerData", GridsContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridsContainerData"+"V", GridsContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridsContainerData"+"V"+"\" value='"+GridsContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellWizardActions", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;justify-content:flex-end;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucBtnback.SetProperty("TooltipText", Btnback_Tooltiptext);
            ucBtnback.SetProperty("Caption", Btnback_Caption);
            ucBtnback.SetProperty("Class", Btnback_Class);
            ucBtnback.Render(context, "wwp_iconbutton", Btnback_Internalname, "BTNBACKContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* User Defined Control */
            ucBtnenter.SetProperty("TooltipText", Btnenter_Tooltiptext);
            ucBtnenter.SetProperty("Caption", Btnenter_Caption);
            ucBtnenter.SetProperty("Class", Btnenter_Class);
            ucBtnenter.Render(context, "wwp_iconbutton", Btnenter_Internalname, "BTNENTERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGrids_empowerer.Render(context, "wwp.gridempowerer", Grids_empowerer_Internalname, "GRIDS_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 35 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridsContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GridsContainer.AddObjectProperty("GRIDS_nEOF", GRIDS_nEOF);
                  GridsContainer.AddObjectProperty("GRIDS_nFirstRecordOnPage", GRIDS_nFirstRecordOnPage);
                  AV51GXV1 = nGXsfl_35_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grids", GridsContainer, subGrids_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridsContainerData", GridsContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridsContainerData"+"V", GridsContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridsContainerData"+"V"+"\" value='"+GridsContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START2O2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_6-177934", 0) ;
            }
         }
         Form.Meta.addItem("description", context.GetMessage( "Add AGB Suppliers", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2O0( ) ;
      }

      protected void WS2O2( )
      {
         START2O2( ) ;
         EVT2O2( ) ;
      }

      protected void EVT2O2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBACK'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBack' */
                              E112O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                    /* Execute user event: Enter */
                                    E122O2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERTAGBSUPPLIER'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsertAGBSupplier' */
                              E132O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDSPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRIDSPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrids_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrids_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrids_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrids_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRIDS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "VUDELETE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "VUDELETE.CLICK") == 0 ) )
                           {
                              nGXsfl_35_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
                              SubsflControlProps_352( ) ;
                              AV51GXV1 = (int)(nGXsfl_35_idx+GRIDS_nFirstRecordOnPage);
                              if ( ( AV18LocationAGBSuppliersSDTs.Count >= AV51GXV1 ) && ( AV51GXV1 > 0 ) )
                              {
                                 AV18LocationAGBSuppliersSDTs.CurrentItem = ((SdtLocationAGBSuppliersSDT)AV18LocationAGBSuppliersSDTs.Item(AV51GXV1));
                                 AV34UDelete = cgiGet( edtavUdelete_Internalname);
                                 AssignAttri("", false, edtavUdelete_Internalname, AV34UDelete);
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E142O2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDS.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E152O2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VUDELETE.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E162O2 ();
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE2O2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA2O2( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            init_web_controls( ) ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = dynavLocationoption_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVvLOCATIONOPTION2O2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvLOCATIONOPTION_data2O2( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXVvLOCATIONOPTION_html2O2( )
      {
         short gxdynajaxvalue;
         GXDLVvLOCATIONOPTION_data2O2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavLocationoption.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavLocationoption.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynavLocationoption.ItemCount > 0 )
         {
            AV19LocationOption = (short)(Math.Round(NumberUtil.Val( dynavLocationoption.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV19LocationOption), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV19LocationOption", StringUtil.LTrimStr( (decimal)(AV19LocationOption), 4, 0));
         }
      }

      protected void GXDLVvLOCATIONOPTION_data2O2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H002O2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            if ( H002O2_A1CustomerId[0] == new getloggedinusercustomerid(context).executeUdp( ) )
            {
               gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H002O2_A18CustomerLocationId[0]), 4, 0, ".", "")));
               gxdynajaxctrldescr.Add(H002O2_A134CustomerLocationName[0]);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void gxnrGrids_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_352( ) ;
         while ( nGXsfl_35_idx <= nRC_GXsfl_35 )
         {
            sendrow_352( ) ;
            nGXsfl_35_idx = ((subGrids_Islastpage==1)&&(nGXsfl_35_idx+1>subGrids_fnc_Recordsperpage( )) ? 1 : nGXsfl_35_idx+1);
            sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
            SubsflControlProps_352( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridsContainer)) ;
         /* End function gxnrGrids_newrow */
      }

      protected void gxgrGrids_refresh( int subGrids_Rows ,
                                        short AV19LocationOption )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDS_nCurrentRecord = 0;
         RF2O2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrids_refresh */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXVvLOCATIONOPTION_html2O2( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavLocationoption.ItemCount > 0 )
         {
            AV19LocationOption = (short)(Math.Round(NumberUtil.Val( dynavLocationoption.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV19LocationOption), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV19LocationOption", StringUtil.LTrimStr( (decimal)(AV19LocationOption), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavLocationoption.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19LocationOption), 4, 0));
            AssignProp("", false, dynavLocationoption_Internalname, "Values", dynavLocationoption.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF2O2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavUdelete_Enabled = 0;
         AssignProp("", false, edtavUdelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUdelete_Enabled), 5, 0), !bGXsfl_35_Refreshing);
         edtavLocationagbsupplierssdts__supplier_agbid_Enabled = 0;
         AssignProp("", false, edtavLocationagbsupplierssdts__supplier_agbid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationagbsupplierssdts__supplier_agbid_Enabled), 5, 0), !bGXsfl_35_Refreshing);
         edtavLocationagbsupplierssdts__supplier_agbname_Enabled = 0;
         AssignProp("", false, edtavLocationagbsupplierssdts__supplier_agbname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationagbsupplierssdts__supplier_agbname_Enabled), 5, 0), !bGXsfl_35_Refreshing);
         edtavLocationagbsupplierssdts__supplier_agbnumber_Enabled = 0;
         AssignProp("", false, edtavLocationagbsupplierssdts__supplier_agbnumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationagbsupplierssdts__supplier_agbnumber_Enabled), 5, 0), !bGXsfl_35_Refreshing);
         edtavLocationagbsupplierssdts__supplier_agbkvknumber_Enabled = 0;
         AssignProp("", false, edtavLocationagbsupplierssdts__supplier_agbkvknumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationagbsupplierssdts__supplier_agbkvknumber_Enabled), 5, 0), !bGXsfl_35_Refreshing);
         edtavLocationagbsupplierssdts__supplier_agbemail_Enabled = 0;
         AssignProp("", false, edtavLocationagbsupplierssdts__supplier_agbemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationagbsupplierssdts__supplier_agbemail_Enabled), 5, 0), !bGXsfl_35_Refreshing);
         edtavLocationagbsupplierssdts__supplier_agbphone_Enabled = 0;
         AssignProp("", false, edtavLocationagbsupplierssdts__supplier_agbphone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationagbsupplierssdts__supplier_agbphone_Enabled), 5, 0), !bGXsfl_35_Refreshing);
         edtavLocationagbsupplierssdts__supplier_agbcontactname_Enabled = 0;
         AssignProp("", false, edtavLocationagbsupplierssdts__supplier_agbcontactname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationagbsupplierssdts__supplier_agbcontactname_Enabled), 5, 0), !bGXsfl_35_Refreshing);
         edtavLocationagbsupplierssdts__supplier_agbpostaladdress_Enabled = 0;
         AssignProp("", false, edtavLocationagbsupplierssdts__supplier_agbpostaladdress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationagbsupplierssdts__supplier_agbpostaladdress_Enabled), 5, 0), !bGXsfl_35_Refreshing);
         edtavLocationagbsupplierssdts__supplier_agbvisitingaddress_Enabled = 0;
         AssignProp("", false, edtavLocationagbsupplierssdts__supplier_agbvisitingaddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationagbsupplierssdts__supplier_agbvisitingaddress_Enabled), 5, 0), !bGXsfl_35_Refreshing);
      }

      protected void RF2O2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridsContainer.ClearRows();
         }
         wbStart = 35;
         nGXsfl_35_idx = 1;
         sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
         SubsflControlProps_352( ) ;
         bGXsfl_35_Refreshing = true;
         GridsContainer.AddObjectProperty("GridName", "Grids");
         GridsContainer.AddObjectProperty("CmpContext", "");
         GridsContainer.AddObjectProperty("InMasterPage", "false");
         GridsContainer.AddObjectProperty("Class", "WorkWith");
         GridsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Backcolorstyle), 1, 0, ".", "")));
         GridsContainer.PageSize = subGrids_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_352( ) ;
            E152O2 ();
            if ( ( subGrids_Islastpage == 0 ) && ( GRIDS_nCurrentRecord > 0 ) && ( GRIDS_nGridOutOfScope == 0 ) && ( nGXsfl_35_idx == 1 ) )
            {
               GRIDS_nCurrentRecord = 0;
               GRIDS_nGridOutOfScope = 1;
               subgrids_firstpage( ) ;
               E152O2 ();
            }
            wbEnd = 35;
            WB2O0( ) ;
         }
         bGXsfl_35_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2O2( )
      {
      }

      protected int subGrids_fnc_Pagecount( )
      {
         GRIDS_nRecordCount = subGrids_fnc_Recordcount( );
         if ( ((int)((GRIDS_nRecordCount) % (subGrids_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRIDS_nRecordCount/ (decimal)(subGrids_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDS_nRecordCount/ (decimal)(subGrids_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrids_fnc_Recordcount( )
      {
         return AV18LocationAGBSuppliersSDTs.Count ;
      }

      protected int subGrids_fnc_Recordsperpage( )
      {
         if ( subGrids_Rows > 0 )
         {
            return subGrids_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrids_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDS_nFirstRecordOnPage/ (decimal)(subGrids_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrids_firstpage( )
      {
         GRIDS_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRIDS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrids_refresh( subGrids_Rows, AV19LocationOption) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrids_nextpage( )
      {
         GRIDS_nRecordCount = subGrids_fnc_Recordcount( );
         if ( ( GRIDS_nRecordCount >= subGrids_fnc_Recordsperpage( ) ) && ( GRIDS_nEOF == 0 ) )
         {
            GRIDS_nFirstRecordOnPage = (long)(GRIDS_nFirstRecordOnPage+subGrids_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nFirstRecordOnPage), 15, 0, ".", "")));
         GridsContainer.AddObjectProperty("GRIDS_nFirstRecordOnPage", GRIDS_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrids_refresh( subGrids_Rows, AV19LocationOption) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDS_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrids_previouspage( )
      {
         if ( GRIDS_nFirstRecordOnPage >= subGrids_fnc_Recordsperpage( ) )
         {
            GRIDS_nFirstRecordOnPage = (long)(GRIDS_nFirstRecordOnPage-subGrids_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrids_refresh( subGrids_Rows, AV19LocationOption) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrids_lastpage( )
      {
         GRIDS_nRecordCount = subGrids_fnc_Recordcount( );
         if ( GRIDS_nRecordCount > subGrids_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRIDS_nRecordCount) % (subGrids_fnc_Recordsperpage( )))) == 0 )
            {
               GRIDS_nFirstRecordOnPage = (long)(GRIDS_nRecordCount-subGrids_fnc_Recordsperpage( ));
            }
            else
            {
               GRIDS_nFirstRecordOnPage = (long)(GRIDS_nRecordCount-((int)((GRIDS_nRecordCount) % (subGrids_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRIDS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrids_refresh( subGrids_Rows, AV19LocationOption) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrids_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDS_nFirstRecordOnPage = (long)(subGrids_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrids_refresh( subGrids_Rows, AV19LocationOption) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtavUdelete_Enabled = 0;
         AssignProp("", false, edtavUdelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUdelete_Enabled), 5, 0), !bGXsfl_35_Refreshing);
         edtavLocationagbsupplierssdts__supplier_agbid_Enabled = 0;
         AssignProp("", false, edtavLocationagbsupplierssdts__supplier_agbid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationagbsupplierssdts__supplier_agbid_Enabled), 5, 0), !bGXsfl_35_Refreshing);
         edtavLocationagbsupplierssdts__supplier_agbname_Enabled = 0;
         AssignProp("", false, edtavLocationagbsupplierssdts__supplier_agbname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationagbsupplierssdts__supplier_agbname_Enabled), 5, 0), !bGXsfl_35_Refreshing);
         edtavLocationagbsupplierssdts__supplier_agbnumber_Enabled = 0;
         AssignProp("", false, edtavLocationagbsupplierssdts__supplier_agbnumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationagbsupplierssdts__supplier_agbnumber_Enabled), 5, 0), !bGXsfl_35_Refreshing);
         edtavLocationagbsupplierssdts__supplier_agbkvknumber_Enabled = 0;
         AssignProp("", false, edtavLocationagbsupplierssdts__supplier_agbkvknumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationagbsupplierssdts__supplier_agbkvknumber_Enabled), 5, 0), !bGXsfl_35_Refreshing);
         edtavLocationagbsupplierssdts__supplier_agbemail_Enabled = 0;
         AssignProp("", false, edtavLocationagbsupplierssdts__supplier_agbemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationagbsupplierssdts__supplier_agbemail_Enabled), 5, 0), !bGXsfl_35_Refreshing);
         edtavLocationagbsupplierssdts__supplier_agbphone_Enabled = 0;
         AssignProp("", false, edtavLocationagbsupplierssdts__supplier_agbphone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationagbsupplierssdts__supplier_agbphone_Enabled), 5, 0), !bGXsfl_35_Refreshing);
         edtavLocationagbsupplierssdts__supplier_agbcontactname_Enabled = 0;
         AssignProp("", false, edtavLocationagbsupplierssdts__supplier_agbcontactname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationagbsupplierssdts__supplier_agbcontactname_Enabled), 5, 0), !bGXsfl_35_Refreshing);
         edtavLocationagbsupplierssdts__supplier_agbpostaladdress_Enabled = 0;
         AssignProp("", false, edtavLocationagbsupplierssdts__supplier_agbpostaladdress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationagbsupplierssdts__supplier_agbpostaladdress_Enabled), 5, 0), !bGXsfl_35_Refreshing);
         edtavLocationagbsupplierssdts__supplier_agbvisitingaddress_Enabled = 0;
         AssignProp("", false, edtavLocationagbsupplierssdts__supplier_agbvisitingaddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationagbsupplierssdts__supplier_agbvisitingaddress_Enabled), 5, 0), !bGXsfl_35_Refreshing);
         GXVvLOCATIONOPTION_html2O2( ) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2O0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E142O2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Locationagbsupplierssdts"), AV18LocationAGBSuppliersSDTs);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV11DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vSUPPLIERAGBOPTIONS_DATA"), AV32SupplierAGBOptions_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vLOCATIONAGBSUPPLIERSSDTS"), AV18LocationAGBSuppliersSDTs);
            ajax_req_read_hidden_sdt(cgiGet( "vSUPPLIERAGBOPTIONS"), AV31SupplierAGBOptions);
            /* Read saved values. */
            nRC_GXsfl_35 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_35"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRIDS_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDS_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRIDS_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDS_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrids_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDS_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRIDS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Rows), 6, 0, ".", "")));
            nRC_GXsfl_35 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_35"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nGXsfl_35_fel_idx = 0;
            while ( nGXsfl_35_fel_idx < nRC_GXsfl_35 )
            {
               nGXsfl_35_fel_idx = ((subGrids_Islastpage==1)&&(nGXsfl_35_fel_idx+1>subGrids_fnc_Recordsperpage( )) ? 1 : nGXsfl_35_fel_idx+1);
               sGXsfl_35_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_352( ) ;
               AV51GXV1 = (int)(nGXsfl_35_fel_idx+GRIDS_nFirstRecordOnPage);
               if ( ( AV18LocationAGBSuppliersSDTs.Count >= AV51GXV1 ) && ( AV51GXV1 > 0 ) )
               {
                  AV18LocationAGBSuppliersSDTs.CurrentItem = ((SdtLocationAGBSuppliersSDT)AV18LocationAGBSuppliersSDTs.Item(AV51GXV1));
                  AV34UDelete = cgiGet( edtavUdelete_Internalname);
               }
            }
            if ( nGXsfl_35_fel_idx == 0 )
            {
               nGXsfl_35_idx = 1;
               sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
               SubsflControlProps_352( ) ;
            }
            nGXsfl_35_fel_idx = 1;
            /* Read variables values. */
            dynavLocationoption.Name = dynavLocationoption_Internalname;
            dynavLocationoption.CurrentValue = cgiGet( dynavLocationoption_Internalname);
            AV19LocationOption = (short)(Math.Round(NumberUtil.Val( cgiGet( dynavLocationoption_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV19LocationOption", StringUtil.LTrimStr( (decimal)(AV19LocationOption), 4, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E142O2 ();
         if (returnInSub) return;
      }

      protected void E142O2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV11DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV11DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         AV13GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV12GAMErrors);
         Combo_supplieragboptions_Gamoauthtoken = AV13GAMSession.gxTpr_Token;
         ucCombo_supplieragboptions.SendProperty(context, "", false, Combo_supplieragboptions_Internalname, "GAMOAuthToken", Combo_supplieragboptions_Gamoauthtoken);
         /* Execute user subroutine: 'LOADCOMBOSUPPLIERAGBOPTIONS' */
         S112 ();
         if (returnInSub) return;
         Grids_empowerer_Gridinternalname = subGrids_Internalname;
         ucGrids_empowerer.SendProperty(context, "", false, Grids_empowerer_Internalname, "GridInternalName", Grids_empowerer_Gridinternalname);
         subGrids_Rows = 0;
         GxWebStd.gx_hidden_field( context, "GRIDS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Rows), 6, 0, ".", "")));
         GXt_int2 = AV47CustomerId;
         new getloggedinusercustomerid(context ).execute( out  GXt_int2) ;
         AV47CustomerId = GXt_int2;
         AV48Customer.Load(AV47CustomerId);
         GXt_SdtGAMUser3 = AV43GAMUser;
         new getloggedinuser(context ).execute( out  GXt_SdtGAMUser3) ;
         AV43GAMUser = GXt_SdtGAMUser3;
         if ( AV43GAMUser.checkrole("Customer Manager") )
         {
            dynavLocationoption.Visible = 1;
            AssignProp("", false, dynavLocationoption_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynavLocationoption.Visible), 5, 0), true);
         }
         else
         {
            if ( AV43GAMUser.checkrole("Receptionist") )
            {
               GXt_int2 = AV19LocationOption;
               new getreceptionistlocationid(context ).execute( out  GXt_int2) ;
               AV19LocationOption = GXt_int2;
               AssignAttri("", false, "AV19LocationOption", StringUtil.LTrimStr( (decimal)(AV19LocationOption), 4, 0));
               dynavLocationoption.Visible = 0;
               AssignProp("", false, dynavLocationoption_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynavLocationoption.Visible), 5, 0), true);
            }
         }
      }

      private void E152O2( )
      {
         /* Grids_Load Routine */
         returnInSub = false;
         AV51GXV1 = 1;
         while ( AV51GXV1 <= AV18LocationAGBSuppliersSDTs.Count )
         {
            AV18LocationAGBSuppliersSDTs.CurrentItem = ((SdtLocationAGBSuppliersSDT)AV18LocationAGBSuppliersSDTs.Item(AV51GXV1));
            AV34UDelete = "<i class=\"fa fa-times\"></i>";
            AssignAttri("", false, edtavUdelete_Internalname, AV34UDelete);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 35;
            }
            if ( ( subGrids_Islastpage == 1 ) || ( subGrids_Rows == 0 ) || ( ( GRIDS_nCurrentRecord >= GRIDS_nFirstRecordOnPage ) && ( GRIDS_nCurrentRecord < GRIDS_nFirstRecordOnPage + subGrids_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_352( ) ;
            }
            GRIDS_nEOF = (short)(((GRIDS_nCurrentRecord<GRIDS_nFirstRecordOnPage+subGrids_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRIDS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nEOF), 1, 0, ".", "")));
            GRIDS_nCurrentRecord = (long)(GRIDS_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_35_Refreshing )
            {
               DoAjaxLoad(35, GridsRow);
            }
            AV51GXV1 = (int)(AV51GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      protected void E112O2( )
      {
         /* 'DoBack' Routine */
         returnInSub = false;
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E122O2 ();
         if (returnInSub) return;
      }

      protected void E122O2( )
      {
         AV51GXV1 = (int)(nGXsfl_35_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV51GXV1 > 0 ) && ( AV18LocationAGBSuppliersSDTs.Count >= AV51GXV1 ) )
         {
            AV18LocationAGBSuppliersSDTs.CurrentItem = ((SdtLocationAGBSuppliersSDT)AV18LocationAGBSuppliersSDTs.Item(AV51GXV1));
         }
         /* Enter Routine */
         returnInSub = false;
         AV61GXV11 = 1;
         while ( AV61GXV11 <= AV18LocationAGBSuppliersSDTs.Count )
         {
            AV17LocationAGBSuppliersSDT = ((SdtLocationAGBSuppliersSDT)AV18LocationAGBSuppliersSDTs.Item(AV61GXV11));
            AV49LocationSupplierAGB = new SdtCustomer_Locations_Supplier_Agb(context);
            AV49LocationSupplierAGB.gxTpr_Supplier_agbid = AV17LocationAGBSuppliersSDT.gxTpr_Supplier_agbid;
            AV48Customer.gxTpr_Locations.GetByKey(AV19LocationOption).gxTpr_Supplier_agb.Add(AV49LocationSupplierAGB, 0);
            AV61GXV11 = (int)(AV61GXV11+1);
         }
         if ( AV48Customer.Update() )
         {
            context.CommitDataStores("addagbsuppliers",pr_default);
            AV18LocationAGBSuppliersSDTs.Clear();
            gx_BV35 = true;
            CallWebObject(formatLink("locationagbsuppliers.aspx") );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            AV50ErrorMessages = AV48Customer.GetMessages();
            GX_msglist.addItem(((GeneXus.Utils.SdtMessages_Message)AV50ErrorMessages.Item(1)).gxTpr_Description);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV48Customer", AV48Customer);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18LocationAGBSuppliersSDTs", AV18LocationAGBSuppliersSDTs);
         nGXsfl_35_bak_idx = nGXsfl_35_idx;
         gxgrGrids_refresh( subGrids_Rows, AV19LocationOption) ;
         nGXsfl_35_idx = nGXsfl_35_bak_idx;
         sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
         SubsflControlProps_352( ) ;
      }

      protected void E132O2( )
      {
         AV51GXV1 = (int)(nGXsfl_35_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV51GXV1 > 0 ) && ( AV18LocationAGBSuppliersSDTs.Count >= AV51GXV1 ) )
         {
            AV18LocationAGBSuppliersSDTs.CurrentItem = ((SdtLocationAGBSuppliersSDT)AV18LocationAGBSuppliersSDTs.Item(AV51GXV1));
         }
         /* 'DoInsertAGBSupplier' Routine */
         returnInSub = false;
         AV62GXV12 = 1;
         while ( AV62GXV12 <= AV31SupplierAGBOptions.Count )
         {
            AV5selectedSupplierId = (short)(AV31SupplierAGBOptions.GetNumeric(AV62GXV12));
            AV41SupplierAGB.Load(AV5selectedSupplierId);
            AV17LocationAGBSuppliersSDT = new SdtLocationAGBSuppliersSDT(context);
            AV17LocationAGBSuppliersSDT.gxTpr_Supplier_agbid = AV41SupplierAGB.gxTpr_Supplier_agbid;
            AV17LocationAGBSuppliersSDT.gxTpr_Supplier_agbkvknumber = AV41SupplierAGB.gxTpr_Supplier_agbkvknumber;
            AV17LocationAGBSuppliersSDT.gxTpr_Supplier_agbnumber = AV41SupplierAGB.gxTpr_Supplier_agbnumber;
            AV17LocationAGBSuppliersSDT.gxTpr_Supplier_agbemail = AV41SupplierAGB.gxTpr_Supplier_agbemail;
            AV17LocationAGBSuppliersSDT.gxTpr_Supplier_agbname = AV41SupplierAGB.gxTpr_Supplier_agbname;
            AV17LocationAGBSuppliersSDT.gxTpr_Supplier_agbphone = AV41SupplierAGB.gxTpr_Supplier_agbphone;
            AV17LocationAGBSuppliersSDT.gxTpr_Supplier_agbcontactname = AV41SupplierAGB.gxTpr_Supplier_agbcontactname;
            AV17LocationAGBSuppliersSDT.gxTpr_Supplier_agbpostaladdress = AV41SupplierAGB.gxTpr_Supplier_agbpostaladdress;
            AV17LocationAGBSuppliersSDT.gxTpr_Supplier_agbvisitingaddress = AV41SupplierAGB.gxTpr_Supplier_agbvisitingaddress;
            AV18LocationAGBSuppliersSDTs.Add(AV17LocationAGBSuppliersSDT, 0);
            gx_BV35 = true;
            AV62GXV12 = (int)(AV62GXV12+1);
         }
         AV31SupplierAGBOptions = (GxSimpleCollection<short>)(new GxSimpleCollection<short>());
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18LocationAGBSuppliersSDTs", AV18LocationAGBSuppliersSDTs);
         nGXsfl_35_bak_idx = nGXsfl_35_idx;
         gxgrGrids_refresh( subGrids_Rows, AV19LocationOption) ;
         nGXsfl_35_idx = nGXsfl_35_bak_idx;
         sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
         SubsflControlProps_352( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV31SupplierAGBOptions", AV31SupplierAGBOptions);
      }

      protected void S112( )
      {
         /* 'LOADCOMBOSUPPLIERAGBOPTIONS' Routine */
         returnInSub = false;
         AV21SelectedTextCol = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV63GXV13 = 1;
         while ( AV63GXV13 <= AV31SupplierAGBOptions.Count )
         {
            AV33SupplierAGBOptionsKey = (short)(AV31SupplierAGBOptions.GetNumeric(AV63GXV13));
            AssignAttri("", false, "AV33SupplierAGBOptionsKey", StringUtil.LTrimStr( (decimal)(AV33SupplierAGBOptionsKey), 4, 0));
            AV64GXLvl127 = 0;
            /* Using cursor H002O3 */
            pr_default.execute(1, new Object[] {AV33SupplierAGBOptionsKey});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A55Supplier_AgbId = H002O3_A55Supplier_AgbId[0];
               A57Supplier_AgbName = H002O3_A57Supplier_AgbName[0];
               AV64GXLvl127 = 1;
               AV21SelectedTextCol.Add(A57Supplier_AgbName, 0);
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            if ( AV64GXLvl127 == 0 )
            {
               AV21SelectedTextCol.Add(StringUtil.Trim( StringUtil.Str( (decimal)(AV33SupplierAGBOptionsKey), 4, 0)), 0);
            }
            AV63GXV13 = (int)(AV63GXV13+1);
         }
         Combo_supplieragboptions_Selectedtext_set = AV21SelectedTextCol.ToJSonString(false);
         ucCombo_supplieragboptions.SendProperty(context, "", false, Combo_supplieragboptions_Internalname, "SelectedText_set", Combo_supplieragboptions_Selectedtext_set);
         Combo_supplieragboptions_Selectedvalue_set = AV31SupplierAGBOptions.ToJSonString(false);
         ucCombo_supplieragboptions.SendProperty(context, "", false, Combo_supplieragboptions_Internalname, "SelectedValue_set", Combo_supplieragboptions_Selectedvalue_set);
      }

      protected void E162O2( )
      {
         AV51GXV1 = (int)(nGXsfl_35_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV51GXV1 > 0 ) && ( AV18LocationAGBSuppliersSDTs.Count >= AV51GXV1 ) )
         {
            AV18LocationAGBSuppliersSDTs.CurrentItem = ((SdtLocationAGBSuppliersSDT)AV18LocationAGBSuppliersSDTs.Item(AV51GXV1));
         }
         /* Udelete_Click Routine */
         returnInSub = false;
         AV42SupplierAgbId = ((SdtLocationAGBSuppliersSDT)(AV18LocationAGBSuppliersSDTs.CurrentItem)).gxTpr_Supplier_agbid;
         AV46Index = 1;
         AV65GXV14 = 1;
         while ( AV65GXV14 <= AV18LocationAGBSuppliersSDTs.Count )
         {
            AV17LocationAGBSuppliersSDT = ((SdtLocationAGBSuppliersSDT)AV18LocationAGBSuppliersSDTs.Item(AV65GXV14));
            if ( AV17LocationAGBSuppliersSDT.gxTpr_Supplier_agbid == AV42SupplierAgbId )
            {
               if (true) break;
            }
            else
            {
               AV46Index = (short)(AV46Index+1);
            }
            AV65GXV14 = (int)(AV65GXV14+1);
         }
         if ( AV46Index <= AV18LocationAGBSuppliersSDTs.Count )
         {
            AV18LocationAGBSuppliersSDTs.RemoveItem(AV46Index);
            gx_BV35 = true;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18LocationAGBSuppliersSDTs", AV18LocationAGBSuppliersSDTs);
         nGXsfl_35_bak_idx = nGXsfl_35_idx;
         gxgrGrids_refresh( subGrids_Rows, AV19LocationOption) ;
         nGXsfl_35_idx = nGXsfl_35_bak_idx;
         sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
         SubsflControlProps_352( ) ;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA2O2( ) ;
         WS2O2( ) ;
         WE2O2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20248298253464", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages."+StringUtil.Lower( context.GetLanguageProperty( "code"))+".js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("addagbsuppliers.js", "?20248298253467", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_352( )
      {
         edtavUdelete_Internalname = "vUDELETE_"+sGXsfl_35_idx;
         edtavLocationagbsupplierssdts__supplier_agbid_Internalname = "LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBID_"+sGXsfl_35_idx;
         edtavLocationagbsupplierssdts__supplier_agbname_Internalname = "LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBNAME_"+sGXsfl_35_idx;
         edtavLocationagbsupplierssdts__supplier_agbnumber_Internalname = "LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBNUMBER_"+sGXsfl_35_idx;
         edtavLocationagbsupplierssdts__supplier_agbkvknumber_Internalname = "LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBKVKNUMBER_"+sGXsfl_35_idx;
         edtavLocationagbsupplierssdts__supplier_agbemail_Internalname = "LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBEMAIL_"+sGXsfl_35_idx;
         edtavLocationagbsupplierssdts__supplier_agbphone_Internalname = "LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBPHONE_"+sGXsfl_35_idx;
         edtavLocationagbsupplierssdts__supplier_agbcontactname_Internalname = "LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBCONTACTNAME_"+sGXsfl_35_idx;
         edtavLocationagbsupplierssdts__supplier_agbpostaladdress_Internalname = "LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBPOSTALADDRESS_"+sGXsfl_35_idx;
         edtavLocationagbsupplierssdts__supplier_agbvisitingaddress_Internalname = "LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBVISITINGADDRESS_"+sGXsfl_35_idx;
      }

      protected void SubsflControlProps_fel_352( )
      {
         edtavUdelete_Internalname = "vUDELETE_"+sGXsfl_35_fel_idx;
         edtavLocationagbsupplierssdts__supplier_agbid_Internalname = "LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBID_"+sGXsfl_35_fel_idx;
         edtavLocationagbsupplierssdts__supplier_agbname_Internalname = "LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBNAME_"+sGXsfl_35_fel_idx;
         edtavLocationagbsupplierssdts__supplier_agbnumber_Internalname = "LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBNUMBER_"+sGXsfl_35_fel_idx;
         edtavLocationagbsupplierssdts__supplier_agbkvknumber_Internalname = "LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBKVKNUMBER_"+sGXsfl_35_fel_idx;
         edtavLocationagbsupplierssdts__supplier_agbemail_Internalname = "LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBEMAIL_"+sGXsfl_35_fel_idx;
         edtavLocationagbsupplierssdts__supplier_agbphone_Internalname = "LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBPHONE_"+sGXsfl_35_fel_idx;
         edtavLocationagbsupplierssdts__supplier_agbcontactname_Internalname = "LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBCONTACTNAME_"+sGXsfl_35_fel_idx;
         edtavLocationagbsupplierssdts__supplier_agbpostaladdress_Internalname = "LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBPOSTALADDRESS_"+sGXsfl_35_fel_idx;
         edtavLocationagbsupplierssdts__supplier_agbvisitingaddress_Internalname = "LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBVISITINGADDRESS_"+sGXsfl_35_fel_idx;
      }

      protected void sendrow_352( )
      {
         SubsflControlProps_352( ) ;
         WB2O0( ) ;
         if ( ( subGrids_Rows * 1 == 0 ) || ( nGXsfl_35_idx <= subGrids_fnc_Recordsperpage( ) * 1 ) )
         {
            GridsRow = GXWebRow.GetNew(context,GridsContainer);
            if ( subGrids_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrids_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrids_Class, "") != 0 )
               {
                  subGrids_Linesclass = subGrids_Class+"Odd";
               }
            }
            else if ( subGrids_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrids_Backstyle = 0;
               subGrids_Backcolor = subGrids_Allbackcolor;
               if ( StringUtil.StrCmp(subGrids_Class, "") != 0 )
               {
                  subGrids_Linesclass = subGrids_Class+"Uniform";
               }
            }
            else if ( subGrids_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrids_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrids_Class, "") != 0 )
               {
                  subGrids_Linesclass = subGrids_Class+"Odd";
               }
               subGrids_Backcolor = (int)(0x0);
            }
            else if ( subGrids_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrids_Backstyle = 1;
               if ( ((int)((nGXsfl_35_idx) % (2))) == 0 )
               {
                  subGrids_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrids_Class, "") != 0 )
                  {
                     subGrids_Linesclass = subGrids_Class+"Even";
                  }
               }
               else
               {
                  subGrids_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrids_Class, "") != 0 )
                  {
                     subGrids_Linesclass = subGrids_Class+"Odd";
                  }
               }
            }
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_35_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavUdelete_Enabled!=0)&&(edtavUdelete_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 36,'',false,'"+sGXsfl_35_idx+"',35)\"" : " ");
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUdelete_Internalname,StringUtil.RTrim( AV34UDelete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavUdelete_Enabled!=0)&&(edtavUdelete_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,36);\"" : " "),"'"+""+"'"+",false,"+"'"+"EVUDELETE.CLICK."+sGXsfl_35_idx+"'",(string)"",(string)"",context.GetMessage( "Delete item", ""),(string)"",(string)edtavUdelete_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUdelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationagbsupplierssdts__supplier_agbid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtLocationAGBSuppliersSDT)AV18LocationAGBSuppliersSDTs.Item(AV51GXV1)).gxTpr_Supplier_agbid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtavLocationagbsupplierssdts__supplier_agbid_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtLocationAGBSuppliersSDT)AV18LocationAGBSuppliersSDTs.Item(AV51GXV1)).gxTpr_Supplier_agbid), "ZZZ9") : context.localUtil.Format( (decimal)(((SdtLocationAGBSuppliersSDT)AV18LocationAGBSuppliersSDTs.Item(AV51GXV1)).gxTpr_Supplier_agbid), "ZZZ9"))),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationagbsupplierssdts__supplier_agbid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavLocationagbsupplierssdts__supplier_agbid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationagbsupplierssdts__supplier_agbname_Internalname,((SdtLocationAGBSuppliersSDT)AV18LocationAGBSuppliersSDTs.Item(AV51GXV1)).gxTpr_Supplier_agbname,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationagbsupplierssdts__supplier_agbname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavLocationagbsupplierssdts__supplier_agbname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationagbsupplierssdts__supplier_agbnumber_Internalname,((SdtLocationAGBSuppliersSDT)AV18LocationAGBSuppliersSDTs.Item(AV51GXV1)).gxTpr_Supplier_agbnumber,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationagbsupplierssdts__supplier_agbnumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavLocationagbsupplierssdts__supplier_agbnumber_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationagbsupplierssdts__supplier_agbkvknumber_Internalname,((SdtLocationAGBSuppliersSDT)AV18LocationAGBSuppliersSDTs.Item(AV51GXV1)).gxTpr_Supplier_agbkvknumber,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationagbsupplierssdts__supplier_agbkvknumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavLocationagbsupplierssdts__supplier_agbkvknumber_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationagbsupplierssdts__supplier_agbemail_Internalname,((SdtLocationAGBSuppliersSDT)AV18LocationAGBSuppliersSDTs.Item(AV51GXV1)).gxTpr_Supplier_agbemail,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationagbsupplierssdts__supplier_agbemail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavLocationagbsupplierssdts__supplier_agbemail_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationagbsupplierssdts__supplier_agbphone_Internalname,StringUtil.RTrim( ((SdtLocationAGBSuppliersSDT)AV18LocationAGBSuppliersSDTs.Item(AV51GXV1)).gxTpr_Supplier_agbphone),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationagbsupplierssdts__supplier_agbphone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavLocationagbsupplierssdts__supplier_agbphone_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationagbsupplierssdts__supplier_agbcontactname_Internalname,((SdtLocationAGBSuppliersSDT)AV18LocationAGBSuppliersSDTs.Item(AV51GXV1)).gxTpr_Supplier_agbcontactname,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationagbsupplierssdts__supplier_agbcontactname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavLocationagbsupplierssdts__supplier_agbcontactname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationagbsupplierssdts__supplier_agbpostaladdress_Internalname,((SdtLocationAGBSuppliersSDT)AV18LocationAGBSuppliersSDTs.Item(AV51GXV1)).gxTpr_Supplier_agbpostaladdress,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationagbsupplierssdts__supplier_agbpostaladdress_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavLocationagbsupplierssdts__supplier_agbpostaladdress_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationagbsupplierssdts__supplier_agbvisitingaddress_Internalname,((SdtLocationAGBSuppliersSDT)AV18LocationAGBSuppliersSDTs.Item(AV51GXV1)).gxTpr_Supplier_agbvisitingaddress,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationagbsupplierssdts__supplier_agbvisitingaddress_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavLocationagbsupplierssdts__supplier_agbvisitingaddress_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes2O2( ) ;
            GridsContainer.AddRow(GridsRow);
            nGXsfl_35_idx = ((subGrids_Islastpage==1)&&(nGXsfl_35_idx+1>subGrids_fnc_Recordsperpage( )) ? 1 : nGXsfl_35_idx+1);
            sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
            SubsflControlProps_352( ) ;
         }
         /* End function sendrow_352 */
      }

      protected void init_web_controls( )
      {
         dynavLocationoption.Name = "vLOCATIONOPTION";
         dynavLocationoption.WebTags = "";
         /* End function init_web_controls */
      }

      protected void StartGridControl35( )
      {
         if ( GridsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridsContainer"+"DivS\" data-gxgridid=\"35\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrids_Internalname, subGrids_Internalname, "", "WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrids_Backcolorstyle == 0 )
            {
               subGrids_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrids_Class) > 0 )
               {
                  subGrids_Linesclass = subGrids_Class+"Title";
               }
            }
            else
            {
               subGrids_Titlebackstyle = 1;
               if ( subGrids_Backcolorstyle == 1 )
               {
                  subGrids_Titlebackcolor = subGrids_Allbackcolor;
                  if ( StringUtil.Len( subGrids_Class) > 0 )
                  {
                     subGrids_Linesclass = subGrids_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrids_Class) > 0 )
                  {
                     subGrids_Linesclass = subGrids_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Supplier_Agb Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Supplier Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Number", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "KvKNumber", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Email", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Phone", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Contact Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Postal Address", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Visiting Address", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridsContainer.AddObjectProperty("GridName", "Grids");
         }
         else
         {
            GridsContainer.AddObjectProperty("GridName", "Grids");
            GridsContainer.AddObjectProperty("Header", subGrids_Header);
            GridsContainer.AddObjectProperty("Class", "WorkWith");
            GridsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Backcolorstyle), 1, 0, ".", "")));
            GridsContainer.AddObjectProperty("CmpContext", "");
            GridsContainer.AddObjectProperty("InMasterPage", "false");
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV34UDelete)));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUdelete_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationagbsupplierssdts__supplier_agbid_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationagbsupplierssdts__supplier_agbname_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationagbsupplierssdts__supplier_agbnumber_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationagbsupplierssdts__supplier_agbkvknumber_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationagbsupplierssdts__supplier_agbemail_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationagbsupplierssdts__supplier_agbphone_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationagbsupplierssdts__supplier_agbcontactname_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationagbsupplierssdts__supplier_agbpostaladdress_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationagbsupplierssdts__supplier_agbvisitingaddress_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Selectedindex), 4, 0, ".", "")));
            GridsContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Allowselection), 1, 0, ".", "")));
            GridsContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Selectioncolor), 9, 0, ".", "")));
            GridsContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Allowhovering), 1, 0, ".", "")));
            GridsContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Hoveringcolor), 9, 0, ".", "")));
            GridsContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Allowcollapsing), 1, 0, ".", "")));
            GridsContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         dynavLocationoption_Internalname = "vLOCATIONOPTION";
         lblSpacer1_Internalname = "SPACER1";
         Combo_supplieragboptions_Internalname = "COMBO_SUPPLIERAGBOPTIONS";
         lblSpacer2_Internalname = "SPACER2";
         bttBtninsertagbsupplier_Internalname = "BTNINSERTAGBSUPPLIER";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         edtavUdelete_Internalname = "vUDELETE";
         edtavLocationagbsupplierssdts__supplier_agbid_Internalname = "LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBID";
         edtavLocationagbsupplierssdts__supplier_agbname_Internalname = "LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBNAME";
         edtavLocationagbsupplierssdts__supplier_agbnumber_Internalname = "LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBNUMBER";
         edtavLocationagbsupplierssdts__supplier_agbkvknumber_Internalname = "LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBKVKNUMBER";
         edtavLocationagbsupplierssdts__supplier_agbemail_Internalname = "LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBEMAIL";
         edtavLocationagbsupplierssdts__supplier_agbphone_Internalname = "LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBPHONE";
         edtavLocationagbsupplierssdts__supplier_agbcontactname_Internalname = "LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBCONTACTNAME";
         edtavLocationagbsupplierssdts__supplier_agbpostaladdress_Internalname = "LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBPOSTALADDRESS";
         edtavLocationagbsupplierssdts__supplier_agbvisitingaddress_Internalname = "LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBVISITINGADDRESS";
         divTablegrid_Internalname = "TABLEGRID";
         Btnback_Internalname = "BTNBACK";
         Btnenter_Internalname = "BTNENTER";
         divTableactions_Internalname = "TABLEACTIONS";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         Grids_empowerer_Internalname = "GRIDS_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGrids_Internalname = "GRIDS";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrids_Allowcollapsing = 0;
         subGrids_Allowselection = 0;
         subGrids_Header = "";
         edtavLocationagbsupplierssdts__supplier_agbvisitingaddress_Jsonclick = "";
         edtavLocationagbsupplierssdts__supplier_agbvisitingaddress_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbpostaladdress_Jsonclick = "";
         edtavLocationagbsupplierssdts__supplier_agbpostaladdress_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbcontactname_Jsonclick = "";
         edtavLocationagbsupplierssdts__supplier_agbcontactname_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbphone_Jsonclick = "";
         edtavLocationagbsupplierssdts__supplier_agbphone_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbemail_Jsonclick = "";
         edtavLocationagbsupplierssdts__supplier_agbemail_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbkvknumber_Jsonclick = "";
         edtavLocationagbsupplierssdts__supplier_agbkvknumber_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbnumber_Jsonclick = "";
         edtavLocationagbsupplierssdts__supplier_agbnumber_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbname_Jsonclick = "";
         edtavLocationagbsupplierssdts__supplier_agbname_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbid_Jsonclick = "";
         edtavLocationagbsupplierssdts__supplier_agbid_Enabled = 0;
         edtavUdelete_Jsonclick = "";
         edtavUdelete_Visible = -1;
         edtavUdelete_Enabled = 1;
         subGrids_Class = "WorkWith";
         subGrids_Backcolorstyle = 0;
         edtavLocationagbsupplierssdts__supplier_agbvisitingaddress_Enabled = -1;
         edtavLocationagbsupplierssdts__supplier_agbpostaladdress_Enabled = -1;
         edtavLocationagbsupplierssdts__supplier_agbcontactname_Enabled = -1;
         edtavLocationagbsupplierssdts__supplier_agbphone_Enabled = -1;
         edtavLocationagbsupplierssdts__supplier_agbemail_Enabled = -1;
         edtavLocationagbsupplierssdts__supplier_agbkvknumber_Enabled = -1;
         edtavLocationagbsupplierssdts__supplier_agbnumber_Enabled = -1;
         edtavLocationagbsupplierssdts__supplier_agbname_Enabled = -1;
         edtavLocationagbsupplierssdts__supplier_agbid_Enabled = -1;
         Btnenter_Class = "Button";
         Btnenter_Caption = context.GetMessage( "GX_BtnEnter", "");
         Btnenter_Tooltiptext = "";
         Btnback_Class = "BtnDefault";
         Btnback_Caption = context.GetMessage( "Cancel", "");
         Btnback_Tooltiptext = "";
         Combo_supplieragboptions_Emptyitemtext = "Select AGB Supplier to add";
         Combo_supplieragboptions_Multiplevaluestype = "Tags";
         Combo_supplieragboptions_Includeonlyselectedoption = Convert.ToBoolean( -1);
         Combo_supplieragboptions_Datalistprocparametersprefix = " \"ComboName\": \"SupplierAGBOptions\"";
         Combo_supplieragboptions_Datalistproc = "AddAgbSuppliersLoadDVCombo";
         Combo_supplieragboptions_Allowmultipleselection = Convert.ToBoolean( -1);
         Combo_supplieragboptions_Cls = "ExtendedCombo AddressAttribute ";
         Combo_supplieragboptions_Caption = "";
         dynavLocationoption_Jsonclick = "";
         dynavLocationoption.Visible = 1;
         dynavLocationoption.Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Add AGB Suppliers", "");
         subGrids_Rows = 0;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDS_nFirstRecordOnPage'},{av:'GRIDS_nEOF'},{av:'AV18LocationAGBSuppliersSDTs',fld:'vLOCATIONAGBSUPPLIERSSDTS',grid:35,pic:''},{av:'nGXsfl_35_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:35},{av:'nRC_GXsfl_35',ctrl:'GRIDS',prop:'GridRC',grid:35},{av:'subGrids_Rows',ctrl:'GRIDS',prop:'Rows'},{av:'dynavLocationoption'},{av:'AV19LocationOption',fld:'vLOCATIONOPTION',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("GRIDS.LOAD","{handler:'E152O2',iparms:[]");
         setEventMetadata("GRIDS.LOAD",",oparms:[{av:'AV34UDelete',fld:'vUDELETE',pic:''}]}");
         setEventMetadata("'DOBACK'","{handler:'E112O2',iparms:[]");
         setEventMetadata("'DOBACK'",",oparms:[]}");
         setEventMetadata("ENTER","{handler:'E122O2',iparms:[{av:'AV18LocationAGBSuppliersSDTs',fld:'vLOCATIONAGBSUPPLIERSSDTS',grid:35,pic:''},{av:'nGXsfl_35_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:35},{av:'GRIDS_nFirstRecordOnPage'},{av:'nRC_GXsfl_35',ctrl:'GRIDS',prop:'GridRC',grid:35},{av:'dynavLocationoption'},{av:'AV19LocationOption',fld:'vLOCATIONOPTION',pic:'ZZZ9'},{av:'AV48Customer',fld:'vCUSTOMER',pic:''},{av:'GRIDS_nEOF'},{av:'subGrids_Rows',ctrl:'GRIDS',prop:'Rows'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV48Customer',fld:'vCUSTOMER',pic:''},{av:'AV18LocationAGBSuppliersSDTs',fld:'vLOCATIONAGBSUPPLIERSSDTS',grid:35,pic:''},{av:'nGXsfl_35_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:35},{av:'GRIDS_nFirstRecordOnPage'},{av:'nRC_GXsfl_35',ctrl:'GRIDS',prop:'GridRC',grid:35}]}");
         setEventMetadata("'DOINSERTAGBSUPPLIER'","{handler:'E132O2',iparms:[{av:'AV31SupplierAGBOptions',fld:'vSUPPLIERAGBOPTIONS',pic:''},{av:'AV18LocationAGBSuppliersSDTs',fld:'vLOCATIONAGBSUPPLIERSSDTS',grid:35,pic:''},{av:'nGXsfl_35_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:35},{av:'GRIDS_nFirstRecordOnPage'},{av:'nRC_GXsfl_35',ctrl:'GRIDS',prop:'GridRC',grid:35},{av:'GRIDS_nEOF'},{av:'subGrids_Rows',ctrl:'GRIDS',prop:'Rows'},{av:'dynavLocationoption'},{av:'AV19LocationOption',fld:'vLOCATIONOPTION',pic:'ZZZ9'}]");
         setEventMetadata("'DOINSERTAGBSUPPLIER'",",oparms:[{av:'AV18LocationAGBSuppliersSDTs',fld:'vLOCATIONAGBSUPPLIERSSDTS',grid:35,pic:''},{av:'nGXsfl_35_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:35},{av:'GRIDS_nFirstRecordOnPage'},{av:'nRC_GXsfl_35',ctrl:'GRIDS',prop:'GridRC',grid:35},{av:'AV31SupplierAGBOptions',fld:'vSUPPLIERAGBOPTIONS',pic:''}]}");
         setEventMetadata("VUDELETE.CLICK","{handler:'E162O2',iparms:[{av:'AV18LocationAGBSuppliersSDTs',fld:'vLOCATIONAGBSUPPLIERSSDTS',grid:35,pic:''},{av:'nGXsfl_35_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:35},{av:'GRIDS_nFirstRecordOnPage'},{av:'nRC_GXsfl_35',ctrl:'GRIDS',prop:'GridRC',grid:35},{av:'GRIDS_nEOF'},{av:'subGrids_Rows',ctrl:'GRIDS',prop:'Rows'},{av:'dynavLocationoption'},{av:'AV19LocationOption',fld:'vLOCATIONOPTION',pic:'ZZZ9'}]");
         setEventMetadata("VUDELETE.CLICK",",oparms:[{av:'AV18LocationAGBSuppliersSDTs',fld:'vLOCATIONAGBSUPPLIERSSDTS',grid:35,pic:''},{av:'nGXsfl_35_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:35},{av:'GRIDS_nFirstRecordOnPage'},{av:'nRC_GXsfl_35',ctrl:'GRIDS',prop:'GridRC',grid:35}]}");
         setEventMetadata("GRIDS_FIRSTPAGE","{handler:'subgrids_firstpage',iparms:[{av:'GRIDS_nFirstRecordOnPage'},{av:'GRIDS_nEOF'},{av:'AV18LocationAGBSuppliersSDTs',fld:'vLOCATIONAGBSUPPLIERSSDTS',grid:35,pic:''},{av:'nGXsfl_35_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:35},{av:'nRC_GXsfl_35',ctrl:'GRIDS',prop:'GridRC',grid:35},{av:'subGrids_Rows',ctrl:'GRIDS',prop:'Rows'},{av:'dynavLocationoption'},{av:'AV19LocationOption',fld:'vLOCATIONOPTION',pic:'ZZZ9'}]");
         setEventMetadata("GRIDS_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRIDS_PREVPAGE","{handler:'subgrids_previouspage',iparms:[{av:'GRIDS_nFirstRecordOnPage'},{av:'GRIDS_nEOF'},{av:'AV18LocationAGBSuppliersSDTs',fld:'vLOCATIONAGBSUPPLIERSSDTS',grid:35,pic:''},{av:'nGXsfl_35_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:35},{av:'nRC_GXsfl_35',ctrl:'GRIDS',prop:'GridRC',grid:35},{av:'subGrids_Rows',ctrl:'GRIDS',prop:'Rows'},{av:'dynavLocationoption'},{av:'AV19LocationOption',fld:'vLOCATIONOPTION',pic:'ZZZ9'}]");
         setEventMetadata("GRIDS_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRIDS_NEXTPAGE","{handler:'subgrids_nextpage',iparms:[{av:'GRIDS_nFirstRecordOnPage'},{av:'GRIDS_nEOF'},{av:'AV18LocationAGBSuppliersSDTs',fld:'vLOCATIONAGBSUPPLIERSSDTS',grid:35,pic:''},{av:'nGXsfl_35_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:35},{av:'nRC_GXsfl_35',ctrl:'GRIDS',prop:'GridRC',grid:35},{av:'subGrids_Rows',ctrl:'GRIDS',prop:'Rows'},{av:'dynavLocationoption'},{av:'AV19LocationOption',fld:'vLOCATIONOPTION',pic:'ZZZ9'}]");
         setEventMetadata("GRIDS_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRIDS_LASTPAGE","{handler:'subgrids_lastpage',iparms:[{av:'GRIDS_nFirstRecordOnPage'},{av:'GRIDS_nEOF'},{av:'AV18LocationAGBSuppliersSDTs',fld:'vLOCATIONAGBSUPPLIERSSDTS',grid:35,pic:''},{av:'nGXsfl_35_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:35},{av:'nRC_GXsfl_35',ctrl:'GRIDS',prop:'GridRC',grid:35},{av:'subGrids_Rows',ctrl:'GRIDS',prop:'Rows'},{av:'dynavLocationoption'},{av:'AV19LocationOption',fld:'vLOCATIONOPTION',pic:'ZZZ9'}]");
         setEventMetadata("GRIDS_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_GXV6","{handler:'Validv_Gxv6',iparms:[]");
         setEventMetadata("VALIDV_GXV6",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Gxv10',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         return  ;
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         Combo_supplieragboptions_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV18LocationAGBSuppliersSDTs = new GXBaseCollection<SdtLocationAGBSuppliersSDT>( context, "LocationAGBSuppliersSDT", "");
         AV11DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV32SupplierAGBOptions_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV48Customer = new SdtCustomer(context);
         AV31SupplierAGBOptions = new GxSimpleCollection<short>();
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         lblSpacer1_Jsonclick = "";
         ucCombo_supplieragboptions = new GXUserControl();
         lblSpacer2_Jsonclick = "";
         bttBtninsertagbsupplier_Jsonclick = "";
         GridsContainer = new GXWebGrid( context);
         sStyleString = "";
         ucBtnback = new GXUserControl();
         ucBtnenter = new GXUserControl();
         ucGrids_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV34UDelete = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         scmdbuf = "";
         H002O2_A18CustomerLocationId = new short[1] ;
         H002O2_A134CustomerLocationName = new string[] {""} ;
         H002O2_A1CustomerId = new short[1] ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV13GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV12GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         Combo_supplieragboptions_Gamoauthtoken = "";
         Grids_empowerer_Gridinternalname = "";
         AV43GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         GXt_SdtGAMUser3 = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         GridsRow = new GXWebRow();
         AV17LocationAGBSuppliersSDT = new SdtLocationAGBSuppliersSDT(context);
         AV49LocationSupplierAGB = new SdtCustomer_Locations_Supplier_Agb(context);
         AV50ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV41SupplierAGB = new SdtSupplier_Agb(context);
         AV21SelectedTextCol = new GxSimpleCollection<string>();
         H002O3_A55Supplier_AgbId = new short[1] ;
         H002O3_A57Supplier_AgbName = new string[] {""} ;
         A57Supplier_AgbName = "";
         Combo_supplieragboptions_Selectedtext_set = "";
         Combo_supplieragboptions_Selectedvalue_set = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrids_Linesclass = "";
         ROClassString = "";
         GridsColumn = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.addagbsuppliers__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.addagbsuppliers__default(),
            new Object[][] {
                new Object[] {
               H002O2_A18CustomerLocationId, H002O2_A134CustomerLocationName, H002O2_A1CustomerId
               }
               , new Object[] {
               H002O3_A55Supplier_AgbId, H002O3_A57Supplier_AgbName
               }
            }
         );
         /* GeneXus formulas. */
         edtavUdelete_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbid_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbname_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbnumber_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbkvknumber_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbemail_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbphone_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbcontactname_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbpostaladdress_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbvisitingaddress_Enabled = 0;
      }

      private short GRIDS_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV19LocationOption ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrids_Backcolorstyle ;
      private short AV47CustomerId ;
      private short GXt_int2 ;
      private short AV5selectedSupplierId ;
      private short AV33SupplierAGBOptionsKey ;
      private short AV64GXLvl127 ;
      private short A55Supplier_AgbId ;
      private short AV42SupplierAgbId ;
      private short AV46Index ;
      private short nGXWrapped ;
      private short subGrids_Backstyle ;
      private short subGrids_Titlebackstyle ;
      private short subGrids_Allowselection ;
      private short subGrids_Allowhovering ;
      private short subGrids_Allowcollapsing ;
      private short subGrids_Collapsed ;
      private int nRC_GXsfl_35 ;
      private int subGrids_Rows ;
      private int nGXsfl_35_idx=1 ;
      private int AV51GXV1 ;
      private int gxdynajaxindex ;
      private int subGrids_Islastpage ;
      private int edtavUdelete_Enabled ;
      private int edtavLocationagbsupplierssdts__supplier_agbid_Enabled ;
      private int edtavLocationagbsupplierssdts__supplier_agbname_Enabled ;
      private int edtavLocationagbsupplierssdts__supplier_agbnumber_Enabled ;
      private int edtavLocationagbsupplierssdts__supplier_agbkvknumber_Enabled ;
      private int edtavLocationagbsupplierssdts__supplier_agbemail_Enabled ;
      private int edtavLocationagbsupplierssdts__supplier_agbphone_Enabled ;
      private int edtavLocationagbsupplierssdts__supplier_agbcontactname_Enabled ;
      private int edtavLocationagbsupplierssdts__supplier_agbpostaladdress_Enabled ;
      private int edtavLocationagbsupplierssdts__supplier_agbvisitingaddress_Enabled ;
      private int GRIDS_nGridOutOfScope ;
      private int nGXsfl_35_fel_idx=1 ;
      private int AV61GXV11 ;
      private int nGXsfl_35_bak_idx=1 ;
      private int AV62GXV12 ;
      private int AV63GXV13 ;
      private int AV65GXV14 ;
      private int idxLst ;
      private int subGrids_Backcolor ;
      private int subGrids_Allbackcolor ;
      private int edtavUdelete_Visible ;
      private int subGrids_Titlebackcolor ;
      private int subGrids_Selectedindex ;
      private int subGrids_Selectioncolor ;
      private int subGrids_Hoveringcolor ;
      private long GRIDS_nFirstRecordOnPage ;
      private long GRIDS_nCurrentRecord ;
      private long GRIDS_nRecordCount ;
      private string Combo_supplieragboptions_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_35_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string divUnnamedtable2_Internalname ;
      private string dynavLocationoption_Internalname ;
      private string TempTags ;
      private string dynavLocationoption_Jsonclick ;
      private string lblSpacer1_Internalname ;
      private string lblSpacer1_Jsonclick ;
      private string Combo_supplieragboptions_Caption ;
      private string Combo_supplieragboptions_Cls ;
      private string Combo_supplieragboptions_Datalistproc ;
      private string Combo_supplieragboptions_Datalistprocparametersprefix ;
      private string Combo_supplieragboptions_Multiplevaluestype ;
      private string Combo_supplieragboptions_Emptyitemtext ;
      private string Combo_supplieragboptions_Internalname ;
      private string lblSpacer2_Internalname ;
      private string lblSpacer2_Jsonclick ;
      private string bttBtninsertagbsupplier_Internalname ;
      private string bttBtninsertagbsupplier_Jsonclick ;
      private string divTablegrid_Internalname ;
      private string sStyleString ;
      private string subGrids_Internalname ;
      private string divTableactions_Internalname ;
      private string Btnback_Tooltiptext ;
      private string Btnback_Caption ;
      private string Btnback_Class ;
      private string Btnback_Internalname ;
      private string Btnenter_Tooltiptext ;
      private string Btnenter_Caption ;
      private string Btnenter_Class ;
      private string Btnenter_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Grids_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV34UDelete ;
      private string edtavUdelete_Internalname ;
      private string gxwrpcisep ;
      private string scmdbuf ;
      private string edtavLocationagbsupplierssdts__supplier_agbid_Internalname ;
      private string edtavLocationagbsupplierssdts__supplier_agbname_Internalname ;
      private string edtavLocationagbsupplierssdts__supplier_agbnumber_Internalname ;
      private string edtavLocationagbsupplierssdts__supplier_agbkvknumber_Internalname ;
      private string edtavLocationagbsupplierssdts__supplier_agbemail_Internalname ;
      private string edtavLocationagbsupplierssdts__supplier_agbphone_Internalname ;
      private string edtavLocationagbsupplierssdts__supplier_agbcontactname_Internalname ;
      private string edtavLocationagbsupplierssdts__supplier_agbpostaladdress_Internalname ;
      private string edtavLocationagbsupplierssdts__supplier_agbvisitingaddress_Internalname ;
      private string sGXsfl_35_fel_idx="0001" ;
      private string Combo_supplieragboptions_Gamoauthtoken ;
      private string Grids_empowerer_Gridinternalname ;
      private string Combo_supplieragboptions_Selectedtext_set ;
      private string Combo_supplieragboptions_Selectedvalue_set ;
      private string subGrids_Class ;
      private string subGrids_Linesclass ;
      private string ROClassString ;
      private string edtavUdelete_Jsonclick ;
      private string edtavLocationagbsupplierssdts__supplier_agbid_Jsonclick ;
      private string edtavLocationagbsupplierssdts__supplier_agbname_Jsonclick ;
      private string edtavLocationagbsupplierssdts__supplier_agbnumber_Jsonclick ;
      private string edtavLocationagbsupplierssdts__supplier_agbkvknumber_Jsonclick ;
      private string edtavLocationagbsupplierssdts__supplier_agbemail_Jsonclick ;
      private string edtavLocationagbsupplierssdts__supplier_agbphone_Jsonclick ;
      private string edtavLocationagbsupplierssdts__supplier_agbcontactname_Jsonclick ;
      private string edtavLocationagbsupplierssdts__supplier_agbpostaladdress_Jsonclick ;
      private string edtavLocationagbsupplierssdts__supplier_agbvisitingaddress_Jsonclick ;
      private string subGrids_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Combo_supplieragboptions_Allowmultipleselection ;
      private bool Combo_supplieragboptions_Includeonlyselectedoption ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool bGXsfl_35_Refreshing=false ;
      private bool returnInSub ;
      private bool gx_BV35 ;
      private string A57Supplier_AgbName ;
      private GxSimpleCollection<short> AV31SupplierAGBOptions ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid GridsContainer ;
      private GXWebRow GridsRow ;
      private GXWebColumn GridsColumn ;
      private GXUserControl ucCombo_supplieragboptions ;
      private GXUserControl ucBtnback ;
      private GXUserControl ucBtnenter ;
      private GXUserControl ucGrids_empowerer ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavLocationoption ;
      private IDataStoreProvider pr_default ;
      private short[] H002O2_A18CustomerLocationId ;
      private string[] H002O2_A134CustomerLocationName ;
      private short[] H002O2_A1CustomerId ;
      private short[] H002O3_A55Supplier_AgbId ;
      private string[] H002O3_A57Supplier_AgbName ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GxSimpleCollection<string> AV21SelectedTextCol ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV32SupplierAGBOptions_Data ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV12GAMErrors ;
      private GXBaseCollection<SdtLocationAGBSuppliersSDT> AV18LocationAGBSuppliersSDTs ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV50ErrorMessages ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV11DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV13GAMSession ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV43GAMUser ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser GXt_SdtGAMUser3 ;
      private SdtLocationAGBSuppliersSDT AV17LocationAGBSuppliersSDT ;
      private SdtSupplier_Agb AV41SupplierAGB ;
      private SdtCustomer AV48Customer ;
      private SdtCustomer_Locations_Supplier_Agb AV49LocationSupplierAGB ;
   }

   public class addagbsuppliers__gam : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "GAM";
    }

 }

 public class addagbsuppliers__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmH002O2;
        prmH002O2 = new Object[] {
        };
        Object[] prmH002O3;
        prmH002O3 = new Object[] {
        new ParDef("AV33SupplierAGBOptionsKey",GXType.Int16,4,0)
        };
        def= new CursorDef[] {
            new CursorDef("H002O2", "SELECT CustomerLocationId, CustomerLocationName, CustomerId FROM CustomerLocation ORDER BY CustomerLocationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002O2,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H002O3", "SELECT Supplier_AgbId, Supplier_AgbName FROM Supplier_AGB WHERE Supplier_AgbId = :AV33SupplierAGBOptionsKey ORDER BY Supplier_AgbId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002O3,1, GxCacheFrequency.OFF ,false,true )
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
     switch ( cursor )
     {
           case 0 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
     }
  }

}

}
