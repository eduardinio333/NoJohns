//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NoJohns.API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Clients
    {
        public Clients()
        {
            this.Comments = new HashSet<Comments>();
            this.ClientsProcedures = new HashSet<ClientsProcedures>();
        }
    
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<ClientsProcedures> ClientsProcedures { get; set; }
    }
}
