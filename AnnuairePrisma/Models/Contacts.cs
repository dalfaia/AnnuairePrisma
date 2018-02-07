using AnnuairePrisma.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AnnuairePrisma.Models
{
    public class Contacts
    {
        [Column("ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idContact { get; set; }
        public string civilite { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string fonction { get; set; }
        public string telportable { get; set; }
        public string tel { get; set; }
        public string mail { get; set; }

        public int idSociete { get; set; }
        public virtual Societes Societes { get; set; }
    }
}