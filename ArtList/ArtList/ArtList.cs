using System;
using System.Collections;
using System.Collections.Generic;

namespace ArtList
{
    /// <summary>
    /// Represents a strongly typed list of objects that can be accessed by index.Provides
    /// methods to search, sort, and manipulate lists.To browse the .NET Framework source
    /// code for this type, see the Reference Source.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    public class ArtList<T> : IList<T>
    {
        private T[] _artList;

        private int _lastAssignedIndex;

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
                if (index < 0
                    || index >= Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }

                return _artList[index];
            }
            set => _artList[index] = value;
        }

        public int Count => _lastAssignedIndex;

        public int Capacity => _artList.Length;

        public bool IsReadOnly => throw new NotImplementedException();

        /// <summary>
        /// Adds an object to the end of the <see cref="ArtList"/>&lt;<see cref="T"/>&gt;.
        /// </summary>
        /// <param name="item">The object to be added to the end of the <see cref="ArtList"/>&lt;<see cref="T"/>&gt;. The value can be null for reference types.</param>
        public void Add(T item)
        {
            CheckCapacity();

            _artList[_lastAssignedIndex] = item;
            _lastAssignedIndex++;
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether an element is in the <see cref="ArtList"/>&lt;<see cref="T"/>&gt;.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="ArtList"/>&lt;<see cref="T"/>&gt;. The value can be null for reference types.</param>
        /// <returns>true if item is found in the <see cref="ArtList"/>&lt;<see cref="T"/>&gt;; otherwise, false.</returns>
        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Copies the entire <see cref="ArtList"/>&lt;<see cref="T"/>&gt; to a compatible one-dimensional array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="array">The one-dimensional System.Array that is the destination of the elements copied from <see cref="ArtList"/>&lt;<see cref="T"/>&gt;. The System.Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            // Exceptions:
            //   T:System.ArgumentNullException:
            //     array is null.
            //
            //   T:System.ArgumentOutOfRangeException:
            //     arrayIndex is less than 0.
            //
            //   T:System.ArgumentException:
            //     The number of elements in the source <see cref="ArtList"/>&lt;<see cref="T"/>&gt; is greater
            //     than the available space from arrayIndex to the end of the destination array.

            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Inserts an element into the <see cref="ArtList"/>&lt;<see cref="T"/>&gt; at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="item">The object to insert. The value can be null for reference types.</param>
        public void Insert(int index, T item)
        {
            // Exceptions:
            //   T:System.ArgumentOutOfRangeException:
            //     index is less than 0.-or- index is greater than <see cref="ArtList"/>&lt;<see cref="T"/>&gt;.Count.

            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="ArtList"/>&lt;<see cref="T"/>&gt;.
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="ArtList"/>&lt;<see cref="T"/>&gt;. The value can be null for reference types.</param>
        /// <returns>true if item is successfully removed; otherwise, false. This method also returns false if item was not found in the <see cref="ArtList"/>&lt;<see cref="T"/>&gt;.</returns>
        public bool Remove(T item)
        {
            throw new NotImplementedException();
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
            if (index < 0
                || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            var newArray = new T[Capacity];
            Array.Copy(_artList, 0, newArray, 0, index);
            Array.Copy(_artList, index + 1, newArray, index, Capacity - index - 1);

            _artList = newArray;
            _lastAssignedIndex--;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}