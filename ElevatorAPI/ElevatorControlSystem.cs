#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace ElevatorAPI
{
  public class ElevatorControlSystem
  {
    #region Local Variables

    List<ElevatorAPI.Objects.Elevator> elevators;
    int numberOfElevators;

    bool internalError = false;

    #endregion

    #region Properies

    /// <summary>
    /// Has something gone wrong with our elevator control system?
    /// </summary>
    public bool HasInternalError
    {
      get
      {
        return (internalError);
      }
    }

    /// <summary>
    /// Gets the list of generated elevators
    /// </summary>
    public List<ElevatorAPI.Objects.Elevator> Elevators
    {
      get
      {
        return (elevators);
      }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates an elevator control system instance
    /// </summary>
    /// <param name="numberOfElevators">Number of elevators to create</param>
    /// <param name="numberOfFloors">Maximum number of floors in the building</param>
    /// <param name="status">Default status of lifts (dormant)</param>
    /// <param name="doorStatus">Default status of doors (open)</param>
    /// <param name="location">Default location of lifts (1)</param>
    /// <param name="doorSpeed">Speed of lift doors</param>
    /// <param name="floorSpeed">Speed of lift between floors</param>
    public ElevatorControlSystem(int numberOfElevators, int numberOfFloors, Enumeration.eStatus status, Enumeration.eDoorStatus doorStatus, int location, int doorSpeed, int floorSpeed)
    {
      try
      {
        elevators = new List<Objects.Elevator>();
        this.numberOfElevators = numberOfElevators;

        Objects.Elevator elevator;

        for (int elevatorCount = 1; elevatorCount <= numberOfElevators; elevatorCount++)
        {
          elevator = new Objects.Elevator(numberOfFloors, status, doorStatus, location, doorSpeed, floorSpeed);
          elevators.Add(elevator);
        }
      }

      catch
      {
        internalError = true;
      }
    }

    /// <summary>
    /// Checks if the lift number is a valid elevator
    /// </summary>
    /// <param name="liftNumber">Lift number to check</param>
    /// <returns>True if elevator falls within lift range</returns>
    private bool CheckLiftNumber(int liftNumber)
    {
      return ((liftNumber >= 0 && liftNumber <= numberOfElevators));
    }

    /// <summary>
    /// Calls the specified lift to the specified floor
    /// </summary>
    /// <param name="liftNumber">Lift to call</param>
    /// <param name="fromFloor">Floor to call the lift to</param>
    public void CallLift(object liftNumber, object fromFloor)
    {
      try
      {
        CallLift(Convert.ToInt32(liftNumber), Convert.ToInt32(fromFloor));
      }

      catch
      {
        internalError = true;
      }
    }

    /// <summary>
    /// Calls the specified lift to the specified floor
    /// </summary>
    /// <param name="liftNumber">Lift to call</param>
    /// <param name="fromFloor">Floor to call the lift to</param>
    public void CallLift(int liftNumber, int fromFloor)
    {
      if (CheckLiftNumber(liftNumber))
       elevators[liftNumber - 1].CallElevator(fromFloor);
    }

    /// <summary>
    /// Haults the specified lift after it has arrived at its next destination
    /// </summary>
    /// <param name="liftNumber">Lift to hault</param>
    public void Hault(object liftNumber)
    {
      try
      {
        Hault(Convert.ToInt32(liftNumber));
      }

      catch
      {
        internalError = true;
      }
    }

    /// <summary>
    /// Haults the specified lift after it has arrived at its next destination
    /// </summary>
    /// <param name="liftNumber">Lift to hault</param>
    public void Hault(int liftNumber)
    {
      if (CheckLiftNumber(liftNumber))
        elevators[liftNumber - 1].Hault();
    }

    /// <summary>
    /// Gets a list of pending call requests (someone has called the lift)
    /// </summary>
    /// <param name="liftNumber">Lift to check</param>
    /// <returns>An array of floor numbers</returns>
    public int[] PendingRequests(object liftNumber)
    {
      try
      {
        return (PendingRequests(Convert.ToInt32(liftNumber)));
      }

      catch
      {
        internalError = true;
      }

      return (new int[] { 0 });
    }

    /// <summary>
    /// Gets a list of pending call requests (someone has called the lift)
    /// </summary>
    /// <param name="liftNumber">Lift to check</param>
    /// <returns>An array of floor numbers</returns>
    public int[] PendingRequests(int liftNumber)
    {
      if (CheckLiftNumber(liftNumber))
        return (elevators[liftNumber - 1].GetPendingRequests());
      else
        return (new int[] { 0 });
    }

    #endregion
  }
}
