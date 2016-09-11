using SQLite;
using System;
using Xamarin.Forms;
using XamarinForms.SQLite;
using XamarinForms.SQLite.SQLite;
using System.Threading.Tasks;

namespace LAPIZZA2
{
    public class SQLiteSamplePage
    {
        private readonly SQLiteConnection _sqLiteConnection;

        public SQLiteSamplePage()
        {

            _sqLiteConnection = DependencyService.Get<ISQLite>().GetConnection();

            _sqLiteConnection.CreateTable<TodoItem>();

           
        }

        public Task Navigation { get; private set; }

        /// <summary>
        /// Gets a ContentPage that contains the items saved in the SQLite database.
        /// </summary>
        /// <returns></returns>
        public ContentPage GetSampleContentPage()
        {
            var picker = new Picker
            {
                Title = "Pizza Base",
                IsVisible = true 
            };
            picker.Items.Add("Itallian");
            picker.Items.Add("Thick pan");

            var picker2 = new Picker
            {
                Title = "Topping No 1",
                IsVisible = true 
            };
            picker2.Items.Add("Pepperoni");
            picker2.Items.Add("Ham");
            picker2.Items.Add("Mushroom");
            picker2.Items.Add("Chillies");
            picker2.Items.Add("Toffu");
            picker2.Items.Add("Capsicum");
            picker2.Items.Add("Veg");
            picker2.Items.Add("Pumpkin");
            picker2.Items.Add("None");


            var picker3 = new Picker
            {
                Title = "Topping #2",
                IsVisible = true 
            };
            picker3.Items.Add("Pepperoni");
            picker3.Items.Add("Ham");
            picker3.Items.Add("Mushroom");
            picker3.Items.Add("Chillies");
            picker3.Items.Add("Toffu");
            picker3.Items.Add("Capsicum");
            picker3.Items.Add("Veg");
            picker3.Items.Add("Pumpkin");
            picker3.Items.Add("None");

            var picker4 = new Picker
            {
                Title = "Toping #3",
                IsVisible = true //<= Is on the page but doesnt use space
            };
            picker4.Items.Add("Pepperoni");
            picker4.Items.Add("Ham");
            picker4.Items.Add("Mushroom");
            picker4.Items.Add("Chillies");
            picker4.Items.Add("Toffu");
            picker4.Items.Add("Capsicum");
            picker4.Items.Add("Veg");
            picker4.Items.Add("Pumpkin");
            picker4.Items.Add("None");

            var pickerT = new Picker
            {
                Title = "Pizza Style",
                IsVisible = true //<= Is on the page but doesnt use space
            };
            pickerT.Items.Add("Custome");
            pickerT.Items.Add("Pepperoni");
            pickerT.Items.Add("Hawaian");
            pickerT.Items.Add("Portobello");
            pickerT.Items.Add("Meat Feast");
            pickerT.Items.Add("Spicy Chicken");
            pickerT.Items.Add("Pumpkin");
            pickerT.Items.Add("Four Cheese");
         







            var listView = new ListView
            {
                ItemsSource = _sqLiteConnection.Table<TodoItem>()
            };

            try
            {
                var pickerSelection = picker.Items[picker.SelectedIndex];
            } catch(Exception e)
            {
                //picker error
            }
            try
            {
                var pickerSelection2 = picker2.Items[picker.SelectedIndex];
            }
            catch (Exception e)
            {
                //picker error
            }
            try
            {
                var pickerSelection3 = picker3.Items[picker.SelectedIndex];
            }
            catch (Exception e)
            {
                //picker error
            }
            try
            {
                var pickerSelection4 = picker4.Items[picker.SelectedIndex];
            }
            catch (Exception e)
            {
                //picker error
            }

            try
            {
                var pickerSelection5 = pickerT.Items[picker.SelectedIndex];
            }
            catch (Exception e)
            {
                //picker error
            }

            var addButton = new Button
            {
                Text = "Add Pizza Type"
            };
            addButton.Clicked += (s, e) =>
            {
                var pickerSelection = picker.Items[picker.SelectedIndex];
                var pickerSelection2 = picker.Items[picker.SelectedIndex];
                var pickerSelection3 = picker.Items[picker.SelectedIndex];
                var pickerSelection4 = picker.Items[picker.SelectedIndex];
                var pickerSelection5 = pickerT.Items[picker.SelectedIndex];
                _sqLiteConnection.Insert(new TodoItem
                {
                    PizzaName = pickerSelection5,
                    Type = pickerSelection,
                    Topping1 = pickerSelection2,
                    Topping2 = pickerSelection3,
                    Topping3 = pickerSelection4,
                    
                });
                listView.ItemsSource = _sqLiteConnection.Table<TodoItem>();
            };

           var SummaryButton = new Button
           {
                Text = "Summary"
           };
            SummaryButton.Clicked += (s, e) =>
            {
                
                };
                // _sqLiteConnection.Insert(new TodoItem
                {

                }
            

          


           
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
                               

                            }
                        },
                        new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            Children =
                            {
                                
                                pickerT,
                                
                            }
                        },
                        picker2,
                        picker3,
                        picker4,
                        addButton,
                        listView,


                    }
                }
            };
            return contentPage;
        }
    }
}
