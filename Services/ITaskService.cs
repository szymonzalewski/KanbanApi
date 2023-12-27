using System;
using KanbanApi.DTO;

namespace KanbanApi.Services
{
	public interface ITaskService
	{
		public Task<IEnumerable<Models.Task>> ReadAll();
        public Task<Models.Task?> CreateOne(CreateTaskDTO createTask);
        public Task<Models.Task?> GetTaskById(int id);
		
		Task<bool> DeleteTaskById(int id);
        //Task UpdateTask(CreateTaskDTO updateTask);
        public Task<Models.Task?> UpdateTaskById(int id, CreateTaskDTO updateTask);
    }
}

