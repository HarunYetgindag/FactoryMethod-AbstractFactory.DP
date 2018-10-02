using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            KitaFabrikasi _kita = new Afrika();
            HayvanlarAlemi _alem = new HayvanlarAlemi(_kita);
            _alem.BesinZinciriIslet();

            KitaFabrikasi _amerika = new Amerika();
            _alem = new HayvanlarAlemi(_amerika);
            _alem.BesinZinciriIslet();


            Console.Read();

        }
    }


    /*
     Etçil ve otçul hayvan
     Kıta (Afrika, Amerika)
     Besin zincirininin işletilmesi
     */

    abstract class KitaFabrikasi
    {
        public abstract EtcilHayvan EtcilOlustur();
        public abstract OtculHayvan OtculOlustur();
    }

    /* Kıta Oluşturmalar */

    class Amerika : KitaFabrikasi
    {
        
        public override EtcilHayvan EtcilOlustur()
        {
            return new Kurt();
        }

        public override OtculHayvan OtculOlustur()
        {
            return new Bizon();
        }
    }

    class Afrika : KitaFabrikasi
    {
        public override EtcilHayvan EtcilOlustur()
        {
            return new Aslan();
        }

        public override OtculHayvan OtculOlustur()
        {
            return new AfrikaAntilobu();
        }
    }

    /* ---- */

    abstract class EtcilHayvan
    {
        public abstract void Yer(OtculHayvan otcul);
    }

    abstract class OtculHayvan
    {
        //Otçul hayvanda ot yer . abstract metot olarak yazılabilir. etçil hayvan nasıl otçul hayvan yiyorsa aynı şekilde abstract metot yazılabilir.
    }

    class AfrikaAntilobu : OtculHayvan
    {

    }

    class Bizon : OtculHayvan
    {

    }

    class Aslan : EtcilHayvan
    {
        public override void Yer(OtculHayvan otcul)
        {
            Console.WriteLine(this.GetType().Name + " yer " + otcul.GetType().Name);
        }
    }

    class Kurt : EtcilHayvan
    {
        public override void Yer(OtculHayvan otcul)
        {
            Console.WriteLine(this.GetType().Name + " yer " + otcul.GetType().Name);
        }
    }

    class HayvanlarAlemi // Application Class
    {
        private OtculHayvan _otcul;
        private EtcilHayvan _etcil;

        public HayvanlarAlemi(KitaFabrikasi _fabrika)
        {
            _otcul = _fabrika.OtculOlustur();
            _etcil = _fabrika.EtcilOlustur();
        }

        public void BesinZinciriIslet()
        {
            _etcil.Yer(_otcul);
        }
    }
}
