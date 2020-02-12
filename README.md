# EPVK

EPVK - Программа для автоматического поиска и комментирования нужных записей ВКонтакте.
Ключевая особенность программы в поиске постов которые будем комментировать. Можно оставить 100+ комментов под какими ни будь рекламными постами или постами с не нужной Вам тематикой - что не будет иметь эффекта, к тому же резко возрастают риски получить бан аккаунта за спам. Используя же гибкие настройки нашей программы достаточно оставить 20-50 комментов, и попасть в цель, где люди нуждаются в том что у вас есть. 

Системные требования:

- Microsoft .NET Framework 4
- Windows XP/7/8/10
- Internet Explorer от 8й версии и выше

Зависимости:
- VkNet.1.35.1

![Иллюстрация к проекту](https://github.com/slay9090/EPVK/raw/master/VK_test/img/1.png)

Возможности:

Основные:
- Возможность использования прокси сервера
- Интеллектуальный поиск записей вашей целевой аудитории, благодаря широкого выбора необходимых параметров
- Комментирование записей от имени Вашей группы
- Механизм работы программы не позволяет дважды оставить комментарий под одной записью
- Прозрачность выполнения процесса

Дополнительные:
- Сбор базы ид по всем возможным параметрам,
- Реализованы механизмы легкого и глубокого поиска,
- Удаление дублей в базе

Обновление 1.1а
- Реализован алгоритм при котором мы не оставим дважды комментарий одному и тому же человеку/группе в разных записях
- Проведена объёмная работа по осуществлению в программе анализа текста записей на основе заданных пользователем текстового фильтра
- Добавлен общий обработчик исключений метода createcomment.wall и авторизации
- Улучшена визуальная составляющая строки поиска, теперь спец. символы аргументов подсвечиваются цветом, не большое изменение так же на панели процесса выполнения, теперь записи соответствующие пользовательскому текстовому фильтру подсвечиваются зеленым
- Устранены мелкие ошибки в процедуре первичного поиска записей, исправлен баг с созданием пустого массива если в поисковой строке в конце был символ ;
- Реализован механизм ввода капчи и автоматического пропуска, в случае бездействия.

Обновление 1.2
- Полностью переработан метод поиска, улучшен алгоритм и эффективность за счет текстовых фильтров
- Добавлено логирование и обработка исключений которые приводили к зависанию приложения

Обновление 1.3
- Добавлена возможность вставлять изображения
- Сохранение/загрузка конфига
- Проверка правильности текстовых фильтров
- Настройка отображения
- Исправлено множество мелких косяков

Обновление 1.4
- Добавлен конструктор фильтров:

========================
Аргументы текстовых фильтров: "*" ();

	"" - Обязательные аргументы, в ковычках может находится одно слово или фраза из двух слов. Фраза ищется в строгой последовательности в тексте.

Например, используя фильтр: "люблю куплю"
 
пост с текстом: 
...в общем, люблю тебя! Сегодня кстати, думала, не куплю я ему ничего пото... 
будет пропущен, а пост с таким текстом: 
...это дело я люблю куплю пожалуй, тока поискать в инете надо ла...
Будет соотвествовать фильтру, и будет оставлен Ваш комментарий.

	Символ * - Не обязательный аргумент, можно не использовать. Определяет поиск слов не зависимо от их окончания, используется только внутри ковычек.

Например, используя фильтр: "люб* куп*"
 
пост с текстом: 
...игрушку эту с детства ещё любила, купила бы обязатательно если бы нашла. Реб...
Будет соотвествовать фильтру и программа оставит ваш комментарий

	( ) - Не обязательный аргумент, используется для отсеивания постов по дополнительному слову, которое может находиться в любой части текста поста. Используется только совместно с выражением в ковычках- "слово1 слово2" (слово3) т.е. в тексте постов будет искаться совадение точной фразы, идущих друг за другом слов "слово1 слово2" плюс к этому совпадение дополнительного слова (слово3) которое может быть в любом месте текста, и только когда все все два выражения "слово1 слово2" и (слово3) будут найдены в тексте поста, будет оставлен коммент. 

К примеру используя фильтр: "нормального дизайн*"(Самара) 

пост с текстом: 
...Друзья, сам не так давно в Самаре проживаю, ищу нормального дизайнера щас надо виз...
Будет считаться как соотвествущий фильтру и программа оставит комментарий.

	; - Обязательный аргумент используется для разделения фильтров 
Пример, ищем посты тех кто хочет купить велик: 
"не дорого"(велик); "приобрету велосипед"; "ищу велик"(цена); "подскажи* где"(велик); "меняю на" (велик) 

------
Чем больше фильтров пропишите, тем больше комментариев оставит программа.
========================

Обновление 1.4.1
- Добавлен графический контсруктор фильтров
![Иллюстрация к проекту](https://github.com/slay9090/EPVK/raw/master/VK_test/img/2.png)

