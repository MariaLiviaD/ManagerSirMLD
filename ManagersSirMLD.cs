/*
 
Metode de programare 

Divide Et Impera (Prezentare Generala)

cu Aplicatie:

Crearea unei clase denumita 
        "ManagerSirMLD" 
care are urmatoarele proprietati: 

    n=numarul de elemente reale ale sirului; 
    min=elementul cu valoarea minima a sirului; 
    max=elementul cu valoarea maxima a sirului; 
    s[n]= sirul in sine; 

si care are urmatoarele metode: 

    Initializare (citire din fisier extern si evaluare proprietati initiale); 
    Citire sir; (cu Divide-et-Impera)
    Calculare Minim si Maxim; (cu Divide-et-Impera)
    Evaluare erori; 
    Cautare element in sir ordonat (cautare binara) (cu Divide-et-Impera);  
    Ordonare sir crescator si descrescator; 
    Evaluare stare ordonare sir; 

Elemente invatate:
    *Conceptul OOP (Object Oriented Programming - Programarea Orientata pe Obiecte)
    *Conceptul de programare Divide et Impera
    *
*/

using System;
using System.IO; //similar <iostream.h> din c++

namespace NSManagerSirMLD
{
    public class CLManagerSirMLD
    {
        public int NumarElemente; //numarul de elemente al sirului - proprietate publica accesibila a obiectului (clasei) (in tema descris ca (n))

        public double ElementMinim; //elementul cel mai mic al sirului - proprietate publica accesibila a obiectului (clasei) (in tema descris ca (min))

        public double ElementMaxim; //elementul cel mai mare al sirului - proprietate publica accesibila a obiectului (clasei) (in tema descris ca (max))

        public double[] sir; // sirul de numere reale - proprietate publica accesibila a obiectului (clasei) (in tema descris ca s(n))

        public int[] x; //vectorul in care voi introduce elementele vectorului sir in ordine crescatoare
        public void Initializare() // functia care citeste dintr-un fisier tot datele de acolo. 
        {
            /*
             *  Fisierul este un fisier .ini care contine setarile initiale ale programului. 
             */
            Console.WriteLine("Introduceti numarul de elemente al sirului: ");
            NumarElemente = Convert.ToInt32(Console.ReadLine());
            sir = new double[NumarElemente];
            CitireSirTastatura(0, NumarElemente - 1);
            ElementMinim = CalculareMin(0, NumarElemente - 1);
            ElementMaxim = CalculareMax(0, NumarElemente - 1);
        }

        public void CitireSirTastatura(int primul, int ultimul) // functia care citeste sirul de la tastatura. 
        {
            /*
             *  Citirea se face prin metroda Divide et Impera
             */
            int pozCurenta; // pozitia curenta

            if (primul < ultimul)
            {
                pozCurenta = (primul + ultimul) / 2; //alege punctul median
                CitireSirTastatura(primul, pozCurenta); // 
                CitireSirTastatura(pozCurenta + 1, ultimul);
            }
            else
            {
                Console.WriteLine("Introduceti valoaarea reala a sirului: ");
                string str = Console.ReadLine();
                sir[primul] = double.Parse(str);
            }
        }

        private double CalculareMin(int primul, int ultimul) // functia care calculeaza valoarea minima a sirului. 
        {
            /*
             *  Calcularea se face prin Divide et Impera = aplicatia 1  din manualul atasat. 
             */
            int pozCurenta;
            double min1, min2;
            if (primul < ultimul)
            {
                pozCurenta = (primul + ultimul) / 2;
                min1 = CalculareMin(primul, pozCurenta);
                min2 = CalculareMin(pozCurenta + 1, ultimul);
                if (min1 < min2)
                {
                    return min1;
                }
                else
                {
                    return min2;
                }
            }
            else
            {
                return sir[primul];
            }
        }
        private double CalculareMax(int primul, int ultimul) // functia care calculeaza valoarea maxima a sirului
        {
            /*
             *   Calcularea se face prin Divide et Impera
             */
            int pozCurenta;
            double max1, max2;
            if (primul < ultimul)
            {
                pozCurenta = (primul + ultimul) / 2;
                max1 = CalculareMax(primul, pozCurenta);
                max2 = CalculareMax(pozCurenta + 1, ultimul);
                if (max1 > max2)
                {
                    return max1;
                }
                else
                {
                    return max2;
                }
            }
            else
            {
                return sir[primul];
            }
        }

        public void Sortare(int primul,int ultimul, double[] sir)
        {
            int mijloc;
            if (sir[primul] > sir[ultimul])
            {
                mijloc = (int) sir[primul];
                sir[primul] = sir[ultimul];
                sir[ultimul] = mijloc;
            }
        }

        public void Interschimbare(int primul, int ultimul, int mijloc,double[]sir)
        {
            x = new int[NumarElemente];
            int i, j, k;
            i = primul;
            j = mijloc + 1;
            k = 1;
            while(i<=mijloc && j<= ultimul)
            {
                if(sir[i] <= sir[j])
                {
                    x[k] = (int) sir[i];
                    i++;
                    k++;
                }
                else
                {
                    x[k] = (int)sir[j];
                    j++;
                    k++;
                }
            }
            if(i <= mijloc)
            {
                for(j=i;j<= mijloc;j++)
                {
                    x[k] = (int)sir[j];
                    k++;
                }
            }
            else
            {
                for(i=j;j<=ultimul;j++)
                {
                    x[k] = (int)sir[i];
                    k++;
                }
            }
            k = 1;
            for(i = primul; i<= ultimul; i++)
            {
                sir[i] = x[k];
                k++;
            }
        }

        public void divimp(int primul,int ultimul, double[] sir)
        {
            int mijloc;
            if((ultimul-primul)<=1)
            {
                Sortare(primul, ultimul,  sir);
            }
            else
            {
                mijloc = (primul + ultimul) / 2;
                divimp(primul, mijloc, sir);
                divimp(mijloc + 1, ultimul, sir);
                Interschimbare(primul, ultimul, mijloc, sir);
            }
        }
    }
}
