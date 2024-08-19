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
   public class gam_checkuseractivationmethod : GXProcedure
   {
      public gam_checkuseractivationmethod( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gam_checkuseractivationmethod( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_UserGUID ,
                           string aP1_LinkURL ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages )
      {
         this.AV15UserGUID = aP0_UserGUID;
         this.AV10LinkURL = aP1_LinkURL;
         this.AV12Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         initialize();
         executePrivate();
         aP2_Messages=this.AV12Messages;
      }

      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> executeUdp( string aP0_UserGUID ,
                                                                             string aP1_LinkURL )
      {
         execute(aP0_UserGUID, aP1_LinkURL, out aP2_Messages);
         return AV12Messages ;
      }

      public void executeSubmit( string aP0_UserGUID ,
                                 string aP1_LinkURL ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages )
      {
         gam_checkuseractivationmethod objgam_checkuseractivationmethod;
         objgam_checkuseractivationmethod = new gam_checkuseractivationmethod();
         objgam_checkuseractivationmethod.AV15UserGUID = aP0_UserGUID;
         objgam_checkuseractivationmethod.AV10LinkURL = aP1_LinkURL;
         objgam_checkuseractivationmethod.AV12Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         objgam_checkuseractivationmethod.context.SetSubmitInitialConfig(context);
         objgam_checkuseractivationmethod.initialize();
         Submit( executePrivateCatch,objgam_checkuseractivationmethod);
         aP2_Messages=this.AV12Messages;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((gam_checkuseractivationmethod)stateInfo).executePrivate();
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
         AV13Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
         if ( StringUtil.StrCmp(AV13Repository.gxTpr_Useractivationmethod, "U") == 0 )
         {
            AV14User.load( AV15UserGUID);
            AV14User.sendemailtoactivateaccount( AV8Application,  AV10LinkURL, out  AV9GAMErrorCollection);
            if ( AV9GAMErrorCollection.Count == 0 )
            {
               AV11Message = new GeneXus.Utils.SdtMessages_Message(context);
               AV11Message.gxTpr_Type = 0;
               AV11Message.gxTpr_Description = context.GetMessage( "GAM_Theaccountwascreatedsuccessfullyanemailwassentwithinstructionstoactivateyouraccount", "");
               AV12Messages.Add(AV11Message, 0);
            }
            else
            {
               new gam_converterrorstomessages(context ).execute(  AV9GAMErrorCollection, out  AV12Messages) ;
            }
         }
         else if ( StringUtil.StrCmp(AV13Repository.gxTpr_Useractivationmethod, "D") == 0 )
         {
            AV11Message = new GeneXus.Utils.SdtMessages_Message(context);
            AV11Message.gxTpr_Type = 0;
            AV11Message.gxTpr_Description = context.GetMessage( "GAM_Theaccountwascreatedsuccessfullyyoumustwaitforconfirmationfromtheadministrator", "");
            AV12Messages.Add(AV11Message, 0);
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
         AV12Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV13Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV14User = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV8Application = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV9GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV11Message = new GeneXus.Utils.SdtMessages_Message(context);
         /* GeneXus formulas. */
      }

      private string AV15UserGUID ;
      private string AV10LinkURL ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV9GAMErrorCollection ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV12Messages ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV8Application ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV14User ;
      private GeneXus.Utils.SdtMessages_Message AV11Message ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV13Repository ;
   }

}
