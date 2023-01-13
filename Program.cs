using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_001
{
    class Node
    {
        public string namaMhs, jnsKel, kelas, kotaAsal;
        public int NIM;
        public Node next;
        public Node prev;

    }
    class Program
    {
        Node START;
        public Program()
        {
            START = null;
        }
        public bool Search(string kotaAsal, ref Node previous, ref Node current)
        {
            for (current = previous = START; current != null && string.Compare(kotaAsal, current.kotaAsal) == 0; previous = current, current = current.next)
            {
                Console.WriteLine(" -> " + current.jnsKel + "  " + current.NIM + "  " + current.namaMhs + "  " + current.kelas + "  " + current.kotaAsal);
            }

            return (current != null);
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
        public void traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nData kosong!");
            else
            {
                Console.WriteLine("\nData Mahasiswa yang tersedia adalah:\n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.NIM + " " + currentNode.namaMhs + " " + currentNode.jnsKel + " " + currentNode.kelas + " " + currentNode.kotaAsal + "\n");
            }
        }
        public void revtraverse()
        {
            if (listEmpty())
                Console.WriteLine("\nData Mahasiswa kosong");
            else
            {
                Console.WriteLine("\nData Mahasiswa dari urutan terbawah " + "adalah:\n");
                Node currentNode;
                for (currentNode = START; currentNode.next != null; currentNode = currentNode.next)
                { }
                while (currentNode != null)
                {
                    Console.Write(currentNode.NIM + " " + currentNode.namaMhs + " " + currentNode.jnsKel + " " + currentNode.kelas + " " + currentNode.kotaAsal + "\n");
                    currentNode = currentNode.prev;
                }
            }
        }
        public void addMhs()
        {
            Console.Write("\nMasukkan NIM Mahasiswa: ");
            int nimmahasiswa = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan Nama Mahasiswa: ");
            string namamahasiswa = Console.ReadLine();
            Console.Write("\nMasukkan Jenis Kelamin: ");
            string jeniskelamin = Console.ReadLine();
            Console.Write("\nMasukkan kelas mahasiswa: ");
            string kelasmahasiswa = Console.ReadLine();
            Console.Write("\nMasukkan kota asal mahasiswa: ");
            string kotaasal = Console.ReadLine();

            Node newnode = new Node();
            newnode.NIM = nimmahasiswa;
            newnode.namaMhs = namamahasiswa;
            newnode.kotaAsal = kotaasal;
            newnode.jnsKel = jeniskelamin;
            newnode.kelas = kelasmahasiswa;


            if (START == null || nimmahasiswa == START.NIM)
            {
                if ((START != null) && (nimmahasiswa == START.NIM))
                {
                    Console.WriteLine("\nData duplikat tidak diperbolehkan");
                    return;
                }
                newnode.next = START;
                if (START != null)
                    START.prev = newnode;
                newnode.prev = null;
                START = newnode;
                return;
            }
            Node previous, current;
            for (current = previous = START; current != null &&
                nimmahasiswa != current.NIM; previous = current, current =
                current.next)
            {
                if (nimmahasiswa == current.NIM)
                {
                    Console.WriteLine("\nData sama tidak diperbolehkan");
                    return;
                }
            }

            newnode.next = current;
            newnode.prev = previous;

            if (current == null)
            {
                newnode.next = null;
                previous.next = newnode;
                return;
            }
            current.prev = newnode;
            previous.next = newnode;
        }
        public bool delMHS(string jnsKel)
        {
            Node previous, current;
            previous = current = null;
            if (Search(jnsKel, ref previous, ref current) == false)
                return false;
            if (current == START)
            {
                START = START.next;
                if (START != null)
                    START.prev = null;
                return true;

            }
            if (current.next == null)
            {
                previous.next = null;
                return true;
            }
            previous.next = current.next;
            current.next.prev = previous;
            return true;
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            while (true)
            {
                try
                {
                    Console.WriteLine("\n Menu Data Mahasiswa " +
                        "\n 1. Menampilkan semua data Mahasiswa" +
                        "\n 2. Mencari Nama Mahasiswa berdasarkan kota asal " +
                        "\n 3. Menampilkan data dari urutan terbawah" +
                        "\n 4. Menambah data Mahasiswa" +
                        "\n 5. Menghapus data Mahasiswa" +
                        "\n 6. Keluar" +

                        "\n Masukkan pilihan anda (1 - 6): "
                        );
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                p.traverse();
                            }
                            break;
                        case '2':
                            {
                                if (p.listEmpty())
                                {
                                    Console.WriteLine("\nData kosong!");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("Masukkan Data Mahasiswa Berdasarkan Kota Asal: ");
                                string namaMahasiswa = Console.ReadLine();
                                if (p.Search(namaMahasiswa, ref prev, ref curr) == false)
                                    Console.WriteLine("\nData ditemukan");
                                else
                                {
                                    Console.WriteLine("\nData ditemukan!");
                                    Console.WriteLine("\nNIM Mahasiswa " + curr.NIM);
                                    Console.WriteLine("\nNama Mahasiswa " + curr.namaMhs);
                                    Console.WriteLine("\nJenis Kelamin " + curr.jnsKel);
                                    Console.WriteLine("\nKelas Mahasiswa " + curr.kelas);
                                    Console.WriteLine("\nKota Asal " + curr.kotaAsal);

                                }
                            }
                            break;
                        case '3':
                            {
                                p.revtraverse();
                            }
                            break;
                        case '4':
                            {

                                p.addMhs();
                            }
                            break;
                        case '5':
                            {
                                if (p.listEmpty())
                                {
                                    Console.WriteLine("\nData Mahasiswa Kosong!");
                                    break;
                                }
                                Console.Write("Masukkan Kota Asal Mahasiswa dari data" + " yang datanya ingin dihapus: ");
                                string kotaasal = Console.ReadLine();
                                Console.WriteLine();
                                if (p.delMHS(kotaasal) == false)
                                    Console.WriteLine("Data tidak ditemukan!");
                                else
                                    Console.WriteLine("Data Kota Asal " + kotaasal + " telah terhapus \n");
                            }
                            break;
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("\nPilihan salah!");
                            }
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}

//2.Saya mengunakan double linked list,karena karena penyisipan dapat dilakukan sebelum dan sesudah data tertentu,jadi saat ingin mencari lebih mudah dan efisien.
//Double Linked List adalah linked list dengan node yang memiliki data dan dua buah reference link (biasanyadisebut next dan prev) yang menunjuk ke node sebelum dan node sesudahnya.
//3.rear dan front
//4.Array adalah kumpulan objek data yang mirip satu sama lain dan disimpan di lokasi memori secara berurutan.
//Sementara itu, linked list merupakan sekumpulan data yang berisi urutan elemen dalam strukturnya.
//Setiap elemen saling terkait dengan elemen , Linked list digunakan untuk mengimplementasikan struktur data lain seperti stack, queue, ataupun graf.
//dan Kita menggunakan array ketika ingin menyimpam banyak data.
//5 a.
//parent 10 childern 5 dan 15 
//parent 30 childern 20 dan 32
//parent 15 childern 10 dan 15
//parent 25 childern 20 dan 28

//b. 5 10 10 12 15 15 16 18 20 20 20 25 28 30 32(inorder traversal)