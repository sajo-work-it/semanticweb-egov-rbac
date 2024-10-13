// Attention: This file is generated. Any modifications will eventually be overwritten.

using System;
using System.Collections.Generic;
using System.Text;
using Semiodesk.Trinity;

namespace OntologiesNamespace
{
    
///<summary>
///The RDF Concepts Vocabulary (RDF)
///
///</summary>
public class rdf : Ontology
{
    public static readonly Uri Namespace = new Uri("http://www.w3.org/1999/02/22-rdf-syntax-ns#");
    public static Uri GetNamespace() { return Namespace; }
    
    public static readonly string Prefix = "rdf";
    public static string GetPrefix() { return Prefix; } 

    ///<summary>
    ///
    ///<see cref="http://www.w3.org/1999/02/22-rdf-syntax-ns#"/>
    ///</summary>
    public static readonly Resource _22_rdf_syntax_ns = new Resource(new Uri("http://www.w3.org/1999/02/22-rdf-syntax-ns#"));


    ///<summary>
    ///The datatype of RDF literals storing fragments of HTML content
    ///<see cref="http://www.w3.org/1999/02/22-rdf-syntax-ns#HTML"/>
    ///</summary>
    public static readonly Resource HTML = new Resource(new Uri("http://www.w3.org/1999/02/22-rdf-syntax-ns#HTML"));


    ///<summary>
    ///The datatype of language-tagged string values
    ///<see cref="http://www.w3.org/1999/02/22-rdf-syntax-ns#langString"/>
    ///</summary>
    public static readonly Resource langString = new Resource(new Uri("http://www.w3.org/1999/02/22-rdf-syntax-ns#langString"));


    ///<summary>
    ///The class of plain (i.e. untyped) literal values, as used in RIF and OWL 2
    ///<see cref="http://www.w3.org/1999/02/22-rdf-syntax-ns#PlainLiteral"/>
    ///</summary>
    public static readonly Resource PlainLiteral = new Resource(new Uri("http://www.w3.org/1999/02/22-rdf-syntax-ns#PlainLiteral"));


    ///<summary>
    ///The subject is an instance of a class.
    ///<see cref="http://www.w3.org/1999/02/22-rdf-syntax-ns#type"/>
    ///</summary>
    public static readonly Property type = new Property(new Uri("http://www.w3.org/1999/02/22-rdf-syntax-ns#type"));


    ///<summary>
    ///The class of RDF properties.
    ///<see cref="http://www.w3.org/1999/02/22-rdf-syntax-ns#Property"/>
    ///</summary>
    public static readonly Class Property = new Class(new Uri("http://www.w3.org/1999/02/22-rdf-syntax-ns#Property"));


    ///<summary>
    ///The class of RDF statements.
    ///<see cref="http://www.w3.org/1999/02/22-rdf-syntax-ns#Statement"/>
    ///</summary>
    public static readonly Class Statement = new Class(new Uri("http://www.w3.org/1999/02/22-rdf-syntax-ns#Statement"));


    ///<summary>
    ///The subject of the subject RDF statement.
    ///<see cref="http://www.w3.org/1999/02/22-rdf-syntax-ns#subject"/>
    ///</summary>
    public static readonly Property subject = new Property(new Uri("http://www.w3.org/1999/02/22-rdf-syntax-ns#subject"));


    ///<summary>
    ///The predicate of the subject RDF statement.
    ///<see cref="http://www.w3.org/1999/02/22-rdf-syntax-ns#predicate"/>
    ///</summary>
    public static readonly Property predicate = new Property(new Uri("http://www.w3.org/1999/02/22-rdf-syntax-ns#predicate"));


    ///<summary>
    ///The object of the subject RDF statement.
    ///<see cref="http://www.w3.org/1999/02/22-rdf-syntax-ns#object"/>
    ///</summary>
    public static readonly Property _object = new Property(new Uri("http://www.w3.org/1999/02/22-rdf-syntax-ns#object"));


