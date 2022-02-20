﻿using System.IO;

namespace FRSP2022
{
    public class CSVExporter
    {
        private static readonly string header = "TeamNumber,StartPosition,AutoLine,AutoLower,AutoUpper,TeleopLower,TeleopUpper,HangarRung,CargoBonus,HangarBonus";
        private static readonly string eventFilePath = @"C:\6498\matchResults.csv";
        //Path.Combine(new DirectoryInfo(new FileInfo(Assembly.GetEntryAssembly().Location).FullName).Parent.FullName, "matchResults.csv");
        public static void Export(RobotModel robot)
        {
            // append current record to file
            string record = $"{robot.TeamNumber},{robot.StartPos},{robot.AutoLine},{robot.AutoLowerCargo},{robot.AutoUpperCargo},{robot.TeleopLowerCargo},{robot.TeleopUpperCargo},{robot.HangarRung},{robot.CargoBonus},{robot.HangarBonus}";

            if (File.Exists(eventFilePath))
            {
                using FileStream fs = new(eventFilePath, FileMode.Append, FileAccess.Write, FileShare.Write);
                using StreamWriter sw = new(fs);
                sw.WriteLine(record);
            }
            else
            {
                using FileStream fs = new(eventFilePath, FileMode.CreateNew, FileAccess.Write, FileShare.Write);
                using StreamWriter sw = new(fs);
                sw.WriteLine(header);
                sw.WriteLine(record);
            }
        }
    }
}
