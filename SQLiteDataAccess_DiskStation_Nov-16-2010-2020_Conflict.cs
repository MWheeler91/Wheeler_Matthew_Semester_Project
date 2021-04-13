using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Wheeler_Matthew_Semester_Project
{
    public class SQLiteDataAccess
    {
        public static List<PersonModel> LoadPeople(string clientQuery)
        {
            // query to fill the listbox with a list of people whose last name = the value in the text box
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))  // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {
                // selects first and last name as FullName
                // From the Clientinfo table
                // where the last name = the text box value
                // , ClientInformation.Client_ID as ID
                var sql = "SELECT (ClientInformation.FirstName || ' ' || ClientInformation.LastName) AS FullName " +
                          "FROM ClientInformation " +
                          "WHERE LastName = @clientquery";
                // sets @clientquery to clientQuery (supplied value)
                var parameters = new { clientquery = clientQuery };
                var output = cnn.Query<PersonModel>(sql, parameters);
                // returns the query to a list
                return output.ToList();
            }
        }

        public static List<NoteModel> LoadNoteQuery(string ClientID)
        {
            // query to fill the listbox with a list of people whose last name = the value in the text box
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))  // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {
                // selects Date
                // From client notes that join the IDs of client Info and client nots
                // where the last name = the text box value
                // need to come back to the order by and fix this once I get the write statement to work.
                var sql = "SELECT strftime('%m-%d-%Y %H:%M:%S', ClientNotes.Date) as Date " +
                          "FROM ClientNotes " +
                          "WHERE Client_ID LIKE @id " +
                          "ORDER BY Date DESC";
                // sets @clientquery to clientQuery (supplied value)
                var parameters = new { id = ClientID };
                var output = cnn.Query<NoteModel>(sql, parameters);
                // returns the query to a list
                return output.ToList();
            }
        }

        public static void SaveNoteQuery(string incomingNote, int clientID)
        {
            // query to fill the listbox with a list of people whose last name = the value in the text box
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))  // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {
                // selects first and last name as FullName
                // From the Clientinfo table
                // where the last name = the text box value
                var sql = "INSERT INTO ClientNotes (Notes, Date, Client_ID) " +
                          "Values (@note, DateTime('now', 'localtime'), @id) ";
                // sets @clientquery to clientQuery (supplied value)
                var parameters = new { note = incomingNote, id = clientID};
                var output = cnn.Execute(sql, parameters);
            }
        }

        public static string ViewNote(object Date, string ClientID)
        {
            // query to fill the listbox with a list of people whose last name = the value in the text box
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))  // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {
                // selects the note 
                // From the Clientnote table that joins the clientnote and clientinfo tables on the ID
                // where the name = passed name and the date matches the highlighted date in the listbox
                var sql = "SELECT  ClientNotes.Notes " +
                          "FROM ClientNotes " +
                          "WHERE Client_ID LIKE @id AND strftime('%m-%d-%Y %H:%M:%S', ClientNotes.Date) LIKE @date ";
                // sets @clientquery to clientQuery (supplied value)
                var parameters = new { id = ClientID, date = Date };
                var output = cnn.QueryFirstOrDefault<string>(sql, parameters);
                return output.ToString();
            }
        }

        public static void SavePerson(MedicalInformation clientmed, ClientInformation client)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString())) // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {

                // writes to my client info table and saves the client_ID to the clientmed object.
                clientmed.Client_ID = cnn.ExecuteScalar<int>("INSERT INTO ClientInformation (FirstName, MiddleInitial, LastName, Phone, Email, Address, City, State, Zip, DateOfBirth, Occupation, Employer, EmergencyContact, EmergencyContactRelationship, EmergencyContactPhone) " +
                                                            "VALUES (@FirstName, @MiddleInitial, @LastName, @Phone, @Email, @Address, @City, @State, @Zip, @DateOfBirth, @Occupation, @Employer, @EmergencyContact, @EmergencyContactRelationShip, @EmergencyContactPhone);" +
                                                             "SELECT last_insert_rowid();", client);
                //writes to the med info tableSS
                cnn.Execute("INSERT INTO MedicalInformation (Client_ID, CurrentMedications, ChronicPain, ChronicPainWhere, OrthopedicPain, OrthopedicPainWhere, Pregnant, PreferedPressureLight, PreferedPressureMedium, PreferedPressureDeep, Allergies, AllergiesWhat, Cancer, HeadacheMigraine, Arthritis, Diabetes, JointReplacement, HighLowBloodPressure, Neuropathy, Fibromyalgia, Stroke, HeartAttack, KidneyDysfunction, BloodClots, Numbness, SprainsStrains, AreasOfDiscomfort) " +
                            "VALUES (@Client_ID, @CurrentMedication, @ChronicPain, @ChronicPainWhere, @OrthopedicPain, @OrthopedicPainWhere, @Pregnant, @PeferredPressureLight, @PeferredPressureMedium, @PeferredPressureDeep, @Allergies, @AllergiesWhat, @Cancer, @HeadacheMigraine, @Arthritis, @Diabetes, @JointReplacement, @HighLowBloodPressure, @Neuropathy, @Fibromyalgia, @Stroke, @HeartAttack, @KidneyDysfunction, @BloodClots, @Numbness, @SprainsStrains, @AreasOfDiscomfort); ", client.MedicalInfo);
            }
        }

    


        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        // FirstName query 
        public static string FirstNameQuery(object Query)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))  // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {
                // SQL command to query the first name column of the client info table where value = the supplied value
                var sql = "SELECT ClientInformation.FirstName " +
                          "FROM ClientInformation " +
                          "WHERE (ClientInformation.FirstName || ' ' || ClientInformation.LastName) LIKE @query";
                // sets the @query to the received Query paramater from the form
                var parameters = new { query = Query };
                // runs the query
                var output = cnn.QueryFirstOrDefault<string>(sql, parameters);
                // returns query as a string
                return output.ToString();
            }
        }
        public static string MiddleInitialQuery(object Query)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))  // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {
                // SQL command to query the first name column of the client info table where value = the supplied value
                var sql = "SELECT ClientInformation.MiddleInitial " +
                          "FROM ClientInformation " +
                          "WHERE (ClientInformation.FirstName || ' ' || ClientInformation.LastName) LIKE @query";
                // sets the @query to the received Query paramater from the form=
                var parameters = new { query = Query };
                // runs the query
                var output = cnn.QueryFirstOrDefault<string>(sql, parameters);
                // returns query as a string
                return output.ToString();
            }
        }

        // test query 
        public static string LastNameQuery(object Query)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))  // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {
                // SQL command to query the first name column of the client info table where value = the supplied value
                var sql = "SELECT ClientInformation.LastName " +
                          "FROM ClientInformation " +
                          "WHERE (ClientInformation.FirstName || ' ' || ClientInformation.LastName) LIKE @query";
                // sets the @query to the received Query paramater from the form
                var parameters = new { query = Query };
                // runs the query
                var output = cnn.QueryFirstOrDefault<string>(sql, parameters);
                // returns query as a string
                return output.ToString();
            }
        }

        public static string PhoneQuery(object Query)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))  // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {
                // SQL command to query the first name column of the client info table where value = the supplied value
                var sql = "SELECT ClientInformation.Phone " +
                          "FROM ClientInformation " +
                          "WHERE (ClientInformation.FirstName || ' ' || ClientInformation.LastName) LIKE @query";
                // sets the @query to the received Query paramater from the form
                var parameters = new { query = Query };
                // runs the query
                var output = cnn.QueryFirstOrDefault<string>(sql, parameters);
                // returns query as a string
                return output.ToString();
            }
        }

        public static string EmailQuery(object Query)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))  // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {
                // SQL command to query the first name column of the client info table where value = the supplied value
                var sql = "SELECT ClientInformation.Email " +
                          "FROM ClientInformation " +
                          "WHERE (ClientInformation.FirstName || ' ' || ClientInformation.LastName) LIKE @query";
                // sets the @query to the received Query paramater from the form
                var parameters = new { query = Query };
                // runs the query
                var output = cnn.QueryFirstOrDefault<string>(sql, parameters);
                // returns query as a string
                return output.ToString();
            }
        }
        public static string AddressQuery(object Query)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))  // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {
                // SQL command to query the first name column of the client info table where value = the supplied value
                var sql = "SELECT ClientInformation.Address " +
                          "FROM ClientInformation " +
                          "WHERE (ClientInformation.FirstName || ' ' || ClientInformation.LastName) LIKE @query";
                // sets the @query to the received Query paramater from the form
                var parameters = new { query = Query };
                // runs the query
                var output = cnn.QueryFirstOrDefault<string>(sql, parameters);
                // returns query as a string
                return output.ToString();
            }
        }
        public static string CityQuery(object Query)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))  // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {
                // SQL command to query the first name column of the client info table where value = the supplied value
                var sql = "SELECT ClientInformation.City " +
                          "FROM ClientInformation " +
                          "WHERE (ClientInformation.FirstName || ' ' || ClientInformation.LastName) LIKE @query";
                // sets the @query to the received Query paramater from the form
                var parameters = new { query = Query };
                // runs the query
                var output = cnn.QueryFirstOrDefault<string>(sql, parameters);
                // returns query as a string
                return output.ToString();
            }
        }
        public static string StateQuery(object Query)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))  // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {
                // SQL command to query the first name column of the client info table where value = the supplied value
                var sql = "SELECT ClientInformation.State " +
                          "FROM ClientInformation " +
                          "WHERE (ClientInformation.FirstName || ' ' || ClientInformation.LastName) LIKE @query";
                // sets the @query to the received Query paramater from the form
                var parameters = new { query = Query };
                // runs the query
                var output = cnn.QueryFirstOrDefault<string>(sql, parameters);
                // returns query as a string
                return output.ToString();
            }
        }
        public static string ZipQuery(object Query)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))  // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {
                // SQL command to query the first name column of the client info table where value = the supplied value
                var sql = "SELECT ClientInformation.Zip " +
                          "FROM ClientInformation " +
                          "WHERE (ClientInformation.FirstName || ' ' || ClientInformation.LastName) LIKE @query";
                // sets the @query to the received Query paramater from the form
                var parameters = new { query = Query };
                // runs the query
                var output = cnn.QueryFirstOrDefault<string>(sql, parameters);
                // returns query as a string
                return output;
            }
        }
        public static string DateOfBirthQuery(object Query)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))  // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {
                // SQL command to query the first name column of the client info table where value = the supplied value
                var sql = "SELECT ClientInformation.DateOfBirth " +
                          "FROM ClientInformation " +
                          "WHERE (ClientInformation.FirstName || ' ' || ClientInformation.LastName) LIKE @query";
                // sets the @query to the received Query paramater from the form
                var parameters = new { query = Query };
                // runs the query
                var output = cnn.QueryFirstOrDefault<string>(sql, parameters);
                // returns query as a string
                return output.ToString();
            }
        }

        public static string OccupationQuery(object Query)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))  // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {
                // SQL command to query the first name column of the client info table where value = the supplied value
                var sql = "SELECT ClientInformation.Occupation " +
                          "FROM ClientInformation " +
                          "WHERE (ClientInformation.FirstName || ' ' || ClientInformation.LastName) LIKE @query";
                // sets the @query to the received Query paramater from the form
                var parameters = new { query = Query };
                // runs the query
                var output = cnn.QueryFirstOrDefault<string>(sql, parameters);
                // returns query as a string
                return output.ToString();
            }
        }

        public static string EmployerQuery(object Query)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))  // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {
                // SQL command to query the first name column of the client info table where value = the supplied value
                var sql = "SELECT ClientInformation.Employer " +
                          "FROM ClientInformation " +
                          "WHERE (ClientInformation.FirstName || ' ' || ClientInformation.LastName) LIKE @query";
                // sets the @query to the received Query paramater from the form
                var parameters = new { query = Query };
                // runs the query
                var output = cnn.QueryFirstOrDefault<string>(sql, parameters);
                // returns query as a string
                return output.ToString();
            }
        }

        public static string EmergencyContactQuery(object Query)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))  // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {
                // SQL command to query the first name column of the client info table where value = the supplied value
                var sql = "SELECT ClientInformation.EmergencyContact " +
                          "FROM ClientInformation " +
                          "WHERE (ClientInformation.FirstName || ' ' || ClientInformation.LastName) LIKE @query";
                // sets the @query to the received Query paramater from the form
                var parameters = new { query = Query };
                // runs the query
                var output = cnn.QueryFirstOrDefault<string>(sql, parameters);
                // returns query as a string
                return output.ToString();
            }
        }
        public static string EmergencyContactRelationshipQuery(object Query)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))  // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {
                // SQL command to query the first name column of the client info table where value = the supplied value
                var sql = "SELECT ClientInformation.EmergencyContactRelationship " +
                          "FROM ClientInformation " +
                          "WHERE (ClientInformation.FirstName || ' ' || ClientInformation.LastName) LIKE @query";
                // sets the @query to the received Query paramater from the form
                var parameters = new { query = Query };
                // runs the query
                var output = cnn.QueryFirstOrDefault<string>(sql, parameters);
                // returns query as a string
                return output.ToString();
            }
        }
        public static string EmergencyContactPhone(object Query)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))  // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {
                // SQL command to query the first name column of the client info table where value = the supplied value
                var sql = "SELECT ClientInformation.EmergencyContactPhone " +
                          "FROM ClientInformation " +
                          "WHERE (ClientInformation.FirstName || ' ' || ClientInformation.LastName) LIKE @query";
                // sets the @query to the received Query paramater from the form
                var parameters = new { query = Query };
                // runs the query
                var output = cnn.QueryFirstOrDefault<string>(sql, parameters);
                // returns query as a string
                return output.ToString();
            }
        }

        public static string ClientID(object Query)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))  // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {
                // SQL command to query the first name column of the client info table where value = the supplied value
                var sql = "SELECT ClientInformation.Client_ID " +
                          "FROM ClientInformation " +
                          "WHERE (ClientInformation.FirstName || ' ' || ClientInformation.LastName) LIKE @query";
                // sets the @query to the received Query paramater from the form
                var parameters = new { query = Query };
                // runs the query
                var output = cnn.QueryFirstOrDefault<string>(sql, parameters);
                // returns query as a string
                return output.ToString();
            }
        }




        public static string CurrentMedicationsQuery(object Query)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))  // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {
                // SQL command to query the first name column of the client info table where value = the supplied value
                var sql = "SELECT MedicalInformation.CurrentMedications " +
                          "FROM MedicalInformation JOIN ClientInformation on ClientInformation.Client_Id = MedicalInformation.Client_ID " +
                          "WHERE (ClientInformation.FirstName || ' ' || ClientInformation.LastName) LIKE @query";
                // sets the @query to the received Query paramater from the form
                var parameters = new { query = Query };
                // runs the query
                var output = cnn.QueryFirstOrDefault<string>(sql, parameters);
                // returns query as a string
                return output.ToString();
            }
        }
        public static string ChronicPainWhereQuery(object Query)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))  // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {
                // SQL command to query the first name column of the client info table where value = the supplied value
                var sql = "SELECT MedicalInformation.ChronicPainWhere " +
                          "FROM MedicalInformation JOIN ClientInformation on ClientInformation.Client_Id = MedicalInformation.Client_ID " +
                          "WHERE (ClientInformation.FirstName || ' ' || ClientInformation.LastName) LIKE @query";
                // sets the @query to the received Query paramater from the form
                var parameters = new { query = Query };
                // runs the query
                var output = cnn.QueryFirstOrDefault<string>(sql, parameters);
                // returns query as a string
                return output.ToString();
            }
        }
        public static string OrthopedicPainWhereQuery(object Query)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))  // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {
                // SQL command to query the first name column of the client info table where value = the supplied value
                var sql = "SELECT MedicalInformation.OrthopedicPainWhere " +
                          "FROM MedicalInformation JOIN ClientInformation on ClientInformation.Client_Id = MedicalInformation.Client_ID " +
                          "WHERE (ClientInformation.FirstName || ' ' || ClientInformation.LastName) LIKE @query";
                // sets the @query to the received Query paramater from the form
                var parameters = new { query = Query };
                // runs the query
                var output = cnn.QueryFirstOrDefault<string>(sql, parameters);
                // returns query as a string
                return output.ToString();
            }
        }
        public static string AreasOfDiscomfortQuery(object Query)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))  // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {
                // SQL command to query the first name column of the client info table where value = the supplied value
                var sql = "SELECT MedicalInformation.AreasOfDiscomfort " +
                          "FROM MedicalInformation JOIN ClientInformation on ClientInformation.Client_Id = MedicalInformation.Client_ID " +
                          "WHERE (ClientInformation.FirstName || ' ' || ClientInformation.LastName) LIKE @query";
                // sets the @query to the received Query paramater from the form
                var parameters = new { query = Query };
                // runs the query
                var output = cnn.QueryFirstOrDefault<string>(sql, parameters);
                // returns query as a string
                return output.ToString();
            }
        }
        public static string AllergiesWhatQuery(object Query)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))  // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {
                // SQL command to query the first name column of the client info table where value = the supplied value
                var sql = "SELECT MedicalInformation.AllergiesWhat " +
                          "FROM MedicalInformation JOIN ClientInformation on ClientInformation.Client_Id = MedicalInformation.Client_ID " +
                          "WHERE (ClientInformation.FirstName || ' ' || ClientInformation.LastName) LIKE @query";
                // sets the @query to the received Query paramater from the form
                var parameters = new { query = Query };
                // runs the query
                var output = cnn.QueryFirstOrDefault<string>(sql, parameters);
                // returns query as a string
                return output.ToString();
            }
        }





        // Check boxes

        public static int ChronicPainQuery(object Query)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))  // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {
                // SQL command to query the first name column of the client info table where value = the supplied value
                var sql = "SELECT MedicalInformation.ChronicPain " +
                          "FROM MedicalInformation JOIN ClientInformation on ClientInformation.Client_Id = MedicalInformation.Client_ID " +
                          "WHERE (ClientInformation.FirstName || ' ' || ClientInformation.LastName) LIKE @query";
                // sets the @query to the received Query paramater from the form
                var parameters = new { query = Query };
                // runs the query
                var output = cnn.QueryFirstOrDefault<int>(sql, parameters);
                // returns query as a string
                return output;
            }
        }

        public static int OrthopedicPainQuery(object Query)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))  // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {
                // SQL command to query the first name column of the client info table where value = the supplied value
                var sql = "SELECT MedicalInformation.OrthopedicPain " +
                          "FROM MedicalInformation JOIN ClientInformation on ClientInformation.Client_Id = MedicalInformation.Client_ID " +
                          "WHERE (ClientInformation.FirstName || ' ' || ClientInformation.LastName) LIKE @query";
                // sets the @query to the received Query paramater from the form
                var parameters = new { query = Query };
                // runs the query
                var output = cnn.QueryFirstOrDefault<int>(sql, parameters);
                // returns query as a string
                return output;
            }
        }

        public static int PregnantQuery(object Query)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))  // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {
                // SQL command to query the first name column of the client info table where value = the supplied value
                var sql = "SELECT MedicalInformation.Pregnant " +
                          "FROM MedicalInformation JOIN ClientInformation on ClientInformation.Client_Id = MedicalInformation.Client_ID " +
                          "WHERE (ClientInformation.FirstName || ' ' || ClientInformation.LastName) LIKE @query";
                // sets the @query to the received Query paramater from the form
                var parameters = new { query = Query };
                // runs the query
                var output = cnn.QueryFirstOrDefault<int>(sql, parameters);
                // returns query as a string
                return output;
            }
        }
        public static int PreferedPressureLightQuery(object Query)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))  // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {
                // SQL command to query the first name column of the client info table where value = the supplied value
                var sql = "SELECT MedicalInformation.PreferedPressureLight " +
                          "FROM MedicalInformation JOIN ClientInformation on ClientInformation.Client_Id = MedicalInformation.Client_ID " +
                          "WHERE (ClientInformation.FirstName || ' ' || ClientInformation.LastName) LIKE @query";
                // sets the @query to the received Query paramater from the form
                var parameters = new { query = Query };
                // runs the query
                var output = cnn.QueryFirstOrDefault<int>(sql, parameters);
                // returns query as a string
                return output;
            }
        }
        public static int PreferedPressureMediumQuery(object Query)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))  // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {
                // SQL command to query the first name column of the client info table where value = the supplied value
                var sql = "SELECT MedicalInformation.PreferedPressureMedium " +
                          "FROM MedicalInformation JOIN ClientInformation on ClientInformation.Client_Id = MedicalInformation.Client_ID " +
                          "WHERE (ClientInformation.FirstName || ' ' || ClientInformation.LastName) LIKE @query";
                // sets the @query to the received Query paramater from the form
                var parameters = new { query = Query };
                // runs the query
                var output = cnn.QueryFirstOrDefault<int>(sql, parameters);
                // returns query as a string
                return output;
            }
        }
        public static int PreferedPressureDeepQuery(object Query)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))  // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {
                // SQL command to query the first name column of the client info table where value = the supplied value
                var sql = "SELECT MedicalInformation.PreferedPressureDeep " +
                          "FROM MedicalInformation JOIN ClientInformation on ClientInformation.Client_Id = MedicalInformation.Client_ID " +
                          "WHERE (ClientInformation.FirstName || ' ' || ClientInformation.LastName) LIKE @query";
                // sets the @query to the received Query paramater from the form
                var parameters = new { query = Query };
                // runs the query
                var output = cnn.QueryFirstOrDefault<int>(sql, parameters);
                // returns query as a string
                return output;
            }
        }
        public static int AllergiesQuery(object Query)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))  // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {
                // SQL command to query the first name column of the client info table where value = the supplied value
                var sql = "SELECT MedicalInformation.Allergies " +
                          "FROM MedicalInformation JOIN ClientInformation on ClientInformation.Client_Id = MedicalInformation.Client_ID " +
                          "WHERE (ClientInformation.FirstName || ' ' || ClientInformation.LastName) LIKE @query";
                // sets the @query to the received Query paramater from the form
                var parameters = new { query = Query };
                // runs the query
                var output = cnn.QueryFirstOrDefault<int>(sql, parameters);
                // returns query as a string
                return output;
            }
        }
        public static int CancerQuery(object Query)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))  // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {
                // SQL command to query the first name column of the client info table where value = the supplied value
                var sql = "SELECT MedicalInformation.Cancer " +
                          "FROM MedicalInformation JOIN ClientInformation on ClientInformation.Client_Id = MedicalInformation.Client_ID " +
                          "WHERE (ClientInformation.FirstName || ' ' || ClientInformation.LastName) LIKE @query";
                // sets the @query to the received Query paramater from the form
                var parameters = new { query = Query };
                // runs the query
                var output = cnn.QueryFirstOrDefault<int>(sql, parameters);
                // returns query as a string
                return output;
            }
        }
        public static int HeadacheMigrainQuery(object Query)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))  // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {
                // SQL command to query the first name column of the client info table where value = the supplied value
                var sql = "SELECT MedicalInformation.HeadacheMigraine " +
                          "FROM MedicalInformation JOIN ClientInformation on ClientInformation.Client_Id = MedicalInformation.Client_ID " +
                          "WHERE (ClientInformation.FirstName || ' ' || ClientInformation.LastName) LIKE @query";
                // sets the @query to the received Query paramater from the form
                var parameters = new { query = Query };
                // runs the query
                var output = cnn.QueryFirstOrDefault<int>(sql, parameters);
                // returns query as a string
                return output;
            }
        }
        public static int ArthritisQuery(object Query)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))  // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {
                // SQL command to query the first name column of the client info table where value = the supplied value
                var sql = "SELECT MedicalInformation.Arthritis " +
                          "FROM MedicalInformation JOIN ClientInformation on ClientInformation.Client_Id = MedicalInformation.Client_ID " +
                          "WHERE (ClientInformation.FirstName || ' ' || ClientInformation.LastName) LIKE @query";
                // sets the @query to the received Query paramater from the form
                var parameters = new { query = Query };
                // runs the query
                var output = cnn.QueryFirstOrDefault<int>(sql, parameters);
                // returns query as a string
                return output;
            }
        }
        public static int DiabetesQuery(object Query)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))  // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {
                // SQL command to query the first name column of the client info table where value = the supplied value
                var sql = "SELECT MedicalInformation.Diabetes " +
                          "FROM MedicalInformation JOIN ClientInformation on ClientInformation.Client_Id = MedicalInformation.Client_ID " +
                          "WHERE (ClientInformation.FirstName || ' ' || ClientInformation.LastName) LIKE @query";
                // sets the @query to the received Query paramater from the form
                var parameters = new { query = Query };
                // runs the query
                var output = cnn.QueryFirstOrDefault<int>(sql, parameters);
                // returns query as a string
                return output;
            }
        }
        public static int JointReplacementQuery(object Query)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))  // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {
                // SQL command to query the first name column of the client info table where value = the supplied value
                var sql = "SELECT MedicalInformation.JointReplacement " +
                          "FROM MedicalInformation JOIN ClientInformation on ClientInformation.Client_Id = MedicalInformation.Client_ID " +
                          "WHERE (ClientInformation.FirstName || ' ' || ClientInformation.LastName) LIKE @query";
                // sets the @query to the received Query paramater from the form
                var parameters = new { query = Query };
                // runs the query
                var output = cnn.QueryFirstOrDefault<int>(sql, parameters);
                // returns query as a string
                return output;
            }
        }
        public static int HighLowBloodPressureQuery(object Query)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))  // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {
                // SQL command to query the first name column of the client info table where value = the supplied value
                var sql = "SELECT MedicalInformation.HighLowBloodPressure " +
                          "FROM MedicalInformation JOIN ClientInformation on ClientInformation.Client_Id = MedicalInformation.Client_ID " +
                          "WHERE (ClientInformation.FirstName || ' ' || ClientInformation.LastName) LIKE @query";
                // sets the @query to the received Query paramater from the form
                var parameters = new { query = Query };
                // runs the query
                var output = cnn.QueryFirstOrDefault<int>(sql, parameters);
                // returns query as a string
                return output;
            }
        }
        public static int NeuropathyQuery(object Query)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))  // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {
                // SQL command to query the first name column of the client info table where value = the supplied value
                var sql = "SELECT MedicalInformation.Neuropathy " +
                          "FROM MedicalInformation JOIN ClientInformation on ClientInformation.Client_Id = MedicalInformation.Client_ID " +
                          "WHERE (ClientInformation.FirstName || ' ' || ClientInformation.LastName) LIKE @query";
                // sets the @query to the received Query paramater from the form
                var parameters = new { query = Query };
                // runs the query
                var output = cnn.QueryFirstOrDefault<int>(sql, parameters);
                // returns query as a string
                return output;
            }
        }
        public static int FibromyalgiaQuery(object Query)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))  // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {
                // SQL command to query the first name column of the client info table where value = the supplied value
                var sql = "SELECT MedicalInformation.Fibromyalgia " +
                          "FROM MedicalInformation JOIN ClientInformation on ClientInformation.Client_Id = MedicalInformation.Client_ID " +
                          "WHERE (ClientInformation.FirstName || ' ' || ClientInformation.LastName) LIKE @query";
                // sets the @query to the received Query paramater from the form
                var parameters = new { query = Query };
                // runs the query
                var output = cnn.QueryFirstOrDefault<int>(sql, parameters);
                // returns query as a string
                return output;
            }
        }
        public static int StrokeQuery(object Query)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))  // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {
                // SQL command to query the first name column of the client info table where value = the supplied value
                var sql = "SELECT MedicalInformation.Stroke " +
                          "FROM MedicalInformation JOIN ClientInformation on ClientInformation.Client_Id = MedicalInformation.Client_ID " +
                          "WHERE (ClientInformation.FirstName || ' ' || ClientInformation.LastName) LIKE @query";
                // sets the @query to the received Query paramater from the form
                var parameters = new { query = Query };
                // runs the query
                var output = cnn.QueryFirstOrDefault<int>(sql, parameters);
                // returns query as a string
                return output;
            }
        }
        public static int HeartAttackQuery(object Query)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))  // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {
                // SQL command to query the first name column of the client info table where value = the supplied value
                var sql = "SELECT MedicalInformation.HeartAttack " +
                          "FROM MedicalInformation JOIN ClientInformation on ClientInformation.Client_Id = MedicalInformation.Client_ID " +
                          "WHERE (ClientInformation.FirstName || ' ' || ClientInformation.LastName) LIKE @query";
                // sets the @query to the received Query paramater from the form
                var parameters = new { query = Query };
                // runs the query
                var output = cnn.QueryFirstOrDefault<int>(sql, parameters);
                // returns query as a string
                return output;
            }
        }
        public static int KidneyDysfunctionQuery(object Query)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))  // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {
                // SQL command to query the first name column of the client info table where value = the supplied value
                var sql = "SELECT MedicalInformation.KidneyDysfunction " +
                          "FROM MedicalInformation JOIN ClientInformation on ClientInformation.Client_Id = MedicalInformation.Client_ID " +
                          "WHERE (ClientInformation.FirstName || ' ' || ClientInformation.LastName) LIKE @query";
                // sets the @query to the received Query paramater from the form
                var parameters = new { query = Query };
                // runs the query
                var output = cnn.QueryFirstOrDefault<int>(sql, parameters);
                // returns query as a string
                return output;
            }
        }
        public static int BloodClotsQuery(object Query)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))  // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {
                // SQL command to query the first name column of the client info table where value = the supplied value
                var sql = "SELECT MedicalInformation.BloodClots " +
                          "FROM MedicalInformation JOIN ClientInformation on ClientInformation.Client_Id = MedicalInformation.Client_ID " +
                          "WHERE (ClientInformation.FirstName || ' ' || ClientInformation.LastName) LIKE @query";
                // sets the @query to the received Query paramater from the form
                var parameters = new { query = Query };
                // runs the query
                var output = cnn.QueryFirstOrDefault<int>(sql, parameters);
                // returns query as a string
                return output;
            }
        }
        public static int NumbnessQuery(object Query)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))  // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {
                // SQL command to query the first name column of the client info table where value = the supplied value
                var sql = "SELECT MedicalInformation.Numbness " +
                          "FROM MedicalInformation JOIN ClientInformation on ClientInformation.Client_Id = MedicalInformation.Client_ID " +
                          "WHERE (ClientInformation.FirstName || ' ' || ClientInformation.LastName) LIKE @query";
                // sets the @query to the received Query paramater from the form
                var parameters = new { query = Query };
                // runs the query
                var output = cnn.QueryFirstOrDefault<int>(sql, parameters);
                // returns query as a string
                return output;
            }
        }
        public static int SprainsStrainsQuery(object Query)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))  // this statement ensures that when the final brace is hit or the program crashes the connection to the DB closes
            {
                // SQL command to query the first name column of the client info table where value = the supplied value
                var sql = "SELECT MedicalInformation.SprainsStrains " +
                          "FROM MedicalInformation JOIN ClientInformation on ClientInformation.Client_Id = MedicalInformation.Client_ID " +
                          "WHERE (ClientInformation.FirstName || ' ' || ClientInformation.LastName) LIKE @query";
                // sets the @query to the received Query paramater from the form
                var parameters = new { query = Query };
                // runs the query
                var output = cnn.QueryFirstOrDefault<int>(sql, parameters);
                // returns query as a string
                return output;
            }
        }
    }
}