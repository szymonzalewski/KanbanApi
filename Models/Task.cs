using System.ComponentModel.DataAnnotations;
namespace KanbanApi.Models;

public class Task
	{
    [Key]
    public int ID { get; set; }

    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Status { get; set; }
    
    
}


