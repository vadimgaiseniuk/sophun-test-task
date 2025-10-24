using System;
using Newtonsoft.Json;
using UnityEngine;

namespace Architecture.Core.Data
{
    [Serializable]
    public class PlayerLeaderboardEntryData
    {
        public string Name;
        public int Score;
        public string AvatarUrl;
        public Sprite Avatar;
        public PlayerType Type;
        public Color32 TypeColor;

        [JsonConstructor]
        public PlayerLeaderboardEntryData(string name, int score, string avatar, string type)
        {
            Name = name;
            Score = score;
            AvatarUrl = avatar;
            Avatar = null;
            Type = Enum.TryParse<PlayerType>(type, out PlayerType parsedType) ? parsedType : PlayerType.Default;
            TypeColor = Color.black;
        }
    }
}