using System;
using System.Collections.Generic;

namespace KAsT_aPi.Models;

public partial class Game
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Price { get; set; }

    public int Discount { get; set; }

    public int PriseIsDiscount { get; set; }

    public string Reviews { get; set; } = null!;

    public string Trailers { get; set; } = null!;

    public string Category { get; set; } = null!;

    public virtual ICollection<GameOfCart> GameOfCarts { get; set; } = new List<GameOfCart>();

    public virtual ICollection<Library> Libraries { get; set; } = new List<Library>();
}
