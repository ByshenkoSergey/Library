using DAL.Models;
using System;
using System.Collections.Generic;

namespace DAL.FailData
{
    public class PublisherData
    {
        public static IEnumerable<Publisher> GetPublishersData()
        {
            yield return new Publisher
            {
                PublisherId = new Guid("e40037b136b24671bd1df0784e1299bf"),
                PublisherName = "New word",
                PublisherInfo = "Fusce eget eros pretium, dictum tellus eu, luctus nulla. Cras lacinia facilisis tortor, eleifend condimentum metus facilisis quis.+" +
                "Nullam libero ipsum, pretium nec volutpat eget, ultrices non velit. Sed nisi lectus, fermentum et elit at, mollis interdum purus. Nullam orci elit," +
                "posuere non suscipit eget, fringilla ac diam. Praesent cursus, leo ut lacinia cursus, ipsum est tempor odio, ac laoreet ex metus non massa. " +
                "Duis imperdiet quis erat vel bibendum.",
                PublisherEmail = @"NewWord@gmail.com",
                PublisherTellNumber = @"+38 (095) 111-11-11"
            };

            yield return new Publisher
            {
                PublisherId = new Guid("e1ad8ea860194250893d41372a755c05"),
                PublisherName = "Pen and pensile",
                PublisherInfo = "Fusce eget eros pretium, dictum tellus eu, luctus nulla. Cras lacinia facilisis tortor, eleifend condimentum metus facilisis quis.+" +
                "Nullam libero ipsum, pretium nec volutpat eget, ultrices non velit. Sed nisi lectus, fermentum et elit at, mollis interdum purus. Nullam orci elit," +
                "posuere non suscipit eget, fringilla ac diam. Praesent cursus, leo ut lacinia cursus, ipsum est tempor odio, ac laoreet ex metus non massa. " +
                "Duis imperdiet quis erat vel bibendum.",
                PublisherEmail = @"PenPen@gmail.com",
                PublisherTellNumber = @"+38 (095) 222-22-22"
            };

            yield return new Publisher
            {
                PublisherId = new Guid("5a8f4495ac8f4eccbeb258409180073b"),
                PublisherName = "ABSDE",
                PublisherInfo = "Fusce eget eros pretium, dictum tellus eu, luctus nulla. Cras lacinia facilisis tortor, eleifend condimentum metus facilisis quis.+" +
                "Nullam libero ipsum, pretium nec volutpat eget, ultrices non velit. Sed nisi lectus, fermentum et elit at, mollis interdum purus. Nullam orci elit," +
                "posuere non suscipit eget, fringilla ac diam. Praesent cursus, leo ut lacinia cursus, ipsum est tempor odio, ac laoreet ex metus non massa. " +
                "Duis imperdiet quis erat vel bibendum.",
                PublisherEmail = @"absde@gmail.com",
                PublisherTellNumber = @"+38 (095) 333-33-33"
            };

            yield return new Publisher
            {
                PublisherId = new Guid("35b6fdeac2aa4edfaf6e655aa1eb06a5"),
                PublisherName = "Hape books",
                PublisherInfo = "Fusce eget eros pretium, dictum tellus eu, luctus nulla. Cras lacinia facilisis tortor, eleifend condimentum metus facilisis quis.+" +
                "Nullam libero ipsum, pretium nec volutpat eget, ultrices non velit. Sed nisi lectus, fermentum et elit at, mollis interdum purus. Nullam orci elit," +
                "posuere non suscipit eget, fringilla ac diam. Praesent cursus, leo ut lacinia cursus, ipsum est tempor odio, ac laoreet ex metus non massa. " +
                "Duis imperdiet quis erat vel bibendum.",
                PublisherEmail = @"hbooks@gmail.com",
                PublisherTellNumber = @"+38 (095) 999-99-99"
            };
        }
    }
}