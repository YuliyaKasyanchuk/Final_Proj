//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InternetApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Question
    {
        public Question()
        {
            this.Answer = new HashSet<Answer>();
        }
    
        public int Id { get; set; }
        public bool IsCheckedBuComputer { get; set; }
        public string Text { get; set; }
    
        public virtual Test Test { get; set; }
        public virtual ICollection<Answer> Answer { get; set; }
    }
}
