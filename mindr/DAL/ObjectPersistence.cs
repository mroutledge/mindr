using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using mindr.Models;

namespace mindr.DAL
{
    class ObjectPersistence
    {
        private static string _path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\reminders";

        /// <summary>
        /// save reminders to app data
        /// </summary>
        /// <param name="reminders"></param>
        public static void SaveReminders(IEnumerable<Reminder> reminders)
        {
            using (FileStream fs = new FileStream(_path, FileMode.OpenOrCreate))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    bw.Write(reminders.Count());
                    foreach (var minder in reminders)
                    {
                        bw.Write(minder.Title);
                        bw.Write(minder.Message);
                        bw.Write(minder.Due.Ticks);
                    }
                }
            }
        }

        /// <summary>
        /// Loads reminds from app data
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Reminder> LoadReminders()
        {
            List<Reminder> reminders = new List<Reminder>();
            if (File.Exists(_path))
            {
                using (FileStream fs = new FileStream(_path, FileMode.Open))
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        int entries = br.ReadInt32();
                        for (int i = 0; i < entries; i++)
                        {
                            string title = br.ReadString();
                            string message = br.ReadString();
                            long dueAsTicks = br.ReadInt64();

                            DateTime due = new DateTime(dueAsTicks);
                            Reminder minder = new Reminder(title, message, due);
                            reminders.Add(minder);
                        }
                    }
                }
            }

            return reminders;
        }
    }
}
