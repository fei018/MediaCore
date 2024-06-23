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
    public partial class LocalMediaInfoTemplateVM : BaseTemplateVM
    {

	    protected override void InitVM()
        {
        }

    }

    public class LocalMediaInfoImportVM : BaseImportVM<LocalMediaInfoTemplateVM, LocalMediaInfo>
    {

    }

}
