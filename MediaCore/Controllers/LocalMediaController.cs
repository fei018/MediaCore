using MediaCore.Extentions;
using MediaCore.ViewModel.LocalMediaScan;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Mvc;

namespace MediaCore.Controllers
{
    [NoLog]
    [Public]
    public class LocalMediaController : BaseController
    {
        #region Local
        public IActionResult Index()
        {
            var scanner = Wtm.CreateVM<LocalMediaScanner>();
            var vm = scanner.GetLocalMediaFolderStorage();
            return View(vm);
        }

        public IActionResult Top()
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
        public IActionResult List(string id)
        {
            var scanner = Wtm.CreateVM<LocalMediaScanner>();
            var list = scanner.GetLocalMediaFolderStorage();

            if (string.IsNullOrEmpty(id))
            {
                var tops = list.Where(x => x.IsRoot).ToList();
                return PartialView("Top", tops);
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
        public IActionResult Play(string id)
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
        public IActionResult DoPlay(string id)
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

        public IActionResult Download(string id)
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
