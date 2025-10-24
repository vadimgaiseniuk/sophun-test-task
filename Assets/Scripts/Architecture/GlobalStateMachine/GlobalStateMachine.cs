using Architecture.Core;
using Architecture.States;
using SceneManagingService;

namespace Architecture
{
    public class GlobalStateMachine : StateMachineBase
    {
        public GlobalStateMachine(ISceneManagingService sceneManagingService)
        {
            var bootstrapState = new BootstrapState(sceneManagingService);
            var leaderboardState = new LeaderboardState();
            
            Add(bootstrapState);
            bootstrapState.Initialize(this);
            Add(leaderboardState);
            leaderboardState.Initialize(this);
        }
    }
}