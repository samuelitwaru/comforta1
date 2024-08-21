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
namespace GeneXus.Programs {
   public class logtofile : GXProcedure
   {
      public logtofile( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public logtofile( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_Message )
      {
         this.AV9Message = aP0_Message;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_Message )
      {
         logtofile objlogtofile;
         objlogtofile = new logtofile();
         objlogtofile.AV9Message = aP0_Message;
         objlogtofile.context.SetSubmitInitialConfig(context);
         objlogtofile.initialize();
         Submit( executePrivateCatch,objlogtofile);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((logtofile)stateInfo).executePrivate();
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
         AV8File.Source = context.GetMessage( "C:\\GxLogs\\Logs.txt", "");
         AV8File.Open("");
         AV8File.WriteLine(AV9Message);
         AV8File.Close();
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
         AV8File = new GxFile(context.GetPhysicalPath());
         /* GeneXus formulas. */
      }

      private string AV9Message ;
      private GxFile AV8File ;
   }

}
