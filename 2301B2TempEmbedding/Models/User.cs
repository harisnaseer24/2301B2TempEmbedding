using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _2301B2TempEmbedding.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$")]
    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}
