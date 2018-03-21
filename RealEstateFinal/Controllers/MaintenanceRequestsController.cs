using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RealEstateFinal.Data;
using RealEstateFinal.Models;

namespace RealEstateFinal.Controllers
{


    public class MaintenanceRequestsController : Controller
    {

        private bool DoesRequestExist(int id)
        {
            return reqcontext.MaintenanceRequests.Any(e => e.ID == id);
        }


        private readonly ApplicationDbContext reqcontext;

        public MaintenanceRequestsController(ApplicationDbContext ctx)
        {
            reqcontext = ctx;
        }

        public async Task<IActionResult> Index()
        {
            return View(await reqcontext.MaintenanceRequests.ToListAsync());
        }


        [Authorize(Roles = "registered user")]
        public IActionResult Create()
        {
            return View();
        }


        public IActionResult Confirm()
        {
            return View();
        }







        [HttpPost]
        public async Task<IActionResult> Create([Bind("ID,Requestor,PropertyAddress,UnitNumber,Description,DateRequested")] MaintenanceRequest maintenanceRequest)
        {
            if (ModelState.IsValid)
            {
                reqcontext.Add(maintenanceRequest);
                await reqcontext.SaveChangesAsync();
                return RedirectToAction(nameof(Confirm));
            }
            return View(maintenanceRequest);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }



            var maintenanceRequest = await reqcontext.MaintenanceRequests.SingleOrDefaultAsync(m => m.ID == id);




            if (maintenanceRequest == null)
            {

                return NotFound();
            }
            return View(maintenanceRequest);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Requestor,PropertyAddress,UnitNumber,Description,DateRequested")] MaintenanceRequest maintenanceRequest)
        {


            if (id != maintenanceRequest.ID)
            {

                return NotFound();
            }

            if (ModelState.IsValid)
            {

                try
                {
                    reqcontext.Update(maintenanceRequest);
                    await reqcontext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoesRequestExist(maintenanceRequest.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Confirm));
            }
            return View(maintenanceRequest);
        }


       

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var maintenanceRequest = await reqcontext.MaintenanceRequests.SingleOrDefaultAsync(m => m.ID == id);
            reqcontext.MaintenanceRequests.Remove(maintenanceRequest);
            await reqcontext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maintenanceRequest = await reqcontext.MaintenanceRequests
                .SingleOrDefaultAsync(m => m.ID == id);
            if (maintenanceRequest == null)
            {
                return NotFound();
            }

            return View(maintenanceRequest);
        }
    }
}
