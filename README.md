# Max.Bot - C# библиотека для Max Messenger Bot API

[![.NET](https://img.shields.io/badge/.NET-9.0-purple.svg)](https://dotnet.microsoft.com/)
[![License](https://img.shields.io/badge/license-Apache%202.0-blue.svg)](LICENSE)

Полнофункциональная библиотека для работы с [Max Messenger Bot API](https://dev.max.ru/docs-api) на платформе .NET 9.

## 📋 Статус проекта

**Статус:** 🚧 В разработке

Библиотека находится на стадии планирования.

## 🎯 Цели проекта

Создать современную, типобезопасную и удобную в использовании библиотеку для работы с Max Messenger Bot API, следуя лучшим практикам из:
- [Telegram.Bot](https://github.com/TelegramBots/Telegram.Bot) - опыт разработки .NET Bot API клиентов
- [VkNet](https://github.com/vknet/vk) - опыт работы с VK API на .NET

## 📚 Референсы

- **Официальная документация:** [dev.max.ru/docs-api](https://dev.max.ru/docs-api)
- **TypeScript реализация:** [max-bot-api-client-ts](https://github.com/max-messenger/max-bot-api-client-ts)
- **Go реализация:** [max-bot-api-client-go](https://github.com/max-messenger/max-bot-api-client-go)

## 🚀 План разработки

Подробный план поэтапной разработки библиотеки описан в файле [`DEVELOPMENT_PLAN.md`](DEVELOPMENT_PLAN.md).

### Основные этапы:

1. ✅ **Подготовка инфраструктуры** - структура проекта, настройка .NET 9
2. 🔄 **Базовый HTTP клиент** - реализация HTTP запросов с retry механизмом
3. 📦 **Базовые модели данных** - User, Chat, Message, Update и другие
4. 🔌 **API методы - Core** - основные методы (getMe, sendMessage, getChat)
5. 📊 **Расширение моделей** - все остальные модели из документации
6. 🔧 **Все остальные API методы** - полная реализация всех методов API
7. 📡 **Обработка событий** - Long Polling и Webhook поддержка
8. 📖 **Документация** - XML документация, примеры, README
9. 🚢 **CI/CD и публикация** - автоматизация сборки и публикация в NuGet

## 🛠 Технологии

- **.NET 9** - целевая платформа
- **System.Text.Json** - сериализация/десериализация
- **Microsoft.Extensions.Http** - HTTP клиент
- **xUnit** - тестирование
- **Moq** - моки для тестов

## 📝 Лицензия

Apache License 2.0 - см. файл [LICENSE](LICENSE)

## 🤝 Вклад в проект

План разработки находится в стадии формирования. После начала реализации будет добавлена информация о том, как можно поучаствовать в разработке.

---

**Версия:** 0.1.0-alpha (планирование)  
**Последнее обновление:** 2025-01-XX