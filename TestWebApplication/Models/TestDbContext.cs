using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;

namespace TestWebApplication.Models
{
    /// <summary>
    /// Контекст для работы с базой данных TestDb
    /// </summary>
    public class TestDbContext: DbContext
    {
        public TestDbContext()
            : base("TestDbConnection") { }

        /// <summary>
        /// Таблица данных о опросниках
        /// </summary>
        public DbSet<Test> Tests { get; set; }

        /// <summary>
        /// Таблица данных о вопросах опросников
        /// </summary>
        public DbSet<Question> Questions { get; set; }
        
        /// <summary>
        /// Таблица данных о вариантах вопросов с выбором 
        /// </summary>
        public DbSet<Variant> Variants { get; set; } 

        /// <summary>
        /// Таблица данных о фактических прохождениях опросов пользователями
        /// </summary>
        public DbSet<FactTest> FactTests { get; set; } 

        /// <summary>
        /// Таблица данных c отмеченными вариантами в вопросах с выбором при фактическом прохождениии опросов 
        /// </summary>
        public DbSet<CheckAnswer> CheckAnswers { get; set; }

        /// <summary>
        /// Таблица данных с текстовыми ответами на вопросы при фактическом прохождениии опросов 
        /// </summary>
        public DbSet<TextAnswer> TextAnswers { get; set; }
    } 
}