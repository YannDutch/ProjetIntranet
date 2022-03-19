using System;
using System.Collections.Generic;
using TpIntranetEntreprise.DAO;

namespace TpIntranetEntreprise.Models.Personne
{
    public class Personne
    {
        private Collaborateur collab;
        private CollabCompta compta;
        private CollabRH rh;
        private CollabAdmin admin;
        private ChefService chef;

        public Personne()
        {

        }
        public Personne(int matriucleCollab, string nom, string prenom, DateTime dateNaissance, string MDP, string nomTypeCollab, string nomTypeService)
        {
            Collab = new Collaborateur(matriucleCollab,nom, prenom, dateNaissance, MDP, nomTypeCollab, nomTypeService);
            Compta = new CollabCompta(matriucleCollab,nom, prenom, dateNaissance, MDP, nomTypeCollab, nomTypeService);
            Rh = new CollabRH(matriucleCollab,nom, prenom, dateNaissance, MDP, nomTypeCollab, nomTypeService);
            Admin = new CollabAdmin(matriucleCollab, nom, prenom, dateNaissance, MDP, nomTypeCollab, nomTypeService);
            Chef = new ChefService(matriucleCollab,nom, prenom, dateNaissance, MDP, nomTypeCollab, nomTypeService);
        }
        public Collaborateur Collab { get => collab; set => collab = value; }
        public CollabCompta Compta { get => compta; set => compta = value; }
        public CollabRH Rh { get => rh; set => rh = value; }
        public CollabAdmin Admin { get => admin; set => admin = value; }
        public ChefService Chef { get => chef; set => chef = value; }
        public bool Save(Personne p)
        {
            if (p.Collab != null) { return p.Collab.Save(); }
            else if (p.Compta != null) { return p.Compta.Save(); }
            else if (p.Rh != null) { return p.Rh.Save(); }
            else if (p.Admin != null) { return p.Admin.Save(); }
            else if (p.Chef != null) { return p.Chef.Save(); }
            return false;
        }
        public bool Delete(Personne p)
        {
            if (p.Collab != null) { return p.Collab.Delete(); }
            else if (p.Compta != null) { return p.Compta.Delete(); }
            else if (p.Rh != null) { return p.Rh.Delete(); }
            else if (p.Admin != null) { return p.Admin.Delete(); }
            else if (p.Chef != null) { return p.Chef.Delete(); }
            return false;
        }
        public static void Find(string nom)
        {
            Personne p = new Personne();
            if (p.Collab != null) { p.Collab.Find(nom); }
            else if (p.Compta != null) { p.Compta.Find(nom); }
            else if (p.Rh != null) { p.Rh.Find(nom); }
            else if (p.Admin != null) { p.Admin.Find(nom); }
            else if (p.Chef != null) { p.Chef.Find(nom); }
            else
                p = null;
        }
        public static void Find(Func<Personne, bool> criteria)
        {
            Personne p = new Personne();
            if (p.Collab != null) { p.Collab.Find((Func<Collaborateur, bool>)criteria); }
            else if (p.Compta != null) { p.Compta.Find((Func<CollabCompta, bool>)criteria); }
            else if (p.Rh != null) { p.Rh.Find((Func<CollabRH, bool>)criteria); }
            else if (p.Admin != null) { p.Admin.Find((Func<CollabAdmin, bool>)criteria); }
            else if (p.Chef != null) { p.Chef.Find((Func<ChefService, bool>)criteria); }
            else { p = null; }

        }
        public static void  FindAl()
        {
            Personne p = new Personne();
            if (p.Collab != null) { p.Collab.FindAl(); }
            else if (p.Compta != null) { p.Compta.FindAl(); }
            else if (p.Rh != null) { p.Rh.FindAl(); }
            else if (p.Admin != null) { p.Admin.FindAl(); }
            else if (p.Chef != null) { p.Chef.FindAl(); }
            else { p = null; }
        }
        public bool Update(Personne p)
        {
            if (p.Collab != null) { return p.Collab.Update(p.Collab); }
            else if (p.Compta != null) { return p.Compta.Update(p.Compta); }
            else if (p.Rh != null) { return p.Rh.Update(p.Rh); }
            else if (p.Admin != null) { return p.Admin.Update(p.Admin); }
            else if (p.Chef != null) { return p.Chef.Update(p.Chef); }
            return false;
        }
        public static void HitoriquesMission(Personne p)
        {
            if (p.Collab != null) { p.Collab.HitoriquesMission(p.Collab); }
            else if (p.Compta != null) { p.Compta.HitoriquesMission(p.Compta); }
            else if (p.Rh != null) { p.Rh.HitoriquesMission(p.Rh); }
            else if (p.Admin != null) { p.Admin.HitoriquesMission(p.Admin); }
            else if (p.Chef != null) { p.Chef.HitoriquesMission(p.Chef); }
            else { p = null; }
        }
    }
}
