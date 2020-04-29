using DAL.Models;
using System;
using System.Collections.Generic;

namespace DAL.FailData
{
    public class PublishingHousesData
    {
        public static IEnumerable<PublishingHouse> GetPublishingHousesData()
        {
            
            yield return new PublishingHouse
            {
                PublishingHouseId = new Guid("e40037b136b24671bd1df0784e1299bf"),
                PublishingHouseName = "New word",
                PublishingHouseInfo = "...Text...",
                PublishingHouseEmail = @"NewWord@gmail.com",
                PublishingHouseTellNumber = @"+38 (095) 111-11-11"
            };

            yield return new PublishingHouse
            {
                PublishingHouseId = new Guid("e1ad8ea860194250893d41372a755c05"),
                PublishingHouseName = "Pen and pensile",
                PublishingHouseInfo = "...Text...",
                PublishingHouseEmail = @"PenPen@gmail.com",
                PublishingHouseTellNumber = @"+38 (095) 222-22-22"
            };

            yield return new PublishingHouse
            {
                PublishingHouseId = new Guid("5a8f4495ac8f4eccbeb258409180073b"),
                PublishingHouseName = "ABSDE",
                PublishingHouseInfo = "...Text...",
                PublishingHouseEmail = @"absde@gmail.com",
                PublishingHouseTellNumber = @"+38 (095) 333-33-33"
            };

            yield return new PublishingHouse
            {
                PublishingHouseId = new Guid("35b6fdeac2aa4edfaf6e655aa1eb06a5"),
                PublishingHouseName = "Hape books",
                PublishingHouseInfo = "...Text...",
                PublishingHouseEmail = @"hbooks@gmail.com",
                PublishingHouseTellNumber = @"+38 (095) 999-99-99"
            };
        }
    }
}