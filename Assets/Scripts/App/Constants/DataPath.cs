using UnityEngine;

namespace App.Constants
{
    public static class DataPath
    {
        public const string LeaderboardFileName = "Leaderboard";
        
        public static readonly Color32 DiamondPlayerColor = new Color32(185, 242, 255, 255);
        public static readonly Color32 GoldPlayerColor = new Color32(255, 215, 0, 255);
        public static readonly Color32 SilverPlayerColor = new Color32(192, 192, 192, 255);
        public static readonly Color32 BronzePlayerColor = new Color32(205, 127, 50, 255);
        public static readonly Color32 DefaultPlayerColor = new Color32(255, 255, 255, 255);

        public const float DiamondPlayerSize = 1.25f;
        public const float GoldPlayerSize = 1.2f;
        public const float SilverPlayerSize = 1.15f;
        public const float BronzePlayerSize = 1.0f;
        public const float DefaultPlayerSize = 0.8f;
    }
}