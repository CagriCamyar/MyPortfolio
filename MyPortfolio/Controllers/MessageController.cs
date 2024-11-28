using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using MyPortfolio.DataAccessLayer.Context;

namespace MyPortfolio.Controllers
{
    public class MessageController : Controller
    {
        MyPortfolioContext portfolioContext = new MyPortfolioContext();
        public IActionResult Inbox()
        {
            var values = portfolioContext.Messages.ToList();
            return View(values);
        }

        public IActionResult ChangeIsReadToTrue(int id)
        {
            var value = portfolioContext.Messages.Find(id);
            value.IsRead = true;
            portfolioContext.SaveChanges();
            return RedirectToAction("Inbox");
        }

		public IActionResult ChangeIsReadToFalse(int id)
		{
			var value = portfolioContext.Messages.Find(id);
			value.IsRead = false;
			portfolioContext.SaveChanges();
			return RedirectToAction("Inbox");
		}

		public IActionResult DeleteMessage(int id)
		{
			var value = portfolioContext.Messages.Find(id);
            portfolioContext.Messages.Remove(value);
            portfolioContext.SaveChanges();
			return RedirectToAction("Inbox");
		}
		public IActionResult MessageDetail(int id)
		{
			var value = portfolioContext.Messages.Find(id);
			return View(value);

		}

	}
}
