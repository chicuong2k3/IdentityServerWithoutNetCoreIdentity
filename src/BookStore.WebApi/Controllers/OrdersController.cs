//using BookStore.Application.Orders.ListOrdersForUser;
//using BookStore.Domain.BaseTypes;
//using BookStore.WebApi.Extensions;

//namespace BookStore.WebApi.Controllers
//{
//    [ApiController]
//    public class OrdersController : ControllerBase
//    {
//        private readonly ISender sender;

//        public OrdersController(ISender sender)
//        {
//            this.sender = sender;
//        }
        
//        [HttpGet("/orders")]
//        public async Task<IActionResult> ListOrdersForUser()
//        {
//            var query = new ListOrdersForUserQuery(claims.GetUserId());
//            var result = await sender.Send(query);

//            if (result.IsFailure)
//            {
//                return result.ProduceProblem();
//            }

//            return Ok(result.Value);
//        }
       
//    }
//}
