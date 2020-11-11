using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotExercise.Commands;
using RobotExercise.State;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotExercise.UnitTests.Commands
{
    [TestClass]
    public class PlaceCommandTests
    {
        [TestMethod]
        public void PlaceRobotReplacesOriginalPosition()
        {
            RobotState state = new RobotState(2, 4, Facing.East);
            ICommand command = new PlaceCommand(state);

            RobotState? result = command.Execute(new RobotState(3, 1, Facing.North));
            Assert.AreEqual(state, result);
        }
    }
}
