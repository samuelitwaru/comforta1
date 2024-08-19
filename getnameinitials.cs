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
   public class getnameinitials : GXProcedure
   {
      public getnameinitials( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public getnameinitials( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_GivenName ,
                           string aP1_LastName ,
                           out string aP2_Initials )
      {
         this.AV8GivenName = aP0_GivenName;
         this.AV10LastName = aP1_LastName;
         this.AV9Initials = "" ;
         initialize();
         executePrivate();
         aP2_Initials=this.AV9Initials;
      }

      public string executeUdp( string aP0_GivenName ,
                                string aP1_LastName )
      {
         execute(aP0_GivenName, aP1_LastName, out aP2_Initials);
         return AV9Initials ;
      }

      public void executeSubmit( string aP0_GivenName ,
                                 string aP1_LastName ,
                                 out string aP2_Initials )
      {
         getnameinitials objgetnameinitials;
         objgetnameinitials = new getnameinitials();
         objgetnameinitials.AV8GivenName = aP0_GivenName;
         objgetnameinitials.AV10LastName = aP1_LastName;
         objgetnameinitials.AV9Initials = "" ;
         objgetnameinitials.context.SetSubmitInitialConfig(context);
         objgetnameinitials.initialize();
         Submit( executePrivateCatch,objgetnameinitials);
         aP2_Initials=this.AV9Initials;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getnameinitials)stateInfo).executePrivate();
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
         AV9Initials = StringUtil.CharAt( AV8GivenName, 1) + "" + StringUtil.CharAt( AV10LastName, 1);
         StringUtil.Upper( AV9Initials) ;
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
         AV9Initials = "";
         /* GeneXus formulas. */
      }

      private string AV9Initials ;
      private string AV8GivenName ;
      private string AV10LastName ;
      private string aP2_Initials ;
   }

}
