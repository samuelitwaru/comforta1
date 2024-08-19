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
   public class amenitieswwgetfilterdata : GXProcedure
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
            return "amenitiesww_Services_Execute" ;
         }

      }

      public amenitieswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public amenitieswwgetfilterdata( IGxContext context )
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
         this.AV35DDOName = aP0_DDOName;
         this.AV36SearchTxtParms = aP1_SearchTxtParms;
         this.AV37SearchTxtTo = aP2_SearchTxtTo;
         this.AV38OptionsJson = "" ;
         this.AV39OptionsDescJson = "" ;
         this.AV40OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV38OptionsJson;
         aP4_OptionsDescJson=this.AV39OptionsDescJson;
         aP5_OptionIndexesJson=this.AV40OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV40OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         amenitieswwgetfilterdata objamenitieswwgetfilterdata;
         objamenitieswwgetfilterdata = new amenitieswwgetfilterdata();
         objamenitieswwgetfilterdata.AV35DDOName = aP0_DDOName;
         objamenitieswwgetfilterdata.AV36SearchTxtParms = aP1_SearchTxtParms;
         objamenitieswwgetfilterdata.AV37SearchTxtTo = aP2_SearchTxtTo;
         objamenitieswwgetfilterdata.AV38OptionsJson = "" ;
         objamenitieswwgetfilterdata.AV39OptionsDescJson = "" ;
         objamenitieswwgetfilterdata.AV40OptionIndexesJson = "" ;
         objamenitieswwgetfilterdata.context.SetSubmitInitialConfig(context);
         objamenitieswwgetfilterdata.initialize();
         Submit( executePrivateCatch,objamenitieswwgetfilterdata);
         aP3_OptionsJson=this.AV38OptionsJson;
         aP4_OptionsDescJson=this.AV39OptionsDescJson;
         aP5_OptionIndexesJson=this.AV40OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((amenitieswwgetfilterdata)stateInfo).executePrivate();
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
         AV25Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV27OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV28OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV22MaxItems = 10;
         AV21PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV36SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV36SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV19SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV36SearchTxtParms)) ? "" : StringUtil.Substring( AV36SearchTxtParms, 3, -1));
         AV20SkipItems = (short)(AV21PageIndex*AV22MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_AMENITIESNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADAMENITIESNAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_AMENITIESTYPENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADAMENITIESTYPENAMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV38OptionsJson = AV25Options.ToJSonString(false);
         AV39OptionsDescJson = AV27OptionsDesc.ToJSonString(false);
         AV40OptionIndexesJson = AV28OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV30Session.Get("AmenitiesWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "AmenitiesWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("AmenitiesWWGridState"), null, "", "");
         }
         AV42GXV1 = 1;
         while ( AV42GXV1 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV42GXV1));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV41FilterFullText = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFAMENITIESNAME") == 0 )
            {
               AV13TFAmenitiesName = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFAMENITIESNAME_SEL") == 0 )
            {
               AV14TFAmenitiesName_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFAMENITIESTYPENAME") == 0 )
            {
               AV17TFAmenitiesTypeName = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFAMENITIESTYPENAME_SEL") == 0 )
            {
               AV18TFAmenitiesTypeName_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            AV42GXV1 = (int)(AV42GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADAMENITIESNAMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFAmenitiesName = AV19SearchTxt;
         AV14TFAmenitiesName_Sel = "";
         AV44Amenitieswwds_1_filterfulltext = AV41FilterFullText;
         AV45Amenitieswwds_2_tfamenitiesname = AV13TFAmenitiesName;
         AV46Amenitieswwds_3_tfamenitiesname_sel = AV14TFAmenitiesName_Sel;
         AV47Amenitieswwds_4_tfamenitiestypename = AV17TFAmenitiesTypeName;
         AV48Amenitieswwds_5_tfamenitiestypename_sel = AV18TFAmenitiesTypeName_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV44Amenitieswwds_1_filterfulltext ,
                                              AV46Amenitieswwds_3_tfamenitiesname_sel ,
                                              AV45Amenitieswwds_2_tfamenitiesname ,
                                              AV48Amenitieswwds_5_tfamenitiestypename_sel ,
                                              AV47Amenitieswwds_4_tfamenitiestypename ,
                                              A110AmenitiesName ,
                                              A109AmenitiesTypeName } ,
                                              new int[]{
                                              }
         });
         lV44Amenitieswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Amenitieswwds_1_filterfulltext), "%", "");
         lV44Amenitieswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Amenitieswwds_1_filterfulltext), "%", "");
         lV45Amenitieswwds_2_tfamenitiesname = StringUtil.Concat( StringUtil.RTrim( AV45Amenitieswwds_2_tfamenitiesname), "%", "");
         lV47Amenitieswwds_4_tfamenitiestypename = StringUtil.Concat( StringUtil.RTrim( AV47Amenitieswwds_4_tfamenitiestypename), "%", "");
         /* Using cursor P00362 */
         pr_default.execute(0, new Object[] {lV44Amenitieswwds_1_filterfulltext, lV44Amenitieswwds_1_filterfulltext, lV45Amenitieswwds_2_tfamenitiesname, AV46Amenitieswwds_3_tfamenitiesname_sel, lV47Amenitieswwds_4_tfamenitiestypename, AV48Amenitieswwds_5_tfamenitiestypename_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK362 = false;
            A108AmenitiesTypeId = P00362_A108AmenitiesTypeId[0];
            A110AmenitiesName = P00362_A110AmenitiesName[0];
            A109AmenitiesTypeName = P00362_A109AmenitiesTypeName[0];
            A107AmenitiesId = P00362_A107AmenitiesId[0];
            A109AmenitiesTypeName = P00362_A109AmenitiesTypeName[0];
            AV29count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00362_A110AmenitiesName[0], A110AmenitiesName) == 0 ) )
            {
               BRK362 = false;
               A107AmenitiesId = P00362_A107AmenitiesId[0];
               AV29count = (long)(AV29count+1);
               BRK362 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV20SkipItems) )
            {
               AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A110AmenitiesName)) ? "<#Empty#>" : A110AmenitiesName);
               AV25Options.Add(AV24Option, 0);
               AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV29count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV25Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV20SkipItems = (short)(AV20SkipItems-1);
            }
            if ( ! BRK362 )
            {
               BRK362 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADAMENITIESTYPENAMEOPTIONS' Routine */
         returnInSub = false;
         AV17TFAmenitiesTypeName = AV19SearchTxt;
         AV18TFAmenitiesTypeName_Sel = "";
         AV44Amenitieswwds_1_filterfulltext = AV41FilterFullText;
         AV45Amenitieswwds_2_tfamenitiesname = AV13TFAmenitiesName;
         AV46Amenitieswwds_3_tfamenitiesname_sel = AV14TFAmenitiesName_Sel;
         AV47Amenitieswwds_4_tfamenitiestypename = AV17TFAmenitiesTypeName;
         AV48Amenitieswwds_5_tfamenitiestypename_sel = AV18TFAmenitiesTypeName_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV44Amenitieswwds_1_filterfulltext ,
                                              AV46Amenitieswwds_3_tfamenitiesname_sel ,
                                              AV45Amenitieswwds_2_tfamenitiesname ,
                                              AV48Amenitieswwds_5_tfamenitiestypename_sel ,
                                              AV47Amenitieswwds_4_tfamenitiestypename ,
                                              A110AmenitiesName ,
                                              A109AmenitiesTypeName } ,
                                              new int[]{
                                              }
         });
         lV44Amenitieswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Amenitieswwds_1_filterfulltext), "%", "");
         lV44Amenitieswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Amenitieswwds_1_filterfulltext), "%", "");
         lV45Amenitieswwds_2_tfamenitiesname = StringUtil.Concat( StringUtil.RTrim( AV45Amenitieswwds_2_tfamenitiesname), "%", "");
         lV47Amenitieswwds_4_tfamenitiestypename = StringUtil.Concat( StringUtil.RTrim( AV47Amenitieswwds_4_tfamenitiestypename), "%", "");
         /* Using cursor P00363 */
         pr_default.execute(1, new Object[] {lV44Amenitieswwds_1_filterfulltext, lV44Amenitieswwds_1_filterfulltext, lV45Amenitieswwds_2_tfamenitiesname, AV46Amenitieswwds_3_tfamenitiesname_sel, lV47Amenitieswwds_4_tfamenitiestypename, AV48Amenitieswwds_5_tfamenitiestypename_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK364 = false;
            A108AmenitiesTypeId = P00363_A108AmenitiesTypeId[0];
            A109AmenitiesTypeName = P00363_A109AmenitiesTypeName[0];
            A110AmenitiesName = P00363_A110AmenitiesName[0];
            A107AmenitiesId = P00363_A107AmenitiesId[0];
            A109AmenitiesTypeName = P00363_A109AmenitiesTypeName[0];
            AV29count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P00363_A108AmenitiesTypeId[0] == A108AmenitiesTypeId ) )
            {
               BRK364 = false;
               A107AmenitiesId = P00363_A107AmenitiesId[0];
               AV29count = (long)(AV29count+1);
               BRK364 = true;
               pr_default.readNext(1);
            }
            AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A109AmenitiesTypeName)) ? "<#Empty#>" : A109AmenitiesTypeName);
            AV23InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV24Option, "<#Empty#>") != 0 ) && ( AV23InsertIndex <= AV25Options.Count ) && ( ( StringUtil.StrCmp(((string)AV25Options.Item(AV23InsertIndex)), AV24Option) < 0 ) || ( StringUtil.StrCmp(((string)AV25Options.Item(AV23InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV23InsertIndex = (int)(AV23InsertIndex+1);
            }
            AV25Options.Add(AV24Option, AV23InsertIndex);
            AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV29count), "Z,ZZZ,ZZZ,ZZ9")), AV23InsertIndex);
            if ( AV25Options.Count == AV20SkipItems + 11 )
            {
               AV25Options.RemoveItem(AV25Options.Count);
               AV28OptionIndexes.RemoveItem(AV28OptionIndexes.Count);
            }
            if ( ! BRK364 )
            {
               BRK364 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
         while ( AV20SkipItems > 0 )
         {
            AV25Options.RemoveItem(1);
            AV28OptionIndexes.RemoveItem(1);
            AV20SkipItems = (short)(AV20SkipItems-1);
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
         AV38OptionsJson = "";
         AV39OptionsDescJson = "";
         AV40OptionIndexesJson = "";
         AV25Options = new GxSimpleCollection<string>();
         AV27OptionsDesc = new GxSimpleCollection<string>();
         AV28OptionIndexes = new GxSimpleCollection<string>();
         AV19SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV30Session = context.GetSession();
         AV32GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV41FilterFullText = "";
         AV13TFAmenitiesName = "";
         AV14TFAmenitiesName_Sel = "";
         AV17TFAmenitiesTypeName = "";
         AV18TFAmenitiesTypeName_Sel = "";
         AV44Amenitieswwds_1_filterfulltext = "";
         AV45Amenitieswwds_2_tfamenitiesname = "";
         AV46Amenitieswwds_3_tfamenitiesname_sel = "";
         AV47Amenitieswwds_4_tfamenitiestypename = "";
         AV48Amenitieswwds_5_tfamenitiestypename_sel = "";
         scmdbuf = "";
         lV44Amenitieswwds_1_filterfulltext = "";
         lV45Amenitieswwds_2_tfamenitiesname = "";
         lV47Amenitieswwds_4_tfamenitiestypename = "";
         A110AmenitiesName = "";
         A109AmenitiesTypeName = "";
         P00362_A108AmenitiesTypeId = new short[1] ;
         P00362_A110AmenitiesName = new string[] {""} ;
         P00362_A109AmenitiesTypeName = new string[] {""} ;
         P00362_A107AmenitiesId = new short[1] ;
         AV24Option = "";
         P00363_A108AmenitiesTypeId = new short[1] ;
         P00363_A109AmenitiesTypeName = new string[] {""} ;
         P00363_A110AmenitiesName = new string[] {""} ;
         P00363_A107AmenitiesId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.amenitieswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00362_A108AmenitiesTypeId, P00362_A110AmenitiesName, P00362_A109AmenitiesTypeName, P00362_A107AmenitiesId
               }
               , new Object[] {
               P00363_A108AmenitiesTypeId, P00363_A109AmenitiesTypeName, P00363_A110AmenitiesName, P00363_A107AmenitiesId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV22MaxItems ;
      private short AV21PageIndex ;
      private short AV20SkipItems ;
      private short A108AmenitiesTypeId ;
      private short A107AmenitiesId ;
      private int AV42GXV1 ;
      private int AV23InsertIndex ;
      private long AV29count ;
      private string scmdbuf ;
      private bool returnInSub ;
      private bool BRK362 ;
      private bool BRK364 ;
      private string AV38OptionsJson ;
      private string AV39OptionsDescJson ;
      private string AV40OptionIndexesJson ;
      private string AV35DDOName ;
      private string AV36SearchTxtParms ;
      private string AV37SearchTxtTo ;
      private string AV19SearchTxt ;
      private string AV41FilterFullText ;
      private string AV13TFAmenitiesName ;
      private string AV14TFAmenitiesName_Sel ;
      private string AV17TFAmenitiesTypeName ;
      private string AV18TFAmenitiesTypeName_Sel ;
      private string AV44Amenitieswwds_1_filterfulltext ;
      private string AV45Amenitieswwds_2_tfamenitiesname ;
      private string AV46Amenitieswwds_3_tfamenitiesname_sel ;
      private string AV47Amenitieswwds_4_tfamenitiestypename ;
      private string AV48Amenitieswwds_5_tfamenitiestypename_sel ;
      private string lV44Amenitieswwds_1_filterfulltext ;
      private string lV45Amenitieswwds_2_tfamenitiesname ;
      private string lV47Amenitieswwds_4_tfamenitiestypename ;
      private string A110AmenitiesName ;
      private string A109AmenitiesTypeName ;
      private string AV24Option ;
      private IGxSession AV30Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00362_A108AmenitiesTypeId ;
      private string[] P00362_A110AmenitiesName ;
      private string[] P00362_A109AmenitiesTypeName ;
      private short[] P00362_A107AmenitiesId ;
      private short[] P00363_A108AmenitiesTypeId ;
      private string[] P00363_A109AmenitiesTypeName ;
      private string[] P00363_A110AmenitiesName ;
      private short[] P00363_A107AmenitiesId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV25Options ;
      private GxSimpleCollection<string> AV27OptionsDesc ;
      private GxSimpleCollection<string> AV28OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
   }

   public class amenitieswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00362( IGxContext context ,
                                             string AV44Amenitieswwds_1_filterfulltext ,
                                             string AV46Amenitieswwds_3_tfamenitiesname_sel ,
                                             string AV45Amenitieswwds_2_tfamenitiesname ,
                                             string AV48Amenitieswwds_5_tfamenitiestypename_sel ,
                                             string AV47Amenitieswwds_4_tfamenitiestypename ,
                                             string A110AmenitiesName ,
                                             string A109AmenitiesTypeName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[6];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.AmenitiesTypeId, T1.AmenitiesName, T2.AmenitiesTypeName, T1.AmenitiesId FROM (Amenities T1 INNER JOIN AmenitiesType T2 ON T2.AmenitiesTypeId = T1.AmenitiesTypeId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Amenitieswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.AmenitiesName like '%' || :lV44Amenitieswwds_1_filterfulltext) or ( T2.AmenitiesTypeName like '%' || :lV44Amenitieswwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV46Amenitieswwds_3_tfamenitiesname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Amenitieswwds_2_tfamenitiesname)) ) )
         {
            AddWhere(sWhereString, "(T1.AmenitiesName like :lV45Amenitieswwds_2_tfamenitiesname)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Amenitieswwds_3_tfamenitiesname_sel)) && ! ( StringUtil.StrCmp(AV46Amenitieswwds_3_tfamenitiesname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.AmenitiesName = ( :AV46Amenitieswwds_3_tfamenitiesname_sel))");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( StringUtil.StrCmp(AV46Amenitieswwds_3_tfamenitiesname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.AmenitiesName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Amenitieswwds_5_tfamenitiestypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Amenitieswwds_4_tfamenitiestypename)) ) )
         {
            AddWhere(sWhereString, "(T2.AmenitiesTypeName like :lV47Amenitieswwds_4_tfamenitiestypename)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Amenitieswwds_5_tfamenitiestypename_sel)) && ! ( StringUtil.StrCmp(AV48Amenitieswwds_5_tfamenitiestypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.AmenitiesTypeName = ( :AV48Amenitieswwds_5_tfamenitiestypename_sel))");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV48Amenitieswwds_5_tfamenitiestypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.AmenitiesTypeName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.AmenitiesName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00363( IGxContext context ,
                                             string AV44Amenitieswwds_1_filterfulltext ,
                                             string AV46Amenitieswwds_3_tfamenitiesname_sel ,
                                             string AV45Amenitieswwds_2_tfamenitiesname ,
                                             string AV48Amenitieswwds_5_tfamenitiestypename_sel ,
                                             string AV47Amenitieswwds_4_tfamenitiestypename ,
                                             string A110AmenitiesName ,
                                             string A109AmenitiesTypeName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.AmenitiesTypeId, T2.AmenitiesTypeName, T1.AmenitiesName, T1.AmenitiesId FROM (Amenities T1 INNER JOIN AmenitiesType T2 ON T2.AmenitiesTypeId = T1.AmenitiesTypeId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Amenitieswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.AmenitiesName like '%' || :lV44Amenitieswwds_1_filterfulltext) or ( T2.AmenitiesTypeName like '%' || :lV44Amenitieswwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV46Amenitieswwds_3_tfamenitiesname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Amenitieswwds_2_tfamenitiesname)) ) )
         {
            AddWhere(sWhereString, "(T1.AmenitiesName like :lV45Amenitieswwds_2_tfamenitiesname)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Amenitieswwds_3_tfamenitiesname_sel)) && ! ( StringUtil.StrCmp(AV46Amenitieswwds_3_tfamenitiesname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.AmenitiesName = ( :AV46Amenitieswwds_3_tfamenitiesname_sel))");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( StringUtil.StrCmp(AV46Amenitieswwds_3_tfamenitiesname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.AmenitiesName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Amenitieswwds_5_tfamenitiestypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Amenitieswwds_4_tfamenitiestypename)) ) )
         {
            AddWhere(sWhereString, "(T2.AmenitiesTypeName like :lV47Amenitieswwds_4_tfamenitiestypename)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Amenitieswwds_5_tfamenitiestypename_sel)) && ! ( StringUtil.StrCmp(AV48Amenitieswwds_5_tfamenitiestypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.AmenitiesTypeName = ( :AV48Amenitieswwds_5_tfamenitiestypename_sel))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV48Amenitieswwds_5_tfamenitiestypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.AmenitiesTypeName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.AmenitiesTypeId";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00362(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] );
               case 1 :
                     return conditional_P00363(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] );
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
          Object[] prmP00362;
          prmP00362 = new Object[] {
          new ParDef("lV44Amenitieswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV44Amenitieswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV45Amenitieswwds_2_tfamenitiesname",GXType.VarChar,40,0) ,
          new ParDef("AV46Amenitieswwds_3_tfamenitiesname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV47Amenitieswwds_4_tfamenitiestypename",GXType.VarChar,40,0) ,
          new ParDef("AV48Amenitieswwds_5_tfamenitiestypename_sel",GXType.VarChar,40,0)
          };
          Object[] prmP00363;
          prmP00363 = new Object[] {
          new ParDef("lV44Amenitieswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV44Amenitieswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV45Amenitieswwds_2_tfamenitiesname",GXType.VarChar,40,0) ,
          new ParDef("AV46Amenitieswwds_3_tfamenitiesname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV47Amenitieswwds_4_tfamenitiestypename",GXType.VarChar,40,0) ,
          new ParDef("AV48Amenitieswwds_5_tfamenitiestypename_sel",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00362", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00362,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00363", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00363,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
       }
    }

 }

}
