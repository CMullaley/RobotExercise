using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RobotExercise.Commands;
using RobotExercise.Parsing;
using RobotExercise.State;
using RobotExercise.Tabletops;

namespace RobotExercise.UnitTests
{
    [TestClass]
    public class SimulatorTests
    {
        private readonly Simulator _simulator;
        private readonly Mock<ICommandParser> _parser;
        private readonly Mock<ITabletop> _tabletop;

        public SimulatorTests()
        {
            _parser = new Mock<ICommandParser>();
            _tabletop = new Mock<ITabletop>();

            _simulator = new Simulator(_parser.Object, _tabletop.Object);
        }

        [TestMethod]
        public void ValidCommandReturnsOk()
        {
            Mock<ICommand> command = new Mock<ICommand>();
            _parser.Setup(x => x.ParseCommand(It.IsAny<string>()))
                .Returns(command.Object);

            string result = _simulator.ProcessCommand("VALID");

            Assert.AreEqual("Ok", result);
        }

        [TestMethod]
        public void InvalidCommandReturnsErrorMessage()
        {
            _parser.Setup(x => x.ParseCommand(It.IsAny<string>()))
                .Throws(new InvalidCommandException());

            string result = _simulator.ProcessCommand("INVALID");

            Assert.AreEqual("Bad Command", result);
        }

        [TestMethod]
        public void CommandIsExecuted()
        {
            Mock<ICommand> command = new Mock<ICommand>();
            _parser.Setup(x => x.ParseCommand(It.IsAny<string>()))
                .Returns(command.Object);

            _simulator.ProcessCommand("DO");

            command.Verify(x => x.Execute(It.IsAny<RobotState>()));
        }

        [TestMethod]
        public void ReportCommandOnUnitialisedStateIsSafe()
        {
            _parser.Setup(x => x.ParseCommand(It.IsAny<string>()))
                .Returns(new ReportCommand());

            string result = _simulator.ProcessCommand("REPORT");

            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void PositionIsChecked()
        {
            RobotState state = new RobotState(1, 4, Facing.South);

            Mock<ICommand> command = new Mock<ICommand>();
            _parser.Setup(x => x.ParseCommand(It.IsAny<string>()))
                .Returns(command.Object);

            command.Setup(x => x.Execute(It.IsAny<RobotState>()))
                .Returns(state);

            _simulator.ProcessCommand("DO");

            _tabletop.Verify(x => x.IsPositionValid(state));
        }
    }
}
