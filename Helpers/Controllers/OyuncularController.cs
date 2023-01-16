using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

#nullable disable

namespace FutbolDunyasi.Controllers
{
    public class OyuncularController : Controller
    {
        private readonly UygulamaDbContext _db;

        public OyuncularController(UygulamaDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Oyuncular.Include(x=>x.Takim).ToList());
        }
        
        public IActionResult Yeni()
        {
            TakimlariYukle();
            return View();
        }
        [HttpPost]
        public IActionResult Yeni(YeniOyuncuViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _db.Add(new Oyuncu()
                {
                    Ad=vm.Ad,
                    FormaNo=vm.FormaNo.Value,
                    Mevki=vm.Mevki.Value,
                    TakimId=vm.TakimId.Value
                });
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            TakimlariYukle();
            return View();
        }

        //GET:Oyuncular/Sil/3
        //    Controller/Action/id
        public IActionResult Sil(int id)
        {
            var oyuncu = _db.Oyuncular.Find(id);

            if (oyuncu == null)
                return NotFound();
            
            return View(oyuncu);
        }
        [HttpPost]
        //POST:Oyuncular/Sil/id
        public IActionResult Sil(Oyuncu oyuncu)
        {
            _db.Remove(oyuncu);
            _db.SaveChanges();

            return RedirectToAction("Index", new {mesaj="silindi"});
        }

        public IActionResult Duzenle(int id)
        {
            var oyuncu = _db.Oyuncular.Find(id);

            if (oyuncu == null)
                return NotFound();

            TakimlariYukle();

            return View(new DuzenleOyuncuViewModel()
            {
                Id= oyuncu.Id,
                Ad=oyuncu.Ad,
                FormaNo=oyuncu.FormaNo,
                Mevki=oyuncu.Mevki,
                TakimId=oyuncu.TakimId,
            });
        }
        [HttpPost]
        public IActionResult Duzenle(DuzenleOyuncuViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var oyuncu = new Oyuncu()
                {
                    Id = vm.Id,
                    Ad = vm.Ad,
                    FormaNo = vm.FormaNo.Value,
                    Mevki = vm.Mevki.Value,
                    TakimId = vm.TakimId.Value
                };
                _db.Update(oyuncu);
                _db.SaveChanges();
                //mesaj olarak başarıyla nasıl göndeririz yöntem 2

                TempData["BasariMesaji"] = $"\"{vm.Ad}\" adlı oyuncunun bilgileri başarıyla güncellendi.";
                return RedirectToAction("Index");
            }


            TakimlariYukle();
            return View();
        }

        private void TakimlariYukle()
        {
            ViewBag.Takimlar = _db.Takimlar.Select(x => new SelectListItem(x.Ad, x.Id.ToString())).ToList();
        }
    }
}
