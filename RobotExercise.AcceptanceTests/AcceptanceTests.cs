using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotExercise.Parsing;

namespace RobotExercise.AcceptanceTests
{
    [TestClass]
    public class AcceptanceTests
    {
        [TestMethod]
        public void ScenarioA()
        {
            RunScenario(new[]
                {
                    "PLACE 0,0,NORTH",
                    "MOVE",
                    "REPORT"
                },
                "0,1,NORTH"
            );
        }

        [TestMethod]
        public void ScenarioB()
        {
            RunScenario(new[]
                {
                    "PLACE 0,0,NORTH",
                    "LEFT",
                    "REPORT"
                },
                "0,0,WEST"
            );
        }

        [TestMethod]
        public void ScenarioC()
        {
            RunScenario(new[]
                {
                    "PLACE 1,2,EAST",
                    "MOVE",
                    "MOVE",
                    "LEFT",
                    "MOVE",
                    "REPORT"
                },
                "3,3,NORTH"
            );
        }



        private void RunScenario(string[] commands, string expectedOutput)
        {
            Simulator simulator = new Simulator(new CommandParser());
            string output = string.Empty;

            foreach(string command in commands)
            {
                output = simulator.ProcessCommand(command);
            }

            Assert.AreEqual(expectedOutput, output);
        }
    }
}
