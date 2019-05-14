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



  }
}
