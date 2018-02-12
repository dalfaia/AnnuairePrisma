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
    public class ResultatRechercheSocieteContact
    {
        public string Icon { get; set; }
        public string Libelle { get; set; }
        public string URL { get; set; }

        public ResultatRechercheSocieteContact() { }

        public ResultatRechercheSocieteContact(Societes pSociete)
        {
            this.Icon = "building";
            this.Libelle = pSociete.nom;
            if (!string.IsNullOrEmpty(pSociete.standard))
                this.Libelle += " - " + pSociete.standard;
            this.URL = "/Societes/Details/" + pSociete.idSociete;
        }
        public ResultatRechercheSocieteContact(Contacts pContact)
        {
            this.Icon = "user";
            this.Libelle = pContact.nom + " " + pContact.prenom;
            if (!string.IsNullOrEmpty(pContact.mail))
                this.Libelle += " - " + pContact.mail;
            if (!string.IsNullOrEmpty(pContact.tel))
                this.Libelle += " - " + pContact.tel;
            if (!string.IsNullOrEmpty(pContact.telportable))
                this.Libelle += " - " + pContact.telportable;
            this.URL = "/Contacts/Details/" + pContact.idContact;
        }
    }
}