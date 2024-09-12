using System;
using System.Collections.Generic;

namespace KAsT_aPi.Models;

public partial class GameOfCart
{
    public int Id { get; set; }

    public int GameId { get; set; }

    public int UserId { get; set; }

    public virtual Game Game { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
