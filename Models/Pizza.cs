using System.ComponentModel.DataAnnotations;

namespace RazorPagesPizza.Models;

public class Pizza
{
    // Declare a public integer property called "Id", which represents the unique identifier of a pizza.
    public int Id { get; set; }

    // Add the [Required] attribute to the following property.
    [Required]
    // Declare a public nullable string '?' property called "Name", which represents the name of the pizza.
    public string? Name { get; set; }

    // Declare a public PizzaSize property called "Size", which represents the size of the pizza.
    public PizzaSize Size { get; set; }

    // Declare a public boolean property called "IsGlutenFree", which represents whether the pizza is gluten-free.
    public bool IsGlutenFree { get; set; }

    // Add the [Range] attribute to the following property.
    [Range(0.01, 9999.99)]
    // Declare a public decimal property called "Price", which represents the price of the pizza.
    public decimal Price { get; set; } 
}


public enum PizzaSize {
     Small, 
     Medium, 
     Large }