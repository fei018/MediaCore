using MediaCore.Model.LocalMedia;
using MediaCore.ViewModel.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WalkingTec.Mvvm.Core;

namespace MediaCore.ViewModel.LocalMedia
{
    public class LocalMediaScanner : BaseVM
    {
        private static List<LocalMediaFolder> LocalMediaFolderStorage { get; set; }

        private static List<LocalMediaFile> LocalMediaFileStorage { get; set; }

        // ---------

        private List<LocalMediaFolder> _folderList { get; } = new();

        private List<string> _fileExtentions { get; set; } = ["*"];

        #region InitVM
        protected override void InitVM()
        {
            //if (Wtm.ConfigInfo.AppSettings.TryGetValue("SysMediaFileExtention", out string ext))
            //{
            //    if (!string.IsNullOrWhiteSpace(ext))
            //    {
            //        if (ext.Contains(','))
            //        {
            //            _fileExtention = [.. ext.Split(',')];
            //        }
            //        else
            //        {
            //            _fileExtention = [ext];
            //        }
            //    }
            //}

            var config = DC.Set<LocalMediaConfig>().AsNoTracking().SingleOrDefault();
            if (config != null && !string.IsNullOrWhiteSpace(config.MediaFileExtention))
            {
                if (config.MediaFileExtention.Contains(','))
                {
                    _fileExtentions = config.MediaFileExtention.Split(',').ToList();
                }
                else
                {
                    _fileExtentions = [config.MediaFileExtention];
                }
            }
        }

        #endregion

        #region GetFoldersByPath
        private List<LocalMediaFolder> GetFoldersByDir(string sysFullPath)
        {
            var list = new List<LocalMediaFolder>();

            var dirs = Directory.EnumerateDirectories(sysFullPath).Order().ToList();

            if (dirs.Count > 0)
            {
                foreach (var dir in dirs)
                {
                    var f = new LocalMediaFolder(dir);

                    list.Add(f);
                }
            }

            return list;
        }
        #endregion

        #region GetFilesByFolder
        private List<LocalMediaFile> GetFilesByDir(string sysfolderPath)
        {
            var list = new List<LocalMediaFile>();

            foreach (var ext in _fileExtentions)
            {
                string pattern = null;
                if (ext == "*")
                {
                    pattern = "*";
                }
                else
                {
                    pattern = "*." + ext;
                }

                var files = Directory.EnumerateFiles(sysfolderPath, pattern, SearchOption.TopDirectoryOnly).Order().ToList();

                if (files != null || files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        string fileExt = Path.GetExtension(file).TrimStart('.');

                        if (MediaFileMimeTypeHelper.TryGet(fileExt, out var mimeType))
                        {
                            var media = new LocalMediaFile(file, mimeType)
                            {
                                Id = Guid.NewGuid().ToString(),
                            };
                            list.Add(media);
                        }
                    }
                }
            }

            return list;
        }
        #endregion

        #region ToScan
        private List<LocalMediaFolder> ToScan(string rootPath)
        {
            _folderList?.Clear();

            if (!Directory.Exists(rootPath))
            {
                throw new Exception($"\"{rootPath}\" is not exist.");
            }

            var subDirs = GetFoldersByDir(rootPath);
            var subFiles = GetFilesByDir(rootPath);

            var folder = new LocalMediaFolder(rootPath)
            {
                Id = Guid.NewGuid().ToString(),
                IsRoot = true,
                Files = subFiles
            };

            _folderList.Add(folder);

            foreach (var dir in subDirs)
            {
                RecursiveDir(dir.FullPath, folder.Id);
            }

            return _folderList;
        }
        #endregion

        #region RecursiveDir
        private void RecursiveDir(string currentDir, string parentId)
        {
            if (!Directory.Exists(currentDir))
            {
                return;
            }

            var subDirs = GetFoldersByDir(currentDir);
            var files = GetFilesByDir(currentDir);

            var vm = new LocalMediaFolder(currentDir)
            {
                Id = Guid.NewGuid().ToString(),
                IsRoot = false,
                Files = files,
                ParentId = parentId,
            };

            _folderList.Add(vm);

            if (subDirs.Count > 0)
            {
                foreach (var dir in subDirs)
                {
                    RecursiveDir(dir.FullPath, vm.Id);
                }
            }
        }
        #endregion

        #region public ReScan()
        public void ReScan()
        {
            var rootDirs = DC.Set<LocalMediaInfo>().ToList();

            if (rootDirs == null || rootDirs.Count <= 0)
            {
                throw new ArgumentException(nameof(LocalMediaInfo) + " is null of database.");
            }

            if (LocalMediaFolderStorage == null)
            {
                LocalMediaFolderStorage = new();
            }
            else
            {
                LocalMediaFolderStorage.Clear();
            }

            for (int i = 0; i < rootDirs.Count; i++)
            {
                if (!string.IsNullOrEmpty(rootDirs[i].MediaRootPath))
                {
                    var folderList = ToScan(rootDirs[i].MediaRootPath);
                    LocalMediaFolderStorage.AddRange(folderList);
                }
            }

            if (LocalMediaFolderStorage.Count <= 0)
            {
                throw new Exception("ReScan():" + nameof(LocalMediaFolderStorage) + ".Count is 0.");
            }

            if (LocalMediaFileStorage == null)
            {
                LocalMediaFileStorage = new();
            }
            else
            {
                LocalMediaFileStorage.Clear();
            }

            for (int i = 0; i < LocalMediaFolderStorage.Count; i++)
            {
                LocalMediaFileStorage.AddRange(LocalMediaFolderStorage[i].Files);
            }
        }
        #endregion

        // ----------

        #region public GetLocalMediaFolderStorage
        public List<LocalMediaFolder> GetLocalMediaFolderStorage()
        {
            if (LocalMediaFolderStorage == null || LocalMediaFolderStorage.Count <= 0)
            {
                ReScan();
            }

            return LocalMediaFolderStorage;
        }
        #endregion

        #region GetLocalMediaFileStorage
        public List<LocalMediaFile> GetLocalMediaFileStorage()
        {
            return LocalMediaFileStorage;
        }
        #endregion
    }
}
