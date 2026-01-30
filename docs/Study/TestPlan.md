# Testovací analýza

## Prioritní oblasti k testování

Prioritou pro testování je, aby e-shop umožňoval nákup za podmínek stanovených v zadání, a aby proběhlo zpracování objednávky na backendu.

- Sanity test pro standardní průchod e-shopem
    - přihlášení
    - přidání zboží do košíku
    - dokončení objednávky
    - platba
- Backend verifikace
    - objednávka správně uložena v databázi (REST API/SQL)
    - objednané zboží je aktualizované v e-shopu (počet kusů)
    - následné kroky po objednávce fungují (požadavek do skladu, email zákazníkovi)
- Checkout page
    - verifikovat povolené kombinace slev
    - vyloučit nesmyslně velkou slevu
- Platba
    - nabízené možnosti platby fungují správně
- Admin Panel
    - verifikace přidání/odebrání/úpravy zboží
- Přístupová práva
    - ověření, že zákazníci nemají přístup do administrace produktů

## Důležité oblasti k testování

Ve druhé fázi je třeba otestovat i různé krajní případy chování aplikace, se kterými se uživatel může setkat, ale nejsou tak časté.
Prioritu performance testování by bylo užitečné vyjasnit se zadavatelem. Podle očekávaného množství zákazníků by se případně performance testování upřednostnilo.

- Performance
    - testovat odezvu aplikace (např. zda netrvá načítání úvodní stránky příliš dlouho pro mnoho položek)
    - testovat vícenásobný současný přístup k aplikaci
    - testovat odezvu backendu
    - testovat vícenásobný současný přístup k backendu

- Bezpečnost
    - odolnost proti útokům (únik dat, neoprávněný přístup apod.)

- Přístupová práva
    - V zadání není specifikována správa uživatelských rolí. Je třeba vyjasnit s developmentem a případně přidat/upravit test specifikace.

- Testování dalších scénářů
    - přidaní do košíku z různých míst
    - ubírání/přidávání zboží v košíku
    - verifikace zadaných hodnot na Checkout stránce
    - testovat mezní případy

## Další oblasti k testování

Toto jsou méně důležité oblasti na testování, protože přímo neovlivňují základní funkčnost aplikace, ale jedná se například o větší přehlednost aplikace pro zákazníky nebo lepší komfort pro zaměstnance při administraci e-shopu.

- Vizuální podoba e-shopu (i pro Admin panel a jeho dialogy)
    - verifikovat konzistentní zobrazení údajů na kartě produktu, v detailní kartě, košíku (např. zobrazení ceny)
    - verifikovat správnost popisu položek (jazyk, gramatika)
    - testovat řazení položek
    - testovat kategorie

- Admin Panel
    - export do Excelu
    - řazení položek

- Testování pro podporované prohlížeče
    - manuálně ověřit vizuální stránku aplikace v různých prohlížečích
    - zajistit spouštění automatických testů pro různé prohlížeče

## Manuální a automatizované testování
### Manuální testy
Manuální testy použijeme pro úvodní otestování aplikace a pro jednorázové akce, kde by se vývoj automatických testů nevyplatil nebo není možný.

- testování vizuální podoby e-shopu
- testování plateb (není jasné, zda je možná automatizace)
- performance testování (lze opakovat při větších změnách v aplikaci, případně zvážit, jestli některé performance testy nezařadit do pravidelných běhů automatických testů)
- penetrační testování

### Automatické testy
Automatické testy slouží pro regresní testování buď už přímo v průběhu vývoje nebo po dokončení první verze. Spuštěním testů ověříme, že po přidaní nové funkcionality nebo opravě nějakého problému nepřestaly fungovat ostatní oblasti. Také můžeme ověřit funkčnost s různými daty a v různých prohlížečích.

- postupně automatiovat test specifikace, které jsme vytvořili při úvodním manuálním testování
- připravit různé sady dat
- testovat různé prohlížeče
