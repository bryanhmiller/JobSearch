using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobSearch.Models
{
    public class Applications
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Stage Status { get; set; }
        public Interest Interest { get; set; }
        public virtual Company Company { get; set; }
    }

    public enum Stage
    {
        Contacted,
        Applied,
        Interviewed,
        Offer
    }

    public enum Interest
    {
        Low,
        Moderate,
        High
    }
}