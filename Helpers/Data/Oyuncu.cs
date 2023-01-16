namespace FutbolDunyasi.Data
{
    public class Oyuncu
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Ad { get; set; } = null!;

        [Display(Name ="Forma No")]
        public int FormaNo { get; set; }

        public Mevki Mevki { get; set; }
        public int TakimId { get; set; }
        public Takim? Takim { get; set; }
    }
}
