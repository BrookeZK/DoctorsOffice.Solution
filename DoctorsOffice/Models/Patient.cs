// using System.Collections.Generic;
// using MySql.Data.MySqlClient;
//
// namespace DoctorsOffice.Models
// {
//   public class Patient
//   {
//     private string _name;
//     private string _ailment;
//     private int _id;
//
//     public Patient(string name, string ailment, int id = 0)
//     {
//       _name = name;
//       _ailment = ailment;
//       _id = id;
//     }
//
//     public string Name{ get => _name; set => _name = value; }
//     public string Ailment{ get => _ailment; set => _ailment = value; }
//     public int Id{ get => _id; }
//
//     public override bool Equals(System.Object otherPatien)
//     {
//       if (!(otherPatient is Patient))
//       {
//         return false;
//       }
//       else
//       {
//         Patient newPatient = (Patient) otherPatient;
//         bool nameEquality = this.Name == newPatient.Name;
//
//         bool ailmentEquality = this.Ailment == newPatient.Ailment;
//
//         bool idEquality = this.Id == newPatient.Id;
//
//         return (nameEquality && ailmentEquality && yearsExpEquality && idEquality);
//       }
//     }
//
//     public static void ClearAll()
//     {
//       MySqlConnection conn = DB.Connection();
//       conn.Open();
//       var cmd = conn.CreateCommand() as MySqlCommand;
//       cmd.CommandText = @"DELETE FROM patients;";
//       cmd.ExecuteNonQuery();
//       conn.Close();
//       if (conn != null)
//       {
//         conn.Dispose();
//       }
//     }
//
//     public static List<Patient> GetAll()
//     {
//       List<Patient> allPatients = new List<Patient> {};
//       MySqlConnection conn = DB.Connection();
//       conn.Open();
//       var cmd = conn.CreateCommand() as MySqlCommand;
//       cmd.CommandText = @"SELECT * FROM patients;";
//       var rdr = cmd.ExecuteReader() as MySqlDataReader;
//       while(rdr.Read())
//       {
//         int patientId = rdr.GetInt32(0);
//         string patientName = rdr.GetString(1);
//         string patientAilment = rdr.GetString(2);
//
//         Patient newPatient = new Patient(patientName, patientAilment, patientId);
//         allPatients.Add(newPatient);
//       }
//       conn.Close();
//       if (conn != null)
//       {
//         conn.Dispose();
//       }
//       return allPatients;
//     }
//
//     public void Save()
//     {
//       MySqlConnection conn = DB.Connection();
//       conn.Open();
//       var cmd = conn.CreateCommand() as MySqlCommand;
//       cmd.CommandText = @"INSERT INTO patients (name, ailment) VALUES (@name, @ailment);";
//
//       MySqlParameter name = new MySqlParameter();
//       name.ParameterName = "@name";
//       name.Value = this._name;
//       cmd.Parameters.Add(name);
//
//       MySqlParameter ailment = new MySqlParameter();
//       ailment.ParameterName = "@ailment";
//       ailment.Value = this._ailment;
//       cmd.Parameters.Add(ailment);
//
//       cmd.ExecuteNonQuery();
//
//       _id = (int) cmd.LastInsertedId;
//       conn.Close();
//       if (conn != null)
//       {
//         conn.Dispose();
//       }
//     }
//
//     public static Patient Find(int id)
//     {
//       MySqlConnection conn = DB.Connection();
//       conn.Open();
//       var cmd = conn.CreateCommand() as MySqlCommand;
//       cmd.CommandText = @"SELECT * FROM patients WHERE id = (@searchId);";
//       MySqlParameter searchId = new MySqlParameter();
//       searchId.ParameterName = "@searchId";
//       searchId.Value = id;
//       cmd.Parameters.Add(searchId);
//       var rdr = cmd.ExecuteReader() as MySqlDataReader;
//       int patientId = 0;
//       string patientName = "";
//       string patientAilment = "";
//       while(rdr.Read())
//       {
//         patientId = rdr.GetInt32(0);
//         patientName = rdr.GetString(1);
//         patientAilment = rdr.GetString(2);
//       }
//       Patient newPatient = new Patient(patientName, patientAilment, patientId);
//       conn.Close();
//       if (conn != null)
//       {
//         conn.Dispose();
//       }
//       return newPatient;
//     }
//
//     public void Edit(string newSpecialty)
//     {
//       MySqlConnection conn = DB.Connection();
//       conn.Open();
//       var cmd = conn.CreateCommand() as MySqlCommand;
//       cmd.CommandText = @"UPDATE patients SET ailment = @newAilment WHERE id = @searchId;";
//       MySqlParameter searchId = new MySqlParameter();
//       searchId.ParameterName = "@searchId";
//       searchId.Value = _id;
//       cmd.Parameters.Add(searchId);
//       MySqlParameter ailment = new MySqlParameter();
//       ailment.ParameterName = "@newAilment";
//       ailment.Value = newAilment;
//       cmd.Parameters.Add(ailment);
//       cmd.ExecuteNonQuery();
//       _ailment = newAilment;
//       conn.Close();
//       if (conn != null)
//       {
//         conn.Dispose();
//       }
//     }
//
//
//
//   }
// }
