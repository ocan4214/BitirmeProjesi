
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
    
public partial class GroupMessage
{

    public int GroupMessageId { get; set; }

    public System.DateTime CreateDate { get; set; }

    public Nullable<System.DateTime> UpdateDate { get; set; }

    public string MessageContext { get; set; }

    public int GroupMemberId { get; set; }

    public int GroupThreadId { get; set; }



    public virtual GroupMember GroupMember { get; set; }

    public virtual GroupThread GroupThread { get; set; }

}

}
