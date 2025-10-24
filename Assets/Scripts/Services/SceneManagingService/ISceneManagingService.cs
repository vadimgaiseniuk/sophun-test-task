using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace SceneManagingService
{
    public interface ISceneManagingService
    {
        Task LoadSceneAsync(string sceneName, LoadSceneMode mode = LoadSceneMode.Additive);
    }
}