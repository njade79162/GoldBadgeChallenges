using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2_ClassLibrary
{
    public enum ClaimType
    {
        Car = 1,
        Home,
        Theft
    }

    public class Claim
    {
        public int ClaimID { get; set; }
        public string Description { get; set; }
        public ClaimType ClaimType { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                if ((DateOfClaim - DateOfIncident).Days <= 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Claim()
        {

        }

        public Claim(int claimID, string description, ClaimType type, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = claimID;
            Description = description;
            ClaimType = type;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }
    }
}
