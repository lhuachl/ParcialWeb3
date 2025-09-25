using System.ComponentModel.DataAnnotations;

namespace PrimerParcial.Models
{
    public class Recipe
    {
        // Clave Primaria (PK)
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la receta es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "La descripci�n es obligatoria")]
        [StringLength(500, ErrorMessage = "La descripci�n no puede exceder 500 caracteres")]
        public string Description { get; set; }

        [StringLength(1000, ErrorMessage = "Las instrucciones no pueden exceder 1000 caracteres")]
        public string Instructions { get; set; }

        [Range(1, 10, ErrorMessage = "La dificultad debe estar entre 1 y 10")]
        public int DifficultyLevel { get; set; }

        [Range(1, 480, ErrorMessage = "El tiempo de preparaci�n debe ser entre 1 y 480 minutos")]
        public int PreparationTime { get; set; } // en minutos

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // --- Relaciones de Entity Framework Core ---

        // Clave For�nea (FK): Vincula esta receta a una categor�a
        public int CategoryId { get; set; }

        // Propiedad de Navegaci�n: El lado 'uno'
        public Category Category { get; set; }

        // Propiedad de Navegaci�n: El lado 'muchos' para los ingredientes de esta receta
        public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }
}