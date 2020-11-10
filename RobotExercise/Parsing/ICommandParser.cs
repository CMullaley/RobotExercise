using RobotExercise.Commands;

namespace RobotExercise.Parsing
{
    public interface ICommandParser
    {
        ICommand ParseCommand(string command);
    }
}
