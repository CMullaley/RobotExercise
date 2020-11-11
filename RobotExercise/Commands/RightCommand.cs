using RobotExercise.State;

namespace RobotExercise.Commands
{
    public class RightCommand : ICommand
    {
        public RobotState? Execute(RobotState? state)
        {
            if (state == null)
            {
                return null;
            }

            int newFacing = (int)state.Facing + 1;

            return new RobotState(
                state.X,
                state.Y,
                newFacing == 5 ? Facing.North : (Facing)newFacing);
        }
    }
}
