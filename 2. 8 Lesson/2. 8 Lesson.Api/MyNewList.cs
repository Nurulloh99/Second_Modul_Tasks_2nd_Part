namespace _2._8_Lesson.Api;

public class MyNewList<T> : IMyNewList<T>
{
    private T[] items;
    private int count;

    public MyNewList()
    {
        items = new T[4];
        count = 0;
    }

    private void Resize()
    {
        var newItems = new T[count * 2];

        for (var i = 0; i < count; i++)
        {
            newItems[i] = items[i];
        }

        items = newItems;
    }


    public void AddItem(T item)
    {
        if (count.Equals(items.Length))
        {
            Resize();
        }

        items[count++] = item;
    }


    public void AddItemsRange(T[] objects)
    {
        foreach (var item in objects)
        {
            AddItem(item);
        }
    }


    private void CheckIndex(int index)
    {
        if (index < 0 || index >= count)
        {
            throw new IndexOutOfRangeException();
        }
    }


    public void Clear()
    {
        items = new T[items.Length];
    }


    public bool Contains(T obj)
    {
        foreach (var item in items)
        {
            if (object.Equals(obj, item))
            {
                return true;
            }
        }

        return false;
    }


    public T GetItemAt(int index)
    {
        foreach (var item in items)
        {
            if (object.Equals(item, index))
            {
                return item;
            }
        }

        throw new DirectoryNotFoundException();
    }


    public int GetItemIndex(T element)
    {
        for(var i = 0; i < count; i++)
        {
            if (object.Equals(items[i], element))
            {
                return i;
            }
        }

        return -1;
    }


    public int GetLastIndex()
    {
        return count - 1;   
    }


    public void InsertAt(int index, T item)
    {
        var newItems = items;
        var copyCount = count;

        items = new T[newItems.Length];
        count = copyCount;

        for(var i = 0; i < copyCount; i++)
        {
            if(i != index)
            {
                AddItem(newItems[i]);
            }
            else
            {
                index = -1;
                AddItem(item);
                i--;
            }
        }
    }

    public void RemoveItem(int index)
    {
        CheckIndex(index);

        for(var i = index; i < count-1; i++)
        {
            items[i] = items[i+1];
        }

        count--;
        items[count] = default(T);
    }


    public void ReplaceAtItems(T oldElement, T newElement)
    {
        for(var i = 0; i < count;i++)
        {
            if(object.Equals(oldElement, items[i]))
            {
                items[i] = newElement;
            }
        }
    }



    public void Reverse()
    {
        var reversedItems = new T[items.Length];
        var countOfIndex = 0;

        for(var i = count-1; i >= 0; i--)
        {
            reversedItems[countOfIndex] = items[i];
            countOfIndex++;
        }

        items = reversedItems;
    }
    


    public T[] ToArray()
    {
        var newItems = new T[items.Length];

        for(var i = 0;i < count; i++)
        {
            newItems[i] = items[i];
        }

        return newItems;
    }

    public void Sort()
    {
        var list = new List<T>();

        for (var i = 0; i < count; i++)
        {
            list.Add(items[i]);
        }

        list.Sort();

        for (var i = 0; i < list.Count; i++)
        {
            items[i] = list[i];
        }
    }
}
