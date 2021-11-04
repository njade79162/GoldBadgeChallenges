using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3_ClassLibrary
{
    public class BadgeRepository
    {
        private readonly Dictionary<int, List<String>> _badgeDirectory = new Dictionary<int, List<String>>();

        public bool AddBadge(Badge badge)
        {
            int startingCount = _badgeDirectory.Count;
            _badgeDirectory.Add(badge.BadgeID, badge.DoorNames);
            return _badgeDirectory.Count > startingCount;
        }

        public Badge GetBadge(int badgeID)
        {
            bool isValidID = _badgeDirectory.TryGetValue(badgeID, out List<string> doorList);
            if (!isValidID)
            {
                return null;
            }
            else
            {
                Badge badge = new Badge(badgeID, doorList);
                return badge;
            }
        }

        public Dictionary<int, List<String>> GetBadgeDirectory()
        {
            return _badgeDirectory;
        }

        public bool UpdateBadge(int oldID, Badge newBadge)
        {
            bool isValidID = _badgeDirectory.TryGetValue(oldID, out List<string> doorList);
            if (!isValidID)
            {
                return false;
            }
            else
            {
                _badgeDirectory.Remove(oldID);
                _badgeDirectory.Add(newBadge.BadgeID, newBadge.DoorNames);
                return true;
            }
        }

        public bool RemoveBadge(Badge badge)
        {
            return _badgeDirectory.Remove(badge.BadgeID);
        }
    }
}
