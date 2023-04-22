using RazorPagesPizza.Models; // import the Pizza model

namespace RazorPagesPizza.Services
{
    public static class PizzaService // define the PizzaService class
    {
        // initialize a list of pizzas and a counter for the next ID
        static List<Pizza> Pizzas { get; }
        static int nextId = 3;

        // initialize the list of pizzas with some initial values
        static PizzaService()
        {
            Pizzas = new List<Pizza>
            {
                new Pizza { Id = 1, Name = "Classic Italian", Price = 20.00M, Size = PizzaSize.Large, IsGlutenFree = false },
                new Pizza { Id = 2, Name = "Veggie", Price = 15.00M, Size = PizzaSize.Small, IsGlutenFree = true }
            };
        }

        // method to get all pizzas in the list
        public static List<Pizza> GetAll()
        {
            return Pizzas;
        }

        // method to get a pizza by its ID
        public static Pizza? Get(int id)
        {
            foreach (var pizza in Pizzas)
            {
                if (pizza.Id == id)
                {
                    return pizza;
                }
            }

            return null; // return null if no pizza with the given ID is found
        }

        // method to add a new pizza to the list
        public static void Add(Pizza pizza)
        {
            pizza.Id = nextId++; // assign a unique ID to the new pizza
            Pizzas.Add(pizza); // add the new pizza to the list
        }

        // method to delete a pizza from the list by its ID
        public static void Delete(int id)
        {
            var pizza = Get(id); // get the pizza with the given ID
            if (pizza is null) // if no pizza is found, return early
                return;

            Pizzas.Remove(pizza); // remove the pizza from the list
        }

        // method to update an existing pizza in the list
        public static void Update(Pizza pizza)
        {
            var index = Pizzas.FindIndex(p => p.Id == pizza.Id); // find the index of the pizza with the same ID
            if (index == -1) // if no pizza is found, return early
                return;

            Pizzas[index] = pizza; // update the pizza at the found index
        }
    }
}