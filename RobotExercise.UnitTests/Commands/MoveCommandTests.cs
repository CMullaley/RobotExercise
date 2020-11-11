using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotExercise.Commands;
using RobotExercise.State;

namespace RobotExercise.UnitTests.Commands
{
    [TestClass]
    public class MoveCommandTests
    {
        private readonly ICommand _command = new MoveCommand();

        [TestMethod]
        public void ActingOnNullIsSafe()
        {
            RobotState? result = _command.Execute(null);
            Assert.IsNull(result);
        }

        [TestMethod]
        [DataRow(Facing.North, 2, 3)]
        [DataRow(Facing.East, 3, 2)]
        [DataRow(Facing.South, 2, 1)]
        [DataRow(Facing.West, 1, 2)]
        public void CommandActsCorrectly(Facing facing, int expectedX, int expectedY)
        {
            RobotState startState = new RobotState(2, 2, facing);
            RobotState? result = _command.Execute(startState);

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedX, result?.X);
            Assert.AreEqual(expectedY, result?.Y);
            Assert.AreEqual(facing, result?.Facing);
        }
    }
}
