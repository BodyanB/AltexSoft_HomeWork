using DeliveryService.Data;
using DeliveryService.Interfaces;
using DeliveryService.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace DeliveryService.Controller
{
    public class BuyerController : IBuyerController
    {
              
            private readonly IStoreContext _storeContext;
            private readonly ILogger _logger;

        public BuyerController(IStoreContext storeContext, ILogger logger)
            {
                _storeContext = storeContext;
                _logger = logger;
        }

        public void AddBuyer(Buyer buyer)
        {
            buyer.Id = _storeContext.Buyers.Count > 0 ? _storeContext.Buyers.Max(x => x.Id) + 1 : 1;

            _storeContext.Buyers.Add(buyer);
            _logger.Log($"Создан новый пользователь ({buyer.Email}).");
        }
      
    }
    }
