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
namespace GeneXus.Programs.workwithplus {
   public class wwp_calendar_getdisableddays : GXProcedure
   {
      public wwp_calendar_getdisableddays( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_calendar_getdisableddays( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GxSimpleCollection<DateTime> aP0_DisabledDays )
      {
         this.AV9DisabledDays = new GxSimpleCollection<DateTime>() ;
         initialize();
         executePrivate();
         aP0_DisabledDays=this.AV9DisabledDays;
      }

      public GxSimpleCollection<DateTime> executeUdp( )
      {
         execute(out aP0_DisabledDays);
         return AV9DisabledDays ;
      }

      public void executeSubmit( out GxSimpleCollection<DateTime> aP0_DisabledDays )
      {
         wwp_calendar_getdisableddays objwwp_calendar_getdisableddays;
         objwwp_calendar_getdisableddays = new wwp_calendar_getdisableddays();
         objwwp_calendar_getdisableddays.AV9DisabledDays = new GxSimpleCollection<DateTime>() ;
         objwwp_calendar_getdisableddays.context.SetSubmitInitialConfig(context);
         objwwp_calendar_getdisableddays.initialize();
         Submit( executePrivateCatch,objwwp_calendar_getdisableddays);
         aP0_DisabledDays=this.AV9DisabledDays;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_calendar_getdisableddays)stateInfo).executePrivate();
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
         AV9DisabledDays = (GxSimpleCollection<DateTime>)(new GxSimpleCollection<DateTime>());
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
         AV9DisabledDays = new GxSimpleCollection<DateTime>();
         /* GeneXus formulas. */
      }

      private GxSimpleCollection<DateTime> aP0_DisabledDays ;
      private GxSimpleCollection<DateTime> AV9DisabledDays ;
   }

}
