// 📁 [AssemblyInfo] - Атрибуты сборки
// 🎯 Core function: Настройка атрибутов сборки (InternalsVisibleTo для тестов)
// 🔗 Key dependencies: System.Runtime.CompilerServices
// 💡 Usage: Используется для предоставления доступа к internal классам для тестового проекта

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Max.Bot.Tests")]

