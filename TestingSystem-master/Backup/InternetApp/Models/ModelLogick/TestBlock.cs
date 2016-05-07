namespace InternetApp.Models.ModelLogick
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TestBlockSet")]
    public partial class TestBlock
    {
        public TestBlock()
        {
            Tests = new HashSet<Test>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Test> Tests { get; set; }
    }
}
