using System;
using System.Collections.Generic;

// 🔹 Абстрактний клас для сутностей із унікальним ідентифікатором
abstract class BaseEntity
{
    public int Id { get; }
    protected BaseEntity(int id) => Id = id;
}

// 🔹 Інтерфейс для гри
interface IPlayable
{
    void Play();
}

// 🔹 Абстрактний клас режиму гри
abstract class GameMode : BaseEntity, IPlayable
{
    protected Dictionary<string, string> Flags = new Dictionary<string, string>();

    protected GameMode(int id) : base(id) { }

    // Додаємо метод для адміністратора, щоб він міг додавати прапори
    public void AddFlag(string country, string flag)
    {
        Flags[country] = flag;
    }

    public abstract void Play();
}

// 🔹 Конкретні режими гри
class EuropeMode : GameMode
{
    public EuropeMode(int id) : base(id)
    {
        Flags.Add("France", "🇫🇷");
        Flags.Add("Germany", "🇩🇪");
        Flags.Add("Italy", "🇮🇹");
    }

    public override void Play()
    {
        Console.WriteLine("Режим: Європа");
        Console.WriteLine("Доступні прапори:");
        foreach (var flag in Flags)
        {
            Console.WriteLine($"{flag.Key}: {flag.Value}");
        }
    }
}

class AsiaMode : GameMode
{
    public AsiaMode(int id) : base(id)
    {
        Flags.Add("Japan", "🇯🇵");
        Flags.Add("China", "🇨🇳");
        Flags.Add("India", "🇮🇳");
    }

    public override void Play()
    {
        Console.WriteLine("Режим: Азія");
        Console.WriteLine("Доступні прапори:");
        foreach (var flag in Flags)
        {
            Console.WriteLine($"{flag.Key}: {flag.Value}");
        }
    }
}

// 🔹 Клас "Користувач"
class Player : BaseEntity
{
    public string Name { get; }

    public Player(int id, string name) : base(id)
    {
        Name = name;
    }
}

// 🔹 Клас "Адміністратор"
class Admin : Player
{
    public Admin(int id, string name) : base(id, name) { }

    // Використовуємо публічний метод `AddFlag` у GameMode
    public void AddFlag(GameMode mode, string country, string flag)
    {
        mode.AddFlag(country, flag);
        Console.WriteLine($"Адміністратор {Name} додав прапор {country}: {flag}");
    }
}

// 🔹 Основний клас для демонстрації роботи
class Program
{
    static void Main()
    {
        Console.WriteLine("Вітаємо у грі 'Flag it up!'");
        Console.WriteLine("Оберіть режим гри: 1 - Європа, 2 - Азія");

        string choice = Console.ReadLine();
        GameMode mode;

        if (choice == "1")
            mode = new EuropeMode(1);
        else if (choice == "2")
            mode = new AsiaMode(2);
        else
        {
            Console.WriteLine("❌ Невірний вибір! Автоматично обрано режим Європи.");
            mode = new EuropeMode(1);
        }

        mode.Play();

        // Додамо адміністратора для перевірки
        Admin admin = new Admin(999, "SuperAdmin");
        admin.AddFlag(mode, "Ukraine", "🇺🇦");

        Console.WriteLine("\n🔹 Оновлений список прапорів:");
        mode.Play();
    }
}
