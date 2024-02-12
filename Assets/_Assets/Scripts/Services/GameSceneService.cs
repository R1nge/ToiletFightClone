using _Assets.Scripts.Services.Levels;
using UnityEngine.SceneManagement;

namespace _Assets.Scripts.Services
{
    public class GameSceneService
    {
        private readonly GameLevelsService _gameLevelsService;

        private GameSceneService(GameLevelsService gameLevelsService) => _gameLevelsService = gameLevelsService;

        public void LoadLastGameLevel()
        {
            //TODO: show/hide loading curtain
            SceneManager.LoadSceneAsync(_gameLevelsService.GetLastLevelName(), LoadSceneMode.Single);
        }
    }
}