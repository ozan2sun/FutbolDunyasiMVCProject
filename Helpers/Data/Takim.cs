
namespace FutbolDunyasi.Data
{
    public class Takim
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Ad { get; set; } = null!;
        public List<Oyuncu> Oyuncular { get; set; } = new List<Oyuncu>();
    }
}
