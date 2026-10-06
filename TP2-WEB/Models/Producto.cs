using System.ComponentModel.DataAnnotations;
using TP2_WEB.Models;

public class Producto : IEntidad
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(150)]
    public string Nombre { get; set; } = "";

    [Range(0.01, 999999999, ErrorMessage = "El precio debe ser mayor a 0")]
    public decimal Precio { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo")]
    public int Stock { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Seleccioná una categoría")]
    public int CategoriaId { get; set; }
    public Categoria? Categoria { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Seleccioná un proveedor")]
    public int ProveedorId { get; set; }
    public Proveedor? Proveedor { get; set; }
}