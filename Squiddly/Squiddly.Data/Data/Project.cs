namespace Squiddly.Data.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        [StringLength(40)]
        public string Name { get; set; }
        [StringLength(256)]
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public string GitRepository { get; set; }
        [ForeignKey("Credentials")]
        public int GitCredentialsId { get; set; }
        public virtual GitCredential Credentials { get; set; }
        public virtual ICollection<Branch> Branches { get; set; } = new HashSet<Branch>();
    }

}