﻿namespace BidCalculatorApi.Model
{
        public class FeeCalculationResult
        {
            public decimal BasePrice { get; set; }
            public decimal BasicFee { get; set; }
            public decimal SpecialFee { get; set; }
            public decimal AssociationFee { get; set; }
            public decimal StorageFee { get; set; }
            public decimal TotalCost { get; set; }
        }
}


