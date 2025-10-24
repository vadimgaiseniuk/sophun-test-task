using System.Threading.Tasks;
using Architecture.Core;
using Services.AssetManagingService;
using UnityEngine;

namespace App.UserInterface
{
    public interface ILeaderboardModel
    {
        IAssetManagingService AssetManagingService { get; }
        
        void CloseLeaderboardPopup();
        
        (Color32 color, float sizeMultiplier) GetPlayerTypeColorAndSize(PlayerType playerType);
        
        Task<Sprite> GetPlayerAvatar(string avatarUrl);
    }
}