
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
    
public partial class Friend
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Friend()
    {

        this.Users = new HashSet<User>();

    }


    public int FriendId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public System.DateTime DateOfBirth { get; set; }

    public System.DateTime FriendAddDate { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<User> Users { get; set; }

}

}
