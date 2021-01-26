using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VaccineClassLib;

namespace VaccineUnitTest
{
    [TestClass]
    public class VaccineTest
    {
        [TestMethod]
        public void TestForSuccesfulCreationOfObj()
        {
            try
            {
                //arrange
                //act
                Vaccine v = new Vaccine() { Id = 1, Producer = "Test", Efficiency = 75, Price = 10 };


                //assert
                Assert.AreEqual("Id: 1, Producer: Test, Price: 10, Efficiency: 75", v.ToString());

            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void TestForFailInProducerName()
        {
            try
            {
                //vi s�tter den op til at fejle
                Vaccine vaccine = new Vaccine() { Producer = "T" };
                //Testen fejler fordi den b�r ramme catchen
                Assert.Fail();
            }
            catch (Exception e)
            {
                //vi tester om beskeden i exception er korrekt
                Assert.IsTrue(e.Message.Contains("Producer name too short"));
            }
        }

        [TestMethod]
        public void TestForFailInPrice()
        {
            try
            {
                //s�tter den op til at fejle
                Vaccine v = new Vaccine() { Price = -1 };
                //testen fejler hvis den n�r her
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Contains("Price must be above 0"));
            }
        }

        [TestMethod]
        public void TestForFailAboveEfficiency()
        {
            try
            {
                //s�tter den op til at fejle
                Vaccine v = new Vaccine() { Efficiency = 101 };
                //Testen fejler hvis den n�r videre
                Assert.Fail();
            }
            catch (Exception e)
            {

                Assert.IsTrue(e.Message.Contains("Efficiency must be below 100"));

            }
        }

        [TestMethod]
        public void TestForFailBelowEfficiency()
        {
            try
            {
                //s�tter den op til at fejle
                Vaccine v = new Vaccine() { Efficiency = 49 };
                //Testen fejler hvis den n�r videre
                Assert.Fail();
            }
            catch (Exception e)
            {

                Assert.IsTrue(e.Message.Contains("Efficiency must be above 50"));

            }
        }

    }
}
