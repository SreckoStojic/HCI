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
    class DataEtikete
    {
        private Dictionary<String, Etiketa> dictionaryEtiketa = new Dictionary<String, Etiketa>();
        private readonly string datoteka;

        public DataEtikete() {
            datoteka = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                "dataEtikete.podaci");
            UcitajDatoteku();

        }

        public void Dodaj(Etiketa e) {
            if (! dictionaryEtiketa.ContainsKey(e.Oznaka))  
                dictionaryEtiketa.Add(e.Oznaka, e);
            MemorisiDatoteku();
        }

        public void Obrisi(Etiketa e) {
            dictionaryEtiketa.Remove(e.Oznaka);
            MemorisiDatoteku();
        }

        public Etiketa this[String oznaka] {
            get { return dictionaryEtiketa[oznaka]; }
            set { dictionaryEtiketa[oznaka] = value; }
        }

        public void MemorisiDatoteku()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            try
            {
                stream = File.Open(datoteka, FileMode.OpenOrCreate);
                formatter.Serialize(stream, dictionaryEtiketa);
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
                    dictionaryEtiketa = (Dictionary<String, Etiketa>)formatter.Deserialize(stream);
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
                dictionaryEtiketa = new Dictionary<String, Etiketa>();
        }

        public Dictionary<String, Etiketa> getAll()
        {
            return dictionaryEtiketa;
        }

        public void ObrisiSve()
        {
            dictionaryEtiketa.Clear();
            MemorisiDatoteku();

        }
    }
}
