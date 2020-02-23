using System.ComponentModel;
using System.Windows;

namespace KMA.ProgrammingInCSharp.LW1Polishchuk
{
    internal interface ILoaderOwner : INotifyPropertyChanged
    {
        Visibility LoaderVisibility { get; set; }
        bool IsControlEnabled { get; set; }
    }
}
