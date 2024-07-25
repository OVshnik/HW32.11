using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace MVCapp.Models.Db.Entity
{
    [Table("Requests")]
    public class Request
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Url { get; set; }
    }
}
