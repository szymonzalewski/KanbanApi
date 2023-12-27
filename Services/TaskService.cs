using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KanbanApi.DTO;
using KanbanApi.Models; // Dodaj odpowiednią ścieżkę do Twojego modelu, jeśli potrzebna

namespace KanbanApi.Services
{
    public class TaskService : ITaskService
    {
        private readonly KanabanApiDbContext _context;

        public TaskService(KanabanApiDbContext context)
        {
            _context = context;
        }

        public async Task<Models.Task?> CreateOne(CreateTaskDTO createTask)
        {
            var newTask = new Models.Task()
            {
                Description = createTask.Description,
                Status = createTask.Status,
                Title = createTask.Title
            };

            await _context.Tasks.AddAsync(newTask);
            await _context.SaveChangesAsync();

            return newTask;
        }

        public async Task<IEnumerable<Models.Task>> ReadAll()
        {
            return await _context.Tasks.ToListAsync();
        }
        public Task<Models.Task> ReadOne(CreateTaskDTO readOneTask)
        {
            throw new NotImplementedException();
        }

        public Task<Models.Task?> GetTaskById(int id)
        {

            return _context.Tasks.FindAsync(id).AsTask();
        }
        public async Task<Models.Task?> DeleteOneTask(int taskIdToDelete)
        {
            var taskToDelete = await _context.Tasks.FindAsync(taskIdToDelete);

            if (taskToDelete != null)
            {
                _context.Tasks.Remove(taskToDelete);
                await _context.SaveChangesAsync();

                return taskToDelete;
            }
            return null;
        }

        public async Task<bool> DeleteTaskById(int id)
        {
            var taskToDelete = await _context.Tasks.FindAsync(id);

            if (taskToDelete != null)
            {
                _context.Tasks.Remove(taskToDelete);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public System.Threading.Tasks.Task DeleteTaskById()
        {
            throw new NotImplementedException();
        }
        public async Task<Models.Task?> UpdateTaskById(int id, CreateTaskDTO updateTask)
        {
            var existingTask = await _context.Tasks.FindAsync(id);

            if (existingTask != null)
            {
                
                existingTask.Title = updateTask.Title;
                existingTask.Description = updateTask.Description;
                existingTask.Status = updateTask.Status;

                
                await _context.SaveChangesAsync();

                return existingTask; 
            }

            return null; 
        }



    }
    
}
