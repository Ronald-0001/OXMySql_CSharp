using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CitizenFX.Core;
using RedLib;
using Newtonsoft.Json.Linq;

namespace Resource.Server
{
    public class ServerMain : ServerScript
    {
        public static ServerMain Instance { get; private set; }
        public static PlayerList PlayerList;
        public static EventHandlerDictionary EventRegistry => Instance.EventHandlers;
        public static ExportDictionary ExportRegistry => Instance.Exports;
        public ServerMain()
        {
            Instance = this;
            PlayerList = Players;
            //
            _ = Init();
        }
        private async Task Init()
        {
            // mysql fuck yeah lets test it
            await Oxsql.Init();

            // tests insert
            //int ins_id1 = await Oxsql.Insert("INSERT INTO characters (cid) VALUES (?)", new string[] { "discord:test_1" });
            //Print.Success(ins_id1.ToString());

            // tests prepare
            //IDictionary<string, object> row = (IDictionary<string, object>)await Oxsql.Prepare("SELECT * FROM characters WHERE cid = ?", new string[] { "discord:871500157307486279_1" });
            //Print.Log(string.Join(", ", row.Keys));
            //if (row.ContainsKey("cid")) { Print.Success(Blob.Convert(row["cid"])); } // blob "Type = List<int>"
            //// timestamp !is double ?!!!!
            //if (row.ContainsKey("cts")) { Print.Success(TimeStamp.Convert(row["cts"])); } // timestamp "Type = double"
            //
            //object i = await Oxsql.Prepare("SELECT i FROM characters WHERE cid = ?", new string[] { "discord:test_1" });
            //if (i is int _i) { Print.Success(_i.ToString()); }

            // tests query
            //IDictionary<string, object> row = (IDictionary<string, object>)await Oxsql.Query("SELECT cid,cts FROM characters WHERE cid = ?", new string[] { "discord:871500157307486279_1" });
            //Print.Log(string.Join(", ", row.Keys));
            //if (row.ContainsKey("cid")) { Print.Success(Blob.Convert(row["cid"])); } // blob "Type = List<int>"
            //// timestamp !is double ?!!!!
            //if (row.ContainsKey("cts")) { Print.Success(TimeStamp.Convert(row["cts"])); } // timestamp "Type = double"
            //
            //object i = await Oxsql.Query("SELECT i FROM characters WHERE cid = ?", new string[] { "discord:test_1" });
            //if (i is int _i) { Print.Success(_i.ToString()); }

            // tests scalar
            //object i = await Oxsql.Scalar("SELECT i FROM characters WHERE cid = ?", new string[] { "discord:test_1" });
            //if (i is int _i) { Print.Success(_i.ToString()); }

            // tests single
            //IDictionary<string, object> row = await Oxsql.Single("SELECT * FROM characters WHERE cid = ?", new string[] { "discord:871500157307486279_1" });
            //if (row.ContainsKey("cid")) { Print.Success(Blob.Convert(row["cid"])); } // blob "Type = List<int>"
            //if (row.ContainsKey("cts")) { Print.Success(TimeStamp.Convert(row["cts"])); } // timestamp "Type = double"

            // tests transaction
            //object transaction1 = new
            //{
            //    query = "UPDATE characters set cts = CURRENT_TIMESTAMP() WHERE cid = :user",
            //    values = new
            //    {
            //        user = "discord:test_1",
            //    },
            //};
            //object transaction2 = new
            //{
            //    query = "UPDATE characters set cts = :time WHERE cid = :user",
            //    values = new
            //    {
            //        user = "discord:test_2",
            //        time = "2000-12-24 00:00:00",
            //    },
            //};
            //var query = new[] {
            //    transaction1,
            //    transaction2,
            //};
            //bool success = await Oxsql.Transaction(query);
            //Print.Success(success.ToString());

            // tests update
            //int row = await Oxsql.Update("UPDATE characters SET cts = CURRENT_TIMESTAMP() WHERE cid = :user ", new { id = 10000, user = "discord:test_1" });
            //Print.Success(row.GetType().Name);
            //if (row is int _i) { Print.Success(_i.ToString()); }

            Print.Log("TESTED!");
        }
    }
}