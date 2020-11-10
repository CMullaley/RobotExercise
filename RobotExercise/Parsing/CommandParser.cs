using RobotExercise.Commands;

namespace RobotExercise.Parsing
{
    public class CommandParser : ICommandParser
    {
        public ICommand ParseCommand(string command)
        {
            switch (command)
            {
                case "MOVE":
                    return new MoveCommand();
                case "LEFT":
                    return new LeftCommand();
                case "RIGHT":
                    return new RightCommand();
                case "REPORT":
                    return new ReportCommand();
            }
            throw new InvalidCommandException();
        }
    }
}
