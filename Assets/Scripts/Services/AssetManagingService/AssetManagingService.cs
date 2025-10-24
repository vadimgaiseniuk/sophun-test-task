using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Services.AssetManagingService
{
    public class AssetManagingService : IAssetManagingService
    {
        public async Task<GameObject> InstantiateAssetAsync(string assetAddress, Transform parent = null)
        {
            AsyncOperationHandle<GameObject> handle = Addressables.InstantiateAsync(assetAddress, parent);
            await handle.Task;

            if (handle.Status == AsyncOperationStatus.Succeeded)
                return handle.Result;
            
            Debug.LogError($"Failed to load asset with name {assetAddress}");
            
            return null;
        }
        
        public async Task<T> InstantiateAssetAsync<T>(string assetAddress, Transform parent = null)
        {
            AsyncOperationHandle<GameObject> handle = Addressables.InstantiateAsync(assetAddress, parent);
            await handle.Task;

            if (handle.Status == AsyncOperationStatus.Succeeded)
                return handle.Result.GetComponent<T>();
            
            Debug.LogError($"Failed to load asset with name {assetAddress}");
            
            return default(T);
        }

        public void ReleaseAssetInstance(GameObject assetAddress)
        {
            Addressables.ReleaseInstance(assetAddress);
        }
    }
}