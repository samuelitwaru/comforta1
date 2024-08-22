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
   public class pagetemplate_bc : GxSilentTrn, IGxSilentTrn
   {
      public pagetemplate_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public pagetemplate_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow0D22( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0D22( ) ;
         standaloneModal( ) ;
         AddRow0D22( ) ;
         Gx_mode = "INS";
         return  ;
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E110D2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z102PageTemplateId = A102PageTemplateId;
               SetMode( "UPD") ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_0D0( )
      {
         BeforeValidate0D22( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0D22( ) ;
            }
            else
            {
               CheckExtendedTable0D22( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0D22( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E120D2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110D2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0D22( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z103PageTemplateName = A103PageTemplateName;
            Z106PageTemplateDescription = A106PageTemplateDescription;
         }
         if ( GX_JID == -1 )
         {
            Z102PageTemplateId = A102PageTemplateId;
            Z103PageTemplateName = A103PageTemplateName;
            Z106PageTemplateDescription = A106PageTemplateDescription;
            Z114PageTemplateHtml = A114PageTemplateHtml;
            Z113PageTemplateCSS = A113PageTemplateCSS;
            Z105PageTemplateImage = A105PageTemplateImage;
            Z40000PageTemplateImage_GXI = A40000PageTemplateImage_GXI;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0D22( )
      {
         /* Using cursor BC000D4 */
         pr_default.execute(2, new Object[] {A102PageTemplateId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound22 = 1;
            A103PageTemplateName = BC000D4_A103PageTemplateName[0];
            A106PageTemplateDescription = BC000D4_A106PageTemplateDescription[0];
            A114PageTemplateHtml = BC000D4_A114PageTemplateHtml[0];
            A113PageTemplateCSS = BC000D4_A113PageTemplateCSS[0];
            A40000PageTemplateImage_GXI = BC000D4_A40000PageTemplateImage_GXI[0];
            A105PageTemplateImage = BC000D4_A105PageTemplateImage[0];
            ZM0D22( -1) ;
         }
         pr_default.close(2);
         OnLoadActions0D22( ) ;
      }

      protected void OnLoadActions0D22( )
      {
      }

      protected void CheckExtendedTable0D22( )
      {
         nIsDirty_22 = 0;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0D22( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0D22( )
      {
         /* Using cursor BC000D5 */
         pr_default.execute(3, new Object[] {A102PageTemplateId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound22 = 1;
         }
         else
         {
            RcdFound22 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000D3 */
         pr_default.execute(1, new Object[] {A102PageTemplateId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0D22( 1) ;
            RcdFound22 = 1;
            A102PageTemplateId = BC000D3_A102PageTemplateId[0];
            A103PageTemplateName = BC000D3_A103PageTemplateName[0];
            A106PageTemplateDescription = BC000D3_A106PageTemplateDescription[0];
            A114PageTemplateHtml = BC000D3_A114PageTemplateHtml[0];
            A113PageTemplateCSS = BC000D3_A113PageTemplateCSS[0];
            A40000PageTemplateImage_GXI = BC000D3_A40000PageTemplateImage_GXI[0];
            A105PageTemplateImage = BC000D3_A105PageTemplateImage[0];
            Z102PageTemplateId = A102PageTemplateId;
            sMode22 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0D22( ) ;
            if ( AnyError == 1 )
            {
               RcdFound22 = 0;
               InitializeNonKey0D22( ) ;
            }
            Gx_mode = sMode22;
         }
         else
         {
            RcdFound22 = 0;
            InitializeNonKey0D22( ) ;
            sMode22 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode22;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0D22( ) ;
         if ( RcdFound22 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_0D0( ) ;
         IsConfirmed = 0;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0D22( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000D2 */
            pr_default.execute(0, new Object[] {A102PageTemplateId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PageTemplate"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z103PageTemplateName, BC000D2_A103PageTemplateName[0]) != 0 ) || ( StringUtil.StrCmp(Z106PageTemplateDescription, BC000D2_A106PageTemplateDescription[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"PageTemplate"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0D22( )
      {
         BeforeValidate0D22( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D22( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0D22( 0) ;
            CheckOptimisticConcurrency0D22( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0D22( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0D22( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000D6 */
                     pr_default.execute(4, new Object[] {A103PageTemplateName, A106PageTemplateDescription, A114PageTemplateHtml, A113PageTemplateCSS, A105PageTemplateImage, A40000PageTemplateImage_GXI});
                     pr_default.close(4);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000D7 */
                     pr_default.execute(5);
                     A102PageTemplateId = BC000D7_A102PageTemplateId[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("PageTemplate");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load0D22( ) ;
            }
            EndLevel0D22( ) ;
         }
         CloseExtendedTableCursors0D22( ) ;
      }

      protected void Update0D22( )
      {
         BeforeValidate0D22( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D22( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0D22( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0D22( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0D22( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000D8 */
                     pr_default.execute(6, new Object[] {A103PageTemplateName, A106PageTemplateDescription, A114PageTemplateHtml, A113PageTemplateCSS, A102PageTemplateId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("PageTemplate");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PageTemplate"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0D22( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel0D22( ) ;
         }
         CloseExtendedTableCursors0D22( ) ;
      }

      protected void DeferredUpdate0D22( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC000D9 */
            pr_default.execute(7, new Object[] {A105PageTemplateImage, A40000PageTemplateImage_GXI, A102PageTemplateId});
            pr_default.close(7);
            pr_default.SmartCacheProvider.SetUpdated("PageTemplate");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0D22( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0D22( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0D22( ) ;
            AfterConfirm0D22( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0D22( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000D10 */
                  pr_default.execute(8, new Object[] {A102PageTemplateId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("PageTemplate");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode22 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0D22( ) ;
         Gx_mode = sMode22;
      }

      protected void OnDeleteControls0D22( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0D22( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0D22( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0D22( )
      {
         /* Scan By routine */
         /* Using cursor BC000D11 */
         pr_default.execute(9, new Object[] {A102PageTemplateId});
         RcdFound22 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound22 = 1;
            A102PageTemplateId = BC000D11_A102PageTemplateId[0];
            A103PageTemplateName = BC000D11_A103PageTemplateName[0];
            A106PageTemplateDescription = BC000D11_A106PageTemplateDescription[0];
            A114PageTemplateHtml = BC000D11_A114PageTemplateHtml[0];
            A113PageTemplateCSS = BC000D11_A113PageTemplateCSS[0];
            A40000PageTemplateImage_GXI = BC000D11_A40000PageTemplateImage_GXI[0];
            A105PageTemplateImage = BC000D11_A105PageTemplateImage[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0D22( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound22 = 0;
         ScanKeyLoad0D22( ) ;
      }

      protected void ScanKeyLoad0D22( )
      {
         sMode22 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound22 = 1;
            A102PageTemplateId = BC000D11_A102PageTemplateId[0];
            A103PageTemplateName = BC000D11_A103PageTemplateName[0];
            A106PageTemplateDescription = BC000D11_A106PageTemplateDescription[0];
            A114PageTemplateHtml = BC000D11_A114PageTemplateHtml[0];
            A113PageTemplateCSS = BC000D11_A113PageTemplateCSS[0];
            A40000PageTemplateImage_GXI = BC000D11_A40000PageTemplateImage_GXI[0];
            A105PageTemplateImage = BC000D11_A105PageTemplateImage[0];
         }
         Gx_mode = sMode22;
      }

      protected void ScanKeyEnd0D22( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm0D22( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0D22( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0D22( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0D22( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0D22( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0D22( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0D22( )
      {
      }

      protected void send_integrity_lvl_hashes0D22( )
      {
      }

      protected void AddRow0D22( )
      {
         VarsToRow22( bcPageTemplate) ;
      }

      protected void ReadRow0D22( )
      {
         RowToVars22( bcPageTemplate, 1) ;
      }

      protected void InitializeNonKey0D22( )
      {
         A103PageTemplateName = "";
         A106PageTemplateDescription = "";
         A114PageTemplateHtml = "";
         A113PageTemplateCSS = "";
         A105PageTemplateImage = "";
         A40000PageTemplateImage_GXI = "";
         Z103PageTemplateName = "";
         Z106PageTemplateDescription = "";
      }

      protected void InitAll0D22( )
      {
         A102PageTemplateId = 0;
         InitializeNonKey0D22( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void VarsToRow22( SdtPageTemplate obj22 )
      {
         obj22.gxTpr_Mode = Gx_mode;
         obj22.gxTpr_Pagetemplatename = A103PageTemplateName;
         obj22.gxTpr_Pagetemplatedescription = A106PageTemplateDescription;
         obj22.gxTpr_Pagetemplatehtml = A114PageTemplateHtml;
         obj22.gxTpr_Pagetemplatecss = A113PageTemplateCSS;
         obj22.gxTpr_Pagetemplateimage = A105PageTemplateImage;
         obj22.gxTpr_Pagetemplateimage_gxi = A40000PageTemplateImage_GXI;
         obj22.gxTpr_Pagetemplateid = A102PageTemplateId;
         obj22.gxTpr_Pagetemplateid_Z = Z102PageTemplateId;
         obj22.gxTpr_Pagetemplatename_Z = Z103PageTemplateName;
         obj22.gxTpr_Pagetemplatedescription_Z = Z106PageTemplateDescription;
         obj22.gxTpr_Pagetemplateimage_gxi_Z = Z40000PageTemplateImage_GXI;
         obj22.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow22( SdtPageTemplate obj22 )
      {
         obj22.gxTpr_Pagetemplateid = A102PageTemplateId;
         return  ;
      }

      public void RowToVars22( SdtPageTemplate obj22 ,
                               int forceLoad )
      {
         Gx_mode = obj22.gxTpr_Mode;
         A103PageTemplateName = obj22.gxTpr_Pagetemplatename;
         A106PageTemplateDescription = obj22.gxTpr_Pagetemplatedescription;
         A114PageTemplateHtml = obj22.gxTpr_Pagetemplatehtml;
         A113PageTemplateCSS = obj22.gxTpr_Pagetemplatecss;
         A105PageTemplateImage = obj22.gxTpr_Pagetemplateimage;
         A40000PageTemplateImage_GXI = obj22.gxTpr_Pagetemplateimage_gxi;
         A102PageTemplateId = obj22.gxTpr_Pagetemplateid;
         Z102PageTemplateId = obj22.gxTpr_Pagetemplateid_Z;
         Z103PageTemplateName = obj22.gxTpr_Pagetemplatename_Z;
         Z106PageTemplateDescription = obj22.gxTpr_Pagetemplatedescription_Z;
         Z40000PageTemplateImage_GXI = obj22.gxTpr_Pagetemplateimage_gxi_Z;
         Gx_mode = obj22.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A102PageTemplateId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0D22( ) ;
         ScanKeyStart0D22( ) ;
         if ( RcdFound22 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z102PageTemplateId = A102PageTemplateId;
         }
         ZM0D22( -1) ;
         OnLoadActions0D22( ) ;
         AddRow0D22( ) ;
         ScanKeyEnd0D22( ) ;
         if ( RcdFound22 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars22( bcPageTemplate, 0) ;
         ScanKeyStart0D22( ) ;
         if ( RcdFound22 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z102PageTemplateId = A102PageTemplateId;
         }
         ZM0D22( -1) ;
         OnLoadActions0D22( ) ;
         AddRow0D22( ) ;
         ScanKeyEnd0D22( ) ;
         if ( RcdFound22 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0D22( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0D22( ) ;
         }
         else
         {
            if ( RcdFound22 == 1 )
            {
               if ( A102PageTemplateId != Z102PageTemplateId )
               {
                  A102PageTemplateId = Z102PageTemplateId;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update0D22( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( A102PageTemplateId != Z102PageTemplateId )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert0D22( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert0D22( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars22( bcPageTemplate, 1) ;
         SaveImpl( ) ;
         VarsToRow22( bcPageTemplate) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars22( bcPageTemplate, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0D22( ) ;
         AfterTrn( ) ;
         VarsToRow22( bcPageTemplate) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow22( bcPageTemplate) ;
         }
         else
         {
            SdtPageTemplate auxBC = new SdtPageTemplate(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A102PageTemplateId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcPageTemplate);
               auxBC.Save();
               bcPageTemplate.Copy((GxSilentTrnSdt)(auxBC));
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars22( bcPageTemplate, 1) ;
         UpdateImpl( ) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars22( bcPageTemplate, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0D22( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
            else
            {
               VarsToRow22( bcPageTemplate) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow22( bcPageTemplate) ;
         }
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars22( bcPageTemplate, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0D22( ) ;
         if ( RcdFound22 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A102PageTemplateId != Z102PageTemplateId )
            {
               A102PageTemplateId = Z102PageTemplateId;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( A102PageTemplateId != Z102PageTemplateId )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         context.RollbackDataStores("pagetemplate_bc",pr_default);
         VarsToRow22( bcPageTemplate) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bcPageTemplate.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcPageTemplate.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcPageTemplate )
         {
            bcPageTemplate = (SdtPageTemplate)(sdt);
            if ( StringUtil.StrCmp(bcPageTemplate.gxTpr_Mode, "") == 0 )
            {
               bcPageTemplate.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow22( bcPageTemplate) ;
            }
            else
            {
               RowToVars22( bcPageTemplate, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcPageTemplate.gxTpr_Mode, "") == 0 )
            {
               bcPageTemplate.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars22( bcPageTemplate, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtPageTemplate PageTemplate_BC
      {
         get {
            return bcPageTemplate ;
         }

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
            return "pagetemplate_Execute" ;
         }

      }

      public void webExecute( )
      {
         createObjects();
         initialize();
      }

      public bool isMasterPage( )
      {
         return false;
      }

      protected void createObjects( )
      {
      }

      protected void Process( )
      {
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
         pr_default.close(1);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         Z103PageTemplateName = "";
         A103PageTemplateName = "";
         Z106PageTemplateDescription = "";
         A106PageTemplateDescription = "";
         Z114PageTemplateHtml = "";
         A114PageTemplateHtml = "";
         Z113PageTemplateCSS = "";
         A113PageTemplateCSS = "";
         Z105PageTemplateImage = "";
         A105PageTemplateImage = "";
         Z40000PageTemplateImage_GXI = "";
         A40000PageTemplateImage_GXI = "";
         BC000D4_A102PageTemplateId = new short[1] ;
         BC000D4_A103PageTemplateName = new string[] {""} ;
         BC000D4_A106PageTemplateDescription = new string[] {""} ;
         BC000D4_A114PageTemplateHtml = new string[] {""} ;
         BC000D4_A113PageTemplateCSS = new string[] {""} ;
         BC000D4_A40000PageTemplateImage_GXI = new string[] {""} ;
         BC000D4_A105PageTemplateImage = new string[] {""} ;
         BC000D5_A102PageTemplateId = new short[1] ;
         BC000D3_A102PageTemplateId = new short[1] ;
         BC000D3_A103PageTemplateName = new string[] {""} ;
         BC000D3_A106PageTemplateDescription = new string[] {""} ;
         BC000D3_A114PageTemplateHtml = new string[] {""} ;
         BC000D3_A113PageTemplateCSS = new string[] {""} ;
         BC000D3_A40000PageTemplateImage_GXI = new string[] {""} ;
         BC000D3_A105PageTemplateImage = new string[] {""} ;
         sMode22 = "";
         BC000D2_A102PageTemplateId = new short[1] ;
         BC000D2_A103PageTemplateName = new string[] {""} ;
         BC000D2_A106PageTemplateDescription = new string[] {""} ;
         BC000D2_A114PageTemplateHtml = new string[] {""} ;
         BC000D2_A113PageTemplateCSS = new string[] {""} ;
         BC000D2_A40000PageTemplateImage_GXI = new string[] {""} ;
         BC000D2_A105PageTemplateImage = new string[] {""} ;
         BC000D7_A102PageTemplateId = new short[1] ;
         BC000D11_A102PageTemplateId = new short[1] ;
         BC000D11_A103PageTemplateName = new string[] {""} ;
         BC000D11_A106PageTemplateDescription = new string[] {""} ;
         BC000D11_A114PageTemplateHtml = new string[] {""} ;
         BC000D11_A113PageTemplateCSS = new string[] {""} ;
         BC000D11_A40000PageTemplateImage_GXI = new string[] {""} ;
         BC000D11_A105PageTemplateImage = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.pagetemplate_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pagetemplate_bc__default(),
            new Object[][] {
                new Object[] {
               BC000D2_A102PageTemplateId, BC000D2_A103PageTemplateName, BC000D2_A106PageTemplateDescription, BC000D2_A114PageTemplateHtml, BC000D2_A113PageTemplateCSS, BC000D2_A40000PageTemplateImage_GXI, BC000D2_A105PageTemplateImage
               }
               , new Object[] {
               BC000D3_A102PageTemplateId, BC000D3_A103PageTemplateName, BC000D3_A106PageTemplateDescription, BC000D3_A114PageTemplateHtml, BC000D3_A113PageTemplateCSS, BC000D3_A40000PageTemplateImage_GXI, BC000D3_A105PageTemplateImage
               }
               , new Object[] {
               BC000D4_A102PageTemplateId, BC000D4_A103PageTemplateName, BC000D4_A106PageTemplateDescription, BC000D4_A114PageTemplateHtml, BC000D4_A113PageTemplateCSS, BC000D4_A40000PageTemplateImage_GXI, BC000D4_A105PageTemplateImage
               }
               , new Object[] {
               BC000D5_A102PageTemplateId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000D7_A102PageTemplateId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000D11_A102PageTemplateId, BC000D11_A103PageTemplateName, BC000D11_A106PageTemplateDescription, BC000D11_A114PageTemplateHtml, BC000D11_A113PageTemplateCSS, BC000D11_A40000PageTemplateImage_GXI, BC000D11_A105PageTemplateImage
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120D2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short Z102PageTemplateId ;
      private short A102PageTemplateId ;
      private short GX_JID ;
      private short RcdFound22 ;
      private short nIsDirty_22 ;
      private int trnEnded ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode22 ;
      private bool returnInSub ;
      private bool mustCommit ;
      private string Z114PageTemplateHtml ;
      private string A114PageTemplateHtml ;
      private string Z113PageTemplateCSS ;
      private string A113PageTemplateCSS ;
      private string Z103PageTemplateName ;
      private string A103PageTemplateName ;
      private string Z106PageTemplateDescription ;
      private string A106PageTemplateDescription ;
      private string Z40000PageTemplateImage_GXI ;
      private string A40000PageTemplateImage_GXI ;
      private string Z105PageTemplateImage ;
      private string A105PageTemplateImage ;
      private IGxSession AV12WebSession ;
      private SdtPageTemplate bcPageTemplate ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC000D4_A102PageTemplateId ;
      private string[] BC000D4_A103PageTemplateName ;
      private string[] BC000D4_A106PageTemplateDescription ;
      private string[] BC000D4_A114PageTemplateHtml ;
      private string[] BC000D4_A113PageTemplateCSS ;
      private string[] BC000D4_A40000PageTemplateImage_GXI ;
      private string[] BC000D4_A105PageTemplateImage ;
      private short[] BC000D5_A102PageTemplateId ;
      private short[] BC000D3_A102PageTemplateId ;
      private string[] BC000D3_A103PageTemplateName ;
      private string[] BC000D3_A106PageTemplateDescription ;
      private string[] BC000D3_A114PageTemplateHtml ;
      private string[] BC000D3_A113PageTemplateCSS ;
      private string[] BC000D3_A40000PageTemplateImage_GXI ;
      private string[] BC000D3_A105PageTemplateImage ;
      private short[] BC000D2_A102PageTemplateId ;
      private string[] BC000D2_A103PageTemplateName ;
      private string[] BC000D2_A106PageTemplateDescription ;
      private string[] BC000D2_A114PageTemplateHtml ;
      private string[] BC000D2_A113PageTemplateCSS ;
      private string[] BC000D2_A40000PageTemplateImage_GXI ;
      private string[] BC000D2_A105PageTemplateImage ;
      private short[] BC000D7_A102PageTemplateId ;
      private short[] BC000D11_A102PageTemplateId ;
      private string[] BC000D11_A103PageTemplateName ;
      private string[] BC000D11_A106PageTemplateDescription ;
      private string[] BC000D11_A114PageTemplateHtml ;
      private string[] BC000D11_A113PageTemplateCSS ;
      private string[] BC000D11_A40000PageTemplateImage_GXI ;
      private string[] BC000D11_A105PageTemplateImage ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
   }

   public class pagetemplate_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class pagetemplate_bc__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new ForEachCursor(def[3])
       ,new UpdateCursor(def[4])
       ,new ForEachCursor(def[5])
       ,new UpdateCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new ForEachCursor(def[9])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000D4;
        prmBC000D4 = new Object[] {
        new ParDef("PageTemplateId",GXType.Int16,4,0)
        };
        Object[] prmBC000D5;
        prmBC000D5 = new Object[] {
        new ParDef("PageTemplateId",GXType.Int16,4,0)
        };
        Object[] prmBC000D3;
        prmBC000D3 = new Object[] {
        new ParDef("PageTemplateId",GXType.Int16,4,0)
        };
        Object[] prmBC000D2;
        prmBC000D2 = new Object[] {
        new ParDef("PageTemplateId",GXType.Int16,4,0)
        };
        Object[] prmBC000D6;
        prmBC000D6 = new Object[] {
        new ParDef("PageTemplateName",GXType.VarChar,40,0) ,
        new ParDef("PageTemplateDescription",GXType.VarChar,200,0) ,
        new ParDef("PageTemplateHtml",GXType.LongVarChar,2097152,0) ,
        new ParDef("PageTemplateCSS",GXType.LongVarChar,2097152,0) ,
        new ParDef("PageTemplateImage",GXType.Byte,1024,0){InDB=false} ,
        new ParDef("PageTemplateImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=4, Tbl="PageTemplate", Fld="PageTemplateImage"}
        };
        Object[] prmBC000D7;
        prmBC000D7 = new Object[] {
        };
        Object[] prmBC000D8;
        prmBC000D8 = new Object[] {
        new ParDef("PageTemplateName",GXType.VarChar,40,0) ,
        new ParDef("PageTemplateDescription",GXType.VarChar,200,0) ,
        new ParDef("PageTemplateHtml",GXType.LongVarChar,2097152,0) ,
        new ParDef("PageTemplateCSS",GXType.LongVarChar,2097152,0) ,
        new ParDef("PageTemplateId",GXType.Int16,4,0)
        };
        Object[] prmBC000D9;
        prmBC000D9 = new Object[] {
        new ParDef("PageTemplateImage",GXType.Byte,1024,0){InDB=false} ,
        new ParDef("PageTemplateImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="PageTemplate", Fld="PageTemplateImage"} ,
        new ParDef("PageTemplateId",GXType.Int16,4,0)
        };
        Object[] prmBC000D10;
        prmBC000D10 = new Object[] {
        new ParDef("PageTemplateId",GXType.Int16,4,0)
        };
        Object[] prmBC000D11;
        prmBC000D11 = new Object[] {
        new ParDef("PageTemplateId",GXType.Int16,4,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000D2", "SELECT PageTemplateId, PageTemplateName, PageTemplateDescription, PageTemplateHtml, PageTemplateCSS, PageTemplateImage_GXI, PageTemplateImage FROM PageTemplate WHERE PageTemplateId = :PageTemplateId  FOR UPDATE OF PageTemplate",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000D3", "SELECT PageTemplateId, PageTemplateName, PageTemplateDescription, PageTemplateHtml, PageTemplateCSS, PageTemplateImage_GXI, PageTemplateImage FROM PageTemplate WHERE PageTemplateId = :PageTemplateId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000D4", "SELECT TM1.PageTemplateId, TM1.PageTemplateName, TM1.PageTemplateDescription, TM1.PageTemplateHtml, TM1.PageTemplateCSS, TM1.PageTemplateImage_GXI, TM1.PageTemplateImage FROM PageTemplate TM1 WHERE TM1.PageTemplateId = :PageTemplateId ORDER BY TM1.PageTemplateId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000D5", "SELECT PageTemplateId FROM PageTemplate WHERE PageTemplateId = :PageTemplateId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000D6", "SAVEPOINT gxupdate;INSERT INTO PageTemplate(PageTemplateName, PageTemplateDescription, PageTemplateHtml, PageTemplateCSS, PageTemplateImage, PageTemplateImage_GXI) VALUES(:PageTemplateName, :PageTemplateDescription, :PageTemplateHtml, :PageTemplateCSS, :PageTemplateImage, :PageTemplateImage_GXI);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000D6)
           ,new CursorDef("BC000D7", "SELECT currval('PageTemplateId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000D8", "SAVEPOINT gxupdate;UPDATE PageTemplate SET PageTemplateName=:PageTemplateName, PageTemplateDescription=:PageTemplateDescription, PageTemplateHtml=:PageTemplateHtml, PageTemplateCSS=:PageTemplateCSS  WHERE PageTemplateId = :PageTemplateId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000D8)
           ,new CursorDef("BC000D9", "SAVEPOINT gxupdate;UPDATE PageTemplate SET PageTemplateImage=:PageTemplateImage, PageTemplateImage_GXI=:PageTemplateImage_GXI  WHERE PageTemplateId = :PageTemplateId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000D9)
           ,new CursorDef("BC000D10", "SAVEPOINT gxupdate;DELETE FROM PageTemplate  WHERE PageTemplateId = :PageTemplateId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000D10)
           ,new CursorDef("BC000D11", "SELECT TM1.PageTemplateId, TM1.PageTemplateName, TM1.PageTemplateDescription, TM1.PageTemplateHtml, TM1.PageTemplateCSS, TM1.PageTemplateImage_GXI, TM1.PageTemplateImage FROM PageTemplate TM1 WHERE TM1.PageTemplateId = :PageTemplateId ORDER BY TM1.PageTemplateId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D11,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
              ((string[]) buf[6])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(6));
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
              ((string[]) buf[6])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(6));
              return;
           case 2 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
              ((string[]) buf[6])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(6));
              return;
           case 3 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 5 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 9 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
              ((string[]) buf[6])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(6));
              return;
     }
  }

}

}
