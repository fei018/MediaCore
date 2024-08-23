using MediaCore.ViewModel.Common;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace MediaCore.ViewModel.LocalMediaScan
{
    public class LocalMediaFile
    {
        public string Id { get; set; }

        [Display(Name = "文件名")]
        public string FileName { get; set; }

        [Display(Name = "文件Full名")]
        public string FileFullName { get; set; }

        [Display(Name = "文件擴展名")]
        public string FileExtention { get; set; }

        public MediaMimeTypeResult MineTypeResult { get; set; }

        public string Url { get; set; }

        public LocalMediaFile() { }

        public LocalMediaFile(string fullName, MediaMimeTypeResult mediaMime)
        {
            FileFullName = fullName;
            FileName = Path.GetFileName(fullName);
            FileExtention = Path.GetExtension(fullName);
            MineTypeResult = mediaMime;
        }
    }
}
