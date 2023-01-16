
namespace FutbolDunyasi.Data
{
    public class UygulamaDbContext:DbContext
    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) :base(options)
        {

        }
        public DbSet<Takim> Takimlar => Set<Takim>();
        public DbSet<Oyuncu> Oyuncular => Set<Oyuncu>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Takim>().HasData(
                new Takim() { Id=1,Ad="Fenerbahçe"},
                new Takim() { Id=2,Ad="Galatasaray"}
                );
            modelBuilder.Entity<Oyuncu>().HasData(
                new Oyuncu() { Id = 1, Ad = "Altay Bayındır", Mevki = Mevki.Kaleci, TakimId = 1 ,FormaNo=1},
                new Oyuncu() { Id = 2, Ad = "Serdar Dursun", Mevki = Mevki.Forvet, TakimId = 1 , FormaNo = 19 },
                new Oyuncu() { Id = 3, Ad = "Fernando Muslera", Mevki = Mevki.Kaleci, TakimId = 2 , FormaNo = 1 },
                new Oyuncu() { Id = 4, Ad = "Haris Seferovic", Mevki = Mevki.Forvet, TakimId = 2, FormaNo = 9 }
                );
        }
    }
}
