using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace МагазинМузыкальныхДисков
{
    public interface IStoreItem
    {
        double Price { get; set; }


        void DiscountPrice(int percent);
    }
    class Disc : IStoreItem
    {
        public string _name;
        protected string _genre;
        protected int _burnCount = 0;

        public Disc(string name, string genre)
        {
            _name = name;
            this._genre = genre;
        }

        public double Price { get; set; }

        public virtual int DiscSize { get; set; }

        public virtual void Burn(params string[] values) { }
        public void DiscountPrice(int percent)
        {
            Price = Price * (double)(100 - percent) / 100;
            Console.WriteLine("Цена с учетом скидки: " + Price);
        }
    }

    class Audio : Disc
    {
        string _artist, _recordingStudio;
        int _songsNumber;
        public Audio(string artist, string recordingStudio, int songsNumber, string name, string genre) : base(name, genre)
        {
            _artist = artist;
            _recordingStudio = recordingStudio;
            _songsNumber = songsNumber;
        }
        public override int DiscSize
        {
            get { return _songsNumber * 8; }
        }

        public override void Burn(params string[] values)
        {
            _artist = values[0];
            _recordingStudio = values[1];
            _name = values[2];
            _genre = values[3];
            _burnCount++;
        }

        public override string ToString()
        {
            return $"Название: {_name}, жанр: {_genre}, исполнитель {_artist}, студия звукозаписи {_recordingStudio}, количество песен {_songsNumber}, количество прожигов: {_burnCount}.";
        }
    }

    class DVD : Disc
    {
        string _producer, _filmCompany;
        int _minutesCout;

        public DVD(string producer, string filmCompany, int minutesCout, string name, string genre) : base (name, genre)
        {
            _producer = producer;
            _filmCompany = filmCompany;
            _minutesCout = minutesCout;
        }

        public override int DiscSize
        {
            get { return (_minutesCout / 64) * 2; }
        }

        public override void Burn(params string[] values)
        {
            _producer = values[0];
            _filmCompany = values[1];
            _name = values[2];
            _genre = values[3];
            _burnCount++;
        }

        public override string ToString()
        {
            return $"Название: {_name} жанр: {_genre}, режиссер: {_producer}, кинокомпания: {_filmCompany}, количество минут: {_minutesCout}, количество прожигов: {_burnCount}";
        }
    }

    class Store
    {
        public string _Storename, _address;
        public List<Disc> _audios = new List<Disc> { };
        public List<Disc> _dvds = new List<Disc> { };

        public Store(string storename, string address)
        {
            _Storename = storename;
            _address = address;
        }

        public List<Disc> AddAudio(params Disc[] value)
        {
            foreach (Disc disc in value)
                _audios.Add(disc);
            return _audios;
        }

        public List<Disc> DeletAudio(params Disc[] args)
        {
            foreach (Disc disc in args)
                _audios.Remove(disc);
            return _audios;
        }

        public List<Disc> AddDVD(params Disc[] value)
        {
            foreach (Disc disc in value)
                _dvds.Add(disc);
            return _dvds;
        }

        public List<Disc> DeletDVD(params Disc[] args)
        {
            foreach(Disc disc in args)
                _dvds.Remove(disc);
            return _dvds;
        }

        public override string ToString()
        {
            foreach (Disc disc in _audios)
            {
                Console.WriteLine(disc.ToString());
            }

            foreach (Disc disc1 in _dvds)
            {
                Console.WriteLine(disc1.ToString());
            }

            return "";
        }
    }


}
