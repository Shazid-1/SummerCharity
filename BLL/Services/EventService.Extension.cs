using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public partial class EventService
    {
        static bool IsOngoing(Event x)
        {
            return x.StartAt < DateTime.Now
                    && x.EndAt > DateTime.Now
                    && x.StartAt != null
                    && !x.StartAt.Equals(DateTime.MinValue);
        }
        static bool IsUpcoming(Event x)
        {
            return x.StartAt > DateTime.Now
                    && x.EndAt != null
                    && !x.EndAt.Equals(DateTime.MinValue);
        }
        static bool IsCanceled(Event x)
        {
            return x.EndAt == null
                    || x.EndAt.Equals(DateTime.MinValue);
        }
        static bool IsFinished(Event x)
        {
            return x.EndAt < DateTime.Now
                    && x.EndAt != null
                    && !x.EndAt.Equals(DateTime.MinValue);
        }
        static IEnumerable<Event> GetByState(IEnumerable<Event> events, string state)
        {
            if (state.Equals("CANCELED"))
            {
                return events.Where(x => IsCanceled(x));
            }
            else if (state.Equals("FINISHED"))
            {
                return events.Where(x => IsFinished(x));
            }
            else if (state.Equals("UPCOMING"))
            {
                return events.Where(x => IsUpcoming(x));
            }
            else if (state.Equals("ONGOING"))
            {
                return events.Where(x => IsOngoing(x));
            } else return events;
        }
    }
}
