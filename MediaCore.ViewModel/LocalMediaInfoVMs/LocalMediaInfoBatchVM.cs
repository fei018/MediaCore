using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using MediaCore.Model.LocalMedia;


namespace MediaCore.ViewModel.LocalMediaInfoVMs
{
    public partial class LocalMediaInfoBatchVM : BaseBatchVM<LocalMediaInfo, LocalMediaInfo_BatchEdit>
    {
        public LocalMediaInfoBatchVM()
        {
            ListVM = new LocalMediaInfoListVM();
            LinkedVM = new LocalMediaInfo_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class LocalMediaInfo_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
