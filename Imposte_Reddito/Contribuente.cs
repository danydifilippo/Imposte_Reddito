using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Imposte_Reddito
{
    internal class Contribuente
    {
        private string _nome;
        public string Nome { get { return _nome; } set { _nome = value; } }

        private string _cognome;
        public string Cognome { get { return _cognome; } set { _cognome = value; } }

        private DateTime _dataNascita;
        public DateTime DataNascita { get { return _dataNascita; } set { _dataNascita = value; } }

        private string _codFiscale;
        public string CodFiscale { get { return _codFiscale; } set { _codFiscale = value; } }

        private string _sesso;
        public string Sesso { get { return _sesso; } set { _sesso = value; } }

        private string _comResidenza;
        public string ComResidenza { get { return _comResidenza; } set { _comResidenza = value; } }

        private decimal _redAnnuale;
        public decimal RedAnnuale { get { return _redAnnuale; } set { _redAnnuale = value; } }


        public void Menu()
        {
            Console.WriteLine("******* SERVIZIO TELEMATICO IMPOSTE *******");
            Console.WriteLine("Scegli la tua opzione:");
            Console.WriteLine("1.Calcola la tua imposta");
            Console.WriteLine("2.Esci\n");

            try
            {
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    Console.WriteLine("Stai per essere reinderizzato alla pagina form 'Imposte'...");
                    Thread.Sleep(2000);
                    FormImposte();
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Arrivederci e consiglia il nostro compilatore");
                    Console.WriteLine("Ti aspettiamo alla prossima dichiarazione");
                    Thread.Sleep(3000);
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Inserisci una scelta valida");
                    Menu();
                }
            }
            catch (Exception ex) { Console.WriteLine($"Errore:{ex.Message}"); }
            Console.ReadLine();
        }

        private void FormImposte()
        {
            try {
            Console.WriteLine("Inserisci il tuo nome:");
            _nome = Console.ReadLine();
            Console.WriteLine("Inserisci il tuo cognome:");
            _cognome = Console.ReadLine();
            Console.WriteLine("Inserisci la tua data di nascita (gg/mm/aaaa):");
            _dataNascita = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci il tuo sesso (M o F):");
            _sesso = Console.ReadLine();
            Console.WriteLine("Inserisci il tuo codice fiscale:");
            _codFiscale = Console.ReadLine();
            Console.WriteLine("Inserisci il tuo comune di residenza:");
            _comResidenza = Console.ReadLine();
            Console.WriteLine("Inserisci il tuo reddito annuale:");
            _redAnnuale = decimal.Parse(Console.ReadLine());
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Errore:{ex.Message}");
            }
        }

    }
}
