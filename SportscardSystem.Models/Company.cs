﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SportscardSystem.Models.Contracts;

namespace SportscardSystem.Models
{
    public class Company : AuditInfo
    {

        public Company() 
        {
            this.Sportscards = new HashSet<Sportscard>();
            this.Clients = new HashSet<Client>();
            this.CreatedOn = DateTime.Now;
            this.IsDeleted = false;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Navigation property - represents related entity
        /// </summary>
        public virtual ICollection<Sportscard> Sportscards { get; set; }

        /// <summary>
        /// Navigation property - represents related entity
        /// </summary>
        public virtual ICollection<Client> Clients { get; set; }
    }
}