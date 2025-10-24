using System.Threading.Tasks;
using Architecture.Core.Data;
using UnityEngine;

namespace App.UserInterface.Models
{
    public interface ILeaderboardModel
    {
        void CloseLeaderboardPopup();
        
        (Color32 color, float sizeMultiplier) GetPlayerTypeColorAndSize(PlayerType playerType);
        
        Task<Sprite> GetPlayerAvatar(string avatarUrl);
    }
}