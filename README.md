#Laboratoria .NET

Repozytorium zawierające projekty realizowane w ramach nauki platformy .NET. 

## Struktura Projektu

- **Lab0** - Podstawy składni C#, operacje na zmiennych.


- **Lab1** - Programowanie obiektowe (klasy, dziedziczenie).
  - `Lab1` - Logika biznesowa (biblioteka/konsola).
     - Logika obliczeniowa, która nie wie o istnieniu przycisków i okienek.
  - `GUI` - Interfejs użytkownika do zadań z Lab1.
    - Interfejs użytkownika.
    - Obsługa zdarzeń (kliknięcia, zmiana tekstu).
    - Wykorzystanie projektu Lab1 poprzez Project Reference.
  - `TestProject1` - Testy automatyczne sprawdzające poprawność logiki.
    - Testy automatyczne sprawdzające np. czy metoda licząca średnią poprawnie reaguje na puste dane.
    - Pokrycie testami kluczowych metod z projektu Lab1.

