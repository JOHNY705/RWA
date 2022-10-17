using Microsoft.ApplicationBlocks.Data;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace Aplikacija_za_administraciju.Models
{
    public class Repozitorij
    {
        public static DataSet DS { get; set; }
        private static readonly string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        public static IEnumerable<Djelatnik> DohvatiDjelatnikeBezTima()
        {
            var tblDjelatnici = SqlHelper.ExecuteDataset(cs, "[DohvatiDjelatnikeKojiNePripadajuTimu]").Tables[0];

            foreach (DataRow row in tblDjelatnici.Rows)
            {
                yield return new Djelatnik(idDjelatnik: (int)row["IDDjelatnik"], ime: row["Ime"].ToString(), prezime: row["Prezime"].ToString(),
                    tip: (int)row["TipID"], email: row["Email"].ToString(), datumZaposlenja: DateTime.Parse(row["DatumZaposlenja"].ToString()),
                    tim: null);
            }
        }

        public static void DodajNovogKlijenta(Klijent klijent)
        {
            SqlParameter[] parameters = new SqlParameter[3];

            parameters[0] = new SqlParameter("@Naziv", SqlDbType.NVarChar, 30)
            {
                Direction = ParameterDirection.Input,
                Value = klijent.Naziv
            };

            parameters[1] = new SqlParameter("@Telefon", SqlDbType.NVarChar, 15)
            {
                Direction = ParameterDirection.Input,
                Value = klijent.Telefon
            };

            parameters[2] = new SqlParameter("@Email", SqlDbType.NVarChar, 25)
            {
                Direction = ParameterDirection.Input,
                Value = klijent.Email
            };

            SqlHelper.ExecuteDataset(cs, CommandType.StoredProcedure, "DodajNovogKlijenta", parameters);
        }

        public static IEnumerable<Projekt> DohvatiProjekteKlijenta(Klijent klijent)
        {
            var tblProjekti = SqlHelper.ExecuteDataset(cs, "DohvatiProjekteKlijenta", klijent.IDKlijent).Tables[0];

            foreach (DataRow row in tblProjekti.Rows)
            {
                yield return new Projekt(idProjekt: (int)row["IDProjekt"], naziv: row["Naziv"].ToString(),
                    datumOtvaranja: DateTime.Parse(row["DatumOtvaranja"].ToString()), voditelj: GetDjelatnik((int)row["VoditeljID"]),
                    klijent: klijent, opisProjekta: row["OpisProjekta"].ToString());
            }
        }

        public static bool UpdateKlijent(Klijent klijent)
        {
            SqlParameter[] parameters = new SqlParameter[5];

            parameters[0] = new SqlParameter("@IDKlijent", SqlDbType.Int)
            {
                Direction = ParameterDirection.Input,
                Value = klijent.IDKlijent
            };

            parameters[1] = new SqlParameter("@Naziv", SqlDbType.NVarChar, 30)
            {
                Direction = ParameterDirection.Input,
                Value = klijent.Naziv
            };

            parameters[2] = new SqlParameter("@Telefon", SqlDbType.NVarChar, 15)
            {
                Direction = ParameterDirection.Input,
                Value = klijent.Telefon
            };

            parameters[3] = new SqlParameter("@Email", SqlDbType.NVarChar, 25)
            {
                Direction = ParameterDirection.Input,
                Value = klijent.Email
            };

            parameters[4] = new SqlParameter("@output", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            SqlHelper.ExecuteDataset(cs, CommandType.StoredProcedure, "AzurirajKlijenta", parameters);

            int output = (int)parameters[4].Value;

            return output == 1;
        }

        public static void DodajNoviTim(Tim tim)
        {
            SqlParameter[] parameters = new SqlParameter[2];

            parameters[0] = new SqlParameter("@Naziv", SqlDbType.NVarChar, 30)
            {
                Direction = ParameterDirection.Input,
                Value = tim.Naziv
            };

            parameters[1] = new SqlParameter("@VoditeljID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Input,
                Value = tim.Voditelj.IDDjelatnik
            };

            SqlHelper.ExecuteDataset(cs, CommandType.StoredProcedure, "DodajNoviTim", parameters);
        }

        public static IEnumerable<Klijent> GetKlijenti()
        {
            var tblKlijenti = SqlHelper.ExecuteDataset(cs, "DohvatiSveKlijente").Tables[0];

            foreach (DataRow row in tblKlijenti.Rows)
            {
                yield return new Klijent(idKlijent: (int)row["IDKlijent"], naziv: row["Naziv"].ToString(), telefon: row["Telefon"].ToString(),
                    email: row["Email"].ToString());
            }
        }

        public static Satnica GetZadnjaSatnicaDjelatnikaZaProjekt(Djelatnik djelatnik, Projekt projekt)
        {
            SqlParameter[] parameters = new SqlParameter[2];

            parameters[0] = new SqlParameter("@IDDjelatnik", SqlDbType.Int)
            {
                Direction = ParameterDirection.Input,
                Value = djelatnik.IDDjelatnik
            };

            parameters[1] = new SqlParameter("@IDProjekti", SqlDbType.Int)
            {
                Direction = ParameterDirection.Input,
                Value = projekt.IDProjekt
            };

            DataTable tblSatnica = SqlHelper.ExecuteDataset(cs, CommandType.StoredProcedure, "DohvatiZadnjuSatnicuDjelatnika", parameters).Tables[0];

            if (tblSatnica.Rows.Count == 0)
            {
                return null;
            }

            DataRow row = tblSatnica.Rows[0];

            return new Satnica
            {
                IDSatnica = int.Parse(row["IDSatnica"].ToString()),
                Djelatnik = djelatnik,
                DatumSatnice = DateTime.Parse(row["DatumSatnice"].ToString()),
                ProjektID = projekt.IDProjekt,
                Komentar = row["Komentar"].ToString(),
                RadniSati = double.Parse(row["RadniSati"].ToString()),
                PrekovremeniSati = double.Parse(row["PrekovremeniSati"].ToString())
            };
        }

        public static Djelatnik LoginUser(string email, string password)
        {
            SqlParameter[] parameters = new SqlParameter[4];

            parameters[0] = new SqlParameter("@email", SqlDbType.NVarChar, 50)
            {
                Direction = ParameterDirection.Input,
                Value = email
            };

            parameters[1] = new SqlParameter("@password", SqlDbType.NVarChar, 50)
            {
                Direction = ParameterDirection.Input,
                Value = password
            };

            parameters[2] = new SqlParameter("@djelatnikID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            SqlHelper.ExecuteDataset(cs, CommandType.StoredProcedure, "ProvjeriKorisnickoImeIZaporku", parameters);

            int idDjelatnik = (int)parameters[2].Value;

            if (idDjelatnik > 0)
            {
                return GetDjelatnik(idDjelatnik);
            }

            return null;
        }

        public static IEnumerable<Djelatnik> GetClanoviTima(Tim tim)
        {
            var tblClanovi = SqlHelper.ExecuteDataset(cs, "DohvatiSveDjelatnikeIzTima", tim.IDTim).Tables[0];

            foreach (DataRow row in tblClanovi.Rows)
            {
                yield return new Djelatnik(idDjelatnik: (int)row["IDDjelatnik"], ime: row["Ime"].ToString(), prezime: row["Prezime"].ToString(),
                    tip: (int)row["TipID"], email: row["Email"].ToString(), datumZaposlenja: DateTime.Parse(row["DatumZaposlenja"].ToString()),
                    tim: tim);
            }
        }

        public static IEnumerable<Djelatnik> DohvatiDjelatnikeBezDirektora()
        {
            var tblDjelatnici = SqlHelper.ExecuteDataset(cs, "DohvatiSveDjelatnikeOsimDirektora").Tables[0];
            
            foreach (DataRow row in tblDjelatnici.Rows)
            {
                yield return new Djelatnik(idDjelatnik: (int)row["IDDjelatnik"], ime: row["Ime"].ToString(), prezime: row["Prezime"].ToString(),
                    tip: (int)row["TipID"], email: row["Email"].ToString(), datumZaposlenja: DateTime.Parse(row["DatumZaposlenja"].ToString()),
                    tim: GetTim((int)row["TipID"]));
            }
        }

        public static bool UpdateTim(Tim tim)
        {
            SqlParameter[] parameters = new SqlParameter[3];

            parameters[0] = new SqlParameter("@IDTim", SqlDbType.Int)
            {
                Direction = ParameterDirection.Input,
                Value = tim.IDTim
            };

            parameters[1] = new SqlParameter("@Naziv", SqlDbType.NVarChar, 30)
            {
                Direction = ParameterDirection.Input,
                Value = tim.Naziv
            };

            parameters[2] = new SqlParameter("@output", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            SqlHelper.ExecuteDataset(cs, CommandType.StoredProcedure, "AzurirajTim", parameters);

            int output = (int)parameters[2].Value;

            return output == 1;
        }

        public static Projekt GetProjekt(int idProjekt)
        {
            DataTable tblProjekt = SqlHelper.ExecuteDataset(cs, "DohvatiPodatkeOProjektu", idProjekt).Tables[0];

            if (tblProjekt.Rows.Count == 0)
            {
                return null;
            }

            DataRow row = tblProjekt.Rows[0];
            return new Projekt(idProjekt: (int)row["IDProjekt"], naziv: row["Naziv"].ToString(),
                datumOtvaranja: DateTime.Parse(row["DatumOtvaranja"].ToString()), voditelj: GetDjelatnik((int)row["VoditeljID"]),
                klijent: GetKlijent((int)row["KlijentID"]), opisProjekta: row["OpisProjekta"].ToString());
        }

        public static void DodajNovogDjelatnika(Djelatnik djelatnik)
        {
            SqlParameter[] parameters = new SqlParameter[8];

            parameters[0] = new SqlParameter("@Ime", SqlDbType.NVarChar, 30)
            {
                Direction = ParameterDirection.Input,
                Value = djelatnik.Ime
            };

            parameters[1] = new SqlParameter("@Prezime", SqlDbType.NVarChar, 30)
            {
                Direction = ParameterDirection.Input,
                Value = djelatnik.Prezime
            };

            parameters[2] = new SqlParameter("@TipID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Input,
                Value = (int)djelatnik.Tip
            };

            parameters[3] = new SqlParameter("@Email", SqlDbType.NVarChar, 30)
            {
                Direction = ParameterDirection.Input,
                Value = djelatnik.Email
            };

            parameters[4] = new SqlParameter("@Lozinka", SqlDbType.NVarChar, 30)
            {
                Direction = ParameterDirection.Input,
                Value = djelatnik.Lozinka
            };

            parameters[5] = new SqlParameter("@DatumZaposlenja", SqlDbType.Date)
            {
                Direction = ParameterDirection.Input,
                Value = djelatnik.DatumZaposlenja.ToShortDateString()
            };

            parameters[6] = new SqlParameter("@TimID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Input,
                Value = djelatnik.Tim == null ? (object)DBNull.Value : djelatnik.Tim.IDTim
            };

            parameters[7] = new SqlParameter("@output", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            SqlHelper.ExecuteDataset(cs, CommandType.StoredProcedure, "DodajNovogDjelatnika", parameters);
        }

        public static IEnumerable<Tim> GetTimovi()
        {
            var tblTimovi = SqlHelper.ExecuteDataset(cs, "DohvatiSveTimove").Tables[0];

            foreach (DataRow row in tblTimovi.Rows)
            {
                yield return new Tim(idTim: (int)row["IDTim"], naziv: row["Naziv"].ToString(), voditeljTima: GetDjelatnik((int)row["VoditeljID"]));
            }
        }

        public static IEnumerable<Djelatnik> DohvatiDjelatnikeKojiRadeNaProjektu(Projekt projekt)
        {
            var tblDjelatnici = SqlHelper.ExecuteDataset(cs, "DohvatiDjelatnikeKojiRadeNaProjektu", projekt.IDProjekt).Tables[0];
            foreach (DataRow row in tblDjelatnici.Rows)
            {
                yield return new Djelatnik(idDjelatnik: (int)row["IDDjelatnik"], ime: row["Ime"].ToString(), prezime: row["Prezime"].ToString(),
                    tip: (int)row["TipID"], email: row["Email"].ToString(), datumZaposlenja: DateTime.Parse(row["DatumZaposlenja"].ToString()),
                    tim: GetTim((int)row["TipID"]));
            }
        }

        public static bool UpdateProjekt(Projekt projekt)
        {
            SqlParameter[] parameters = new SqlParameter[5];

            parameters[0] = new SqlParameter("@IDProjekt", SqlDbType.Int)
            {
                Direction = ParameterDirection.Input,
                Value = projekt.IDProjekt
            };

            parameters[1] = new SqlParameter("@Naziv", SqlDbType.NVarChar, 30)
            {
                Direction = ParameterDirection.Input,
                Value = projekt.Naziv
            };

            parameters[2] = new SqlParameter("@DatumOtvaranja", SqlDbType.Date)
            {
                Direction = ParameterDirection.Input,
                Value = projekt.DatumOtvaranja
            };

            parameters[3] = new SqlParameter("@OpisProjekta", SqlDbType.NVarChar, 200)
            {
                Direction = ParameterDirection.Input,
                Value = projekt.OpisProjekta
            };

            parameters[4] = new SqlParameter("@output", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            SqlHelper.ExecuteDataset(cs, CommandType.StoredProcedure, "AzurirajProjekt", parameters);
            int output = (int)parameters[4].Value;
            return output == 1;
        }

        public static Djelatnik LoginKorisnika(string email, string lozinka)
        {
            SqlParameter[] parameters = new SqlParameter[4];

            parameters[0] = new SqlParameter("@email", SqlDbType.NVarChar, 50)
            {
                Direction = ParameterDirection.Input,
                Value = email
            };
            parameters[1] = new SqlParameter("@password", SqlDbType.NVarChar, 50)
            {
                Direction = ParameterDirection.Input,
                Value = lozinka
            };
            parameters[2] = new SqlParameter("@djelatnikID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            SqlHelper.ExecuteDataset(cs, CommandType.StoredProcedure, "ProvjeriKorisnickoImeIZaporku", parameters);

            int djelatnikID = (int)parameters[2].Value;

            if (djelatnikID > 0)
            {
                return GetDjelatnik(djelatnikID);
            }

            return null;
        }

        public static void DodajNoviProjekt(Projekt projekt)
        {
            SqlParameter[] parameters = new SqlParameter[5];

            parameters[0] = new SqlParameter("@Naziv", SqlDbType.NVarChar, 30)
            {
                Direction = ParameterDirection.Input,
                Value = projekt.Naziv
            };

            parameters[1] = new SqlParameter("@DatumOtvaranja", SqlDbType.Date)
            {
                Direction = ParameterDirection.Input,
                Value = $"{projekt.DatumOtvaranja.ToShortDateString()}"
            };

            parameters[2] = new SqlParameter("@VoditeljID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Input,
                Value = projekt.Voditelj.IDDjelatnik
            };

            parameters[3] = new SqlParameter("@KlijentID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Input,
                Value = projekt.Klijent.IDKlijent
            };

            parameters[4] = new SqlParameter("@OpisProjekta", SqlDbType.NVarChar, 200)
            {
                Direction = ParameterDirection.Input,
                Value = projekt.OpisProjekta
            };

            SqlHelper.ExecuteDataset(cs, CommandType.StoredProcedure, "DodajNoviProjekt", parameters);
        }

        public static IEnumerable<Projekt> GetProjektiDjelatnika(int korisnikId)
        {
            var tblProjekti = SqlHelper.ExecuteDataset(cs, "DohvatiProjekteNaKojimaDjelatnikMozeRaditi", korisnikId).Tables[0];
            foreach (DataRow row in tblProjekti.Rows)
            {
                yield return new Projekt(idProjekt: (int)row["IDProjekt"], naziv: row["Naziv"].ToString(),
                    datumOtvaranja: DateTime.Parse(row["DatumOtvaranja"].ToString()), voditelj: GetDjelatnik((int)row["VoditeljID"]),
                    klijent: GetKlijent((int)row["IDKlijent"]), opisProjekta: row["OpisProjekta"].ToString());
            }
        }

        public static Klijent GetKlijent(int idKlijent)
        {
            DataTable tblKlijent = SqlHelper.ExecuteDataset(cs, "DohvatiKlijenta", idKlijent).Tables[0];

            if (tblKlijent.Rows.Count == 0)
            {
                return null;
            }

            DataRow row = tblKlijent.Rows[0];
            return new Klijent(idKlijent: (int)row["IDKlijent"], naziv: row["Naziv"].ToString(), telefon: row["Telefon"].ToString(),
                email: row["Email"].ToString());
        }

        public static bool PromijeniDjelatnikuLozinku(Djelatnik djelatnik)
        {
            SqlParameter[] parameters = new SqlParameter[3];

            parameters[0] = new SqlParameter("@IDDjelatnik", SqlDbType.Int)
            {
                Direction = ParameterDirection.Input,
                Value = djelatnik.IDDjelatnik
            };

            parameters[1] = new SqlParameter("@NovaLozinka", SqlDbType.NVarChar, 50)
            {
                Direction = ParameterDirection.Input,
                Value = djelatnik.Lozinka
            };

            parameters[2] = new SqlParameter("@output", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            SqlHelper.ExecuteDataset(cs, CommandType.StoredProcedure, "AzurirajLozinku", parameters);

            int output = (int)parameters[2].Value;

            return output == 1;
        }

        public static bool UpdateDjelatnik(Djelatnik djelatnik)
        {
            SqlParameter[] parameters = new SqlParameter[7];

            parameters[0] = new SqlParameter("@IDDjelatnik", SqlDbType.Int)
            {
                Direction = ParameterDirection.Input,
                Value = djelatnik.IDDjelatnik
            };

            parameters[1] = new SqlParameter("@Ime", SqlDbType.NVarChar, 30)
            {
                Direction = ParameterDirection.Input,
                Value = djelatnik.Ime
            };

            parameters[2] = new SqlParameter("@Prezime", SqlDbType.NVarChar, 30)
            {
                Direction = ParameterDirection.Input,
                Value = djelatnik.Prezime
            };

            parameters[3] = new SqlParameter("@TipID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Input,
                Value = (int)djelatnik.Tip
            };

            parameters[4] = new SqlParameter("@Email", SqlDbType.NVarChar, 50)
            {
                Direction = ParameterDirection.Input,
                Value = djelatnik.Email
            };

            parameters[5] = new SqlParameter("@TimID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Input,
                Value = djelatnik.Tim.IDTim
            };

            parameters[6] = new SqlParameter("@output", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            SqlHelper.ExecuteDataset(cs, CommandType.StoredProcedure, "AzurirajDjelatnika", parameters);

            int output = (int)parameters[6].Value;

            return output == 1;
        }

        public static Tim GetTimDjelatnika(int idDjelatnik)
        {
            DataTable tblTim = SqlHelper.ExecuteDataset(cs, "DohvatiPodatkeOTimuDjelatnika", idDjelatnik).Tables[0];

            if (tblTim.Rows.Count == 0)
            {
                return null;
            }

            DataRow row = tblTim.Rows[0];
            Tim tim = new Tim
            {
                IDTim = (int)row["IDTim"],
                Naziv = row["Naziv"].ToString()
            };

            tim.Voditelj = GetDjelatnik((int)row["VoditeljID"], tim);

            return tim;
        }

        public static Djelatnik GetDjelatnik(int idDjelatnik)
        {
            DataTable tblDjelatnik = SqlHelper.ExecuteDataset(cs, "DohvatiPodatkeODjelatniku", idDjelatnik).Tables[0];

            if (tblDjelatnik.Rows.Count == 0)
            {
                return null;
            }

            DataRow row = tblDjelatnik.Rows[0];
            return new Djelatnik(idDjelatnik: (int)row["IDDjelatnik"], ime: row["Ime"].ToString(), prezime: row["Prezime"].ToString(),
                tip: (int)row["TipID"], email: row["Email"].ToString(), lozinka: row["Lozinka"].ToString(),
                datumZaposlenja: DateTime.Parse(row["DatumZaposlenja"].ToString()), tim: GetTim((int)row["TipID"]));
        }

        public static Djelatnik GetDjelatnik(int idDjelatnik, Tim tim)
        {
            DataTable tblDjelatnik = SqlHelper.ExecuteDataset(cs, "DohvatiPodatkeODjelatniku", idDjelatnik).Tables[0];

            if (tblDjelatnik.Rows.Count == 0)
            {
                return null;
            }

            DataRow row = tblDjelatnik.Rows[0];
            return new Djelatnik(idDjelatnik: (int)row["IDDjelatnik"], ime: row["Ime"].ToString(), prezime: row["Prezime"].ToString(), tip: (int)row["TipID"],
                email: row["Email"].ToString(), lozinka: row["Lozinka"].ToString(), datumZaposlenja: DateTime.Parse(row["DatumZaposlenja"].ToString()),
                tim: tim ?? GetTim((int)row["TipID"]));
        }

        public static Tim GetTim(int timID)
        {
            DataTable tblTim = SqlHelper.ExecuteDataset(cs, "DohvatiPodatkeOTimu", timID).Tables[0];

            if (tblTim.Rows.Count == 0)
            {
                return null;
            }

            DataRow row = tblTim.Rows[0];
            Tim tim = new Tim
            {
                IDTim = (int)row["IDTim"],
                Naziv = row["Naziv"].ToString()
            };

            tim.Voditelj = GetDjelatnik((int)row["VoditeljID"], tim);

            return tim;
        }
    }
}