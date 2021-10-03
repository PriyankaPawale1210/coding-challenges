using Robot_Wars.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RobotLayer.Command
{
    public class RobotBuilders
    {
        private const string latitudeName = "Latitude";
        private const string longitudeName = "Longitude";
        private const string directionName = "Direction";

        private static readonly string regexPatternDirection = string.Format(@"^(?<{0}>\d+) (?<{1}>\d+) (?<{2}>[n|e|s|w])$", latitudeName, longitudeName, directionName);
        private static readonly string regexPatternArena = String.Format(@"^(?<{0}>\d+) (?<{1}>\d+)$", latitudeName, longitudeName);
        private static readonly string regexPatternMove = String.Format(@"^[m|r|l]+$");

        private IRobots _robot;
        private ILog _log;
        public RobotBuilders(IRobots robot,ILog log)
        {
            this._robot = robot;
            this._log = log;
        }

        public void ServeMethod(string command)
        {
            if (Regex.Match(command, regexPatternArena, RegexOptions.IgnoreCase).Success)
            {
                this._robot.CreateArean(command.Split(' '));
                this._log.Logger("Arena Created Successfully");
            }

            else if (Regex.Match(command, regexPatternDirection, RegexOptions.IgnoreCase).Success)
            {
                this._robot.SetRobtDirection(command.Split(' '));
                this._log.Logger("Robot Created Successfully");

            }
            else if (Regex.Match(command, regexPatternMove, RegexOptions.IgnoreCase).Success)
            {
                string result = this._robot.calculatePlannedPosition(command.ToUpper());
                this._log.Logger(string.Format("Robot Position {0}", result));
            }
            else
            {
                this._log.Logger("Invalid Input");
                Environment.Exit(0);
            }
           
        }
    }
}
