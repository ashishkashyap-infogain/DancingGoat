///////////////////////////////////////////////////////////////////////////
//           Liquid XML Objects GENERATED CODE - DO NOT MODIFY           //
//            https://www.liquid-technologies.com/xml-objects            //
//=======================================================================//
// Dependencies                                                          //
//     Nuget : LiquidTechnologies.XmlObjects.Runtime                     //
//           : MUST BE VERSION 18.0.2                                    //
//=======================================================================//
// Online Help                                                           //
//     https://www.liquid-technologies.com/xml-objects-quick-start-guide //
//=======================================================================//
// Licensing Information                                                 //
//     https://www.liquid-technologies.com/eula                          //
///////////////////////////////////////////////////////////////////////////
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Numerics;
using LiquidTechnologies.XmlObjects;
using LiquidTechnologies.XmlObjects.Attribution;

// ------------------------------------------------------
// |                      Settings                      |
// ------------------------------------------------------
// GenerateCommonBaseClass                  = False
// GenerateUnprocessedNodeHandlers          = False
// RaiseChangeEvents                        = False
// CollectionNaming                         = Pluralize
// Language                                 = CS
// OutputNamespace                          = LiquidTechnologies.GeneratedLx
// WriteDefaultValuesForOptionalAttributes  = False
// WriteDefaultValuesForOptionalElements    = False
// GenerationModel                          = Simple
//                                            *WARNING* this simplified model that is very easy to work with
//                                            but may cause the XML to be produced without regard for element
//                                            cardinality or order. Where very high compliance with the XML Schema
//                                            standard is required use GenerationModelType.Conformant
// XSD Schema Files
//    file://sandbox/schema.xsd


namespace LiquidTechnologies.GeneratedLx
{
    #region Global Settings
    /// <summary>Contains library level properties, and ensures the version of the runtime used matches the version used to generate it.</summary>
    [LxRuntimeRequirements("18.0.2.9849", "Free Community Edition", "M9WDQLWDQNEEVNLX", LiquidTechnologies.XmlObjects.LicenseTermsType.CommunityEdition)]
    public partial class LxRuntimeRequirementsWritten
    {
    }

    #endregion

}

namespace LiquidTechnologies.GeneratedLx.Xs
{
    #region Complex Types
    /// <summary>A class representing the root XSD complexType anyType@http://www.w3.org/2001/XMLSchema</summary>
    /// <XsdPath>schema:.../www.w3.org/2001/XMLSchema/complexType:anyType</XsdPath>
    /// <XsdFile>http://www.w3.org/2001/XMLSchema</XsdFile>
    /// <XsdLocation>Empty</XsdLocation>
    [LxSimpleComplexTypeDefinition("anyType", "http://www.w3.org/2001/XMLSchema")]
    public partial class AnyTypeCt : XElement
    {
        /// <summary>Constructor : create a <see cref="AnyTypeCt" /> element &lt;anyType xmlns='http://www.w3.org/2001/XMLSchema'&gt;</summary>
        public AnyTypeCt() : base(XName.Get("anyType", "http://www.w3.org/2001/XMLSchema")) { }

    }

    #endregion

}

namespace LiquidTechnologies.GeneratedLx.Ns
{
    #region Elements
    /// <summary>A class representing the root XSD element NewDataSet</summary>
    /// <XsdPath>schema:schema.xsd/element:NewDataSet</XsdPath>
    /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
    /// <XsdLocation>3:4-70:17</XsdLocation>
    [LxSimpleElementDefinition("NewDataSet", "", ElementScopeType.GlobalElement)]
    public partial class NewDataSetElm
    {
        /// <summary>A collection of <see cref="LiquidTechnologies.GeneratedLx.Ns.NewDataSetElm.DancingGoatMvc_CafeElm" /></summary>
        [LxElementRef(MinOccurs = 0, MaxOccurs = LxConstants.Unbounded)]
        public List<LiquidTechnologies.GeneratedLx.Ns.NewDataSetElm.DancingGoatMvc_CafeElm> DancingGoatMvc_Cafes { get; } = new List<LiquidTechnologies.GeneratedLx.Ns.NewDataSetElm.DancingGoatMvc_CafeElm>();

        /// <summary>Represent the inline xs:element DancingGoatMvc_Cafe.</summary>
        /// <XsdPath>schema:schema.xsd/element:NewDataSet/choice/element:DancingGoatMvc_Cafe</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>6:13-63:26</XsdLocation>
        [LxSimpleElementDefinition("DancingGoatMvc_Cafe", "", ElementScopeType.InlineElement)]
        public partial class DancingGoatMvc_CafeElm
        {
            /// <summary>A <see cref="System.Int32" />, Required</summary>
            [LxElementValue("CafeID", "", LxValueType.Value, XsdType.XsdInt, MinOccurs = 1, MaxOccurs = 1)]
            public System.Int32 CafeID { get; set; }

            /// <summary>A <see cref="System.String" />, Required : should not be set to null</summary>
            [LxElementValue("CafeName", "", LxValueType.Value, XsdType.XsdString, MinOccurs = 1, MaxOccurs = 1, MaxLength = "50")]
            public System.String CafeName { get; set; } = "";

            /// <summary>A nullable <see cref="System.Boolean" />, Optional : null when not set</summary>
            [LxElementValue("CafeIsCompanyCafe", "", LxValueType.Value, XsdType.XsdBoolean, MinOccurs = 0, MaxOccurs = 1)]
            public System.Boolean? CafeIsCompanyCafe { get; set; }

            /// <summary>A <see cref="System.String" />, Required : should not be set to null</summary>
            [LxElementValue("CafeStreet", "", LxValueType.Value, XsdType.XsdString, MinOccurs = 1, MaxOccurs = 1, MaxLength = "50")]
            public System.String CafeStreet { get; set; } = "";

            /// <summary>A <see cref="System.String" />, Required : should not be set to null</summary>
            [LxElementValue("CafeCity", "", LxValueType.Value, XsdType.XsdString, MinOccurs = 1, MaxOccurs = 1, MaxLength = "50")]
            public System.String CafeCity { get; set; } = "";

            /// <summary>A <see cref="System.String" />, Required : should not be set to null</summary>
            [LxElementValue("CafeCountry", "", LxValueType.Value, XsdType.XsdString, MinOccurs = 1, MaxOccurs = 1, MaxLength = "100")]
            public System.String CafeCountry { get; set; } = "";

            /// <summary>A <see cref="System.String" />, Required : should not be set to null</summary>
            [LxElementValue("CafeZipCode", "", LxValueType.Value, XsdType.XsdString, MinOccurs = 1, MaxOccurs = 1, MaxLength = "15")]
            public System.String CafeZipCode { get; set; } = "";

            /// <summary>A <see cref="System.String" />, Required : should not be set to null</summary>
            [LxElementValue("CafePhone", "", LxValueType.Value, XsdType.XsdString, MinOccurs = 1, MaxOccurs = 1, MaxLength = "30")]
            public System.String CafePhone { get; set; } = "";

            /// <summary>A <see cref="System.String" />, Optional : null when not set</summary>
            [LxElementValue("CafePhoto", "", LxValueType.Value, XsdType.XsdString, MinOccurs = 0, MaxOccurs = 1)]
            public System.String CafePhoto { get; set; }

            /// <summary>A <see cref="System.String" />, Optional : null when not set</summary>
            [LxElementValue("CafeAdditionalNotes", "", LxValueType.Value, XsdType.XsdString, MinOccurs = 0, MaxOccurs = 1, MaxLength = "200")]
            public System.String CafeAdditionalNotes { get; set; }

        }

    }

    #endregion

}