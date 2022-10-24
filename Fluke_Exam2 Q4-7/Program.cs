using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluke_Exam2_Q4
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Tardis theTardis = new Tardis();
            PhoneBooth pBooth = new PhoneBooth();

            UsePhone(theTardis);
            UsePhone(pBooth);
        }
        static void UsePhone(object obj)
        {
            Tardis tardis = new Tardis();
            PhoneBooth booth = new PhoneBooth();

            if (obj.GetType() == typeof(PhoneBooth))
            {
                booth.OpenDoor();
            }
            else if (obj.GetType() == typeof(Tardis))
            {
                tardis.TimeTravel();
            }

            PhoneInterface aPhone = (PhoneInterface)obj;
            aPhone.MakeCall();
            aPhone.HangUp();
        }
    }
    public abstract class Phone
    {
        private string phoneNumber;
        public string address;
        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }
            set
            {
                this.phoneNumber = value;
            }
        }
        public abstract void Connect();
        public abstract void Disconnect();
    }
    public interface PhoneInterface
    {
        void Answer();
        void MakeCall();
        void HangUp();
    }
    public class RotaryPhone : Phone, PhoneInterface
    {
        public void Answer()
        {

        }
        public void MakeCall()
        {

        }
        public void HangUp()
        {

        }
        public override void Connect()
        {

        }
        public override void Disconnect()
        {

        }
    }
    public class PushButtonPhone : Phone, PhoneInterface
    {
        public void Answer()
        {

        }
        public void MakeCall()
        {

        }
        public void HangUp()
        {

        }
        public override void Connect()
        {

        }
        public override void Disconnect()
        {

        }
    }
    public class Tardis : RotaryPhone
    {
        private bool sonicScrewdriver;
        private byte whichDrWho;
        private string femaleSideKick;
        public double exteriorSurfaceArea;
        public double interiorVolume;
        public byte WhichDrWho
        {
            get
            {
                return this.whichDrWho;
            }
        }
        public string FemaleSideKick
        {
            get
            {
                return this.femaleSideKick;
            }
        }
        public static bool operator ==(Tardis one, Tardis two)
        {
            return one.whichDrWho == two.whichDrWho;
        }
        public static bool operator !=(Tardis one, Tardis two)
        {
            return one.whichDrWho != two.whichDrWho;
        }
        public static bool operator <(Tardis one, Tardis two)
        {
            if (one.whichDrWho == 10)
            {
                return false;
            }
            else if (two.whichDrWho == 10)
            {
                return true;
            }
            else if (one.whichDrWho == 10 && two.whichDrWho == 10)
            {
                return false;
            }
            return one.whichDrWho < two.whichDrWho;
        }
        public static bool operator >(Tardis one, Tardis two)
        {
            if (two.whichDrWho == 10)
            {
                return false;
            }
            else if (one.whichDrWho == 10)
            {
                return true;
            }
            else if (two.whichDrWho == 10 && one.whichDrWho == 10)
            {
                return false;
            }
            return one.whichDrWho > two.whichDrWho;
        }
        public static bool operator <=(Tardis one, Tardis two)
        {
            if (one.whichDrWho == 10 && two.whichDrWho == 10)
            {
                return true;
            }
            else if (one.whichDrWho == 10)
            {
                return false;
            }
            else if (two.whichDrWho == 10)
            {
                return true;
            }
            return one.whichDrWho <= two.whichDrWho;
        }
        public static bool operator >=(Tardis one, Tardis two)
        {
            if (two.whichDrWho == 10 && one.whichDrWho == 10)
            {
                return true;
            }
            else if (two.whichDrWho == 10)
            {
                return true;
            }
            else if (one.whichDrWho == 10)
            {
                return false;
            }
            return one.whichDrWho >= two.whichDrWho;
        }
        public void TimeTravel()
        {

        }
    }
    public class PhoneBooth : PushButtonPhone
    {
        private bool superMan;
        public double costPerCall;
        public bool phoneBook;
        public void OpenDoor()
        {

        }
        public void CloseDoor()
        {

        }
    }
}
