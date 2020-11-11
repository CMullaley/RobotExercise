using RobotExercise.Commands;
using RobotExercise.Parsing;
using RobotExercise.State;

namespace RobotExercise
{
    public class Simulator
    {
        private readonly ICommandParser _parser;
        
        private RobotState? _state;

        public Simulator(ICommandParser parser)
        {
            _parser = parser;
        }

        public string ProcessCommand(string commandText)
        {
            try
            {
                ICommand command = _parser.ParseCommand(commandText);

                if (command is ReportCommand)
                {
                    return _state?.ToString() ?? string.Empty;
                }

                _state = command.Execute(_state);
            }
            catch(InvalidCommandException)
            {
                return "Bad Command";
            }

            return "Ok";
        }
    }
}
