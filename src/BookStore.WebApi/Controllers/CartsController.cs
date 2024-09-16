//using BookStore.Application.Carts.AddItem;
//using BookStore.Application.Carts.CheckoutCart;
//using BookStore.Application.Carts.ClearCart;
//using BookStore.Application.Carts.GetCart;
//using BookStore.Application.Carts.RemoveItem;
//using BookStore.Domain.BaseTypes;
//using BookStore.WebApi.Extensions;
//using BookStore.WebApi.Requests.Carts;

//namespace BookStore.WebApi.Controllers
//{
//    [ApiController]
//    public class CartsController : ControllerBase
//    {
//        private readonly ISender sender;

//        public CartsController(ISender sender)
//        {
//            this.sender = sender;
//        }
//        [HttpPost("/carts")]
//        public async Task<IActionResult> AddItemToCart([FromBody] AddItemToCartRequest request)
//        {
//            var command = new AddItemToCartCommand(
//                claims.GetUserId(),
//                request.BookId,
//                request.Quantity);

//            var result = await sender.Send(command);

//            if (result.IsFailure)
//            {
//                return result.ProduceProblem();
//            }

//            return NoContent();
//        }

//        [HttpPost("/carts/checkout")]
//        public async Task<IActionResult> CheckoutCart([FromBody] CheckoutCartRequest request)
//        {
//            var command = new CheckoutCartCommand(
//                claims.GetUserId(),
//                request.ShippingAddressId
//            );

//            var result = await sender.Send(command);

//            if (result.IsFailure)
//            {
//                return result.ProduceProblem();
//            }

//            return Ok(result.Value);
//        }


//        [HttpGet("/carts")]
//        public async Task<IActionResult> Get()
//        {
//            var command = new GetCartQuery(claims.GetUserId());

//            var result = await sender.Send(command);

//            if (result.IsFailure)
//            {
//                return result.ProduceProblem();
//            }

//            return Ok(result.Value);
//        }

//        [HttpDelete("/carts/clear")]
//        public async Task<IActionResult> ClearCart()
//        {
//            var command = new ClearCartCommand(claims.GetUserId());
//            var result = await sender.Send(command);

//            if (result.IsFailure)
//            {
//                return result.ProduceProblem();
//            }

//            return NoContent();
//        }

//        [HttpDelete("/carts/remove")]
//        public async Task<IActionResult> RemoveItemFromCart([FromBody] RemoveItemFromCartRequest request)
//        {
//            var command = new RemoveItemFromCartCommand(
//                claims.GetUserId(),
//                request.BookId,
//                request.Quantity);

//            var result = await sender.Send(command);

//            if (result.IsFailure)
//            {
//                return result.ProduceProblem();
//            }

//            return NoContent();
//        }


//    }
//}
