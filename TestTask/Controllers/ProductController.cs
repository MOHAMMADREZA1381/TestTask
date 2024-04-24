using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Test.Application.IServices;
using Test.Domain.ViewModel.Product;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
namespace TestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        #region Services
        private readonly IProductService _productService;
        private readonly IUserService _userService;
        public ProductController(IProductService productService, IUserService userService)
        {
            _productService = productService;
            _userService = userService;
        }

        #endregion

        [Authorize]
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(ProductViewModel viewModel)
        {
            var Userid = int.Parse(User.Claims.FirstOrDefault().Value);
            var usr = await _userService.GetUserById(Userid);
            if (ModelState.IsValid)
            {
                viewModel.ManufacturePhone = usr.PhoneNumber;
                viewModel.ManufactureEmail = usr.Email;
                viewModel.UserId = Userid;
                await _productService.AddProduct(viewModel);
                return new JsonResult(Ok());
            }
            return new JsonResult(BadRequest());
        }
        [Authorize]
        [HttpPut("{ProductId}")]
        public async Task<IActionResult> EditProduct(int ProductId,EditProductViewModel viewModel)
        {
            var Userid = int.Parse(User.Claims.FirstOrDefault().Value);
            bool CheckOwner = await _productService.CehckOwner(ProductId, Userid);
            if(CheckOwner==false)
            {
                return new JsonResult(NotFound());
            }
            if (ModelState.IsValid)
            {
                viewModel.Id = ProductId;
                await _productService.EditProduct(viewModel);
                return new JsonResult(Ok());
            }
            return new JsonResult(NotFound());
        }

        [Authorize]
        [HttpDelete("{ProductId}")]
        public async Task<IActionResult> DeleteProduct(int ProductId)
        {
            bool ExistProduct = await _productService.ExistProduct(ProductId);
            if (ExistProduct==false)
            {
                return new JsonResult(NotFound());
            }

            var Userid = int.Parse(User.Claims.FirstOrDefault().Value);
            bool CheckOwner = await _productService.CehckOwner(ProductId, Userid);
            if (CheckOwner == false)
            {
                return new JsonResult(NotFound());
            }

            await _productService.DeleteProduct(ProductId);
            return new JsonResult(Ok());

        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var Products=await _productService.GetAllProducts();
            return new JsonResult(Ok(Products));
        }

    }
}
