using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NileshWebApi.Filters;
using NileshWebApi.Models;
using System.Collections.Generic;

namespace NileshWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ActionClass("Controller")]
    public class OrdersController : ControllerBase
    {

        private readonly ExamContext dbcontext;

        public OrdersController(ExamContext _dbcontext)
        {
            dbcontext = _dbcontext;
        }
     
        [HttpGet("GetAllOrders")]
        public List<Order> GetAllOder()
        {
            List<Order> orders = new List<Order>();
            var oder=dbcontext.Orders.Where(order=>order.Isdeleted==0);
            if (oder.Any())
            {
                orders=oder.ToList();
            }
            return orders;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var deleteList = dbcontext.Orders.Find(id);
            deleteList.Isdeleted = 1;
            dbcontext.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public Order Get(int id)
        {
            if (id == null)
            {
                return null;
            }

            Order? order = dbcontext.Orders.Find(id);
            return order;
        }
    }
}
