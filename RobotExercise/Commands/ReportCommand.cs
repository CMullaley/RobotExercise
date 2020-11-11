using RobotExercise.State;

namespace RobotExercise.Commands
{
    public class ReportCommand : ICommand
    {
        public RobotState? Execute(RobotState? state)
        {
            return state;
        }
    }
}
