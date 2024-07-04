namespace API_Bibliotek.Models
{
    public class Bok
    {
        public int BokID { get; set; }
        public string Tittel { get; set; }
        public string ISBN { get; set; }
        public DateTime PubliseringsDato { get; set; }
    }

}
