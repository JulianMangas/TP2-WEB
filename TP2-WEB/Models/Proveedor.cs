// Models/Proveedor.cs
using System.ComponentModel.DataAnnotations;
namespace TP2_WEB.Models;



public class Proveedor : IEntidad
{
    public int Id { get; set; }

    [Required(ErrorMessage = "La razón social es obligatoria")]
    [StringLength(150)]
    public string RazonSocial { get; set; } = "";

    [Required, StringLength(13)]
    public string Cuit { get; set; } = "";

    [EmailAddress(ErrorMessage = "Email inválido")]
    public string? Email { get; set; }

    [StringLength(30)]
    public string? Telefono { get; set; }

    public List<Producto> Productos { get; set; } = new();
}