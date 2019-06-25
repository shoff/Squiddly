namespace Squiddly.Data.Data
{
    using System.ComponentModel.DataAnnotations;

    public class GitCredential
    {
        [Key]
        public int GitCredentialId { get; set; }
        public string GitUserName { get; set; }
        // TODO Must encrypt
        public string GitPassword { get; set; }
    }
}