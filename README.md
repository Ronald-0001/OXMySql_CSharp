# oxmysql_csharp
* c# compatability for oxmysql
* awaoids [#thread-affinity](https://docs.fivem.net/docs/scripting-manual/runtimes/javascript/#thread-affinity)

# oxsql
* include/oxmysql.cs is a class you can include to your project for easy use

# examples
---
```cs
// example insert
int ins_id1 = await Oxsql.Insert("INSERT INTO characters (cid) VALUES (?)", new string[] { "discord:test_1" });
Print.Success(ins_id1.ToString());
```
---
```cs
// example prepare multi return
IDictionary<string, object> row = (IDictionary<string, object>)await Oxsql.Prepare(
  "SELECT * FROM characters WHERE cid = ?", new string[] { "discord:test_1" }
);
Print.Log(string.Join(", ", row.Keys));

// example prepare single return
object i = await Oxsql.Prepare("SELECT i FROM characters WHERE cid = ?", new string[] { "discord:test_1" });
if (i is int _i) { Print.Success(_i.ToString()); }
```
---
```cs
// example query multi return
IDictionary<string, object> row = (IDictionary<string, object>)await Oxsql.Query(
  "SELECT cid,cts FROM characters WHERE cid = ?", new string[] { "discord:test_1" }
);
Print.Log(string.Join(", ", row.Keys));

// example query single return
object i = await Oxsql.Query("SELECT i FROM characters WHERE cid = ?", new string[] { "discord:test_1" });
if (i is int _i) { Print.Success(_i.ToString()); }
```
---
```cs
// example scalar
object i = await Oxsql.Scalar("SELECT i FROM characters WHERE cid = ?", new string[] { "discord:test_1" });
if (i is int _i) { Print.Success(_i.ToString()); }
```
---
```cs
// example single
IDictionary<string, object> row = await Oxsql.Single("SELECT * FROM characters WHERE cid = ?", new string[] { "discord:test_1" });
Print.Log(string.Join(", ", row.Keys));
```
---
```cs
// example transaction
object transaction1 = new
{
    query = "UPDATE characters set cts = CURRENT_TIMESTAMP() WHERE cid = :user",
    values = new
    {
        user = "discord:test_1",
    },
};
object transaction2 = new
{
    query = "UPDATE characters set cts = :time WHERE cid = :user",
    values = new
    {
        user = "discord:test_2",
        time = "2000-12-24 00:00:00",
    },
};
var query = new[] {
    transaction1,
    transaction2,
};
bool success = await Oxsql.Transaction(query);
Print.Success(success.ToString());
```
---
```cs
// example update
int changedRows = await Oxsql.Update("UPDATE characters SET cts = CURRENT_TIMESTAMP() WHERE cid = :user ", new { id = 10000, user = "discord:test_1" });
Print.Success(changedRows.ToString());
```
