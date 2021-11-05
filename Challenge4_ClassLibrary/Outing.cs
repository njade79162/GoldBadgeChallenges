using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge4_ClassLibrary
{
    public enum EventType
    {
        Golf = 1,
        Bowling,
        AmusementPark,
        Concert
    }
    
    public class Outing
    {
        public EventType TypeOfEvent { get; set; }
        public int NumAttended { get; set; }
        public DateTime Date { get; set; }
        public double CostPerPerson { get; set; }
        public double TotalCost
        {
            get
            {
                return CostPerPerson * NumAttended;
            }
        }

        public Outing()
        {

        }

        public Outing(EventType eventType, int numAttended, DateTime dateOfEvent, double costPerPerson)
        {
            TypeOfEvent = eventType;
            NumAttended = numAttended;
            Date = dateOfEvent;
            CostPerPerson = costPerPerson;
        }
    }
}
