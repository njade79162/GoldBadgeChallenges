using Challenge3_ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Challenge3_UnitTests
{
    [TestClass]
    public class BadgeRepositoryTests
    {
        [TestMethod]
        public void Test_AddBadge()
        {
            BadgeRepository badgeRepo = new BadgeRepository();
            Badge badge = new Badge(12345, new List<string>());

            bool added = badgeRepo.AddBadge(badge);

            Assert.IsTrue(added);
        }

        [TestMethod]
        public void Test_GetBadge()
        {
            BadgeRepository badgeRepo = new BadgeRepository();
            List<string> doorList = new List<string>();
            doorList.Add("A7");
            Badge expected = new Badge(12345, doorList);
            badgeRepo.AddBadge(expected);

            Badge actual = badgeRepo.GetBadge(12345);
            bool areEqual = true;
            if(expected.BadgeID != actual.BadgeID)
            {
                areEqual = false;
            }
            else if(expected.DoorNames.Count != actual.DoorNames.Count)
            {
                areEqual = false;
            }
            else
            {
                for(int i = 0; i < expected.DoorNames.Count; i++)
                {
                    if(expected.DoorNames[i] != actual.DoorNames[i])
                    {
                        areEqual = false;
                        break;
                    }
                }
            }

            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void Test_GetBadgeDirectory()
        {
            BadgeRepository badgeRepo = new BadgeRepository();
            List<string> doorList = new List<string>();
            doorList.Add("A7");
            Badge badge = new Badge(12345, doorList);
            badgeRepo.AddBadge(badge);
            Dictionary<int, List<string>> expected = new Dictionary<int, List<string>>();
            expected.Add(12345, doorList);

            Dictionary<int, List<string>> actual = badgeRepo.GetBadgeDirectory();
            bool areEqual = false;
            foreach(KeyValuePair<int, List<string>> expectedBadge in expected)
            {
                bool exists = actual.TryGetValue(expectedBadge.Key, out List<string> actualDoorList);
                if (!exists)
                {
                    areEqual = false;
                    break;
                }
                else if(expectedBadge.Value.Count != actualDoorList.Count)
                {
                    areEqual = false;
                    break;
                }
                else
                {
                    for(int i = 0; i < expectedBadge.Value.Count; i++)
                    {
                        if(expectedBadge.Value[i] != actualDoorList[i])
                        {
                            areEqual = false;
                            break;
                        }
                    }
                }

                areEqual = true;
            }

            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void Test_UpdateBadge()
        {
            BadgeRepository badgeRepo = new BadgeRepository();
            List<string> doorList = new List<string>();
            doorList.Add("A7");
            Badge badge = new Badge(12345, doorList);
            badgeRepo.AddBadge(badge);
            List<string> newDoorList = new List<string>();
            doorList.Add("A8");
            Badge newBadge = new Badge(12345, newDoorList);

            bool updated = badgeRepo.UpdateBadge(12345, newBadge);

            Assert.IsTrue(updated);
        }

        [TestMethod]
        public void Test_RemoveBadge()
        {
            BadgeRepository badgeRepo = new BadgeRepository();
            List<string> doorList = new List<string>();
            doorList.Add("A7");
            Badge badge = new Badge(12345, doorList);
            badgeRepo.AddBadge(badge);

            bool isRemoved = badgeRepo.RemoveBadge(badge);

            Assert.IsTrue(isRemoved);
        }
    }
}
