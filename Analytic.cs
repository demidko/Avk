using System;
using System.Collections.Generic;
using System.Linq;
using VkNet;
using VkNet.Model;
using static System.IO.File;
using static System.Text.Json.JsonSerializer;
using static System.TimeSpan;
using static Authorization;

/// <summary>
/// Аналитик для простых задач
/// </summary>
internal class Analytic
{
    private const string DbPath = ".db";
    private readonly VkApi _api;
    private readonly FriendsDatabase _db;

    public Analytic(VkApi api)
    {
        _api = api;
        _db = new FriendsDatabase("friends.json", api);
    }
}