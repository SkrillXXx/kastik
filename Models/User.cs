using System;
using System.Collections.Generic;

namespace KAsT_aPi.Models;

public partial class User
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Email { get; set; } = null!;

    public virtual ICollection<GameOfCart>? GameOfCarts { get; set; } = new List<GameOfCart>();

    public virtual ICollection<Library>? Libraries { get; set; } = new List<Library>();
}
