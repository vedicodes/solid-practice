namespace SolidConsoleApp
{
    public interface VendingMachine // We have a polluted interface. We have many un-related methods. This interface has low cohesion because we have many un-related methods.
    {
        void TakeMoney();
        void BrewCoffe();
        void BrewTea();
        void DispenseWater();
        void DispenseSoda();
        void DispenseSnacks();
    }

    public class SnackVendingMachine : VendingMachine // The class is dependent on methods that it doesn't relay on. This violates Interface Segregation principle.
    {
        string amount { get; set; }

        public void BrewCoffe()
        {
            throw new NotImplementedException();
        }

        public void BrewTea()
        {
            throw new NotImplementedException();
        }

        public void DispenseSnacks()
        {
            if (!string.IsNullOrEmpty(amount))
            {
                Console.WriteLine("Dispensing Snacks!");
            }
        }

        public void DispenseSoda()
        {
            throw new NotImplementedException();
        }

        public void DispenseWater()
        {
            throw new NotImplementedException();
        }

        public void TakeMoney()
        {
            Console.WriteLine("Please Enter Amount: ");
            amount = Console.ReadLine();
        }
    }

    public interface AfterVendingMachine
    {
        void TakeMoney();
    }

    public interface ColdBevrages : AfterVendingMachine
    {
        void DispenseWater();
        void DispenseSoda();
    }

    public interface HotBevrages : AfterVendingMachine
    {
        void BrewCoffe();
        void BrewTea();
    }

    public interface Snacks : AfterVendingMachine
    {
        void DispenseSnacks();
    }

    public class AfterSnackVendingMachine : Snacks
    {
        string amount { get; set; }

        public void DispenseSnacks()
        {
            if (!string.IsNullOrEmpty(amount))
            {
                Console.WriteLine("Dispensing Snacks!");
            }
        }

        public void TakeMoney()
        {
            Console.WriteLine("Please Enter Amount: ");
            amount = Console.ReadLine();
        }
    }

    public class InterfaceSegregation
    {
        public static void Run()
        {
            var snackVending = new AfterSnackVendingMachine();
            snackVending.TakeMoney();
            snackVending.DispenseSnacks();
        }
    }
}
