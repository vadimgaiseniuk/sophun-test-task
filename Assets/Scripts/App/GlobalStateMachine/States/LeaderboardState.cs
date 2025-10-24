using System.Collections.Generic;
using System.Threading.Tasks;
using App.Constants;
using App.UserInterface;
using Architecture.Core;
using Services.AssetManagingService;
using Services.DataSerializationService;
using Services.FileHandlingService;
using Services.SimplePopupService;
using Services.WebRequestHandlingService;
using UnityEngine;

namespace App.GlobalStateMachine
{
    public class LeaderboardState : StateBase, ILeaderboardModel
    {
        private readonly GlobalStateMachine m_GlobalStateMachine;
        private readonly IFileHandlingService m_FileHandlingService;
        private readonly IDataSerializationService m_DataSerializationService;
        private readonly IWebRequestHandlingService m_WebRequestHandlingService;
        private readonly IPopupManagingService m_PopupManagingService;

        private Dictionary<string, Sprite> m_CachedAvatars;

        public LeaderboardState(GlobalStateMachine globalStateMachine, IFileHandlingService fileHandlingService, IDataSerializationService dataSerializationService, IWebRequestHandlingService webRequestHandlingService, IAssetManagingService assetManagingService, IPopupManagingService popupManagingService)
        {
            m_GlobalStateMachine = globalStateMachine;
            m_FileHandlingService = fileHandlingService;
            m_DataSerializationService = dataSerializationService;
            m_WebRequestHandlingService = webRequestHandlingService;
            AssetManagingService = assetManagingService;
            m_PopupManagingService = popupManagingService;
        }
        
        public IAssetManagingService AssetManagingService { get; }
        
        public override void Enter()
        {
            Subscribe();
        }

        public override void Exit()
        {
            m_PopupManagingService.ClosePopup(AssetPath.PopupViewPath);
            Dispose();
        }

        private void Subscribe()
        {
            Application.quitting += LoadQuitState;
            m_GlobalStateMachine.Context.UIRootView.LeaderboardButton.onClick.AddListener(DisplayLeaderboardPopup);
        }

        private void Unsubscribe()
        {
            Application.quitting -= LoadQuitState;
            m_GlobalStateMachine.Context.UIRootView.LeaderboardButton.onClick.RemoveAllListeners();
        }

        private void Dispose()
        {
            Unsubscribe();
            m_CachedAvatars = null;
        }

        public void CloseLeaderboardPopup()
        {
            m_PopupManagingService.ClosePopup(AssetPath.PopupViewPath);
        }

        public async Task<Sprite> GetPlayerAvatar(string avatarUrl)
        {
            if (m_CachedAvatars.TryGetValue(avatarUrl, out Sprite playerAvatar))
                return playerAvatar;

            Sprite avatar = await m_WebRequestHandlingService.GetImageAsync(avatarUrl);
            
            m_CachedAvatars[avatarUrl] = avatar;

            return avatar;
        }
        
        public (Color32 color, float sizeMultiplier) GetPlayerTypeColorAndSize(PlayerType playerType)
        {
            Color32 playerColor = playerType switch
            {
                PlayerType.Bronze => DataPath.BronzePlayerColor,
                PlayerType.Silver => DataPath.SilverPlayerColor,
                PlayerType.Gold => DataPath.GoldPlayerColor,
                PlayerType.Diamond => DataPath.DiamondPlayerColor,
                _ => DataPath.DefaultPlayerColor
            };

            float sizeMultiplier = playerType switch
            {
                PlayerType.Bronze => DataPath.BronzePlayerSize,
                PlayerType.Silver => DataPath.SilverPlayerSize,
                PlayerType.Gold => DataPath.GoldPlayerSize,
                PlayerType.Diamond => DataPath.DiamondPlayerSize,
                _ => DataPath.DefaultPlayerSize
            };
            
            return (playerColor, sizeMultiplier);
        }
        
        private async void DisplayLeaderboardPopup()
        {
            string leaderboardFileContent = await m_FileHandlingService.ReadFileFromResourcesAsync(DataPath.LeaderboardFileName);
            LeaderboardData leaderboardData = await m_DataSerializationService.DeserializeAsync<LeaderboardData>(leaderboardFileContent);
            m_CachedAvatars ??= new Dictionary<string, Sprite>(leaderboardData.Leaderboard.Count);
            
            m_PopupManagingService.OpenPopup<LeaderboardData, ILeaderboardModel>(AssetPath.PopupViewPath, leaderboardData, this, m_GlobalStateMachine.Context.UIRootView.ContentContainer);
        }

        private void LoadQuitState()
        {
            m_GlobalStateMachine.ChangeState<QuitState>();
        }
    }
}