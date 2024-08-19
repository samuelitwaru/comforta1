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
   public class amenitiesloaddvcombo : GXProcedure
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
            return "amenities_Services_Execute" ;
         }

      }

      public amenitiesloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public amenitiesloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           short aP3_AmenitiesId ,
                           string aP4_SearchTxtParms ,
                           out string aP5_SelectedValue ,
                           out string aP6_SelectedText ,
                           out string aP7_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV19IsDynamicCall = aP2_IsDynamicCall;
         this.AV20AmenitiesId = aP3_AmenitiesId;
         this.AV21SearchTxtParms = aP4_SearchTxtParms;
         this.AV22SelectedValue = "" ;
         this.AV23SelectedText = "" ;
         this.AV24Combo_DataJson = "" ;
         initialize();
         executePrivate();
         aP5_SelectedValue=this.AV22SelectedValue;
         aP6_SelectedText=this.AV23SelectedText;
         aP7_Combo_DataJson=this.AV24Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                string aP1_TrnMode ,
                                bool aP2_IsDynamicCall ,
                                short aP3_AmenitiesId ,
                                string aP4_SearchTxtParms ,
                                out string aP5_SelectedValue ,
                                out string aP6_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_AmenitiesId, aP4_SearchTxtParms, out aP5_SelectedValue, out aP6_SelectedText, out aP7_Combo_DataJson);
         return AV24Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 short aP3_AmenitiesId ,
                                 string aP4_SearchTxtParms ,
                                 out string aP5_SelectedValue ,
                                 out string aP6_SelectedText ,
                                 out string aP7_Combo_DataJson )
      {
         amenitiesloaddvcombo objamenitiesloaddvcombo;
         objamenitiesloaddvcombo = new amenitiesloaddvcombo();
         objamenitiesloaddvcombo.AV17ComboName = aP0_ComboName;
         objamenitiesloaddvcombo.AV18TrnMode = aP1_TrnMode;
         objamenitiesloaddvcombo.AV19IsDynamicCall = aP2_IsDynamicCall;
         objamenitiesloaddvcombo.AV20AmenitiesId = aP3_AmenitiesId;
         objamenitiesloaddvcombo.AV21SearchTxtParms = aP4_SearchTxtParms;
         objamenitiesloaddvcombo.AV22SelectedValue = "" ;
         objamenitiesloaddvcombo.AV23SelectedText = "" ;
         objamenitiesloaddvcombo.AV24Combo_DataJson = "" ;
         objamenitiesloaddvcombo.context.SetSubmitInitialConfig(context);
         objamenitiesloaddvcombo.initialize();
         Submit( executePrivateCatch,objamenitiesloaddvcombo);
         aP5_SelectedValue=this.AV22SelectedValue;
         aP6_SelectedText=this.AV23SelectedText;
         aP7_Combo_DataJson=this.AV24Combo_DataJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((amenitiesloaddvcombo)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV17ComboName, "AmenitiesTypeId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_AMENITIESTYPEID' */
            S111 ();
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
         /* 'LOADCOMBOITEMS_AMENITIESTYPEID' Routine */
         returnInSub = false;
         if ( AV19IsDynamicCall )
         {
            GXPagingFrom2 = AV12SkipItems;
            GXPagingTo2 = AV11MaxItems;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV14SearchTxt ,
                                                 A109AmenitiesTypeName } ,
                                                 new int[]{
                                                 }
            });
            lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
            /* Using cursor P00352 */
            pr_default.execute(0, new Object[] {lV14SearchTxt, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A109AmenitiesTypeName = P00352_A109AmenitiesTypeName[0];
               A108AmenitiesTypeId = P00352_A108AmenitiesTypeId[0];
               AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A108AmenitiesTypeId), 4, 0));
               AV16Combo_DataItem.gxTpr_Title = A109AmenitiesTypeName;
               AV15Combo_Data.Add(AV16Combo_DataItem, 0);
               if ( AV15Combo_Data.Count > AV11MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
            AV24Combo_DataJson = AV15Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P00353 */
                  pr_default.execute(1, new Object[] {AV20AmenitiesId});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A107AmenitiesId = P00353_A107AmenitiesId[0];
                     A108AmenitiesTypeId = P00353_A108AmenitiesTypeId[0];
                     A109AmenitiesTypeName = P00353_A109AmenitiesTypeName[0];
                     A109AmenitiesTypeName = P00353_A109AmenitiesTypeName[0];
                     AV22SelectedValue = ((0==A108AmenitiesTypeId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A108AmenitiesTypeId), 4, 0)));
                     AV23SelectedText = A109AmenitiesTypeName;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(1);
               }
               else
               {
                  AV28AmenitiesTypeId = (short)(Math.Round(NumberUtil.Val( AV14SearchTxt, "."), 18, MidpointRounding.ToEven));
                  /* Using cursor P00354 */
                  pr_default.execute(2, new Object[] {AV28AmenitiesTypeId});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A108AmenitiesTypeId = P00354_A108AmenitiesTypeId[0];
                     A109AmenitiesTypeName = P00354_A109AmenitiesTypeName[0];
                     AV23SelectedText = A109AmenitiesTypeName;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(2);
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
         scmdbuf = "";
         lV14SearchTxt = "";
         A109AmenitiesTypeName = "";
         P00352_A109AmenitiesTypeName = new string[] {""} ;
         P00352_A108AmenitiesTypeId = new short[1] ;
         AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV15Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P00353_A107AmenitiesId = new short[1] ;
         P00353_A108AmenitiesTypeId = new short[1] ;
         P00353_A109AmenitiesTypeName = new string[] {""} ;
         P00354_A108AmenitiesTypeId = new short[1] ;
         P00354_A109AmenitiesTypeName = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.amenitiesloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00352_A109AmenitiesTypeName, P00352_A108AmenitiesTypeId
               }
               , new Object[] {
               P00353_A107AmenitiesId, P00353_A108AmenitiesTypeId, P00353_A109AmenitiesTypeName
               }
               , new Object[] {
               P00354_A108AmenitiesTypeId, P00354_A109AmenitiesTypeName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20AmenitiesId ;
      private short AV13PageIndex ;
      private short AV12SkipItems ;
      private short A108AmenitiesTypeId ;
      private short A107AmenitiesId ;
      private short AV28AmenitiesTypeId ;
      private int AV11MaxItems ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
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
      private string lV14SearchTxt ;
      private string A109AmenitiesTypeName ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00352_A109AmenitiesTypeName ;
      private short[] P00352_A108AmenitiesTypeId ;
      private short[] P00353_A107AmenitiesId ;
      private short[] P00353_A108AmenitiesTypeId ;
      private string[] P00353_A109AmenitiesTypeName ;
      private short[] P00354_A108AmenitiesTypeId ;
      private string[] P00354_A109AmenitiesTypeName ;
      private string aP5_SelectedValue ;
      private string aP6_SelectedText ;
      private string aP7_Combo_DataJson ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
   }

   public class amenitiesloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00352( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A109AmenitiesTypeName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " AmenitiesTypeName, AmenitiesTypeId";
         sFromString = " FROM AmenitiesType";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(AmenitiesTypeName like '%' || :lV14SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         sOrderString += " ORDER BY AmenitiesTypeName, AmenitiesTypeId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00352(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00353;
          prmP00353 = new Object[] {
          new ParDef("AV20AmenitiesId",GXType.Int16,4,0)
          };
          Object[] prmP00354;
          prmP00354 = new Object[] {
          new ParDef("AV28AmenitiesTypeId",GXType.Int16,4,0)
          };
          Object[] prmP00352;
          prmP00352 = new Object[] {
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00352", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00352,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00353", "SELECT T1.AmenitiesId, T1.AmenitiesTypeId, T2.AmenitiesTypeName FROM (Amenities T1 INNER JOIN AmenitiesType T2 ON T2.AmenitiesTypeId = T1.AmenitiesTypeId) WHERE T1.AmenitiesId = :AV20AmenitiesId ORDER BY T1.AmenitiesId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00353,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00354", "SELECT AmenitiesTypeId, AmenitiesTypeName FROM AmenitiesType WHERE AmenitiesTypeId = :AV28AmenitiesTypeId ORDER BY AmenitiesTypeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00354,1, GxCacheFrequency.OFF ,false,true )
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
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
