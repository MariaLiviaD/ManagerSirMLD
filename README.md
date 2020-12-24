# ManagerSirMLD

  Este o clasa care foloseste metoda ***Divide-Et-Impera*** pentru a calcula diverse. Se furnizeaza ca o librarie .dll care poate fi folosita in alte proiecte C#
  
  <hr>

## Instalare

__ManagerSirMLD__ se poate folosi prin *include* in proiecte conform scriptului C# de mai jos :point_down:
                           
  ```.NET CLI
  dotnet add package ManagerSIRMLD --version 1.0.0
   ```
-----------------------------------------------------------------------------------------------
## Descriere proiect
 
 > ### Metode de programare  :heavy_check_mark:

  #### Divide Et Impera <br>
  ![Divide-et-Impera_image](
(Prezentare Generala)<br>
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
<li> <b> Lucru cu github.com </b>

<hr>

## Mod de folosire

```XML
  <ItemGroup>
    <PackageReference Include="ManagerSIRMLD" Version="1.0.0" />
  </ItemGroup>
```

```C#
using ManagerSirMLD; // folosirea namespace-ului si a clasei create
var SirMLD = new ManagersSirMLD(); //instantierea obiectului.
```

## Link-uri
[Site Proiect](http://veng.ro/managersirmld/)

## License
[MIT](https://choosealicense.com/licenses/mit/)
