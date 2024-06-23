using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;

namespace MediaCore.Model.LocalMedia
{
    [Table("LocalMediaInfo")]
    public class LocalMediaInfo : TopBasePoco
    {
        /// <summary>
        /// 本地文件目錄
        /// </summary>
        [Display(Name = "文件目錄")]
        [Required]
        public string MediaRootPath { get; set; }
    }
}
