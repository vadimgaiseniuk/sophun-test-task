using System.Threading.Tasks;
using UnityEngine;

namespace Services.AssetManagingService
{
    public interface IAssetManagingService
    {
        Task<GameObject> InstantiateAssetAsync(string assetAddress, Transform parent = null);
        
        Task<T> InstantiateAssetAsync<T>(string assetAddress, Transform parent = null);

        void ReleaseAssetInstance(GameObject assetObject);
    }
}