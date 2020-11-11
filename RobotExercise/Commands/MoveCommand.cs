using RobotExercise.State;

namespace RobotExercise.Commands
{
    public class MoveCommand : ICommand
    {
        public RobotState? Execute(RobotState? state)
        {
            if (state == null)
            {
                return null;
            }

            return (state.Facing) switch
            {
                Facing.North => new RobotState(state.X, state.Y + 1, state.Facing),
                Facing.East => new RobotState(state.X + 1, state.Y, state.Facing),
                Facing.South => new RobotState(state.X, state.Y - 1, state.Facing),
                Facing.West => new RobotState(state.X - 1, state.Y, state.Facing),
                _ => state,
            };
        }
    }
}
