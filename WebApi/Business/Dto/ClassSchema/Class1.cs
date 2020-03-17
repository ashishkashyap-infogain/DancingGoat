/* 
 Licensed under the Apache License, Version 2.0

 http://www.apache.org/licenses/LICENSE-2.0
 */
using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace Xml2CSharp
{
    [XmlRoot(ElementName = "element", Namespace = "http://www.w3.org/2001/XMLSchema")]
    public class Element
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "ReadOnly", Namespace = "urn:schemas-microsoft-com:xml-msdata")]
        public string ReadOnly { get; set; }
        [XmlAttribute(AttributeName = "AutoIncrement", Namespace = "urn:schemas-microsoft-com:xml-msdata")]
        public string AutoIncrement { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlElement(ElementName = "simpleType", Namespace = "http://www.w3.org/2001/XMLSchema")]
        public SimpleType SimpleType { get; set; }
        [XmlAttribute(AttributeName = "minOccurs")]
        public string MinOccurs { get; set; }
        [XmlAttribute(AttributeName = "DataType", Namespace = "urn:schemas-microsoft-com:xml-msdata")]
        public string DataType { get; set; }
    }

    [XmlRoot(ElementName = "maxLength", Namespace = "http://www.w3.org/2001/XMLSchema")]
    public class MaxLength
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "restriction", Namespace = "http://www.w3.org/2001/XMLSchema")]
    public class Restriction
    {
        [XmlElement(ElementName = "maxLength", Namespace = "http://www.w3.org/2001/XMLSchema")]
        public MaxLength MaxLength { get; set; }
        [XmlAttribute(AttributeName = "base")]
        public string Base { get; set; }
    }

    [XmlRoot(ElementName = "simpleType", Namespace = "http://www.w3.org/2001/XMLSchema")]
    public class SimpleType
    {
        [XmlElement(ElementName = "restriction", Namespace = "http://www.w3.org/2001/XMLSchema")]
        public Restriction Restriction { get; set; }
    }

    [XmlRoot(ElementName = "sequence", Namespace = "http://www.w3.org/2001/XMLSchema")]
    public class Sequence
    {
        [XmlElement(ElementName = "element", Namespace = "http://www.w3.org/2001/XMLSchema")]
        public List<Element> Element { get; set; }
    }

    [XmlRoot(ElementName = "complexType", Namespace = "http://www.w3.org/2001/XMLSchema")]
    public class ComplexType
    {
        [XmlElement(ElementName = "sequence", Namespace = "http://www.w3.org/2001/XMLSchema")]
        public Sequence Sequence { get; set; }
    }

    [XmlRoot(ElementName = "choice", Namespace = "http://www.w3.org/2001/XMLSchema")]
    public class Choice
    {
        [XmlElement(ElementName = "element", Namespace = "http://www.w3.org/2001/XMLSchema")]
        public Element Element { get; set; }
        [XmlAttribute(AttributeName = "minOccurs")]
        public string MinOccurs { get; set; }
        [XmlAttribute(AttributeName = "maxOccurs")]
        public string MaxOccurs { get; set; }
    }

    [XmlRoot(ElementName = "selector", Namespace = "http://www.w3.org/2001/XMLSchema")]
    public class Selector
    {
        [XmlAttribute(AttributeName = "xpath")]
        public string Xpath { get; set; }
    }

    [XmlRoot(ElementName = "field", Namespace = "http://www.w3.org/2001/XMLSchema")]
    public class Field
    {
        [XmlAttribute(AttributeName = "xpath")]
        public string Xpath { get; set; }
    }

    [XmlRoot(ElementName = "unique", Namespace = "http://www.w3.org/2001/XMLSchema")]
    public class Unique
    {
        [XmlElement(ElementName = "selector", Namespace = "http://www.w3.org/2001/XMLSchema")]
        public Selector Selector { get; set; }
        [XmlElement(ElementName = "field", Namespace = "http://www.w3.org/2001/XMLSchema")]
        public Field Field { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "PrimaryKey", Namespace = "urn:schemas-microsoft-com:xml-msdata")]
        public string PrimaryKey { get; set; }
    }

    [XmlRoot(ElementName = "schema", Namespace = "http://www.w3.org/2001/XMLSchema")]
    public class Schema
    {
        [XmlElement(ElementName = "element", Namespace = "http://www.w3.org/2001/XMLSchema")]
        public Element Element { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
        [XmlAttribute(AttributeName = "xs", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xs { get; set; }
        [XmlAttribute(AttributeName = "msdata", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Msdata { get; set; }
    }

}
