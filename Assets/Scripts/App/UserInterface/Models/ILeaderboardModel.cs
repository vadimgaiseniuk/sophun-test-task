using System.Threading.Tasks;
using Architecture.Core;
using UnityEngine;

namespace App.UserInterface
{
    public interface ILeaderboardModel
    {
        void CloseLeaderboardPopup();
        
        (Color32 color, float sizeMultiplier) GetPlayerTypeColorAndSize(PlayerType playerType);
        
        Task<Sprite> GetPlayerAvatar(string avatarUrl);
    }
}