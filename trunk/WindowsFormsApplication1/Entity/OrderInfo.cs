using System;
using System.Collections.Generic;
using System.Text;

namespace DeGuangTicketsHelper.Entity
{
    public class OrderInfo
    {
        public string Token { get; set; }
        public string TrainDate{get;set;}
        public TicketInfo TicketInfo{get;set;}
        List<Passenger> passengers;
        public List<Passenger> Passengers
        {
            get
            {
                if (passengers == null)
                {
                    passengers = new List<Passenger>();
                }
                return passengers;
            }
            set
            {
                passengers = value;
            }
        }
    }
}
