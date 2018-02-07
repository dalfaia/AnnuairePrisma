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
    public class Societes
    { 

    [Column("ID")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int idSociete { get; set; }
    [Column("Client")]
    [Display(Name = "CLIENT")]
    public string nom { get; set; }
    public string raisonSociale { get; set; }
    [Column("Adresse")]
    public string adresse1 { get; set; }
    public string adresse2 { get; set; }
    public string codePostal { get; set; }
    public string ville { get; set; }
    [Column("Telephone")]
    public string standard { get; set; }

        public virtual ICollection<Contacts> Contact { get; set; }
    }
}