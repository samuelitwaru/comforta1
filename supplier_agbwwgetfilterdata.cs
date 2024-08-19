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
   public class supplier_agbwwgetfilterdata : GXProcedure
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
            return "supplier_agbww_Services_Execute" ;
         }

      }

      public supplier_agbwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public supplier_agbwwgetfilterdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_DDOName ,
                           string aP1_SearchTxtParms ,
                           string aP2_SearchTxtTo ,
                           out string aP3_OptionsJson ,
                           out string aP4_OptionsDescJson ,
                           out string aP5_OptionIndexesJson )
      {
         this.AV45DDOName = aP0_DDOName;
         this.AV46SearchTxtParms = aP1_SearchTxtParms;
         this.AV47SearchTxtTo = aP2_SearchTxtTo;
         this.AV48OptionsJson = "" ;
         this.AV49OptionsDescJson = "" ;
         this.AV50OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV48OptionsJson;
         aP4_OptionsDescJson=this.AV49OptionsDescJson;
         aP5_OptionIndexesJson=this.AV50OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV50OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         supplier_agbwwgetfilterdata objsupplier_agbwwgetfilterdata;
         objsupplier_agbwwgetfilterdata = new supplier_agbwwgetfilterdata();
         objsupplier_agbwwgetfilterdata.AV45DDOName = aP0_DDOName;
         objsupplier_agbwwgetfilterdata.AV46SearchTxtParms = aP1_SearchTxtParms;
         objsupplier_agbwwgetfilterdata.AV47SearchTxtTo = aP2_SearchTxtTo;
         objsupplier_agbwwgetfilterdata.AV48OptionsJson = "" ;
         objsupplier_agbwwgetfilterdata.AV49OptionsDescJson = "" ;
         objsupplier_agbwwgetfilterdata.AV50OptionIndexesJson = "" ;
         objsupplier_agbwwgetfilterdata.context.SetSubmitInitialConfig(context);
         objsupplier_agbwwgetfilterdata.initialize();
         Submit( executePrivateCatch,objsupplier_agbwwgetfilterdata);
         aP3_OptionsJson=this.AV48OptionsJson;
         aP4_OptionsDescJson=this.AV49OptionsDescJson;
         aP5_OptionIndexesJson=this.AV50OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((supplier_agbwwgetfilterdata)stateInfo).executePrivate();
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
         AV35Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV37OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV38OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV32MaxItems = 10;
         AV31PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV46SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV46SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV29SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV46SearchTxtParms)) ? "" : StringUtil.Substring( AV46SearchTxtParms, 3, -1));
         AV30SkipItems = (short)(AV31PageIndex*AV32MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV45DDOName), "DDO_SUPPLIER_AGBNUMBER") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIER_AGBNUMBEROPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV45DDOName), "DDO_SUPPLIER_AGBNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIER_AGBNAMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV45DDOName), "DDO_SUPPLIER_AGBKVKNUMBER") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIER_AGBKVKNUMBEROPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV45DDOName), "DDO_SUPPLIER_AGBVISITINGADDRESS") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIER_AGBVISITINGADDRESSOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV45DDOName), "DDO_SUPPLIER_AGBPOSTALADDRESS") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIER_AGBPOSTALADDRESSOPTIONS' */
            S161 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV45DDOName), "DDO_SUPPLIER_AGBEMAIL") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIER_AGBEMAILOPTIONS' */
            S171 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV45DDOName), "DDO_SUPPLIER_AGBPHONE") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIER_AGBPHONEOPTIONS' */
            S181 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV45DDOName), "DDO_SUPPLIER_AGBCONTACTNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIER_AGBCONTACTNAMEOPTIONS' */
            S191 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV48OptionsJson = AV35Options.ToJSonString(false);
         AV49OptionsDescJson = AV37OptionsDesc.ToJSonString(false);
         AV50OptionIndexesJson = AV38OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV40Session.Get("Supplier_AgbWWGridState"), "") == 0 )
         {
            AV42GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Supplier_AgbWWGridState"), null, "", "");
         }
         else
         {
            AV42GridState.FromXml(AV40Session.Get("Supplier_AgbWWGridState"), null, "", "");
         }
         AV52GXV1 = 1;
         while ( AV52GXV1 <= AV42GridState.gxTpr_Filtervalues.Count )
         {
            AV43GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV42GridState.gxTpr_Filtervalues.Item(AV52GXV1));
            if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV51FilterFullText = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_AGBID") == 0 )
            {
               AV11TFSupplier_AgbId = (short)(Math.Round(NumberUtil.Val( AV43GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFSupplier_AgbId_To = (short)(Math.Round(NumberUtil.Val( AV43GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_AGBNUMBER") == 0 )
            {
               AV13TFSupplier_AgbNumber = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_AGBNUMBER_SEL") == 0 )
            {
               AV14TFSupplier_AgbNumber_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_AGBNAME") == 0 )
            {
               AV15TFSupplier_AgbName = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_AGBNAME_SEL") == 0 )
            {
               AV16TFSupplier_AgbName_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_AGBKVKNUMBER") == 0 )
            {
               AV17TFSupplier_AgbKvkNumber = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_AGBKVKNUMBER_SEL") == 0 )
            {
               AV18TFSupplier_AgbKvkNumber_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_AGBVISITINGADDRESS") == 0 )
            {
               AV19TFSupplier_AgbVisitingAddress = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_AGBVISITINGADDRESS_SEL") == 0 )
            {
               AV20TFSupplier_AgbVisitingAddress_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_AGBPOSTALADDRESS") == 0 )
            {
               AV21TFSupplier_AgbPostalAddress = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_AGBPOSTALADDRESS_SEL") == 0 )
            {
               AV22TFSupplier_AgbPostalAddress_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_AGBEMAIL") == 0 )
            {
               AV23TFSupplier_AgbEmail = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_AGBEMAIL_SEL") == 0 )
            {
               AV24TFSupplier_AgbEmail_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_AGBPHONE") == 0 )
            {
               AV25TFSupplier_AgbPhone = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_AGBPHONE_SEL") == 0 )
            {
               AV26TFSupplier_AgbPhone_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_AGBCONTACTNAME") == 0 )
            {
               AV27TFSupplier_AgbContactName = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_AGBCONTACTNAME_SEL") == 0 )
            {
               AV28TFSupplier_AgbContactName_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            AV52GXV1 = (int)(AV52GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADSUPPLIER_AGBNUMBEROPTIONS' Routine */
         returnInSub = false;
         AV13TFSupplier_AgbNumber = AV29SearchTxt;
         AV14TFSupplier_AgbNumber_Sel = "";
         AV54Supplier_agbwwds_1_filterfulltext = AV51FilterFullText;
         AV55Supplier_agbwwds_2_tfsupplier_agbid = AV11TFSupplier_AgbId;
         AV56Supplier_agbwwds_3_tfsupplier_agbid_to = AV12TFSupplier_AgbId_To;
         AV57Supplier_agbwwds_4_tfsupplier_agbnumber = AV13TFSupplier_AgbNumber;
         AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel = AV14TFSupplier_AgbNumber_Sel;
         AV59Supplier_agbwwds_6_tfsupplier_agbname = AV15TFSupplier_AgbName;
         AV60Supplier_agbwwds_7_tfsupplier_agbname_sel = AV16TFSupplier_AgbName_Sel;
         AV61Supplier_agbwwds_8_tfsupplier_agbkvknumber = AV17TFSupplier_AgbKvkNumber;
         AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel = AV18TFSupplier_AgbKvkNumber_Sel;
         AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress = AV19TFSupplier_AgbVisitingAddress;
         AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel = AV20TFSupplier_AgbVisitingAddress_Sel;
         AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress = AV21TFSupplier_AgbPostalAddress;
         AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel = AV22TFSupplier_AgbPostalAddress_Sel;
         AV67Supplier_agbwwds_14_tfsupplier_agbemail = AV23TFSupplier_AgbEmail;
         AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel = AV24TFSupplier_AgbEmail_Sel;
         AV69Supplier_agbwwds_16_tfsupplier_agbphone = AV25TFSupplier_AgbPhone;
         AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel = AV26TFSupplier_AgbPhone_Sel;
         AV71Supplier_agbwwds_18_tfsupplier_agbcontactname = AV27TFSupplier_AgbContactName;
         AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel = AV28TFSupplier_AgbContactName_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV54Supplier_agbwwds_1_filterfulltext ,
                                              AV55Supplier_agbwwds_2_tfsupplier_agbid ,
                                              AV56Supplier_agbwwds_3_tfsupplier_agbid_to ,
                                              AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel ,
                                              AV57Supplier_agbwwds_4_tfsupplier_agbnumber ,
                                              AV60Supplier_agbwwds_7_tfsupplier_agbname_sel ,
                                              AV59Supplier_agbwwds_6_tfsupplier_agbname ,
                                              AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel ,
                                              AV61Supplier_agbwwds_8_tfsupplier_agbkvknumber ,
                                              AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel ,
                                              AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress ,
                                              AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel ,
                                              AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress ,
                                              AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel ,
                                              AV67Supplier_agbwwds_14_tfsupplier_agbemail ,
                                              AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel ,
                                              AV69Supplier_agbwwds_16_tfsupplier_agbphone ,
                                              AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel ,
                                              AV71Supplier_agbwwds_18_tfsupplier_agbcontactname ,
                                              A55Supplier_AgbId ,
                                              A56Supplier_AgbNumber ,
                                              A57Supplier_AgbName ,
                                              A58Supplier_AgbKvkNumber ,
                                              A59Supplier_AgbVisitingAddress ,
                                              A60Supplier_AgbPostalAddress ,
                                              A61Supplier_AgbEmail ,
                                              A62Supplier_AgbPhone ,
                                              A63Supplier_AgbContactName } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV57Supplier_agbwwds_4_tfsupplier_agbnumber = StringUtil.Concat( StringUtil.RTrim( AV57Supplier_agbwwds_4_tfsupplier_agbnumber), "%", "");
         lV59Supplier_agbwwds_6_tfsupplier_agbname = StringUtil.Concat( StringUtil.RTrim( AV59Supplier_agbwwds_6_tfsupplier_agbname), "%", "");
         lV61Supplier_agbwwds_8_tfsupplier_agbkvknumber = StringUtil.Concat( StringUtil.RTrim( AV61Supplier_agbwwds_8_tfsupplier_agbkvknumber), "%", "");
         lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress = StringUtil.Concat( StringUtil.RTrim( AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress), "%", "");
         lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress = StringUtil.Concat( StringUtil.RTrim( AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress), "%", "");
         lV67Supplier_agbwwds_14_tfsupplier_agbemail = StringUtil.Concat( StringUtil.RTrim( AV67Supplier_agbwwds_14_tfsupplier_agbemail), "%", "");
         lV69Supplier_agbwwds_16_tfsupplier_agbphone = StringUtil.PadR( StringUtil.RTrim( AV69Supplier_agbwwds_16_tfsupplier_agbphone), 20, "%");
         lV71Supplier_agbwwds_18_tfsupplier_agbcontactname = StringUtil.Concat( StringUtil.RTrim( AV71Supplier_agbwwds_18_tfsupplier_agbcontactname), "%", "");
         /* Using cursor P002F2 */
         pr_default.execute(0, new Object[] {lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, AV55Supplier_agbwwds_2_tfsupplier_agbid, AV56Supplier_agbwwds_3_tfsupplier_agbid_to, lV57Supplier_agbwwds_4_tfsupplier_agbnumber, AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel, lV59Supplier_agbwwds_6_tfsupplier_agbname, AV60Supplier_agbwwds_7_tfsupplier_agbname_sel, lV61Supplier_agbwwds_8_tfsupplier_agbkvknumber, AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel, lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress, AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress, AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel, lV67Supplier_agbwwds_14_tfsupplier_agbemail, AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel, lV69Supplier_agbwwds_16_tfsupplier_agbphone, AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel, lV71Supplier_agbwwds_18_tfsupplier_agbcontactname, AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK2F2 = false;
            A56Supplier_AgbNumber = P002F2_A56Supplier_AgbNumber[0];
            A55Supplier_AgbId = P002F2_A55Supplier_AgbId[0];
            A63Supplier_AgbContactName = P002F2_A63Supplier_AgbContactName[0];
            n63Supplier_AgbContactName = P002F2_n63Supplier_AgbContactName[0];
            A62Supplier_AgbPhone = P002F2_A62Supplier_AgbPhone[0];
            n62Supplier_AgbPhone = P002F2_n62Supplier_AgbPhone[0];
            A61Supplier_AgbEmail = P002F2_A61Supplier_AgbEmail[0];
            n61Supplier_AgbEmail = P002F2_n61Supplier_AgbEmail[0];
            A60Supplier_AgbPostalAddress = P002F2_A60Supplier_AgbPostalAddress[0];
            n60Supplier_AgbPostalAddress = P002F2_n60Supplier_AgbPostalAddress[0];
            A59Supplier_AgbVisitingAddress = P002F2_A59Supplier_AgbVisitingAddress[0];
            n59Supplier_AgbVisitingAddress = P002F2_n59Supplier_AgbVisitingAddress[0];
            A58Supplier_AgbKvkNumber = P002F2_A58Supplier_AgbKvkNumber[0];
            A57Supplier_AgbName = P002F2_A57Supplier_AgbName[0];
            AV39count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P002F2_A56Supplier_AgbNumber[0], A56Supplier_AgbNumber) == 0 ) )
            {
               BRK2F2 = false;
               A55Supplier_AgbId = P002F2_A55Supplier_AgbId[0];
               AV39count = (long)(AV39count+1);
               BRK2F2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV30SkipItems) )
            {
               AV34Option = (String.IsNullOrEmpty(StringUtil.RTrim( A56Supplier_AgbNumber)) ? "<#Empty#>" : A56Supplier_AgbNumber);
               AV35Options.Add(AV34Option, 0);
               AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV39count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV35Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV30SkipItems = (short)(AV30SkipItems-1);
            }
            if ( ! BRK2F2 )
            {
               BRK2F2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADSUPPLIER_AGBNAMEOPTIONS' Routine */
         returnInSub = false;
         AV15TFSupplier_AgbName = AV29SearchTxt;
         AV16TFSupplier_AgbName_Sel = "";
         AV54Supplier_agbwwds_1_filterfulltext = AV51FilterFullText;
         AV55Supplier_agbwwds_2_tfsupplier_agbid = AV11TFSupplier_AgbId;
         AV56Supplier_agbwwds_3_tfsupplier_agbid_to = AV12TFSupplier_AgbId_To;
         AV57Supplier_agbwwds_4_tfsupplier_agbnumber = AV13TFSupplier_AgbNumber;
         AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel = AV14TFSupplier_AgbNumber_Sel;
         AV59Supplier_agbwwds_6_tfsupplier_agbname = AV15TFSupplier_AgbName;
         AV60Supplier_agbwwds_7_tfsupplier_agbname_sel = AV16TFSupplier_AgbName_Sel;
         AV61Supplier_agbwwds_8_tfsupplier_agbkvknumber = AV17TFSupplier_AgbKvkNumber;
         AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel = AV18TFSupplier_AgbKvkNumber_Sel;
         AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress = AV19TFSupplier_AgbVisitingAddress;
         AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel = AV20TFSupplier_AgbVisitingAddress_Sel;
         AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress = AV21TFSupplier_AgbPostalAddress;
         AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel = AV22TFSupplier_AgbPostalAddress_Sel;
         AV67Supplier_agbwwds_14_tfsupplier_agbemail = AV23TFSupplier_AgbEmail;
         AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel = AV24TFSupplier_AgbEmail_Sel;
         AV69Supplier_agbwwds_16_tfsupplier_agbphone = AV25TFSupplier_AgbPhone;
         AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel = AV26TFSupplier_AgbPhone_Sel;
         AV71Supplier_agbwwds_18_tfsupplier_agbcontactname = AV27TFSupplier_AgbContactName;
         AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel = AV28TFSupplier_AgbContactName_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV54Supplier_agbwwds_1_filterfulltext ,
                                              AV55Supplier_agbwwds_2_tfsupplier_agbid ,
                                              AV56Supplier_agbwwds_3_tfsupplier_agbid_to ,
                                              AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel ,
                                              AV57Supplier_agbwwds_4_tfsupplier_agbnumber ,
                                              AV60Supplier_agbwwds_7_tfsupplier_agbname_sel ,
                                              AV59Supplier_agbwwds_6_tfsupplier_agbname ,
                                              AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel ,
                                              AV61Supplier_agbwwds_8_tfsupplier_agbkvknumber ,
                                              AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel ,
                                              AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress ,
                                              AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel ,
                                              AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress ,
                                              AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel ,
                                              AV67Supplier_agbwwds_14_tfsupplier_agbemail ,
                                              AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel ,
                                              AV69Supplier_agbwwds_16_tfsupplier_agbphone ,
                                              AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel ,
                                              AV71Supplier_agbwwds_18_tfsupplier_agbcontactname ,
                                              A55Supplier_AgbId ,
                                              A56Supplier_AgbNumber ,
                                              A57Supplier_AgbName ,
                                              A58Supplier_AgbKvkNumber ,
                                              A59Supplier_AgbVisitingAddress ,
                                              A60Supplier_AgbPostalAddress ,
                                              A61Supplier_AgbEmail ,
                                              A62Supplier_AgbPhone ,
                                              A63Supplier_AgbContactName } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV57Supplier_agbwwds_4_tfsupplier_agbnumber = StringUtil.Concat( StringUtil.RTrim( AV57Supplier_agbwwds_4_tfsupplier_agbnumber), "%", "");
         lV59Supplier_agbwwds_6_tfsupplier_agbname = StringUtil.Concat( StringUtil.RTrim( AV59Supplier_agbwwds_6_tfsupplier_agbname), "%", "");
         lV61Supplier_agbwwds_8_tfsupplier_agbkvknumber = StringUtil.Concat( StringUtil.RTrim( AV61Supplier_agbwwds_8_tfsupplier_agbkvknumber), "%", "");
         lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress = StringUtil.Concat( StringUtil.RTrim( AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress), "%", "");
         lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress = StringUtil.Concat( StringUtil.RTrim( AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress), "%", "");
         lV67Supplier_agbwwds_14_tfsupplier_agbemail = StringUtil.Concat( StringUtil.RTrim( AV67Supplier_agbwwds_14_tfsupplier_agbemail), "%", "");
         lV69Supplier_agbwwds_16_tfsupplier_agbphone = StringUtil.PadR( StringUtil.RTrim( AV69Supplier_agbwwds_16_tfsupplier_agbphone), 20, "%");
         lV71Supplier_agbwwds_18_tfsupplier_agbcontactname = StringUtil.Concat( StringUtil.RTrim( AV71Supplier_agbwwds_18_tfsupplier_agbcontactname), "%", "");
         /* Using cursor P002F3 */
         pr_default.execute(1, new Object[] {lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, AV55Supplier_agbwwds_2_tfsupplier_agbid, AV56Supplier_agbwwds_3_tfsupplier_agbid_to, lV57Supplier_agbwwds_4_tfsupplier_agbnumber, AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel, lV59Supplier_agbwwds_6_tfsupplier_agbname, AV60Supplier_agbwwds_7_tfsupplier_agbname_sel, lV61Supplier_agbwwds_8_tfsupplier_agbkvknumber, AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel, lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress, AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress, AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel, lV67Supplier_agbwwds_14_tfsupplier_agbemail, AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel, lV69Supplier_agbwwds_16_tfsupplier_agbphone, AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel, lV71Supplier_agbwwds_18_tfsupplier_agbcontactname, AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK2F4 = false;
            A57Supplier_AgbName = P002F3_A57Supplier_AgbName[0];
            A55Supplier_AgbId = P002F3_A55Supplier_AgbId[0];
            A63Supplier_AgbContactName = P002F3_A63Supplier_AgbContactName[0];
            n63Supplier_AgbContactName = P002F3_n63Supplier_AgbContactName[0];
            A62Supplier_AgbPhone = P002F3_A62Supplier_AgbPhone[0];
            n62Supplier_AgbPhone = P002F3_n62Supplier_AgbPhone[0];
            A61Supplier_AgbEmail = P002F3_A61Supplier_AgbEmail[0];
            n61Supplier_AgbEmail = P002F3_n61Supplier_AgbEmail[0];
            A60Supplier_AgbPostalAddress = P002F3_A60Supplier_AgbPostalAddress[0];
            n60Supplier_AgbPostalAddress = P002F3_n60Supplier_AgbPostalAddress[0];
            A59Supplier_AgbVisitingAddress = P002F3_A59Supplier_AgbVisitingAddress[0];
            n59Supplier_AgbVisitingAddress = P002F3_n59Supplier_AgbVisitingAddress[0];
            A58Supplier_AgbKvkNumber = P002F3_A58Supplier_AgbKvkNumber[0];
            A56Supplier_AgbNumber = P002F3_A56Supplier_AgbNumber[0];
            AV39count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P002F3_A57Supplier_AgbName[0], A57Supplier_AgbName) == 0 ) )
            {
               BRK2F4 = false;
               A55Supplier_AgbId = P002F3_A55Supplier_AgbId[0];
               AV39count = (long)(AV39count+1);
               BRK2F4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV30SkipItems) )
            {
               AV34Option = (String.IsNullOrEmpty(StringUtil.RTrim( A57Supplier_AgbName)) ? "<#Empty#>" : A57Supplier_AgbName);
               AV35Options.Add(AV34Option, 0);
               AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV39count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV35Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV30SkipItems = (short)(AV30SkipItems-1);
            }
            if ( ! BRK2F4 )
            {
               BRK2F4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADSUPPLIER_AGBKVKNUMBEROPTIONS' Routine */
         returnInSub = false;
         AV17TFSupplier_AgbKvkNumber = AV29SearchTxt;
         AV18TFSupplier_AgbKvkNumber_Sel = "";
         AV54Supplier_agbwwds_1_filterfulltext = AV51FilterFullText;
         AV55Supplier_agbwwds_2_tfsupplier_agbid = AV11TFSupplier_AgbId;
         AV56Supplier_agbwwds_3_tfsupplier_agbid_to = AV12TFSupplier_AgbId_To;
         AV57Supplier_agbwwds_4_tfsupplier_agbnumber = AV13TFSupplier_AgbNumber;
         AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel = AV14TFSupplier_AgbNumber_Sel;
         AV59Supplier_agbwwds_6_tfsupplier_agbname = AV15TFSupplier_AgbName;
         AV60Supplier_agbwwds_7_tfsupplier_agbname_sel = AV16TFSupplier_AgbName_Sel;
         AV61Supplier_agbwwds_8_tfsupplier_agbkvknumber = AV17TFSupplier_AgbKvkNumber;
         AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel = AV18TFSupplier_AgbKvkNumber_Sel;
         AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress = AV19TFSupplier_AgbVisitingAddress;
         AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel = AV20TFSupplier_AgbVisitingAddress_Sel;
         AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress = AV21TFSupplier_AgbPostalAddress;
         AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel = AV22TFSupplier_AgbPostalAddress_Sel;
         AV67Supplier_agbwwds_14_tfsupplier_agbemail = AV23TFSupplier_AgbEmail;
         AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel = AV24TFSupplier_AgbEmail_Sel;
         AV69Supplier_agbwwds_16_tfsupplier_agbphone = AV25TFSupplier_AgbPhone;
         AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel = AV26TFSupplier_AgbPhone_Sel;
         AV71Supplier_agbwwds_18_tfsupplier_agbcontactname = AV27TFSupplier_AgbContactName;
         AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel = AV28TFSupplier_AgbContactName_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV54Supplier_agbwwds_1_filterfulltext ,
                                              AV55Supplier_agbwwds_2_tfsupplier_agbid ,
                                              AV56Supplier_agbwwds_3_tfsupplier_agbid_to ,
                                              AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel ,
                                              AV57Supplier_agbwwds_4_tfsupplier_agbnumber ,
                                              AV60Supplier_agbwwds_7_tfsupplier_agbname_sel ,
                                              AV59Supplier_agbwwds_6_tfsupplier_agbname ,
                                              AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel ,
                                              AV61Supplier_agbwwds_8_tfsupplier_agbkvknumber ,
                                              AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel ,
                                              AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress ,
                                              AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel ,
                                              AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress ,
                                              AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel ,
                                              AV67Supplier_agbwwds_14_tfsupplier_agbemail ,
                                              AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel ,
                                              AV69Supplier_agbwwds_16_tfsupplier_agbphone ,
                                              AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel ,
                                              AV71Supplier_agbwwds_18_tfsupplier_agbcontactname ,
                                              A55Supplier_AgbId ,
                                              A56Supplier_AgbNumber ,
                                              A57Supplier_AgbName ,
                                              A58Supplier_AgbKvkNumber ,
                                              A59Supplier_AgbVisitingAddress ,
                                              A60Supplier_AgbPostalAddress ,
                                              A61Supplier_AgbEmail ,
                                              A62Supplier_AgbPhone ,
                                              A63Supplier_AgbContactName } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV57Supplier_agbwwds_4_tfsupplier_agbnumber = StringUtil.Concat( StringUtil.RTrim( AV57Supplier_agbwwds_4_tfsupplier_agbnumber), "%", "");
         lV59Supplier_agbwwds_6_tfsupplier_agbname = StringUtil.Concat( StringUtil.RTrim( AV59Supplier_agbwwds_6_tfsupplier_agbname), "%", "");
         lV61Supplier_agbwwds_8_tfsupplier_agbkvknumber = StringUtil.Concat( StringUtil.RTrim( AV61Supplier_agbwwds_8_tfsupplier_agbkvknumber), "%", "");
         lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress = StringUtil.Concat( StringUtil.RTrim( AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress), "%", "");
         lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress = StringUtil.Concat( StringUtil.RTrim( AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress), "%", "");
         lV67Supplier_agbwwds_14_tfsupplier_agbemail = StringUtil.Concat( StringUtil.RTrim( AV67Supplier_agbwwds_14_tfsupplier_agbemail), "%", "");
         lV69Supplier_agbwwds_16_tfsupplier_agbphone = StringUtil.PadR( StringUtil.RTrim( AV69Supplier_agbwwds_16_tfsupplier_agbphone), 20, "%");
         lV71Supplier_agbwwds_18_tfsupplier_agbcontactname = StringUtil.Concat( StringUtil.RTrim( AV71Supplier_agbwwds_18_tfsupplier_agbcontactname), "%", "");
         /* Using cursor P002F4 */
         pr_default.execute(2, new Object[] {lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, AV55Supplier_agbwwds_2_tfsupplier_agbid, AV56Supplier_agbwwds_3_tfsupplier_agbid_to, lV57Supplier_agbwwds_4_tfsupplier_agbnumber, AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel, lV59Supplier_agbwwds_6_tfsupplier_agbname, AV60Supplier_agbwwds_7_tfsupplier_agbname_sel, lV61Supplier_agbwwds_8_tfsupplier_agbkvknumber, AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel, lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress, AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress, AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel, lV67Supplier_agbwwds_14_tfsupplier_agbemail, AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel, lV69Supplier_agbwwds_16_tfsupplier_agbphone, AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel, lV71Supplier_agbwwds_18_tfsupplier_agbcontactname, AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK2F6 = false;
            A58Supplier_AgbKvkNumber = P002F4_A58Supplier_AgbKvkNumber[0];
            A55Supplier_AgbId = P002F4_A55Supplier_AgbId[0];
            A63Supplier_AgbContactName = P002F4_A63Supplier_AgbContactName[0];
            n63Supplier_AgbContactName = P002F4_n63Supplier_AgbContactName[0];
            A62Supplier_AgbPhone = P002F4_A62Supplier_AgbPhone[0];
            n62Supplier_AgbPhone = P002F4_n62Supplier_AgbPhone[0];
            A61Supplier_AgbEmail = P002F4_A61Supplier_AgbEmail[0];
            n61Supplier_AgbEmail = P002F4_n61Supplier_AgbEmail[0];
            A60Supplier_AgbPostalAddress = P002F4_A60Supplier_AgbPostalAddress[0];
            n60Supplier_AgbPostalAddress = P002F4_n60Supplier_AgbPostalAddress[0];
            A59Supplier_AgbVisitingAddress = P002F4_A59Supplier_AgbVisitingAddress[0];
            n59Supplier_AgbVisitingAddress = P002F4_n59Supplier_AgbVisitingAddress[0];
            A57Supplier_AgbName = P002F4_A57Supplier_AgbName[0];
            A56Supplier_AgbNumber = P002F4_A56Supplier_AgbNumber[0];
            AV39count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P002F4_A58Supplier_AgbKvkNumber[0], A58Supplier_AgbKvkNumber) == 0 ) )
            {
               BRK2F6 = false;
               A55Supplier_AgbId = P002F4_A55Supplier_AgbId[0];
               AV39count = (long)(AV39count+1);
               BRK2F6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV30SkipItems) )
            {
               AV34Option = (String.IsNullOrEmpty(StringUtil.RTrim( A58Supplier_AgbKvkNumber)) ? "<#Empty#>" : A58Supplier_AgbKvkNumber);
               AV35Options.Add(AV34Option, 0);
               AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV39count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV35Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV30SkipItems = (short)(AV30SkipItems-1);
            }
            if ( ! BRK2F6 )
            {
               BRK2F6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADSUPPLIER_AGBVISITINGADDRESSOPTIONS' Routine */
         returnInSub = false;
         AV19TFSupplier_AgbVisitingAddress = AV29SearchTxt;
         AV20TFSupplier_AgbVisitingAddress_Sel = "";
         AV54Supplier_agbwwds_1_filterfulltext = AV51FilterFullText;
         AV55Supplier_agbwwds_2_tfsupplier_agbid = AV11TFSupplier_AgbId;
         AV56Supplier_agbwwds_3_tfsupplier_agbid_to = AV12TFSupplier_AgbId_To;
         AV57Supplier_agbwwds_4_tfsupplier_agbnumber = AV13TFSupplier_AgbNumber;
         AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel = AV14TFSupplier_AgbNumber_Sel;
         AV59Supplier_agbwwds_6_tfsupplier_agbname = AV15TFSupplier_AgbName;
         AV60Supplier_agbwwds_7_tfsupplier_agbname_sel = AV16TFSupplier_AgbName_Sel;
         AV61Supplier_agbwwds_8_tfsupplier_agbkvknumber = AV17TFSupplier_AgbKvkNumber;
         AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel = AV18TFSupplier_AgbKvkNumber_Sel;
         AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress = AV19TFSupplier_AgbVisitingAddress;
         AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel = AV20TFSupplier_AgbVisitingAddress_Sel;
         AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress = AV21TFSupplier_AgbPostalAddress;
         AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel = AV22TFSupplier_AgbPostalAddress_Sel;
         AV67Supplier_agbwwds_14_tfsupplier_agbemail = AV23TFSupplier_AgbEmail;
         AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel = AV24TFSupplier_AgbEmail_Sel;
         AV69Supplier_agbwwds_16_tfsupplier_agbphone = AV25TFSupplier_AgbPhone;
         AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel = AV26TFSupplier_AgbPhone_Sel;
         AV71Supplier_agbwwds_18_tfsupplier_agbcontactname = AV27TFSupplier_AgbContactName;
         AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel = AV28TFSupplier_AgbContactName_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV54Supplier_agbwwds_1_filterfulltext ,
                                              AV55Supplier_agbwwds_2_tfsupplier_agbid ,
                                              AV56Supplier_agbwwds_3_tfsupplier_agbid_to ,
                                              AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel ,
                                              AV57Supplier_agbwwds_4_tfsupplier_agbnumber ,
                                              AV60Supplier_agbwwds_7_tfsupplier_agbname_sel ,
                                              AV59Supplier_agbwwds_6_tfsupplier_agbname ,
                                              AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel ,
                                              AV61Supplier_agbwwds_8_tfsupplier_agbkvknumber ,
                                              AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel ,
                                              AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress ,
                                              AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel ,
                                              AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress ,
                                              AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel ,
                                              AV67Supplier_agbwwds_14_tfsupplier_agbemail ,
                                              AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel ,
                                              AV69Supplier_agbwwds_16_tfsupplier_agbphone ,
                                              AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel ,
                                              AV71Supplier_agbwwds_18_tfsupplier_agbcontactname ,
                                              A55Supplier_AgbId ,
                                              A56Supplier_AgbNumber ,
                                              A57Supplier_AgbName ,
                                              A58Supplier_AgbKvkNumber ,
                                              A59Supplier_AgbVisitingAddress ,
                                              A60Supplier_AgbPostalAddress ,
                                              A61Supplier_AgbEmail ,
                                              A62Supplier_AgbPhone ,
                                              A63Supplier_AgbContactName } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV57Supplier_agbwwds_4_tfsupplier_agbnumber = StringUtil.Concat( StringUtil.RTrim( AV57Supplier_agbwwds_4_tfsupplier_agbnumber), "%", "");
         lV59Supplier_agbwwds_6_tfsupplier_agbname = StringUtil.Concat( StringUtil.RTrim( AV59Supplier_agbwwds_6_tfsupplier_agbname), "%", "");
         lV61Supplier_agbwwds_8_tfsupplier_agbkvknumber = StringUtil.Concat( StringUtil.RTrim( AV61Supplier_agbwwds_8_tfsupplier_agbkvknumber), "%", "");
         lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress = StringUtil.Concat( StringUtil.RTrim( AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress), "%", "");
         lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress = StringUtil.Concat( StringUtil.RTrim( AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress), "%", "");
         lV67Supplier_agbwwds_14_tfsupplier_agbemail = StringUtil.Concat( StringUtil.RTrim( AV67Supplier_agbwwds_14_tfsupplier_agbemail), "%", "");
         lV69Supplier_agbwwds_16_tfsupplier_agbphone = StringUtil.PadR( StringUtil.RTrim( AV69Supplier_agbwwds_16_tfsupplier_agbphone), 20, "%");
         lV71Supplier_agbwwds_18_tfsupplier_agbcontactname = StringUtil.Concat( StringUtil.RTrim( AV71Supplier_agbwwds_18_tfsupplier_agbcontactname), "%", "");
         /* Using cursor P002F5 */
         pr_default.execute(3, new Object[] {lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, AV55Supplier_agbwwds_2_tfsupplier_agbid, AV56Supplier_agbwwds_3_tfsupplier_agbid_to, lV57Supplier_agbwwds_4_tfsupplier_agbnumber, AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel, lV59Supplier_agbwwds_6_tfsupplier_agbname, AV60Supplier_agbwwds_7_tfsupplier_agbname_sel, lV61Supplier_agbwwds_8_tfsupplier_agbkvknumber, AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel, lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress, AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress, AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel, lV67Supplier_agbwwds_14_tfsupplier_agbemail, AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel, lV69Supplier_agbwwds_16_tfsupplier_agbphone, AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel, lV71Supplier_agbwwds_18_tfsupplier_agbcontactname, AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK2F8 = false;
            A59Supplier_AgbVisitingAddress = P002F5_A59Supplier_AgbVisitingAddress[0];
            n59Supplier_AgbVisitingAddress = P002F5_n59Supplier_AgbVisitingAddress[0];
            A55Supplier_AgbId = P002F5_A55Supplier_AgbId[0];
            A63Supplier_AgbContactName = P002F5_A63Supplier_AgbContactName[0];
            n63Supplier_AgbContactName = P002F5_n63Supplier_AgbContactName[0];
            A62Supplier_AgbPhone = P002F5_A62Supplier_AgbPhone[0];
            n62Supplier_AgbPhone = P002F5_n62Supplier_AgbPhone[0];
            A61Supplier_AgbEmail = P002F5_A61Supplier_AgbEmail[0];
            n61Supplier_AgbEmail = P002F5_n61Supplier_AgbEmail[0];
            A60Supplier_AgbPostalAddress = P002F5_A60Supplier_AgbPostalAddress[0];
            n60Supplier_AgbPostalAddress = P002F5_n60Supplier_AgbPostalAddress[0];
            A58Supplier_AgbKvkNumber = P002F5_A58Supplier_AgbKvkNumber[0];
            A57Supplier_AgbName = P002F5_A57Supplier_AgbName[0];
            A56Supplier_AgbNumber = P002F5_A56Supplier_AgbNumber[0];
            AV39count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P002F5_A59Supplier_AgbVisitingAddress[0], A59Supplier_AgbVisitingAddress) == 0 ) )
            {
               BRK2F8 = false;
               A55Supplier_AgbId = P002F5_A55Supplier_AgbId[0];
               AV39count = (long)(AV39count+1);
               BRK2F8 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV30SkipItems) )
            {
               AV34Option = (String.IsNullOrEmpty(StringUtil.RTrim( A59Supplier_AgbVisitingAddress)) ? "<#Empty#>" : A59Supplier_AgbVisitingAddress);
               AV35Options.Add(AV34Option, 0);
               AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV39count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV35Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV30SkipItems = (short)(AV30SkipItems-1);
            }
            if ( ! BRK2F8 )
            {
               BRK2F8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADSUPPLIER_AGBPOSTALADDRESSOPTIONS' Routine */
         returnInSub = false;
         AV21TFSupplier_AgbPostalAddress = AV29SearchTxt;
         AV22TFSupplier_AgbPostalAddress_Sel = "";
         AV54Supplier_agbwwds_1_filterfulltext = AV51FilterFullText;
         AV55Supplier_agbwwds_2_tfsupplier_agbid = AV11TFSupplier_AgbId;
         AV56Supplier_agbwwds_3_tfsupplier_agbid_to = AV12TFSupplier_AgbId_To;
         AV57Supplier_agbwwds_4_tfsupplier_agbnumber = AV13TFSupplier_AgbNumber;
         AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel = AV14TFSupplier_AgbNumber_Sel;
         AV59Supplier_agbwwds_6_tfsupplier_agbname = AV15TFSupplier_AgbName;
         AV60Supplier_agbwwds_7_tfsupplier_agbname_sel = AV16TFSupplier_AgbName_Sel;
         AV61Supplier_agbwwds_8_tfsupplier_agbkvknumber = AV17TFSupplier_AgbKvkNumber;
         AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel = AV18TFSupplier_AgbKvkNumber_Sel;
         AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress = AV19TFSupplier_AgbVisitingAddress;
         AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel = AV20TFSupplier_AgbVisitingAddress_Sel;
         AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress = AV21TFSupplier_AgbPostalAddress;
         AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel = AV22TFSupplier_AgbPostalAddress_Sel;
         AV67Supplier_agbwwds_14_tfsupplier_agbemail = AV23TFSupplier_AgbEmail;
         AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel = AV24TFSupplier_AgbEmail_Sel;
         AV69Supplier_agbwwds_16_tfsupplier_agbphone = AV25TFSupplier_AgbPhone;
         AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel = AV26TFSupplier_AgbPhone_Sel;
         AV71Supplier_agbwwds_18_tfsupplier_agbcontactname = AV27TFSupplier_AgbContactName;
         AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel = AV28TFSupplier_AgbContactName_Sel;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV54Supplier_agbwwds_1_filterfulltext ,
                                              AV55Supplier_agbwwds_2_tfsupplier_agbid ,
                                              AV56Supplier_agbwwds_3_tfsupplier_agbid_to ,
                                              AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel ,
                                              AV57Supplier_agbwwds_4_tfsupplier_agbnumber ,
                                              AV60Supplier_agbwwds_7_tfsupplier_agbname_sel ,
                                              AV59Supplier_agbwwds_6_tfsupplier_agbname ,
                                              AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel ,
                                              AV61Supplier_agbwwds_8_tfsupplier_agbkvknumber ,
                                              AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel ,
                                              AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress ,
                                              AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel ,
                                              AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress ,
                                              AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel ,
                                              AV67Supplier_agbwwds_14_tfsupplier_agbemail ,
                                              AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel ,
                                              AV69Supplier_agbwwds_16_tfsupplier_agbphone ,
                                              AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel ,
                                              AV71Supplier_agbwwds_18_tfsupplier_agbcontactname ,
                                              A55Supplier_AgbId ,
                                              A56Supplier_AgbNumber ,
                                              A57Supplier_AgbName ,
                                              A58Supplier_AgbKvkNumber ,
                                              A59Supplier_AgbVisitingAddress ,
                                              A60Supplier_AgbPostalAddress ,
                                              A61Supplier_AgbEmail ,
                                              A62Supplier_AgbPhone ,
                                              A63Supplier_AgbContactName } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV57Supplier_agbwwds_4_tfsupplier_agbnumber = StringUtil.Concat( StringUtil.RTrim( AV57Supplier_agbwwds_4_tfsupplier_agbnumber), "%", "");
         lV59Supplier_agbwwds_6_tfsupplier_agbname = StringUtil.Concat( StringUtil.RTrim( AV59Supplier_agbwwds_6_tfsupplier_agbname), "%", "");
         lV61Supplier_agbwwds_8_tfsupplier_agbkvknumber = StringUtil.Concat( StringUtil.RTrim( AV61Supplier_agbwwds_8_tfsupplier_agbkvknumber), "%", "");
         lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress = StringUtil.Concat( StringUtil.RTrim( AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress), "%", "");
         lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress = StringUtil.Concat( StringUtil.RTrim( AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress), "%", "");
         lV67Supplier_agbwwds_14_tfsupplier_agbemail = StringUtil.Concat( StringUtil.RTrim( AV67Supplier_agbwwds_14_tfsupplier_agbemail), "%", "");
         lV69Supplier_agbwwds_16_tfsupplier_agbphone = StringUtil.PadR( StringUtil.RTrim( AV69Supplier_agbwwds_16_tfsupplier_agbphone), 20, "%");
         lV71Supplier_agbwwds_18_tfsupplier_agbcontactname = StringUtil.Concat( StringUtil.RTrim( AV71Supplier_agbwwds_18_tfsupplier_agbcontactname), "%", "");
         /* Using cursor P002F6 */
         pr_default.execute(4, new Object[] {lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, AV55Supplier_agbwwds_2_tfsupplier_agbid, AV56Supplier_agbwwds_3_tfsupplier_agbid_to, lV57Supplier_agbwwds_4_tfsupplier_agbnumber, AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel, lV59Supplier_agbwwds_6_tfsupplier_agbname, AV60Supplier_agbwwds_7_tfsupplier_agbname_sel, lV61Supplier_agbwwds_8_tfsupplier_agbkvknumber, AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel, lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress, AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress, AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel, lV67Supplier_agbwwds_14_tfsupplier_agbemail, AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel, lV69Supplier_agbwwds_16_tfsupplier_agbphone, AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel, lV71Supplier_agbwwds_18_tfsupplier_agbcontactname, AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRK2F10 = false;
            A60Supplier_AgbPostalAddress = P002F6_A60Supplier_AgbPostalAddress[0];
            n60Supplier_AgbPostalAddress = P002F6_n60Supplier_AgbPostalAddress[0];
            A55Supplier_AgbId = P002F6_A55Supplier_AgbId[0];
            A63Supplier_AgbContactName = P002F6_A63Supplier_AgbContactName[0];
            n63Supplier_AgbContactName = P002F6_n63Supplier_AgbContactName[0];
            A62Supplier_AgbPhone = P002F6_A62Supplier_AgbPhone[0];
            n62Supplier_AgbPhone = P002F6_n62Supplier_AgbPhone[0];
            A61Supplier_AgbEmail = P002F6_A61Supplier_AgbEmail[0];
            n61Supplier_AgbEmail = P002F6_n61Supplier_AgbEmail[0];
            A59Supplier_AgbVisitingAddress = P002F6_A59Supplier_AgbVisitingAddress[0];
            n59Supplier_AgbVisitingAddress = P002F6_n59Supplier_AgbVisitingAddress[0];
            A58Supplier_AgbKvkNumber = P002F6_A58Supplier_AgbKvkNumber[0];
            A57Supplier_AgbName = P002F6_A57Supplier_AgbName[0];
            A56Supplier_AgbNumber = P002F6_A56Supplier_AgbNumber[0];
            AV39count = 0;
            while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P002F6_A60Supplier_AgbPostalAddress[0], A60Supplier_AgbPostalAddress) == 0 ) )
            {
               BRK2F10 = false;
               A55Supplier_AgbId = P002F6_A55Supplier_AgbId[0];
               AV39count = (long)(AV39count+1);
               BRK2F10 = true;
               pr_default.readNext(4);
            }
            if ( (0==AV30SkipItems) )
            {
               AV34Option = (String.IsNullOrEmpty(StringUtil.RTrim( A60Supplier_AgbPostalAddress)) ? "<#Empty#>" : A60Supplier_AgbPostalAddress);
               AV35Options.Add(AV34Option, 0);
               AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV39count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV35Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV30SkipItems = (short)(AV30SkipItems-1);
            }
            if ( ! BRK2F10 )
            {
               BRK2F10 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
      }

      protected void S171( )
      {
         /* 'LOADSUPPLIER_AGBEMAILOPTIONS' Routine */
         returnInSub = false;
         AV23TFSupplier_AgbEmail = AV29SearchTxt;
         AV24TFSupplier_AgbEmail_Sel = "";
         AV54Supplier_agbwwds_1_filterfulltext = AV51FilterFullText;
         AV55Supplier_agbwwds_2_tfsupplier_agbid = AV11TFSupplier_AgbId;
         AV56Supplier_agbwwds_3_tfsupplier_agbid_to = AV12TFSupplier_AgbId_To;
         AV57Supplier_agbwwds_4_tfsupplier_agbnumber = AV13TFSupplier_AgbNumber;
         AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel = AV14TFSupplier_AgbNumber_Sel;
         AV59Supplier_agbwwds_6_tfsupplier_agbname = AV15TFSupplier_AgbName;
         AV60Supplier_agbwwds_7_tfsupplier_agbname_sel = AV16TFSupplier_AgbName_Sel;
         AV61Supplier_agbwwds_8_tfsupplier_agbkvknumber = AV17TFSupplier_AgbKvkNumber;
         AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel = AV18TFSupplier_AgbKvkNumber_Sel;
         AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress = AV19TFSupplier_AgbVisitingAddress;
         AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel = AV20TFSupplier_AgbVisitingAddress_Sel;
         AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress = AV21TFSupplier_AgbPostalAddress;
         AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel = AV22TFSupplier_AgbPostalAddress_Sel;
         AV67Supplier_agbwwds_14_tfsupplier_agbemail = AV23TFSupplier_AgbEmail;
         AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel = AV24TFSupplier_AgbEmail_Sel;
         AV69Supplier_agbwwds_16_tfsupplier_agbphone = AV25TFSupplier_AgbPhone;
         AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel = AV26TFSupplier_AgbPhone_Sel;
         AV71Supplier_agbwwds_18_tfsupplier_agbcontactname = AV27TFSupplier_AgbContactName;
         AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel = AV28TFSupplier_AgbContactName_Sel;
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              AV54Supplier_agbwwds_1_filterfulltext ,
                                              AV55Supplier_agbwwds_2_tfsupplier_agbid ,
                                              AV56Supplier_agbwwds_3_tfsupplier_agbid_to ,
                                              AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel ,
                                              AV57Supplier_agbwwds_4_tfsupplier_agbnumber ,
                                              AV60Supplier_agbwwds_7_tfsupplier_agbname_sel ,
                                              AV59Supplier_agbwwds_6_tfsupplier_agbname ,
                                              AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel ,
                                              AV61Supplier_agbwwds_8_tfsupplier_agbkvknumber ,
                                              AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel ,
                                              AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress ,
                                              AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel ,
                                              AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress ,
                                              AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel ,
                                              AV67Supplier_agbwwds_14_tfsupplier_agbemail ,
                                              AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel ,
                                              AV69Supplier_agbwwds_16_tfsupplier_agbphone ,
                                              AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel ,
                                              AV71Supplier_agbwwds_18_tfsupplier_agbcontactname ,
                                              A55Supplier_AgbId ,
                                              A56Supplier_AgbNumber ,
                                              A57Supplier_AgbName ,
                                              A58Supplier_AgbKvkNumber ,
                                              A59Supplier_AgbVisitingAddress ,
                                              A60Supplier_AgbPostalAddress ,
                                              A61Supplier_AgbEmail ,
                                              A62Supplier_AgbPhone ,
                                              A63Supplier_AgbContactName } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV57Supplier_agbwwds_4_tfsupplier_agbnumber = StringUtil.Concat( StringUtil.RTrim( AV57Supplier_agbwwds_4_tfsupplier_agbnumber), "%", "");
         lV59Supplier_agbwwds_6_tfsupplier_agbname = StringUtil.Concat( StringUtil.RTrim( AV59Supplier_agbwwds_6_tfsupplier_agbname), "%", "");
         lV61Supplier_agbwwds_8_tfsupplier_agbkvknumber = StringUtil.Concat( StringUtil.RTrim( AV61Supplier_agbwwds_8_tfsupplier_agbkvknumber), "%", "");
         lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress = StringUtil.Concat( StringUtil.RTrim( AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress), "%", "");
         lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress = StringUtil.Concat( StringUtil.RTrim( AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress), "%", "");
         lV67Supplier_agbwwds_14_tfsupplier_agbemail = StringUtil.Concat( StringUtil.RTrim( AV67Supplier_agbwwds_14_tfsupplier_agbemail), "%", "");
         lV69Supplier_agbwwds_16_tfsupplier_agbphone = StringUtil.PadR( StringUtil.RTrim( AV69Supplier_agbwwds_16_tfsupplier_agbphone), 20, "%");
         lV71Supplier_agbwwds_18_tfsupplier_agbcontactname = StringUtil.Concat( StringUtil.RTrim( AV71Supplier_agbwwds_18_tfsupplier_agbcontactname), "%", "");
         /* Using cursor P002F7 */
         pr_default.execute(5, new Object[] {lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, AV55Supplier_agbwwds_2_tfsupplier_agbid, AV56Supplier_agbwwds_3_tfsupplier_agbid_to, lV57Supplier_agbwwds_4_tfsupplier_agbnumber, AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel, lV59Supplier_agbwwds_6_tfsupplier_agbname, AV60Supplier_agbwwds_7_tfsupplier_agbname_sel, lV61Supplier_agbwwds_8_tfsupplier_agbkvknumber, AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel, lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress, AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress, AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel, lV67Supplier_agbwwds_14_tfsupplier_agbemail, AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel, lV69Supplier_agbwwds_16_tfsupplier_agbphone, AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel, lV71Supplier_agbwwds_18_tfsupplier_agbcontactname, AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel});
         while ( (pr_default.getStatus(5) != 101) )
         {
            BRK2F12 = false;
            A61Supplier_AgbEmail = P002F7_A61Supplier_AgbEmail[0];
            n61Supplier_AgbEmail = P002F7_n61Supplier_AgbEmail[0];
            A55Supplier_AgbId = P002F7_A55Supplier_AgbId[0];
            A63Supplier_AgbContactName = P002F7_A63Supplier_AgbContactName[0];
            n63Supplier_AgbContactName = P002F7_n63Supplier_AgbContactName[0];
            A62Supplier_AgbPhone = P002F7_A62Supplier_AgbPhone[0];
            n62Supplier_AgbPhone = P002F7_n62Supplier_AgbPhone[0];
            A60Supplier_AgbPostalAddress = P002F7_A60Supplier_AgbPostalAddress[0];
            n60Supplier_AgbPostalAddress = P002F7_n60Supplier_AgbPostalAddress[0];
            A59Supplier_AgbVisitingAddress = P002F7_A59Supplier_AgbVisitingAddress[0];
            n59Supplier_AgbVisitingAddress = P002F7_n59Supplier_AgbVisitingAddress[0];
            A58Supplier_AgbKvkNumber = P002F7_A58Supplier_AgbKvkNumber[0];
            A57Supplier_AgbName = P002F7_A57Supplier_AgbName[0];
            A56Supplier_AgbNumber = P002F7_A56Supplier_AgbNumber[0];
            AV39count = 0;
            while ( (pr_default.getStatus(5) != 101) && ( StringUtil.StrCmp(P002F7_A61Supplier_AgbEmail[0], A61Supplier_AgbEmail) == 0 ) )
            {
               BRK2F12 = false;
               A55Supplier_AgbId = P002F7_A55Supplier_AgbId[0];
               AV39count = (long)(AV39count+1);
               BRK2F12 = true;
               pr_default.readNext(5);
            }
            if ( (0==AV30SkipItems) )
            {
               AV34Option = (String.IsNullOrEmpty(StringUtil.RTrim( A61Supplier_AgbEmail)) ? "<#Empty#>" : A61Supplier_AgbEmail);
               AV35Options.Add(AV34Option, 0);
               AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV39count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV35Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV30SkipItems = (short)(AV30SkipItems-1);
            }
            if ( ! BRK2F12 )
            {
               BRK2F12 = true;
               pr_default.readNext(5);
            }
         }
         pr_default.close(5);
      }

      protected void S181( )
      {
         /* 'LOADSUPPLIER_AGBPHONEOPTIONS' Routine */
         returnInSub = false;
         AV25TFSupplier_AgbPhone = AV29SearchTxt;
         AV26TFSupplier_AgbPhone_Sel = "";
         AV54Supplier_agbwwds_1_filterfulltext = AV51FilterFullText;
         AV55Supplier_agbwwds_2_tfsupplier_agbid = AV11TFSupplier_AgbId;
         AV56Supplier_agbwwds_3_tfsupplier_agbid_to = AV12TFSupplier_AgbId_To;
         AV57Supplier_agbwwds_4_tfsupplier_agbnumber = AV13TFSupplier_AgbNumber;
         AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel = AV14TFSupplier_AgbNumber_Sel;
         AV59Supplier_agbwwds_6_tfsupplier_agbname = AV15TFSupplier_AgbName;
         AV60Supplier_agbwwds_7_tfsupplier_agbname_sel = AV16TFSupplier_AgbName_Sel;
         AV61Supplier_agbwwds_8_tfsupplier_agbkvknumber = AV17TFSupplier_AgbKvkNumber;
         AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel = AV18TFSupplier_AgbKvkNumber_Sel;
         AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress = AV19TFSupplier_AgbVisitingAddress;
         AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel = AV20TFSupplier_AgbVisitingAddress_Sel;
         AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress = AV21TFSupplier_AgbPostalAddress;
         AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel = AV22TFSupplier_AgbPostalAddress_Sel;
         AV67Supplier_agbwwds_14_tfsupplier_agbemail = AV23TFSupplier_AgbEmail;
         AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel = AV24TFSupplier_AgbEmail_Sel;
         AV69Supplier_agbwwds_16_tfsupplier_agbphone = AV25TFSupplier_AgbPhone;
         AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel = AV26TFSupplier_AgbPhone_Sel;
         AV71Supplier_agbwwds_18_tfsupplier_agbcontactname = AV27TFSupplier_AgbContactName;
         AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel = AV28TFSupplier_AgbContactName_Sel;
         pr_default.dynParam(6, new Object[]{ new Object[]{
                                              AV54Supplier_agbwwds_1_filterfulltext ,
                                              AV55Supplier_agbwwds_2_tfsupplier_agbid ,
                                              AV56Supplier_agbwwds_3_tfsupplier_agbid_to ,
                                              AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel ,
                                              AV57Supplier_agbwwds_4_tfsupplier_agbnumber ,
                                              AV60Supplier_agbwwds_7_tfsupplier_agbname_sel ,
                                              AV59Supplier_agbwwds_6_tfsupplier_agbname ,
                                              AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel ,
                                              AV61Supplier_agbwwds_8_tfsupplier_agbkvknumber ,
                                              AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel ,
                                              AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress ,
                                              AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel ,
                                              AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress ,
                                              AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel ,
                                              AV67Supplier_agbwwds_14_tfsupplier_agbemail ,
                                              AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel ,
                                              AV69Supplier_agbwwds_16_tfsupplier_agbphone ,
                                              AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel ,
                                              AV71Supplier_agbwwds_18_tfsupplier_agbcontactname ,
                                              A55Supplier_AgbId ,
                                              A56Supplier_AgbNumber ,
                                              A57Supplier_AgbName ,
                                              A58Supplier_AgbKvkNumber ,
                                              A59Supplier_AgbVisitingAddress ,
                                              A60Supplier_AgbPostalAddress ,
                                              A61Supplier_AgbEmail ,
                                              A62Supplier_AgbPhone ,
                                              A63Supplier_AgbContactName } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV57Supplier_agbwwds_4_tfsupplier_agbnumber = StringUtil.Concat( StringUtil.RTrim( AV57Supplier_agbwwds_4_tfsupplier_agbnumber), "%", "");
         lV59Supplier_agbwwds_6_tfsupplier_agbname = StringUtil.Concat( StringUtil.RTrim( AV59Supplier_agbwwds_6_tfsupplier_agbname), "%", "");
         lV61Supplier_agbwwds_8_tfsupplier_agbkvknumber = StringUtil.Concat( StringUtil.RTrim( AV61Supplier_agbwwds_8_tfsupplier_agbkvknumber), "%", "");
         lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress = StringUtil.Concat( StringUtil.RTrim( AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress), "%", "");
         lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress = StringUtil.Concat( StringUtil.RTrim( AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress), "%", "");
         lV67Supplier_agbwwds_14_tfsupplier_agbemail = StringUtil.Concat( StringUtil.RTrim( AV67Supplier_agbwwds_14_tfsupplier_agbemail), "%", "");
         lV69Supplier_agbwwds_16_tfsupplier_agbphone = StringUtil.PadR( StringUtil.RTrim( AV69Supplier_agbwwds_16_tfsupplier_agbphone), 20, "%");
         lV71Supplier_agbwwds_18_tfsupplier_agbcontactname = StringUtil.Concat( StringUtil.RTrim( AV71Supplier_agbwwds_18_tfsupplier_agbcontactname), "%", "");
         /* Using cursor P002F8 */
         pr_default.execute(6, new Object[] {lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, AV55Supplier_agbwwds_2_tfsupplier_agbid, AV56Supplier_agbwwds_3_tfsupplier_agbid_to, lV57Supplier_agbwwds_4_tfsupplier_agbnumber, AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel, lV59Supplier_agbwwds_6_tfsupplier_agbname, AV60Supplier_agbwwds_7_tfsupplier_agbname_sel, lV61Supplier_agbwwds_8_tfsupplier_agbkvknumber, AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel, lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress, AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress, AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel, lV67Supplier_agbwwds_14_tfsupplier_agbemail, AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel, lV69Supplier_agbwwds_16_tfsupplier_agbphone, AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel, lV71Supplier_agbwwds_18_tfsupplier_agbcontactname, AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel});
         while ( (pr_default.getStatus(6) != 101) )
         {
            BRK2F14 = false;
            A62Supplier_AgbPhone = P002F8_A62Supplier_AgbPhone[0];
            n62Supplier_AgbPhone = P002F8_n62Supplier_AgbPhone[0];
            A55Supplier_AgbId = P002F8_A55Supplier_AgbId[0];
            A63Supplier_AgbContactName = P002F8_A63Supplier_AgbContactName[0];
            n63Supplier_AgbContactName = P002F8_n63Supplier_AgbContactName[0];
            A61Supplier_AgbEmail = P002F8_A61Supplier_AgbEmail[0];
            n61Supplier_AgbEmail = P002F8_n61Supplier_AgbEmail[0];
            A60Supplier_AgbPostalAddress = P002F8_A60Supplier_AgbPostalAddress[0];
            n60Supplier_AgbPostalAddress = P002F8_n60Supplier_AgbPostalAddress[0];
            A59Supplier_AgbVisitingAddress = P002F8_A59Supplier_AgbVisitingAddress[0];
            n59Supplier_AgbVisitingAddress = P002F8_n59Supplier_AgbVisitingAddress[0];
            A58Supplier_AgbKvkNumber = P002F8_A58Supplier_AgbKvkNumber[0];
            A57Supplier_AgbName = P002F8_A57Supplier_AgbName[0];
            A56Supplier_AgbNumber = P002F8_A56Supplier_AgbNumber[0];
            AV39count = 0;
            while ( (pr_default.getStatus(6) != 101) && ( StringUtil.StrCmp(P002F8_A62Supplier_AgbPhone[0], A62Supplier_AgbPhone) == 0 ) )
            {
               BRK2F14 = false;
               A55Supplier_AgbId = P002F8_A55Supplier_AgbId[0];
               AV39count = (long)(AV39count+1);
               BRK2F14 = true;
               pr_default.readNext(6);
            }
            if ( (0==AV30SkipItems) )
            {
               AV34Option = (String.IsNullOrEmpty(StringUtil.RTrim( A62Supplier_AgbPhone)) ? "<#Empty#>" : A62Supplier_AgbPhone);
               AV35Options.Add(AV34Option, 0);
               AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV39count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV35Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV30SkipItems = (short)(AV30SkipItems-1);
            }
            if ( ! BRK2F14 )
            {
               BRK2F14 = true;
               pr_default.readNext(6);
            }
         }
         pr_default.close(6);
      }

      protected void S191( )
      {
         /* 'LOADSUPPLIER_AGBCONTACTNAMEOPTIONS' Routine */
         returnInSub = false;
         AV27TFSupplier_AgbContactName = AV29SearchTxt;
         AV28TFSupplier_AgbContactName_Sel = "";
         AV54Supplier_agbwwds_1_filterfulltext = AV51FilterFullText;
         AV55Supplier_agbwwds_2_tfsupplier_agbid = AV11TFSupplier_AgbId;
         AV56Supplier_agbwwds_3_tfsupplier_agbid_to = AV12TFSupplier_AgbId_To;
         AV57Supplier_agbwwds_4_tfsupplier_agbnumber = AV13TFSupplier_AgbNumber;
         AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel = AV14TFSupplier_AgbNumber_Sel;
         AV59Supplier_agbwwds_6_tfsupplier_agbname = AV15TFSupplier_AgbName;
         AV60Supplier_agbwwds_7_tfsupplier_agbname_sel = AV16TFSupplier_AgbName_Sel;
         AV61Supplier_agbwwds_8_tfsupplier_agbkvknumber = AV17TFSupplier_AgbKvkNumber;
         AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel = AV18TFSupplier_AgbKvkNumber_Sel;
         AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress = AV19TFSupplier_AgbVisitingAddress;
         AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel = AV20TFSupplier_AgbVisitingAddress_Sel;
         AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress = AV21TFSupplier_AgbPostalAddress;
         AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel = AV22TFSupplier_AgbPostalAddress_Sel;
         AV67Supplier_agbwwds_14_tfsupplier_agbemail = AV23TFSupplier_AgbEmail;
         AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel = AV24TFSupplier_AgbEmail_Sel;
         AV69Supplier_agbwwds_16_tfsupplier_agbphone = AV25TFSupplier_AgbPhone;
         AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel = AV26TFSupplier_AgbPhone_Sel;
         AV71Supplier_agbwwds_18_tfsupplier_agbcontactname = AV27TFSupplier_AgbContactName;
         AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel = AV28TFSupplier_AgbContactName_Sel;
         pr_default.dynParam(7, new Object[]{ new Object[]{
                                              AV54Supplier_agbwwds_1_filterfulltext ,
                                              AV55Supplier_agbwwds_2_tfsupplier_agbid ,
                                              AV56Supplier_agbwwds_3_tfsupplier_agbid_to ,
                                              AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel ,
                                              AV57Supplier_agbwwds_4_tfsupplier_agbnumber ,
                                              AV60Supplier_agbwwds_7_tfsupplier_agbname_sel ,
                                              AV59Supplier_agbwwds_6_tfsupplier_agbname ,
                                              AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel ,
                                              AV61Supplier_agbwwds_8_tfsupplier_agbkvknumber ,
                                              AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel ,
                                              AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress ,
                                              AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel ,
                                              AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress ,
                                              AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel ,
                                              AV67Supplier_agbwwds_14_tfsupplier_agbemail ,
                                              AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel ,
                                              AV69Supplier_agbwwds_16_tfsupplier_agbphone ,
                                              AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel ,
                                              AV71Supplier_agbwwds_18_tfsupplier_agbcontactname ,
                                              A55Supplier_AgbId ,
                                              A56Supplier_AgbNumber ,
                                              A57Supplier_AgbName ,
                                              A58Supplier_AgbKvkNumber ,
                                              A59Supplier_AgbVisitingAddress ,
                                              A60Supplier_AgbPostalAddress ,
                                              A61Supplier_AgbEmail ,
                                              A62Supplier_AgbPhone ,
                                              A63Supplier_AgbContactName } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV57Supplier_agbwwds_4_tfsupplier_agbnumber = StringUtil.Concat( StringUtil.RTrim( AV57Supplier_agbwwds_4_tfsupplier_agbnumber), "%", "");
         lV59Supplier_agbwwds_6_tfsupplier_agbname = StringUtil.Concat( StringUtil.RTrim( AV59Supplier_agbwwds_6_tfsupplier_agbname), "%", "");
         lV61Supplier_agbwwds_8_tfsupplier_agbkvknumber = StringUtil.Concat( StringUtil.RTrim( AV61Supplier_agbwwds_8_tfsupplier_agbkvknumber), "%", "");
         lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress = StringUtil.Concat( StringUtil.RTrim( AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress), "%", "");
         lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress = StringUtil.Concat( StringUtil.RTrim( AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress), "%", "");
         lV67Supplier_agbwwds_14_tfsupplier_agbemail = StringUtil.Concat( StringUtil.RTrim( AV67Supplier_agbwwds_14_tfsupplier_agbemail), "%", "");
         lV69Supplier_agbwwds_16_tfsupplier_agbphone = StringUtil.PadR( StringUtil.RTrim( AV69Supplier_agbwwds_16_tfsupplier_agbphone), 20, "%");
         lV71Supplier_agbwwds_18_tfsupplier_agbcontactname = StringUtil.Concat( StringUtil.RTrim( AV71Supplier_agbwwds_18_tfsupplier_agbcontactname), "%", "");
         /* Using cursor P002F9 */
         pr_default.execute(7, new Object[] {lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, AV55Supplier_agbwwds_2_tfsupplier_agbid, AV56Supplier_agbwwds_3_tfsupplier_agbid_to, lV57Supplier_agbwwds_4_tfsupplier_agbnumber, AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel, lV59Supplier_agbwwds_6_tfsupplier_agbname, AV60Supplier_agbwwds_7_tfsupplier_agbname_sel, lV61Supplier_agbwwds_8_tfsupplier_agbkvknumber, AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel, lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress, AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress, AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel, lV67Supplier_agbwwds_14_tfsupplier_agbemail, AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel, lV69Supplier_agbwwds_16_tfsupplier_agbphone, AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel, lV71Supplier_agbwwds_18_tfsupplier_agbcontactname, AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel});
         while ( (pr_default.getStatus(7) != 101) )
         {
            BRK2F16 = false;
            A63Supplier_AgbContactName = P002F9_A63Supplier_AgbContactName[0];
            n63Supplier_AgbContactName = P002F9_n63Supplier_AgbContactName[0];
            A55Supplier_AgbId = P002F9_A55Supplier_AgbId[0];
            A62Supplier_AgbPhone = P002F9_A62Supplier_AgbPhone[0];
            n62Supplier_AgbPhone = P002F9_n62Supplier_AgbPhone[0];
            A61Supplier_AgbEmail = P002F9_A61Supplier_AgbEmail[0];
            n61Supplier_AgbEmail = P002F9_n61Supplier_AgbEmail[0];
            A60Supplier_AgbPostalAddress = P002F9_A60Supplier_AgbPostalAddress[0];
            n60Supplier_AgbPostalAddress = P002F9_n60Supplier_AgbPostalAddress[0];
            A59Supplier_AgbVisitingAddress = P002F9_A59Supplier_AgbVisitingAddress[0];
            n59Supplier_AgbVisitingAddress = P002F9_n59Supplier_AgbVisitingAddress[0];
            A58Supplier_AgbKvkNumber = P002F9_A58Supplier_AgbKvkNumber[0];
            A57Supplier_AgbName = P002F9_A57Supplier_AgbName[0];
            A56Supplier_AgbNumber = P002F9_A56Supplier_AgbNumber[0];
            AV39count = 0;
            while ( (pr_default.getStatus(7) != 101) && ( StringUtil.StrCmp(P002F9_A63Supplier_AgbContactName[0], A63Supplier_AgbContactName) == 0 ) )
            {
               BRK2F16 = false;
               A55Supplier_AgbId = P002F9_A55Supplier_AgbId[0];
               AV39count = (long)(AV39count+1);
               BRK2F16 = true;
               pr_default.readNext(7);
            }
            if ( (0==AV30SkipItems) )
            {
               AV34Option = (String.IsNullOrEmpty(StringUtil.RTrim( A63Supplier_AgbContactName)) ? "<#Empty#>" : A63Supplier_AgbContactName);
               AV35Options.Add(AV34Option, 0);
               AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV39count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV35Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV30SkipItems = (short)(AV30SkipItems-1);
            }
            if ( ! BRK2F16 )
            {
               BRK2F16 = true;
               pr_default.readNext(7);
            }
         }
         pr_default.close(7);
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
         AV48OptionsJson = "";
         AV49OptionsDescJson = "";
         AV50OptionIndexesJson = "";
         AV35Options = new GxSimpleCollection<string>();
         AV37OptionsDesc = new GxSimpleCollection<string>();
         AV38OptionIndexes = new GxSimpleCollection<string>();
         AV29SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV40Session = context.GetSession();
         AV42GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV43GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV51FilterFullText = "";
         AV13TFSupplier_AgbNumber = "";
         AV14TFSupplier_AgbNumber_Sel = "";
         AV15TFSupplier_AgbName = "";
         AV16TFSupplier_AgbName_Sel = "";
         AV17TFSupplier_AgbKvkNumber = "";
         AV18TFSupplier_AgbKvkNumber_Sel = "";
         AV19TFSupplier_AgbVisitingAddress = "";
         AV20TFSupplier_AgbVisitingAddress_Sel = "";
         AV21TFSupplier_AgbPostalAddress = "";
         AV22TFSupplier_AgbPostalAddress_Sel = "";
         AV23TFSupplier_AgbEmail = "";
         AV24TFSupplier_AgbEmail_Sel = "";
         AV25TFSupplier_AgbPhone = "";
         AV26TFSupplier_AgbPhone_Sel = "";
         AV27TFSupplier_AgbContactName = "";
         AV28TFSupplier_AgbContactName_Sel = "";
         AV54Supplier_agbwwds_1_filterfulltext = "";
         AV57Supplier_agbwwds_4_tfsupplier_agbnumber = "";
         AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel = "";
         AV59Supplier_agbwwds_6_tfsupplier_agbname = "";
         AV60Supplier_agbwwds_7_tfsupplier_agbname_sel = "";
         AV61Supplier_agbwwds_8_tfsupplier_agbkvknumber = "";
         AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel = "";
         AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress = "";
         AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel = "";
         AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress = "";
         AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel = "";
         AV67Supplier_agbwwds_14_tfsupplier_agbemail = "";
         AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel = "";
         AV69Supplier_agbwwds_16_tfsupplier_agbphone = "";
         AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel = "";
         AV71Supplier_agbwwds_18_tfsupplier_agbcontactname = "";
         AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel = "";
         scmdbuf = "";
         lV54Supplier_agbwwds_1_filterfulltext = "";
         lV57Supplier_agbwwds_4_tfsupplier_agbnumber = "";
         lV59Supplier_agbwwds_6_tfsupplier_agbname = "";
         lV61Supplier_agbwwds_8_tfsupplier_agbkvknumber = "";
         lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress = "";
         lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress = "";
         lV67Supplier_agbwwds_14_tfsupplier_agbemail = "";
         lV69Supplier_agbwwds_16_tfsupplier_agbphone = "";
         lV71Supplier_agbwwds_18_tfsupplier_agbcontactname = "";
         A56Supplier_AgbNumber = "";
         A57Supplier_AgbName = "";
         A58Supplier_AgbKvkNumber = "";
         A59Supplier_AgbVisitingAddress = "";
         A60Supplier_AgbPostalAddress = "";
         A61Supplier_AgbEmail = "";
         A62Supplier_AgbPhone = "";
         A63Supplier_AgbContactName = "";
         P002F2_A56Supplier_AgbNumber = new string[] {""} ;
         P002F2_A55Supplier_AgbId = new short[1] ;
         P002F2_A63Supplier_AgbContactName = new string[] {""} ;
         P002F2_n63Supplier_AgbContactName = new bool[] {false} ;
         P002F2_A62Supplier_AgbPhone = new string[] {""} ;
         P002F2_n62Supplier_AgbPhone = new bool[] {false} ;
         P002F2_A61Supplier_AgbEmail = new string[] {""} ;
         P002F2_n61Supplier_AgbEmail = new bool[] {false} ;
         P002F2_A60Supplier_AgbPostalAddress = new string[] {""} ;
         P002F2_n60Supplier_AgbPostalAddress = new bool[] {false} ;
         P002F2_A59Supplier_AgbVisitingAddress = new string[] {""} ;
         P002F2_n59Supplier_AgbVisitingAddress = new bool[] {false} ;
         P002F2_A58Supplier_AgbKvkNumber = new string[] {""} ;
         P002F2_A57Supplier_AgbName = new string[] {""} ;
         AV34Option = "";
         P002F3_A57Supplier_AgbName = new string[] {""} ;
         P002F3_A55Supplier_AgbId = new short[1] ;
         P002F3_A63Supplier_AgbContactName = new string[] {""} ;
         P002F3_n63Supplier_AgbContactName = new bool[] {false} ;
         P002F3_A62Supplier_AgbPhone = new string[] {""} ;
         P002F3_n62Supplier_AgbPhone = new bool[] {false} ;
         P002F3_A61Supplier_AgbEmail = new string[] {""} ;
         P002F3_n61Supplier_AgbEmail = new bool[] {false} ;
         P002F3_A60Supplier_AgbPostalAddress = new string[] {""} ;
         P002F3_n60Supplier_AgbPostalAddress = new bool[] {false} ;
         P002F3_A59Supplier_AgbVisitingAddress = new string[] {""} ;
         P002F3_n59Supplier_AgbVisitingAddress = new bool[] {false} ;
         P002F3_A58Supplier_AgbKvkNumber = new string[] {""} ;
         P002F3_A56Supplier_AgbNumber = new string[] {""} ;
         P002F4_A58Supplier_AgbKvkNumber = new string[] {""} ;
         P002F4_A55Supplier_AgbId = new short[1] ;
         P002F4_A63Supplier_AgbContactName = new string[] {""} ;
         P002F4_n63Supplier_AgbContactName = new bool[] {false} ;
         P002F4_A62Supplier_AgbPhone = new string[] {""} ;
         P002F4_n62Supplier_AgbPhone = new bool[] {false} ;
         P002F4_A61Supplier_AgbEmail = new string[] {""} ;
         P002F4_n61Supplier_AgbEmail = new bool[] {false} ;
         P002F4_A60Supplier_AgbPostalAddress = new string[] {""} ;
         P002F4_n60Supplier_AgbPostalAddress = new bool[] {false} ;
         P002F4_A59Supplier_AgbVisitingAddress = new string[] {""} ;
         P002F4_n59Supplier_AgbVisitingAddress = new bool[] {false} ;
         P002F4_A57Supplier_AgbName = new string[] {""} ;
         P002F4_A56Supplier_AgbNumber = new string[] {""} ;
         P002F5_A59Supplier_AgbVisitingAddress = new string[] {""} ;
         P002F5_n59Supplier_AgbVisitingAddress = new bool[] {false} ;
         P002F5_A55Supplier_AgbId = new short[1] ;
         P002F5_A63Supplier_AgbContactName = new string[] {""} ;
         P002F5_n63Supplier_AgbContactName = new bool[] {false} ;
         P002F5_A62Supplier_AgbPhone = new string[] {""} ;
         P002F5_n62Supplier_AgbPhone = new bool[] {false} ;
         P002F5_A61Supplier_AgbEmail = new string[] {""} ;
         P002F5_n61Supplier_AgbEmail = new bool[] {false} ;
         P002F5_A60Supplier_AgbPostalAddress = new string[] {""} ;
         P002F5_n60Supplier_AgbPostalAddress = new bool[] {false} ;
         P002F5_A58Supplier_AgbKvkNumber = new string[] {""} ;
         P002F5_A57Supplier_AgbName = new string[] {""} ;
         P002F5_A56Supplier_AgbNumber = new string[] {""} ;
         P002F6_A60Supplier_AgbPostalAddress = new string[] {""} ;
         P002F6_n60Supplier_AgbPostalAddress = new bool[] {false} ;
         P002F6_A55Supplier_AgbId = new short[1] ;
         P002F6_A63Supplier_AgbContactName = new string[] {""} ;
         P002F6_n63Supplier_AgbContactName = new bool[] {false} ;
         P002F6_A62Supplier_AgbPhone = new string[] {""} ;
         P002F6_n62Supplier_AgbPhone = new bool[] {false} ;
         P002F6_A61Supplier_AgbEmail = new string[] {""} ;
         P002F6_n61Supplier_AgbEmail = new bool[] {false} ;
         P002F6_A59Supplier_AgbVisitingAddress = new string[] {""} ;
         P002F6_n59Supplier_AgbVisitingAddress = new bool[] {false} ;
         P002F6_A58Supplier_AgbKvkNumber = new string[] {""} ;
         P002F6_A57Supplier_AgbName = new string[] {""} ;
         P002F6_A56Supplier_AgbNumber = new string[] {""} ;
         P002F7_A61Supplier_AgbEmail = new string[] {""} ;
         P002F7_n61Supplier_AgbEmail = new bool[] {false} ;
         P002F7_A55Supplier_AgbId = new short[1] ;
         P002F7_A63Supplier_AgbContactName = new string[] {""} ;
         P002F7_n63Supplier_AgbContactName = new bool[] {false} ;
         P002F7_A62Supplier_AgbPhone = new string[] {""} ;
         P002F7_n62Supplier_AgbPhone = new bool[] {false} ;
         P002F7_A60Supplier_AgbPostalAddress = new string[] {""} ;
         P002F7_n60Supplier_AgbPostalAddress = new bool[] {false} ;
         P002F7_A59Supplier_AgbVisitingAddress = new string[] {""} ;
         P002F7_n59Supplier_AgbVisitingAddress = new bool[] {false} ;
         P002F7_A58Supplier_AgbKvkNumber = new string[] {""} ;
         P002F7_A57Supplier_AgbName = new string[] {""} ;
         P002F7_A56Supplier_AgbNumber = new string[] {""} ;
         P002F8_A62Supplier_AgbPhone = new string[] {""} ;
         P002F8_n62Supplier_AgbPhone = new bool[] {false} ;
         P002F8_A55Supplier_AgbId = new short[1] ;
         P002F8_A63Supplier_AgbContactName = new string[] {""} ;
         P002F8_n63Supplier_AgbContactName = new bool[] {false} ;
         P002F8_A61Supplier_AgbEmail = new string[] {""} ;
         P002F8_n61Supplier_AgbEmail = new bool[] {false} ;
         P002F8_A60Supplier_AgbPostalAddress = new string[] {""} ;
         P002F8_n60Supplier_AgbPostalAddress = new bool[] {false} ;
         P002F8_A59Supplier_AgbVisitingAddress = new string[] {""} ;
         P002F8_n59Supplier_AgbVisitingAddress = new bool[] {false} ;
         P002F8_A58Supplier_AgbKvkNumber = new string[] {""} ;
         P002F8_A57Supplier_AgbName = new string[] {""} ;
         P002F8_A56Supplier_AgbNumber = new string[] {""} ;
         P002F9_A63Supplier_AgbContactName = new string[] {""} ;
         P002F9_n63Supplier_AgbContactName = new bool[] {false} ;
         P002F9_A55Supplier_AgbId = new short[1] ;
         P002F9_A62Supplier_AgbPhone = new string[] {""} ;
         P002F9_n62Supplier_AgbPhone = new bool[] {false} ;
         P002F9_A61Supplier_AgbEmail = new string[] {""} ;
         P002F9_n61Supplier_AgbEmail = new bool[] {false} ;
         P002F9_A60Supplier_AgbPostalAddress = new string[] {""} ;
         P002F9_n60Supplier_AgbPostalAddress = new bool[] {false} ;
         P002F9_A59Supplier_AgbVisitingAddress = new string[] {""} ;
         P002F9_n59Supplier_AgbVisitingAddress = new bool[] {false} ;
         P002F9_A58Supplier_AgbKvkNumber = new string[] {""} ;
         P002F9_A57Supplier_AgbName = new string[] {""} ;
         P002F9_A56Supplier_AgbNumber = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.supplier_agbwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P002F2_A56Supplier_AgbNumber, P002F2_A55Supplier_AgbId, P002F2_A63Supplier_AgbContactName, P002F2_n63Supplier_AgbContactName, P002F2_A62Supplier_AgbPhone, P002F2_n62Supplier_AgbPhone, P002F2_A61Supplier_AgbEmail, P002F2_n61Supplier_AgbEmail, P002F2_A60Supplier_AgbPostalAddress, P002F2_n60Supplier_AgbPostalAddress,
               P002F2_A59Supplier_AgbVisitingAddress, P002F2_n59Supplier_AgbVisitingAddress, P002F2_A58Supplier_AgbKvkNumber, P002F2_A57Supplier_AgbName
               }
               , new Object[] {
               P002F3_A57Supplier_AgbName, P002F3_A55Supplier_AgbId, P002F3_A63Supplier_AgbContactName, P002F3_n63Supplier_AgbContactName, P002F3_A62Supplier_AgbPhone, P002F3_n62Supplier_AgbPhone, P002F3_A61Supplier_AgbEmail, P002F3_n61Supplier_AgbEmail, P002F3_A60Supplier_AgbPostalAddress, P002F3_n60Supplier_AgbPostalAddress,
               P002F3_A59Supplier_AgbVisitingAddress, P002F3_n59Supplier_AgbVisitingAddress, P002F3_A58Supplier_AgbKvkNumber, P002F3_A56Supplier_AgbNumber
               }
               , new Object[] {
               P002F4_A58Supplier_AgbKvkNumber, P002F4_A55Supplier_AgbId, P002F4_A63Supplier_AgbContactName, P002F4_n63Supplier_AgbContactName, P002F4_A62Supplier_AgbPhone, P002F4_n62Supplier_AgbPhone, P002F4_A61Supplier_AgbEmail, P002F4_n61Supplier_AgbEmail, P002F4_A60Supplier_AgbPostalAddress, P002F4_n60Supplier_AgbPostalAddress,
               P002F4_A59Supplier_AgbVisitingAddress, P002F4_n59Supplier_AgbVisitingAddress, P002F4_A57Supplier_AgbName, P002F4_A56Supplier_AgbNumber
               }
               , new Object[] {
               P002F5_A59Supplier_AgbVisitingAddress, P002F5_n59Supplier_AgbVisitingAddress, P002F5_A55Supplier_AgbId, P002F5_A63Supplier_AgbContactName, P002F5_n63Supplier_AgbContactName, P002F5_A62Supplier_AgbPhone, P002F5_n62Supplier_AgbPhone, P002F5_A61Supplier_AgbEmail, P002F5_n61Supplier_AgbEmail, P002F5_A60Supplier_AgbPostalAddress,
               P002F5_n60Supplier_AgbPostalAddress, P002F5_A58Supplier_AgbKvkNumber, P002F5_A57Supplier_AgbName, P002F5_A56Supplier_AgbNumber
               }
               , new Object[] {
               P002F6_A60Supplier_AgbPostalAddress, P002F6_n60Supplier_AgbPostalAddress, P002F6_A55Supplier_AgbId, P002F6_A63Supplier_AgbContactName, P002F6_n63Supplier_AgbContactName, P002F6_A62Supplier_AgbPhone, P002F6_n62Supplier_AgbPhone, P002F6_A61Supplier_AgbEmail, P002F6_n61Supplier_AgbEmail, P002F6_A59Supplier_AgbVisitingAddress,
               P002F6_n59Supplier_AgbVisitingAddress, P002F6_A58Supplier_AgbKvkNumber, P002F6_A57Supplier_AgbName, P002F6_A56Supplier_AgbNumber
               }
               , new Object[] {
               P002F7_A61Supplier_AgbEmail, P002F7_n61Supplier_AgbEmail, P002F7_A55Supplier_AgbId, P002F7_A63Supplier_AgbContactName, P002F7_n63Supplier_AgbContactName, P002F7_A62Supplier_AgbPhone, P002F7_n62Supplier_AgbPhone, P002F7_A60Supplier_AgbPostalAddress, P002F7_n60Supplier_AgbPostalAddress, P002F7_A59Supplier_AgbVisitingAddress,
               P002F7_n59Supplier_AgbVisitingAddress, P002F7_A58Supplier_AgbKvkNumber, P002F7_A57Supplier_AgbName, P002F7_A56Supplier_AgbNumber
               }
               , new Object[] {
               P002F8_A62Supplier_AgbPhone, P002F8_n62Supplier_AgbPhone, P002F8_A55Supplier_AgbId, P002F8_A63Supplier_AgbContactName, P002F8_n63Supplier_AgbContactName, P002F8_A61Supplier_AgbEmail, P002F8_n61Supplier_AgbEmail, P002F8_A60Supplier_AgbPostalAddress, P002F8_n60Supplier_AgbPostalAddress, P002F8_A59Supplier_AgbVisitingAddress,
               P002F8_n59Supplier_AgbVisitingAddress, P002F8_A58Supplier_AgbKvkNumber, P002F8_A57Supplier_AgbName, P002F8_A56Supplier_AgbNumber
               }
               , new Object[] {
               P002F9_A63Supplier_AgbContactName, P002F9_n63Supplier_AgbContactName, P002F9_A55Supplier_AgbId, P002F9_A62Supplier_AgbPhone, P002F9_n62Supplier_AgbPhone, P002F9_A61Supplier_AgbEmail, P002F9_n61Supplier_AgbEmail, P002F9_A60Supplier_AgbPostalAddress, P002F9_n60Supplier_AgbPostalAddress, P002F9_A59Supplier_AgbVisitingAddress,
               P002F9_n59Supplier_AgbVisitingAddress, P002F9_A58Supplier_AgbKvkNumber, P002F9_A57Supplier_AgbName, P002F9_A56Supplier_AgbNumber
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV32MaxItems ;
      private short AV31PageIndex ;
      private short AV30SkipItems ;
      private short AV11TFSupplier_AgbId ;
      private short AV12TFSupplier_AgbId_To ;
      private short AV55Supplier_agbwwds_2_tfsupplier_agbid ;
      private short AV56Supplier_agbwwds_3_tfsupplier_agbid_to ;
      private short A55Supplier_AgbId ;
      private int AV52GXV1 ;
      private long AV39count ;
      private string AV25TFSupplier_AgbPhone ;
      private string AV26TFSupplier_AgbPhone_Sel ;
      private string AV69Supplier_agbwwds_16_tfsupplier_agbphone ;
      private string AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel ;
      private string scmdbuf ;
      private string lV69Supplier_agbwwds_16_tfsupplier_agbphone ;
      private string A62Supplier_AgbPhone ;
      private bool returnInSub ;
      private bool BRK2F2 ;
      private bool n63Supplier_AgbContactName ;
      private bool n62Supplier_AgbPhone ;
      private bool n61Supplier_AgbEmail ;
      private bool n60Supplier_AgbPostalAddress ;
      private bool n59Supplier_AgbVisitingAddress ;
      private bool BRK2F4 ;
      private bool BRK2F6 ;
      private bool BRK2F8 ;
      private bool BRK2F10 ;
      private bool BRK2F12 ;
      private bool BRK2F14 ;
      private bool BRK2F16 ;
      private string AV48OptionsJson ;
      private string AV49OptionsDescJson ;
      private string AV50OptionIndexesJson ;
      private string AV45DDOName ;
      private string AV46SearchTxtParms ;
      private string AV47SearchTxtTo ;
      private string AV29SearchTxt ;
      private string AV51FilterFullText ;
      private string AV13TFSupplier_AgbNumber ;
      private string AV14TFSupplier_AgbNumber_Sel ;
      private string AV15TFSupplier_AgbName ;
      private string AV16TFSupplier_AgbName_Sel ;
      private string AV17TFSupplier_AgbKvkNumber ;
      private string AV18TFSupplier_AgbKvkNumber_Sel ;
      private string AV19TFSupplier_AgbVisitingAddress ;
      private string AV20TFSupplier_AgbVisitingAddress_Sel ;
      private string AV21TFSupplier_AgbPostalAddress ;
      private string AV22TFSupplier_AgbPostalAddress_Sel ;
      private string AV23TFSupplier_AgbEmail ;
      private string AV24TFSupplier_AgbEmail_Sel ;
      private string AV27TFSupplier_AgbContactName ;
      private string AV28TFSupplier_AgbContactName_Sel ;
      private string AV54Supplier_agbwwds_1_filterfulltext ;
      private string AV57Supplier_agbwwds_4_tfsupplier_agbnumber ;
      private string AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel ;
      private string AV59Supplier_agbwwds_6_tfsupplier_agbname ;
      private string AV60Supplier_agbwwds_7_tfsupplier_agbname_sel ;
      private string AV61Supplier_agbwwds_8_tfsupplier_agbkvknumber ;
      private string AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel ;
      private string AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress ;
      private string AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel ;
      private string AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress ;
      private string AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel ;
      private string AV67Supplier_agbwwds_14_tfsupplier_agbemail ;
      private string AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel ;
      private string AV71Supplier_agbwwds_18_tfsupplier_agbcontactname ;
      private string AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel ;
      private string lV54Supplier_agbwwds_1_filterfulltext ;
      private string lV57Supplier_agbwwds_4_tfsupplier_agbnumber ;
      private string lV59Supplier_agbwwds_6_tfsupplier_agbname ;
      private string lV61Supplier_agbwwds_8_tfsupplier_agbkvknumber ;
      private string lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress ;
      private string lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress ;
      private string lV67Supplier_agbwwds_14_tfsupplier_agbemail ;
      private string lV71Supplier_agbwwds_18_tfsupplier_agbcontactname ;
      private string A56Supplier_AgbNumber ;
      private string A57Supplier_AgbName ;
      private string A58Supplier_AgbKvkNumber ;
      private string A59Supplier_AgbVisitingAddress ;
      private string A60Supplier_AgbPostalAddress ;
      private string A61Supplier_AgbEmail ;
      private string A63Supplier_AgbContactName ;
      private string AV34Option ;
      private IGxSession AV40Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P002F2_A56Supplier_AgbNumber ;
      private short[] P002F2_A55Supplier_AgbId ;
      private string[] P002F2_A63Supplier_AgbContactName ;
      private bool[] P002F2_n63Supplier_AgbContactName ;
      private string[] P002F2_A62Supplier_AgbPhone ;
      private bool[] P002F2_n62Supplier_AgbPhone ;
      private string[] P002F2_A61Supplier_AgbEmail ;
      private bool[] P002F2_n61Supplier_AgbEmail ;
      private string[] P002F2_A60Supplier_AgbPostalAddress ;
      private bool[] P002F2_n60Supplier_AgbPostalAddress ;
      private string[] P002F2_A59Supplier_AgbVisitingAddress ;
      private bool[] P002F2_n59Supplier_AgbVisitingAddress ;
      private string[] P002F2_A58Supplier_AgbKvkNumber ;
      private string[] P002F2_A57Supplier_AgbName ;
      private string[] P002F3_A57Supplier_AgbName ;
      private short[] P002F3_A55Supplier_AgbId ;
      private string[] P002F3_A63Supplier_AgbContactName ;
      private bool[] P002F3_n63Supplier_AgbContactName ;
      private string[] P002F3_A62Supplier_AgbPhone ;
      private bool[] P002F3_n62Supplier_AgbPhone ;
      private string[] P002F3_A61Supplier_AgbEmail ;
      private bool[] P002F3_n61Supplier_AgbEmail ;
      private string[] P002F3_A60Supplier_AgbPostalAddress ;
      private bool[] P002F3_n60Supplier_AgbPostalAddress ;
      private string[] P002F3_A59Supplier_AgbVisitingAddress ;
      private bool[] P002F3_n59Supplier_AgbVisitingAddress ;
      private string[] P002F3_A58Supplier_AgbKvkNumber ;
      private string[] P002F3_A56Supplier_AgbNumber ;
      private string[] P002F4_A58Supplier_AgbKvkNumber ;
      private short[] P002F4_A55Supplier_AgbId ;
      private string[] P002F4_A63Supplier_AgbContactName ;
      private bool[] P002F4_n63Supplier_AgbContactName ;
      private string[] P002F4_A62Supplier_AgbPhone ;
      private bool[] P002F4_n62Supplier_AgbPhone ;
      private string[] P002F4_A61Supplier_AgbEmail ;
      private bool[] P002F4_n61Supplier_AgbEmail ;
      private string[] P002F4_A60Supplier_AgbPostalAddress ;
      private bool[] P002F4_n60Supplier_AgbPostalAddress ;
      private string[] P002F4_A59Supplier_AgbVisitingAddress ;
      private bool[] P002F4_n59Supplier_AgbVisitingAddress ;
      private string[] P002F4_A57Supplier_AgbName ;
      private string[] P002F4_A56Supplier_AgbNumber ;
      private string[] P002F5_A59Supplier_AgbVisitingAddress ;
      private bool[] P002F5_n59Supplier_AgbVisitingAddress ;
      private short[] P002F5_A55Supplier_AgbId ;
      private string[] P002F5_A63Supplier_AgbContactName ;
      private bool[] P002F5_n63Supplier_AgbContactName ;
      private string[] P002F5_A62Supplier_AgbPhone ;
      private bool[] P002F5_n62Supplier_AgbPhone ;
      private string[] P002F5_A61Supplier_AgbEmail ;
      private bool[] P002F5_n61Supplier_AgbEmail ;
      private string[] P002F5_A60Supplier_AgbPostalAddress ;
      private bool[] P002F5_n60Supplier_AgbPostalAddress ;
      private string[] P002F5_A58Supplier_AgbKvkNumber ;
      private string[] P002F5_A57Supplier_AgbName ;
      private string[] P002F5_A56Supplier_AgbNumber ;
      private string[] P002F6_A60Supplier_AgbPostalAddress ;
      private bool[] P002F6_n60Supplier_AgbPostalAddress ;
      private short[] P002F6_A55Supplier_AgbId ;
      private string[] P002F6_A63Supplier_AgbContactName ;
      private bool[] P002F6_n63Supplier_AgbContactName ;
      private string[] P002F6_A62Supplier_AgbPhone ;
      private bool[] P002F6_n62Supplier_AgbPhone ;
      private string[] P002F6_A61Supplier_AgbEmail ;
      private bool[] P002F6_n61Supplier_AgbEmail ;
      private string[] P002F6_A59Supplier_AgbVisitingAddress ;
      private bool[] P002F6_n59Supplier_AgbVisitingAddress ;
      private string[] P002F6_A58Supplier_AgbKvkNumber ;
      private string[] P002F6_A57Supplier_AgbName ;
      private string[] P002F6_A56Supplier_AgbNumber ;
      private string[] P002F7_A61Supplier_AgbEmail ;
      private bool[] P002F7_n61Supplier_AgbEmail ;
      private short[] P002F7_A55Supplier_AgbId ;
      private string[] P002F7_A63Supplier_AgbContactName ;
      private bool[] P002F7_n63Supplier_AgbContactName ;
      private string[] P002F7_A62Supplier_AgbPhone ;
      private bool[] P002F7_n62Supplier_AgbPhone ;
      private string[] P002F7_A60Supplier_AgbPostalAddress ;
      private bool[] P002F7_n60Supplier_AgbPostalAddress ;
      private string[] P002F7_A59Supplier_AgbVisitingAddress ;
      private bool[] P002F7_n59Supplier_AgbVisitingAddress ;
      private string[] P002F7_A58Supplier_AgbKvkNumber ;
      private string[] P002F7_A57Supplier_AgbName ;
      private string[] P002F7_A56Supplier_AgbNumber ;
      private string[] P002F8_A62Supplier_AgbPhone ;
      private bool[] P002F8_n62Supplier_AgbPhone ;
      private short[] P002F8_A55Supplier_AgbId ;
      private string[] P002F8_A63Supplier_AgbContactName ;
      private bool[] P002F8_n63Supplier_AgbContactName ;
      private string[] P002F8_A61Supplier_AgbEmail ;
      private bool[] P002F8_n61Supplier_AgbEmail ;
      private string[] P002F8_A60Supplier_AgbPostalAddress ;
      private bool[] P002F8_n60Supplier_AgbPostalAddress ;
      private string[] P002F8_A59Supplier_AgbVisitingAddress ;
      private bool[] P002F8_n59Supplier_AgbVisitingAddress ;
      private string[] P002F8_A58Supplier_AgbKvkNumber ;
      private string[] P002F8_A57Supplier_AgbName ;
      private string[] P002F8_A56Supplier_AgbNumber ;
      private string[] P002F9_A63Supplier_AgbContactName ;
      private bool[] P002F9_n63Supplier_AgbContactName ;
      private short[] P002F9_A55Supplier_AgbId ;
      private string[] P002F9_A62Supplier_AgbPhone ;
      private bool[] P002F9_n62Supplier_AgbPhone ;
      private string[] P002F9_A61Supplier_AgbEmail ;
      private bool[] P002F9_n61Supplier_AgbEmail ;
      private string[] P002F9_A60Supplier_AgbPostalAddress ;
      private bool[] P002F9_n60Supplier_AgbPostalAddress ;
      private string[] P002F9_A59Supplier_AgbVisitingAddress ;
      private bool[] P002F9_n59Supplier_AgbVisitingAddress ;
      private string[] P002F9_A58Supplier_AgbKvkNumber ;
      private string[] P002F9_A57Supplier_AgbName ;
      private string[] P002F9_A56Supplier_AgbNumber ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV35Options ;
      private GxSimpleCollection<string> AV37OptionsDesc ;
      private GxSimpleCollection<string> AV38OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV42GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV43GridStateFilterValue ;
   }

   public class supplier_agbwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002F2( IGxContext context ,
                                             string AV54Supplier_agbwwds_1_filterfulltext ,
                                             short AV55Supplier_agbwwds_2_tfsupplier_agbid ,
                                             short AV56Supplier_agbwwds_3_tfsupplier_agbid_to ,
                                             string AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel ,
                                             string AV57Supplier_agbwwds_4_tfsupplier_agbnumber ,
                                             string AV60Supplier_agbwwds_7_tfsupplier_agbname_sel ,
                                             string AV59Supplier_agbwwds_6_tfsupplier_agbname ,
                                             string AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel ,
                                             string AV61Supplier_agbwwds_8_tfsupplier_agbkvknumber ,
                                             string AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel ,
                                             string AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress ,
                                             string AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel ,
                                             string AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress ,
                                             string AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel ,
                                             string AV67Supplier_agbwwds_14_tfsupplier_agbemail ,
                                             string AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel ,
                                             string AV69Supplier_agbwwds_16_tfsupplier_agbphone ,
                                             string AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel ,
                                             string AV71Supplier_agbwwds_18_tfsupplier_agbcontactname ,
                                             short A55Supplier_AgbId ,
                                             string A56Supplier_AgbNumber ,
                                             string A57Supplier_AgbName ,
                                             string A58Supplier_AgbKvkNumber ,
                                             string A59Supplier_AgbVisitingAddress ,
                                             string A60Supplier_AgbPostalAddress ,
                                             string A61Supplier_AgbEmail ,
                                             string A62Supplier_AgbPhone ,
                                             string A63Supplier_AgbContactName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[27];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT Supplier_AgbNumber, Supplier_AgbId, Supplier_AgbContactName, Supplier_AgbPhone, Supplier_AgbEmail, Supplier_AgbPostalAddress, Supplier_AgbVisitingAddress, Supplier_AgbKvkNumber, Supplier_AgbName FROM Supplier_AGB";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(Supplier_AgbId,'9999'), 2) like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbNumber like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbName like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbKvkNumber like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbVisitingAddress like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbPostalAddress like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbEmail like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbPhone like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbContactName like '%' || :lV54Supplier_agbwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
            GXv_int1[5] = 1;
            GXv_int1[6] = 1;
            GXv_int1[7] = 1;
            GXv_int1[8] = 1;
         }
         if ( ! (0==AV55Supplier_agbwwds_2_tfsupplier_agbid) )
         {
            AddWhere(sWhereString, "(Supplier_AgbId >= :AV55Supplier_agbwwds_2_tfsupplier_agbid)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! (0==AV56Supplier_agbwwds_3_tfsupplier_agbid_to) )
         {
            AddWhere(sWhereString, "(Supplier_AgbId <= :AV56Supplier_agbwwds_3_tfsupplier_agbid_to)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Supplier_agbwwds_4_tfsupplier_agbnumber)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbNumber like :lV57Supplier_agbwwds_4_tfsupplier_agbnumber)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel)) && ! ( StringUtil.StrCmp(AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbNumber = ( :AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel))");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( StringUtil.StrCmp(AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Supplier_AgbNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Supplier_agbwwds_7_tfsupplier_agbname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Supplier_agbwwds_6_tfsupplier_agbname)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbName like :lV59Supplier_agbwwds_6_tfsupplier_agbname)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Supplier_agbwwds_7_tfsupplier_agbname_sel)) && ! ( StringUtil.StrCmp(AV60Supplier_agbwwds_7_tfsupplier_agbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbName = ( :AV60Supplier_agbwwds_7_tfsupplier_agbname_sel))");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( StringUtil.StrCmp(AV60Supplier_agbwwds_7_tfsupplier_agbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Supplier_AgbName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Supplier_agbwwds_8_tfsupplier_agbkvknumber)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbKvkNumber like :lV61Supplier_agbwwds_8_tfsupplier_agbkvknumber)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel)) && ! ( StringUtil.StrCmp(AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbKvkNumber = ( :AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel))");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( StringUtil.StrCmp(AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Supplier_AgbKvkNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress like :lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel)) && ! ( StringUtil.StrCmp(AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress = ( :AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel))");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( StringUtil.StrCmp(AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbVisitingAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress like :lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel)) && ! ( StringUtil.StrCmp(AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress = ( :AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel))");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( StringUtil.StrCmp(AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbPostalAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Supplier_agbwwds_14_tfsupplier_agbemail)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail like :lV67Supplier_agbwwds_14_tfsupplier_agbemail)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel)) && ! ( StringUtil.StrCmp(AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail = ( :AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel))");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( StringUtil.StrCmp(AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Supplier_agbwwds_16_tfsupplier_agbphone)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone like :lV69Supplier_agbwwds_16_tfsupplier_agbphone)");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel)) && ! ( StringUtil.StrCmp(AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone = ( :AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel))");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( StringUtil.StrCmp(AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Supplier_agbwwds_18_tfsupplier_agbcontactname)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName like :lV71Supplier_agbwwds_18_tfsupplier_agbcontactname)");
         }
         else
         {
            GXv_int1[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel)) && ! ( StringUtil.StrCmp(AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName = ( :AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel))");
         }
         else
         {
            GXv_int1[26] = 1;
         }
         if ( StringUtil.StrCmp(AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbContactName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY Supplier_AgbNumber";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P002F3( IGxContext context ,
                                             string AV54Supplier_agbwwds_1_filterfulltext ,
                                             short AV55Supplier_agbwwds_2_tfsupplier_agbid ,
                                             short AV56Supplier_agbwwds_3_tfsupplier_agbid_to ,
                                             string AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel ,
                                             string AV57Supplier_agbwwds_4_tfsupplier_agbnumber ,
                                             string AV60Supplier_agbwwds_7_tfsupplier_agbname_sel ,
                                             string AV59Supplier_agbwwds_6_tfsupplier_agbname ,
                                             string AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel ,
                                             string AV61Supplier_agbwwds_8_tfsupplier_agbkvknumber ,
                                             string AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel ,
                                             string AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress ,
                                             string AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel ,
                                             string AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress ,
                                             string AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel ,
                                             string AV67Supplier_agbwwds_14_tfsupplier_agbemail ,
                                             string AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel ,
                                             string AV69Supplier_agbwwds_16_tfsupplier_agbphone ,
                                             string AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel ,
                                             string AV71Supplier_agbwwds_18_tfsupplier_agbcontactname ,
                                             short A55Supplier_AgbId ,
                                             string A56Supplier_AgbNumber ,
                                             string A57Supplier_AgbName ,
                                             string A58Supplier_AgbKvkNumber ,
                                             string A59Supplier_AgbVisitingAddress ,
                                             string A60Supplier_AgbPostalAddress ,
                                             string A61Supplier_AgbEmail ,
                                             string A62Supplier_AgbPhone ,
                                             string A63Supplier_AgbContactName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[27];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT Supplier_AgbName, Supplier_AgbId, Supplier_AgbContactName, Supplier_AgbPhone, Supplier_AgbEmail, Supplier_AgbPostalAddress, Supplier_AgbVisitingAddress, Supplier_AgbKvkNumber, Supplier_AgbNumber FROM Supplier_AGB";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(Supplier_AgbId,'9999'), 2) like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbNumber like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbName like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbKvkNumber like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbVisitingAddress like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbPostalAddress like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbEmail like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbPhone like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbContactName like '%' || :lV54Supplier_agbwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
            GXv_int3[5] = 1;
            GXv_int3[6] = 1;
            GXv_int3[7] = 1;
            GXv_int3[8] = 1;
         }
         if ( ! (0==AV55Supplier_agbwwds_2_tfsupplier_agbid) )
         {
            AddWhere(sWhereString, "(Supplier_AgbId >= :AV55Supplier_agbwwds_2_tfsupplier_agbid)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! (0==AV56Supplier_agbwwds_3_tfsupplier_agbid_to) )
         {
            AddWhere(sWhereString, "(Supplier_AgbId <= :AV56Supplier_agbwwds_3_tfsupplier_agbid_to)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Supplier_agbwwds_4_tfsupplier_agbnumber)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbNumber like :lV57Supplier_agbwwds_4_tfsupplier_agbnumber)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel)) && ! ( StringUtil.StrCmp(AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbNumber = ( :AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel))");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( StringUtil.StrCmp(AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Supplier_AgbNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Supplier_agbwwds_7_tfsupplier_agbname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Supplier_agbwwds_6_tfsupplier_agbname)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbName like :lV59Supplier_agbwwds_6_tfsupplier_agbname)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Supplier_agbwwds_7_tfsupplier_agbname_sel)) && ! ( StringUtil.StrCmp(AV60Supplier_agbwwds_7_tfsupplier_agbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbName = ( :AV60Supplier_agbwwds_7_tfsupplier_agbname_sel))");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( StringUtil.StrCmp(AV60Supplier_agbwwds_7_tfsupplier_agbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Supplier_AgbName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Supplier_agbwwds_8_tfsupplier_agbkvknumber)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbKvkNumber like :lV61Supplier_agbwwds_8_tfsupplier_agbkvknumber)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel)) && ! ( StringUtil.StrCmp(AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbKvkNumber = ( :AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel))");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( StringUtil.StrCmp(AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Supplier_AgbKvkNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress like :lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel)) && ! ( StringUtil.StrCmp(AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress = ( :AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel))");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( StringUtil.StrCmp(AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbVisitingAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress like :lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel)) && ! ( StringUtil.StrCmp(AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress = ( :AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel))");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( StringUtil.StrCmp(AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbPostalAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Supplier_agbwwds_14_tfsupplier_agbemail)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail like :lV67Supplier_agbwwds_14_tfsupplier_agbemail)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel)) && ! ( StringUtil.StrCmp(AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail = ( :AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel))");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( StringUtil.StrCmp(AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Supplier_agbwwds_16_tfsupplier_agbphone)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone like :lV69Supplier_agbwwds_16_tfsupplier_agbphone)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel)) && ! ( StringUtil.StrCmp(AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone = ( :AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel))");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( StringUtil.StrCmp(AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Supplier_agbwwds_18_tfsupplier_agbcontactname)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName like :lV71Supplier_agbwwds_18_tfsupplier_agbcontactname)");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel)) && ! ( StringUtil.StrCmp(AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName = ( :AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel))");
         }
         else
         {
            GXv_int3[26] = 1;
         }
         if ( StringUtil.StrCmp(AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbContactName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY Supplier_AgbName";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P002F4( IGxContext context ,
                                             string AV54Supplier_agbwwds_1_filterfulltext ,
                                             short AV55Supplier_agbwwds_2_tfsupplier_agbid ,
                                             short AV56Supplier_agbwwds_3_tfsupplier_agbid_to ,
                                             string AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel ,
                                             string AV57Supplier_agbwwds_4_tfsupplier_agbnumber ,
                                             string AV60Supplier_agbwwds_7_tfsupplier_agbname_sel ,
                                             string AV59Supplier_agbwwds_6_tfsupplier_agbname ,
                                             string AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel ,
                                             string AV61Supplier_agbwwds_8_tfsupplier_agbkvknumber ,
                                             string AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel ,
                                             string AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress ,
                                             string AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel ,
                                             string AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress ,
                                             string AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel ,
                                             string AV67Supplier_agbwwds_14_tfsupplier_agbemail ,
                                             string AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel ,
                                             string AV69Supplier_agbwwds_16_tfsupplier_agbphone ,
                                             string AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel ,
                                             string AV71Supplier_agbwwds_18_tfsupplier_agbcontactname ,
                                             short A55Supplier_AgbId ,
                                             string A56Supplier_AgbNumber ,
                                             string A57Supplier_AgbName ,
                                             string A58Supplier_AgbKvkNumber ,
                                             string A59Supplier_AgbVisitingAddress ,
                                             string A60Supplier_AgbPostalAddress ,
                                             string A61Supplier_AgbEmail ,
                                             string A62Supplier_AgbPhone ,
                                             string A63Supplier_AgbContactName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[27];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT Supplier_AgbKvkNumber, Supplier_AgbId, Supplier_AgbContactName, Supplier_AgbPhone, Supplier_AgbEmail, Supplier_AgbPostalAddress, Supplier_AgbVisitingAddress, Supplier_AgbName, Supplier_AgbNumber FROM Supplier_AGB";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(Supplier_AgbId,'9999'), 2) like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbNumber like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbName like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbKvkNumber like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbVisitingAddress like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbPostalAddress like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbEmail like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbPhone like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbContactName like '%' || :lV54Supplier_agbwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
            GXv_int5[5] = 1;
            GXv_int5[6] = 1;
            GXv_int5[7] = 1;
            GXv_int5[8] = 1;
         }
         if ( ! (0==AV55Supplier_agbwwds_2_tfsupplier_agbid) )
         {
            AddWhere(sWhereString, "(Supplier_AgbId >= :AV55Supplier_agbwwds_2_tfsupplier_agbid)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! (0==AV56Supplier_agbwwds_3_tfsupplier_agbid_to) )
         {
            AddWhere(sWhereString, "(Supplier_AgbId <= :AV56Supplier_agbwwds_3_tfsupplier_agbid_to)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Supplier_agbwwds_4_tfsupplier_agbnumber)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbNumber like :lV57Supplier_agbwwds_4_tfsupplier_agbnumber)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel)) && ! ( StringUtil.StrCmp(AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbNumber = ( :AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel))");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( StringUtil.StrCmp(AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Supplier_AgbNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Supplier_agbwwds_7_tfsupplier_agbname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Supplier_agbwwds_6_tfsupplier_agbname)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbName like :lV59Supplier_agbwwds_6_tfsupplier_agbname)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Supplier_agbwwds_7_tfsupplier_agbname_sel)) && ! ( StringUtil.StrCmp(AV60Supplier_agbwwds_7_tfsupplier_agbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbName = ( :AV60Supplier_agbwwds_7_tfsupplier_agbname_sel))");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( StringUtil.StrCmp(AV60Supplier_agbwwds_7_tfsupplier_agbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Supplier_AgbName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Supplier_agbwwds_8_tfsupplier_agbkvknumber)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbKvkNumber like :lV61Supplier_agbwwds_8_tfsupplier_agbkvknumber)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel)) && ! ( StringUtil.StrCmp(AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbKvkNumber = ( :AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel))");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( StringUtil.StrCmp(AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Supplier_AgbKvkNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress like :lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel)) && ! ( StringUtil.StrCmp(AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress = ( :AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel))");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( StringUtil.StrCmp(AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbVisitingAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress like :lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel)) && ! ( StringUtil.StrCmp(AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress = ( :AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel))");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( StringUtil.StrCmp(AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbPostalAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Supplier_agbwwds_14_tfsupplier_agbemail)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail like :lV67Supplier_agbwwds_14_tfsupplier_agbemail)");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel)) && ! ( StringUtil.StrCmp(AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail = ( :AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel))");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( StringUtil.StrCmp(AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Supplier_agbwwds_16_tfsupplier_agbphone)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone like :lV69Supplier_agbwwds_16_tfsupplier_agbphone)");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel)) && ! ( StringUtil.StrCmp(AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone = ( :AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel))");
         }
         else
         {
            GXv_int5[24] = 1;
         }
         if ( StringUtil.StrCmp(AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Supplier_agbwwds_18_tfsupplier_agbcontactname)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName like :lV71Supplier_agbwwds_18_tfsupplier_agbcontactname)");
         }
         else
         {
            GXv_int5[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel)) && ! ( StringUtil.StrCmp(AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName = ( :AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel))");
         }
         else
         {
            GXv_int5[26] = 1;
         }
         if ( StringUtil.StrCmp(AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbContactName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY Supplier_AgbKvkNumber";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P002F5( IGxContext context ,
                                             string AV54Supplier_agbwwds_1_filterfulltext ,
                                             short AV55Supplier_agbwwds_2_tfsupplier_agbid ,
                                             short AV56Supplier_agbwwds_3_tfsupplier_agbid_to ,
                                             string AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel ,
                                             string AV57Supplier_agbwwds_4_tfsupplier_agbnumber ,
                                             string AV60Supplier_agbwwds_7_tfsupplier_agbname_sel ,
                                             string AV59Supplier_agbwwds_6_tfsupplier_agbname ,
                                             string AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel ,
                                             string AV61Supplier_agbwwds_8_tfsupplier_agbkvknumber ,
                                             string AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel ,
                                             string AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress ,
                                             string AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel ,
                                             string AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress ,
                                             string AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel ,
                                             string AV67Supplier_agbwwds_14_tfsupplier_agbemail ,
                                             string AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel ,
                                             string AV69Supplier_agbwwds_16_tfsupplier_agbphone ,
                                             string AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel ,
                                             string AV71Supplier_agbwwds_18_tfsupplier_agbcontactname ,
                                             short A55Supplier_AgbId ,
                                             string A56Supplier_AgbNumber ,
                                             string A57Supplier_AgbName ,
                                             string A58Supplier_AgbKvkNumber ,
                                             string A59Supplier_AgbVisitingAddress ,
                                             string A60Supplier_AgbPostalAddress ,
                                             string A61Supplier_AgbEmail ,
                                             string A62Supplier_AgbPhone ,
                                             string A63Supplier_AgbContactName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[27];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT Supplier_AgbVisitingAddress, Supplier_AgbId, Supplier_AgbContactName, Supplier_AgbPhone, Supplier_AgbEmail, Supplier_AgbPostalAddress, Supplier_AgbKvkNumber, Supplier_AgbName, Supplier_AgbNumber FROM Supplier_AGB";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(Supplier_AgbId,'9999'), 2) like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbNumber like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbName like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbKvkNumber like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbVisitingAddress like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbPostalAddress like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbEmail like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbPhone like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbContactName like '%' || :lV54Supplier_agbwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int7[0] = 1;
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
            GXv_int7[4] = 1;
            GXv_int7[5] = 1;
            GXv_int7[6] = 1;
            GXv_int7[7] = 1;
            GXv_int7[8] = 1;
         }
         if ( ! (0==AV55Supplier_agbwwds_2_tfsupplier_agbid) )
         {
            AddWhere(sWhereString, "(Supplier_AgbId >= :AV55Supplier_agbwwds_2_tfsupplier_agbid)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( ! (0==AV56Supplier_agbwwds_3_tfsupplier_agbid_to) )
         {
            AddWhere(sWhereString, "(Supplier_AgbId <= :AV56Supplier_agbwwds_3_tfsupplier_agbid_to)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Supplier_agbwwds_4_tfsupplier_agbnumber)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbNumber like :lV57Supplier_agbwwds_4_tfsupplier_agbnumber)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel)) && ! ( StringUtil.StrCmp(AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbNumber = ( :AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel))");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( StringUtil.StrCmp(AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Supplier_AgbNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Supplier_agbwwds_7_tfsupplier_agbname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Supplier_agbwwds_6_tfsupplier_agbname)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbName like :lV59Supplier_agbwwds_6_tfsupplier_agbname)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Supplier_agbwwds_7_tfsupplier_agbname_sel)) && ! ( StringUtil.StrCmp(AV60Supplier_agbwwds_7_tfsupplier_agbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbName = ( :AV60Supplier_agbwwds_7_tfsupplier_agbname_sel))");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( StringUtil.StrCmp(AV60Supplier_agbwwds_7_tfsupplier_agbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Supplier_AgbName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Supplier_agbwwds_8_tfsupplier_agbkvknumber)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbKvkNumber like :lV61Supplier_agbwwds_8_tfsupplier_agbkvknumber)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel)) && ! ( StringUtil.StrCmp(AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbKvkNumber = ( :AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel))");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( StringUtil.StrCmp(AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Supplier_AgbKvkNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress like :lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel)) && ! ( StringUtil.StrCmp(AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress = ( :AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel))");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( StringUtil.StrCmp(AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbVisitingAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress like :lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress)");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel)) && ! ( StringUtil.StrCmp(AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress = ( :AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel))");
         }
         else
         {
            GXv_int7[20] = 1;
         }
         if ( StringUtil.StrCmp(AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbPostalAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Supplier_agbwwds_14_tfsupplier_agbemail)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail like :lV67Supplier_agbwwds_14_tfsupplier_agbemail)");
         }
         else
         {
            GXv_int7[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel)) && ! ( StringUtil.StrCmp(AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail = ( :AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel))");
         }
         else
         {
            GXv_int7[22] = 1;
         }
         if ( StringUtil.StrCmp(AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Supplier_agbwwds_16_tfsupplier_agbphone)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone like :lV69Supplier_agbwwds_16_tfsupplier_agbphone)");
         }
         else
         {
            GXv_int7[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel)) && ! ( StringUtil.StrCmp(AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone = ( :AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel))");
         }
         else
         {
            GXv_int7[24] = 1;
         }
         if ( StringUtil.StrCmp(AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Supplier_agbwwds_18_tfsupplier_agbcontactname)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName like :lV71Supplier_agbwwds_18_tfsupplier_agbcontactname)");
         }
         else
         {
            GXv_int7[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel)) && ! ( StringUtil.StrCmp(AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName = ( :AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel))");
         }
         else
         {
            GXv_int7[26] = 1;
         }
         if ( StringUtil.StrCmp(AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbContactName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY Supplier_AgbVisitingAddress";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P002F6( IGxContext context ,
                                             string AV54Supplier_agbwwds_1_filterfulltext ,
                                             short AV55Supplier_agbwwds_2_tfsupplier_agbid ,
                                             short AV56Supplier_agbwwds_3_tfsupplier_agbid_to ,
                                             string AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel ,
                                             string AV57Supplier_agbwwds_4_tfsupplier_agbnumber ,
                                             string AV60Supplier_agbwwds_7_tfsupplier_agbname_sel ,
                                             string AV59Supplier_agbwwds_6_tfsupplier_agbname ,
                                             string AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel ,
                                             string AV61Supplier_agbwwds_8_tfsupplier_agbkvknumber ,
                                             string AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel ,
                                             string AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress ,
                                             string AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel ,
                                             string AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress ,
                                             string AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel ,
                                             string AV67Supplier_agbwwds_14_tfsupplier_agbemail ,
                                             string AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel ,
                                             string AV69Supplier_agbwwds_16_tfsupplier_agbphone ,
                                             string AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel ,
                                             string AV71Supplier_agbwwds_18_tfsupplier_agbcontactname ,
                                             short A55Supplier_AgbId ,
                                             string A56Supplier_AgbNumber ,
                                             string A57Supplier_AgbName ,
                                             string A58Supplier_AgbKvkNumber ,
                                             string A59Supplier_AgbVisitingAddress ,
                                             string A60Supplier_AgbPostalAddress ,
                                             string A61Supplier_AgbEmail ,
                                             string A62Supplier_AgbPhone ,
                                             string A63Supplier_AgbContactName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[27];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT Supplier_AgbPostalAddress, Supplier_AgbId, Supplier_AgbContactName, Supplier_AgbPhone, Supplier_AgbEmail, Supplier_AgbVisitingAddress, Supplier_AgbKvkNumber, Supplier_AgbName, Supplier_AgbNumber FROM Supplier_AGB";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(Supplier_AgbId,'9999'), 2) like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbNumber like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbName like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbKvkNumber like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbVisitingAddress like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbPostalAddress like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbEmail like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbPhone like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbContactName like '%' || :lV54Supplier_agbwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int9[0] = 1;
            GXv_int9[1] = 1;
            GXv_int9[2] = 1;
            GXv_int9[3] = 1;
            GXv_int9[4] = 1;
            GXv_int9[5] = 1;
            GXv_int9[6] = 1;
            GXv_int9[7] = 1;
            GXv_int9[8] = 1;
         }
         if ( ! (0==AV55Supplier_agbwwds_2_tfsupplier_agbid) )
         {
            AddWhere(sWhereString, "(Supplier_AgbId >= :AV55Supplier_agbwwds_2_tfsupplier_agbid)");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( ! (0==AV56Supplier_agbwwds_3_tfsupplier_agbid_to) )
         {
            AddWhere(sWhereString, "(Supplier_AgbId <= :AV56Supplier_agbwwds_3_tfsupplier_agbid_to)");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Supplier_agbwwds_4_tfsupplier_agbnumber)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbNumber like :lV57Supplier_agbwwds_4_tfsupplier_agbnumber)");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel)) && ! ( StringUtil.StrCmp(AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbNumber = ( :AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel))");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( StringUtil.StrCmp(AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Supplier_AgbNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Supplier_agbwwds_7_tfsupplier_agbname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Supplier_agbwwds_6_tfsupplier_agbname)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbName like :lV59Supplier_agbwwds_6_tfsupplier_agbname)");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Supplier_agbwwds_7_tfsupplier_agbname_sel)) && ! ( StringUtil.StrCmp(AV60Supplier_agbwwds_7_tfsupplier_agbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbName = ( :AV60Supplier_agbwwds_7_tfsupplier_agbname_sel))");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( StringUtil.StrCmp(AV60Supplier_agbwwds_7_tfsupplier_agbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Supplier_AgbName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Supplier_agbwwds_8_tfsupplier_agbkvknumber)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbKvkNumber like :lV61Supplier_agbwwds_8_tfsupplier_agbkvknumber)");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel)) && ! ( StringUtil.StrCmp(AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbKvkNumber = ( :AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel))");
         }
         else
         {
            GXv_int9[16] = 1;
         }
         if ( StringUtil.StrCmp(AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Supplier_AgbKvkNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress like :lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress)");
         }
         else
         {
            GXv_int9[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel)) && ! ( StringUtil.StrCmp(AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress = ( :AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel))");
         }
         else
         {
            GXv_int9[18] = 1;
         }
         if ( StringUtil.StrCmp(AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbVisitingAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress like :lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress)");
         }
         else
         {
            GXv_int9[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel)) && ! ( StringUtil.StrCmp(AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress = ( :AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel))");
         }
         else
         {
            GXv_int9[20] = 1;
         }
         if ( StringUtil.StrCmp(AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbPostalAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Supplier_agbwwds_14_tfsupplier_agbemail)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail like :lV67Supplier_agbwwds_14_tfsupplier_agbemail)");
         }
         else
         {
            GXv_int9[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel)) && ! ( StringUtil.StrCmp(AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail = ( :AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel))");
         }
         else
         {
            GXv_int9[22] = 1;
         }
         if ( StringUtil.StrCmp(AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Supplier_agbwwds_16_tfsupplier_agbphone)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone like :lV69Supplier_agbwwds_16_tfsupplier_agbphone)");
         }
         else
         {
            GXv_int9[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel)) && ! ( StringUtil.StrCmp(AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone = ( :AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel))");
         }
         else
         {
            GXv_int9[24] = 1;
         }
         if ( StringUtil.StrCmp(AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Supplier_agbwwds_18_tfsupplier_agbcontactname)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName like :lV71Supplier_agbwwds_18_tfsupplier_agbcontactname)");
         }
         else
         {
            GXv_int9[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel)) && ! ( StringUtil.StrCmp(AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName = ( :AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel))");
         }
         else
         {
            GXv_int9[26] = 1;
         }
         if ( StringUtil.StrCmp(AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbContactName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY Supplier_AgbPostalAddress";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      protected Object[] conditional_P002F7( IGxContext context ,
                                             string AV54Supplier_agbwwds_1_filterfulltext ,
                                             short AV55Supplier_agbwwds_2_tfsupplier_agbid ,
                                             short AV56Supplier_agbwwds_3_tfsupplier_agbid_to ,
                                             string AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel ,
                                             string AV57Supplier_agbwwds_4_tfsupplier_agbnumber ,
                                             string AV60Supplier_agbwwds_7_tfsupplier_agbname_sel ,
                                             string AV59Supplier_agbwwds_6_tfsupplier_agbname ,
                                             string AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel ,
                                             string AV61Supplier_agbwwds_8_tfsupplier_agbkvknumber ,
                                             string AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel ,
                                             string AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress ,
                                             string AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel ,
                                             string AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress ,
                                             string AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel ,
                                             string AV67Supplier_agbwwds_14_tfsupplier_agbemail ,
                                             string AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel ,
                                             string AV69Supplier_agbwwds_16_tfsupplier_agbphone ,
                                             string AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel ,
                                             string AV71Supplier_agbwwds_18_tfsupplier_agbcontactname ,
                                             short A55Supplier_AgbId ,
                                             string A56Supplier_AgbNumber ,
                                             string A57Supplier_AgbName ,
                                             string A58Supplier_AgbKvkNumber ,
                                             string A59Supplier_AgbVisitingAddress ,
                                             string A60Supplier_AgbPostalAddress ,
                                             string A61Supplier_AgbEmail ,
                                             string A62Supplier_AgbPhone ,
                                             string A63Supplier_AgbContactName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[27];
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT Supplier_AgbEmail, Supplier_AgbId, Supplier_AgbContactName, Supplier_AgbPhone, Supplier_AgbPostalAddress, Supplier_AgbVisitingAddress, Supplier_AgbKvkNumber, Supplier_AgbName, Supplier_AgbNumber FROM Supplier_AGB";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(Supplier_AgbId,'9999'), 2) like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbNumber like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbName like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbKvkNumber like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbVisitingAddress like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbPostalAddress like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbEmail like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbPhone like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbContactName like '%' || :lV54Supplier_agbwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int11[0] = 1;
            GXv_int11[1] = 1;
            GXv_int11[2] = 1;
            GXv_int11[3] = 1;
            GXv_int11[4] = 1;
            GXv_int11[5] = 1;
            GXv_int11[6] = 1;
            GXv_int11[7] = 1;
            GXv_int11[8] = 1;
         }
         if ( ! (0==AV55Supplier_agbwwds_2_tfsupplier_agbid) )
         {
            AddWhere(sWhereString, "(Supplier_AgbId >= :AV55Supplier_agbwwds_2_tfsupplier_agbid)");
         }
         else
         {
            GXv_int11[9] = 1;
         }
         if ( ! (0==AV56Supplier_agbwwds_3_tfsupplier_agbid_to) )
         {
            AddWhere(sWhereString, "(Supplier_AgbId <= :AV56Supplier_agbwwds_3_tfsupplier_agbid_to)");
         }
         else
         {
            GXv_int11[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Supplier_agbwwds_4_tfsupplier_agbnumber)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbNumber like :lV57Supplier_agbwwds_4_tfsupplier_agbnumber)");
         }
         else
         {
            GXv_int11[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel)) && ! ( StringUtil.StrCmp(AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbNumber = ( :AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel))");
         }
         else
         {
            GXv_int11[12] = 1;
         }
         if ( StringUtil.StrCmp(AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Supplier_AgbNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Supplier_agbwwds_7_tfsupplier_agbname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Supplier_agbwwds_6_tfsupplier_agbname)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbName like :lV59Supplier_agbwwds_6_tfsupplier_agbname)");
         }
         else
         {
            GXv_int11[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Supplier_agbwwds_7_tfsupplier_agbname_sel)) && ! ( StringUtil.StrCmp(AV60Supplier_agbwwds_7_tfsupplier_agbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbName = ( :AV60Supplier_agbwwds_7_tfsupplier_agbname_sel))");
         }
         else
         {
            GXv_int11[14] = 1;
         }
         if ( StringUtil.StrCmp(AV60Supplier_agbwwds_7_tfsupplier_agbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Supplier_AgbName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Supplier_agbwwds_8_tfsupplier_agbkvknumber)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbKvkNumber like :lV61Supplier_agbwwds_8_tfsupplier_agbkvknumber)");
         }
         else
         {
            GXv_int11[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel)) && ! ( StringUtil.StrCmp(AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbKvkNumber = ( :AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel))");
         }
         else
         {
            GXv_int11[16] = 1;
         }
         if ( StringUtil.StrCmp(AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Supplier_AgbKvkNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress like :lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress)");
         }
         else
         {
            GXv_int11[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel)) && ! ( StringUtil.StrCmp(AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress = ( :AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel))");
         }
         else
         {
            GXv_int11[18] = 1;
         }
         if ( StringUtil.StrCmp(AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbVisitingAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress like :lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress)");
         }
         else
         {
            GXv_int11[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel)) && ! ( StringUtil.StrCmp(AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress = ( :AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel))");
         }
         else
         {
            GXv_int11[20] = 1;
         }
         if ( StringUtil.StrCmp(AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbPostalAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Supplier_agbwwds_14_tfsupplier_agbemail)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail like :lV67Supplier_agbwwds_14_tfsupplier_agbemail)");
         }
         else
         {
            GXv_int11[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel)) && ! ( StringUtil.StrCmp(AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail = ( :AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel))");
         }
         else
         {
            GXv_int11[22] = 1;
         }
         if ( StringUtil.StrCmp(AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Supplier_agbwwds_16_tfsupplier_agbphone)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone like :lV69Supplier_agbwwds_16_tfsupplier_agbphone)");
         }
         else
         {
            GXv_int11[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel)) && ! ( StringUtil.StrCmp(AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone = ( :AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel))");
         }
         else
         {
            GXv_int11[24] = 1;
         }
         if ( StringUtil.StrCmp(AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Supplier_agbwwds_18_tfsupplier_agbcontactname)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName like :lV71Supplier_agbwwds_18_tfsupplier_agbcontactname)");
         }
         else
         {
            GXv_int11[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel)) && ! ( StringUtil.StrCmp(AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName = ( :AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel))");
         }
         else
         {
            GXv_int11[26] = 1;
         }
         if ( StringUtil.StrCmp(AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbContactName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY Supplier_AgbEmail";
         GXv_Object12[0] = scmdbuf;
         GXv_Object12[1] = GXv_int11;
         return GXv_Object12 ;
      }

      protected Object[] conditional_P002F8( IGxContext context ,
                                             string AV54Supplier_agbwwds_1_filterfulltext ,
                                             short AV55Supplier_agbwwds_2_tfsupplier_agbid ,
                                             short AV56Supplier_agbwwds_3_tfsupplier_agbid_to ,
                                             string AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel ,
                                             string AV57Supplier_agbwwds_4_tfsupplier_agbnumber ,
                                             string AV60Supplier_agbwwds_7_tfsupplier_agbname_sel ,
                                             string AV59Supplier_agbwwds_6_tfsupplier_agbname ,
                                             string AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel ,
                                             string AV61Supplier_agbwwds_8_tfsupplier_agbkvknumber ,
                                             string AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel ,
                                             string AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress ,
                                             string AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel ,
                                             string AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress ,
                                             string AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel ,
                                             string AV67Supplier_agbwwds_14_tfsupplier_agbemail ,
                                             string AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel ,
                                             string AV69Supplier_agbwwds_16_tfsupplier_agbphone ,
                                             string AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel ,
                                             string AV71Supplier_agbwwds_18_tfsupplier_agbcontactname ,
                                             short A55Supplier_AgbId ,
                                             string A56Supplier_AgbNumber ,
                                             string A57Supplier_AgbName ,
                                             string A58Supplier_AgbKvkNumber ,
                                             string A59Supplier_AgbVisitingAddress ,
                                             string A60Supplier_AgbPostalAddress ,
                                             string A61Supplier_AgbEmail ,
                                             string A62Supplier_AgbPhone ,
                                             string A63Supplier_AgbContactName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int13 = new short[27];
         Object[] GXv_Object14 = new Object[2];
         scmdbuf = "SELECT Supplier_AgbPhone, Supplier_AgbId, Supplier_AgbContactName, Supplier_AgbEmail, Supplier_AgbPostalAddress, Supplier_AgbVisitingAddress, Supplier_AgbKvkNumber, Supplier_AgbName, Supplier_AgbNumber FROM Supplier_AGB";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(Supplier_AgbId,'9999'), 2) like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbNumber like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbName like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbKvkNumber like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbVisitingAddress like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbPostalAddress like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbEmail like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbPhone like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbContactName like '%' || :lV54Supplier_agbwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int13[0] = 1;
            GXv_int13[1] = 1;
            GXv_int13[2] = 1;
            GXv_int13[3] = 1;
            GXv_int13[4] = 1;
            GXv_int13[5] = 1;
            GXv_int13[6] = 1;
            GXv_int13[7] = 1;
            GXv_int13[8] = 1;
         }
         if ( ! (0==AV55Supplier_agbwwds_2_tfsupplier_agbid) )
         {
            AddWhere(sWhereString, "(Supplier_AgbId >= :AV55Supplier_agbwwds_2_tfsupplier_agbid)");
         }
         else
         {
            GXv_int13[9] = 1;
         }
         if ( ! (0==AV56Supplier_agbwwds_3_tfsupplier_agbid_to) )
         {
            AddWhere(sWhereString, "(Supplier_AgbId <= :AV56Supplier_agbwwds_3_tfsupplier_agbid_to)");
         }
         else
         {
            GXv_int13[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Supplier_agbwwds_4_tfsupplier_agbnumber)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbNumber like :lV57Supplier_agbwwds_4_tfsupplier_agbnumber)");
         }
         else
         {
            GXv_int13[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel)) && ! ( StringUtil.StrCmp(AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbNumber = ( :AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel))");
         }
         else
         {
            GXv_int13[12] = 1;
         }
         if ( StringUtil.StrCmp(AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Supplier_AgbNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Supplier_agbwwds_7_tfsupplier_agbname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Supplier_agbwwds_6_tfsupplier_agbname)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbName like :lV59Supplier_agbwwds_6_tfsupplier_agbname)");
         }
         else
         {
            GXv_int13[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Supplier_agbwwds_7_tfsupplier_agbname_sel)) && ! ( StringUtil.StrCmp(AV60Supplier_agbwwds_7_tfsupplier_agbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbName = ( :AV60Supplier_agbwwds_7_tfsupplier_agbname_sel))");
         }
         else
         {
            GXv_int13[14] = 1;
         }
         if ( StringUtil.StrCmp(AV60Supplier_agbwwds_7_tfsupplier_agbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Supplier_AgbName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Supplier_agbwwds_8_tfsupplier_agbkvknumber)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbKvkNumber like :lV61Supplier_agbwwds_8_tfsupplier_agbkvknumber)");
         }
         else
         {
            GXv_int13[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel)) && ! ( StringUtil.StrCmp(AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbKvkNumber = ( :AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel))");
         }
         else
         {
            GXv_int13[16] = 1;
         }
         if ( StringUtil.StrCmp(AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Supplier_AgbKvkNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress like :lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress)");
         }
         else
         {
            GXv_int13[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel)) && ! ( StringUtil.StrCmp(AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress = ( :AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel))");
         }
         else
         {
            GXv_int13[18] = 1;
         }
         if ( StringUtil.StrCmp(AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbVisitingAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress like :lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress)");
         }
         else
         {
            GXv_int13[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel)) && ! ( StringUtil.StrCmp(AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress = ( :AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel))");
         }
         else
         {
            GXv_int13[20] = 1;
         }
         if ( StringUtil.StrCmp(AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbPostalAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Supplier_agbwwds_14_tfsupplier_agbemail)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail like :lV67Supplier_agbwwds_14_tfsupplier_agbemail)");
         }
         else
         {
            GXv_int13[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel)) && ! ( StringUtil.StrCmp(AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail = ( :AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel))");
         }
         else
         {
            GXv_int13[22] = 1;
         }
         if ( StringUtil.StrCmp(AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Supplier_agbwwds_16_tfsupplier_agbphone)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone like :lV69Supplier_agbwwds_16_tfsupplier_agbphone)");
         }
         else
         {
            GXv_int13[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel)) && ! ( StringUtil.StrCmp(AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone = ( :AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel))");
         }
         else
         {
            GXv_int13[24] = 1;
         }
         if ( StringUtil.StrCmp(AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Supplier_agbwwds_18_tfsupplier_agbcontactname)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName like :lV71Supplier_agbwwds_18_tfsupplier_agbcontactname)");
         }
         else
         {
            GXv_int13[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel)) && ! ( StringUtil.StrCmp(AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName = ( :AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel))");
         }
         else
         {
            GXv_int13[26] = 1;
         }
         if ( StringUtil.StrCmp(AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbContactName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY Supplier_AgbPhone";
         GXv_Object14[0] = scmdbuf;
         GXv_Object14[1] = GXv_int13;
         return GXv_Object14 ;
      }

      protected Object[] conditional_P002F9( IGxContext context ,
                                             string AV54Supplier_agbwwds_1_filterfulltext ,
                                             short AV55Supplier_agbwwds_2_tfsupplier_agbid ,
                                             short AV56Supplier_agbwwds_3_tfsupplier_agbid_to ,
                                             string AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel ,
                                             string AV57Supplier_agbwwds_4_tfsupplier_agbnumber ,
                                             string AV60Supplier_agbwwds_7_tfsupplier_agbname_sel ,
                                             string AV59Supplier_agbwwds_6_tfsupplier_agbname ,
                                             string AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel ,
                                             string AV61Supplier_agbwwds_8_tfsupplier_agbkvknumber ,
                                             string AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel ,
                                             string AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress ,
                                             string AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel ,
                                             string AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress ,
                                             string AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel ,
                                             string AV67Supplier_agbwwds_14_tfsupplier_agbemail ,
                                             string AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel ,
                                             string AV69Supplier_agbwwds_16_tfsupplier_agbphone ,
                                             string AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel ,
                                             string AV71Supplier_agbwwds_18_tfsupplier_agbcontactname ,
                                             short A55Supplier_AgbId ,
                                             string A56Supplier_AgbNumber ,
                                             string A57Supplier_AgbName ,
                                             string A58Supplier_AgbKvkNumber ,
                                             string A59Supplier_AgbVisitingAddress ,
                                             string A60Supplier_AgbPostalAddress ,
                                             string A61Supplier_AgbEmail ,
                                             string A62Supplier_AgbPhone ,
                                             string A63Supplier_AgbContactName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int15 = new short[27];
         Object[] GXv_Object16 = new Object[2];
         scmdbuf = "SELECT Supplier_AgbContactName, Supplier_AgbId, Supplier_AgbPhone, Supplier_AgbEmail, Supplier_AgbPostalAddress, Supplier_AgbVisitingAddress, Supplier_AgbKvkNumber, Supplier_AgbName, Supplier_AgbNumber FROM Supplier_AGB";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(Supplier_AgbId,'9999'), 2) like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbNumber like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbName like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbKvkNumber like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbVisitingAddress like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbPostalAddress like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbEmail like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbPhone like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbContactName like '%' || :lV54Supplier_agbwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int15[0] = 1;
            GXv_int15[1] = 1;
            GXv_int15[2] = 1;
            GXv_int15[3] = 1;
            GXv_int15[4] = 1;
            GXv_int15[5] = 1;
            GXv_int15[6] = 1;
            GXv_int15[7] = 1;
            GXv_int15[8] = 1;
         }
         if ( ! (0==AV55Supplier_agbwwds_2_tfsupplier_agbid) )
         {
            AddWhere(sWhereString, "(Supplier_AgbId >= :AV55Supplier_agbwwds_2_tfsupplier_agbid)");
         }
         else
         {
            GXv_int15[9] = 1;
         }
         if ( ! (0==AV56Supplier_agbwwds_3_tfsupplier_agbid_to) )
         {
            AddWhere(sWhereString, "(Supplier_AgbId <= :AV56Supplier_agbwwds_3_tfsupplier_agbid_to)");
         }
         else
         {
            GXv_int15[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Supplier_agbwwds_4_tfsupplier_agbnumber)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbNumber like :lV57Supplier_agbwwds_4_tfsupplier_agbnumber)");
         }
         else
         {
            GXv_int15[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel)) && ! ( StringUtil.StrCmp(AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbNumber = ( :AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel))");
         }
         else
         {
            GXv_int15[12] = 1;
         }
         if ( StringUtil.StrCmp(AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Supplier_AgbNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Supplier_agbwwds_7_tfsupplier_agbname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Supplier_agbwwds_6_tfsupplier_agbname)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbName like :lV59Supplier_agbwwds_6_tfsupplier_agbname)");
         }
         else
         {
            GXv_int15[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Supplier_agbwwds_7_tfsupplier_agbname_sel)) && ! ( StringUtil.StrCmp(AV60Supplier_agbwwds_7_tfsupplier_agbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbName = ( :AV60Supplier_agbwwds_7_tfsupplier_agbname_sel))");
         }
         else
         {
            GXv_int15[14] = 1;
         }
         if ( StringUtil.StrCmp(AV60Supplier_agbwwds_7_tfsupplier_agbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Supplier_AgbName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Supplier_agbwwds_8_tfsupplier_agbkvknumber)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbKvkNumber like :lV61Supplier_agbwwds_8_tfsupplier_agbkvknumber)");
         }
         else
         {
            GXv_int15[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel)) && ! ( StringUtil.StrCmp(AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbKvkNumber = ( :AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel))");
         }
         else
         {
            GXv_int15[16] = 1;
         }
         if ( StringUtil.StrCmp(AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Supplier_AgbKvkNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress like :lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress)");
         }
         else
         {
            GXv_int15[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel)) && ! ( StringUtil.StrCmp(AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress = ( :AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel))");
         }
         else
         {
            GXv_int15[18] = 1;
         }
         if ( StringUtil.StrCmp(AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbVisitingAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress like :lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress)");
         }
         else
         {
            GXv_int15[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel)) && ! ( StringUtil.StrCmp(AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress = ( :AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel))");
         }
         else
         {
            GXv_int15[20] = 1;
         }
         if ( StringUtil.StrCmp(AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbPostalAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Supplier_agbwwds_14_tfsupplier_agbemail)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail like :lV67Supplier_agbwwds_14_tfsupplier_agbemail)");
         }
         else
         {
            GXv_int15[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel)) && ! ( StringUtil.StrCmp(AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail = ( :AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel))");
         }
         else
         {
            GXv_int15[22] = 1;
         }
         if ( StringUtil.StrCmp(AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Supplier_agbwwds_16_tfsupplier_agbphone)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone like :lV69Supplier_agbwwds_16_tfsupplier_agbphone)");
         }
         else
         {
            GXv_int15[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel)) && ! ( StringUtil.StrCmp(AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone = ( :AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel))");
         }
         else
         {
            GXv_int15[24] = 1;
         }
         if ( StringUtil.StrCmp(AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Supplier_agbwwds_18_tfsupplier_agbcontactname)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName like :lV71Supplier_agbwwds_18_tfsupplier_agbcontactname)");
         }
         else
         {
            GXv_int15[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel)) && ! ( StringUtil.StrCmp(AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName = ( :AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel))");
         }
         else
         {
            GXv_int15[26] = 1;
         }
         if ( StringUtil.StrCmp(AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbContactName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY Supplier_AgbContactName";
         GXv_Object16[0] = scmdbuf;
         GXv_Object16[1] = GXv_int15;
         return GXv_Object16 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P002F2(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] );
               case 1 :
                     return conditional_P002F3(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] );
               case 2 :
                     return conditional_P002F4(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] );
               case 3 :
                     return conditional_P002F5(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] );
               case 4 :
                     return conditional_P002F6(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] );
               case 5 :
                     return conditional_P002F7(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] );
               case 6 :
                     return conditional_P002F8(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] );
               case 7 :
                     return conditional_P002F9(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP002F2;
          prmP002F2 = new Object[] {
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV55Supplier_agbwwds_2_tfsupplier_agbid",GXType.Int16,4,0) ,
          new ParDef("AV56Supplier_agbwwds_3_tfsupplier_agbid_to",GXType.Int16,4,0) ,
          new ParDef("lV57Supplier_agbwwds_4_tfsupplier_agbnumber",GXType.VarChar,10,0) ,
          new ParDef("AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel",GXType.VarChar,10,0) ,
          new ParDef("lV59Supplier_agbwwds_6_tfsupplier_agbname",GXType.VarChar,40,0) ,
          new ParDef("AV60Supplier_agbwwds_7_tfsupplier_agbname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV61Supplier_agbwwds_8_tfsupplier_agbkvknumber",GXType.VarChar,8,0) ,
          new ParDef("AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel",GXType.VarChar,8,0) ,
          new ParDef("lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress",GXType.VarChar,1024,0) ,
          new ParDef("AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV67Supplier_agbwwds_14_tfsupplier_agbemail",GXType.VarChar,100,0) ,
          new ParDef("AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV69Supplier_agbwwds_16_tfsupplier_agbphone",GXType.Char,20,0) ,
          new ParDef("AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel",GXType.Char,20,0) ,
          new ParDef("lV71Supplier_agbwwds_18_tfsupplier_agbcontactname",GXType.VarChar,40,0) ,
          new ParDef("AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel",GXType.VarChar,40,0)
          };
          Object[] prmP002F3;
          prmP002F3 = new Object[] {
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV55Supplier_agbwwds_2_tfsupplier_agbid",GXType.Int16,4,0) ,
          new ParDef("AV56Supplier_agbwwds_3_tfsupplier_agbid_to",GXType.Int16,4,0) ,
          new ParDef("lV57Supplier_agbwwds_4_tfsupplier_agbnumber",GXType.VarChar,10,0) ,
          new ParDef("AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel",GXType.VarChar,10,0) ,
          new ParDef("lV59Supplier_agbwwds_6_tfsupplier_agbname",GXType.VarChar,40,0) ,
          new ParDef("AV60Supplier_agbwwds_7_tfsupplier_agbname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV61Supplier_agbwwds_8_tfsupplier_agbkvknumber",GXType.VarChar,8,0) ,
          new ParDef("AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel",GXType.VarChar,8,0) ,
          new ParDef("lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress",GXType.VarChar,1024,0) ,
          new ParDef("AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV67Supplier_agbwwds_14_tfsupplier_agbemail",GXType.VarChar,100,0) ,
          new ParDef("AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV69Supplier_agbwwds_16_tfsupplier_agbphone",GXType.Char,20,0) ,
          new ParDef("AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel",GXType.Char,20,0) ,
          new ParDef("lV71Supplier_agbwwds_18_tfsupplier_agbcontactname",GXType.VarChar,40,0) ,
          new ParDef("AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel",GXType.VarChar,40,0)
          };
          Object[] prmP002F4;
          prmP002F4 = new Object[] {
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV55Supplier_agbwwds_2_tfsupplier_agbid",GXType.Int16,4,0) ,
          new ParDef("AV56Supplier_agbwwds_3_tfsupplier_agbid_to",GXType.Int16,4,0) ,
          new ParDef("lV57Supplier_agbwwds_4_tfsupplier_agbnumber",GXType.VarChar,10,0) ,
          new ParDef("AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel",GXType.VarChar,10,0) ,
          new ParDef("lV59Supplier_agbwwds_6_tfsupplier_agbname",GXType.VarChar,40,0) ,
          new ParDef("AV60Supplier_agbwwds_7_tfsupplier_agbname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV61Supplier_agbwwds_8_tfsupplier_agbkvknumber",GXType.VarChar,8,0) ,
          new ParDef("AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel",GXType.VarChar,8,0) ,
          new ParDef("lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress",GXType.VarChar,1024,0) ,
          new ParDef("AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV67Supplier_agbwwds_14_tfsupplier_agbemail",GXType.VarChar,100,0) ,
          new ParDef("AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV69Supplier_agbwwds_16_tfsupplier_agbphone",GXType.Char,20,0) ,
          new ParDef("AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel",GXType.Char,20,0) ,
          new ParDef("lV71Supplier_agbwwds_18_tfsupplier_agbcontactname",GXType.VarChar,40,0) ,
          new ParDef("AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel",GXType.VarChar,40,0)
          };
          Object[] prmP002F5;
          prmP002F5 = new Object[] {
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV55Supplier_agbwwds_2_tfsupplier_agbid",GXType.Int16,4,0) ,
          new ParDef("AV56Supplier_agbwwds_3_tfsupplier_agbid_to",GXType.Int16,4,0) ,
          new ParDef("lV57Supplier_agbwwds_4_tfsupplier_agbnumber",GXType.VarChar,10,0) ,
          new ParDef("AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel",GXType.VarChar,10,0) ,
          new ParDef("lV59Supplier_agbwwds_6_tfsupplier_agbname",GXType.VarChar,40,0) ,
          new ParDef("AV60Supplier_agbwwds_7_tfsupplier_agbname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV61Supplier_agbwwds_8_tfsupplier_agbkvknumber",GXType.VarChar,8,0) ,
          new ParDef("AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel",GXType.VarChar,8,0) ,
          new ParDef("lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress",GXType.VarChar,1024,0) ,
          new ParDef("AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV67Supplier_agbwwds_14_tfsupplier_agbemail",GXType.VarChar,100,0) ,
          new ParDef("AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV69Supplier_agbwwds_16_tfsupplier_agbphone",GXType.Char,20,0) ,
          new ParDef("AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel",GXType.Char,20,0) ,
          new ParDef("lV71Supplier_agbwwds_18_tfsupplier_agbcontactname",GXType.VarChar,40,0) ,
          new ParDef("AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel",GXType.VarChar,40,0)
          };
          Object[] prmP002F6;
          prmP002F6 = new Object[] {
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV55Supplier_agbwwds_2_tfsupplier_agbid",GXType.Int16,4,0) ,
          new ParDef("AV56Supplier_agbwwds_3_tfsupplier_agbid_to",GXType.Int16,4,0) ,
          new ParDef("lV57Supplier_agbwwds_4_tfsupplier_agbnumber",GXType.VarChar,10,0) ,
          new ParDef("AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel",GXType.VarChar,10,0) ,
          new ParDef("lV59Supplier_agbwwds_6_tfsupplier_agbname",GXType.VarChar,40,0) ,
          new ParDef("AV60Supplier_agbwwds_7_tfsupplier_agbname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV61Supplier_agbwwds_8_tfsupplier_agbkvknumber",GXType.VarChar,8,0) ,
          new ParDef("AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel",GXType.VarChar,8,0) ,
          new ParDef("lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress",GXType.VarChar,1024,0) ,
          new ParDef("AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV67Supplier_agbwwds_14_tfsupplier_agbemail",GXType.VarChar,100,0) ,
          new ParDef("AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV69Supplier_agbwwds_16_tfsupplier_agbphone",GXType.Char,20,0) ,
          new ParDef("AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel",GXType.Char,20,0) ,
          new ParDef("lV71Supplier_agbwwds_18_tfsupplier_agbcontactname",GXType.VarChar,40,0) ,
          new ParDef("AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel",GXType.VarChar,40,0)
          };
          Object[] prmP002F7;
          prmP002F7 = new Object[] {
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV55Supplier_agbwwds_2_tfsupplier_agbid",GXType.Int16,4,0) ,
          new ParDef("AV56Supplier_agbwwds_3_tfsupplier_agbid_to",GXType.Int16,4,0) ,
          new ParDef("lV57Supplier_agbwwds_4_tfsupplier_agbnumber",GXType.VarChar,10,0) ,
          new ParDef("AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel",GXType.VarChar,10,0) ,
          new ParDef("lV59Supplier_agbwwds_6_tfsupplier_agbname",GXType.VarChar,40,0) ,
          new ParDef("AV60Supplier_agbwwds_7_tfsupplier_agbname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV61Supplier_agbwwds_8_tfsupplier_agbkvknumber",GXType.VarChar,8,0) ,
          new ParDef("AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel",GXType.VarChar,8,0) ,
          new ParDef("lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress",GXType.VarChar,1024,0) ,
          new ParDef("AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV67Supplier_agbwwds_14_tfsupplier_agbemail",GXType.VarChar,100,0) ,
          new ParDef("AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV69Supplier_agbwwds_16_tfsupplier_agbphone",GXType.Char,20,0) ,
          new ParDef("AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel",GXType.Char,20,0) ,
          new ParDef("lV71Supplier_agbwwds_18_tfsupplier_agbcontactname",GXType.VarChar,40,0) ,
          new ParDef("AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel",GXType.VarChar,40,0)
          };
          Object[] prmP002F8;
          prmP002F8 = new Object[] {
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV55Supplier_agbwwds_2_tfsupplier_agbid",GXType.Int16,4,0) ,
          new ParDef("AV56Supplier_agbwwds_3_tfsupplier_agbid_to",GXType.Int16,4,0) ,
          new ParDef("lV57Supplier_agbwwds_4_tfsupplier_agbnumber",GXType.VarChar,10,0) ,
          new ParDef("AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel",GXType.VarChar,10,0) ,
          new ParDef("lV59Supplier_agbwwds_6_tfsupplier_agbname",GXType.VarChar,40,0) ,
          new ParDef("AV60Supplier_agbwwds_7_tfsupplier_agbname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV61Supplier_agbwwds_8_tfsupplier_agbkvknumber",GXType.VarChar,8,0) ,
          new ParDef("AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel",GXType.VarChar,8,0) ,
          new ParDef("lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress",GXType.VarChar,1024,0) ,
          new ParDef("AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV67Supplier_agbwwds_14_tfsupplier_agbemail",GXType.VarChar,100,0) ,
          new ParDef("AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV69Supplier_agbwwds_16_tfsupplier_agbphone",GXType.Char,20,0) ,
          new ParDef("AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel",GXType.Char,20,0) ,
          new ParDef("lV71Supplier_agbwwds_18_tfsupplier_agbcontactname",GXType.VarChar,40,0) ,
          new ParDef("AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel",GXType.VarChar,40,0)
          };
          Object[] prmP002F9;
          prmP002F9 = new Object[] {
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV55Supplier_agbwwds_2_tfsupplier_agbid",GXType.Int16,4,0) ,
          new ParDef("AV56Supplier_agbwwds_3_tfsupplier_agbid_to",GXType.Int16,4,0) ,
          new ParDef("lV57Supplier_agbwwds_4_tfsupplier_agbnumber",GXType.VarChar,10,0) ,
          new ParDef("AV58Supplier_agbwwds_5_tfsupplier_agbnumber_sel",GXType.VarChar,10,0) ,
          new ParDef("lV59Supplier_agbwwds_6_tfsupplier_agbname",GXType.VarChar,40,0) ,
          new ParDef("AV60Supplier_agbwwds_7_tfsupplier_agbname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV61Supplier_agbwwds_8_tfsupplier_agbkvknumber",GXType.VarChar,8,0) ,
          new ParDef("AV62Supplier_agbwwds_9_tfsupplier_agbkvknumber_sel",GXType.VarChar,8,0) ,
          new ParDef("lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress",GXType.VarChar,1024,0) ,
          new ParDef("AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV67Supplier_agbwwds_14_tfsupplier_agbemail",GXType.VarChar,100,0) ,
          new ParDef("AV68Supplier_agbwwds_15_tfsupplier_agbemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV69Supplier_agbwwds_16_tfsupplier_agbphone",GXType.Char,20,0) ,
          new ParDef("AV70Supplier_agbwwds_17_tfsupplier_agbphone_sel",GXType.Char,20,0) ,
          new ParDef("lV71Supplier_agbwwds_18_tfsupplier_agbcontactname",GXType.VarChar,40,0) ,
          new ParDef("AV72Supplier_agbwwds_19_tfsupplier_agbcontactname_sel",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002F2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002F2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002F3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002F3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002F4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002F4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002F5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002F5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002F6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002F6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002F7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002F7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002F8", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002F8,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002F9", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002F9,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 20);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((string[]) buf[8])[0] = rslt.getVarchar(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((string[]) buf[10])[0] = rslt.getVarchar(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((string[]) buf[12])[0] = rslt.getVarchar(8);
                ((string[]) buf[13])[0] = rslt.getVarchar(9);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 20);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((string[]) buf[8])[0] = rslt.getVarchar(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((string[]) buf[10])[0] = rslt.getVarchar(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((string[]) buf[12])[0] = rslt.getVarchar(8);
                ((string[]) buf[13])[0] = rslt.getVarchar(9);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 20);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((string[]) buf[8])[0] = rslt.getVarchar(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((string[]) buf[10])[0] = rslt.getVarchar(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((string[]) buf[12])[0] = rslt.getVarchar(8);
                ((string[]) buf[13])[0] = rslt.getVarchar(9);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getString(4, 20);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((string[]) buf[12])[0] = rslt.getVarchar(8);
                ((string[]) buf[13])[0] = rslt.getVarchar(9);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getString(4, 20);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((string[]) buf[12])[0] = rslt.getVarchar(8);
                ((string[]) buf[13])[0] = rslt.getVarchar(9);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getString(4, 20);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((string[]) buf[12])[0] = rslt.getVarchar(8);
                ((string[]) buf[13])[0] = rslt.getVarchar(9);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((string[]) buf[12])[0] = rslt.getVarchar(8);
                ((string[]) buf[13])[0] = rslt.getVarchar(9);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 20);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((string[]) buf[12])[0] = rslt.getVarchar(8);
                ((string[]) buf[13])[0] = rslt.getVarchar(9);
                return;
       }
    }

 }

}
