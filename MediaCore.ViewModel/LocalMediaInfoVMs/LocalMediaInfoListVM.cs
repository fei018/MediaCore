using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using MediaCore.Model.LocalMedia;


namespace MediaCore.ViewModel.LocalMediaInfoVMs
{
    public partial class LocalMediaInfoListVM : BasePagedListVM<LocalMediaInfo_View, LocalMediaInfoSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("LocalMediaInfo", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"LocalMedia", dialogWidth: 800),
                this.MakeStandardAction("LocalMediaInfo", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "LocalMedia", dialogWidth: 800),
                this.MakeStandardAction("LocalMediaInfo", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "LocalMedia", dialogWidth: 800),
                this.MakeStandardAction("LocalMediaInfo", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "LocalMedia", dialogWidth: 800),
                this.MakeStandardAction("LocalMediaInfo", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "LocalMedia", dialogWidth: 800),
                this.MakeStandardAction("LocalMediaInfo", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "LocalMedia", dialogWidth: 800),
                this.MakeStandardAction("LocalMediaInfo", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "LocalMedia", dialogWidth: 800),
                this.MakeStandardAction("LocalMediaInfo", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "LocalMedia"),
            };
        }


        protected override IEnumerable<IGridColumn<LocalMediaInfo_View>> InitGridHeader()
        {
            return new List<GridColumn<LocalMediaInfo_View>>{
                this.MakeGridHeader(x => x.ID, width:250),
                this.MakeGridHeader(x => x.MediaRootPath),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<LocalMediaInfo_View> GetSearchQuery()
        {
            var query = DC.Set<LocalMediaInfo>()
                .Select(x => new LocalMediaInfo_View
                {
                    ID = x.ID,
                    MediaRootPath = x.MediaRootPath,
                })
                .OrderBy(x => x.MediaRootPath);
            return query;
        }

    }

    public class LocalMediaInfo_View : LocalMediaInfo
    {

    }
}
