using Challenge4_ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Challenge4_UnitTests
{
    [TestClass]
    public class OutingRepositoryTests
    {
        [TestMethod]
        public void Test_AddOuting()
        {
            OutingRepository outingRepo = new OutingRepository();
            Outing outing = new Outing();

            bool added = outingRepo.AddOuting(outing);

            Assert.IsTrue(added);
        }

        [TestMethod]
        public void Test_GetOutingDirectory()
        {
            OutingRepository outingRepo = new OutingRepository();
            Outing outing = new Outing();
            List<Outing> expected = new List<Outing>();
            expected.Add(outing);
            outingRepo.AddOuting(outing);
            List<Outing> actual = outingRepo.GetOutingDirectory();

            bool areEqual = true;
            if(expected.Count != actual.Count)
            {
                areEqual = false;
            }
            else
            {
                for(int i = 0; i < expected.Count; i++)
                {
                    if(expected[i] != actual[i])
                    {
                        areEqual = false;
                    }
                }
            }

            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void Test_GetOutingsByType()
        {
            OutingRepository outingRepo = new OutingRepository();
            Outing outing1 = new Outing();
            Outing outing2 = new Outing();
            Outing outing3 = new Outing();
            outing1.TypeOfEvent = EventType.Golf;
            outing2.TypeOfEvent = EventType.Golf;
            outing3.TypeOfEvent = EventType.Bowling;
            outingRepo.AddOuting(outing1);
            outingRepo.AddOuting(outing2);
            outingRepo.AddOuting(outing3);
            List<Outing> expected = new List<Outing>();
            expected.Add(outing1);
            expected.Add(outing2);
            List<Outing> actual = outingRepo.GetOutingsByType(EventType.Golf);

            bool areEqual = true;
            if (expected.Count != actual.Count)
            {
                areEqual = false;
            }
            else
            {
                for (int i = 0; i < expected.Count; i++)
                {
                    if (expected[i] != actual[i])
                    {
                        areEqual = false;
                    }
                }
            }

            Assert.IsTrue(areEqual);
        }
    }
}
