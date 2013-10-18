using ElevatorAPI.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ElevatorAPI.Enumeration;
using System.Timers;

namespace Test_ElevatorAPI
{


  /// <summary>
  ///This is a test class for ElevatorTest and is intended
  ///to contain all ElevatorTest Unit Tests
  ///</summary>
  [TestClass()]
  public class ElevatorTest
  {
    private TestContext testContextInstance;

    /// <summary>
    ///Gets or sets the test context which provides
    ///information about and functionality for the current test run.
    ///</summary>
    public TestContext TestContext
    {
      get
      {
        return testContextInstance;
      }
      set
      {
        testContextInstance = value;
      }
    }

    #region Additional test attributes
    // 
    //You can use the following additional attributes as you write your tests:
    //
    //Use ClassInitialize to run code before running the first test in the class
    //[ClassInitialize()]
    //public static void MyClassInitialize(TestContext testContext)
    //{
    //}
    //
    //Use ClassCleanup to run code after all tests in a class have run
    //[ClassCleanup()]
    //public static void MyClassCleanup()
    //{
    //}
    //
    //Use TestInitialize to run code before running each test
    //[TestInitialize()]
    //public void MyTestInitialize()
    //{
    //}
    //
    //Use TestCleanup to run code after each test has run
    //[TestCleanup()]
    //public void MyTestCleanup()
    //{
    //}
    //
    #endregion


    /// <summary>
    ///A test for Elevator Constructor
    ///</summary>
    [TestMethod()]
    public void ElevatorConstructorTest()
    {
      int numberOfFloors = 100; // TODO: Initialize to an appropriate value
      eStatus status = new eStatus(); // TODO: Initialize to an appropriate value
      eDoorStatus doorStatus = new eDoorStatus(); // TODO: Initialize to an appropriate value
      int location = 1; // TODO: Initialize to an appropriate value
      int doorSpeed = 2; // TODO: Initialize to an appropriate value
      int floorSpeed = 3; // TODO: Initialize to an appropriate value
      Elevator target = new Elevator(numberOfFloors, status, doorStatus, location, doorSpeed, floorSpeed);

      Assert.IsNotNull(target);
      Assert.IsInstanceOfType(target, typeof(Elevator));
    }

    /// <summary>
    ///A test for CallElevator
    ///</summary>
    [TestMethod()]
    public void CallElevatorTest()
    {
      int numberOfFloors = 100; 
      eStatus status = new eStatus(); 
      eDoorStatus doorStatus = new eDoorStatus();
      int location = 1; 
      int doorSpeed = 2; 
      int floorSpeed = 3; 
      Elevator target = new Elevator(numberOfFloors, status, doorStatus, location, doorSpeed, floorSpeed); // TODO: Initialize to an appropriate value
      int fromFloor = 1; 
      target.CallElevator(fromFloor);

      Assert.AreEqual(fromFloor, target.Location);
    }
  }
}
