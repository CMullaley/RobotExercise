using RobotExercise.State;

namespace RobotExercise.Commands
{
    public interface ICommand
    {
        RobotState? Execute(RobotState? state);
    }
}
