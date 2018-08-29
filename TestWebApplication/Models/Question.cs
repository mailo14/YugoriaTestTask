using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWebApplication.Models
{
    /// <summary>
    /// Вопрос опросника
    /// </summary>
    public class Question
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public Test Test { get; set; }
        public QuestionType Type { get; set; }
        public int Num { get; set; }
        public string Text { get; set; }
        public ICollection<Variant> Variants { get; set; }
    }
   
}
namespace TestWebApplication
{
    
    public enum QuestionType : int
    {
        typeText = 0, // с вводом текста ответа в поле
        selectOne, // с выбором одного варианта ответа
        selectMany // с выбором нескольких вариантов 
    }
}