# KitchenGateWayAPI

Проект предназначен для работы сотрудников ресторана с разделением обязанностей. В данном случае существует две категории работника: повар и официант. В каждой категории сотрудники делятся на старшего и рядового персонала.
Старшие повара могут создавать и изменять рецепты, а официанты собирать обрабатывать заказы посетителей.

Решение KitchenGateWayAPI содержит следующие проекты:
<ul>
  <li>AuthorizationAPI</li>
  <li>KitchenGateWayAPI</li>
  <li>OrderAPI</li>
  <li>RecipeAPI</li>
  <li>ReceiptAPI</li>
  <li>OrderAPI.Test</li>
  <li>RecipeApi.Test</li>
</ul>

Логирование осуществляет Serilog, который пишет сообщения в единый журнал Seq.


<h3>AuthorizationAPI</h3>

<p>Данный проект отвечает за регистрацию новых сотрудников и выдача токенов. </p>
Используется Asp.Net Core Identity для хранения данных пользователя и управления ими в БД (Sqlite).
Пользователям присвоены утверждения о принадлежности к профессии и наличии признака старшего сотрудника. 
Получив токен, пользователь может обращаться к контроллерам проектов OrderAPI и RecipeAPI.

<h3>KitchenGateWayAPI</h3>
<p>Данный проект является шлюзом API и действует как единая точка входа для группы API. Шлюз реализован с помощью Ocelot. </p>
Шлюз перенаправляет запрос, проверяя наличие прав у пользователей на работу с контроллерами сервисов.


<h3>OrderAPI</h3>
<p>Предназначен для работы официантов с заказами. Позволяет получать отчеты по заказам, а также расчитать итоговую стоимость. </p>
Информация о заказах хранится в БД MS SQL server. Для получения отчетов были написаны процедуры, вызов которых осуществляется с помощью Dapper, который обеспечивает большую производительность и быстрее позволяет выполнять запросы, чем EF Core. 


<h3>RecipeAPI</h3>
<p>Предназначен для работы поваров с рецептами. </p>
Доступ к методам контроллеров имеют старшие повара. Для работы со списком рецептов используется Entity Framework Core.


<h3>ReceiptAPI</h3>
<p>Предназначен для работы бухгалтерии для контроля кассовых чеков. </p>
База чеков хранится на PostgreSQL. Вызов sql-функций осуществляется с помощью ADO.NET.


<h3>OrderAPI.Test и RecipeApi.Test</h3>
<p>Проекты для модульного тестирования на основе xUnit </p>
