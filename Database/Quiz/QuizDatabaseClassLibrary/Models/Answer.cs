using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuizDatabaseClassLibrary.Models;

[Table("answers")]
[Index("QuestionId", Name = "QuestionId")]
public partial class Answer
{
    [Key]
    [Column(TypeName = "int(11)")]
    public int Id { get; set; }

    [Column(TypeName = "text")]
    public string AnswerText { get; set; } = null!;

    public bool IsCorrect { get; set; }

    [Column(TypeName = "int(11)")]
    public int QuestionId { get; set; }

    [ForeignKey("QuestionId")]
    [InverseProperty("Answers")]
    public virtual Question Question { get; set; } = null!;
}
