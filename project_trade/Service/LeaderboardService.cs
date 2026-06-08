using System.Data;
using Dapper;
using StackExchange.Redis;
namespace project_trade.Service;

public class LeaderboardService
(
 IConnectionMultiplexer redis,
 IDbConnection db
 )
{
    public void init()
    {
        string sql = @"
SELECT user_id AS UserId, SUM(quantity) AS Total 
            FROM portfolios 
            GROUP BY user_id 
            ORDER BY Total DESC 
            LIMIT 3        ";
        var TopUsers = db.Query(sql).ToList();
        var redisDb = redis.GetDatabase();
        redisDb.KeyDelete("top3");
        foreach (var user in TopUsers)
        {
            redisDb.SortedSetAdd("top3", user.UserId.ToString(), (double)user.Total);
        }
    }
}



