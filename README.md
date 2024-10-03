README: 

Webová kalkulačka 

Tento projekt představuje webovou aplikaci s kalkulačkou, která umožňuje provádět základní početní operace s dvěma čísly s desetinnými místy. 
Aplikace byla navržena s důrazem na udržitelnost, modularitu a rozšiřitelnost. Níže naleznete podrobnosti o implementaci a funkcionalitách.

Funkcionality 

* Základní početní operace: Sčítání (+) Odčítání (-) Násobení (*) Dělení (/) 
* Historie operací: Na stránce je zobrazena historie posledních 10 provedených operací. Při načtení stránky jsou tyto operace načteny z databáze.
* Bez přenačítání stránky (AJAX): Při provádění výpočtů stránka není přenačítána. Po kliknutí na tlačítko "spočítat" se výsledek výpočtu zobrazí okamžitě pomocí AJAXu.
* Logování výpočtů do databáze: Každý provedený výpočet je zaznamenán do databáze včetně operandů, operace a výsledku.
* Zobrazení výsledku a historie: Po každém výpočtu je výsledek zobrazen na displeji kalkulačky. Současně je aktualizována historie operací.
* Zaokrouhlení výsledků: Výsledky výpočtů jsou vraceny jako celá čísla, zaokrouhlené na nejbližší hodnotu.

Oddělení logiky a vrstvy dat: 
Aplikace je rozvrstvena na několik částí: 
* Služba výpočtů (CalculationService): Obsahuje logiku pro provádění matematických operací. 
* Datová vrstva (ICalculationLogRepository): Odpovídá za ukládání výsledků operací do databáze. Kontroléry (Controllers): Zajišťují zpracování požadavků od uživatele.
* Modularita a udržitelnost kódu: Logika výpočtů je oddělena a implementována tak, aby ji bylo možné znovu použít v jiných projektech. Aplikace podporuje chyby, které jsou odesílány do metody SendError(Exception exception), kde jsou zaznamenávány pro pozdější analýzu.
* Testování: Kód je pokryt jednotkovými testy pro logiku výpočtů. Testy zajišťují, že základní operace (sčítání, odčítání, násobení, dělení, a výjimky při dělení nulou) fungují správně.
* Logování chyb do souboru: Chybové zprávy jsou logovány do souboru errors.log v případě, že dojde k výjimkám při práci s datovou vrstvou.

Architektura a rozdělení vrstev 
Aplikace byla navržena jako vícevrstvá aplikace podle zásad oddělení zodpovědností: 
* Prezentace: Obsahuje uživatelské rozhraní (front-end), které využívá AJAX pro komunikaci s backendem, čímž se zajišťuje, že při výpočtech nedochází k přenačítání stránky.
* Obchodní logika (Business Logic): CalculationService: Tato služba obsahuje logiku pro výpočet operací a je oddělena od zpracování dat. Je implementována tak, aby byla opakovaně použitelná.
* Datová vrstva (Data Layer): ICalculationLogRepository a CalculationLogRepository: Implementují záznam operací do databáze a jsou zcela odděleny od obchodní logiky. To umožňuje snadnou úpravu způsobu ukládání dat (například při přechodu na jinou databázi).
* Unit testy: Projekt obsahuje pokrytí jednotkovými testy pomocí MSTest. Testy jsou zaměřené na základní matematické operace a ověření správnosti logiky.
* Instalace a spuštění Klony projektu: Klonujte tento projekt pomocí Git: git clone https://github.com/Gal1x1/Calculator.git
* Instalace závislostí: Otevřete projekt v Visual Studio a ujistěte se, že všechny závislosti jsou správně nainstalovány. Spusťte projekt v Visual Studio, aby se načetly všechny závislosti, včetně Entity Framework a Unity (pokud je používán).
* Nastavení databáze: Ujistěte se, že máte správně nakonfigurovanou databázi. Připojovací řetězec (connection string) je třeba zadat v konfiguračním souboru appsettings.json nebo web.config. Spuštění aplikace: Spusťte aplikaci v prostředí Visual Studio. Přístup k aplikaci bude dostupný prostřednictvím prohlížeče na adrese: http://localhost:5000.

Testování 
Aplikace obsahuje jednotkové testy, které lze spustit pomocí Test Explorer ve Visual Studio. Testují se základní operace kalkulačky (sčítání, odčítání, násobení, dělení a výjimky při dělení nulou).
* Technologie ASP.NET Core MVC: Používá se jako architektura pro zajištění oddělení prezentace, obchodní logiky a datové vrstvy. 
* Entity Framework Core: Používá se pro práci s databází.
* MSTest: Testovací rámec pro jednotkové testy.
* AJAX: Zajišťuje, že při práci s kalkulačkou nedochází k přenačítání stránky.

Chyby a logování 
* Logování chyb: Chybové zprávy jsou logovány do souboru errors.log prostřednictvím metody SendError.
* Zpracování výjimek: Každá výjimka je předána metodě SendError, která shromažďuje informace o výjimkách.

Autořka: Galina Chudinova 

Projekt byl vytvořen jako ukázka implementace vícevrstvého systému s kalkulačkou a oddělením obchodní logiky a datové vrstvy.
