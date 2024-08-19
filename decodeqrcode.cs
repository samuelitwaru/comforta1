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
   public class decodeqrcode : GXProcedure
   {
      public decodeqrcode( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public decodeqrcode( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_ScannedCode ,
                           out string aP1_Email ,
                           out string aP2_Password )
      {
         this.AV23ScannedCode = aP0_ScannedCode;
         this.AV12Email = "" ;
         this.AV21Password = "" ;
         initialize();
         executePrivate();
         aP1_Email=this.AV12Email;
         aP2_Password=this.AV21Password;
      }

      public string executeUdp( string aP0_ScannedCode ,
                                out string aP1_Email )
      {
         execute(aP0_ScannedCode, out aP1_Email, out aP2_Password);
         return AV21Password ;
      }

      public void executeSubmit( string aP0_ScannedCode ,
                                 out string aP1_Email ,
                                 out string aP2_Password )
      {
         decodeqrcode objdecodeqrcode;
         objdecodeqrcode = new decodeqrcode();
         objdecodeqrcode.AV23ScannedCode = aP0_ScannedCode;
         objdecodeqrcode.AV12Email = "" ;
         objdecodeqrcode.AV21Password = "" ;
         objdecodeqrcode.context.SetSubmitInitialConfig(context);
         objdecodeqrcode.initialize();
         Submit( executePrivateCatch,objdecodeqrcode);
         aP1_Email=this.AV12Email;
         aP2_Password=this.AV21Password;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((decodeqrcode)stateInfo).executePrivate();
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
         AV15key = context.GetMessage( "76a2173be6393254e72ffa4d6df1030a3d2f94a3bb6d4a6e69a2cda0e056cb13", "");
         AV20nonce = context.GetMessage( "10dd993308d37a15b55f64a0e763f353", "");
         AV11Decrypted = AV24SymmetricBlockCipher.doaeaddecrypt("AES", "AEAD_EAX", AV15key, 128, AV20nonce, AV23ScannedCode);
         AV22Properties.FromJSonString(AV11Decrypted, null);
         AV26User = AV22Properties.Get("user");
         AV10Code = AV22Properties.Get("code");
         AV12Email = Decrypt64( AV26User, AV15key);
         AV21Password = Decrypt64( AV10Code, AV15key);
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
         AV12Email = "";
         AV21Password = "";
         AV15key = "";
         AV20nonce = "";
         AV11Decrypted = "";
         AV24SymmetricBlockCipher = new GeneXus.Programs.genexuscryptography.SdtSymmetricBlockCipher(context);
         AV22Properties = new GXProperties();
         AV26User = "";
         AV10Code = "";
         /* GeneXus formulas. */
      }

      private string AV21Password ;
      private string AV23ScannedCode ;
      private string AV11Decrypted ;
      private string AV12Email ;
      private string AV15key ;
      private string AV20nonce ;
      private string AV26User ;
      private string AV10Code ;
      private GeneXus.Programs.genexuscryptography.SdtSymmetricBlockCipher AV24SymmetricBlockCipher ;
      private string aP1_Email ;
      private string aP2_Password ;
      private GXProperties AV22Properties ;
   }

}
