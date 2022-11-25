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

        private decimal _imposta;
        public decimal Imposta { get { return _imposta; } set { _imposta = value; } }
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
            Menu();
        }

        private void FormImposte()
        {
            try
            {
                Console.WriteLine("Inserisci il tuo nome:");
                _nome = Console.ReadLine();
                Console.WriteLine("Inserisci il tuo cognome:");
                _cognome = Console.ReadLine();
                Console.WriteLine("Inserisci la tua data di nascita (gg/mm/aaaa):");
                _dataNascita = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Inserisci il tuo sesso (M o F):");
                string s = Console.ReadLine();
                while (s != "F" && s != "M" && s != "f" && s != "m")
                { Console.WriteLine("Valore non valido");
                    Console.WriteLine("Inserisci il tuo sesso (M o F):");
                    s = Console.ReadLine();
                }
                _sesso = s;
                Console.WriteLine("Inserisci il tuo codice fiscale:");
                _codFiscale = Console.ReadLine();
                Console.WriteLine("Inserisci il tuo comune di residenza:");
                _comResidenza = Console.ReadLine();
                Console.WriteLine("Inserisci il tuo reddito annuale:");
                _redAnnuale = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Stai per essere reinderizzato al calcolatore Imposte...");
                Thread.Sleep(2000);
                RisultatoImposta();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore:{ex.Message}");
            }
        }
        private void RisultatoImposta()
        {
            if (_redAnnuale <= 15000) { _imposta = _redAnnuale * 0.23m; }
            else if (_redAnnuale > 15000 && _redAnnuale <= 28000) { _imposta = (_redAnnuale - 15000) * 0.27m + 3450; }
            else if (_redAnnuale > 28000 && _redAnnuale <= 55000) { _imposta = (_redAnnuale - 28000) * 0.38m + 6960; }
            else if (_redAnnuale > 55000 && _redAnnuale <= 75000) { _imposta = (_redAnnuale - 55000) * 0.41m + 17220; }
            else if (_redAnnuale > 75000) { _imposta = (_redAnnuale - 75000) * 0.43m + 25420; }

            Console.WriteLine("\nCALCOLO DELL'IMPOSTA DA VERSARE:\n");
            Console.WriteLine($"Contribuente: {Nome} {Cognome},");
            Console.WriteLine($"nato il {DataNascita.ToString("dd/MM/yyyy")} ({Sesso}),");
            Console.WriteLine($"residente in {ComResidenza},");
            Console.WriteLine($"codice fiscale: {CodFiscale}\n");
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine($"reddito dichiarato: € {RedAnnuale.ToString("N")}\n");
            Console.WriteLine($"IMPOSTA DA VERSARE: € {_imposta.ToString("N")}\n");

            Menu();
        }

    }
}
