//using System;
//using System.IO;

//namespace MediaCore.ViewModel.LocalMedia
//{
//    public class LocalMediaHelper
//    {
//        /// <summary>
//        /// 編碼 全字符集
//        /// </summary>
//        /// <param name="path"></param>
//        /// <returns></returns>
//        public static string EncodePath(string path)
//        {
//            return Uri.EscapeDataString(path);
//        }

//        /// <summary>
//        /// 解碼 全字符集
//        /// </summary>
//        /// <param name="path"></param>
//        /// <returns></returns>
//        public static string DecodePath(string path)
//        {
//            return Uri.UnescapeDataString(path);
//        }

//        /// <summary>
//        /// 編碼 文件路徑的, 可以 Url 訪問
//        /// </summary>
//        /// <param name="path"></param>
//        /// <returns></returns>
//        public static string EncodeFilePathUrl(string path)
//        {
//#pragma warning disable SYSLIB0013 // 類型或成員已經過時
//            return Uri.EscapeUriString(path.Replace('\\', '/'));
//#pragma warning restore SYSLIB0013 // 類型或成員已經過時
//        }

//        //public static string CutMediaRootPath(string sysFullPath)
//        //{
//        //    //return sysFullPath.Substring(SysMediaConfig.SysMediaRootPath.Length).TrimStart('\\');
//        //    return sysFullPath.Replace(LocalMediaSetting.SysMediaRootPath, string.Empty, StringComparison.OrdinalIgnoreCase).TrimStart('\\');
//        //}

//        /// <summary>
//        /// 由相對路徑獲得系統全路徑
//        /// </summary>
//        /// <param name="relativePath"></param>
//        /// <returns></returns>
//        //public static string GetSysFullPath(string relativePath)
//        //{
//        //    return Path.Combine(LocalMediaSetting.SysMediaRootPath, relativePath);
//        //}

//        //public static bool IsMediaRootPath(string path)
//        //{
//        //    if (!string.IsNullOrEmpty(path))
//        //    {
//        //        string root = LocalMediaSetting.SysMediaRootPath.Trim().TrimEnd('\\').ToLower();
//        //        string current = path.Trim()?.TrimEnd('\\')?.ToLower();

//        //        if (root == current)
//        //        {
//        //            return true;
//        //        }
//        //        else
//        //        {
//        //            return false;
//        //        }
//        //    }

//        //    throw new Exception(nameof(LocalMediaSetting.SysMediaRootPath) + " 路徑 IsNullOrEmpty.");
//        //}
//    }
//}
