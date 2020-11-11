using RobotExercise.State;

namespace RobotExercise.Commands
{
    public class LeftCommand : ICommand
    {
        public RobotState? Execute(RobotState? state)
        {
            if (state == null)
            {
                return null;
            }

            int newFacing = (int)state.Facing - 1;

            return new RobotState(
                state.X,
                state.Y,
                newFacing == 0 ? Facing.West : (Facing)newFacing);
        }
    }
}
