using SQLite;

namespace XamarinForms.SQLite
{
    public class TodoItem
    {

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string PizzaName { get; set; }

        public string Topping1 { get; set; }

        public string Topping2 { get; set; }

        public string Topping3 { get; set; }

        public string Type { get; set; }

        public bool Done { get; set; }

        public override string ToString()
        {
            return string.Format("Done : {0}, Type : {1},  PizzaName : {2}, Topping1 : {3}, Topping2 : {4}, Topping3 : {5}", Done, Type, PizzaName, Topping1, Topping2, Topping3);
        }
    }
}