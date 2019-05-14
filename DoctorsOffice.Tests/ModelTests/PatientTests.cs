using Microsoft.VisualStudio.TestTools.UnitTesting;
using DoctorsOffice.Models;
using System.Collections.Generic;
using System;

namespace DoctorsOffice.Tests
{
  [TestClass]
  public class PatientTest //: IDisposable
  {

    // public void Dispose()
    // {
    //   Patient.ClearAll();
    //   Doctor.ClearAll();
    // }

    public PatientTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=doctors_office_test;";
    }

  }
}
