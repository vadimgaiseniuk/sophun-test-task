using UnityEngine;
using UnityEngine.UI;

namespace UserInterface
{
    public class UIRootView : MonoBehaviour
    {
        [field: SerializeField] public RectTransform ContentContainer { get; private set; }
        [field: SerializeField] public Button LeaderboardButton { get; private set; }
    }
}