    ///<summary>
    ///The class of unordered containers.
    ///<see cref="http://www.w3.org/1999/02/22-rdf-syntax-ns#Bag"/>
    ///</summary>
    public static readonly Class Bag = new Class(new Uri("http://www.w3.org/1999/02/22-rdf-syntax-ns#Bag"));


    ///<summary>
    ///The class of ordered containers.
    ///<see cref="http://www.w3.org/1999/02/22-rdf-syntax-ns#Seq"/>
    ///</summary>
    public static readonly Class Seq = new Class(new Uri("http://www.w3.org/1999/02/22-rdf-syntax-ns#Seq"));


    ///<summary>
    ///The class of containers of alternatives.
    ///<see cref="http://www.w3.org/1999/02/22-rdf-syntax-ns#Alt"/>
    ///</summary>
    public static readonly Class Alt = new Class(new Uri("http://www.w3.org/1999/02/22-rdf-syntax-ns#Alt"));


    ///<summary>
    ///Idiomatic property used for structured values.
    ///<see cref="http://www.w3.org/1999/02/22-rdf-syntax-ns#value"/>
    ///</summary>
    public static readonly Property value = new Property(new Uri("http://www.w3.org/1999/02/22-rdf-syntax-ns#value"));


    ///<summary>
    ///The class of RDF Lists.
    ///<see cref="http://www.w3.org/1999/02/22-rdf-syntax-ns#List"/>
    ///</summary>
    public static readonly Class List = new Class(new Uri("http://www.w3.org/1999/02/22-rdf-syntax-ns#List"));


    ///<summary>
    ///The empty list, with no items in it. If the rest of a list is nil then the list has no more items in it.
    ///<see cref="http://www.w3.org/1999/02/22-rdf-syntax-ns#nil"/>
    ///</summary>
    public static readonly Resource nil = new Resource(new Uri("http://www.w3.org/1999/02/22-rdf-syntax-ns#nil"));


    ///<summary>
    ///The first item in the subject RDF list.
    ///<see cref="http://www.w3.org/1999/02/22-rdf-syntax-ns#first"/>
    ///</summary>
    public static readonly Property first = new Property(new Uri("http://www.w3.org/1999/02/22-rdf-syntax-ns#first"));


    ///<summary>
    ///The rest of the subject RDF list after the first item.
    ///<see cref="http://www.w3.org/1999/02/22-rdf-syntax-ns#rest"/>
    ///</summary>
    public static readonly Property rest = new Property(new Uri("http://www.w3.org/1999/02/22-rdf-syntax-ns#rest"));


    ///<summary>
    ///The datatype of XML literal values.
    ///<see cref="http://www.w3.org/1999/02/22-rdf-syntax-ns#XMLLiteral"/>
    ///</summary>
    public static readonly Resource XMLLiteral = new Resource(new Uri("http://www.w3.org/1999/02/22-rdf-syntax-ns#XMLLiteral"));

}
///<summary>
///The RDF Concepts Vocabulary (RDF)
///
///</summary>
public static class RDF
{
    public static readonly Uri Namespace = new Uri("http://www.w3.org/1999/02/22-rdf-syntax-ns#");
    public static Uri GetNamespace() { return Namespace; }
    
    public static readonly string Prefix = "RDF";
    public static string GetPrefix() { return Prefix; } 

    ///<summary>
    ///
    ///<see cref="http://www.w3.org/1999/02/22-rdf-syntax-ns#"/>
    ///</summary>
    public const string _22_rdf_syntax_ns = "http://www.w3.org/1999/02/22-rdf-syntax-ns#";

    ///<summary>
    ///The datatype of RDF literals storing fragments of HTML content
    ///<see cref="http://www.w3.org/1999/02/22-rdf-syntax-ns#HTML"/>
    ///</summary>
    public const string HTML = "http://www.w3.org/1999/02/22-rdf-syntax-ns#HTML";

    ///<summary>
    ///The datatype of language-tagged string values
    ///<see cref="http://www.w3.org/1999/02/22-rdf-syntax-ns#langString"/>
    ///</summary>
    public const string langString = "http://www.w3.org/1999/02/22-rdf-syntax-ns#langString";

