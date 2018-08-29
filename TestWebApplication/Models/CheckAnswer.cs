using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWebApplication.Models
{
    /// <summary>
    /// Выбранный вариант на вопрос с выбором
    /// </summary>
    public class CheckAnswer
    {
        public int Id { get; set; }
        public int FactTestId { get; set; }
        public FactTest FactTest { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public int VariantId { get; set; }
        public Variant Variant { get; set; }
    }
}