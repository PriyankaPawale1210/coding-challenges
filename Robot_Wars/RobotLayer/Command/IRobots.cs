using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotLayer.Command
{
    public interface IRobots
    {
        void CreateArean(string[] command);
        void SetRobtDirection(string[] command);
        string calculatePlannedPosition(string movement);
    }
}
