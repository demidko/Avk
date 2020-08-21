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
    private readonly Dictionary<User, LinkedList<(DateTime timestamp, List<User> onlineFriends)>> _db;
    private readonly VkApi _api;

    private Application(string[] authorizationData)
    {
        _api = LoginApi(authorizationData);
        _db = Exists(DbPath)
            ? Deserialize<Dictionary<User, LinkedList<(DateTime, List<User>)>>>(ReadAllBytes(DbPath))
            : new Dictionary<User, LinkedList<(DateTime, List<User>)>>();
        FromMinutes(1).Schedule(async () => await WriteAllBytesAsync(".db", SerializeToUtf8Bytes(_db)));
    }

    private void Analyze(string link)
    {
    }

    private static void Main(string[] authorizationData)
    {
        var application = new Application(authorizationData);

        // цикл обработки команд
    }
}