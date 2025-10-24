using System.Threading.Tasks;
using UnityEngine;

namespace Services.WebRequestHandlingService
{
    public interface IWebRequestHandlingService
    {
        Task<Sprite> GetImageAsync(string url);
    }
}