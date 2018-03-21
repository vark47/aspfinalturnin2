using RealEstateFinal.Models;
using System;
using System.Linq;
using RealEstateFinal.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace RealEstateFinal.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider services)
        {
            ApplicationDbContext context = services.GetRequiredService<ApplicationDbContext>();
            context.Database.EnsureCreated();
            if (!context.Listings.Any())
            {
                //Image image = new Image { ImageID = 1, URL = "~/images/home1.jpg" }; 
                //context.Images.Add(image);
                //context.SaveChanges();      
                Listing listing = new Listing { ImgURL = "/images/home1.jpg", Baths = 1.5, Beds = 2, AvailableNow = true, Body = "This place hardly hasn't had no murders in it.", Rent = 1300.00m, Title = "Awesome Bungalow in Detroit" };
                context.Listings.Add(listing);
                Listing listing2 = new Listing { ImgURL = "/images/home2.jpg", Baths = 1, Beds = 5, AvailableNow = false, Body = "Only 10 visits from the police this month", Rent = 800.00m, Title = "Sweet Diggs in a Not So Great Area" };
                context.Listings.Add(listing2);
                Listing listing3 = new Listing { ImgURL = "/images/home3.jpg", Baths = 1, Beds = 2, AvailableNow = true, Body = "Sadly this is the best part of town", Rent = 900.00m, Title = "The Best in the West" };
                context.Listings.Add(listing3);
                Listing listing4 = new Listing { ImgURL = "/images/home4.jpg", Baths = 2, Beds = 2, AvailableNow = false, Body = "We accept felons!", Rent = 2000.00m, Title = "This One Has Most of its Floorboards" };
                context.Listings.Add(listing4);
                Listing listing5 = new Listing { ImgURL = "/images/home5.jpg", Baths = 6, Beds = 2, AvailableNow = true, Body = "Why are you even still considering renting from us?", Rent = 1100.00m, Title = "Needs Some Paint" };
                context.Listings.Add(listing5);
                Listing listing6 = new Listing { ImgURL = "/images/home6.jpg", Baths = 2, Beds = 2, AvailableNow = false, Body = "The perfect location to open your new laboritory", Rent = 2000.00m, Title = "Probably an industrial site of some kind" };
                context.Listings.Add(listing6);
                Listing listing7 = new Listing { ImgURL = "/images/home7.jpg", Baths = 1, Beds = 1, AvailableNow = true, Body = "The real RV from Breaking Bad", Rent = 900.00m, Title = "Live in a set from a real TV show" };
                context.Listings.Add(listing7);

                



            // Add code to initialize context tables


            //Listing listing2 = new Listing { Body = "A beautiful place to get away from law enforcement.", Rent = 1100.00m, Title = "Another Awesome House" };
            // context.Listings.Add(listing2);



            //image.Listings.Add(listing);




            context.SaveChanges(); // save the last addition
            }





             ApplicationDbContext context2 = services.GetRequiredService<ApplicationDbContext>();
              context2.Database.EnsureCreated();
              if (!context2.MaintenanceRequests.Any())
              {
               
                MaintenanceRequest request = new MaintenanceRequest {  Requestor = "John Smith", PropertyAddress = "420 Highway 69", UnitNumber = 41, Description = "There are squatters in the basement again", DateRequested = new DateTime(2017, 1, 18) };
                  context2.MaintenanceRequests.Add(request);
                  MaintenanceRequest request2 = new MaintenanceRequest {  Requestor = "Bill Smith", PropertyAddress = "76 Highway 361", UnitNumber = 12, Description = "The roof caved in AGAIN", DateRequested = new DateTime(2017, 12, 31) };
                  context2.MaintenanceRequests.Add(request2);
                  MaintenanceRequest request3 = new MaintenanceRequest {  Requestor = "Hans Richmoind", PropertyAddress = "3621 Hanover St", UnitNumber = 31, Description = "The meth lab next door exploded", DateRequested = new DateTime(2018, 1, 1) };
                  context2.MaintenanceRequests.Add(request3);
                  MaintenanceRequest request4 = new MaintenanceRequest { Requestor = "Shia Lebough", PropertyAddress = "362 JUST DO IT Ave", UnitNumber = 31, Description = "JUST DO IT", DateRequested = new DateTime(2018, 1, 2) };
                  context2.MaintenanceRequests.Add(request4);
                  MaintenanceRequest request5 = new MaintenanceRequest {  Requestor = "A concerned citizen", PropertyAddress = "362 JUST DO IT Ave", UnitNumber = 32, Description = "The crazy guy next door wont stop screaming JUST DO IT all night", DateRequested = new DateTime(2018, 1, 2) };
                  context2.MaintenanceRequests.Add(request5);
                  context2.SaveChanges(); // save the last addition




              }


           /* ApplicationDbContext context3 = services.GetRequiredService<ApplicationDbContext>();
            context3.Database.EnsureCreated();
            if (!context3.Users.Any())
            {

                ApplicationUser user1 = new ApplicationUser();
                user1.Email = "admin@example.com";
                user1.UserName = "admin@example.com";
                user1.PasswordHash = "password";
                user1.Role



            }*/

          
            
        }

    }
    }


