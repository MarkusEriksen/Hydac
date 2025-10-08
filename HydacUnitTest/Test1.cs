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

            // Act
            bool checkedIn = registration.TryCheckInOut(employeeId, true, out string nameIn);
            bool checkedInAgain = registration.TryCheckInOut(employeeId, true, out _); // Should fail
            bool checkedOut = registration.TryCheckInOut(employeeId, false, out string nameOut);

            // Assert
            Assert.IsTrue(checkedIn, "Check-in should succeed.");
            Assert.IsFalse(checkedInAgain, "Second check-in should fail (already checked in).");
            Assert.IsTrue(checkedOut, "Check-out should succeed.");
            Assert.AreEqual(expectedName, nameIn, "Check-in name mismatch.");
            Assert.AreEqual(expectedName, nameOut, "Check-out name mismatch.");
        }
    }
}
