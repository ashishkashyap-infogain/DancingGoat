//--------------------------------------------------------------------------------------------------
// <auto-generated>
//
//     This code was generated by code generator tool.
//
//     To customize the code use your own partial class. For more info about how to use and customize
//     the generated code see the documentation at http://docs.kentico.com.
//
// </auto-generated>
//--------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

using CMS;
using CMS.Base;
using CMS.Helpers;
using CMS.DataEngine;
using CMS.DocumentEngine.Types.DancingGoatMvc;
using CMS.DocumentEngine;

[assembly: RegisterDocumentType(AboutUsSection.CLASS_NAME, typeof(AboutUsSection))]

namespace CMS.DocumentEngine.Types.DancingGoatMvc
{
	/// <summary>
	/// Represents a content item of type AboutUsSection.
	/// </summary>
	public partial class AboutUsSection : TreeNode
	{
		#region "Constants and variables"

		/// <summary>
		/// The name of the data class.
		/// </summary>
		public const string CLASS_NAME = "DancingGoatMvc.AboutUsSection";


		/// <summary>
		/// The instance of the class that provides extended API for working with AboutUsSection fields.
		/// </summary>
		private readonly AboutUsSectionFields mFields;

		#endregion


		#region "Properties"

		/// <summary>
		/// AboutUsSectionID.
		/// </summary>
		[DatabaseIDField]
		public int AboutUsSectionID
		{
			get
			{
				return ValidationHelper.GetInteger(GetValue("AboutUsSectionID"), 0);
			}
			set
			{
				SetValue("AboutUsSectionID", value);
			}
		}


		/// <summary>
		/// Heading.
		/// </summary>
		[DatabaseField]
		public string AboutUsSectionHeading
		{
			get
			{
				return ValidationHelper.GetString(GetValue("AboutUsSectionHeading"), @"");
			}
			set
			{
				SetValue("AboutUsSectionHeading", value);
			}
		}


		/// <summary>
		/// Image.
		/// </summary>
		[DatabaseField]
		public Guid AboutUsSectionImage
		{
			get
			{
				return ValidationHelper.GetGuid(GetValue("AboutUsSectionImage"), Guid.Empty);
			}
			set
			{
				SetValue("AboutUsSectionImage", value);
			}
		}


		/// <summary>
		/// Text.
		/// </summary>
		[DatabaseField]
		public string AboutUsSectionText
		{
			get
			{
				return ValidationHelper.GetString(GetValue("AboutUsSectionText"), @"");
			}
			set
			{
				SetValue("AboutUsSectionText", value);
			}
		}


		/// <summary>
		/// Gets an object that provides extended API for working with AboutUsSection fields.
		/// </summary>
		[RegisterProperty]
		public AboutUsSectionFields Fields
		{
			get
			{
				return mFields;
			}
		}


		/// <summary>
		/// Provides extended API for working with AboutUsSection fields.
		/// </summary>
		[RegisterAllProperties]
		public partial class AboutUsSectionFields : AbstractHierarchicalObject<AboutUsSectionFields>
		{
			/// <summary>
			/// The content item of type AboutUsSection that is a target of the extended API.
			/// </summary>
			private readonly AboutUsSection mInstance;


			/// <summary>
			/// Initializes a new instance of the <see cref="AboutUsSectionFields" /> class with the specified content item of type AboutUsSection.
			/// </summary>
			/// <param name="instance">The content item of type AboutUsSection that is a target of the extended API.</param>
			public AboutUsSectionFields(AboutUsSection instance)
			{
				mInstance = instance;
			}


			/// <summary>
			/// AboutUsSectionID.
			/// </summary>
			public int ID
			{
				get
				{
					return mInstance.AboutUsSectionID;
				}
				set
				{
					mInstance.AboutUsSectionID = value;
				}
			}


			/// <summary>
			/// Heading.
			/// </summary>
			public string Heading
			{
				get
				{
					return mInstance.AboutUsSectionHeading;
				}
				set
				{
					mInstance.AboutUsSectionHeading = value;
				}
			}


			/// <summary>
			/// Image.
			/// </summary>
			public DocumentAttachment Image
			{
				get
				{
					return mInstance.GetFieldDocumentAttachment("AboutUsSectionImage");
				}
			}


			/// <summary>
			/// Text.
			/// </summary>
			public string Text
			{
				get
				{
					return mInstance.AboutUsSectionText;
				}
				set
				{
					mInstance.AboutUsSectionText = value;
				}
			}
		}

		#endregion


		#region "Constructors"

		/// <summary>
		/// Initializes a new instance of the <see cref="AboutUsSection" /> class.
		/// </summary>
		public AboutUsSection() : base(CLASS_NAME)
		{
			mFields = new AboutUsSectionFields(this);
		}

		#endregion
	}
}