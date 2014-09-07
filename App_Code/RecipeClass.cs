using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RecipeClass
/// </summary>
public class RecipeClass
{
    public RecipeClass()
    { }
    //
    // TODO: Add constructor logic here
    //
    public int RecipeID { get; set; }
    public string RecipeCategory { get; set; }
    public string RecipeName { get; set; }
    public string Cook { get; set; }
    public string Ingredients { get; set; }
    public string Directions { get; set; }
    public int Views { get; set; }
    public int Favorites { get; set; }
    public int Likes { get; set; }
    public string ImagePath { get; set; }
    public int PreparationTime { get; set; }
    public DateTime DateAdded { get; set; }


    public RecipeClass(string recipeCategory, string recipeName, string cook, string ingredients, string directions, int preparationTime, string imagePath = null)
    {
        RecipeCategory = recipeCategory;
        RecipeName = recipeName;
        Cook = cook;
        Ingredients = ingredients;
        Directions = directions;
        PreparationTime = preparationTime;
        ImagePath = imagePath;
        DateAdded = DateTime.Now.Date;
    }
}