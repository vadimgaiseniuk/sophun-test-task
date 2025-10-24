using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneManagingService
{
    public class SceneManagingService : ISceneManagingService
    {
        public async Task LoadSceneAsync(string sceneName, LoadSceneMode mode = LoadSceneMode.Additive)
        {
            bool isThisSceneActive = SceneManager.GetActiveScene().name == sceneName;
            
            if (isThisSceneActive)
                return;

            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName, mode);

            if (asyncOperation == null)
                return;

            while (!asyncOperation.isDone)
            {
                await Task.Yield();
            }
            
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
        }
    }
}