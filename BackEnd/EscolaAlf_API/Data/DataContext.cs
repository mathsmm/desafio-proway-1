using System;
using System.Collections.Generic;
using EscolaAlf_API.Models;
using Microsoft.EntityFrameworkCore;

namespace EscolaAlf_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
        public DbSet<Option> Option { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<StudentReply> StudentReply { get; set; }
        public DbSet<StudentSituation> StudentSituation { get; set; }
        public DbSet<StudentGrade> StudentGrade { get; set; }
        public DbSet<Template> Template { get; set; }
        public DbSet<Test> Test { get; set; }
        public DbSet<TestQuestion> TestQuestion { get; set; }

         protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Student>()
                .HasData(new List<Student>() {
                    new Student(1, "Matheus", DateTime.Parse("21/4/2003")),
                    new Student(2, "Cristina", DateTime.Parse("4/8/2003")),
                    new Student(3, "Diego", DateTime.Parse("5/1/2004")),
                    new Student(4, "Ronaldo", DateTime.Parse("9/7/2003")),
                    new Student(5, "Emilly", DateTime.Parse("5/1/2002"))
                });

            builder.Entity<Test>()
                .HasData(new List<Test>() {
                    new Test(1, DateTime.Parse("4/3/2020")),
                    new Test(2, DateTime.Parse("7/5/2020")),
                    new Test(3, DateTime.Parse("12/8/2020"))
                });

            builder.Entity<Question>()
                .HasData(new List<Question>() {
                    new Question(1, "Quem descobriu o Brasil?"),
                    new Question(2, "O que são células adiposas?"),
                    new Question(3, "Qual a fórmula da água?"),
                    new Question(4, "O que é 'C#'?"),
                    new Question(5, "O que a vaca bebe?")
                });

            builder.Entity<Option>()
                .HasData(new List<Option>() {
                    new Option(1, 1, 1, "Pedro Álvares Cabral"),
                    new Option(2, 2, 1, "Napoleão Bernardes"),
                    new Option(3, 3, 1, "Elizabeth I"),
                    new Option(4, 4, 1, "Michael Jackson"),
                    new Option(5, 1, 2, "Células da pele"),
                    new Option(6, 2, 2, "Células dos ossos"),
                    new Option(7, 3, 2, "Células de gordura"),
                    new Option(8, 4, 2, "Células de defesa"),
                    new Option(9, 1, 3, "H202"),
                    new Option(10, 2, 3, "CH4"),
                    new Option(11, 3, 3, "N2"),
                    new Option(12, 4, 3, "H2O"),
                    new Option(13, 1, 4, "Uma ferramenta"),
                    new Option(14, 2, 4, "Uma linguagem de programção"),
                    new Option(15, 3, 4, "Uma marca de carro"),
                    new Option(16, 4, 4, "Uma empresa de tecnologia"),
                    new Option(17, 1, 5, "Leite"),
                    new Option(18, 2, 5, "Suco"),
                    new Option(19, 3, 5, "Chimarrão"),
                    new Option(20, 4, 5, "Água")
                });

            builder.Entity<TestQuestion>()
                .HasData(new List<TestQuestion>() {
                    new TestQuestion(1, 1, 1, 1, 5),
                    new TestQuestion(2, 1, 3, 2, 10),
                    new TestQuestion(3, 2, 2, 1, 2),
                    new TestQuestion(4, 2, 4, 2, 3),
                    new TestQuestion(5, 3, 3, 1, 20),
                    new TestQuestion(6, 3, 5, 2, 30)
                });

            builder.Entity<Template>()
                .HasData(new List<Template>() {
                    new Template(1, 1, 1),
                    new Template(2, 2, 12)
                });

            builder.Entity<StudentReply>()
                .HasData(new List<StudentReply>() {
                    new StudentReply(1, 1, 1, 1),
                    new StudentReply(2, 1, 2, 11)
                });
        }
    }
}
