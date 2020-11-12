using RobotExercise.State;

namespace RobotExercise.Tabletops
{
    public class SquareTabletop : ITabletop
    {
        private readonly uint _size;

        public SquareTabletop(uint size)
        {
            _size = size;
        }

        public bool IsPositionValid(RobotState state)
        {
            return (
                state.X >= 0 &&
                state.X < _size &&
                state.Y >= 0 &&
                state.Y < _size);
        }
    }
}
