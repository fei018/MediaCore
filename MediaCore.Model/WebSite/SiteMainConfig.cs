using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;

namespace MediaCore.Model.WebSite
{
    [Table("SiteMainConfig")]
    public class SiteMainConfig : TopBasePoco
    {
        [Display(Name = "網站標題")]
        public string SiteTitle { get; set; }
    }
}
