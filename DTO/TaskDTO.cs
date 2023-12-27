
using System.ComponentModel.DataAnnotations;

namespace KanbanApi.DTO;

	public class CreateTaskDTO
	{
    [Required]
    public required string Title { get; set; }

    [Required]
    public required string Description { get; set; }

    [Required]
    public required string Status { get; set; }
}


