using System;
using static System.Console;
using static System.ConsoleColor;

/// <summary>
/// Класс для печати данных в консоль
/// </summary>
internal static class Terminal
{
    /// <summary>
    /// Напечатать в консоль
    /// </summary>
    /// <param name="obj">объект</param>
    /// <param name="color">цвет, по умолчанию черный</param>
    /// <typeparam name="T">тип объекта</typeparam>
    internal static void Print<T>(this T obj, ConsoleColor color = Black)
    {
        var previousColor = ForegroundColor;
        ForegroundColor = color;
        Write(obj);
        ForegroundColor = previousColor;
    }

    /// <summary>
    /// Напечатать в консоль с переносом строки
    /// </summary>
    /// <param name="obj">объект</param>
    /// <param name="color">цвет, по умолчанию черный</param>
    /// <typeparam name="T">тип объекта</typeparam>
    internal static void Println<T>(this T obj, ConsoleColor color = Black)
    {
        obj.Print(color);
        WriteLine();
    }
}