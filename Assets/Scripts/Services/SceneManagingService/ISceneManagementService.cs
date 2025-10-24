using System;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace SceneManagementService
{
    public interface ISceneManagementService
    {
        Task LoadSceneAsync(string sceneName, Action onSceneLoaded = null, LoadSceneMode mode = LoadSceneMode.Additive);
    }
}