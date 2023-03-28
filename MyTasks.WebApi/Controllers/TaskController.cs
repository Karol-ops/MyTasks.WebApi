using Microsoft.AspNetCore.Mvc;
using MyTasks.WebApi.Models;
using MyTasks.WebApi.Models.Converters;
using MyTasks.WebApi.Models.Dtos;
using MyTasks.WebApi.Models.Response;
using System;
using System.Collections.Generic;

namespace MyTasks.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public TaskController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public DataResponse<IEnumerable<TaskDto>> Get()
        {
            var response = new DataResponse<IEnumerable<TaskDto>>();

            try
            {
                response.Data = _unitOfWork.Task.Get().ToDtos();
            }
            catch (Exception exception)
            {

                //logowanie do pliku
                response.Errors.Add(new Error(exception.Source, exception.Message));
            }

            return response;
        }

        [HttpGet("{id}")]
        public DataResponse<TaskDto> Get(int id)
        {
            var response = new DataResponse<TaskDto>();

            try
            {
                response.Data = _unitOfWork.Task.Get(id)?.ToDto();
            }
            catch (Exception exception)
            {

                //logowanie do pliku
                response.Errors.Add(new Error(exception.Source, exception.Message));
            }

            return response;
        }

        [HttpGet("{recordsCount}/{page}")]
        public DataResponse<IEnumerable<TaskDto>> Get(int recordsCount, int page)
        {
            var response = new DataResponse<IEnumerable<TaskDto>>();

            try
            {
                if (recordsCount <= 0)
                {
                    throw new ArgumentException(nameof(recordsCount));
                }

                if (page <= 0)
                {
                    throw new ArgumentException(nameof(page));
                }

                response.Data = _unitOfWork.Task.Get(recordsCount, page)?.ToDtos();
            }
            catch (Exception exception)
            {

                //logowanie do pliku
                response.Errors.Add(new Error(exception.Source, exception.Message));
            }

            return response;
        }

        [HttpPost]
        public DataResponse<int> Add(TaskDto taskDto)
        {
            var response = new DataResponse<int>();

            try
            {
                var task = taskDto.ToDao();
                _unitOfWork.Task.Add(task);
                _unitOfWork.Complete();
                response.Data = task.Id;
            }
            catch (Exception exception)
            {

                //logowanie do pliku
                response.Errors.Add(new Error(exception.Source, exception.Message));
            }

            return response;
        }

        [HttpPut]
        public Response Update(TaskDto task)
        {
            var response = new Response();

            try
            {
                _unitOfWork.Task.Update(task.ToDao());
                _unitOfWork.Complete();
            }
            catch (Exception exception)
            {

                //logowanie do pliku
                response.Errors.Add(new Error(exception.Source, exception.Message));
            }

            return response;
        }

        [HttpDelete("{id}")]
        public Response Delete(int id)
        {
            var response = new Response();

            try
            {
                _unitOfWork.Task.Delete(id);
                _unitOfWork.Complete();
            }
            catch (Exception exception)
            {

                //logowanie do pliku
                response.Errors.Add(new Error(exception.Source, exception.Message));
            }

            return response;
        }
    }
}
