using _1._1_Lesson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1_Lesson.Services;

public class MealsService
{

    private List<Meals> ListedMeals;

    public MealsService()
    {
        ListedMeals = new List<Meals>();
    }


    public Meals AddFood(Meals food)
    {
        food.Id = Guid.NewGuid();
        ListedMeals.Add(food);

        return food;
    }


    public Meals GetById(Guid foodId)
    {
        foreach(var food in ListedMeals)
        {
            if(food.Id == foodId)
            {
                return food;
            }
        }
        return null;
    }



    public List<Meals> GetAllFoods()
    {
        return ListedMeals;
    }



    public bool DeletedFood(Guid foodId)
    {
        var foundFood = GetById(foodId);

        if(foundFood is null)
        {
            return false;
        }

        ListedMeals.Remove(foundFood);
        return true;
    }



    public bool UpdateFood(Meals food)
    {
        var foundFood = GetById(food.Id);

        if(foundFood is null)
        {
            return false;
        }

        var index = ListedMeals.IndexOf(foundFood);
        ListedMeals[index] = foundFood;
        return true;
    }





    // Get Most Expensive Dish
    // Search Dish By Name
    // Get Average Dish Price
    // Get Dish By Location
    // Get Cheapest Dish
    // Add Comment
    // Add Negative Comment







}
