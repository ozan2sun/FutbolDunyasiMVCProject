namespace FutbolDunyasi.Models
{
    public class YeniOyuncuViewModel
    {
        [Required(ErrorMessage ="{0} alanı zorunludur.")]
        [MaxLength(100,ErrorMessage ="{0} en fazla {1} karakter içerebilir.")]
        public string Ad { get; set; } = null!;

        [Display(Name = "Forma No")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public int? FormaNo { get; set; } = default;

        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public Mevki? Mevki { get; set; } = default;

        [Display(Name = "Takım")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public int? TakimId { get; set; } = default;
    }
}
