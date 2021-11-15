using System.IO;

namespace Module2HW2
{
    public class Starter
    {
        private readonly Actions _actions = new Actions();
        private readonly Logger _logger = Logger.Instance;
        public void Run()
        {
            Configurations.Instance.CartSize = 10;
            Configurations.Instance.Currency = Сurrency.UAH;
            _actions.NewClient("Fedya", "Pupkin", 36, "pupkin@gmail.com");
            _logger.WriteToLog("ПРИШЕЛ НОВЫЙ КЛИЕНТ ПУПКИН");
            _actions.SomeTestDevices();
            _logger.WriteToLog("ТОВАРЫ СОЗДАНЫ НА СКЛАДЕ");
            _actions.SaveCurentStateInLog();
            _actions.GetFoodsToCart();
            _logger.WriteToLog("ТОВАРЫ ДОБАВЛЕНЫ В КОРЗИНУ");
            _actions.SaveCurentStateInLog();
            var numberOrder = _actions.ConfirmOrder();
            _logger.WriteToLog($"СОЗДАН ЗАКАЗ №{numberOrder} ИЗ КОРЗИНЫ");
            _actions.SaveCurentStateInLog();
            _actions.PaidOrder();
            File.WriteAllText("log.txt", Logger.Instance.GetAllLog());
        }
    }
}