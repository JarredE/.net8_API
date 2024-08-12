using System;
using System.Collections.Generic;

namespace WebsiteAPI.Entities;

public partial class Logintable
{
    public int? Id { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }
}
