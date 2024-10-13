using Semiodesk.Trinity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using VDS.RDF.Query.Algebra;
using System.IO;

namespace materTestCore2.Helpers
{
    public static class Queries2
    {
        //public static string prefix = "PREFIX data:<http://www.semanticweb.org/administrator/ontologies/2022/10/data#>";
        public static string prefix = "PREFIX rdf:<http://www.w3.org/1999/02/22-rdf-syntax-ns#>" +
"PREFIX data:<http://www.semanticweb.org/administrator/ontologies/2022/10/data#>" +
"PREFIX persons:<http://www.semanticweb.org/administrator/ontologies/2022/10/personal-data-ontology#> " +
"PREFIX edu:<http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#> " +
"PREFIX health:<http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#> " +
"PREFIX military: <http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#> ";


        public static string officersInjuryQuery = "SELECT DISTINCT ?officer (SUM(?percentage) AS ?per )  " +
"FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/myModel> " +
"WHERE { " +
"?officer rdf:type military:officer . " +
"?officer persons:full_name ?officer_name . " +
"?officer health:patient_has ?details . " +
"?details health:injury_percentage ?percentage . " +
"?officer persons:national_id ?officer_national_id . " +
"?injury health:injury_has ?details . " +
"} group by (?officer) having (?per >";


public static string updateNamedGraphMilitary = "PREFIX military-ontology:<http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#> " +
" INSERT " + 
" {   GRAPH <http://www.semanticweb.org/administrator/ontologies/2022/10/myModel> { ?s ?p ?o . } }" +
" WHERE { ?s ?p ?o . "+
//" FILTER(?p IN (military-ontology:jop_has_unit , military-ontology:jop_has_position , military-ontology:jop_has_officer)) " +
            " FILTER(?p IN (military-ontology:jop_has_unit , military-ontology:jop_has_position )) " +

" FILTER NOT EXISTS { GRAPH <http://www.semanticweb.org/administrator/ontologies/2022/10/myModel> { ?s ?p ?o }}}";

public static string updateNamedGraphHealth = "PREFIX health-ontology:<http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#> " +
            " INSERT " + 
" {   GRAPH <http://www.semanticweb.org/administrator/ontologies/2022/10/myModel> { ?s ?p ?o . } }" +
" WHERE { ?s ?p ?o. "+
//" FILTER(?p IN(health-ontology:patient_injuries_hospital , health-ontology:patient_injuries_injury , health-ontology:patient_injuries_patient)) " +
" FILTER(?p IN(health-ontology:patient_injuries_hospital , health-ontology:patient_injuries_injury)) " +

" FILTER NOT EXISTS { GRAPH <http://www.semanticweb.org/administrator/ontologies/2022/10/myModel> { ?s ?p ?o }}}";

public static string updateNamedGraphEducation = "PREFIX education-ontology:<http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#> " + 
            " INSERT " + 
" {   GRAPH <http://www.semanticweb.org/administrator/ontologies/2022/10/myModel> { ?s ?p ?o . } }" +
" WHERE { ?s ?p ?o. "+
//" FILTER(?p IN(education-ontology:exam_has_course , education-ontology:done_by , education-ontology:enrolled_by)) " +
            " FILTER(?p IN(education-ontology:exam_has_course )) " +

" FILTER NOT EXISTS { GRAPH <http://www.semanticweb.org/administrator/ontologies/2022/10/myModel> { ?s ?p ?o }}}";



//        public static string personsQuery = "SELECT DISTINCT ?person ?person_name ?person_gender ?person_address ?person_national_id " +
//            "FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/defaultModel>" +
// "WHERE { " +
// "?person data:full_name ?person_name . " +
// "?person data:address ?person_address . " +
// "?person data:gender ?person_gender . " +
// "?person data:national_id ?person_national_id  }";


//        public static string studentsQuery = "SELECT DISTINCT ?student ?student_name ?student_gender ?student_address ?student_national_id ?student_graduated ?student_year " +
//            "FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/defaultModel>" +
//  "WHERE { " +
//  "?student data:full_name ?student_name . " +
//  "?student data:address ?student_address . " +
//  "?student data:gender ?student_gender . " +
//  "?student data:national_id ?student_national_id . " +
//  "?student data:student_graduated ?student_graduated . " +
//  "?student data:student_year ?student_year }";

//        public static string examsQuery = "SELECT DISTINCT ?exam ?exam_grade ?exam_pass " +
//            "FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/defaultModel>" +
//            "where { " +
//            "?exam data:exam_grade ?exam_grade ." +
//            "?exam data:exam_pass ?exam_pass} ";

//        public static string examsQuery2 = "SELECT DISTINCT ?exam ?exam_grade ?exam_pass " +
//            "FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/defaultModel>" +
//            "where { " +
//            "?student data:do ?exam . " +
//            "?student data:national_id ?student_national_id . " +
//            "?exam data:exam_grade ?exam_grade . " +
//            "?exam data:exam_pass ?exam_pass  FILTER (?student_national_id = ";

//        public static string examsQuery3 = "SELECT DISTINCT ?exam ?exam_grade ?exam_pass " +
//            "FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/defaultModel>" +
//    "where { " +
//    "?course data:has_exam ?exam ." +
//    "?exam data:exam_grade ?exam_grade ." +
//    "?exam data:exam_pass ?exam_pass filter (str(?course) = '";

//        public static string collegesQuery = "SELECT DISTINCT ?college ?college_name " +
//            "FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/defaultModel>" +
//            "where{ ?college data:college_name ?college_name } ";

//        public static string coursesQuery = "SELECT DISTINCT ?course ?course_name " +
//            "FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/defaultModel>" +
//            "where { " +
//            "?course data:course_name ?course_name} ";

//        public static string patientsQuery = "SELECT DISTINCT ?patient ?patient_name ?patient_gender ?patient_address ?patient_national_id ?patient_is_soldier " +
//            "FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/defaultModel>" +
//  "WHERE { " +
//  "?patient data:full_name ?patient_name ." +
//  "?patient data:address ?patient_address . " +
//  "?patient data:gender ?patient_gender . " +
//  "?patient data:national_id ?patient_national_id . " +
//            "?patient data:is_soldier ?patient_is_soldier  }";

//        public static string hospitalsQuery = "SELECT DISTINCT ?hospital ?hospital_name ?hospital_address  " +
//            "FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/defaultModel>" +
//"WHERE { " +
//            "?hospital data:hospital_name ?hospital_name . " +
//    "?hospital data:hospital_address ?hospital_address  }";

//        public static string injuriesQuery = "SELECT DISTINCT ?injury ?injury_name " +
//            "FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/defaultModel>" +
//"WHERE { " +
//            "?injury data:injury_name ?injury_name  }";

//        public static string patient_injuriesQuery = "SELECT DISTINCT ?injury ?injury_date ?injury_percentage  " +
//            "FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/defaultModel>" +
//"WHERE { " +

//            "?injury data:injury_date ?injury_date . " +
//    "?injury data:injury_percentage ?injury_percentage  }";

//        public static string patient_injuriesQuery2 = "SELECT DISTINCT ?injury ?injury_date ?injury_percentage  " +
//    "FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/defaultModel>" +
//"WHERE { " +

//    "?patient data:national_id ?patient_national_id . " +
//    "?patient data:patient_has ?injury . " +
//    "?injury data:injury_date ?injury_date . " +
//    "injury data:injury_percentage ?injury_percentage filter (?patient_national_id =";

//        public static string patient_injuriesQuery3 = "SELECT DISTINCT ?patient_injury ?injury_date ?injury_percentage  " +
//    "FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/defaultModel>" +
//"WHERE { " +
//    "?injury health:injury_has ?patient_injury . " +
//    "?patient_injury health:injury_date ?injury_date . " +
//    "?patient_injury health:injury_percentage ?injury_percentage filter (str(?injury) = '";


//        public static string patient_injuriesQuery4 = "SELECT DISTINCT ?patient_injury ?injury_date ?injury_percentage  " +
//    "FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/defaultModel>" +
//"WHERE { " +
//    "?hospital data:hospital_has ?patient_injury . " +
//    "?patient_injury data:injury_date ?injury_date . " +
//    "?patient_injury data:injury_percentage ?injury_percentage filter (str(?hospital) = '";

//        public static string specific_patient_injuriesQuery = "SELECT DISTINCT ?name ?injury_name ?date ?injury_percentage " +
//            "FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/defaultModel>" +
//  "WHERE { " +
//  "?patient data:full_name ?name . " +
//  "?patient data:national_id ?patient_national_id . " +
//  "?patient data:patient_has ?details . " +
//  "?details data:injury_date ?date . " +
//  "?details data:injury_percentage ?injury_percentage . " +
//            "?injury data:injury_has ?details ." +
//            "?injury data:injury_name ?injury_name ." +
//            "FILTER (?patient_national_id = ";

//        public static string officersQuery = "SELECT DISTINCT ?officer ?officer_name ?officer_gender ?officer_address ?officer_national_id ?officer_rank ?officer_specialization " +
//            "FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/defaultModel> " +
//  "WHERE { " +

//  "?officer data:full_name ?officer_name . " +
//  "?officer data:address ?officer_address ." +
//  "?officer data:gender ?officer_gender . " +
//  "?officer data:national_id ?officer_national_id . " +
//            "?officer data:officer_rank ?officer_rank . " +
//            "?officer data:officer_specialization ?officer_specialization }";


//        public static string jopsQuery = "SELECT DISTINCT ?jop ?jop_year " +
//"FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/defaultModel>" +
//"WHERE { " +
//"?jop data:jop_year ?jop_year  }";

//        public static string jopsQuery2 = "SELECT DISTINCT ?jop ?jop_year " +
//            "FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/defaultModel>" +
//"WHERE { " +

//            "?officer data:national_id ?officer_national_id . " +
//            "?officer data:officer_has_jop ?jop ." +
//            "?jop military:jop_year ?jop_year .  filter (?officer_national_id =";

//        public static string jopsQuery3 = "SELECT DISTINCT ?jop ?jop_year " +
//    "FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/defaultModel>" +
//"WHERE { " +
//            "?position data:position_has_jop ?jop . " +
//            "?jop data:jop_year ?jop_year    filter (str(?position) = '";

//        public static string jopsQuery4 = "SELECT DISTINCT ?jop ?jop_year " +
//"FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/defaultModel>" +
//"WHERE { " +
//    "?unit data:unit_has_jop ?jop .  " +
//    "?jop data:jop_year ?jop_year    filter (str(?unit) = '";

//        public static string positionsQuery = "SELECT DISTINCT ?position ?position_name ?position_salary " +
//            "FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/defaultModel>" +
//"WHERE { " +
//            "?position data:position_name ?position_name . " +
//    "?position data:position_salary ?position_salary }";

//        public static string unitsQuery = "SELECT DISTINCT ?unit ?unit_name ?unit_positioning_place " +
//            "FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/defaultModel>" +
//"WHERE { " +
//    "?unit data:unit_name ?unit_name . " +
//"?unit data:unit_positioning_place ?unit_positioning_place }";



    }
}
