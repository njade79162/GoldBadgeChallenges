using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2_ClassLibrary
{
    public class ClaimRepository
    {
        private readonly Queue<Claim> _claimDirectory = new Queue<Claim>();

        public bool AddClaim(Claim claim)
        {
            int startingCount = _claimDirectory.Count;
            _claimDirectory.Enqueue(claim);
            return _claimDirectory.Count > startingCount;
        }

        public Claim GetClaim(int claimID)
        {
            foreach(Claim claim in _claimDirectory)
            {
                if(claim.ClaimID == claimID)
                {
                    return claim;
                }
            }
            return null;
        }

        public Claim GetNextClaim()
        {
            if (_claimDirectory.Count > 0)
            {
                return _claimDirectory.Peek();
            }
            else
            {
                Console.WriteLine("The queue is empty. \n" +
                    "Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                return null;
            }
        }

        public Queue<Claim> GetClaimDirectory()
        {
            return _claimDirectory;
        }

        public Claim DequeueClaim()
        {
            return _claimDirectory.Dequeue();
        }
    }
}
