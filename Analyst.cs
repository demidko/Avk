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
/// Аналитик общения друзей
/// </summary>
internal class Analyst
{
    private const string DbPath = ".db";
    private readonly VkApi _api;
    private readonly Database _db;

    public Analyst(VkApi api)
    {
        _api = api;
        _db = new Database("friends.json", api);
        FromMinutes(1).Schedule(() => { });
    }

    private void UpdateDb()
    {
        foreach (var user in _db.GetUsers())
        {
            
        }
    }
}