using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RobotExercise.Commands;
using RobotExercise.Parsing;
using RobotExercise.State;

namespace RobotExercise.UnitTests
{
    [TestClass]
    public class SimulatorTests
    {
        private readonly Simulator _simulator;
        private readonly Mock<ICommandParser> _parser;

        public SimulatorTests()
        {
            _parser = new Mock<ICommandParser>();
            _simulator = new Simulator(_parser.Object);
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
    }
}