    ///<summary>
    ///The class of plain (i.e. untyped) literal values, as used in RIF and OWL 2
    ///<see cref="http://www.w3.org/1999/02/22-rdf-syntax-ns#PlainLiteral"/>
    ///</summary>
    public const string PlainLiteral = "http://www.w3.org/1999/02/22-rdf-syntax-ns#PlainLiteral";

    ///<summary>
    ///The subject is an instance of a class.
    ///<see cref="http://www.w3.org/1999/02/22-rdf-syntax-ns#type"/>
    ///</summary>
    public const string type = "http://www.w3.org/1999/02/22-rdf-syntax-ns#type";

    ///<summary>
    ///The class of RDF properties.
    ///<see cref="http://www.w3.org/1999/02/22-rdf-syntax-ns#Property"/>
    ///</summary>
    public const string Property = "http://www.w3.org/1999/02/22-rdf-syntax-ns#Property";

    ///<summary>
    ///The class of RDF statements.
    ///<see cref="http://www.w3.org/1999/02/22-rdf-syntax-ns#Statement"/>
    ///</summary>
    public const string Statement = "http://www.w3.org/1999/02/22-rdf-syntax-ns#Statement";

    ///<summary>
    ///The subject of the subject RDF statement.
    ///<see cref="http://www.w3.org/1999/02/22-rdf-syntax-ns#subject"/>
    ///</summary>
    public const string subject = "http://www.w3.org/1999/02/22-rdf-syntax-ns#subject";

    ///<summary>
    ///The predicate of the subject RDF statement.
    ///<see cref="http://www.w3.org/1999/02/22-rdf-syntax-ns#predicate"/>
    ///</summary>
    public const string predicate = "http://www.w3.org/1999/02/22-rdf-syntax-ns#predicate";

    ///<summary>
    ///The object of the subject RDF statement.
    ///<see cref="http://www.w3.org/1999/02/22-rdf-syntax-ns#object"/>
    ///</summary>
    public const string _object = "http://www.w3.org/1999/02/22-rdf-syntax-ns#object";

    ///<summary>
    ///The class of unordered containers.
    ///<see cref="http://www.w3.org/1999/02/22-rdf-syntax-ns#Bag"/>
    ///</summary>
    public const string Bag = "http://www.w3.org/1999/02/22-rdf-syntax-ns#Bag";

    ///<summary>
    ///The class of ordered containers.
    ///<see cref="http://www.w3.org/1999/02/22-rdf-syntax-ns#Seq"/>
    ///</summary>
    public const string Seq = "http://www.w3.org/1999/02/22-rdf-syntax-ns#Seq";

    ///<summary>
    ///The class of containers of alternatives.
    ///<see cref="http://www.w3.org/1999/02/22-rdf-syntax-ns#Alt"/>
    ///</summary>
    public const string Alt = "http://www.w3.org/1999/02/22-rdf-syntax-ns#Alt";

    ///<summary>
    ///Idiomatic property used for structured values.
    ///<see cref="http://www.w3.org/1999/02/22-rdf-syntax-ns#value"/>
    ///</summary>
    public const string value = "http://www.w3.org/1999/02/22-rdf-syntax-ns#value";

    ///<summary>
    ///The class of RDF Lists.
    ///<see cref="http://www.w3.org/1999/02/22-rdf-syntax-ns#List"/>
    ///</summary>
    public const string List = "http://www.w3.org/1999/02/22-rdf-syntax-ns#List";

    ///<summary>
    ///The empty list, with no items in it. If the rest of a list is nil then the list has no more items in it.
    ///<see cref="http://www.w3.org/1999/02/22-rdf-syntax-ns#nil"/>
    ///</summary>
    public const string nil = "http://www.w3.org/1999/02/22-rdf-syntax-ns#nil";

    ///<summary>
    ///The first item in the subject RDF list.
    ///<see cref="http://www.w3.org/1999/02/22-rdf-syntax-ns#first"/>
    ///</summary>
    public const string first = "http://www.w3.org/1999/02/22-rdf-syntax-ns#first";

