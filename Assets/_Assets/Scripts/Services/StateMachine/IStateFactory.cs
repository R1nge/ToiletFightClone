namespace _Assets.Scripts.Services.StateMachine
{
    public interface IStateFactory
    {
        IGameState CreateState(GameStateMachine gameStateMachine);
    }
}