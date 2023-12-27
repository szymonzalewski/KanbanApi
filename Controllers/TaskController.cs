using KanbanApi.DTO;
using KanbanApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KanbanApi.Controllers;

[ApiController]
[Route("[controller]")]

public class TaskController : Controller
{
    private ITaskService _service;
    public TaskController(ITaskService service)
    {
        _service = service;
    }

    [HttpGet("All")]
    public async Task<ActionResult<IEnumerable<Models.Task>>> ReadAll()
    {
        try
        {
            var tasks = await _service.ReadAll();
            return Ok(tasks);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server Error: {ex.Message}");
        }


    }

    [HttpPost]
    public async Task<ActionResult<Models.Task>> CreatOne(CreateTaskDTO createTask)
    {
        try
        {
            var result = await _service.CreateOne(createTask);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server Error: {ex.Message}");
        }
    }
    [HttpGet("One")]
    public async Task<ActionResult<Models.Task>> GetTaskById(int id)
    {
        try
        {
            var result = await _service.GetTaskById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server Error: {ex.Message}");
        }


    }
    [HttpDelete("One")]
    public async Task<ActionResult<Models.Task>> DeleteTaskById(int id)
    {
        try
        {
            var deleted = await _service.DeleteTaskById(id);

            if (deleted)
            {
                return Ok($"Usunięto: {id}");
            }

            return NotFound();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server Error: {ex.Message}");
        }

    }
    [HttpPut("{id}")]
    public async Task<ActionResult<Models.Task>> UpdateTaskById(int id, CreateTaskDTO updateTask)
    {
        try
        {
            var result = await _service.UpdateTaskById(id, updateTask);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server Error: {ex.Message}");
        }
    }



}
