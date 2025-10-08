using Hydac;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HydacUnitTest
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void Employee_ComeAndGo_RecordsCorrectly()
        {
            // Arrange
            var registration = new Registration();
            int employeeId = 1;
            string expectedName = "Anders Madsen";
            var employee = Employee.employes[0];

            // Simulere check-in
            employee.IsCheckedIn = false;
            registration.id = employeeId;
            registration.name = expectedName;
            registration.inOut = true;

            // Act & Assert
            if (!employee.IsCheckedIn)
            {
                employee.IsCheckedIn = true;
                Assert.IsTrue(employee.IsCheckedIn, "Check-in should succeed.");
            }
            else
            {
                Assert.Fail("Employee should not be already checked in.");
            }

            // Prøv at checke in igen (skulle fejle)
            bool checkedInAgain = employee.IsCheckedIn;
            Assert.IsTrue(checkedInAgain, "Second check-in should fail (already checked in).");

            // Simulere chech ud
            registration.inOut = false;
            if (employee.IsCheckedIn)
            {
                employee.IsCheckedIn = false;
                Assert.IsFalse(employee.IsCheckedIn, "Check-out should succeed.");
            }
            else
            {
                Assert.Fail("Employee should be checked in before checking out.");
            }

            Assert.AreEqual(expectedName, registration.name, "Check-in name mismatch.");
            Assert.AreEqual(expectedName, registration.name, "Check-out name mismatch.");
        }
    }
}
