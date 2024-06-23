using MediaCore.Extentions;
using MediaCore.ViewModel.LocalMedia;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Mvc;

namespace MediaCore.Controllers
{
    [NoLog]
    [Public]
    public class MediaController : BaseController
    {
        #region Local
        public IActionResult LocalIndex()
        {
            var scanner = Wtm.CreateVM<LocalMediaScanner>();
            var vm = scanner.GetLocalMediaFolderStorage();
            return View(vm);
        }

        public IActionResult LocalTop()
        {
            var scanner = Wtm.CreateVM<LocalMediaScanner>();
            var list = scanner.GetLocalMediaFolderStorage();
            var vm = list.Where(x => x.IsRoot).ToList();
            return PartialView(vm);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">LocalMediaFolder id</param>
        /// <returns></returns>
        public IActionResult LocalList(string id)
        {
            var scanner = Wtm.CreateVM<LocalMediaScanner>();
            var list = scanner.GetLocalMediaFolderStorage();

            if (string.IsNullOrEmpty(id))
            {
                var tops = list.Where(x => x.IsRoot).ToList();
                return PartialView("LocalTop", tops);
            }

            var vm = list.SingleOrDefault(x => x.Id == id);

            if (vm == null)
            {
                return this.ErrorView("LocalMediaFolder id is not found in LocalMediaFolderStorage. id: " + id);
            }
            else
            {
                return PartialView(vm);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">LocalMediaFile id</param>
        /// <returns></returns>
        public IActionResult LocalPlay(string id)
        {
            var scanner = Wtm.CreateVM<LocalMediaScanner>();

            var files = scanner.GetLocalMediaFileStorage();
            var file = files.Find(x=>x.Id == id);
            if (file == null)
            {
                return this.ErrorView("LocalMediaFile id is not found in LocalMediaFileStorage: " + id);
            }
            return View(file);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">LocalMediaFile id</param>
        /// <returns></returns>
        public IActionResult DoLocalPlay(string id)
        {
            var scanner = Wtm.CreateVM<LocalMediaScanner>();
            var files = scanner.GetLocalMediaFileStorage();
            var file = files.Find(x => x.Id == id);
            if (file == null)
            {
                return this.ErrorView("LocalMediaFile id is not found in LocalMediaFileStorage: " + id);
            }

            var stream = System.IO.File.OpenRead(file.FileFullName);
            return File(stream, file.MineTypeResult.MimeType, file.FileName, true);
        }
        #endregion
    }
}
