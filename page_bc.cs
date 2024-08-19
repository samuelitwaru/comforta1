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
   public class page_bc : GxSilentTrn, IGxSilentTrn
   {
      public page_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public page_bc( IGxContext context )
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
         ReadRow0C21( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0C21( ) ;
         standaloneModal( ) ;
         AddRow0C21( ) ;
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
            E110C2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z98PageId = A98PageId;
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

      protected void CONFIRM_0C0( )
      {
         BeforeValidate0C21( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0C21( ) ;
            }
            else
            {
               CheckExtendedTable0C21( ) ;
               if ( AnyError == 0 )
               {
                  ZM0C21( 4) ;
               }
               CloseExtendedTableCursors0C21( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E120C2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV23Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV24GXV1 = 1;
            while ( AV24GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV24GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "CustomerId") == 0 )
               {
                  AV13Insert_CustomerId = (short)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV24GXV1 = (int)(AV24GXV1+1);
            }
         }
      }

      protected void E110C2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0C21( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z99PageName = A99PageName;
            Z1CustomerId = A1CustomerId;
         }
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z3CustomerName = A3CustomerName;
            Z5CustomerEmail = A5CustomerEmail;
         }
         if ( GX_JID == -3 )
         {
            Z98PageId = A98PageId;
            Z99PageName = A99PageName;
            Z100PageHtmlContent = A100PageHtmlContent;
            Z112PageCssContent = A112PageCssContent;
            Z101PageJsonContent = A101PageJsonContent;
            Z1CustomerId = A1CustomerId;
            Z3CustomerName = A3CustomerName;
            Z5CustomerEmail = A5CustomerEmail;
         }
      }

      protected void standaloneNotModal( )
      {
         AV23Pgmname = "Page_BC";
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0C21( )
      {
         /* Using cursor BC000C5 */
         pr_default.execute(3, new Object[] {A98PageId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound21 = 1;
            A99PageName = BC000C5_A99PageName[0];
            A100PageHtmlContent = BC000C5_A100PageHtmlContent[0];
            A112PageCssContent = BC000C5_A112PageCssContent[0];
            A101PageJsonContent = BC000C5_A101PageJsonContent[0];
            A3CustomerName = BC000C5_A3CustomerName[0];
            A5CustomerEmail = BC000C5_A5CustomerEmail[0];
            n5CustomerEmail = BC000C5_n5CustomerEmail[0];
            A1CustomerId = BC000C5_A1CustomerId[0];
            ZM0C21( -3) ;
         }
         pr_default.close(3);
         OnLoadActions0C21( ) ;
      }

      protected void OnLoadActions0C21( )
      {
      }

      protected void CheckExtendedTable0C21( )
      {
         nIsDirty_21 = 0;
         standaloneModal( ) ;
         /* Using cursor BC000C4 */
         pr_default.execute(2, new Object[] {A1CustomerId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Customer", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "CUSTOMERID");
            AnyError = 1;
         }
         A3CustomerName = BC000C4_A3CustomerName[0];
         A5CustomerEmail = BC000C4_A5CustomerEmail[0];
         n5CustomerEmail = BC000C4_n5CustomerEmail[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0C21( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0C21( )
      {
         /* Using cursor BC000C6 */
         pr_default.execute(4, new Object[] {A98PageId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound21 = 1;
         }
         else
         {
            RcdFound21 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000C3 */
         pr_default.execute(1, new Object[] {A98PageId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0C21( 3) ;
            RcdFound21 = 1;
            A98PageId = BC000C3_A98PageId[0];
            A99PageName = BC000C3_A99PageName[0];
            A100PageHtmlContent = BC000C3_A100PageHtmlContent[0];
            A112PageCssContent = BC000C3_A112PageCssContent[0];
            A101PageJsonContent = BC000C3_A101PageJsonContent[0];
            A1CustomerId = BC000C3_A1CustomerId[0];
            Z98PageId = A98PageId;
            sMode21 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0C21( ) ;
            if ( AnyError == 1 )
            {
               RcdFound21 = 0;
               InitializeNonKey0C21( ) ;
            }
            Gx_mode = sMode21;
         }
         else
         {
            RcdFound21 = 0;
            InitializeNonKey0C21( ) ;
            sMode21 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode21;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0C21( ) ;
         if ( RcdFound21 == 0 )
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
         CONFIRM_0C0( ) ;
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

      protected void CheckOptimisticConcurrency0C21( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000C2 */
            pr_default.execute(0, new Object[] {A98PageId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Page"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z99PageName, BC000C2_A99PageName[0]) != 0 ) || ( Z1CustomerId != BC000C2_A1CustomerId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Page"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0C21( )
      {
         BeforeValidate0C21( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C21( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0C21( 0) ;
            CheckOptimisticConcurrency0C21( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C21( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0C21( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000C7 */
                     pr_default.execute(5, new Object[] {A99PageName, A100PageHtmlContent, A112PageCssContent, A101PageJsonContent, A1CustomerId});
                     pr_default.close(5);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000C8 */
                     pr_default.execute(6);
                     A98PageId = BC000C8_A98PageId[0];
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Page");
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
               Load0C21( ) ;
            }
            EndLevel0C21( ) ;
         }
         CloseExtendedTableCursors0C21( ) ;
      }

      protected void Update0C21( )
      {
         BeforeValidate0C21( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C21( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C21( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C21( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0C21( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000C9 */
                     pr_default.execute(7, new Object[] {A99PageName, A100PageHtmlContent, A112PageCssContent, A101PageJsonContent, A1CustomerId, A98PageId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Page");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Page"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0C21( ) ;
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
            EndLevel0C21( ) ;
         }
         CloseExtendedTableCursors0C21( ) ;
      }

      protected void DeferredUpdate0C21( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0C21( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C21( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0C21( ) ;
            AfterConfirm0C21( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0C21( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000C10 */
                  pr_default.execute(8, new Object[] {A98PageId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Page");
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
         sMode21 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0C21( ) ;
         Gx_mode = sMode21;
      }

      protected void OnDeleteControls0C21( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000C11 */
            pr_default.execute(9, new Object[] {A1CustomerId});
            A3CustomerName = BC000C11_A3CustomerName[0];
            A5CustomerEmail = BC000C11_A5CustomerEmail[0];
            n5CustomerEmail = BC000C11_n5CustomerEmail[0];
            pr_default.close(9);
         }
      }

      protected void EndLevel0C21( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0C21( ) ;
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

      public void ScanKeyStart0C21( )
      {
         /* Scan By routine */
         /* Using cursor BC000C12 */
         pr_default.execute(10, new Object[] {A98PageId});
         RcdFound21 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound21 = 1;
            A98PageId = BC000C12_A98PageId[0];
            A99PageName = BC000C12_A99PageName[0];
            A100PageHtmlContent = BC000C12_A100PageHtmlContent[0];
            A112PageCssContent = BC000C12_A112PageCssContent[0];
            A101PageJsonContent = BC000C12_A101PageJsonContent[0];
            A3CustomerName = BC000C12_A3CustomerName[0];
            A5CustomerEmail = BC000C12_A5CustomerEmail[0];
            n5CustomerEmail = BC000C12_n5CustomerEmail[0];
            A1CustomerId = BC000C12_A1CustomerId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0C21( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound21 = 0;
         ScanKeyLoad0C21( ) ;
      }

      protected void ScanKeyLoad0C21( )
      {
         sMode21 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound21 = 1;
            A98PageId = BC000C12_A98PageId[0];
            A99PageName = BC000C12_A99PageName[0];
            A100PageHtmlContent = BC000C12_A100PageHtmlContent[0];
            A112PageCssContent = BC000C12_A112PageCssContent[0];
            A101PageJsonContent = BC000C12_A101PageJsonContent[0];
            A3CustomerName = BC000C12_A3CustomerName[0];
            A5CustomerEmail = BC000C12_A5CustomerEmail[0];
            n5CustomerEmail = BC000C12_n5CustomerEmail[0];
            A1CustomerId = BC000C12_A1CustomerId[0];
         }
         Gx_mode = sMode21;
      }

      protected void ScanKeyEnd0C21( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm0C21( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0C21( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0C21( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0C21( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0C21( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0C21( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0C21( )
      {
      }

      protected void send_integrity_lvl_hashes0C21( )
      {
      }

      protected void AddRow0C21( )
      {
         VarsToRow21( bcPage) ;
      }

      protected void ReadRow0C21( )
      {
         RowToVars21( bcPage, 1) ;
      }

      protected void InitializeNonKey0C21( )
      {
         A99PageName = "";
         A100PageHtmlContent = "";
         A112PageCssContent = "";
         A101PageJsonContent = "";
         A1CustomerId = 0;
         A3CustomerName = "";
         A5CustomerEmail = "";
         n5CustomerEmail = false;
         Z99PageName = "";
         Z1CustomerId = 0;
      }

      protected void InitAll0C21( )
      {
         A98PageId = 0;
         InitializeNonKey0C21( ) ;
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

      public void VarsToRow21( SdtPage obj21 )
      {
         obj21.gxTpr_Mode = Gx_mode;
         obj21.gxTpr_Pagename = A99PageName;
         obj21.gxTpr_Pagehtmlcontent = A100PageHtmlContent;
         obj21.gxTpr_Pagecsscontent = A112PageCssContent;
         obj21.gxTpr_Pagejsoncontent = A101PageJsonContent;
         obj21.gxTpr_Customerid = A1CustomerId;
         obj21.gxTpr_Customername = A3CustomerName;
         obj21.gxTpr_Customeremail = A5CustomerEmail;
         obj21.gxTpr_Pageid = A98PageId;
         obj21.gxTpr_Pageid_Z = Z98PageId;
         obj21.gxTpr_Pagename_Z = Z99PageName;
         obj21.gxTpr_Customerid_Z = Z1CustomerId;
         obj21.gxTpr_Customername_Z = Z3CustomerName;
         obj21.gxTpr_Customeremail_Z = Z5CustomerEmail;
         obj21.gxTpr_Customeremail_N = (short)(Convert.ToInt16(n5CustomerEmail));
         obj21.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow21( SdtPage obj21 )
      {
         obj21.gxTpr_Pageid = A98PageId;
         return  ;
      }

      public void RowToVars21( SdtPage obj21 ,
                               int forceLoad )
      {
         Gx_mode = obj21.gxTpr_Mode;
         A99PageName = obj21.gxTpr_Pagename;
         A100PageHtmlContent = obj21.gxTpr_Pagehtmlcontent;
         A112PageCssContent = obj21.gxTpr_Pagecsscontent;
         A101PageJsonContent = obj21.gxTpr_Pagejsoncontent;
         A1CustomerId = obj21.gxTpr_Customerid;
         A3CustomerName = obj21.gxTpr_Customername;
         A5CustomerEmail = obj21.gxTpr_Customeremail;
         n5CustomerEmail = false;
         A98PageId = obj21.gxTpr_Pageid;
         Z98PageId = obj21.gxTpr_Pageid_Z;
         Z99PageName = obj21.gxTpr_Pagename_Z;
         Z1CustomerId = obj21.gxTpr_Customerid_Z;
         Z3CustomerName = obj21.gxTpr_Customername_Z;
         Z5CustomerEmail = obj21.gxTpr_Customeremail_Z;
         n5CustomerEmail = (bool)(Convert.ToBoolean(obj21.gxTpr_Customeremail_N));
         Gx_mode = obj21.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A98PageId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0C21( ) ;
         ScanKeyStart0C21( ) ;
         if ( RcdFound21 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z98PageId = A98PageId;
         }
         ZM0C21( -3) ;
         OnLoadActions0C21( ) ;
         AddRow0C21( ) ;
         ScanKeyEnd0C21( ) ;
         if ( RcdFound21 == 0 )
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
         RowToVars21( bcPage, 0) ;
         ScanKeyStart0C21( ) ;
         if ( RcdFound21 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z98PageId = A98PageId;
         }
         ZM0C21( -3) ;
         OnLoadActions0C21( ) ;
         AddRow0C21( ) ;
         ScanKeyEnd0C21( ) ;
         if ( RcdFound21 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0C21( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0C21( ) ;
         }
         else
         {
            if ( RcdFound21 == 1 )
            {
               if ( A98PageId != Z98PageId )
               {
                  A98PageId = Z98PageId;
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
                  Update0C21( ) ;
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
                  if ( A98PageId != Z98PageId )
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
                        Insert0C21( ) ;
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
                        Insert0C21( ) ;
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
         RowToVars21( bcPage, 1) ;
         SaveImpl( ) ;
         VarsToRow21( bcPage) ;
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
         RowToVars21( bcPage, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0C21( ) ;
         AfterTrn( ) ;
         VarsToRow21( bcPage) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow21( bcPage) ;
         }
         else
         {
            SdtPage auxBC = new SdtPage(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A98PageId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcPage);
               auxBC.Save();
               bcPage.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars21( bcPage, 1) ;
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
         RowToVars21( bcPage, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0C21( ) ;
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
               VarsToRow21( bcPage) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow21( bcPage) ;
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
         RowToVars21( bcPage, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0C21( ) ;
         if ( RcdFound21 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A98PageId != Z98PageId )
            {
               A98PageId = Z98PageId;
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
            if ( A98PageId != Z98PageId )
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
         context.RollbackDataStores("page_bc",pr_default);
         VarsToRow21( bcPage) ;
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
         Gx_mode = bcPage.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcPage.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcPage )
         {
            bcPage = (SdtPage)(sdt);
            if ( StringUtil.StrCmp(bcPage.gxTpr_Mode, "") == 0 )
            {
               bcPage.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow21( bcPage) ;
            }
            else
            {
               RowToVars21( bcPage, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcPage.gxTpr_Mode, "") == 0 )
            {
               bcPage.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars21( bcPage, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtPage Page_BC
      {
         get {
            return bcPage ;
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
            return "page_Execute" ;
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
         pr_default.close(9);
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
         AV23Pgmname = "";
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z99PageName = "";
         A99PageName = "";
         Z3CustomerName = "";
         A3CustomerName = "";
         Z5CustomerEmail = "";
         A5CustomerEmail = "";
         Z100PageHtmlContent = "";
         A100PageHtmlContent = "";
         Z112PageCssContent = "";
         A112PageCssContent = "";
         Z101PageJsonContent = "";
         A101PageJsonContent = "";
         BC000C5_A98PageId = new short[1] ;
         BC000C5_A99PageName = new string[] {""} ;
         BC000C5_A100PageHtmlContent = new string[] {""} ;
         BC000C5_A112PageCssContent = new string[] {""} ;
         BC000C5_A101PageJsonContent = new string[] {""} ;
         BC000C5_A3CustomerName = new string[] {""} ;
         BC000C5_A5CustomerEmail = new string[] {""} ;
         BC000C5_n5CustomerEmail = new bool[] {false} ;
         BC000C5_A1CustomerId = new short[1] ;
         BC000C4_A3CustomerName = new string[] {""} ;
         BC000C4_A5CustomerEmail = new string[] {""} ;
         BC000C4_n5CustomerEmail = new bool[] {false} ;
         BC000C6_A98PageId = new short[1] ;
         BC000C3_A98PageId = new short[1] ;
         BC000C3_A99PageName = new string[] {""} ;
         BC000C3_A100PageHtmlContent = new string[] {""} ;
         BC000C3_A112PageCssContent = new string[] {""} ;
         BC000C3_A101PageJsonContent = new string[] {""} ;
         BC000C3_A1CustomerId = new short[1] ;
         sMode21 = "";
         BC000C2_A98PageId = new short[1] ;
         BC000C2_A99PageName = new string[] {""} ;
         BC000C2_A100PageHtmlContent = new string[] {""} ;
         BC000C2_A112PageCssContent = new string[] {""} ;
         BC000C2_A101PageJsonContent = new string[] {""} ;
         BC000C2_A1CustomerId = new short[1] ;
         BC000C8_A98PageId = new short[1] ;
         BC000C11_A3CustomerName = new string[] {""} ;
         BC000C11_A5CustomerEmail = new string[] {""} ;
         BC000C11_n5CustomerEmail = new bool[] {false} ;
         BC000C12_A98PageId = new short[1] ;
         BC000C12_A99PageName = new string[] {""} ;
         BC000C12_A100PageHtmlContent = new string[] {""} ;
         BC000C12_A112PageCssContent = new string[] {""} ;
         BC000C12_A101PageJsonContent = new string[] {""} ;
         BC000C12_A3CustomerName = new string[] {""} ;
         BC000C12_A5CustomerEmail = new string[] {""} ;
         BC000C12_n5CustomerEmail = new bool[] {false} ;
         BC000C12_A1CustomerId = new short[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.page_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.page_bc__default(),
            new Object[][] {
                new Object[] {
               BC000C2_A98PageId, BC000C2_A99PageName, BC000C2_A100PageHtmlContent, BC000C2_A112PageCssContent, BC000C2_A101PageJsonContent, BC000C2_A1CustomerId
               }
               , new Object[] {
               BC000C3_A98PageId, BC000C3_A99PageName, BC000C3_A100PageHtmlContent, BC000C3_A112PageCssContent, BC000C3_A101PageJsonContent, BC000C3_A1CustomerId
               }
               , new Object[] {
               BC000C4_A3CustomerName, BC000C4_A5CustomerEmail, BC000C4_n5CustomerEmail
               }
               , new Object[] {
               BC000C5_A98PageId, BC000C5_A99PageName, BC000C5_A100PageHtmlContent, BC000C5_A112PageCssContent, BC000C5_A101PageJsonContent, BC000C5_A3CustomerName, BC000C5_A5CustomerEmail, BC000C5_n5CustomerEmail, BC000C5_A1CustomerId
               }
               , new Object[] {
               BC000C6_A98PageId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000C8_A98PageId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000C11_A3CustomerName, BC000C11_A5CustomerEmail, BC000C11_n5CustomerEmail
               }
               , new Object[] {
               BC000C12_A98PageId, BC000C12_A99PageName, BC000C12_A100PageHtmlContent, BC000C12_A112PageCssContent, BC000C12_A101PageJsonContent, BC000C12_A3CustomerName, BC000C12_A5CustomerEmail, BC000C12_n5CustomerEmail, BC000C12_A1CustomerId
               }
            }
         );
         AV23Pgmname = "Page_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120C2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short Z98PageId ;
      private short A98PageId ;
      private short AV13Insert_CustomerId ;
      private short GX_JID ;
      private short Z1CustomerId ;
      private short A1CustomerId ;
      private short RcdFound21 ;
      private short nIsDirty_21 ;
      private int trnEnded ;
      private int AV24GXV1 ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV23Pgmname ;
      private string sMode21 ;
      private bool returnInSub ;
      private bool n5CustomerEmail ;
      private bool mustCommit ;
      private string Z100PageHtmlContent ;
      private string A100PageHtmlContent ;
      private string Z112PageCssContent ;
      private string A112PageCssContent ;
      private string Z101PageJsonContent ;
      private string A101PageJsonContent ;
      private string Z99PageName ;
      private string A99PageName ;
      private string Z3CustomerName ;
      private string A3CustomerName ;
      private string Z5CustomerEmail ;
      private string A5CustomerEmail ;
      private IGxSession AV12WebSession ;
      private SdtPage bcPage ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC000C5_A98PageId ;
      private string[] BC000C5_A99PageName ;
      private string[] BC000C5_A100PageHtmlContent ;
      private string[] BC000C5_A112PageCssContent ;
      private string[] BC000C5_A101PageJsonContent ;
      private string[] BC000C5_A3CustomerName ;
      private string[] BC000C5_A5CustomerEmail ;
      private bool[] BC000C5_n5CustomerEmail ;
      private short[] BC000C5_A1CustomerId ;
      private string[] BC000C4_A3CustomerName ;
      private string[] BC000C4_A5CustomerEmail ;
      private bool[] BC000C4_n5CustomerEmail ;
      private short[] BC000C6_A98PageId ;
      private short[] BC000C3_A98PageId ;
      private string[] BC000C3_A99PageName ;
      private string[] BC000C3_A100PageHtmlContent ;
      private string[] BC000C3_A112PageCssContent ;
      private string[] BC000C3_A101PageJsonContent ;
      private short[] BC000C3_A1CustomerId ;
      private short[] BC000C2_A98PageId ;
      private string[] BC000C2_A99PageName ;
      private string[] BC000C2_A100PageHtmlContent ;
      private string[] BC000C2_A112PageCssContent ;
      private string[] BC000C2_A101PageJsonContent ;
      private short[] BC000C2_A1CustomerId ;
      private short[] BC000C8_A98PageId ;
      private string[] BC000C11_A3CustomerName ;
      private string[] BC000C11_A5CustomerEmail ;
      private bool[] BC000C11_n5CustomerEmail ;
      private short[] BC000C12_A98PageId ;
      private string[] BC000C12_A99PageName ;
      private string[] BC000C12_A100PageHtmlContent ;
      private string[] BC000C12_A112PageCssContent ;
      private string[] BC000C12_A101PageJsonContent ;
      private string[] BC000C12_A3CustomerName ;
      private string[] BC000C12_A5CustomerEmail ;
      private bool[] BC000C12_n5CustomerEmail ;
      private short[] BC000C12_A1CustomerId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
   }

   public class page_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class page_bc__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new ForEachCursor(def[3])
       ,new ForEachCursor(def[4])
       ,new UpdateCursor(def[5])
       ,new ForEachCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new ForEachCursor(def[10])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000C5;
        prmBC000C5 = new Object[] {
        new ParDef("PageId",GXType.Int16,4,0)
        };
        Object[] prmBC000C4;
        prmBC000C4 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmBC000C6;
        prmBC000C6 = new Object[] {
        new ParDef("PageId",GXType.Int16,4,0)
        };
        Object[] prmBC000C3;
        prmBC000C3 = new Object[] {
        new ParDef("PageId",GXType.Int16,4,0)
        };
        Object[] prmBC000C2;
        prmBC000C2 = new Object[] {
        new ParDef("PageId",GXType.Int16,4,0)
        };
        Object[] prmBC000C7;
        prmBC000C7 = new Object[] {
        new ParDef("PageName",GXType.VarChar,40,0) ,
        new ParDef("PageHtmlContent",GXType.LongVarChar,5242880,0) ,
        new ParDef("PageCssContent",GXType.LongVarChar,2097152,0) ,
        new ParDef("PageJsonContent",GXType.LongVarChar,2097152,0) ,
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmBC000C8;
        prmBC000C8 = new Object[] {
        };
        Object[] prmBC000C9;
        prmBC000C9 = new Object[] {
        new ParDef("PageName",GXType.VarChar,40,0) ,
        new ParDef("PageHtmlContent",GXType.LongVarChar,5242880,0) ,
        new ParDef("PageCssContent",GXType.LongVarChar,2097152,0) ,
        new ParDef("PageJsonContent",GXType.LongVarChar,2097152,0) ,
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("PageId",GXType.Int16,4,0)
        };
        Object[] prmBC000C10;
        prmBC000C10 = new Object[] {
        new ParDef("PageId",GXType.Int16,4,0)
        };
        Object[] prmBC000C11;
        prmBC000C11 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmBC000C12;
        prmBC000C12 = new Object[] {
        new ParDef("PageId",GXType.Int16,4,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000C2", "SELECT PageId, PageName, PageHtmlContent, PageCssContent, PageJsonContent, CustomerId FROM Page WHERE PageId = :PageId  FOR UPDATE OF Page",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000C3", "SELECT PageId, PageName, PageHtmlContent, PageCssContent, PageJsonContent, CustomerId FROM Page WHERE PageId = :PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000C4", "SELECT CustomerName, CustomerEmail FROM Customer WHERE CustomerId = :CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000C5", "SELECT TM1.PageId, TM1.PageName, TM1.PageHtmlContent, TM1.PageCssContent, TM1.PageJsonContent, T2.CustomerName, T2.CustomerEmail, TM1.CustomerId FROM (Page TM1 INNER JOIN Customer T2 ON T2.CustomerId = TM1.CustomerId) WHERE TM1.PageId = :PageId ORDER BY TM1.PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000C6", "SELECT PageId FROM Page WHERE PageId = :PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000C7", "SAVEPOINT gxupdate;INSERT INTO Page(PageName, PageHtmlContent, PageCssContent, PageJsonContent, CustomerId) VALUES(:PageName, :PageHtmlContent, :PageCssContent, :PageJsonContent, :CustomerId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000C7)
           ,new CursorDef("BC000C8", "SELECT currval('PageId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000C9", "SAVEPOINT gxupdate;UPDATE Page SET PageName=:PageName, PageHtmlContent=:PageHtmlContent, PageCssContent=:PageCssContent, PageJsonContent=:PageJsonContent, CustomerId=:CustomerId  WHERE PageId = :PageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000C9)
           ,new CursorDef("BC000C10", "SAVEPOINT gxupdate;DELETE FROM Page  WHERE PageId = :PageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000C10)
           ,new CursorDef("BC000C11", "SELECT CustomerName, CustomerEmail FROM Customer WHERE CustomerId = :CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000C12", "SELECT TM1.PageId, TM1.PageName, TM1.PageHtmlContent, TM1.PageCssContent, TM1.PageJsonContent, T2.CustomerName, T2.CustomerEmail, TM1.CustomerId FROM (Page TM1 INNER JOIN Customer T2 ON T2.CustomerId = TM1.CustomerId) WHERE TM1.PageId = :PageId ORDER BY TM1.PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C12,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              return;
           case 3 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              ((short[]) buf[8])[0] = rslt.getShort(8);
              return;
           case 4 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 6 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              return;
           case 10 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              ((short[]) buf[8])[0] = rslt.getShort(8);
              return;
     }
  }

}

}
