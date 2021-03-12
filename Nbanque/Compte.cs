using System;
using System.Collections.Generic;
using System.Text;
using TpBanqueV1.Nclients;


// Code 02527


namespace TpBanqueV1.Nbanque
{

    enum Tcritere { montant , date }

    abstract class Compte
    {
        #region attributs ( private ) 

        private string _numero;
        protected double _solde;
        private DateTime _dateCreation;

        private Client _titulaire;
        private List<Operation> _historique = new List<Operation>();
        private int nbrOp = 0; 

        #endregion

        #region proprietes 

        public string Numero
        {
            get => _numero; 
        }

        public double Solde
        {
            get => _solde;
            set => _solde = value; 
        }

        public DateTime DateCreation
        {
            get => _dateCreation; 
        }

        public Client Titulaire
        {
            get => _titulaire; 
        }

        #endregion

        #region constructeurs 

        public Compte ( Client titulaire,  string numero , double solde , string dateCreation)
        {
            _titulaire = titulaire; 
            _numero = numero;
            _solde = solde;
            _dateCreation = DateTime.Parse(dateCreation) ; 
        }

        public Compte(Client titulaire, string numero, double solde, DateTime dateCreation)
        {
            _titulaire = titulaire;
            _numero = numero;
            _solde = solde;
            _dateCreation = dateCreation;
        }

        public Compte(Client titulaire, string numero)
        {
            _titulaire = titulaire;
            _numero = numero;
            _solde = 0;
            _dateCreation = DateTime.Now;
        }

        public Compte() : this( new Client() , "indefini", 0, DateTime.Now) { }

        public void Deconstruct (out string numero, out double solde, out DateTime dateCreation)
        {
            numero = _numero;
            solde = _solde;
            dateCreation = _dateCreation;
        }

        #endregion

        #region méthodes
        public void Crediter ( double montant )
        {
            _solde += montant;
            //Ajouter une operation 
            AjouterOperation(Toperation.Credit, montant); 
        }

        protected void AjouterOperation ( Toperation type , double montant)
        {
            Operation op;
            op = new Operation(type, montant, DateTime.Now);
            _historique.Add(op); 
            //if (nbrOp < 10)
            //{
            //    _historique[nbrOp++] = op;
            //}
            //else
            //{
            //    for (int i = 0; i < 9; i++)
            //        _historique[i] = _historique[i + 1];
            //    _historique[9] = op;
            //}
        }

        public abstract void Debiter(double montant);
       

        public string GetHistorique ()
        {
            StringBuilder listing = new StringBuilder("Liste des operations : \n");
            foreach ( Operation op in _historique)
                listing.AppendLine(op.ToString());
            return listing.ToString(); 
        }


        public string GetHistorique( Tcritere critere )
        {
            StringBuilder listing = new StringBuilder("Liste des operations : \n");
            if (critere == Tcritere.montant)
                _historique.Sort(); 
            else if (critere == Tcritere.date)
                _historique.Sort ( new ComparateurOperationParDate () ); // tri sur la date 
            foreach (Operation op in _historique)
                listing.AppendLine(op.ToString());
            return listing.ToString();
        }

        //Faire une nouvelle version du GetHistorique ( GetHistoriqueLambda)  
        //trié en utilisant les lambdas 
        //Faire un traitement qui supprime les opérations inferieures à une valeur donnée
        public string GetHistoriqueLambda(Tcritere critere)
        {
            StringBuilder listing = new StringBuilder("Liste des operations : \n");
            if (critere == Tcritere.montant)
                _historique.Sort( ( op1 , op2) => op1.Montant.CompareTo(op2.Montant)); 
            else if (critere == Tcritere.date)
                _historique.Sort((op1, op2) => op1.Date.CompareTo(op2.Date)); // tri sur la date 
            _historique.ForEach(op => listing.AppendLine(op.ToString() ));  
            return listing.ToString();
        }

        public bool SupprimerOperation ( double montant )
        {
            return _historique.RemoveAll( op => op.Montant <= montant) == 0 ? false : true ; 
        }

        public string GetHistorique(double montant)
        {
            // Definit un predicate V1 
            //bool CompareMontant(Operation op) => op.Montant > montant;
            StringBuilder listing = new StringBuilder("Liste des operations : \n");
            //List<Operation> resultat = _historique.FindAll(CompareMontant); 
            //V2 avec méthode anonyme
            //List<Operation> resultat = 
            //    _historique.FindAll(delegate( Operation op) { return op.Montant > montant; } );
            // V3 avec lambda 
            List<Operation> resultat = _historique.FindAll( op =>  op.Montant > montant );
            resultat.ForEach(op => listing.AppendLine(op.ToString())); 
            //foreach (Operation op in resultat)
            //    listing.AppendLine(op.ToString());
            return listing.ToString();
        }


        public override string ToString() => $"{_numero} {_solde} {_dateCreation} {_titulaire.ToString()}"; 

        #endregion
    }
}
