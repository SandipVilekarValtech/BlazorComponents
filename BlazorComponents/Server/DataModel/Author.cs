using System;
using System.Collections.Generic;

namespace BlazorComponents.Server.DataModel;

public partial class Author
{
    public short Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime Birthdate { get; set; }

    public DateTime Added { get; set; }
}
