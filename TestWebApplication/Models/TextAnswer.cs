using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWebApplication.Models
{
    /// <summary>
    /// Текстовый ответ на вопрос опросника
    /// </summary>
    public class TextAnswer
    {
        public int Id { get; set; }
        public int FactTestId { get; set; }
        public FactTest FactTest { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public string Text { get; set; }
    }
}