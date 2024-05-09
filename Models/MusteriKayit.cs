using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DenemeProject.Models
{
    [Table("MusteriKayits")]
    public class MusteriKayit
    {
        [Key]
        public int MusteriID{ get; set; }

        public string Ad { get; set; }

        public string Soyad { get; set; }

        public int Yas { get; set; }

        public string Cinsiyet { get; set; }

        public DateTime DogumTarihi { get; set; }

        public string Meslek { get; set; }

        public string MezunOlduguOkul { get; set; }

        public string Telefon { get; set; }

        public string Sehir { get; set; }

        public string Adres { get; set; }



    }
}
