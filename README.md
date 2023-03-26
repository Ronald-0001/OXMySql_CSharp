# oxmysql_csharp
* c# compatability for oxmysql
* awaoids [#thread-affinity](https://docs.fivem.net/docs/scripting-manual/runtimes/javascript/#thread-affinity)

# oxsql
* include/oxmysql.cs is a class you can include to your project for easy use

# examples
* tests/server.cs
---
```cs
// example insert
int ins_id1 = await Oxsql.Insert("INSERT INTO characters (cid) VALUES (?)", new string[] { "discord:test_1" });
Print.Success(ins_id1.ToString());
```
---
```
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
```
```
