/*
				   File: type_SdtCreateLocationData_Step1
			Description: Step1
				 Author: Nemo 🐠 for C# (.NET) version 18.0.6.177934
		   Program type: Callable routine
			  Main DBMS: 
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;


namespace GeneXus.Programs
{
	[XmlRoot(ElementName="CreateLocationData.Step1")]
	[XmlType(TypeName="CreateLocationData.Step1" , Namespace="Comforta11" )]
	[Serializable]
	public class SdtCreateLocationData_Step1 : GxUserType
	{
		public SdtCreateLocationData_Step1( )
		{
			/* Constructor for serialization */
			gxTv_SdtCreateLocationData_Step1_Customerlocationemail = "";

			gxTv_SdtCreateLocationData_Step1_Customerlocationphone = "";

			gxTv_SdtCreateLocationData_Step1_Customerlocationpostaladdress = "";

			gxTv_SdtCreateLocationData_Step1_Customerlocationvisitingaddress = "";

		}

		public SdtCreateLocationData_Step1(IGxContext context)
		{
			this.context = context;	
			initialize();
		}

		#region Json
		private static Hashtable mapper;
		public override string JsonMap(string value)
		{
			if (mapper == null)
			{
				mapper = new Hashtable();
			}
			return (string)mapper[value]; ;
		}

		public override void ToJSON()
		{
			ToJSON(true) ;
			return;
		}

		public override void ToJSON(bool includeState)
		{
			AddObjectProperty("CustomerLocationId", gxTpr_Customerlocationid, false);


			AddObjectProperty("CustomerLocationEmail", gxTpr_Customerlocationemail, false);


			AddObjectProperty("CustomerLocationPhone", gxTpr_Customerlocationphone, false);


			AddObjectProperty("CustomerLocationPostalAddress", gxTpr_Customerlocationpostaladdress, false);


			AddObjectProperty("CustomerLocationVisitingAddress", gxTpr_Customerlocationvisitingaddress, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="CustomerLocationId")]
		[XmlElement(ElementName="CustomerLocationId")]
		public short gxTpr_Customerlocationid
		{
			get {
				return gxTv_SdtCreateLocationData_Step1_Customerlocationid; 
			}
			set {
				gxTv_SdtCreateLocationData_Step1_Customerlocationid = value;
				SetDirty("Customerlocationid");
			}
		}




		[SoapElement(ElementName="CustomerLocationEmail")]
		[XmlElement(ElementName="CustomerLocationEmail")]
		public string gxTpr_Customerlocationemail
		{
			get {
				return gxTv_SdtCreateLocationData_Step1_Customerlocationemail; 
			}
			set {
				gxTv_SdtCreateLocationData_Step1_Customerlocationemail = value;
				SetDirty("Customerlocationemail");
			}
		}




		[SoapElement(ElementName="CustomerLocationPhone")]
		[XmlElement(ElementName="CustomerLocationPhone")]
		public string gxTpr_Customerlocationphone
		{
			get {
				return gxTv_SdtCreateLocationData_Step1_Customerlocationphone; 
			}
			set {
				gxTv_SdtCreateLocationData_Step1_Customerlocationphone = value;
				SetDirty("Customerlocationphone");
			}
		}




		[SoapElement(ElementName="CustomerLocationPostalAddress")]
		[XmlElement(ElementName="CustomerLocationPostalAddress")]
		public string gxTpr_Customerlocationpostaladdress
		{
			get {
				return gxTv_SdtCreateLocationData_Step1_Customerlocationpostaladdress; 
			}
			set {
				gxTv_SdtCreateLocationData_Step1_Customerlocationpostaladdress = value;
				SetDirty("Customerlocationpostaladdress");
			}
		}




		[SoapElement(ElementName="CustomerLocationVisitingAddress")]
		[XmlElement(ElementName="CustomerLocationVisitingAddress")]
		public string gxTpr_Customerlocationvisitingaddress
		{
			get {
				return gxTv_SdtCreateLocationData_Step1_Customerlocationvisitingaddress; 
			}
			set {
				gxTv_SdtCreateLocationData_Step1_Customerlocationvisitingaddress = value;
				SetDirty("Customerlocationvisitingaddress");
			}
		}



		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtCreateLocationData_Step1_Customerlocationemail = "";
			gxTv_SdtCreateLocationData_Step1_Customerlocationphone = "";
			gxTv_SdtCreateLocationData_Step1_Customerlocationpostaladdress = "";
			gxTv_SdtCreateLocationData_Step1_Customerlocationvisitingaddress = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtCreateLocationData_Step1_Customerlocationid;
		 

		protected string gxTv_SdtCreateLocationData_Step1_Customerlocationemail;
		 

		protected string gxTv_SdtCreateLocationData_Step1_Customerlocationphone;
		 

		protected string gxTv_SdtCreateLocationData_Step1_Customerlocationpostaladdress;
		 

		protected string gxTv_SdtCreateLocationData_Step1_Customerlocationvisitingaddress;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"CreateLocationData.Step1", Namespace="Comforta11")]
	public class SdtCreateLocationData_Step1_RESTInterface : GxGenericCollectionItem<SdtCreateLocationData_Step1>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtCreateLocationData_Step1_RESTInterface( ) : base()
		{	
		}

		public SdtCreateLocationData_Step1_RESTInterface( SdtCreateLocationData_Step1 psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="CustomerLocationId", Order=0)]
		public short gxTpr_Customerlocationid
		{
			get { 
				return sdt.gxTpr_Customerlocationid;

			}
			set { 
				sdt.gxTpr_Customerlocationid = value;
			}
		}

		[DataMember(Name="CustomerLocationEmail", Order=1)]
		public  string gxTpr_Customerlocationemail
		{
			get { 
				return sdt.gxTpr_Customerlocationemail;

			}
			set { 
				 sdt.gxTpr_Customerlocationemail = value;
			}
		}

		[DataMember(Name="CustomerLocationPhone", Order=2)]
		public  string gxTpr_Customerlocationphone
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Customerlocationphone);

			}
			set { 
				 sdt.gxTpr_Customerlocationphone = value;
			}
		}

		[DataMember(Name="CustomerLocationPostalAddress", Order=3)]
		public  string gxTpr_Customerlocationpostaladdress
		{
			get { 
				return sdt.gxTpr_Customerlocationpostaladdress;

			}
			set { 
				 sdt.gxTpr_Customerlocationpostaladdress = value;
			}
		}

		[DataMember(Name="CustomerLocationVisitingAddress", Order=4)]
		public  string gxTpr_Customerlocationvisitingaddress
		{
			get { 
				return sdt.gxTpr_Customerlocationvisitingaddress;

			}
			set { 
				 sdt.gxTpr_Customerlocationvisitingaddress = value;
			}
		}


		#endregion

		public SdtCreateLocationData_Step1 sdt
		{
			get { 
				return (SdtCreateLocationData_Step1)Sdt;
			}
			set { 
				Sdt = value;
			}
		}

		[OnDeserializing]
		void checkSdt( StreamingContext ctx )
		{
			if ( sdt == null )
			{
				sdt = new SdtCreateLocationData_Step1() ;
			}
		}
	}
	#endregion
}