#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

#endregion

namespace ElevatorAPI.Objects
{
  public class Elevator : Interfaces.IElevator
  {
    #region Local Variables

    Enumeration.eStatus status;
    Enumeration.eDoorStatus doorStatus;

    int location;
    int maxLocation;
    int doorSpeed;
    int floorSpeed;

    bool[] buttonsActive;

    Timer elevatorMotion;
    Timer elevatorDoorsOpen;
    Timer elevatorDoorsClose;

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the current status of an elevator
    /// </summary>
    public ElevatorAPI.Enumeration.eStatus Status
    {
      get
      {
        return (status);
      }
      set
      {
        status = value;
      }
    }

    /// <summary>
    /// Gets or sets the current status of the elevator doors
    /// </summary>
    public Enumeration.eDoorStatus DoorStatus
    {
      get
      {
        return (doorStatus);
      }
      set
      {
        doorStatus = value;
      }
    }

    /// <summary>
    /// Gets or sets the current location of the lift
    /// </summary>
    public int Location
    {
      get
      {
        return (location);
      }
      set
      {
        location = value;
      }
    }

    /// <summary>
    /// Gets or sets the maximum number of floors in the building
    /// </summary>
    public int MaxLocation
    {
      get
      {
        return (maxLocation);
      }
      set
      {
        maxLocation = value;
      }
    }

    /// <summary>
    /// Gets or sets the door speed
    /// </summary>
    public int DoorSpeed
    {
      get
      {
        return (doorSpeed);
      }
      set
      {
        if (doorSpeed >= 1000)
          doorSpeed = value;
        else
          doorSpeed = value * 1000;
      }
    }

