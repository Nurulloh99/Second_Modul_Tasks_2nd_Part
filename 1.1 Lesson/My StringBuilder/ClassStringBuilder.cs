using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1_Lesson.My_StringBuilder;

public class ClassStringBuilder
{
    private char[] strBuilder;

    private int defCapacity = 16;
    private int index = 0;

    public ClassStringBuilder()
    {
        strBuilder = new char[defCapacity];
    }

    public ClassStringBuilder(int capasity)
    {
        strBuilder = new char[capasity];
    }

    public void AppendValue(string strAppend)
    {
        if(index + strAppend.Length <= strBuilder.Count())
        {
            foreach (var strChar in strAppend)
            {
                strBuilder[index] = strChar;
                index++;
            }
        }
        else
        {
            var newChar = new char[strBuilder.Length * 2];

            index = 0;

            var arr = new char[1];


            foreach(var strChar in strBuilder)
            {
                if (strChar != arr[0])
                {
                    newChar[index] = strChar;
                    index++;
                }
            }

            

            foreach (var strChar in strAppend)
            {
                newChar[index] = strChar;
                index++;
            }

            strBuilder = newChar;
        }
    }

     
    public string GetValueBackStringFromArray()
    {
        var str = String.Empty;
        var arr = new char[1];

        foreach(var character in strBuilder)
        {
            if(character != arr[0])
            {
                str += character;
            }
        }

        return str;
    }


    public void UpdateValue(int index, char character)
    {
        strBuilder[index] = character;
    }
}
