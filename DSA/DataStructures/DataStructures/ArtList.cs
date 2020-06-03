using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    /// <summary>
    /// Написать класс MyList<T>, который реализует интерфейс IList<T>  
    ///
    /// Готов функционал за исключением:
    /// 1. Конструктор для создания списка из переданного массива/коллекции:
    /// ArtList<int> numbers = new ArtList<int>() { 1, 2, 3, 45 };
    /// 2. GetEnumerator().
    /// 
    /// Represents a strongly typed list of objects that can be accessed by index.Provides
    /// methods to search, sort, and manipulate lists.To browse the .NET Framework source
    /// code for this type, see the Reference Source.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    public class ArtList<T> : IList<T>
    {
        protected T[] _artList;

        #region ctor
        /// <summary>
        /// Initializes a new instance of the ArtList<T> class that is empty and has the specified initial capacity.
        /// </summary>
        public ArtList() : this(0) { }

        /// <summary>
        /// Initializes a new instance of the ArtList<T> class that is empty and has the default initial capacity.
        /// </summary>
        /// <param name="capacity"></param>
        public ArtList(int capacity) => _artList = new T[capacity];
        #endregion

        public T this[int index]
        {
            get
            {
                var isIndexOk = index >= 0 && index < Count;
                if (!isIndexOk)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }

                return _artList[index];
            }
            set => _artList[index] = value;
        }

        public int Count { get; private set; }

        /// <summary>
        /// Gets or sets the total number of elements the internal data structure can hold without resizing.
        /// </summary>
        /// <returns>The number of elements that the ArtList can contain before resizing is required.</returns>
        /// <exception cref="ArgumentOutOfRangeException">ArtList.Capacity is set to a value that is less than ArtList.Count.</exception>
        public int Capacity
        {
            get => _artList.Length;
            set
            {
                if (value < Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                if (value == _artList.Length)
                {
                    return;
                }

                if (value <= 0)
                {
                    _artList = new T[0];
                }
                else
                {
                    var newArray = new T[value];
                    if (Count > 0)
                    {
                        Array.Copy(_artList, 0, newArray, 0, Count);
                    }
                    _artList = newArray;
                }
            }
        }

        public bool IsReadOnly => false;

        /// <summary>
        /// Adds an object to the end of the <see cref="ArtList"/>&lt;<see cref="T"/>&gt;.
        /// </summary>
        /// <param name="item">The object to be added to the end of the <see cref="ArtList"/>&lt;<see cref="T"/>&gt;. The value can be null for reference types.</param>
        public virtual void Add(T item)
        {
            CheckCapacity();

            _artList[Count] = item;
            Count++;
        }

        private void CheckCapacity()
        {
            if (Count >= Capacity)
            {
                IncreaseCapacity();
            }
        }

        private void IncreaseCapacity()
        {
            var newCapacity = Capacity == 0 ? 4 : Capacity * 2;
            var newArray = new T[newCapacity];
            Array.Copy(_artList, 0, newArray, 0, Capacity);

            _artList = newArray;
        }

        /// <summary>
        /// Removes all elements from the <see cref="ArtList"/>&lt;<see cref="T"/>&gt;.
        /// </summary>
        public void Clear()
        {
            _artList = new T[Capacity];
            Count = 0;
        }

        /// <summary>
        /// Determines whether an element is in the <see cref="ArtList"/>&lt;<see cref="T"/>&gt;.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="ArtList"/>&lt;<see cref="T"/>&gt;. The value can be null for reference types.</param>
        /// <returns>true if item is found in the <see cref="ArtList"/>&lt;<see cref="T"/>&gt;; otherwise, false.</returns>
        public bool Contains(T item)
        {
            return IndexOf(item) >= 0;
        }

        /// <summary>
        /// Copies the entire <see cref="ArtList"/>&lt;<see cref="T"/>&gt; to a compatible one-dimensional <param name="array">,
        /// starting at the specified <param name="arrayIndex"> of the target <param name="array">.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="Array"/> that is the destination of the elements copied from <see cref="ArtList"/>&lt;<see cref="T"/>&gt;.
        /// The <see cref="Array"/> must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based <param name="arrayIndex"> in <paramref name="array"/> at which copying begins.</param>
        /// <exception cref="ArgumentNullException"><paramref name="array"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="arrayIndex"/> is less than 0.</exception>
        /// <exception cref="ArgumentException">
        /// The number of elements in the source <see cref="ArtList"/>&lt;<see cref="T"/>&gt; is greater
        /// than the available space from <paramref name="arrayIndex"/> to the end of the destination <paramref name="array"/>.
        /// </exception> 
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            }

            var freeSpaceCount = array.Length - arrayIndex;
            if (Count > freeSpaceCount)
            {
                throw new ArgumentException(nameof(arrayIndex));
            }

            if (Count <= 0) return; //nothing to copy

            Array.Copy(_artList, 0, array, arrayIndex, Count);
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the first occurrence within the entire <see cref="ArtList"/>&lt;<see cref="T"/>&gt;.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="ArtList"/>&lt;<see cref="T"/>&gt;. The value can be null for reference types.</param>
        /// <returns>The zero-based index of the first occurrence of item within the entire <see cref="ArtList"/>&lt;<see cref="T"/>&gt;, if found; otherwise, –1.</returns>
        public int IndexOf(T item)
        {
            return Array.IndexOf(_artList, item);
        }

        /// <summary>
        /// Inserts an element into the <see cref="ArtList"/>&lt;<see cref="T"/>&gt; at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="item">The object to insert. The value can be null for reference types.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="index"/> is less than 0.-or- <paramref name="index"/> is greater than <see cref="ArtList"/>&lt;<see cref="T"/>&gt;.Count
        /// </exception>
        public void Insert(int index, T item)
        {
            var isIndexOk = index >= 0 && index <= Count;
            if (!isIndexOk)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            CheckCapacity();

            var newArray = new T[Capacity];
            Array.Copy(_artList, 0, newArray, 0, index);
            newArray[index] = item;
            Array.Copy(_artList, index, newArray, index + 1, Count - index);

            _artList = newArray;
            Count++;
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="ArtList"/>&lt;<see cref="T"/>&gt;.
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="ArtList"/>&lt;<see cref="T"/>&gt;. The value can be null for reference types.</param>
        /// <returns>true if item is successfully removed; otherwise, false. This method also returns false if item was not found in the <see cref="ArtList"/>&lt;<see cref="T"/>&gt;.</returns>
        /// <exception cref="Exception">
        /// After removing the <paramref name="item"/>, the new array capacity/count unexpectedly changed/increased compared to the initial
        /// </exception>
        public bool Remove(T item)
        {
            int numIndex = IndexOf(item);
            if (numIndex <= -1)
            {
                //returns false if item was not found
                return false;
            }

            var oldCapacity = Capacity;
            var oldCount = Count;
            RemoveAt(numIndex);

            var exceptionMessageTemplate = $"After removing the item {item.ToString()}, the new array %0 unexpectedly %1 compared to the initial";

            var capacityResult = oldCapacity.CompareTo(Capacity); //compare previous and new Capacities
            if (capacityResult != 0) //capacity should remain the same
            {
                //throw exception if new array capacity is greater than old one - smthng went wrong
                throw new Exception(string.Format(exceptionMessageTemplate, "capacity", "changed") +
                                $"\n\tinitial array capacity={oldCapacity}" +
                                $"\n\tnew array capacity={Capacity}");
            }

            var countResult = oldCount.CompareTo(Count); //compare previous and new Counts
            if (countResult == -1) //count may stay the same or decrease
            {
                //throw exception if new array count is greater than old one - smthng went wrong
                throw new Exception(string.Format(exceptionMessageTemplate, "count", "increased") +
                                $"\n\tinitial array count={oldCount}" +
                                $"\n\tnew array count={Count}");
            }

            //true if item is successfully removed; otherwise, false
            return countResult == 1;
        }

        /// <summary>
        /// Removes the element at the specified <paramref name="index"/> of the <see cref="ArtList"/>&lt;<see cref="T"/>&gt;.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="index"/> is less than 0.-or- <paramref name="index"/> is equal to or greater than <see cref="ArtList"/>&lt;<see cref="T"/>&gt;.Count
        /// </exception>
        public void RemoveAt(int index)
        {
            var isIndexOk = index >= 0 && index < Count;
            if (!isIndexOk)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            var newArray = new T[Capacity];
            Array.Copy(_artList, 0, newArray, 0, index);
            Array.Copy(_artList, index + 1, newArray, index, Capacity - index - 1);

            _artList = newArray;
            Count--;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}