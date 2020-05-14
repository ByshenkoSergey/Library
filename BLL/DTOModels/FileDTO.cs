using System;
using System.IO;

namespace BLL.DTOModels
{
    public class FileDTO
    {
        public string FileName { get; set; }
        public MemoryStream File { get; set; }
       public string FileType { get; set; }
    }
}
