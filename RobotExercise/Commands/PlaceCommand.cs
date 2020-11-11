using RobotExercise.State;

namespace RobotExercise.Commands
{
    public class PlaceCommand : ICommand
    {
        private readonly RobotState _state;

        public PlaceCommand(RobotState state)
        {
            _state = state;
        }

        public RobotState? Execute(RobotState? state)
        {
            return _state;
        }
    }
}
