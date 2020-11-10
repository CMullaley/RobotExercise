using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotExercise.Commands;
using RobotExercise.Parsing;
using System;

namespace RobotExercise.UnitTests.Parsing
{
    [TestClass]
    public class CommandParserTests
    {
        private ICommandParser _parser;

        [TestInitialize]
        public void Initialize()
        {
            _parser = new CommandParser();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandException))]
        public void InvalidCommandThrowsException()
        {
            _parser.ParseCommand("INVALID");
        }

        [TestMethod]
        [DataRow("MOVE", typeof(MoveCommand))]
        [DataRow("LEFT", typeof(LeftCommand))]
        [DataRow("RIGHT", typeof(RightCommand))]
        [DataRow("REPORT", typeof(ReportCommand))]
        public void CreateSimpleCommand(string command, Type type)
        {
            ICommand result = _parser.ParseCommand(command);

            Assert.IsInstanceOfType(result, type);
        }
    }
}
