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
   public class pagetemplatewwgetfilterdata : GXProcedure
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
            return "pagetemplateww_Services_Execute" ;
         }

      }

      public pagetemplatewwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public pagetemplatewwgetfilterdata( IGxContext context )
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
         this.AV31DDOName = aP0_DDOName;
         this.AV32SearchTxtParms = aP1_SearchTxtParms;
         this.AV33SearchTxtTo = aP2_SearchTxtTo;
         this.AV34OptionsJson = "" ;
         this.AV35OptionsDescJson = "" ;
         this.AV36OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV34OptionsJson;
         aP4_OptionsDescJson=this.AV35OptionsDescJson;
         aP5_OptionIndexesJson=this.AV36OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV36OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         pagetemplatewwgetfilterdata objpagetemplatewwgetfilterdata;
         objpagetemplatewwgetfilterdata = new pagetemplatewwgetfilterdata();
         objpagetemplatewwgetfilterdata.AV31DDOName = aP0_DDOName;
         objpagetemplatewwgetfilterdata.AV32SearchTxtParms = aP1_SearchTxtParms;
         objpagetemplatewwgetfilterdata.AV33SearchTxtTo = aP2_SearchTxtTo;
         objpagetemplatewwgetfilterdata.AV34OptionsJson = "" ;
         objpagetemplatewwgetfilterdata.AV35OptionsDescJson = "" ;
         objpagetemplatewwgetfilterdata.AV36OptionIndexesJson = "" ;
         objpagetemplatewwgetfilterdata.context.SetSubmitInitialConfig(context);
         objpagetemplatewwgetfilterdata.initialize();
         Submit( executePrivateCatch,objpagetemplatewwgetfilterdata);
         aP3_OptionsJson=this.AV34OptionsJson;
         aP4_OptionsDescJson=this.AV35OptionsDescJson;
         aP5_OptionIndexesJson=this.AV36OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pagetemplatewwgetfilterdata)stateInfo).executePrivate();
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
         AV21Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV23OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV24OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV18MaxItems = 10;
         AV17PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV32SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV32SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV15SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV32SearchTxtParms)) ? "" : StringUtil.Substring( AV32SearchTxtParms, 3, -1));
         AV16SkipItems = (short)(AV17PageIndex*AV18MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV31DDOName), "DDO_PAGETEMPLATENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADPAGETEMPLATENAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV31DDOName), "DDO_PAGETEMPLATEDESCRIPTION") == 0 )
         {
            /* Execute user subroutine: 'LOADPAGETEMPLATEDESCRIPTIONOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV34OptionsJson = AV21Options.ToJSonString(false);
         AV35OptionsDescJson = AV23OptionsDesc.ToJSonString(false);
         AV36OptionIndexesJson = AV24OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV26Session.Get("PageTemplateWWGridState"), "") == 0 )
         {
            AV28GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "PageTemplateWWGridState"), null, "", "");
         }
         else
         {
            AV28GridState.FromXml(AV26Session.Get("PageTemplateWWGridState"), null, "", "");
         }
         AV38GXV1 = 1;
         while ( AV38GXV1 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV38GXV1));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV37FilterFullText = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFPAGETEMPLATENAME") == 0 )
            {
               AV11TFPageTemplateName = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFPAGETEMPLATENAME_SEL") == 0 )
            {
               AV12TFPageTemplateName_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFPAGETEMPLATEDESCRIPTION") == 0 )
            {
               AV13TFPageTemplateDescription = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFPAGETEMPLATEDESCRIPTION_SEL") == 0 )
            {
               AV14TFPageTemplateDescription_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            AV38GXV1 = (int)(AV38GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADPAGETEMPLATENAMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFPageTemplateName = AV15SearchTxt;
         AV12TFPageTemplateName_Sel = "";
         AV40Pagetemplatewwds_1_filterfulltext = AV37FilterFullText;
         AV41Pagetemplatewwds_2_tfpagetemplatename = AV11TFPageTemplateName;
         AV42Pagetemplatewwds_3_tfpagetemplatename_sel = AV12TFPageTemplateName_Sel;
         AV43Pagetemplatewwds_4_tfpagetemplatedescription = AV13TFPageTemplateDescription;
         AV44Pagetemplatewwds_5_tfpagetemplatedescription_sel = AV14TFPageTemplateDescription_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV40Pagetemplatewwds_1_filterfulltext ,
                                              AV42Pagetemplatewwds_3_tfpagetemplatename_sel ,
                                              AV41Pagetemplatewwds_2_tfpagetemplatename ,
                                              AV44Pagetemplatewwds_5_tfpagetemplatedescription_sel ,
                                              AV43Pagetemplatewwds_4_tfpagetemplatedescription ,
                                              A103PageTemplateName ,
                                              A106PageTemplateDescription } ,
                                              new int[]{
                                              }
         });
         lV40Pagetemplatewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV40Pagetemplatewwds_1_filterfulltext), "%", "");
         lV40Pagetemplatewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV40Pagetemplatewwds_1_filterfulltext), "%", "");
         lV41Pagetemplatewwds_2_tfpagetemplatename = StringUtil.Concat( StringUtil.RTrim( AV41Pagetemplatewwds_2_tfpagetemplatename), "%", "");
         lV43Pagetemplatewwds_4_tfpagetemplatedescription = StringUtil.Concat( StringUtil.RTrim( AV43Pagetemplatewwds_4_tfpagetemplatedescription), "%", "");
         /* Using cursor P003M2 */
         pr_default.execute(0, new Object[] {lV40Pagetemplatewwds_1_filterfulltext, lV40Pagetemplatewwds_1_filterfulltext, lV41Pagetemplatewwds_2_tfpagetemplatename, AV42Pagetemplatewwds_3_tfpagetemplatename_sel, lV43Pagetemplatewwds_4_tfpagetemplatedescription, AV44Pagetemplatewwds_5_tfpagetemplatedescription_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK3M2 = false;
            A103PageTemplateName = P003M2_A103PageTemplateName[0];
            A106PageTemplateDescription = P003M2_A106PageTemplateDescription[0];
            A102PageTemplateId = P003M2_A102PageTemplateId[0];
            AV25count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P003M2_A103PageTemplateName[0], A103PageTemplateName) == 0 ) )
            {
               BRK3M2 = false;
               A102PageTemplateId = P003M2_A102PageTemplateId[0];
               AV25count = (long)(AV25count+1);
               BRK3M2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV16SkipItems) )
            {
               AV20Option = (String.IsNullOrEmpty(StringUtil.RTrim( A103PageTemplateName)) ? "<#Empty#>" : A103PageTemplateName);
               AV21Options.Add(AV20Option, 0);
               AV24OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV25count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV21Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV16SkipItems = (short)(AV16SkipItems-1);
            }
            if ( ! BRK3M2 )
            {
               BRK3M2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADPAGETEMPLATEDESCRIPTIONOPTIONS' Routine */
         returnInSub = false;
         AV13TFPageTemplateDescription = AV15SearchTxt;
         AV14TFPageTemplateDescription_Sel = "";
         AV40Pagetemplatewwds_1_filterfulltext = AV37FilterFullText;
         AV41Pagetemplatewwds_2_tfpagetemplatename = AV11TFPageTemplateName;
         AV42Pagetemplatewwds_3_tfpagetemplatename_sel = AV12TFPageTemplateName_Sel;
         AV43Pagetemplatewwds_4_tfpagetemplatedescription = AV13TFPageTemplateDescription;
         AV44Pagetemplatewwds_5_tfpagetemplatedescription_sel = AV14TFPageTemplateDescription_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV40Pagetemplatewwds_1_filterfulltext ,
                                              AV42Pagetemplatewwds_3_tfpagetemplatename_sel ,
                                              AV41Pagetemplatewwds_2_tfpagetemplatename ,
                                              AV44Pagetemplatewwds_5_tfpagetemplatedescription_sel ,
                                              AV43Pagetemplatewwds_4_tfpagetemplatedescription ,
                                              A103PageTemplateName ,
                                              A106PageTemplateDescription } ,
                                              new int[]{
                                              }
         });
         lV40Pagetemplatewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV40Pagetemplatewwds_1_filterfulltext), "%", "");
         lV40Pagetemplatewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV40Pagetemplatewwds_1_filterfulltext), "%", "");
         lV41Pagetemplatewwds_2_tfpagetemplatename = StringUtil.Concat( StringUtil.RTrim( AV41Pagetemplatewwds_2_tfpagetemplatename), "%", "");
         lV43Pagetemplatewwds_4_tfpagetemplatedescription = StringUtil.Concat( StringUtil.RTrim( AV43Pagetemplatewwds_4_tfpagetemplatedescription), "%", "");
         /* Using cursor P003M3 */
         pr_default.execute(1, new Object[] {lV40Pagetemplatewwds_1_filterfulltext, lV40Pagetemplatewwds_1_filterfulltext, lV41Pagetemplatewwds_2_tfpagetemplatename, AV42Pagetemplatewwds_3_tfpagetemplatename_sel, lV43Pagetemplatewwds_4_tfpagetemplatedescription, AV44Pagetemplatewwds_5_tfpagetemplatedescription_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK3M4 = false;
            A106PageTemplateDescription = P003M3_A106PageTemplateDescription[0];
            A103PageTemplateName = P003M3_A103PageTemplateName[0];
            A102PageTemplateId = P003M3_A102PageTemplateId[0];
            AV25count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P003M3_A106PageTemplateDescription[0], A106PageTemplateDescription) == 0 ) )
            {
               BRK3M4 = false;
               A102PageTemplateId = P003M3_A102PageTemplateId[0];
               AV25count = (long)(AV25count+1);
               BRK3M4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV16SkipItems) )
            {
               AV20Option = (String.IsNullOrEmpty(StringUtil.RTrim( A106PageTemplateDescription)) ? "<#Empty#>" : A106PageTemplateDescription);
               AV21Options.Add(AV20Option, 0);
               AV24OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV25count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV21Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV16SkipItems = (short)(AV16SkipItems-1);
            }
            if ( ! BRK3M4 )
            {
               BRK3M4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
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
         AV34OptionsJson = "";
         AV35OptionsDescJson = "";
         AV36OptionIndexesJson = "";
         AV21Options = new GxSimpleCollection<string>();
         AV23OptionsDesc = new GxSimpleCollection<string>();
         AV24OptionIndexes = new GxSimpleCollection<string>();
         AV15SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV26Session = context.GetSession();
         AV28GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV29GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV37FilterFullText = "";
         AV11TFPageTemplateName = "";
         AV12TFPageTemplateName_Sel = "";
         AV13TFPageTemplateDescription = "";
         AV14TFPageTemplateDescription_Sel = "";
         AV40Pagetemplatewwds_1_filterfulltext = "";
         AV41Pagetemplatewwds_2_tfpagetemplatename = "";
         AV42Pagetemplatewwds_3_tfpagetemplatename_sel = "";
         AV43Pagetemplatewwds_4_tfpagetemplatedescription = "";
         AV44Pagetemplatewwds_5_tfpagetemplatedescription_sel = "";
         scmdbuf = "";
         lV40Pagetemplatewwds_1_filterfulltext = "";
         lV41Pagetemplatewwds_2_tfpagetemplatename = "";
         lV43Pagetemplatewwds_4_tfpagetemplatedescription = "";
         A103PageTemplateName = "";
         A106PageTemplateDescription = "";
         P003M2_A103PageTemplateName = new string[] {""} ;
         P003M2_A106PageTemplateDescription = new string[] {""} ;
         P003M2_A102PageTemplateId = new short[1] ;
         AV20Option = "";
         P003M3_A106PageTemplateDescription = new string[] {""} ;
         P003M3_A103PageTemplateName = new string[] {""} ;
         P003M3_A102PageTemplateId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pagetemplatewwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P003M2_A103PageTemplateName, P003M2_A106PageTemplateDescription, P003M2_A102PageTemplateId
               }
               , new Object[] {
               P003M3_A106PageTemplateDescription, P003M3_A103PageTemplateName, P003M3_A102PageTemplateId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV18MaxItems ;
      private short AV17PageIndex ;
      private short AV16SkipItems ;
      private short A102PageTemplateId ;
      private int AV38GXV1 ;
      private long AV25count ;
      private string scmdbuf ;
      private bool returnInSub ;
      private bool BRK3M2 ;
      private bool BRK3M4 ;
      private string AV34OptionsJson ;
      private string AV35OptionsDescJson ;
      private string AV36OptionIndexesJson ;
      private string AV31DDOName ;
      private string AV32SearchTxtParms ;
      private string AV33SearchTxtTo ;
      private string AV15SearchTxt ;
      private string AV37FilterFullText ;
      private string AV11TFPageTemplateName ;
      private string AV12TFPageTemplateName_Sel ;
      private string AV13TFPageTemplateDescription ;
      private string AV14TFPageTemplateDescription_Sel ;
      private string AV40Pagetemplatewwds_1_filterfulltext ;
      private string AV41Pagetemplatewwds_2_tfpagetemplatename ;
      private string AV42Pagetemplatewwds_3_tfpagetemplatename_sel ;
      private string AV43Pagetemplatewwds_4_tfpagetemplatedescription ;
      private string AV44Pagetemplatewwds_5_tfpagetemplatedescription_sel ;
      private string lV40Pagetemplatewwds_1_filterfulltext ;
      private string lV41Pagetemplatewwds_2_tfpagetemplatename ;
      private string lV43Pagetemplatewwds_4_tfpagetemplatedescription ;
      private string A103PageTemplateName ;
      private string A106PageTemplateDescription ;
      private string AV20Option ;
      private IGxSession AV26Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P003M2_A103PageTemplateName ;
      private string[] P003M2_A106PageTemplateDescription ;
      private short[] P003M2_A102PageTemplateId ;
      private string[] P003M3_A106PageTemplateDescription ;
      private string[] P003M3_A103PageTemplateName ;
      private short[] P003M3_A102PageTemplateId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV21Options ;
      private GxSimpleCollection<string> AV23OptionsDesc ;
      private GxSimpleCollection<string> AV24OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV28GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV29GridStateFilterValue ;
   }

   public class pagetemplatewwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003M2( IGxContext context ,
                                             string AV40Pagetemplatewwds_1_filterfulltext ,
                                             string AV42Pagetemplatewwds_3_tfpagetemplatename_sel ,
                                             string AV41Pagetemplatewwds_2_tfpagetemplatename ,
                                             string AV44Pagetemplatewwds_5_tfpagetemplatedescription_sel ,
                                             string AV43Pagetemplatewwds_4_tfpagetemplatedescription ,
                                             string A103PageTemplateName ,
                                             string A106PageTemplateDescription )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[6];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT PageTemplateName, PageTemplateDescription, PageTemplateId FROM PageTemplate";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40Pagetemplatewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( PageTemplateName like '%' || :lV40Pagetemplatewwds_1_filterfulltext) or ( PageTemplateDescription like '%' || :lV40Pagetemplatewwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV42Pagetemplatewwds_3_tfpagetemplatename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41Pagetemplatewwds_2_tfpagetemplatename)) ) )
         {
            AddWhere(sWhereString, "(PageTemplateName like :lV41Pagetemplatewwds_2_tfpagetemplatename)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Pagetemplatewwds_3_tfpagetemplatename_sel)) && ! ( StringUtil.StrCmp(AV42Pagetemplatewwds_3_tfpagetemplatename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(PageTemplateName = ( :AV42Pagetemplatewwds_3_tfpagetemplatename_sel))");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( StringUtil.StrCmp(AV42Pagetemplatewwds_3_tfpagetemplatename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from PageTemplateName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44Pagetemplatewwds_5_tfpagetemplatedescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Pagetemplatewwds_4_tfpagetemplatedescription)) ) )
         {
            AddWhere(sWhereString, "(PageTemplateDescription like :lV43Pagetemplatewwds_4_tfpagetemplatedescription)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Pagetemplatewwds_5_tfpagetemplatedescription_sel)) && ! ( StringUtil.StrCmp(AV44Pagetemplatewwds_5_tfpagetemplatedescription_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(PageTemplateDescription = ( :AV44Pagetemplatewwds_5_tfpagetemplatedescription_sel))");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV44Pagetemplatewwds_5_tfpagetemplatedescription_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from PageTemplateDescription))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY PageTemplateName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P003M3( IGxContext context ,
                                             string AV40Pagetemplatewwds_1_filterfulltext ,
                                             string AV42Pagetemplatewwds_3_tfpagetemplatename_sel ,
                                             string AV41Pagetemplatewwds_2_tfpagetemplatename ,
                                             string AV44Pagetemplatewwds_5_tfpagetemplatedescription_sel ,
                                             string AV43Pagetemplatewwds_4_tfpagetemplatedescription ,
                                             string A103PageTemplateName ,
                                             string A106PageTemplateDescription )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT PageTemplateDescription, PageTemplateName, PageTemplateId FROM PageTemplate";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40Pagetemplatewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( PageTemplateName like '%' || :lV40Pagetemplatewwds_1_filterfulltext) or ( PageTemplateDescription like '%' || :lV40Pagetemplatewwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV42Pagetemplatewwds_3_tfpagetemplatename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41Pagetemplatewwds_2_tfpagetemplatename)) ) )
         {
            AddWhere(sWhereString, "(PageTemplateName like :lV41Pagetemplatewwds_2_tfpagetemplatename)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Pagetemplatewwds_3_tfpagetemplatename_sel)) && ! ( StringUtil.StrCmp(AV42Pagetemplatewwds_3_tfpagetemplatename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(PageTemplateName = ( :AV42Pagetemplatewwds_3_tfpagetemplatename_sel))");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( StringUtil.StrCmp(AV42Pagetemplatewwds_3_tfpagetemplatename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from PageTemplateName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44Pagetemplatewwds_5_tfpagetemplatedescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Pagetemplatewwds_4_tfpagetemplatedescription)) ) )
         {
            AddWhere(sWhereString, "(PageTemplateDescription like :lV43Pagetemplatewwds_4_tfpagetemplatedescription)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Pagetemplatewwds_5_tfpagetemplatedescription_sel)) && ! ( StringUtil.StrCmp(AV44Pagetemplatewwds_5_tfpagetemplatedescription_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(PageTemplateDescription = ( :AV44Pagetemplatewwds_5_tfpagetemplatedescription_sel))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV44Pagetemplatewwds_5_tfpagetemplatedescription_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from PageTemplateDescription))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY PageTemplateDescription";
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
                     return conditional_P003M2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] );
               case 1 :
                     return conditional_P003M3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] );
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
          Object[] prmP003M2;
          prmP003M2 = new Object[] {
          new ParDef("lV40Pagetemplatewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV40Pagetemplatewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV41Pagetemplatewwds_2_tfpagetemplatename",GXType.VarChar,40,0) ,
          new ParDef("AV42Pagetemplatewwds_3_tfpagetemplatename_sel",GXType.VarChar,40,0) ,
          new ParDef("lV43Pagetemplatewwds_4_tfpagetemplatedescription",GXType.VarChar,200,0) ,
          new ParDef("AV44Pagetemplatewwds_5_tfpagetemplatedescription_sel",GXType.VarChar,200,0)
          };
          Object[] prmP003M3;
          prmP003M3 = new Object[] {
          new ParDef("lV40Pagetemplatewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV40Pagetemplatewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV41Pagetemplatewwds_2_tfpagetemplatename",GXType.VarChar,40,0) ,
          new ParDef("AV42Pagetemplatewwds_3_tfpagetemplatename_sel",GXType.VarChar,40,0) ,
          new ParDef("lV43Pagetemplatewwds_4_tfpagetemplatedescription",GXType.VarChar,200,0) ,
          new ParDef("AV44Pagetemplatewwds_5_tfpagetemplatedescription_sel",GXType.VarChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003M2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003M2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P003M3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003M3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
       }
    }

 }

}
