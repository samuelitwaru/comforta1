using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class GxFullTextSearchReindexer
   {
      public static int Reindex( IGxContext context )
      {
         GxSilentTrnSdt obj;
         IGxSilentTrn trn;
         bool result;
         obj = new SdtSupplier_Agb(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtResident(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtCustomer(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtSupplier_Gen(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new GeneXus.Programs.workwithplus.SdtWWP_Parameter(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtPageTemplate(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtLocationEvent(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtCustomerCustomization(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtPage(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         return 1 ;
      }

   }

}
