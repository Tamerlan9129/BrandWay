﻿using Core.Entities;

namespace Business.ViewModels.Basket
{
    public class BasketIndexVM
    {
        public BasketIndexVM()
        {
            BasketProducts = new List<BasketProductVM>();
        }
        public List<BasketProductVM> BasketProducts { get; set; }

        public int BasketId { get; set; }
        public int Count { get; set; }

    }
}
