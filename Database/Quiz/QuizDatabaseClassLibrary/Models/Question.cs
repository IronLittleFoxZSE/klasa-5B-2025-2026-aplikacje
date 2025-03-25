using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuizDatabaseClassLibrary.Models;

[Table("question")]
public partial class Question
{
    [Key]
    [Column(TypeName = "int(11)")]
    public int Id { get; set; }

    [Column(TypeName = "text")]
    public string QuestionText { get; set; } = null!;

    [Column(TypeName = "int(11)")]
    public int QuestionType { get; set; }

    [InverseProperty("Question")]
    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();
}
