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
    >>>Citire Sire din fisier cu selectare prin windows; 
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
using IniParser; //biblioteca ce iti ofera posibilitatea de a lucra cu fisiera de tip .ini
using IniParser.Model; //biblioteca ce iti ofera posibilitatea de a lucra cu fisiera de tip .ini

namespace NSManagerSirMLD
{
    public class CLManagerSirMLD
    {
        public int NumarElemente; //numarul de elemente al sirului - proprietate publica accesibila a obiectului (clasei) (in tema descris ca (n))

        public double ElementMinim; //elementul cel mai mic al sirului - proprietate publica accesibila a obiectului (clasei) (in tema descris ca (min))

        public double ElementMaxim; //elementul cel mai mare al sirului - proprietate publica accesibila a obiectului (clasei) (in tema descris ca (max))

        public double[] sir; // sirul de numere reale - proprietate publica accesibila a obiectului (clasei) (in tema descris ca s(n))

        public double[] x; //vectorul in care voi introduce elementele vectorului sir in ordine crescatoare

        public string CaleFisierIntrare; //calea catre fisierul de citit

        public double ElementCautat; // elementul ce va fi cautat in sir
        public void Initializare() // functia care citeste dintr-un fisier tot datele de acolo. 
        {
            /*
             *  Fisierul este un fisier .ini care contine setarile initiale ale programului. 
             */
            //ElementMinim = CalculareMin(0, NumarElemente - 1);
            //ElementMaxim = CalculareMax(0, NumarElemente - 1);
        }
        public void AfiseazaElementeSir() //functia care afiseaza elementele sirului citite din fisierul .ini
        {
            Console.WriteLine("Numarul de elemente al sirului este: " + NumarElemente); //mesaj ce afiseaza numarul de elemente citit din fisier
            for (int i=0; i< NumarElemente; i++) //pentru i = 0 mai mic decat NumarElemente se afiseaza elementele sirului + pozitia acestora in sir
            {
                Console.WriteLine("Sir["+i+"]="+ sir[i]);
            }
        }
        public void CitireSirTastatura() // functia care citeste elementele sirului de la tastatura
        {
            Console.WriteLine("Introduceti numarul de elemente al sirului: "); //scrie mesaj in consola
            NumarElemente = Convert.ToInt32(Console.ReadLine()); //transforma numarul citit si il pune in proprietatea NumarElemente
            sir = new double[NumarElemente]; // instantiaza sirul cu Numar de Elemente
            CitireSirTastaturaDivEtImp(0, NumarElemente - 1); // citeste sirul cu Divide Et Impera de la tastatura. 
        }

        private void CitireSirTastaturaDivEtImp(int primul, int ultimul) // functia care citeste sirul de la tastatura. 
        {
            /*
             *  Citirea se face prin metroda Divide et Impera
             */
            int pozCurenta; // pozitia curenta
            string str; // variabila folosita la citirea de la tastatura

            if (primul < ultimul)
            {
                pozCurenta = (primul + ultimul) / 2; //alege punctul median
                CitireSirTastaturaDivEtImp(primul, pozCurenta); //
                CitireSirTastaturaDivEtImp(pozCurenta + 1, ultimul);
            }
            else
            {
                Console.WriteLine("Introduceti valoaarea reala a sirului: "); // scrie un mesaj
                str = Console.ReadLine(); //citeste de la tastatura
                sir[primul] = double.Parse(str); // transforma un numar in sir
            }
        }

