# Programování v aplikacích - semestrální úkol  
Mým cílem bylo centralizovat UI a co největší využití plochy. Hlavní panel se proto skládá ze tří částí:  
- Postranní lišta se všemi stanicemi, barevně odlišenými podle aktuální naměřené hodnoty
- Tabulka se všemi naměřenými hodnotami aktuální stanice
- Nastavení stanice s možností stanici odstranit
Nastavení SMTP serveru a autorizačních tokenů jsem pro ulehčení práce poté už rozdělil.
Ponechal jsem stránku historie, kde jsou všechna přijatá měření.

  
Pro správnou funkci tokenů prosím použít mnou upravené *[api](https://github.com/TenBigi/WaterMonitor_Api)*. Přidal jsem malou funkci, kdy si api automaticky bere nejnovější token.
Nejsem si jistý, zda je to správné řešění, ale chtěl jsem si vyzkoušet posílání věcí i na druhou stranu. :)

Bohužel jsem nezprovoznil monitoring stanic a posílání mailů, ale myslím že základ mám dobrý. Jen mi nejde zprovoznit hangfire. Pokud by práce nestačila na zápočet, určitě to opravím.
Další věc, které není úplně ideální je výpis měření. Ani v jednom případě není nijak ostránkovaný, ani se nedá filtrovat, či řadit. Při velkém objemu dat by to byl určitě problém.  
Jsem si toho vědom a opět, pokud by to byl problém, tak opravím.

  

