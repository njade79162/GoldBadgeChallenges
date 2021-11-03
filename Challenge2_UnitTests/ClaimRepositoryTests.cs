using Challenge2_ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Challenge2_UnitTests
{
    [TestClass]
    public class ClaimRepositoryTests
    {
        [TestMethod]
        public void Test_AddClaim()
        {
            ClaimRepository claimRepo = new ClaimRepository();
            Claim claim = new Claim();

            bool added = claimRepo.AddClaim(claim);

            Assert.IsTrue(added);
        }

        [TestMethod]
        public void Test_GetClaim()
        {
            ClaimRepository claimRepo = new ClaimRepository();
            Claim expected = new Claim(1, "Description", ClaimType.Car, 20.00, new DateTime(2020, 7, 3), new DateTime(2020, 7, 5));
            claimRepo.AddClaim(expected);

            Claim actual = claimRepo.GetClaim(1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_GetNextClaim()
        {
            ClaimRepository claimRepo = new ClaimRepository();
            Claim expected = new Claim(1, "Description", ClaimType.Car, 20.00, new DateTime(2020, 7, 3), new DateTime(2020, 7, 5));
            claimRepo.AddClaim(expected);

            Claim actual = claimRepo.GetNextClaim();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_GetClaimDirectory()
        {
            ClaimRepository claimRepo = new ClaimRepository();
            Claim claim = new Claim(1, "Description", ClaimType.Car, 20.00, new DateTime(2020, 7, 3), new DateTime(2020, 7, 5));
            claimRepo.AddClaim(claim);
            Queue<Claim> expected = new Queue<Claim>();
            expected.Enqueue(claim);
            Queue<Claim> actual = claimRepo.GetClaimDirectory();

            bool areEqual = false;
            foreach(Claim expectedClaim in expected)
            {
                if (expectedClaim != actual.Dequeue())
                {
                    areEqual = false;
                    break;
                }

                areEqual = true;
            }

            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void Test_DequeueClaim()
        {
            ClaimRepository claimRepo = new ClaimRepository();
            Claim expected = new Claim(1, "Description", ClaimType.Car, 20.00, new DateTime(2020, 7, 3), new DateTime(2020, 7, 5));
            claimRepo.AddClaim(expected);

            Claim actual = claimRepo.DequeueClaim();

            Assert.AreEqual(expected, actual);
        }
    }
}
