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
   public class residentww : GXDataArea
   {
      public residentww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public residentww( IGxContext context )
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
         AV69Pgmname = GetPar( "Pgmname");
         AV27TFResidentBsnNumber = GetPar( "TFResidentBsnNumber");
         AV28TFResidentBsnNumber_Sel = GetPar( "TFResidentBsnNumber_Sel");
         AV29TFResidentGivenName = GetPar( "TFResidentGivenName");
         AV30TFResidentGivenName_Sel = GetPar( "TFResidentGivenName_Sel");
         AV31TFResidentLastName = GetPar( "TFResidentLastName");
         AV32TFResidentLastName_Sel = GetPar( "TFResidentLastName_Sel");
         AV35TFResidentEmail = GetPar( "TFResidentEmail");
         AV36TFResidentEmail_Sel = GetPar( "TFResidentEmail_Sel");
         AV37TFResidentAddress = GetPar( "TFResidentAddress");
         AV38TFResidentAddress_Sel = GetPar( "TFResidentAddress_Sel");
         AV39TFResidentPhone = GetPar( "TFResidentPhone");
         AV40TFResidentPhone_Sel = GetPar( "TFResidentPhone_Sel");
         AV43TFResidentTypeName = GetPar( "TFResidentTypeName");
         AV44TFResidentTypeName_Sel = GetPar( "TFResidentTypeName_Sel");
         AV13OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV14OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV53IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV55IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV56IsAuthorized_ResidentTypeName = StringUtil.StrToBool( GetPar( "IsAuthorized_ResidentTypeName"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV69Pgmname, AV27TFResidentBsnNumber, AV28TFResidentBsnNumber_Sel, AV29TFResidentGivenName, AV30TFResidentGivenName_Sel, AV31TFResidentLastName, AV32TFResidentLastName_Sel, AV35TFResidentEmail, AV36TFResidentEmail_Sel, AV37TFResidentAddress, AV38TFResidentAddress_Sel, AV39TFResidentPhone, AV40TFResidentPhone_Sel, AV43TFResidentTypeName, AV44TFResidentTypeName_Sel, AV13OrderedBy, AV14OrderedDsc, AV53IsAuthorized_Update, AV55IsAuthorized_Delete, AV56IsAuthorized_ResidentTypeName) ;
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
            return "residentww_Execute" ;
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
         PA1K2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1K2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("residentww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV69Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV69Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV53IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV53IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV55IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV55IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_RESIDENTTYPENAME", AV56IsAuthorized_ResidentTypeName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_RESIDENTTYPENAME", GetSecureSignedToken( "", AV56IsAuthorized_ResidentTypeName, context));
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
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV49GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV50GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV51GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV45DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV45DDO_TitleSettingsIcons);
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV69Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV69Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFRESIDENTBSNNUMBER", AV27TFResidentBsnNumber);
         GxWebStd.gx_hidden_field( context, "vTFRESIDENTBSNNUMBER_SEL", AV28TFResidentBsnNumber_Sel);
         GxWebStd.gx_hidden_field( context, "vTFRESIDENTGIVENNAME", AV29TFResidentGivenName);
         GxWebStd.gx_hidden_field( context, "vTFRESIDENTGIVENNAME_SEL", AV30TFResidentGivenName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFRESIDENTLASTNAME", AV31TFResidentLastName);
         GxWebStd.gx_hidden_field( context, "vTFRESIDENTLASTNAME_SEL", AV32TFResidentLastName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFRESIDENTEMAIL", AV35TFResidentEmail);
         GxWebStd.gx_hidden_field( context, "vTFRESIDENTEMAIL_SEL", AV36TFResidentEmail_Sel);
         GxWebStd.gx_hidden_field( context, "vTFRESIDENTADDRESS", AV37TFResidentAddress);
         GxWebStd.gx_hidden_field( context, "vTFRESIDENTADDRESS_SEL", AV38TFResidentAddress_Sel);
         GxWebStd.gx_hidden_field( context, "vTFRESIDENTPHONE", StringUtil.RTrim( AV39TFResidentPhone));
         GxWebStd.gx_hidden_field( context, "vTFRESIDENTPHONE_SEL", StringUtil.RTrim( AV40TFResidentPhone_Sel));
         GxWebStd.gx_hidden_field( context, "vTFRESIDENTTYPENAME", AV43TFResidentTypeName);
         GxWebStd.gx_hidden_field( context, "vTFRESIDENTTYPENAME_SEL", AV44TFResidentTypeName_Sel);
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV53IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV53IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV55IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV55IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_RESIDENTTYPENAME", AV56IsAuthorized_ResidentTypeName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_RESIDENTTYPENAME", GetSecureSignedToken( "", AV56IsAuthorized_ResidentTypeName, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
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
            WE1K2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1K2( ) ;
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
         return formatLink("residentww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "ResidentWW" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( " Residents", "") ;
      }

      protected void WB1K0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtncreateresidentaction_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", context.GetMessage( "Insert", ""), bttBtncreateresidentaction_Jsonclick, 7, context.GetMessage( "Insert", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e111k1_client"+"'", TempTags, "", 2, "HLP_ResidentWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_ResidentWW.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV16FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV16FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_ResidentWW.htm");
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV49GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV50GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV51GridAppliedFilters);
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
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV45DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV45DDO_TitleSettingsIcons);
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

      protected void START1K2( )
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
         Form.Meta.addItem("description", context.GetMessage( " Residents", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1K0( ) ;
      }

      protected void WS1K2( )
      {
         START1K2( ) ;
         EVT1K2( ) ;
      }

      protected void EVT1K2( )
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
                              E121K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E131K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E141K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E151K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E161K2 ();
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
                              AV66viewQrCode = cgiGet( edtavViewqrcode_Internalname);
                              AssignAttri("", false, edtavViewqrcode_Internalname, AV66viewQrCode);
                              A31ResidentId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtResidentId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A40ResidentBsnNumber = cgiGet( edtResidentBsnNumber_Internalname);
                              A33ResidentGivenName = cgiGet( edtResidentGivenName_Internalname);
                              A34ResidentLastName = cgiGet( edtResidentLastName_Internalname);
                              A35ResidentInitials = cgiGet( edtResidentInitials_Internalname);
                              n35ResidentInitials = false;
                              A36ResidentEmail = cgiGet( edtResidentEmail_Internalname);
                              A37ResidentAddress = cgiGet( edtResidentAddress_Internalname);
                              n37ResidentAddress = false;
                              A38ResidentPhone = cgiGet( edtResidentPhone_Internalname);
                              n38ResidentPhone = false;
                              A39ResidentGAMGUID = cgiGet( edtResidentGAMGUID_Internalname);
                              A82ResidentTypeId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtResidentTypeId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A83ResidentTypeName = cgiGet( edtResidentTypeName_Internalname);
                              A1CustomerId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCustomerId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A3CustomerName = cgiGet( edtCustomerName_Internalname);
                              A18CustomerLocationId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCustomerLocationId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              AV52Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV52Update);
                              AV54Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri("", false, edtavDelete_Internalname, AV54Delete);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E171K2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E181K2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E191K2 ();
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

      protected void WE1K2( )
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

      protected void PA1K2( )
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
                                       string AV69Pgmname ,
                                       string AV27TFResidentBsnNumber ,
                                       string AV28TFResidentBsnNumber_Sel ,
                                       string AV29TFResidentGivenName ,
                                       string AV30TFResidentGivenName_Sel ,
                                       string AV31TFResidentLastName ,
                                       string AV32TFResidentLastName_Sel ,
                                       string AV35TFResidentEmail ,
                                       string AV36TFResidentEmail_Sel ,
                                       string AV37TFResidentAddress ,
                                       string AV38TFResidentAddress_Sel ,
                                       string AV39TFResidentPhone ,
                                       string AV40TFResidentPhone_Sel ,
                                       string AV43TFResidentTypeName ,
                                       string AV44TFResidentTypeName_Sel ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       bool AV53IsAuthorized_Update ,
                                       bool AV55IsAuthorized_Delete ,
                                       bool AV56IsAuthorized_ResidentTypeName )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF1K2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_RESIDENTEMAIL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A36ResidentEmail, "")), context));
         GxWebStd.gx_hidden_field( context, "RESIDENTEMAIL", A36ResidentEmail);
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
         RF1K2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV69Pgmname = "ResidentWW";
         edtavViewqrcode_Enabled = 0;
         AssignProp("", false, edtavViewqrcode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavViewqrcode_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         edtavUpdate_Enabled = 0;
         AssignProp("", false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         edtavDelete_Enabled = 0;
         AssignProp("", false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_37_Refreshing);
      }

      protected void RF1K2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 37;
         /* Execute user event: Refresh */
         E181K2 ();
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
                                                 AV70Residentwwds_3_filterfulltext ,
                                                 AV72Residentwwds_5_tfresidentbsnnumber_sel ,
                                                 AV71Residentwwds_4_tfresidentbsnnumber ,
                                                 AV74Residentwwds_7_tfresidentgivenname_sel ,
                                                 AV73Residentwwds_6_tfresidentgivenname ,
                                                 AV76Residentwwds_9_tfresidentlastname_sel ,
                                                 AV75Residentwwds_8_tfresidentlastname ,
                                                 AV78Residentwwds_11_tfresidentemail_sel ,
                                                 AV77Residentwwds_10_tfresidentemail ,
                                                 AV80Residentwwds_13_tfresidentaddress_sel ,
                                                 AV79Residentwwds_12_tfresidentaddress ,
                                                 AV82Residentwwds_15_tfresidentphone_sel ,
                                                 AV81Residentwwds_14_tfresidentphone ,
                                                 AV84Residentwwds_17_tfresidenttypename_sel ,
                                                 AV83Residentwwds_16_tfresidenttypename ,
                                                 A40ResidentBsnNumber ,
                                                 A33ResidentGivenName ,
                                                 A34ResidentLastName ,
                                                 A36ResidentEmail ,
                                                 A37ResidentAddress ,
                                                 A38ResidentPhone ,
                                                 A83ResidentTypeName ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc ,
                                                 A1CustomerId ,
                                                 AV67Udparg1 ,
                                                 A18CustomerLocationId ,
                                                 AV68Udparg2 } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV70Residentwwds_3_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Residentwwds_3_filterfulltext), "%", "");
            lV70Residentwwds_3_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Residentwwds_3_filterfulltext), "%", "");
            lV70Residentwwds_3_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Residentwwds_3_filterfulltext), "%", "");
            lV70Residentwwds_3_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Residentwwds_3_filterfulltext), "%", "");
            lV70Residentwwds_3_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Residentwwds_3_filterfulltext), "%", "");
            lV70Residentwwds_3_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Residentwwds_3_filterfulltext), "%", "");
            lV70Residentwwds_3_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Residentwwds_3_filterfulltext), "%", "");
            lV71Residentwwds_4_tfresidentbsnnumber = StringUtil.Concat( StringUtil.RTrim( AV71Residentwwds_4_tfresidentbsnnumber), "%", "");
            lV73Residentwwds_6_tfresidentgivenname = StringUtil.Concat( StringUtil.RTrim( AV73Residentwwds_6_tfresidentgivenname), "%", "");
            lV75Residentwwds_8_tfresidentlastname = StringUtil.Concat( StringUtil.RTrim( AV75Residentwwds_8_tfresidentlastname), "%", "");
            lV77Residentwwds_10_tfresidentemail = StringUtil.Concat( StringUtil.RTrim( AV77Residentwwds_10_tfresidentemail), "%", "");
            lV79Residentwwds_12_tfresidentaddress = StringUtil.Concat( StringUtil.RTrim( AV79Residentwwds_12_tfresidentaddress), "%", "");
            lV81Residentwwds_14_tfresidentphone = StringUtil.PadR( StringUtil.RTrim( AV81Residentwwds_14_tfresidentphone), 20, "%");
            lV83Residentwwds_16_tfresidenttypename = StringUtil.Concat( StringUtil.RTrim( AV83Residentwwds_16_tfresidenttypename), "%", "");
            /* Using cursor H001K2 */
            pr_default.execute(0, new Object[] {AV67Udparg1, AV68Udparg2, lV70Residentwwds_3_filterfulltext, lV70Residentwwds_3_filterfulltext, lV70Residentwwds_3_filterfulltext, lV70Residentwwds_3_filterfulltext, lV70Residentwwds_3_filterfulltext, lV70Residentwwds_3_filterfulltext, lV70Residentwwds_3_filterfulltext, lV71Residentwwds_4_tfresidentbsnnumber, AV72Residentwwds_5_tfresidentbsnnumber_sel, lV73Residentwwds_6_tfresidentgivenname, AV74Residentwwds_7_tfresidentgivenname_sel, lV75Residentwwds_8_tfresidentlastname, AV76Residentwwds_9_tfresidentlastname_sel, lV77Residentwwds_10_tfresidentemail, AV78Residentwwds_11_tfresidentemail_sel, lV79Residentwwds_12_tfresidentaddress, AV80Residentwwds_13_tfresidentaddress_sel, lV81Residentwwds_14_tfresidentphone, AV82Residentwwds_15_tfresidentphone_sel, lV83Residentwwds_16_tfresidenttypename, AV84Residentwwds_17_tfresidenttypename_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_37_idx = 1;
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A18CustomerLocationId = H001K2_A18CustomerLocationId[0];
               A3CustomerName = H001K2_A3CustomerName[0];
               A1CustomerId = H001K2_A1CustomerId[0];
               A83ResidentTypeName = H001K2_A83ResidentTypeName[0];
               A82ResidentTypeId = H001K2_A82ResidentTypeId[0];
               A39ResidentGAMGUID = H001K2_A39ResidentGAMGUID[0];
               A38ResidentPhone = H001K2_A38ResidentPhone[0];
               n38ResidentPhone = H001K2_n38ResidentPhone[0];
               A37ResidentAddress = H001K2_A37ResidentAddress[0];
               n37ResidentAddress = H001K2_n37ResidentAddress[0];
               A36ResidentEmail = H001K2_A36ResidentEmail[0];
               A35ResidentInitials = H001K2_A35ResidentInitials[0];
               n35ResidentInitials = H001K2_n35ResidentInitials[0];
               A34ResidentLastName = H001K2_A34ResidentLastName[0];
               A33ResidentGivenName = H001K2_A33ResidentGivenName[0];
               A40ResidentBsnNumber = H001K2_A40ResidentBsnNumber[0];
               A31ResidentId = H001K2_A31ResidentId[0];
               A3CustomerName = H001K2_A3CustomerName[0];
               A83ResidentTypeName = H001K2_A83ResidentTypeName[0];
               E191K2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 37;
            WB1K0( ) ;
         }
         bGXsfl_37_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1K2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV69Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV69Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV53IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV53IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV55IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV55IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_RESIDENTTYPENAME", AV56IsAuthorized_ResidentTypeName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_RESIDENTTYPENAME", GetSecureSignedToken( "", AV56IsAuthorized_ResidentTypeName, context));
         GxWebStd.gx_hidden_field( context, "gxhash_RESIDENTEMAIL"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, StringUtil.RTrim( context.localUtil.Format( A36ResidentEmail, "")), context));
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
         AV70Residentwwds_3_filterfulltext = AV16FilterFullText;
         AV71Residentwwds_4_tfresidentbsnnumber = AV27TFResidentBsnNumber;
         AV72Residentwwds_5_tfresidentbsnnumber_sel = AV28TFResidentBsnNumber_Sel;
         AV73Residentwwds_6_tfresidentgivenname = AV29TFResidentGivenName;
         AV74Residentwwds_7_tfresidentgivenname_sel = AV30TFResidentGivenName_Sel;
         AV75Residentwwds_8_tfresidentlastname = AV31TFResidentLastName;
         AV76Residentwwds_9_tfresidentlastname_sel = AV32TFResidentLastName_Sel;
         AV77Residentwwds_10_tfresidentemail = AV35TFResidentEmail;
         AV78Residentwwds_11_tfresidentemail_sel = AV36TFResidentEmail_Sel;
         AV79Residentwwds_12_tfresidentaddress = AV37TFResidentAddress;
         AV80Residentwwds_13_tfresidentaddress_sel = AV38TFResidentAddress_Sel;
         AV81Residentwwds_14_tfresidentphone = AV39TFResidentPhone;
         AV82Residentwwds_15_tfresidentphone_sel = AV40TFResidentPhone_Sel;
         AV83Residentwwds_16_tfresidenttypename = AV43TFResidentTypeName;
         AV84Residentwwds_17_tfresidenttypename_sel = AV44TFResidentTypeName_Sel;
         AV67Udparg1 = new getloggedinusercustomerid(context).executeUdp( );
         AV68Udparg2 = new getreceptionistlocationid(context).executeUdp( );
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV70Residentwwds_3_filterfulltext ,
                                              AV72Residentwwds_5_tfresidentbsnnumber_sel ,
                                              AV71Residentwwds_4_tfresidentbsnnumber ,
                                              AV74Residentwwds_7_tfresidentgivenname_sel ,
                                              AV73Residentwwds_6_tfresidentgivenname ,
                                              AV76Residentwwds_9_tfresidentlastname_sel ,
                                              AV75Residentwwds_8_tfresidentlastname ,
                                              AV78Residentwwds_11_tfresidentemail_sel ,
                                              AV77Residentwwds_10_tfresidentemail ,
                                              AV80Residentwwds_13_tfresidentaddress_sel ,
                                              AV79Residentwwds_12_tfresidentaddress ,
                                              AV82Residentwwds_15_tfresidentphone_sel ,
                                              AV81Residentwwds_14_tfresidentphone ,
                                              AV84Residentwwds_17_tfresidenttypename_sel ,
                                              AV83Residentwwds_16_tfresidenttypename ,
                                              A40ResidentBsnNumber ,
                                              A33ResidentGivenName ,
                                              A34ResidentLastName ,
                                              A36ResidentEmail ,
                                              A37ResidentAddress ,
                                              A38ResidentPhone ,
                                              A83ResidentTypeName ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc ,
                                              A1CustomerId ,
                                              AV67Udparg1 ,
                                              A18CustomerLocationId ,
                                              AV68Udparg2 } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV70Residentwwds_3_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Residentwwds_3_filterfulltext), "%", "");
         lV70Residentwwds_3_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Residentwwds_3_filterfulltext), "%", "");
         lV70Residentwwds_3_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Residentwwds_3_filterfulltext), "%", "");
         lV70Residentwwds_3_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Residentwwds_3_filterfulltext), "%", "");
         lV70Residentwwds_3_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Residentwwds_3_filterfulltext), "%", "");
         lV70Residentwwds_3_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Residentwwds_3_filterfulltext), "%", "");
         lV70Residentwwds_3_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Residentwwds_3_filterfulltext), "%", "");
         lV71Residentwwds_4_tfresidentbsnnumber = StringUtil.Concat( StringUtil.RTrim( AV71Residentwwds_4_tfresidentbsnnumber), "%", "");
         lV73Residentwwds_6_tfresidentgivenname = StringUtil.Concat( StringUtil.RTrim( AV73Residentwwds_6_tfresidentgivenname), "%", "");
         lV75Residentwwds_8_tfresidentlastname = StringUtil.Concat( StringUtil.RTrim( AV75Residentwwds_8_tfresidentlastname), "%", "");
         lV77Residentwwds_10_tfresidentemail = StringUtil.Concat( StringUtil.RTrim( AV77Residentwwds_10_tfresidentemail), "%", "");
         lV79Residentwwds_12_tfresidentaddress = StringUtil.Concat( StringUtil.RTrim( AV79Residentwwds_12_tfresidentaddress), "%", "");
         lV81Residentwwds_14_tfresidentphone = StringUtil.PadR( StringUtil.RTrim( AV81Residentwwds_14_tfresidentphone), 20, "%");
         lV83Residentwwds_16_tfresidenttypename = StringUtil.Concat( StringUtil.RTrim( AV83Residentwwds_16_tfresidenttypename), "%", "");
         /* Using cursor H001K3 */
         pr_default.execute(1, new Object[] {AV67Udparg1, AV68Udparg2, lV70Residentwwds_3_filterfulltext, lV70Residentwwds_3_filterfulltext, lV70Residentwwds_3_filterfulltext, lV70Residentwwds_3_filterfulltext, lV70Residentwwds_3_filterfulltext, lV70Residentwwds_3_filterfulltext, lV70Residentwwds_3_filterfulltext, lV71Residentwwds_4_tfresidentbsnnumber, AV72Residentwwds_5_tfresidentbsnnumber_sel, lV73Residentwwds_6_tfresidentgivenname, AV74Residentwwds_7_tfresidentgivenname_sel, lV75Residentwwds_8_tfresidentlastname, AV76Residentwwds_9_tfresidentlastname_sel, lV77Residentwwds_10_tfresidentemail, AV78Residentwwds_11_tfresidentemail_sel, lV79Residentwwds_12_tfresidentaddress, AV80Residentwwds_13_tfresidentaddress_sel, lV81Residentwwds_14_tfresidentphone, AV82Residentwwds_15_tfresidentphone_sel, lV83Residentwwds_16_tfresidenttypename, AV84Residentwwds_17_tfresidenttypename_sel});
         GRID_nRecordCount = H001K3_AGRID_nRecordCount[0];
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
         AV70Residentwwds_3_filterfulltext = AV16FilterFullText;
         AV71Residentwwds_4_tfresidentbsnnumber = AV27TFResidentBsnNumber;
         AV72Residentwwds_5_tfresidentbsnnumber_sel = AV28TFResidentBsnNumber_Sel;
         AV73Residentwwds_6_tfresidentgivenname = AV29TFResidentGivenName;
         AV74Residentwwds_7_tfresidentgivenname_sel = AV30TFResidentGivenName_Sel;
         AV75Residentwwds_8_tfresidentlastname = AV31TFResidentLastName;
         AV76Residentwwds_9_tfresidentlastname_sel = AV32TFResidentLastName_Sel;
         AV77Residentwwds_10_tfresidentemail = AV35TFResidentEmail;
         AV78Residentwwds_11_tfresidentemail_sel = AV36TFResidentEmail_Sel;
         AV79Residentwwds_12_tfresidentaddress = AV37TFResidentAddress;
         AV80Residentwwds_13_tfresidentaddress_sel = AV38TFResidentAddress_Sel;
         AV81Residentwwds_14_tfresidentphone = AV39TFResidentPhone;
         AV82Residentwwds_15_tfresidentphone_sel = AV40TFResidentPhone_Sel;
         AV83Residentwwds_16_tfresidenttypename = AV43TFResidentTypeName;
         AV84Residentwwds_17_tfresidenttypename_sel = AV44TFResidentTypeName_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV69Pgmname, AV27TFResidentBsnNumber, AV28TFResidentBsnNumber_Sel, AV29TFResidentGivenName, AV30TFResidentGivenName_Sel, AV31TFResidentLastName, AV32TFResidentLastName_Sel, AV35TFResidentEmail, AV36TFResidentEmail_Sel, AV37TFResidentAddress, AV38TFResidentAddress_Sel, AV39TFResidentPhone, AV40TFResidentPhone_Sel, AV43TFResidentTypeName, AV44TFResidentTypeName_Sel, AV13OrderedBy, AV14OrderedDsc, AV53IsAuthorized_Update, AV55IsAuthorized_Delete, AV56IsAuthorized_ResidentTypeName) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV70Residentwwds_3_filterfulltext = AV16FilterFullText;
         AV71Residentwwds_4_tfresidentbsnnumber = AV27TFResidentBsnNumber;
         AV72Residentwwds_5_tfresidentbsnnumber_sel = AV28TFResidentBsnNumber_Sel;
         AV73Residentwwds_6_tfresidentgivenname = AV29TFResidentGivenName;
         AV74Residentwwds_7_tfresidentgivenname_sel = AV30TFResidentGivenName_Sel;
         AV75Residentwwds_8_tfresidentlastname = AV31TFResidentLastName;
         AV76Residentwwds_9_tfresidentlastname_sel = AV32TFResidentLastName_Sel;
         AV77Residentwwds_10_tfresidentemail = AV35TFResidentEmail;
         AV78Residentwwds_11_tfresidentemail_sel = AV36TFResidentEmail_Sel;
         AV79Residentwwds_12_tfresidentaddress = AV37TFResidentAddress;
         AV80Residentwwds_13_tfresidentaddress_sel = AV38TFResidentAddress_Sel;
         AV81Residentwwds_14_tfresidentphone = AV39TFResidentPhone;
         AV82Residentwwds_15_tfresidentphone_sel = AV40TFResidentPhone_Sel;
         AV83Residentwwds_16_tfresidenttypename = AV43TFResidentTypeName;
         AV84Residentwwds_17_tfresidenttypename_sel = AV44TFResidentTypeName_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV69Pgmname, AV27TFResidentBsnNumber, AV28TFResidentBsnNumber_Sel, AV29TFResidentGivenName, AV30TFResidentGivenName_Sel, AV31TFResidentLastName, AV32TFResidentLastName_Sel, AV35TFResidentEmail, AV36TFResidentEmail_Sel, AV37TFResidentAddress, AV38TFResidentAddress_Sel, AV39TFResidentPhone, AV40TFResidentPhone_Sel, AV43TFResidentTypeName, AV44TFResidentTypeName_Sel, AV13OrderedBy, AV14OrderedDsc, AV53IsAuthorized_Update, AV55IsAuthorized_Delete, AV56IsAuthorized_ResidentTypeName) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV70Residentwwds_3_filterfulltext = AV16FilterFullText;
         AV71Residentwwds_4_tfresidentbsnnumber = AV27TFResidentBsnNumber;
         AV72Residentwwds_5_tfresidentbsnnumber_sel = AV28TFResidentBsnNumber_Sel;
         AV73Residentwwds_6_tfresidentgivenname = AV29TFResidentGivenName;
         AV74Residentwwds_7_tfresidentgivenname_sel = AV30TFResidentGivenName_Sel;
         AV75Residentwwds_8_tfresidentlastname = AV31TFResidentLastName;
         AV76Residentwwds_9_tfresidentlastname_sel = AV32TFResidentLastName_Sel;
         AV77Residentwwds_10_tfresidentemail = AV35TFResidentEmail;
         AV78Residentwwds_11_tfresidentemail_sel = AV36TFResidentEmail_Sel;
         AV79Residentwwds_12_tfresidentaddress = AV37TFResidentAddress;
         AV80Residentwwds_13_tfresidentaddress_sel = AV38TFResidentAddress_Sel;
         AV81Residentwwds_14_tfresidentphone = AV39TFResidentPhone;
         AV82Residentwwds_15_tfresidentphone_sel = AV40TFResidentPhone_Sel;
         AV83Residentwwds_16_tfresidenttypename = AV43TFResidentTypeName;
         AV84Residentwwds_17_tfresidenttypename_sel = AV44TFResidentTypeName_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV69Pgmname, AV27TFResidentBsnNumber, AV28TFResidentBsnNumber_Sel, AV29TFResidentGivenName, AV30TFResidentGivenName_Sel, AV31TFResidentLastName, AV32TFResidentLastName_Sel, AV35TFResidentEmail, AV36TFResidentEmail_Sel, AV37TFResidentAddress, AV38TFResidentAddress_Sel, AV39TFResidentPhone, AV40TFResidentPhone_Sel, AV43TFResidentTypeName, AV44TFResidentTypeName_Sel, AV13OrderedBy, AV14OrderedDsc, AV53IsAuthorized_Update, AV55IsAuthorized_Delete, AV56IsAuthorized_ResidentTypeName) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV70Residentwwds_3_filterfulltext = AV16FilterFullText;
         AV71Residentwwds_4_tfresidentbsnnumber = AV27TFResidentBsnNumber;
         AV72Residentwwds_5_tfresidentbsnnumber_sel = AV28TFResidentBsnNumber_Sel;
         AV73Residentwwds_6_tfresidentgivenname = AV29TFResidentGivenName;
         AV74Residentwwds_7_tfresidentgivenname_sel = AV30TFResidentGivenName_Sel;
         AV75Residentwwds_8_tfresidentlastname = AV31TFResidentLastName;
         AV76Residentwwds_9_tfresidentlastname_sel = AV32TFResidentLastName_Sel;
         AV77Residentwwds_10_tfresidentemail = AV35TFResidentEmail;
         AV78Residentwwds_11_tfresidentemail_sel = AV36TFResidentEmail_Sel;
         AV79Residentwwds_12_tfresidentaddress = AV37TFResidentAddress;
         AV80Residentwwds_13_tfresidentaddress_sel = AV38TFResidentAddress_Sel;
         AV81Residentwwds_14_tfresidentphone = AV39TFResidentPhone;
         AV82Residentwwds_15_tfresidentphone_sel = AV40TFResidentPhone_Sel;
         AV83Residentwwds_16_tfresidenttypename = AV43TFResidentTypeName;
         AV84Residentwwds_17_tfresidenttypename_sel = AV44TFResidentTypeName_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV69Pgmname, AV27TFResidentBsnNumber, AV28TFResidentBsnNumber_Sel, AV29TFResidentGivenName, AV30TFResidentGivenName_Sel, AV31TFResidentLastName, AV32TFResidentLastName_Sel, AV35TFResidentEmail, AV36TFResidentEmail_Sel, AV37TFResidentAddress, AV38TFResidentAddress_Sel, AV39TFResidentPhone, AV40TFResidentPhone_Sel, AV43TFResidentTypeName, AV44TFResidentTypeName_Sel, AV13OrderedBy, AV14OrderedDsc, AV53IsAuthorized_Update, AV55IsAuthorized_Delete, AV56IsAuthorized_ResidentTypeName) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV70Residentwwds_3_filterfulltext = AV16FilterFullText;
         AV71Residentwwds_4_tfresidentbsnnumber = AV27TFResidentBsnNumber;
         AV72Residentwwds_5_tfresidentbsnnumber_sel = AV28TFResidentBsnNumber_Sel;
         AV73Residentwwds_6_tfresidentgivenname = AV29TFResidentGivenName;
         AV74Residentwwds_7_tfresidentgivenname_sel = AV30TFResidentGivenName_Sel;
         AV75Residentwwds_8_tfresidentlastname = AV31TFResidentLastName;
         AV76Residentwwds_9_tfresidentlastname_sel = AV32TFResidentLastName_Sel;
         AV77Residentwwds_10_tfresidentemail = AV35TFResidentEmail;
         AV78Residentwwds_11_tfresidentemail_sel = AV36TFResidentEmail_Sel;
         AV79Residentwwds_12_tfresidentaddress = AV37TFResidentAddress;
         AV80Residentwwds_13_tfresidentaddress_sel = AV38TFResidentAddress_Sel;
         AV81Residentwwds_14_tfresidentphone = AV39TFResidentPhone;
         AV82Residentwwds_15_tfresidentphone_sel = AV40TFResidentPhone_Sel;
         AV83Residentwwds_16_tfresidenttypename = AV43TFResidentTypeName;
         AV84Residentwwds_17_tfresidenttypename_sel = AV44TFResidentTypeName_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV69Pgmname, AV27TFResidentBsnNumber, AV28TFResidentBsnNumber_Sel, AV29TFResidentGivenName, AV30TFResidentGivenName_Sel, AV31TFResidentLastName, AV32TFResidentLastName_Sel, AV35TFResidentEmail, AV36TFResidentEmail_Sel, AV37TFResidentAddress, AV38TFResidentAddress_Sel, AV39TFResidentPhone, AV40TFResidentPhone_Sel, AV43TFResidentTypeName, AV44TFResidentTypeName_Sel, AV13OrderedBy, AV14OrderedDsc, AV53IsAuthorized_Update, AV55IsAuthorized_Delete, AV56IsAuthorized_ResidentTypeName) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV69Pgmname = "ResidentWW";
         edtavViewqrcode_Enabled = 0;
         AssignProp("", false, edtavViewqrcode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavViewqrcode_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         edtavUpdate_Enabled = 0;
         AssignProp("", false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         edtavDelete_Enabled = 0;
         AssignProp("", false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         edtResidentId_Enabled = 0;
         AssignProp("", false, edtResidentId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentId_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         edtResidentBsnNumber_Enabled = 0;
         AssignProp("", false, edtResidentBsnNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentBsnNumber_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         edtResidentGivenName_Enabled = 0;
         AssignProp("", false, edtResidentGivenName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentGivenName_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         edtResidentLastName_Enabled = 0;
         AssignProp("", false, edtResidentLastName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentLastName_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         edtResidentInitials_Enabled = 0;
         AssignProp("", false, edtResidentInitials_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentInitials_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         edtResidentEmail_Enabled = 0;
         AssignProp("", false, edtResidentEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentEmail_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         edtResidentAddress_Enabled = 0;
         AssignProp("", false, edtResidentAddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentAddress_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         edtResidentPhone_Enabled = 0;
         AssignProp("", false, edtResidentPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentPhone_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         edtResidentGAMGUID_Enabled = 0;
         AssignProp("", false, edtResidentGAMGUID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentGAMGUID_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         edtResidentTypeId_Enabled = 0;
         AssignProp("", false, edtResidentTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentTypeId_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         edtResidentTypeName_Enabled = 0;
         AssignProp("", false, edtResidentTypeName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentTypeName_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         edtCustomerId_Enabled = 0;
         AssignProp("", false, edtCustomerId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerId_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         edtCustomerName_Enabled = 0;
         AssignProp("", false, edtCustomerName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerName_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         edtCustomerLocationId_Enabled = 0;
         AssignProp("", false, edtCustomerLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerLocationId_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1K0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E171K2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV22ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV45DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV19ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_37 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_37"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV49GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV50GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV51GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            Ddo_grid_Includedatalist = cgiGet( "DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( "DDO_GRID_Datalisttype");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
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
         E171K2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E171K2( )
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
         GXt_boolean1 = AV56IsAuthorized_ResidentTypeName;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "residenttypeview_Execute", out  GXt_boolean1) ;
         AV56IsAuthorized_ResidentTypeName = GXt_boolean1;
         AssignAttri("", false, "AV56IsAuthorized_ResidentTypeName", AV56IsAuthorized_ResidentTypeName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_RESIDENTTYPENAME", GetSecureSignedToken( "", AV56IsAuthorized_ResidentTypeName, context));
         AV46GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV47GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV46GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = context.GetMessage( " Residents", "");
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV45DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV45DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E181K2( )
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
         if ( StringUtil.StrCmp(AV21Session.Get("ResidentWWColumnsSelector"), "") != 0 )
         {
            AV17ColumnsSelectorXML = AV21Session.Get("ResidentWWColumnsSelector");
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
         edtResidentBsnNumber_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtResidentBsnNumber_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResidentBsnNumber_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtResidentGivenName_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtResidentGivenName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResidentGivenName_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtResidentLastName_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtResidentLastName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResidentLastName_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtResidentEmail_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtResidentEmail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResidentEmail_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtResidentAddress_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtResidentAddress_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResidentAddress_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtResidentPhone_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtResidentPhone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResidentPhone_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtResidentTypeName_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(7)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtResidentTypeName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResidentTypeName_Visible), 5, 0), !bGXsfl_37_Refreshing);
         AV49GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV49GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV49GridCurrentPage), 10, 0));
         AV50GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV50GridPageCount", StringUtil.LTrimStr( (decimal)(AV50GridPageCount), 10, 0));
         GXt_char3 = AV51GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV69Pgmname, out  GXt_char3) ;
         AV51GridAppliedFilters = GXt_char3;
         AssignAttri("", false, "AV51GridAppliedFilters", AV51GridAppliedFilters);
         AV70Residentwwds_3_filterfulltext = AV16FilterFullText;
         AV71Residentwwds_4_tfresidentbsnnumber = AV27TFResidentBsnNumber;
         AV72Residentwwds_5_tfresidentbsnnumber_sel = AV28TFResidentBsnNumber_Sel;
         AV73Residentwwds_6_tfresidentgivenname = AV29TFResidentGivenName;
         AV74Residentwwds_7_tfresidentgivenname_sel = AV30TFResidentGivenName_Sel;
         AV75Residentwwds_8_tfresidentlastname = AV31TFResidentLastName;
         AV76Residentwwds_9_tfresidentlastname_sel = AV32TFResidentLastName_Sel;
         AV77Residentwwds_10_tfresidentemail = AV35TFResidentEmail;
         AV78Residentwwds_11_tfresidentemail_sel = AV36TFResidentEmail_Sel;
         AV79Residentwwds_12_tfresidentaddress = AV37TFResidentAddress;
         AV80Residentwwds_13_tfresidentaddress_sel = AV38TFResidentAddress_Sel;
         AV81Residentwwds_14_tfresidentphone = AV39TFResidentPhone;
         AV82Residentwwds_15_tfresidentphone_sel = AV40TFResidentPhone_Sel;
         AV83Residentwwds_16_tfresidenttypename = AV43TFResidentTypeName;
         AV84Residentwwds_17_tfresidenttypename_sel = AV44TFResidentTypeName_Sel;
         AV67Udparg1 = new getloggedinusercustomerid(context).executeUdp( );
         AV68Udparg2 = new getreceptionistlocationid(context).executeUdp( );
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ColumnsSelector", AV19ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ManageFiltersData", AV22ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E131K2( )
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
            AV48PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV48PageToGo) ;
         }
      }

      protected void E141K2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E151K2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ResidentBsnNumber") == 0 )
            {
               AV27TFResidentBsnNumber = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV27TFResidentBsnNumber", AV27TFResidentBsnNumber);
               AV28TFResidentBsnNumber_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV28TFResidentBsnNumber_Sel", AV28TFResidentBsnNumber_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ResidentGivenName") == 0 )
            {
               AV29TFResidentGivenName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV29TFResidentGivenName", AV29TFResidentGivenName);
               AV30TFResidentGivenName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV30TFResidentGivenName_Sel", AV30TFResidentGivenName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ResidentLastName") == 0 )
            {
               AV31TFResidentLastName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV31TFResidentLastName", AV31TFResidentLastName);
               AV32TFResidentLastName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV32TFResidentLastName_Sel", AV32TFResidentLastName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ResidentEmail") == 0 )
            {
               AV35TFResidentEmail = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV35TFResidentEmail", AV35TFResidentEmail);
               AV36TFResidentEmail_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV36TFResidentEmail_Sel", AV36TFResidentEmail_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ResidentAddress") == 0 )
            {
               AV37TFResidentAddress = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV37TFResidentAddress", AV37TFResidentAddress);
               AV38TFResidentAddress_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV38TFResidentAddress_Sel", AV38TFResidentAddress_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ResidentPhone") == 0 )
            {
               AV39TFResidentPhone = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV39TFResidentPhone", AV39TFResidentPhone);
               AV40TFResidentPhone_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV40TFResidentPhone_Sel", AV40TFResidentPhone_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ResidentTypeName") == 0 )
            {
               AV43TFResidentTypeName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV43TFResidentTypeName", AV43TFResidentTypeName);
               AV44TFResidentTypeName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV44TFResidentTypeName_Sel", AV44TFResidentTypeName_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E191K2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV66viewQrCode = "<i class=\"fas fa-qrcode\"></i>";
         AssignAttri("", false, edtavViewqrcode_Internalname, AV66viewQrCode);
         AV52Update = "<i class=\"fa fa-pen\"></i>";
         AssignAttri("", false, edtavUpdate_Internalname, AV52Update);
         if ( AV53IsAuthorized_Update )
         {
            edtavUpdate_Link = formatLink("resident.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.LTrimStr(A31ResidentId,4,0))}, new string[] {"Mode","ResidentId"}) ;
         }
         AV54Delete = "<i class=\"fa fa-times\"></i>";
         AssignAttri("", false, edtavDelete_Internalname, AV54Delete);
         if ( AV55IsAuthorized_Delete )
         {
            edtavDelete_Link = formatLink("resident.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.LTrimStr(A31ResidentId,4,0))}, new string[] {"Mode","ResidentId"}) ;
         }
         if ( AV56IsAuthorized_ResidentTypeName )
         {
            edtResidentTypeName_Link = formatLink("residenttypeview.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A82ResidentTypeId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"ResidentTypeId","TabCode"}) ;
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

      protected void E161K2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV17ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV19ColumnsSelector.FromJSonString(AV17ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "ResidentWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV17ColumnsSelectorXML)) ? "" : AV19ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ColumnsSelector", AV19ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ManageFiltersData", AV22ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E121K2( )
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
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx", new object[] {UrlEncode(StringUtil.RTrim("ResidentWWFilters")),UrlEncode(StringUtil.RTrim(AV69Pgmname+"GridState"))}, new string[] {"UserKey","GridStateKey"}) , new Object[] {});
            AV24ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV24ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV24ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx", new object[] {UrlEncode(StringUtil.RTrim("ResidentWWFilters"))}, new string[] {"UserKey"}) , new Object[] {});
            AV24ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV24ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV24ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char3 = AV23ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "ResidentWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV69Pgmname+"GridState",  AV23ManageFiltersXml) ;
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "ResidentBsnNumber",  "",  "BSN Number",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "ResidentGivenName",  "",  "Given Name",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "ResidentLastName",  "",  "Last Name",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "ResidentEmail",  "",  "Email",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "ResidentAddress",  "",  "Address",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "ResidentPhone",  "",  "Phone",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "ResidentTypeName",  "",  "Resident Type",  true,  "") ;
         GXt_char3 = AV18UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "ResidentWWColumnsSelector", out  GXt_char3) ;
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
         GXt_boolean1 = AV53IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "resident_Update", out  GXt_boolean1) ;
         AV53IsAuthorized_Update = GXt_boolean1;
         AssignAttri("", false, "AV53IsAuthorized_Update", AV53IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV53IsAuthorized_Update, context));
         if ( ! ( AV53IsAuthorized_Update ) )
         {
            edtavUpdate_Visible = 0;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_37_Refreshing);
         }
         GXt_boolean1 = AV55IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "resident_Delete", out  GXt_boolean1) ;
         AV55IsAuthorized_Delete = GXt_boolean1;
         AssignAttri("", false, "AV55IsAuthorized_Delete", AV55IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV55IsAuthorized_Delete, context));
         if ( ! ( AV55IsAuthorized_Delete ) )
         {
            edtavDelete_Visible = 0;
            AssignProp("", false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_37_Refreshing);
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV22ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "ResidentWWFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV22ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S182( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV16FilterFullText = "";
         AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
         AV27TFResidentBsnNumber = "";
         AssignAttri("", false, "AV27TFResidentBsnNumber", AV27TFResidentBsnNumber);
         AV28TFResidentBsnNumber_Sel = "";
         AssignAttri("", false, "AV28TFResidentBsnNumber_Sel", AV28TFResidentBsnNumber_Sel);
         AV29TFResidentGivenName = "";
         AssignAttri("", false, "AV29TFResidentGivenName", AV29TFResidentGivenName);
         AV30TFResidentGivenName_Sel = "";
         AssignAttri("", false, "AV30TFResidentGivenName_Sel", AV30TFResidentGivenName_Sel);
         AV31TFResidentLastName = "";
         AssignAttri("", false, "AV31TFResidentLastName", AV31TFResidentLastName);
         AV32TFResidentLastName_Sel = "";
         AssignAttri("", false, "AV32TFResidentLastName_Sel", AV32TFResidentLastName_Sel);
         AV35TFResidentEmail = "";
         AssignAttri("", false, "AV35TFResidentEmail", AV35TFResidentEmail);
         AV36TFResidentEmail_Sel = "";
         AssignAttri("", false, "AV36TFResidentEmail_Sel", AV36TFResidentEmail_Sel);
         AV37TFResidentAddress = "";
         AssignAttri("", false, "AV37TFResidentAddress", AV37TFResidentAddress);
         AV38TFResidentAddress_Sel = "";
         AssignAttri("", false, "AV38TFResidentAddress_Sel", AV38TFResidentAddress_Sel);
         AV39TFResidentPhone = "";
         AssignAttri("", false, "AV39TFResidentPhone", AV39TFResidentPhone);
         AV40TFResidentPhone_Sel = "";
         AssignAttri("", false, "AV40TFResidentPhone_Sel", AV40TFResidentPhone_Sel);
         AV43TFResidentTypeName = "";
         AssignAttri("", false, "AV43TFResidentTypeName", AV43TFResidentTypeName);
         AV44TFResidentTypeName_Sel = "";
         AssignAttri("", false, "AV44TFResidentTypeName_Sel", AV44TFResidentTypeName_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV21Session.Get(AV69Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV69Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV21Session.Get(AV69Pgmname+"GridState"), null, "", "");
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
         AV85GXV1 = 1;
         while ( AV85GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV85GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV16FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFRESIDENTBSNNUMBER") == 0 )
            {
               AV27TFResidentBsnNumber = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV27TFResidentBsnNumber", AV27TFResidentBsnNumber);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFRESIDENTBSNNUMBER_SEL") == 0 )
            {
               AV28TFResidentBsnNumber_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV28TFResidentBsnNumber_Sel", AV28TFResidentBsnNumber_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFRESIDENTGIVENNAME") == 0 )
            {
               AV29TFResidentGivenName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV29TFResidentGivenName", AV29TFResidentGivenName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFRESIDENTGIVENNAME_SEL") == 0 )
            {
               AV30TFResidentGivenName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV30TFResidentGivenName_Sel", AV30TFResidentGivenName_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFRESIDENTLASTNAME") == 0 )
            {
               AV31TFResidentLastName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV31TFResidentLastName", AV31TFResidentLastName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFRESIDENTLASTNAME_SEL") == 0 )
            {
               AV32TFResidentLastName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV32TFResidentLastName_Sel", AV32TFResidentLastName_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFRESIDENTEMAIL") == 0 )
            {
               AV35TFResidentEmail = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV35TFResidentEmail", AV35TFResidentEmail);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFRESIDENTEMAIL_SEL") == 0 )
            {
               AV36TFResidentEmail_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV36TFResidentEmail_Sel", AV36TFResidentEmail_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFRESIDENTADDRESS") == 0 )
            {
               AV37TFResidentAddress = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV37TFResidentAddress", AV37TFResidentAddress);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFRESIDENTADDRESS_SEL") == 0 )
            {
               AV38TFResidentAddress_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV38TFResidentAddress_Sel", AV38TFResidentAddress_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFRESIDENTPHONE") == 0 )
            {
               AV39TFResidentPhone = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV39TFResidentPhone", AV39TFResidentPhone);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFRESIDENTPHONE_SEL") == 0 )
            {
               AV40TFResidentPhone_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV40TFResidentPhone_Sel", AV40TFResidentPhone_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFRESIDENTTYPENAME") == 0 )
            {
               AV43TFResidentTypeName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV43TFResidentTypeName", AV43TFResidentTypeName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFRESIDENTTYPENAME_SEL") == 0 )
            {
               AV44TFResidentTypeName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV44TFResidentTypeName_Sel", AV44TFResidentTypeName_Sel);
            }
            AV85GXV1 = (int)(AV85GXV1+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV28TFResidentBsnNumber_Sel)),  AV28TFResidentBsnNumber_Sel, out  GXt_char3) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV30TFResidentGivenName_Sel)),  AV30TFResidentGivenName_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV32TFResidentLastName_Sel)),  AV32TFResidentLastName_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV36TFResidentEmail_Sel)),  AV36TFResidentEmail_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV38TFResidentAddress_Sel)),  AV38TFResidentAddress_Sel, out  GXt_char8) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV40TFResidentPhone_Sel)),  AV40TFResidentPhone_Sel, out  GXt_char9) ;
         GXt_char10 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV44TFResidentTypeName_Sel)),  AV44TFResidentTypeName_Sel, out  GXt_char10) ;
         Ddo_grid_Selectedvalue_set = GXt_char3+"|"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7+"|"+GXt_char8+"|"+GXt_char9+"|"+GXt_char10;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char10 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV27TFResidentBsnNumber)),  AV27TFResidentBsnNumber, out  GXt_char10) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV29TFResidentGivenName)),  AV29TFResidentGivenName, out  GXt_char9) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV31TFResidentLastName)),  AV31TFResidentLastName, out  GXt_char8) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV35TFResidentEmail)),  AV35TFResidentEmail, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV37TFResidentAddress)),  AV37TFResidentAddress, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV39TFResidentPhone)),  AV39TFResidentPhone, out  GXt_char5) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV43TFResidentTypeName)),  AV43TFResidentTypeName, out  GXt_char3) ;
         Ddo_grid_Filteredtext_set = GXt_char10+"|"+GXt_char9+"|"+GXt_char8+"|"+GXt_char7+"|"+GXt_char6+"|"+GXt_char5+"|"+GXt_char3;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV21Session.Get(AV69Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)),  0,  AV16FilterFullText,  AV16FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFRESIDENTBSNNUMBER",  context.GetMessage( "BSN Number", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV27TFResidentBsnNumber)),  0,  AV27TFResidentBsnNumber,  AV27TFResidentBsnNumber,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV28TFResidentBsnNumber_Sel)),  AV28TFResidentBsnNumber_Sel,  AV28TFResidentBsnNumber_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFRESIDENTGIVENNAME",  context.GetMessage( "Given Name", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV29TFResidentGivenName)),  0,  AV29TFResidentGivenName,  AV29TFResidentGivenName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV30TFResidentGivenName_Sel)),  AV30TFResidentGivenName_Sel,  AV30TFResidentGivenName_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFRESIDENTLASTNAME",  context.GetMessage( "Last Name", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV31TFResidentLastName)),  0,  AV31TFResidentLastName,  AV31TFResidentLastName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV32TFResidentLastName_Sel)),  AV32TFResidentLastName_Sel,  AV32TFResidentLastName_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFRESIDENTEMAIL",  context.GetMessage( "Email", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV35TFResidentEmail)),  0,  AV35TFResidentEmail,  AV35TFResidentEmail,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV36TFResidentEmail_Sel)),  AV36TFResidentEmail_Sel,  AV36TFResidentEmail_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFRESIDENTADDRESS",  context.GetMessage( "Address", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV37TFResidentAddress)),  0,  AV37TFResidentAddress,  AV37TFResidentAddress,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV38TFResidentAddress_Sel)),  AV38TFResidentAddress_Sel,  AV38TFResidentAddress_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFRESIDENTPHONE",  context.GetMessage( "Phone", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV39TFResidentPhone)),  0,  AV39TFResidentPhone,  AV39TFResidentPhone,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV40TFResidentPhone_Sel)),  AV40TFResidentPhone_Sel,  AV40TFResidentPhone_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFRESIDENTTYPENAME",  context.GetMessage( "Resident Type", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV43TFResidentTypeName)),  0,  AV43TFResidentTypeName,  AV43TFResidentTypeName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV44TFResidentTypeName_Sel)),  AV44TFResidentTypeName_Sel,  AV44TFResidentTypeName_Sel) ;
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV69Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV69Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "Resident";
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
         PA1K2( ) ;
         WS1K2( ) ;
         WE1K2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20248244143069", true, true);
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
         context.AddJavascriptSource("residentww.js", "?20248244143071", false, true);
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
         edtavViewqrcode_Internalname = "vVIEWQRCODE_"+sGXsfl_37_idx;
         edtResidentId_Internalname = "RESIDENTID_"+sGXsfl_37_idx;
         edtResidentBsnNumber_Internalname = "RESIDENTBSNNUMBER_"+sGXsfl_37_idx;
         edtResidentGivenName_Internalname = "RESIDENTGIVENNAME_"+sGXsfl_37_idx;
         edtResidentLastName_Internalname = "RESIDENTLASTNAME_"+sGXsfl_37_idx;
         edtResidentInitials_Internalname = "RESIDENTINITIALS_"+sGXsfl_37_idx;
         edtResidentEmail_Internalname = "RESIDENTEMAIL_"+sGXsfl_37_idx;
         edtResidentAddress_Internalname = "RESIDENTADDRESS_"+sGXsfl_37_idx;
         edtResidentPhone_Internalname = "RESIDENTPHONE_"+sGXsfl_37_idx;
         edtResidentGAMGUID_Internalname = "RESIDENTGAMGUID_"+sGXsfl_37_idx;
         edtResidentTypeId_Internalname = "RESIDENTTYPEID_"+sGXsfl_37_idx;
         edtResidentTypeName_Internalname = "RESIDENTTYPENAME_"+sGXsfl_37_idx;
         edtCustomerId_Internalname = "CUSTOMERID_"+sGXsfl_37_idx;
         edtCustomerName_Internalname = "CUSTOMERNAME_"+sGXsfl_37_idx;
         edtCustomerLocationId_Internalname = "CUSTOMERLOCATIONID_"+sGXsfl_37_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_37_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_37_idx;
      }

      protected void SubsflControlProps_fel_372( )
      {
         edtavViewqrcode_Internalname = "vVIEWQRCODE_"+sGXsfl_37_fel_idx;
         edtResidentId_Internalname = "RESIDENTID_"+sGXsfl_37_fel_idx;
         edtResidentBsnNumber_Internalname = "RESIDENTBSNNUMBER_"+sGXsfl_37_fel_idx;
         edtResidentGivenName_Internalname = "RESIDENTGIVENNAME_"+sGXsfl_37_fel_idx;
         edtResidentLastName_Internalname = "RESIDENTLASTNAME_"+sGXsfl_37_fel_idx;
         edtResidentInitials_Internalname = "RESIDENTINITIALS_"+sGXsfl_37_fel_idx;
         edtResidentEmail_Internalname = "RESIDENTEMAIL_"+sGXsfl_37_fel_idx;
         edtResidentAddress_Internalname = "RESIDENTADDRESS_"+sGXsfl_37_fel_idx;
         edtResidentPhone_Internalname = "RESIDENTPHONE_"+sGXsfl_37_fel_idx;
         edtResidentGAMGUID_Internalname = "RESIDENTGAMGUID_"+sGXsfl_37_fel_idx;
         edtResidentTypeId_Internalname = "RESIDENTTYPEID_"+sGXsfl_37_fel_idx;
         edtResidentTypeName_Internalname = "RESIDENTTYPENAME_"+sGXsfl_37_fel_idx;
         edtCustomerId_Internalname = "CUSTOMERID_"+sGXsfl_37_fel_idx;
         edtCustomerName_Internalname = "CUSTOMERNAME_"+sGXsfl_37_fel_idx;
         edtCustomerLocationId_Internalname = "CUSTOMERLOCATIONID_"+sGXsfl_37_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_37_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_37_fel_idx;
      }

      protected void sendrow_372( )
      {
         SubsflControlProps_372( ) ;
         WB1K0( ) ;
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavViewqrcode_Enabled!=0)&&(edtavViewqrcode_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 38,'',false,'"+sGXsfl_37_idx+"',37)\"" : " ");
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavViewqrcode_Internalname,StringUtil.RTrim( AV66viewQrCode),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavViewqrcode_Enabled!=0)&&(edtavViewqrcode_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,38);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+"e201k2_client"+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavViewqrcode_Jsonclick,(short)7,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavViewqrcode_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A31ResidentId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A31ResidentId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResidentId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtResidentBsnNumber_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentBsnNumber_Internalname,(string)A40ResidentBsnNumber,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResidentBsnNumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtResidentBsnNumber_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"BsnNumber",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtResidentGivenName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentGivenName_Internalname,(string)A33ResidentGivenName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResidentGivenName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtResidentGivenName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtResidentLastName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentLastName_Internalname,(string)A34ResidentLastName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResidentLastName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtResidentLastName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentInitials_Internalname,StringUtil.RTrim( A35ResidentInitials),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResidentInitials_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtResidentEmail_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentEmail_Internalname,(string)A36ResidentEmail,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A36ResidentEmail,(string)"",(string)"",(string)"",(string)edtResidentEmail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtResidentEmail_Visible,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtResidentAddress_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentAddress_Internalname,(string)A37ResidentAddress,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'","http://maps.google.com/maps?q="+GXUtil.UrlEncode( A37ResidentAddress),(string)"_blank",(string)"",(string)"",(string)edtResidentAddress_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtResidentAddress_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Address",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtResidentPhone_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A38ResidentPhone);
            }
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentPhone_Internalname,StringUtil.RTrim( A38ResidentPhone),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtResidentPhone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtResidentPhone_Visible,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentGAMGUID_Internalname,(string)A39ResidentGAMGUID,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResidentGAMGUID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)0,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMUserIdentification",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentTypeId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A82ResidentTypeId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A82ResidentTypeId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResidentTypeId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtResidentTypeName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentTypeName_Internalname,(string)A83ResidentTypeName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtResidentTypeName_Link,(string)"",(string)"",(string)"",(string)edtResidentTypeName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtResidentTypeName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A1CustomerId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A1CustomerId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCustomerId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerName_Internalname,(string)A3CustomerName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCustomerName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerLocationId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A18CustomerLocationId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A18CustomerLocationId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCustomerLocationId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavUpdate_Enabled!=0)&&(edtavUpdate_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 53,'',false,'"+sGXsfl_37_idx+"',37)\"" : " ");
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV52Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavUpdate_Enabled!=0)&&(edtavUpdate_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,53);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",context.GetMessage( "GXM_update", ""),(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavDelete_Enabled!=0)&&(edtavDelete_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 54,'',false,'"+sGXsfl_37_idx+"',37)\"" : " ");
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV54Delete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavDelete_Enabled!=0)&&(edtavDelete_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,54);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDelete_Link,(string)"",context.GetMessage( "GX_BtnDelete", ""),(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavDelete_Visible,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes1K2( ) ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtResidentBsnNumber_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "BSN Number", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtResidentGivenName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Given Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtResidentLastName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Last Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtResidentEmail_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Email", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtResidentAddress_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Address", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtResidentPhone_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Phone", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtResidentTypeName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Resident Type", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV66viewQrCode)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavViewqrcode_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A31ResidentId), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A40ResidentBsnNumber));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentBsnNumber_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A33ResidentGivenName));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentGivenName_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A34ResidentLastName));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentLastName_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A35ResidentInitials)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A36ResidentEmail));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentEmail_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A37ResidentAddress));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentAddress_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A38ResidentPhone)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentPhone_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A39ResidentGAMGUID));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A82ResidentTypeId), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A83ResidentTypeName));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtResidentTypeName_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentTypeName_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1CustomerId), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A3CustomerName));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A18CustomerLocationId), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV52Update)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV54Delete)));
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
         bttBtncreateresidentaction_Internalname = "BTNCREATERESIDENTACTION";
         bttBtneditcolumns_Internalname = "BTNEDITCOLUMNS";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         divTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         edtavViewqrcode_Internalname = "vVIEWQRCODE";
         edtResidentId_Internalname = "RESIDENTID";
         edtResidentBsnNumber_Internalname = "RESIDENTBSNNUMBER";
         edtResidentGivenName_Internalname = "RESIDENTGIVENNAME";
         edtResidentLastName_Internalname = "RESIDENTLASTNAME";
         edtResidentInitials_Internalname = "RESIDENTINITIALS";
         edtResidentEmail_Internalname = "RESIDENTEMAIL";
         edtResidentAddress_Internalname = "RESIDENTADDRESS";
         edtResidentPhone_Internalname = "RESIDENTPHONE";
         edtResidentGAMGUID_Internalname = "RESIDENTGAMGUID";
         edtResidentTypeId_Internalname = "RESIDENTTYPEID";
         edtResidentTypeName_Internalname = "RESIDENTTYPENAME";
         edtCustomerId_Internalname = "CUSTOMERID";
         edtCustomerName_Internalname = "CUSTOMERNAME";
         edtCustomerLocationId_Internalname = "CUSTOMERLOCATIONID";
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
         edtavDelete_Enabled = 1;
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Link = "";
         edtavUpdate_Enabled = 1;
         edtCustomerLocationId_Jsonclick = "";
         edtCustomerName_Jsonclick = "";
         edtCustomerId_Jsonclick = "";
         edtResidentTypeName_Jsonclick = "";
         edtResidentTypeName_Link = "";
         edtResidentTypeId_Jsonclick = "";
         edtResidentGAMGUID_Jsonclick = "";
         edtResidentPhone_Jsonclick = "";
         edtResidentAddress_Jsonclick = "";
         edtResidentEmail_Jsonclick = "";
         edtResidentInitials_Jsonclick = "";
         edtResidentLastName_Jsonclick = "";
         edtResidentGivenName_Jsonclick = "";
         edtResidentBsnNumber_Jsonclick = "";
         edtResidentId_Jsonclick = "";
         edtavViewqrcode_Jsonclick = "";
         edtavViewqrcode_Visible = -1;
         edtavViewqrcode_Enabled = 1;
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavDelete_Visible = -1;
         edtavUpdate_Visible = -1;
         edtResidentTypeName_Visible = -1;
         edtResidentPhone_Visible = -1;
         edtResidentAddress_Visible = -1;
         edtResidentEmail_Visible = -1;
         edtResidentLastName_Visible = -1;
         edtResidentGivenName_Visible = -1;
         edtResidentBsnNumber_Visible = -1;
         edtCustomerLocationId_Enabled = 0;
         edtCustomerName_Enabled = 0;
         edtCustomerId_Enabled = 0;
         edtResidentTypeName_Enabled = 0;
         edtResidentTypeId_Enabled = 0;
         edtResidentGAMGUID_Enabled = 0;
         edtResidentPhone_Enabled = 0;
         edtResidentAddress_Enabled = 0;
         edtResidentEmail_Enabled = 0;
         edtResidentInitials_Enabled = 0;
         edtResidentLastName_Enabled = 0;
         edtResidentGivenName_Enabled = 0;
         edtResidentBsnNumber_Enabled = 0;
         edtResidentId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = "";
         Ddo_gridcolumnsselector_Dropdownoptionstype = "GridColumnsSelector";
         Ddo_gridcolumnsselector_Cls = "ColumnsSelector hidden-xs";
         Ddo_gridcolumnsselector_Tooltip = "WWP_EditColumnsTooltip";
         Ddo_gridcolumnsselector_Caption = context.GetMessage( "WWP_EditColumnsCaption", "");
         Ddo_gridcolumnsselector_Icon = "fas fa-cog";
         Ddo_gridcolumnsselector_Icontype = "FontIcon";
         Ddo_grid_Datalistproc = "ResidentWWGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character|Character|Character|Character|Character|Character|Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5|6|7";
         Ddo_grid_Columnids = "2:ResidentBsnNumber|3:ResidentGivenName|4:ResidentLastName|6:ResidentEmail|7:ResidentAddress|8:ResidentPhone|11:ResidentTypeName";
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
         Form.Caption = context.GetMessage( " Residents", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV24ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV19ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV69Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27TFResidentBsnNumber',fld:'vTFRESIDENTBSNNUMBER',pic:''},{av:'AV28TFResidentBsnNumber_Sel',fld:'vTFRESIDENTBSNNUMBER_SEL',pic:''},{av:'AV29TFResidentGivenName',fld:'vTFRESIDENTGIVENNAME',pic:''},{av:'AV30TFResidentGivenName_Sel',fld:'vTFRESIDENTGIVENNAME_SEL',pic:''},{av:'AV31TFResidentLastName',fld:'vTFRESIDENTLASTNAME',pic:''},{av:'AV32TFResidentLastName_Sel',fld:'vTFRESIDENTLASTNAME_SEL',pic:''},{av:'AV35TFResidentEmail',fld:'vTFRESIDENTEMAIL',pic:''},{av:'AV36TFResidentEmail_Sel',fld:'vTFRESIDENTEMAIL_SEL',pic:''},{av:'AV37TFResidentAddress',fld:'vTFRESIDENTADDRESS',pic:''},{av:'AV38TFResidentAddress_Sel',fld:'vTFRESIDENTADDRESS_SEL',pic:''},{av:'AV39TFResidentPhone',fld:'vTFRESIDENTPHONE',pic:''},{av:'AV40TFResidentPhone_Sel',fld:'vTFRESIDENTPHONE_SEL',pic:''},{av:'AV43TFResidentTypeName',fld:'vTFRESIDENTTYPENAME',pic:''},{av:'AV44TFResidentTypeName_Sel',fld:'vTFRESIDENTTYPENAME_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV53IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV55IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV56IsAuthorized_ResidentTypeName',fld:'vISAUTHORIZED_RESIDENTTYPENAME',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV24ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV19ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtResidentBsnNumber_Visible',ctrl:'RESIDENTBSNNUMBER',prop:'Visible'},{av:'edtResidentGivenName_Visible',ctrl:'RESIDENTGIVENNAME',prop:'Visible'},{av:'edtResidentLastName_Visible',ctrl:'RESIDENTLASTNAME',prop:'Visible'},{av:'edtResidentEmail_Visible',ctrl:'RESIDENTEMAIL',prop:'Visible'},{av:'edtResidentAddress_Visible',ctrl:'RESIDENTADDRESS',prop:'Visible'},{av:'edtResidentPhone_Visible',ctrl:'RESIDENTPHONE',prop:'Visible'},{av:'edtResidentTypeName_Visible',ctrl:'RESIDENTTYPENAME',prop:'Visible'},{av:'AV49GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV50GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV51GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV53IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV55IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV22ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E131K2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV24ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV19ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV69Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27TFResidentBsnNumber',fld:'vTFRESIDENTBSNNUMBER',pic:''},{av:'AV28TFResidentBsnNumber_Sel',fld:'vTFRESIDENTBSNNUMBER_SEL',pic:''},{av:'AV29TFResidentGivenName',fld:'vTFRESIDENTGIVENNAME',pic:''},{av:'AV30TFResidentGivenName_Sel',fld:'vTFRESIDENTGIVENNAME_SEL',pic:''},{av:'AV31TFResidentLastName',fld:'vTFRESIDENTLASTNAME',pic:''},{av:'AV32TFResidentLastName_Sel',fld:'vTFRESIDENTLASTNAME_SEL',pic:''},{av:'AV35TFResidentEmail',fld:'vTFRESIDENTEMAIL',pic:''},{av:'AV36TFResidentEmail_Sel',fld:'vTFRESIDENTEMAIL_SEL',pic:''},{av:'AV37TFResidentAddress',fld:'vTFRESIDENTADDRESS',pic:''},{av:'AV38TFResidentAddress_Sel',fld:'vTFRESIDENTADDRESS_SEL',pic:''},{av:'AV39TFResidentPhone',fld:'vTFRESIDENTPHONE',pic:''},{av:'AV40TFResidentPhone_Sel',fld:'vTFRESIDENTPHONE_SEL',pic:''},{av:'AV43TFResidentTypeName',fld:'vTFRESIDENTTYPENAME',pic:''},{av:'AV44TFResidentTypeName_Sel',fld:'vTFRESIDENTTYPENAME_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV53IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV55IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV56IsAuthorized_ResidentTypeName',fld:'vISAUTHORIZED_RESIDENTTYPENAME',pic:'',hsh:true},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E141K2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV24ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV19ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV69Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27TFResidentBsnNumber',fld:'vTFRESIDENTBSNNUMBER',pic:''},{av:'AV28TFResidentBsnNumber_Sel',fld:'vTFRESIDENTBSNNUMBER_SEL',pic:''},{av:'AV29TFResidentGivenName',fld:'vTFRESIDENTGIVENNAME',pic:''},{av:'AV30TFResidentGivenName_Sel',fld:'vTFRESIDENTGIVENNAME_SEL',pic:''},{av:'AV31TFResidentLastName',fld:'vTFRESIDENTLASTNAME',pic:''},{av:'AV32TFResidentLastName_Sel',fld:'vTFRESIDENTLASTNAME_SEL',pic:''},{av:'AV35TFResidentEmail',fld:'vTFRESIDENTEMAIL',pic:''},{av:'AV36TFResidentEmail_Sel',fld:'vTFRESIDENTEMAIL_SEL',pic:''},{av:'AV37TFResidentAddress',fld:'vTFRESIDENTADDRESS',pic:''},{av:'AV38TFResidentAddress_Sel',fld:'vTFRESIDENTADDRESS_SEL',pic:''},{av:'AV39TFResidentPhone',fld:'vTFRESIDENTPHONE',pic:''},{av:'AV40TFResidentPhone_Sel',fld:'vTFRESIDENTPHONE_SEL',pic:''},{av:'AV43TFResidentTypeName',fld:'vTFRESIDENTTYPENAME',pic:''},{av:'AV44TFResidentTypeName_Sel',fld:'vTFRESIDENTTYPENAME_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV53IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV55IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV56IsAuthorized_ResidentTypeName',fld:'vISAUTHORIZED_RESIDENTTYPENAME',pic:'',hsh:true},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E151K2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV24ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV19ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV69Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27TFResidentBsnNumber',fld:'vTFRESIDENTBSNNUMBER',pic:''},{av:'AV28TFResidentBsnNumber_Sel',fld:'vTFRESIDENTBSNNUMBER_SEL',pic:''},{av:'AV29TFResidentGivenName',fld:'vTFRESIDENTGIVENNAME',pic:''},{av:'AV30TFResidentGivenName_Sel',fld:'vTFRESIDENTGIVENNAME_SEL',pic:''},{av:'AV31TFResidentLastName',fld:'vTFRESIDENTLASTNAME',pic:''},{av:'AV32TFResidentLastName_Sel',fld:'vTFRESIDENTLASTNAME_SEL',pic:''},{av:'AV35TFResidentEmail',fld:'vTFRESIDENTEMAIL',pic:''},{av:'AV36TFResidentEmail_Sel',fld:'vTFRESIDENTEMAIL_SEL',pic:''},{av:'AV37TFResidentAddress',fld:'vTFRESIDENTADDRESS',pic:''},{av:'AV38TFResidentAddress_Sel',fld:'vTFRESIDENTADDRESS_SEL',pic:''},{av:'AV39TFResidentPhone',fld:'vTFRESIDENTPHONE',pic:''},{av:'AV40TFResidentPhone_Sel',fld:'vTFRESIDENTPHONE_SEL',pic:''},{av:'AV43TFResidentTypeName',fld:'vTFRESIDENTTYPENAME',pic:''},{av:'AV44TFResidentTypeName_Sel',fld:'vTFRESIDENTTYPENAME_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV53IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV55IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV56IsAuthorized_ResidentTypeName',fld:'vISAUTHORIZED_RESIDENTTYPENAME',pic:'',hsh:true},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV43TFResidentTypeName',fld:'vTFRESIDENTTYPENAME',pic:''},{av:'AV44TFResidentTypeName_Sel',fld:'vTFRESIDENTTYPENAME_SEL',pic:''},{av:'AV39TFResidentPhone',fld:'vTFRESIDENTPHONE',pic:''},{av:'AV40TFResidentPhone_Sel',fld:'vTFRESIDENTPHONE_SEL',pic:''},{av:'AV37TFResidentAddress',fld:'vTFRESIDENTADDRESS',pic:''},{av:'AV38TFResidentAddress_Sel',fld:'vTFRESIDENTADDRESS_SEL',pic:''},{av:'AV35TFResidentEmail',fld:'vTFRESIDENTEMAIL',pic:''},{av:'AV36TFResidentEmail_Sel',fld:'vTFRESIDENTEMAIL_SEL',pic:''},{av:'AV31TFResidentLastName',fld:'vTFRESIDENTLASTNAME',pic:''},{av:'AV32TFResidentLastName_Sel',fld:'vTFRESIDENTLASTNAME_SEL',pic:''},{av:'AV29TFResidentGivenName',fld:'vTFRESIDENTGIVENNAME',pic:''},{av:'AV30TFResidentGivenName_Sel',fld:'vTFRESIDENTGIVENNAME_SEL',pic:''},{av:'AV27TFResidentBsnNumber',fld:'vTFRESIDENTBSNNUMBER',pic:''},{av:'AV28TFResidentBsnNumber_Sel',fld:'vTFRESIDENTBSNNUMBER_SEL',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E191K2',iparms:[{av:'AV53IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'A31ResidentId',fld:'RESIDENTID',pic:'ZZZ9'},{av:'AV55IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV56IsAuthorized_ResidentTypeName',fld:'vISAUTHORIZED_RESIDENTTYPENAME',pic:'',hsh:true},{av:'A82ResidentTypeId',fld:'RESIDENTTYPEID',pic:'ZZZ9'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'AV66viewQrCode',fld:'vVIEWQRCODE',pic:''},{av:'AV52Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Link',ctrl:'vUPDATE',prop:'Link'},{av:'AV54Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Link',ctrl:'vDELETE',prop:'Link'},{av:'edtResidentTypeName_Link',ctrl:'RESIDENTTYPENAME',prop:'Link'}]}");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","{handler:'E161K2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV24ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV19ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV69Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27TFResidentBsnNumber',fld:'vTFRESIDENTBSNNUMBER',pic:''},{av:'AV28TFResidentBsnNumber_Sel',fld:'vTFRESIDENTBSNNUMBER_SEL',pic:''},{av:'AV29TFResidentGivenName',fld:'vTFRESIDENTGIVENNAME',pic:''},{av:'AV30TFResidentGivenName_Sel',fld:'vTFRESIDENTGIVENNAME_SEL',pic:''},{av:'AV31TFResidentLastName',fld:'vTFRESIDENTLASTNAME',pic:''},{av:'AV32TFResidentLastName_Sel',fld:'vTFRESIDENTLASTNAME_SEL',pic:''},{av:'AV35TFResidentEmail',fld:'vTFRESIDENTEMAIL',pic:''},{av:'AV36TFResidentEmail_Sel',fld:'vTFRESIDENTEMAIL_SEL',pic:''},{av:'AV37TFResidentAddress',fld:'vTFRESIDENTADDRESS',pic:''},{av:'AV38TFResidentAddress_Sel',fld:'vTFRESIDENTADDRESS_SEL',pic:''},{av:'AV39TFResidentPhone',fld:'vTFRESIDENTPHONE',pic:''},{av:'AV40TFResidentPhone_Sel',fld:'vTFRESIDENTPHONE_SEL',pic:''},{av:'AV43TFResidentTypeName',fld:'vTFRESIDENTTYPENAME',pic:''},{av:'AV44TFResidentTypeName_Sel',fld:'vTFRESIDENTTYPENAME_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV53IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV55IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV56IsAuthorized_ResidentTypeName',fld:'vISAUTHORIZED_RESIDENTTYPENAME',pic:'',hsh:true},{av:'Ddo_gridcolumnsselector_Columnsselectorvalues',ctrl:'DDO_GRIDCOLUMNSSELECTOR',prop:'ColumnsSelectorValues'}]");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",",oparms:[{av:'AV19ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV24ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'edtResidentBsnNumber_Visible',ctrl:'RESIDENTBSNNUMBER',prop:'Visible'},{av:'edtResidentGivenName_Visible',ctrl:'RESIDENTGIVENNAME',prop:'Visible'},{av:'edtResidentLastName_Visible',ctrl:'RESIDENTLASTNAME',prop:'Visible'},{av:'edtResidentEmail_Visible',ctrl:'RESIDENTEMAIL',prop:'Visible'},{av:'edtResidentAddress_Visible',ctrl:'RESIDENTADDRESS',prop:'Visible'},{av:'edtResidentPhone_Visible',ctrl:'RESIDENTPHONE',prop:'Visible'},{av:'edtResidentTypeName_Visible',ctrl:'RESIDENTTYPENAME',prop:'Visible'},{av:'AV49GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV50GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV51GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV53IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV55IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV22ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E121K2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV24ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV19ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV69Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27TFResidentBsnNumber',fld:'vTFRESIDENTBSNNUMBER',pic:''},{av:'AV28TFResidentBsnNumber_Sel',fld:'vTFRESIDENTBSNNUMBER_SEL',pic:''},{av:'AV29TFResidentGivenName',fld:'vTFRESIDENTGIVENNAME',pic:''},{av:'AV30TFResidentGivenName_Sel',fld:'vTFRESIDENTGIVENNAME_SEL',pic:''},{av:'AV31TFResidentLastName',fld:'vTFRESIDENTLASTNAME',pic:''},{av:'AV32TFResidentLastName_Sel',fld:'vTFRESIDENTLASTNAME_SEL',pic:''},{av:'AV35TFResidentEmail',fld:'vTFRESIDENTEMAIL',pic:''},{av:'AV36TFResidentEmail_Sel',fld:'vTFRESIDENTEMAIL_SEL',pic:''},{av:'AV37TFResidentAddress',fld:'vTFRESIDENTADDRESS',pic:''},{av:'AV38TFResidentAddress_Sel',fld:'vTFRESIDENTADDRESS_SEL',pic:''},{av:'AV39TFResidentPhone',fld:'vTFRESIDENTPHONE',pic:''},{av:'AV40TFResidentPhone_Sel',fld:'vTFRESIDENTPHONE_SEL',pic:''},{av:'AV43TFResidentTypeName',fld:'vTFRESIDENTTYPENAME',pic:''},{av:'AV44TFResidentTypeName_Sel',fld:'vTFRESIDENTTYPENAME_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV53IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV55IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV56IsAuthorized_ResidentTypeName',fld:'vISAUTHORIZED_RESIDENTTYPENAME',pic:'',hsh:true},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV24ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV27TFResidentBsnNumber',fld:'vTFRESIDENTBSNNUMBER',pic:''},{av:'AV28TFResidentBsnNumber_Sel',fld:'vTFRESIDENTBSNNUMBER_SEL',pic:''},{av:'AV29TFResidentGivenName',fld:'vTFRESIDENTGIVENNAME',pic:''},{av:'AV30TFResidentGivenName_Sel',fld:'vTFRESIDENTGIVENNAME_SEL',pic:''},{av:'AV31TFResidentLastName',fld:'vTFRESIDENTLASTNAME',pic:''},{av:'AV32TFResidentLastName_Sel',fld:'vTFRESIDENTLASTNAME_SEL',pic:''},{av:'AV35TFResidentEmail',fld:'vTFRESIDENTEMAIL',pic:''},{av:'AV36TFResidentEmail_Sel',fld:'vTFRESIDENTEMAIL_SEL',pic:''},{av:'AV37TFResidentAddress',fld:'vTFRESIDENTADDRESS',pic:''},{av:'AV38TFResidentAddress_Sel',fld:'vTFRESIDENTADDRESS_SEL',pic:''},{av:'AV39TFResidentPhone',fld:'vTFRESIDENTPHONE',pic:''},{av:'AV40TFResidentPhone_Sel',fld:'vTFRESIDENTPHONE_SEL',pic:''},{av:'AV43TFResidentTypeName',fld:'vTFRESIDENTTYPENAME',pic:''},{av:'AV44TFResidentTypeName_Sel',fld:'vTFRESIDENTTYPENAME_SEL',pic:''},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV19ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtResidentBsnNumber_Visible',ctrl:'RESIDENTBSNNUMBER',prop:'Visible'},{av:'edtResidentGivenName_Visible',ctrl:'RESIDENTGIVENNAME',prop:'Visible'},{av:'edtResidentLastName_Visible',ctrl:'RESIDENTLASTNAME',prop:'Visible'},{av:'edtResidentEmail_Visible',ctrl:'RESIDENTEMAIL',prop:'Visible'},{av:'edtResidentAddress_Visible',ctrl:'RESIDENTADDRESS',prop:'Visible'},{av:'edtResidentPhone_Visible',ctrl:'RESIDENTPHONE',prop:'Visible'},{av:'edtResidentTypeName_Visible',ctrl:'RESIDENTTYPENAME',prop:'Visible'},{av:'AV49GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV50GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV51GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV53IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV55IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV22ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("'DOCREATERESIDENTACTION'","{handler:'E111K1',iparms:[]");
         setEventMetadata("'DOCREATERESIDENTACTION'",",oparms:[]}");
         setEventMetadata("VVIEWQRCODE.CLICK","{handler:'E201K2',iparms:[{av:'A36ResidentEmail',fld:'RESIDENTEMAIL',pic:'',hsh:true}]");
         setEventMetadata("VVIEWQRCODE.CLICK",",oparms:[]}");
         setEventMetadata("VALID_RESIDENTTYPEID","{handler:'Valid_Residenttypeid',iparms:[]");
         setEventMetadata("VALID_RESIDENTTYPEID",",oparms:[]}");
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
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV16FilterFullText = "";
         AV19ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV69Pgmname = "";
         AV27TFResidentBsnNumber = "";
         AV28TFResidentBsnNumber_Sel = "";
         AV29TFResidentGivenName = "";
         AV30TFResidentGivenName_Sel = "";
         AV31TFResidentLastName = "";
         AV32TFResidentLastName_Sel = "";
         AV35TFResidentEmail = "";
         AV36TFResidentEmail_Sel = "";
         AV37TFResidentAddress = "";
         AV38TFResidentAddress_Sel = "";
         AV39TFResidentPhone = "";
         AV40TFResidentPhone_Sel = "";
         AV43TFResidentTypeName = "";
         AV44TFResidentTypeName_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV22ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV51GridAppliedFilters = "";
         AV45DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
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
         bttBtncreateresidentaction_Jsonclick = "";
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
         AV66viewQrCode = "";
         A40ResidentBsnNumber = "";
         A33ResidentGivenName = "";
         A34ResidentLastName = "";
         A35ResidentInitials = "";
         A36ResidentEmail = "";
         A37ResidentAddress = "";
         A38ResidentPhone = "";
         A39ResidentGAMGUID = "";
         A83ResidentTypeName = "";
         A3CustomerName = "";
         AV52Update = "";
         AV54Delete = "";
         scmdbuf = "";
         lV70Residentwwds_3_filterfulltext = "";
         lV71Residentwwds_4_tfresidentbsnnumber = "";
         lV73Residentwwds_6_tfresidentgivenname = "";
         lV75Residentwwds_8_tfresidentlastname = "";
         lV77Residentwwds_10_tfresidentemail = "";
         lV79Residentwwds_12_tfresidentaddress = "";
         lV81Residentwwds_14_tfresidentphone = "";
         lV83Residentwwds_16_tfresidenttypename = "";
         AV70Residentwwds_3_filterfulltext = "";
         AV72Residentwwds_5_tfresidentbsnnumber_sel = "";
         AV71Residentwwds_4_tfresidentbsnnumber = "";
         AV74Residentwwds_7_tfresidentgivenname_sel = "";
         AV73Residentwwds_6_tfresidentgivenname = "";
         AV76Residentwwds_9_tfresidentlastname_sel = "";
         AV75Residentwwds_8_tfresidentlastname = "";
         AV78Residentwwds_11_tfresidentemail_sel = "";
         AV77Residentwwds_10_tfresidentemail = "";
         AV80Residentwwds_13_tfresidentaddress_sel = "";
         AV79Residentwwds_12_tfresidentaddress = "";
         AV82Residentwwds_15_tfresidentphone_sel = "";
         AV81Residentwwds_14_tfresidentphone = "";
         AV84Residentwwds_17_tfresidenttypename_sel = "";
         AV83Residentwwds_16_tfresidenttypename = "";
         H001K2_A18CustomerLocationId = new short[1] ;
         H001K2_A3CustomerName = new string[] {""} ;
         H001K2_A1CustomerId = new short[1] ;
         H001K2_A83ResidentTypeName = new string[] {""} ;
         H001K2_A82ResidentTypeId = new short[1] ;
         H001K2_A39ResidentGAMGUID = new string[] {""} ;
         H001K2_A38ResidentPhone = new string[] {""} ;
         H001K2_n38ResidentPhone = new bool[] {false} ;
         H001K2_A37ResidentAddress = new string[] {""} ;
         H001K2_n37ResidentAddress = new bool[] {false} ;
         H001K2_A36ResidentEmail = new string[] {""} ;
         H001K2_A35ResidentInitials = new string[] {""} ;
         H001K2_n35ResidentInitials = new bool[] {false} ;
         H001K2_A34ResidentLastName = new string[] {""} ;
         H001K2_A33ResidentGivenName = new string[] {""} ;
         H001K2_A40ResidentBsnNumber = new string[] {""} ;
         H001K2_A31ResidentId = new short[1] ;
         H001K3_AGRID_nRecordCount = new long[1] ;
         AV8HTTPRequest = new GxHttpRequest( context);
         AV46GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV47GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.residentww__default(),
            new Object[][] {
                new Object[] {
               H001K2_A18CustomerLocationId, H001K2_A3CustomerName, H001K2_A1CustomerId, H001K2_A83ResidentTypeName, H001K2_A82ResidentTypeId, H001K2_A39ResidentGAMGUID, H001K2_A38ResidentPhone, H001K2_n38ResidentPhone, H001K2_A37ResidentAddress, H001K2_n37ResidentAddress,
               H001K2_A36ResidentEmail, H001K2_A35ResidentInitials, H001K2_n35ResidentInitials, H001K2_A34ResidentLastName, H001K2_A33ResidentGivenName, H001K2_A40ResidentBsnNumber, H001K2_A31ResidentId
               }
               , new Object[] {
               H001K3_AGRID_nRecordCount
               }
            }
         );
         AV69Pgmname = "ResidentWW";
         /* GeneXus formulas. */
         AV69Pgmname = "ResidentWW";
         edtavViewqrcode_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV24ManageFiltersExecutionStep ;
      private short AV13OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A31ResidentId ;
      private short A82ResidentTypeId ;
      private short A1CustomerId ;
      private short A18CustomerLocationId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV67Udparg1 ;
      private short AV68Udparg2 ;
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
      private int edtavFilterfulltext_Enabled ;
      private int subGrid_Islastpage ;
      private int edtavViewqrcode_Enabled ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtResidentId_Enabled ;
      private int edtResidentBsnNumber_Enabled ;
      private int edtResidentGivenName_Enabled ;
      private int edtResidentLastName_Enabled ;
      private int edtResidentInitials_Enabled ;
      private int edtResidentEmail_Enabled ;
      private int edtResidentAddress_Enabled ;
      private int edtResidentPhone_Enabled ;
      private int edtResidentGAMGUID_Enabled ;
      private int edtResidentTypeId_Enabled ;
      private int edtResidentTypeName_Enabled ;
      private int edtCustomerId_Enabled ;
      private int edtCustomerName_Enabled ;
      private int edtCustomerLocationId_Enabled ;
      private int edtResidentBsnNumber_Visible ;
      private int edtResidentGivenName_Visible ;
      private int edtResidentLastName_Visible ;
      private int edtResidentEmail_Visible ;
      private int edtResidentAddress_Visible ;
      private int edtResidentPhone_Visible ;
      private int edtResidentTypeName_Visible ;
      private int AV48PageToGo ;
      private int edtavUpdate_Visible ;
      private int edtavDelete_Visible ;
      private int AV85GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int edtavViewqrcode_Visible ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV49GridCurrentPage ;
      private long AV50GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_37_idx="0001" ;
      private string AV69Pgmname ;
      private string AV39TFResidentPhone ;
      private string AV40TFResidentPhone_Sel ;
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
      private string Ddo_grid_Includedatalist ;
      private string Ddo_grid_Datalisttype ;
      private string Ddo_grid_Datalistproc ;
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
      private string bttBtncreateresidentaction_Internalname ;
      private string bttBtncreateresidentaction_Jsonclick ;
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
      private string AV66viewQrCode ;
      private string edtavViewqrcode_Internalname ;
      private string edtResidentId_Internalname ;
      private string edtResidentBsnNumber_Internalname ;
      private string edtResidentGivenName_Internalname ;
      private string edtResidentLastName_Internalname ;
      private string A35ResidentInitials ;
      private string edtResidentInitials_Internalname ;
      private string edtResidentEmail_Internalname ;
      private string edtResidentAddress_Internalname ;
      private string A38ResidentPhone ;
      private string edtResidentPhone_Internalname ;
      private string edtResidentGAMGUID_Internalname ;
      private string edtResidentTypeId_Internalname ;
      private string edtResidentTypeName_Internalname ;
      private string edtCustomerId_Internalname ;
      private string edtCustomerName_Internalname ;
      private string edtCustomerLocationId_Internalname ;
      private string AV52Update ;
      private string edtavUpdate_Internalname ;
      private string AV54Delete ;
      private string edtavDelete_Internalname ;
      private string scmdbuf ;
      private string lV81Residentwwds_14_tfresidentphone ;
      private string AV82Residentwwds_15_tfresidentphone_sel ;
      private string AV81Residentwwds_14_tfresidentphone ;
      private string edtavUpdate_Link ;
      private string edtavDelete_Link ;
      private string edtResidentTypeName_Link ;
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
      private string edtavViewqrcode_Jsonclick ;
      private string edtResidentId_Jsonclick ;
      private string edtResidentBsnNumber_Jsonclick ;
      private string edtResidentGivenName_Jsonclick ;
      private string edtResidentLastName_Jsonclick ;
      private string edtResidentInitials_Jsonclick ;
      private string edtResidentEmail_Jsonclick ;
      private string edtResidentAddress_Jsonclick ;
      private string gxphoneLink ;
      private string edtResidentPhone_Jsonclick ;
      private string edtResidentGAMGUID_Jsonclick ;
      private string edtResidentTypeId_Jsonclick ;
      private string edtResidentTypeName_Jsonclick ;
      private string edtCustomerId_Jsonclick ;
      private string edtCustomerName_Jsonclick ;
      private string edtCustomerLocationId_Jsonclick ;
      private string edtavUpdate_Jsonclick ;
      private string edtavDelete_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV53IsAuthorized_Update ;
      private bool AV55IsAuthorized_Delete ;
      private bool AV56IsAuthorized_ResidentTypeName ;
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
      private bool n35ResidentInitials ;
      private bool n37ResidentAddress ;
      private bool n38ResidentPhone ;
      private bool bGXsfl_37_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool GXt_boolean1 ;
      private string AV17ColumnsSelectorXML ;
      private string AV23ManageFiltersXml ;
      private string AV18UserCustomValue ;
      private string AV16FilterFullText ;
      private string AV27TFResidentBsnNumber ;
      private string AV28TFResidentBsnNumber_Sel ;
      private string AV29TFResidentGivenName ;
      private string AV30TFResidentGivenName_Sel ;
      private string AV31TFResidentLastName ;
      private string AV32TFResidentLastName_Sel ;
      private string AV35TFResidentEmail ;
      private string AV36TFResidentEmail_Sel ;
      private string AV37TFResidentAddress ;
      private string AV38TFResidentAddress_Sel ;
      private string AV43TFResidentTypeName ;
      private string AV44TFResidentTypeName_Sel ;
      private string AV51GridAppliedFilters ;
      private string A40ResidentBsnNumber ;
      private string A33ResidentGivenName ;
      private string A34ResidentLastName ;
      private string A36ResidentEmail ;
      private string A37ResidentAddress ;
      private string A39ResidentGAMGUID ;
      private string A83ResidentTypeName ;
      private string A3CustomerName ;
      private string lV70Residentwwds_3_filterfulltext ;
      private string lV71Residentwwds_4_tfresidentbsnnumber ;
      private string lV73Residentwwds_6_tfresidentgivenname ;
      private string lV75Residentwwds_8_tfresidentlastname ;
      private string lV77Residentwwds_10_tfresidentemail ;
      private string lV79Residentwwds_12_tfresidentaddress ;
      private string lV83Residentwwds_16_tfresidenttypename ;
      private string AV70Residentwwds_3_filterfulltext ;
      private string AV72Residentwwds_5_tfresidentbsnnumber_sel ;
      private string AV71Residentwwds_4_tfresidentbsnnumber ;
      private string AV74Residentwwds_7_tfresidentgivenname_sel ;
      private string AV73Residentwwds_6_tfresidentgivenname ;
      private string AV76Residentwwds_9_tfresidentlastname_sel ;
      private string AV75Residentwwds_8_tfresidentlastname ;
      private string AV78Residentwwds_11_tfresidentemail_sel ;
      private string AV77Residentwwds_10_tfresidentemail ;
      private string AV80Residentwwds_13_tfresidentaddress_sel ;
      private string AV79Residentwwds_12_tfresidentaddress ;
      private string AV84Residentwwds_17_tfresidenttypename_sel ;
      private string AV83Residentwwds_16_tfresidenttypename ;
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
      private short[] H001K2_A18CustomerLocationId ;
      private string[] H001K2_A3CustomerName ;
      private short[] H001K2_A1CustomerId ;
      private string[] H001K2_A83ResidentTypeName ;
      private short[] H001K2_A82ResidentTypeId ;
      private string[] H001K2_A39ResidentGAMGUID ;
      private string[] H001K2_A38ResidentPhone ;
      private bool[] H001K2_n38ResidentPhone ;
      private string[] H001K2_A37ResidentAddress ;
      private bool[] H001K2_n37ResidentAddress ;
      private string[] H001K2_A36ResidentEmail ;
      private string[] H001K2_A35ResidentInitials ;
      private bool[] H001K2_n35ResidentInitials ;
      private string[] H001K2_A34ResidentLastName ;
      private string[] H001K2_A33ResidentGivenName ;
      private string[] H001K2_A40ResidentBsnNumber ;
      private short[] H001K2_A31ResidentId ;
      private long[] H001K3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV22ManageFiltersData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV47GAMErrors ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV19ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV20ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV45DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV46GAMSession ;
   }

   public class residentww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H001K2( IGxContext context ,
                                             string AV70Residentwwds_3_filterfulltext ,
                                             string AV72Residentwwds_5_tfresidentbsnnumber_sel ,
                                             string AV71Residentwwds_4_tfresidentbsnnumber ,
                                             string AV74Residentwwds_7_tfresidentgivenname_sel ,
                                             string AV73Residentwwds_6_tfresidentgivenname ,
                                             string AV76Residentwwds_9_tfresidentlastname_sel ,
                                             string AV75Residentwwds_8_tfresidentlastname ,
                                             string AV78Residentwwds_11_tfresidentemail_sel ,
                                             string AV77Residentwwds_10_tfresidentemail ,
                                             string AV80Residentwwds_13_tfresidentaddress_sel ,
                                             string AV79Residentwwds_12_tfresidentaddress ,
                                             string AV82Residentwwds_15_tfresidentphone_sel ,
                                             string AV81Residentwwds_14_tfresidentphone ,
                                             string AV84Residentwwds_17_tfresidenttypename_sel ,
                                             string AV83Residentwwds_16_tfresidenttypename ,
                                             string A40ResidentBsnNumber ,
                                             string A33ResidentGivenName ,
                                             string A34ResidentLastName ,
                                             string A36ResidentEmail ,
                                             string A37ResidentAddress ,
                                             string A38ResidentPhone ,
                                             string A83ResidentTypeName ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             short A1CustomerId ,
                                             short AV67Udparg1 ,
                                             short A18CustomerLocationId ,
                                             short AV68Udparg2 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[26];
         Object[] GXv_Object12 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.CustomerLocationId, T2.CustomerName, T1.CustomerId, T3.ResidentTypeName, T1.ResidentTypeId, T1.ResidentGAMGUID, T1.ResidentPhone, T1.ResidentAddress, T1.ResidentEmail, T1.ResidentInitials, T1.ResidentLastName, T1.ResidentGivenName, T1.ResidentBsnNumber, T1.ResidentId";
         sFromString = " FROM ((Resident T1 INNER JOIN Customer T2 ON T2.CustomerId = T1.CustomerId) INNER JOIN ResidentType T3 ON T3.ResidentTypeId = T1.ResidentTypeId)";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.CustomerId = :AV67Udparg1)");
         AddWhere(sWhereString, "(T1.CustomerLocationId = :AV68Udparg2)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Residentwwds_3_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.ResidentBsnNumber like '%' || :lV70Residentwwds_3_filterfulltext) or ( T1.ResidentGivenName like '%' || :lV70Residentwwds_3_filterfulltext) or ( T1.ResidentLastName like '%' || :lV70Residentwwds_3_filterfulltext) or ( T1.ResidentEmail like '%' || :lV70Residentwwds_3_filterfulltext) or ( T1.ResidentAddress like '%' || :lV70Residentwwds_3_filterfulltext) or ( T1.ResidentPhone like '%' || :lV70Residentwwds_3_filterfulltext) or ( T3.ResidentTypeName like '%' || :lV70Residentwwds_3_filterfulltext))");
         }
         else
         {
            GXv_int11[2] = 1;
            GXv_int11[3] = 1;
            GXv_int11[4] = 1;
            GXv_int11[5] = 1;
            GXv_int11[6] = 1;
            GXv_int11[7] = 1;
            GXv_int11[8] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Residentwwds_5_tfresidentbsnnumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Residentwwds_4_tfresidentbsnnumber)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber like :lV71Residentwwds_4_tfresidentbsnnumber)");
         }
         else
         {
            GXv_int11[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Residentwwds_5_tfresidentbsnnumber_sel)) && ! ( StringUtil.StrCmp(AV72Residentwwds_5_tfresidentbsnnumber_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber = ( :AV72Residentwwds_5_tfresidentbsnnumber_sel))");
         }
         else
         {
            GXv_int11[10] = 1;
         }
         if ( StringUtil.StrCmp(AV72Residentwwds_5_tfresidentbsnnumber_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentBsnNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Residentwwds_7_tfresidentgivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Residentwwds_6_tfresidentgivenname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName like :lV73Residentwwds_6_tfresidentgivenname)");
         }
         else
         {
            GXv_int11[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Residentwwds_7_tfresidentgivenname_sel)) && ! ( StringUtil.StrCmp(AV74Residentwwds_7_tfresidentgivenname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName = ( :AV74Residentwwds_7_tfresidentgivenname_sel))");
         }
         else
         {
            GXv_int11[12] = 1;
         }
         if ( StringUtil.StrCmp(AV74Residentwwds_7_tfresidentgivenname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Residentwwds_9_tfresidentlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Residentwwds_8_tfresidentlastname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName like :lV75Residentwwds_8_tfresidentlastname)");
         }
         else
         {
            GXv_int11[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Residentwwds_9_tfresidentlastname_sel)) && ! ( StringUtil.StrCmp(AV76Residentwwds_9_tfresidentlastname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName = ( :AV76Residentwwds_9_tfresidentlastname_sel))");
         }
         else
         {
            GXv_int11[14] = 1;
         }
         if ( StringUtil.StrCmp(AV76Residentwwds_9_tfresidentlastname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Residentwwds_11_tfresidentemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Residentwwds_10_tfresidentemail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail like :lV77Residentwwds_10_tfresidentemail)");
         }
         else
         {
            GXv_int11[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Residentwwds_11_tfresidentemail_sel)) && ! ( StringUtil.StrCmp(AV78Residentwwds_11_tfresidentemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail = ( :AV78Residentwwds_11_tfresidentemail_sel))");
         }
         else
         {
            GXv_int11[16] = 1;
         }
         if ( StringUtil.StrCmp(AV78Residentwwds_11_tfresidentemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Residentwwds_13_tfresidentaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Residentwwds_12_tfresidentaddress)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress like :lV79Residentwwds_12_tfresidentaddress)");
         }
         else
         {
            GXv_int11[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Residentwwds_13_tfresidentaddress_sel)) && ! ( StringUtil.StrCmp(AV80Residentwwds_13_tfresidentaddress_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress = ( :AV80Residentwwds_13_tfresidentaddress_sel))");
         }
         else
         {
            GXv_int11[18] = 1;
         }
         if ( StringUtil.StrCmp(AV80Residentwwds_13_tfresidentaddress_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress IS NULL or (char_length(trim(trailing ' ' from T1.ResidentAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Residentwwds_15_tfresidentphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Residentwwds_14_tfresidentphone)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone like :lV81Residentwwds_14_tfresidentphone)");
         }
         else
         {
            GXv_int11[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Residentwwds_15_tfresidentphone_sel)) && ! ( StringUtil.StrCmp(AV82Residentwwds_15_tfresidentphone_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone = ( :AV82Residentwwds_15_tfresidentphone_sel))");
         }
         else
         {
            GXv_int11[20] = 1;
         }
         if ( StringUtil.StrCmp(AV82Residentwwds_15_tfresidentphone_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone IS NULL or (char_length(trim(trailing ' ' from T1.ResidentPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Residentwwds_17_tfresidenttypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Residentwwds_16_tfresidenttypename)) ) )
         {
            AddWhere(sWhereString, "(T3.ResidentTypeName like :lV83Residentwwds_16_tfresidenttypename)");
         }
         else
         {
            GXv_int11[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Residentwwds_17_tfresidenttypename_sel)) && ! ( StringUtil.StrCmp(AV84Residentwwds_17_tfresidenttypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ResidentTypeName = ( :AV84Residentwwds_17_tfresidenttypename_sel))");
         }
         else
         {
            GXv_int11[22] = 1;
         }
         if ( StringUtil.StrCmp(AV84Residentwwds_17_tfresidenttypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.ResidentTypeName))=0))");
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ResidentBsnNumber";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ResidentBsnNumber DESC";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ResidentGivenName, T1.ResidentId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ResidentGivenName DESC, T1.ResidentId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ResidentLastName, T1.ResidentId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ResidentLastName DESC, T1.ResidentId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ResidentEmail, T1.ResidentId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ResidentEmail DESC, T1.ResidentId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ResidentAddress, T1.ResidentId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ResidentAddress DESC, T1.ResidentId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ResidentPhone, T1.ResidentId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ResidentPhone DESC, T1.ResidentId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T3.ResidentTypeName, T1.ResidentId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T3.ResidentTypeName DESC, T1.ResidentId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.ResidentId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object12[0] = scmdbuf;
         GXv_Object12[1] = GXv_int11;
         return GXv_Object12 ;
      }

      protected Object[] conditional_H001K3( IGxContext context ,
                                             string AV70Residentwwds_3_filterfulltext ,
                                             string AV72Residentwwds_5_tfresidentbsnnumber_sel ,
                                             string AV71Residentwwds_4_tfresidentbsnnumber ,
                                             string AV74Residentwwds_7_tfresidentgivenname_sel ,
                                             string AV73Residentwwds_6_tfresidentgivenname ,
                                             string AV76Residentwwds_9_tfresidentlastname_sel ,
                                             string AV75Residentwwds_8_tfresidentlastname ,
                                             string AV78Residentwwds_11_tfresidentemail_sel ,
                                             string AV77Residentwwds_10_tfresidentemail ,
                                             string AV80Residentwwds_13_tfresidentaddress_sel ,
                                             string AV79Residentwwds_12_tfresidentaddress ,
                                             string AV82Residentwwds_15_tfresidentphone_sel ,
                                             string AV81Residentwwds_14_tfresidentphone ,
                                             string AV84Residentwwds_17_tfresidenttypename_sel ,
                                             string AV83Residentwwds_16_tfresidenttypename ,
                                             string A40ResidentBsnNumber ,
                                             string A33ResidentGivenName ,
                                             string A34ResidentLastName ,
                                             string A36ResidentEmail ,
                                             string A37ResidentAddress ,
                                             string A38ResidentPhone ,
                                             string A83ResidentTypeName ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             short A1CustomerId ,
                                             short AV67Udparg1 ,
                                             short A18CustomerLocationId ,
                                             short AV68Udparg2 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int13 = new short[23];
         Object[] GXv_Object14 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ((Resident T1 INNER JOIN Customer T3 ON T3.CustomerId = T1.CustomerId) INNER JOIN ResidentType T2 ON T2.ResidentTypeId = T1.ResidentTypeId)";
         AddWhere(sWhereString, "(T1.CustomerId = :AV67Udparg1)");
         AddWhere(sWhereString, "(T1.CustomerLocationId = :AV68Udparg2)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Residentwwds_3_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.ResidentBsnNumber like '%' || :lV70Residentwwds_3_filterfulltext) or ( T1.ResidentGivenName like '%' || :lV70Residentwwds_3_filterfulltext) or ( T1.ResidentLastName like '%' || :lV70Residentwwds_3_filterfulltext) or ( T1.ResidentEmail like '%' || :lV70Residentwwds_3_filterfulltext) or ( T1.ResidentAddress like '%' || :lV70Residentwwds_3_filterfulltext) or ( T1.ResidentPhone like '%' || :lV70Residentwwds_3_filterfulltext) or ( T2.ResidentTypeName like '%' || :lV70Residentwwds_3_filterfulltext))");
         }
         else
         {
            GXv_int13[2] = 1;
            GXv_int13[3] = 1;
            GXv_int13[4] = 1;
            GXv_int13[5] = 1;
            GXv_int13[6] = 1;
            GXv_int13[7] = 1;
            GXv_int13[8] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Residentwwds_5_tfresidentbsnnumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Residentwwds_4_tfresidentbsnnumber)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber like :lV71Residentwwds_4_tfresidentbsnnumber)");
         }
         else
         {
            GXv_int13[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Residentwwds_5_tfresidentbsnnumber_sel)) && ! ( StringUtil.StrCmp(AV72Residentwwds_5_tfresidentbsnnumber_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber = ( :AV72Residentwwds_5_tfresidentbsnnumber_sel))");
         }
         else
         {
            GXv_int13[10] = 1;
         }
         if ( StringUtil.StrCmp(AV72Residentwwds_5_tfresidentbsnnumber_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentBsnNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Residentwwds_7_tfresidentgivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Residentwwds_6_tfresidentgivenname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName like :lV73Residentwwds_6_tfresidentgivenname)");
         }
         else
         {
            GXv_int13[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Residentwwds_7_tfresidentgivenname_sel)) && ! ( StringUtil.StrCmp(AV74Residentwwds_7_tfresidentgivenname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName = ( :AV74Residentwwds_7_tfresidentgivenname_sel))");
         }
         else
         {
            GXv_int13[12] = 1;
         }
         if ( StringUtil.StrCmp(AV74Residentwwds_7_tfresidentgivenname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Residentwwds_9_tfresidentlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Residentwwds_8_tfresidentlastname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName like :lV75Residentwwds_8_tfresidentlastname)");
         }
         else
         {
            GXv_int13[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Residentwwds_9_tfresidentlastname_sel)) && ! ( StringUtil.StrCmp(AV76Residentwwds_9_tfresidentlastname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName = ( :AV76Residentwwds_9_tfresidentlastname_sel))");
         }
         else
         {
            GXv_int13[14] = 1;
         }
         if ( StringUtil.StrCmp(AV76Residentwwds_9_tfresidentlastname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Residentwwds_11_tfresidentemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Residentwwds_10_tfresidentemail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail like :lV77Residentwwds_10_tfresidentemail)");
         }
         else
         {
            GXv_int13[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Residentwwds_11_tfresidentemail_sel)) && ! ( StringUtil.StrCmp(AV78Residentwwds_11_tfresidentemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail = ( :AV78Residentwwds_11_tfresidentemail_sel))");
         }
         else
         {
            GXv_int13[16] = 1;
         }
         if ( StringUtil.StrCmp(AV78Residentwwds_11_tfresidentemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Residentwwds_13_tfresidentaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Residentwwds_12_tfresidentaddress)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress like :lV79Residentwwds_12_tfresidentaddress)");
         }
         else
         {
            GXv_int13[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Residentwwds_13_tfresidentaddress_sel)) && ! ( StringUtil.StrCmp(AV80Residentwwds_13_tfresidentaddress_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress = ( :AV80Residentwwds_13_tfresidentaddress_sel))");
         }
         else
         {
            GXv_int13[18] = 1;
         }
         if ( StringUtil.StrCmp(AV80Residentwwds_13_tfresidentaddress_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress IS NULL or (char_length(trim(trailing ' ' from T1.ResidentAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Residentwwds_15_tfresidentphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Residentwwds_14_tfresidentphone)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone like :lV81Residentwwds_14_tfresidentphone)");
         }
         else
         {
            GXv_int13[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Residentwwds_15_tfresidentphone_sel)) && ! ( StringUtil.StrCmp(AV82Residentwwds_15_tfresidentphone_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone = ( :AV82Residentwwds_15_tfresidentphone_sel))");
         }
         else
         {
            GXv_int13[20] = 1;
         }
         if ( StringUtil.StrCmp(AV82Residentwwds_15_tfresidentphone_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone IS NULL or (char_length(trim(trailing ' ' from T1.ResidentPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Residentwwds_17_tfresidenttypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Residentwwds_16_tfresidenttypename)) ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName like :lV83Residentwwds_16_tfresidenttypename)");
         }
         else
         {
            GXv_int13[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Residentwwds_17_tfresidenttypename_sel)) && ! ( StringUtil.StrCmp(AV84Residentwwds_17_tfresidenttypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName = ( :AV84Residentwwds_17_tfresidenttypename_sel))");
         }
         else
         {
            GXv_int13[22] = 1;
         }
         if ( StringUtil.StrCmp(AV84Residentwwds_17_tfresidenttypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ResidentTypeName))=0))");
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
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object14[0] = scmdbuf;
         GXv_Object14[1] = GXv_int13;
         return GXv_Object14 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H001K2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (short)dynConstraints[22] , (bool)dynConstraints[23] , (short)dynConstraints[24] , (short)dynConstraints[25] , (short)dynConstraints[26] , (short)dynConstraints[27] );
               case 1 :
                     return conditional_H001K3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (short)dynConstraints[22] , (bool)dynConstraints[23] , (short)dynConstraints[24] , (short)dynConstraints[25] , (short)dynConstraints[26] , (short)dynConstraints[27] );
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
          Object[] prmH001K2;
          prmH001K2 = new Object[] {
          new ParDef("AV67Udparg1",GXType.Int16,4,0) ,
          new ParDef("AV68Udparg2",GXType.Int16,4,0) ,
          new ParDef("lV70Residentwwds_3_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Residentwwds_3_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Residentwwds_3_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Residentwwds_3_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Residentwwds_3_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Residentwwds_3_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Residentwwds_3_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV71Residentwwds_4_tfresidentbsnnumber",GXType.VarChar,40,0) ,
          new ParDef("AV72Residentwwds_5_tfresidentbsnnumber_sel",GXType.VarChar,40,0) ,
          new ParDef("lV73Residentwwds_6_tfresidentgivenname",GXType.VarChar,40,0) ,
          new ParDef("AV74Residentwwds_7_tfresidentgivenname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV75Residentwwds_8_tfresidentlastname",GXType.VarChar,40,0) ,
          new ParDef("AV76Residentwwds_9_tfresidentlastname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV77Residentwwds_10_tfresidentemail",GXType.VarChar,100,0) ,
          new ParDef("AV78Residentwwds_11_tfresidentemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV79Residentwwds_12_tfresidentaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV80Residentwwds_13_tfresidentaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV81Residentwwds_14_tfresidentphone",GXType.Char,20,0) ,
          new ParDef("AV82Residentwwds_15_tfresidentphone_sel",GXType.Char,20,0) ,
          new ParDef("lV83Residentwwds_16_tfresidenttypename",GXType.VarChar,40,0) ,
          new ParDef("AV84Residentwwds_17_tfresidenttypename_sel",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH001K3;
          prmH001K3 = new Object[] {
          new ParDef("AV67Udparg1",GXType.Int16,4,0) ,
          new ParDef("AV68Udparg2",GXType.Int16,4,0) ,
          new ParDef("lV70Residentwwds_3_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Residentwwds_3_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Residentwwds_3_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Residentwwds_3_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Residentwwds_3_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Residentwwds_3_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Residentwwds_3_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV71Residentwwds_4_tfresidentbsnnumber",GXType.VarChar,40,0) ,
          new ParDef("AV72Residentwwds_5_tfresidentbsnnumber_sel",GXType.VarChar,40,0) ,
          new ParDef("lV73Residentwwds_6_tfresidentgivenname",GXType.VarChar,40,0) ,
          new ParDef("AV74Residentwwds_7_tfresidentgivenname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV75Residentwwds_8_tfresidentlastname",GXType.VarChar,40,0) ,
          new ParDef("AV76Residentwwds_9_tfresidentlastname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV77Residentwwds_10_tfresidentemail",GXType.VarChar,100,0) ,
          new ParDef("AV78Residentwwds_11_tfresidentemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV79Residentwwds_12_tfresidentaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV80Residentwwds_13_tfresidentaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV81Residentwwds_14_tfresidentphone",GXType.Char,20,0) ,
          new ParDef("AV82Residentwwds_15_tfresidentphone_sel",GXType.Char,20,0) ,
          new ParDef("lV83Residentwwds_16_tfresidenttypename",GXType.VarChar,40,0) ,
          new ParDef("AV84Residentwwds_17_tfresidenttypename_sel",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("H001K2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001K2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H001K3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001K3,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((string[]) buf[10])[0] = rslt.getVarchar(9);
                ((string[]) buf[11])[0] = rslt.getString(10, 20);
                ((bool[]) buf[12])[0] = rslt.wasNull(10);
                ((string[]) buf[13])[0] = rslt.getVarchar(11);
                ((string[]) buf[14])[0] = rslt.getVarchar(12);
                ((string[]) buf[15])[0] = rslt.getVarchar(13);
                ((short[]) buf[16])[0] = rslt.getShort(14);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
