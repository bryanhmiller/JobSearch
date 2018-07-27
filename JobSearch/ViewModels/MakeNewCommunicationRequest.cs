using System;
using System.ComponentModel.DataAnnotations;
namespace JobSearch.ViewModels
{
    public class MakeNewCommunicationRequest
    {
        [Required]
        public DateTime When { get; set; }
        public string Contact { get; set; }
        public Direction Direction { get; set; }
        public Method Method { get; set; }
        public string Details { get; set; }
        public int CompanyId{ get; set; }
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
