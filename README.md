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

- **Lab2** - Projekt aplikacji bazodanowej integrującej zewnętrzne API oraz trwałe przechowywanie danych.
Opis projektu

Celem laboratorium jest stworzenie programu w języku C#, który komunikuje się z API (Open Exchange Rates) oraz zarządza lokalną bazą danych przy użyciu Entity Framework Core.
Struktura Lab 2

    Zadanie 1: API & JSON – Pobieranie danych asynchronicznie za pomocą HttpClient oraz ich deserializacja.

    Zadanie 2: Baza danych (EF Core) – Obsługa bazy danych w pliku SQLite oraz mapowanie obiektowo-relacyjne (ORM).

        Relacje: Zaimplementowana relacja jeden-do-wielu (klasa ExchangeDate oraz CurrencyRate).

        Mechanizm Cache: Dane pobierane są z API tylko w przypadku ich braku w bazie danych (optymalizacja zapytań).

        Praca z danymi: Filtrowanie i sortowanie wyników za pomocą kwerend LINQ.

    Zadanie 3: GUI (MAUI) – (W trakcie/Opcjonalnie) Interfejs użytkownika w technologii Multi-platform App UI pozwalający na wyświetlanie i dodawanie rekordów.
