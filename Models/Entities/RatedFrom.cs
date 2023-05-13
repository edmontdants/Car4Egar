using System.ComponentModel.DataAnnotations;

namespace Car4EgarAPI.Models.Entities
{
    public class RatedFrom
    {
        [Key]
        public string CarVIN { get; set; }
        public string BorroweNID { get; set; }
        public bool RatedOrNot { get; set; }
    }
}
