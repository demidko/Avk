using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using VkNet;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using static System.IO.File;
using static System.Text.Json.JsonSerializer;

/// <summary>
/// Простенькая база снэпшотов друзей-онлайн пользователей за определенные моменты времени 
/// </summary>
internal class Database
{
    private readonly string _path;

    private readonly Dictionary<long, LinkedList<(DateTime Timestamp, IEnumerable<long> FriendsOnline)>>
        _snapshots;

    private readonly VkApi _api;


    public Database(string path, VkApi api)
    {
        _path = path;
        _api = api;
        _snapshots = Exists(_path)
            ? Deserialize<Dictionary<long, LinkedList<(DateTime, IEnumerable<long>)>>>(ReadAllBytes(_path))
            : new Dictionary<long, LinkedList<(DateTime, IEnumerable<long>)>>();
    }

    /// <summary>
    /// Перечислить пользователей данные о которых есть в базе
    /// </summary>
    public IEnumerable<long> GetUsers() => _snapshots.Keys;

    /// <summary>
    /// Удалить данные о пользователе из базы
    /// </summary>
    public void RemoveUser(long userId) => _snapshots.Remove(userId);

    /// <returns>список снэпшотов друзей онлайн из базы данных</returns>
    public IEnumerable<(DateTime Timestamp, IEnumerable<long> FriendsOnline)>
        GetSnapshots(long userId) => _snapshots[userId];

    // TODO снепшоты делаем здесь для оптимизации записи в файл


    private async ValueTask SnapshotAsync(long userId)
    {
        var friends = await _api.Friends.GetOnlineAsync(new FriendsGetOnlineParams
        {
            UserId = userId,
            Order = FriendsOrder.Hints
        });
        if (!_snapshots.ContainsKey(userId))
        {
            _snapshots[userId] = new LinkedList<(DateTime Timestamp, IEnumerable<long> FriendsOnline)>();
        }
        _snapshots[userId].AddLast((DateTime.Now, friends.Online));
    }
}