﻿namespace ST10102524_APPR6312_POE_PART_2.Models
{
    public class IncomingDataModel
    {
        public IEnumerable<Disaster> Disasters { get; set; }
        public IEnumerable<GoodsDonation> GoodsDonations { get; set; }
        public IEnumerable<MoneyDonation> MoneyDonations { get; set; }
    }
}
