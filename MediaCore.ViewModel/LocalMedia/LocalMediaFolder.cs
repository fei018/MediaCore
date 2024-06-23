using System.Collections.Generic;

namespace MediaCore.ViewModel.LocalMedia
{
    public class LocalMediaFolder
    {
        public string Id { get; set; }

        public string ParentId { get; set; }

        /// <summary>
        /// 是否文件夾指定的根目錄
        /// </summary>
        public bool IsRoot { get; set; } = false;

        public List<LocalMediaFile> Files { get; set; } = new();

        /// <summary>
        /// 文件夾名
        /// </summary>
        public string FolderName { get; set; }

        public string FullPath { get; set; }


        public LocalMediaFolder(string fullPath)
        {
            FolderName = fullPath.Substring(fullPath.TrimEnd('\\').LastIndexOf('\\') + 1);

            FullPath = fullPath;
        }
    }
}
