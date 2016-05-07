using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace InternetApp.Models.ModelLogick
{
    [Table("AnswerSet")]
    public partial class Answer
    {
        [Key]
        public int Id { get; set; }
        public int Question_Id { get; set; }

        private bool mIsRight;
        private string mText;

        [Required]
        public bool IsRight
        {
            get { return mIsRight; }
            set { mIsRight = value; }
        }
        [Required]
        public string Text
        {
            get { return mText; }
            set { mText = value; }
        }

        public virtual Question Question { get; set; }
    }
}