using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_094
{
    class Node
    {
        public int IDBarang;
        public string NamaBarang;
        public string JenisBarang;
        public string HargaBarang;
        public Node next;
        public Node prev;
    }
    class list
    {
        Node START;
        public list()
        {
            START = null;
        }
        public void addnode()
        {
            int id;
            string NM, JNS, HRG;
            Console.Write("\nMasukan ID Barang :");
            id = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukan Nama Barang :");
            NM = Console.ReadLine();
            Console.Write("\nMasukan Jenis Barang :");
            JNS = Console.ReadLine();
            Console.Write("\nMasukan Harga Barang :");
            HRG = Console.ReadLine();
            Node newnode = new Node();

            newnode.IDBarang = id;
            newnode.NamaBarang = NM;
            newnode.JenisBarang = JNS;
            newnode.HargaBarang = HRG;


            if (START == null || id <= START.IDBarang)
            {
                if ((START != null) && (id == START.IDBarang))
                {
                    Console.WriteLine("\nDuplicate ID Barang not allowed\n");
                    return;
                }
                newnode.next = START;
                START = newnode;
                return;
            }
            Node previous, current;
            previous = START;
            current = START;

            while ((current != null) && (id >= current.IDBarang))
            {
                if (id == current.IDBarang)
                {
                    Console.WriteLine("\nDuplicate ID Barang not allowed\n");
                    return;
                }
                previous = current;
                current = current.next;
            }
            newnode.next = current;
            previous.next = newnode;
        }
        public void traverse()
        {
            if (listEmpty())
            {
                Console.WriteLine("\nList is empt.\n");
            }
            else
            {
                Console.WriteLine("\nList Barang yang ada : ");
              
                Node currentNode;
                for (currentNode = START; currentNode != null;
                    currentNode = currentNode.next)

                {
                    Console.Write(currentNode.JenisBarang + " " + currentNode.NamaBarang + " " + currentNode.HargaBarang + " " + currentNode.IDBarang + " ");
                }
                Console.WriteLine();

            }
        }
     
        public bool Search (string JNS, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;
            while ((current != null) && (JNS != current.JenisBarang))
            {
                previous = current;
                current = current.next;
            }
            if (current == null)
                return (false);
            else
                return (true);
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
    }
    class program
    {
        static void Main(string[] args)
        {
            list obj = new list();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMENU");
                    Console.WriteLine("1. Tambahkan data");
                    Console.WriteLine("2. Tampilkan seluruh data yang ada");
                    Console.WriteLine("3. Cari data yang ada");
                    Console.WriteLine("4. EXIT");
                    Console.Write("\nEnter your choice (1-4) : ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addnode();
                            }
                            break;
                        
                        case '2':
                            {
                                obj.traverse();
                            }
                            break;
                        case '3':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Node previous, current;
                                previous = current = null;
                                Console.Write("\nMasukan jenis barang : ");
                                string NUM = Console.ReadLine();
                                if (obj.Search(NUM, ref previous, ref current) == false)
                                    Console.WriteLine("\nRecord not found.");
                                else
                                {
                                    Node JNS;
                                    for (JNS = current; JNS != null; JNS = JNS.next)
                                    {
                                        Console.WriteLine("\nRecord found");
                                        Console.WriteLine("\nJenis Barang: " + current.JenisBarang);
                                        Console.WriteLine("\nNama Barang: " + current.NamaBarang);
                                        Console.WriteLine("\nHarga Barang: " + current.HargaBarang);
                                        Console.WriteLine("\nID Barang: " + current.IDBarang);
                                    }
                                }
                            
                            }
                            break;
                        case '4':
                            return;
                        default:
                            {
                                Console.WriteLine("\nInvalid Option");
                                break;
                            }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nCheck for the value enterted");
                }
            }
        }
    }
}


//NO 2.Singly linked list adalah algoritma yang cocok digunakan dalam situasi di mana data harus ditambahkan atau dihapus dari awal atau akhir dari daftar.
//NO 3. array itu terdapat batasannya 
//NO 4. Rear dan font
//NO 5. (a) 46 & 55, 62 & 64, 16 & 53, 41 & 47, 63 & 70
//(b) preorder = 60,41,16,25,53,46,42,55,74,65,63,62,64,70//