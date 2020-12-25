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

        public double ElementMaxim; //elementul cel mai mare al sirului - proprietate publica sccesibila a obiectului (clasei) (in tema descris ca (max))

        public double [] sir; // sirul de numere reale - proprietate publica accesibila a obiectului (clasei) (in tema descris ca s(n))
        
        public void Initializare() // functia care citeste dintr-un fisier tot datele de acolo. 
        {
            /*
             *  Fisierul este un fisier .ini care contine setarile initiale ale programului. 
             */
            Console.WriteLine("Introduceti numarul de elemente al sirului: ");
            NumarElemente = Convert.ToInt32(Console.ReadLine());
            sir = new double[NumarElemente];
            CitireSirTastatura(0,NumarElemente-1);
            ElementMinim=CalculareMin(0,NumarElemente-1);
        }

        public void CitireSirTastatura(int primul, int ultimul ) // functia care citeste sirul de la tastatura. 
        {
            /*
             *  Citirea se face prin metroda Divide et Impera
             */
            int pozCurenta; // pozitia curenta

            if (primul<ultimul)
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
             *  Calcularea se face prin Divide et Impera = aplicatiile 1 si 2 din manualul atasat. 
             */
            int pozCurenta;
            double min1, min2; 
            if (primul<ultimul)
            {
                pozCurenta = (primul + ultimul) / 2;
                min1 = CalculareMin(primul, pozCurenta);
                min2 = CalculareMin(pozCurenta + 1, ultimul);
                if (min1<min2)
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

    }
}
