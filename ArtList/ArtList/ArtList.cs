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
        public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        /// <summary>
        /// Adds an object to the end of the System.Collections.Generic.List`1.
        /// </summary>
        /// <param name="item">The object to be added to the end of the System.Collections.Generic.List`1. The value can be null for reference types.</param>
        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes all elements from the System.Collections.Generic.List`1.
        /// </summary>
        public void Clear()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether an element is in the System.Collections.Generic.List`1.
        /// </summary>
        /// <param name="item">The object to locate in the System.Collections.Generic.List`1. The value can be null for reference types.</param>
        /// <returns>true if item is found in the System.Collections.Generic.List`1; otherwise, false.</returns>
        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Copies the entire System.Collections.Generic.List`1 to a compatible one-dimensional array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="array">The one-dimensional System.Array that is the destination of the elements copied from System.Collections.Generic.List`1. The System.Array must have zero-based indexing.</param>
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
            //     The number of elements in the source System.Collections.Generic.List`1 is greater
            //     than the available space from arrayIndex to the end of the destination array.

            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the first occurrence within the entire System.Collections.Generic.List`1.
        /// </summary>
        /// <param name="item">The object to locate in the System.Collections.Generic.List`1. The value can be null for reference types.</param>
        /// <returns>The zero-based index of the first occurrence of item within the entire System.Collections.Generic.List`1, if found; otherwise, –1.</returns>
        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Inserts an element into the System.Collections.Generic.List`1 at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="item">The object to insert. The value can be null for reference types.</param>
        public void Insert(int index, T item)
        {
            // Exceptions:
            //   T:System.ArgumentOutOfRangeException:
            //     index is less than 0.-or- index is greater than System.Collections.Generic.List`1.Count.

            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the System.Collections.Generic.List`1.
        /// </summary>
        /// <param name="item">The object to remove from the System.Collections.Generic.List`1. The value can be null for reference types.</param>
        /// <returns>true if item is successfully removed; otherwise, false. This method also returns false if item was not found in the System.Collections.Generic.List`1.</returns>
        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the element at the specified index of the System.Collections.Generic.List`1.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        public void RemoveAt(int index)
        {
            // Exceptions:
            //   T:System.ArgumentOutOfRangeException:
            //     index is less than 0.-or- index is equal to or greater than System.Collections.Generic.List`1.Count.

            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}