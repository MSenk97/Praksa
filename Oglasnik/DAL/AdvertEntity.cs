﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AdvertEntity
    {
        public int AdvertID { get; set; }
        public int CategoryID { get; set; }

        public string Title { get; set; }

        public int Price { get; set; }

        public string Condition { get; set; }

        public string Description { get; set; }

        public int DeliveryID { get; set; }

        public int UserID { get; set; }
    }
}