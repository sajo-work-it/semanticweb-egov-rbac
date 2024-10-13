using Semiodesk.Trinity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace materTestCore2.Helpers
{
    public static class Queries
    {
        public static string prefix = "PREFIX rdf:<http://www.w3.org/1999/02/22-rdf-syntax-ns#>" +
"PREFIX rdfs:<http://www.w3.org/2000/01/rdf-schema#>" +
            "PREFIX citizens:<http://www.semanticweb.org/administrator/ontologies/2022/10/citizens-ontology#> " +
        "PREFIX persons:<http://www.semanticweb.org/administrator/ontologies/2022/10/personal-data-ontology#> " +
        "PREFIX edu:<http://www.semanticweb.org/administrator/ontologies/2022/10/education-ontology#> " +
        "PREFIX health:<http://www.semanticweb.org/administrator/ontologies/2022/10/health-ontology#> " +
        "PREFIX military:<http://www.semanticweb.org/administrator/ontologies/2022/10/military-ontology#> ";

        public static string personsQuery = "SELECT DISTINCT ?person ?person_name ?person_gender ?person_address ?person_national_id ?citizen " +
            "FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/defaultModel>" +
 "WHERE { " +
            "?citizen citizens:has-personal-data ?person ." +
 "?person persons:full_name ?person_name .  " +
 "?person persons:address ?person_address . " +
 "?person persons:gender ?person_gender . " +
 "?person persons:national_id ?person_national_id  }";

        public static string citizensQuery = "SELECT DISTINCT ?citizen  " +
            "FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/defaultModel>" +
"WHERE { " +
" ?citizen a <http://www.semanticweb.org/administrator/ontologies/2022/10/citizens-ontology#citizen>  }";

        public static string studentsQuery = "SELECT DISTINCT ?student ?student_name ?student_gender ?student_address ?student_national_id ?student_graduated ?student_year " +
            "FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/defaultModel>" +
  "WHERE { " +
  "?student rdf:type edu:StudentProfile. " +
  "?student edu:student_has_citizen ?cit . " +
  "?cit citizens:has-personal-data ?person . " +
  "?person persons:full_name ?student_name . " +
  "?person persons:address ?student_address . " +
  "?person persons:gender ?student_gender . " +
  "?person persons:national_id ?student_national_id ." +
            "?student edu:student_graduated ?student_graduated . " +
            "?student edu:student_year ?student_year }";

        public static string examsQuery = "SELECT DISTINCT ?exam ?exam_grade ?exam_pass " +
            "FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/defaultModel>" +
            "where { " +
            "?exam edu:exam_grade ?exam_grade ." +
            "?exam edu:exam_pass ?exam_pass} ";

        public static string examsQuery2 = "SELECT DISTINCT ?exam ?exam_grade ?exam_pass " +
            "FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/defaultModel>" +
            "where { " +
            "?student edu:do ?exam ." +
            "?student edu:student_has_citizen ?cit ." +
            "?cit citizens:has-personal-data ?person ." +
            "?person persons:national_id ?student_national_id ." +
            "?exam edu:exam_grade ?exam_grade ." +
            "?exam edu:exam_pass ?exam_pass " +
            "filter (?student_national_id = ";
        public static string examsQuery3 = "SELECT DISTINCT ?exam ?exam_grade ?exam_pass " +
            "FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/defaultModel>" +
    "where { " +
    "?course edu:has_exam ?exam ." +
    "?exam edu:exam_grade ?exam_grade ." +
    "?exam edu:exam_pass ?exam_pass " +
    "filter (str(?course) = '";
        public static string collegesQuery = "SELECT DISTINCT ?college ?college_name " +
            "FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/defaultModel>" +
            "where{ ?college edu:college_name ?college_name } ";

        public static string coursesQuery = "SELECT DISTINCT ?course ?course_name " +
            "FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/defaultModel>" +
            "where { " +
            "?course edu:course_name ?course_name} ";
        public static string patientsQuery = "SELECT DISTINCT ?patient ?patient_name ?patient_gender ?patient_address ?patient_national_id ?patient_is_soldier " +
            "FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/defaultModel>" +
  "WHERE { " +
  "?patient rdf:type health:patient. " +
  "?patient health:patient_has_citizen ?cit . " +
  "?cit citizens:has-personal-data ?person . " +
  "?person persons:full_name ?patient_name . " +
  "?person persons:address ?patient_address . " +
  "?person persons:gender ?patient_gender . " +
  "?person persons:national_id ?patient_national_id . " +
            "?patient health:is_soldier ?patient_is_soldier  }";
        public static string hospitalsQuery = "SELECT DISTINCT ?hospital ?hospital_name ?hospital_address  " +
            "FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/defaultModel>" +
"WHERE { " +
            "?hospital health:hospital_name ?hospital_name . " +
    "?hospital health:hospital_address ?hospital_address  }";
        public static string injuriesQuery = "SELECT DISTINCT ?injury ?injury_name " +
            "FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/defaultModel>" +
"WHERE { " +
            "?injury health:injury_name ?injury_name  }";
        public static string patient_injuriesQuery = "SELECT DISTINCT ?injury ?injury_date ?injury_percentage  " +
            "FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/defaultModel>" +
"WHERE { " +
              //"?patient health:patient_has_citizen ?cit . " +

            "?injury health:injury_date ?injury_date . " +
    "?injury health:injury_percentage ?injury_percentage  }";

        public static string patient_injuriesQuery2 = "SELECT DISTINCT ?injury ?injury_date ?injury_percentage  " +
    "FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/defaultModel>" +
"WHERE { " +
    "?patient health:patient_has_citizen ?cit . " +
    "?cit citizens:has-personal-data ?person . " +
    "?person persons:national_id ?patient_national_id . " +
            "?patient health:patient_has ?injury ." +
    "?injury health:injury_date ?injury_date . " +
    "?injury health:injury_percentage ?injury_percentage filter (?patient_national_id =";

        public static string patient_injuriesQuery3 = "SELECT DISTINCT ?patient_injury ?injury_date ?injury_percentage  " +
    "FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/defaultModel>" +
"WHERE { " +
    "?injury health:injury_has ?patient_injury . " +
    "?patient_injury health:injury_date ?injury_date . " +
    "?patient_injury health:injury_percentage ?injury_percentage filter (str(?injury) = '";


        public static string patient_injuriesQuery4 = "SELECT DISTINCT ?patient_injury ?injury_date ?injury_percentage  " +
    "FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/defaultModel>" +
"WHERE { " +
    "?hospital health:hospital_has ?patient_injury . " +
    "?patient_injury health:injury_date ?injury_date . " +
    "?patient_injury health:injury_percentage ?injury_percentage filter (str(?hospital) = '";

        public static string specific_patient_injuriesQuery = "SELECT DISTINCT ?name ?injury_name ?date ?injury_percentage " +
            "FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/defaultModel>" +
  "WHERE { " +
  "?cit citizens:has-personal-data ?person. " +
  "?person persons:full_name ?name . " +
  "?person persons:national_id ?patient_national_id . " +
  "?patient health:patient_has_citizen ?cit . " +
  "?patient health:patient_has ?details . " +
  "?details health:injury_date ?date . " +
  "?details health:injury_percentage ?injury_percentage . " +
            "?injury health:injury_has ?details ." +
            "?injury health:injury_name ?injury_name ." +
            "FILTER (?patient_national_id = ";

        public static string officersQuery = "SELECT DISTINCT ?officer ?officer_name ?officer_gender ?officer_address ?officer_national_id ?officer_rank ?officer_specialization " +
            "FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/defaultModel> " +
  "WHERE { " +
  "?officer rdf:type military:officer. " +
  "?officer military:officer_has_citizen ?cit . " +
  "?cit citizens:has-personal-data ?person . " +
  "?person persons:full_name ?officer_name . " +
  "?person persons:address ?officer_address . " +
  "?person persons:gender ?officer_gender . " +
  "?person persons:national_id ?officer_national_id ." +
            "?officer military:officer_rank ?officer_rank . " +
            "?officer military:officer_specialization ?officer_specialization }";

        public static string officersInjuryQuery = "SELECT DISTINCT ?officer (SUM(?percentage) AS ?per )  " +
    "FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/defaultModel> " +
"WHERE { " +
"?officer military:officer_has_citizen ?citizen ." +
"?citizen citizens:has-personal-data ?person . " +
"?person persons:full_name ?officer_name . " +
"?patient health:patient_has_citizen ?citizen . " +
"?patient health:patient_has ?details . " +
"?details health:injury_percentage ?percentage . " +
"?person persons:national_id ?officer_national_id ." +
    "?injury health:injury_has ?details . " +
    "} group by (?officer) having (?per >";

        public static string jopsQuery = "SELECT DISTINCT ?jop ?jop_year " +
"FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/defaultModel>" +
"WHERE { " +
"?jop military:jop_year ?jop_year  }";

        public static string jopsQuery2 = "SELECT DISTINCT ?jop ?jop_year " +
            "FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/defaultModel>" +
"WHERE { " +
            "?officer military:officer_has_citizen ?cit . " +
            "?cit citizens:has-personal-data ?person . " +
            "?person persons:national_id ?officer_national_id . " +
            "?officer military:officer_has_jop ?jop ." +
            "?jop military:jop_year ?jop_year .  filter (?officer_national_id =";

        public static string jopsQuery3 = "SELECT DISTINCT ?jop ?jop_year " +
    "FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/defaultModel>" +
"WHERE { " +
            "?position military:position_has_jop ?jop . " +
            "?jop military:jop_year ?jop_year    filter (str(?position) = '";
        public static string jopsQuery4 = "SELECT DISTINCT ?jop ?jop_year " +
"FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/defaultModel>" +
"WHERE { " +
    "?unit military:unit_has_jop ?jop .  " +
    "?jop military:jop_year ?jop_year    filter (str(?unit) = '";
        public static string positionsQuery = "SELECT DISTINCT ?position ?position_name ?position_salary " +
            "FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/defaultModel>" +
"WHERE { " +
            "?position military:position_name ?position_name . " +
    "?position military:position_salary ?position_salary }";
        public static string unitsQuery = "SELECT DISTINCT ?unit ?unit_name ?unit_positioning_place " +
            "FROM <http://www.semanticweb.org/administrator/ontologies/2022/10/defaultModel>" +
"WHERE { " +
    "?unit military:unit_name ?unit_name . " +
"?unit military:unit_positioning_place ?unit_positioning_place }";

    }
}
