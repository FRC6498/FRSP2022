using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FRSP2022
{
    public partial class RobotModel : INotifyPropertyChanged
    {
        private bool autoLine = false;
        private int autoLowerCargo = 0;
        private int autoUpperCargo = 0;
        private int teleopLowerCargo = 0;
        private int teleopUpperCargo = 0;
        private HangarRung hangarRung;
        private bool cargoBonus = false;
        private bool hangarBonus = false;
        private int teamNumber;
        private StartPosition startPos;

        // properties determined by 2022 game manual
        #region Autonomous
        public bool AutoLine { get => autoLine; set { autoLine = value; NotifyPropertyChanged(); } }
        public int AutoLowerCargo { get => autoLowerCargo; set { autoLowerCargo = value; NotifyPropertyChanged(); } }
        public int AutoUpperCargo { get => autoUpperCargo; set { autoUpperCargo = value; NotifyPropertyChanged(); } }
        #endregion

        #region Teleop
        public int TeleopLowerCargo { get => teleopLowerCargo; set { teleopLowerCargo = value; NotifyPropertyChanged(); } }
        public int TeleopUpperCargo { get => teleopUpperCargo; set { teleopUpperCargo = value; NotifyPropertyChanged(); } }
        #endregion

        #region Endgame
        public HangarRung HangarRung { get => hangarRung; set { hangarRung = value; NotifyPropertyChanged(); } }
        public bool CargoBonus { get => cargoBonus; set { cargoBonus = value; NotifyPropertyChanged(); } }
        public bool HangarBonus { get => hangarBonus; set { hangarBonus = value; NotifyPropertyChanged(); } }
        #endregion

        #region Misc
        public int TeamNumber { get => teamNumber; set { teamNumber = value; NotifyPropertyChanged(); } }
        public StartPosition StartPos { get => startPos; set { startPos = value; NotifyPropertyChanged(); } }
        #endregion

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static RobotModel Parse(string text)
        {
            RobotModel model = new();
            string[] segments = text.Split(',');
            model.TeamNumber = int.Parse(segments[0]);
            model.StartPos = (StartPosition)Enum.Parse(typeof(StartPosition), segments[1]);
            model.AutoLine = bool.Parse(segments[2]);
            model.AutoLowerCargo = int.Parse(segments[3]);
            model.AutoUpperCargo = int.Parse(segments[4]);
            model.TeleopLowerCargo = int.Parse(segments[5]);
            model.TeleopUpperCargo = int.Parse(segments[6]);
            model.HangarRung = (HangarRung)Enum.Parse(typeof(HangarRung), segments[7]);
            model.CargoBonus = bool.Parse(segments[8]);
            model.HangarBonus = bool.Parse(segments[9]);

            return model;
        }
    }
}
