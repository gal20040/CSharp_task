namespace DataStructures
{
    //todo: сначала сделаю на int, с дженериками как-то не задалось - простое сравнение не работает: Operator >= cannot be applied to operands of type 'T' and 'T'
    public class BinaryTree : ArtList<int>
    {
        public override void Add(int item)
        {
            base.Add(item);

            //todo: не знаю, как просто получить доступ - пришлось изменить модификатор доступа на protected у _artList
            //todo: дженерики: не знаю, как найти элемент, перед которым надо вставить новый элемент - простое сравнение не работает: Operator >= cannot be applied to operands of type 'T' and 'T'
            //Array.Sort(_artList, 0, Count);

            int index = Count - 1;

            for (; index >= 0; index--)
            {
                if (this[index] <= item)
                {
                    Insert(index + 1, item);
                }
            }
        }

        /// <summary>Ищет переданный элемент.</summary>
        /// <param name="item">Искомый элемент</param>
        /// <returns>Индекс найденного элемента. Если элемент не найден, то -1.</returns>
        public int Search(int item)
        {
            const int noItemIndex = -1;
            if (Count == 0)
            {
                //Если в структуре нет элементов, то -1
                return noItemIndex;
            }

            int minIndex = 0;
            int maxIndex = Count - 1;

            return Search(item, minIndex, maxIndex);
        }

        private int Search(int item, int minIndex, int maxIndex)
        {
            var index = -1;

            var midIndex = (maxIndex + minIndex) / 2;

            if (item < _artList[midIndex])
            {
                int newMinIndex = minIndex;
                int newMaxIndex = midIndex - 1;

                index = Search(item, newMinIndex, newMaxIndex);
            }
            else if (_artList[midIndex] == item)
            {
                index = midIndex;
            }
            else
            {
                /*
                    _artList[midIndex] < item
                                      (C) Ваш Кэп
                */
                int newMinIndex = midIndex + 1;
                int newMaxIndex = maxIndex;

                index = Search(item, newMinIndex, newMaxIndex);
            }

            return index;
        }
    }
}