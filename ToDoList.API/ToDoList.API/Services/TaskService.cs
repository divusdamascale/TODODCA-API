using Microsoft.Identity.Client;
using ToDoList.API.Domain.DTOs;
using ToDoList.API.Repositories.Interfaces;
using ToDoList.API.Services.Interfaces;

namespace ToDoList.API.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;
        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> ChangeState(int id,bool state)
        {
            var task = _repository.GetTaskById(id);

            if(task is not null)
            {
                task.Result.State = state;
                await _repository.UpdateTask(task.Result);
                return true;
            }
            else
            {
                return false;
            }


        }

        public async Task<TaskToAddDTO> CreateTask(TaskToAddDTO task)
        {
            var taskToAdd = TaskToAddDTOToTask(task);
            var addedTask = await _repository.CreateTask(taskToAdd);

            if(addedTask is not null)
            {
                return task;
            }
            else
            {
                return new TaskToAddDTO();
            }
        }

        public async Task<TaskDTO> DeleteTask(int id)
        {
            var task = _repository.GetTaskById(id);

            if(task is not null)
            {
                await _repository.DeleteTask(task.Result);
                return await Task.FromResult(new TaskDTO() { 
                    TaskId = id,
                    TaskName = task.Result.TaskName,
                    ListId = task.Result.ListId,
                    EndDate = task.Result.EndDate,
                    State = task.Result.State
                });
            }
            else
            {
                return new TaskDTO();
            }
        }

        public async Task<IEnumerable<Views.Models.Task>> GetAllTasks()
        {
            var tasks = await _repository.GetAllTasks();

            if(tasks is not null)
            {
                return tasks;
            }
            else
            {
                return new List<Views.Models.Task>();
            }
        }

        public async Task<Views.Models.Task> GetTaskById(int id)
        {
            var task = await _repository.GetTaskById(id);
            if(task is not null)
            {
                return task;
            }
            return new Views.Models.Task();
        }

        public async Task<IEnumerable<Views.Models.Task>> GetTasksByListId(int listId)
        {
            var tasks = await _repository.GetTasksByListId(listId);

            if(tasks.Any())
            {
                return tasks;
            }
            else
            {
                return new List<Views.Models.Task>();
            }

        }

        public async Task<TaskToUpdateDTO> UpdateTask(TaskToUpdateDTO task)
        {
            var taskToUpdate = await _repository.GetTaskById(task.TaskId);

            if(taskToUpdate is not null)
            {
                taskToUpdate.TaskName = task.TaskName;
                taskToUpdate.EndDate = task.EndDate;
                taskToUpdate.State = task.State;
                await _repository.UpdateTask(taskToUpdate);
                return task;
            }
            else
            {
                return new TaskToUpdateDTO();
            }
        }


        private Views.Models.Task TaskToAddDTOToTask(TaskToAddDTO task)
        {
            return new Views.Models.Task()
            {
                ListId = task.ListId,
                TaskName = task.TaskName,
                EndDate = task.EndDate,
                State = false
            };
        }


    }
}
