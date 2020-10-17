namespace OurCooking.Network
{
    public class Manager
    {
        private static Manager _instance;
        public static Manager GetInstance()
        {
            if (_instance == null) _instance = new Manager();
            return _instance;
        }
    }
}
