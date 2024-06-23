using System;
using System.ComponentModel.DataAnnotations;

namespace MediaCore.Model
{

    public class RefDicNameAttribute : Attribute
    {
        public string Name { get; set; }
    }
}