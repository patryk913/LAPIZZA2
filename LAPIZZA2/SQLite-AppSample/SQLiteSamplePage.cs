using SQLite;
using Xamarin.Forms;
using XamarinForms.SQLite;
using XamarinForms.SQLite.SQLite;

namespace LAPIZZA2
{
    public class SQLiteSamplePage
    {
        private readonly SQLiteConnection _sqLiteConnection;

        public SQLiteSamplePage()
        {

            _sqLiteConnection = DependencyService.Get<ISQLite>().GetConnection();

            _sqLiteConnection.CreateTable<TodoItem>();

            // ADD
            _sqLiteConnection.Insert(new TodoItem
            {
                Text = "Tutorial about SQLite",
                Done = false,
            });

            // UPDATE
            _sqLiteConnection.Update(new TodoItem
            {
                ID = 1,
                Text = "Creating a tutorial about SQLite",
                Done = true,
            });

            _sqLiteConnection.Insert(new TodoItem
            {
                Text = "Meeting Friends at 11 AM",
                Done = true,
            });

            // DELETE
            _sqLiteConnection.Delete<TodoItem>(2);
        }

        /// <summary>
        /// Gets a ContentPage that contains the items saved in the SQLite database.
        /// </summary>
        /// <returns></returns>
        public ContentPage GetSampleContentPage()
        {
            var picker = new Picker
            {
                Title = "Pizza Base",
                IsVisible = true //<= Is on the page but doesnt use space
            };
            picker.Items.Add("Itallian");
            picker.Items.Add("Thick pan");


            var PizzaName = new Entry
            {
                Placeholder = "Pizzan Type",
                WidthRequest = Device.OnPlatform<double>(300, 300, 260)
            };

            var PizzaTopping = new  Entry
            {
                Placeholder = "Topping",
                WidthRequest = Device.OnPlatform<double>(300, 300, 260)
            };

            var switcher = new Switch();

            var listView = new ListView
            {
                ItemsSource = _sqLiteConnection.Table<TodoItem>()
            };

            var addButton = new Button
            {
                Text = "Add TodoItem"
            };
            addButton.Clicked += (s, e) =>
            {
                _sqLiteConnection.Insert(new TodoItem
                {
                    Text = PizzaName.Text,
                    Done = switcher.IsToggled,
                });
                listView.ItemsSource = _sqLiteConnection.Table<TodoItem>();
            };

           

            var refreshButton = new Button
            {
                Text = "Refresh TodoItems"
            };


            refreshButton.Clicked += (s, e) =>
            {
                listView.ItemsSource = _sqLiteConnection.Table<TodoItem>();
            };

            var contentPage = new ContentPage
            {
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label
                        {
                            Text = "LAPIZZA",
                            FontSize = 50
                        },
                        new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            Children =
                            {
                                picker,
                                PizzaName,
                                switcher,
                            }
                        },
                        PizzaTopping,
                        addButton,
                        refreshButton,
                        listView,
                    }
                }
            };
            return contentPage;
        }
    }
}
