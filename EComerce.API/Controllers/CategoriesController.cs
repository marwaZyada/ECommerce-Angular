using AutoMapper;
using EComerce.API.Dtos;
using EComerce.API.Errors;
using EComerce.Core.Entities.Product;
using EComerce.Core.Interfaces;
using EComerce.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EComerce.API.Controllers
{
  
    public class CategoriesController : BaseController
    {
        public CategoriesController(IUnitOfWork unitOfWork,IMapper mapper) : base(unitOfWork,mapper)
        {
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var categories = await _unitOfWork.CategoryRepository.GetAllAsync();
                if (categories == null)
                    return BadRequest(new ApiResponse(400));
                return Ok(categories);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        
        }
        [HttpGet("GetbyId/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
                if (category== null)
                    return NotFound(new ApiResponse(404, $"Not found category id={id}"));
                return Ok(category);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(CategoryDto model)
        {
            try
            {
                var category =_mapper.Map<Category>(model);
                await _unitOfWork.CategoryRepository.AddAsync(category);
                return Ok(new  ApiResponse(200, "new item has been added" ));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdatedCategoryDto model)
        {
            try
            {
                var category = _mapper.Map<UpdatedCategoryDto, Category>(model);

                await _unitOfWork.CategoryRepository.UpdateAsync(category);
                return Ok(new ApiResponse(200 ,"new item has been updated" ));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                
                await _unitOfWork.CategoryRepository.DeleteAsync(id);
                return Ok(new ApiResponse(200, "new item has been deleted"));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }
}
