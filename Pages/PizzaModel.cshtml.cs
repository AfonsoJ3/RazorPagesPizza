using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesPizza.Models;
using RazorPagesPizza.Services;

namespace RazorPagesPizza.Pages
{
    public class PizzaModel : PageModel
    {
        // Field to hold list of pizzas
        public List<Pizza> pizzas = new();

        // Property to bind new pizza data from form
        [BindProperty]
        public Pizza NewPizza { get; set; } = new();

        // Method to run when page loads
        public void OnGet()
        {
            // Get all pizzas from the service and assign to field
            pizzas = PizzaService.GetAll();
        }

        // Method to return text indicating if pizza is gluten free
        public string GlutenFreeText(Pizza pizza)
        {
            if(pizza.IsGlutenFree)
            {
                return "Gluten Free";
            }

            return "Not Gluten Free";
        }

        // Method to run when form is submitted to add new pizza
        public IActionResult OnPost()
        {
            // Check if model state is invalid (e.g. required fields not filled)
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Add new pizza to service and redirect to "Get" method
            PizzaService.Add(NewPizza);
            return RedirectToAction("Get");
        }

        // Method to run when delete button is clicked
        public IActionResult OnPostDelete(int id)
        {
            // Delete pizza with given id from service and redirect to "Get" method
            PizzaService.Delete(id);
            return RedirectToAction("Get");
        }
    }
}