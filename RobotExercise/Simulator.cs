using RobotExercise.Commands;
using RobotExercise.Parsing;
using RobotExercise.State;
using RobotExercise.Tabletops;

namespace RobotExercise
{
    public class Simulator
    {
        private readonly ICommandParser _parser;
        private readonly ITabletop _tabletop;
        
        private RobotState? _state;

        public Simulator(ICommandParser parser, ITabletop tabletop)
        {
            _parser = parser;
            _tabletop = tabletop;
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

                RobotState? targetState = command.Execute(_state);

                if (targetState != null && _tabletop.IsPositionValid(targetState))
                {
                    _state = targetState;
                }
            }
            catch(InvalidCommandException)
            {
                return "Bad Command";
            }

            return "Ok";
        }
    }
}
