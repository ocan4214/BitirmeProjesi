using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace BitirmeProjesi.Models
{

    [MetadataType(typeof(EventMetadata))]
    public partial class Event
    {



    }

    public class EventMetadata
    {

        [Display(Name = "Definition")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Definition name required")]
        public string EventDefinition { get; set; }
        [Display(Name = "Topic")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Topic name required")]
        public string EventTopic { get; set; }
        [Display(Name = "Location")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Location name required")]
        public string EventLocation { get; set; }
       
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime EventCreateDate { get; set; }

        [Display(Name = "Event Begin Date")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Begin Date Required")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime EventBeginDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime EventUpdateDate { get; set; }


    }


}