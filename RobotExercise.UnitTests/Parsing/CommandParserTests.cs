using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotExercise.Parsing;

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
    }
}
