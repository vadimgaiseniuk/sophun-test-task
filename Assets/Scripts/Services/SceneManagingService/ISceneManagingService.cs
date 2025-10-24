using System;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace SceneManagingService
{
    public interface ISceneManagingService
    {
        Task LoadSceneAsync(string sceneName, Action onSceneLoaded = null, LoadSceneMode mode = LoadSceneMode.Additive);
    }
}