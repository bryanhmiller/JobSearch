using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobSearch.Models
{
    public class ToDos
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string Action { get; set; }
        public string Note { get; set; }
        public Status Status { get; set; }
        public DateTime Due { get; set; }
    }

    public enum Status
    {
        Doing,
        Done,
        Impedes
    }
}