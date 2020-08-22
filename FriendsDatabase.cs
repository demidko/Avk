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
/// Простенькая nosql база снэпшотов друзей разных пользователей за определенные моменты времени 
/// </summary>
internal class FriendsDatabase
{
    private readonly string _path;
    private readonly VkApi _api;

    private readonly Dictionary<User, LinkedList<(DateTime Timestamp, IReadOnlyCollection<long> FriendsOnline)>>
        _snapshots;

    public FriendsDatabase(string path, VkApi api)
    {
        _path = path;
        _api = api;
        _snapshots = Exists(_path)
            ? Deserialize<Dictionary<User, LinkedList<(DateTime, IReadOnlyCollection<long>)>>>(ReadAllBytes(_path))
            : new Dictionary<User, LinkedList<(DateTime, IReadOnlyCollection<long>)>>();
    }

    /// <returns>список снэпшотов друзей онлайн из базы данных</returns>
    public IEnumerable<(DateTime Timestamp, IReadOnlyCollection<long> FriendsOnline)>
        ListSnapshots(User user) => _snapshots[user];

    /// <summary>
    /// Метод сохраняет снэпшот друзей онлайн в базу данных
    /// </summary>
    public async Task SnapshotAsync(User user)
    {
        var friends = await _api.Friends.GetOnlineAsync(new FriendsGetOnlineParams
        {
            UserId = user.Id, Order = FriendsOrder.Hints
        });
        _snapshots[user].AddLast((DateTime.Now, friends.Online));
        await WriteAllBytesAsync(_path, SerializeToUtf8Bytes(_snapshots));
    }
}