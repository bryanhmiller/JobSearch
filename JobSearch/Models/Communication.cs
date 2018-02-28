using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobSearch.Models
{
    public class Communication
    {
        public int Id { get; set; }
        public DateTime When { get; set; }
        public virtual Company Company { get; set; }
        public string Contact { get; set; }
        public Direction Direction { get; set; }
        public Method Method { get; set; }
        public string Details { get; set; }
    }

    public enum Direction
    {
        Incoming,
        Outgoing
    }

    public enum Method
    {
        Email,
        Phone,
        Text,
        Personal,
        Other
    }
}