using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;

namespace MediaCore.Model.LocalMedia
{
    [Table("LocalMediaConfig")]
    public class LocalMediaConfig : TopBasePoco
    {
        /// <summary>
        /// 指定搜索文件的擴展名
        /// </summary>
        [Display(Name = "文件擴展名")]
        public string MediaFileExtention { get; set; }
    }
}
