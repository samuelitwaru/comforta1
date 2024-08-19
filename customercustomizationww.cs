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
   public class customercustomizationww : GXDataArea
   {
      public customercustomizationww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public customercustomizationww( IGxContext context )
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
         AV49Pgmname = GetPar( "Pgmname");
         AV25TFCustomerCustomizationId = (short)(Math.Round(NumberUtil.Val( GetPar( "TFCustomerCustomizationId"), "."), 18, MidpointRounding.ToEven));
         AV26TFCustomerCustomizationId_To = (short)(Math.Round(NumberUtil.Val( GetPar( "TFCustomerCustomizationId_To"), "."), 18, MidpointRounding.ToEven));
         AV27TFCustomerCustomizationBaseColor = GetPar( "TFCustomerCustomizationBaseColor");
         AV28TFCustomerCustomizationBaseColor_Sel = GetPar( "TFCustomerCustomizationBaseColor_Sel");
         AV29TFCustomerCustomizationFontSize = GetPar( "TFCustomerCustomizationFontSize");
         AV48TFCustomerCustomizationFontSize_Sel = GetPar( "TFCustomerCustomizationFontSize_Sel");
         AV31TFCustomerId = (short)(Math.Round(NumberUtil.Val( GetPar( "TFCustomerId"), "."), 18, MidpointRounding.ToEven));
         AV32TFCustomerId_To = (short)(Math.Round(NumberUtil.Val( GetPar( "TFCustomerId_To"), "."), 18, MidpointRounding.ToEven));
         AV33TFCustomerName = GetPar( "TFCustomerName");
         AV34TFCustomerName_Sel = GetPar( "TFCustomerName_Sel");
         AV13OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV14OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV43IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV45IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV46IsAuthorized_CustomerCustomizationBaseColor = StringUtil.StrToBool( GetPar( "IsAuthorized_CustomerCustomizationBaseColor"));
         AV47IsAuthorized_Insert = StringUtil.StrToBool( GetPar( "IsAuthorized_Insert"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV49Pgmname, AV25TFCustomerCustomizationId, AV26TFCustomerCustomizationId_To, AV27TFCustomerCustomizationBaseColor, AV28TFCustomerCustomizationBaseColor_Sel, AV29TFCustomerCustomizationFontSize, AV48TFCustomerCustomizationFontSize_Sel, AV31TFCustomerId, AV32TFCustomerId_To, AV33TFCustomerName, AV34TFCustomerName_Sel, AV13OrderedBy, AV14OrderedDsc, AV43IsAuthorized_Update, AV45IsAuthorized_Delete, AV46IsAuthorized_CustomerCustomizationBaseColor, AV47IsAuthorized_Insert) ;
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
            return "customercustomizationww_Execute" ;
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
         PA3J2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3J2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("customercustomizationww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV49Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV49Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV43IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV43IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV45IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV45IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_CUSTOMERCUSTOMIZATIONBASECOLOR", AV46IsAuthorized_CustomerCustomizationBaseColor);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_CUSTOMERCUSTOMIZATIONBASECOLOR", GetSecureSignedToken( "", AV46IsAuthorized_CustomerCustomizationBaseColor, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV47IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV47IsAuthorized_Insert, context));
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
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV41GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV35DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV35DDO_TitleSettingsIcons);
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV49Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV49Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFCUSTOMERCUSTOMIZATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25TFCustomerCustomizationId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFCUSTOMERCUSTOMIZATIONID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26TFCustomerCustomizationId_To), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFCUSTOMERCUSTOMIZATIONBASECOLOR", AV27TFCustomerCustomizationBaseColor);
         GxWebStd.gx_hidden_field( context, "vTFCUSTOMERCUSTOMIZATIONBASECOLOR_SEL", AV28TFCustomerCustomizationBaseColor_Sel);
         GxWebStd.gx_hidden_field( context, "vTFCUSTOMERCUSTOMIZATIONFONTSIZE", AV29TFCustomerCustomizationFontSize);
         GxWebStd.gx_hidden_field( context, "vTFCUSTOMERCUSTOMIZATIONFONTSIZE_SEL", AV48TFCustomerCustomizationFontSize_Sel);
         GxWebStd.gx_hidden_field( context, "vTFCUSTOMERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31TFCustomerId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFCUSTOMERID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32TFCustomerId_To), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFCUSTOMERNAME", AV33TFCustomerName);
         GxWebStd.gx_hidden_field( context, "vTFCUSTOMERNAME_SEL", AV34TFCustomerName_Sel);
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV43IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV43IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV45IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV45IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_CUSTOMERCUSTOMIZATIONBASECOLOR", AV46IsAuthorized_CustomerCustomizationBaseColor);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_CUSTOMERCUSTOMIZATIONBASECOLOR", GetSecureSignedToken( "", AV46IsAuthorized_CustomerCustomizationBaseColor, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV47IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV47IsAuthorized_Insert, context));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
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
            WE3J2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3J2( ) ;
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
         return formatLink("customercustomizationww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CustomerCustomizationWW" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( " Customer Customization", "") ;
      }

      protected void WB3J0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", context.GetMessage( "GXM_insert", ""), bttBtninsert_Jsonclick, 5, context.GetMessage( "GXM_insert", ""), "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_CustomerCustomizationWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_CustomerCustomizationWW.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV16FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV16FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_CustomerCustomizationWW.htm");
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV39GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV40GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV41GridAppliedFilters);
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV35DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV35DDO_TitleSettingsIcons);
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

      protected void START3J2( )
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
         Form.Meta.addItem("description", context.GetMessage( " Customer Customization", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3J0( ) ;
      }

      protected void WS3J2( )
      {
         START3J2( ) ;
         EVT3J2( ) ;
      }

      protected void EVT3J2( )
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
                              E113J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E123J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E133J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E143J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E153J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E163J2 ();
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
                              A128CustomerCustomizationId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCustomerCustomizationId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A129CustomerCustomizationLogo = cgiGet( edtCustomerCustomizationLogo_Internalname);
                              AssignProp("", false, edtCustomerCustomizationLogo_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A129CustomerCustomizationLogo)) ? A40000CustomerCustomizationLogo_GXI : context.convertURL( context.PathToRelativeUrl( A129CustomerCustomizationLogo))), !bGXsfl_37_Refreshing);
                              AssignProp("", false, edtCustomerCustomizationLogo_Internalname, "SrcSet", context.GetImageSrcSet( A129CustomerCustomizationLogo), true);
                              A130CustomerCustomizationFavicon = cgiGet( edtCustomerCustomizationFavicon_Internalname);
                              AssignProp("", false, edtCustomerCustomizationFavicon_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A130CustomerCustomizationFavicon)) ? A40001CustomerCustomizationFavicon_G : context.convertURL( context.PathToRelativeUrl( A130CustomerCustomizationFavicon))), !bGXsfl_37_Refreshing);
                              AssignProp("", false, edtCustomerCustomizationFavicon_Internalname, "SrcSet", context.GetImageSrcSet( A130CustomerCustomizationFavicon), true);
                              A131CustomerCustomizationBaseColor = cgiGet( edtCustomerCustomizationBaseColor_Internalname);
                              A132CustomerCustomizationFontSize = cgiGet( edtCustomerCustomizationFontSize_Internalname);
                              A1CustomerId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCustomerId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A3CustomerName = cgiGet( edtCustomerName_Internalname);
                              AV42Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV42Update);
                              AV44Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri("", false, edtavDelete_Internalname, AV44Delete);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E173J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E183J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E193J2 ();
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

      protected void WE3J2( )
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

      protected void PA3J2( )
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
                                       string AV49Pgmname ,
                                       short AV25TFCustomerCustomizationId ,
                                       short AV26TFCustomerCustomizationId_To ,
                                       string AV27TFCustomerCustomizationBaseColor ,
                                       string AV28TFCustomerCustomizationBaseColor_Sel ,
                                       string AV29TFCustomerCustomizationFontSize ,
                                       string AV48TFCustomerCustomizationFontSize_Sel ,
                                       short AV31TFCustomerId ,
                                       short AV32TFCustomerId_To ,
                                       string AV33TFCustomerName ,
                                       string AV34TFCustomerName_Sel ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       bool AV43IsAuthorized_Update ,
                                       bool AV45IsAuthorized_Delete ,
                                       bool AV46IsAuthorized_CustomerCustomizationBaseColor ,
                                       bool AV47IsAuthorized_Insert )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF3J2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CUSTOMERCUSTOMIZATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A128CustomerCustomizationId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "CUSTOMERCUSTOMIZATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A128CustomerCustomizationId), 4, 0, ".", "")));
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
         RF3J2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV49Pgmname = "CustomerCustomizationWW";
         edtavUpdate_Enabled = 0;
         AssignProp("", false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         edtavDelete_Enabled = 0;
         AssignProp("", false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_37_Refreshing);
      }

      protected void RF3J2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 37;
         /* Execute user event: Refresh */
         E183J2 ();
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
                                                 AV50Customercustomizationwwds_1_filterfulltext ,
                                                 AV51Customercustomizationwwds_2_tfcustomercustomizationid ,
                                                 AV52Customercustomizationwwds_3_tfcustomercustomizationid_to ,
                                                 AV54Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel ,
                                                 AV53Customercustomizationwwds_4_tfcustomercustomizationbasecolor ,
                                                 AV56Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel ,
                                                 AV55Customercustomizationwwds_6_tfcustomercustomizationfontsize ,
                                                 AV57Customercustomizationwwds_8_tfcustomerid ,
                                                 AV58Customercustomizationwwds_9_tfcustomerid_to ,
                                                 AV60Customercustomizationwwds_11_tfcustomername_sel ,
                                                 AV59Customercustomizationwwds_10_tfcustomername ,
                                                 A128CustomerCustomizationId ,
                                                 A131CustomerCustomizationBaseColor ,
                                                 A132CustomerCustomizationFontSize ,
                                                 A1CustomerId ,
                                                 A3CustomerName ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV50Customercustomizationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Customercustomizationwwds_1_filterfulltext), "%", "");
            lV50Customercustomizationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Customercustomizationwwds_1_filterfulltext), "%", "");
            lV50Customercustomizationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Customercustomizationwwds_1_filterfulltext), "%", "");
            lV50Customercustomizationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Customercustomizationwwds_1_filterfulltext), "%", "");
            lV50Customercustomizationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Customercustomizationwwds_1_filterfulltext), "%", "");
            lV53Customercustomizationwwds_4_tfcustomercustomizationbasecolor = StringUtil.Concat( StringUtil.RTrim( AV53Customercustomizationwwds_4_tfcustomercustomizationbasecolor), "%", "");
            lV55Customercustomizationwwds_6_tfcustomercustomizationfontsize = StringUtil.Concat( StringUtil.RTrim( AV55Customercustomizationwwds_6_tfcustomercustomizationfontsize), "%", "");
            lV59Customercustomizationwwds_10_tfcustomername = StringUtil.Concat( StringUtil.RTrim( AV59Customercustomizationwwds_10_tfcustomername), "%", "");
            /* Using cursor H003J2 */
            pr_default.execute(0, new Object[] {lV50Customercustomizationwwds_1_filterfulltext, lV50Customercustomizationwwds_1_filterfulltext, lV50Customercustomizationwwds_1_filterfulltext, lV50Customercustomizationwwds_1_filterfulltext, lV50Customercustomizationwwds_1_filterfulltext, AV51Customercustomizationwwds_2_tfcustomercustomizationid, AV52Customercustomizationwwds_3_tfcustomercustomizationid_to, lV53Customercustomizationwwds_4_tfcustomercustomizationbasecolor, AV54Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel, lV55Customercustomizationwwds_6_tfcustomercustomizationfontsize, AV56Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel, AV57Customercustomizationwwds_8_tfcustomerid, AV58Customercustomizationwwds_9_tfcustomerid_to, lV59Customercustomizationwwds_10_tfcustomername, AV60Customercustomizationwwds_11_tfcustomername_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_37_idx = 1;
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A3CustomerName = H003J2_A3CustomerName[0];
               A1CustomerId = H003J2_A1CustomerId[0];
               A132CustomerCustomizationFontSize = H003J2_A132CustomerCustomizationFontSize[0];
               A131CustomerCustomizationBaseColor = H003J2_A131CustomerCustomizationBaseColor[0];
               A40001CustomerCustomizationFavicon_G = H003J2_A40001CustomerCustomizationFavicon_G[0];
               AssignProp("", false, edtCustomerCustomizationFavicon_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A130CustomerCustomizationFavicon)) ? A40001CustomerCustomizationFavicon_G : context.convertURL( context.PathToRelativeUrl( A130CustomerCustomizationFavicon))), !bGXsfl_37_Refreshing);
               AssignProp("", false, edtCustomerCustomizationFavicon_Internalname, "SrcSet", context.GetImageSrcSet( A130CustomerCustomizationFavicon), true);
               A40000CustomerCustomizationLogo_GXI = H003J2_A40000CustomerCustomizationLogo_GXI[0];
               AssignProp("", false, edtCustomerCustomizationLogo_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A129CustomerCustomizationLogo)) ? A40000CustomerCustomizationLogo_GXI : context.convertURL( context.PathToRelativeUrl( A129CustomerCustomizationLogo))), !bGXsfl_37_Refreshing);
               AssignProp("", false, edtCustomerCustomizationLogo_Internalname, "SrcSet", context.GetImageSrcSet( A129CustomerCustomizationLogo), true);
               A128CustomerCustomizationId = H003J2_A128CustomerCustomizationId[0];
               A130CustomerCustomizationFavicon = H003J2_A130CustomerCustomizationFavicon[0];
               AssignProp("", false, edtCustomerCustomizationFavicon_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A130CustomerCustomizationFavicon)) ? A40001CustomerCustomizationFavicon_G : context.convertURL( context.PathToRelativeUrl( A130CustomerCustomizationFavicon))), !bGXsfl_37_Refreshing);
               AssignProp("", false, edtCustomerCustomizationFavicon_Internalname, "SrcSet", context.GetImageSrcSet( A130CustomerCustomizationFavicon), true);
               A129CustomerCustomizationLogo = H003J2_A129CustomerCustomizationLogo[0];
               AssignProp("", false, edtCustomerCustomizationLogo_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A129CustomerCustomizationLogo)) ? A40000CustomerCustomizationLogo_GXI : context.convertURL( context.PathToRelativeUrl( A129CustomerCustomizationLogo))), !bGXsfl_37_Refreshing);
               AssignProp("", false, edtCustomerCustomizationLogo_Internalname, "SrcSet", context.GetImageSrcSet( A129CustomerCustomizationLogo), true);
               A3CustomerName = H003J2_A3CustomerName[0];
               E193J2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 37;
            WB3J0( ) ;
         }
         bGXsfl_37_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3J2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV49Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV49Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV43IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV43IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV45IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV45IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_CUSTOMERCUSTOMIZATIONBASECOLOR", AV46IsAuthorized_CustomerCustomizationBaseColor);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_CUSTOMERCUSTOMIZATIONBASECOLOR", GetSecureSignedToken( "", AV46IsAuthorized_CustomerCustomizationBaseColor, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV47IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV47IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "gxhash_CUSTOMERCUSTOMIZATIONID"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, context.localUtil.Format( (decimal)(A128CustomerCustomizationId), "ZZZ9"), context));
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
         AV50Customercustomizationwwds_1_filterfulltext = AV16FilterFullText;
         AV51Customercustomizationwwds_2_tfcustomercustomizationid = AV25TFCustomerCustomizationId;
         AV52Customercustomizationwwds_3_tfcustomercustomizationid_to = AV26TFCustomerCustomizationId_To;
         AV53Customercustomizationwwds_4_tfcustomercustomizationbasecolor = AV27TFCustomerCustomizationBaseColor;
         AV54Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel = AV28TFCustomerCustomizationBaseColor_Sel;
         AV55Customercustomizationwwds_6_tfcustomercustomizationfontsize = AV29TFCustomerCustomizationFontSize;
         AV56Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel = AV48TFCustomerCustomizationFontSize_Sel;
         AV57Customercustomizationwwds_8_tfcustomerid = AV31TFCustomerId;
         AV58Customercustomizationwwds_9_tfcustomerid_to = AV32TFCustomerId_To;
         AV59Customercustomizationwwds_10_tfcustomername = AV33TFCustomerName;
         AV60Customercustomizationwwds_11_tfcustomername_sel = AV34TFCustomerName_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV50Customercustomizationwwds_1_filterfulltext ,
                                              AV51Customercustomizationwwds_2_tfcustomercustomizationid ,
                                              AV52Customercustomizationwwds_3_tfcustomercustomizationid_to ,
                                              AV54Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel ,
                                              AV53Customercustomizationwwds_4_tfcustomercustomizationbasecolor ,
                                              AV56Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel ,
                                              AV55Customercustomizationwwds_6_tfcustomercustomizationfontsize ,
                                              AV57Customercustomizationwwds_8_tfcustomerid ,
                                              AV58Customercustomizationwwds_9_tfcustomerid_to ,
                                              AV60Customercustomizationwwds_11_tfcustomername_sel ,
                                              AV59Customercustomizationwwds_10_tfcustomername ,
                                              A128CustomerCustomizationId ,
                                              A131CustomerCustomizationBaseColor ,
                                              A132CustomerCustomizationFontSize ,
                                              A1CustomerId ,
                                              A3CustomerName ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV50Customercustomizationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Customercustomizationwwds_1_filterfulltext), "%", "");
         lV50Customercustomizationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Customercustomizationwwds_1_filterfulltext), "%", "");
         lV50Customercustomizationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Customercustomizationwwds_1_filterfulltext), "%", "");
         lV50Customercustomizationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Customercustomizationwwds_1_filterfulltext), "%", "");
         lV50Customercustomizationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Customercustomizationwwds_1_filterfulltext), "%", "");
         lV53Customercustomizationwwds_4_tfcustomercustomizationbasecolor = StringUtil.Concat( StringUtil.RTrim( AV53Customercustomizationwwds_4_tfcustomercustomizationbasecolor), "%", "");
         lV55Customercustomizationwwds_6_tfcustomercustomizationfontsize = StringUtil.Concat( StringUtil.RTrim( AV55Customercustomizationwwds_6_tfcustomercustomizationfontsize), "%", "");
         lV59Customercustomizationwwds_10_tfcustomername = StringUtil.Concat( StringUtil.RTrim( AV59Customercustomizationwwds_10_tfcustomername), "%", "");
         /* Using cursor H003J3 */
         pr_default.execute(1, new Object[] {lV50Customercustomizationwwds_1_filterfulltext, lV50Customercustomizationwwds_1_filterfulltext, lV50Customercustomizationwwds_1_filterfulltext, lV50Customercustomizationwwds_1_filterfulltext, lV50Customercustomizationwwds_1_filterfulltext, AV51Customercustomizationwwds_2_tfcustomercustomizationid, AV52Customercustomizationwwds_3_tfcustomercustomizationid_to, lV53Customercustomizationwwds_4_tfcustomercustomizationbasecolor, AV54Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel, lV55Customercustomizationwwds_6_tfcustomercustomizationfontsize, AV56Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel, AV57Customercustomizationwwds_8_tfcustomerid, AV58Customercustomizationwwds_9_tfcustomerid_to, lV59Customercustomizationwwds_10_tfcustomername, AV60Customercustomizationwwds_11_tfcustomername_sel});
         GRID_nRecordCount = H003J3_AGRID_nRecordCount[0];
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
         AV50Customercustomizationwwds_1_filterfulltext = AV16FilterFullText;
         AV51Customercustomizationwwds_2_tfcustomercustomizationid = AV25TFCustomerCustomizationId;
         AV52Customercustomizationwwds_3_tfcustomercustomizationid_to = AV26TFCustomerCustomizationId_To;
         AV53Customercustomizationwwds_4_tfcustomercustomizationbasecolor = AV27TFCustomerCustomizationBaseColor;
         AV54Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel = AV28TFCustomerCustomizationBaseColor_Sel;
         AV55Customercustomizationwwds_6_tfcustomercustomizationfontsize = AV29TFCustomerCustomizationFontSize;
         AV56Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel = AV48TFCustomerCustomizationFontSize_Sel;
         AV57Customercustomizationwwds_8_tfcustomerid = AV31TFCustomerId;
         AV58Customercustomizationwwds_9_tfcustomerid_to = AV32TFCustomerId_To;
         AV59Customercustomizationwwds_10_tfcustomername = AV33TFCustomerName;
         AV60Customercustomizationwwds_11_tfcustomername_sel = AV34TFCustomerName_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV49Pgmname, AV25TFCustomerCustomizationId, AV26TFCustomerCustomizationId_To, AV27TFCustomerCustomizationBaseColor, AV28TFCustomerCustomizationBaseColor_Sel, AV29TFCustomerCustomizationFontSize, AV48TFCustomerCustomizationFontSize_Sel, AV31TFCustomerId, AV32TFCustomerId_To, AV33TFCustomerName, AV34TFCustomerName_Sel, AV13OrderedBy, AV14OrderedDsc, AV43IsAuthorized_Update, AV45IsAuthorized_Delete, AV46IsAuthorized_CustomerCustomizationBaseColor, AV47IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV50Customercustomizationwwds_1_filterfulltext = AV16FilterFullText;
         AV51Customercustomizationwwds_2_tfcustomercustomizationid = AV25TFCustomerCustomizationId;
         AV52Customercustomizationwwds_3_tfcustomercustomizationid_to = AV26TFCustomerCustomizationId_To;
         AV53Customercustomizationwwds_4_tfcustomercustomizationbasecolor = AV27TFCustomerCustomizationBaseColor;
         AV54Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel = AV28TFCustomerCustomizationBaseColor_Sel;
         AV55Customercustomizationwwds_6_tfcustomercustomizationfontsize = AV29TFCustomerCustomizationFontSize;
         AV56Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel = AV48TFCustomerCustomizationFontSize_Sel;
         AV57Customercustomizationwwds_8_tfcustomerid = AV31TFCustomerId;
         AV58Customercustomizationwwds_9_tfcustomerid_to = AV32TFCustomerId_To;
         AV59Customercustomizationwwds_10_tfcustomername = AV33TFCustomerName;
         AV60Customercustomizationwwds_11_tfcustomername_sel = AV34TFCustomerName_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV49Pgmname, AV25TFCustomerCustomizationId, AV26TFCustomerCustomizationId_To, AV27TFCustomerCustomizationBaseColor, AV28TFCustomerCustomizationBaseColor_Sel, AV29TFCustomerCustomizationFontSize, AV48TFCustomerCustomizationFontSize_Sel, AV31TFCustomerId, AV32TFCustomerId_To, AV33TFCustomerName, AV34TFCustomerName_Sel, AV13OrderedBy, AV14OrderedDsc, AV43IsAuthorized_Update, AV45IsAuthorized_Delete, AV46IsAuthorized_CustomerCustomizationBaseColor, AV47IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV50Customercustomizationwwds_1_filterfulltext = AV16FilterFullText;
         AV51Customercustomizationwwds_2_tfcustomercustomizationid = AV25TFCustomerCustomizationId;
         AV52Customercustomizationwwds_3_tfcustomercustomizationid_to = AV26TFCustomerCustomizationId_To;
         AV53Customercustomizationwwds_4_tfcustomercustomizationbasecolor = AV27TFCustomerCustomizationBaseColor;
         AV54Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel = AV28TFCustomerCustomizationBaseColor_Sel;
         AV55Customercustomizationwwds_6_tfcustomercustomizationfontsize = AV29TFCustomerCustomizationFontSize;
         AV56Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel = AV48TFCustomerCustomizationFontSize_Sel;
         AV57Customercustomizationwwds_8_tfcustomerid = AV31TFCustomerId;
         AV58Customercustomizationwwds_9_tfcustomerid_to = AV32TFCustomerId_To;
         AV59Customercustomizationwwds_10_tfcustomername = AV33TFCustomerName;
         AV60Customercustomizationwwds_11_tfcustomername_sel = AV34TFCustomerName_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV49Pgmname, AV25TFCustomerCustomizationId, AV26TFCustomerCustomizationId_To, AV27TFCustomerCustomizationBaseColor, AV28TFCustomerCustomizationBaseColor_Sel, AV29TFCustomerCustomizationFontSize, AV48TFCustomerCustomizationFontSize_Sel, AV31TFCustomerId, AV32TFCustomerId_To, AV33TFCustomerName, AV34TFCustomerName_Sel, AV13OrderedBy, AV14OrderedDsc, AV43IsAuthorized_Update, AV45IsAuthorized_Delete, AV46IsAuthorized_CustomerCustomizationBaseColor, AV47IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV50Customercustomizationwwds_1_filterfulltext = AV16FilterFullText;
         AV51Customercustomizationwwds_2_tfcustomercustomizationid = AV25TFCustomerCustomizationId;
         AV52Customercustomizationwwds_3_tfcustomercustomizationid_to = AV26TFCustomerCustomizationId_To;
         AV53Customercustomizationwwds_4_tfcustomercustomizationbasecolor = AV27TFCustomerCustomizationBaseColor;
         AV54Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel = AV28TFCustomerCustomizationBaseColor_Sel;
         AV55Customercustomizationwwds_6_tfcustomercustomizationfontsize = AV29TFCustomerCustomizationFontSize;
         AV56Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel = AV48TFCustomerCustomizationFontSize_Sel;
         AV57Customercustomizationwwds_8_tfcustomerid = AV31TFCustomerId;
         AV58Customercustomizationwwds_9_tfcustomerid_to = AV32TFCustomerId_To;
         AV59Customercustomizationwwds_10_tfcustomername = AV33TFCustomerName;
         AV60Customercustomizationwwds_11_tfcustomername_sel = AV34TFCustomerName_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV49Pgmname, AV25TFCustomerCustomizationId, AV26TFCustomerCustomizationId_To, AV27TFCustomerCustomizationBaseColor, AV28TFCustomerCustomizationBaseColor_Sel, AV29TFCustomerCustomizationFontSize, AV48TFCustomerCustomizationFontSize_Sel, AV31TFCustomerId, AV32TFCustomerId_To, AV33TFCustomerName, AV34TFCustomerName_Sel, AV13OrderedBy, AV14OrderedDsc, AV43IsAuthorized_Update, AV45IsAuthorized_Delete, AV46IsAuthorized_CustomerCustomizationBaseColor, AV47IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV50Customercustomizationwwds_1_filterfulltext = AV16FilterFullText;
         AV51Customercustomizationwwds_2_tfcustomercustomizationid = AV25TFCustomerCustomizationId;
         AV52Customercustomizationwwds_3_tfcustomercustomizationid_to = AV26TFCustomerCustomizationId_To;
         AV53Customercustomizationwwds_4_tfcustomercustomizationbasecolor = AV27TFCustomerCustomizationBaseColor;
         AV54Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel = AV28TFCustomerCustomizationBaseColor_Sel;
         AV55Customercustomizationwwds_6_tfcustomercustomizationfontsize = AV29TFCustomerCustomizationFontSize;
         AV56Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel = AV48TFCustomerCustomizationFontSize_Sel;
         AV57Customercustomizationwwds_8_tfcustomerid = AV31TFCustomerId;
         AV58Customercustomizationwwds_9_tfcustomerid_to = AV32TFCustomerId_To;
         AV59Customercustomizationwwds_10_tfcustomername = AV33TFCustomerName;
         AV60Customercustomizationwwds_11_tfcustomername_sel = AV34TFCustomerName_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV49Pgmname, AV25TFCustomerCustomizationId, AV26TFCustomerCustomizationId_To, AV27TFCustomerCustomizationBaseColor, AV28TFCustomerCustomizationBaseColor_Sel, AV29TFCustomerCustomizationFontSize, AV48TFCustomerCustomizationFontSize_Sel, AV31TFCustomerId, AV32TFCustomerId_To, AV33TFCustomerName, AV34TFCustomerName_Sel, AV13OrderedBy, AV14OrderedDsc, AV43IsAuthorized_Update, AV45IsAuthorized_Delete, AV46IsAuthorized_CustomerCustomizationBaseColor, AV47IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV49Pgmname = "CustomerCustomizationWW";
         edtavUpdate_Enabled = 0;
         AssignProp("", false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         edtavDelete_Enabled = 0;
         AssignProp("", false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         edtCustomerCustomizationId_Enabled = 0;
         AssignProp("", false, edtCustomerCustomizationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerCustomizationId_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         edtCustomerCustomizationLogo_Enabled = 0;
         AssignProp("", false, edtCustomerCustomizationLogo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerCustomizationLogo_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         edtCustomerCustomizationFavicon_Enabled = 0;
         AssignProp("", false, edtCustomerCustomizationFavicon_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerCustomizationFavicon_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         edtCustomerCustomizationBaseColor_Enabled = 0;
         AssignProp("", false, edtCustomerCustomizationBaseColor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerCustomizationBaseColor_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         edtCustomerCustomizationFontSize_Enabled = 0;
         AssignProp("", false, edtCustomerCustomizationFontSize_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerCustomizationFontSize_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         edtCustomerId_Enabled = 0;
         AssignProp("", false, edtCustomerId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerId_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         edtCustomerName_Enabled = 0;
         AssignProp("", false, edtCustomerName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerName_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3J0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E173J2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV22ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV35DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV19ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_37 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_37"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV39GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV40GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV41GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
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
         E173J2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E173J2( )
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
         GXt_boolean1 = AV46IsAuthorized_CustomerCustomizationBaseColor;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "customercustomizationview_Execute", out  GXt_boolean1) ;
         AV46IsAuthorized_CustomerCustomizationBaseColor = GXt_boolean1;
         AssignAttri("", false, "AV46IsAuthorized_CustomerCustomizationBaseColor", AV46IsAuthorized_CustomerCustomizationBaseColor);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_CUSTOMERCUSTOMIZATIONBASECOLOR", GetSecureSignedToken( "", AV46IsAuthorized_CustomerCustomizationBaseColor, context));
         AV36GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV37GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV36GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = context.GetMessage( " Customer Customization", "");
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV35DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV35DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E183J2( )
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
         if ( StringUtil.StrCmp(AV21Session.Get("CustomerCustomizationWWColumnsSelector"), "") != 0 )
         {
            AV17ColumnsSelectorXML = AV21Session.Get("CustomerCustomizationWWColumnsSelector");
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
         edtCustomerCustomizationId_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCustomerCustomizationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCustomerCustomizationId_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtCustomerCustomizationLogo_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCustomerCustomizationLogo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCustomerCustomizationLogo_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtCustomerCustomizationFavicon_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCustomerCustomizationFavicon_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCustomerCustomizationFavicon_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtCustomerCustomizationBaseColor_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCustomerCustomizationBaseColor_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCustomerCustomizationBaseColor_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtCustomerCustomizationFontSize_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCustomerCustomizationFontSize_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCustomerCustomizationFontSize_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtCustomerId_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCustomerId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCustomerId_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtCustomerName_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(7)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCustomerName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCustomerName_Visible), 5, 0), !bGXsfl_37_Refreshing);
         AV39GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV39GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV39GridCurrentPage), 10, 0));
         AV40GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV40GridPageCount", StringUtil.LTrimStr( (decimal)(AV40GridPageCount), 10, 0));
         GXt_char3 = AV41GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV49Pgmname, out  GXt_char3) ;
         AV41GridAppliedFilters = GXt_char3;
         AssignAttri("", false, "AV41GridAppliedFilters", AV41GridAppliedFilters);
         AV50Customercustomizationwwds_1_filterfulltext = AV16FilterFullText;
         AV51Customercustomizationwwds_2_tfcustomercustomizationid = AV25TFCustomerCustomizationId;
         AV52Customercustomizationwwds_3_tfcustomercustomizationid_to = AV26TFCustomerCustomizationId_To;
         AV53Customercustomizationwwds_4_tfcustomercustomizationbasecolor = AV27TFCustomerCustomizationBaseColor;
         AV54Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel = AV28TFCustomerCustomizationBaseColor_Sel;
         AV55Customercustomizationwwds_6_tfcustomercustomizationfontsize = AV29TFCustomerCustomizationFontSize;
         AV56Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel = AV48TFCustomerCustomizationFontSize_Sel;
         AV57Customercustomizationwwds_8_tfcustomerid = AV31TFCustomerId;
         AV58Customercustomizationwwds_9_tfcustomerid_to = AV32TFCustomerId_To;
         AV59Customercustomizationwwds_10_tfcustomername = AV33TFCustomerName;
         AV60Customercustomizationwwds_11_tfcustomername_sel = AV34TFCustomerName_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ColumnsSelector", AV19ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ManageFiltersData", AV22ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E123J2( )
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
            AV38PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV38PageToGo) ;
         }
      }

      protected void E133J2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E143J2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CustomerCustomizationId") == 0 )
            {
               AV25TFCustomerCustomizationId = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV25TFCustomerCustomizationId", StringUtil.LTrimStr( (decimal)(AV25TFCustomerCustomizationId), 4, 0));
               AV26TFCustomerCustomizationId_To = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV26TFCustomerCustomizationId_To", StringUtil.LTrimStr( (decimal)(AV26TFCustomerCustomizationId_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CustomerCustomizationBaseColor") == 0 )
            {
               AV27TFCustomerCustomizationBaseColor = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV27TFCustomerCustomizationBaseColor", AV27TFCustomerCustomizationBaseColor);
               AV28TFCustomerCustomizationBaseColor_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV28TFCustomerCustomizationBaseColor_Sel", AV28TFCustomerCustomizationBaseColor_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CustomerCustomizationFontSize") == 0 )
            {
               AV29TFCustomerCustomizationFontSize = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV29TFCustomerCustomizationFontSize", AV29TFCustomerCustomizationFontSize);
               AV48TFCustomerCustomizationFontSize_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV48TFCustomerCustomizationFontSize_Sel", AV48TFCustomerCustomizationFontSize_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CustomerId") == 0 )
            {
               AV31TFCustomerId = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV31TFCustomerId", StringUtil.LTrimStr( (decimal)(AV31TFCustomerId), 4, 0));
               AV32TFCustomerId_To = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV32TFCustomerId_To", StringUtil.LTrimStr( (decimal)(AV32TFCustomerId_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CustomerName") == 0 )
            {
               AV33TFCustomerName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV33TFCustomerName", AV33TFCustomerName);
               AV34TFCustomerName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV34TFCustomerName_Sel", AV34TFCustomerName_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E193J2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV42Update = "<i class=\"fa fa-pen\"></i>";
         AssignAttri("", false, edtavUpdate_Internalname, AV42Update);
         if ( AV43IsAuthorized_Update )
         {
            edtavUpdate_Link = formatLink("customercustomization.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.LTrimStr(A128CustomerCustomizationId,4,0))}, new string[] {"Mode","CustomerCustomizationId"}) ;
         }
         AV44Delete = "<i class=\"fa fa-times\"></i>";
         AssignAttri("", false, edtavDelete_Internalname, AV44Delete);
         if ( AV45IsAuthorized_Delete )
         {
            edtavDelete_Link = formatLink("customercustomization.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.LTrimStr(A128CustomerCustomizationId,4,0))}, new string[] {"Mode","CustomerCustomizationId"}) ;
         }
         if ( AV46IsAuthorized_CustomerCustomizationBaseColor )
         {
            edtCustomerCustomizationBaseColor_Link = formatLink("customercustomizationview.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A128CustomerCustomizationId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"CustomerCustomizationId","TabCode"}) ;
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

      protected void E153J2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV17ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV19ColumnsSelector.FromJSonString(AV17ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "CustomerCustomizationWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV17ColumnsSelectorXML)) ? "" : AV19ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ColumnsSelector", AV19ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ManageFiltersData", AV22ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E113J2( )
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
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx", new object[] {UrlEncode(StringUtil.RTrim("CustomerCustomizationWWFilters")),UrlEncode(StringUtil.RTrim(AV49Pgmname+"GridState"))}, new string[] {"UserKey","GridStateKey"}) , new Object[] {});
            AV24ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV24ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV24ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx", new object[] {UrlEncode(StringUtil.RTrim("CustomerCustomizationWWFilters"))}, new string[] {"UserKey"}) , new Object[] {});
            AV24ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV24ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV24ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char3 = AV23ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "CustomerCustomizationWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV49Pgmname+"GridState",  AV23ManageFiltersXml) ;
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

      protected void E163J2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( AV47IsAuthorized_Insert )
         {
            CallWebObject(formatLink("customercustomization.aspx", new object[] {UrlEncode(StringUtil.RTrim("INS")),UrlEncode(StringUtil.LTrimStr(0,1,0))}, new string[] {"Mode","CustomerCustomizationId"}) );
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "CustomerCustomizationId",  "",  "Customization Id",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "CustomerCustomizationLogo",  "",  "Customization Logo",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "CustomerCustomizationFavicon",  "",  "Customization Favicon",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "CustomerCustomizationBaseColor",  "",  "Base Color",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "CustomerCustomizationFontSize",  "",  "Font Size",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "CustomerId",  "",  "Customer Id",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "CustomerName",  "",  "Customer Name",  true,  "") ;
         GXt_char3 = AV18UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "CustomerCustomizationWWColumnsSelector", out  GXt_char3) ;
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
         GXt_boolean1 = AV43IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "customercustomization_Update", out  GXt_boolean1) ;
         AV43IsAuthorized_Update = GXt_boolean1;
         AssignAttri("", false, "AV43IsAuthorized_Update", AV43IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV43IsAuthorized_Update, context));
         if ( ! ( AV43IsAuthorized_Update ) )
         {
            edtavUpdate_Visible = 0;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_37_Refreshing);
         }
         GXt_boolean1 = AV45IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "customercustomization_Delete", out  GXt_boolean1) ;
         AV45IsAuthorized_Delete = GXt_boolean1;
         AssignAttri("", false, "AV45IsAuthorized_Delete", AV45IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV45IsAuthorized_Delete, context));
         if ( ! ( AV45IsAuthorized_Delete ) )
         {
            edtavDelete_Visible = 0;
            AssignProp("", false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_37_Refreshing);
         }
         GXt_boolean1 = AV47IsAuthorized_Insert;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "customercustomization_Insert", out  GXt_boolean1) ;
         AV47IsAuthorized_Insert = GXt_boolean1;
         AssignAttri("", false, "AV47IsAuthorized_Insert", AV47IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV47IsAuthorized_Insert, context));
         if ( ! ( AV47IsAuthorized_Insert ) )
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
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "CustomerCustomizationWWFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV22ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S182( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV16FilterFullText = "";
         AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
         AV25TFCustomerCustomizationId = 0;
         AssignAttri("", false, "AV25TFCustomerCustomizationId", StringUtil.LTrimStr( (decimal)(AV25TFCustomerCustomizationId), 4, 0));
         AV26TFCustomerCustomizationId_To = 0;
         AssignAttri("", false, "AV26TFCustomerCustomizationId_To", StringUtil.LTrimStr( (decimal)(AV26TFCustomerCustomizationId_To), 4, 0));
         AV27TFCustomerCustomizationBaseColor = "";
         AssignAttri("", false, "AV27TFCustomerCustomizationBaseColor", AV27TFCustomerCustomizationBaseColor);
         AV28TFCustomerCustomizationBaseColor_Sel = "";
         AssignAttri("", false, "AV28TFCustomerCustomizationBaseColor_Sel", AV28TFCustomerCustomizationBaseColor_Sel);
         AV29TFCustomerCustomizationFontSize = "";
         AssignAttri("", false, "AV29TFCustomerCustomizationFontSize", AV29TFCustomerCustomizationFontSize);
         AV48TFCustomerCustomizationFontSize_Sel = "";
         AssignAttri("", false, "AV48TFCustomerCustomizationFontSize_Sel", AV48TFCustomerCustomizationFontSize_Sel);
         AV31TFCustomerId = 0;
         AssignAttri("", false, "AV31TFCustomerId", StringUtil.LTrimStr( (decimal)(AV31TFCustomerId), 4, 0));
         AV32TFCustomerId_To = 0;
         AssignAttri("", false, "AV32TFCustomerId_To", StringUtil.LTrimStr( (decimal)(AV32TFCustomerId_To), 4, 0));
         AV33TFCustomerName = "";
         AssignAttri("", false, "AV33TFCustomerName", AV33TFCustomerName);
         AV34TFCustomerName_Sel = "";
         AssignAttri("", false, "AV34TFCustomerName_Sel", AV34TFCustomerName_Sel);
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
         if ( StringUtil.StrCmp(AV21Session.Get(AV49Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV49Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV21Session.Get(AV49Pgmname+"GridState"), null, "", "");
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
         AV61GXV1 = 1;
         while ( AV61GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV61GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV16FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCUSTOMERCUSTOMIZATIONID") == 0 )
            {
               AV25TFCustomerCustomizationId = (short)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV25TFCustomerCustomizationId", StringUtil.LTrimStr( (decimal)(AV25TFCustomerCustomizationId), 4, 0));
               AV26TFCustomerCustomizationId_To = (short)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV26TFCustomerCustomizationId_To", StringUtil.LTrimStr( (decimal)(AV26TFCustomerCustomizationId_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCUSTOMERCUSTOMIZATIONBASECOLOR") == 0 )
            {
               AV27TFCustomerCustomizationBaseColor = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV27TFCustomerCustomizationBaseColor", AV27TFCustomerCustomizationBaseColor);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCUSTOMERCUSTOMIZATIONBASECOLOR_SEL") == 0 )
            {
               AV28TFCustomerCustomizationBaseColor_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV28TFCustomerCustomizationBaseColor_Sel", AV28TFCustomerCustomizationBaseColor_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCUSTOMERCUSTOMIZATIONFONTSIZE") == 0 )
            {
               AV29TFCustomerCustomizationFontSize = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV29TFCustomerCustomizationFontSize", AV29TFCustomerCustomizationFontSize);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCUSTOMERCUSTOMIZATIONFONTSIZE_SEL") == 0 )
            {
               AV48TFCustomerCustomizationFontSize_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV48TFCustomerCustomizationFontSize_Sel", AV48TFCustomerCustomizationFontSize_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCUSTOMERID") == 0 )
            {
               AV31TFCustomerId = (short)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV31TFCustomerId", StringUtil.LTrimStr( (decimal)(AV31TFCustomerId), 4, 0));
               AV32TFCustomerId_To = (short)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV32TFCustomerId_To", StringUtil.LTrimStr( (decimal)(AV32TFCustomerId_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCUSTOMERNAME") == 0 )
            {
               AV33TFCustomerName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV33TFCustomerName", AV33TFCustomerName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCUSTOMERNAME_SEL") == 0 )
            {
               AV34TFCustomerName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV34TFCustomerName_Sel", AV34TFCustomerName_Sel);
            }
            AV61GXV1 = (int)(AV61GXV1+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV28TFCustomerCustomizationBaseColor_Sel)),  AV28TFCustomerCustomizationBaseColor_Sel, out  GXt_char3) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV48TFCustomerCustomizationFontSize_Sel)),  AV48TFCustomerCustomizationFontSize_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV34TFCustomerName_Sel)),  AV34TFCustomerName_Sel, out  GXt_char6) ;
         Ddo_grid_Selectedvalue_set = "|||"+GXt_char3+"|"+GXt_char5+"||"+GXt_char6;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV27TFCustomerCustomizationBaseColor)),  AV27TFCustomerCustomizationBaseColor, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV29TFCustomerCustomizationFontSize)),  AV29TFCustomerCustomizationFontSize, out  GXt_char5) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV33TFCustomerName)),  AV33TFCustomerName, out  GXt_char3) ;
         Ddo_grid_Filteredtext_set = ((0==AV25TFCustomerCustomizationId) ? "" : StringUtil.Str( (decimal)(AV25TFCustomerCustomizationId), 4, 0))+"|||"+GXt_char6+"|"+GXt_char5+"|"+((0==AV31TFCustomerId) ? "" : StringUtil.Str( (decimal)(AV31TFCustomerId), 4, 0))+"|"+GXt_char3;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((0==AV26TFCustomerCustomizationId_To) ? "" : StringUtil.Str( (decimal)(AV26TFCustomerCustomizationId_To), 4, 0))+"|||||"+((0==AV32TFCustomerId_To) ? "" : StringUtil.Str( (decimal)(AV32TFCustomerId_To), 4, 0))+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV21Session.Get(AV49Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)),  0,  AV16FilterFullText,  AV16FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFCUSTOMERCUSTOMIZATIONID",  context.GetMessage( "Customization Id", ""),  !((0==AV25TFCustomerCustomizationId)&&(0==AV26TFCustomerCustomizationId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV25TFCustomerCustomizationId), 4, 0)),  ((0==AV25TFCustomerCustomizationId) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV25TFCustomerCustomizationId), "ZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV26TFCustomerCustomizationId_To), 4, 0)),  ((0==AV26TFCustomerCustomizationId_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV26TFCustomerCustomizationId_To), "ZZZ9")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFCUSTOMERCUSTOMIZATIONBASECOLOR",  context.GetMessage( "Base Color", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV27TFCustomerCustomizationBaseColor)),  0,  AV27TFCustomerCustomizationBaseColor,  AV27TFCustomerCustomizationBaseColor,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV28TFCustomerCustomizationBaseColor_Sel)),  AV28TFCustomerCustomizationBaseColor_Sel,  AV28TFCustomerCustomizationBaseColor_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFCUSTOMERCUSTOMIZATIONFONTSIZE",  context.GetMessage( "Font Size", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV29TFCustomerCustomizationFontSize)),  0,  AV29TFCustomerCustomizationFontSize,  AV29TFCustomerCustomizationFontSize,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV48TFCustomerCustomizationFontSize_Sel)),  AV48TFCustomerCustomizationFontSize_Sel,  AV48TFCustomerCustomizationFontSize_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFCUSTOMERID",  context.GetMessage( "Customer Id", ""),  !((0==AV31TFCustomerId)&&(0==AV32TFCustomerId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV31TFCustomerId), 4, 0)),  ((0==AV31TFCustomerId) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV31TFCustomerId), "ZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV32TFCustomerId_To), 4, 0)),  ((0==AV32TFCustomerId_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV32TFCustomerId_To), "ZZZ9")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFCUSTOMERNAME",  context.GetMessage( "Customer Name", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV33TFCustomerName)),  0,  AV33TFCustomerName,  AV33TFCustomerName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV34TFCustomerName_Sel)),  AV34TFCustomerName_Sel,  AV34TFCustomerName_Sel) ;
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV49Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV49Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "CustomerCustomization";
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
         PA3J2( ) ;
         WS3J2( ) ;
         WE3J2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202481915584739", true, true);
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
         context.AddJavascriptSource("customercustomizationww.js", "?202481915584741", false, true);
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
         edtCustomerCustomizationId_Internalname = "CUSTOMERCUSTOMIZATIONID_"+sGXsfl_37_idx;
         edtCustomerCustomizationLogo_Internalname = "CUSTOMERCUSTOMIZATIONLOGO_"+sGXsfl_37_idx;
         edtCustomerCustomizationFavicon_Internalname = "CUSTOMERCUSTOMIZATIONFAVICON_"+sGXsfl_37_idx;
         edtCustomerCustomizationBaseColor_Internalname = "CUSTOMERCUSTOMIZATIONBASECOLOR_"+sGXsfl_37_idx;
         edtCustomerCustomizationFontSize_Internalname = "CUSTOMERCUSTOMIZATIONFONTSIZE_"+sGXsfl_37_idx;
         edtCustomerId_Internalname = "CUSTOMERID_"+sGXsfl_37_idx;
         edtCustomerName_Internalname = "CUSTOMERNAME_"+sGXsfl_37_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_37_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_37_idx;
      }

      protected void SubsflControlProps_fel_372( )
      {
         edtCustomerCustomizationId_Internalname = "CUSTOMERCUSTOMIZATIONID_"+sGXsfl_37_fel_idx;
         edtCustomerCustomizationLogo_Internalname = "CUSTOMERCUSTOMIZATIONLOGO_"+sGXsfl_37_fel_idx;
         edtCustomerCustomizationFavicon_Internalname = "CUSTOMERCUSTOMIZATIONFAVICON_"+sGXsfl_37_fel_idx;
         edtCustomerCustomizationBaseColor_Internalname = "CUSTOMERCUSTOMIZATIONBASECOLOR_"+sGXsfl_37_fel_idx;
         edtCustomerCustomizationFontSize_Internalname = "CUSTOMERCUSTOMIZATIONFONTSIZE_"+sGXsfl_37_fel_idx;
         edtCustomerId_Internalname = "CUSTOMERID_"+sGXsfl_37_fel_idx;
         edtCustomerName_Internalname = "CUSTOMERNAME_"+sGXsfl_37_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_37_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_37_fel_idx;
      }

      protected void sendrow_372( )
      {
         SubsflControlProps_372( ) ;
         WB3J0( ) ;
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtCustomerCustomizationId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerCustomizationId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A128CustomerCustomizationId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A128CustomerCustomizationId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCustomerCustomizationId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtCustomerCustomizationId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtCustomerCustomizationLogo_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Attribute";
            StyleString = "";
            A129CustomerCustomizationLogo_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A129CustomerCustomizationLogo))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000CustomerCustomizationLogo_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A129CustomerCustomizationLogo)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A129CustomerCustomizationLogo)) ? A40000CustomerCustomizationLogo_GXI : context.PathToRelativeUrl( A129CustomerCustomizationLogo));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerCustomizationLogo_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(int)edtCustomerCustomizationLogo_Visible,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A129CustomerCustomizationLogo_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtCustomerCustomizationFavicon_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Attribute";
            StyleString = "";
            A130CustomerCustomizationFavicon_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A130CustomerCustomizationFavicon))&&String.IsNullOrEmpty(StringUtil.RTrim( A40001CustomerCustomizationFavicon_G)))||!String.IsNullOrEmpty(StringUtil.RTrim( A130CustomerCustomizationFavicon)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A130CustomerCustomizationFavicon)) ? A40001CustomerCustomizationFavicon_G : context.PathToRelativeUrl( A130CustomerCustomizationFavicon));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerCustomizationFavicon_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(int)edtCustomerCustomizationFavicon_Visible,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A130CustomerCustomizationFavicon_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtCustomerCustomizationBaseColor_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerCustomizationBaseColor_Internalname,(string)A131CustomerCustomizationBaseColor,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtCustomerCustomizationBaseColor_Link,(string)"",(string)"",(string)"",(string)edtCustomerCustomizationBaseColor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCustomerCustomizationBaseColor_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtCustomerCustomizationFontSize_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerCustomizationFontSize_Internalname,(string)A132CustomerCustomizationFontSize,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCustomerCustomizationFontSize_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtCustomerCustomizationFontSize_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtCustomerId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A1CustomerId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A1CustomerId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCustomerId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtCustomerId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtCustomerName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerName_Internalname,(string)A3CustomerName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCustomerName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtCustomerName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV42Update),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",context.GetMessage( "GXM_update", ""),(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV44Delete),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDelete_Link,(string)"",context.GetMessage( "GX_BtnDelete", ""),(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavDelete_Visible,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes3J2( ) ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCustomerCustomizationId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Customization Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCustomerCustomizationLogo_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Customization Logo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCustomerCustomizationFavicon_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Customization Favicon", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCustomerCustomizationBaseColor_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Base Color", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCustomerCustomizationFontSize_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Font Size", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCustomerId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Customer Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCustomerName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Customer Name", "")) ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A128CustomerCustomizationId), 4, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerCustomizationId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( A129CustomerCustomizationLogo));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerCustomizationLogo_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( A130CustomerCustomizationFavicon));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerCustomizationFavicon_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A131CustomerCustomizationBaseColor));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtCustomerCustomizationBaseColor_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerCustomizationBaseColor_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A132CustomerCustomizationFontSize));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerCustomizationFontSize_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1CustomerId), 4, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A3CustomerName));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerName_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV42Update)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV44Delete)));
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
         edtCustomerCustomizationId_Internalname = "CUSTOMERCUSTOMIZATIONID";
         edtCustomerCustomizationLogo_Internalname = "CUSTOMERCUSTOMIZATIONLOGO";
         edtCustomerCustomizationFavicon_Internalname = "CUSTOMERCUSTOMIZATIONFAVICON";
         edtCustomerCustomizationBaseColor_Internalname = "CUSTOMERCUSTOMIZATIONBASECOLOR";
         edtCustomerCustomizationFontSize_Internalname = "CUSTOMERCUSTOMIZATIONFONTSIZE";
         edtCustomerId_Internalname = "CUSTOMERID";
         edtCustomerName_Internalname = "CUSTOMERNAME";
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
         edtCustomerName_Jsonclick = "";
         edtCustomerId_Jsonclick = "";
         edtCustomerCustomizationFontSize_Jsonclick = "";
         edtCustomerCustomizationBaseColor_Jsonclick = "";
         edtCustomerCustomizationBaseColor_Link = "";
         edtCustomerCustomizationId_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavDelete_Visible = -1;
         edtavUpdate_Visible = -1;
         edtCustomerName_Visible = -1;
         edtCustomerId_Visible = -1;
         edtCustomerCustomizationFontSize_Visible = -1;
         edtCustomerCustomizationBaseColor_Visible = -1;
         edtCustomerCustomizationFavicon_Visible = -1;
         edtCustomerCustomizationLogo_Visible = -1;
         edtCustomerCustomizationId_Visible = -1;
         edtCustomerName_Enabled = 0;
         edtCustomerId_Enabled = 0;
         edtCustomerCustomizationFontSize_Enabled = 0;
         edtCustomerCustomizationBaseColor_Enabled = 0;
         edtCustomerCustomizationFavicon_Enabled = 0;
         edtCustomerCustomizationLogo_Enabled = 0;
         edtCustomerCustomizationId_Enabled = 0;
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
         Ddo_grid_Format = "4.0|||||4.0|";
         Ddo_grid_Datalistproc = "CustomerCustomizationWWGetFilterData";
         Ddo_grid_Datalisttype = "|||Dynamic|Dynamic||Dynamic";
         Ddo_grid_Includedatalist = "|||T|T||T";
         Ddo_grid_Filterisrange = "T|||||T|";
         Ddo_grid_Filtertype = "Numeric|||Character|Character|Numeric|Character";
         Ddo_grid_Includefilter = "T|||T|T|T|T";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T|||T|T|T|T";
         Ddo_grid_Columnssortvalues = "2|||1|3|4|5";
         Ddo_grid_Columnids = "0:CustomerCustomizationId|1:CustomerCustomizationLogo|2:CustomerCustomizationFavicon|3:CustomerCustomizationBaseColor|4:CustomerCustomizationFontSize|5:CustomerId|6:CustomerName";
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
         Form.Caption = context.GetMessage( " Customer Customization", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV24ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV19ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV49Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV25TFCustomerCustomizationId',fld:'vTFCUSTOMERCUSTOMIZATIONID',pic:'ZZZ9'},{av:'AV26TFCustomerCustomizationId_To',fld:'vTFCUSTOMERCUSTOMIZATIONID_TO',pic:'ZZZ9'},{av:'AV27TFCustomerCustomizationBaseColor',fld:'vTFCUSTOMERCUSTOMIZATIONBASECOLOR',pic:''},{av:'AV28TFCustomerCustomizationBaseColor_Sel',fld:'vTFCUSTOMERCUSTOMIZATIONBASECOLOR_SEL',pic:''},{av:'AV29TFCustomerCustomizationFontSize',fld:'vTFCUSTOMERCUSTOMIZATIONFONTSIZE',pic:''},{av:'AV48TFCustomerCustomizationFontSize_Sel',fld:'vTFCUSTOMERCUSTOMIZATIONFONTSIZE_SEL',pic:''},{av:'AV31TFCustomerId',fld:'vTFCUSTOMERID',pic:'ZZZ9'},{av:'AV32TFCustomerId_To',fld:'vTFCUSTOMERID_TO',pic:'ZZZ9'},{av:'AV33TFCustomerName',fld:'vTFCUSTOMERNAME',pic:''},{av:'AV34TFCustomerName_Sel',fld:'vTFCUSTOMERNAME_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV43IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV45IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV46IsAuthorized_CustomerCustomizationBaseColor',fld:'vISAUTHORIZED_CUSTOMERCUSTOMIZATIONBASECOLOR',pic:'',hsh:true},{av:'AV47IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV24ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV19ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtCustomerCustomizationId_Visible',ctrl:'CUSTOMERCUSTOMIZATIONID',prop:'Visible'},{av:'edtCustomerCustomizationLogo_Visible',ctrl:'CUSTOMERCUSTOMIZATIONLOGO',prop:'Visible'},{av:'edtCustomerCustomizationFavicon_Visible',ctrl:'CUSTOMERCUSTOMIZATIONFAVICON',prop:'Visible'},{av:'edtCustomerCustomizationBaseColor_Visible',ctrl:'CUSTOMERCUSTOMIZATIONBASECOLOR',prop:'Visible'},{av:'edtCustomerCustomizationFontSize_Visible',ctrl:'CUSTOMERCUSTOMIZATIONFONTSIZE',prop:'Visible'},{av:'edtCustomerId_Visible',ctrl:'CUSTOMERID',prop:'Visible'},{av:'edtCustomerName_Visible',ctrl:'CUSTOMERNAME',prop:'Visible'},{av:'AV39GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV40GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV41GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV43IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV45IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV47IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV22ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E123J2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV24ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV19ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV49Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV25TFCustomerCustomizationId',fld:'vTFCUSTOMERCUSTOMIZATIONID',pic:'ZZZ9'},{av:'AV26TFCustomerCustomizationId_To',fld:'vTFCUSTOMERCUSTOMIZATIONID_TO',pic:'ZZZ9'},{av:'AV27TFCustomerCustomizationBaseColor',fld:'vTFCUSTOMERCUSTOMIZATIONBASECOLOR',pic:''},{av:'AV28TFCustomerCustomizationBaseColor_Sel',fld:'vTFCUSTOMERCUSTOMIZATIONBASECOLOR_SEL',pic:''},{av:'AV29TFCustomerCustomizationFontSize',fld:'vTFCUSTOMERCUSTOMIZATIONFONTSIZE',pic:''},{av:'AV48TFCustomerCustomizationFontSize_Sel',fld:'vTFCUSTOMERCUSTOMIZATIONFONTSIZE_SEL',pic:''},{av:'AV31TFCustomerId',fld:'vTFCUSTOMERID',pic:'ZZZ9'},{av:'AV32TFCustomerId_To',fld:'vTFCUSTOMERID_TO',pic:'ZZZ9'},{av:'AV33TFCustomerName',fld:'vTFCUSTOMERNAME',pic:''},{av:'AV34TFCustomerName_Sel',fld:'vTFCUSTOMERNAME_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV43IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV45IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV46IsAuthorized_CustomerCustomizationBaseColor',fld:'vISAUTHORIZED_CUSTOMERCUSTOMIZATIONBASECOLOR',pic:'',hsh:true},{av:'AV47IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E133J2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV24ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV19ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV49Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV25TFCustomerCustomizationId',fld:'vTFCUSTOMERCUSTOMIZATIONID',pic:'ZZZ9'},{av:'AV26TFCustomerCustomizationId_To',fld:'vTFCUSTOMERCUSTOMIZATIONID_TO',pic:'ZZZ9'},{av:'AV27TFCustomerCustomizationBaseColor',fld:'vTFCUSTOMERCUSTOMIZATIONBASECOLOR',pic:''},{av:'AV28TFCustomerCustomizationBaseColor_Sel',fld:'vTFCUSTOMERCUSTOMIZATIONBASECOLOR_SEL',pic:''},{av:'AV29TFCustomerCustomizationFontSize',fld:'vTFCUSTOMERCUSTOMIZATIONFONTSIZE',pic:''},{av:'AV48TFCustomerCustomizationFontSize_Sel',fld:'vTFCUSTOMERCUSTOMIZATIONFONTSIZE_SEL',pic:''},{av:'AV31TFCustomerId',fld:'vTFCUSTOMERID',pic:'ZZZ9'},{av:'AV32TFCustomerId_To',fld:'vTFCUSTOMERID_TO',pic:'ZZZ9'},{av:'AV33TFCustomerName',fld:'vTFCUSTOMERNAME',pic:''},{av:'AV34TFCustomerName_Sel',fld:'vTFCUSTOMERNAME_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV43IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV45IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV46IsAuthorized_CustomerCustomizationBaseColor',fld:'vISAUTHORIZED_CUSTOMERCUSTOMIZATIONBASECOLOR',pic:'',hsh:true},{av:'AV47IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E143J2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV24ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV19ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV49Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV25TFCustomerCustomizationId',fld:'vTFCUSTOMERCUSTOMIZATIONID',pic:'ZZZ9'},{av:'AV26TFCustomerCustomizationId_To',fld:'vTFCUSTOMERCUSTOMIZATIONID_TO',pic:'ZZZ9'},{av:'AV27TFCustomerCustomizationBaseColor',fld:'vTFCUSTOMERCUSTOMIZATIONBASECOLOR',pic:''},{av:'AV28TFCustomerCustomizationBaseColor_Sel',fld:'vTFCUSTOMERCUSTOMIZATIONBASECOLOR_SEL',pic:''},{av:'AV29TFCustomerCustomizationFontSize',fld:'vTFCUSTOMERCUSTOMIZATIONFONTSIZE',pic:''},{av:'AV48TFCustomerCustomizationFontSize_Sel',fld:'vTFCUSTOMERCUSTOMIZATIONFONTSIZE_SEL',pic:''},{av:'AV31TFCustomerId',fld:'vTFCUSTOMERID',pic:'ZZZ9'},{av:'AV32TFCustomerId_To',fld:'vTFCUSTOMERID_TO',pic:'ZZZ9'},{av:'AV33TFCustomerName',fld:'vTFCUSTOMERNAME',pic:''},{av:'AV34TFCustomerName_Sel',fld:'vTFCUSTOMERNAME_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV43IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV45IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV46IsAuthorized_CustomerCustomizationBaseColor',fld:'vISAUTHORIZED_CUSTOMERCUSTOMIZATIONBASECOLOR',pic:'',hsh:true},{av:'AV47IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV25TFCustomerCustomizationId',fld:'vTFCUSTOMERCUSTOMIZATIONID',pic:'ZZZ9'},{av:'AV26TFCustomerCustomizationId_To',fld:'vTFCUSTOMERCUSTOMIZATIONID_TO',pic:'ZZZ9'},{av:'AV27TFCustomerCustomizationBaseColor',fld:'vTFCUSTOMERCUSTOMIZATIONBASECOLOR',pic:''},{av:'AV28TFCustomerCustomizationBaseColor_Sel',fld:'vTFCUSTOMERCUSTOMIZATIONBASECOLOR_SEL',pic:''},{av:'AV29TFCustomerCustomizationFontSize',fld:'vTFCUSTOMERCUSTOMIZATIONFONTSIZE',pic:''},{av:'AV48TFCustomerCustomizationFontSize_Sel',fld:'vTFCUSTOMERCUSTOMIZATIONFONTSIZE_SEL',pic:''},{av:'AV31TFCustomerId',fld:'vTFCUSTOMERID',pic:'ZZZ9'},{av:'AV32TFCustomerId_To',fld:'vTFCUSTOMERID_TO',pic:'ZZZ9'},{av:'AV33TFCustomerName',fld:'vTFCUSTOMERNAME',pic:''},{av:'AV34TFCustomerName_Sel',fld:'vTFCUSTOMERNAME_SEL',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E193J2',iparms:[{av:'AV43IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'A128CustomerCustomizationId',fld:'CUSTOMERCUSTOMIZATIONID',pic:'ZZZ9',hsh:true},{av:'AV45IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV46IsAuthorized_CustomerCustomizationBaseColor',fld:'vISAUTHORIZED_CUSTOMERCUSTOMIZATIONBASECOLOR',pic:'',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'AV42Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Link',ctrl:'vUPDATE',prop:'Link'},{av:'AV44Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Link',ctrl:'vDELETE',prop:'Link'},{av:'edtCustomerCustomizationBaseColor_Link',ctrl:'CUSTOMERCUSTOMIZATIONBASECOLOR',prop:'Link'}]}");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","{handler:'E153J2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV24ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV19ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV49Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV25TFCustomerCustomizationId',fld:'vTFCUSTOMERCUSTOMIZATIONID',pic:'ZZZ9'},{av:'AV26TFCustomerCustomizationId_To',fld:'vTFCUSTOMERCUSTOMIZATIONID_TO',pic:'ZZZ9'},{av:'AV27TFCustomerCustomizationBaseColor',fld:'vTFCUSTOMERCUSTOMIZATIONBASECOLOR',pic:''},{av:'AV28TFCustomerCustomizationBaseColor_Sel',fld:'vTFCUSTOMERCUSTOMIZATIONBASECOLOR_SEL',pic:''},{av:'AV29TFCustomerCustomizationFontSize',fld:'vTFCUSTOMERCUSTOMIZATIONFONTSIZE',pic:''},{av:'AV48TFCustomerCustomizationFontSize_Sel',fld:'vTFCUSTOMERCUSTOMIZATIONFONTSIZE_SEL',pic:''},{av:'AV31TFCustomerId',fld:'vTFCUSTOMERID',pic:'ZZZ9'},{av:'AV32TFCustomerId_To',fld:'vTFCUSTOMERID_TO',pic:'ZZZ9'},{av:'AV33TFCustomerName',fld:'vTFCUSTOMERNAME',pic:''},{av:'AV34TFCustomerName_Sel',fld:'vTFCUSTOMERNAME_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV43IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV45IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV46IsAuthorized_CustomerCustomizationBaseColor',fld:'vISAUTHORIZED_CUSTOMERCUSTOMIZATIONBASECOLOR',pic:'',hsh:true},{av:'AV47IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_gridcolumnsselector_Columnsselectorvalues',ctrl:'DDO_GRIDCOLUMNSSELECTOR',prop:'ColumnsSelectorValues'}]");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",",oparms:[{av:'AV19ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV24ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'edtCustomerCustomizationId_Visible',ctrl:'CUSTOMERCUSTOMIZATIONID',prop:'Visible'},{av:'edtCustomerCustomizationLogo_Visible',ctrl:'CUSTOMERCUSTOMIZATIONLOGO',prop:'Visible'},{av:'edtCustomerCustomizationFavicon_Visible',ctrl:'CUSTOMERCUSTOMIZATIONFAVICON',prop:'Visible'},{av:'edtCustomerCustomizationBaseColor_Visible',ctrl:'CUSTOMERCUSTOMIZATIONBASECOLOR',prop:'Visible'},{av:'edtCustomerCustomizationFontSize_Visible',ctrl:'CUSTOMERCUSTOMIZATIONFONTSIZE',prop:'Visible'},{av:'edtCustomerId_Visible',ctrl:'CUSTOMERID',prop:'Visible'},{av:'edtCustomerName_Visible',ctrl:'CUSTOMERNAME',prop:'Visible'},{av:'AV39GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV40GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV41GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV43IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV45IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV47IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV22ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E113J2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV24ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV19ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV49Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV25TFCustomerCustomizationId',fld:'vTFCUSTOMERCUSTOMIZATIONID',pic:'ZZZ9'},{av:'AV26TFCustomerCustomizationId_To',fld:'vTFCUSTOMERCUSTOMIZATIONID_TO',pic:'ZZZ9'},{av:'AV27TFCustomerCustomizationBaseColor',fld:'vTFCUSTOMERCUSTOMIZATIONBASECOLOR',pic:''},{av:'AV28TFCustomerCustomizationBaseColor_Sel',fld:'vTFCUSTOMERCUSTOMIZATIONBASECOLOR_SEL',pic:''},{av:'AV29TFCustomerCustomizationFontSize',fld:'vTFCUSTOMERCUSTOMIZATIONFONTSIZE',pic:''},{av:'AV48TFCustomerCustomizationFontSize_Sel',fld:'vTFCUSTOMERCUSTOMIZATIONFONTSIZE_SEL',pic:''},{av:'AV31TFCustomerId',fld:'vTFCUSTOMERID',pic:'ZZZ9'},{av:'AV32TFCustomerId_To',fld:'vTFCUSTOMERID_TO',pic:'ZZZ9'},{av:'AV33TFCustomerName',fld:'vTFCUSTOMERNAME',pic:''},{av:'AV34TFCustomerName_Sel',fld:'vTFCUSTOMERNAME_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV43IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV45IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV46IsAuthorized_CustomerCustomizationBaseColor',fld:'vISAUTHORIZED_CUSTOMERCUSTOMIZATIONBASECOLOR',pic:'',hsh:true},{av:'AV47IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV24ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV25TFCustomerCustomizationId',fld:'vTFCUSTOMERCUSTOMIZATIONID',pic:'ZZZ9'},{av:'AV26TFCustomerCustomizationId_To',fld:'vTFCUSTOMERCUSTOMIZATIONID_TO',pic:'ZZZ9'},{av:'AV27TFCustomerCustomizationBaseColor',fld:'vTFCUSTOMERCUSTOMIZATIONBASECOLOR',pic:''},{av:'AV28TFCustomerCustomizationBaseColor_Sel',fld:'vTFCUSTOMERCUSTOMIZATIONBASECOLOR_SEL',pic:''},{av:'AV29TFCustomerCustomizationFontSize',fld:'vTFCUSTOMERCUSTOMIZATIONFONTSIZE',pic:''},{av:'AV48TFCustomerCustomizationFontSize_Sel',fld:'vTFCUSTOMERCUSTOMIZATIONFONTSIZE_SEL',pic:''},{av:'AV31TFCustomerId',fld:'vTFCUSTOMERID',pic:'ZZZ9'},{av:'AV32TFCustomerId_To',fld:'vTFCUSTOMERID_TO',pic:'ZZZ9'},{av:'AV33TFCustomerName',fld:'vTFCUSTOMERNAME',pic:''},{av:'AV34TFCustomerName_Sel',fld:'vTFCUSTOMERNAME_SEL',pic:''},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV19ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtCustomerCustomizationId_Visible',ctrl:'CUSTOMERCUSTOMIZATIONID',prop:'Visible'},{av:'edtCustomerCustomizationLogo_Visible',ctrl:'CUSTOMERCUSTOMIZATIONLOGO',prop:'Visible'},{av:'edtCustomerCustomizationFavicon_Visible',ctrl:'CUSTOMERCUSTOMIZATIONFAVICON',prop:'Visible'},{av:'edtCustomerCustomizationBaseColor_Visible',ctrl:'CUSTOMERCUSTOMIZATIONBASECOLOR',prop:'Visible'},{av:'edtCustomerCustomizationFontSize_Visible',ctrl:'CUSTOMERCUSTOMIZATIONFONTSIZE',prop:'Visible'},{av:'edtCustomerId_Visible',ctrl:'CUSTOMERID',prop:'Visible'},{av:'edtCustomerName_Visible',ctrl:'CUSTOMERNAME',prop:'Visible'},{av:'AV39GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV40GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV41GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV43IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV45IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV47IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV22ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("'DOINSERT'","{handler:'E163J2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV24ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV19ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV49Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV25TFCustomerCustomizationId',fld:'vTFCUSTOMERCUSTOMIZATIONID',pic:'ZZZ9'},{av:'AV26TFCustomerCustomizationId_To',fld:'vTFCUSTOMERCUSTOMIZATIONID_TO',pic:'ZZZ9'},{av:'AV27TFCustomerCustomizationBaseColor',fld:'vTFCUSTOMERCUSTOMIZATIONBASECOLOR',pic:''},{av:'AV28TFCustomerCustomizationBaseColor_Sel',fld:'vTFCUSTOMERCUSTOMIZATIONBASECOLOR_SEL',pic:''},{av:'AV29TFCustomerCustomizationFontSize',fld:'vTFCUSTOMERCUSTOMIZATIONFONTSIZE',pic:''},{av:'AV48TFCustomerCustomizationFontSize_Sel',fld:'vTFCUSTOMERCUSTOMIZATIONFONTSIZE_SEL',pic:''},{av:'AV31TFCustomerId',fld:'vTFCUSTOMERID',pic:'ZZZ9'},{av:'AV32TFCustomerId_To',fld:'vTFCUSTOMERID_TO',pic:'ZZZ9'},{av:'AV33TFCustomerName',fld:'vTFCUSTOMERNAME',pic:''},{av:'AV34TFCustomerName_Sel',fld:'vTFCUSTOMERNAME_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV43IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV45IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV46IsAuthorized_CustomerCustomizationBaseColor',fld:'vISAUTHORIZED_CUSTOMERCUSTOMIZATIONBASECOLOR',pic:'',hsh:true},{av:'AV47IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'A128CustomerCustomizationId',fld:'CUSTOMERCUSTOMIZATIONID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("'DOINSERT'",",oparms:[{av:'AV24ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV19ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtCustomerCustomizationId_Visible',ctrl:'CUSTOMERCUSTOMIZATIONID',prop:'Visible'},{av:'edtCustomerCustomizationLogo_Visible',ctrl:'CUSTOMERCUSTOMIZATIONLOGO',prop:'Visible'},{av:'edtCustomerCustomizationFavicon_Visible',ctrl:'CUSTOMERCUSTOMIZATIONFAVICON',prop:'Visible'},{av:'edtCustomerCustomizationBaseColor_Visible',ctrl:'CUSTOMERCUSTOMIZATIONBASECOLOR',prop:'Visible'},{av:'edtCustomerCustomizationFontSize_Visible',ctrl:'CUSTOMERCUSTOMIZATIONFONTSIZE',prop:'Visible'},{av:'edtCustomerId_Visible',ctrl:'CUSTOMERID',prop:'Visible'},{av:'edtCustomerName_Visible',ctrl:'CUSTOMERNAME',prop:'Visible'},{av:'AV39GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV40GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV41GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV43IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV45IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV47IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV22ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("VALID_CUSTOMERID","{handler:'Valid_Customerid',iparms:[]");
         setEventMetadata("VALID_CUSTOMERID",",oparms:[]}");
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
         Ddo_grid_Selectedcolumn = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Filteredtextto_get = "";
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV16FilterFullText = "";
         AV19ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV49Pgmname = "";
         AV27TFCustomerCustomizationBaseColor = "";
         AV28TFCustomerCustomizationBaseColor_Sel = "";
         AV29TFCustomerCustomizationFontSize = "";
         AV48TFCustomerCustomizationFontSize_Sel = "";
         AV33TFCustomerName = "";
         AV34TFCustomerName_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV22ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV41GridAppliedFilters = "";
         AV35DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
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
         A129CustomerCustomizationLogo = "";
         A40000CustomerCustomizationLogo_GXI = "";
         A130CustomerCustomizationFavicon = "";
         A40001CustomerCustomizationFavicon_G = "";
         A131CustomerCustomizationBaseColor = "";
         A132CustomerCustomizationFontSize = "";
         A3CustomerName = "";
         AV42Update = "";
         AV44Delete = "";
         scmdbuf = "";
         lV50Customercustomizationwwds_1_filterfulltext = "";
         lV53Customercustomizationwwds_4_tfcustomercustomizationbasecolor = "";
         lV55Customercustomizationwwds_6_tfcustomercustomizationfontsize = "";
         lV59Customercustomizationwwds_10_tfcustomername = "";
         AV50Customercustomizationwwds_1_filterfulltext = "";
         AV54Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel = "";
         AV53Customercustomizationwwds_4_tfcustomercustomizationbasecolor = "";
         AV56Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel = "";
         AV55Customercustomizationwwds_6_tfcustomercustomizationfontsize = "";
         AV60Customercustomizationwwds_11_tfcustomername_sel = "";
         AV59Customercustomizationwwds_10_tfcustomername = "";
         H003J2_A3CustomerName = new string[] {""} ;
         H003J2_A1CustomerId = new short[1] ;
         H003J2_A132CustomerCustomizationFontSize = new string[] {""} ;
         H003J2_A131CustomerCustomizationBaseColor = new string[] {""} ;
         H003J2_A40001CustomerCustomizationFavicon_G = new string[] {""} ;
         H003J2_A40000CustomerCustomizationLogo_GXI = new string[] {""} ;
         H003J2_A128CustomerCustomizationId = new short[1] ;
         H003J2_A130CustomerCustomizationFavicon = new string[] {""} ;
         H003J2_A129CustomerCustomizationLogo = new string[] {""} ;
         H003J3_AGRID_nRecordCount = new long[1] ;
         AV8HTTPRequest = new GxHttpRequest( context);
         AV36GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV37GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
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
         GXt_char6 = "";
         GXt_char5 = "";
         GXt_char3 = "";
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         sImgUrl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.customercustomizationww__default(),
            new Object[][] {
                new Object[] {
               H003J2_A3CustomerName, H003J2_A1CustomerId, H003J2_A132CustomerCustomizationFontSize, H003J2_A131CustomerCustomizationBaseColor, H003J2_A40001CustomerCustomizationFavicon_G, H003J2_A40000CustomerCustomizationLogo_GXI, H003J2_A128CustomerCustomizationId, H003J2_A130CustomerCustomizationFavicon, H003J2_A129CustomerCustomizationLogo
               }
               , new Object[] {
               H003J3_AGRID_nRecordCount
               }
            }
         );
         AV49Pgmname = "CustomerCustomizationWW";
         /* GeneXus formulas. */
         AV49Pgmname = "CustomerCustomizationWW";
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV24ManageFiltersExecutionStep ;
      private short AV25TFCustomerCustomizationId ;
      private short AV26TFCustomerCustomizationId_To ;
      private short AV31TFCustomerId ;
      private short AV32TFCustomerId_To ;
      private short AV13OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A128CustomerCustomizationId ;
      private short A1CustomerId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV51Customercustomizationwwds_2_tfcustomercustomizationid ;
      private short AV52Customercustomizationwwds_3_tfcustomercustomizationid_to ;
      private short AV57Customercustomizationwwds_8_tfcustomerid ;
      private short AV58Customercustomizationwwds_9_tfcustomerid_to ;
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
      private int edtCustomerCustomizationId_Enabled ;
      private int edtCustomerCustomizationLogo_Enabled ;
      private int edtCustomerCustomizationFavicon_Enabled ;
      private int edtCustomerCustomizationBaseColor_Enabled ;
      private int edtCustomerCustomizationFontSize_Enabled ;
      private int edtCustomerId_Enabled ;
      private int edtCustomerName_Enabled ;
      private int edtCustomerCustomizationId_Visible ;
      private int edtCustomerCustomizationLogo_Visible ;
      private int edtCustomerCustomizationFavicon_Visible ;
      private int edtCustomerCustomizationBaseColor_Visible ;
      private int edtCustomerCustomizationFontSize_Visible ;
      private int edtCustomerId_Visible ;
      private int edtCustomerName_Visible ;
      private int AV38PageToGo ;
      private int edtavUpdate_Visible ;
      private int edtavDelete_Visible ;
      private int AV61GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV39GridCurrentPage ;
      private long AV40GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_37_idx="0001" ;
      private string AV49Pgmname ;
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
      private string edtCustomerCustomizationId_Internalname ;
      private string edtCustomerCustomizationLogo_Internalname ;
      private string edtCustomerCustomizationFavicon_Internalname ;
      private string edtCustomerCustomizationBaseColor_Internalname ;
      private string edtCustomerCustomizationFontSize_Internalname ;
      private string edtCustomerId_Internalname ;
      private string edtCustomerName_Internalname ;
      private string AV42Update ;
      private string edtavUpdate_Internalname ;
      private string AV44Delete ;
      private string edtavDelete_Internalname ;
      private string scmdbuf ;
      private string edtavUpdate_Link ;
      private string edtavDelete_Link ;
      private string edtCustomerCustomizationBaseColor_Link ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char3 ;
      private string sGXsfl_37_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtCustomerCustomizationId_Jsonclick ;
      private string sImgUrl ;
      private string edtCustomerCustomizationBaseColor_Jsonclick ;
      private string edtCustomerCustomizationFontSize_Jsonclick ;
      private string edtCustomerId_Jsonclick ;
      private string edtCustomerName_Jsonclick ;
      private string edtavUpdate_Jsonclick ;
      private string edtavDelete_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV43IsAuthorized_Update ;
      private bool AV45IsAuthorized_Delete ;
      private bool AV46IsAuthorized_CustomerCustomizationBaseColor ;
      private bool AV47IsAuthorized_Insert ;
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
      private bool bGXsfl_37_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool GXt_boolean1 ;
      private bool A129CustomerCustomizationLogo_IsBlob ;
      private bool A130CustomerCustomizationFavicon_IsBlob ;
      private string AV17ColumnsSelectorXML ;
      private string AV23ManageFiltersXml ;
      private string AV18UserCustomValue ;
      private string AV16FilterFullText ;
      private string AV27TFCustomerCustomizationBaseColor ;
      private string AV28TFCustomerCustomizationBaseColor_Sel ;
      private string AV29TFCustomerCustomizationFontSize ;
      private string AV48TFCustomerCustomizationFontSize_Sel ;
      private string AV33TFCustomerName ;
      private string AV34TFCustomerName_Sel ;
      private string AV41GridAppliedFilters ;
      private string A40000CustomerCustomizationLogo_GXI ;
      private string A40001CustomerCustomizationFavicon_G ;
      private string A131CustomerCustomizationBaseColor ;
      private string A132CustomerCustomizationFontSize ;
      private string A3CustomerName ;
      private string lV50Customercustomizationwwds_1_filterfulltext ;
      private string lV53Customercustomizationwwds_4_tfcustomercustomizationbasecolor ;
      private string lV55Customercustomizationwwds_6_tfcustomercustomizationfontsize ;
      private string lV59Customercustomizationwwds_10_tfcustomername ;
      private string AV50Customercustomizationwwds_1_filterfulltext ;
      private string AV54Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel ;
      private string AV53Customercustomizationwwds_4_tfcustomercustomizationbasecolor ;
      private string AV56Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel ;
      private string AV55Customercustomizationwwds_6_tfcustomercustomizationfontsize ;
      private string AV60Customercustomizationwwds_11_tfcustomername_sel ;
      private string AV59Customercustomizationwwds_10_tfcustomername ;
      private string A129CustomerCustomizationLogo ;
      private string A130CustomerCustomizationFavicon ;
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
      private string[] H003J2_A3CustomerName ;
      private short[] H003J2_A1CustomerId ;
      private string[] H003J2_A132CustomerCustomizationFontSize ;
      private string[] H003J2_A131CustomerCustomizationBaseColor ;
      private string[] H003J2_A40001CustomerCustomizationFavicon_G ;
      private string[] H003J2_A40000CustomerCustomizationLogo_GXI ;
      private short[] H003J2_A128CustomerCustomizationId ;
      private string[] H003J2_A130CustomerCustomizationFavicon ;
      private string[] H003J2_A129CustomerCustomizationLogo ;
      private long[] H003J3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV22ManageFiltersData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV37GAMErrors ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV19ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV20ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV35DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV36GAMSession ;
   }

   public class customercustomizationww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H003J2( IGxContext context ,
                                             string AV50Customercustomizationwwds_1_filterfulltext ,
                                             short AV51Customercustomizationwwds_2_tfcustomercustomizationid ,
                                             short AV52Customercustomizationwwds_3_tfcustomercustomizationid_to ,
                                             string AV54Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel ,
                                             string AV53Customercustomizationwwds_4_tfcustomercustomizationbasecolor ,
                                             string AV56Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel ,
                                             string AV55Customercustomizationwwds_6_tfcustomercustomizationfontsize ,
                                             short AV57Customercustomizationwwds_8_tfcustomerid ,
                                             short AV58Customercustomizationwwds_9_tfcustomerid_to ,
                                             string AV60Customercustomizationwwds_11_tfcustomername_sel ,
                                             string AV59Customercustomizationwwds_10_tfcustomername ,
                                             short A128CustomerCustomizationId ,
                                             string A131CustomerCustomizationBaseColor ,
                                             string A132CustomerCustomizationFontSize ,
                                             short A1CustomerId ,
                                             string A3CustomerName ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[18];
         Object[] GXv_Object8 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T2.CustomerName, T1.CustomerId, T1.CustomerCustomizationFontSize, T1.CustomerCustomizationBaseColor, T1.CustomerCustomizationFavicon_G, T1.CustomerCustomizationLogo_GXI, T1.CustomerCustomizationId, T1.CustomerCustomizationFavicon, T1.CustomerCustomizationLogo";
         sFromString = " FROM (CustomerCustomization T1 INNER JOIN Customer T2 ON T2.CustomerId = T1.CustomerId)";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Customercustomizationwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.CustomerCustomizationId,'9999'), 2) like '%' || :lV50Customercustomizationwwds_1_filterfulltext) or ( T1.CustomerCustomizationBaseColor like '%' || :lV50Customercustomizationwwds_1_filterfulltext) or ( T1.CustomerCustomizationFontSize like '%' || :lV50Customercustomizationwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.CustomerId,'9999'), 2) like '%' || :lV50Customercustomizationwwds_1_filterfulltext) or ( T2.CustomerName like '%' || :lV50Customercustomizationwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int7[0] = 1;
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
            GXv_int7[4] = 1;
         }
         if ( ! (0==AV51Customercustomizationwwds_2_tfcustomercustomizationid) )
         {
            AddWhere(sWhereString, "(T1.CustomerCustomizationId >= :AV51Customercustomizationwwds_2_tfcustomercustomizationid)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ! (0==AV52Customercustomizationwwds_3_tfcustomercustomizationid_to) )
         {
            AddWhere(sWhereString, "(T1.CustomerCustomizationId <= :AV52Customercustomizationwwds_3_tfcustomercustomizationid_to)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Customercustomizationwwds_4_tfcustomercustomizationbasecolor)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerCustomizationBaseColor like :lV53Customercustomizationwwds_4_tfcustomercustomizationbasecolo)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel)) && ! ( StringUtil.StrCmp(AV54Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerCustomizationBaseColor = ( :AV54Customercustomizationwwds_5_tfcustomercustomizationbasecolo))");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( StringUtil.StrCmp(AV54Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CustomerCustomizationBaseColor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Customercustomizationwwds_6_tfcustomercustomizationfontsize)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerCustomizationFontSize like :lV55Customercustomizationwwds_6_tfcustomercustomizationfontsize)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel)) && ! ( StringUtil.StrCmp(AV56Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerCustomizationFontSize = ( :AV56Customercustomizationwwds_7_tfcustomercustomizationfontsize))");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( StringUtil.StrCmp(AV56Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CustomerCustomizationFontSize))=0))");
         }
         if ( ! (0==AV57Customercustomizationwwds_8_tfcustomerid) )
         {
            AddWhere(sWhereString, "(T1.CustomerId >= :AV57Customercustomizationwwds_8_tfcustomerid)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( ! (0==AV58Customercustomizationwwds_9_tfcustomerid_to) )
         {
            AddWhere(sWhereString, "(T1.CustomerId <= :AV58Customercustomizationwwds_9_tfcustomerid_to)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Customercustomizationwwds_11_tfcustomername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Customercustomizationwwds_10_tfcustomername)) ) )
         {
            AddWhere(sWhereString, "(T2.CustomerName like :lV59Customercustomizationwwds_10_tfcustomername)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Customercustomizationwwds_11_tfcustomername_sel)) && ! ( StringUtil.StrCmp(AV60Customercustomizationwwds_11_tfcustomername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CustomerName = ( :AV60Customercustomizationwwds_11_tfcustomername_sel))");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( StringUtil.StrCmp(AV60Customercustomizationwwds_11_tfcustomername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.CustomerName))=0))");
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.CustomerCustomizationBaseColor, T1.CustomerCustomizationId";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.CustomerCustomizationBaseColor DESC, T1.CustomerCustomizationId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.CustomerCustomizationId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.CustomerCustomizationId DESC";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.CustomerCustomizationFontSize, T1.CustomerCustomizationId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.CustomerCustomizationFontSize DESC, T1.CustomerCustomizationId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.CustomerId, T1.CustomerCustomizationId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.CustomerId DESC, T1.CustomerCustomizationId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T2.CustomerName, T1.CustomerCustomizationId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.CustomerName DESC, T1.CustomerCustomizationId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.CustomerCustomizationId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_H003J3( IGxContext context ,
                                             string AV50Customercustomizationwwds_1_filterfulltext ,
                                             short AV51Customercustomizationwwds_2_tfcustomercustomizationid ,
                                             short AV52Customercustomizationwwds_3_tfcustomercustomizationid_to ,
                                             string AV54Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel ,
                                             string AV53Customercustomizationwwds_4_tfcustomercustomizationbasecolor ,
                                             string AV56Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel ,
                                             string AV55Customercustomizationwwds_6_tfcustomercustomizationfontsize ,
                                             short AV57Customercustomizationwwds_8_tfcustomerid ,
                                             short AV58Customercustomizationwwds_9_tfcustomerid_to ,
                                             string AV60Customercustomizationwwds_11_tfcustomername_sel ,
                                             string AV59Customercustomizationwwds_10_tfcustomername ,
                                             short A128CustomerCustomizationId ,
                                             string A131CustomerCustomizationBaseColor ,
                                             string A132CustomerCustomizationFontSize ,
                                             short A1CustomerId ,
                                             string A3CustomerName ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[15];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (CustomerCustomization T1 INNER JOIN Customer T2 ON T2.CustomerId = T1.CustomerId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Customercustomizationwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.CustomerCustomizationId,'9999'), 2) like '%' || :lV50Customercustomizationwwds_1_filterfulltext) or ( T1.CustomerCustomizationBaseColor like '%' || :lV50Customercustomizationwwds_1_filterfulltext) or ( T1.CustomerCustomizationFontSize like '%' || :lV50Customercustomizationwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.CustomerId,'9999'), 2) like '%' || :lV50Customercustomizationwwds_1_filterfulltext) or ( T2.CustomerName like '%' || :lV50Customercustomizationwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int9[0] = 1;
            GXv_int9[1] = 1;
            GXv_int9[2] = 1;
            GXv_int9[3] = 1;
            GXv_int9[4] = 1;
         }
         if ( ! (0==AV51Customercustomizationwwds_2_tfcustomercustomizationid) )
         {
            AddWhere(sWhereString, "(T1.CustomerCustomizationId >= :AV51Customercustomizationwwds_2_tfcustomercustomizationid)");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( ! (0==AV52Customercustomizationwwds_3_tfcustomercustomizationid_to) )
         {
            AddWhere(sWhereString, "(T1.CustomerCustomizationId <= :AV52Customercustomizationwwds_3_tfcustomercustomizationid_to)");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Customercustomizationwwds_4_tfcustomercustomizationbasecolor)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerCustomizationBaseColor like :lV53Customercustomizationwwds_4_tfcustomercustomizationbasecolo)");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel)) && ! ( StringUtil.StrCmp(AV54Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerCustomizationBaseColor = ( :AV54Customercustomizationwwds_5_tfcustomercustomizationbasecolo))");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( StringUtil.StrCmp(AV54Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CustomerCustomizationBaseColor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Customercustomizationwwds_6_tfcustomercustomizationfontsize)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerCustomizationFontSize like :lV55Customercustomizationwwds_6_tfcustomercustomizationfontsize)");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel)) && ! ( StringUtil.StrCmp(AV56Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerCustomizationFontSize = ( :AV56Customercustomizationwwds_7_tfcustomercustomizationfontsize))");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( StringUtil.StrCmp(AV56Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CustomerCustomizationFontSize))=0))");
         }
         if ( ! (0==AV57Customercustomizationwwds_8_tfcustomerid) )
         {
            AddWhere(sWhereString, "(T1.CustomerId >= :AV57Customercustomizationwwds_8_tfcustomerid)");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( ! (0==AV58Customercustomizationwwds_9_tfcustomerid_to) )
         {
            AddWhere(sWhereString, "(T1.CustomerId <= :AV58Customercustomizationwwds_9_tfcustomerid_to)");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Customercustomizationwwds_11_tfcustomername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Customercustomizationwwds_10_tfcustomername)) ) )
         {
            AddWhere(sWhereString, "(T2.CustomerName like :lV59Customercustomizationwwds_10_tfcustomername)");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Customercustomizationwwds_11_tfcustomername_sel)) && ! ( StringUtil.StrCmp(AV60Customercustomizationwwds_11_tfcustomername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CustomerName = ( :AV60Customercustomizationwwds_11_tfcustomername_sel))");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( StringUtil.StrCmp(AV60Customercustomizationwwds_11_tfcustomername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.CustomerName))=0))");
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
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H003J2(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (bool)dynConstraints[17] );
               case 1 :
                     return conditional_H003J3(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (bool)dynConstraints[17] );
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
          Object[] prmH003J2;
          prmH003J2 = new Object[] {
          new ParDef("lV50Customercustomizationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Customercustomizationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Customercustomizationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Customercustomizationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Customercustomizationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV51Customercustomizationwwds_2_tfcustomercustomizationid",GXType.Int16,4,0) ,
          new ParDef("AV52Customercustomizationwwds_3_tfcustomercustomizationid_to",GXType.Int16,4,0) ,
          new ParDef("lV53Customercustomizationwwds_4_tfcustomercustomizationbasecolo",GXType.VarChar,40,0) ,
          new ParDef("AV54Customercustomizationwwds_5_tfcustomercustomizationbasecolo",GXType.VarChar,40,0) ,
          new ParDef("lV55Customercustomizationwwds_6_tfcustomercustomizationfontsize",GXType.VarChar,40,0) ,
          new ParDef("AV56Customercustomizationwwds_7_tfcustomercustomizationfontsize",GXType.VarChar,40,0) ,
          new ParDef("AV57Customercustomizationwwds_8_tfcustomerid",GXType.Int16,4,0) ,
          new ParDef("AV58Customercustomizationwwds_9_tfcustomerid_to",GXType.Int16,4,0) ,
          new ParDef("lV59Customercustomizationwwds_10_tfcustomername",GXType.VarChar,40,0) ,
          new ParDef("AV60Customercustomizationwwds_11_tfcustomername_sel",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH003J3;
          prmH003J3 = new Object[] {
          new ParDef("lV50Customercustomizationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Customercustomizationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Customercustomizationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Customercustomizationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Customercustomizationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV51Customercustomizationwwds_2_tfcustomercustomizationid",GXType.Int16,4,0) ,
          new ParDef("AV52Customercustomizationwwds_3_tfcustomercustomizationid_to",GXType.Int16,4,0) ,
          new ParDef("lV53Customercustomizationwwds_4_tfcustomercustomizationbasecolo",GXType.VarChar,40,0) ,
          new ParDef("AV54Customercustomizationwwds_5_tfcustomercustomizationbasecolo",GXType.VarChar,40,0) ,
          new ParDef("lV55Customercustomizationwwds_6_tfcustomercustomizationfontsize",GXType.VarChar,40,0) ,
          new ParDef("AV56Customercustomizationwwds_7_tfcustomercustomizationfontsize",GXType.VarChar,40,0) ,
          new ParDef("AV57Customercustomizationwwds_8_tfcustomerid",GXType.Int16,4,0) ,
          new ParDef("AV58Customercustomizationwwds_9_tfcustomerid_to",GXType.Int16,4,0) ,
          new ParDef("lV59Customercustomizationwwds_10_tfcustomername",GXType.VarChar,40,0) ,
          new ParDef("AV60Customercustomizationwwds_11_tfcustomername_sel",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("H003J2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003J2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003J3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003J3,1, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(5));
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(6));
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
