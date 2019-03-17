using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing;
using System.Runtime.Serialization;

namespace Projekat_5._3DW.podaci
{
    class DataTipovi
    {
        private Dictionary<String, Tip> dictionaryTip = new Dictionary<String, Tip>();
        private readonly string datoteka;

        public DataTipovi()
        {
            datoteka = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                "dataTipovi.podaci");
            UcitajDatoteku();

        }

        public void Dodaj(Tip t)
        {
            if (!dictionaryTip.ContainsKey(t.Oznaka))
                dictionaryTip.Add(t.Oznaka, t);
            MemorisiDatoteku();
        }

        public void Obrisi(Tip t)
        {
            dictionaryTip.Remove(t.Oznaka);
            MemorisiDatoteku();
        }

        public Tip this[String oznaka]
        {
            get { return dictionaryTip[oznaka]; }
            set { dictionaryTip[oznaka] = value; }
        }

        public void MemorisiDatoteku()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            try
            {
                stream = File.Open(datoteka, FileMode.OpenOrCreate);
                formatter.Serialize(stream, dictionaryTip);
            }
            catch (SerializationException ex)
            {
                Console.WriteLine("Exception Message: " + ex.Message);
            }
            finally
            {
                if (stream != null)
                    stream.Dispose();
            }
        }

        private void UcitajDatoteku()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            if (File.Exists(datoteka))
            {
                try
                {
                    stream = File.Open(datoteka, FileMode.Open);
                    dictionaryTip = (Dictionary<String, Tip>)formatter.Deserialize(stream);
                }
                catch (SerializationException ex)
                {
                    Console.WriteLine("Exception Message: " + ex.Message);
                }
                finally
                {
                    if (stream != null)
                        stream.Dispose();
                }

            }
            else
                dictionaryTip = new Dictionary<String, Tip>();
        }

        public Dictionary<String, Tip> getAll()
        {
            return dictionaryTip;
        }

        public void ObrisiSve()
        {
            dictionaryTip.Clear();
            MemorisiDatoteku();

        }
    }
}
