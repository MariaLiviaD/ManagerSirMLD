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
    Citire Sir din fisier; 
    Calculare Minim si Maxim; (cu Divide-et-Impera)
    Cautare element in sir ordonat (cautare binara) (cu Divide-et-Impera);  
    Ordonare sir crescator si descrescator;  

Elemente invatate:
    *Conceptul OOP (Object Oriented Programming - Programarea Orientata pe Obiecte)
    *Conceptul de programare Divide et Impera
    
*/

using System;
using System.IO;
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

        public double[] x; //vectorul in care voi introduce elementele vectorului "sir" in ordine crescatoare

        public double[] y; //vectorul in care voi introduce elementele vectorului "sir" in ordine descrescatoare

        public string CaleFisierIntrare; //calea catre fisierul de citit

        public double ElementCautat; // elementul ce va fi cautat in sir


        public void AfiseazaElementeSir() //procedura care afiseaza elementele sirului citite din fisierul .ini
        {
            Console.WriteLine("Numarul de elemente al sirului este: " + NumarElemente); //mesaj pentru afisarea numarului de elemente;
            Console.WriteLine();
            for (int i=0; i< NumarElemente; i++) //pentru i = 0 mai mic decat NumarElemente se afiseaza elementele sirului + pozitia acestora in sir
            {
                Console.WriteLine("Sir["+i+"]="+ sir[i]);
            }
        }
        public void CitireSirTastatura() // functia care citeste numarul de elemente al sirului de la tastatura;
        {
            Console.WriteLine("Introduceti numarul de elemente al sirului: "); //scrie mesaj in consola pentru introducerea numarului de elemente;
            NumarElemente = Convert.ToInt32(Console.ReadLine()); //transforma numarul citit din string(deoarece noi introducem un text) in int si il salvam in NumarElemente;
            sir = new double[NumarElemente]; // la inceput am initializat "sir" ca fiind public pentru a putea acum sa ii dam marimea (punem "new double" deorece ii dam o noua
                                             // "caracteristica" (la inceput el era un vector gol nu avea o marime));
            CitireSirTastaturaDivEtImp(0, NumarElemente - 1); // citeste sirul cu Divide Et Impera de la tastatura. 
        }

        private void CitireSirTastaturaDivEtImp(int primul, int ultimul) // procedura care citeste elementele sirului de la tastatura;
        {
            /*
              Citirea se face prin metroda Divide et Impera;
             */
            int pozCurenta; // initializam pozCurenta de tip int deoarece aceasta reprezinta indicele elementului din mijloc;
            string str; // variabila folosita la citirea elementelor de la tastatura (noi introducem un text care pe urma il vom transforma in double(tipul elementelor din sir);

            if (primul < ultimul) // daca primul < ultimul va avea loc divizarea sirului respectiv subsirurilor, deoarece noi trebuie sa ajungem la subsiruri de dimensiunea 1 pentru
                                  // a realiza citirea si in cazul nostru aceasta comparatie ne arata daca subsirul nostru are mai multe elemente;
            {
                pozCurenta = (primul + ultimul) / 2; // calculam pentru fiecarea subsir(si pentru sirul initial) mijlocul acesteia;
                CitireSirTastaturaDivEtImp(primul, pozCurenta); //divizam sirul / subsirurile; acesta preia subsirul din stanga;
                CitireSirTastaturaDivEtImp(pozCurenta + 1, ultimul); //divizam sirul / subsirurile; aceasta preia subsirul din dreapta;
                // impartim sir / subsirurile in doua sibsiruri de aceea luam stanga si dreapta sirului / subsirului anterior;
                // cand facem verificarea daca primul < ultimul in cazul subsirului din stanga format dupa divizare ultimul = pozCurenta iar in cazul subsirului din dreapta 
                // primul = pozCurenta + 1(pozCurenta se afla in subsirul anterior);
            }
            else // altfel primul = ultimul ceea ce ne arata ca subsirul nostru a ajuns la dimensiunea 1;
            {
                Console.WriteLine("Introduceti valoarea reala a sirului: "); // scriem un mesaj pentru introducerea valorii;
                str = Console.ReadLine(); //citim de la tastatura elementul;
                sir[primul] = double.Parse(str); // transformam din string in int valoarea citita; 
                                                 // scriem sir[primul] deorece pe acesta ramura "else" primul = ultimul, dar primul ne arata pozitia elementului (daca noi
                                                 // introducem primul element atunci el va fie salvat in sir[0] reprezentand primul element iar 0 = primul ( mijlocul subsirului/sirului)
                                                 // si tot asa pana cand se ajunge la sir[NumarElement - 1];
            }
        }

        public void CitireSirFisier (string cale) // procedura care citeste numarul de elemente si elementele sirului dintr-un fisier dat.
                                                  // (string cale) este folosit pentru atasarea path -ului fiserului creat;   
        {
            /*
             * folsosete codul ini-parser de pe internet pentru a citi fisierele tip .ini structurate;
             * informatiile despre citire din fisier tip .ini au fost preluate de pe GitHub.com >https://github.com/rickyah/ini-parser<;
             */
            var parser = new FileIniDataParser();  // instantiem obiectul parser pentru a accesa fisierul .ini;
            IniData data = parser.ReadFile(cale); // citim fiserul;
            string numar = data["Initiere Sir"]["NumarElemente"]; // citeste elementul "NumarElemente"
            string elementesir = data["Initiere Sir"]["ElementeSir"]; //citeste elementul "ElementeSir"

            NumarElemente = Convert.ToInt32(numar); // ceea ce am introdus noi este sub forma de string si atunci transformam textul in int si il salvam in NumarElemente;
            sir = new double[NumarElemente]; // ii dam o noua proprietate lui "sir" dand marimea vectorului "sir";

            string s = elementesir; //initializam o variabila string "s"  cu elementesir care ne salveaza textul cu elementele sirului;
            char[] separators = new char[] { ',' }; //variabila de tip char "separators" este initializata cu caracterele ce se regasesc in sir si vor fi indepartate
            // pentru ca acestea sa nu fie incluse in vectorul ce va pastra elementele sirului;
            //sirul nostru reprezinta un text 

            string[] subs = s.Split(separators, StringSplitOptions.RemoveEmptyEntries); // vectorul de tip string "subs" va memora numerele textului nostru ce reprezinta elementele sirului;
                                                                                        // "StringSplitOptions.RemoveEmptyEntries" este folosit in cazul in care avem mai multe
                                                                                        //caractere una dupa alta(fara spatiu intre ele) si le elimina 
                                                                                        //si pe acestea;

            int k = 0; // initializam cu 0 o variabila de tip int "k" pentru exprimarea pozitiei elementelor sirului;

            foreach (var sub in subs) //pentru fiecare variabila sub din subs in vectorul nostru initial "sir" ce memoreaza elementele sirului salvam pe rand si transformam in double 
                //(deoarece fisierul nostru contine elementele sirului de tip string >text<) elementele textului
            {
                if (k < NumarElemente) //aceasta salvare se executa numar dac k < NumarElemente deaorece trebuie sa respectam marimea vectorului nostru;
                {
                    sir[k] = double.Parse(sub); // salvarea si transformarea in double a elementelor textului
                    k++; // crestem valoare lui k odata cu salvarea unei valori in sir;
                }
            }
        }

        public double CalculareMin(int primul, int ultimul) // functia care calculeaza valoarea minima a sirului;
        {
            /*
               Calcularea se face prin Divide et Impera = aplicatia 1  din manualul atasat; 
               -functia nostra contine int primul si int ultimul deoarece de fiecare data noi cautam valoarea minima intr-un "interval";
               -de-a lungul divizarii ultimul este de fapt pozCurenta in subsirul din stanga, iar in cel din dreapta stanga = pozCurenta + 1, deoarece 
                nu il mai luam inca o data pe pozCurenta;
             */
            int pozCurenta; // initializam indicele elementului din mijloc de tip int(el reprezinta indicele elementului din mijloc in sir/subsir) 
                            //pentru sir respectiv pentru fiecare subsir;
            double min1, min2; // initializam min1 si min2 de tip double(elementele sirului pot avea valori reale) 
                               //pentru salvarea fiecarui minim al subsirurilor, inclusiv cel al sirului;
            if (primul < ultimul) // daca primul < ultimul va avea loc impartirea deoarece in acest caz subsirurile noastre au mai mult de 1 un element
                                  // iar noi trebuie sa ajungem la subsiruri de dimensiunea 1 pentru a salva primele valori  max1 si max2;
            {
                pozCurenta = (primul + ultimul) / 2; // calculam de fiecare data pentru fiecare subsir indicele elementului din mijloc;
                min1 = CalculareMin(primul, pozCurenta); // min1 va fi mereu egal cu minmul subsirurilor din partea stanga dupa divizarea unui subsir; 
                min2 = CalculareMin(pozCurenta + 1, ultimul); // min2 va fi mereu egal cu minimul subsirurilor din partea dreapta dupa divizarea unui subsir;
                // facem acest lucru pentru a putea compara de fiecare data minnimul subsirului din stanga cu cel din dreapta pentru a afla minimul
                // subsirului mare(cel care a fost divizat); 
                // acest proces se repeta pana cand se ajunge la sirul initial;
                if (min1 < min2) // daca min1 < min2 atunci minim = min1;
                {
                    return min1; //folosim return doarece functia noastra este egala cu ElementMinim(pe care o initializam public double) si atunci dupa ce functia noastra 
                    // se opreste ElementMinim va avea valoarea minima a sirului;
                }
                else // alfel minim = min2;
                {
                    return min2;
                }
            }
            else // altfel in acest caz primul = ultimul de unde rezulta ca am ajuns la subsiruri de dimensiunea 1;
            {
                return sir[primul]; // aici min1 respectiv min2 isi iau valorile, deoarece subsirurile noastre contin un singur
                //element si atunci se poate realiza compararea;
            }
        }
        public double CalculareMax(int primul, int ultimul) // functia care calculeaza valoarea maxima a sirului
        {
            /*
             Calcularea se face prin Divide et Impera; rezolvarea asemanatoare cu cea de la minim
             -functia nostra contine int primul si int ultimul deoarece de fiecare data noi cautam valoarea maxima intr-un "interval";
             -de-a lungul divizarii ultimul este de fapt pozCurenta in subsirul din stanga, iar in cel din dreapta stanga = pozCurenta + 1, deoarece 
              nu il mai luam inca o data pe pozCurenta;
             */
            int pozCurenta; // initializam pozCurenta de tip int(deorece el reprezinta indicele elementului din mijloc din sir/subsir)
                            // pentru sir respectiv pentru fiecare subsir;
            double max1, max2;  // initializam max1 si max2 de tip double(elementele sirului pot avea valori reale) 
                                //pentru salvarea fiecarui maxim al subsirurilor, inclusiv cel al sirului;
            if (primul < ultimul) // daca primul < ultimul va avea loc impartirea deoarece in acest caz subsirurile noastre au mai mult de 1 un element
                                  // iar noi trebuie sa ajungem la subsiruri de dimensiunea 1 pentru a salva primele valori  max1 si max2;
            {
                pozCurenta = (primul + ultimul) / 2; // calculam de fiecare data pentru fiecare subsir indicele elementului din mijloc;
                max1 = CalculareMax(primul, pozCurenta); // max1 va fi mereu egal cu maximul subsirurilor din partea stanga dupa divizarea unui subsir; 
                max2 = CalculareMax(pozCurenta + 1, ultimul); // max2 va fi mereu egal cu maximul subsirurilor din partea dreapta dupa divizarea unui subsir;
                // facem acest lucru pentru a putea compara de fiecare data maximul subsirului din stanga cu cel din dreapta pentru a afla maximul
                // subsirului mare(cel care a fost divizat); 
                // acest proces se repeta pana cand se ajunge la sirul initial;
                if (max1 > max2) // daca max1 > max2 atunci maxim = max1;
                {
                    return max1; //folosim return doarece functia noastra este egala cu ElementMaxim(pe care o initializam public double) si atunci dupa ce functia noastra 
                    // se opreste ElementMaxim va avea valoarea maxima a sirului;
                }
                else // alfel maxim = max2;
                {
                    return max2;
                }
            }
            else // altfel in acest caz primul = ultimul de unde rezulta ca am ajuns la subsiruri de dimensiunea 1;
            {
                return sir[primul]; // aici max1 respectiv max2 isi iau primele valori, deoarece subsirurile noastre contin un singur
                //element si atunci se poate realiza compararea; 
            }
        }

        public void SortareSirCrescator(double[] x, int stanga, int mijloc, int dreapta) // procedura ce ne va sorta crescator sirul initial (daca acesta nu este ordonat);
        {
            // acest tip de sortare se numeste MergeSort;
            // de fapt sortarea sirului initial se bazeaza pe sortarea subsirurilor;
            double[] sirauxiliar; // initializam un sir auxiliar de tip double pentru memorarea elementelor in urma sortarii;
            sirauxiliar = new double[dreapta - stanga + 1]; // dam marimea vectorului "sirauxiliar" acesta reprezentand numarul de elemente din fiecare subsir format in urma divizarii;
            int i = stanga; // initializam o variabila "i" de tip int ce va fi egala cu stanga (pozitia primului element al subsirului din partea stanga);
            int j = mijloc + 1; // initializam o variabila j de tip int ce va fi egala cu mijlocul subsirului + 1 (pozitia primului element al subsirului din partea dreapta);
            int k = 0; // initializam o variabila de tip int k = 0 ce va reprezenta pozitia elementelor in vectorul "sirauxiliar";

            while (i <= mijloc && j <= dreapta) // cat timp i <= mijloc si j <= dreapta vom face compararea elementelor intre ele (nu toate elementele vor fi sortate in 
            // aceasta etapa ci vom salva elementele mai mai mici din fiecare subsir;
            {
                // compararea se face mai intai intre primele elemente ale subsirurilor;
                if (x[i] <= x[j]) // daca elementul din stanga (subsirul din stanga) este mai mic decat cel din dreapta(subsirul din dreapta)
                {
                    sirauxiliar[k] = x[i]; //atunci vom salva in sirul auxiliar valoarea acestuia;
                    k++; //creste k;
                    i++; // creste i deoarece am salvat valoarea de pe pozitia i si atunci il verificam pe urmatorul;
                }
                else //alfel elementul din dreapta este mai mic decat cel din stanga;
                {
                    sirauxiliar[k] = x[j]; // salvam valoarea acestuia in sirul auxiliar;
                    k++; // creste k;
                    j++; // creste j deoarece am salvat valoarea de pe pozitia j si atunci il verificam pe urmatorul;
                }
            }

            while (i <= mijloc) // salvam elementele ramase din primul subsir;
            {
                sirauxiliar[k] = x[i];
                i++;
                k++;
            }

            while (j <= dreapta) // salvam elementele ramase din al doilea subsir;
            {
                sirauxiliar[k] = x[j];
                j++;
                k++;
            }

            for (i = stanga; i <= dreapta; i++) // salvam elementele sortate in sirul initial;
            {
                x[i] = sirauxiliar[i - stanga]; // pozitiile din sir auxiliar incep mereu de la 0;
            }
        }

        public void ImpartireaSiruluiCrescator(double[] x, int stanga, int dreapta) // procedura ce va imparti sirul initial/ subsirurile in subsiruri si care dupa impartirea acestora pe rand 
            // cheama sortarea acestora;
        {
            if (stanga < dreapta)  
            {
                int mijloc = (stanga + dreapta) / 2; // initializam o variabila mijloc egala cu indicele elementului din mijloc;
                ImpartireaSiruluiCrescator(x, stanga, mijloc); // aplicam aceasi functie si pentru subsirul din stanga pentru a-l imparti;
                ImpartireaSiruluiCrescator(x, mijloc + 1, dreapta); // aplicam aceasi functie si pentru subsirul din dreapta pentru a-l imparti;
                SortareSirCrescator(x, stanga, mijloc, dreapta); // cand stanga = dreapta nu mai are loc nicio impartire si atunci chemam sortare pentru fiecare subsir in parte format;
            }
        }


        public void SortareSirDescrescator(double[] y, int stanga, int mijloc, int dreapta) //// procedura ce ne va sorta descrescator sirul initial (daca acesta nu este ordonat);
        {
            double[] sirauxiliar; //initializam un sir auxiliar de tip double pentru memorarea elementelor in urma sortarii;
            sirauxiliar = new double[dreapta - stanga + 1]; // dam marimea vectorului "sirauxiliar" acesta reprezentand numarul de elemente din fiecare subsir format in urma divizarii;
            int i = stanga; // initializam o variabila "i" de tip int ce va fi egala cu stanga (pozitia primului element al subsirului din partea stanga);
            int j = mijloc + 1; // initializam o variabila j de tip int ce va fi egala cu mijlocul subsirului + 1 (pozitia primului element al subsirului din partea dreapta);
            int k = 0; // initializam o variabila de tip int k = 0 ce va reprezenta pozitia elementelor in vectorul "sirauxiliar";

            while (i <= mijloc && j <= dreapta) // cat timp i <= mijloc si j <= dreapta vom face compararea elementelor intre ele (nu toate elementele vor fi sortate in 
            // aceasta etapa ci vom salva elementele mai mai mici din fiecare subsir;
            {
                if (y[i] >= y[j]) // daca elementul din stanga (subsirul din stanga) este mai mmare decat cel din dreapta(subsirul din dreapta)
                {
                    sirauxiliar[k] = y[i]; //atunci vom salva in sirul auxiliar valoarea acestuia;
                    k++; //creste k;
                    i++; // creste i deoarece am salvat valoarea de pe pozitia i si atunci il verificam pe urmatorul;
                }
                else //alfel elementul din dreapta este mai mmare decat cel din stanga;
                {
                    sirauxiliar[k] = y[j]; // salvam valoarea acestuia in sirul auxiliar;
                    k++; // creste k;
                    j++; // creste j deoarece am salvat valoarea de pe pozitia j si atunci il verificam pe urmatorul;
                }
            }

            while (i <= mijloc) // salvam elementele ramase din primul subsir;
            {
                sirauxiliar[k] = y[i];
                i++;
                k++;
            }

            while (j <= dreapta) // salvam elementele ramase din al doilea subsir;
            {
                sirauxiliar[k] = y[j];
                j++;
                k++;
            }

            for (i = stanga; i <= dreapta; i++) // salvam elementele sortate in sirul initial;
            {
                y[i] = sirauxiliar[i - stanga]; // pozitiile din sir auxiliar incep mereu de la 0;
            }
        }

        public void ImpartireaSiruluiDescrescator(double[] y, int stanga, int dreapta) // procedura ce va imparti sirul initial/ subsirurile in subsiruri si care dupa impartirea acestora pe rand 
        // cheama sortarea acestora;
        {
            if (stanga < dreapta) // daca stanga < dreapta are loc impartirea alfel stanga = dreapta si atunci este chemata sortarea;
            {
                int mijloc = (stanga + dreapta) / 2; // initializam o variabila mijloc egala cu indicele elementului din mijloc;
                ImpartireaSiruluiDescrescator(y, stanga, mijloc); // aplicam aceasi functie si pentru subsirul din stanga pentru a-l imparti;
                ImpartireaSiruluiDescrescator(y, mijloc + 1, dreapta); // aplicam aceasi functie si pentru subsirul din dreapta pentru a-l imparti;
                SortareSirDescrescator(y, stanga, mijloc, dreapta); // cand stanga = dreapta nu mai are loc nicio impartire si atunci chemam sortare pentru fiecare subsir in parte format;
            }
        }

        public double CirireElementCautatSir(string cale) // functia ce va citi din fisier elementul cautat
        {
            double elcau; //initializam de tip double o variabila elcau ca va fi egala mai tarziu cu valoarea din fisier;
            var parser = new FileIniDataParser(); //  instantiaza obiectul Parser;
            IniData data = parser.ReadFile(cale); // citeste datele din fisierul indicat;
            string NrCau = data["NumarCautat"]["ElementCautat"];// initializam o variabila "NrCau" de tip string ce va retine "textul" ce contine elementul cautat;
            elcau = double.Parse(NrCau); // salverea valorii "NrCau" si transformarea acesteia in double in variabila elcau;
            return elcau; // functia noastra este double ca la sfarsitul acesteia sa returneze valoarea elementului cautat.
        }


        public bool CautareBinara(int primul, int ultimul, double elemc, double[] x) //functia care cauta elementul cerut;
        {
            int pozCurenta = (primul + ultimul) / 2; //initializam pozCurebta de tip int ce reprezinta indicele elementului din mijloc;

            if (elemc == x[pozCurenta]) // verificam daca elementul din mijloc este egal cu numarul pe care il cautam ;
            {
                return true; //daca respecta aceasta conditie cautarea se opreste si returneaza true(functia este bool) ce ne indica ca elementul a fost gasit;
            }
            else //altfel impartim sirul/subsirurile;
            {
                if (primul < ultimul) //daca primul < ultimul vom imparti sirul deoarece acest lucru ne arata ca avem mai multe elemente in sir/subsiruri; alfel am avea un sir / subsiruri 
                    //de dimensiiunea 1 pe care nu le mai putem imparti;
                {
                    if (elemc < x[pozCurenta]) //verificam daca elementul cautat este mai mic decat elementul din mijloc pentru a cauta numai in primul subsir ce se va forma;
                    {
                        return CautareBinara(primul, pozCurenta - 1, elemc, x); //daca respecta conditia de mai sus atunci returnam aceasi functie pentru primul subsir si atunci 
                        //cautarea se va face in acel subsir;
                    }
                    else //altfel elementul cautat este mai mare decat elementul din mijloc;
                    {
                        return CautareBinara(pozCurenta + 1, ultimul, elemc, x); //returnam aceasi functie pentru a-l doilea subsir;
                    }
                }
            }
            return false; //la final returnam false in cazul in care elementul nu a fost gasit;
        }
        public void Meniu() //procedura ce afiseaza meniul programului;
        {
            Console.WriteLine("    Meniu");
            Console.WriteLine("Programul va afisa:");
            Console.WriteLine("1. Numarul de elemente al sirului.");
            Console.WriteLine("2. Sirul propriu-zis si pozitiile elementelor in sir.");
            Console.WriteLine("3. Maximul din sir.");
            Console.WriteLine("4. Minimul din sir.");
            Console.WriteLine("5. Mesaj pentru aflarea sau nu in sir a unui element dat.");
            Console.WriteLine("6. Sirul ordonat crescator.");
            Console.WriteLine("7. Sirul ordonat descrescator.");
        }

    }
}
