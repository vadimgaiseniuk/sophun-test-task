using System;
using System.Collections.Generic;

namespace Architecture.Core.Data
{
    [Serializable]
    public class LeaderboardData
    {
        public List<PlayerLeaderboardEntryData> Leaderboard;
    }
}