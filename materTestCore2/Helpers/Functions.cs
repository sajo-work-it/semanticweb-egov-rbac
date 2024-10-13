using materTestCore2.Models.EGovModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel;
using VDS.RDF;
using VDS.RDF.Nodes;
using VDS.RDF.Query;
using VDS.RDF.Writing;
using static materTestCore2.Models.EGovModels.SharedClasses;
using HttpMethod = System.Net.Http.HttpMethod;
using OntologiesNamespace;
using materTestCore2.Models.EGovModels.personal;
using materTestCore2.Models.EGovModels.education;
using materTestCore2.Models.EGovModels.military;
using materTestCore2.Models.EGovModels.health;
using Semiodesk.Trinity;
using System.Diagnostics;

namespace materTestCore2.Helpers
{
    public static class Functions
    {

        public static bool removeStudent(Citizen citizen, StudentProfile student)
        {
            if (citizen != null)
            {
                citizen.RemoveProperty(rdf.type, education.StudentProfile);
                citizen.RemoveProperty(education.student_graduated, student.student_graduated);
                citizen.RemoveProperty(education.student_year, student.student_year);

                if (student.Do != null && student.Do.Count > 0)
                {
                    foreach (var exam in student.Do)
                    {
                        citizen.RemoveProperty(education._do, exam);
                    }
                }

                citizen.Commit();
                return true;
            }
            return false;
        }

        public static bool removeOfficer(Citizen citizen, Officer officer)
        {
            if (citizen != null)
            {

                citizen.RemoveProperty(rdf.type, military.officer);
                citizen.RemoveProperty(military.officer_rank, officer.Officer_rank);
                citizen.RemoveProperty(military.officer_specialization, officer.officer_specialization);
                if (officer.officer_has_jop != null && officer.officer_has_jop.Count > 0)
                {
                    foreach (var jop in officer.officer_has_jop)
                    {
                        citizen.RemoveProperty(military.officer_has_jop, jop);
                    }
                }

                citizen.Commit();
                return true;
            }
            return false;
        }

        public static bool removePatient(Citizen citizen, Patient patient)
        {
            if (citizen != null)
            {

                citizen.RemoveProperty(rdf.type, health.patient);
                citizen.RemoveProperty(health.is_soldier, patient.is_soldier);
                if (patient.patient_has != null && patient.patient_has.Count > 0)
                {
                    foreach (var patient_injury in patient.patient_has)
                    {
                        citizen.RemoveProperty(health.patient_has, patient_injury);
                    }
                }

                citizen.Commit();
                return true;
            }
            return false;
        }

        public static bool addStudent(Citizen citizen, StudentProfile student)
        {
            if (citizen != null)
            {
                citizen.AddProperty(rdf.type, education.StudentProfile);
                citizen.AddProperty(education.student_graduated, student.student_graduated);
                citizen.AddProperty(education.student_year, student.student_year);

                citizen.Commit();
                return true;
            }
            return false;
        }

