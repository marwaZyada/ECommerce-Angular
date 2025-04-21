using AutoMapper;
using EComerce.API.Dtos;
using EComerce.API.Errors;
using EComerce.Core.Entities.Product;
using EComerce.Core.Interfaces;
using EComerce.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EComerce.API.Controllers
{

    public class ProductsController : BaseController
    {
        private readonly IimageManagementService service;

        public ProductsController(IUnitOfWork unitOfWork, IMapper mapper, IimageManagementService service) : base(unitOfWork, mapper)
        {
            this.service = service;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var products = await _unitOfWork.ProductRepository.GetAllAsync(p => p.Category, p => p.photos);
                if (products == null)
                    return BadRequest(new ApiResponse(400));
                return Ok(_mapper.Map<IReadOnlyList<ProductDto>>(products));
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
                var Product = await _unitOfWork.ProductRepository.GetByIdAsync(id, p => p.Category, p => p.photos);
                if (Product == null)
                    return NotFound(new ApiResponse(404, $"Not found product id={id}"));
                return Ok(_mapper.Map<ProductDto>(Product));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromForm] AddProductDto model)
        {
            try
            {
                if (model is null) return BadRequest();

                var product = _mapper.Map<AddProductDto, Product>(model);
                var imagesname = await service.AddImageAsync(model.photos, model.Name);
                foreach (var item in imagesname)
                {
                    product.photos.Add(new Photo()
                    {
                        ImageName = item
                    });

                }


                await _unitOfWork.ProductRepository.AddAsync(product);
                return Ok(new ApiResponse(200, "new item has been added"));


            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromForm] UpdatedProductDto model)
        {
            try
            {
                var oldproduct = await _unitOfWork.ProductRepository.GetByIdAsync(model.Id, p => p.Category, p => p.photos);
                var oldimagesname = oldproduct.photos.Select(p => p.ImageName).ToList();
                var product = _mapper.Map(model, oldproduct);
                
                if (model.photos.Count > 0)
                {
                    oldproduct.photos.Clear();
                    
                   

                 
                    var imagesname = await service.AddImageAsync(model.photos, model.Name);
                    foreach (var item in imagesname)
                    {
                        product.photos.Add(new Photo()
                        {
                            ImageName = item
                        });

                    }
                }
                await _unitOfWork.ProductRepository.UpdateAsync(product);
                foreach (var item in oldimagesname)
                {
                    service.DeleteImageAsync(item);
                }
                return Ok(new ApiResponse(200, "new item has been updated"));
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

                var result = await _unitOfWork.ProductRepository.DeleteAsync(id);

                if (!result) return BadRequest();
                return Ok(new ApiResponse(200, "new item has been deleted"));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

    }
}
