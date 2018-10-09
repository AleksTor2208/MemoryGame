using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ModelLayer;
using WpfApp1.Annotations;

namespace WpfApp1
{
   public class CardsViewModel : ViewModelBase
   {
      public ObservableCollection<Card> Model { get; private set; } = new ObservableCollection<Card>();


      public CardsViewModel(Card[] cards)
      {
         cards.ToList().ForEach(c => Model.Add(c));
      }
   }

   public class ViewModelBase : System.Windows.Freezable, INotifyPropertyChanged
   {
      public event PropertyChangedEventHandler PropertyChanged;

      [NotifyPropertyChangedInvocator]

      protected virtual void OnPropertyChanged(string propertyName)
      {
         PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
         if (propertyChanged == null)
            return;
         PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
         propertyChanged((object)this, e);
      }

      protected override Freezable CreateInstanceCore()
      {
         throw new NotImplementedException();
      }
   }
}
