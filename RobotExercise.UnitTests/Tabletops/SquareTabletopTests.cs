using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotExercise.State;
using RobotExercise.Tabletops;

namespace RobotExercise.UnitTests.Tabletops
{
    [TestClass]
    public class SquareTabletopTests
    {
        private readonly ITabletop _tabletop = new SquareTabletop(5);

        [TestMethod]
        [DataRow(2, 3)]
        [DataRow(0, 0)]
        [DataRow(0, 4)]
        [DataRow(4, 0)]
        [DataRow(4, 4)]
        public void ValidPositionPasses(int x, int y)
        {
            Assert.IsTrue(_tabletop.IsPositionValid(new RobotState(x, y, Facing.North)));
        }

        [TestMethod]
        [DataRow(0, 5)]
        [DataRow(5, 0)]
        [DataRow(2, 6)]
        [DataRow(-1, 3)]
        [DataRow(2, -1)]
        public void InvalidPositionFails(int x, int y)
        {
            Assert.IsFalse(_tabletop.IsPositionValid(new RobotState(x, y, Facing.North)));
        }
    }
}
