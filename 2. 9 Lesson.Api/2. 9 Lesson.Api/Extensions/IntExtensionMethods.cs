using System.Text;

namespace _2._9_Lesson.Api.Extensions;

public static class IntExtensionMethods
{
    /**
    public static bool GetEvenNumbers(this int number)
    {
        return number % 2 == 0;
    }



    public static bool GetAmountOfPrimeNumbers(this int number)
    {
        int count = 0;

        for (var i = 1; i <= number; i++)
        {
            if (number % i == 0)
            {
                count++;
            }
        }

        return count == 2;
    }



    public static int AddAnyNumberToValue(this ref int value, int number)
    {
        return value + number;
    }


    public static int CountOfCapitalLetters(this StringBuilder text)
    {
        var count = 0;

        for (var i = 0; i < text.Length; i++)
        {
            if (char.IsUpper(text[i]))
            {
                count++;
            }
        }

        return count;
    }


    public static Person GetTheOldestPerson(this List<Person> persons)
    {
        var oldPerson = new Person();

        foreach (var person in persons)
        {
            if (person.Age > oldPerson.Age)
            {
                oldPerson = person;
            }
        }

        return oldPerson;
    }


    public static double GetTotalPriceOfBook(this List<Book> books)
    {
        var totalPrice = 0d;

        foreach(var book in books)
        {
            totalPrice += book.Price;
        }

        return totalPrice;
    }
    */



    public static bool GetEvenNumber(this int number)
    {
        return number % 2 == 0;
    }


    public static bool GetAmountOfPrimeNumbers(this int number)
    {
        var count = 0;

        for (var i = 1; i <= number; i++)
        {
            if(number % i == 0)
            {
                count++;
            }
        }

        return count == 2;
    }


    public static int AddAnyNumberToValue(this ref int value, int number)
    {
        return value + number;
    }



    public static int GetAmountOfCapitalLetters(this StringBuilder text)
    {
        var count = 0;

        for(var i = 0; i < text.Length; i++)
        {
            if (char.IsUpper(text[i]))
            {
                count++;
            }
        }

        return count;
    }



    public static Person GetTheOldestPerson(this List<Person> persons)
    {
        var oldPerson = new Person();

        foreach (var person in persons)
        {
            if(person.Age > oldPerson.Age)
            {
                oldPerson = person;
            }
        }

        return oldPerson;
    }


    public static double GetTotelPriceOfBooks(this List<Book> books)
    {
        var totalPrice = 0d;

        foreach(var book in books)
        {
            totalPrice += book.Price;
        }

        return totalPrice;
    }



}
