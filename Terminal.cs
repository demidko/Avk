using System;
using static System.Console;

/// <summary>
/// Расширения для работы с REPL
/// </summary>
internal static class Terminal
{
    private const ConsoleColor SystemColor = ConsoleColor.DarkBlue;

    /// <summary>
    /// Напечатать в консоль
    /// </summary>
    /// <param name="obj">объект</param>
    /// <param name="color">цвет, по умолчанию черный</param>
    /// <typeparam name="T">тип объекта</typeparam>
    // ReSharper disable once MemberCanBePrivate.Global
    public static void Print<T>(this T obj, ConsoleColor? color = null)
    {
        var previousColor = ForegroundColor;
        ForegroundColor = color ?? previousColor;
        Write(obj);
        ForegroundColor = previousColor;
    }

    /// <summary>
    /// Напечатать в консоль с переносом строки
    /// </summary>
    /// <param name="obj">объект</param>
    /// <param name="color">цвет, по умолчанию черный</param>
    /// <typeparam name="T">тип объекта</typeparam>
    // ReSharper disable once MemberCanBePrivate.Global
    public static void Println<T>(this T obj, ConsoleColor? color = null)
    {
        obj.Print(color);
        WriteLine();
    }

    /// <summary>
    /// Метод считывает команду пользователя с помощью ">>>"
    /// </summary>
    /// <returns>строка команды</returns>
    public static string ReadCommand()
    {
        ">>> ".Print(SystemColor);
        // ReSharper disable once AssignNullToNotNullAttribute
        return ReadLine();
    }

    /// <summary>
    /// Напечатать важное сообщение
    /// </summary>
    /// <param name="obj">сообщение</param>
    /// <typeparam name="T">тип сообщения</typeparam>
    public static void PrintImportantMessage<T>(this T obj) => obj.Println(SystemColor);
}