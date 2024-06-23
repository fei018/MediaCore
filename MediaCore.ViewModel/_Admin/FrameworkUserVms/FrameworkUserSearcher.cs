﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using MediaCore.Model;
namespace MediaCore.ViewModel._Admin.FrameworkUserVMs
{
    public partial class FrameworkUserSearcher : BaseSearcher
    {
        
        public List<string> _AdminFrameworkUserSTempSelected { get; set; }
        [Display(Name = "_Model._FrameworkUser._ITCode")]
        public string ITCode { get; set; }
        [Display(Name = "_Model._FrameworkUser._Name")]
        public string Name { get; set; }
        [Display(Name = "_Model._FrameworkUser._IsValid")]
        public bool? IsValid { get; set; }

        protected override void InitVM()
        {
            
        }
    }

}