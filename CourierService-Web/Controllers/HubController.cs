﻿using CourierService_Web.Data;
using CourierService_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourierService_Web.Controllers
{
    public class HubController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HubController(ApplicationDbContext context)
        {
            _context = context;
        }

        private void UpdateLayout()
        {
            //pickup request count
            var pickupRequestCount = _context.Parcels.Where(p => p.Status == "Pickup Request").Count();
            ViewBag.PickupRequestCount = pickupRequestCount;

            //total percel count according to hubId
            var hubId = Request.Cookies["HubId"];
            var totalParcelCount = _context.Parcels.Where(p => p.HubId == hubId).Count();
            ViewBag.TotalParcelCount = totalParcelCount;

            //delivered parcel count according to hubId
            var deliveredParcelCount = _context.Parcels.Where(p => p.HubId == hubId && p.DeliveryId != null).Count();
            ViewBag.DeliveredParcelCount = deliveredParcelCount;

           

            DateTime todayStart = DateTime.Today;
            DateTime tomorrowStart = todayStart.AddDays(1);
            //all parcel list for today
            var todayParcelList = _context.Parcels
                .Where(p => p.HubId == hubId && p.PickupRequestDate >= todayStart && p.PickupRequestDate < tomorrowStart).Include(u => u.Merchant).Include(u => u.Rider)
                .ToList();
            ViewBag.TodayParcelList = todayParcelList;

            //all parcel list for today count
            var todayParcelCount = todayParcelList.Count;
            ViewBag.TodayParcelCount = todayParcelCount;

            //return parcel count according to hubId
            var returnParcelCount = _context.Parcels.Where(p => p.HubId == hubId && p.ReturnId !=null).Count();
            ViewBag.ReturnParcelCount = returnParcelCount;

            //exchange parcel count according to hubId
            var exchangeParcelCount = _context.ExchangeParcels.Where(p => p.HubId == hubId).Count();
            ViewBag.ExchangeParcelCount = exchangeParcelCount;

            //parcel in hub count according to hubId
            var parcelInHubCount = _context.Parcels.Where(p => p.HubId == hubId && p.Status == "Parcel In Hub").Count();
            ViewBag.ParcelInHubCount = parcelInHubCount;

            //parcel Assigned A Rider For Pickup count according to hubId
            var parcelAssignedRiderForPickupCount = _context.Parcels.Where(p => p.HubId == hubId && p.Status == "Assigned A Rider For Pickup").Count();
            ViewBag.ParcelAssignedRiderForPickupCount = parcelAssignedRiderForPickupCount;

            //parcel Assigned For Delivery count according to hubId
            var parcelAssignedForDeliveryCount = _context.Parcels.Where(p => p.HubId == hubId && p.Status == "Assigned For Delivery").Count();
            ViewBag.ParcelAssignedForDeliveryCount = parcelAssignedForDeliveryCount;




        }

        //ishublogged in
        public bool IsHubLoggedIn()
        {
            if (Request.Cookies["HubId"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public IActionResult Index()
        {
            UpdateLayout();
            return View();
        }

        public IActionResult Parcel(DateTime? selectedDate)
        {
            if (!IsHubLoggedIn())
            {
                return RedirectToAction("Login", "Home");
            }
            var hubId = Request.Cookies["HubId"];
            IQueryable<Parcel> parcelsQuery = _context.Parcels
                .Where(x => x.HubId == hubId)
                .Include(u => u.Rider)
                .Include(m=>m.Merchant)
                .Include(h => h.Hub);

            if (!selectedDate.HasValue)
            {
                selectedDate = DateTime.Today;
            }

            parcelsQuery = parcelsQuery.Where(x => x.PickupRequestDate.Value.Date == selectedDate.Value.Date);

            var parcels = parcelsQuery.ToList();

            return View(parcelsQuery);
        }

        //Return parcel
        
        //Status - ReturnParcelInHub
        public IActionResult ReturnParcelHub(string id)
        {
            if (!IsHubLoggedIn())
            {
                return RedirectToAction("Login", "Home");
            }
            var returnParcel = _context.Parcels.Find(id);
            returnParcel.Status = "Return Parcel In Hub";
            _context.Parcels.Update(returnParcel);
            _context.SaveChanges();
            return RedirectToAction("ReturnParcel");
        }

        //status - ExchangeParcelHub
        public IActionResult ExchangeParcelHub(string id)
        {
            if (!IsHubLoggedIn())
            {
                return RedirectToAction("Login", "Home");
            }
            var exchangeParcel = _context.Parcels.Find(id);
            exchangeParcel.Status = "Exchange Parcel In Hub";
            _context.Parcels.Update(exchangeParcel);
            _context.SaveChanges();
            return RedirectToAction("ExchangeParcel");
        }
        //assign a parcel
        public IActionResult AssignParcel(string id)
        {

            if (!IsHubLoggedIn())
            {
                return RedirectToAction("Login", "Home");
            }

            // Find the parcel by ID
            var parcel = _context.Parcels.Find(id);
            if (parcel == null)
            {
                return NotFound();
            }

            // Get a list of available riders
            var riders = _context.Riders.Where(u => u.State == "Available");

            // Pass the list of riders to the view
            ViewBag.Riders = riders;


            return View(parcel);
        }

        public IActionResult AssignDeliveryRider(string id)
        {

            if (!IsHubLoggedIn())
            {
                return RedirectToAction("Login", "Home");
            }

            // Find the parcel by ID
            var parcel = _context.Parcels.Find(id);
            if (parcel == null)
            {
                return NotFound();
            }

            // Get a list of available riders
            var riders = _context.Riders.Where(u => u.State == "Available");

            // Pass the list of riders to the view
            ViewBag.Riders = riders;


            return View(parcel);
        }
        [HttpPost]
        public IActionResult AssignParcel(string id, string riderId)
        {
            if (!IsHubLoggedIn())
            {
                return RedirectToAction("Login", "Home");
            }


            // Find the parcel by ID
            var parcel = _context.Parcels.Find(id);
            if (parcel == null)
            {
                return NotFound();
            }

            // Find the rider by ID
            var rider = _context.Riders.Find(riderId);
            if (rider == null)
            {
                return NotFound();
            }

            // Assign the rider to the parcel
            parcel.Rider = rider;
            parcel.Status = "Assigned A Rider For Pickup";
            parcel.DispatchDate = DateTime.Now.Date;


            // Save changes to the database
            _context.SaveChanges();
            TempData["success"] = "Parcel Assigned Successfully";
            // Redirect to the parcel details page or any other desired page
            return RedirectToAction("Parcel", "Hub");
        }

        [HttpPost]
        public IActionResult AssignDeliveryRider(string id, string riderId)
        {
            if (!IsHubLoggedIn())
            {
                return RedirectToAction("Login", "Home");
            }


            // Find the parcel by ID
            var parcel = _context.Parcels.Find(id);
            if (parcel == null)
            {
                return NotFound();
            }

            // Find the rider by ID
            var rider = _context.Riders.Find(riderId);
            if (rider == null)
            {
                return NotFound();
            }

            // Assign the rider to the parcel
            parcel.Rider = rider;
            parcel.Status = "Assigned For Delivery";
            //parcel.DispatchDate = DateTime.Now.Date;


            // Save changes to the database
            _context.SaveChanges();
            TempData["success"] = "Assigned Successfully";
            // Redirect to the parcel details page or any other desired page
            return RedirectToAction("Parcel", "Hub");
        }

        //assignRiderToMerchant
        public IActionResult AssignRiderToMerchant(string id)
        {
            if (!IsHubLoggedIn())
            {
                return RedirectToAction("Login", "Home");
            }
            // Find the parcel by ID
            var parcel = _context.Parcels.Where(p=>p.Id == id).Include(m=>m.Merchant).FirstOrDefault();
            if (parcel == null)
            {
                return NotFound();
            }

            // Get a list of available riders
            var riders = _context.Riders.Where(u => u.State == "Available");

            // Pass the list of riders to the view
            ViewBag.Riders = riders;


            return View(parcel);
            
        }
        [HttpPost]
        public IActionResult AssignRiderToMerchant(string id, string riderId)
        {
            if (!IsHubLoggedIn())
            {
                return RedirectToAction("Login", "Home");
            }
            var parcel = _context.Parcels.Find(id);
            if (parcel == null)
            {
                return NotFound();
            }
            var rider = _context.Riders.Find(riderId);
            if (rider == null)
            {
                return NotFound();
            }
            parcel.Rider = rider;
            parcel.Status = "Assigned For Return Parcel";
            //parcel.DispatchDate = DateTime.Now.Date;
            _context.SaveChanges();
            TempData["success"] = "Assigned Rider For Return Parcel Successfully";
            return RedirectToAction("Parcel", "Hub");
        }

        //RiderForExchnage
        public IActionResult RiderForExchange(string id)
        {
            if (!IsHubLoggedIn())
            {
                return RedirectToAction("Login", "Home");
            }
            var parcel = _context.Parcels.Where(p => p.Id == id).Include(m => m.Merchant).FirstOrDefault();
            if (parcel == null)
            {
                return NotFound();
            }
            var riders = _context.Riders.Where(u => u.State == "Available");
            ViewBag.Riders = riders;
            return View(parcel);
        }
        [HttpPost]
        public IActionResult RiderForExchange(string id, string riderId)
        {
            if (!IsHubLoggedIn())
            {
                return RedirectToAction("Login", "Home");
            }
            var parcel = _context.Parcels.Find(id);
            if (parcel == null)
            {
                return NotFound();
            }
            var rider = _context.Riders.Find(riderId);
            if (rider == null)
            {
                return NotFound();
            }
            parcel.Rider = rider;
            parcel.Status = "Assigned For Exchange Parcel";
            _context.SaveChanges();
            TempData["success"] = "Assigned Rider For Exchange Parcel Successfully";
            return RedirectToAction("Parcel", "Hub");
        }


        //status change to Parcel In Hub
        public IActionResult ParcelInHub(string id)
        {
            if (!IsHubLoggedIn())
            {

                return RedirectToAction("Login", "Home");
            }

            //var riderId = HttpContext.Request.Cookies["RiderId"];
            ////find rider by riderId
            //var rider = _context.Riders.Find(riderId);
            var parcel = _context.Parcels.Find(id);
            parcel.Status = "Parcel In Hub";
            parcel.DeliveryDate = DateTime.Now.Date;
            //rider.State = "Available";
            _context.Parcels.Update(parcel);
            //_context.Riders.Update(rider);
            _context.SaveChanges();
            return RedirectToAction("Parcel");
        }

        //Profile
        public IActionResult Profile()
        {
            if (!IsHubLoggedIn())
            {
                return RedirectToAction("Login", "Home");
            }
            var hubId = Request.Cookies["HubId"];
            var hub = _context.Hubs.FirstOrDefault(h => h.Id == hubId);
            if (hub == null)
            {
                return NotFound();
            }
            return View(hub);
        }

        //delivery parcel list
        public IActionResult DeliveredParcelList(DateTime? selectedDate)
        {
            if (!IsHubLoggedIn())
            {
                return RedirectToAction("Login", "Home");
            }
            var hubId = Request.Cookies["HubId"];
            IQueryable<Parcel> deliveredParcelsQuery = _context.Parcels
                .Where(x => x.HubId == hubId && x.DeliveryId != null)
                .Include(x => x.DeliveryParcel)
                .Include(x => x.Rider)
                .Include(h => h.Hub);

            if (!selectedDate.HasValue)
            {
                selectedDate = DateTime.Today;
            }

            deliveredParcelsQuery = deliveredParcelsQuery.Where(x => x.DeliveryParcel.DeliveryDate.Date == selectedDate.Value.Date);
            var deliveredParcels = deliveredParcelsQuery.ToList();
            return View(deliveredParcels);
        }

        //return parcel list
        public IActionResult ReturnParcelList(DateTime? selectedDate)
        {
            if (!IsHubLoggedIn())
            {
                return RedirectToAction("Login", "Home");
            }
            var hubId = Request.Cookies["HubId"];
            IQueryable<Parcel> returnParcelsQuery = _context.Parcels
                .Where(x => x.HubId == hubId && x.ReturnId != null)
                .Include(x => x.ReturnParcel)
                .Include(x => x.Rider)
                .Include(h => h.Hub);

            if (!selectedDate.HasValue)
            {
                selectedDate = DateTime.Today;
            }
            returnParcelsQuery = returnParcelsQuery.Where(x => x.ReturnParcel.ReturnDate.Date == selectedDate.Value.Date);
            var returnParcels = returnParcelsQuery.ToList();

            return View(returnParcels);
        }

        //exchange parcel list
        public IActionResult ExchangeParcelList(DateTime? selectedDate)
        {
            if (!IsHubLoggedIn())
            {
                return RedirectToAction("Login", "Home");
            }
            var hubId = Request.Cookies["HubId"];
            IQueryable<Parcel> exchangeParcelsQuery = _context.Parcels
                .Where(x => x.HubId == hubId && x.ExchangeId != null)
                .Include(x => x.ExchangeParcel)
                .Include(x => x.Rider)
                .Include(h => h.Hub);
            if (!selectedDate.HasValue)
            {
                selectedDate = DateTime.Today;
            }
            exchangeParcelsQuery = exchangeParcelsQuery.Where(x => x.ExchangeParcel.ExchangeDate.Date == selectedDate.Value.Date);
            var exchangeParcels = exchangeParcelsQuery.ToList();
            return View(exchangeParcels);
        }

        public IActionResult PaymentInHand(string? id)
        {
            if (!IsHubLoggedIn())
            {
                return RedirectToAction("Login", "Home");
            }

            if (id == null)
            {
                return NotFound();
            }

            var parcel = _context.Parcels.Find(id);
            if (parcel == null)
            {
                return NotFound();
            }

            parcel.PaymentInHand = "PaymentInHand";
            _context.Parcels.Update(parcel);
            _context.SaveChanges();

            TempData["success"] = "Payment In Hand";
            return RedirectToAction("Parcel");
        }

        public IActionResult PaymentNotInHand(string? id)
        {
            if (!IsHubLoggedIn())
            {
                return RedirectToAction("Login", "Home");
            }

            if (id == null)
            {
                return NotFound();
            }

            var parcel = _context.Parcels.Find(id);
            if (parcel == null)
            {
                return NotFound();
            }

            parcel.PaymentInHand = "PaymentNotInHand";
            TempData["success"] = "Payment Not In Hand";
            _context.Parcels.Update(parcel);
            _context.SaveChanges();

            TempData["success"] = "Payment Payment In Hand";
            return RedirectToAction("Parcel");
        }

        //PaymentMerchant
        public IActionResult PaymentMerchant(string? id)
        {
            if (!IsHubLoggedIn())
            {
                return RedirectToAction("Login", "Home");
            }

            if (id == null)
            {
                return NotFound();
            }

            var parcel = _context.Parcels.Find(id);
            if (parcel == null)
            {
                return NotFound();
            }

            parcel.PaymentStatus = "Paid To Merchant";
            _context.Parcels.Update(parcel);
            _context.SaveChanges();

            TempData["success"] = "Payment Merchant";
            return RedirectToAction("Parcel");
        }

        //PaymentDeliveryCharge
        public IActionResult PaymentDeliveryCharge(string? id)
        {
            if (!IsHubLoggedIn())
            {
                return RedirectToAction("Login", "Home");
            }

            if (id == null)
            {
                return NotFound();
            }

            var parcel = _context.Parcels.Find(id);
            if (parcel == null)
            {
                return NotFound();
            }

            parcel.PaymentStatus = "Paid Delivery Charge To Merchant";
            _context.Parcels.Update(parcel);
            _context.SaveChanges();

            TempData["success"] = "Payment Delivery Charge";
            return RedirectToAction("Parcel");
        }
    }
}