        public static bool addOfficer(Citizen citizen, Officer officer)
        {
            if (citizen != null)
            {
                citizen.AddProperty(rdf.type, military.officer);
                citizen.AddProperty(military.officer_rank, officer.Officer_rank);
                citizen.AddProperty(military.officer_specialization, officer.officer_specialization);


                citizen.Commit();
                return true;
            }
            return false;
        }
        public static bool addPatient(Citizen citizen, Patient patient)
        {
            if (citizen != null)
            {
                citizen.AddProperty(rdf.type, health.patient);
                citizen.AddProperty(health.is_soldier, patient.is_soldier);

                citizen.Commit();
                return true;
            }
            return false;
        }
        public static bool addPerson(Citizen citizen, PersonProfile person)
        {
            if (citizen != null)
            {
                citizen.AddProperty(rdf.type, personal.PersonProfile);
                citizen.AddProperty(personal.national_id, person.national_id);
                citizen.AddProperty(personal.gender, person.gender);
                citizen.AddProperty(personal.address, person.address);
                citizen.AddProperty(personal.full_name, person.full_name);

                
                //citizen.Commit();
                return true;
            }
            return false;
        }
        public static mixedNodeValues getNodeValue(SparqlResult result, string variableName)
        {
            INode n;
            mixedNodeValues data = new mixedNodeValues();

            if (result.TryGetValue(variableName, out n))
            {
                switch (n.NodeType)
                {
                    case NodeType.Uri:
                        data.stringValue = ((IUriNode)n).Uri.AbsoluteUri;
                        break;
                    case NodeType.Blank:
                        data.stringValue = "";
                        break;
                    case NodeType.Literal:
                        {
                            BaseLiteralNode nn = (BaseLiteralNode)n;
                            if (nn.DataType != null)
                            {
                                switch (nn.DataType.Fragment)
                                {
                                    case "#integer":
                                    case "#int":
                                        data.intValue = ((int)n.AsValuedNode().AsInteger());
                                        break;
                                    case "#boolean":
                                        data.boolValue = n.AsValuedNode().AsBoolean();
                                        break;
                                    case "#string":
                                        data.stringValue = n.AsValuedNode().AsString();
                                        break;
                                    case "#float":
                                        data.floatValue = n.AsValuedNode().AsFloat();
                                        break;
                                }

                            }
                            else
                                data.stringValue = n.AsValuedNode().AsString();


                            break;
                        }
                        
                    default:
                        throw new RdfOutputException("Unexpected Node Type");
                }
            }
            else
            {

                data.stringValue = String.Empty;
            }
            return data;
        }
        public static string boolGender(this bool value)
        {
            return value ? "ذكر" : "أنثى";
        }
        public static string boolGraduated(this bool value)
        {
            return value ? "متخرج" : "غير متخرج";
        }
        public static string boolPass(this bool value)
        {
            return value ? "تجاوز" : "لم يتجاوز";
        }
        public static string boolSoldier(this bool value)
        {
            return value ? "عسكري" : "مدني";
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [System.ComponentModel.Description("تسجيل الدخول")]
        public static async Task<authenticationResponse2>? LoginApiCall(LoginViewModel model, HttpClient AuthenticationClient)
        {
            var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("username", model.UserName),
                    new KeyValuePair<string, string>("password", model.Password)
                });

            var requestBody = new HttpRequestMessage(HttpMethod.Post, AuthenticationClient.BaseAddress);
            requestBody.Content = content;

            authenticationResponse2? responseObject = new authenticationResponse2();
            try
            {

                using (var response = await AuthenticationClient.PostAsync(AuthenticationClient.BaseAddress, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    responseObject = JsonConvert.DeserializeObject<authenticationResponse2>(apiResponse);
                }
            }
            catch (Exception ex)
            {
                responseObject.Success = false;
                responseObject.Message = "لا يمكن الاتصال بالمخدم";
            }
            return responseObject;

        }

        public static string appRouting(string controllerPath)
        {
            switch (controllerPath)
            {
                case "educationControllers":
                    return "AppMohe";
                case "healthControllers":
                    return "AppMoh";
                case "militaryControllers":
                    return "AppMod";
                case "personal_dataControllers":
                    return "AppC";
                default:
                    return "";
            }
        }
        public static string GetEnumDescription(this Enum enumeratoion)
        {
            var description = string.Empty;
            try
            {
                var type = enumeratoion.GetType();
                var memInfo = type.GetMember(enumeratoion.ToString());
                var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                description = ((DescriptionAttribute)attributes[0]).Description;
            }
            catch (Exception)
            {
            }
            return description;
        }
        //public static void RestartFusekiWithoutConsole()
        //{
        //    ProcessStartInfo processInfo = new ProcessStartInfo
        //    {
        //        FileName = @"C:\apache-jena-fuseki-4.6.1\fuseki-restart.bat", // Full path to your batch file
        //        CreateNoWindow = true,
        //        UseShellExecute = false,
        //        WindowStyle = ProcessWindowStyle.Hidden // Hide the window
        //    };

