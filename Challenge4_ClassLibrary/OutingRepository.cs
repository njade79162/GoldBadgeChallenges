using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge4_ClassLibrary
{
    public class OutingRepository
    {
        private readonly List<Outing> _outingDirectory = new List<Outing>();

        public bool AddOuting(Outing outing)
        {
            int startingCount = _outingDirectory.Count;
            _outingDirectory.Add(outing);
            return _outingDirectory.Count > startingCount;
        }

        public List<Outing> GetOutingDirectory()
        {
            return _outingDirectory;
        }

        public List<Outing> GetOutingsByType(EventType eventType)
        {
            List<Outing> returnList = new List<Outing>();
            foreach(Outing outing in _outingDirectory)
            {
                if(outing.TypeOfEvent == eventType)
                {
                    returnList.Add(outing);
                }
            }

            return returnList;
        }
    }
}
