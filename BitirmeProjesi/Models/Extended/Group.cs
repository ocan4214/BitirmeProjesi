using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BitirmeProjesi.Models
{

    [MetadataType(typeof(GroupMetadata))]
    public partial class Group
    {


        
        
       
    }

    public class GroupMetadata
    {
        [Required]
        public string GroupDescription { get; set; }
        [Required]
        public bool IsPublic { get; set; }
        [Required]
        public string GroupName { get; set; }
    }
}