using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElevatorAPI.Enumeration
{
  public enum eStatus
  {
    disabled,
    dormant,
    movingUp,
    movingDown
  }

  public enum eDescriptiveStatus
  {
    disabled,
    dormant,
    movingUp,
    movingDown,
    doorsOpen,
    doorsClosed
  }

  public enum eDirection
  {
    up,
    down
  }

  public enum eDoorStatus
  {
    open,
    closed
  }
}
