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
                command.Execute(_state);
            }
            catch(InvalidCommandException)
            {
                return "Bad Command";
            }

            return "Ok";
        }
    }
}
