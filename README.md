# ManagerSirMLD

  Este o clasa care foloseste metoda ***Divide-Et-Impera*** pentru a calcula diverse. Se furnizeaza ca o librarie .dll care poate fi folosita in alte proiecte C#
  
  <hr>

## Instalare

__ManagerSirMLD__ se poate folosi prin *comanda .NET CLI* in proiecte conform scriptului C# de mai jos :point_down:
                           
  ```.NET CLI
  dotnet add package ManagerSIRMLD --version 1.0.6
  ```
-----------------------------------------------------------------------------------------------
## Descriere proiect
 
 > ### Metode de programare  :heavy_check_mark:

  ### Divide Et Impera <br>
  ![di](http://veng.ro/managersirmld/wp-content/uploads/sites/2/2020/12/divide.jpg "Divide Et Impera")<br>

  #### Algoritmul Metodei

```C#
    void divide_et_impera(p,u,sol)
    {
        if (p<u) 
            {
              imparte(p,u,poz) // determină poziţia pivotului
              divide_et_impera(p, poz, sol1); // se aplică algoritmul
              divide_et_impera(poz+1, u, sol2); // pentru fiecare subproblemă
              sol = combina(sol1, sol2); // formarea solutiei
            }
        else
            {
              rezolva(sol); //rezolvă subproblema elementară
            }
    }
```

  #### Aplicatie

:exclamation: Crearea unei clase denumita __ManagerSirMLD__ <br>
  1. Care are urmatoarele proprietati: <br>

   
<li> <b> n </b> = numarul de elemente reale ale sirului; 
<li> <b> min </b> =elementul cu valoarea minima a sirului; 
<li> <b style> max </b> =elementul cu valoarea maxima a sirului; 
<li> <b> s[n]</b>= sirul in sine; <br> <br>
  
   2. Care are urmatoarele metode:<br>
   
  <li> <b> Initializare </b> (citire din fisier extern si evaluare proprietati initiale); <br>
  <li> <b> Citire sir </b> (cu Divide-et-Impera); <br>
  <li>  Calculare <b> Minim </b> si <b> Maxim </b> (cu Divide-et-Impera); <br>
  <li> <b> Evaluare erori; </b> <br>
  <li> <b> Cautare element in sir ordonat </b> (cautare binara) (cu Divide-et-Impera); <br> 
  <li> <b>  Ordonare sir crescator si descrescator; </b> <br>
  <li> <b>  Evaluare stare ordonare sir; </b>
    <br> <br>
    
 > ### Elemente invatate  :heavy_check_mark: <br>
 
   <li> <b> Conceptul OOP (Object Oriented Programming - Programarea Orientata pe Obiecte)</b> <br>
   <li> <b> Conceptul de programare Divide et Impera</b><br>
   <li> <b> Lucrul cu github.com; NuGet.org </b>
   <li> <b> Intelegerea conceptului de cloud in programare </b>
   <li> <b> Familiarizare cu Visual Studio Community si conectarea la cloud </b>
   <li> <b> Crearea unui site de prezentare pentru proiect folosind tehnologii preprogramate tip WordPress </b>
     

<hr>

## Mod de folosire

```XML
  <ItemGroup>
    <PackageReference Include="ManagerSIRMLD" Version="1.0.6" />
  </ItemGroup>
```

```C#
using ManagerSirMLD; // folosirea namespace-ului si a clasei create
var SirMLD = new ManagersSirMLD(); //instantierea obiectului.
```

## Link-uri
[Site Proiect](http://veng.ro/managersirmld/)<br>
[Descrierea Clasei](/Documentatii/ManagerSirMLD.md)<br>

## License
[MIT](/License.md)