    ///<summary>
    ///The rest of the subject RDF list after the first item.
    ///<see cref="http://www.w3.org/1999/02/22-rdf-syntax-ns#rest"/>
    ///</summary>
    public const string rest = "http://www.w3.org/1999/02/22-rdf-syntax-ns#rest";

    ///<summary>
    ///The datatype of XML literal values.
    ///<see cref="http://www.w3.org/1999/02/22-rdf-syntax-ns#XMLLiteral"/>
    ///</summary>
    public const string XMLLiteral = "http://www.w3.org/1999/02/22-rdf-syntax-ns#XMLLiteral";
}

///<summary>
///
///
///</summary>
public class education : Ontology
{
    public static readonly Uri Namespace = new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology/");
    public static Uri GetNamespace() { return Namespace; }
    
    public static readonly string Prefix = "education";
    public static string GetPrefix() { return Prefix; } 

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology"/>
    ///</summary>
    public static readonly Resource education_ontology = new Resource(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#belongs_to"/>
    ///</summary>
    public static readonly Property belongs_to = new Property(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#belongs_to"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#college_has_course"/>
    ///</summary>
    public static readonly Property college_has_course = new Property(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#college_has_course"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#do"/>
    ///</summary>
    public static readonly Property _do = new Property(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#do"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#done_by"/>
    ///</summary>
    public static readonly Property done_by = new Property(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#done_by"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#enrolls_in"/>
    ///</summary>
    public static readonly Property enrolls_in = new Property(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#enrolls_in"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#enrolled_by"/>
    ///</summary>
    public static readonly Property enrolled_by = new Property(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#enrolled_by"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#has_exam"/>
    ///</summary>
    public static readonly Property has_exam = new Property(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#has_exam"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#exam_has_course"/>
    ///</summary>
    public static readonly Property exam_has_course = new Property(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#exam_has_course"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#college_name"/>
    ///</summary>
    public static readonly Property college_name = new Property(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#college_name"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#course_name"/>
    ///</summary>
    public static readonly Property course_name = new Property(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#course_name"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#exam_grade"/>
    ///</summary>
    public static readonly Property exam_grade = new Property(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#exam_grade"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#exam_pass"/>
    ///</summary>
    public static readonly Property exam_pass = new Property(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#exam_pass"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#student_graduated"/>
    ///</summary>
    public static readonly Property student_graduated = new Property(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#student_graduated"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#student_year"/>
    ///</summary>
    public static readonly Property student_year = new Property(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#student_year"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#StudentProfile"/>
    ///</summary>
    public static readonly Class StudentProfile = new Class(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#StudentProfile"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#college"/>
    ///</summary>
    public static readonly Class college = new Class(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#college"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#course"/>
    ///</summary>
    public static readonly Class course = new Class(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#course"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#exam"/>
    ///</summary>
    public static readonly Class exam = new Class(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#exam"));

}
///<summary>
///
///
///</summary>
public static class EDUCATION
{
    public static readonly Uri Namespace = new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology/");
    public static Uri GetNamespace() { return Namespace; }
    
    public static readonly string Prefix = "EDUCATION";
    public static string GetPrefix() { return Prefix; } 

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology"/>
    ///</summary>
    public const string education_ontology = "http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#belongs_to"/>
    ///</summary>
    public const string belongs_to = "http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#belongs_to";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#college_has_course"/>
    ///</summary>
    public const string college_has_course = "http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#college_has_course";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#do"/>
    ///</summary>
    public const string _do = "http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#do";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#done_by"/>
    ///</summary>
    public const string done_by = "http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#done_by";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#enrolls_in"/>
    ///</summary>
    public const string enrolls_in = "http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#enrolls_in";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#enrolled_by"/>
    ///</summary>
    public const string enrolled_by = "http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#enrolled_by";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#has_exam"/>
    ///</summary>
    public const string has_exam = "http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#has_exam";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#exam_has_course"/>
    ///</summary>
    public const string exam_has_course = "http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#exam_has_course";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#college_name"/>
    ///</summary>
    public const string college_name = "http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#college_name";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#course_name"/>
    ///</summary>
    public const string course_name = "http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#course_name";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#exam_grade"/>
    ///</summary>
    public const string exam_grade = "http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#exam_grade";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#exam_pass"/>
    ///</summary>
    public const string exam_pass = "http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#exam_pass";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#student_graduated"/>
    ///</summary>
    public const string student_graduated = "http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#student_graduated";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#student_year"/>
    ///</summary>
    public const string student_year = "http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#student_year";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#StudentProfile"/>
    ///</summary>
    public const string StudentProfile = "http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#StudentProfile";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#college"/>
    ///</summary>
    public const string college = "http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#college";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#course"/>
    ///</summary>
    public const string course = "http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#course";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#exam"/>
    ///</summary>
    public const string exam = "http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#exam";
}

///<summary>
///
///
///</summary>
public class personal : Ontology
{
    public static readonly Uri Namespace = new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/personal-data-ontology/");
    public static Uri GetNamespace() { return Namespace; }
    
    public static readonly string Prefix = "personal";
    public static string GetPrefix() { return Prefix; } 

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/personal-data-ontology"/>
    ///</summary>
    public static readonly Resource personal_data_ontology = new Resource(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/personal-data-ontology"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/personal-data-ontology#address"/>
    ///</summary>
    public static readonly Property address = new Property(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/personal-data-ontology#address"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/personal-data-ontology#full_name"/>
    ///</summary>
    public static readonly Property full_name = new Property(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/personal-data-ontology#full_name"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/personal-data-ontology#gender"/>
    ///</summary>
    public static readonly Property gender = new Property(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/personal-data-ontology#gender"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/personal-data-ontology#national_id"/>
    ///</summary>
    public static readonly Property national_id = new Property(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/personal-data-ontology#national_id"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/personal-data-ontology#PersonProfile"/>
    ///</summary>
    public static readonly Class PersonProfile = new Class(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/personal-data-ontology#PersonProfile"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/personal-data-ontology#Citizen"/>
    ///</summary>
    public static readonly Class Citizen = new Class(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/personal-data-ontology#Citizen"));

}
///<summary>
///
///
///</summary>
public static class PERSONAL
{
    public static readonly Uri Namespace = new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/personal-data-ontology/");
    public static Uri GetNamespace() { return Namespace; }
    
    public static readonly string Prefix = "PERSONAL";
    public static string GetPrefix() { return Prefix; } 

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/personal-data-ontology"/>
    ///</summary>
    public const string personal_data_ontology = "http://www.semanticweb.org/administrator/ontologies/2022/10/personal-data-ontology";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/personal-data-ontology#address"/>
    ///</summary>
    public const string address = "http://www.semanticweb.org/administrator/ontologies/2022/10/personal-data-ontology#address";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/personal-data-ontology#full_name"/>
    ///</summary>
    public const string full_name = "http://www.semanticweb.org/administrator/ontologies/2022/10/personal-data-ontology#full_name";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/personal-data-ontology#gender"/>
    ///</summary>
    public const string gender = "http://www.semanticweb.org/administrator/ontologies/2022/10/personal-data-ontology#gender";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/personal-data-ontology#national_id"/>
    ///</summary>
    public const string national_id = "http://www.semanticweb.org/administrator/ontologies/2022/10/personal-data-ontology#national_id";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/personal-data-ontology#PersonProfile"/>
    ///</summary>
    public const string PersonProfile = "http://www.semanticweb.org/administrator/ontologies/2022/10/personal-data-ontology#PersonProfile";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/personal-data-ontology#Citizen"/>
    ///</summary>
    public const string Citizen = "http://www.semanticweb.org/administrator/ontologies/2022/10/personal-data-ontology#Citizen";
}

///<summary>
///
///
///</summary>
public class health : Ontology
{
    public static readonly Uri Namespace = new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology/");
    public static Uri GetNamespace() { return Namespace; }
    
    public static readonly string Prefix = "health";
    public static string GetPrefix() { return Prefix; } 

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology"/>
    ///</summary>
    public static readonly Resource health_ontology = new Resource(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#hospital_has"/>
    ///</summary>
    public static readonly Property hospital_has = new Property(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#hospital_has"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#patient_injuries_hospital"/>
    ///</summary>
    public static readonly Property patient_injuries_hospital = new Property(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#patient_injuries_hospital"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#injury_has"/>
    ///</summary>
    public static readonly Property injury_has = new Property(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#injury_has"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#patient_injuries_injury"/>
    ///</summary>
    public static readonly Property patient_injuries_injury = new Property(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#patient_injuries_injury"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#patient_has"/>
    ///</summary>
    public static readonly Property patient_has = new Property(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#patient_has"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#patient_injuries_patient"/>
    ///</summary>
    public static readonly Property patient_injuries_patient = new Property(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#patient_injuries_patient"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#hospital_address"/>
    ///</summary>
    public static readonly Property hospital_address = new Property(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#hospital_address"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#hospital_name"/>
    ///</summary>
    public static readonly Property hospital_name = new Property(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#hospital_name"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#injury_date"/>
    ///</summary>
    public static readonly Property injury_date = new Property(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#injury_date"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#injury_name"/>
    ///</summary>
    public static readonly Property injury_name = new Property(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#injury_name"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#injury_percentage"/>
    ///</summary>
    public static readonly Property injury_percentage = new Property(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#injury_percentage"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#is_soldier"/>
    ///</summary>
    public static readonly Property is_soldier = new Property(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#is_soldier"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#hospital"/>
    ///</summary>
    public static readonly Class hospital = new Class(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#hospital"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#injury"/>
    ///</summary>
    public static readonly Class injury = new Class(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#injury"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#patient"/>
    ///</summary>
    public static readonly Class patient = new Class(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#patient"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#patient_injuries"/>
    ///</summary>
    public static readonly Class patient_injuries = new Class(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#patient_injuries"));

}
///<summary>
///
///
///</summary>
public static class HEALTH
{
    public static readonly Uri Namespace = new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology/");
    public static Uri GetNamespace() { return Namespace; }
    
    public static readonly string Prefix = "HEALTH";
    public static string GetPrefix() { return Prefix; } 

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology"/>
    ///</summary>
    public const string health_ontology = "http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#hospital_has"/>
    ///</summary>
    public const string hospital_has = "http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#hospital_has";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#patient_injuries_hospital"/>
    ///</summary>
    public const string patient_injuries_hospital = "http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#patient_injuries_hospital";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#injury_has"/>
    ///</summary>
    public const string injury_has = "http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#injury_has";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#patient_injuries_injury"/>
    ///</summary>
    public const string patient_injuries_injury = "http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#patient_injuries_injury";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#patient_has"/>
    ///</summary>
    public const string patient_has = "http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#patient_has";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#patient_injuries_patient"/>
    ///</summary>
    public const string patient_injuries_patient = "http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#patient_injuries_patient";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#hospital_address"/>
    ///</summary>
    public const string hospital_address = "http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#hospital_address";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#hospital_name"/>
    ///</summary>
    public const string hospital_name = "http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#hospital_name";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#injury_date"/>
    ///</summary>
    public const string injury_date = "http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#injury_date";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#injury_name"/>
    ///</summary>
    public const string injury_name = "http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#injury_name";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#injury_percentage"/>
    ///</summary>
    public const string injury_percentage = "http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#injury_percentage";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#is_soldier"/>
    ///</summary>
    public const string is_soldier = "http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#is_soldier";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#hospital"/>
    ///</summary>
    public const string hospital = "http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#hospital";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#injury"/>
    ///</summary>
    public const string injury = "http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#injury";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#patient"/>
    ///</summary>
    public const string patient = "http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#patient";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#patient_injuries"/>
    ///</summary>
    public const string patient_injuries = "http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#patient_injuries";
}

///<summary>
///
///
///</summary>
public class military : Ontology
{
    public static readonly Uri Namespace = new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology/");
    public static Uri GetNamespace() { return Namespace; }
    
    public static readonly string Prefix = "military";
    public static string GetPrefix() { return Prefix; } 

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology"/>
    ///</summary>
    public static readonly Resource military_ontology = new Resource(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#officer_has_jop"/>
    ///</summary>
    public static readonly Property officer_has_jop = new Property(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#officer_has_jop"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#jop_has_officer"/>
    ///</summary>
    public static readonly Property jop_has_officer = new Property(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#jop_has_officer"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#position_has_jop"/>
    ///</summary>
    public static readonly Property position_has_jop = new Property(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#position_has_jop"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#jop_has_position"/>
    ///</summary>
    public static readonly Property jop_has_position = new Property(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#jop_has_position"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#unit_has_jop"/>
    ///</summary>
    public static readonly Property unit_has_jop = new Property(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#unit_has_jop"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#jop_has_unit"/>
    ///</summary>
    public static readonly Property jop_has_unit = new Property(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#jop_has_unit"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#jop_year"/>
    ///</summary>
    public static readonly Property jop_year = new Property(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#jop_year"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#officer_rank"/>
    ///</summary>
    public static readonly Property officer_rank = new Property(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#officer_rank"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#officer_specialization"/>
    ///</summary>
    public static readonly Property officer_specialization = new Property(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#officer_specialization"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#position_name"/>
    ///</summary>
    public static readonly Property position_name = new Property(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#position_name"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#position_salary"/>
    ///</summary>
    public static readonly Property position_salary = new Property(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#position_salary"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#unit_name"/>
    ///</summary>
    public static readonly Property unit_name = new Property(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#unit_name"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#unit_positioning_place"/>
    ///</summary>
    public static readonly Property unit_positioning_place = new Property(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#unit_positioning_place"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#jop"/>
    ///</summary>
    public static readonly Class jop = new Class(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#jop"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#officer"/>
    ///</summary>
    public static readonly Class officer = new Class(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#officer"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#position"/>
    ///</summary>
    public static readonly Class position = new Class(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#position"));


    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#unit"/>
    ///</summary>
    public static readonly Class unit = new Class(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#unit"));

}
///<summary>
///
///
///</summary>
public static class MILITARY
{
    public static readonly Uri Namespace = new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology/");
    public static Uri GetNamespace() { return Namespace; }
    
    public static readonly string Prefix = "MILITARY";
    public static string GetPrefix() { return Prefix; } 

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology"/>
    ///</summary>
    public const string military_ontology = "http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#officer_has_jop"/>
    ///</summary>
    public const string officer_has_jop = "http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#officer_has_jop";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#jop_has_officer"/>
    ///</summary>
    public const string jop_has_officer = "http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#jop_has_officer";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#position_has_jop"/>
    ///</summary>
    public const string position_has_jop = "http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#position_has_jop";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#jop_has_position"/>
    ///</summary>
    public const string jop_has_position = "http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#jop_has_position";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#unit_has_jop"/>
    ///</summary>
    public const string unit_has_jop = "http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#unit_has_jop";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#jop_has_unit"/>
    ///</summary>
    public const string jop_has_unit = "http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#jop_has_unit";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#jop_year"/>
    ///</summary>
    public const string jop_year = "http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#jop_year";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#officer_rank"/>
    ///</summary>
    public const string officer_rank = "http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#officer_rank";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#officer_specialization"/>
    ///</summary>
    public const string officer_specialization = "http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#officer_specialization";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#position_name"/>
    ///</summary>
    public const string position_name = "http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#position_name";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#position_salary"/>
    ///</summary>
    public const string position_salary = "http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#position_salary";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#unit_name"/>
    ///</summary>
    public const string unit_name = "http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#unit_name";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#unit_positioning_place"/>
    ///</summary>
    public const string unit_positioning_place = "http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#unit_positioning_place";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#jop"/>
    ///</summary>
    public const string jop = "http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#jop";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#officer"/>
    ///</summary>
    public const string officer = "http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#officer";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#position"/>
    ///</summary>
    public const string position = "http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#position";

    ///<summary>
    ///
    ///<see cref="http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#unit"/>
    ///</summary>
    public const string unit = "http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#unit";
}

}