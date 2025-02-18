using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PeopleDatabaseClassLibrary.Models;

[Table("adreses")]
public partial class Adrese
{
    [Key]
    [Column(TypeName = "int(11)")]
    public int Id { get; set; }

    [StringLength(100)]
    public string Street { get; set; } = null!;

    [StringLength(20)]
    public string HouseNumber { get; set; } = null!;

    [StringLength(80)]
    public string Country { get; set; } = null!;

    [InverseProperty("Adress")]
    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
