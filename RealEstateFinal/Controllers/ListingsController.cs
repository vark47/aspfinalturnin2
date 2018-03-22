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
    public class ListingsController : Controller
    {
        private readonly ApplicationDbContext dbcontxt;

        public ListingsController(ApplicationDbContext context)
        {
            dbcontxt = context;
        }

        private bool DoesListingExist(int id)
        {
            return dbcontxt.Listings.Any(e => e.ID == id);
        }

        public async Task<IActionResult> Index(string searchString)
        {
            // creates linq query for search
            var listings = from l in dbcontxt.Listings
                         select l;
            //simple check to see if search string exists

            if (!String.IsNullOrEmpty(searchString))
            {
                listings = listings.Where(s => s.Title.Contains(searchString));
            }

            //sends data to page
            // return View(await dbcontxt.Listings.ToListAsync());
            return View(await listings.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)

        {
            if (id == null)
            {
                return NotFound();
            }

            var listing = await dbcontxt.Listings

                .SingleOrDefaultAsync(m => m.ID == id);



            if (listing == null)
            {

                return NotFound();

            }

            return View(listing);
        }
        [Authorize(Roles ="admin")]
        public IActionResult CreateListing()
        {
            return View();
        }
        
        [HttpPost]

     
        public async Task<IActionResult> Create([Bind("ID,Body,Title,Rent,ImgURL,Beds,Baths,AvailableNow")] Listing listing)
        {
            if (ModelState.IsValid)
            {
                dbcontxt.Add(listing);
                await dbcontxt.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(listing);
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var listing = await dbcontxt.Listings.SingleOrDefaultAsync(m => m.ID == id);

            if (listing == null)
            {


                return NotFound();
            }
            return View(listing);
        }
        [HttpPost]

        public async Task<IActionResult> Edit(int id, [Bind("ID,Body,Title,Rent,ImgURL,Beds,Baths,AvailableNow")] Listing listing)
        {
            if (id != listing.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    dbcontxt.Update(listing);

                    await dbcontxt.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoesListingExist(listing.ID))
                    {
                        return NotFound();
                    }
                    else
                    {


                        throw;



                    }

                }
                return RedirectToAction(nameof(Index));
            }
            return View(listing);
        }
        [Authorize(Roles = "admin")]


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)

            {
                return NotFound();
            }

            var listing = await dbcontxt.Listings

                .SingleOrDefaultAsync(m => m.ID == id);
            if (listing == null)
            {
                return NotFound();
            }

            return View(listing);
        }

        [HttpPost, ActionName("Delete")]
   
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listing = await dbcontxt.Listings.SingleOrDefaultAsync(m => m.ID == id);
            dbcontxt.Listings.Remove(listing);

            await dbcontxt.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
    }
}
