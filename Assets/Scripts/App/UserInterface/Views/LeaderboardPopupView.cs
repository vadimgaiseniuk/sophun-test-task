using System.Threading.Tasks;
using App.UserInterface.Models;
using App.UserInterface.Presenters;
using Architecture.Core.Data;
using Services.AssetManagingService;
using SimplePopupService;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterface
{
    public class LeaderboardPopupView : MonoBehaviour, IPopupInitialization<LeaderboardData, ILeaderboardModel>
    {
        [SerializeField] private RectTransform m_ContentContainer;
        [SerializeField] private Button m_CloseButton;

        private LeaderboardPopupPresenter m_Presenter;
        
        public async Task Initialize(LeaderboardData data, ILeaderboardModel model, IAssetManagingService assetManagingService)
        {
            m_Presenter = new LeaderboardPopupPresenter(model, assetManagingService, this);
            
            await m_Presenter.Construct(data, m_ContentContainer);
            Subscribe();
        }

        public void Dispose()
        {
            Unsubscribe();
        }

        private void Subscribe()
        {
            m_CloseButton.onClick.AddListener(m_Presenter.OnCloseButtonClicked);
        }

        private void Unsubscribe()
        {
            m_CloseButton.onClick.RemoveAllListeners();
        }
    }
}