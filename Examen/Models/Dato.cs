using System;
using System.Collections.Generic;

namespace Examen.Models;

public partial class Dato
{
    public int  Id { get; set; }

    public string  Nombre { get; set; } = null!;

    public string  ApePaterno { get; set; } = null!;

    public string  ApeMaterno { get; set; } = null!;

    public int  Edad { get; set; }

    public double  Altura { get; set; }

    public string  Sexo { get; set; } = null!;

    public string  Correo { get; set; } = null!;
}
