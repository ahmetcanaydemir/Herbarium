using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herbarium.Class
{
    public static class Log
    {
        public  enum LogType
        {
            DEBUG,
            ERROR,
            WARNING,
            INFO
        }
        
        public static void CreateLog(LogType type, string text, string details = null)
        {
            herbariumEntities entities = new herbariumEntities();
            log log = new log()
            {
                datetime = DateTime.Now,
                user = UserBLL.ActiveUser is null ? null : entities.user.Find(UserBLL.ActiveUser.id),
                type = (int)type,
                logtext = text,
                details = details
            };
            entities.log.Add(log);
            entities.SaveChanges();
        }
        public static void Info(string text, string details= null)
        {
            CreateLog(LogType.INFO, text, details);
        }
        public static void Debug(string text, string details= null)
        {
            CreateLog(LogType.DEBUG, text, details);
        }
        public static void Warning(string text, string details=null)
        {
            CreateLog(LogType.WARNING, text, details);
        }
        public static void Error(string text, string details = null)
        {
            CreateLog(LogType.ERROR, text, details);
        }
        public static void Error(string text, Exception ex = null)
        {
            CreateLog(LogType.ERROR, text, "Mesaj:\n" + ex.Message + "\n\nStack Trace\n" + ex.StackTrace);
        }
        public static string PlantRowToJson(DataRow row)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (DataColumn column in row.Table.Columns)
            {
                dic.Add(column.ColumnName, row[column].ToString());
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(dic, Newtonsoft.Json.Formatting.Indented);
        }
        public static string DictToJson(Dictionary<string, string> dic)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(dic, Newtonsoft.Json.Formatting.Indented);
        }
        public static string DiffBetweenTwoDict(Dictionary<string, string> first, Dictionary<string, string> second)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var key in first.Keys)
            {
                if (first[key] != second[key])
                    sb.Append(key + ":\t" + second[key] + " --> " + first[key] + "\n");
            }
            return sb.ToString();
        }

        public static Dictionary<string, string> PlantRowToDict(DataRow row)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (DataColumn column in row.Table.Columns)
            {
                dic.Add(column.ColumnName, row[column].ToString());
            }
            return dic;
        }
        public static List<Dictionary<string, string>> DataTableToList(DataTable table)
        {
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(PlantRowToDict(row));
            }
            
            return list;
        }
    }
}
