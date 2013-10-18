using ElevatorAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ElevatorAPI.Enumeration;
using ElevatorAPI.Objects;
using System.Collections.Generic;

namespace Test_ElevatorAPI
{
    
    
    /// <summary>
    ///This is a test class for ElevatorControlSystemTest and is intended
    ///to contain all ElevatorControlSystemTest Unit Tests
    ///</summary>
  [TestClass()]
  public class ElevatorControlSystemTest
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
    ///A test for ElevatorControlSystem Constructor
    ///</summary>
    [TestMethod()]
    public void ElevatorControlSystemConstructorTest()
    {
      int numberOfElevators = 4;
      int numberOfFloors = 100; 
      eStatus status = new eStatus(); 
      eDoorStatus doorStatus = new eDoorStatus(); 
      int location = 1;
      int doorSpeed = 2; 
      int floorSpeed = 3;
      ElevatorControlSystem target = new ElevatorControlSystem(numberOfElevators, numberOfFloors, status, doorStatus, location, doorSpeed, floorSpeed);
      Assert.IsNotNull(target);
      Assert.IsInstanceOfType(target, typeof(ElevatorControlSystem));
    }

    /// <summary>
    ///A test for CallLift
    ///</summary>
    [TestMethod()]
    public void CallLiftTest()
    {
      int numberOfElevators = 4;
      int numberOfFloors = 100;
      eStatus status = new eStatus();
      eDoorStatus doorStatus = new eDoorStatus();
      int location = 1;
      int doorSpeed = 2;
      int floorSpeed = 3;
      ElevatorControlSystem target = new ElevatorControlSystem(numberOfElevators, numberOfFloors, status, doorStatus, location, doorSpeed, floorSpeed); // TODO: Initialize to an appropriate value
      int liftNumber = 1;
      int fromFloor = 5; 
      target.CallLift(liftNumber, fromFloor);

      //Assert.AreEqual(fromFloor, target.Elevators[liftNumber].Location);
      Assert.Inconclusive("Timers are non functional when executing from test");
    }

    /// <summary>
    ///A test for CallLift
    ///</summary>
    [TestMethod()]
    public void CallLiftTest1()
    {
      int numberOfElevators = 4;
      int numberOfFloors = 100;
      eStatus status = new eStatus();
      eDoorStatus doorStatus = new eDoorStatus();
      int location = 1;
      int doorSpeed = 2;
      int floorSpeed = 3;
      ElevatorControlSystem target = new ElevatorControlSystem(numberOfElevators, numberOfFloors, status, doorStatus, location, doorSpeed, floorSpeed); // TODO: Initialize to an appropriate value
      int liftNumber = 3;
      int fromFloor = 7;
      target.CallLift(liftNumber, fromFloor);

      //Assert.AreEqual(fromFloor, target.Elevators[liftNumber].Location);
      Assert.Inconclusive("Timers are non functional when executing from test");
    }

    /// <summary>
    ///A test for CallLift
    ///</summary>
    [TestMethod()]
    public void CallLiftTest2()
    {
      int numberOfElevators = 4;
      int numberOfFloors = 100;
      eStatus status = new eStatus();
      eDoorStatus doorStatus = new eDoorStatus();
      int location = 1;
      int doorSpeed = 2;
      int floorSpeed = 3;
      ElevatorControlSystem target = new ElevatorControlSystem(numberOfElevators, numberOfFloors, status, doorStatus, location, doorSpeed, floorSpeed);
      int liftNumber = 4;
      int fromFloor = 100;
      target.CallLift(liftNumber, fromFloor);

      //Assert.AreEqual(fromFloor, target.Elevators[liftNumber].Location);
      Assert.Inconclusive("Timers are non functional when executing from test");
    }

    /// <summary>
    ///A test for Elevators
    ///</summary>
    [TestMethod()]
    public void ElevatorsTest()
    {
      int numberOfElevators = 0; // TODO: Initialize to an appropriate value
      int numberOfFloors = 0; // TODO: Initialize to an appropriate value
      eStatus status = new eStatus(); // TODO: Initialize to an appropriate value
      eDoorStatus doorStatus = new eDoorStatus(); // TODO: Initialize to an appropriate value
      int location = 0; // TODO: Initialize to an appropriate value
      int doorSpeed = 0; // TODO: Initialize to an appropriate value
      int floorSpeed = 0; // TODO: Initialize to an appropriate value
      ElevatorControlSystem target = new ElevatorControlSystem(numberOfElevators, numberOfFloors, status, doorStatus, location, doorSpeed, floorSpeed); // TODO: Initialize to an appropriate value
      List<Elevator> actual;
      actual = target.Elevators;

      Assert.IsNotNull(actual);
      Assert.IsInstanceOfType(actual, typeof(List<Elevator>));
    }
  }
}
