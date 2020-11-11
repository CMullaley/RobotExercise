using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotExercise.Commands;
using RobotExercise.State;
using System.ComponentModel;

namespace RobotExercise.UnitTests.Commands
{
    [TestClass]
    public class LeftCommandTests
    {
        private readonly ICommand _command = new LeftCommand();

        [TestMethod]
        public void ActingOnNullIsSafe()
        {
            RobotState? result = _command.Execute(null);
            Assert.IsNull(result);
        }

        [TestMethod]
        [DataRow(Facing.North, Facing.West)]
        [DataRow(Facing.East, Facing.North)]
        [DataRow(Facing.South, Facing.East)]
        [DataRow(Facing.West, Facing.South)]
        public void CommandActsCorrectly(Facing start, Facing expected)
        {
            int startX = 2;
            int startY = 3;

            RobotState startState = new RobotState(startX, startY, start);
            RobotState? result = _command.Execute(startState);

            Assert.IsNotNull(result);
            Assert.AreEqual(startX, result?.X);
            Assert.AreEqual(startY, result?.Y);
            Assert.AreEqual(expected, result?.Facing);
        }
    }
}
