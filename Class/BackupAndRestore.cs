using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Smo;
namespace Herbarium.Class
{
    
    class BackupAndRestore
    {
       private Server server;
        public BackupAndRestore()
        {
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(@"data source =.\SQLEXPRESS; initial catalog = herbarium; integrated security = True;");
            server = new Server(new Microsoft.SqlServer.Management.Common.ServerConnection(conn));
        }
        public bool Backup(string path)
        {
            try
            {
                Backup bkpDBFull = new Backup();
                bkpDBFull.Action = BackupActionType.Database;
                bkpDBFull.Database = "herbarium";
                bkpDBFull.Devices.AddDevice(path, DeviceType.File);

                bkpDBFull.BackupSetName = "herbarium database Backup";
                bkpDBFull.BackupSetDescription = "herbarium database - Full Backup " + DateTime.Now;
                bkpDBFull.Initialize = false;


                bkpDBFull.SqlBackup(server);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        
        public bool Restore(string path)
        {
            try
            {
                Restore restoreDB = new Restore();
                restoreDB.Database = "herbarium";
                restoreDB.Action = RestoreActionType.Database;
                restoreDB.Devices.AddDevice(@"D:\AdventureWorksFull.bak", DeviceType.File);

                restoreDB.ReplaceDatabase = true;
                restoreDB.NoRecovery = true;

                // restoreDB.PercentComplete += CompletionStatusInPercent;
                // restoreDB.Complete += Restore_Completed;

                restoreDB.SqlRestore(server);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
