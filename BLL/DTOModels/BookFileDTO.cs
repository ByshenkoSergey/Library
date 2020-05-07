using System;

namespace BLL.DTOModels
{
    public class BookFileDTO
    {
        public Guid BookId { get; set; }
        public string BookName { get; set; }
        public string BookFilePath { get; set; }
        public string ContentType { get; set; }
              
    }
}
