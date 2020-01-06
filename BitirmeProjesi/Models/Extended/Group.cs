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
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required Group Description")]
        [Display(Name = "Group Description")]
        public string GroupDescription { get; set; }
        [Required]
        public bool IsPublic { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required Group Name")]
        [Display(Name = "Group Name")]
        public string GroupName { get; set; }
        [Required]
        [Display(Name = "Group Type")]
        public string GroupType { get; set; }
    }
}