﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace My.BaseViewModels
{
    public abstract class NotifyPropertyChangedBase : INotifyPropertyChanged
    {
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        #endregion
    }
}
