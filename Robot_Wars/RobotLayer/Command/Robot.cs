using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotLayer.Command
{
    public class Robot : IRobots
    {
        public static int fieldWidth = 1;
        public static int fieldHeight = 1;

        public int currentXPosition = 0;
        public int currentYPosition = 0;
        public string currentOrientation = "N";
        private int originX = 0;
        private int originY = 0;


        //  Look up table for cardinal directions in counter clockwise direction
        public string[] cardinalDirection = { "N", "W", "S", "E" };
        public void CreateArean(string[] command)
        {
            int latitude = Convert.ToInt32(command[0]);
            int longitude = Convert.ToInt32(command[1]);
            fieldHeight = latitude;
            fieldWidth = longitude;

        }

        public void SetRobtDirection(string[] command)
        {
            currentXPosition = Convert.ToInt32(command[0]);
            currentYPosition = Convert.ToInt32(command[1]);
            currentOrientation = (command[2]).ToString().ToUpper();

        }

        public string calculatePlannedPosition(string movement)
        {
            string plannedPosition = currentXPosition.ToString() + " " + currentYPosition.ToString() + " " + currentOrientation;

            foreach (char c in movement)
            {
                switch (c)
                {
                    case ('L'):
                        {
                            //  Rotate 90 degrees clockwise
                            int index = Array.FindIndex(cardinalDirection, row => row == currentOrientation);

                            //  Move up the array
                            //  If we hit the last element of the array then reset to first element
                            currentOrientation = (index < cardinalDirection.Length - 1) ? cardinalDirection[index + 1] : cardinalDirection[0];
                        }
                        break;
                    case ('R'):
                        {
                            //  Rotate 90 degrees clockwise
                            int index = Array.FindIndex(cardinalDirection, row => row == currentOrientation);

                            //  Move down the array 
                            //  If we hit the first element of the array then reset to last element
                            currentOrientation = (index > 0) ? cardinalDirection[index - 1] : cardinalDirection[3];
                        }
                        break;
                    case ('M'):
                        {
                            //  Move up by 1 unit in y axis within grid boundaries
                            if ((currentOrientation == "N") && (currentYPosition < fieldHeight))
                            {
                                currentYPosition++;
                            }
                            //  Move left by 1 unit in x axis within grid boundaries
                            if ((currentOrientation == "W") && (currentXPosition > originX))
                            {
                                currentXPosition--;
                            }

                            //  Move down by 1 unit in y axis within grid boundaries
                            if ((currentOrientation == "S") && (currentYPosition > originY))
                            {
                                currentYPosition--;
                            }

                            //  Move right by 1 unit in x axis within grid boundaries
                            if ((currentOrientation == "E") && (currentXPosition < fieldWidth))
                            {
                                currentXPosition++;
                            }
                        }
                        break;
                }
            }
            plannedPosition = currentXPosition + " " + currentYPosition + " " + currentOrientation;

            return plannedPosition;
        }
    }
}
