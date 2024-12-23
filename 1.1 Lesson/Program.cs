using _1._1_Lesson.Models;
using _1._1_Lesson.My_StringBuilder;

namespace _1._1_Lesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            var p1 = "Nurulloh";
            var p2 = p1;
            var p3 = p1;

            p2 = "Bekmurod";

            Console.WriteLine(p1);
            Console.WriteLine(p2);
            Console.WriteLine(p3);

            Console.WriteLine();

            var obj = new Meals();

            obj.Name = "Nurulloh";

            var bek1 = obj;
            var bek2 = obj;
            var bek3 = bek1;
            var nur = bek3;
            nur.Name = "Eldor";

            Console.WriteLine(bek1.Name);
            Console.WriteLine(bek2.Name);
            Console.WriteLine(bek3.Name);
            Console.WriteLine(nur.Name);
            */
            var strBuilder = new ClassStringBuilder();

            strBuilder.AppendValue("Nurulloh");
            var text = strBuilder.GetValueBackStringFromArray();
            Console.WriteLine(text);

            strBuilder.AppendValue(" vs  Bekmurod");
            text = strBuilder.GetValueBackStringFromArray();
            Console.WriteLine(text);

            strBuilder.UpdateValue(10, 'a');
            strBuilder.UpdateValue(11, 'n');
            strBuilder.UpdateValue(12, 'd');
            text = strBuilder.GetValueBackStringFromArray();
            Console.WriteLine(text);
        }

       


    }
}
