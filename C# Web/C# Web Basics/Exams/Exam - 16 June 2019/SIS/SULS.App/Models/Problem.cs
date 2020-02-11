namespace SULS.App.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Problem
    {
        public Problem()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Submissions = new HashSet<Submission>();
        }

        public string Id { get; set; }

        [MaxLength(20), MinLength(5)]
        [Required]
        public string Name { get; set; }

        public int Points { get; set; }

        public ICollection<Submission> Submissions { get; set; }
    }
}
