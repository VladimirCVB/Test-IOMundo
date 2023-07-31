using System.ComponentModel.DataAnnotations;

namespace Test_IOMundo.ViewModels
{
    public class RequestObject
    {
        [Display(Name = "Check-In Date")]
        [Required(ErrorMessage = "Date is required")]
        public DateTime DateForm { get; set; }

        [Display(Name = "Duration")]
        [Required(ErrorMessage = "Duration is required")]
        public int Duration { get; set; }

        [Display(Name = "Person Count")]
        [Required(ErrorMessage = "Person Count is required")]
        public string PeopleCount { get; set; }
    }
}
