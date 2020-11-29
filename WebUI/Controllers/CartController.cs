using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Helpers;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class CartController : Controller
    {
        private ICartService _cartService;
        private ICartSessionHelper _cartSessionHelper;
        private IProductService _productService;

        public CartController(ICartService cartService, ICartSessionHelper cartSessionHelper, IProductService productService)
        {
            _cartService = cartService;
            _cartSessionHelper = cartSessionHelper;
            _productService = productService;
        }

        public IActionResult AddToCart(int productId)
        {
            //Get Product
            Product product = _productService.GetById(productId);
            var cart = _cartSessionHelper.GetCart("cart");
            _cartService.AddToCart(cart, product);
            _cartSessionHelper.SetCart("cart",cart);

            TempData.Add("message", product.ProductName + "added to your cart.");

            return RedirectToAction("Index", "Product");
        }

        public IActionResult RemoveFromCart(int productId)
        {
            Product product = _productService.GetById(productId);
            var cart = _cartSessionHelper.GetCart("cart");
            _cartService.RemoveFromCart(cart, productId);
            _cartSessionHelper.SetCart("cart",cart);

            TempData.Add("message", product.ProductName + "removed in your cart.");
            return RedirectToAction("Index", "Cart");
        }

        public IActionResult Index()
        {
            var model = new CartListViewModel
            {
                Cart = _cartSessionHelper.GetCart("cart")
            };
            return View(model);
        }

        public IActionResult Complete()
        {
            var model = new ShippingDetailsViewModel
            {
                ShippingDetail = new ShippingDetail()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Complete(ShippingDetail shippingDetail)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            TempData.Add("message", "Your order has been successfully completed.");
            _cartSessionHelper.Clear();
            return RedirectToAction("Index", "Cart");
        }
    }

}
