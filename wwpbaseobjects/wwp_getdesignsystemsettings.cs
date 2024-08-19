using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
namespace GeneXus.Programs.wwpbaseobjects {
   public class wwp_getdesignsystemsettings : GXProcedure
   {
      public wwp_getdesignsystemsettings( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_getdesignsystemsettings( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GeneXus.Programs.wwpbaseobjects.SdtWWP_DesignSystemSettings aP0_WWP_DesignSystemSettings )
      {
         this.AV8WWP_DesignSystemSettings = new GeneXus.Programs.wwpbaseobjects.SdtWWP_DesignSystemSettings(context) ;
         initialize();
         executePrivate();
         aP0_WWP_DesignSystemSettings=this.AV8WWP_DesignSystemSettings;
      }

      public GeneXus.Programs.wwpbaseobjects.SdtWWP_DesignSystemSettings executeUdp( )
      {
         execute(out aP0_WWP_DesignSystemSettings);
         return AV8WWP_DesignSystemSettings ;
      }

      public void executeSubmit( out GeneXus.Programs.wwpbaseobjects.SdtWWP_DesignSystemSettings aP0_WWP_DesignSystemSettings )
      {
         wwp_getdesignsystemsettings objwwp_getdesignsystemsettings;
         objwwp_getdesignsystemsettings = new wwp_getdesignsystemsettings();
         objwwp_getdesignsystemsettings.AV8WWP_DesignSystemSettings = new GeneXus.Programs.wwpbaseobjects.SdtWWP_DesignSystemSettings(context) ;
         objwwp_getdesignsystemsettings.context.SetSubmitInitialConfig(context);
         objwwp_getdesignsystemsettings.initialize();
         Submit( executePrivateCatch,objwwp_getdesignsystemsettings);
         aP0_WWP_DesignSystemSettings=this.AV8WWP_DesignSystemSettings;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_getdesignsystemsettings)stateInfo).executePrivate();
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
         GXt_char1 = AV9WWP_DesignSystemSettingsJSON;
         new GeneXus.Programs.wwpbaseobjects.loaduserkeyvalue(context ).execute(  "DesignSystemSettings", out  GXt_char1) ;
         AV9WWP_DesignSystemSettingsJSON = GXt_char1;
         if ( StringUtil.StrCmp(AV9WWP_DesignSystemSettingsJSON, "") != 0 )
         {
            AV8WWP_DesignSystemSettings.FromJSonString(AV9WWP_DesignSystemSettingsJSON, null);
         }
         else
         {
            AV8WWP_DesignSystemSettings = new GeneXus.Programs.wwpbaseobjects.SdtWWP_DesignSystemSettings(context);
            AV8WWP_DesignSystemSettings.gxTpr_Basecolor = "MediumViolet";
            AV8WWP_DesignSystemSettings.gxTpr_Backgroundstyle = "Light";
            AV8WWP_DesignSystemSettings.gxTpr_Menucolor = "Light";
            AV8WWP_DesignSystemSettings.gxTpr_Fontsize = "Medium";
            new GeneXus.Programs.wwpbaseobjects.saveuserkeyvalue(context ).execute(  "DesignSystemSettings",  AV8WWP_DesignSystemSettings.ToJSonString(false, true)) ;
         }
         this.cleanup();
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
         AV8WWP_DesignSystemSettings = new GeneXus.Programs.wwpbaseobjects.SdtWWP_DesignSystemSettings(context);
         AV9WWP_DesignSystemSettingsJSON = "";
         GXt_char1 = "";
         /* GeneXus formulas. */
      }

      private string GXt_char1 ;
      private string AV9WWP_DesignSystemSettingsJSON ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_DesignSystemSettings aP0_WWP_DesignSystemSettings ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_DesignSystemSettings AV8WWP_DesignSystemSettings ;
   }

}
