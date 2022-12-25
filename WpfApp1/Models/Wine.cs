using System;
using System.Collections.Generic;

namespace WpfApp1;

public partial class Wine
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Grade { get; set; } = null!;

    public int Price { get; set; }

    public string Country { get; set; } = null!;

    public DateTime YearOfAqing { get; set; }

    public double Volume { get; set; }

    public double Estimation { get; set; }
}
