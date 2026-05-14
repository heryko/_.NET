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

- **Lab3** - Obliczenia wielowątkowe w technologii.NET
  - `MatrixLibrary` - - Logika obliczeniowa oparta na paradygmatach obiektowych. 
    Implementacja wysokopoziomowego zrównoleglania z użyciem biblioteki Parallel (Parallel.For).
    Implementacja niskopoziomowego zarządzania wątkami przy użyciu klasy Thread. 
    Mechanizmy synchronizacji i kontroli stopnia zrównoleglenia (ParallelOptions, Thread.Join). 

  - `PerformanceConsole` - Aplikacja konsolowa do analizy wydajności. 
    Generowanie losowych macierzy o parametrach podawanych w kodzie lub z konsoli. 
    Pomiar czasu wykonywania operacji przy użyciu klasy Stopwatch. 
    Porównanie i analiza przyspieszenia (Speedup) algorytmów wielowątkowych względem podejścia sekwencyjnego dla różnych rozmiarów macierzy (≥100). 

| Wątki (Y) \ Rozmiar (X) | 500 (P / T) | 100 (P / T) |
| :--- | :--- | :--- |
| **1 (Sekwencyjnie)** | 2591 ms / 2090 ms | 24 ms / 21 ms |
| **2** | 1249 ms / 1295 ms | 9 ms / 20 ms |
| **4** | 638 ms / 675 ms | 5 ms / 29 ms |
| **12** | 314 ms / 394 ms | 11 ms / 65 ms |
| **100** | 433 ms / 1203 ms | 13 ms / 456 ms |


Oto opis Lab 4 przygotowany w bloku kodu, gotowy do skopiowania do pliku README.md. Struktura i wcięcia są identyczne z Twoimi poprzednimi wpisami:
Markdown

- **Lab 4** - Aplikacja webowa w technologii ASP.NET Core.
  - `BlazorApp` - Użycie platformy Blazor i modyfikacja domyślnego projektu.
     - Implementacja aplikacji w oparciu o .NET 8.0 i tryb Interactive Server.
     - Rozszerzenie komponentu pogodowego o 10-dniową prognozę oraz licznik dni ciepłych (>15°C).
     - Wykorzystanie składni LINQ do filtrowania danych oraz obsługa zdarzeń interfejsu użytkownika.
  - `ML_SentimentAnalysis` - Użycie biblioteki ML.NET do klasyfikacji nastroju.
     - Wytrenowanie modelu AI przy użyciu Model Builder na zbiorze danych z serwisu Kaggle.
     - Integracja modelu z aplikacją poprzez wstrzykiwanie usługi PredictionEnginePool.
     - Budowa interaktywnej podstrony do analizy sentymentu wyświetlającej etykietę oraz pewność predykcji.
  - `DatabaseApp` - Bazodanowa aplikacja webowa z systemem autoryzacji.
     - Wykorzystanie Entity Framework Core do obsługi bazy danych i automatycznej generacji stron typu CRUD.
     - Implementacja systemu logowania oraz Individual Accounts do autoryzacji i zabezpieczania dostępu do stron.
     - Funkcjonalności dodatkowe: dynamiczne sortowanie kolumn, system aktualizacji ocen oraz obsługa obrazów via URL.
