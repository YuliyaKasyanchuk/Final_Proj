using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace InternetApp.Models.ModelLogick
{
    [Table("TestSet")]
    public partial class Test
    {
        public  Test() 
        {
            mQuestions = new HashSet<Question>();
        }
        private ICollection<Question> mRightAnswers = null;

        [Key]
        public int Id { get; set; }

        public int TestBlock_Id { get; set; }

        private DateTime mBeginDate;
        private DateTime mEndDate;

        [Required]
        public DateTime BeginDate
        {
            get { return mBeginDate; }
            set { mBeginDate = value; }
        }
        [Required]
        public DateTime EndDate
        {
            get { return mEndDate; }
            set { mEndDate = value; }
        }

        private bool mIsPublic;
        [Required]
        public bool IsPublic
        {
            get { return mIsPublic; }
            set { mIsPublic = value; }
        }

        private string mName;
        [Required]
        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }

        private ICollection<Question> mQuestions;
        public ICollection<Question> Questions
        {
            get { return mQuestions; }
            set { mQuestions = value; }
        }

        public virtual TestBlock TestBlock { get; set; }
    }
}