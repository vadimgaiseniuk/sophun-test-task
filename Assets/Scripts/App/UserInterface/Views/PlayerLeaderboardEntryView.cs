using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterface
{
    public class PlayerLeaderboardEntryView : MonoBehaviour
    {
        [SerializeField] private Image m_AvatarImage;
        [SerializeField] private TextMeshProUGUI m_AvatarLoadingText;
        [SerializeField] private TextMeshProUGUI m_NameText;
        [SerializeField] private TextMeshProUGUI m_ScoreText;
        [SerializeField] private Image m_TypeImage;

        public void Construct(Sprite playerAvatar, string playerName, string playerScore, Color32 playerTypeColor, float playerTypeImageSizeMultiplayer)
        {
            if (playerAvatar == null) 
                m_AvatarLoadingText.gameObject.SetActive(true);
            
            m_AvatarImage.sprite = playerAvatar;
            m_NameText.text = playerName;
            m_ScoreText.text = playerScore;
            m_TypeImage.color = playerTypeColor;
            
            m_TypeImage.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, m_TypeImage.rectTransform.rect.width * playerTypeImageSizeMultiplayer);
            m_TypeImage.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, m_TypeImage.rectTransform.rect.height * playerTypeImageSizeMultiplayer);
        }

        public void SetAvatar(Sprite playerAvatar)
        {
            m_AvatarImage.sprite = playerAvatar;
            
            m_AvatarLoadingText.gameObject.SetActive(false);
        }
    }
}