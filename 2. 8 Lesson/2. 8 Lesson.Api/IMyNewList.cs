using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._8_Lesson.Api
{
    internal interface IMyNewList<T>
    {
        bool Contains(T item);
        void Clear();
        T[] ToArray();
        void InsertAt(int index, T item);
        void AddItem(T item);
        T GetItemAt(int index);
        void RemoveItem(int index);
        int GetLastIndex();
        void Reverse();
        void AddItemsRange(T[] items);
        void ReplaceAtItems(T oldElement, T newElement);
        int GetItemIndex(T element);
        void Sort();
    }
}
