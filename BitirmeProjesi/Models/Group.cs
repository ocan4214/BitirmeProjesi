
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
    
public partial class Group
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Group()
    {

        this.GroupThreads = new HashSet<GroupThread>();

        this.GroupMembers = new HashSet<GroupMember>();

        this.GroupChats = new HashSet<GroupChat>();

        this.Events = new HashSet<Event>();

    }


    public int GroupId { get; set; }

    public System.DateTime CreateDate { get; set; }

    public string GroupDescription { get; set; }

    public string GroupType { get; set; }

    public Nullable<int> MemberCount { get; set; }

    public bool IsPublic { get; set; }

    public string GroupName { get; set; }

    public Nullable<System.DateTime> UpdateDate { get; set; }

    public int OwnerId { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<GroupThread> GroupThreads { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<GroupMember> GroupMembers { get; set; }

    public virtual User User { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<GroupChat> GroupChats { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Event> Events { get; set; }

}

}
