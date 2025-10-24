using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace App.UserInterface
{
    public class PlayerLeaderboardEntryView : MonoBehaviour
    {
        [SerializeField] private Image m_BackgroundImage;
        [SerializeField] private LayoutElement m_LayoutElement;
        [SerializeField] private Image m_AvatarImage;
        [SerializeField] private TextMeshProUGUI m_AvatarLoadingText;
        [SerializeField] private TextMeshProUGUI m_NameText;
        [SerializeField] private TextMeshProUGUI m_ScoreText;

        public void Construct(Sprite playerAvatar, string playerName, string playerScore, Color32 playerTypeColor, float playerTypeImageSizeMultiplayer)
        {
            if (playerAvatar == null) 
                m_AvatarLoadingText.gameObject.SetActive(true);
            
            m_AvatarImage.sprite = playerAvatar;
            m_NameText.text = playerName;
            m_ScoreText.text = playerScore;
            m_BackgroundImage.color = playerTypeColor;
            
            m_LayoutElement.preferredHeight *= playerTypeImageSizeMultiplayer;
        }

        public void SetAvatar(Sprite playerAvatar)
        {
            m_AvatarImage.sprite = playerAvatar;
            
            m_AvatarLoadingText.gameObject.SetActive(false);
        }
    }
}