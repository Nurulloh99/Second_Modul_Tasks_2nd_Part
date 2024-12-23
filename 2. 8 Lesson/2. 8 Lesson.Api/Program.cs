namespace _2._8_Lesson.Api
{
    internal class Programm
    {
        static void Main(string[] args)
        {
            IMyNewList<int> list = new MyNewList<int>();
            list.AddItem(13);
            list.AddItem(98);
            list.AddItem(10);
            list.AddItem(100);
            list.Sort();
            int aaa = 0;

        }
    }
}
