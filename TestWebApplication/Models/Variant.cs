using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWebApplication.Models
{
    /// <summary>
    /// Вариант ответа на вопрос с выбором
    /// </summary>
    public class Variant
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public int Num { get; set; } = 0;
        public string Text { get; set; }
    }
}