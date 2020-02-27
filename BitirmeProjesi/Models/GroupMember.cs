//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BitirmeProjesi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class GroupMember
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GroupMember()
        {
            this.GroupMessages = new HashSet<GroupMessage>();
            this.Events = new HashSet<Event>();
        }
    
        public int GroupMemberId { get; set; }
        public string CreateDate { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsApproved { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }
    
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GroupMessage> GroupMessages { get; set; }
        public virtual Group Group { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Event> Events { get; set; }
    }
}
