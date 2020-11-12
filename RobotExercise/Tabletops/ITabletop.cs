using RobotExercise.State;

namespace RobotExercise.Tabletops
{
    public interface ITabletop
    {
        bool IsPositionValid(RobotState state);
    }
}
