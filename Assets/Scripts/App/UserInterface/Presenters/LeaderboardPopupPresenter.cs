using System.Collections.Generic;
using System.Threading.Tasks;
using App.UserInterface.Models;
using Architecture.Core.Data;
using Services.AssetManagingService;
using UnityEngine;
using UserInterface;

namespace App.UserInterface.Presenters
{
    public class LeaderboardPopupPresenter
    {
        private readonly ILeaderboardModel m_Model;
        private readonly IAssetManagingService m_AssetManagingService;
        private readonly LeaderboardPopupView m_View;
        
        private List<PlayerLeaderboardEntryView> m_PlayerLeaderboardEntryViews;

        public LeaderboardPopupPresenter(ILeaderboardModel model, IAssetManagingService assetManagingService, LeaderboardPopupView view)
        {
            m_Model = model;
            m_AssetManagingService = assetManagingService;
            m_View = view;
        }

        public async Task Construct(LeaderboardData data, RectTransform contentContainer)
        {
            m_PlayerLeaderboardEntryViews = new List<PlayerLeaderboardEntryView>(data.Leaderboard.Count);
            
            foreach (PlayerLeaderboardEntryData playerLeaderboardEntryData in data.Leaderboard)
            {
                PlayerLeaderboardEntryView playerLeaderboardEntryView = await m_AssetManagingService.InstantiateAssetAsync<PlayerLeaderboardEntryView>(AssetPath.PlayerEntryViewPath, contentContainer);
                
                (Color32 playerColor, float playerSizeMultiplier) = m_Model.GetPlayerTypeColorAndSize(playerLeaderboardEntryData.Type);
                playerLeaderboardEntryView.Construct(playerLeaderboardEntryData.Avatar, playerLeaderboardEntryData.Name, playerLeaderboardEntryData.Score.ToString(), playerColor, playerSizeMultiplier);
                
                m_PlayerLeaderboardEntryViews.Add(playerLeaderboardEntryView);
            }

            // to demonstrate the avatar loading
            for (var i = 0; i < m_PlayerLeaderboardEntryViews.Count; i++)
            {
                PlayerLeaderboardEntryData playerLeaderboardEntryData = data.Leaderboard[i];
                
                PlayerLeaderboardEntryView playerLeaderboardEntryView = m_PlayerLeaderboardEntryViews[i];
                playerLeaderboardEntryView.SetAvatar(await m_Model.GetPlayerAvatar(playerLeaderboardEntryData.AvatarUrl));
            }
        }

        public void OnCloseButtonClicked()
        {
            m_View.Dispose();
            m_Model.CloseLeaderboardPopup();
        }
    }
}