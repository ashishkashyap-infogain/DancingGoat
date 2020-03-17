using System.Collections.Generic;

namespace Business.Dto.ClassSchema
{

    public class MaxLength
    {
        public string value { get; set; }
    }
    public class Restriction
    {
        public string _base { get; set; }
        public MaxLength maxLength { get; set; }
    }
    public class SimpleType
    {
        public Restriction restriction { get; set; }
    }
    public class Element3
    {
        public string name { get; set; }
        public string ReadOnly { get; set; }
        public string AutoIncrement { get; set; }
        public SimpleType simpleType { get; set; }
        public string minOccurs { get; set; }
        public string DataType { get; set; }
    }
    public class Sequence
    {
        public List<Element3> element { get; set; }
    }
    public class ComplexType2
    {
        public Sequence sequence { get; set; }
    }
    public class Element2
    {
        public string name { get; set; }
        public ComplexType2 complexType { get; set; }
    }
    public class Choice
    {
        public string minOccurs { get; set; }
        public string maxOccurs { get; set; }
        public Element2 element { get; set; }
    }
    public class ComplexType
    {
        public Choice choice { get; set; }
    }
    public class Selector
    {
        public string xpath { get; set; }
    }
    public class Field
    {
        public string xpath { get; set; }
    }
    public class Unique
    {
        public string name { get; set; }
        public string PrimaryKey { get; set; }
        public Selector selector { get; set; }
        public Field field { get; set; }
    }
    public class Element
    {
        public string name { get; set; }
        public string IsDataSet { get; set; }
        public string UseCurrentLocale { get; set; }
        public ComplexType complexType { get; set; }
        public Unique unique { get; set; }
    }
    public class ClassSchemaDto
    {
        public string id { get; set; }
        public Element element { get; set; }
    }
}
