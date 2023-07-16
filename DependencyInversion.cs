namespace SolidConsoleApp
{
    public class Television
    {
        public void SetTelevisionOn()
        {
            Console.WriteLine("Television is On!");
        }
        public void SetTelevisionOff()
        {
            Console.WriteLine("Television is Off!");
        }
    }

    public class RemoteControl // Remote only controls Television which is a concreat class, we can't control any other component because of this. It directly depends on a low level component. This violates Dependency Inversion principle.
    {
        bool isTurnedOn { get; set; }
        Television tv { get; set; }

        public RemoteControl(Television tv)
        {
            this.tv = tv;
        }

        public void Click()
        {
            isTurnedOn = !isTurnedOn;
            if (isTurnedOn)
                tv.SetTelevisionOff();
            else
                tv.SetTelevisionOff();
        }
    }

    public interface OnOffDevice
    {
        void TurnOn();
        void TurnOff();
    }

    public class AfterRemoteControl
    {
        bool isTurnedOn { get; set; }
        OnOffDevice device { get; set; }

        public AfterRemoteControl(OnOffDevice device)
        {
            this.device = device;
        }

        public void Click()
        {
            isTurnedOn = !isTurnedOn;
            if (isTurnedOn)
                device.TurnOff();
            else
                device.TurnOn();
        }
    }

    public class AfterTelevision : OnOffDevice
    {
        public void TurnOff()
        {
            SetTelevisionOff();
        }

        public void TurnOn()
        {
            SetTelevisionOn();
        }
        public void SetTelevisionOn()
        {
            Console.WriteLine("Television is On!");
        }
        public void SetTelevisionOff()
        {
            Console.WriteLine("Television is Off!");
        }
    }

    public class DependencyInversion
    {
        public static void Run()
        {
            var tv = new AfterTelevision();
            var deviceRemote = new AfterRemoteControl(tv);
            deviceRemote.Click();
        }
    }
}
