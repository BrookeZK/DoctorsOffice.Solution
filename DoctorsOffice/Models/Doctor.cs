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

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO doctors (name, specialty, years_of_experience) VALUES (@name, @specialty, @yearsexp);";

      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@name";
      name.Value = this._name;
      cmd.Parameters.Add(name);

      MySqlParameter specialty = new MySqlParameter();
      specialty.ParameterName = "@specialty";
      specialty.Value = this._specialty;
      cmd.Parameters.Add(specialty);

      MySqlParameter yearsexp = new MySqlParameter();
      yearsexp.ParameterName = "@yearsexp";
      yearsexp.Value = this._yearsExp;
      cmd.Parameters.Add(yearsexp);

      cmd.ExecuteNonQuery();

      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static Doctor Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM doctors WHERE id = (@searchId);";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int doctorId = 0;
      string doctorName = "";
      string doctorSpecialty = "";
      int doctorYrsExp = 0;
      while(rdr.Read())
      {
        doctorId = rdr.GetInt32(0);
        doctorName = rdr.GetString(1);
        doctorSpecialty = rdr.GetString(2);
        doctorYrsExp = rdr.GetInt32(3);
      }
      Doctor newDoctor = new Doctor(doctorName, doctorSpecialty, doctorYrsExp, doctorId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return newDoctor;
    }

    // public void Edit(string newSpecialty)
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"UPDATE doctors SET specialty = @newSpecialty WHERE id = @searchId;";
    //   MySqlParameter searchId = new MySqlParameter();
    //   searchId.ParameterName = "@searchId";
    //   searchId.Value = _id;
    //   cmd.Parameters.Add(searchId);
    //   MySqlParameter specialty = new MySqlParameter();
    //   specialty.ParameterName = "@newSpecialty";
    //   specialty.Value = newSpecialty;
    //   cmd.Parameters.Add(specialty);
    //   cmd.ExecuteNonQuery();
    //   _specialty = newSpecialty;
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    // }



  }
}
