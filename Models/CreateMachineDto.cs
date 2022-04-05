using System.ComponentModel.DataAnnotations;


namespace A17MMS.Models
{
    public class CreateMachineDto
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
        public Status Status { get; set; }
    }
}
