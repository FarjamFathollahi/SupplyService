using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SupplyService.Contracts.SupplyRequests.Commands.CreateSupplyRequest;
using SupplyService.Contracts.SupplyRequests.Commands.DeleteSupplyRequest;
using SupplyService.Contracts.SupplyRequests.Commands.EditSupplyRequeset;
using SupplyService.Contracts.SupplyRequests.Commands.GetAllSupplyRequests;
using SupplyService.Contracts.SupplyRequests.Commands.GetSupplyRequest;
using SupplyService.Domain.Entities;

namespace SupplyService.Web.Controllers
{
    [Authorize]
    public class SupplyRequestController : BaseController
    {
        private readonly IMediator _mediatr;

        public SupplyRequestController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        //GET: SupplyRequest

        public async Task<IActionResult> Index()
        {
            return RedirectToAction("List", "SupplyRequest", new { id = UserId });
        }
        //GET: SupplyRequest
        public async Task<IActionResult> List(string id)
        {
            var list = await _mediatr.Send(new GetAllSupplyRequestsQuery(id));
            return View(list);
        }

        // GET: SupplyRequest/Details/5
        public async Task<IActionResult> Details(string id)
        {
            var supplyRequest = await _mediatr.Send(new GetSupplyRequestQuery(id, UserId));
            return View(supplyRequest);
        }

        // GET: SupplyRequest/Create
        public IActionResult Create()
        {
            var userId = UserId;
            return View();
        }

        // POST: SupplyRequest/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,Department")] CreateSupplyRequestCommand supplyRequest)
        {
            if (ModelState.IsValid)
            {
                supplyRequest.UserId = UserId;
                var result = await _mediatr.Send(supplyRequest);
                return RedirectToAction(nameof(Index));
            }
            return View(supplyRequest);
        }

        // GET: SupplyRequest/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            var supplyRequest = await _mediatr.Send(new GetSupplyRequestQuery(id, UserId));
            return View(supplyRequest);
        }

        // POST: SupplyRequest/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, EditSupplyRequestCommand supplyRequest)
        {
            if (id != supplyRequest.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                supplyRequest.UserId = UserId;
                await _mediatr.Send(supplyRequest);
                return RedirectToAction(nameof(Index));
            }
            return View(supplyRequest);
        }

        // GET: SupplyRequest/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            var supplyRequest = await _mediatr.Send(new GetSupplyRequestQuery(id, UserId));
            return View(supplyRequest);
        }

        // POST: SupplyRequest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _mediatr.Send(new DeleteSupplyRequestCommand(id, UserId));
            return RedirectToAction(nameof(Index));
        }

        //private bool SupplyRequestExists(string id)
        //{
        //  return (_context.SupplyRequests?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
