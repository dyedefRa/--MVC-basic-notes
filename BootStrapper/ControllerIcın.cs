  public class HaberController : Controller
    {
        #region Kategori Repository
        HaberContext ctx = new HaberContext();

        private readonly IHaberRepository _haberRepository;
        private readonly IKullaniciRepository _kullaniciRepository;
        private readonly IKategoriRepository _kategoriRepository;
        private readonly IResimRepository _resimRepository;
        private readonly IEtiketRepository _etiketRepository;

        public HaberController(IHaberRepository haberRepository, IKullaniciRepository kullaniciRepository, IKategoriRepository kategoriRepository, IResimRepository resimRepository, IEtiketRepository etiketRepository)
        {
            _haberRepository = haberRepository;
            _kullaniciRepository = kullaniciRepository;
            _kategoriRepository = kategoriRepository;
            _resimRepository = resimRepository;
            _etiketRepository = etiketRepository;
        }
    }