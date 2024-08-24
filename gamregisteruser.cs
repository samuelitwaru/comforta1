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
   public class gamregisteruser : GXDataArea
   {
      public gamregisteruser( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gamregisteruser( IGxContext context )
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpageempty", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpageempty", new Object[] {context});
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
         PA0S2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0S2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gamregisteruser.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vBIRTHDAY", context.localUtil.DToC( AV6Birthday, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vBIRTHDAY", GetSecureSignedToken( "", AV6Birthday, context));
         GxWebStd.gx_hidden_field( context, "vGENDER", StringUtil.RTrim( AV12Gender));
         GxWebStd.gx_hidden_field( context, "gxhash_vGENDER", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV12Gender, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSERREMEMBERME", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28UserRememberMe), 2, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERREMEMBERME", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV28UserRememberMe), "Z9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_boolean_hidden_field( context, "vCHECKREQUIREDFIELDSRESULT", AV29CheckRequiredFieldsResult);
         GxWebStd.gx_hidden_field( context, "vBIRTHDAY", context.localUtil.DToC( AV6Birthday, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vBIRTHDAY", GetSecureSignedToken( "", AV6Birthday, context));
         GxWebStd.gx_hidden_field( context, "vGENDER", StringUtil.RTrim( AV12Gender));
         GxWebStd.gx_hidden_field( context, "gxhash_vGENDER", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV12Gender, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSERREMEMBERME", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28UserRememberMe), 2, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERREMEMBERME", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV28UserRememberMe), "Z9"), context));
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
            WE0S2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0S2( ) ;
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
         return formatLink("gamregisteruser.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "GAMRegisterUser" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Register user ", "") ;
      }

      protected void WB0S0( )
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", divLayoutmaintable_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginLogin", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Static images/pictures */
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgHeaderoriginal_gximage, "")==0) ? "GX_Image_LogoLogin_Class" : "GX_Image_"+imgHeaderoriginal_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "e9edf59f-db45-4e16-b6a6-2c2b6611a4a3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgHeaderoriginal_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_GAMRegisterUser.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablelogin_Internalname, 1, 0, "px", 0, "px", "TableLogin2Cols", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSignin_Internalname, context.GetMessage( "WWP_GAM_Register", ""), "", "", lblSignin_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockTitleLogin", 0, "", 1, 1, 0, 0, "HLP_GAMRegisterUser.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divName_cell_Internalname, 1, 0, "px", 0, "px", divName_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavName_Internalname, context.GetMessage( "Name", ""), "col-sm-3 AttributeRegisterLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavName_Internalname, AV17Name, StringUtil.RTrim( context.localUtil.Format( AV17Name, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_GAM_Name", ""), edtavName_Jsonclick, 0, "AttributeRegister", "", "", "", "", 1, edtavName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "start", true, "", "HLP_GAMRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divEmail_cell_Internalname, 1, 0, "px", 0, "px", divEmail_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmail_Internalname, context.GetMessage( "EMail", ""), "col-sm-3 AttributeRegisterLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmail_Internalname, AV7EMail, StringUtil.RTrim( context.localUtil.Format( AV7EMail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_GAM_Email", ""), edtavEmail_Jsonclick, 0, "AttributeRegister", "", "", "", "", 1, edtavEmail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMEMail", "start", true, "", "HLP_GAMRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divPassword_cell_Internalname, 1, 0, "px", 0, "px", divPassword_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPassword_Internalname, context.GetMessage( "Password", ""), "col-sm-3 AttributeRegisterLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPassword_Internalname, StringUtil.RTrim( AV18Password), StringUtil.RTrim( context.localUtil.Format( AV18Password, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_GAM_Password", ""), edtavPassword_Jsonclick, 0, "AttributeRegister", "", "", "", "", 1, edtavPassword_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, edtavPassword_Ispassword, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMPassword", "start", true, "", "HLP_GAMRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divPasswordconf_cell_Internalname, 1, 0, "px", 0, "px", divPasswordconf_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPasswordconf_Internalname, context.GetMessage( "Password Conf", ""), "col-sm-3 AttributeRegisterLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPasswordconf_Internalname, StringUtil.RTrim( AV19PasswordConf), StringUtil.RTrim( context.localUtil.Format( AV19PasswordConf, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_GAM_Passwordconfirmation", ""), edtavPasswordconf_Jsonclick, 0, "AttributeRegister", "", "", "", "", 1, edtavPasswordconf_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, -1, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMPassword", "start", true, "", "HLP_GAMRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFirstname_cell_Internalname, 1, 0, "px", 0, "px", divFirstname_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFirstname_Internalname, context.GetMessage( "First Name", ""), "col-sm-3 AttributeRegisterLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFirstname_Internalname, StringUtil.RTrim( AV9FirstName), StringUtil.RTrim( context.localUtil.Format( AV9FirstName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_GAM_FirstName", ""), edtavFirstname_Jsonclick, 0, "AttributeRegister", "", "", "", "", 1, edtavFirstname_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLastname_cell_Internalname, 1, 0, "px", 0, "px", divLastname_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLastname_Internalname, context.GetMessage( "Last Name", ""), "col-sm-3 AttributeRegisterLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLastname_Internalname, StringUtil.RTrim( AV13LastName), StringUtil.RTrim( context.localUtil.Format( AV13LastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_GAM_LastName", ""), edtavLastname_Jsonclick, 0, "AttributeRegister", "", "", "", "", 1, edtavLastname_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingLogin", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divActions_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "justify-content:flex-end;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", context.GetMessage( "WWP_GAM_Register", ""), bttBtnenter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "WWP_GAM_Back", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START0S2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Register user ", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0S0( ) ;
      }

      protected void WS0S2( )
      {
         START0S2( ) ;
         EVT0S2( ) ;
      }

      protected void EVT0S2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E110S2 ();
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
                                    E120S2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E130S2 ();
                              /* No code required for Cancel button. It is implemented as the Reset button. */
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
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0S2( )
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

      protected void PA0S2( )
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
               GX_FocusControl = edtavName_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
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
         RF0S2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF0S2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E130S2 ();
            WB0S0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0S2( )
      {
         GxWebStd.gx_hidden_field( context, "vBIRTHDAY", context.localUtil.DToC( AV6Birthday, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vBIRTHDAY", GetSecureSignedToken( "", AV6Birthday, context));
         GxWebStd.gx_hidden_field( context, "vGENDER", StringUtil.RTrim( AV12Gender));
         GxWebStd.gx_hidden_field( context, "gxhash_vGENDER", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV12Gender, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSERREMEMBERME", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28UserRememberMe), 2, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERREMEMBERME", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV28UserRememberMe), "Z9"), context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0S0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110S2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            AV17Name = cgiGet( edtavName_Internalname);
            AssignAttri("", false, "AV17Name", AV17Name);
            AV7EMail = cgiGet( edtavEmail_Internalname);
            AssignAttri("", false, "AV7EMail", AV7EMail);
            AV18Password = cgiGet( edtavPassword_Internalname);
            AssignAttri("", false, "AV18Password", AV18Password);
            AV19PasswordConf = cgiGet( edtavPasswordconf_Internalname);
            AssignAttri("", false, "AV19PasswordConf", AV19PasswordConf);
            AV9FirstName = cgiGet( edtavFirstname_Internalname);
            AssignAttri("", false, "AV9FirstName", AV9FirstName);
            AV13LastName = cgiGet( edtavLastname_Internalname);
            AssignAttri("", false, "AV13LastName", AV13LastName);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E110S2 ();
         if (returnInSub) return;
      }

      protected void E110S2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Backcolor = GXUtil.RGB( 238, 238, 238);
         AssignProp("", false, "FORM", "Backcolor", StringUtil.LTrimStr( (decimal)(Form.Backcolor), 9, 0), true);
         divLayoutmaintable_Class = "MainContainer";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         edtavPassword_Ispassword = 1;
         AssignProp("", false, edtavPassword_Internalname, "Ispassword", StringUtil.Str( (decimal)(edtavPassword_Ispassword), 1, 0), true);
         AV26Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if (returnInSub) return;
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E120S2 ();
         if (returnInSub) return;
      }

      protected void E120S2( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S122 ();
         if (returnInSub) return;
         if ( AV29CheckRequiredFieldsResult )
         {
            AV26Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
            if ( StringUtil.StrCmp(AV18Password, AV19PasswordConf) == 0 )
            {
               AV27User.gxTpr_Name = AV17Name;
               AV27User.gxTpr_Email = AV7EMail;
               AV27User.gxTpr_Firstname = AV9FirstName;
               AV27User.gxTpr_Lastname = AV13LastName;
               AV27User.gxTpr_Birthday = AV6Birthday;
               AV27User.gxTpr_Gender = AV12Gender;
               AV27User.gxTpr_Password = AV18Password;
               AV27User.save();
               if ( AV27User.success() )
               {
                  context.CommitDataStores("gamregisteruser",pr_default);
                  if ( StringUtil.StrCmp(AV26Repository.gxTpr_Useractivationmethod, "A") == 0 )
                  {
                     AV24AdditionalParameter.gxTpr_Rememberusertype = AV28UserRememberMe;
                     AV15LoginOK = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).login(AV17Name, AV18Password, AV24AdditionalParameter, out  AV8Errors);
                     if ( AV15LoginOK )
                     {
                        new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).applicationgohome("8d9934db-05db-4d64-adba-5e0466c3appU") ;
                     }
                     else
                     {
                        /* Execute user subroutine: 'DISPLAYMESSAGES' */
                        S132 ();
                        if (returnInSub) return;
                     }
                  }
                  else
                  {
                     AV14LinkURL = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).applicationgetaccountactivationurl("");
                     if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14LinkURL)) )
                     {
                        AV33GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context).get();
                        AV14LinkURL = StringUtil.Trim( AV33GAMApplication.gxTpr_Environment.gxTpr_Url) + formatLink("gamactivateuseraccount.aspx", new object[] {UrlEncode(StringUtil.RTrim(""))}, new string[] {"ActivationKey"}) ;
                        AV14LinkURL += "?%1";
                     }
                     new gam_checkuseractivationmethod(context ).execute(  AV27User.gxTpr_Guid,  AV14LinkURL, out  AV16Messages) ;
                     AV34GXV1 = 1;
                     while ( AV34GXV1 <= AV16Messages.Count )
                     {
                        AV20Message = ((GeneXus.Utils.SdtMessages_Message)AV16Messages.Item(AV34GXV1));
                        GX_msglist.addItem(AV20Message.gxTpr_Description);
                        AV34GXV1 = (int)(AV34GXV1+1);
                     }
                  }
               }
               else
               {
                  AV8Errors = AV27User.geterrors();
                  /* Execute user subroutine: 'DISPLAYMESSAGES' */
                  S132 ();
                  if (returnInSub) return;
               }
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "WWP_GAM_PasswordNotMatch", ""));
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV26Repository", AV26Repository);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27User", AV27User);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24AdditionalParameter", AV24AdditionalParameter);
      }

      protected void S122( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV29CheckRequiredFieldsResult = true;
         AssignAttri("", false, "AV29CheckRequiredFieldsResult", AV29CheckRequiredFieldsResult);
         if ( ( true ) && String.IsNullOrEmpty(StringUtil.RTrim( AV17Name)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "WWP_GAM_Name", ""), "", "", "", "", "", "", "", ""),  "error",  edtavName_Internalname,  "true",  ""));
            AV29CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV29CheckRequiredFieldsResult", AV29CheckRequiredFieldsResult);
         }
         if ( ( AV26Repository.gxTpr_Requiredemail ) && String.IsNullOrEmpty(StringUtil.RTrim( AV7EMail)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "WWP_GAM_Email", ""), "", "", "", "", "", "", "", ""),  "error",  edtavEmail_Internalname,  "true",  ""));
            AV29CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV29CheckRequiredFieldsResult", AV29CheckRequiredFieldsResult);
         }
         if ( ( AV26Repository.gxTpr_Requiredpassword ) && String.IsNullOrEmpty(StringUtil.RTrim( AV18Password)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "WWP_GAM_Password", ""), "", "", "", "", "", "", "", ""),  "error",  edtavPassword_Internalname,  "true",  ""));
            AV29CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV29CheckRequiredFieldsResult", AV29CheckRequiredFieldsResult);
         }
         if ( ( AV26Repository.gxTpr_Requiredpassword ) && String.IsNullOrEmpty(StringUtil.RTrim( AV19PasswordConf)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "WWP_GAM_Passwordconfirmation", ""), "", "", "", "", "", "", "", ""),  "error",  edtavPasswordconf_Internalname,  "true",  ""));
            AV29CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV29CheckRequiredFieldsResult", AV29CheckRequiredFieldsResult);
         }
         if ( ( AV26Repository.gxTpr_Requiredfirstname ) && String.IsNullOrEmpty(StringUtil.RTrim( AV9FirstName)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "WWP_GAM_FirstName", ""), "", "", "", "", "", "", "", ""),  "error",  edtavFirstname_Internalname,  "true",  ""));
            AV29CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV29CheckRequiredFieldsResult", AV29CheckRequiredFieldsResult);
         }
         if ( ( AV26Repository.gxTpr_Requiredlastname ) && String.IsNullOrEmpty(StringUtil.RTrim( AV13LastName)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "WWP_GAM_LastName", ""), "", "", "", "", "", "", "", ""),  "error",  edtavLastname_Internalname,  "true",  ""));
            AV29CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV29CheckRequiredFieldsResult", AV29CheckRequiredFieldsResult);
         }
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( true )
         {
            divName_cell_Class = "col-xs-12 col-sm-6 RequiredDataContentCellLogin CellPaddingLogin";
            AssignProp("", false, divName_cell_Internalname, "Class", divName_cell_Class, true);
         }
         else
         {
            divName_cell_Class = "col-xs-12 col-sm-6 DataContentCellLogin CellPaddingLogin";
            AssignProp("", false, divName_cell_Internalname, "Class", divName_cell_Class, true);
         }
         if ( AV26Repository.gxTpr_Requiredemail )
         {
            divEmail_cell_Class = "col-xs-12 col-sm-6 RequiredDataContentCellLogin CellPaddingLogin";
            AssignProp("", false, divEmail_cell_Internalname, "Class", divEmail_cell_Class, true);
         }
         else
         {
            divEmail_cell_Class = "col-xs-12 col-sm-6 DataContentCellLogin CellPaddingLogin";
            AssignProp("", false, divEmail_cell_Internalname, "Class", divEmail_cell_Class, true);
         }
         if ( AV26Repository.gxTpr_Requiredpassword )
         {
            divPassword_cell_Class = "col-xs-12 col-sm-6 RequiredDataContentCellLogin CellPaddingLogin";
            AssignProp("", false, divPassword_cell_Internalname, "Class", divPassword_cell_Class, true);
         }
         else
         {
            divPassword_cell_Class = "col-xs-12 col-sm-6 DataContentCellLogin CellPaddingLogin";
            AssignProp("", false, divPassword_cell_Internalname, "Class", divPassword_cell_Class, true);
         }
         if ( AV26Repository.gxTpr_Requiredpassword )
         {
            divPasswordconf_cell_Class = "col-xs-12 col-sm-6 RequiredDataContentCellLogin CellPaddingLogin";
            AssignProp("", false, divPasswordconf_cell_Internalname, "Class", divPasswordconf_cell_Class, true);
         }
         else
         {
            divPasswordconf_cell_Class = "col-xs-12 col-sm-6 DataContentCellLogin CellPaddingLogin";
            AssignProp("", false, divPasswordconf_cell_Internalname, "Class", divPasswordconf_cell_Class, true);
         }
         if ( AV26Repository.gxTpr_Requiredfirstname )
         {
            divFirstname_cell_Class = "col-xs-12 col-sm-6 RequiredDataContentCellLogin CellPaddingLogin";
            AssignProp("", false, divFirstname_cell_Internalname, "Class", divFirstname_cell_Class, true);
         }
         else
         {
            divFirstname_cell_Class = "col-xs-12 col-sm-6 DataContentCellLogin CellPaddingLogin";
            AssignProp("", false, divFirstname_cell_Internalname, "Class", divFirstname_cell_Class, true);
         }
         if ( AV26Repository.gxTpr_Requiredlastname )
         {
            divLastname_cell_Class = "col-xs-12 col-sm-6 RequiredDataContentCellLogin CellPaddingLogin";
            AssignProp("", false, divLastname_cell_Internalname, "Class", divLastname_cell_Class, true);
         }
         else
         {
            divLastname_cell_Class = "col-xs-12 col-sm-6 DataContentCellLogin CellPaddingLogin";
            AssignProp("", false, divLastname_cell_Internalname, "Class", divLastname_cell_Class, true);
         }
      }

      protected void S132( )
      {
         /* 'DISPLAYMESSAGES' Routine */
         returnInSub = false;
         AV35GXV2 = 1;
         while ( AV35GXV2 <= AV8Errors.Count )
         {
            AV25Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV8Errors.Item(AV35GXV2));
            GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV25Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV25Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
            AV35GXV2 = (int)(AV35GXV2+1);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E130S2( )
      {
         /* Load Routine */
         returnInSub = false;
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
         PA0S2( ) ;
         WS0S2( ) ;
         WE0S2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024824414280", true, true);
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
         context.AddJavascriptSource("gamregisteruser.js", "?2024824414283", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         imgHeaderoriginal_Internalname = "HEADERORIGINAL";
         lblSignin_Internalname = "SIGNIN";
         edtavName_Internalname = "vNAME";
         divName_cell_Internalname = "NAME_CELL";
         edtavEmail_Internalname = "vEMAIL";
         divEmail_cell_Internalname = "EMAIL_CELL";
         edtavPassword_Internalname = "vPASSWORD";
         divPassword_cell_Internalname = "PASSWORD_CELL";
         edtavPasswordconf_Internalname = "vPASSWORDCONF";
         divPasswordconf_cell_Internalname = "PASSWORDCONF_CELL";
         edtavFirstname_Internalname = "vFIRSTNAME";
         divFirstname_cell_Internalname = "FIRSTNAME_CELL";
         edtavLastname_Internalname = "vLASTNAME";
         divLastname_cell_Internalname = "LASTNAME_CELL";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         divActions_Internalname = "ACTIONS";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         divTablelogin_Internalname = "TABLELOGIN";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtavLastname_Jsonclick = "";
         edtavLastname_Enabled = 1;
         divLastname_cell_Class = "col-xs-12 col-sm-6";
         edtavFirstname_Jsonclick = "";
         edtavFirstname_Enabled = 1;
         divFirstname_cell_Class = "col-xs-12 col-sm-6";
         edtavPasswordconf_Jsonclick = "";
         edtavPasswordconf_Enabled = 1;
         divPasswordconf_cell_Class = "col-xs-12 col-sm-6";
         edtavPassword_Jsonclick = "";
         edtavPassword_Ispassword = -1;
         edtavPassword_Enabled = 1;
         divPassword_cell_Class = "col-xs-12 col-sm-6";
         edtavEmail_Jsonclick = "";
         edtavEmail_Enabled = 1;
         divEmail_cell_Class = "col-xs-12 col-sm-6";
         edtavName_Jsonclick = "";
         edtavName_Enabled = 1;
         divName_cell_Class = "col-xs-12 col-sm-6";
         divLayoutmaintable_Class = "Table";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Register user ", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV6Birthday',fld:'vBIRTHDAY',pic:'',hsh:true},{av:'AV12Gender',fld:'vGENDER',pic:'',hsh:true},{av:'AV28UserRememberMe',fld:'vUSERREMEMBERME',pic:'Z9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("ENTER","{handler:'E120S2',iparms:[{av:'AV29CheckRequiredFieldsResult',fld:'vCHECKREQUIREDFIELDSRESULT',pic:''},{av:'AV18Password',fld:'vPASSWORD',pic:''},{av:'AV19PasswordConf',fld:'vPASSWORDCONF',pic:''},{av:'AV17Name',fld:'vNAME',pic:''},{av:'AV7EMail',fld:'vEMAIL',pic:''},{av:'AV9FirstName',fld:'vFIRSTNAME',pic:''},{av:'AV13LastName',fld:'vLASTNAME',pic:''},{av:'AV6Birthday',fld:'vBIRTHDAY',pic:'',hsh:true},{av:'AV12Gender',fld:'vGENDER',pic:'',hsh:true},{av:'AV28UserRememberMe',fld:'vUSERREMEMBERME',pic:'Z9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV29CheckRequiredFieldsResult',fld:'vCHECKREQUIREDFIELDSRESULT',pic:''}]}");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         AV6Birthday = DateTime.MinValue;
         AV12Gender = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         imgHeaderoriginal_gximage = "";
         StyleString = "";
         sImgUrl = "";
         lblSignin_Jsonclick = "";
         TempTags = "";
         AV17Name = "";
         AV7EMail = "";
         AV18Password = "";
         AV19PasswordConf = "";
         AV9FirstName = "";
         AV13LastName = "";
         bttBtnenter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV26Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV27User = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV24AdditionalParameter = new GeneXus.Programs.genexussecurity.SdtGAMLoginAdditionalParameters(context);
         AV8Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV14LinkURL = "";
         AV33GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV16Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV20Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV25Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.gamregisteruser__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gamregisteruser__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short AV28UserRememberMe ;
      private short wbEnd ;
      private short wbStart ;
      private short edtavPassword_Ispassword ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavName_Enabled ;
      private int edtavEmail_Enabled ;
      private int edtavPassword_Enabled ;
      private int edtavPasswordconf_Enabled ;
      private int edtavFirstname_Enabled ;
      private int edtavLastname_Enabled ;
      private int AV34GXV1 ;
      private int AV35GXV2 ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string AV12Gender ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string divTablecontent_Internalname ;
      private string ClassString ;
      private string imgHeaderoriginal_gximage ;
      private string StyleString ;
      private string sImgUrl ;
      private string imgHeaderoriginal_Internalname ;
      private string divTablelogin_Internalname ;
      private string lblSignin_Internalname ;
      private string lblSignin_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string divName_cell_Internalname ;
      private string divName_cell_Class ;
      private string edtavName_Internalname ;
      private string TempTags ;
      private string edtavName_Jsonclick ;
      private string divEmail_cell_Internalname ;
      private string divEmail_cell_Class ;
      private string edtavEmail_Internalname ;
      private string edtavEmail_Jsonclick ;
      private string divPassword_cell_Internalname ;
      private string divPassword_cell_Class ;
      private string edtavPassword_Internalname ;
      private string AV18Password ;
      private string edtavPassword_Jsonclick ;
      private string divPasswordconf_cell_Internalname ;
      private string divPasswordconf_cell_Class ;
      private string edtavPasswordconf_Internalname ;
      private string AV19PasswordConf ;
      private string edtavPasswordconf_Jsonclick ;
      private string divFirstname_cell_Internalname ;
      private string divFirstname_cell_Class ;
      private string edtavFirstname_Internalname ;
      private string AV9FirstName ;
      private string edtavFirstname_Jsonclick ;
      private string divLastname_cell_Internalname ;
      private string divLastname_cell_Class ;
      private string edtavLastname_Internalname ;
      private string AV13LastName ;
      private string edtavLastname_Jsonclick ;
      private string divActions_Internalname ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private DateTime AV6Birthday ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV29CheckRequiredFieldsResult ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV15LoginOK ;
      private string AV17Name ;
      private string AV7EMail ;
      private string AV14LinkURL ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV8Errors ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV16Messages ;
      private GXWebForm Form ;
      private GeneXus.Programs.genexussecurity.SdtGAMLoginAdditionalParameters AV24AdditionalParameter ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV25Error ;
      private GeneXus.Utils.SdtMessages_Message AV20Message ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV26Repository ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV27User ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV33GAMApplication ;
   }

   public class gamregisteruser__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class gamregisteruser__default : DataStoreHelperBase, IDataStoreHelper
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

}

}
