using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_banca_oop
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string CodiceFiscale { get; set; }
        public double Stipendio { get; set; }

        public Cliente(string nome, string cognome, string codiceFiscale, double stipendio)
        {
            this.Nome = nome;
            this.Cognome = cognome;
            this.CodiceFiscale = codiceFiscale;
            this.Stipendio = stipendio;
        }

        public override string ToString()
        {

            return string.Format("Nome: {0}\nCognome: {1}\nCodiceFiscale: {2}\nStipendio: {3}",
                                 this.Nome,
                                 this.Cognome,
                                 this.CodiceFiscale,
                                 this.Stipendio);
        }


    }
    public class Prestito
    {
        public Cliente Intestatario { get; set; }
        public double Ammontare { get; set; }
        public double Rata { get; set; }
        public DateTime DataInzio { get; set; }
        public DateTime DataFine { get; set; }
        public string CF { get; set; }


        public int GiorniAllaScadenza()
        {
            TimeSpan tsAppo = DataFine - DateTime.Now;
            return (int)tsAppo.TotalDays;
        }
    }

    class Banca
    {
        public string NomeBanca { get; set; }
        private List<Cliente> clientList;
        private List<Prestito> prestitoList;

        public Banca(string sNome)
        {
            NomeBanca = sNome;
            clientList = new List<Cliente>();
            prestitoList = new List<Prestito>();
        }

        public void addCliente(Cliente cliente)
        {

            clientList.Add(cliente);
        }

        public void deleteCLiente(Cliente cliente)
        {
            this.clientList.Remove(cliente);
        }

        public bool UpdateCliente(string sCodiceFiscale, double dStipendio)
        {
            Cliente mioCliente = clientList.Find(x => x.CodiceFiscale == sCodiceFiscale);
            if (mioCliente != null)
            {
                mioCliente.Stipendio = dStipendio;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddPrestito(string cf, double ammontare, double rate, DateTime dataInizio, DateTime dataFine)
        {
            Prestito prestito = new Prestito();
            prestito.CF = cf;
            prestito.Ammontare = ammontare;
            prestito.Rata = rate;
            prestito.DataInzio = dataInizio;
            prestito.DataFine = dataFine;

            if (clientList.Exists(c => c.CodiceFiscale == cf))
            {
                prestitoList.Add(prestito);
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<Prestito> RicercaPrestiti(string codiceFiscale)
        {
            return this.prestitoList.FindAll(p => p.Intestatario.CodiceFiscale == codiceFiscale);
        }


        public Dictionary<string, double> AmmontarePrestitiPerCliente()
        {
            Dictionary<string, double> kv = new Dictionary<string, double>();
            foreach (Prestito prestito in this.prestitoList)
            {
                if (kv.ContainsKey(prestito.CF))
                {
                    kv[prestito.CF] += prestito.Ammontare;

                }
                else
                {
                    kv[prestito.CF] = prestito.Ammontare;
                }
            }
            return kv;
        }

    }


}
