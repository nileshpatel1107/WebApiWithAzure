using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NileshWebApi.Filters;
using NileshWebApi.Models;
using System.Linq;

namespace NileshWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Home : ControllerBase
    {
        private readonly ExamContext dbcontext;

        public Home(ExamContext _dbcontext)
        {
            dbcontext = _dbcontext;
        }
        //[HttpGet]
        //    public List<Feedback> GetAllFeedBack()
        //    {
        //        var feedbackList = dbcontext.Feedbacks
        //            .Where(f => f.IsDeleted == 0 && f.Rating == 5)
        //            .Include(f => f.Order) // Fetch Order details
        //            .Include(f => f.OrderItem) // Fetch OrderItem details
        //            .Include(f => f.FeedbackDocs) // Fetch related FeedbackDocs
        //            .ToList(); // Fetch from database first

        //        // Map data properly
        //        var result = feedbackList.Select(f => new Feedback
        //        {
        //            FeedbackId = f.FeedbackId,
        //            OrderId = f.OrderId,
        //            OrderItemId = f.OrderItemId,
        //            Rating = f.Rating,
        //            Date = f.Date,
        //            Comments = f.Comments,
        //            CreatedOn = f.CreatedOn,
        //            UpdatedOn = f.UpdatedOn,
        //            CreatedBy = f.CreatedBy,
        //            IsDeleted = f.IsDeleted,
        //            Order = f.Order != null ? new Order
        //            {
        //                OrderId = f.Order.OrderId,
        //                OrderRefunds = f.Order.OrderRefunds,
        //                DateOfOrder = f.Order.DateOfOrder
        //            } : null,
        //            OrderItem = f.OrderItem != null ? new OrderItem
        //            {
        //                OrderItemId = f.OrderItem.OrderItemId,
        //                TaxAmount = f.OrderItem.TaxAmount,
        //                Quantity = f.OrderItem.Quantity,
        //                Discount = f.OrderItem.Discount,
        //                TaxPercentage = f.OrderItem.TaxPercentage,
        //                Type = f.OrderItem.Type
        //            } : null,
        //            FeedbackDocs = f.FeedbackDocs.Select(fd => new FeedbackDoc
        //            {
        //                FeedbackDocsId = fd.FeedbackDocsId,
        //                FeedbackId = fd.FeedbackId,
        //                Path = fd.Path,
        //                Type = fd.Type
        //            }).ToList()
        //        }).ToList();

        //        return result;
        //    }



        [HttpGet]
        [ActionClass("Action")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var orders = await dbcontext.
                Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                .Include(o => o.Feedbacks)
                .Include(o => o.OrderRefunds)
                .ToListAsync();

             
            if (orders == null || !orders.Any())
            {
                return NotFound("No orders found.");
            }

            //List<Feedback> feedbackList = new List<Feedback>();

            //// Loop through the orders safely
            //foreach (var order in orders)
            //{
            
            //        foreach (var feedback in order.Feedbacks)
            //        {
            //            if (feedback != null)
            //            {
            //                feedbackList.Add(new Feedback
            //                {
            //                    Comments = feedback.Comments,
            //                    FeedbackId = feedback.FeedbackId
            //                });
            //            }
            //        }

            //        order.Feedbacks = feedbackList;
                
            //}

            

            return Ok(orders);
        }

        [HttpGet("{id}")]
        public Feedback GetFeedBack(int id)
        {
            if (id != null)
            {

            Feedback result = dbcontext.Feedbacks.Find(id);
            return result;
            }
            return null;
        }

        [HttpPost]


        public ActionResult<Feedback> Post([FromBody] Feedback feedback)
        {
            //dbcontext.Feedbacks.Add(feedback);
            //dbcontext.SaveChanges();
            var feedbackId = dbcontext.Feedbacks
                   .FromSqlRaw("EXEC selctfeedback @p0, @p1, @p2,@p3,@p4",
                       feedback.OrderId,
                       feedback.OrderItemId,
                       feedback.Rating,
                       feedback.Comments,
                       feedback.IsDeleted)
                   .AsEnumerable()
                   .FirstOrDefault()?.FeedbackId; // Get the inserted ID

            feedback.FeedbackId = feedbackId ?? 0;
            return Ok(feedback);
        }


        [HttpPut("{id}")]
        public IActionResult Edit(int id, Feedback updatedFeedback)
        {
            if (updatedFeedback == null || id != updatedFeedback.FeedbackId)
            {
                return BadRequest(new { message = "Invalid request data" });
            }

            var existingFeedback = dbcontext.Feedbacks.Find(id);
            if (existingFeedback == null)
            {
                return NotFound(new { message = "Feedback not found" });
            }

            // Update properties
            existingFeedback.Comments = updatedFeedback.Comments;
            existingFeedback.Rating = updatedFeedback.Rating;
            existingFeedback.OrderId = updatedFeedback.OrderId;
            existingFeedback.IsDeleted = updatedFeedback.IsDeleted;
            existingFeedback.CreatedOn = updatedFeedback.CreatedOn;
            updatedFeedback.FeedbackId = id;

            try
            {
                dbcontext.SaveChanges();
                return Ok(new { message = "Feedback updated successfully", feedback = existingFeedback });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred", error = ex.Message });
            }
        }


        [HttpDelete(("{id}"))]
        public IActionResult Delete(int id)
        {
            if (id <= 0) // Check for valid ID
            {
                return BadRequest(new { message = "Invalid ID" });
            }

            var feedback = dbcontext.Feedbacks.Find(id);

            if (feedback == null)
            {
                return NotFound(new { message = "Feedback not found" });
            }

            try
            {
                int rowsAffected = dbcontext.Database.ExecuteSqlRaw("EXEC sp_deletefeedById @p0", id);

                if (rowsAffected > 0)
                {
                    return Ok(new { message = "Feedback deleted successfully" });
                }
                else
                {
                    return NotFound(new { message = "Feedback not found" });
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred", error = ex.Message });
            }
        }
    }
}
