using RobotExercise.Commands;
using RobotExercise.State;
using System;

namespace RobotExercise.Parsing
{
    public class CommandParser : ICommandParser
    {
        public ICommand ParseCommand(string command)
        {
            string[]? components = command.Split(' ');
            if (components == null || components.Length == 0)
            {
                throw new InvalidCommandException();
            }

            return (components[0]) switch
            {
                "PLACE" => ParsePlaceCommand(components),
                "MOVE" => new MoveCommand(),
                "LEFT" => new LeftCommand(),
                "RIGHT" => new RightCommand(),
                "REPORT" => new ReportCommand(),
                _ => throw new InvalidCommandException()
            };
        }

        private ICommand ParsePlaceCommand(string[] components)
        {
            if (components.Length == 1)
            {
                throw new InvalidCommandException();
            }

            string[] data = components[1].Split(',');

            if (data.Length != 3)
            {
                throw new InvalidCommandException();
            }

            if (!int.TryParse(data[0], out int x) ||
                !int.TryParse(data[1], out int y) ||
                !Enum.TryParse(typeof(Facing), data[2], true, out object? facing))
            {
                throw new InvalidCommandException();
            }

            return new PlaceCommand();
        }
    }
}
