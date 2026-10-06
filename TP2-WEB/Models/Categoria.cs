// Models/Categoria.cs
using System.ComponentModel.DataAnnotations;
namespace TP2_WEB.Models;


public class Categoria : IEntidad
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(100)]
    public string Nombre { get; set; } = "";

    [StringLength(250)]
    public string? Descripcion { get; set; }

    public List<Producto> Productos { get; set; } = new();
}