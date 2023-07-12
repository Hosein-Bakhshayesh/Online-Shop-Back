using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityShopProject.Shared.Models
{
    public class ImageFile
    {
        public FileData Files { get; set; }

    }
    public class FileData
    {
        public string FileName { get; set; }
        public byte[] Data { get; set; }
        public string FileType { get; set; }
        public long Size { get; set; }
    }
}
