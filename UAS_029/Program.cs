using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//1.

namespace UAS_029
{
    class Node
    {
        public int nim;
        public string nama;
        public string kelas;
        public string jeniskelamin;
        public string asalKota;
        public Node next;
        public Node prev;
    }
    class DoubleLinkedList
    {
        Node START;

        public DoubleLinkedList()
        {
            START = null;
        }
        public void addNode()
        {
            int nis;
            string nm;
            string kls;
            string jk;
            string akt;
            Console.Write("\nMasukkan NIM mahasiswa: ");
            nis = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan Nama mahasiswa: ");
            nm = Console.ReadLine();
            Console.Write("\nMasukkan Kelas mahasiswa: ");
            kls = Console.ReadLine();
            Console.Write("\nMasukkan Jenis kelamin mahasiswa: ");
            jk = Console.ReadLine();
            Console.Write("\nMasukkan Asal kota mahasiswa: ");
            akt = Console.ReadLine();
            Node newNode = new Node();
            newNode.nim = nis;
            newNode.nama = nm;
            newNode.kelas = kls;
            newNode.jeniskelamin = jk;
            newNode.asalKota = akt;

            if (START == null || nis <= START.nim)
            {
                if ((START != null) && (nis == START.nim))
                {
                    Console.WriteLine("\nDuplikat NIM tidak di izinkan!");
                    return;
                }
                newNode.next = START;
                if (START != null)
                    START.prev = newNode;
                newNode.prev = null;
                START = newNode;
                return;
            }
            Node previous, current;
            for (current = previous = START;
                current != null && nis >= current.nim;
                previous = current, current = current.next)
            {
                if (nis == current.nim)
                {
                    Console.WriteLine("\nDuplikat NIM tidak di izinkan!");
                    return;
                }
            }
            newNode.next = current;
            newNode.prev = previous;

            if (current == null)
            {
                newNode.next = null;
                previous.next = newNode;
                return;
            }
            current.prev = newNode;
            previous.next = newNode;
        }
        public bool search(string kota, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;


            while ((current != null) && (kota != current.asalKota))
            {
                previous = current;
                current = current.next;
            }

            if (current == null)
                return (false);
            else
                return (true);

        }
        public bool DellNode(string kota)
        {
            Node previous, current;
            previous = current = null;
            if (search(kota, ref previous, ref current) == false)
                return false;
            if (current.next == null)
            {
                previous.next = null;
                return true;
            }
            if (current == START)
            {
                START = START.next;
                if (START != null)
                    START.prev = null;
                return true;
            }
            previous.next = current.next;
            current.next.prev = previous;
            return true;

        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
        public void ascending()
        {
            if (listEmpty())
                Console.WriteLine("\nList kosong");
            else
            {
                Console.WriteLine("\nUrutan naik dari list " + "NIM adalah:\n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.nama + " " + currentNode.nim + " " + currentNode.kelas + " "+ currentNode.jeniskelamin + " " + currentNode.asalKota + "\n");
            }
        }
        public void descending()
        {
            if (listEmpty())
                Console.WriteLine("\nList kosong");
            else
            {
                Console.WriteLine("\nUrutan menurun dari " + "NIM adalah:\n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next) { }

                while (currentNode != null)
                {
                    Console.Write(currentNode.nama + " " + currentNode.nim + " " + currentNode.kelas + " " + currentNode.jeniskelamin + " " + currentNode.asalKota + "\n");
                    currentNode = currentNode.prev;
                }
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            DoubleLinkedList obj = new DoubleLinkedList();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Tambah mahasiswa ke list");
                    Console.WriteLine("2. Hapus mahasiswa ke list");
                    Console.WriteLine("3. Tampilkan semua mahasiswa dari list dengan urutan naik NIM ");
                    Console.WriteLine("4. Tampilkan semua mahasiswa dari list dengan urutan turun NIM ");
                    Console.WriteLine("5. Cari mahasiswa di list");
                    Console.WriteLine("6. Exit\n");
                    Console.Write("Masukkan pilihan anda (1-6): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNode();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\nList kosong");
                                    break;
                                }
                                Console.Write("\nMasukkan NIM mahasiswa" +
                                    "yang akan dihapus:");
                                string nim = Convert.ToString(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.DellNode(nim) == false)
                                    Console.Write("Mahasiswa tidak di temukan");
                                else
                                    Console.WriteLine("Mahasiswa yang mempunyai NIM " + nim + " telah dihapus \n");
                            }
                            break;
                        case '3':
                            {
                                obj.ascending();
                            }
                            break;
                        case '4':
                            {
                                obj.descending();
                            }
                            break;
                        case '5':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList kosong");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("\n Masukkan asal kota mahasiswa yang akan dicari: ");
                                string kota = Convert.ToString(Console.ReadLine());
                                if (obj.search(kota, ref prev, ref curr) == false)
                                    Console.WriteLine("\nMahasiswa tidak ditemukan");
                                else
                                {
                                    Console.WriteLine("\nMahasiswa ditemukan!");
                                    Console.WriteLine("\nnama: " + curr.nama);
                                    Console.WriteLine("\nNIM: " + curr.nim);
                                    Console.WriteLine("\nnama: " + curr.kelas);
                                    Console.WriteLine("\nnama: " + curr.jeniskelamin);
                                    Console.WriteLine("\nnama: " + curr.asalKota);
                                }
                            }
                            break;
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("\nPilihan tidak tersedia");
                            }
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Silahkan cek kembali yang anda masukkan.");
                }
            }
        }
    }
}

/* 2. Saya menggunakan double link list, saya memilih algoritma double link list karena untuk memudahkan Bepe mencari mahasiswa berdasarkan asal kota dan mengurutkan mahasiswa
 * 3. Rear, Front
 * 4. Perbedaan array dan linked list adalah linked list tidak memiliki limit upper bound untuk ukuran stack, sedangkan array memiliki limit upper bound,
 * array dipakai ketika data memiliki batas, dan linked list dipakai saat data tidak memiliki batas
 * 5. a. Parents = 10, 10, 15, 15, 18, 30, 20, 20, 25
 *       child   = 5, 10, 15, 15, 12, 16, 18, 20, 20, 32, 25, 20, 28
 *    b. Inorder : 1. Traverse the left subtree
 *                 2. Visit root
 *                 3. Traverse the right subtree
 * urutan : 5, 10, 10, 12, 15, 15, 16, 18, 20, 20, 20, 20, 25, 28, 30, 32
 */
