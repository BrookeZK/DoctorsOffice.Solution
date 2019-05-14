using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace DoctorsOffice.Models
{
  public class Doctor
  {
    private string _name;
    private string _specialty;
    private int _yearsExp;
    private int _id;

    public Doctor(string name, string specialty, int yearsExp, int id = 0)
    {
      _name = name;
      _specialty = specialty;
      _yearsExp = yearsExp;
      _id = id;
    }

    public string Name{ get => _name; set => _name = value; }
    public string Specialty{ get => _specialty; set => _specialty = value; }
    public int YearsExp{ get => _yearsExp; set => _yearsExp = value; }
    public int Id{ get => _id; }

    public override bool Equals(System.Object otherDoctor)
    {
      if (!(otherDoctor is Doctor))
      {
        return false;
      }
      else
      {
        Doctor newDoctor = (Doctor) otherDoctor;
        bool nameEquality = this.Name == newDoctor.Name;

        bool specialtyEquality = this.Specialty == newDoctor.Specialty;

        bool yearsExpEquality = this.YearsExp == newDoctor.YearsExp;

        bool idEquality = this.Id == newDoctor.Id;

        return (nameEquality && specialtyEquality && yearsExpEquality && idEquality);
      }
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM doctors;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Doctor> GetAll()
    {
      List<Doctor> allDoctors = new List<Doctor> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM doctors;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int doctorId = rdr.GetInt32(0);
        string doctorName = rdr.GetString(1);
        string doctorSpecialty = rdr.GetString(2);
        int doctorYearsExp = rdr.GetInt32(3);

        Doctor newDoctor = new Doctor(doctorName, doctorSpecialty, doctorYearsExp, doctorId);
        allDoctors.Add(newDoctor);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allDoctors;
    }



  }
}
