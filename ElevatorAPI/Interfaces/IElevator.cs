using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElevatorAPI.Interfaces
{
  interface IElevator
  {
    ElevatorAPI.Enumeration.eStatus Status
    {
      get;
      set;
    }

    ElevatorAPI.Enumeration.eDoorStatus DoorStatus
    {
      get;
      set;
    }

    int Location
    {
      get;
      set;
    }

    int MaxLocation
    {
      get;
      set;
    }

    int DoorSpeed
    {
      get;
      set;
    }

    int FloorSpeed
    {
      get;
      set;
    }

    void Move();
    void CallElevator(int fromFloor);
  }
}
