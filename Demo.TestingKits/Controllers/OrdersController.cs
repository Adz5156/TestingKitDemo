using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.TestingKits.Factories;
using Demo.TestingKits.Models;
using Demo.TestingKits.Entites;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Demo.TestingKits.Services;
using Demo.TestingKits.Services.Jobs;
using Microsoft.Extensions.Logging;

namespace Demo.TestingKits.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IProcessingManager _processingManager;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IProcessingManager processingManager, ILogger<OrdersController> logger)
        {
            _processingManager = processingManager;
            _logger = logger;
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View(new OrderViewModel());
        }

        public IActionResult Success()
        {
            ViewData["PendingOrders"] = _processingManager.CountPendingJobs.ToString();
            return View();
        }

        [HttpPost]
        public IActionResult Create(OrderViewModel vm)
        {
            //Check is vm Valid
            if (!ModelState.IsValid) return View(vm);

            try
            {
                //Configure the testing kit
                var TestingKit = TestingKitFactory.CreateTestingKit(vm.SelectedTestTypes.ToArray());
                var Order = new Order
                {
                    Name = vm.Name,
                    HouseNameOrNo = vm.HouseNameOrNo,
                    Street = vm.Street,
                    PostCode = vm.PostCode,
                    Email = vm.Email,
                    TelephoneNo = vm.TelephoneNo,
                    TestingKitUid = TestingKit.Uid,
                    TestingKit = TestingKit
                };

                var DispatchRequest = new Dispatch(Order);
                _processingManager.AddJobs(DispatchRequest);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return RedirectToAction("Error");
            }

            return RedirectToAction("Success");

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}