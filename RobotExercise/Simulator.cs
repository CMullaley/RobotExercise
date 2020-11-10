using RobotExercise.Parsing;

namespace RobotExercise
{
    public class Simulator
    {
        private readonly ICommandParser _parser;

        public Simulator(ICommandParser parser)
        {
            _parser = parser;
        }

        public string ProcessCommand(string command)
        {
            try
            {
                _parser.ParseCommand(command);
            }
            catch(InvalidCommandException)
            {
                return "Bad Command";
            }

            return "Ok";
        }
    }
}
