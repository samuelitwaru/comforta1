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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class supplier_agbww : GXDataArea
   {
      public supplier_agbww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public supplier_agbww( IGxContext context )
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               gxnrGrid_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
            {
               gxgrGrid_refresh_invoke( ) ;
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

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_37 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_37"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_37_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_37_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_37_idx = GetPar( "sGXsfl_37_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid_newrow( ) ;
         /* End function gxnrGrid_newrow_invoke */
      }

      protected void gxgrGrid_refresh_invoke( )
      {
         subGrid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid_Rows"), "."), 18, MidpointRounding.ToEven));
         AV16FilterFullText = GetPar( "FilterFullText");
         AV24ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV19ColumnsSelector);
         AV56Pgmname = GetPar( "Pgmname");
         AV25TFSupplier_AgbId = (short)(Math.Round(NumberUtil.Val( GetPar( "TFSupplier_AgbId"), "."), 18, MidpointRounding.ToEven));
         AV26TFSupplier_AgbId_To = (short)(Math.Round(NumberUtil.Val( GetPar( "TFSupplier_AgbId_To"), "."), 18, MidpointRounding.ToEven));
         AV27TFSupplier_AgbNumber = GetPar( "TFSupplier_AgbNumber");
         AV28TFSupplier_AgbNumber_Sel = GetPar( "TFSupplier_AgbNumber_Sel");
         AV29TFSupplier_AgbName = GetPar( "TFSupplier_AgbName");
         AV30TFSupplier_AgbName_Sel = GetPar( "TFSupplier_AgbName_Sel");
         AV31TFSupplier_AgbKvkNumber = GetPar( "TFSupplier_AgbKvkNumber");
         AV32TFSupplier_AgbKvkNumber_Sel = GetPar( "TFSupplier_AgbKvkNumber_Sel");
         AV33TFSupplier_AgbVisitingAddress = GetPar( "TFSupplier_AgbVisitingAddress");
         AV34TFSupplier_AgbVisitingAddress_Sel = GetPar( "TFSupplier_AgbVisitingAddress_Sel");
         AV35TFSupplier_AgbPostalAddress = GetPar( "TFSupplier_AgbPostalAddress");
         AV36TFSupplier_AgbPostalAddress_Sel = GetPar( "TFSupplier_AgbPostalAddress_Sel");
         AV37TFSupplier_AgbEmail = GetPar( "TFSupplier_AgbEmail");
         AV38TFSupplier_AgbEmail_Sel = GetPar( "TFSupplier_AgbEmail_Sel");
         AV39TFSupplier_AgbPhone = GetPar( "TFSupplier_AgbPhone");
         AV40TFSupplier_AgbPhone_Sel = GetPar( "TFSupplier_AgbPhone_Sel");
         AV41TFSupplier_AgbContactName = GetPar( "TFSupplier_AgbContactName");
         AV42TFSupplier_AgbContactName_Sel = GetPar( "TFSupplier_AgbContactName_Sel");
         AV13OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV14OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV51IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV53IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV54IsAuthorized_Supplier_AgbNumber = StringUtil.StrToBool( GetPar( "IsAuthorized_Supplier_AgbNumber"));
         AV55IsAuthorized_Insert = StringUtil.StrToBool( GetPar( "IsAuthorized_Insert"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV56Pgmname, AV25TFSupplier_AgbId, AV26TFSupplier_AgbId_To, AV27TFSupplier_AgbNumber, AV28TFSupplier_AgbNumber_Sel, AV29TFSupplier_AgbName, AV30TFSupplier_AgbName_Sel, AV31TFSupplier_AgbKvkNumber, AV32TFSupplier_AgbKvkNumber_Sel, AV33TFSupplier_AgbVisitingAddress, AV34TFSupplier_AgbVisitingAddress_Sel, AV35TFSupplier_AgbPostalAddress, AV36TFSupplier_AgbPostalAddress_Sel, AV37TFSupplier_AgbEmail, AV38TFSupplier_AgbEmail_Sel, AV39TFSupplier_AgbPhone, AV40TFSupplier_AgbPhone_Sel, AV41TFSupplier_AgbContactName, AV42TFSupplier_AgbContactName_Sel, AV13OrderedBy, AV14OrderedDsc, AV51IsAuthorized_Update, AV53IsAuthorized_Delete, AV54IsAuthorized_Supplier_AgbNumber, AV55IsAuthorized_Insert) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
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
            return "supplier_agbww_Execute" ;
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
         PA1L2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1L2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("supplier_agbww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV56Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV56Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV51IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV51IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV53IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV53IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_SUPPLIER_AGBNUMBER", AV54IsAuthorized_Supplier_AgbNumber);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SUPPLIER_AGBNUMBER", GetSecureSignedToken( "", AV54IsAuthorized_Supplier_AgbNumber, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV55IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV55IsAuthorized_Insert, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV16FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_37", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_37), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV22ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV22ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV47GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV48GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV49GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV43DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV43DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV19ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV19ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV56Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV56Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIER_AGBID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25TFSupplier_AgbId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIER_AGBID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26TFSupplier_AgbId_To), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIER_AGBNUMBER", AV27TFSupplier_AgbNumber);
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIER_AGBNUMBER_SEL", AV28TFSupplier_AgbNumber_Sel);
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIER_AGBNAME", AV29TFSupplier_AgbName);
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIER_AGBNAME_SEL", AV30TFSupplier_AgbName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIER_AGBKVKNUMBER", AV31TFSupplier_AgbKvkNumber);
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIER_AGBKVKNUMBER_SEL", AV32TFSupplier_AgbKvkNumber_Sel);
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIER_AGBVISITINGADDRESS", AV33TFSupplier_AgbVisitingAddress);
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIER_AGBVISITINGADDRESS_SEL", AV34TFSupplier_AgbVisitingAddress_Sel);
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIER_AGBPOSTALADDRESS", AV35TFSupplier_AgbPostalAddress);
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIER_AGBPOSTALADDRESS_SEL", AV36TFSupplier_AgbPostalAddress_Sel);
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIER_AGBEMAIL", AV37TFSupplier_AgbEmail);
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIER_AGBEMAIL_SEL", AV38TFSupplier_AgbEmail_Sel);
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIER_AGBPHONE", StringUtil.RTrim( AV39TFSupplier_AgbPhone));
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIER_AGBPHONE_SEL", StringUtil.RTrim( AV40TFSupplier_AgbPhone_Sel));
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIER_AGBCONTACTNAME", AV41TFSupplier_AgbContactName);
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIER_AGBCONTACTNAME_SEL", AV42TFSupplier_AgbContactName_Sel);
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV51IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV51IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV53IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV53IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_SUPPLIER_AGBNUMBER", AV54IsAuthorized_Supplier_AgbNumber);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SUPPLIER_AGBNUMBER", GetSecureSignedToken( "", AV54IsAuthorized_Supplier_AgbNumber, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV55IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV55IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icontype", StringUtil.RTrim( Ddo_managefilters_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icon", StringUtil.RTrim( Ddo_managefilters_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Tooltip", StringUtil.RTrim( Ddo_managefilters_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Cls", StringUtil.RTrim( Ddo_managefilters_Cls));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Class", StringUtil.RTrim( Gridpaginationbar_Class));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridpaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridpaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridpaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridpaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridpaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridpaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridpaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridpaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridpaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Previous", StringUtil.RTrim( Gridpaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Next", StringUtil.RTrim( Gridpaginationbar_Next));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Caption", StringUtil.RTrim( Gridpaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridpaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridpaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_set", StringUtil.RTrim( Ddo_grid_Filteredtextto_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gamoauthtoken", StringUtil.RTrim( Ddo_grid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Fixable", StringUtil.RTrim( Ddo_grid_Fixable));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filterisrange", StringUtil.RTrim( Ddo_grid_Filterisrange));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icontype", StringUtil.RTrim( Ddo_gridcolumnsselector_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icon", StringUtil.RTrim( Ddo_gridcolumnsselector_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Caption", StringUtil.RTrim( Ddo_gridcolumnsselector_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Tooltip", StringUtil.RTrim( Ddo_gridcolumnsselector_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Cls", StringUtil.RTrim( Ddo_gridcolumnsselector_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype", StringUtil.RTrim( Ddo_gridcolumnsselector_Dropdownoptionstype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname", StringUtil.RTrim( Ddo_gridcolumnsselector_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_gridcolumnsselector_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hascolumnsselector", StringUtil.BoolToStr( Grid_empowerer_Hascolumnsselector));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
            WE1L2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1L2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("supplier_agbww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Supplier_AgbWW" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( " AGB Suppliers", "") ;
      }

      protected void WB1L0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingBottom", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheadercontent_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupGrouped", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", context.GetMessage( "GXM_insert", ""), bttBtninsert_Jsonclick, 5, context.GetMessage( "GXM_insert", ""), "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Supplier_AgbWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_Supplier_AgbWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablerightheader_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucDdo_managefilters.SetProperty("IconType", Ddo_managefilters_Icontype);
            ucDdo_managefilters.SetProperty("Icon", Ddo_managefilters_Icon);
            ucDdo_managefilters.SetProperty("Caption", Ddo_managefilters_Caption);
            ucDdo_managefilters.SetProperty("Tooltip", Ddo_managefilters_Tooltip);
            ucDdo_managefilters.SetProperty("Cls", Ddo_managefilters_Cls);
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV22ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, "DDO_MANAGEFILTERSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablefilters_Internalname, 1, 0, "px", 0, "px", "TableFilters", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilterfulltext_Internalname, context.GetMessage( "Filter Full Text", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'" + sGXsfl_37_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV16FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV16FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_Supplier_AgbWW.htm");
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
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl37( ) ;
         }
         if ( wbEnd == 37 )
         {
            wbEnd = 0;
            nRC_GXsfl_37 = (int)(nGXsfl_37_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGridpaginationbar.SetProperty("Class", Gridpaginationbar_Class);
            ucGridpaginationbar.SetProperty("ShowFirst", Gridpaginationbar_Showfirst);
            ucGridpaginationbar.SetProperty("ShowPrevious", Gridpaginationbar_Showprevious);
            ucGridpaginationbar.SetProperty("ShowNext", Gridpaginationbar_Shownext);
            ucGridpaginationbar.SetProperty("ShowLast", Gridpaginationbar_Showlast);
            ucGridpaginationbar.SetProperty("PagesToShow", Gridpaginationbar_Pagestoshow);
            ucGridpaginationbar.SetProperty("PagingButtonsPosition", Gridpaginationbar_Pagingbuttonsposition);
            ucGridpaginationbar.SetProperty("PagingCaptionPosition", Gridpaginationbar_Pagingcaptionposition);
            ucGridpaginationbar.SetProperty("EmptyGridClass", Gridpaginationbar_Emptygridclass);
            ucGridpaginationbar.SetProperty("RowsPerPageSelector", Gridpaginationbar_Rowsperpageselector);
            ucGridpaginationbar.SetProperty("RowsPerPageOptions", Gridpaginationbar_Rowsperpageoptions);
            ucGridpaginationbar.SetProperty("Previous", Gridpaginationbar_Previous);
            ucGridpaginationbar.SetProperty("Next", Gridpaginationbar_Next);
            ucGridpaginationbar.SetProperty("Caption", Gridpaginationbar_Caption);
            ucGridpaginationbar.SetProperty("EmptyGridCaption", Gridpaginationbar_Emptygridcaption);
            ucGridpaginationbar.SetProperty("RowsPerPageCaption", Gridpaginationbar_Rowsperpagecaption);
            ucGridpaginationbar.SetProperty("CurrentPage", AV47GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV48GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV49GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, "GRIDPAGINATIONBARContainer");
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
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("Fixable", Ddo_grid_Fixable);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("FilterIsRange", Ddo_grid_Filterisrange);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV43DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV43DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV19ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 37 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START1L2( )
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
         Form.Meta.addItem("description", context.GetMessage( " AGB Suppliers", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1L0( ) ;
      }

      protected void WS1L2( )
      {
         START1L2( ) ;
         EVT1L2( ) ;
      }

      protected void EVT1L2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "DDO_MANAGEFILTERS.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E111L2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E121L2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E131L2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E141L2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E151L2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E161L2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_37_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
                              SubsflControlProps_372( ) ;
                              A55Supplier_AgbId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSupplier_AgbId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A56Supplier_AgbNumber = cgiGet( edtSupplier_AgbNumber_Internalname);
                              A57Supplier_AgbName = cgiGet( edtSupplier_AgbName_Internalname);
                              A58Supplier_AgbKvkNumber = cgiGet( edtSupplier_AgbKvkNumber_Internalname);
                              A59Supplier_AgbVisitingAddress = cgiGet( edtSupplier_AgbVisitingAddress_Internalname);
                              n59Supplier_AgbVisitingAddress = false;
                              A60Supplier_AgbPostalAddress = cgiGet( edtSupplier_AgbPostalAddress_Internalname);
                              n60Supplier_AgbPostalAddress = false;
                              A61Supplier_AgbEmail = cgiGet( edtSupplier_AgbEmail_Internalname);
                              n61Supplier_AgbEmail = false;
                              A62Supplier_AgbPhone = cgiGet( edtSupplier_AgbPhone_Internalname);
                              n62Supplier_AgbPhone = false;
                              A63Supplier_AgbContactName = cgiGet( edtSupplier_AgbContactName_Internalname);
                              n63Supplier_AgbContactName = false;
                              AV50Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV50Update);
                              AV52Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri("", false, edtavDelete_Internalname, AV52Delete);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E171L2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E181L2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E191L2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV16FilterFullText) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
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

      protected void WE1L2( )
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

      protected void PA1L2( )
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
               GX_FocusControl = edtavFilterfulltext_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_372( ) ;
         while ( nGXsfl_37_idx <= nRC_GXsfl_37 )
         {
            sendrow_372( ) ;
            nGXsfl_37_idx = ((subGrid_Islastpage==1)&&(nGXsfl_37_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_37_idx+1);
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV16FilterFullText ,
                                       short AV24ManageFiltersExecutionStep ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV19ColumnsSelector ,
                                       string AV56Pgmname ,
                                       short AV25TFSupplier_AgbId ,
                                       short AV26TFSupplier_AgbId_To ,
                                       string AV27TFSupplier_AgbNumber ,
                                       string AV28TFSupplier_AgbNumber_Sel ,
                                       string AV29TFSupplier_AgbName ,
                                       string AV30TFSupplier_AgbName_Sel ,
                                       string AV31TFSupplier_AgbKvkNumber ,
                                       string AV32TFSupplier_AgbKvkNumber_Sel ,
                                       string AV33TFSupplier_AgbVisitingAddress ,
                                       string AV34TFSupplier_AgbVisitingAddress_Sel ,
                                       string AV35TFSupplier_AgbPostalAddress ,
                                       string AV36TFSupplier_AgbPostalAddress_Sel ,
                                       string AV37TFSupplier_AgbEmail ,
                                       string AV38TFSupplier_AgbEmail_Sel ,
                                       string AV39TFSupplier_AgbPhone ,
                                       string AV40TFSupplier_AgbPhone_Sel ,
                                       string AV41TFSupplier_AgbContactName ,
                                       string AV42TFSupplier_AgbContactName_Sel ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       bool AV51IsAuthorized_Update ,
                                       bool AV53IsAuthorized_Delete ,
                                       bool AV54IsAuthorized_Supplier_AgbNumber ,
                                       bool AV55IsAuthorized_Insert )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF1L2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_SUPPLIER_AGBID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A55Supplier_AgbId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "SUPPLIER_AGBID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A55Supplier_AgbId), 4, 0, ".", "")));
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF1L2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV56Pgmname = "Supplier_AgbWW";
         edtavUpdate_Enabled = 0;
         AssignProp("", false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         edtavDelete_Enabled = 0;
         AssignProp("", false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_37_Refreshing);
      }

      protected void RF1L2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 37;
         /* Execute user event: Refresh */
         E181L2 ();
         nGXsfl_37_idx = 1;
         sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
         SubsflControlProps_372( ) ;
         bGXsfl_37_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_372( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV57Supplier_agbwwds_1_filterfulltext ,
                                                 AV58Supplier_agbwwds_2_tfsupplier_agbid ,
                                                 AV59Supplier_agbwwds_3_tfsupplier_agbid_to ,
                                                 AV61Supplier_agbwwds_5_tfsupplier_agbnumber_sel ,
                                                 AV60Supplier_agbwwds_4_tfsupplier_agbnumber ,
                                                 AV63Supplier_agbwwds_7_tfsupplier_agbname_sel ,
                                                 AV62Supplier_agbwwds_6_tfsupplier_agbname ,
                                                 AV65Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel ,
                                                 AV64Supplier_agbwwds_8_tfsupplier_agbkvknumber ,
                                                 AV67Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel ,
                                                 AV66Supplier_agbwwds_10_tfsupplier_agbvisitingaddress ,
                                                 AV69Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel ,
                                                 AV68Supplier_agbwwds_12_tfsupplier_agbpostaladdress ,
                                                 AV71Supplier_agbwwds_15_tfsupplier_agbemail_sel ,
                                                 AV70Supplier_agbwwds_14_tfsupplier_agbemail ,
                                                 AV73Supplier_agbwwds_17_tfsupplier_agbphone_sel ,
                                                 AV72Supplier_agbwwds_16_tfsupplier_agbphone ,
                                                 AV75Supplier_agbwwds_19_tfsupplier_agbcontactname_sel ,
                                                 AV74Supplier_agbwwds_18_tfsupplier_agbcontactname ,
                                                 A55Supplier_AgbId ,
                                                 A56Supplier_AgbNumber ,
                                                 A57Supplier_AgbName ,
                                                 A58Supplier_AgbKvkNumber ,
                                                 A59Supplier_AgbVisitingAddress ,
                                                 A60Supplier_AgbPostalAddress ,
                                                 A61Supplier_AgbEmail ,
                                                 A62Supplier_AgbPhone ,
                                                 A63Supplier_AgbContactName ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV57Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Supplier_agbwwds_1_filterfulltext), "%", "");
            lV57Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Supplier_agbwwds_1_filterfulltext), "%", "");
            lV57Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Supplier_agbwwds_1_filterfulltext), "%", "");
            lV57Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Supplier_agbwwds_1_filterfulltext), "%", "");
            lV57Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Supplier_agbwwds_1_filterfulltext), "%", "");
            lV57Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Supplier_agbwwds_1_filterfulltext), "%", "");
            lV57Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Supplier_agbwwds_1_filterfulltext), "%", "");
            lV57Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Supplier_agbwwds_1_filterfulltext), "%", "");
            lV57Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Supplier_agbwwds_1_filterfulltext), "%", "");
            lV60Supplier_agbwwds_4_tfsupplier_agbnumber = StringUtil.Concat( StringUtil.RTrim( AV60Supplier_agbwwds_4_tfsupplier_agbnumber), "%", "");
            lV62Supplier_agbwwds_6_tfsupplier_agbname = StringUtil.Concat( StringUtil.RTrim( AV62Supplier_agbwwds_6_tfsupplier_agbname), "%", "");
            lV64Supplier_agbwwds_8_tfsupplier_agbkvknumber = StringUtil.Concat( StringUtil.RTrim( AV64Supplier_agbwwds_8_tfsupplier_agbkvknumber), "%", "");
            lV66Supplier_agbwwds_10_tfsupplier_agbvisitingaddress = StringUtil.Concat( StringUtil.RTrim( AV66Supplier_agbwwds_10_tfsupplier_agbvisitingaddress), "%", "");
            lV68Supplier_agbwwds_12_tfsupplier_agbpostaladdress = StringUtil.Concat( StringUtil.RTrim( AV68Supplier_agbwwds_12_tfsupplier_agbpostaladdress), "%", "");
            lV70Supplier_agbwwds_14_tfsupplier_agbemail = StringUtil.Concat( StringUtil.RTrim( AV70Supplier_agbwwds_14_tfsupplier_agbemail), "%", "");
            lV72Supplier_agbwwds_16_tfsupplier_agbphone = StringUtil.PadR( StringUtil.RTrim( AV72Supplier_agbwwds_16_tfsupplier_agbphone), 20, "%");
            lV74Supplier_agbwwds_18_tfsupplier_agbcontactname = StringUtil.Concat( StringUtil.RTrim( AV74Supplier_agbwwds_18_tfsupplier_agbcontactname), "%", "");
            /* Using cursor H001L2 */
            pr_default.execute(0, new Object[] {lV57Supplier_agbwwds_1_filterfulltext, lV57Supplier_agbwwds_1_filterfulltext, lV57Supplier_agbwwds_1_filterfulltext, lV57Supplier_agbwwds_1_filterfulltext, lV57Supplier_agbwwds_1_filterfulltext, lV57Supplier_agbwwds_1_filterfulltext, lV57Supplier_agbwwds_1_filterfulltext, lV57Supplier_agbwwds_1_filterfulltext, lV57Supplier_agbwwds_1_filterfulltext, AV58Supplier_agbwwds_2_tfsupplier_agbid, AV59Supplier_agbwwds_3_tfsupplier_agbid_to, lV60Supplier_agbwwds_4_tfsupplier_agbnumber, AV61Supplier_agbwwds_5_tfsupplier_agbnumber_sel, lV62Supplier_agbwwds_6_tfsupplier_agbname, AV63Supplier_agbwwds_7_tfsupplier_agbname_sel, lV64Supplier_agbwwds_8_tfsupplier_agbkvknumber, AV65Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel, lV66Supplier_agbwwds_10_tfsupplier_agbvisitingaddress, AV67Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, lV68Supplier_agbwwds_12_tfsupplier_agbpostaladdress, AV69Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel, lV70Supplier_agbwwds_14_tfsupplier_agbemail, AV71Supplier_agbwwds_15_tfsupplier_agbemail_sel, lV72Supplier_agbwwds_16_tfsupplier_agbphone, AV73Supplier_agbwwds_17_tfsupplier_agbphone_sel, lV74Supplier_agbwwds_18_tfsupplier_agbcontactname, AV75Supplier_agbwwds_19_tfsupplier_agbcontactname_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_37_idx = 1;
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A63Supplier_AgbContactName = H001L2_A63Supplier_AgbContactName[0];
               n63Supplier_AgbContactName = H001L2_n63Supplier_AgbContactName[0];
               A62Supplier_AgbPhone = H001L2_A62Supplier_AgbPhone[0];
               n62Supplier_AgbPhone = H001L2_n62Supplier_AgbPhone[0];
               A61Supplier_AgbEmail = H001L2_A61Supplier_AgbEmail[0];
               n61Supplier_AgbEmail = H001L2_n61Supplier_AgbEmail[0];
               A60Supplier_AgbPostalAddress = H001L2_A60Supplier_AgbPostalAddress[0];
               n60Supplier_AgbPostalAddress = H001L2_n60Supplier_AgbPostalAddress[0];
               A59Supplier_AgbVisitingAddress = H001L2_A59Supplier_AgbVisitingAddress[0];
               n59Supplier_AgbVisitingAddress = H001L2_n59Supplier_AgbVisitingAddress[0];
               A58Supplier_AgbKvkNumber = H001L2_A58Supplier_AgbKvkNumber[0];
               A57Supplier_AgbName = H001L2_A57Supplier_AgbName[0];
               A56Supplier_AgbNumber = H001L2_A56Supplier_AgbNumber[0];
               A55Supplier_AgbId = H001L2_A55Supplier_AgbId[0];
               E191L2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 37;
            WB1L0( ) ;
         }
         bGXsfl_37_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1L2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV56Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV56Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV51IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV51IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV53IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV53IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_SUPPLIER_AGBNUMBER", AV54IsAuthorized_Supplier_AgbNumber);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SUPPLIER_AGBNUMBER", GetSecureSignedToken( "", AV54IsAuthorized_Supplier_AgbNumber, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV55IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV55IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "gxhash_SUPPLIER_AGBID"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, context.localUtil.Format( (decimal)(A55Supplier_AgbId), "ZZZ9"), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         AV57Supplier_agbwwds_1_filterfulltext = AV16FilterFullText;
         AV58Supplier_agbwwds_2_tfsupplier_agbid = AV25TFSupplier_AgbId;
         AV59Supplier_agbwwds_3_tfsupplier_agbid_to = AV26TFSupplier_AgbId_To;
         AV60Supplier_agbwwds_4_tfsupplier_agbnumber = AV27TFSupplier_AgbNumber;
         AV61Supplier_agbwwds_5_tfsupplier_agbnumber_sel = AV28TFSupplier_AgbNumber_Sel;
         AV62Supplier_agbwwds_6_tfsupplier_agbname = AV29TFSupplier_AgbName;
         AV63Supplier_agbwwds_7_tfsupplier_agbname_sel = AV30TFSupplier_AgbName_Sel;
         AV64Supplier_agbwwds_8_tfsupplier_agbkvknumber = AV31TFSupplier_AgbKvkNumber;
         AV65Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel = AV32TFSupplier_AgbKvkNumber_Sel;
         AV66Supplier_agbwwds_10_tfsupplier_agbvisitingaddress = AV33TFSupplier_AgbVisitingAddress;
         AV67Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel = AV34TFSupplier_AgbVisitingAddress_Sel;
         AV68Supplier_agbwwds_12_tfsupplier_agbpostaladdress = AV35TFSupplier_AgbPostalAddress;
         AV69Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel = AV36TFSupplier_AgbPostalAddress_Sel;
         AV70Supplier_agbwwds_14_tfsupplier_agbemail = AV37TFSupplier_AgbEmail;
         AV71Supplier_agbwwds_15_tfsupplier_agbemail_sel = AV38TFSupplier_AgbEmail_Sel;
         AV72Supplier_agbwwds_16_tfsupplier_agbphone = AV39TFSupplier_AgbPhone;
         AV73Supplier_agbwwds_17_tfsupplier_agbphone_sel = AV40TFSupplier_AgbPhone_Sel;
         AV74Supplier_agbwwds_18_tfsupplier_agbcontactname = AV41TFSupplier_AgbContactName;
         AV75Supplier_agbwwds_19_tfsupplier_agbcontactname_sel = AV42TFSupplier_AgbContactName_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV57Supplier_agbwwds_1_filterfulltext ,
                                              AV58Supplier_agbwwds_2_tfsupplier_agbid ,
                                              AV59Supplier_agbwwds_3_tfsupplier_agbid_to ,
                                              AV61Supplier_agbwwds_5_tfsupplier_agbnumber_sel ,
                                              AV60Supplier_agbwwds_4_tfsupplier_agbnumber ,
                                              AV63Supplier_agbwwds_7_tfsupplier_agbname_sel ,
                                              AV62Supplier_agbwwds_6_tfsupplier_agbname ,
                                              AV65Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel ,
                                              AV64Supplier_agbwwds_8_tfsupplier_agbkvknumber ,
                                              AV67Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel ,
                                              AV66Supplier_agbwwds_10_tfsupplier_agbvisitingaddress ,
                                              AV69Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel ,
                                              AV68Supplier_agbwwds_12_tfsupplier_agbpostaladdress ,
                                              AV71Supplier_agbwwds_15_tfsupplier_agbemail_sel ,
                                              AV70Supplier_agbwwds_14_tfsupplier_agbemail ,
                                              AV73Supplier_agbwwds_17_tfsupplier_agbphone_sel ,
                                              AV72Supplier_agbwwds_16_tfsupplier_agbphone ,
                                              AV75Supplier_agbwwds_19_tfsupplier_agbcontactname_sel ,
                                              AV74Supplier_agbwwds_18_tfsupplier_agbcontactname ,
                                              A55Supplier_AgbId ,
                                              A56Supplier_AgbNumber ,
                                              A57Supplier_AgbName ,
                                              A58Supplier_AgbKvkNumber ,
                                              A59Supplier_AgbVisitingAddress ,
                                              A60Supplier_AgbPostalAddress ,
                                              A61Supplier_AgbEmail ,
                                              A62Supplier_AgbPhone ,
                                              A63Supplier_AgbContactName ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV57Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Supplier_agbwwds_1_filterfulltext), "%", "");
         lV57Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Supplier_agbwwds_1_filterfulltext), "%", "");
         lV57Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Supplier_agbwwds_1_filterfulltext), "%", "");
         lV57Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Supplier_agbwwds_1_filterfulltext), "%", "");
         lV57Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Supplier_agbwwds_1_filterfulltext), "%", "");
         lV57Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Supplier_agbwwds_1_filterfulltext), "%", "");
         lV57Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Supplier_agbwwds_1_filterfulltext), "%", "");
         lV57Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Supplier_agbwwds_1_filterfulltext), "%", "");
         lV57Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Supplier_agbwwds_1_filterfulltext), "%", "");
         lV60Supplier_agbwwds_4_tfsupplier_agbnumber = StringUtil.Concat( StringUtil.RTrim( AV60Supplier_agbwwds_4_tfsupplier_agbnumber), "%", "");
         lV62Supplier_agbwwds_6_tfsupplier_agbname = StringUtil.Concat( StringUtil.RTrim( AV62Supplier_agbwwds_6_tfsupplier_agbname), "%", "");
         lV64Supplier_agbwwds_8_tfsupplier_agbkvknumber = StringUtil.Concat( StringUtil.RTrim( AV64Supplier_agbwwds_8_tfsupplier_agbkvknumber), "%", "");
         lV66Supplier_agbwwds_10_tfsupplier_agbvisitingaddress = StringUtil.Concat( StringUtil.RTrim( AV66Supplier_agbwwds_10_tfsupplier_agbvisitingaddress), "%", "");
         lV68Supplier_agbwwds_12_tfsupplier_agbpostaladdress = StringUtil.Concat( StringUtil.RTrim( AV68Supplier_agbwwds_12_tfsupplier_agbpostaladdress), "%", "");
         lV70Supplier_agbwwds_14_tfsupplier_agbemail = StringUtil.Concat( StringUtil.RTrim( AV70Supplier_agbwwds_14_tfsupplier_agbemail), "%", "");
         lV72Supplier_agbwwds_16_tfsupplier_agbphone = StringUtil.PadR( StringUtil.RTrim( AV72Supplier_agbwwds_16_tfsupplier_agbphone), 20, "%");
         lV74Supplier_agbwwds_18_tfsupplier_agbcontactname = StringUtil.Concat( StringUtil.RTrim( AV74Supplier_agbwwds_18_tfsupplier_agbcontactname), "%", "");
         /* Using cursor H001L3 */
         pr_default.execute(1, new Object[] {lV57Supplier_agbwwds_1_filterfulltext, lV57Supplier_agbwwds_1_filterfulltext, lV57Supplier_agbwwds_1_filterfulltext, lV57Supplier_agbwwds_1_filterfulltext, lV57Supplier_agbwwds_1_filterfulltext, lV57Supplier_agbwwds_1_filterfulltext, lV57Supplier_agbwwds_1_filterfulltext, lV57Supplier_agbwwds_1_filterfulltext, lV57Supplier_agbwwds_1_filterfulltext, AV58Supplier_agbwwds_2_tfsupplier_agbid, AV59Supplier_agbwwds_3_tfsupplier_agbid_to, lV60Supplier_agbwwds_4_tfsupplier_agbnumber, AV61Supplier_agbwwds_5_tfsupplier_agbnumber_sel, lV62Supplier_agbwwds_6_tfsupplier_agbname, AV63Supplier_agbwwds_7_tfsupplier_agbname_sel, lV64Supplier_agbwwds_8_tfsupplier_agbkvknumber, AV65Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel, lV66Supplier_agbwwds_10_tfsupplier_agbvisitingaddress, AV67Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, lV68Supplier_agbwwds_12_tfsupplier_agbpostaladdress, AV69Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel, lV70Supplier_agbwwds_14_tfsupplier_agbemail, AV71Supplier_agbwwds_15_tfsupplier_agbemail_sel, lV72Supplier_agbwwds_16_tfsupplier_agbphone, AV73Supplier_agbwwds_17_tfsupplier_agbphone_sel, lV74Supplier_agbwwds_18_tfsupplier_agbcontactname, AV75Supplier_agbwwds_19_tfsupplier_agbcontactname_sel});
         GRID_nRecordCount = H001L3_AGRID_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID_nRecordCount) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         AV57Supplier_agbwwds_1_filterfulltext = AV16FilterFullText;
         AV58Supplier_agbwwds_2_tfsupplier_agbid = AV25TFSupplier_AgbId;
         AV59Supplier_agbwwds_3_tfsupplier_agbid_to = AV26TFSupplier_AgbId_To;
         AV60Supplier_agbwwds_4_tfsupplier_agbnumber = AV27TFSupplier_AgbNumber;
         AV61Supplier_agbwwds_5_tfsupplier_agbnumber_sel = AV28TFSupplier_AgbNumber_Sel;
         AV62Supplier_agbwwds_6_tfsupplier_agbname = AV29TFSupplier_AgbName;
         AV63Supplier_agbwwds_7_tfsupplier_agbname_sel = AV30TFSupplier_AgbName_Sel;
         AV64Supplier_agbwwds_8_tfsupplier_agbkvknumber = AV31TFSupplier_AgbKvkNumber;
         AV65Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel = AV32TFSupplier_AgbKvkNumber_Sel;
         AV66Supplier_agbwwds_10_tfsupplier_agbvisitingaddress = AV33TFSupplier_AgbVisitingAddress;
         AV67Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel = AV34TFSupplier_AgbVisitingAddress_Sel;
         AV68Supplier_agbwwds_12_tfsupplier_agbpostaladdress = AV35TFSupplier_AgbPostalAddress;
         AV69Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel = AV36TFSupplier_AgbPostalAddress_Sel;
         AV70Supplier_agbwwds_14_tfsupplier_agbemail = AV37TFSupplier_AgbEmail;
         AV71Supplier_agbwwds_15_tfsupplier_agbemail_sel = AV38TFSupplier_AgbEmail_Sel;
         AV72Supplier_agbwwds_16_tfsupplier_agbphone = AV39TFSupplier_AgbPhone;
         AV73Supplier_agbwwds_17_tfsupplier_agbphone_sel = AV40TFSupplier_AgbPhone_Sel;
         AV74Supplier_agbwwds_18_tfsupplier_agbcontactname = AV41TFSupplier_AgbContactName;
         AV75Supplier_agbwwds_19_tfsupplier_agbcontactname_sel = AV42TFSupplier_AgbContactName_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV56Pgmname, AV25TFSupplier_AgbId, AV26TFSupplier_AgbId_To, AV27TFSupplier_AgbNumber, AV28TFSupplier_AgbNumber_Sel, AV29TFSupplier_AgbName, AV30TFSupplier_AgbName_Sel, AV31TFSupplier_AgbKvkNumber, AV32TFSupplier_AgbKvkNumber_Sel, AV33TFSupplier_AgbVisitingAddress, AV34TFSupplier_AgbVisitingAddress_Sel, AV35TFSupplier_AgbPostalAddress, AV36TFSupplier_AgbPostalAddress_Sel, AV37TFSupplier_AgbEmail, AV38TFSupplier_AgbEmail_Sel, AV39TFSupplier_AgbPhone, AV40TFSupplier_AgbPhone_Sel, AV41TFSupplier_AgbContactName, AV42TFSupplier_AgbContactName_Sel, AV13OrderedBy, AV14OrderedDsc, AV51IsAuthorized_Update, AV53IsAuthorized_Delete, AV54IsAuthorized_Supplier_AgbNumber, AV55IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV57Supplier_agbwwds_1_filterfulltext = AV16FilterFullText;
         AV58Supplier_agbwwds_2_tfsupplier_agbid = AV25TFSupplier_AgbId;
         AV59Supplier_agbwwds_3_tfsupplier_agbid_to = AV26TFSupplier_AgbId_To;
         AV60Supplier_agbwwds_4_tfsupplier_agbnumber = AV27TFSupplier_AgbNumber;
         AV61Supplier_agbwwds_5_tfsupplier_agbnumber_sel = AV28TFSupplier_AgbNumber_Sel;
         AV62Supplier_agbwwds_6_tfsupplier_agbname = AV29TFSupplier_AgbName;
         AV63Supplier_agbwwds_7_tfsupplier_agbname_sel = AV30TFSupplier_AgbName_Sel;
         AV64Supplier_agbwwds_8_tfsupplier_agbkvknumber = AV31TFSupplier_AgbKvkNumber;
         AV65Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel = AV32TFSupplier_AgbKvkNumber_Sel;
         AV66Supplier_agbwwds_10_tfsupplier_agbvisitingaddress = AV33TFSupplier_AgbVisitingAddress;
         AV67Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel = AV34TFSupplier_AgbVisitingAddress_Sel;
         AV68Supplier_agbwwds_12_tfsupplier_agbpostaladdress = AV35TFSupplier_AgbPostalAddress;
         AV69Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel = AV36TFSupplier_AgbPostalAddress_Sel;
         AV70Supplier_agbwwds_14_tfsupplier_agbemail = AV37TFSupplier_AgbEmail;
         AV71Supplier_agbwwds_15_tfsupplier_agbemail_sel = AV38TFSupplier_AgbEmail_Sel;
         AV72Supplier_agbwwds_16_tfsupplier_agbphone = AV39TFSupplier_AgbPhone;
         AV73Supplier_agbwwds_17_tfsupplier_agbphone_sel = AV40TFSupplier_AgbPhone_Sel;
         AV74Supplier_agbwwds_18_tfsupplier_agbcontactname = AV41TFSupplier_AgbContactName;
         AV75Supplier_agbwwds_19_tfsupplier_agbcontactname_sel = AV42TFSupplier_AgbContactName_Sel;
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV56Pgmname, AV25TFSupplier_AgbId, AV26TFSupplier_AgbId_To, AV27TFSupplier_AgbNumber, AV28TFSupplier_AgbNumber_Sel, AV29TFSupplier_AgbName, AV30TFSupplier_AgbName_Sel, AV31TFSupplier_AgbKvkNumber, AV32TFSupplier_AgbKvkNumber_Sel, AV33TFSupplier_AgbVisitingAddress, AV34TFSupplier_AgbVisitingAddress_Sel, AV35TFSupplier_AgbPostalAddress, AV36TFSupplier_AgbPostalAddress_Sel, AV37TFSupplier_AgbEmail, AV38TFSupplier_AgbEmail_Sel, AV39TFSupplier_AgbPhone, AV40TFSupplier_AgbPhone_Sel, AV41TFSupplier_AgbContactName, AV42TFSupplier_AgbContactName_Sel, AV13OrderedBy, AV14OrderedDsc, AV51IsAuthorized_Update, AV53IsAuthorized_Delete, AV54IsAuthorized_Supplier_AgbNumber, AV55IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV57Supplier_agbwwds_1_filterfulltext = AV16FilterFullText;
         AV58Supplier_agbwwds_2_tfsupplier_agbid = AV25TFSupplier_AgbId;
         AV59Supplier_agbwwds_3_tfsupplier_agbid_to = AV26TFSupplier_AgbId_To;
         AV60Supplier_agbwwds_4_tfsupplier_agbnumber = AV27TFSupplier_AgbNumber;
         AV61Supplier_agbwwds_5_tfsupplier_agbnumber_sel = AV28TFSupplier_AgbNumber_Sel;
         AV62Supplier_agbwwds_6_tfsupplier_agbname = AV29TFSupplier_AgbName;
         AV63Supplier_agbwwds_7_tfsupplier_agbname_sel = AV30TFSupplier_AgbName_Sel;
         AV64Supplier_agbwwds_8_tfsupplier_agbkvknumber = AV31TFSupplier_AgbKvkNumber;
         AV65Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel = AV32TFSupplier_AgbKvkNumber_Sel;
         AV66Supplier_agbwwds_10_tfsupplier_agbvisitingaddress = AV33TFSupplier_AgbVisitingAddress;
         AV67Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel = AV34TFSupplier_AgbVisitingAddress_Sel;
         AV68Supplier_agbwwds_12_tfsupplier_agbpostaladdress = AV35TFSupplier_AgbPostalAddress;
         AV69Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel = AV36TFSupplier_AgbPostalAddress_Sel;
         AV70Supplier_agbwwds_14_tfsupplier_agbemail = AV37TFSupplier_AgbEmail;
         AV71Supplier_agbwwds_15_tfsupplier_agbemail_sel = AV38TFSupplier_AgbEmail_Sel;
         AV72Supplier_agbwwds_16_tfsupplier_agbphone = AV39TFSupplier_AgbPhone;
         AV73Supplier_agbwwds_17_tfsupplier_agbphone_sel = AV40TFSupplier_AgbPhone_Sel;
         AV74Supplier_agbwwds_18_tfsupplier_agbcontactname = AV41TFSupplier_AgbContactName;
         AV75Supplier_agbwwds_19_tfsupplier_agbcontactname_sel = AV42TFSupplier_AgbContactName_Sel;
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV56Pgmname, AV25TFSupplier_AgbId, AV26TFSupplier_AgbId_To, AV27TFSupplier_AgbNumber, AV28TFSupplier_AgbNumber_Sel, AV29TFSupplier_AgbName, AV30TFSupplier_AgbName_Sel, AV31TFSupplier_AgbKvkNumber, AV32TFSupplier_AgbKvkNumber_Sel, AV33TFSupplier_AgbVisitingAddress, AV34TFSupplier_AgbVisitingAddress_Sel, AV35TFSupplier_AgbPostalAddress, AV36TFSupplier_AgbPostalAddress_Sel, AV37TFSupplier_AgbEmail, AV38TFSupplier_AgbEmail_Sel, AV39TFSupplier_AgbPhone, AV40TFSupplier_AgbPhone_Sel, AV41TFSupplier_AgbContactName, AV42TFSupplier_AgbContactName_Sel, AV13OrderedBy, AV14OrderedDsc, AV51IsAuthorized_Update, AV53IsAuthorized_Delete, AV54IsAuthorized_Supplier_AgbNumber, AV55IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV57Supplier_agbwwds_1_filterfulltext = AV16FilterFullText;
         AV58Supplier_agbwwds_2_tfsupplier_agbid = AV25TFSupplier_AgbId;
         AV59Supplier_agbwwds_3_tfsupplier_agbid_to = AV26TFSupplier_AgbId_To;
         AV60Supplier_agbwwds_4_tfsupplier_agbnumber = AV27TFSupplier_AgbNumber;
         AV61Supplier_agbwwds_5_tfsupplier_agbnumber_sel = AV28TFSupplier_AgbNumber_Sel;
         AV62Supplier_agbwwds_6_tfsupplier_agbname = AV29TFSupplier_AgbName;
         AV63Supplier_agbwwds_7_tfsupplier_agbname_sel = AV30TFSupplier_AgbName_Sel;
         AV64Supplier_agbwwds_8_tfsupplier_agbkvknumber = AV31TFSupplier_AgbKvkNumber;
         AV65Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel = AV32TFSupplier_AgbKvkNumber_Sel;
         AV66Supplier_agbwwds_10_tfsupplier_agbvisitingaddress = AV33TFSupplier_AgbVisitingAddress;
         AV67Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel = AV34TFSupplier_AgbVisitingAddress_Sel;
         AV68Supplier_agbwwds_12_tfsupplier_agbpostaladdress = AV35TFSupplier_AgbPostalAddress;
         AV69Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel = AV36TFSupplier_AgbPostalAddress_Sel;
         AV70Supplier_agbwwds_14_tfsupplier_agbemail = AV37TFSupplier_AgbEmail;
         AV71Supplier_agbwwds_15_tfsupplier_agbemail_sel = AV38TFSupplier_AgbEmail_Sel;
         AV72Supplier_agbwwds_16_tfsupplier_agbphone = AV39TFSupplier_AgbPhone;
         AV73Supplier_agbwwds_17_tfsupplier_agbphone_sel = AV40TFSupplier_AgbPhone_Sel;
         AV74Supplier_agbwwds_18_tfsupplier_agbcontactname = AV41TFSupplier_AgbContactName;
         AV75Supplier_agbwwds_19_tfsupplier_agbcontactname_sel = AV42TFSupplier_AgbContactName_Sel;
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV56Pgmname, AV25TFSupplier_AgbId, AV26TFSupplier_AgbId_To, AV27TFSupplier_AgbNumber, AV28TFSupplier_AgbNumber_Sel, AV29TFSupplier_AgbName, AV30TFSupplier_AgbName_Sel, AV31TFSupplier_AgbKvkNumber, AV32TFSupplier_AgbKvkNumber_Sel, AV33TFSupplier_AgbVisitingAddress, AV34TFSupplier_AgbVisitingAddress_Sel, AV35TFSupplier_AgbPostalAddress, AV36TFSupplier_AgbPostalAddress_Sel, AV37TFSupplier_AgbEmail, AV38TFSupplier_AgbEmail_Sel, AV39TFSupplier_AgbPhone, AV40TFSupplier_AgbPhone_Sel, AV41TFSupplier_AgbContactName, AV42TFSupplier_AgbContactName_Sel, AV13OrderedBy, AV14OrderedDsc, AV51IsAuthorized_Update, AV53IsAuthorized_Delete, AV54IsAuthorized_Supplier_AgbNumber, AV55IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV57Supplier_agbwwds_1_filterfulltext = AV16FilterFullText;
         AV58Supplier_agbwwds_2_tfsupplier_agbid = AV25TFSupplier_AgbId;
         AV59Supplier_agbwwds_3_tfsupplier_agbid_to = AV26TFSupplier_AgbId_To;
         AV60Supplier_agbwwds_4_tfsupplier_agbnumber = AV27TFSupplier_AgbNumber;
         AV61Supplier_agbwwds_5_tfsupplier_agbnumber_sel = AV28TFSupplier_AgbNumber_Sel;
         AV62Supplier_agbwwds_6_tfsupplier_agbname = AV29TFSupplier_AgbName;
         AV63Supplier_agbwwds_7_tfsupplier_agbname_sel = AV30TFSupplier_AgbName_Sel;
         AV64Supplier_agbwwds_8_tfsupplier_agbkvknumber = AV31TFSupplier_AgbKvkNumber;
         AV65Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel = AV32TFSupplier_AgbKvkNumber_Sel;
         AV66Supplier_agbwwds_10_tfsupplier_agbvisitingaddress = AV33TFSupplier_AgbVisitingAddress;
         AV67Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel = AV34TFSupplier_AgbVisitingAddress_Sel;
         AV68Supplier_agbwwds_12_tfsupplier_agbpostaladdress = AV35TFSupplier_AgbPostalAddress;
         AV69Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel = AV36TFSupplier_AgbPostalAddress_Sel;
         AV70Supplier_agbwwds_14_tfsupplier_agbemail = AV37TFSupplier_AgbEmail;
         AV71Supplier_agbwwds_15_tfsupplier_agbemail_sel = AV38TFSupplier_AgbEmail_Sel;
         AV72Supplier_agbwwds_16_tfsupplier_agbphone = AV39TFSupplier_AgbPhone;
         AV73Supplier_agbwwds_17_tfsupplier_agbphone_sel = AV40TFSupplier_AgbPhone_Sel;
         AV74Supplier_agbwwds_18_tfsupplier_agbcontactname = AV41TFSupplier_AgbContactName;
         AV75Supplier_agbwwds_19_tfsupplier_agbcontactname_sel = AV42TFSupplier_AgbContactName_Sel;
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV56Pgmname, AV25TFSupplier_AgbId, AV26TFSupplier_AgbId_To, AV27TFSupplier_AgbNumber, AV28TFSupplier_AgbNumber_Sel, AV29TFSupplier_AgbName, AV30TFSupplier_AgbName_Sel, AV31TFSupplier_AgbKvkNumber, AV32TFSupplier_AgbKvkNumber_Sel, AV33TFSupplier_AgbVisitingAddress, AV34TFSupplier_AgbVisitingAddress_Sel, AV35TFSupplier_AgbPostalAddress, AV36TFSupplier_AgbPostalAddress_Sel, AV37TFSupplier_AgbEmail, AV38TFSupplier_AgbEmail_Sel, AV39TFSupplier_AgbPhone, AV40TFSupplier_AgbPhone_Sel, AV41TFSupplier_AgbContactName, AV42TFSupplier_AgbContactName_Sel, AV13OrderedBy, AV14OrderedDsc, AV51IsAuthorized_Update, AV53IsAuthorized_Delete, AV54IsAuthorized_Supplier_AgbNumber, AV55IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV56Pgmname = "Supplier_AgbWW";
         edtavUpdate_Enabled = 0;
         AssignProp("", false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         edtavDelete_Enabled = 0;
         AssignProp("", false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         edtSupplier_AgbId_Enabled = 0;
         AssignProp("", false, edtSupplier_AgbId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbId_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         edtSupplier_AgbNumber_Enabled = 0;
         AssignProp("", false, edtSupplier_AgbNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbNumber_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         edtSupplier_AgbName_Enabled = 0;
         AssignProp("", false, edtSupplier_AgbName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbName_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         edtSupplier_AgbKvkNumber_Enabled = 0;
         AssignProp("", false, edtSupplier_AgbKvkNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbKvkNumber_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         edtSupplier_AgbVisitingAddress_Enabled = 0;
         AssignProp("", false, edtSupplier_AgbVisitingAddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbVisitingAddress_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         edtSupplier_AgbPostalAddress_Enabled = 0;
         AssignProp("", false, edtSupplier_AgbPostalAddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbPostalAddress_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         edtSupplier_AgbEmail_Enabled = 0;
         AssignProp("", false, edtSupplier_AgbEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbEmail_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         edtSupplier_AgbPhone_Enabled = 0;
         AssignProp("", false, edtSupplier_AgbPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbPhone_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         edtSupplier_AgbContactName_Enabled = 0;
         AssignProp("", false, edtSupplier_AgbContactName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbContactName_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1L0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E171L2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV22ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV43DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV19ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_37 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_37"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV47GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV48GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV49GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_managefilters_Icontype = cgiGet( "DDO_MANAGEFILTERS_Icontype");
            Ddo_managefilters_Icon = cgiGet( "DDO_MANAGEFILTERS_Icon");
            Ddo_managefilters_Tooltip = cgiGet( "DDO_MANAGEFILTERS_Tooltip");
            Ddo_managefilters_Cls = cgiGet( "DDO_MANAGEFILTERS_Cls");
            Gridpaginationbar_Class = cgiGet( "GRIDPAGINATIONBAR_Class");
            Gridpaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showfirst"));
            Gridpaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showprevious"));
            Gridpaginationbar_Shownext = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Shownext"));
            Gridpaginationbar_Showlast = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showlast"));
            Gridpaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Pagestoshow"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Pagingbuttonsposition = cgiGet( "GRIDPAGINATIONBAR_Pagingbuttonsposition");
            Gridpaginationbar_Pagingcaptionposition = cgiGet( "GRIDPAGINATIONBAR_Pagingcaptionposition");
            Gridpaginationbar_Emptygridclass = cgiGet( "GRIDPAGINATIONBAR_Emptygridclass");
            Gridpaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselector"));
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Rowsperpageoptions = cgiGet( "GRIDPAGINATIONBAR_Rowsperpageoptions");
            Gridpaginationbar_Previous = cgiGet( "GRIDPAGINATIONBAR_Previous");
            Gridpaginationbar_Next = cgiGet( "GRIDPAGINATIONBAR_Next");
            Gridpaginationbar_Caption = cgiGet( "GRIDPAGINATIONBAR_Caption");
            Gridpaginationbar_Emptygridcaption = cgiGet( "GRIDPAGINATIONBAR_Emptygridcaption");
            Gridpaginationbar_Rowsperpagecaption = cgiGet( "GRIDPAGINATIONBAR_Rowsperpagecaption");
            Ddo_grid_Caption = cgiGet( "DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( "DDO_GRID_Filteredtext_set");
            Ddo_grid_Filteredtextto_set = cgiGet( "DDO_GRID_Filteredtextto_set");
            Ddo_grid_Selectedvalue_set = cgiGet( "DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gamoauthtoken = cgiGet( "DDO_GRID_Gamoauthtoken");
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( "DDO_GRID_Includesortasc");
            Ddo_grid_Fixable = cgiGet( "DDO_GRID_Fixable");
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( "DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( "DDO_GRID_Filtertype");
            Ddo_grid_Filterisrange = cgiGet( "DDO_GRID_Filterisrange");
            Ddo_grid_Includedatalist = cgiGet( "DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( "DDO_GRID_Datalisttype");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Ddo_grid_Format = cgiGet( "DDO_GRID_Format");
            Ddo_gridcolumnsselector_Icontype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icontype");
            Ddo_gridcolumnsselector_Icon = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icon");
            Ddo_gridcolumnsselector_Caption = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Caption");
            Ddo_gridcolumnsselector_Tooltip = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Tooltip");
            Ddo_gridcolumnsselector_Cls = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Cls");
            Ddo_gridcolumnsselector_Dropdownoptionstype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype");
            Ddo_gridcolumnsselector_Gridinternalname = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname");
            Ddo_gridcolumnsselector_Titlecontrolidtoreplace = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Hascolumnsselector = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hascolumnsselector"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV16FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV16FilterFullText) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E171L2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E171L2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
         if ( StringUtil.StrCmp(AV8HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_boolean1 = AV54IsAuthorized_Supplier_AgbNumber;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "supplier_agbview_Execute", out  GXt_boolean1) ;
         AV54IsAuthorized_Supplier_AgbNumber = GXt_boolean1;
         AssignAttri("", false, "AV54IsAuthorized_Supplier_AgbNumber", AV54IsAuthorized_Supplier_AgbNumber);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SUPPLIER_AGBNUMBER", GetSecureSignedToken( "", AV54IsAuthorized_Supplier_AgbNumber, context));
         AV44GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV45GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV44GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = context.GetMessage( " AGB Suppliers", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV13OrderedBy < 1 )
         {
            AV13OrderedBy = 1;
            AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV43DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV43DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E181L2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV24ManageFiltersExecutionStep == 1 )
         {
            AV24ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV24ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV24ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV24ManageFiltersExecutionStep == 2 )
         {
            AV24ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV24ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV24ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( StringUtil.StrCmp(AV21Session.Get("Supplier_AgbWWColumnsSelector"), "") != 0 )
         {
            AV17ColumnsSelectorXML = AV21Session.Get("Supplier_AgbWWColumnsSelector");
            AV19ColumnsSelector.FromXml(AV17ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         edtSupplier_AgbId_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSupplier_AgbId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbId_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtSupplier_AgbNumber_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSupplier_AgbNumber_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbNumber_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtSupplier_AgbName_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSupplier_AgbName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbName_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtSupplier_AgbKvkNumber_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSupplier_AgbKvkNumber_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbKvkNumber_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtSupplier_AgbVisitingAddress_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSupplier_AgbVisitingAddress_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbVisitingAddress_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtSupplier_AgbPostalAddress_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSupplier_AgbPostalAddress_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbPostalAddress_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtSupplier_AgbEmail_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(7)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSupplier_AgbEmail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbEmail_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtSupplier_AgbPhone_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(8)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSupplier_AgbPhone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbPhone_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtSupplier_AgbContactName_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(9)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSupplier_AgbContactName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbContactName_Visible), 5, 0), !bGXsfl_37_Refreshing);
         AV47GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV47GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV47GridCurrentPage), 10, 0));
         AV48GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV48GridPageCount", StringUtil.LTrimStr( (decimal)(AV48GridPageCount), 10, 0));
         GXt_char3 = AV49GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV56Pgmname, out  GXt_char3) ;
         AV49GridAppliedFilters = GXt_char3;
         AssignAttri("", false, "AV49GridAppliedFilters", AV49GridAppliedFilters);
         AV57Supplier_agbwwds_1_filterfulltext = AV16FilterFullText;
         AV58Supplier_agbwwds_2_tfsupplier_agbid = AV25TFSupplier_AgbId;
         AV59Supplier_agbwwds_3_tfsupplier_agbid_to = AV26TFSupplier_AgbId_To;
         AV60Supplier_agbwwds_4_tfsupplier_agbnumber = AV27TFSupplier_AgbNumber;
         AV61Supplier_agbwwds_5_tfsupplier_agbnumber_sel = AV28TFSupplier_AgbNumber_Sel;
         AV62Supplier_agbwwds_6_tfsupplier_agbname = AV29TFSupplier_AgbName;
         AV63Supplier_agbwwds_7_tfsupplier_agbname_sel = AV30TFSupplier_AgbName_Sel;
         AV64Supplier_agbwwds_8_tfsupplier_agbkvknumber = AV31TFSupplier_AgbKvkNumber;
         AV65Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel = AV32TFSupplier_AgbKvkNumber_Sel;
         AV66Supplier_agbwwds_10_tfsupplier_agbvisitingaddress = AV33TFSupplier_AgbVisitingAddress;
         AV67Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel = AV34TFSupplier_AgbVisitingAddress_Sel;
         AV68Supplier_agbwwds_12_tfsupplier_agbpostaladdress = AV35TFSupplier_AgbPostalAddress;
         AV69Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel = AV36TFSupplier_AgbPostalAddress_Sel;
         AV70Supplier_agbwwds_14_tfsupplier_agbemail = AV37TFSupplier_AgbEmail;
         AV71Supplier_agbwwds_15_tfsupplier_agbemail_sel = AV38TFSupplier_AgbEmail_Sel;
         AV72Supplier_agbwwds_16_tfsupplier_agbphone = AV39TFSupplier_AgbPhone;
         AV73Supplier_agbwwds_17_tfsupplier_agbphone_sel = AV40TFSupplier_AgbPhone_Sel;
         AV74Supplier_agbwwds_18_tfsupplier_agbcontactname = AV41TFSupplier_AgbContactName;
         AV75Supplier_agbwwds_19_tfsupplier_agbcontactname_sel = AV42TFSupplier_AgbContactName_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ColumnsSelector", AV19ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ManageFiltersData", AV22ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E121L2( )
      {
         /* Gridpaginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Previous") == 0 )
         {
            subgrid_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Next") == 0 )
         {
            subgrid_nextpage( ) ;
         }
         else
         {
            AV46PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV46PageToGo) ;
         }
      }

      protected void E131L2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E141L2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV13OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            AV14OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "Supplier_AgbId") == 0 )
            {
               AV25TFSupplier_AgbId = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV25TFSupplier_AgbId", StringUtil.LTrimStr( (decimal)(AV25TFSupplier_AgbId), 4, 0));
               AV26TFSupplier_AgbId_To = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV26TFSupplier_AgbId_To", StringUtil.LTrimStr( (decimal)(AV26TFSupplier_AgbId_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "Supplier_AgbNumber") == 0 )
            {
               AV27TFSupplier_AgbNumber = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV27TFSupplier_AgbNumber", AV27TFSupplier_AgbNumber);
               AV28TFSupplier_AgbNumber_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV28TFSupplier_AgbNumber_Sel", AV28TFSupplier_AgbNumber_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "Supplier_AgbName") == 0 )
            {
               AV29TFSupplier_AgbName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV29TFSupplier_AgbName", AV29TFSupplier_AgbName);
               AV30TFSupplier_AgbName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV30TFSupplier_AgbName_Sel", AV30TFSupplier_AgbName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "Supplier_AgbKvkNumber") == 0 )
            {
               AV31TFSupplier_AgbKvkNumber = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV31TFSupplier_AgbKvkNumber", AV31TFSupplier_AgbKvkNumber);
               AV32TFSupplier_AgbKvkNumber_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV32TFSupplier_AgbKvkNumber_Sel", AV32TFSupplier_AgbKvkNumber_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "Supplier_AgbVisitingAddress") == 0 )
            {
               AV33TFSupplier_AgbVisitingAddress = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV33TFSupplier_AgbVisitingAddress", AV33TFSupplier_AgbVisitingAddress);
               AV34TFSupplier_AgbVisitingAddress_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV34TFSupplier_AgbVisitingAddress_Sel", AV34TFSupplier_AgbVisitingAddress_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "Supplier_AgbPostalAddress") == 0 )
            {
               AV35TFSupplier_AgbPostalAddress = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV35TFSupplier_AgbPostalAddress", AV35TFSupplier_AgbPostalAddress);
               AV36TFSupplier_AgbPostalAddress_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV36TFSupplier_AgbPostalAddress_Sel", AV36TFSupplier_AgbPostalAddress_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "Supplier_AgbEmail") == 0 )
            {
               AV37TFSupplier_AgbEmail = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV37TFSupplier_AgbEmail", AV37TFSupplier_AgbEmail);
               AV38TFSupplier_AgbEmail_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV38TFSupplier_AgbEmail_Sel", AV38TFSupplier_AgbEmail_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "Supplier_AgbPhone") == 0 )
            {
               AV39TFSupplier_AgbPhone = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV39TFSupplier_AgbPhone", AV39TFSupplier_AgbPhone);
               AV40TFSupplier_AgbPhone_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV40TFSupplier_AgbPhone_Sel", AV40TFSupplier_AgbPhone_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "Supplier_AgbContactName") == 0 )
            {
               AV41TFSupplier_AgbContactName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV41TFSupplier_AgbContactName", AV41TFSupplier_AgbContactName);
               AV42TFSupplier_AgbContactName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV42TFSupplier_AgbContactName_Sel", AV42TFSupplier_AgbContactName_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E191L2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV50Update = "<i class=\"fa fa-pen\"></i>";
         AssignAttri("", false, edtavUpdate_Internalname, AV50Update);
         if ( AV51IsAuthorized_Update )
         {
            edtavUpdate_Link = formatLink("supplier_agb.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.LTrimStr(A55Supplier_AgbId,4,0))}, new string[] {"Mode","Supplier_AgbId"}) ;
         }
         AV52Delete = "<i class=\"fa fa-times\"></i>";
         AssignAttri("", false, edtavDelete_Internalname, AV52Delete);
         if ( AV53IsAuthorized_Delete )
         {
            edtavDelete_Link = formatLink("supplier_agb.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.LTrimStr(A55Supplier_AgbId,4,0))}, new string[] {"Mode","Supplier_AgbId"}) ;
         }
         if ( AV54IsAuthorized_Supplier_AgbNumber )
         {
            edtSupplier_AgbNumber_Link = formatLink("supplier_agbview.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A55Supplier_AgbId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Supplier_AgbId","TabCode"}) ;
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 37;
         }
         sendrow_372( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_37_Refreshing )
         {
            DoAjaxLoad(37, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E151L2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV17ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV19ColumnsSelector.FromJSonString(AV17ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "Supplier_AgbWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV17ColumnsSelectorXML)) ? "" : AV19ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ColumnsSelector", AV19ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ManageFiltersData", AV22ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E111L2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S182 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Save#>") == 0 )
         {
            /* Execute user subroutine: 'SAVEGRIDSTATE' */
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx", new object[] {UrlEncode(StringUtil.RTrim("Supplier_AgbWWFilters")),UrlEncode(StringUtil.RTrim(AV56Pgmname+"GridState"))}, new string[] {"UserKey","GridStateKey"}) , new Object[] {});
            AV24ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV24ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV24ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx", new object[] {UrlEncode(StringUtil.RTrim("Supplier_AgbWWFilters"))}, new string[] {"UserKey"}) , new Object[] {});
            AV24ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV24ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV24ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char3 = AV23ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "Supplier_AgbWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
            AV23ManageFiltersXml = GXt_char3;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV23ManageFiltersXml)) )
            {
               GX_msglist.addItem(context.GetMessage( "WWP_FilterNotExist", ""));
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S182 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV56Pgmname+"GridState",  AV23ManageFiltersXml) ;
               AV11GridState.FromXml(AV23ManageFiltersXml, null, "", "");
               AV13OrderedBy = AV11GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
               AV14OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S142 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S192 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ColumnsSelector", AV19ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ManageFiltersData", AV22ManageFiltersData);
      }

      protected void E161L2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( AV55IsAuthorized_Insert )
         {
            CallWebObject(formatLink("supplier_agb.aspx", new object[] {UrlEncode(StringUtil.RTrim("INS")),UrlEncode(StringUtil.LTrimStr(0,1,0))}, new string[] {"Mode","Supplier_AgbId"}) );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ColumnsSelector", AV19ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ManageFiltersData", AV22ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV13OrderedBy), 4, 0))+":"+(AV14OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S172( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV19ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "Supplier_AgbId",  "",  "Id",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "Supplier_AgbNumber",  "",  "Number",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "Supplier_AgbName",  "",  "Name",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "Supplier_AgbKvkNumber",  "",  "Kvk Number",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "Supplier_AgbVisitingAddress",  "",  "Visiting Address",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "Supplier_AgbPostalAddress",  "",  "Postal Address",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "Supplier_AgbEmail",  "",  "Email",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "Supplier_AgbPhone",  "",  "Phone",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "Supplier_AgbContactName",  "",  "Contact Name",  true,  "") ;
         GXt_char3 = AV18UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "Supplier_AgbWWColumnsSelector", out  GXt_char3) ;
         AV18UserCustomValue = GXt_char3;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV18UserCustomValue)) ) )
         {
            AV20ColumnsSelectorAux.FromXml(AV18UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV20ColumnsSelectorAux, ref  AV19ColumnsSelector) ;
         }
      }

      protected void S152( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean1 = AV51IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "supplier_agb_Update", out  GXt_boolean1) ;
         AV51IsAuthorized_Update = GXt_boolean1;
         AssignAttri("", false, "AV51IsAuthorized_Update", AV51IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV51IsAuthorized_Update, context));
         if ( ! ( AV51IsAuthorized_Update ) )
         {
            edtavUpdate_Visible = 0;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_37_Refreshing);
         }
         GXt_boolean1 = AV53IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "supplier_agb_Delete", out  GXt_boolean1) ;
         AV53IsAuthorized_Delete = GXt_boolean1;
         AssignAttri("", false, "AV53IsAuthorized_Delete", AV53IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV53IsAuthorized_Delete, context));
         if ( ! ( AV53IsAuthorized_Delete ) )
         {
            edtavDelete_Visible = 0;
            AssignProp("", false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_37_Refreshing);
         }
         GXt_boolean1 = AV55IsAuthorized_Insert;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "supplier_agb_Insert", out  GXt_boolean1) ;
         AV55IsAuthorized_Insert = GXt_boolean1;
         AssignAttri("", false, "AV55IsAuthorized_Insert", AV55IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV55IsAuthorized_Insert, context));
         if ( ! ( AV55IsAuthorized_Insert ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV22ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "Supplier_AgbWWFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV22ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S182( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV16FilterFullText = "";
         AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
         AV25TFSupplier_AgbId = 0;
         AssignAttri("", false, "AV25TFSupplier_AgbId", StringUtil.LTrimStr( (decimal)(AV25TFSupplier_AgbId), 4, 0));
         AV26TFSupplier_AgbId_To = 0;
         AssignAttri("", false, "AV26TFSupplier_AgbId_To", StringUtil.LTrimStr( (decimal)(AV26TFSupplier_AgbId_To), 4, 0));
         AV27TFSupplier_AgbNumber = "";
         AssignAttri("", false, "AV27TFSupplier_AgbNumber", AV27TFSupplier_AgbNumber);
         AV28TFSupplier_AgbNumber_Sel = "";
         AssignAttri("", false, "AV28TFSupplier_AgbNumber_Sel", AV28TFSupplier_AgbNumber_Sel);
         AV29TFSupplier_AgbName = "";
         AssignAttri("", false, "AV29TFSupplier_AgbName", AV29TFSupplier_AgbName);
         AV30TFSupplier_AgbName_Sel = "";
         AssignAttri("", false, "AV30TFSupplier_AgbName_Sel", AV30TFSupplier_AgbName_Sel);
         AV31TFSupplier_AgbKvkNumber = "";
         AssignAttri("", false, "AV31TFSupplier_AgbKvkNumber", AV31TFSupplier_AgbKvkNumber);
         AV32TFSupplier_AgbKvkNumber_Sel = "";
         AssignAttri("", false, "AV32TFSupplier_AgbKvkNumber_Sel", AV32TFSupplier_AgbKvkNumber_Sel);
         AV33TFSupplier_AgbVisitingAddress = "";
         AssignAttri("", false, "AV33TFSupplier_AgbVisitingAddress", AV33TFSupplier_AgbVisitingAddress);
         AV34TFSupplier_AgbVisitingAddress_Sel = "";
         AssignAttri("", false, "AV34TFSupplier_AgbVisitingAddress_Sel", AV34TFSupplier_AgbVisitingAddress_Sel);
         AV35TFSupplier_AgbPostalAddress = "";
         AssignAttri("", false, "AV35TFSupplier_AgbPostalAddress", AV35TFSupplier_AgbPostalAddress);
         AV36TFSupplier_AgbPostalAddress_Sel = "";
         AssignAttri("", false, "AV36TFSupplier_AgbPostalAddress_Sel", AV36TFSupplier_AgbPostalAddress_Sel);
         AV37TFSupplier_AgbEmail = "";
         AssignAttri("", false, "AV37TFSupplier_AgbEmail", AV37TFSupplier_AgbEmail);
         AV38TFSupplier_AgbEmail_Sel = "";
         AssignAttri("", false, "AV38TFSupplier_AgbEmail_Sel", AV38TFSupplier_AgbEmail_Sel);
         AV39TFSupplier_AgbPhone = "";
         AssignAttri("", false, "AV39TFSupplier_AgbPhone", AV39TFSupplier_AgbPhone);
         AV40TFSupplier_AgbPhone_Sel = "";
         AssignAttri("", false, "AV40TFSupplier_AgbPhone_Sel", AV40TFSupplier_AgbPhone_Sel);
         AV41TFSupplier_AgbContactName = "";
         AssignAttri("", false, "AV41TFSupplier_AgbContactName", AV41TFSupplier_AgbContactName);
         AV42TFSupplier_AgbContactName_Sel = "";
         AssignAttri("", false, "AV42TFSupplier_AgbContactName_Sel", AV42TFSupplier_AgbContactName_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV21Session.Get(AV56Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV56Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV21Session.Get(AV56Pgmname+"GridState"), null, "", "");
         }
         AV13OrderedBy = AV11GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
         AV14OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV11GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV11GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV11GridState.gxTpr_Currentpage) ;
      }

      protected void S192( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV76GXV1 = 1;
         while ( AV76GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV76GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV16FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_AGBID") == 0 )
            {
               AV25TFSupplier_AgbId = (short)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV25TFSupplier_AgbId", StringUtil.LTrimStr( (decimal)(AV25TFSupplier_AgbId), 4, 0));
               AV26TFSupplier_AgbId_To = (short)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV26TFSupplier_AgbId_To", StringUtil.LTrimStr( (decimal)(AV26TFSupplier_AgbId_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_AGBNUMBER") == 0 )
            {
               AV27TFSupplier_AgbNumber = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV27TFSupplier_AgbNumber", AV27TFSupplier_AgbNumber);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_AGBNUMBER_SEL") == 0 )
            {
               AV28TFSupplier_AgbNumber_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV28TFSupplier_AgbNumber_Sel", AV28TFSupplier_AgbNumber_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_AGBNAME") == 0 )
            {
               AV29TFSupplier_AgbName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV29TFSupplier_AgbName", AV29TFSupplier_AgbName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_AGBNAME_SEL") == 0 )
            {
               AV30TFSupplier_AgbName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV30TFSupplier_AgbName_Sel", AV30TFSupplier_AgbName_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_AGBKVKNUMBER") == 0 )
            {
               AV31TFSupplier_AgbKvkNumber = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV31TFSupplier_AgbKvkNumber", AV31TFSupplier_AgbKvkNumber);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_AGBKVKNUMBER_SEL") == 0 )
            {
               AV32TFSupplier_AgbKvkNumber_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV32TFSupplier_AgbKvkNumber_Sel", AV32TFSupplier_AgbKvkNumber_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_AGBVISITINGADDRESS") == 0 )
            {
               AV33TFSupplier_AgbVisitingAddress = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV33TFSupplier_AgbVisitingAddress", AV33TFSupplier_AgbVisitingAddress);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_AGBVISITINGADDRESS_SEL") == 0 )
            {
               AV34TFSupplier_AgbVisitingAddress_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV34TFSupplier_AgbVisitingAddress_Sel", AV34TFSupplier_AgbVisitingAddress_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_AGBPOSTALADDRESS") == 0 )
            {
               AV35TFSupplier_AgbPostalAddress = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV35TFSupplier_AgbPostalAddress", AV35TFSupplier_AgbPostalAddress);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_AGBPOSTALADDRESS_SEL") == 0 )
            {
               AV36TFSupplier_AgbPostalAddress_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV36TFSupplier_AgbPostalAddress_Sel", AV36TFSupplier_AgbPostalAddress_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_AGBEMAIL") == 0 )
            {
               AV37TFSupplier_AgbEmail = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV37TFSupplier_AgbEmail", AV37TFSupplier_AgbEmail);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_AGBEMAIL_SEL") == 0 )
            {
               AV38TFSupplier_AgbEmail_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV38TFSupplier_AgbEmail_Sel", AV38TFSupplier_AgbEmail_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_AGBPHONE") == 0 )
            {
               AV39TFSupplier_AgbPhone = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV39TFSupplier_AgbPhone", AV39TFSupplier_AgbPhone);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_AGBPHONE_SEL") == 0 )
            {
               AV40TFSupplier_AgbPhone_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV40TFSupplier_AgbPhone_Sel", AV40TFSupplier_AgbPhone_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_AGBCONTACTNAME") == 0 )
            {
               AV41TFSupplier_AgbContactName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV41TFSupplier_AgbContactName", AV41TFSupplier_AgbContactName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_AGBCONTACTNAME_SEL") == 0 )
            {
               AV42TFSupplier_AgbContactName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV42TFSupplier_AgbContactName_Sel", AV42TFSupplier_AgbContactName_Sel);
            }
            AV76GXV1 = (int)(AV76GXV1+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV28TFSupplier_AgbNumber_Sel)),  AV28TFSupplier_AgbNumber_Sel, out  GXt_char3) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV30TFSupplier_AgbName_Sel)),  AV30TFSupplier_AgbName_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV32TFSupplier_AgbKvkNumber_Sel)),  AV32TFSupplier_AgbKvkNumber_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV34TFSupplier_AgbVisitingAddress_Sel)),  AV34TFSupplier_AgbVisitingAddress_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV36TFSupplier_AgbPostalAddress_Sel)),  AV36TFSupplier_AgbPostalAddress_Sel, out  GXt_char8) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV38TFSupplier_AgbEmail_Sel)),  AV38TFSupplier_AgbEmail_Sel, out  GXt_char9) ;
         GXt_char10 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV40TFSupplier_AgbPhone_Sel)),  AV40TFSupplier_AgbPhone_Sel, out  GXt_char10) ;
         GXt_char11 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV42TFSupplier_AgbContactName_Sel)),  AV42TFSupplier_AgbContactName_Sel, out  GXt_char11) ;
         Ddo_grid_Selectedvalue_set = "|"+GXt_char3+"|"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7+"|"+GXt_char8+"|"+GXt_char9+"|"+GXt_char10+"|"+GXt_char11;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char11 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV27TFSupplier_AgbNumber)),  AV27TFSupplier_AgbNumber, out  GXt_char11) ;
         GXt_char10 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV29TFSupplier_AgbName)),  AV29TFSupplier_AgbName, out  GXt_char10) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV31TFSupplier_AgbKvkNumber)),  AV31TFSupplier_AgbKvkNumber, out  GXt_char9) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV33TFSupplier_AgbVisitingAddress)),  AV33TFSupplier_AgbVisitingAddress, out  GXt_char8) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV35TFSupplier_AgbPostalAddress)),  AV35TFSupplier_AgbPostalAddress, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV37TFSupplier_AgbEmail)),  AV37TFSupplier_AgbEmail, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV39TFSupplier_AgbPhone)),  AV39TFSupplier_AgbPhone, out  GXt_char5) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV41TFSupplier_AgbContactName)),  AV41TFSupplier_AgbContactName, out  GXt_char3) ;
         Ddo_grid_Filteredtext_set = ((0==AV25TFSupplier_AgbId) ? "" : StringUtil.Str( (decimal)(AV25TFSupplier_AgbId), 4, 0))+"|"+GXt_char11+"|"+GXt_char10+"|"+GXt_char9+"|"+GXt_char8+"|"+GXt_char7+"|"+GXt_char6+"|"+GXt_char5+"|"+GXt_char3;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((0==AV26TFSupplier_AgbId_To) ? "" : StringUtil.Str( (decimal)(AV26TFSupplier_AgbId_To), 4, 0))+"||||||||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV21Session.Get(AV56Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)),  0,  AV16FilterFullText,  AV16FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFSUPPLIER_AGBID",  context.GetMessage( "Id", ""),  !((0==AV25TFSupplier_AgbId)&&(0==AV26TFSupplier_AgbId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV25TFSupplier_AgbId), 4, 0)),  ((0==AV25TFSupplier_AgbId) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV25TFSupplier_AgbId), "ZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV26TFSupplier_AgbId_To), 4, 0)),  ((0==AV26TFSupplier_AgbId_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV26TFSupplier_AgbId_To), "ZZZ9")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFSUPPLIER_AGBNUMBER",  context.GetMessage( "Number", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV27TFSupplier_AgbNumber)),  0,  AV27TFSupplier_AgbNumber,  AV27TFSupplier_AgbNumber,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV28TFSupplier_AgbNumber_Sel)),  AV28TFSupplier_AgbNumber_Sel,  AV28TFSupplier_AgbNumber_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFSUPPLIER_AGBNAME",  context.GetMessage( "Name", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV29TFSupplier_AgbName)),  0,  AV29TFSupplier_AgbName,  AV29TFSupplier_AgbName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV30TFSupplier_AgbName_Sel)),  AV30TFSupplier_AgbName_Sel,  AV30TFSupplier_AgbName_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFSUPPLIER_AGBKVKNUMBER",  context.GetMessage( "Kvk Number", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV31TFSupplier_AgbKvkNumber)),  0,  AV31TFSupplier_AgbKvkNumber,  AV31TFSupplier_AgbKvkNumber,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV32TFSupplier_AgbKvkNumber_Sel)),  AV32TFSupplier_AgbKvkNumber_Sel,  AV32TFSupplier_AgbKvkNumber_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFSUPPLIER_AGBVISITINGADDRESS",  context.GetMessage( "Visiting Address", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV33TFSupplier_AgbVisitingAddress)),  0,  AV33TFSupplier_AgbVisitingAddress,  AV33TFSupplier_AgbVisitingAddress,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV34TFSupplier_AgbVisitingAddress_Sel)),  AV34TFSupplier_AgbVisitingAddress_Sel,  AV34TFSupplier_AgbVisitingAddress_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFSUPPLIER_AGBPOSTALADDRESS",  context.GetMessage( "Postal Address", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV35TFSupplier_AgbPostalAddress)),  0,  AV35TFSupplier_AgbPostalAddress,  AV35TFSupplier_AgbPostalAddress,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV36TFSupplier_AgbPostalAddress_Sel)),  AV36TFSupplier_AgbPostalAddress_Sel,  AV36TFSupplier_AgbPostalAddress_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFSUPPLIER_AGBEMAIL",  context.GetMessage( "Email", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV37TFSupplier_AgbEmail)),  0,  AV37TFSupplier_AgbEmail,  AV37TFSupplier_AgbEmail,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV38TFSupplier_AgbEmail_Sel)),  AV38TFSupplier_AgbEmail_Sel,  AV38TFSupplier_AgbEmail_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFSUPPLIER_AGBPHONE",  context.GetMessage( "Phone", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV39TFSupplier_AgbPhone)),  0,  AV39TFSupplier_AgbPhone,  AV39TFSupplier_AgbPhone,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV40TFSupplier_AgbPhone_Sel)),  AV40TFSupplier_AgbPhone_Sel,  AV40TFSupplier_AgbPhone_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFSUPPLIER_AGBCONTACTNAME",  context.GetMessage( "Contact Name", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV41TFSupplier_AgbContactName)),  0,  AV41TFSupplier_AgbContactName,  AV41TFSupplier_AgbContactName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV42TFSupplier_AgbContactName_Sel)),  AV42TFSupplier_AgbContactName_Sel,  AV42TFSupplier_AgbContactName_Sel) ;
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV56Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV56Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "Supplier_Agb";
         AV21Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
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
         PA1L2( ) ;
         WS1L2( ) ;
         WE1L2( ) ;
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
         AddStyleSheetFile("DVelop/DVPaginationBar/DVPaginationBar.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202481915574559", true, true);
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
         context.AddJavascriptSource("supplier_agbww.js", "?202481915574560", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_372( )
      {
         edtSupplier_AgbId_Internalname = "SUPPLIER_AGBID_"+sGXsfl_37_idx;
         edtSupplier_AgbNumber_Internalname = "SUPPLIER_AGBNUMBER_"+sGXsfl_37_idx;
         edtSupplier_AgbName_Internalname = "SUPPLIER_AGBNAME_"+sGXsfl_37_idx;
         edtSupplier_AgbKvkNumber_Internalname = "SUPPLIER_AGBKVKNUMBER_"+sGXsfl_37_idx;
         edtSupplier_AgbVisitingAddress_Internalname = "SUPPLIER_AGBVISITINGADDRESS_"+sGXsfl_37_idx;
         edtSupplier_AgbPostalAddress_Internalname = "SUPPLIER_AGBPOSTALADDRESS_"+sGXsfl_37_idx;
         edtSupplier_AgbEmail_Internalname = "SUPPLIER_AGBEMAIL_"+sGXsfl_37_idx;
         edtSupplier_AgbPhone_Internalname = "SUPPLIER_AGBPHONE_"+sGXsfl_37_idx;
         edtSupplier_AgbContactName_Internalname = "SUPPLIER_AGBCONTACTNAME_"+sGXsfl_37_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_37_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_37_idx;
      }

      protected void SubsflControlProps_fel_372( )
      {
         edtSupplier_AgbId_Internalname = "SUPPLIER_AGBID_"+sGXsfl_37_fel_idx;
         edtSupplier_AgbNumber_Internalname = "SUPPLIER_AGBNUMBER_"+sGXsfl_37_fel_idx;
         edtSupplier_AgbName_Internalname = "SUPPLIER_AGBNAME_"+sGXsfl_37_fel_idx;
         edtSupplier_AgbKvkNumber_Internalname = "SUPPLIER_AGBKVKNUMBER_"+sGXsfl_37_fel_idx;
         edtSupplier_AgbVisitingAddress_Internalname = "SUPPLIER_AGBVISITINGADDRESS_"+sGXsfl_37_fel_idx;
         edtSupplier_AgbPostalAddress_Internalname = "SUPPLIER_AGBPOSTALADDRESS_"+sGXsfl_37_fel_idx;
         edtSupplier_AgbEmail_Internalname = "SUPPLIER_AGBEMAIL_"+sGXsfl_37_fel_idx;
         edtSupplier_AgbPhone_Internalname = "SUPPLIER_AGBPHONE_"+sGXsfl_37_fel_idx;
         edtSupplier_AgbContactName_Internalname = "SUPPLIER_AGBCONTACTNAME_"+sGXsfl_37_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_37_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_37_fel_idx;
      }

      protected void sendrow_372( )
      {
         SubsflControlProps_372( ) ;
         WB1L0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_37_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0x0);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_37_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_37_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtSupplier_AgbId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplier_AgbId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A55Supplier_AgbId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A55Supplier_AgbId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplier_AgbId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtSupplier_AgbId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtSupplier_AgbNumber_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplier_AgbNumber_Internalname,(string)A56Supplier_AgbNumber,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtSupplier_AgbNumber_Link,(string)"",(string)"",(string)"",(string)edtSupplier_AgbNumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtSupplier_AgbNumber_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"AgbNumber",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtSupplier_AgbName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplier_AgbName_Internalname,(string)A57Supplier_AgbName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplier_AgbName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtSupplier_AgbName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtSupplier_AgbKvkNumber_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplier_AgbKvkNumber_Internalname,(string)A58Supplier_AgbKvkNumber,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplier_AgbKvkNumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtSupplier_AgbKvkNumber_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"KvkNumber",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtSupplier_AgbVisitingAddress_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplier_AgbVisitingAddress_Internalname,(string)A59Supplier_AgbVisitingAddress,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'","http://maps.google.com/maps?q="+GXUtil.UrlEncode( A59Supplier_AgbVisitingAddress),(string)"_blank",(string)"",(string)"",(string)edtSupplier_AgbVisitingAddress_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtSupplier_AgbVisitingAddress_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Address",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtSupplier_AgbPostalAddress_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplier_AgbPostalAddress_Internalname,(string)A60Supplier_AgbPostalAddress,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'","http://maps.google.com/maps?q="+GXUtil.UrlEncode( A60Supplier_AgbPostalAddress),(string)"_blank",(string)"",(string)"",(string)edtSupplier_AgbPostalAddress_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtSupplier_AgbPostalAddress_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Address",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtSupplier_AgbEmail_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplier_AgbEmail_Internalname,(string)A61Supplier_AgbEmail,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A61Supplier_AgbEmail,(string)"",(string)"",(string)"",(string)edtSupplier_AgbEmail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtSupplier_AgbEmail_Visible,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtSupplier_AgbPhone_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A62Supplier_AgbPhone);
            }
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplier_AgbPhone_Internalname,StringUtil.RTrim( A62Supplier_AgbPhone),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtSupplier_AgbPhone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtSupplier_AgbPhone_Visible,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtSupplier_AgbContactName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplier_AgbContactName_Internalname,(string)A63Supplier_AgbContactName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplier_AgbContactName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtSupplier_AgbContactName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV50Update),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",context.GetMessage( "GXM_update", ""),(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV52Delete),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDelete_Link,(string)"",context.GetMessage( "GX_BtnDelete", ""),(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavDelete_Visible,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes1L2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_37_idx = ((subGrid_Islastpage==1)&&(nGXsfl_37_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_37_idx+1);
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
         }
         /* End function sendrow_372 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl37( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"37\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "GridWithPaginationBar WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid_Backcolorstyle == 0 )
            {
               subGrid_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid_Class) > 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Title";
               }
            }
            else
            {
               subGrid_Titlebackstyle = 1;
               if ( subGrid_Backcolorstyle == 1 )
               {
                  subGrid_Titlebackcolor = subGrid_Allbackcolor;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSupplier_AgbId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSupplier_AgbNumber_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Number", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSupplier_AgbName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSupplier_AgbKvkNumber_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Kvk Number", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSupplier_AgbVisitingAddress_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Visiting Address", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSupplier_AgbPostalAddress_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Postal Address", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSupplier_AgbEmail_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Email", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSupplier_AgbPhone_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Phone", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSupplier_AgbContactName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Contact Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridContainer = new GXWebGrid( context);
            }
            else
            {
               GridContainer.Clear();
            }
            GridContainer.SetWrapped(nGXWrapped);
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A55Supplier_AgbId), 4, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_AgbId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A56Supplier_AgbNumber));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtSupplier_AgbNumber_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_AgbNumber_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A57Supplier_AgbName));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_AgbName_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A58Supplier_AgbKvkNumber));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_AgbKvkNumber_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A59Supplier_AgbVisitingAddress));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_AgbVisitingAddress_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A60Supplier_AgbPostalAddress));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_AgbPostalAddress_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A61Supplier_AgbEmail));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_AgbEmail_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A62Supplier_AgbPhone)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_AgbPhone_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A63Supplier_AgbContactName));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_AgbContactName_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV50Update)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV52Delete)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDelete_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         bttBtninsert_Internalname = "BTNINSERT";
         bttBtneditcolumns_Internalname = "BTNEDITCOLUMNS";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         divTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         edtSupplier_AgbId_Internalname = "SUPPLIER_AGBID";
         edtSupplier_AgbNumber_Internalname = "SUPPLIER_AGBNUMBER";
         edtSupplier_AgbName_Internalname = "SUPPLIER_AGBNAME";
         edtSupplier_AgbKvkNumber_Internalname = "SUPPLIER_AGBKVKNUMBER";
         edtSupplier_AgbVisitingAddress_Internalname = "SUPPLIER_AGBVISITINGADDRESS";
         edtSupplier_AgbPostalAddress_Internalname = "SUPPLIER_AGBPOSTALADDRESS";
         edtSupplier_AgbEmail_Internalname = "SUPPLIER_AGBEMAIL";
         edtSupplier_AgbPhone_Internalname = "SUPPLIER_AGBPHONE";
         edtSupplier_AgbContactName_Internalname = "SUPPLIER_AGBCONTACTNAME";
         edtavUpdate_Internalname = "vUPDATE";
         edtavDelete_Internalname = "vDELETE";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_grid_Internalname = "DDO_GRID";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         edtavDelete_Jsonclick = "";
         edtavDelete_Link = "";
         edtavDelete_Enabled = 0;
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Link = "";
         edtavUpdate_Enabled = 0;
         edtSupplier_AgbContactName_Jsonclick = "";
         edtSupplier_AgbPhone_Jsonclick = "";
         edtSupplier_AgbEmail_Jsonclick = "";
         edtSupplier_AgbPostalAddress_Jsonclick = "";
         edtSupplier_AgbVisitingAddress_Jsonclick = "";
         edtSupplier_AgbKvkNumber_Jsonclick = "";
         edtSupplier_AgbName_Jsonclick = "";
         edtSupplier_AgbNumber_Jsonclick = "";
         edtSupplier_AgbNumber_Link = "";
         edtSupplier_AgbId_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavDelete_Visible = -1;
         edtavUpdate_Visible = -1;
         edtSupplier_AgbContactName_Visible = -1;
         edtSupplier_AgbPhone_Visible = -1;
         edtSupplier_AgbEmail_Visible = -1;
         edtSupplier_AgbPostalAddress_Visible = -1;
         edtSupplier_AgbVisitingAddress_Visible = -1;
         edtSupplier_AgbKvkNumber_Visible = -1;
         edtSupplier_AgbName_Visible = -1;
         edtSupplier_AgbNumber_Visible = -1;
         edtSupplier_AgbId_Visible = -1;
         edtSupplier_AgbContactName_Enabled = 0;
         edtSupplier_AgbPhone_Enabled = 0;
         edtSupplier_AgbEmail_Enabled = 0;
         edtSupplier_AgbPostalAddress_Enabled = 0;
         edtSupplier_AgbVisitingAddress_Enabled = 0;
         edtSupplier_AgbKvkNumber_Enabled = 0;
         edtSupplier_AgbName_Enabled = 0;
         edtSupplier_AgbNumber_Enabled = 0;
         edtSupplier_AgbId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         bttBtninsert_Visible = 1;
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = "";
         Ddo_gridcolumnsselector_Dropdownoptionstype = "GridColumnsSelector";
         Ddo_gridcolumnsselector_Cls = "ColumnsSelector hidden-xs";
         Ddo_gridcolumnsselector_Tooltip = "WWP_EditColumnsTooltip";
         Ddo_gridcolumnsselector_Caption = context.GetMessage( "WWP_EditColumnsCaption", "");
         Ddo_gridcolumnsselector_Icon = "fas fa-cog";
         Ddo_gridcolumnsselector_Icontype = "FontIcon";
         Ddo_grid_Format = "4.0||||||||";
         Ddo_grid_Datalistproc = "Supplier_AgbWWGetFilterData";
         Ddo_grid_Datalisttype = "|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "|T|T|T|T|T|T|T|T";
         Ddo_grid_Filterisrange = "T||||||||";
         Ddo_grid_Filtertype = "Numeric|Character|Character|Character|Character|Character|Character|Character|Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|1|3|4|5|6|7|8|9";
         Ddo_grid_Columnids = "0:Supplier_AgbId|1:Supplier_AgbNumber|2:Supplier_AgbName|3:Supplier_AgbKvkNumber|4:Supplier_AgbVisitingAddress|5:Supplier_AgbPostalAddress|6:Supplier_AgbEmail|7:Supplier_AgbPhone|8:Supplier_AgbContactName";
         Ddo_grid_Gridinternalname = "";
         Gridpaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridpaginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Gridpaginationbar_Caption = context.GetMessage( "WWP_PagingCaption", "");
         Gridpaginationbar_Next = "WWP_PagingNextCaption";
         Gridpaginationbar_Previous = "WWP_PagingPreviousCaption";
         Gridpaginationbar_Rowsperpageoptions = "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50";
         Gridpaginationbar_Rowsperpageselectedvalue = 10;
         Gridpaginationbar_Rowsperpageselector = Convert.ToBoolean( -1);
         Gridpaginationbar_Emptygridclass = "PaginationBarEmptyGrid";
         Gridpaginationbar_Pagingcaptionposition = "Left";
         Gridpaginationbar_Pagingbuttonsposition = "Right";
         Gridpaginationbar_Pagestoshow = 5;
         Gridpaginationbar_Showlast = Convert.ToBoolean( 0);
         Gridpaginationbar_Shownext = Convert.ToBoolean( -1);
         Gridpaginationbar_Showprevious = Convert.ToBoolean( -1);
         Gridpaginationbar_Showfirst = Convert.ToBoolean( 0);
         Gridpaginationbar_Class = "PaginationBar";
         Ddo_managefilters_Cls = "ManageFilters";
         Ddo_managefilters_Tooltip = "WWP_ManageFiltersTooltip";
         Ddo_managefilters_Icon = "fas fa-filter";
         Ddo_managefilters_Icontype = "FontIcon";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( " AGB Suppliers", "");
         subGrid_Rows = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV24ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV19ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV56Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV25TFSupplier_AgbId',fld:'vTFSUPPLIER_AGBID',pic:'ZZZ9'},{av:'AV26TFSupplier_AgbId_To',fld:'vTFSUPPLIER_AGBID_TO',pic:'ZZZ9'},{av:'AV27TFSupplier_AgbNumber',fld:'vTFSUPPLIER_AGBNUMBER',pic:''},{av:'AV28TFSupplier_AgbNumber_Sel',fld:'vTFSUPPLIER_AGBNUMBER_SEL',pic:''},{av:'AV29TFSupplier_AgbName',fld:'vTFSUPPLIER_AGBNAME',pic:''},{av:'AV30TFSupplier_AgbName_Sel',fld:'vTFSUPPLIER_AGBNAME_SEL',pic:''},{av:'AV31TFSupplier_AgbKvkNumber',fld:'vTFSUPPLIER_AGBKVKNUMBER',pic:''},{av:'AV32TFSupplier_AgbKvkNumber_Sel',fld:'vTFSUPPLIER_AGBKVKNUMBER_SEL',pic:''},{av:'AV33TFSupplier_AgbVisitingAddress',fld:'vTFSUPPLIER_AGBVISITINGADDRESS',pic:''},{av:'AV34TFSupplier_AgbVisitingAddress_Sel',fld:'vTFSUPPLIER_AGBVISITINGADDRESS_SEL',pic:''},{av:'AV35TFSupplier_AgbPostalAddress',fld:'vTFSUPPLIER_AGBPOSTALADDRESS',pic:''},{av:'AV36TFSupplier_AgbPostalAddress_Sel',fld:'vTFSUPPLIER_AGBPOSTALADDRESS_SEL',pic:''},{av:'AV37TFSupplier_AgbEmail',fld:'vTFSUPPLIER_AGBEMAIL',pic:''},{av:'AV38TFSupplier_AgbEmail_Sel',fld:'vTFSUPPLIER_AGBEMAIL_SEL',pic:''},{av:'AV39TFSupplier_AgbPhone',fld:'vTFSUPPLIER_AGBPHONE',pic:''},{av:'AV40TFSupplier_AgbPhone_Sel',fld:'vTFSUPPLIER_AGBPHONE_SEL',pic:''},{av:'AV41TFSupplier_AgbContactName',fld:'vTFSUPPLIER_AGBCONTACTNAME',pic:''},{av:'AV42TFSupplier_AgbContactName_Sel',fld:'vTFSUPPLIER_AGBCONTACTNAME_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV51IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV53IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV54IsAuthorized_Supplier_AgbNumber',fld:'vISAUTHORIZED_SUPPLIER_AGBNUMBER',pic:'',hsh:true},{av:'AV55IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV24ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV19ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtSupplier_AgbId_Visible',ctrl:'SUPPLIER_AGBID',prop:'Visible'},{av:'edtSupplier_AgbNumber_Visible',ctrl:'SUPPLIER_AGBNUMBER',prop:'Visible'},{av:'edtSupplier_AgbName_Visible',ctrl:'SUPPLIER_AGBNAME',prop:'Visible'},{av:'edtSupplier_AgbKvkNumber_Visible',ctrl:'SUPPLIER_AGBKVKNUMBER',prop:'Visible'},{av:'edtSupplier_AgbVisitingAddress_Visible',ctrl:'SUPPLIER_AGBVISITINGADDRESS',prop:'Visible'},{av:'edtSupplier_AgbPostalAddress_Visible',ctrl:'SUPPLIER_AGBPOSTALADDRESS',prop:'Visible'},{av:'edtSupplier_AgbEmail_Visible',ctrl:'SUPPLIER_AGBEMAIL',prop:'Visible'},{av:'edtSupplier_AgbPhone_Visible',ctrl:'SUPPLIER_AGBPHONE',prop:'Visible'},{av:'edtSupplier_AgbContactName_Visible',ctrl:'SUPPLIER_AGBCONTACTNAME',prop:'Visible'},{av:'AV47GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV48GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV49GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV51IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV53IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV55IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV22ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E121L2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV24ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV19ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV56Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV25TFSupplier_AgbId',fld:'vTFSUPPLIER_AGBID',pic:'ZZZ9'},{av:'AV26TFSupplier_AgbId_To',fld:'vTFSUPPLIER_AGBID_TO',pic:'ZZZ9'},{av:'AV27TFSupplier_AgbNumber',fld:'vTFSUPPLIER_AGBNUMBER',pic:''},{av:'AV28TFSupplier_AgbNumber_Sel',fld:'vTFSUPPLIER_AGBNUMBER_SEL',pic:''},{av:'AV29TFSupplier_AgbName',fld:'vTFSUPPLIER_AGBNAME',pic:''},{av:'AV30TFSupplier_AgbName_Sel',fld:'vTFSUPPLIER_AGBNAME_SEL',pic:''},{av:'AV31TFSupplier_AgbKvkNumber',fld:'vTFSUPPLIER_AGBKVKNUMBER',pic:''},{av:'AV32TFSupplier_AgbKvkNumber_Sel',fld:'vTFSUPPLIER_AGBKVKNUMBER_SEL',pic:''},{av:'AV33TFSupplier_AgbVisitingAddress',fld:'vTFSUPPLIER_AGBVISITINGADDRESS',pic:''},{av:'AV34TFSupplier_AgbVisitingAddress_Sel',fld:'vTFSUPPLIER_AGBVISITINGADDRESS_SEL',pic:''},{av:'AV35TFSupplier_AgbPostalAddress',fld:'vTFSUPPLIER_AGBPOSTALADDRESS',pic:''},{av:'AV36TFSupplier_AgbPostalAddress_Sel',fld:'vTFSUPPLIER_AGBPOSTALADDRESS_SEL',pic:''},{av:'AV37TFSupplier_AgbEmail',fld:'vTFSUPPLIER_AGBEMAIL',pic:''},{av:'AV38TFSupplier_AgbEmail_Sel',fld:'vTFSUPPLIER_AGBEMAIL_SEL',pic:''},{av:'AV39TFSupplier_AgbPhone',fld:'vTFSUPPLIER_AGBPHONE',pic:''},{av:'AV40TFSupplier_AgbPhone_Sel',fld:'vTFSUPPLIER_AGBPHONE_SEL',pic:''},{av:'AV41TFSupplier_AgbContactName',fld:'vTFSUPPLIER_AGBCONTACTNAME',pic:''},{av:'AV42TFSupplier_AgbContactName_Sel',fld:'vTFSUPPLIER_AGBCONTACTNAME_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV51IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV53IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV54IsAuthorized_Supplier_AgbNumber',fld:'vISAUTHORIZED_SUPPLIER_AGBNUMBER',pic:'',hsh:true},{av:'AV55IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E131L2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV24ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV19ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV56Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV25TFSupplier_AgbId',fld:'vTFSUPPLIER_AGBID',pic:'ZZZ9'},{av:'AV26TFSupplier_AgbId_To',fld:'vTFSUPPLIER_AGBID_TO',pic:'ZZZ9'},{av:'AV27TFSupplier_AgbNumber',fld:'vTFSUPPLIER_AGBNUMBER',pic:''},{av:'AV28TFSupplier_AgbNumber_Sel',fld:'vTFSUPPLIER_AGBNUMBER_SEL',pic:''},{av:'AV29TFSupplier_AgbName',fld:'vTFSUPPLIER_AGBNAME',pic:''},{av:'AV30TFSupplier_AgbName_Sel',fld:'vTFSUPPLIER_AGBNAME_SEL',pic:''},{av:'AV31TFSupplier_AgbKvkNumber',fld:'vTFSUPPLIER_AGBKVKNUMBER',pic:''},{av:'AV32TFSupplier_AgbKvkNumber_Sel',fld:'vTFSUPPLIER_AGBKVKNUMBER_SEL',pic:''},{av:'AV33TFSupplier_AgbVisitingAddress',fld:'vTFSUPPLIER_AGBVISITINGADDRESS',pic:''},{av:'AV34TFSupplier_AgbVisitingAddress_Sel',fld:'vTFSUPPLIER_AGBVISITINGADDRESS_SEL',pic:''},{av:'AV35TFSupplier_AgbPostalAddress',fld:'vTFSUPPLIER_AGBPOSTALADDRESS',pic:''},{av:'AV36TFSupplier_AgbPostalAddress_Sel',fld:'vTFSUPPLIER_AGBPOSTALADDRESS_SEL',pic:''},{av:'AV37TFSupplier_AgbEmail',fld:'vTFSUPPLIER_AGBEMAIL',pic:''},{av:'AV38TFSupplier_AgbEmail_Sel',fld:'vTFSUPPLIER_AGBEMAIL_SEL',pic:''},{av:'AV39TFSupplier_AgbPhone',fld:'vTFSUPPLIER_AGBPHONE',pic:''},{av:'AV40TFSupplier_AgbPhone_Sel',fld:'vTFSUPPLIER_AGBPHONE_SEL',pic:''},{av:'AV41TFSupplier_AgbContactName',fld:'vTFSUPPLIER_AGBCONTACTNAME',pic:''},{av:'AV42TFSupplier_AgbContactName_Sel',fld:'vTFSUPPLIER_AGBCONTACTNAME_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV51IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV53IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV54IsAuthorized_Supplier_AgbNumber',fld:'vISAUTHORIZED_SUPPLIER_AGBNUMBER',pic:'',hsh:true},{av:'AV55IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E141L2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV24ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV19ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV56Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV25TFSupplier_AgbId',fld:'vTFSUPPLIER_AGBID',pic:'ZZZ9'},{av:'AV26TFSupplier_AgbId_To',fld:'vTFSUPPLIER_AGBID_TO',pic:'ZZZ9'},{av:'AV27TFSupplier_AgbNumber',fld:'vTFSUPPLIER_AGBNUMBER',pic:''},{av:'AV28TFSupplier_AgbNumber_Sel',fld:'vTFSUPPLIER_AGBNUMBER_SEL',pic:''},{av:'AV29TFSupplier_AgbName',fld:'vTFSUPPLIER_AGBNAME',pic:''},{av:'AV30TFSupplier_AgbName_Sel',fld:'vTFSUPPLIER_AGBNAME_SEL',pic:''},{av:'AV31TFSupplier_AgbKvkNumber',fld:'vTFSUPPLIER_AGBKVKNUMBER',pic:''},{av:'AV32TFSupplier_AgbKvkNumber_Sel',fld:'vTFSUPPLIER_AGBKVKNUMBER_SEL',pic:''},{av:'AV33TFSupplier_AgbVisitingAddress',fld:'vTFSUPPLIER_AGBVISITINGADDRESS',pic:''},{av:'AV34TFSupplier_AgbVisitingAddress_Sel',fld:'vTFSUPPLIER_AGBVISITINGADDRESS_SEL',pic:''},{av:'AV35TFSupplier_AgbPostalAddress',fld:'vTFSUPPLIER_AGBPOSTALADDRESS',pic:''},{av:'AV36TFSupplier_AgbPostalAddress_Sel',fld:'vTFSUPPLIER_AGBPOSTALADDRESS_SEL',pic:''},{av:'AV37TFSupplier_AgbEmail',fld:'vTFSUPPLIER_AGBEMAIL',pic:''},{av:'AV38TFSupplier_AgbEmail_Sel',fld:'vTFSUPPLIER_AGBEMAIL_SEL',pic:''},{av:'AV39TFSupplier_AgbPhone',fld:'vTFSUPPLIER_AGBPHONE',pic:''},{av:'AV40TFSupplier_AgbPhone_Sel',fld:'vTFSUPPLIER_AGBPHONE_SEL',pic:''},{av:'AV41TFSupplier_AgbContactName',fld:'vTFSUPPLIER_AGBCONTACTNAME',pic:''},{av:'AV42TFSupplier_AgbContactName_Sel',fld:'vTFSUPPLIER_AGBCONTACTNAME_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV51IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV53IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV54IsAuthorized_Supplier_AgbNumber',fld:'vISAUTHORIZED_SUPPLIER_AGBNUMBER',pic:'',hsh:true},{av:'AV55IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV41TFSupplier_AgbContactName',fld:'vTFSUPPLIER_AGBCONTACTNAME',pic:''},{av:'AV42TFSupplier_AgbContactName_Sel',fld:'vTFSUPPLIER_AGBCONTACTNAME_SEL',pic:''},{av:'AV39TFSupplier_AgbPhone',fld:'vTFSUPPLIER_AGBPHONE',pic:''},{av:'AV40TFSupplier_AgbPhone_Sel',fld:'vTFSUPPLIER_AGBPHONE_SEL',pic:''},{av:'AV37TFSupplier_AgbEmail',fld:'vTFSUPPLIER_AGBEMAIL',pic:''},{av:'AV38TFSupplier_AgbEmail_Sel',fld:'vTFSUPPLIER_AGBEMAIL_SEL',pic:''},{av:'AV35TFSupplier_AgbPostalAddress',fld:'vTFSUPPLIER_AGBPOSTALADDRESS',pic:''},{av:'AV36TFSupplier_AgbPostalAddress_Sel',fld:'vTFSUPPLIER_AGBPOSTALADDRESS_SEL',pic:''},{av:'AV33TFSupplier_AgbVisitingAddress',fld:'vTFSUPPLIER_AGBVISITINGADDRESS',pic:''},{av:'AV34TFSupplier_AgbVisitingAddress_Sel',fld:'vTFSUPPLIER_AGBVISITINGADDRESS_SEL',pic:''},{av:'AV31TFSupplier_AgbKvkNumber',fld:'vTFSUPPLIER_AGBKVKNUMBER',pic:''},{av:'AV32TFSupplier_AgbKvkNumber_Sel',fld:'vTFSUPPLIER_AGBKVKNUMBER_SEL',pic:''},{av:'AV29TFSupplier_AgbName',fld:'vTFSUPPLIER_AGBNAME',pic:''},{av:'AV30TFSupplier_AgbName_Sel',fld:'vTFSUPPLIER_AGBNAME_SEL',pic:''},{av:'AV27TFSupplier_AgbNumber',fld:'vTFSUPPLIER_AGBNUMBER',pic:''},{av:'AV28TFSupplier_AgbNumber_Sel',fld:'vTFSUPPLIER_AGBNUMBER_SEL',pic:''},{av:'AV25TFSupplier_AgbId',fld:'vTFSUPPLIER_AGBID',pic:'ZZZ9'},{av:'AV26TFSupplier_AgbId_To',fld:'vTFSUPPLIER_AGBID_TO',pic:'ZZZ9'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E191L2',iparms:[{av:'AV51IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'A55Supplier_AgbId',fld:'SUPPLIER_AGBID',pic:'ZZZ9',hsh:true},{av:'AV53IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV54IsAuthorized_Supplier_AgbNumber',fld:'vISAUTHORIZED_SUPPLIER_AGBNUMBER',pic:'',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'AV50Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Link',ctrl:'vUPDATE',prop:'Link'},{av:'AV52Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Link',ctrl:'vDELETE',prop:'Link'},{av:'edtSupplier_AgbNumber_Link',ctrl:'SUPPLIER_AGBNUMBER',prop:'Link'}]}");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","{handler:'E151L2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV24ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV19ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV56Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV25TFSupplier_AgbId',fld:'vTFSUPPLIER_AGBID',pic:'ZZZ9'},{av:'AV26TFSupplier_AgbId_To',fld:'vTFSUPPLIER_AGBID_TO',pic:'ZZZ9'},{av:'AV27TFSupplier_AgbNumber',fld:'vTFSUPPLIER_AGBNUMBER',pic:''},{av:'AV28TFSupplier_AgbNumber_Sel',fld:'vTFSUPPLIER_AGBNUMBER_SEL',pic:''},{av:'AV29TFSupplier_AgbName',fld:'vTFSUPPLIER_AGBNAME',pic:''},{av:'AV30TFSupplier_AgbName_Sel',fld:'vTFSUPPLIER_AGBNAME_SEL',pic:''},{av:'AV31TFSupplier_AgbKvkNumber',fld:'vTFSUPPLIER_AGBKVKNUMBER',pic:''},{av:'AV32TFSupplier_AgbKvkNumber_Sel',fld:'vTFSUPPLIER_AGBKVKNUMBER_SEL',pic:''},{av:'AV33TFSupplier_AgbVisitingAddress',fld:'vTFSUPPLIER_AGBVISITINGADDRESS',pic:''},{av:'AV34TFSupplier_AgbVisitingAddress_Sel',fld:'vTFSUPPLIER_AGBVISITINGADDRESS_SEL',pic:''},{av:'AV35TFSupplier_AgbPostalAddress',fld:'vTFSUPPLIER_AGBPOSTALADDRESS',pic:''},{av:'AV36TFSupplier_AgbPostalAddress_Sel',fld:'vTFSUPPLIER_AGBPOSTALADDRESS_SEL',pic:''},{av:'AV37TFSupplier_AgbEmail',fld:'vTFSUPPLIER_AGBEMAIL',pic:''},{av:'AV38TFSupplier_AgbEmail_Sel',fld:'vTFSUPPLIER_AGBEMAIL_SEL',pic:''},{av:'AV39TFSupplier_AgbPhone',fld:'vTFSUPPLIER_AGBPHONE',pic:''},{av:'AV40TFSupplier_AgbPhone_Sel',fld:'vTFSUPPLIER_AGBPHONE_SEL',pic:''},{av:'AV41TFSupplier_AgbContactName',fld:'vTFSUPPLIER_AGBCONTACTNAME',pic:''},{av:'AV42TFSupplier_AgbContactName_Sel',fld:'vTFSUPPLIER_AGBCONTACTNAME_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV51IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV53IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV54IsAuthorized_Supplier_AgbNumber',fld:'vISAUTHORIZED_SUPPLIER_AGBNUMBER',pic:'',hsh:true},{av:'AV55IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_gridcolumnsselector_Columnsselectorvalues',ctrl:'DDO_GRIDCOLUMNSSELECTOR',prop:'ColumnsSelectorValues'}]");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",",oparms:[{av:'AV19ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV24ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'edtSupplier_AgbId_Visible',ctrl:'SUPPLIER_AGBID',prop:'Visible'},{av:'edtSupplier_AgbNumber_Visible',ctrl:'SUPPLIER_AGBNUMBER',prop:'Visible'},{av:'edtSupplier_AgbName_Visible',ctrl:'SUPPLIER_AGBNAME',prop:'Visible'},{av:'edtSupplier_AgbKvkNumber_Visible',ctrl:'SUPPLIER_AGBKVKNUMBER',prop:'Visible'},{av:'edtSupplier_AgbVisitingAddress_Visible',ctrl:'SUPPLIER_AGBVISITINGADDRESS',prop:'Visible'},{av:'edtSupplier_AgbPostalAddress_Visible',ctrl:'SUPPLIER_AGBPOSTALADDRESS',prop:'Visible'},{av:'edtSupplier_AgbEmail_Visible',ctrl:'SUPPLIER_AGBEMAIL',prop:'Visible'},{av:'edtSupplier_AgbPhone_Visible',ctrl:'SUPPLIER_AGBPHONE',prop:'Visible'},{av:'edtSupplier_AgbContactName_Visible',ctrl:'SUPPLIER_AGBCONTACTNAME',prop:'Visible'},{av:'AV47GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV48GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV49GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV51IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV53IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV55IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV22ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E111L2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV24ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV19ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV56Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV25TFSupplier_AgbId',fld:'vTFSUPPLIER_AGBID',pic:'ZZZ9'},{av:'AV26TFSupplier_AgbId_To',fld:'vTFSUPPLIER_AGBID_TO',pic:'ZZZ9'},{av:'AV27TFSupplier_AgbNumber',fld:'vTFSUPPLIER_AGBNUMBER',pic:''},{av:'AV28TFSupplier_AgbNumber_Sel',fld:'vTFSUPPLIER_AGBNUMBER_SEL',pic:''},{av:'AV29TFSupplier_AgbName',fld:'vTFSUPPLIER_AGBNAME',pic:''},{av:'AV30TFSupplier_AgbName_Sel',fld:'vTFSUPPLIER_AGBNAME_SEL',pic:''},{av:'AV31TFSupplier_AgbKvkNumber',fld:'vTFSUPPLIER_AGBKVKNUMBER',pic:''},{av:'AV32TFSupplier_AgbKvkNumber_Sel',fld:'vTFSUPPLIER_AGBKVKNUMBER_SEL',pic:''},{av:'AV33TFSupplier_AgbVisitingAddress',fld:'vTFSUPPLIER_AGBVISITINGADDRESS',pic:''},{av:'AV34TFSupplier_AgbVisitingAddress_Sel',fld:'vTFSUPPLIER_AGBVISITINGADDRESS_SEL',pic:''},{av:'AV35TFSupplier_AgbPostalAddress',fld:'vTFSUPPLIER_AGBPOSTALADDRESS',pic:''},{av:'AV36TFSupplier_AgbPostalAddress_Sel',fld:'vTFSUPPLIER_AGBPOSTALADDRESS_SEL',pic:''},{av:'AV37TFSupplier_AgbEmail',fld:'vTFSUPPLIER_AGBEMAIL',pic:''},{av:'AV38TFSupplier_AgbEmail_Sel',fld:'vTFSUPPLIER_AGBEMAIL_SEL',pic:''},{av:'AV39TFSupplier_AgbPhone',fld:'vTFSUPPLIER_AGBPHONE',pic:''},{av:'AV40TFSupplier_AgbPhone_Sel',fld:'vTFSUPPLIER_AGBPHONE_SEL',pic:''},{av:'AV41TFSupplier_AgbContactName',fld:'vTFSUPPLIER_AGBCONTACTNAME',pic:''},{av:'AV42TFSupplier_AgbContactName_Sel',fld:'vTFSUPPLIER_AGBCONTACTNAME_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV51IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV53IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV54IsAuthorized_Supplier_AgbNumber',fld:'vISAUTHORIZED_SUPPLIER_AGBNUMBER',pic:'',hsh:true},{av:'AV55IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV24ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV25TFSupplier_AgbId',fld:'vTFSUPPLIER_AGBID',pic:'ZZZ9'},{av:'AV26TFSupplier_AgbId_To',fld:'vTFSUPPLIER_AGBID_TO',pic:'ZZZ9'},{av:'AV27TFSupplier_AgbNumber',fld:'vTFSUPPLIER_AGBNUMBER',pic:''},{av:'AV28TFSupplier_AgbNumber_Sel',fld:'vTFSUPPLIER_AGBNUMBER_SEL',pic:''},{av:'AV29TFSupplier_AgbName',fld:'vTFSUPPLIER_AGBNAME',pic:''},{av:'AV30TFSupplier_AgbName_Sel',fld:'vTFSUPPLIER_AGBNAME_SEL',pic:''},{av:'AV31TFSupplier_AgbKvkNumber',fld:'vTFSUPPLIER_AGBKVKNUMBER',pic:''},{av:'AV32TFSupplier_AgbKvkNumber_Sel',fld:'vTFSUPPLIER_AGBKVKNUMBER_SEL',pic:''},{av:'AV33TFSupplier_AgbVisitingAddress',fld:'vTFSUPPLIER_AGBVISITINGADDRESS',pic:''},{av:'AV34TFSupplier_AgbVisitingAddress_Sel',fld:'vTFSUPPLIER_AGBVISITINGADDRESS_SEL',pic:''},{av:'AV35TFSupplier_AgbPostalAddress',fld:'vTFSUPPLIER_AGBPOSTALADDRESS',pic:''},{av:'AV36TFSupplier_AgbPostalAddress_Sel',fld:'vTFSUPPLIER_AGBPOSTALADDRESS_SEL',pic:''},{av:'AV37TFSupplier_AgbEmail',fld:'vTFSUPPLIER_AGBEMAIL',pic:''},{av:'AV38TFSupplier_AgbEmail_Sel',fld:'vTFSUPPLIER_AGBEMAIL_SEL',pic:''},{av:'AV39TFSupplier_AgbPhone',fld:'vTFSUPPLIER_AGBPHONE',pic:''},{av:'AV40TFSupplier_AgbPhone_Sel',fld:'vTFSUPPLIER_AGBPHONE_SEL',pic:''},{av:'AV41TFSupplier_AgbContactName',fld:'vTFSUPPLIER_AGBCONTACTNAME',pic:''},{av:'AV42TFSupplier_AgbContactName_Sel',fld:'vTFSUPPLIER_AGBCONTACTNAME_SEL',pic:''},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV19ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtSupplier_AgbId_Visible',ctrl:'SUPPLIER_AGBID',prop:'Visible'},{av:'edtSupplier_AgbNumber_Visible',ctrl:'SUPPLIER_AGBNUMBER',prop:'Visible'},{av:'edtSupplier_AgbName_Visible',ctrl:'SUPPLIER_AGBNAME',prop:'Visible'},{av:'edtSupplier_AgbKvkNumber_Visible',ctrl:'SUPPLIER_AGBKVKNUMBER',prop:'Visible'},{av:'edtSupplier_AgbVisitingAddress_Visible',ctrl:'SUPPLIER_AGBVISITINGADDRESS',prop:'Visible'},{av:'edtSupplier_AgbPostalAddress_Visible',ctrl:'SUPPLIER_AGBPOSTALADDRESS',prop:'Visible'},{av:'edtSupplier_AgbEmail_Visible',ctrl:'SUPPLIER_AGBEMAIL',prop:'Visible'},{av:'edtSupplier_AgbPhone_Visible',ctrl:'SUPPLIER_AGBPHONE',prop:'Visible'},{av:'edtSupplier_AgbContactName_Visible',ctrl:'SUPPLIER_AGBCONTACTNAME',prop:'Visible'},{av:'AV47GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV48GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV49GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV51IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV53IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV55IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV22ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("'DOINSERT'","{handler:'E161L2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV24ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV19ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV56Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV25TFSupplier_AgbId',fld:'vTFSUPPLIER_AGBID',pic:'ZZZ9'},{av:'AV26TFSupplier_AgbId_To',fld:'vTFSUPPLIER_AGBID_TO',pic:'ZZZ9'},{av:'AV27TFSupplier_AgbNumber',fld:'vTFSUPPLIER_AGBNUMBER',pic:''},{av:'AV28TFSupplier_AgbNumber_Sel',fld:'vTFSUPPLIER_AGBNUMBER_SEL',pic:''},{av:'AV29TFSupplier_AgbName',fld:'vTFSUPPLIER_AGBNAME',pic:''},{av:'AV30TFSupplier_AgbName_Sel',fld:'vTFSUPPLIER_AGBNAME_SEL',pic:''},{av:'AV31TFSupplier_AgbKvkNumber',fld:'vTFSUPPLIER_AGBKVKNUMBER',pic:''},{av:'AV32TFSupplier_AgbKvkNumber_Sel',fld:'vTFSUPPLIER_AGBKVKNUMBER_SEL',pic:''},{av:'AV33TFSupplier_AgbVisitingAddress',fld:'vTFSUPPLIER_AGBVISITINGADDRESS',pic:''},{av:'AV34TFSupplier_AgbVisitingAddress_Sel',fld:'vTFSUPPLIER_AGBVISITINGADDRESS_SEL',pic:''},{av:'AV35TFSupplier_AgbPostalAddress',fld:'vTFSUPPLIER_AGBPOSTALADDRESS',pic:''},{av:'AV36TFSupplier_AgbPostalAddress_Sel',fld:'vTFSUPPLIER_AGBPOSTALADDRESS_SEL',pic:''},{av:'AV37TFSupplier_AgbEmail',fld:'vTFSUPPLIER_AGBEMAIL',pic:''},{av:'AV38TFSupplier_AgbEmail_Sel',fld:'vTFSUPPLIER_AGBEMAIL_SEL',pic:''},{av:'AV39TFSupplier_AgbPhone',fld:'vTFSUPPLIER_AGBPHONE',pic:''},{av:'AV40TFSupplier_AgbPhone_Sel',fld:'vTFSUPPLIER_AGBPHONE_SEL',pic:''},{av:'AV41TFSupplier_AgbContactName',fld:'vTFSUPPLIER_AGBCONTACTNAME',pic:''},{av:'AV42TFSupplier_AgbContactName_Sel',fld:'vTFSUPPLIER_AGBCONTACTNAME_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV51IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV53IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV54IsAuthorized_Supplier_AgbNumber',fld:'vISAUTHORIZED_SUPPLIER_AGBNUMBER',pic:'',hsh:true},{av:'AV55IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'A55Supplier_AgbId',fld:'SUPPLIER_AGBID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("'DOINSERT'",",oparms:[{av:'AV24ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV19ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtSupplier_AgbId_Visible',ctrl:'SUPPLIER_AGBID',prop:'Visible'},{av:'edtSupplier_AgbNumber_Visible',ctrl:'SUPPLIER_AGBNUMBER',prop:'Visible'},{av:'edtSupplier_AgbName_Visible',ctrl:'SUPPLIER_AGBNAME',prop:'Visible'},{av:'edtSupplier_AgbKvkNumber_Visible',ctrl:'SUPPLIER_AGBKVKNUMBER',prop:'Visible'},{av:'edtSupplier_AgbVisitingAddress_Visible',ctrl:'SUPPLIER_AGBVISITINGADDRESS',prop:'Visible'},{av:'edtSupplier_AgbPostalAddress_Visible',ctrl:'SUPPLIER_AGBPOSTALADDRESS',prop:'Visible'},{av:'edtSupplier_AgbEmail_Visible',ctrl:'SUPPLIER_AGBEMAIL',prop:'Visible'},{av:'edtSupplier_AgbPhone_Visible',ctrl:'SUPPLIER_AGBPHONE',prop:'Visible'},{av:'edtSupplier_AgbContactName_Visible',ctrl:'SUPPLIER_AGBCONTACTNAME',prop:'Visible'},{av:'AV47GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV48GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV49GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV51IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV53IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV55IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV22ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("NULL","{handler:'Validv_Delete',iparms:[]");
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
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Filteredtextto_get = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV16FilterFullText = "";
         AV19ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV56Pgmname = "";
         AV27TFSupplier_AgbNumber = "";
         AV28TFSupplier_AgbNumber_Sel = "";
         AV29TFSupplier_AgbName = "";
         AV30TFSupplier_AgbName_Sel = "";
         AV31TFSupplier_AgbKvkNumber = "";
         AV32TFSupplier_AgbKvkNumber_Sel = "";
         AV33TFSupplier_AgbVisitingAddress = "";
         AV34TFSupplier_AgbVisitingAddress_Sel = "";
         AV35TFSupplier_AgbPostalAddress = "";
         AV36TFSupplier_AgbPostalAddress_Sel = "";
         AV37TFSupplier_AgbEmail = "";
         AV38TFSupplier_AgbEmail_Sel = "";
         AV39TFSupplier_AgbPhone = "";
         AV40TFSupplier_AgbPhone_Sel = "";
         AV41TFSupplier_AgbContactName = "";
         AV42TFSupplier_AgbContactName_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV22ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV49GridAppliedFilters = "";
         AV43DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Gamoauthtoken = "";
         Ddo_grid_Sortedstatus = "";
         Ddo_gridcolumnsselector_Gridinternalname = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtninsert_Jsonclick = "";
         bttBtneditcolumns_Jsonclick = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A56Supplier_AgbNumber = "";
         A57Supplier_AgbName = "";
         A58Supplier_AgbKvkNumber = "";
         A59Supplier_AgbVisitingAddress = "";
         A60Supplier_AgbPostalAddress = "";
         A61Supplier_AgbEmail = "";
         A62Supplier_AgbPhone = "";
         A63Supplier_AgbContactName = "";
         AV50Update = "";
         AV52Delete = "";
         scmdbuf = "";
         lV57Supplier_agbwwds_1_filterfulltext = "";
         lV60Supplier_agbwwds_4_tfsupplier_agbnumber = "";
         lV62Supplier_agbwwds_6_tfsupplier_agbname = "";
         lV64Supplier_agbwwds_8_tfsupplier_agbkvknumber = "";
         lV66Supplier_agbwwds_10_tfsupplier_agbvisitingaddress = "";
         lV68Supplier_agbwwds_12_tfsupplier_agbpostaladdress = "";
         lV70Supplier_agbwwds_14_tfsupplier_agbemail = "";
         lV72Supplier_agbwwds_16_tfsupplier_agbphone = "";
         lV74Supplier_agbwwds_18_tfsupplier_agbcontactname = "";
         AV57Supplier_agbwwds_1_filterfulltext = "";
         AV61Supplier_agbwwds_5_tfsupplier_agbnumber_sel = "";
         AV60Supplier_agbwwds_4_tfsupplier_agbnumber = "";
         AV63Supplier_agbwwds_7_tfsupplier_agbname_sel = "";
         AV62Supplier_agbwwds_6_tfsupplier_agbname = "";
         AV65Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel = "";
         AV64Supplier_agbwwds_8_tfsupplier_agbkvknumber = "";
         AV67Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel = "";
         AV66Supplier_agbwwds_10_tfsupplier_agbvisitingaddress = "";
         AV69Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel = "";
         AV68Supplier_agbwwds_12_tfsupplier_agbpostaladdress = "";
         AV71Supplier_agbwwds_15_tfsupplier_agbemail_sel = "";
         AV70Supplier_agbwwds_14_tfsupplier_agbemail = "";
         AV73Supplier_agbwwds_17_tfsupplier_agbphone_sel = "";
         AV72Supplier_agbwwds_16_tfsupplier_agbphone = "";
         AV75Supplier_agbwwds_19_tfsupplier_agbcontactname_sel = "";
         AV74Supplier_agbwwds_18_tfsupplier_agbcontactname = "";
         H001L2_A63Supplier_AgbContactName = new string[] {""} ;
         H001L2_n63Supplier_AgbContactName = new bool[] {false} ;
         H001L2_A62Supplier_AgbPhone = new string[] {""} ;
         H001L2_n62Supplier_AgbPhone = new bool[] {false} ;
         H001L2_A61Supplier_AgbEmail = new string[] {""} ;
         H001L2_n61Supplier_AgbEmail = new bool[] {false} ;
         H001L2_A60Supplier_AgbPostalAddress = new string[] {""} ;
         H001L2_n60Supplier_AgbPostalAddress = new bool[] {false} ;
         H001L2_A59Supplier_AgbVisitingAddress = new string[] {""} ;
         H001L2_n59Supplier_AgbVisitingAddress = new bool[] {false} ;
         H001L2_A58Supplier_AgbKvkNumber = new string[] {""} ;
         H001L2_A57Supplier_AgbName = new string[] {""} ;
         H001L2_A56Supplier_AgbNumber = new string[] {""} ;
         H001L2_A55Supplier_AgbId = new short[1] ;
         H001L3_AGRID_nRecordCount = new long[1] ;
         AV8HTTPRequest = new GxHttpRequest( context);
         AV44GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV45GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV21Session = context.GetSession();
         AV17ColumnsSelectorXML = "";
         GridRow = new GXWebRow();
         AV23ManageFiltersXml = "";
         AV18UserCustomValue = "";
         AV20ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char11 = "";
         GXt_char10 = "";
         GXt_char9 = "";
         GXt_char8 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         GXt_char3 = "";
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         gxphoneLink = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.supplier_agbww__default(),
            new Object[][] {
                new Object[] {
               H001L2_A63Supplier_AgbContactName, H001L2_n63Supplier_AgbContactName, H001L2_A62Supplier_AgbPhone, H001L2_n62Supplier_AgbPhone, H001L2_A61Supplier_AgbEmail, H001L2_n61Supplier_AgbEmail, H001L2_A60Supplier_AgbPostalAddress, H001L2_n60Supplier_AgbPostalAddress, H001L2_A59Supplier_AgbVisitingAddress, H001L2_n59Supplier_AgbVisitingAddress,
               H001L2_A58Supplier_AgbKvkNumber, H001L2_A57Supplier_AgbName, H001L2_A56Supplier_AgbNumber, H001L2_A55Supplier_AgbId
               }
               , new Object[] {
               H001L3_AGRID_nRecordCount
               }
            }
         );
         AV56Pgmname = "Supplier_AgbWW";
         /* GeneXus formulas. */
         AV56Pgmname = "Supplier_AgbWW";
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV24ManageFiltersExecutionStep ;
      private short AV25TFSupplier_AgbId ;
      private short AV26TFSupplier_AgbId_To ;
      private short AV13OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A55Supplier_AgbId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV58Supplier_agbwwds_2_tfsupplier_agbid ;
      private short AV59Supplier_agbwwds_3_tfsupplier_agbid_to ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_37 ;
      private int nGXsfl_37_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtninsert_Visible ;
      private int edtavFilterfulltext_Enabled ;
      private int subGrid_Islastpage ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtSupplier_AgbId_Enabled ;
      private int edtSupplier_AgbNumber_Enabled ;
      private int edtSupplier_AgbName_Enabled ;
      private int edtSupplier_AgbKvkNumber_Enabled ;
      private int edtSupplier_AgbVisitingAddress_Enabled ;
      private int edtSupplier_AgbPostalAddress_Enabled ;
      private int edtSupplier_AgbEmail_Enabled ;
      private int edtSupplier_AgbPhone_Enabled ;
      private int edtSupplier_AgbContactName_Enabled ;
      private int edtSupplier_AgbId_Visible ;
      private int edtSupplier_AgbNumber_Visible ;
      private int edtSupplier_AgbName_Visible ;
      private int edtSupplier_AgbKvkNumber_Visible ;
      private int edtSupplier_AgbVisitingAddress_Visible ;
      private int edtSupplier_AgbPostalAddress_Visible ;
      private int edtSupplier_AgbEmail_Visible ;
      private int edtSupplier_AgbPhone_Visible ;
      private int edtSupplier_AgbContactName_Visible ;
      private int AV46PageToGo ;
      private int edtavUpdate_Visible ;
      private int edtavDelete_Visible ;
      private int AV76GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV47GridCurrentPage ;
      private long AV48GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_37_idx="0001" ;
      private string AV56Pgmname ;
      private string AV39TFSupplier_AgbPhone ;
      private string AV40TFSupplier_AgbPhone_Sel ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Ddo_managefilters_Icontype ;
      private string Ddo_managefilters_Icon ;
      private string Ddo_managefilters_Tooltip ;
      private string Ddo_managefilters_Cls ;
      private string Gridpaginationbar_Class ;
      private string Gridpaginationbar_Pagingbuttonsposition ;
      private string Gridpaginationbar_Pagingcaptionposition ;
      private string Gridpaginationbar_Emptygridclass ;
      private string Gridpaginationbar_Rowsperpageoptions ;
      private string Gridpaginationbar_Previous ;
      private string Gridpaginationbar_Next ;
      private string Gridpaginationbar_Caption ;
      private string Gridpaginationbar_Emptygridcaption ;
      private string Gridpaginationbar_Rowsperpagecaption ;
      private string Ddo_grid_Caption ;
      private string Ddo_grid_Filteredtext_set ;
      private string Ddo_grid_Filteredtextto_set ;
      private string Ddo_grid_Selectedvalue_set ;
      private string Ddo_grid_Gamoauthtoken ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Fixable ;
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_grid_Includefilter ;
      private string Ddo_grid_Filtertype ;
      private string Ddo_grid_Filterisrange ;
      private string Ddo_grid_Includedatalist ;
      private string Ddo_grid_Datalisttype ;
      private string Ddo_grid_Datalistproc ;
      private string Ddo_grid_Format ;
      private string Ddo_gridcolumnsselector_Icontype ;
      private string Ddo_gridcolumnsselector_Icon ;
      private string Ddo_gridcolumnsselector_Caption ;
      private string Ddo_gridcolumnsselector_Tooltip ;
      private string Ddo_gridcolumnsselector_Cls ;
      private string Ddo_gridcolumnsselector_Dropdownoptionstype ;
      private string Ddo_gridcolumnsselector_Gridinternalname ;
      private string Ddo_gridcolumnsselector_Titlecontrolidtoreplace ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
      private string bttBtneditcolumns_Internalname ;
      private string bttBtneditcolumns_Jsonclick ;
      private string divTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string divTablefilters_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Ddo_gridcolumnsselector_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtSupplier_AgbId_Internalname ;
      private string edtSupplier_AgbNumber_Internalname ;
      private string edtSupplier_AgbName_Internalname ;
      private string edtSupplier_AgbKvkNumber_Internalname ;
      private string edtSupplier_AgbVisitingAddress_Internalname ;
      private string edtSupplier_AgbPostalAddress_Internalname ;
      private string edtSupplier_AgbEmail_Internalname ;
      private string A62Supplier_AgbPhone ;
      private string edtSupplier_AgbPhone_Internalname ;
      private string edtSupplier_AgbContactName_Internalname ;
      private string AV50Update ;
      private string edtavUpdate_Internalname ;
      private string AV52Delete ;
      private string edtavDelete_Internalname ;
      private string scmdbuf ;
      private string lV72Supplier_agbwwds_16_tfsupplier_agbphone ;
      private string AV73Supplier_agbwwds_17_tfsupplier_agbphone_sel ;
      private string AV72Supplier_agbwwds_16_tfsupplier_agbphone ;
      private string edtavUpdate_Link ;
      private string edtavDelete_Link ;
      private string edtSupplier_AgbNumber_Link ;
      private string GXt_char11 ;
      private string GXt_char10 ;
      private string GXt_char9 ;
      private string GXt_char8 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char3 ;
      private string sGXsfl_37_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtSupplier_AgbId_Jsonclick ;
      private string edtSupplier_AgbNumber_Jsonclick ;
      private string edtSupplier_AgbName_Jsonclick ;
      private string edtSupplier_AgbKvkNumber_Jsonclick ;
      private string edtSupplier_AgbVisitingAddress_Jsonclick ;
      private string edtSupplier_AgbPostalAddress_Jsonclick ;
      private string edtSupplier_AgbEmail_Jsonclick ;
      private string gxphoneLink ;
      private string edtSupplier_AgbPhone_Jsonclick ;
      private string edtSupplier_AgbContactName_Jsonclick ;
      private string edtavUpdate_Jsonclick ;
      private string edtavDelete_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV51IsAuthorized_Update ;
      private bool AV53IsAuthorized_Delete ;
      private bool AV54IsAuthorized_Supplier_AgbNumber ;
      private bool AV55IsAuthorized_Insert ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n59Supplier_AgbVisitingAddress ;
      private bool n60Supplier_AgbPostalAddress ;
      private bool n61Supplier_AgbEmail ;
      private bool n62Supplier_AgbPhone ;
      private bool n63Supplier_AgbContactName ;
      private bool bGXsfl_37_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool GXt_boolean1 ;
      private string AV17ColumnsSelectorXML ;
      private string AV23ManageFiltersXml ;
      private string AV18UserCustomValue ;
      private string AV16FilterFullText ;
      private string AV27TFSupplier_AgbNumber ;
      private string AV28TFSupplier_AgbNumber_Sel ;
      private string AV29TFSupplier_AgbName ;
      private string AV30TFSupplier_AgbName_Sel ;
      private string AV31TFSupplier_AgbKvkNumber ;
      private string AV32TFSupplier_AgbKvkNumber_Sel ;
      private string AV33TFSupplier_AgbVisitingAddress ;
      private string AV34TFSupplier_AgbVisitingAddress_Sel ;
      private string AV35TFSupplier_AgbPostalAddress ;
      private string AV36TFSupplier_AgbPostalAddress_Sel ;
      private string AV37TFSupplier_AgbEmail ;
      private string AV38TFSupplier_AgbEmail_Sel ;
      private string AV41TFSupplier_AgbContactName ;
      private string AV42TFSupplier_AgbContactName_Sel ;
      private string AV49GridAppliedFilters ;
      private string A56Supplier_AgbNumber ;
      private string A57Supplier_AgbName ;
      private string A58Supplier_AgbKvkNumber ;
      private string A59Supplier_AgbVisitingAddress ;
      private string A60Supplier_AgbPostalAddress ;
      private string A61Supplier_AgbEmail ;
      private string A63Supplier_AgbContactName ;
      private string lV57Supplier_agbwwds_1_filterfulltext ;
      private string lV60Supplier_agbwwds_4_tfsupplier_agbnumber ;
      private string lV62Supplier_agbwwds_6_tfsupplier_agbname ;
      private string lV64Supplier_agbwwds_8_tfsupplier_agbkvknumber ;
      private string lV66Supplier_agbwwds_10_tfsupplier_agbvisitingaddress ;
      private string lV68Supplier_agbwwds_12_tfsupplier_agbpostaladdress ;
      private string lV70Supplier_agbwwds_14_tfsupplier_agbemail ;
      private string lV74Supplier_agbwwds_18_tfsupplier_agbcontactname ;
      private string AV57Supplier_agbwwds_1_filterfulltext ;
      private string AV61Supplier_agbwwds_5_tfsupplier_agbnumber_sel ;
      private string AV60Supplier_agbwwds_4_tfsupplier_agbnumber ;
      private string AV63Supplier_agbwwds_7_tfsupplier_agbname_sel ;
      private string AV62Supplier_agbwwds_6_tfsupplier_agbname ;
      private string AV65Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel ;
      private string AV64Supplier_agbwwds_8_tfsupplier_agbkvknumber ;
      private string AV67Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel ;
      private string AV66Supplier_agbwwds_10_tfsupplier_agbvisitingaddress ;
      private string AV69Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel ;
      private string AV68Supplier_agbwwds_12_tfsupplier_agbpostaladdress ;
      private string AV71Supplier_agbwwds_15_tfsupplier_agbemail_sel ;
      private string AV70Supplier_agbwwds_14_tfsupplier_agbemail ;
      private string AV75Supplier_agbwwds_19_tfsupplier_agbcontactname_sel ;
      private string AV74Supplier_agbwwds_18_tfsupplier_agbcontactname ;
      private IGxSession AV21Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] H001L2_A63Supplier_AgbContactName ;
      private bool[] H001L2_n63Supplier_AgbContactName ;
      private string[] H001L2_A62Supplier_AgbPhone ;
      private bool[] H001L2_n62Supplier_AgbPhone ;
      private string[] H001L2_A61Supplier_AgbEmail ;
      private bool[] H001L2_n61Supplier_AgbEmail ;
      private string[] H001L2_A60Supplier_AgbPostalAddress ;
      private bool[] H001L2_n60Supplier_AgbPostalAddress ;
      private string[] H001L2_A59Supplier_AgbVisitingAddress ;
      private bool[] H001L2_n59Supplier_AgbVisitingAddress ;
      private string[] H001L2_A58Supplier_AgbKvkNumber ;
      private string[] H001L2_A57Supplier_AgbName ;
      private string[] H001L2_A56Supplier_AgbNumber ;
      private short[] H001L2_A55Supplier_AgbId ;
      private long[] H001L3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV22ManageFiltersData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV45GAMErrors ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV19ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV20ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV43DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV44GAMSession ;
   }

   public class supplier_agbww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H001L2( IGxContext context ,
                                             string AV57Supplier_agbwwds_1_filterfulltext ,
                                             short AV58Supplier_agbwwds_2_tfsupplier_agbid ,
                                             short AV59Supplier_agbwwds_3_tfsupplier_agbid_to ,
                                             string AV61Supplier_agbwwds_5_tfsupplier_agbnumber_sel ,
                                             string AV60Supplier_agbwwds_4_tfsupplier_agbnumber ,
                                             string AV63Supplier_agbwwds_7_tfsupplier_agbname_sel ,
                                             string AV62Supplier_agbwwds_6_tfsupplier_agbname ,
                                             string AV65Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel ,
                                             string AV64Supplier_agbwwds_8_tfsupplier_agbkvknumber ,
                                             string AV67Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel ,
                                             string AV66Supplier_agbwwds_10_tfsupplier_agbvisitingaddress ,
                                             string AV69Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel ,
                                             string AV68Supplier_agbwwds_12_tfsupplier_agbpostaladdress ,
                                             string AV71Supplier_agbwwds_15_tfsupplier_agbemail_sel ,
                                             string AV70Supplier_agbwwds_14_tfsupplier_agbemail ,
                                             string AV73Supplier_agbwwds_17_tfsupplier_agbphone_sel ,
                                             string AV72Supplier_agbwwds_16_tfsupplier_agbphone ,
                                             string AV75Supplier_agbwwds_19_tfsupplier_agbcontactname_sel ,
                                             string AV74Supplier_agbwwds_18_tfsupplier_agbcontactname ,
                                             short A55Supplier_AgbId ,
                                             string A56Supplier_AgbNumber ,
                                             string A57Supplier_AgbName ,
                                             string A58Supplier_AgbKvkNumber ,
                                             string A59Supplier_AgbVisitingAddress ,
                                             string A60Supplier_AgbPostalAddress ,
                                             string A61Supplier_AgbEmail ,
                                             string A62Supplier_AgbPhone ,
                                             string A63Supplier_AgbContactName ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int12 = new short[30];
         Object[] GXv_Object13 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " Supplier_AgbContactName, Supplier_AgbPhone, Supplier_AgbEmail, Supplier_AgbPostalAddress, Supplier_AgbVisitingAddress, Supplier_AgbKvkNumber, Supplier_AgbName, Supplier_AgbNumber, Supplier_AgbId";
         sFromString = " FROM Supplier_AGB";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Supplier_agbwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(Supplier_AgbId,'9999'), 2) like '%' || :lV57Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbNumber like '%' || :lV57Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbName like '%' || :lV57Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbKvkNumber like '%' || :lV57Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbVisitingAddress like '%' || :lV57Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbPostalAddress like '%' || :lV57Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbEmail like '%' || :lV57Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbPhone like '%' || :lV57Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbContactName like '%' || :lV57Supplier_agbwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int12[0] = 1;
            GXv_int12[1] = 1;
            GXv_int12[2] = 1;
            GXv_int12[3] = 1;
            GXv_int12[4] = 1;
            GXv_int12[5] = 1;
            GXv_int12[6] = 1;
            GXv_int12[7] = 1;
            GXv_int12[8] = 1;
         }
         if ( ! (0==AV58Supplier_agbwwds_2_tfsupplier_agbid) )
         {
            AddWhere(sWhereString, "(Supplier_AgbId >= :AV58Supplier_agbwwds_2_tfsupplier_agbid)");
         }
         else
         {
            GXv_int12[9] = 1;
         }
         if ( ! (0==AV59Supplier_agbwwds_3_tfsupplier_agbid_to) )
         {
            AddWhere(sWhereString, "(Supplier_AgbId <= :AV59Supplier_agbwwds_3_tfsupplier_agbid_to)");
         }
         else
         {
            GXv_int12[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Supplier_agbwwds_5_tfsupplier_agbnumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Supplier_agbwwds_4_tfsupplier_agbnumber)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbNumber like :lV60Supplier_agbwwds_4_tfsupplier_agbnumber)");
         }
         else
         {
            GXv_int12[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Supplier_agbwwds_5_tfsupplier_agbnumber_sel)) && ! ( StringUtil.StrCmp(AV61Supplier_agbwwds_5_tfsupplier_agbnumber_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbNumber = ( :AV61Supplier_agbwwds_5_tfsupplier_agbnumber_sel))");
         }
         else
         {
            GXv_int12[12] = 1;
         }
         if ( StringUtil.StrCmp(AV61Supplier_agbwwds_5_tfsupplier_agbnumber_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Supplier_AgbNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Supplier_agbwwds_7_tfsupplier_agbname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Supplier_agbwwds_6_tfsupplier_agbname)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbName like :lV62Supplier_agbwwds_6_tfsupplier_agbname)");
         }
         else
         {
            GXv_int12[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Supplier_agbwwds_7_tfsupplier_agbname_sel)) && ! ( StringUtil.StrCmp(AV63Supplier_agbwwds_7_tfsupplier_agbname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbName = ( :AV63Supplier_agbwwds_7_tfsupplier_agbname_sel))");
         }
         else
         {
            GXv_int12[14] = 1;
         }
         if ( StringUtil.StrCmp(AV63Supplier_agbwwds_7_tfsupplier_agbname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Supplier_AgbName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Supplier_agbwwds_8_tfsupplier_agbkvknumber)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbKvkNumber like :lV64Supplier_agbwwds_8_tfsupplier_agbkvknumber)");
         }
         else
         {
            GXv_int12[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel)) && ! ( StringUtil.StrCmp(AV65Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbKvkNumber = ( :AV65Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel))");
         }
         else
         {
            GXv_int12[16] = 1;
         }
         if ( StringUtil.StrCmp(AV65Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Supplier_AgbKvkNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Supplier_agbwwds_10_tfsupplier_agbvisitingaddress)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress like :lV66Supplier_agbwwds_10_tfsupplier_agbvisitingaddress)");
         }
         else
         {
            GXv_int12[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel)) && ! ( StringUtil.StrCmp(AV67Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress = ( :AV67Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel))");
         }
         else
         {
            GXv_int12[18] = 1;
         }
         if ( StringUtil.StrCmp(AV67Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbVisitingAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Supplier_agbwwds_12_tfsupplier_agbpostaladdress)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress like :lV68Supplier_agbwwds_12_tfsupplier_agbpostaladdress)");
         }
         else
         {
            GXv_int12[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel)) && ! ( StringUtil.StrCmp(AV69Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress = ( :AV69Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel))");
         }
         else
         {
            GXv_int12[20] = 1;
         }
         if ( StringUtil.StrCmp(AV69Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbPostalAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Supplier_agbwwds_15_tfsupplier_agbemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Supplier_agbwwds_14_tfsupplier_agbemail)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail like :lV70Supplier_agbwwds_14_tfsupplier_agbemail)");
         }
         else
         {
            GXv_int12[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Supplier_agbwwds_15_tfsupplier_agbemail_sel)) && ! ( StringUtil.StrCmp(AV71Supplier_agbwwds_15_tfsupplier_agbemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail = ( :AV71Supplier_agbwwds_15_tfsupplier_agbemail_sel))");
         }
         else
         {
            GXv_int12[22] = 1;
         }
         if ( StringUtil.StrCmp(AV71Supplier_agbwwds_15_tfsupplier_agbemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Supplier_agbwwds_17_tfsupplier_agbphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Supplier_agbwwds_16_tfsupplier_agbphone)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone like :lV72Supplier_agbwwds_16_tfsupplier_agbphone)");
         }
         else
         {
            GXv_int12[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Supplier_agbwwds_17_tfsupplier_agbphone_sel)) && ! ( StringUtil.StrCmp(AV73Supplier_agbwwds_17_tfsupplier_agbphone_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone = ( :AV73Supplier_agbwwds_17_tfsupplier_agbphone_sel))");
         }
         else
         {
            GXv_int12[24] = 1;
         }
         if ( StringUtil.StrCmp(AV73Supplier_agbwwds_17_tfsupplier_agbphone_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Supplier_agbwwds_19_tfsupplier_agbcontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Supplier_agbwwds_18_tfsupplier_agbcontactname)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName like :lV74Supplier_agbwwds_18_tfsupplier_agbcontactname)");
         }
         else
         {
            GXv_int12[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Supplier_agbwwds_19_tfsupplier_agbcontactname_sel)) && ! ( StringUtil.StrCmp(AV75Supplier_agbwwds_19_tfsupplier_agbcontactname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName = ( :AV75Supplier_agbwwds_19_tfsupplier_agbcontactname_sel))");
         }
         else
         {
            GXv_int12[26] = 1;
         }
         if ( StringUtil.StrCmp(AV75Supplier_agbwwds_19_tfsupplier_agbcontactname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbContactName))=0))");
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY Supplier_AgbNumber, Supplier_AgbId";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY Supplier_AgbNumber DESC, Supplier_AgbId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY Supplier_AgbId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY Supplier_AgbId DESC";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY Supplier_AgbName, Supplier_AgbId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY Supplier_AgbName DESC, Supplier_AgbId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY Supplier_AgbKvkNumber, Supplier_AgbId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY Supplier_AgbKvkNumber DESC, Supplier_AgbId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY Supplier_AgbVisitingAddress, Supplier_AgbId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY Supplier_AgbVisitingAddress DESC, Supplier_AgbId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY Supplier_AgbPostalAddress, Supplier_AgbId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY Supplier_AgbPostalAddress DESC, Supplier_AgbId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY Supplier_AgbEmail, Supplier_AgbId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY Supplier_AgbEmail DESC, Supplier_AgbId";
         }
         else if ( ( AV13OrderedBy == 8 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY Supplier_AgbPhone, Supplier_AgbId";
         }
         else if ( ( AV13OrderedBy == 8 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY Supplier_AgbPhone DESC, Supplier_AgbId";
         }
         else if ( ( AV13OrderedBy == 9 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY Supplier_AgbContactName, Supplier_AgbId";
         }
         else if ( ( AV13OrderedBy == 9 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY Supplier_AgbContactName DESC, Supplier_AgbId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY Supplier_AgbId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object13[0] = scmdbuf;
         GXv_Object13[1] = GXv_int12;
         return GXv_Object13 ;
      }

      protected Object[] conditional_H001L3( IGxContext context ,
                                             string AV57Supplier_agbwwds_1_filterfulltext ,
                                             short AV58Supplier_agbwwds_2_tfsupplier_agbid ,
                                             short AV59Supplier_agbwwds_3_tfsupplier_agbid_to ,
                                             string AV61Supplier_agbwwds_5_tfsupplier_agbnumber_sel ,
                                             string AV60Supplier_agbwwds_4_tfsupplier_agbnumber ,
                                             string AV63Supplier_agbwwds_7_tfsupplier_agbname_sel ,
                                             string AV62Supplier_agbwwds_6_tfsupplier_agbname ,
                                             string AV65Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel ,
                                             string AV64Supplier_agbwwds_8_tfsupplier_agbkvknumber ,
                                             string AV67Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel ,
                                             string AV66Supplier_agbwwds_10_tfsupplier_agbvisitingaddress ,
                                             string AV69Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel ,
                                             string AV68Supplier_agbwwds_12_tfsupplier_agbpostaladdress ,
                                             string AV71Supplier_agbwwds_15_tfsupplier_agbemail_sel ,
                                             string AV70Supplier_agbwwds_14_tfsupplier_agbemail ,
                                             string AV73Supplier_agbwwds_17_tfsupplier_agbphone_sel ,
                                             string AV72Supplier_agbwwds_16_tfsupplier_agbphone ,
                                             string AV75Supplier_agbwwds_19_tfsupplier_agbcontactname_sel ,
                                             string AV74Supplier_agbwwds_18_tfsupplier_agbcontactname ,
                                             short A55Supplier_AgbId ,
                                             string A56Supplier_AgbNumber ,
                                             string A57Supplier_AgbName ,
                                             string A58Supplier_AgbKvkNumber ,
                                             string A59Supplier_AgbVisitingAddress ,
                                             string A60Supplier_AgbPostalAddress ,
                                             string A61Supplier_AgbEmail ,
                                             string A62Supplier_AgbPhone ,
                                             string A63Supplier_AgbContactName ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int14 = new short[27];
         Object[] GXv_Object15 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM Supplier_AGB";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Supplier_agbwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(Supplier_AgbId,'9999'), 2) like '%' || :lV57Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbNumber like '%' || :lV57Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbName like '%' || :lV57Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbKvkNumber like '%' || :lV57Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbVisitingAddress like '%' || :lV57Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbPostalAddress like '%' || :lV57Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbEmail like '%' || :lV57Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbPhone like '%' || :lV57Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbContactName like '%' || :lV57Supplier_agbwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int14[0] = 1;
            GXv_int14[1] = 1;
            GXv_int14[2] = 1;
            GXv_int14[3] = 1;
            GXv_int14[4] = 1;
            GXv_int14[5] = 1;
            GXv_int14[6] = 1;
            GXv_int14[7] = 1;
            GXv_int14[8] = 1;
         }
         if ( ! (0==AV58Supplier_agbwwds_2_tfsupplier_agbid) )
         {
            AddWhere(sWhereString, "(Supplier_AgbId >= :AV58Supplier_agbwwds_2_tfsupplier_agbid)");
         }
         else
         {
            GXv_int14[9] = 1;
         }
         if ( ! (0==AV59Supplier_agbwwds_3_tfsupplier_agbid_to) )
         {
            AddWhere(sWhereString, "(Supplier_AgbId <= :AV59Supplier_agbwwds_3_tfsupplier_agbid_to)");
         }
         else
         {
            GXv_int14[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Supplier_agbwwds_5_tfsupplier_agbnumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Supplier_agbwwds_4_tfsupplier_agbnumber)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbNumber like :lV60Supplier_agbwwds_4_tfsupplier_agbnumber)");
         }
         else
         {
            GXv_int14[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Supplier_agbwwds_5_tfsupplier_agbnumber_sel)) && ! ( StringUtil.StrCmp(AV61Supplier_agbwwds_5_tfsupplier_agbnumber_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbNumber = ( :AV61Supplier_agbwwds_5_tfsupplier_agbnumber_sel))");
         }
         else
         {
            GXv_int14[12] = 1;
         }
         if ( StringUtil.StrCmp(AV61Supplier_agbwwds_5_tfsupplier_agbnumber_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Supplier_AgbNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Supplier_agbwwds_7_tfsupplier_agbname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Supplier_agbwwds_6_tfsupplier_agbname)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbName like :lV62Supplier_agbwwds_6_tfsupplier_agbname)");
         }
         else
         {
            GXv_int14[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Supplier_agbwwds_7_tfsupplier_agbname_sel)) && ! ( StringUtil.StrCmp(AV63Supplier_agbwwds_7_tfsupplier_agbname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbName = ( :AV63Supplier_agbwwds_7_tfsupplier_agbname_sel))");
         }
         else
         {
            GXv_int14[14] = 1;
         }
         if ( StringUtil.StrCmp(AV63Supplier_agbwwds_7_tfsupplier_agbname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Supplier_AgbName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Supplier_agbwwds_8_tfsupplier_agbkvknumber)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbKvkNumber like :lV64Supplier_agbwwds_8_tfsupplier_agbkvknumber)");
         }
         else
         {
            GXv_int14[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel)) && ! ( StringUtil.StrCmp(AV65Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbKvkNumber = ( :AV65Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel))");
         }
         else
         {
            GXv_int14[16] = 1;
         }
         if ( StringUtil.StrCmp(AV65Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Supplier_AgbKvkNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Supplier_agbwwds_10_tfsupplier_agbvisitingaddress)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress like :lV66Supplier_agbwwds_10_tfsupplier_agbvisitingaddress)");
         }
         else
         {
            GXv_int14[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel)) && ! ( StringUtil.StrCmp(AV67Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress = ( :AV67Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel))");
         }
         else
         {
            GXv_int14[18] = 1;
         }
         if ( StringUtil.StrCmp(AV67Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbVisitingAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Supplier_agbwwds_12_tfsupplier_agbpostaladdress)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress like :lV68Supplier_agbwwds_12_tfsupplier_agbpostaladdress)");
         }
         else
         {
            GXv_int14[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel)) && ! ( StringUtil.StrCmp(AV69Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress = ( :AV69Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel))");
         }
         else
         {
            GXv_int14[20] = 1;
         }
         if ( StringUtil.StrCmp(AV69Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbPostalAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Supplier_agbwwds_15_tfsupplier_agbemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Supplier_agbwwds_14_tfsupplier_agbemail)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail like :lV70Supplier_agbwwds_14_tfsupplier_agbemail)");
         }
         else
         {
            GXv_int14[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Supplier_agbwwds_15_tfsupplier_agbemail_sel)) && ! ( StringUtil.StrCmp(AV71Supplier_agbwwds_15_tfsupplier_agbemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail = ( :AV71Supplier_agbwwds_15_tfsupplier_agbemail_sel))");
         }
         else
         {
            GXv_int14[22] = 1;
         }
         if ( StringUtil.StrCmp(AV71Supplier_agbwwds_15_tfsupplier_agbemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Supplier_agbwwds_17_tfsupplier_agbphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Supplier_agbwwds_16_tfsupplier_agbphone)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone like :lV72Supplier_agbwwds_16_tfsupplier_agbphone)");
         }
         else
         {
            GXv_int14[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Supplier_agbwwds_17_tfsupplier_agbphone_sel)) && ! ( StringUtil.StrCmp(AV73Supplier_agbwwds_17_tfsupplier_agbphone_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone = ( :AV73Supplier_agbwwds_17_tfsupplier_agbphone_sel))");
         }
         else
         {
            GXv_int14[24] = 1;
         }
         if ( StringUtil.StrCmp(AV73Supplier_agbwwds_17_tfsupplier_agbphone_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Supplier_agbwwds_19_tfsupplier_agbcontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Supplier_agbwwds_18_tfsupplier_agbcontactname)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName like :lV74Supplier_agbwwds_18_tfsupplier_agbcontactname)");
         }
         else
         {
            GXv_int14[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Supplier_agbwwds_19_tfsupplier_agbcontactname_sel)) && ! ( StringUtil.StrCmp(AV75Supplier_agbwwds_19_tfsupplier_agbcontactname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName = ( :AV75Supplier_agbwwds_19_tfsupplier_agbcontactname_sel))");
         }
         else
         {
            GXv_int14[26] = 1;
         }
         if ( StringUtil.StrCmp(AV75Supplier_agbwwds_19_tfsupplier_agbcontactname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbContactName))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 8 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 8 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 9 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 9 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object15[0] = scmdbuf;
         GXv_Object15[1] = GXv_int14;
         return GXv_Object15 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H001L2(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (short)dynConstraints[28] , (bool)dynConstraints[29] );
               case 1 :
                     return conditional_H001L3(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (short)dynConstraints[28] , (bool)dynConstraints[29] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmH001L2;
          prmH001L2 = new Object[] {
          new ParDef("lV57Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV58Supplier_agbwwds_2_tfsupplier_agbid",GXType.Int16,4,0) ,
          new ParDef("AV59Supplier_agbwwds_3_tfsupplier_agbid_to",GXType.Int16,4,0) ,
          new ParDef("lV60Supplier_agbwwds_4_tfsupplier_agbnumber",GXType.VarChar,10,0) ,
          new ParDef("AV61Supplier_agbwwds_5_tfsupplier_agbnumber_sel",GXType.VarChar,10,0) ,
          new ParDef("lV62Supplier_agbwwds_6_tfsupplier_agbname",GXType.VarChar,40,0) ,
          new ParDef("AV63Supplier_agbwwds_7_tfsupplier_agbname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV64Supplier_agbwwds_8_tfsupplier_agbkvknumber",GXType.VarChar,8,0) ,
          new ParDef("AV65Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel",GXType.VarChar,8,0) ,
          new ParDef("lV66Supplier_agbwwds_10_tfsupplier_agbvisitingaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV67Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV68Supplier_agbwwds_12_tfsupplier_agbpostaladdress",GXType.VarChar,1024,0) ,
          new ParDef("AV69Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV70Supplier_agbwwds_14_tfsupplier_agbemail",GXType.VarChar,100,0) ,
          new ParDef("AV71Supplier_agbwwds_15_tfsupplier_agbemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV72Supplier_agbwwds_16_tfsupplier_agbphone",GXType.Char,20,0) ,
          new ParDef("AV73Supplier_agbwwds_17_tfsupplier_agbphone_sel",GXType.Char,20,0) ,
          new ParDef("lV74Supplier_agbwwds_18_tfsupplier_agbcontactname",GXType.VarChar,40,0) ,
          new ParDef("AV75Supplier_agbwwds_19_tfsupplier_agbcontactname_sel",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH001L3;
          prmH001L3 = new Object[] {
          new ParDef("lV57Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV58Supplier_agbwwds_2_tfsupplier_agbid",GXType.Int16,4,0) ,
          new ParDef("AV59Supplier_agbwwds_3_tfsupplier_agbid_to",GXType.Int16,4,0) ,
          new ParDef("lV60Supplier_agbwwds_4_tfsupplier_agbnumber",GXType.VarChar,10,0) ,
          new ParDef("AV61Supplier_agbwwds_5_tfsupplier_agbnumber_sel",GXType.VarChar,10,0) ,
          new ParDef("lV62Supplier_agbwwds_6_tfsupplier_agbname",GXType.VarChar,40,0) ,
          new ParDef("AV63Supplier_agbwwds_7_tfsupplier_agbname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV64Supplier_agbwwds_8_tfsupplier_agbkvknumber",GXType.VarChar,8,0) ,
          new ParDef("AV65Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel",GXType.VarChar,8,0) ,
          new ParDef("lV66Supplier_agbwwds_10_tfsupplier_agbvisitingaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV67Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV68Supplier_agbwwds_12_tfsupplier_agbpostaladdress",GXType.VarChar,1024,0) ,
          new ParDef("AV69Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV70Supplier_agbwwds_14_tfsupplier_agbemail",GXType.VarChar,100,0) ,
          new ParDef("AV71Supplier_agbwwds_15_tfsupplier_agbemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV72Supplier_agbwwds_16_tfsupplier_agbphone",GXType.Char,20,0) ,
          new ParDef("AV73Supplier_agbwwds_17_tfsupplier_agbphone_sel",GXType.Char,20,0) ,
          new ParDef("lV74Supplier_agbwwds_18_tfsupplier_agbcontactname",GXType.VarChar,40,0) ,
          new ParDef("AV75Supplier_agbwwds_19_tfsupplier_agbcontactname_sel",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("H001L2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001L2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H001L3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001L3,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 20);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((string[]) buf[12])[0] = rslt.getVarchar(8);
                ((short[]) buf[13])[0] = rslt.getShort(9);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
