using System;
using System.Collections.Generic;
using System.Text;

namespace Tour_TUI_Operator.Interfaces
{
   public interface ITuiDataContext
    {
        Dictionary<int, Airline> Airlines { get; }

        Dictionary<int, City> Cities { get; }

        Dictionary<int, Country> Countries { get; }

        Dictionary<int, Hotel> Hotels { get; }

        Dictionary<int, Provider> Providers { get; }

        Dictionary<int, RoomType> RoomTypes { get; }

        Dictionary<int, Tour> Tours { get; }

        Task InitializeDataContext(int cityCount, int hotelCount, int tourCount, int airlineCount);
    }
}
