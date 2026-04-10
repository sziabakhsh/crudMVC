using System.ComponentModel.DataAnnotations;

namespace CRUDOperationMVC.Entities
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;
        [StringLength (25)]
        public string Phone { get; set; } = string.Empty;
        [StringLength(200)]
        public string Address { get; set; } = string.Empty;

    }
}
