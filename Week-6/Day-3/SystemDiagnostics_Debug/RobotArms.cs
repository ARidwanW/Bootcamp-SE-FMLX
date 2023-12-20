using System.Diagnostics;

namespace Debugging
{
    public class RobotArm
    {
        public void Connect()
        {
            Debug.WriteLine("Connecting to robot arm");
            // Code to connect to robot arm
        }

        public void MoveTo(int x, int y, int z)
        {
            Debug.WriteLine($"Moving robot arm to ({x}, {y}, {z})");
            // Code to move robot arm to specified position
        }

        public void Grab()
        {
            Debug.WriteLine("Grabbing object with robot arm");
            // Code to grab object with robot arm
        }

        public void Release()
        {
            Debug.WriteLine("Releasing object with robot arm");
            // Code to release object with robot arm
        }

        public void Disconnect()
        {
            Debug.WriteLine("Disconnecting from robot arm");
            // Code to disconnect from robot arm
        }
    }
}