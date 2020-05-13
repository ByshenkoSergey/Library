using System;
using System.IO;

namespace BLL.DTOModels
{
    public class FileDTO
    {
        public string FileName { get; set; }
        public object File { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
    }
}
