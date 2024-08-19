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
   public class getloggedinuser : GXProcedure
   {
      public getloggedinuser( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public getloggedinuser( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GeneXus.Programs.genexussecurity.SdtGAMUser aP0_GAMUser )
      {
         this.AV10GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context) ;
         initialize();
         executePrivate();
         aP0_GAMUser=this.AV10GAMUser;
      }

      public GeneXus.Programs.genexussecurity.SdtGAMUser executeUdp( )
      {
         execute(out aP0_GAMUser);
         return AV10GAMUser ;
      }

      public void executeSubmit( out GeneXus.Programs.genexussecurity.SdtGAMUser aP0_GAMUser )
      {
         getloggedinuser objgetloggedinuser;
         objgetloggedinuser = new getloggedinuser();
         objgetloggedinuser.AV10GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context) ;
         objgetloggedinuser.context.SetSubmitInitialConfig(context);
         objgetloggedinuser.initialize();
         Submit( executePrivateCatch,objgetloggedinuser);
         aP0_GAMUser=this.AV10GAMUser;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getloggedinuser)stateInfo).executePrivate();
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
         AV9GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV8GAMErrors);
         AV10GAMUser = AV9GAMSession.gxTpr_User;
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
         AV10GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV9GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV8GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         /* GeneXus formulas. */
      }

      private GeneXus.Programs.genexussecurity.SdtGAMUser aP0_GAMUser ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV8GAMErrors ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV9GAMSession ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV10GAMUser ;
   }

}
