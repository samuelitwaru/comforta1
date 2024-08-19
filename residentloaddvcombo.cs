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
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class residentloaddvcombo : GXProcedure
   {
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
            return "resident_Services_Execute" ;
         }

      }

      public residentloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public residentloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           short aP3_ResidentId ,
                           short aP4_Cond_CustomerId ,
                           string aP5_SearchTxtParms ,
                           out string aP6_SelectedValue ,
                           out string aP7_SelectedText ,
                           out string aP8_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV19IsDynamicCall = aP2_IsDynamicCall;
         this.AV20ResidentId = aP3_ResidentId;
         this.AV35Cond_CustomerId = aP4_Cond_CustomerId;
         this.AV21SearchTxtParms = aP5_SearchTxtParms;
         this.AV22SelectedValue = "" ;
         this.AV23SelectedText = "" ;
         this.AV24Combo_DataJson = "" ;
         initialize();
         executePrivate();
         aP6_SelectedValue=this.AV22SelectedValue;
         aP7_SelectedText=this.AV23SelectedText;
         aP8_Combo_DataJson=this.AV24Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                string aP1_TrnMode ,
                                bool aP2_IsDynamicCall ,
                                short aP3_ResidentId ,
                                short aP4_Cond_CustomerId ,
                                string aP5_SearchTxtParms ,
                                out string aP6_SelectedValue ,
                                out string aP7_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_ResidentId, aP4_Cond_CustomerId, aP5_SearchTxtParms, out aP6_SelectedValue, out aP7_SelectedText, out aP8_Combo_DataJson);
         return AV24Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 short aP3_ResidentId ,
                                 short aP4_Cond_CustomerId ,
                                 string aP5_SearchTxtParms ,
                                 out string aP6_SelectedValue ,
                                 out string aP7_SelectedText ,
                                 out string aP8_Combo_DataJson )
      {
         residentloaddvcombo objresidentloaddvcombo;
         objresidentloaddvcombo = new residentloaddvcombo();
         objresidentloaddvcombo.AV17ComboName = aP0_ComboName;
         objresidentloaddvcombo.AV18TrnMode = aP1_TrnMode;
         objresidentloaddvcombo.AV19IsDynamicCall = aP2_IsDynamicCall;
         objresidentloaddvcombo.AV20ResidentId = aP3_ResidentId;
         objresidentloaddvcombo.AV35Cond_CustomerId = aP4_Cond_CustomerId;
         objresidentloaddvcombo.AV21SearchTxtParms = aP5_SearchTxtParms;
         objresidentloaddvcombo.AV22SelectedValue = "" ;
         objresidentloaddvcombo.AV23SelectedText = "" ;
         objresidentloaddvcombo.AV24Combo_DataJson = "" ;
         objresidentloaddvcombo.context.SetSubmitInitialConfig(context);
         objresidentloaddvcombo.initialize();
         Submit( executePrivateCatch,objresidentloaddvcombo);
         aP6_SelectedValue=this.AV22SelectedValue;
         aP7_SelectedText=this.AV23SelectedText;
         aP8_Combo_DataJson=this.AV24Combo_DataJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((residentloaddvcombo)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV11MaxItems = 10;
         AV13PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV21SearchTxtParms))||StringUtil.StartsWith( AV18TrnMode, "GET") ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV21SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV14SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV21SearchTxtParms))||StringUtil.StartsWith( AV18TrnMode, "GET") ? AV21SearchTxtParms : StringUtil.Substring( AV21SearchTxtParms, 3, -1));
         AV12SkipItems = (short)(AV13PageIndex*AV11MaxItems);
         if ( StringUtil.StrCmp(AV17ComboName, "ProductServiceId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_PRODUCTSERVICEID' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "ResidentTypeId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_RESIDENTTYPEID' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "CustomerLocationId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_CUSTOMERLOCATIONID' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "CustomerId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_CUSTOMERID' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADCOMBOITEMS_PRODUCTSERVICEID' Routine */
         returnInSub = false;
         if ( AV19IsDynamicCall )
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "GET_DSC") == 0 )
            {
               AV30ValuesCollection.FromJSonString(AV14SearchTxt, null);
               AV29DscsCollection = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
               AV36GXV1 = 1;
               while ( AV36GXV1 <= AV30ValuesCollection.Count )
               {
                  AV31ValueItem = ((string)AV30ValuesCollection.Item(AV36GXV1));
                  AV32ProductServiceId_Filter = (short)(Math.Round(NumberUtil.Val( AV31ValueItem, "."), 18, MidpointRounding.ToEven));
                  AV37GXLvl35 = 0;
                  /* Using cursor P002C2 */
                  pr_default.execute(0, new Object[] {AV32ProductServiceId_Filter});
                  while ( (pr_default.getStatus(0) != 101) )
                  {
                     A73ProductServiceId = P002C2_A73ProductServiceId[0];
                     A74ProductServiceName = P002C2_A74ProductServiceName[0];
                     AV37GXLvl35 = 1;
                     AV29DscsCollection.Add(A74ProductServiceName, 0);
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(0);
                  if ( AV37GXLvl35 == 0 )
                  {
                     AV29DscsCollection.Add("", 0);
                  }
                  AV36GXV1 = (int)(AV36GXV1+1);
               }
               AV24Combo_DataJson = AV29DscsCollection.ToJSonString(false);
            }
            else
            {
               GXPagingFrom3 = AV12SkipItems;
               GXPagingTo3 = AV11MaxItems;
               pr_default.dynParam(1, new Object[]{ new Object[]{
                                                    AV14SearchTxt ,
                                                    A74ProductServiceName } ,
                                                    new int[]{
                                                    }
               });
               lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
               /* Using cursor P002C3 */
               pr_default.execute(1, new Object[] {lV14SearchTxt, GXPagingFrom3, GXPagingTo3, GXPagingTo3});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A74ProductServiceName = P002C3_A74ProductServiceName[0];
                  A73ProductServiceId = P002C3_A73ProductServiceId[0];
                  AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
                  AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A73ProductServiceId), 4, 0));
                  AV16Combo_DataItem.gxTpr_Title = A74ProductServiceName;
                  AV15Combo_Data.Add(AV16Combo_DataItem, 0);
                  if ( AV15Combo_Data.Count > AV11MaxItems )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               AV24Combo_DataJson = AV15Combo_Data.ToJSonString(false);
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_RESIDENTTYPEID' Routine */
         returnInSub = false;
         if ( AV19IsDynamicCall )
         {
            GXPagingFrom4 = AV12SkipItems;
            GXPagingTo4 = AV11MaxItems;
            pr_default.dynParam(2, new Object[]{ new Object[]{
                                                 AV14SearchTxt ,
                                                 A83ResidentTypeName } ,
                                                 new int[]{
                                                 }
            });
            lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
            /* Using cursor P002C4 */
            pr_default.execute(2, new Object[] {lV14SearchTxt, GXPagingFrom4, GXPagingTo4, GXPagingTo4});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A83ResidentTypeName = P002C4_A83ResidentTypeName[0];
               A82ResidentTypeId = P002C4_A82ResidentTypeId[0];
               AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A82ResidentTypeId), 4, 0));
               AV16Combo_DataItem.gxTpr_Title = A83ResidentTypeName;
               AV15Combo_Data.Add(AV16Combo_DataItem, 0);
               if ( AV15Combo_Data.Count > AV11MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(2);
            }
            pr_default.close(2);
            AV24Combo_DataJson = AV15Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P002C5 */
                  pr_default.execute(3, new Object[] {AV20ResidentId});
                  while ( (pr_default.getStatus(3) != 101) )
                  {
                     A31ResidentId = P002C5_A31ResidentId[0];
                     A82ResidentTypeId = P002C5_A82ResidentTypeId[0];
                     A83ResidentTypeName = P002C5_A83ResidentTypeName[0];
                     A83ResidentTypeName = P002C5_A83ResidentTypeName[0];
                     AV22SelectedValue = ((0==A82ResidentTypeId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A82ResidentTypeId), 4, 0)));
                     AV23SelectedText = A83ResidentTypeName;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(3);
               }
               else
               {
                  AV28ResidentTypeId = (short)(Math.Round(NumberUtil.Val( AV14SearchTxt, "."), 18, MidpointRounding.ToEven));
                  /* Using cursor P002C6 */
                  pr_default.execute(4, new Object[] {AV28ResidentTypeId});
                  while ( (pr_default.getStatus(4) != 101) )
                  {
                     A82ResidentTypeId = P002C6_A82ResidentTypeId[0];
                     A83ResidentTypeName = P002C6_A83ResidentTypeName[0];
                     AV23SelectedText = A83ResidentTypeName;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(4);
               }
            }
         }
      }

      protected void S131( )
      {
         /* 'LOADCOMBOITEMS_CUSTOMERLOCATIONID' Routine */
         returnInSub = false;
         if ( AV19IsDynamicCall )
         {
            GXPagingFrom7 = AV12SkipItems;
            GXPagingTo7 = AV11MaxItems;
            pr_default.dynParam(5, new Object[]{ new Object[]{
                                                 AV14SearchTxt ,
                                                 A19CustomerLocationVisitingAddres ,
                                                 A1CustomerId ,
                                                 AV35Cond_CustomerId } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
            /* Using cursor P002C7 */
            pr_default.execute(5, new Object[] {AV35Cond_CustomerId, lV14SearchTxt, GXPagingFrom7, GXPagingTo7, GXPagingTo7});
            while ( (pr_default.getStatus(5) != 101) )
            {
               A1CustomerId = P002C7_A1CustomerId[0];
               A19CustomerLocationVisitingAddres = P002C7_A19CustomerLocationVisitingAddres[0];
               A18CustomerLocationId = P002C7_A18CustomerLocationId[0];
               AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A18CustomerLocationId), 4, 0));
               AV16Combo_DataItem.gxTpr_Title = A19CustomerLocationVisitingAddres;
               AV15Combo_Data.Add(AV16Combo_DataItem, 0);
               if ( AV15Combo_Data.Count > AV11MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(5);
            }
            pr_default.close(5);
            AV24Combo_DataJson = AV15Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P002C8 */
                  pr_default.execute(6, new Object[] {AV20ResidentId});
                  while ( (pr_default.getStatus(6) != 101) )
                  {
                     A1CustomerId = P002C8_A1CustomerId[0];
                     A31ResidentId = P002C8_A31ResidentId[0];
                     A18CustomerLocationId = P002C8_A18CustomerLocationId[0];
                     A19CustomerLocationVisitingAddres = P002C8_A19CustomerLocationVisitingAddres[0];
                     A19CustomerLocationVisitingAddres = P002C8_A19CustomerLocationVisitingAddres[0];
                     AV22SelectedValue = ((0==A18CustomerLocationId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A18CustomerLocationId), 4, 0)));
                     AV23SelectedText = A19CustomerLocationVisitingAddres;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(6);
               }
               else
               {
                  AV33CustomerLocationId = (short)(Math.Round(NumberUtil.Val( AV14SearchTxt, "."), 18, MidpointRounding.ToEven));
                  /* Using cursor P002C9 */
                  pr_default.execute(7, new Object[] {AV35Cond_CustomerId, AV33CustomerLocationId});
                  while ( (pr_default.getStatus(7) != 101) )
                  {
                     A1CustomerId = P002C9_A1CustomerId[0];
                     A18CustomerLocationId = P002C9_A18CustomerLocationId[0];
                     A19CustomerLocationVisitingAddres = P002C9_A19CustomerLocationVisitingAddres[0];
                     AV23SelectedText = A19CustomerLocationVisitingAddres;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(7);
               }
            }
         }
      }

      protected void S141( )
      {
         /* 'LOADCOMBOITEMS_CUSTOMERID' Routine */
         returnInSub = false;
         if ( AV19IsDynamicCall )
         {
            GXPagingFrom10 = AV12SkipItems;
            GXPagingTo10 = AV11MaxItems;
            pr_default.dynParam(8, new Object[]{ new Object[]{
                                                 AV14SearchTxt ,
                                                 A41CustomerKvkNumber } ,
                                                 new int[]{
                                                 }
            });
            lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
            /* Using cursor P002C10 */
            pr_default.execute(8, new Object[] {lV14SearchTxt, GXPagingFrom10, GXPagingTo10, GXPagingTo10});
            while ( (pr_default.getStatus(8) != 101) )
            {
               A41CustomerKvkNumber = P002C10_A41CustomerKvkNumber[0];
               A1CustomerId = P002C10_A1CustomerId[0];
               AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A1CustomerId), 4, 0));
               AV16Combo_DataItem.gxTpr_Title = A41CustomerKvkNumber;
               AV15Combo_Data.Add(AV16Combo_DataItem, 0);
               if ( AV15Combo_Data.Count > AV11MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(8);
            }
            pr_default.close(8);
            AV24Combo_DataJson = AV15Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P002C11 */
                  pr_default.execute(9, new Object[] {AV20ResidentId});
                  while ( (pr_default.getStatus(9) != 101) )
                  {
                     A31ResidentId = P002C11_A31ResidentId[0];
                     A1CustomerId = P002C11_A1CustomerId[0];
                     A41CustomerKvkNumber = P002C11_A41CustomerKvkNumber[0];
                     A41CustomerKvkNumber = P002C11_A41CustomerKvkNumber[0];
                     AV22SelectedValue = ((0==A1CustomerId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A1CustomerId), 4, 0)));
                     AV23SelectedText = A41CustomerKvkNumber;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(9);
               }
               else
               {
                  AV34CustomerId = (short)(Math.Round(NumberUtil.Val( AV14SearchTxt, "."), 18, MidpointRounding.ToEven));
                  /* Using cursor P002C12 */
                  pr_default.execute(10, new Object[] {AV34CustomerId});
                  while ( (pr_default.getStatus(10) != 101) )
                  {
                     A1CustomerId = P002C12_A1CustomerId[0];
                     A41CustomerKvkNumber = P002C12_A41CustomerKvkNumber[0];
                     AV23SelectedText = A41CustomerKvkNumber;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(10);
               }
            }
         }
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         AV22SelectedValue = "";
         AV23SelectedText = "";
         AV24Combo_DataJson = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV14SearchTxt = "";
         AV30ValuesCollection = new GxSimpleCollection<string>();
         AV29DscsCollection = new GxSimpleCollection<string>();
         AV31ValueItem = "";
         scmdbuf = "";
         P002C2_A73ProductServiceId = new short[1] ;
         P002C2_A74ProductServiceName = new string[] {""} ;
         A74ProductServiceName = "";
         lV14SearchTxt = "";
         P002C3_A74ProductServiceName = new string[] {""} ;
         P002C3_A73ProductServiceId = new short[1] ;
         AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV15Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A83ResidentTypeName = "";
         P002C4_A83ResidentTypeName = new string[] {""} ;
         P002C4_A82ResidentTypeId = new short[1] ;
         P002C5_A31ResidentId = new short[1] ;
         P002C5_A82ResidentTypeId = new short[1] ;
         P002C5_A83ResidentTypeName = new string[] {""} ;
         P002C6_A82ResidentTypeId = new short[1] ;
         P002C6_A83ResidentTypeName = new string[] {""} ;
         A19CustomerLocationVisitingAddres = "";
         P002C7_A1CustomerId = new short[1] ;
         P002C7_A19CustomerLocationVisitingAddres = new string[] {""} ;
         P002C7_A18CustomerLocationId = new short[1] ;
         P002C8_A1CustomerId = new short[1] ;
         P002C8_A31ResidentId = new short[1] ;
         P002C8_A18CustomerLocationId = new short[1] ;
         P002C8_A19CustomerLocationVisitingAddres = new string[] {""} ;
         P002C9_A1CustomerId = new short[1] ;
         P002C9_A18CustomerLocationId = new short[1] ;
         P002C9_A19CustomerLocationVisitingAddres = new string[] {""} ;
         A41CustomerKvkNumber = "";
         P002C10_A41CustomerKvkNumber = new string[] {""} ;
         P002C10_A1CustomerId = new short[1] ;
         P002C11_A31ResidentId = new short[1] ;
         P002C11_A1CustomerId = new short[1] ;
         P002C11_A41CustomerKvkNumber = new string[] {""} ;
         P002C12_A1CustomerId = new short[1] ;
         P002C12_A41CustomerKvkNumber = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.residentloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P002C2_A73ProductServiceId, P002C2_A74ProductServiceName
               }
               , new Object[] {
               P002C3_A74ProductServiceName, P002C3_A73ProductServiceId
               }
               , new Object[] {
               P002C4_A83ResidentTypeName, P002C4_A82ResidentTypeId
               }
               , new Object[] {
               P002C5_A31ResidentId, P002C5_A82ResidentTypeId, P002C5_A83ResidentTypeName
               }
               , new Object[] {
               P002C6_A82ResidentTypeId, P002C6_A83ResidentTypeName
               }
               , new Object[] {
               P002C7_A1CustomerId, P002C7_A19CustomerLocationVisitingAddres, P002C7_A18CustomerLocationId
               }
               , new Object[] {
               P002C8_A1CustomerId, P002C8_A31ResidentId, P002C8_A18CustomerLocationId, P002C8_A19CustomerLocationVisitingAddres
               }
               , new Object[] {
               P002C9_A1CustomerId, P002C9_A18CustomerLocationId, P002C9_A19CustomerLocationVisitingAddres
               }
               , new Object[] {
               P002C10_A41CustomerKvkNumber, P002C10_A1CustomerId
               }
               , new Object[] {
               P002C11_A31ResidentId, P002C11_A1CustomerId, P002C11_A41CustomerKvkNumber
               }
               , new Object[] {
               P002C12_A1CustomerId, P002C12_A41CustomerKvkNumber
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20ResidentId ;
      private short AV35Cond_CustomerId ;
      private short AV13PageIndex ;
      private short AV12SkipItems ;
      private short AV32ProductServiceId_Filter ;
      private short AV37GXLvl35 ;
      private short A73ProductServiceId ;
      private short A82ResidentTypeId ;
      private short A31ResidentId ;
      private short AV28ResidentTypeId ;
      private short A1CustomerId ;
      private short A18CustomerLocationId ;
      private short AV33CustomerLocationId ;
      private short AV34CustomerId ;
      private int AV11MaxItems ;
      private int AV36GXV1 ;
      private int GXPagingFrom3 ;
      private int GXPagingTo3 ;
      private int GXPagingFrom4 ;
      private int GXPagingTo4 ;
      private int GXPagingFrom7 ;
      private int GXPagingTo7 ;
      private int GXPagingFrom10 ;
      private int GXPagingTo10 ;
      private string AV18TrnMode ;
      private string scmdbuf ;
      private bool AV19IsDynamicCall ;
      private bool returnInSub ;
      private string AV24Combo_DataJson ;
      private string AV17ComboName ;
      private string AV21SearchTxtParms ;
      private string AV22SelectedValue ;
      private string AV23SelectedText ;
      private string AV14SearchTxt ;
      private string AV31ValueItem ;
      private string A74ProductServiceName ;
      private string lV14SearchTxt ;
      private string A83ResidentTypeName ;
      private string A19CustomerLocationVisitingAddres ;
      private string A41CustomerKvkNumber ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P002C2_A73ProductServiceId ;
      private string[] P002C2_A74ProductServiceName ;
      private string[] P002C3_A74ProductServiceName ;
      private short[] P002C3_A73ProductServiceId ;
      private string[] P002C4_A83ResidentTypeName ;
      private short[] P002C4_A82ResidentTypeId ;
      private short[] P002C5_A31ResidentId ;
      private short[] P002C5_A82ResidentTypeId ;
      private string[] P002C5_A83ResidentTypeName ;
      private short[] P002C6_A82ResidentTypeId ;
      private string[] P002C6_A83ResidentTypeName ;
      private short[] P002C7_A1CustomerId ;
      private string[] P002C7_A19CustomerLocationVisitingAddres ;
      private short[] P002C7_A18CustomerLocationId ;
      private short[] P002C8_A1CustomerId ;
      private short[] P002C8_A31ResidentId ;
      private short[] P002C8_A18CustomerLocationId ;
      private string[] P002C8_A19CustomerLocationVisitingAddres ;
      private short[] P002C9_A1CustomerId ;
      private short[] P002C9_A18CustomerLocationId ;
      private string[] P002C9_A19CustomerLocationVisitingAddres ;
      private string[] P002C10_A41CustomerKvkNumber ;
      private short[] P002C10_A1CustomerId ;
      private short[] P002C11_A31ResidentId ;
      private short[] P002C11_A1CustomerId ;
      private string[] P002C11_A41CustomerKvkNumber ;
      private short[] P002C12_A1CustomerId ;
      private string[] P002C12_A41CustomerKvkNumber ;
      private string aP6_SelectedValue ;
      private string aP7_SelectedText ;
      private string aP8_Combo_DataJson ;
      private GxSimpleCollection<string> AV30ValuesCollection ;
      private GxSimpleCollection<string> AV29DscsCollection ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
   }

   public class residentloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002C3( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A74ProductServiceName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " ProductServiceName, ProductServiceId";
         sFromString = " FROM ProductService";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(ProductServiceName like '%' || :lV14SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         sOrderString += " ORDER BY ProductServiceName, ProductServiceId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom3" + " LIMIT CASE WHEN " + ":GXPagingTo3" + " > 0 THEN " + ":GXPagingTo3" + " ELSE 1e9 END";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P002C4( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A83ResidentTypeName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[4];
         Object[] GXv_Object4 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " ResidentTypeName, ResidentTypeId";
         sFromString = " FROM ResidentType";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(ResidentTypeName like '%' || :lV14SearchTxt)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         sOrderString += " ORDER BY ResidentTypeName, ResidentTypeId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom4" + " LIMIT CASE WHEN " + ":GXPagingTo4" + " > 0 THEN " + ":GXPagingTo4" + " ELSE 1e9 END";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P002C7( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A19CustomerLocationVisitingAddres ,
                                             short A1CustomerId ,
                                             short AV35Cond_CustomerId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[5];
         Object[] GXv_Object6 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " CustomerId, CustomerLocationVisitingAddres, CustomerLocationId";
         sFromString = " FROM CustomerLocation";
         sOrderString = "";
         AddWhere(sWhereString, "(CustomerId = :AV35Cond_CustomerId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(CustomerLocationVisitingAddres like '%' || :lV14SearchTxt)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         sOrderString += " ORDER BY CustomerLocationVisitingAddres, CustomerId, CustomerLocationId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom7" + " LIMIT CASE WHEN " + ":GXPagingTo7" + " > 0 THEN " + ":GXPagingTo7" + " ELSE 1e9 END";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P002C10( IGxContext context ,
                                              string AV14SearchTxt ,
                                              string A41CustomerKvkNumber )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[4];
         Object[] GXv_Object8 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " CustomerKvkNumber, CustomerId";
         sFromString = " FROM Customer";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(CustomerKvkNumber like '%' || :lV14SearchTxt)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         sOrderString += " ORDER BY CustomerKvkNumber, CustomerId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom10" + " LIMIT CASE WHEN " + ":GXPagingTo10" + " > 0 THEN " + ":GXPagingTo10" + " ELSE 1e9 END";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_P002C3(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 2 :
                     return conditional_P002C4(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 5 :
                     return conditional_P002C7(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] );
               case 8 :
                     return conditional_P002C10(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP002C2;
          prmP002C2 = new Object[] {
          new ParDef("AV32ProductServiceId_Filter",GXType.Int16,4,0)
          };
          Object[] prmP002C5;
          prmP002C5 = new Object[] {
          new ParDef("AV20ResidentId",GXType.Int16,4,0)
          };
          Object[] prmP002C6;
          prmP002C6 = new Object[] {
          new ParDef("AV28ResidentTypeId",GXType.Int16,4,0)
          };
          Object[] prmP002C8;
          prmP002C8 = new Object[] {
          new ParDef("AV20ResidentId",GXType.Int16,4,0)
          };
          Object[] prmP002C9;
          prmP002C9 = new Object[] {
          new ParDef("AV35Cond_CustomerId",GXType.Int16,4,0) ,
          new ParDef("AV33CustomerLocationId",GXType.Int16,4,0)
          };
          Object[] prmP002C11;
          prmP002C11 = new Object[] {
          new ParDef("AV20ResidentId",GXType.Int16,4,0)
          };
          Object[] prmP002C12;
          prmP002C12 = new Object[] {
          new ParDef("AV34CustomerId",GXType.Int16,4,0)
          };
          Object[] prmP002C3;
          prmP002C3 = new Object[] {
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom3",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo3",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo3",GXType.Int32,9,0)
          };
          Object[] prmP002C4;
          prmP002C4 = new Object[] {
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom4",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo4",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo4",GXType.Int32,9,0)
          };
          Object[] prmP002C7;
          prmP002C7 = new Object[] {
          new ParDef("AV35Cond_CustomerId",GXType.Int16,4,0) ,
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom7",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo7",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo7",GXType.Int32,9,0)
          };
          Object[] prmP002C10;
          prmP002C10 = new Object[] {
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom10",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo10",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo10",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002C2", "SELECT ProductServiceId, ProductServiceName FROM ProductService WHERE ProductServiceId = :AV32ProductServiceId_Filter ORDER BY ProductServiceId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002C2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P002C3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002C3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P002C4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002C4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P002C5", "SELECT T1.ResidentId, T1.ResidentTypeId, T2.ResidentTypeName FROM (Resident T1 INNER JOIN ResidentType T2 ON T2.ResidentTypeId = T1.ResidentTypeId) WHERE T1.ResidentId = :AV20ResidentId ORDER BY T1.ResidentId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002C5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P002C6", "SELECT ResidentTypeId, ResidentTypeName FROM ResidentType WHERE ResidentTypeId = :AV28ResidentTypeId ORDER BY ResidentTypeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002C6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P002C7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002C7,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P002C8", "SELECT T1.CustomerId, T1.ResidentId, T1.CustomerLocationId, T2.CustomerLocationVisitingAddres FROM (Resident T1 INNER JOIN CustomerLocation T2 ON T2.CustomerId = T1.CustomerId AND T2.CustomerLocationId = T1.CustomerLocationId) WHERE T1.ResidentId = :AV20ResidentId ORDER BY T1.ResidentId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002C8,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P002C9", "SELECT CustomerId, CustomerLocationId, CustomerLocationVisitingAddres FROM CustomerLocation WHERE CustomerId = :AV35Cond_CustomerId and CustomerLocationId = :AV33CustomerLocationId ORDER BY CustomerId, CustomerLocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002C9,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P002C10", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002C10,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P002C11", "SELECT T1.ResidentId, T1.CustomerId, T2.CustomerKvkNumber FROM (Resident T1 INNER JOIN Customer T2 ON T2.CustomerId = T1.CustomerId) WHERE T1.ResidentId = :AV20ResidentId ORDER BY T1.ResidentId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002C11,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P002C12", "SELECT CustomerId, CustomerKvkNumber FROM Customer WHERE CustomerId = :AV34CustomerId ORDER BY CustomerId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002C12,1, GxCacheFrequency.OFF ,false,true )
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
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
