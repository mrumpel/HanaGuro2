using System.ComponentModel.DataAnnotations;

namespace HanaGuro2.Models.Dtos;

public class PlantUpdateDto
{
        [Required]
        public int Id { get; set; }
        public int? Level { get; set; }
        public decimal? Price { get; set; }
        public int? TypeId { get; set; }
        public int? BiomeId { get; set; }
        public int? OwnerId { get; set; }
}