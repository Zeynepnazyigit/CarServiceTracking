using System.Text.Json;
using CarServiceTracking.UI.Web.ViewModels.CustomerCars;

namespace CarServiceTracking.UI.Web.Services
{
    public class CustomerCarSessionService
    {
        private const string SessionKey = "customer_cars";
        private readonly IHttpContextAccessor _http;

        public CustomerCarSessionService(IHttpContextAccessor http)
        {
            _http = http;
        }

        private ISession Session =>
            _http.HttpContext?.Session
            ?? throw new InvalidOperationException("Session erişilemedi. UseSession() ve AddSession() açık mı?");

        public List<CustomerCarVM> GetAll()
        {
            var json = Session.GetString(SessionKey);
            if (string.IsNullOrWhiteSpace(json))
                return new List<CustomerCarVM>();

            return JsonSerializer.Deserialize<List<CustomerCarVM>>(json) ?? new List<CustomerCarVM>();
        }

        public void Add(CustomerCarVM car)
        {
            var list = GetAll();
            car.Id = list.Count == 0 ? 1 : list.Max(x => x.Id) + 1;
            list.Add(car);
            Save(list);
        }

        public CustomerCarVM? GetById(int id) => GetAll().FirstOrDefault(x => x.Id == id);

        public void SetServiceStatus(int id, bool isInService)
        {
            var list = GetAll();
            var car = list.FirstOrDefault(x => x.Id == id);
            if (car == null) return;

            car.IsInService = isInService;
            Save(list);
        }

        public void Delete(int id)
        {
            var list = GetAll();
            list.RemoveAll(x => x.Id == id);
            Save(list);
        }

        private void Save(List<CustomerCarVM> list)
        {
            var json = JsonSerializer.Serialize(list);
            Session.SetString(SessionKey, json);
        }
    }
}
