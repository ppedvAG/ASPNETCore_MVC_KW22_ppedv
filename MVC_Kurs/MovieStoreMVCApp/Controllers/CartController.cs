using Microsoft.AspNetCore.Mvc;
using MovieStoreMVCApp.Data;
using MovieStoreMVCApp.Helpers;
using MovieStoreMVCApp.Models; //Movie
//using MovieStoreMVCApp.ViewModels

namespace MovieStoreMVCApp.Controllers
{
    public class CartController : Controller
    {
        private readonly MovieDbContext movieDbContext;

        public CartController(MovieDbContext movieDbContext)
        {
            this.movieDbContext = movieDbContext;
        }

        //[Route("index")]
        public IActionResult Index()
        {
            List<CartItemViewModel> cartList = SessionHelper.GetObjectFromJson<List<CartItemViewModel>>(HttpContext.Session, "cart");
            ViewBag.total = cartList.Sum(item => item.Movie.Price * item.Quantity);
            return View(cartList);
        }

        //[Route("buy/{id}")]
        public IActionResult Buy(int id)
        {
            


            if (SessionHelper.GetObjectFromJson<List<CartItemViewModel>>(HttpContext.Session, "cart") == null)
            {
                List<CartItemViewModel> cartList = new List<CartItemViewModel>();

                cartList.Add(new CartItemViewModel { Movie = movieDbContext.Movies.Find(id), Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cartList);
            }
            else
            {
                List<CartItemViewModel> cart = SessionHelper.GetObjectFromJson<List<CartItemViewModel>>(HttpContext.Session, "cart");
                int index = isExist(id);
                
                //Ist schon einmal gekauft worden
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new CartItemViewModel { Movie = movieDbContext.Movies.Find(id), Quantity = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }

        //[Route("remove/{id}")]
        public IActionResult Remove(int id)
        {
            List<CartItemViewModel> cart = SessionHelper.GetObjectFromJson<List<CartItemViewModel>>(HttpContext.Session, "cart");
            int index = isExist(id);

            if (cart[index].Quantity > 1)
                cart[index].Quantity--;
            else
                cart.RemoveAt(index);

            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        private int isExist(int id)
        {
            List<CartItemViewModel> cart = SessionHelper.GetObjectFromJson<List<CartItemViewModel>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Movie.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