    /// <summary>
    /// Gets or sets the floor speed
    /// </summary>
    public int FloorSpeed
    {
      get
      {
        return (floorSpeed);
      }
      set
      {
        if (floorSpeed >= 1000)
          floorSpeed = value;
        else
          floorSpeed = value * 1000;
      }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Create an instance of an elevator
    /// </summary>
    /// <param name="numberOfFloors">Maximum number of floors that the elevator can travel to</param>
    /// <param name="status">The default status of the elevator (dormant)</param>
    /// <param name="doorStatus">The default status of the doors (open)</param>
    /// <param name="location">The default location of the elevator (1)</param>
    /// <param name="doorSpeed">The speed of the doors</param>
    /// <param name="floorSpeed">The speed in which the elevator can travel between floors</param>
    public Elevator(int numberOfFloors, Enumeration.eStatus status, Enumeration.eDoorStatus doorStatus, int location, int doorSpeed, int floorSpeed)
    {
      this.maxLocation = numberOfFloors;
      this.status = status;
      this.doorStatus = doorStatus;
      this.location = location;
      DoorSpeed = doorSpeed;
      FloorSpeed = floorSpeed;

      buttonsActive = new bool[maxLocation + 1];

      elevatorMotion = new Timer(FloorSpeed);
      elevatorDoorsOpen = new Timer(DoorSpeed);
      elevatorDoorsClose = new Timer(DoorSpeed);

      elevatorMotion.Elapsed += new ElapsedEventHandler(elevatorMotion_Move);
      elevatorDoorsOpen.Elapsed += new ElapsedEventHandler(elevatorDoors_Open);
      elevatorDoorsClose.Elapsed += new ElapsedEventHandler(elevatorDoors_Close);
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Attempt to move the elevator
    /// </summary>
    public void Move()
    {
      if (status != Enumeration.eStatus.disabled)
      {
        doorStatus = Enumeration.eDoorStatus.closed;
        elevatorMotion.Start();
      }
    }

    /// <summary>
    /// Attempts to move the elevator in the direction specified
    /// </summary>
    /// <param name="eStatus">Direction in which to try to move the elevator</param>
    private void Move(Enumeration.eStatus eStatus)
    {
      status = eStatus;
      Move();
    }

    /// <summary>
    /// Call the elevator to a specified floor
    /// </summary>
    /// <param name="fromFloor">Floor to call elevator to</param>
    public void CallElevator(int fromFloor)
    {
      if (fromFloor > 0 && fromFloor <= maxLocation)
      {
        if (status != Enumeration.eStatus.disabled)
        {
          buttonsActive[fromFloor] = true;
          
          if (!elevatorMotion.Enabled) // If the elevator is NOT moving
          {
            if (location < fromFloor)
              Move(Enumeration.eStatus.movingUp);
            else if (location > fromFloor)
              Move(Enumeration.eStatus.movingDown);
            else
            {
              buttonsActive[fromFloor] = false;
              status = Enumeration.eStatus.dormant;
            }
          }
        }
      }
    }

    /// <summary>
    /// Haults the elevator at the next floor by clearing all pending requests and sets it to disabled
    /// </summary>
    public void Hault()
    {
      for (int floorCount = 0; floorCount <= maxLocation; floorCount++)
        buttonsActive[floorCount] = false;

      status = Enumeration.eStatus.disabled;
    }

    /// <summary>
    /// Returns an array of numbers (offset 0) showing the selected floors
    /// </summary>
    /// <returns></returns>
    public int[] GetPendingRequests()
    {
      return(buttonsActive.Select((b, i) => b == true ? i : -1).Where(i => i != -1).ToArray());
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Does the elevator have any pending floors to travel to?
    /// </summary>
    /// <returns>True if elevator has other pending floors</returns>
    private bool HasOtherPendingfloors()
    {
      return (buttonsActive.Count(b => b == true) >= 1);
    }

    /// <summary>
    /// Check if there are any pending floors above (or below) our current location
    /// </summary>
    /// <param name="floorToStartFrom">Where the elevator is currently</param>
    /// <param name="direction">direction to check for pending floors</param>
    /// <returns>True if there are pending floors above or below us</returns>
    private bool IsFloorQueued(int floorToStartFrom, Enumeration.eDirection direction)
    {
      if (direction == Enumeration.eDirection.up)
      {
        for (int floorCount = floorToStartFrom; floorCount <= maxLocation; floorCount++)
        {
          if (buttonsActive[floorCount])
            return (true);
        }
      }
      else
      {
        for (int floorCount = floorToStartFrom; floorCount >= 1; floorCount--)
        {
          if (buttonsActive[floorCount])
            return (true);
        }
      }

      return (false);
    }

    /// <summary>
    /// Moves the elevator to the next floor if there are any other floors to travel to in this queue
    /// </summary>
    private void MoveToNextFloor()
    {
      if (IsFloorQueued(location, status == Enumeration.eStatus.movingUp ? Enumeration.eDirection.up : Enumeration.eDirection.down))
        Move();
      else
      {
        if (status == Enumeration.eStatus.movingUp && IsFloorQueued(location, Enumeration.eDirection.down))
          Move(Enumeration.eStatus.movingDown);
        else if (status == Enumeration.eStatus.movingDown && IsFloorQueued(location, Enumeration.eDirection.up))
          Move(Enumeration.eStatus.movingUp);
        else
        {
          doorStatus = Enumeration.eDoorStatus.open;
          status = Enumeration.eStatus.dormant;
        }
      }
    }

    /// <summary>
    /// Move the elevator to the next floor (up or down)
    /// </summary>
    private void elevatorMotion_Move(object sender, ElapsedEventArgs e)
    {
      elevatorMotion.Stop();

      if (status == Enumeration.eStatus.movingUp)
        ++location;
      else
        --location;

      // If we are travelling past a floor that has an active button then stop and open the doors
      if (buttonsActive[location])
      {
        buttonsActive[location] = false;
        elevatorDoorsOpen.Start();
      }
      else
        MoveToNextFloor();
    }

    /// <summary>
    /// Open the lift doors
    /// </summary>
    private void elevatorDoors_Open(object sender, ElapsedEventArgs e)
    {
      doorStatus = Enumeration.eDoorStatus.open;
      elevatorDoorsOpen.Stop();

      if (HasOtherPendingfloors())
        elevatorDoorsClose.Start();
      else
        status = Enumeration.eStatus.dormant;
    }

    /// <summary>
    /// Closes the lift doors
    /// </summary>
    private void elevatorDoors_Close(object sender, ElapsedEventArgs e)
    {
      doorStatus = Enumeration.eDoorStatus.closed;
      elevatorDoorsClose.Stop();
      MoveToNextFloor();
    }

    #endregion
  }
}
