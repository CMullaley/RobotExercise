using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RobotExercise.Parsing;

namespace RobotExercise.UnitTests
{
    [TestClass]
    public class SImulatorTests
    {
        private Simulator _simulator;
        private Mock<ICommandParser> _parser;

        [TestInitialize]
        public void Initialize()
        {
            _parser = new Mock<ICommandParser>();
            _simulator = new Simulator(_parser.Object);
        }

        [TestMethod]
        public void ValidCommandReturnsOk()
        {
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
    }
}
