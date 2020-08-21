using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using VkNet;
using VkNet.Model;
using static System.IO.File;
using static System.Text.Json.JsonSerializer;
using static System.TimeSpan;
using static Authorization;
using Timer = System.Timers.Timer;

/// <summary>
/// Главный класс
/// </summary>
internal class Application
{
    private const string DbPath = ".db";

    private readonly Dictionary<User, LinkedList<(DateTime timestamp, List<User> onlineFriends)>>
        _db = new Dictionary<User, LinkedList<(DateTime, List<User>)>>();

    private readonly VkApi _api;

    private Application(VkApi api)
    {
        _api = api;
        if (Exists(DbPath))
        {
            _db = Deserialize<Dictionary<User, LinkedList<(DateTime, List<User>)>>>(ReadAllBytes(DbPath));
        }
        FromMinutes(1).Schedule(() => WriteAllBytesAsync(".db", SerializeToUtf8Bytes(_db)));
    }

    private void Analyze(string link)
    {
    }

    private void StopAnalysis


    private static void Main(string[] user)
    {
        var application = new Application(Login(user));
        // цикл обработки команд
    }
}