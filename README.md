# Softwarove Architektury - Hotelový systém

Navrhněte hotelový systém, který řídí celý hotel. Umožnuje recepci provádět rezervace a vyúčtovat služby klientům. Řídí přístup do různých míst a ke službám hotelu na základě koupených služeb, umožňuje objednat jídlo a jiné služby na pokoj.

## Diagram

https://www.figma.com/design/P2PMOooD5uKye8W8b8Zsgc/Event-Storming-(Community)

## Rozdělení práce

 - Service System - Radomír Mann [493346]
 - Billing system - Jakub Košvanec [485430]
 - Access System - Jonáš Jadrníček [514017]
 - Room management System - Josef Žižka [514412]

### Service system
Tato část systému bude odpovědná za to, když dojde k nějakému objednání buď pití jídla nebo pití na pokoj, hotel toto zaznamená a bude to dále interně řešit, než se tento proces neuzavře ukončení, tak že ubytovaný objednávku obdrží nebo bude z nějakého důvodu zamítnuta.

Tato část systému bude rovněž vstupní branou k novým službám hotelu jako jsou přístupy do jiných částí hotelu, které nemusí mít ubytovný povelené hned po ubytování. Mezi takovéto služby můžeme řadit jako přístup do wellnessu, plaveckého bezénu nebo posilovny. (Kde tyto složby vyžadují přístupová práva navíc)

Na konci každé úspěšného dokončení objednané služby bude ubytovanému přidána nová položka na jeho účet.

### Billing system
Systém bude zodpovědný za to, že zákazníkovi bude správně zaúčtováno všechno co si během svého pobytu objednal.

Při jeho ukončení pobytu bude mu vystavena faktura za celý jeho pobyt, kdy pak bude moci zvolit jednu z možností, jak celý pobyt zaplatit a to buď s pomocí platební brány nebo čistě za pomoci hotovosti.

Bude zde existovat i jedno drobné rozšíření, kdy pokud zákazník něco způsobí (a hotel by tím byl nějak peněžně poškozen), bude moci zaměstnanec ubytovanému naúčtovat věci navíc.

### Access system
S příchodem na hotel bude ubytovanému v základu přiřazen přístup na jeho pokoj, kdy pokud bude potřebovat další služby, které právě vyžadují nějaká přístupová práva navíc, tak se o to tento systém správně postará.

V systému bude zahrnuta základní správa, kdy se na jednotlivé požádané služby bude moci reagovat s pomocí zamítnutí nebo povolení této žádosti.

### Room managment system
Systém spravující místnosti bude moci zadávat nové pokoje hotelu do systému pro rezervaci. Pokud bude třeba dočasně nějaký pokoj opravit nebo provést jinou činnost s ním, tak zde budeme moci pokoj dočastně odstavit ze systému, aby nebyl nabízen potencionálnim zákazníkům.

Dále, zde bude možné si zažádat po Checkoutu ubytovaného o jeho uklizení a dokud tato služba nebude provedena, tak se pokoj nebude moci nabídnout žádnému jinému zákazníkovi.

V neposlední řadě bude tato část systému spravovat jednotlivé rezervace nad pokoji.

## Architektura
Systém bude postaven s myšlenkou Clean architecture, kdy celý systém bude běžet nad modular monolith, kdy bude zajištěný jednoduchý přechod na micro service architekturu, v případě potřeby o nějaké rozšíření a škálování.