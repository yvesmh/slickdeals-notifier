﻿using System;
namespace SlickDealsNotifier
{
    public class Deal
    {
        public int DealId { get; set; }
        public string Title { get; set; }
        public string Store { get; set; }
        public string Price { get; set; }
        public int Votes { get; set; }
        public bool IsFire { get; set; }
        public string Url { get; set; }
    }
}
