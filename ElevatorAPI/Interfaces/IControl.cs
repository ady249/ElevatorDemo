using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElevatorAPI.Interfaces
{
  interface IControl
  {
    int CallElevator(int callingFloor);
    Enumeration.eStatus Status(Interfaces.IElevator elevator);
  }
}
