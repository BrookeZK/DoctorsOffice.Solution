using Microsoft.VisualStudio.TestTools.UnitTesting;
using DoctorsOffice.Models;
using System.Collections.Generic;
using System;

namespace DoctorsOffice.Tests
{
  [TestClass]
  public class DoctorTest //: IDisposable
  {

    // public void Dispose()
    // {
    //   Patient.ClearAll();
    //   Doctor.ClearAll();
    // }

    public DoctorTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=doctors_office_test;";
    }

    [TestMethod]
    public void DoctorConstructor_CreatesNewInstanceOfDoctor_Doctor()
    {
      Doctor newDoctor = new Doctor("Dr. Fancy", "Coughs", 12);
      Assert.AreEqual(typeof(Doctor), newDoctor.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      //Arrange
      string name = "Dr. Fancy";
      Doctor newDoctor = new Doctor(name, "Coughs", 12);

      //Act
      string result = newDoctor.Name;

      //Assert
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void SetName_SetsNamePropertyToNewValue_String()
    {
      //Arrange
      string name1 = "Dr. Fancy";
      Doctor newDoctor = new Doctor(name1, "cough", 12);
      string name2 = "Dr. Lacey";

      //Act
      string result = newDoctor.Name = name2;

      //Assert
      Assert.AreEqual(name2, result);
    }
    [TestMethod]
    public void
    GetSpecialty_ReturnsSpecialty_String()
    {
      string specialty = "noses";
      Doctor newDoctor = new Doctor("Dr. Luden", specialty, 2);

      string result = newDoctor.Specialty;

      Assert.AreEqual(specialty, result);
    }
    [TestMethod]
    public void
    SetSpecialty_SetsSpecialtyPropertyToNewValue_String()
    {
      //Arrange
      string specialty1 = "fingers";
      Doctor newDoctor = new Doctor("Dr. Swarz", specialty1,23);
      string specialty2 = "hair";

      string result = newDoctor.Specialty = specialty2;

      Assert.AreEqual(specialty2, result);
    }
    [TestMethod]
    public void
    GetYearsExp_ReturnsYearsExp_Int()
    {
      int yearsExp = 5;
      Doctor newDoctor = new Doctor("Dr. Willow", "teeth", yearsExp);

      int result = newDoctor.YearsExp;

      Assert.AreEqual(yearsExp, result);
    }
    [TestMethod]
    public void
    SetYearsExp_SetsYearsExpPropertyToNewValue_Int()
    {
      int yearsExp = 7;
      Doctor newDoctor = new Doctor("Dr. Cookie", "stomach", yearsExp);
      int yearsExp2 = 20;

      int result = newDoctor.YearsExp = yearsExp2;

      Assert.AreEqual(yearsExp2, result);
    }
  }
}
