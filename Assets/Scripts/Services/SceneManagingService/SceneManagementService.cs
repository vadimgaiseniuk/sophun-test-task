using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneManagementService
{
    public class SceneManagementService : ISceneManagementService
    {
        public async Task LoadSceneAsync(string sceneName, Action onSceneLoaded = null, LoadSceneMode mode = LoadSceneMode.Additive)
        {
            bool isThisSceneActive = SceneManager.GetActiveScene().name == sceneName;
            
            if (isThisSceneActive)
            {
                onSceneLoaded?.Invoke();
                return;
            }

            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName, mode);

            if (asyncOperation == null)
                return;

            while (!asyncOperation.isDone)
            {
                await Task.Yield();
            }
            
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
            
            onSceneLoaded?.Invoke();
        }
    }
}