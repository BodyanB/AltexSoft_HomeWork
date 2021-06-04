//using DeliveryService.Data;
using DeliveryService.Interfaces;
using DeliveryService.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace DeliveryService.Controller
{
    public class BuyerController : IBuyerController
    {
              
            private readonly IStoreContext storeContext;

            public BuyerController(IStoreContext storeContext)
            {
                this.storeContext = storeContext;
            }

        public void AddBuyer(Buyer buyer)
        {
            buyer.Id = storeContext.Buyers.Count > 0 ? storeContext.Buyers.Max(x => x.Id) + 1 : 1;

            storeContext.Buyers.Add(buyer);
        }
      
    }
    }
