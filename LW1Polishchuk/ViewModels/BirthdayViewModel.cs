using System;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using KMA.ProgrammingInCSharp.LW1Polishchuk.Managers;
using KMA.ProgrammingInCSharp.LW1Polishchuk.Models;
using KMA.ProgrammingInCSharp.LW1Polishchuk.Tools;

namespace KMA.ProgrammingInCSharp.LW1Polishchuk.ViewModels
{
    public class BirthdayViewModel : BaseViewModel
    {
        #region Fields
        private DateTime _birthday = DateTime.Today;
        private UserInfo _user;
        private string _ageInfo = string.Empty;
        private string _zodiacSign = string.Empty;
        private string _chineseHoroscope = string.Empty;
        
        private RelayCommand<object> _birthDayCommand;
        #endregion

        #region Properties
        public DateTime Birthday
        {
            get { return _birthday; }
            set
            {
                _birthday = value;
                OnPropertyChanged();
            }
        }

        public UserInfo User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }

        public string AgeInfo
        {
            get { return _ageInfo; }
            set
            {
                _ageInfo = value;
                OnPropertyChanged();
            }
        }

        public string ChineseHoroscope
        {
            get { return _chineseHoroscope; }
            set
            {
                _chineseHoroscope = value;
                OnPropertyChanged();
            }
        }

        public string ZodiacSign
        {
            get { return _zodiacSign; }
            set
            {
                _zodiacSign = value;
                OnPropertyChanged();
            }
        }
        
        public RelayCommand<object> BirthDayCommand
        {
            get
            {
                return _birthDayCommand ??= new RelayCommand<object>(
                    o => HoroscopeImplementation(), o => ValidateBDay());
            }
        }
        #endregion

        private bool ValidateBDay()
        {
            bool success;
            var now = DateTime.Now;
            if (now.Year - Birthday.Year > 135)
                success = false;
            else
            {
                var delta = now - Birthday;
                success = delta.Milliseconds > 0;
            }

            if (!success)
            {
                MessageBox.Show("Incorrect Birthday.");
                User = null;
            }

            return success;
        }

        private string GetAgeInfo()
        {
            var now = DateTime.Now;
            string happyBirthday = User.BirthDay.Day == now.Day && User.BirthDay.Month == now.Month
                ? "Happy birthday! 🎂 \n"
                : string.Empty;
            int age = now.Month > User.BirthDay.Month ||
                      now.Month == User.BirthDay.Month && now.Day >= User.BirthDay.Day
                ? now.Year - User.BirthDay.Year
                : now.Year - User.BirthDay.Year - 1;
            return happyBirthday + $"Your age is {age}";
        }

        private string GetChineseHoroscope() => $"Your chinese horoscope sign is {User.ChineseHoroscopeSign}";
        private string GetZodiacSign() => $"Your zodiac sign is {User.ZodiacSign}";

        private async void HoroscopeImplementation()
        {
            AgeInfo = ChineseHoroscope = ZodiacSign = string.Empty;
            LoaderManager.Instance.ShowLoader();
            await Task.Delay(2000);

            User = new UserInfo(Birthday);
            LoaderManager.Instance.HideLoader();
            AgeInfo = GetAgeInfo();
            ChineseHoroscope = GetChineseHoroscope();
            ZodiacSign = GetZodiacSign();
        }
    }
}