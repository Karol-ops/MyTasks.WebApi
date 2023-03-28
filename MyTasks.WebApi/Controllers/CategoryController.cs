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
    public class CategoryController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public CategoryController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public DataResponse<IEnumerable<CategoryDto>> Get()
        {
            var response = new DataResponse<IEnumerable<CategoryDto>>();

            try
            {
                response.Data = _unitOfWork.Category.Get().ToDtos();
            }
            catch (Exception exception)
            {

                //logowanie do pliku
                response.Errors.Add(new Error(exception.Source, exception.Message));
            }

            return response;
        }

        [HttpGet("{id}")]
        public DataResponse<CategoryDto> Get(int id)
        {
            var response = new DataResponse<CategoryDto>();

            try
            {
                response.Data = _unitOfWork.Category.Get(id)?.ToDto();
            }
            catch (Exception exception)
            {

                //logowanie do pliku
                response.Errors.Add(new Error(exception.Source, exception.Message));
            }

            return response;
        }

        [HttpGet("{recordsCount}/{page}")]
        public DataResponse<IEnumerable<CategoryDto>> Get(int recordsCount, int page)
        {
            var response = new DataResponse<IEnumerable<CategoryDto>>();

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

                response.Data = _unitOfWork.Category.Get(recordsCount, page)?.ToDtos();
            }
            catch (Exception exception)
            {

                //logowanie do pliku
                response.Errors.Add(new Error(exception.Source, exception.Message));
            }

            return response;
        }

        [HttpPost]
        public DataResponse<int> Add(CategoryDto categoryDto)
        {
            var response = new DataResponse<int>();

            try
            {
                var category = categoryDto.ToDao();
                _unitOfWork.Category.Add(category);
                _unitOfWork.Complete();
                response.Data = category.Id;
            }
            catch (Exception exception)
            {

                //logowanie do pliku
                response.Errors.Add(new Error(exception.Source, exception.Message));
            }

            return response;
        }

        [HttpPut]
        public Response Update(CategoryDto category)
        {
            var response = new Response();

            try
            {
                _unitOfWork.Category.Update(category.ToDao());
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
                _unitOfWork.Category.Delete(id);
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
