using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Dokuman[] _dokumanlar = new Dokuman[2];
            _dokumanlar[0] = new Ozgecmis();
            _dokumanlar[1] = new Rapor();
            foreach (Dokuman d in _dokumanlar)
            {
                Console.WriteLine("\n"+d.GetType().Name+"--");
                foreach (Sayfa s in d.Sayfalar)
                {
                    Console.WriteLine(" " + s.GetType().Name + "--");
                }
            }
            Console.Read();
        }
    }

    abstract class Sayfa
    {

    }

    class YetenekSayfasi : Sayfa
    {

    }

    class EgitimSayfasi : Sayfa
    {

    }

    class DeneyimSayfasi : Sayfa
    {

    }

    class GirisSayfasi : Sayfa
    {

    }

    class SonucSayfasi : Sayfa
    {

    }

    class OzetSayfasi : Sayfa
    {

    }

    class BiyografiSayfasi : Sayfa
    {

    }

    abstract class Dokuman
    {
        public Dokuman() // constructor. instance alınınca direk sayfa oluşturulucak
        {
            this.SayfaOlustur();
        }

        private List<Sayfa> _sayfalar = new List<Sayfa>();

        public List<Sayfa> Sayfalar
        {
            get
            {
                return _sayfalar;
            }
        }

        public abstract void SayfaOlustur();
    }

    class Ozgecmis : Dokuman
    {
        
        public override void SayfaOlustur()
        {
            Sayfalar.Add(new GirisSayfasi());
            Sayfalar.Add(new YetenekSayfasi());
            Sayfalar.Add(new EgitimSayfasi());
            Sayfalar.Add(new DeneyimSayfasi());
        }
    }

    class Rapor : Dokuman
    {
        public override void SayfaOlustur()
        {
            Sayfalar.Add(new GirisSayfasi());
            Sayfalar.Add(new SonucSayfasi());
            Sayfalar.Add(new OzetSayfasi());
            Sayfalar.Add(new BiyografiSayfasi());
        }
    }
}
