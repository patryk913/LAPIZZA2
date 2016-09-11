using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;
using XamarinForms.SQLite;
using XamarinForms.SQLite.SQLite;

namespace LAPIZZA2
{
    public class Summary : ContentPage
    {

        private readonly SQLiteConnection _sqLiteConnection;

        public Summary()
        {

            _sqLiteConnection = DependencyService.Get<ISQLite>().GetConnection();

            _sqLiteConnection.CreateTable<TodoItem>();

            var listView = new ListView
            {
                ItemsSource = _sqLiteConnection.Table<TodoItem>()
            };

            new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                            {
                                listView,


                            }
            };
        }
    }
}
