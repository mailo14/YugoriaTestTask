using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWebApplication.Models
{
    /// <summary>
    /// Фактически пройденный опрос
    /// </summary>
    public class FactTest
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public virtual Test Test { get; set; }
        public string UserIP{ get; set; } 
        public virtual ICollection<CheckAnswer> CheckAnswers { get; set; }
        public virtual ICollection<TextAnswer> TextAnswers { get; set; }
    }
}