using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ElevatorAPI;

namespace WindowsFormsApplication1
{
  public partial class Form1 : Form
  {
    ElevatorControlSystem liftControl;

    public Form1()
    {
      InitializeComponent();

      liftControl = new ElevatorControlSystem(4, 10, ElevatorAPI.Enumeration.eStatus.dormant, ElevatorAPI.Enumeration.eDoorStatus.open, 1, 2, 3);
      timer1.Start();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      liftControl.CallLift(textBox1.Text, textBox2.Text);
      richTextBox2.Text += String.Format("Lift #{0} - Person waiting at floor {1}\r\n", textBox1.Text, textBox2.Text);
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      int ele=0;
      richTextBox1.Text = "";
      foreach (ElevatorAPI.Objects.Elevator elevator in liftControl.Elevators)
        richTextBox1.Text += String.Format("Lift {0};Floor={1};Lift Status={2};Door Status={3}\r\n", ++ele, elevator.Location, elevator.Status, elevator.DoorStatus);
    }
  }
}
