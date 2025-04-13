using System;

namespace ManajemenKaryawan
{
    // Kelas Induk
    class Karyawan
    {
        public string Nama { get; set; }
        public string ID { get; set; }
        public double GajiPokok { get; set; }

        public virtual double HitungGaji()
        {
            return GajiPokok;
        }
    }

    // Karyawan Tetap
    class KaryawanTetap : Karyawan
    {
        public override double HitungGaji()
        {
            return GajiPokok + 500000;
        }
    }

    // Karyawan Kontrak
    class KaryawanKontrak : Karyawan
    {
        public override double HitungGaji()
        {
            return GajiPokok - 200000;
        }
    }

    // Karyawan Magang
    class KaryawanMagang : Karyawan
    {
        public override double HitungGaji()
        {
            return GajiPokok;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Masukkan jenis karyawan (Tetap/Kontrak/Magang):");
            string jenis = Console.ReadLine().ToLower();

            Console.WriteLine("Masukkan nama karyawan:");
            string nama = Console.ReadLine();

            Console.WriteLine("Masukkan ID karyawan:");
            string id = Console.ReadLine();

            Console.WriteLine("Masukkan gaji pokok:");
            double gajiPokok = Convert.ToDouble(Console.ReadLine());

            Karyawan karyawan = jenis switch
            {
                "tetap" => new KaryawanTetap(),
                "kontrak" => new KaryawanKontrak(),
                "magang" => new KaryawanMagang(),
                _ => null
            };

            if (karyawan == null)
            {
                Console.WriteLine("Jenis karyawan tidak dikenali.");
                return;
            }

            karyawan.Nama = nama;
            karyawan.ID = id;
            karyawan.GajiPokok = gajiPokok;

            double gajiAkhir = karyawan.HitungGaji();

            Console.WriteLine($"\n--- Data Karyawan ---");
            Console.WriteLine($"Nama        : {karyawan.Nama}");
            Console.WriteLine($"ID          : {karyawan.ID}");
            Console.WriteLine($"Jenis       : {jenis}");
            Console.WriteLine($"Gaji Akhir  : {gajiAkhir:C}");
        }
    }
}