        public void CitireSirFisier (string cale) // citeste Numarul de elemente si stringul Sir dintr-un fisier dat.
        {
            /*
             * folsoeste codul ini-parser din internet pentru a citi fisierele tip .ini structurate
             */
            var parser = new FileIniDataParser(); //  instantiaza obiectul Parser
            IniData data = parser.ReadFile(cale); // citeste datele din fisierul indicat
            string numar = data["Initiere Sir"]["NumarElemente"]; // citeste elementul "NumarElemente"
            string elementesir = data["Initiere Sir"]["ElementeSir"]; //citeste elementul "ElementeSir"

            NumarElemente = Convert.ToInt32(numar); //transformarea "numarr" ului in int in cazul in care string-ul acestura contine un caracter char
            sir = new double[NumarElemente]; //instantierea sirului cu Numar de Elemente

            string s = elementesir; //initializam un element s de tip string cu elementesir
            char[] separators = new char[] { ',' }; //variabila de tip char "separators" este initializata cu caracterele ce se regases in sir si vor fi indepartate
            // pentru ca acestea sa nu fie in incluse in vectorul ce va pastra elementele sirului;
            //sirul nostru reprezinta un text 

            string[] subs = s.Split(separators, StringSplitOptions.RemoveEmptyEntries); // vectorul de tip string "subs" va memora "cifrele" textului nostru ce reprezinta 
            //elementele sirului

            int k = 0; // initializam cu 0 o variabila de tip in "k" pentru exprimarea pozitiei elementelor sirului

            foreach (var sub in subs) //pentru fiecare variabila sub din subs in vectorul nostru initial "sir" ce memoreaza elementele sirului salvam pe rand si transformam in double 
                //( in cazul aparitiei unui caracter de tip char) elementele textului
            {
                if (k < NumarElemente)
                {
                    sir[k] = double.Parse(sub);
                    k++;
                }
            }



        }

        public double CalculareMin(int primul, int ultimul) // functia care calculeaza valoarea minima a sirului. 
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
        public double CalculareMax(int primul, int ultimul) // functia care calculeaza valoarea maxima a sirului
        {
            /*
             *   Calcularea se face prin Divide et Impera; rezolvarea asemanatoare cu cea de la minim
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

        public double CirireElementCautatSir(string cale)
        {
            double elcau;
            var parser = new FileIniDataParser(); //  instantiaza obiectul Parser
            IniData data = parser.ReadFile(cale); // citeste datele din fisierul indicat
            string NrCau = data["NumarCautat"]["ElementCautat"]; // citeste elementul "ElementCautat"
            elcau = double.Parse(NrCau); // salverea valorii "NumarCautat" si transfoermarea acestuia in double in variabila ElementCautat
            return elcau;
        }


        public bool CautareBinara(int primul, int ultimul, double elemc, double[] sir)
        {
            int pozCurenta = (primul + ultimul) / 2;

            if (elemc == sir[pozCurenta])
            {
                return true;
            }
            else
            {
                if (primul < ultimul)
                {
                    if (elemc < sir[pozCurenta])
                    {
                        return CautareBinara(primul, pozCurenta - 1, elemc, sir);
                    }
                    else
                    {
                        return CautareBinara(pozCurenta + 1, ultimul, elemc, sir);
                    }
                }
            }
            return false;
        }

        /*  Sortarea sirului prin Divide Et Impera in lucru
                private void Sortare(int st,int dr, double[] sir)
                {
                    double aux;
                    if (sir[st] > sir[dr])
                    {
                        aux = sir[st];
                        sir[st] = sir[dr];
                        sir[dr] = aux;
                    }
                }

                private void Interschimbare(int primul, int ultimul, int mijloc, double[]sir, int elem)
                {
                    var siraux = new double[elem];
                    int i, j, k;
                    i = primul;
                    j = mijloc + 1;
                    k = 1;
                    while(i<=mijloc && j<= ultimul)
                    {
                        if(sir[i] <= sir[j])
                        {
                            siraux[k] = sir[i];
                            i++;
                            k++;
                        }
                        else
                        {
                            siraux[k] = sir[j];
                            j++;
                            k++;
                        }
                    }
                    if(i <= mijloc)
                    {
                        for(j=i;j<= mijloc;j++)
                        {
                            siraux[k] = sir[j];
                            k++;
                        }
                    }
                    else
                    {
                        for(i=j;j<=ultimul;j++)
                        {
                            siraux[k] = (int)sir[i];
                            k++;
                        }
                    }
                    k = 1;
                    for(i = primul; i<= ultimul; i++)
                    {
                        sir[i] = siraux[k];
                        k++;
                    }
                }

                public void SortareSir(int primul,int ultimul, double[] sir, int elem)
                {
                    int mijloc;
                    if((ultimul-primul)<=1)
                    {
                        Sortare(primul, ultimul,  sir);
                    }
                    else
                    {
                        mijloc = (primul + ultimul) / 2;
                        SortareSir(primul, mijloc, sir, elem);
                        SortareSir(mijloc + 1, ultimul, sir, elem);
                        Interschimbare(primul, ultimul, mijloc, sir, elem);
                    }
                } */
    }
}
