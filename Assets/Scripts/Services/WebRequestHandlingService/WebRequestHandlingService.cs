using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Services.WebRequestHandlingService
{
    public class WebRequestHandlingService : IWebRequestHandlingService
    {
        public async Task<Sprite> GetImageAsync(string url)
        {
            UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
            
            try
            {
                AsyncOperation asyncOperation = request.SendWebRequest();

                if (asyncOperation == null)
                    return null;

                while (!asyncOperation.isDone)
                {
                    await Task.Yield();
                    Debug.Log(asyncOperation.progress);
                }

                if (request.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError("Failed to load avatar");
                    return null;
                }
                
                Texture2D downloadedAvatarTexture = DownloadHandlerTexture.GetContent(request);
                
                return Sprite.Create(downloadedAvatarTexture,  new Rect(0, 0, downloadedAvatarTexture.width, downloadedAvatarTexture.height), Vector2.zero);
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to load avatar with exception: {e.Message}");
                return null;
            }
        }
    }
}