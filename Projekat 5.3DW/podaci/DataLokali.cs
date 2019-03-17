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
    class DataLokali
    {
        private Dictionary<String, Lokal> dictionaryLokal = new Dictionary<String, Lokal>();
        private readonly string datoteka;

        public DataLokali()
        {
            datoteka = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                "dataLokali.podaci");
            UcitajDatoteku();

        }

        public void Dodaj(Lokal l)
        {
            if (!dictionaryLokal.ContainsKey(l.Oznaka))
                dictionaryLokal.Add(l.Oznaka, l);
            MemorisiDatoteku();
        }

        public void Obrisi(Lokal l)
        {
            dictionaryLokal.Remove(l.Oznaka);
            MemorisiDatoteku();
        }

        public Lokal this[String oznaka]
        {
            get { return dictionaryLokal[oznaka]; }
            set { dictionaryLokal[oznaka] = value; }
        }

        public void MemorisiDatoteku()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            try
            {
                stream = File.Open(datoteka, FileMode.OpenOrCreate);
                formatter.Serialize(stream, dictionaryLokal);
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
                    dictionaryLokal = (Dictionary<String, Lokal>)formatter.Deserialize(stream);
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
                dictionaryLokal = new Dictionary<String, Lokal>();
        }

        public Dictionary<String, Lokal> getAll()
        {
            return dictionaryLokal;
        }

        public void ObrisiSve()
        {
            dictionaryLokal.Clear();
            MemorisiDatoteku();

        }
    }
}
