namespace Squiddly.Data.Data
{
    using System.ComponentModel.DataAnnotations;

    public class Branch
    {
        [Key]
        public int BranchId { get; set; }
        public string Name { get; set; }

    }
}