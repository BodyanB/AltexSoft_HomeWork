﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Models
{
    public class AdressDelivery : GoodsId
    {
        public int BuyerId { get; set; }
        public string CityName { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public string ApartmentNumber { get; set; } 
        public string PostCode { get; set; }
    }
}