        //    Process process = Process.Start(processInfo);
        //    process.WaitForExit(); // Optional: Wait for the batch file to finish before proceeding
        //}



        //// Method to restart Fuseki
        //public static void RestartFuseki()
        //{
        //    // Stop (kill) the running Fuseki process
        //    KillFusekiProcess();

        //    // Start Fuseki again
        //    StartFusekiJarDirectly();
        //}
        //public static void StartFusekiJarDirectly()
        //{
        //    var processInfo = new ProcessStartInfo("java")
        //    {
        //        Arguments = "-jar C:\\apache-jena-fuseki-4.6.1\\fuseki-server.jar",
        //        CreateNoWindow = true,
        //        UseShellExecute = false,
        //        RedirectStandardOutput = true,
        //        RedirectStandardError = true,
        //        WindowStyle = ProcessWindowStyle.Hidden
        //    };

        //    var process = Process.Start(processInfo);
        //    process.OutputDataReceived += (sender, e) => Console.WriteLine("Output: " + e.Data);
        //    process.ErrorDataReceived += (sender, e) => Console.WriteLine("Error: " + e.Data);

        //    process.BeginOutputReadLine();
        //    process.BeginErrorReadLine();

        //    process.WaitForExit();
        //}

        //// Method to kill Fuseki process
        //private static void KillFusekiProcess()
        //{
        //    var processInfo = new ProcessStartInfo
        //    {
        //        FileName = "cmd.exe",
        //        Arguments = "/c for /f \"tokens=5\" %a in ('netstat -aon ^| find \":3030\" ^| find \"LISTEN\"') do taskkill /pid %a /f",
        //        UseShellExecute = false,
        //        CreateNoWindow = true
        //    };

        //    var process = Process.Start(processInfo);
        //    process.WaitForExit();
        //    process.Close();
        //}

        //// Method to start Fuseki
        //private static void StartFuseki()
        //{
        //    var processInfo = new ProcessStartInfo
        //    {
        //        FileName = @"cmd.exe",
        //        Arguments = @"/c C:\\apache-jena-fuseki-4.6.1\\fuseki-server.bat --update --mem /ds",
        //        UseShellExecute = true,
        //        CreateNoWindow = true,
        //        WindowStyle = ProcessWindowStyle.Hidden
        //    };


        //    var process = Process.Start(processInfo);
        //    process.WaitForExit();
        //}



        public static void RestartFuseki2(string fusekiServerPath)
        {
            try
            {
                var processInfo = new ProcessStartInfo
                {
                    FileName = Path.Combine(fusekiServerPath, "fuseki-restart.bat"),  // Ensure it's the .bat file for Windows
                    CreateNoWindow = true,
                    UseShellExecute = true,   // UseShellExecute should be true for .bat files
                    WindowStyle = ProcessWindowStyle.Hidden,  // Hides the window

                    WorkingDirectory = fusekiServerPath,  // Set the correct working directory
                };

                var process = Process.Start(processInfo);
                process.WaitForExit();

                Console.WriteLine("Fuseki server restarted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error restarting Fuseki: {ex.Message}");
            }
        }


        //public static void RestartFuseki1(string command)
        //{
        //    string fusekiServerPath = "C:\\apache-jena-fuseki-4.6.1";

        //    var processInfo = new ProcessStartInfo("cmd.exe", fusekiServerPath + command);
        //    processInfo.CreateNoWindow = true;
        //    processInfo.UseShellExecute = false;
        //    processInfo.RedirectStandardError = true;
        //    processInfo.RedirectStandardOutput = true;

        //    var process = Process.Start(processInfo);

        //    process.OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
        //        Console.WriteLine("output>>" + e.Data);
        //    process.BeginOutputReadLine();

        //    process.ErrorDataReceived += (object sender, DataReceivedEventArgs e) =>
        //        Console.WriteLine("error>>" + e.Data);
        //    process.BeginErrorReadLine();

        //    process.WaitForExit();

        //    Console.WriteLine("ExitCode: {0}", process.ExitCode);
        //    process.Close();
        //}
    }
}
