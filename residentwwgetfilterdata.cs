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
   public class residentwwgetfilterdata : GXProcedure
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
            return "residentww_Services_Execute" ;
         }

      }

      public residentwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public residentwwgetfilterdata( IGxContext context )
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
         this.AV47DDOName = aP0_DDOName;
         this.AV48SearchTxtParms = aP1_SearchTxtParms;
         this.AV49SearchTxtTo = aP2_SearchTxtTo;
         this.AV50OptionsJson = "" ;
         this.AV51OptionsDescJson = "" ;
         this.AV52OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV50OptionsJson;
         aP4_OptionsDescJson=this.AV51OptionsDescJson;
         aP5_OptionIndexesJson=this.AV52OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV52OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         residentwwgetfilterdata objresidentwwgetfilterdata;
         objresidentwwgetfilterdata = new residentwwgetfilterdata();
         objresidentwwgetfilterdata.AV47DDOName = aP0_DDOName;
         objresidentwwgetfilterdata.AV48SearchTxtParms = aP1_SearchTxtParms;
         objresidentwwgetfilterdata.AV49SearchTxtTo = aP2_SearchTxtTo;
         objresidentwwgetfilterdata.AV50OptionsJson = "" ;
         objresidentwwgetfilterdata.AV51OptionsDescJson = "" ;
         objresidentwwgetfilterdata.AV52OptionIndexesJson = "" ;
         objresidentwwgetfilterdata.context.SetSubmitInitialConfig(context);
         objresidentwwgetfilterdata.initialize();
         Submit( executePrivateCatch,objresidentwwgetfilterdata);
         aP3_OptionsJson=this.AV50OptionsJson;
         aP4_OptionsDescJson=this.AV51OptionsDescJson;
         aP5_OptionIndexesJson=this.AV52OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((residentwwgetfilterdata)stateInfo).executePrivate();
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
         AV37Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV39OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV40OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV34MaxItems = 10;
         AV33PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV48SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV48SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV31SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV48SearchTxtParms)) ? "" : StringUtil.Substring( AV48SearchTxtParms, 3, -1));
         AV32SkipItems = (short)(AV33PageIndex*AV34MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_RESIDENTBSNNUMBER") == 0 )
         {
            /* Execute user subroutine: 'LOADRESIDENTBSNNUMBEROPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_RESIDENTGIVENNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADRESIDENTGIVENNAMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_RESIDENTLASTNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADRESIDENTLASTNAMEOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_RESIDENTEMAIL") == 0 )
         {
            /* Execute user subroutine: 'LOADRESIDENTEMAILOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_RESIDENTADDRESS") == 0 )
         {
            /* Execute user subroutine: 'LOADRESIDENTADDRESSOPTIONS' */
            S161 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_RESIDENTPHONE") == 0 )
         {
            /* Execute user subroutine: 'LOADRESIDENTPHONEOPTIONS' */
            S171 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_RESIDENTTYPENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADRESIDENTTYPENAMEOPTIONS' */
            S181 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV50OptionsJson = AV37Options.ToJSonString(false);
         AV51OptionsDescJson = AV39OptionsDesc.ToJSonString(false);
         AV52OptionIndexesJson = AV40OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV42Session.Get("ResidentWWGridState"), "") == 0 )
         {
            AV44GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ResidentWWGridState"), null, "", "");
         }
         else
         {
            AV44GridState.FromXml(AV42Session.Get("ResidentWWGridState"), null, "", "");
         }
         AV62GXV1 = 1;
         while ( AV62GXV1 <= AV44GridState.gxTpr_Filtervalues.Count )
         {
            AV45GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV44GridState.gxTpr_Filtervalues.Item(AV62GXV1));
            if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV53FilterFullText = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTBSNNUMBER") == 0 )
            {
               AV13TFResidentBsnNumber = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTBSNNUMBER_SEL") == 0 )
            {
               AV14TFResidentBsnNumber_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTGIVENNAME") == 0 )
            {
               AV15TFResidentGivenName = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTGIVENNAME_SEL") == 0 )
            {
               AV16TFResidentGivenName_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTLASTNAME") == 0 )
            {
               AV17TFResidentLastName = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTLASTNAME_SEL") == 0 )
            {
               AV18TFResidentLastName_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTEMAIL") == 0 )
            {
               AV21TFResidentEmail = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTEMAIL_SEL") == 0 )
            {
               AV22TFResidentEmail_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTADDRESS") == 0 )
            {
               AV23TFResidentAddress = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTADDRESS_SEL") == 0 )
            {
               AV24TFResidentAddress_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTPHONE") == 0 )
            {
               AV25TFResidentPhone = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTPHONE_SEL") == 0 )
            {
               AV26TFResidentPhone_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTTYPENAME") == 0 )
            {
               AV29TFResidentTypeName = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTTYPENAME_SEL") == 0 )
            {
               AV30TFResidentTypeName_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            AV62GXV1 = (int)(AV62GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADRESIDENTBSNNUMBEROPTIONS' Routine */
         returnInSub = false;
         AV13TFResidentBsnNumber = AV31SearchTxt;
         AV14TFResidentBsnNumber_Sel = "";
         AV64Residentwwds_1_filterfulltext = AV53FilterFullText;
         AV65Residentwwds_2_tfresidentbsnnumber = AV13TFResidentBsnNumber;
         AV66Residentwwds_3_tfresidentbsnnumber_sel = AV14TFResidentBsnNumber_Sel;
         AV67Residentwwds_4_tfresidentgivenname = AV15TFResidentGivenName;
         AV68Residentwwds_5_tfresidentgivenname_sel = AV16TFResidentGivenName_Sel;
         AV69Residentwwds_6_tfresidentlastname = AV17TFResidentLastName;
         AV70Residentwwds_7_tfresidentlastname_sel = AV18TFResidentLastName_Sel;
         AV71Residentwwds_8_tfresidentemail = AV21TFResidentEmail;
         AV72Residentwwds_9_tfresidentemail_sel = AV22TFResidentEmail_Sel;
         AV73Residentwwds_10_tfresidentaddress = AV23TFResidentAddress;
         AV74Residentwwds_11_tfresidentaddress_sel = AV24TFResidentAddress_Sel;
         AV75Residentwwds_12_tfresidentphone = AV25TFResidentPhone;
         AV76Residentwwds_13_tfresidentphone_sel = AV26TFResidentPhone_Sel;
         AV77Residentwwds_14_tfresidenttypename = AV29TFResidentTypeName;
         AV78Residentwwds_15_tfresidenttypename_sel = AV30TFResidentTypeName_Sel;
         AV79Udparg16 = new getloggedinusercustomerid(context).executeUdp( );
         AV80Udparg17 = new getreceptionistlocationid(context).executeUdp( );
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV64Residentwwds_1_filterfulltext ,
                                              AV66Residentwwds_3_tfresidentbsnnumber_sel ,
                                              AV65Residentwwds_2_tfresidentbsnnumber ,
                                              AV68Residentwwds_5_tfresidentgivenname_sel ,
                                              AV67Residentwwds_4_tfresidentgivenname ,
                                              AV70Residentwwds_7_tfresidentlastname_sel ,
                                              AV69Residentwwds_6_tfresidentlastname ,
                                              AV72Residentwwds_9_tfresidentemail_sel ,
                                              AV71Residentwwds_8_tfresidentemail ,
                                              AV74Residentwwds_11_tfresidentaddress_sel ,
                                              AV73Residentwwds_10_tfresidentaddress ,
                                              AV76Residentwwds_13_tfresidentphone_sel ,
                                              AV75Residentwwds_12_tfresidentphone ,
                                              AV78Residentwwds_15_tfresidenttypename_sel ,
                                              AV77Residentwwds_14_tfresidenttypename ,
                                              A40ResidentBsnNumber ,
                                              A33ResidentGivenName ,
                                              A34ResidentLastName ,
                                              A36ResidentEmail ,
                                              A37ResidentAddress ,
                                              A38ResidentPhone ,
                                              A83ResidentTypeName ,
                                              A1CustomerId ,
                                              AV79Udparg16 ,
                                              A18CustomerLocationId ,
                                              AV80Udparg17 } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV65Residentwwds_2_tfresidentbsnnumber = StringUtil.Concat( StringUtil.RTrim( AV65Residentwwds_2_tfresidentbsnnumber), "%", "");
         lV67Residentwwds_4_tfresidentgivenname = StringUtil.Concat( StringUtil.RTrim( AV67Residentwwds_4_tfresidentgivenname), "%", "");
         lV69Residentwwds_6_tfresidentlastname = StringUtil.Concat( StringUtil.RTrim( AV69Residentwwds_6_tfresidentlastname), "%", "");
         lV71Residentwwds_8_tfresidentemail = StringUtil.Concat( StringUtil.RTrim( AV71Residentwwds_8_tfresidentemail), "%", "");
         lV73Residentwwds_10_tfresidentaddress = StringUtil.Concat( StringUtil.RTrim( AV73Residentwwds_10_tfresidentaddress), "%", "");
         lV75Residentwwds_12_tfresidentphone = StringUtil.PadR( StringUtil.RTrim( AV75Residentwwds_12_tfresidentphone), 20, "%");
         lV77Residentwwds_14_tfresidenttypename = StringUtil.Concat( StringUtil.RTrim( AV77Residentwwds_14_tfresidenttypename), "%", "");
         /* Using cursor P002D2 */
         pr_default.execute(0, new Object[] {AV79Udparg16, AV80Udparg17, lV64Residentwwds_1_filterfulltext, lV64Residentwwds_1_filterfulltext, lV64Residentwwds_1_filterfulltext, lV64Residentwwds_1_filterfulltext, lV64Residentwwds_1_filterfulltext, lV64Residentwwds_1_filterfulltext, lV64Residentwwds_1_filterfulltext, lV65Residentwwds_2_tfresidentbsnnumber, AV66Residentwwds_3_tfresidentbsnnumber_sel, lV67Residentwwds_4_tfresidentgivenname, AV68Residentwwds_5_tfresidentgivenname_sel, lV69Residentwwds_6_tfresidentlastname, AV70Residentwwds_7_tfresidentlastname_sel, lV71Residentwwds_8_tfresidentemail, AV72Residentwwds_9_tfresidentemail_sel, lV73Residentwwds_10_tfresidentaddress, AV74Residentwwds_11_tfresidentaddress_sel, lV75Residentwwds_12_tfresidentphone, AV76Residentwwds_13_tfresidentphone_sel, lV77Residentwwds_14_tfresidenttypename, AV78Residentwwds_15_tfresidenttypename_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK2D2 = false;
            A82ResidentTypeId = P002D2_A82ResidentTypeId[0];
            A40ResidentBsnNumber = P002D2_A40ResidentBsnNumber[0];
            A18CustomerLocationId = P002D2_A18CustomerLocationId[0];
            A1CustomerId = P002D2_A1CustomerId[0];
            A83ResidentTypeName = P002D2_A83ResidentTypeName[0];
            A38ResidentPhone = P002D2_A38ResidentPhone[0];
            n38ResidentPhone = P002D2_n38ResidentPhone[0];
            A37ResidentAddress = P002D2_A37ResidentAddress[0];
            n37ResidentAddress = P002D2_n37ResidentAddress[0];
            A36ResidentEmail = P002D2_A36ResidentEmail[0];
            A34ResidentLastName = P002D2_A34ResidentLastName[0];
            A33ResidentGivenName = P002D2_A33ResidentGivenName[0];
            A31ResidentId = P002D2_A31ResidentId[0];
            A83ResidentTypeName = P002D2_A83ResidentTypeName[0];
            AV41count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P002D2_A40ResidentBsnNumber[0], A40ResidentBsnNumber) == 0 ) )
            {
               BRK2D2 = false;
               A31ResidentId = P002D2_A31ResidentId[0];
               AV41count = (long)(AV41count+1);
               BRK2D2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV32SkipItems) )
            {
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A40ResidentBsnNumber)) ? "<#Empty#>" : A40ResidentBsnNumber);
               AV37Options.Add(AV36Option, 0);
               AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV37Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV32SkipItems = (short)(AV32SkipItems-1);
            }
            if ( ! BRK2D2 )
            {
               BRK2D2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADRESIDENTGIVENNAMEOPTIONS' Routine */
         returnInSub = false;
         AV15TFResidentGivenName = AV31SearchTxt;
         AV16TFResidentGivenName_Sel = "";
         AV64Residentwwds_1_filterfulltext = AV53FilterFullText;
         AV65Residentwwds_2_tfresidentbsnnumber = AV13TFResidentBsnNumber;
         AV66Residentwwds_3_tfresidentbsnnumber_sel = AV14TFResidentBsnNumber_Sel;
         AV67Residentwwds_4_tfresidentgivenname = AV15TFResidentGivenName;
         AV68Residentwwds_5_tfresidentgivenname_sel = AV16TFResidentGivenName_Sel;
         AV69Residentwwds_6_tfresidentlastname = AV17TFResidentLastName;
         AV70Residentwwds_7_tfresidentlastname_sel = AV18TFResidentLastName_Sel;
         AV71Residentwwds_8_tfresidentemail = AV21TFResidentEmail;
         AV72Residentwwds_9_tfresidentemail_sel = AV22TFResidentEmail_Sel;
         AV73Residentwwds_10_tfresidentaddress = AV23TFResidentAddress;
         AV74Residentwwds_11_tfresidentaddress_sel = AV24TFResidentAddress_Sel;
         AV75Residentwwds_12_tfresidentphone = AV25TFResidentPhone;
         AV76Residentwwds_13_tfresidentphone_sel = AV26TFResidentPhone_Sel;
         AV77Residentwwds_14_tfresidenttypename = AV29TFResidentTypeName;
         AV78Residentwwds_15_tfresidenttypename_sel = AV30TFResidentTypeName_Sel;
         AV79Udparg16 = new getloggedinusercustomerid(context).executeUdp( );
         AV80Udparg17 = new getreceptionistlocationid(context).executeUdp( );
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV64Residentwwds_1_filterfulltext ,
                                              AV66Residentwwds_3_tfresidentbsnnumber_sel ,
                                              AV65Residentwwds_2_tfresidentbsnnumber ,
                                              AV68Residentwwds_5_tfresidentgivenname_sel ,
                                              AV67Residentwwds_4_tfresidentgivenname ,
                                              AV70Residentwwds_7_tfresidentlastname_sel ,
                                              AV69Residentwwds_6_tfresidentlastname ,
                                              AV72Residentwwds_9_tfresidentemail_sel ,
                                              AV71Residentwwds_8_tfresidentemail ,
                                              AV74Residentwwds_11_tfresidentaddress_sel ,
                                              AV73Residentwwds_10_tfresidentaddress ,
                                              AV76Residentwwds_13_tfresidentphone_sel ,
                                              AV75Residentwwds_12_tfresidentphone ,
                                              AV78Residentwwds_15_tfresidenttypename_sel ,
                                              AV77Residentwwds_14_tfresidenttypename ,
                                              A40ResidentBsnNumber ,
                                              A33ResidentGivenName ,
                                              A34ResidentLastName ,
                                              A36ResidentEmail ,
                                              A37ResidentAddress ,
                                              A38ResidentPhone ,
                                              A83ResidentTypeName ,
                                              A1CustomerId ,
                                              AV79Udparg16 ,
                                              A18CustomerLocationId ,
                                              AV80Udparg17 } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV65Residentwwds_2_tfresidentbsnnumber = StringUtil.Concat( StringUtil.RTrim( AV65Residentwwds_2_tfresidentbsnnumber), "%", "");
         lV67Residentwwds_4_tfresidentgivenname = StringUtil.Concat( StringUtil.RTrim( AV67Residentwwds_4_tfresidentgivenname), "%", "");
         lV69Residentwwds_6_tfresidentlastname = StringUtil.Concat( StringUtil.RTrim( AV69Residentwwds_6_tfresidentlastname), "%", "");
         lV71Residentwwds_8_tfresidentemail = StringUtil.Concat( StringUtil.RTrim( AV71Residentwwds_8_tfresidentemail), "%", "");
         lV73Residentwwds_10_tfresidentaddress = StringUtil.Concat( StringUtil.RTrim( AV73Residentwwds_10_tfresidentaddress), "%", "");
         lV75Residentwwds_12_tfresidentphone = StringUtil.PadR( StringUtil.RTrim( AV75Residentwwds_12_tfresidentphone), 20, "%");
         lV77Residentwwds_14_tfresidenttypename = StringUtil.Concat( StringUtil.RTrim( AV77Residentwwds_14_tfresidenttypename), "%", "");
         /* Using cursor P002D3 */
         pr_default.execute(1, new Object[] {AV79Udparg16, AV80Udparg17, lV64Residentwwds_1_filterfulltext, lV64Residentwwds_1_filterfulltext, lV64Residentwwds_1_filterfulltext, lV64Residentwwds_1_filterfulltext, lV64Residentwwds_1_filterfulltext, lV64Residentwwds_1_filterfulltext, lV64Residentwwds_1_filterfulltext, lV65Residentwwds_2_tfresidentbsnnumber, AV66Residentwwds_3_tfresidentbsnnumber_sel, lV67Residentwwds_4_tfresidentgivenname, AV68Residentwwds_5_tfresidentgivenname_sel, lV69Residentwwds_6_tfresidentlastname, AV70Residentwwds_7_tfresidentlastname_sel, lV71Residentwwds_8_tfresidentemail, AV72Residentwwds_9_tfresidentemail_sel, lV73Residentwwds_10_tfresidentaddress, AV74Residentwwds_11_tfresidentaddress_sel, lV75Residentwwds_12_tfresidentphone, AV76Residentwwds_13_tfresidentphone_sel, lV77Residentwwds_14_tfresidenttypename, AV78Residentwwds_15_tfresidenttypename_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK2D4 = false;
            A82ResidentTypeId = P002D3_A82ResidentTypeId[0];
            A1CustomerId = P002D3_A1CustomerId[0];
            A18CustomerLocationId = P002D3_A18CustomerLocationId[0];
            A33ResidentGivenName = P002D3_A33ResidentGivenName[0];
            A83ResidentTypeName = P002D3_A83ResidentTypeName[0];
            A38ResidentPhone = P002D3_A38ResidentPhone[0];
            n38ResidentPhone = P002D3_n38ResidentPhone[0];
            A37ResidentAddress = P002D3_A37ResidentAddress[0];
            n37ResidentAddress = P002D3_n37ResidentAddress[0];
            A36ResidentEmail = P002D3_A36ResidentEmail[0];
            A34ResidentLastName = P002D3_A34ResidentLastName[0];
            A40ResidentBsnNumber = P002D3_A40ResidentBsnNumber[0];
            A31ResidentId = P002D3_A31ResidentId[0];
            A83ResidentTypeName = P002D3_A83ResidentTypeName[0];
            AV41count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P002D3_A33ResidentGivenName[0], A33ResidentGivenName) == 0 ) )
            {
               BRK2D4 = false;
               A31ResidentId = P002D3_A31ResidentId[0];
               AV41count = (long)(AV41count+1);
               BRK2D4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV32SkipItems) )
            {
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A33ResidentGivenName)) ? "<#Empty#>" : A33ResidentGivenName);
               AV37Options.Add(AV36Option, 0);
               AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV37Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV32SkipItems = (short)(AV32SkipItems-1);
            }
            if ( ! BRK2D4 )
            {
               BRK2D4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADRESIDENTLASTNAMEOPTIONS' Routine */
         returnInSub = false;
         AV17TFResidentLastName = AV31SearchTxt;
         AV18TFResidentLastName_Sel = "";
         AV64Residentwwds_1_filterfulltext = AV53FilterFullText;
         AV65Residentwwds_2_tfresidentbsnnumber = AV13TFResidentBsnNumber;
         AV66Residentwwds_3_tfresidentbsnnumber_sel = AV14TFResidentBsnNumber_Sel;
         AV67Residentwwds_4_tfresidentgivenname = AV15TFResidentGivenName;
         AV68Residentwwds_5_tfresidentgivenname_sel = AV16TFResidentGivenName_Sel;
         AV69Residentwwds_6_tfresidentlastname = AV17TFResidentLastName;
         AV70Residentwwds_7_tfresidentlastname_sel = AV18TFResidentLastName_Sel;
         AV71Residentwwds_8_tfresidentemail = AV21TFResidentEmail;
         AV72Residentwwds_9_tfresidentemail_sel = AV22TFResidentEmail_Sel;
         AV73Residentwwds_10_tfresidentaddress = AV23TFResidentAddress;
         AV74Residentwwds_11_tfresidentaddress_sel = AV24TFResidentAddress_Sel;
         AV75Residentwwds_12_tfresidentphone = AV25TFResidentPhone;
         AV76Residentwwds_13_tfresidentphone_sel = AV26TFResidentPhone_Sel;
         AV77Residentwwds_14_tfresidenttypename = AV29TFResidentTypeName;
         AV78Residentwwds_15_tfresidenttypename_sel = AV30TFResidentTypeName_Sel;
         AV79Udparg16 = new getloggedinusercustomerid(context).executeUdp( );
         AV80Udparg17 = new getreceptionistlocationid(context).executeUdp( );
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV64Residentwwds_1_filterfulltext ,
                                              AV66Residentwwds_3_tfresidentbsnnumber_sel ,
                                              AV65Residentwwds_2_tfresidentbsnnumber ,
                                              AV68Residentwwds_5_tfresidentgivenname_sel ,
                                              AV67Residentwwds_4_tfresidentgivenname ,
                                              AV70Residentwwds_7_tfresidentlastname_sel ,
                                              AV69Residentwwds_6_tfresidentlastname ,
                                              AV72Residentwwds_9_tfresidentemail_sel ,
                                              AV71Residentwwds_8_tfresidentemail ,
                                              AV74Residentwwds_11_tfresidentaddress_sel ,
                                              AV73Residentwwds_10_tfresidentaddress ,
                                              AV76Residentwwds_13_tfresidentphone_sel ,
                                              AV75Residentwwds_12_tfresidentphone ,
                                              AV78Residentwwds_15_tfresidenttypename_sel ,
                                              AV77Residentwwds_14_tfresidenttypename ,
                                              A40ResidentBsnNumber ,
                                              A33ResidentGivenName ,
                                              A34ResidentLastName ,
                                              A36ResidentEmail ,
                                              A37ResidentAddress ,
                                              A38ResidentPhone ,
                                              A83ResidentTypeName ,
                                              A1CustomerId ,
                                              AV79Udparg16 ,
                                              A18CustomerLocationId ,
                                              AV80Udparg17 } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV65Residentwwds_2_tfresidentbsnnumber = StringUtil.Concat( StringUtil.RTrim( AV65Residentwwds_2_tfresidentbsnnumber), "%", "");
         lV67Residentwwds_4_tfresidentgivenname = StringUtil.Concat( StringUtil.RTrim( AV67Residentwwds_4_tfresidentgivenname), "%", "");
         lV69Residentwwds_6_tfresidentlastname = StringUtil.Concat( StringUtil.RTrim( AV69Residentwwds_6_tfresidentlastname), "%", "");
         lV71Residentwwds_8_tfresidentemail = StringUtil.Concat( StringUtil.RTrim( AV71Residentwwds_8_tfresidentemail), "%", "");
         lV73Residentwwds_10_tfresidentaddress = StringUtil.Concat( StringUtil.RTrim( AV73Residentwwds_10_tfresidentaddress), "%", "");
         lV75Residentwwds_12_tfresidentphone = StringUtil.PadR( StringUtil.RTrim( AV75Residentwwds_12_tfresidentphone), 20, "%");
         lV77Residentwwds_14_tfresidenttypename = StringUtil.Concat( StringUtil.RTrim( AV77Residentwwds_14_tfresidenttypename), "%", "");
         /* Using cursor P002D4 */
         pr_default.execute(2, new Object[] {AV79Udparg16, AV80Udparg17, lV64Residentwwds_1_filterfulltext, lV64Residentwwds_1_filterfulltext, lV64Residentwwds_1_filterfulltext, lV64Residentwwds_1_filterfulltext, lV64Residentwwds_1_filterfulltext, lV64Residentwwds_1_filterfulltext, lV64Residentwwds_1_filterfulltext, lV65Residentwwds_2_tfresidentbsnnumber, AV66Residentwwds_3_tfresidentbsnnumber_sel, lV67Residentwwds_4_tfresidentgivenname, AV68Residentwwds_5_tfresidentgivenname_sel, lV69Residentwwds_6_tfresidentlastname, AV70Residentwwds_7_tfresidentlastname_sel, lV71Residentwwds_8_tfresidentemail, AV72Residentwwds_9_tfresidentemail_sel, lV73Residentwwds_10_tfresidentaddress, AV74Residentwwds_11_tfresidentaddress_sel, lV75Residentwwds_12_tfresidentphone, AV76Residentwwds_13_tfresidentphone_sel, lV77Residentwwds_14_tfresidenttypename, AV78Residentwwds_15_tfresidenttypename_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK2D6 = false;
            A82ResidentTypeId = P002D4_A82ResidentTypeId[0];
            A1CustomerId = P002D4_A1CustomerId[0];
            A18CustomerLocationId = P002D4_A18CustomerLocationId[0];
            A34ResidentLastName = P002D4_A34ResidentLastName[0];
            A83ResidentTypeName = P002D4_A83ResidentTypeName[0];
            A38ResidentPhone = P002D4_A38ResidentPhone[0];
            n38ResidentPhone = P002D4_n38ResidentPhone[0];
            A37ResidentAddress = P002D4_A37ResidentAddress[0];
            n37ResidentAddress = P002D4_n37ResidentAddress[0];
            A36ResidentEmail = P002D4_A36ResidentEmail[0];
            A33ResidentGivenName = P002D4_A33ResidentGivenName[0];
            A40ResidentBsnNumber = P002D4_A40ResidentBsnNumber[0];
            A31ResidentId = P002D4_A31ResidentId[0];
            A83ResidentTypeName = P002D4_A83ResidentTypeName[0];
            AV41count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P002D4_A34ResidentLastName[0], A34ResidentLastName) == 0 ) )
            {
               BRK2D6 = false;
               A31ResidentId = P002D4_A31ResidentId[0];
               AV41count = (long)(AV41count+1);
               BRK2D6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV32SkipItems) )
            {
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A34ResidentLastName)) ? "<#Empty#>" : A34ResidentLastName);
               AV37Options.Add(AV36Option, 0);
               AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV37Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV32SkipItems = (short)(AV32SkipItems-1);
            }
            if ( ! BRK2D6 )
            {
               BRK2D6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADRESIDENTEMAILOPTIONS' Routine */
         returnInSub = false;
         AV21TFResidentEmail = AV31SearchTxt;
         AV22TFResidentEmail_Sel = "";
         AV64Residentwwds_1_filterfulltext = AV53FilterFullText;
         AV65Residentwwds_2_tfresidentbsnnumber = AV13TFResidentBsnNumber;
         AV66Residentwwds_3_tfresidentbsnnumber_sel = AV14TFResidentBsnNumber_Sel;
         AV67Residentwwds_4_tfresidentgivenname = AV15TFResidentGivenName;
         AV68Residentwwds_5_tfresidentgivenname_sel = AV16TFResidentGivenName_Sel;
         AV69Residentwwds_6_tfresidentlastname = AV17TFResidentLastName;
         AV70Residentwwds_7_tfresidentlastname_sel = AV18TFResidentLastName_Sel;
         AV71Residentwwds_8_tfresidentemail = AV21TFResidentEmail;
         AV72Residentwwds_9_tfresidentemail_sel = AV22TFResidentEmail_Sel;
         AV73Residentwwds_10_tfresidentaddress = AV23TFResidentAddress;
         AV74Residentwwds_11_tfresidentaddress_sel = AV24TFResidentAddress_Sel;
         AV75Residentwwds_12_tfresidentphone = AV25TFResidentPhone;
         AV76Residentwwds_13_tfresidentphone_sel = AV26TFResidentPhone_Sel;
         AV77Residentwwds_14_tfresidenttypename = AV29TFResidentTypeName;
         AV78Residentwwds_15_tfresidenttypename_sel = AV30TFResidentTypeName_Sel;
         AV79Udparg16 = new getloggedinusercustomerid(context).executeUdp( );
         AV80Udparg17 = new getreceptionistlocationid(context).executeUdp( );
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV64Residentwwds_1_filterfulltext ,
                                              AV66Residentwwds_3_tfresidentbsnnumber_sel ,
                                              AV65Residentwwds_2_tfresidentbsnnumber ,
                                              AV68Residentwwds_5_tfresidentgivenname_sel ,
                                              AV67Residentwwds_4_tfresidentgivenname ,
                                              AV70Residentwwds_7_tfresidentlastname_sel ,
                                              AV69Residentwwds_6_tfresidentlastname ,
                                              AV72Residentwwds_9_tfresidentemail_sel ,
                                              AV71Residentwwds_8_tfresidentemail ,
                                              AV74Residentwwds_11_tfresidentaddress_sel ,
                                              AV73Residentwwds_10_tfresidentaddress ,
                                              AV76Residentwwds_13_tfresidentphone_sel ,
                                              AV75Residentwwds_12_tfresidentphone ,
                                              AV78Residentwwds_15_tfresidenttypename_sel ,
                                              AV77Residentwwds_14_tfresidenttypename ,
                                              A40ResidentBsnNumber ,
                                              A33ResidentGivenName ,
                                              A34ResidentLastName ,
                                              A36ResidentEmail ,
                                              A37ResidentAddress ,
                                              A38ResidentPhone ,
                                              A83ResidentTypeName ,
                                              A1CustomerId ,
                                              AV79Udparg16 ,
                                              A18CustomerLocationId ,
                                              AV80Udparg17 } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV65Residentwwds_2_tfresidentbsnnumber = StringUtil.Concat( StringUtil.RTrim( AV65Residentwwds_2_tfresidentbsnnumber), "%", "");
         lV67Residentwwds_4_tfresidentgivenname = StringUtil.Concat( StringUtil.RTrim( AV67Residentwwds_4_tfresidentgivenname), "%", "");
         lV69Residentwwds_6_tfresidentlastname = StringUtil.Concat( StringUtil.RTrim( AV69Residentwwds_6_tfresidentlastname), "%", "");
         lV71Residentwwds_8_tfresidentemail = StringUtil.Concat( StringUtil.RTrim( AV71Residentwwds_8_tfresidentemail), "%", "");
         lV73Residentwwds_10_tfresidentaddress = StringUtil.Concat( StringUtil.RTrim( AV73Residentwwds_10_tfresidentaddress), "%", "");
         lV75Residentwwds_12_tfresidentphone = StringUtil.PadR( StringUtil.RTrim( AV75Residentwwds_12_tfresidentphone), 20, "%");
         lV77Residentwwds_14_tfresidenttypename = StringUtil.Concat( StringUtil.RTrim( AV77Residentwwds_14_tfresidenttypename), "%", "");
         /* Using cursor P002D5 */
         pr_default.execute(3, new Object[] {AV79Udparg16, AV80Udparg17, lV64Residentwwds_1_filterfulltext, lV64Residentwwds_1_filterfulltext, lV64Residentwwds_1_filterfulltext, lV64Residentwwds_1_filterfulltext, lV64Residentwwds_1_filterfulltext, lV64Residentwwds_1_filterfulltext, lV64Residentwwds_1_filterfulltext, lV65Residentwwds_2_tfresidentbsnnumber, AV66Residentwwds_3_tfresidentbsnnumber_sel, lV67Residentwwds_4_tfresidentgivenname, AV68Residentwwds_5_tfresidentgivenname_sel, lV69Residentwwds_6_tfresidentlastname, AV70Residentwwds_7_tfresidentlastname_sel, lV71Residentwwds_8_tfresidentemail, AV72Residentwwds_9_tfresidentemail_sel, lV73Residentwwds_10_tfresidentaddress, AV74Residentwwds_11_tfresidentaddress_sel, lV75Residentwwds_12_tfresidentphone, AV76Residentwwds_13_tfresidentphone_sel, lV77Residentwwds_14_tfresidenttypename, AV78Residentwwds_15_tfresidenttypename_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK2D8 = false;
            A82ResidentTypeId = P002D5_A82ResidentTypeId[0];
            A1CustomerId = P002D5_A1CustomerId[0];
            A18CustomerLocationId = P002D5_A18CustomerLocationId[0];
            A36ResidentEmail = P002D5_A36ResidentEmail[0];
            A83ResidentTypeName = P002D5_A83ResidentTypeName[0];
            A38ResidentPhone = P002D5_A38ResidentPhone[0];
            n38ResidentPhone = P002D5_n38ResidentPhone[0];
            A37ResidentAddress = P002D5_A37ResidentAddress[0];
            n37ResidentAddress = P002D5_n37ResidentAddress[0];
            A34ResidentLastName = P002D5_A34ResidentLastName[0];
            A33ResidentGivenName = P002D5_A33ResidentGivenName[0];
            A40ResidentBsnNumber = P002D5_A40ResidentBsnNumber[0];
            A31ResidentId = P002D5_A31ResidentId[0];
            A83ResidentTypeName = P002D5_A83ResidentTypeName[0];
            AV41count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P002D5_A36ResidentEmail[0], A36ResidentEmail) == 0 ) )
            {
               BRK2D8 = false;
               A31ResidentId = P002D5_A31ResidentId[0];
               AV41count = (long)(AV41count+1);
               BRK2D8 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV32SkipItems) )
            {
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A36ResidentEmail)) ? "<#Empty#>" : A36ResidentEmail);
               AV37Options.Add(AV36Option, 0);
               AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV37Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV32SkipItems = (short)(AV32SkipItems-1);
            }
            if ( ! BRK2D8 )
            {
               BRK2D8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADRESIDENTADDRESSOPTIONS' Routine */
         returnInSub = false;
         AV23TFResidentAddress = AV31SearchTxt;
         AV24TFResidentAddress_Sel = "";
         AV64Residentwwds_1_filterfulltext = AV53FilterFullText;
         AV65Residentwwds_2_tfresidentbsnnumber = AV13TFResidentBsnNumber;
         AV66Residentwwds_3_tfresidentbsnnumber_sel = AV14TFResidentBsnNumber_Sel;
         AV67Residentwwds_4_tfresidentgivenname = AV15TFResidentGivenName;
         AV68Residentwwds_5_tfresidentgivenname_sel = AV16TFResidentGivenName_Sel;
         AV69Residentwwds_6_tfresidentlastname = AV17TFResidentLastName;
         AV70Residentwwds_7_tfresidentlastname_sel = AV18TFResidentLastName_Sel;
         AV71Residentwwds_8_tfresidentemail = AV21TFResidentEmail;
         AV72Residentwwds_9_tfresidentemail_sel = AV22TFResidentEmail_Sel;
         AV73Residentwwds_10_tfresidentaddress = AV23TFResidentAddress;
         AV74Residentwwds_11_tfresidentaddress_sel = AV24TFResidentAddress_Sel;
         AV75Residentwwds_12_tfresidentphone = AV25TFResidentPhone;
         AV76Residentwwds_13_tfresidentphone_sel = AV26TFResidentPhone_Sel;
         AV77Residentwwds_14_tfresidenttypename = AV29TFResidentTypeName;
         AV78Residentwwds_15_tfresidenttypename_sel = AV30TFResidentTypeName_Sel;
         AV79Udparg16 = new getloggedinusercustomerid(context).executeUdp( );
         AV80Udparg17 = new getreceptionistlocationid(context).executeUdp( );
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV64Residentwwds_1_filterfulltext ,
                                              AV66Residentwwds_3_tfresidentbsnnumber_sel ,
                                              AV65Residentwwds_2_tfresidentbsnnumber ,
                                              AV68Residentwwds_5_tfresidentgivenname_sel ,
                                              AV67Residentwwds_4_tfresidentgivenname ,
                                              AV70Residentwwds_7_tfresidentlastname_sel ,
                                              AV69Residentwwds_6_tfresidentlastname ,
                                              AV72Residentwwds_9_tfresidentemail_sel ,
                                              AV71Residentwwds_8_tfresidentemail ,
                                              AV74Residentwwds_11_tfresidentaddress_sel ,
                                              AV73Residentwwds_10_tfresidentaddress ,
                                              AV76Residentwwds_13_tfresidentphone_sel ,
                                              AV75Residentwwds_12_tfresidentphone ,
                                              AV78Residentwwds_15_tfresidenttypename_sel ,
                                              AV77Residentwwds_14_tfresidenttypename ,
                                              A40ResidentBsnNumber ,
                                              A33ResidentGivenName ,
                                              A34ResidentLastName ,
                                              A36ResidentEmail ,
                                              A37ResidentAddress ,
                                              A38ResidentPhone ,
                                              A83ResidentTypeName ,
                                              A1CustomerId ,
                                              AV79Udparg16 ,
                                              A18CustomerLocationId ,
                                              AV80Udparg17 } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV65Residentwwds_2_tfresidentbsnnumber = StringUtil.Concat( StringUtil.RTrim( AV65Residentwwds_2_tfresidentbsnnumber), "%", "");
         lV67Residentwwds_4_tfresidentgivenname = StringUtil.Concat( StringUtil.RTrim( AV67Residentwwds_4_tfresidentgivenname), "%", "");
         lV69Residentwwds_6_tfresidentlastname = StringUtil.Concat( StringUtil.RTrim( AV69Residentwwds_6_tfresidentlastname), "%", "");
         lV71Residentwwds_8_tfresidentemail = StringUtil.Concat( StringUtil.RTrim( AV71Residentwwds_8_tfresidentemail), "%", "");
         lV73Residentwwds_10_tfresidentaddress = StringUtil.Concat( StringUtil.RTrim( AV73Residentwwds_10_tfresidentaddress), "%", "");
         lV75Residentwwds_12_tfresidentphone = StringUtil.PadR( StringUtil.RTrim( AV75Residentwwds_12_tfresidentphone), 20, "%");
         lV77Residentwwds_14_tfresidenttypename = StringUtil.Concat( StringUtil.RTrim( AV77Residentwwds_14_tfresidenttypename), "%", "");
         /* Using cursor P002D6 */
         pr_default.execute(4, new Object[] {AV79Udparg16, AV80Udparg17, lV64Residentwwds_1_filterfulltext, lV64Residentwwds_1_filterfulltext, lV64Residentwwds_1_filterfulltext, lV64Residentwwds_1_filterfulltext, lV64Residentwwds_1_filterfulltext, lV64Residentwwds_1_filterfulltext, lV64Residentwwds_1_filterfulltext, lV65Residentwwds_2_tfresidentbsnnumber, AV66Residentwwds_3_tfresidentbsnnumber_sel, lV67Residentwwds_4_tfresidentgivenname, AV68Residentwwds_5_tfresidentgivenname_sel, lV69Residentwwds_6_tfresidentlastname, AV70Residentwwds_7_tfresidentlastname_sel, lV71Residentwwds_8_tfresidentemail, AV72Residentwwds_9_tfresidentemail_sel, lV73Residentwwds_10_tfresidentaddress, AV74Residentwwds_11_tfresidentaddress_sel, lV75Residentwwds_12_tfresidentphone, AV76Residentwwds_13_tfresidentphone_sel, lV77Residentwwds_14_tfresidenttypename, AV78Residentwwds_15_tfresidenttypename_sel});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRK2D10 = false;
            A82ResidentTypeId = P002D6_A82ResidentTypeId[0];
            A1CustomerId = P002D6_A1CustomerId[0];
            A18CustomerLocationId = P002D6_A18CustomerLocationId[0];
            A37ResidentAddress = P002D6_A37ResidentAddress[0];
            n37ResidentAddress = P002D6_n37ResidentAddress[0];
            A83ResidentTypeName = P002D6_A83ResidentTypeName[0];
            A38ResidentPhone = P002D6_A38ResidentPhone[0];
            n38ResidentPhone = P002D6_n38ResidentPhone[0];
            A36ResidentEmail = P002D6_A36ResidentEmail[0];
            A34ResidentLastName = P002D6_A34ResidentLastName[0];
            A33ResidentGivenName = P002D6_A33ResidentGivenName[0];
            A40ResidentBsnNumber = P002D6_A40ResidentBsnNumber[0];
            A31ResidentId = P002D6_A31ResidentId[0];
            A83ResidentTypeName = P002D6_A83ResidentTypeName[0];
            AV41count = 0;
            while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P002D6_A37ResidentAddress[0], A37ResidentAddress) == 0 ) )
            {
               BRK2D10 = false;
               A31ResidentId = P002D6_A31ResidentId[0];
               AV41count = (long)(AV41count+1);
               BRK2D10 = true;
               pr_default.readNext(4);
            }
            if ( (0==AV32SkipItems) )
            {
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A37ResidentAddress)) ? "<#Empty#>" : A37ResidentAddress);
               AV37Options.Add(AV36Option, 0);
               AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV37Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV32SkipItems = (short)(AV32SkipItems-1);
            }
            if ( ! BRK2D10 )
            {
               BRK2D10 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
      }

      protected void S171( )
      {
         /* 'LOADRESIDENTPHONEOPTIONS' Routine */
         returnInSub = false;
         AV25TFResidentPhone = AV31SearchTxt;
         AV26TFResidentPhone_Sel = "";
         AV64Residentwwds_1_filterfulltext = AV53FilterFullText;
         AV65Residentwwds_2_tfresidentbsnnumber = AV13TFResidentBsnNumber;
         AV66Residentwwds_3_tfresidentbsnnumber_sel = AV14TFResidentBsnNumber_Sel;
         AV67Residentwwds_4_tfresidentgivenname = AV15TFResidentGivenName;
         AV68Residentwwds_5_tfresidentgivenname_sel = AV16TFResidentGivenName_Sel;
         AV69Residentwwds_6_tfresidentlastname = AV17TFResidentLastName;
         AV70Residentwwds_7_tfresidentlastname_sel = AV18TFResidentLastName_Sel;
         AV71Residentwwds_8_tfresidentemail = AV21TFResidentEmail;
         AV72Residentwwds_9_tfresidentemail_sel = AV22TFResidentEmail_Sel;
         AV73Residentwwds_10_tfresidentaddress = AV23TFResidentAddress;
         AV74Residentwwds_11_tfresidentaddress_sel = AV24TFResidentAddress_Sel;
         AV75Residentwwds_12_tfresidentphone = AV25TFResidentPhone;
         AV76Residentwwds_13_tfresidentphone_sel = AV26TFResidentPhone_Sel;
         AV77Residentwwds_14_tfresidenttypename = AV29TFResidentTypeName;
         AV78Residentwwds_15_tfresidenttypename_sel = AV30TFResidentTypeName_Sel;
         AV79Udparg16 = new getloggedinusercustomerid(context).executeUdp( );
         AV80Udparg17 = new getreceptionistlocationid(context).executeUdp( );
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              AV64Residentwwds_1_filterfulltext ,
                                              AV66Residentwwds_3_tfresidentbsnnumber_sel ,
                                              AV65Residentwwds_2_tfresidentbsnnumber ,
                                              AV68Residentwwds_5_tfresidentgivenname_sel ,
                                              AV67Residentwwds_4_tfresidentgivenname ,
                                              AV70Residentwwds_7_tfresidentlastname_sel ,
                                              AV69Residentwwds_6_tfresidentlastname ,
                                              AV72Residentwwds_9_tfresidentemail_sel ,
                                              AV71Residentwwds_8_tfresidentemail ,
                                              AV74Residentwwds_11_tfresidentaddress_sel ,
                                              AV73Residentwwds_10_tfresidentaddress ,
                                              AV76Residentwwds_13_tfresidentphone_sel ,
                                              AV75Residentwwds_12_tfresidentphone ,
                                              AV78Residentwwds_15_tfresidenttypename_sel ,
                                              AV77Residentwwds_14_tfresidenttypename ,
                                              A40ResidentBsnNumber ,
                                              A33ResidentGivenName ,
                                              A34ResidentLastName ,
                                              A36ResidentEmail ,
                                              A37ResidentAddress ,
                                              A38ResidentPhone ,
                                              A83ResidentTypeName ,
                                              A1CustomerId ,
                                              AV79Udparg16 ,
                                              A18CustomerLocationId ,
                                              AV80Udparg17 } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV65Residentwwds_2_tfresidentbsnnumber = StringUtil.Concat( StringUtil.RTrim( AV65Residentwwds_2_tfresidentbsnnumber), "%", "");
         lV67Residentwwds_4_tfresidentgivenname = StringUtil.Concat( StringUtil.RTrim( AV67Residentwwds_4_tfresidentgivenname), "%", "");
         lV69Residentwwds_6_tfresidentlastname = StringUtil.Concat( StringUtil.RTrim( AV69Residentwwds_6_tfresidentlastname), "%", "");
         lV71Residentwwds_8_tfresidentemail = StringUtil.Concat( StringUtil.RTrim( AV71Residentwwds_8_tfresidentemail), "%", "");
         lV73Residentwwds_10_tfresidentaddress = StringUtil.Concat( StringUtil.RTrim( AV73Residentwwds_10_tfresidentaddress), "%", "");
         lV75Residentwwds_12_tfresidentphone = StringUtil.PadR( StringUtil.RTrim( AV75Residentwwds_12_tfresidentphone), 20, "%");
         lV77Residentwwds_14_tfresidenttypename = StringUtil.Concat( StringUtil.RTrim( AV77Residentwwds_14_tfresidenttypename), "%", "");
         /* Using cursor P002D7 */
         pr_default.execute(5, new Object[] {AV79Udparg16, AV80Udparg17, lV64Residentwwds_1_filterfulltext, lV64Residentwwds_1_filterfulltext, lV64Residentwwds_1_filterfulltext, lV64Residentwwds_1_filterfulltext, lV64Residentwwds_1_filterfulltext, lV64Residentwwds_1_filterfulltext, lV64Residentwwds_1_filterfulltext, lV65Residentwwds_2_tfresidentbsnnumber, AV66Residentwwds_3_tfresidentbsnnumber_sel, lV67Residentwwds_4_tfresidentgivenname, AV68Residentwwds_5_tfresidentgivenname_sel, lV69Residentwwds_6_tfresidentlastname, AV70Residentwwds_7_tfresidentlastname_sel, lV71Residentwwds_8_tfresidentemail, AV72Residentwwds_9_tfresidentemail_sel, lV73Residentwwds_10_tfresidentaddress, AV74Residentwwds_11_tfresidentaddress_sel, lV75Residentwwds_12_tfresidentphone, AV76Residentwwds_13_tfresidentphone_sel, lV77Residentwwds_14_tfresidenttypename, AV78Residentwwds_15_tfresidenttypename_sel});
         while ( (pr_default.getStatus(5) != 101) )
         {
            BRK2D12 = false;
            A82ResidentTypeId = P002D7_A82ResidentTypeId[0];
            A1CustomerId = P002D7_A1CustomerId[0];
            A18CustomerLocationId = P002D7_A18CustomerLocationId[0];
            A38ResidentPhone = P002D7_A38ResidentPhone[0];
            n38ResidentPhone = P002D7_n38ResidentPhone[0];
            A83ResidentTypeName = P002D7_A83ResidentTypeName[0];
            A37ResidentAddress = P002D7_A37ResidentAddress[0];
            n37ResidentAddress = P002D7_n37ResidentAddress[0];
            A36ResidentEmail = P002D7_A36ResidentEmail[0];
            A34ResidentLastName = P002D7_A34ResidentLastName[0];
            A33ResidentGivenName = P002D7_A33ResidentGivenName[0];
            A40ResidentBsnNumber = P002D7_A40ResidentBsnNumber[0];
            A31ResidentId = P002D7_A31ResidentId[0];
            A83ResidentTypeName = P002D7_A83ResidentTypeName[0];
            AV41count = 0;
            while ( (pr_default.getStatus(5) != 101) && ( StringUtil.StrCmp(P002D7_A38ResidentPhone[0], A38ResidentPhone) == 0 ) )
            {
               BRK2D12 = false;
               A31ResidentId = P002D7_A31ResidentId[0];
               AV41count = (long)(AV41count+1);
               BRK2D12 = true;
               pr_default.readNext(5);
            }
            if ( (0==AV32SkipItems) )
            {
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A38ResidentPhone)) ? "<#Empty#>" : A38ResidentPhone);
               AV37Options.Add(AV36Option, 0);
               AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV37Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV32SkipItems = (short)(AV32SkipItems-1);
            }
            if ( ! BRK2D12 )
            {
               BRK2D12 = true;
               pr_default.readNext(5);
            }
         }
         pr_default.close(5);
      }

      protected void S181( )
      {
         /* 'LOADRESIDENTTYPENAMEOPTIONS' Routine */
         returnInSub = false;
         AV29TFResidentTypeName = AV31SearchTxt;
         AV30TFResidentTypeName_Sel = "";
         AV64Residentwwds_1_filterfulltext = AV53FilterFullText;
         AV65Residentwwds_2_tfresidentbsnnumber = AV13TFResidentBsnNumber;
         AV66Residentwwds_3_tfresidentbsnnumber_sel = AV14TFResidentBsnNumber_Sel;
         AV67Residentwwds_4_tfresidentgivenname = AV15TFResidentGivenName;
         AV68Residentwwds_5_tfresidentgivenname_sel = AV16TFResidentGivenName_Sel;
         AV69Residentwwds_6_tfresidentlastname = AV17TFResidentLastName;
         AV70Residentwwds_7_tfresidentlastname_sel = AV18TFResidentLastName_Sel;
         AV71Residentwwds_8_tfresidentemail = AV21TFResidentEmail;
         AV72Residentwwds_9_tfresidentemail_sel = AV22TFResidentEmail_Sel;
         AV73Residentwwds_10_tfresidentaddress = AV23TFResidentAddress;
         AV74Residentwwds_11_tfresidentaddress_sel = AV24TFResidentAddress_Sel;
         AV75Residentwwds_12_tfresidentphone = AV25TFResidentPhone;
         AV76Residentwwds_13_tfresidentphone_sel = AV26TFResidentPhone_Sel;
         AV77Residentwwds_14_tfresidenttypename = AV29TFResidentTypeName;
         AV78Residentwwds_15_tfresidenttypename_sel = AV30TFResidentTypeName_Sel;
         AV79Udparg16 = new getloggedinusercustomerid(context).executeUdp( );
         AV80Udparg17 = new getreceptionistlocationid(context).executeUdp( );
         pr_default.dynParam(6, new Object[]{ new Object[]{
                                              AV64Residentwwds_1_filterfulltext ,
                                              AV66Residentwwds_3_tfresidentbsnnumber_sel ,
                                              AV65Residentwwds_2_tfresidentbsnnumber ,
                                              AV68Residentwwds_5_tfresidentgivenname_sel ,
                                              AV67Residentwwds_4_tfresidentgivenname ,
                                              AV70Residentwwds_7_tfresidentlastname_sel ,
                                              AV69Residentwwds_6_tfresidentlastname ,
                                              AV72Residentwwds_9_tfresidentemail_sel ,
                                              AV71Residentwwds_8_tfresidentemail ,
                                              AV74Residentwwds_11_tfresidentaddress_sel ,
                                              AV73Residentwwds_10_tfresidentaddress ,
                                              AV76Residentwwds_13_tfresidentphone_sel ,
                                              AV75Residentwwds_12_tfresidentphone ,
                                              AV78Residentwwds_15_tfresidenttypename_sel ,
                                              AV77Residentwwds_14_tfresidenttypename ,
                                              A40ResidentBsnNumber ,
                                              A33ResidentGivenName ,
                                              A34ResidentLastName ,
                                              A36ResidentEmail ,
                                              A37ResidentAddress ,
                                              A38ResidentPhone ,
                                              A83ResidentTypeName ,
                                              A1CustomerId ,
                                              AV79Udparg16 ,
                                              A18CustomerLocationId ,
                                              AV80Udparg17 } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV64Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Residentwwds_1_filterfulltext), "%", "");
         lV65Residentwwds_2_tfresidentbsnnumber = StringUtil.Concat( StringUtil.RTrim( AV65Residentwwds_2_tfresidentbsnnumber), "%", "");
         lV67Residentwwds_4_tfresidentgivenname = StringUtil.Concat( StringUtil.RTrim( AV67Residentwwds_4_tfresidentgivenname), "%", "");
         lV69Residentwwds_6_tfresidentlastname = StringUtil.Concat( StringUtil.RTrim( AV69Residentwwds_6_tfresidentlastname), "%", "");
         lV71Residentwwds_8_tfresidentemail = StringUtil.Concat( StringUtil.RTrim( AV71Residentwwds_8_tfresidentemail), "%", "");
         lV73Residentwwds_10_tfresidentaddress = StringUtil.Concat( StringUtil.RTrim( AV73Residentwwds_10_tfresidentaddress), "%", "");
         lV75Residentwwds_12_tfresidentphone = StringUtil.PadR( StringUtil.RTrim( AV75Residentwwds_12_tfresidentphone), 20, "%");
         lV77Residentwwds_14_tfresidenttypename = StringUtil.Concat( StringUtil.RTrim( AV77Residentwwds_14_tfresidenttypename), "%", "");
         /* Using cursor P002D8 */
         pr_default.execute(6, new Object[] {AV79Udparg16, AV80Udparg17, lV64Residentwwds_1_filterfulltext, lV64Residentwwds_1_filterfulltext, lV64Residentwwds_1_filterfulltext, lV64Residentwwds_1_filterfulltext, lV64Residentwwds_1_filterfulltext, lV64Residentwwds_1_filterfulltext, lV64Residentwwds_1_filterfulltext, lV65Residentwwds_2_tfresidentbsnnumber, AV66Residentwwds_3_tfresidentbsnnumber_sel, lV67Residentwwds_4_tfresidentgivenname, AV68Residentwwds_5_tfresidentgivenname_sel, lV69Residentwwds_6_tfresidentlastname, AV70Residentwwds_7_tfresidentlastname_sel, lV71Residentwwds_8_tfresidentemail, AV72Residentwwds_9_tfresidentemail_sel, lV73Residentwwds_10_tfresidentaddress, AV74Residentwwds_11_tfresidentaddress_sel, lV75Residentwwds_12_tfresidentphone, AV76Residentwwds_13_tfresidentphone_sel, lV77Residentwwds_14_tfresidenttypename, AV78Residentwwds_15_tfresidenttypename_sel});
         while ( (pr_default.getStatus(6) != 101) )
         {
            BRK2D14 = false;
            A82ResidentTypeId = P002D8_A82ResidentTypeId[0];
            A18CustomerLocationId = P002D8_A18CustomerLocationId[0];
            A1CustomerId = P002D8_A1CustomerId[0];
            A83ResidentTypeName = P002D8_A83ResidentTypeName[0];
            A38ResidentPhone = P002D8_A38ResidentPhone[0];
            n38ResidentPhone = P002D8_n38ResidentPhone[0];
            A37ResidentAddress = P002D8_A37ResidentAddress[0];
            n37ResidentAddress = P002D8_n37ResidentAddress[0];
            A36ResidentEmail = P002D8_A36ResidentEmail[0];
            A34ResidentLastName = P002D8_A34ResidentLastName[0];
            A33ResidentGivenName = P002D8_A33ResidentGivenName[0];
            A40ResidentBsnNumber = P002D8_A40ResidentBsnNumber[0];
            A31ResidentId = P002D8_A31ResidentId[0];
            A83ResidentTypeName = P002D8_A83ResidentTypeName[0];
            AV41count = 0;
            while ( (pr_default.getStatus(6) != 101) && ( P002D8_A82ResidentTypeId[0] == A82ResidentTypeId ) )
            {
               BRK2D14 = false;
               A31ResidentId = P002D8_A31ResidentId[0];
               AV41count = (long)(AV41count+1);
               BRK2D14 = true;
               pr_default.readNext(6);
            }
            AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A83ResidentTypeName)) ? "<#Empty#>" : A83ResidentTypeName);
            AV35InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV36Option, "<#Empty#>") != 0 ) && ( AV35InsertIndex <= AV37Options.Count ) && ( ( StringUtil.StrCmp(((string)AV37Options.Item(AV35InsertIndex)), AV36Option) < 0 ) || ( StringUtil.StrCmp(((string)AV37Options.Item(AV35InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV35InsertIndex = (int)(AV35InsertIndex+1);
            }
            AV37Options.Add(AV36Option, AV35InsertIndex);
            AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), AV35InsertIndex);
            if ( AV37Options.Count == AV32SkipItems + 11 )
            {
               AV37Options.RemoveItem(AV37Options.Count);
               AV40OptionIndexes.RemoveItem(AV40OptionIndexes.Count);
            }
            if ( ! BRK2D14 )
            {
               BRK2D14 = true;
               pr_default.readNext(6);
            }
         }
         pr_default.close(6);
         while ( AV32SkipItems > 0 )
         {
            AV37Options.RemoveItem(1);
            AV40OptionIndexes.RemoveItem(1);
            AV32SkipItems = (short)(AV32SkipItems-1);
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
         AV50OptionsJson = "";
         AV51OptionsDescJson = "";
         AV52OptionIndexesJson = "";
         AV37Options = new GxSimpleCollection<string>();
         AV39OptionsDesc = new GxSimpleCollection<string>();
         AV40OptionIndexes = new GxSimpleCollection<string>();
         AV31SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV42Session = context.GetSession();
         AV44GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV45GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV53FilterFullText = "";
         AV13TFResidentBsnNumber = "";
         AV14TFResidentBsnNumber_Sel = "";
         AV15TFResidentGivenName = "";
         AV16TFResidentGivenName_Sel = "";
         AV17TFResidentLastName = "";
         AV18TFResidentLastName_Sel = "";
         AV21TFResidentEmail = "";
         AV22TFResidentEmail_Sel = "";
         AV23TFResidentAddress = "";
         AV24TFResidentAddress_Sel = "";
         AV25TFResidentPhone = "";
         AV26TFResidentPhone_Sel = "";
         AV29TFResidentTypeName = "";
         AV30TFResidentTypeName_Sel = "";
         AV64Residentwwds_1_filterfulltext = "";
         AV65Residentwwds_2_tfresidentbsnnumber = "";
         AV66Residentwwds_3_tfresidentbsnnumber_sel = "";
         AV67Residentwwds_4_tfresidentgivenname = "";
         AV68Residentwwds_5_tfresidentgivenname_sel = "";
         AV69Residentwwds_6_tfresidentlastname = "";
         AV70Residentwwds_7_tfresidentlastname_sel = "";
         AV71Residentwwds_8_tfresidentemail = "";
         AV72Residentwwds_9_tfresidentemail_sel = "";
         AV73Residentwwds_10_tfresidentaddress = "";
         AV74Residentwwds_11_tfresidentaddress_sel = "";
         AV75Residentwwds_12_tfresidentphone = "";
         AV76Residentwwds_13_tfresidentphone_sel = "";
         AV77Residentwwds_14_tfresidenttypename = "";
         AV78Residentwwds_15_tfresidenttypename_sel = "";
         scmdbuf = "";
         lV64Residentwwds_1_filterfulltext = "";
         lV65Residentwwds_2_tfresidentbsnnumber = "";
         lV67Residentwwds_4_tfresidentgivenname = "";
         lV69Residentwwds_6_tfresidentlastname = "";
         lV71Residentwwds_8_tfresidentemail = "";
         lV73Residentwwds_10_tfresidentaddress = "";
         lV75Residentwwds_12_tfresidentphone = "";
         lV77Residentwwds_14_tfresidenttypename = "";
         A40ResidentBsnNumber = "";
         A33ResidentGivenName = "";
         A34ResidentLastName = "";
         A36ResidentEmail = "";
         A37ResidentAddress = "";
         A38ResidentPhone = "";
         A83ResidentTypeName = "";
         P002D2_A82ResidentTypeId = new short[1] ;
         P002D2_A40ResidentBsnNumber = new string[] {""} ;
         P002D2_A18CustomerLocationId = new short[1] ;
         P002D2_A1CustomerId = new short[1] ;
         P002D2_A83ResidentTypeName = new string[] {""} ;
         P002D2_A38ResidentPhone = new string[] {""} ;
         P002D2_n38ResidentPhone = new bool[] {false} ;
         P002D2_A37ResidentAddress = new string[] {""} ;
         P002D2_n37ResidentAddress = new bool[] {false} ;
         P002D2_A36ResidentEmail = new string[] {""} ;
         P002D2_A34ResidentLastName = new string[] {""} ;
         P002D2_A33ResidentGivenName = new string[] {""} ;
         P002D2_A31ResidentId = new short[1] ;
         AV36Option = "";
         P002D3_A82ResidentTypeId = new short[1] ;
         P002D3_A1CustomerId = new short[1] ;
         P002D3_A18CustomerLocationId = new short[1] ;
         P002D3_A33ResidentGivenName = new string[] {""} ;
         P002D3_A83ResidentTypeName = new string[] {""} ;
         P002D3_A38ResidentPhone = new string[] {""} ;
         P002D3_n38ResidentPhone = new bool[] {false} ;
         P002D3_A37ResidentAddress = new string[] {""} ;
         P002D3_n37ResidentAddress = new bool[] {false} ;
         P002D3_A36ResidentEmail = new string[] {""} ;
         P002D3_A34ResidentLastName = new string[] {""} ;
         P002D3_A40ResidentBsnNumber = new string[] {""} ;
         P002D3_A31ResidentId = new short[1] ;
         P002D4_A82ResidentTypeId = new short[1] ;
         P002D4_A1CustomerId = new short[1] ;
         P002D4_A18CustomerLocationId = new short[1] ;
         P002D4_A34ResidentLastName = new string[] {""} ;
         P002D4_A83ResidentTypeName = new string[] {""} ;
         P002D4_A38ResidentPhone = new string[] {""} ;
         P002D4_n38ResidentPhone = new bool[] {false} ;
         P002D4_A37ResidentAddress = new string[] {""} ;
         P002D4_n37ResidentAddress = new bool[] {false} ;
         P002D4_A36ResidentEmail = new string[] {""} ;
         P002D4_A33ResidentGivenName = new string[] {""} ;
         P002D4_A40ResidentBsnNumber = new string[] {""} ;
         P002D4_A31ResidentId = new short[1] ;
         P002D5_A82ResidentTypeId = new short[1] ;
         P002D5_A1CustomerId = new short[1] ;
         P002D5_A18CustomerLocationId = new short[1] ;
         P002D5_A36ResidentEmail = new string[] {""} ;
         P002D5_A83ResidentTypeName = new string[] {""} ;
         P002D5_A38ResidentPhone = new string[] {""} ;
         P002D5_n38ResidentPhone = new bool[] {false} ;
         P002D5_A37ResidentAddress = new string[] {""} ;
         P002D5_n37ResidentAddress = new bool[] {false} ;
         P002D5_A34ResidentLastName = new string[] {""} ;
         P002D5_A33ResidentGivenName = new string[] {""} ;
         P002D5_A40ResidentBsnNumber = new string[] {""} ;
         P002D5_A31ResidentId = new short[1] ;
         P002D6_A82ResidentTypeId = new short[1] ;
         P002D6_A1CustomerId = new short[1] ;
         P002D6_A18CustomerLocationId = new short[1] ;
         P002D6_A37ResidentAddress = new string[] {""} ;
         P002D6_n37ResidentAddress = new bool[] {false} ;
         P002D6_A83ResidentTypeName = new string[] {""} ;
         P002D6_A38ResidentPhone = new string[] {""} ;
         P002D6_n38ResidentPhone = new bool[] {false} ;
         P002D6_A36ResidentEmail = new string[] {""} ;
         P002D6_A34ResidentLastName = new string[] {""} ;
         P002D6_A33ResidentGivenName = new string[] {""} ;
         P002D6_A40ResidentBsnNumber = new string[] {""} ;
         P002D6_A31ResidentId = new short[1] ;
         P002D7_A82ResidentTypeId = new short[1] ;
         P002D7_A1CustomerId = new short[1] ;
         P002D7_A18CustomerLocationId = new short[1] ;
         P002D7_A38ResidentPhone = new string[] {""} ;
         P002D7_n38ResidentPhone = new bool[] {false} ;
         P002D7_A83ResidentTypeName = new string[] {""} ;
         P002D7_A37ResidentAddress = new string[] {""} ;
         P002D7_n37ResidentAddress = new bool[] {false} ;
         P002D7_A36ResidentEmail = new string[] {""} ;
         P002D7_A34ResidentLastName = new string[] {""} ;
         P002D7_A33ResidentGivenName = new string[] {""} ;
         P002D7_A40ResidentBsnNumber = new string[] {""} ;
         P002D7_A31ResidentId = new short[1] ;
         P002D8_A82ResidentTypeId = new short[1] ;
         P002D8_A18CustomerLocationId = new short[1] ;
         P002D8_A1CustomerId = new short[1] ;
         P002D8_A83ResidentTypeName = new string[] {""} ;
         P002D8_A38ResidentPhone = new string[] {""} ;
         P002D8_n38ResidentPhone = new bool[] {false} ;
         P002D8_A37ResidentAddress = new string[] {""} ;
         P002D8_n37ResidentAddress = new bool[] {false} ;
         P002D8_A36ResidentEmail = new string[] {""} ;
         P002D8_A34ResidentLastName = new string[] {""} ;
         P002D8_A33ResidentGivenName = new string[] {""} ;
         P002D8_A40ResidentBsnNumber = new string[] {""} ;
         P002D8_A31ResidentId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.residentwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P002D2_A82ResidentTypeId, P002D2_A40ResidentBsnNumber, P002D2_A18CustomerLocationId, P002D2_A1CustomerId, P002D2_A83ResidentTypeName, P002D2_A38ResidentPhone, P002D2_n38ResidentPhone, P002D2_A37ResidentAddress, P002D2_n37ResidentAddress, P002D2_A36ResidentEmail,
               P002D2_A34ResidentLastName, P002D2_A33ResidentGivenName, P002D2_A31ResidentId
               }
               , new Object[] {
               P002D3_A82ResidentTypeId, P002D3_A1CustomerId, P002D3_A18CustomerLocationId, P002D3_A33ResidentGivenName, P002D3_A83ResidentTypeName, P002D3_A38ResidentPhone, P002D3_n38ResidentPhone, P002D3_A37ResidentAddress, P002D3_n37ResidentAddress, P002D3_A36ResidentEmail,
               P002D3_A34ResidentLastName, P002D3_A40ResidentBsnNumber, P002D3_A31ResidentId
               }
               , new Object[] {
               P002D4_A82ResidentTypeId, P002D4_A1CustomerId, P002D4_A18CustomerLocationId, P002D4_A34ResidentLastName, P002D4_A83ResidentTypeName, P002D4_A38ResidentPhone, P002D4_n38ResidentPhone, P002D4_A37ResidentAddress, P002D4_n37ResidentAddress, P002D4_A36ResidentEmail,
               P002D4_A33ResidentGivenName, P002D4_A40ResidentBsnNumber, P002D4_A31ResidentId
               }
               , new Object[] {
               P002D5_A82ResidentTypeId, P002D5_A1CustomerId, P002D5_A18CustomerLocationId, P002D5_A36ResidentEmail, P002D5_A83ResidentTypeName, P002D5_A38ResidentPhone, P002D5_n38ResidentPhone, P002D5_A37ResidentAddress, P002D5_n37ResidentAddress, P002D5_A34ResidentLastName,
               P002D5_A33ResidentGivenName, P002D5_A40ResidentBsnNumber, P002D5_A31ResidentId
               }
               , new Object[] {
               P002D6_A82ResidentTypeId, P002D6_A1CustomerId, P002D6_A18CustomerLocationId, P002D6_A37ResidentAddress, P002D6_n37ResidentAddress, P002D6_A83ResidentTypeName, P002D6_A38ResidentPhone, P002D6_n38ResidentPhone, P002D6_A36ResidentEmail, P002D6_A34ResidentLastName,
               P002D6_A33ResidentGivenName, P002D6_A40ResidentBsnNumber, P002D6_A31ResidentId
               }
               , new Object[] {
               P002D7_A82ResidentTypeId, P002D7_A1CustomerId, P002D7_A18CustomerLocationId, P002D7_A38ResidentPhone, P002D7_n38ResidentPhone, P002D7_A83ResidentTypeName, P002D7_A37ResidentAddress, P002D7_n37ResidentAddress, P002D7_A36ResidentEmail, P002D7_A34ResidentLastName,
               P002D7_A33ResidentGivenName, P002D7_A40ResidentBsnNumber, P002D7_A31ResidentId
               }
               , new Object[] {
               P002D8_A82ResidentTypeId, P002D8_A18CustomerLocationId, P002D8_A1CustomerId, P002D8_A83ResidentTypeName, P002D8_A38ResidentPhone, P002D8_n38ResidentPhone, P002D8_A37ResidentAddress, P002D8_n37ResidentAddress, P002D8_A36ResidentEmail, P002D8_A34ResidentLastName,
               P002D8_A33ResidentGivenName, P002D8_A40ResidentBsnNumber, P002D8_A31ResidentId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV34MaxItems ;
      private short AV33PageIndex ;
      private short AV32SkipItems ;
      private short AV79Udparg16 ;
      private short AV80Udparg17 ;
      private short A1CustomerId ;
      private short A18CustomerLocationId ;
      private short A82ResidentTypeId ;
      private short A31ResidentId ;
      private int AV62GXV1 ;
      private int AV35InsertIndex ;
      private long AV41count ;
      private string AV25TFResidentPhone ;
      private string AV26TFResidentPhone_Sel ;
      private string AV75Residentwwds_12_tfresidentphone ;
      private string AV76Residentwwds_13_tfresidentphone_sel ;
      private string scmdbuf ;
      private string lV75Residentwwds_12_tfresidentphone ;
      private string A38ResidentPhone ;
      private bool returnInSub ;
      private bool BRK2D2 ;
      private bool n38ResidentPhone ;
      private bool n37ResidentAddress ;
      private bool BRK2D4 ;
      private bool BRK2D6 ;
      private bool BRK2D8 ;
      private bool BRK2D10 ;
      private bool BRK2D12 ;
      private bool BRK2D14 ;
      private string AV50OptionsJson ;
      private string AV51OptionsDescJson ;
      private string AV52OptionIndexesJson ;
      private string AV47DDOName ;
      private string AV48SearchTxtParms ;
      private string AV49SearchTxtTo ;
      private string AV31SearchTxt ;
      private string AV53FilterFullText ;
      private string AV13TFResidentBsnNumber ;
      private string AV14TFResidentBsnNumber_Sel ;
      private string AV15TFResidentGivenName ;
      private string AV16TFResidentGivenName_Sel ;
      private string AV17TFResidentLastName ;
      private string AV18TFResidentLastName_Sel ;
      private string AV21TFResidentEmail ;
      private string AV22TFResidentEmail_Sel ;
      private string AV23TFResidentAddress ;
      private string AV24TFResidentAddress_Sel ;
      private string AV29TFResidentTypeName ;
      private string AV30TFResidentTypeName_Sel ;
      private string AV64Residentwwds_1_filterfulltext ;
      private string AV65Residentwwds_2_tfresidentbsnnumber ;
      private string AV66Residentwwds_3_tfresidentbsnnumber_sel ;
      private string AV67Residentwwds_4_tfresidentgivenname ;
      private string AV68Residentwwds_5_tfresidentgivenname_sel ;
      private string AV69Residentwwds_6_tfresidentlastname ;
      private string AV70Residentwwds_7_tfresidentlastname_sel ;
      private string AV71Residentwwds_8_tfresidentemail ;
      private string AV72Residentwwds_9_tfresidentemail_sel ;
      private string AV73Residentwwds_10_tfresidentaddress ;
      private string AV74Residentwwds_11_tfresidentaddress_sel ;
      private string AV77Residentwwds_14_tfresidenttypename ;
      private string AV78Residentwwds_15_tfresidenttypename_sel ;
      private string lV64Residentwwds_1_filterfulltext ;
      private string lV65Residentwwds_2_tfresidentbsnnumber ;
      private string lV67Residentwwds_4_tfresidentgivenname ;
      private string lV69Residentwwds_6_tfresidentlastname ;
      private string lV71Residentwwds_8_tfresidentemail ;
      private string lV73Residentwwds_10_tfresidentaddress ;
      private string lV77Residentwwds_14_tfresidenttypename ;
      private string A40ResidentBsnNumber ;
      private string A33ResidentGivenName ;
      private string A34ResidentLastName ;
      private string A36ResidentEmail ;
      private string A37ResidentAddress ;
      private string A83ResidentTypeName ;
      private string AV36Option ;
      private IGxSession AV42Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P002D2_A82ResidentTypeId ;
      private string[] P002D2_A40ResidentBsnNumber ;
      private short[] P002D2_A18CustomerLocationId ;
      private short[] P002D2_A1CustomerId ;
      private string[] P002D2_A83ResidentTypeName ;
      private string[] P002D2_A38ResidentPhone ;
      private bool[] P002D2_n38ResidentPhone ;
      private string[] P002D2_A37ResidentAddress ;
      private bool[] P002D2_n37ResidentAddress ;
      private string[] P002D2_A36ResidentEmail ;
      private string[] P002D2_A34ResidentLastName ;
      private string[] P002D2_A33ResidentGivenName ;
      private short[] P002D2_A31ResidentId ;
      private short[] P002D3_A82ResidentTypeId ;
      private short[] P002D3_A1CustomerId ;
      private short[] P002D3_A18CustomerLocationId ;
      private string[] P002D3_A33ResidentGivenName ;
      private string[] P002D3_A83ResidentTypeName ;
      private string[] P002D3_A38ResidentPhone ;
      private bool[] P002D3_n38ResidentPhone ;
      private string[] P002D3_A37ResidentAddress ;
      private bool[] P002D3_n37ResidentAddress ;
      private string[] P002D3_A36ResidentEmail ;
      private string[] P002D3_A34ResidentLastName ;
      private string[] P002D3_A40ResidentBsnNumber ;
      private short[] P002D3_A31ResidentId ;
      private short[] P002D4_A82ResidentTypeId ;
      private short[] P002D4_A1CustomerId ;
      private short[] P002D4_A18CustomerLocationId ;
      private string[] P002D4_A34ResidentLastName ;
      private string[] P002D4_A83ResidentTypeName ;
      private string[] P002D4_A38ResidentPhone ;
      private bool[] P002D4_n38ResidentPhone ;
      private string[] P002D4_A37ResidentAddress ;
      private bool[] P002D4_n37ResidentAddress ;
      private string[] P002D4_A36ResidentEmail ;
      private string[] P002D4_A33ResidentGivenName ;
      private string[] P002D4_A40ResidentBsnNumber ;
      private short[] P002D4_A31ResidentId ;
      private short[] P002D5_A82ResidentTypeId ;
      private short[] P002D5_A1CustomerId ;
      private short[] P002D5_A18CustomerLocationId ;
      private string[] P002D5_A36ResidentEmail ;
      private string[] P002D5_A83ResidentTypeName ;
      private string[] P002D5_A38ResidentPhone ;
      private bool[] P002D5_n38ResidentPhone ;
      private string[] P002D5_A37ResidentAddress ;
      private bool[] P002D5_n37ResidentAddress ;
      private string[] P002D5_A34ResidentLastName ;
      private string[] P002D5_A33ResidentGivenName ;
      private string[] P002D5_A40ResidentBsnNumber ;
      private short[] P002D5_A31ResidentId ;
      private short[] P002D6_A82ResidentTypeId ;
      private short[] P002D6_A1CustomerId ;
      private short[] P002D6_A18CustomerLocationId ;
      private string[] P002D6_A37ResidentAddress ;
      private bool[] P002D6_n37ResidentAddress ;
      private string[] P002D6_A83ResidentTypeName ;
      private string[] P002D6_A38ResidentPhone ;
      private bool[] P002D6_n38ResidentPhone ;
      private string[] P002D6_A36ResidentEmail ;
      private string[] P002D6_A34ResidentLastName ;
      private string[] P002D6_A33ResidentGivenName ;
      private string[] P002D6_A40ResidentBsnNumber ;
      private short[] P002D6_A31ResidentId ;
      private short[] P002D7_A82ResidentTypeId ;
      private short[] P002D7_A1CustomerId ;
      private short[] P002D7_A18CustomerLocationId ;
      private string[] P002D7_A38ResidentPhone ;
      private bool[] P002D7_n38ResidentPhone ;
      private string[] P002D7_A83ResidentTypeName ;
      private string[] P002D7_A37ResidentAddress ;
      private bool[] P002D7_n37ResidentAddress ;
      private string[] P002D7_A36ResidentEmail ;
      private string[] P002D7_A34ResidentLastName ;
      private string[] P002D7_A33ResidentGivenName ;
      private string[] P002D7_A40ResidentBsnNumber ;
      private short[] P002D7_A31ResidentId ;
      private short[] P002D8_A82ResidentTypeId ;
      private short[] P002D8_A18CustomerLocationId ;
      private short[] P002D8_A1CustomerId ;
      private string[] P002D8_A83ResidentTypeName ;
      private string[] P002D8_A38ResidentPhone ;
      private bool[] P002D8_n38ResidentPhone ;
      private string[] P002D8_A37ResidentAddress ;
      private bool[] P002D8_n37ResidentAddress ;
      private string[] P002D8_A36ResidentEmail ;
      private string[] P002D8_A34ResidentLastName ;
      private string[] P002D8_A33ResidentGivenName ;
      private string[] P002D8_A40ResidentBsnNumber ;
      private short[] P002D8_A31ResidentId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV37Options ;
      private GxSimpleCollection<string> AV39OptionsDesc ;
      private GxSimpleCollection<string> AV40OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV44GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV45GridStateFilterValue ;
   }

   public class residentwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002D2( IGxContext context ,
                                             string AV64Residentwwds_1_filterfulltext ,
                                             string AV66Residentwwds_3_tfresidentbsnnumber_sel ,
                                             string AV65Residentwwds_2_tfresidentbsnnumber ,
                                             string AV68Residentwwds_5_tfresidentgivenname_sel ,
                                             string AV67Residentwwds_4_tfresidentgivenname ,
                                             string AV70Residentwwds_7_tfresidentlastname_sel ,
                                             string AV69Residentwwds_6_tfresidentlastname ,
                                             string AV72Residentwwds_9_tfresidentemail_sel ,
                                             string AV71Residentwwds_8_tfresidentemail ,
                                             string AV74Residentwwds_11_tfresidentaddress_sel ,
                                             string AV73Residentwwds_10_tfresidentaddress ,
                                             string AV76Residentwwds_13_tfresidentphone_sel ,
                                             string AV75Residentwwds_12_tfresidentphone ,
                                             string AV78Residentwwds_15_tfresidenttypename_sel ,
                                             string AV77Residentwwds_14_tfresidenttypename ,
                                             string A40ResidentBsnNumber ,
                                             string A33ResidentGivenName ,
                                             string A34ResidentLastName ,
                                             string A36ResidentEmail ,
                                             string A37ResidentAddress ,
                                             string A38ResidentPhone ,
                                             string A83ResidentTypeName ,
                                             short A1CustomerId ,
                                             short AV79Udparg16 ,
                                             short A18CustomerLocationId ,
                                             short AV80Udparg17 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[23];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.ResidentTypeId, T1.ResidentBsnNumber, T1.CustomerLocationId, T1.CustomerId, T2.ResidentTypeName, T1.ResidentPhone, T1.ResidentAddress, T1.ResidentEmail, T1.ResidentLastName, T1.ResidentGivenName, T1.ResidentId FROM (Resident T1 INNER JOIN ResidentType T2 ON T2.ResidentTypeId = T1.ResidentTypeId)";
         AddWhere(sWhereString, "(T1.CustomerId = :AV79Udparg16)");
         AddWhere(sWhereString, "(T1.CustomerLocationId = :AV80Udparg17)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Residentwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.ResidentBsnNumber like '%' || :lV64Residentwwds_1_filterfulltext) or ( T1.ResidentGivenName like '%' || :lV64Residentwwds_1_filterfulltext) or ( T1.ResidentLastName like '%' || :lV64Residentwwds_1_filterfulltext) or ( T1.ResidentEmail like '%' || :lV64Residentwwds_1_filterfulltext) or ( T1.ResidentAddress like '%' || :lV64Residentwwds_1_filterfulltext) or ( T1.ResidentPhone like '%' || :lV64Residentwwds_1_filterfulltext) or ( T2.ResidentTypeName like '%' || :lV64Residentwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
            GXv_int1[5] = 1;
            GXv_int1[6] = 1;
            GXv_int1[7] = 1;
            GXv_int1[8] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Residentwwds_3_tfresidentbsnnumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Residentwwds_2_tfresidentbsnnumber)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber like :lV65Residentwwds_2_tfresidentbsnnumber)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Residentwwds_3_tfresidentbsnnumber_sel)) && ! ( StringUtil.StrCmp(AV66Residentwwds_3_tfresidentbsnnumber_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber = ( :AV66Residentwwds_3_tfresidentbsnnumber_sel))");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( StringUtil.StrCmp(AV66Residentwwds_3_tfresidentbsnnumber_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentBsnNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Residentwwds_5_tfresidentgivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Residentwwds_4_tfresidentgivenname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName like :lV67Residentwwds_4_tfresidentgivenname)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Residentwwds_5_tfresidentgivenname_sel)) && ! ( StringUtil.StrCmp(AV68Residentwwds_5_tfresidentgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName = ( :AV68Residentwwds_5_tfresidentgivenname_sel))");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( StringUtil.StrCmp(AV68Residentwwds_5_tfresidentgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Residentwwds_7_tfresidentlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Residentwwds_6_tfresidentlastname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName like :lV69Residentwwds_6_tfresidentlastname)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Residentwwds_7_tfresidentlastname_sel)) && ! ( StringUtil.StrCmp(AV70Residentwwds_7_tfresidentlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName = ( :AV70Residentwwds_7_tfresidentlastname_sel))");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( StringUtil.StrCmp(AV70Residentwwds_7_tfresidentlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Residentwwds_9_tfresidentemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Residentwwds_8_tfresidentemail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail like :lV71Residentwwds_8_tfresidentemail)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Residentwwds_9_tfresidentemail_sel)) && ! ( StringUtil.StrCmp(AV72Residentwwds_9_tfresidentemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail = ( :AV72Residentwwds_9_tfresidentemail_sel))");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( StringUtil.StrCmp(AV72Residentwwds_9_tfresidentemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Residentwwds_11_tfresidentaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Residentwwds_10_tfresidentaddress)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress like :lV73Residentwwds_10_tfresidentaddress)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Residentwwds_11_tfresidentaddress_sel)) && ! ( StringUtil.StrCmp(AV74Residentwwds_11_tfresidentaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress = ( :AV74Residentwwds_11_tfresidentaddress_sel))");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( StringUtil.StrCmp(AV74Residentwwds_11_tfresidentaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress IS NULL or (char_length(trim(trailing ' ' from T1.ResidentAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Residentwwds_13_tfresidentphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Residentwwds_12_tfresidentphone)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone like :lV75Residentwwds_12_tfresidentphone)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Residentwwds_13_tfresidentphone_sel)) && ! ( StringUtil.StrCmp(AV76Residentwwds_13_tfresidentphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone = ( :AV76Residentwwds_13_tfresidentphone_sel))");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( StringUtil.StrCmp(AV76Residentwwds_13_tfresidentphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone IS NULL or (char_length(trim(trailing ' ' from T1.ResidentPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Residentwwds_15_tfresidenttypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Residentwwds_14_tfresidenttypename)) ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName like :lV77Residentwwds_14_tfresidenttypename)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Residentwwds_15_tfresidenttypename_sel)) && ! ( StringUtil.StrCmp(AV78Residentwwds_15_tfresidenttypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName = ( :AV78Residentwwds_15_tfresidenttypename_sel))");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( StringUtil.StrCmp(AV78Residentwwds_15_tfresidenttypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ResidentTypeName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ResidentBsnNumber";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P002D3( IGxContext context ,
                                             string AV64Residentwwds_1_filterfulltext ,
                                             string AV66Residentwwds_3_tfresidentbsnnumber_sel ,
                                             string AV65Residentwwds_2_tfresidentbsnnumber ,
                                             string AV68Residentwwds_5_tfresidentgivenname_sel ,
                                             string AV67Residentwwds_4_tfresidentgivenname ,
                                             string AV70Residentwwds_7_tfresidentlastname_sel ,
                                             string AV69Residentwwds_6_tfresidentlastname ,
                                             string AV72Residentwwds_9_tfresidentemail_sel ,
                                             string AV71Residentwwds_8_tfresidentemail ,
                                             string AV74Residentwwds_11_tfresidentaddress_sel ,
                                             string AV73Residentwwds_10_tfresidentaddress ,
                                             string AV76Residentwwds_13_tfresidentphone_sel ,
                                             string AV75Residentwwds_12_tfresidentphone ,
                                             string AV78Residentwwds_15_tfresidenttypename_sel ,
                                             string AV77Residentwwds_14_tfresidenttypename ,
                                             string A40ResidentBsnNumber ,
                                             string A33ResidentGivenName ,
                                             string A34ResidentLastName ,
                                             string A36ResidentEmail ,
                                             string A37ResidentAddress ,
                                             string A38ResidentPhone ,
                                             string A83ResidentTypeName ,
                                             short A1CustomerId ,
                                             short AV79Udparg16 ,
                                             short A18CustomerLocationId ,
                                             short AV80Udparg17 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[23];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.ResidentTypeId, T1.CustomerId, T1.CustomerLocationId, T1.ResidentGivenName, T2.ResidentTypeName, T1.ResidentPhone, T1.ResidentAddress, T1.ResidentEmail, T1.ResidentLastName, T1.ResidentBsnNumber, T1.ResidentId FROM (Resident T1 INNER JOIN ResidentType T2 ON T2.ResidentTypeId = T1.ResidentTypeId)";
         AddWhere(sWhereString, "(T1.CustomerId = :AV79Udparg16)");
         AddWhere(sWhereString, "(T1.CustomerLocationId = :AV80Udparg17)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Residentwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.ResidentBsnNumber like '%' || :lV64Residentwwds_1_filterfulltext) or ( T1.ResidentGivenName like '%' || :lV64Residentwwds_1_filterfulltext) or ( T1.ResidentLastName like '%' || :lV64Residentwwds_1_filterfulltext) or ( T1.ResidentEmail like '%' || :lV64Residentwwds_1_filterfulltext) or ( T1.ResidentAddress like '%' || :lV64Residentwwds_1_filterfulltext) or ( T1.ResidentPhone like '%' || :lV64Residentwwds_1_filterfulltext) or ( T2.ResidentTypeName like '%' || :lV64Residentwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
            GXv_int3[5] = 1;
            GXv_int3[6] = 1;
            GXv_int3[7] = 1;
            GXv_int3[8] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Residentwwds_3_tfresidentbsnnumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Residentwwds_2_tfresidentbsnnumber)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber like :lV65Residentwwds_2_tfresidentbsnnumber)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Residentwwds_3_tfresidentbsnnumber_sel)) && ! ( StringUtil.StrCmp(AV66Residentwwds_3_tfresidentbsnnumber_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber = ( :AV66Residentwwds_3_tfresidentbsnnumber_sel))");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( StringUtil.StrCmp(AV66Residentwwds_3_tfresidentbsnnumber_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentBsnNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Residentwwds_5_tfresidentgivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Residentwwds_4_tfresidentgivenname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName like :lV67Residentwwds_4_tfresidentgivenname)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Residentwwds_5_tfresidentgivenname_sel)) && ! ( StringUtil.StrCmp(AV68Residentwwds_5_tfresidentgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName = ( :AV68Residentwwds_5_tfresidentgivenname_sel))");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( StringUtil.StrCmp(AV68Residentwwds_5_tfresidentgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Residentwwds_7_tfresidentlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Residentwwds_6_tfresidentlastname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName like :lV69Residentwwds_6_tfresidentlastname)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Residentwwds_7_tfresidentlastname_sel)) && ! ( StringUtil.StrCmp(AV70Residentwwds_7_tfresidentlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName = ( :AV70Residentwwds_7_tfresidentlastname_sel))");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( StringUtil.StrCmp(AV70Residentwwds_7_tfresidentlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Residentwwds_9_tfresidentemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Residentwwds_8_tfresidentemail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail like :lV71Residentwwds_8_tfresidentemail)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Residentwwds_9_tfresidentemail_sel)) && ! ( StringUtil.StrCmp(AV72Residentwwds_9_tfresidentemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail = ( :AV72Residentwwds_9_tfresidentemail_sel))");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( StringUtil.StrCmp(AV72Residentwwds_9_tfresidentemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Residentwwds_11_tfresidentaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Residentwwds_10_tfresidentaddress)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress like :lV73Residentwwds_10_tfresidentaddress)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Residentwwds_11_tfresidentaddress_sel)) && ! ( StringUtil.StrCmp(AV74Residentwwds_11_tfresidentaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress = ( :AV74Residentwwds_11_tfresidentaddress_sel))");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( StringUtil.StrCmp(AV74Residentwwds_11_tfresidentaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress IS NULL or (char_length(trim(trailing ' ' from T1.ResidentAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Residentwwds_13_tfresidentphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Residentwwds_12_tfresidentphone)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone like :lV75Residentwwds_12_tfresidentphone)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Residentwwds_13_tfresidentphone_sel)) && ! ( StringUtil.StrCmp(AV76Residentwwds_13_tfresidentphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone = ( :AV76Residentwwds_13_tfresidentphone_sel))");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( StringUtil.StrCmp(AV76Residentwwds_13_tfresidentphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone IS NULL or (char_length(trim(trailing ' ' from T1.ResidentPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Residentwwds_15_tfresidenttypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Residentwwds_14_tfresidenttypename)) ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName like :lV77Residentwwds_14_tfresidenttypename)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Residentwwds_15_tfresidenttypename_sel)) && ! ( StringUtil.StrCmp(AV78Residentwwds_15_tfresidenttypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName = ( :AV78Residentwwds_15_tfresidenttypename_sel))");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( StringUtil.StrCmp(AV78Residentwwds_15_tfresidenttypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ResidentTypeName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ResidentGivenName";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P002D4( IGxContext context ,
                                             string AV64Residentwwds_1_filterfulltext ,
                                             string AV66Residentwwds_3_tfresidentbsnnumber_sel ,
                                             string AV65Residentwwds_2_tfresidentbsnnumber ,
                                             string AV68Residentwwds_5_tfresidentgivenname_sel ,
                                             string AV67Residentwwds_4_tfresidentgivenname ,
                                             string AV70Residentwwds_7_tfresidentlastname_sel ,
                                             string AV69Residentwwds_6_tfresidentlastname ,
                                             string AV72Residentwwds_9_tfresidentemail_sel ,
                                             string AV71Residentwwds_8_tfresidentemail ,
                                             string AV74Residentwwds_11_tfresidentaddress_sel ,
                                             string AV73Residentwwds_10_tfresidentaddress ,
                                             string AV76Residentwwds_13_tfresidentphone_sel ,
                                             string AV75Residentwwds_12_tfresidentphone ,
                                             string AV78Residentwwds_15_tfresidenttypename_sel ,
                                             string AV77Residentwwds_14_tfresidenttypename ,
                                             string A40ResidentBsnNumber ,
                                             string A33ResidentGivenName ,
                                             string A34ResidentLastName ,
                                             string A36ResidentEmail ,
                                             string A37ResidentAddress ,
                                             string A38ResidentPhone ,
                                             string A83ResidentTypeName ,
                                             short A1CustomerId ,
                                             short AV79Udparg16 ,
                                             short A18CustomerLocationId ,
                                             short AV80Udparg17 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[23];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.ResidentTypeId, T1.CustomerId, T1.CustomerLocationId, T1.ResidentLastName, T2.ResidentTypeName, T1.ResidentPhone, T1.ResidentAddress, T1.ResidentEmail, T1.ResidentGivenName, T1.ResidentBsnNumber, T1.ResidentId FROM (Resident T1 INNER JOIN ResidentType T2 ON T2.ResidentTypeId = T1.ResidentTypeId)";
         AddWhere(sWhereString, "(T1.CustomerId = :AV79Udparg16)");
         AddWhere(sWhereString, "(T1.CustomerLocationId = :AV80Udparg17)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Residentwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.ResidentBsnNumber like '%' || :lV64Residentwwds_1_filterfulltext) or ( T1.ResidentGivenName like '%' || :lV64Residentwwds_1_filterfulltext) or ( T1.ResidentLastName like '%' || :lV64Residentwwds_1_filterfulltext) or ( T1.ResidentEmail like '%' || :lV64Residentwwds_1_filterfulltext) or ( T1.ResidentAddress like '%' || :lV64Residentwwds_1_filterfulltext) or ( T1.ResidentPhone like '%' || :lV64Residentwwds_1_filterfulltext) or ( T2.ResidentTypeName like '%' || :lV64Residentwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
            GXv_int5[5] = 1;
            GXv_int5[6] = 1;
            GXv_int5[7] = 1;
            GXv_int5[8] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Residentwwds_3_tfresidentbsnnumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Residentwwds_2_tfresidentbsnnumber)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber like :lV65Residentwwds_2_tfresidentbsnnumber)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Residentwwds_3_tfresidentbsnnumber_sel)) && ! ( StringUtil.StrCmp(AV66Residentwwds_3_tfresidentbsnnumber_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber = ( :AV66Residentwwds_3_tfresidentbsnnumber_sel))");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( StringUtil.StrCmp(AV66Residentwwds_3_tfresidentbsnnumber_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentBsnNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Residentwwds_5_tfresidentgivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Residentwwds_4_tfresidentgivenname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName like :lV67Residentwwds_4_tfresidentgivenname)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Residentwwds_5_tfresidentgivenname_sel)) && ! ( StringUtil.StrCmp(AV68Residentwwds_5_tfresidentgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName = ( :AV68Residentwwds_5_tfresidentgivenname_sel))");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( StringUtil.StrCmp(AV68Residentwwds_5_tfresidentgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Residentwwds_7_tfresidentlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Residentwwds_6_tfresidentlastname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName like :lV69Residentwwds_6_tfresidentlastname)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Residentwwds_7_tfresidentlastname_sel)) && ! ( StringUtil.StrCmp(AV70Residentwwds_7_tfresidentlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName = ( :AV70Residentwwds_7_tfresidentlastname_sel))");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( StringUtil.StrCmp(AV70Residentwwds_7_tfresidentlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Residentwwds_9_tfresidentemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Residentwwds_8_tfresidentemail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail like :lV71Residentwwds_8_tfresidentemail)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Residentwwds_9_tfresidentemail_sel)) && ! ( StringUtil.StrCmp(AV72Residentwwds_9_tfresidentemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail = ( :AV72Residentwwds_9_tfresidentemail_sel))");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( StringUtil.StrCmp(AV72Residentwwds_9_tfresidentemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Residentwwds_11_tfresidentaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Residentwwds_10_tfresidentaddress)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress like :lV73Residentwwds_10_tfresidentaddress)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Residentwwds_11_tfresidentaddress_sel)) && ! ( StringUtil.StrCmp(AV74Residentwwds_11_tfresidentaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress = ( :AV74Residentwwds_11_tfresidentaddress_sel))");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( StringUtil.StrCmp(AV74Residentwwds_11_tfresidentaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress IS NULL or (char_length(trim(trailing ' ' from T1.ResidentAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Residentwwds_13_tfresidentphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Residentwwds_12_tfresidentphone)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone like :lV75Residentwwds_12_tfresidentphone)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Residentwwds_13_tfresidentphone_sel)) && ! ( StringUtil.StrCmp(AV76Residentwwds_13_tfresidentphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone = ( :AV76Residentwwds_13_tfresidentphone_sel))");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( StringUtil.StrCmp(AV76Residentwwds_13_tfresidentphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone IS NULL or (char_length(trim(trailing ' ' from T1.ResidentPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Residentwwds_15_tfresidenttypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Residentwwds_14_tfresidenttypename)) ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName like :lV77Residentwwds_14_tfresidenttypename)");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Residentwwds_15_tfresidenttypename_sel)) && ! ( StringUtil.StrCmp(AV78Residentwwds_15_tfresidenttypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName = ( :AV78Residentwwds_15_tfresidenttypename_sel))");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( StringUtil.StrCmp(AV78Residentwwds_15_tfresidenttypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ResidentTypeName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ResidentLastName";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P002D5( IGxContext context ,
                                             string AV64Residentwwds_1_filterfulltext ,
                                             string AV66Residentwwds_3_tfresidentbsnnumber_sel ,
                                             string AV65Residentwwds_2_tfresidentbsnnumber ,
                                             string AV68Residentwwds_5_tfresidentgivenname_sel ,
                                             string AV67Residentwwds_4_tfresidentgivenname ,
                                             string AV70Residentwwds_7_tfresidentlastname_sel ,
                                             string AV69Residentwwds_6_tfresidentlastname ,
                                             string AV72Residentwwds_9_tfresidentemail_sel ,
                                             string AV71Residentwwds_8_tfresidentemail ,
                                             string AV74Residentwwds_11_tfresidentaddress_sel ,
                                             string AV73Residentwwds_10_tfresidentaddress ,
                                             string AV76Residentwwds_13_tfresidentphone_sel ,
                                             string AV75Residentwwds_12_tfresidentphone ,
                                             string AV78Residentwwds_15_tfresidenttypename_sel ,
                                             string AV77Residentwwds_14_tfresidenttypename ,
                                             string A40ResidentBsnNumber ,
                                             string A33ResidentGivenName ,
                                             string A34ResidentLastName ,
                                             string A36ResidentEmail ,
                                             string A37ResidentAddress ,
                                             string A38ResidentPhone ,
                                             string A83ResidentTypeName ,
                                             short A1CustomerId ,
                                             short AV79Udparg16 ,
                                             short A18CustomerLocationId ,
                                             short AV80Udparg17 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[23];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.ResidentTypeId, T1.CustomerId, T1.CustomerLocationId, T1.ResidentEmail, T2.ResidentTypeName, T1.ResidentPhone, T1.ResidentAddress, T1.ResidentLastName, T1.ResidentGivenName, T1.ResidentBsnNumber, T1.ResidentId FROM (Resident T1 INNER JOIN ResidentType T2 ON T2.ResidentTypeId = T1.ResidentTypeId)";
         AddWhere(sWhereString, "(T1.CustomerId = :AV79Udparg16)");
         AddWhere(sWhereString, "(T1.CustomerLocationId = :AV80Udparg17)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Residentwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.ResidentBsnNumber like '%' || :lV64Residentwwds_1_filterfulltext) or ( T1.ResidentGivenName like '%' || :lV64Residentwwds_1_filterfulltext) or ( T1.ResidentLastName like '%' || :lV64Residentwwds_1_filterfulltext) or ( T1.ResidentEmail like '%' || :lV64Residentwwds_1_filterfulltext) or ( T1.ResidentAddress like '%' || :lV64Residentwwds_1_filterfulltext) or ( T1.ResidentPhone like '%' || :lV64Residentwwds_1_filterfulltext) or ( T2.ResidentTypeName like '%' || :lV64Residentwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
            GXv_int7[4] = 1;
            GXv_int7[5] = 1;
            GXv_int7[6] = 1;
            GXv_int7[7] = 1;
            GXv_int7[8] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Residentwwds_3_tfresidentbsnnumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Residentwwds_2_tfresidentbsnnumber)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber like :lV65Residentwwds_2_tfresidentbsnnumber)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Residentwwds_3_tfresidentbsnnumber_sel)) && ! ( StringUtil.StrCmp(AV66Residentwwds_3_tfresidentbsnnumber_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber = ( :AV66Residentwwds_3_tfresidentbsnnumber_sel))");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( StringUtil.StrCmp(AV66Residentwwds_3_tfresidentbsnnumber_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentBsnNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Residentwwds_5_tfresidentgivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Residentwwds_4_tfresidentgivenname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName like :lV67Residentwwds_4_tfresidentgivenname)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Residentwwds_5_tfresidentgivenname_sel)) && ! ( StringUtil.StrCmp(AV68Residentwwds_5_tfresidentgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName = ( :AV68Residentwwds_5_tfresidentgivenname_sel))");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( StringUtil.StrCmp(AV68Residentwwds_5_tfresidentgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Residentwwds_7_tfresidentlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Residentwwds_6_tfresidentlastname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName like :lV69Residentwwds_6_tfresidentlastname)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Residentwwds_7_tfresidentlastname_sel)) && ! ( StringUtil.StrCmp(AV70Residentwwds_7_tfresidentlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName = ( :AV70Residentwwds_7_tfresidentlastname_sel))");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( StringUtil.StrCmp(AV70Residentwwds_7_tfresidentlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Residentwwds_9_tfresidentemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Residentwwds_8_tfresidentemail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail like :lV71Residentwwds_8_tfresidentemail)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Residentwwds_9_tfresidentemail_sel)) && ! ( StringUtil.StrCmp(AV72Residentwwds_9_tfresidentemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail = ( :AV72Residentwwds_9_tfresidentemail_sel))");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( StringUtil.StrCmp(AV72Residentwwds_9_tfresidentemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Residentwwds_11_tfresidentaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Residentwwds_10_tfresidentaddress)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress like :lV73Residentwwds_10_tfresidentaddress)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Residentwwds_11_tfresidentaddress_sel)) && ! ( StringUtil.StrCmp(AV74Residentwwds_11_tfresidentaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress = ( :AV74Residentwwds_11_tfresidentaddress_sel))");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( StringUtil.StrCmp(AV74Residentwwds_11_tfresidentaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress IS NULL or (char_length(trim(trailing ' ' from T1.ResidentAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Residentwwds_13_tfresidentphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Residentwwds_12_tfresidentphone)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone like :lV75Residentwwds_12_tfresidentphone)");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Residentwwds_13_tfresidentphone_sel)) && ! ( StringUtil.StrCmp(AV76Residentwwds_13_tfresidentphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone = ( :AV76Residentwwds_13_tfresidentphone_sel))");
         }
         else
         {
            GXv_int7[20] = 1;
         }
         if ( StringUtil.StrCmp(AV76Residentwwds_13_tfresidentphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone IS NULL or (char_length(trim(trailing ' ' from T1.ResidentPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Residentwwds_15_tfresidenttypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Residentwwds_14_tfresidenttypename)) ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName like :lV77Residentwwds_14_tfresidenttypename)");
         }
         else
         {
            GXv_int7[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Residentwwds_15_tfresidenttypename_sel)) && ! ( StringUtil.StrCmp(AV78Residentwwds_15_tfresidenttypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName = ( :AV78Residentwwds_15_tfresidenttypename_sel))");
         }
         else
         {
            GXv_int7[22] = 1;
         }
         if ( StringUtil.StrCmp(AV78Residentwwds_15_tfresidenttypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ResidentTypeName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ResidentEmail";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P002D6( IGxContext context ,
                                             string AV64Residentwwds_1_filterfulltext ,
                                             string AV66Residentwwds_3_tfresidentbsnnumber_sel ,
                                             string AV65Residentwwds_2_tfresidentbsnnumber ,
                                             string AV68Residentwwds_5_tfresidentgivenname_sel ,
                                             string AV67Residentwwds_4_tfresidentgivenname ,
                                             string AV70Residentwwds_7_tfresidentlastname_sel ,
                                             string AV69Residentwwds_6_tfresidentlastname ,
                                             string AV72Residentwwds_9_tfresidentemail_sel ,
                                             string AV71Residentwwds_8_tfresidentemail ,
                                             string AV74Residentwwds_11_tfresidentaddress_sel ,
                                             string AV73Residentwwds_10_tfresidentaddress ,
                                             string AV76Residentwwds_13_tfresidentphone_sel ,
                                             string AV75Residentwwds_12_tfresidentphone ,
                                             string AV78Residentwwds_15_tfresidenttypename_sel ,
                                             string AV77Residentwwds_14_tfresidenttypename ,
                                             string A40ResidentBsnNumber ,
                                             string A33ResidentGivenName ,
                                             string A34ResidentLastName ,
                                             string A36ResidentEmail ,
                                             string A37ResidentAddress ,
                                             string A38ResidentPhone ,
                                             string A83ResidentTypeName ,
                                             short A1CustomerId ,
                                             short AV79Udparg16 ,
                                             short A18CustomerLocationId ,
                                             short AV80Udparg17 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[23];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T1.ResidentTypeId, T1.CustomerId, T1.CustomerLocationId, T1.ResidentAddress, T2.ResidentTypeName, T1.ResidentPhone, T1.ResidentEmail, T1.ResidentLastName, T1.ResidentGivenName, T1.ResidentBsnNumber, T1.ResidentId FROM (Resident T1 INNER JOIN ResidentType T2 ON T2.ResidentTypeId = T1.ResidentTypeId)";
         AddWhere(sWhereString, "(T1.CustomerId = :AV79Udparg16)");
         AddWhere(sWhereString, "(T1.CustomerLocationId = :AV80Udparg17)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Residentwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.ResidentBsnNumber like '%' || :lV64Residentwwds_1_filterfulltext) or ( T1.ResidentGivenName like '%' || :lV64Residentwwds_1_filterfulltext) or ( T1.ResidentLastName like '%' || :lV64Residentwwds_1_filterfulltext) or ( T1.ResidentEmail like '%' || :lV64Residentwwds_1_filterfulltext) or ( T1.ResidentAddress like '%' || :lV64Residentwwds_1_filterfulltext) or ( T1.ResidentPhone like '%' || :lV64Residentwwds_1_filterfulltext) or ( T2.ResidentTypeName like '%' || :lV64Residentwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int9[2] = 1;
            GXv_int9[3] = 1;
            GXv_int9[4] = 1;
            GXv_int9[5] = 1;
            GXv_int9[6] = 1;
            GXv_int9[7] = 1;
            GXv_int9[8] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Residentwwds_3_tfresidentbsnnumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Residentwwds_2_tfresidentbsnnumber)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber like :lV65Residentwwds_2_tfresidentbsnnumber)");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Residentwwds_3_tfresidentbsnnumber_sel)) && ! ( StringUtil.StrCmp(AV66Residentwwds_3_tfresidentbsnnumber_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber = ( :AV66Residentwwds_3_tfresidentbsnnumber_sel))");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( StringUtil.StrCmp(AV66Residentwwds_3_tfresidentbsnnumber_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentBsnNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Residentwwds_5_tfresidentgivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Residentwwds_4_tfresidentgivenname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName like :lV67Residentwwds_4_tfresidentgivenname)");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Residentwwds_5_tfresidentgivenname_sel)) && ! ( StringUtil.StrCmp(AV68Residentwwds_5_tfresidentgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName = ( :AV68Residentwwds_5_tfresidentgivenname_sel))");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( StringUtil.StrCmp(AV68Residentwwds_5_tfresidentgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Residentwwds_7_tfresidentlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Residentwwds_6_tfresidentlastname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName like :lV69Residentwwds_6_tfresidentlastname)");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Residentwwds_7_tfresidentlastname_sel)) && ! ( StringUtil.StrCmp(AV70Residentwwds_7_tfresidentlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName = ( :AV70Residentwwds_7_tfresidentlastname_sel))");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( StringUtil.StrCmp(AV70Residentwwds_7_tfresidentlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Residentwwds_9_tfresidentemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Residentwwds_8_tfresidentemail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail like :lV71Residentwwds_8_tfresidentemail)");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Residentwwds_9_tfresidentemail_sel)) && ! ( StringUtil.StrCmp(AV72Residentwwds_9_tfresidentemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail = ( :AV72Residentwwds_9_tfresidentemail_sel))");
         }
         else
         {
            GXv_int9[16] = 1;
         }
         if ( StringUtil.StrCmp(AV72Residentwwds_9_tfresidentemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Residentwwds_11_tfresidentaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Residentwwds_10_tfresidentaddress)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress like :lV73Residentwwds_10_tfresidentaddress)");
         }
         else
         {
            GXv_int9[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Residentwwds_11_tfresidentaddress_sel)) && ! ( StringUtil.StrCmp(AV74Residentwwds_11_tfresidentaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress = ( :AV74Residentwwds_11_tfresidentaddress_sel))");
         }
         else
         {
            GXv_int9[18] = 1;
         }
         if ( StringUtil.StrCmp(AV74Residentwwds_11_tfresidentaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress IS NULL or (char_length(trim(trailing ' ' from T1.ResidentAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Residentwwds_13_tfresidentphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Residentwwds_12_tfresidentphone)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone like :lV75Residentwwds_12_tfresidentphone)");
         }
         else
         {
            GXv_int9[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Residentwwds_13_tfresidentphone_sel)) && ! ( StringUtil.StrCmp(AV76Residentwwds_13_tfresidentphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone = ( :AV76Residentwwds_13_tfresidentphone_sel))");
         }
         else
         {
            GXv_int9[20] = 1;
         }
         if ( StringUtil.StrCmp(AV76Residentwwds_13_tfresidentphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone IS NULL or (char_length(trim(trailing ' ' from T1.ResidentPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Residentwwds_15_tfresidenttypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Residentwwds_14_tfresidenttypename)) ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName like :lV77Residentwwds_14_tfresidenttypename)");
         }
         else
         {
            GXv_int9[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Residentwwds_15_tfresidenttypename_sel)) && ! ( StringUtil.StrCmp(AV78Residentwwds_15_tfresidenttypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName = ( :AV78Residentwwds_15_tfresidenttypename_sel))");
         }
         else
         {
            GXv_int9[22] = 1;
         }
         if ( StringUtil.StrCmp(AV78Residentwwds_15_tfresidenttypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ResidentTypeName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ResidentAddress";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      protected Object[] conditional_P002D7( IGxContext context ,
                                             string AV64Residentwwds_1_filterfulltext ,
                                             string AV66Residentwwds_3_tfresidentbsnnumber_sel ,
                                             string AV65Residentwwds_2_tfresidentbsnnumber ,
                                             string AV68Residentwwds_5_tfresidentgivenname_sel ,
                                             string AV67Residentwwds_4_tfresidentgivenname ,
                                             string AV70Residentwwds_7_tfresidentlastname_sel ,
                                             string AV69Residentwwds_6_tfresidentlastname ,
                                             string AV72Residentwwds_9_tfresidentemail_sel ,
                                             string AV71Residentwwds_8_tfresidentemail ,
                                             string AV74Residentwwds_11_tfresidentaddress_sel ,
                                             string AV73Residentwwds_10_tfresidentaddress ,
                                             string AV76Residentwwds_13_tfresidentphone_sel ,
                                             string AV75Residentwwds_12_tfresidentphone ,
                                             string AV78Residentwwds_15_tfresidenttypename_sel ,
                                             string AV77Residentwwds_14_tfresidenttypename ,
                                             string A40ResidentBsnNumber ,
                                             string A33ResidentGivenName ,
                                             string A34ResidentLastName ,
                                             string A36ResidentEmail ,
                                             string A37ResidentAddress ,
                                             string A38ResidentPhone ,
                                             string A83ResidentTypeName ,
                                             short A1CustomerId ,
                                             short AV79Udparg16 ,
                                             short A18CustomerLocationId ,
                                             short AV80Udparg17 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[23];
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT T1.ResidentTypeId, T1.CustomerId, T1.CustomerLocationId, T1.ResidentPhone, T2.ResidentTypeName, T1.ResidentAddress, T1.ResidentEmail, T1.ResidentLastName, T1.ResidentGivenName, T1.ResidentBsnNumber, T1.ResidentId FROM (Resident T1 INNER JOIN ResidentType T2 ON T2.ResidentTypeId = T1.ResidentTypeId)";
         AddWhere(sWhereString, "(T1.CustomerId = :AV79Udparg16)");
         AddWhere(sWhereString, "(T1.CustomerLocationId = :AV80Udparg17)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Residentwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.ResidentBsnNumber like '%' || :lV64Residentwwds_1_filterfulltext) or ( T1.ResidentGivenName like '%' || :lV64Residentwwds_1_filterfulltext) or ( T1.ResidentLastName like '%' || :lV64Residentwwds_1_filterfulltext) or ( T1.ResidentEmail like '%' || :lV64Residentwwds_1_filterfulltext) or ( T1.ResidentAddress like '%' || :lV64Residentwwds_1_filterfulltext) or ( T1.ResidentPhone like '%' || :lV64Residentwwds_1_filterfulltext) or ( T2.ResidentTypeName like '%' || :lV64Residentwwds_1_filterfulltext))");
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
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Residentwwds_3_tfresidentbsnnumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Residentwwds_2_tfresidentbsnnumber)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber like :lV65Residentwwds_2_tfresidentbsnnumber)");
         }
         else
         {
            GXv_int11[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Residentwwds_3_tfresidentbsnnumber_sel)) && ! ( StringUtil.StrCmp(AV66Residentwwds_3_tfresidentbsnnumber_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber = ( :AV66Residentwwds_3_tfresidentbsnnumber_sel))");
         }
         else
         {
            GXv_int11[10] = 1;
         }
         if ( StringUtil.StrCmp(AV66Residentwwds_3_tfresidentbsnnumber_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentBsnNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Residentwwds_5_tfresidentgivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Residentwwds_4_tfresidentgivenname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName like :lV67Residentwwds_4_tfresidentgivenname)");
         }
         else
         {
            GXv_int11[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Residentwwds_5_tfresidentgivenname_sel)) && ! ( StringUtil.StrCmp(AV68Residentwwds_5_tfresidentgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName = ( :AV68Residentwwds_5_tfresidentgivenname_sel))");
         }
         else
         {
            GXv_int11[12] = 1;
         }
         if ( StringUtil.StrCmp(AV68Residentwwds_5_tfresidentgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Residentwwds_7_tfresidentlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Residentwwds_6_tfresidentlastname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName like :lV69Residentwwds_6_tfresidentlastname)");
         }
         else
         {
            GXv_int11[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Residentwwds_7_tfresidentlastname_sel)) && ! ( StringUtil.StrCmp(AV70Residentwwds_7_tfresidentlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName = ( :AV70Residentwwds_7_tfresidentlastname_sel))");
         }
         else
         {
            GXv_int11[14] = 1;
         }
         if ( StringUtil.StrCmp(AV70Residentwwds_7_tfresidentlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Residentwwds_9_tfresidentemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Residentwwds_8_tfresidentemail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail like :lV71Residentwwds_8_tfresidentemail)");
         }
         else
         {
            GXv_int11[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Residentwwds_9_tfresidentemail_sel)) && ! ( StringUtil.StrCmp(AV72Residentwwds_9_tfresidentemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail = ( :AV72Residentwwds_9_tfresidentemail_sel))");
         }
         else
         {
            GXv_int11[16] = 1;
         }
         if ( StringUtil.StrCmp(AV72Residentwwds_9_tfresidentemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Residentwwds_11_tfresidentaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Residentwwds_10_tfresidentaddress)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress like :lV73Residentwwds_10_tfresidentaddress)");
         }
         else
         {
            GXv_int11[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Residentwwds_11_tfresidentaddress_sel)) && ! ( StringUtil.StrCmp(AV74Residentwwds_11_tfresidentaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress = ( :AV74Residentwwds_11_tfresidentaddress_sel))");
         }
         else
         {
            GXv_int11[18] = 1;
         }
         if ( StringUtil.StrCmp(AV74Residentwwds_11_tfresidentaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress IS NULL or (char_length(trim(trailing ' ' from T1.ResidentAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Residentwwds_13_tfresidentphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Residentwwds_12_tfresidentphone)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone like :lV75Residentwwds_12_tfresidentphone)");
         }
         else
         {
            GXv_int11[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Residentwwds_13_tfresidentphone_sel)) && ! ( StringUtil.StrCmp(AV76Residentwwds_13_tfresidentphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone = ( :AV76Residentwwds_13_tfresidentphone_sel))");
         }
         else
         {
            GXv_int11[20] = 1;
         }
         if ( StringUtil.StrCmp(AV76Residentwwds_13_tfresidentphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone IS NULL or (char_length(trim(trailing ' ' from T1.ResidentPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Residentwwds_15_tfresidenttypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Residentwwds_14_tfresidenttypename)) ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName like :lV77Residentwwds_14_tfresidenttypename)");
         }
         else
         {
            GXv_int11[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Residentwwds_15_tfresidenttypename_sel)) && ! ( StringUtil.StrCmp(AV78Residentwwds_15_tfresidenttypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName = ( :AV78Residentwwds_15_tfresidenttypename_sel))");
         }
         else
         {
            GXv_int11[22] = 1;
         }
         if ( StringUtil.StrCmp(AV78Residentwwds_15_tfresidenttypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ResidentTypeName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ResidentPhone";
         GXv_Object12[0] = scmdbuf;
         GXv_Object12[1] = GXv_int11;
         return GXv_Object12 ;
      }

      protected Object[] conditional_P002D8( IGxContext context ,
                                             string AV64Residentwwds_1_filterfulltext ,
                                             string AV66Residentwwds_3_tfresidentbsnnumber_sel ,
                                             string AV65Residentwwds_2_tfresidentbsnnumber ,
                                             string AV68Residentwwds_5_tfresidentgivenname_sel ,
                                             string AV67Residentwwds_4_tfresidentgivenname ,
                                             string AV70Residentwwds_7_tfresidentlastname_sel ,
                                             string AV69Residentwwds_6_tfresidentlastname ,
                                             string AV72Residentwwds_9_tfresidentemail_sel ,
                                             string AV71Residentwwds_8_tfresidentemail ,
                                             string AV74Residentwwds_11_tfresidentaddress_sel ,
                                             string AV73Residentwwds_10_tfresidentaddress ,
                                             string AV76Residentwwds_13_tfresidentphone_sel ,
                                             string AV75Residentwwds_12_tfresidentphone ,
                                             string AV78Residentwwds_15_tfresidenttypename_sel ,
                                             string AV77Residentwwds_14_tfresidenttypename ,
                                             string A40ResidentBsnNumber ,
                                             string A33ResidentGivenName ,
                                             string A34ResidentLastName ,
                                             string A36ResidentEmail ,
                                             string A37ResidentAddress ,
                                             string A38ResidentPhone ,
                                             string A83ResidentTypeName ,
                                             short A1CustomerId ,
                                             short AV79Udparg16 ,
                                             short A18CustomerLocationId ,
                                             short AV80Udparg17 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int13 = new short[23];
         Object[] GXv_Object14 = new Object[2];
         scmdbuf = "SELECT T1.ResidentTypeId, T1.CustomerLocationId, T1.CustomerId, T2.ResidentTypeName, T1.ResidentPhone, T1.ResidentAddress, T1.ResidentEmail, T1.ResidentLastName, T1.ResidentGivenName, T1.ResidentBsnNumber, T1.ResidentId FROM (Resident T1 INNER JOIN ResidentType T2 ON T2.ResidentTypeId = T1.ResidentTypeId)";
         AddWhere(sWhereString, "(T1.CustomerId = :AV79Udparg16)");
         AddWhere(sWhereString, "(T1.CustomerLocationId = :AV80Udparg17)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Residentwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.ResidentBsnNumber like '%' || :lV64Residentwwds_1_filterfulltext) or ( T1.ResidentGivenName like '%' || :lV64Residentwwds_1_filterfulltext) or ( T1.ResidentLastName like '%' || :lV64Residentwwds_1_filterfulltext) or ( T1.ResidentEmail like '%' || :lV64Residentwwds_1_filterfulltext) or ( T1.ResidentAddress like '%' || :lV64Residentwwds_1_filterfulltext) or ( T1.ResidentPhone like '%' || :lV64Residentwwds_1_filterfulltext) or ( T2.ResidentTypeName like '%' || :lV64Residentwwds_1_filterfulltext))");
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
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Residentwwds_3_tfresidentbsnnumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Residentwwds_2_tfresidentbsnnumber)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber like :lV65Residentwwds_2_tfresidentbsnnumber)");
         }
         else
         {
            GXv_int13[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Residentwwds_3_tfresidentbsnnumber_sel)) && ! ( StringUtil.StrCmp(AV66Residentwwds_3_tfresidentbsnnumber_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber = ( :AV66Residentwwds_3_tfresidentbsnnumber_sel))");
         }
         else
         {
            GXv_int13[10] = 1;
         }
         if ( StringUtil.StrCmp(AV66Residentwwds_3_tfresidentbsnnumber_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentBsnNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Residentwwds_5_tfresidentgivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Residentwwds_4_tfresidentgivenname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName like :lV67Residentwwds_4_tfresidentgivenname)");
         }
         else
         {
            GXv_int13[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Residentwwds_5_tfresidentgivenname_sel)) && ! ( StringUtil.StrCmp(AV68Residentwwds_5_tfresidentgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName = ( :AV68Residentwwds_5_tfresidentgivenname_sel))");
         }
         else
         {
            GXv_int13[12] = 1;
         }
         if ( StringUtil.StrCmp(AV68Residentwwds_5_tfresidentgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Residentwwds_7_tfresidentlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Residentwwds_6_tfresidentlastname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName like :lV69Residentwwds_6_tfresidentlastname)");
         }
         else
         {
            GXv_int13[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Residentwwds_7_tfresidentlastname_sel)) && ! ( StringUtil.StrCmp(AV70Residentwwds_7_tfresidentlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName = ( :AV70Residentwwds_7_tfresidentlastname_sel))");
         }
         else
         {
            GXv_int13[14] = 1;
         }
         if ( StringUtil.StrCmp(AV70Residentwwds_7_tfresidentlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Residentwwds_9_tfresidentemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Residentwwds_8_tfresidentemail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail like :lV71Residentwwds_8_tfresidentemail)");
         }
         else
         {
            GXv_int13[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Residentwwds_9_tfresidentemail_sel)) && ! ( StringUtil.StrCmp(AV72Residentwwds_9_tfresidentemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail = ( :AV72Residentwwds_9_tfresidentemail_sel))");
         }
         else
         {
            GXv_int13[16] = 1;
         }
         if ( StringUtil.StrCmp(AV72Residentwwds_9_tfresidentemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Residentwwds_11_tfresidentaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Residentwwds_10_tfresidentaddress)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress like :lV73Residentwwds_10_tfresidentaddress)");
         }
         else
         {
            GXv_int13[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Residentwwds_11_tfresidentaddress_sel)) && ! ( StringUtil.StrCmp(AV74Residentwwds_11_tfresidentaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress = ( :AV74Residentwwds_11_tfresidentaddress_sel))");
         }
         else
         {
            GXv_int13[18] = 1;
         }
         if ( StringUtil.StrCmp(AV74Residentwwds_11_tfresidentaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress IS NULL or (char_length(trim(trailing ' ' from T1.ResidentAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Residentwwds_13_tfresidentphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Residentwwds_12_tfresidentphone)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone like :lV75Residentwwds_12_tfresidentphone)");
         }
         else
         {
            GXv_int13[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Residentwwds_13_tfresidentphone_sel)) && ! ( StringUtil.StrCmp(AV76Residentwwds_13_tfresidentphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone = ( :AV76Residentwwds_13_tfresidentphone_sel))");
         }
         else
         {
            GXv_int13[20] = 1;
         }
         if ( StringUtil.StrCmp(AV76Residentwwds_13_tfresidentphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone IS NULL or (char_length(trim(trailing ' ' from T1.ResidentPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Residentwwds_15_tfresidenttypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Residentwwds_14_tfresidenttypename)) ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName like :lV77Residentwwds_14_tfresidenttypename)");
         }
         else
         {
            GXv_int13[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Residentwwds_15_tfresidenttypename_sel)) && ! ( StringUtil.StrCmp(AV78Residentwwds_15_tfresidenttypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName = ( :AV78Residentwwds_15_tfresidenttypename_sel))");
         }
         else
         {
            GXv_int13[22] = 1;
         }
         if ( StringUtil.StrCmp(AV78Residentwwds_15_tfresidenttypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ResidentTypeName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ResidentTypeId";
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
                     return conditional_P002D2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (short)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (short)dynConstraints[25] );
               case 1 :
                     return conditional_P002D3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (short)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (short)dynConstraints[25] );
               case 2 :
                     return conditional_P002D4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (short)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (short)dynConstraints[25] );
               case 3 :
                     return conditional_P002D5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (short)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (short)dynConstraints[25] );
               case 4 :
                     return conditional_P002D6(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (short)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (short)dynConstraints[25] );
               case 5 :
                     return conditional_P002D7(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (short)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (short)dynConstraints[25] );
               case 6 :
                     return conditional_P002D8(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (short)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (short)dynConstraints[25] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP002D2;
          prmP002D2 = new Object[] {
          new ParDef("AV79Udparg16",GXType.Int16,4,0) ,
          new ParDef("AV80Udparg17",GXType.Int16,4,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Residentwwds_2_tfresidentbsnnumber",GXType.VarChar,40,0) ,
          new ParDef("AV66Residentwwds_3_tfresidentbsnnumber_sel",GXType.VarChar,40,0) ,
          new ParDef("lV67Residentwwds_4_tfresidentgivenname",GXType.VarChar,40,0) ,
          new ParDef("AV68Residentwwds_5_tfresidentgivenname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV69Residentwwds_6_tfresidentlastname",GXType.VarChar,40,0) ,
          new ParDef("AV70Residentwwds_7_tfresidentlastname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV71Residentwwds_8_tfresidentemail",GXType.VarChar,100,0) ,
          new ParDef("AV72Residentwwds_9_tfresidentemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV73Residentwwds_10_tfresidentaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV74Residentwwds_11_tfresidentaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV75Residentwwds_12_tfresidentphone",GXType.Char,20,0) ,
          new ParDef("AV76Residentwwds_13_tfresidentphone_sel",GXType.Char,20,0) ,
          new ParDef("lV77Residentwwds_14_tfresidenttypename",GXType.VarChar,40,0) ,
          new ParDef("AV78Residentwwds_15_tfresidenttypename_sel",GXType.VarChar,40,0)
          };
          Object[] prmP002D3;
          prmP002D3 = new Object[] {
          new ParDef("AV79Udparg16",GXType.Int16,4,0) ,
          new ParDef("AV80Udparg17",GXType.Int16,4,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Residentwwds_2_tfresidentbsnnumber",GXType.VarChar,40,0) ,
          new ParDef("AV66Residentwwds_3_tfresidentbsnnumber_sel",GXType.VarChar,40,0) ,
          new ParDef("lV67Residentwwds_4_tfresidentgivenname",GXType.VarChar,40,0) ,
          new ParDef("AV68Residentwwds_5_tfresidentgivenname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV69Residentwwds_6_tfresidentlastname",GXType.VarChar,40,0) ,
          new ParDef("AV70Residentwwds_7_tfresidentlastname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV71Residentwwds_8_tfresidentemail",GXType.VarChar,100,0) ,
          new ParDef("AV72Residentwwds_9_tfresidentemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV73Residentwwds_10_tfresidentaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV74Residentwwds_11_tfresidentaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV75Residentwwds_12_tfresidentphone",GXType.Char,20,0) ,
          new ParDef("AV76Residentwwds_13_tfresidentphone_sel",GXType.Char,20,0) ,
          new ParDef("lV77Residentwwds_14_tfresidenttypename",GXType.VarChar,40,0) ,
          new ParDef("AV78Residentwwds_15_tfresidenttypename_sel",GXType.VarChar,40,0)
          };
          Object[] prmP002D4;
          prmP002D4 = new Object[] {
          new ParDef("AV79Udparg16",GXType.Int16,4,0) ,
          new ParDef("AV80Udparg17",GXType.Int16,4,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Residentwwds_2_tfresidentbsnnumber",GXType.VarChar,40,0) ,
          new ParDef("AV66Residentwwds_3_tfresidentbsnnumber_sel",GXType.VarChar,40,0) ,
          new ParDef("lV67Residentwwds_4_tfresidentgivenname",GXType.VarChar,40,0) ,
          new ParDef("AV68Residentwwds_5_tfresidentgivenname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV69Residentwwds_6_tfresidentlastname",GXType.VarChar,40,0) ,
          new ParDef("AV70Residentwwds_7_tfresidentlastname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV71Residentwwds_8_tfresidentemail",GXType.VarChar,100,0) ,
          new ParDef("AV72Residentwwds_9_tfresidentemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV73Residentwwds_10_tfresidentaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV74Residentwwds_11_tfresidentaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV75Residentwwds_12_tfresidentphone",GXType.Char,20,0) ,
          new ParDef("AV76Residentwwds_13_tfresidentphone_sel",GXType.Char,20,0) ,
          new ParDef("lV77Residentwwds_14_tfresidenttypename",GXType.VarChar,40,0) ,
          new ParDef("AV78Residentwwds_15_tfresidenttypename_sel",GXType.VarChar,40,0)
          };
          Object[] prmP002D5;
          prmP002D5 = new Object[] {
          new ParDef("AV79Udparg16",GXType.Int16,4,0) ,
          new ParDef("AV80Udparg17",GXType.Int16,4,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Residentwwds_2_tfresidentbsnnumber",GXType.VarChar,40,0) ,
          new ParDef("AV66Residentwwds_3_tfresidentbsnnumber_sel",GXType.VarChar,40,0) ,
          new ParDef("lV67Residentwwds_4_tfresidentgivenname",GXType.VarChar,40,0) ,
          new ParDef("AV68Residentwwds_5_tfresidentgivenname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV69Residentwwds_6_tfresidentlastname",GXType.VarChar,40,0) ,
          new ParDef("AV70Residentwwds_7_tfresidentlastname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV71Residentwwds_8_tfresidentemail",GXType.VarChar,100,0) ,
          new ParDef("AV72Residentwwds_9_tfresidentemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV73Residentwwds_10_tfresidentaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV74Residentwwds_11_tfresidentaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV75Residentwwds_12_tfresidentphone",GXType.Char,20,0) ,
          new ParDef("AV76Residentwwds_13_tfresidentphone_sel",GXType.Char,20,0) ,
          new ParDef("lV77Residentwwds_14_tfresidenttypename",GXType.VarChar,40,0) ,
          new ParDef("AV78Residentwwds_15_tfresidenttypename_sel",GXType.VarChar,40,0)
          };
          Object[] prmP002D6;
          prmP002D6 = new Object[] {
          new ParDef("AV79Udparg16",GXType.Int16,4,0) ,
          new ParDef("AV80Udparg17",GXType.Int16,4,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Residentwwds_2_tfresidentbsnnumber",GXType.VarChar,40,0) ,
          new ParDef("AV66Residentwwds_3_tfresidentbsnnumber_sel",GXType.VarChar,40,0) ,
          new ParDef("lV67Residentwwds_4_tfresidentgivenname",GXType.VarChar,40,0) ,
          new ParDef("AV68Residentwwds_5_tfresidentgivenname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV69Residentwwds_6_tfresidentlastname",GXType.VarChar,40,0) ,
          new ParDef("AV70Residentwwds_7_tfresidentlastname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV71Residentwwds_8_tfresidentemail",GXType.VarChar,100,0) ,
          new ParDef("AV72Residentwwds_9_tfresidentemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV73Residentwwds_10_tfresidentaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV74Residentwwds_11_tfresidentaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV75Residentwwds_12_tfresidentphone",GXType.Char,20,0) ,
          new ParDef("AV76Residentwwds_13_tfresidentphone_sel",GXType.Char,20,0) ,
          new ParDef("lV77Residentwwds_14_tfresidenttypename",GXType.VarChar,40,0) ,
          new ParDef("AV78Residentwwds_15_tfresidenttypename_sel",GXType.VarChar,40,0)
          };
          Object[] prmP002D7;
          prmP002D7 = new Object[] {
          new ParDef("AV79Udparg16",GXType.Int16,4,0) ,
          new ParDef("AV80Udparg17",GXType.Int16,4,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Residentwwds_2_tfresidentbsnnumber",GXType.VarChar,40,0) ,
          new ParDef("AV66Residentwwds_3_tfresidentbsnnumber_sel",GXType.VarChar,40,0) ,
          new ParDef("lV67Residentwwds_4_tfresidentgivenname",GXType.VarChar,40,0) ,
          new ParDef("AV68Residentwwds_5_tfresidentgivenname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV69Residentwwds_6_tfresidentlastname",GXType.VarChar,40,0) ,
          new ParDef("AV70Residentwwds_7_tfresidentlastname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV71Residentwwds_8_tfresidentemail",GXType.VarChar,100,0) ,
          new ParDef("AV72Residentwwds_9_tfresidentemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV73Residentwwds_10_tfresidentaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV74Residentwwds_11_tfresidentaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV75Residentwwds_12_tfresidentphone",GXType.Char,20,0) ,
          new ParDef("AV76Residentwwds_13_tfresidentphone_sel",GXType.Char,20,0) ,
          new ParDef("lV77Residentwwds_14_tfresidenttypename",GXType.VarChar,40,0) ,
          new ParDef("AV78Residentwwds_15_tfresidenttypename_sel",GXType.VarChar,40,0)
          };
          Object[] prmP002D8;
          prmP002D8 = new Object[] {
          new ParDef("AV79Udparg16",GXType.Int16,4,0) ,
          new ParDef("AV80Udparg17",GXType.Int16,4,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Residentwwds_2_tfresidentbsnnumber",GXType.VarChar,40,0) ,
          new ParDef("AV66Residentwwds_3_tfresidentbsnnumber_sel",GXType.VarChar,40,0) ,
          new ParDef("lV67Residentwwds_4_tfresidentgivenname",GXType.VarChar,40,0) ,
          new ParDef("AV68Residentwwds_5_tfresidentgivenname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV69Residentwwds_6_tfresidentlastname",GXType.VarChar,40,0) ,
          new ParDef("AV70Residentwwds_7_tfresidentlastname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV71Residentwwds_8_tfresidentemail",GXType.VarChar,100,0) ,
          new ParDef("AV72Residentwwds_9_tfresidentemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV73Residentwwds_10_tfresidentaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV74Residentwwds_11_tfresidentaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV75Residentwwds_12_tfresidentphone",GXType.Char,20,0) ,
          new ParDef("AV76Residentwwds_13_tfresidentphone_sel",GXType.Char,20,0) ,
          new ParDef("lV77Residentwwds_14_tfresidenttypename",GXType.VarChar,40,0) ,
          new ParDef("AV78Residentwwds_15_tfresidenttypename_sel",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002D2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002D2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002D3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002D3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002D4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002D4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002D5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002D5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002D6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002D6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002D7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002D7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002D8", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002D8,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                ((string[]) buf[10])[0] = rslt.getVarchar(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                ((short[]) buf[12])[0] = rslt.getShort(11);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                ((string[]) buf[10])[0] = rslt.getVarchar(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                ((short[]) buf[12])[0] = rslt.getShort(11);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                ((string[]) buf[10])[0] = rslt.getVarchar(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                ((short[]) buf[12])[0] = rslt.getShort(11);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                ((string[]) buf[10])[0] = rslt.getVarchar(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                ((short[]) buf[12])[0] = rslt.getShort(11);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 20);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((string[]) buf[8])[0] = rslt.getVarchar(7);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                ((string[]) buf[10])[0] = rslt.getVarchar(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                ((short[]) buf[12])[0] = rslt.getShort(11);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((string[]) buf[8])[0] = rslt.getVarchar(7);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                ((string[]) buf[10])[0] = rslt.getVarchar(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                ((short[]) buf[12])[0] = rslt.getShort(11);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((string[]) buf[8])[0] = rslt.getVarchar(7);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                ((string[]) buf[10])[0] = rslt.getVarchar(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                ((short[]) buf[12])[0] = rslt.getShort(11);
                return;
       }
    }

 }

}
