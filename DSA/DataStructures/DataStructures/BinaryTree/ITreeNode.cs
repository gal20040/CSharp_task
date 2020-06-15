namespace DataStructures.BinaryTree
{
    public interface ITreeNode<T>
    {
        #region add child
        /// <summary>Добавляет левого сына и только если его не было раньше</summary>
        /// <returns>Возвращает текущий-обновлённый узел</returns>
        ITreeNode<T> AddLeftChild(ITreeNode<T> leftChild);

        /// <summary>Добавляет правого сына и только если его не было раньше</summary>
        /// <returns>Возвращает текущий-обновлённый узел</returns>
        ITreeNode<T> AddRightChild(ITreeNode<T> rightChild);
        #endregion

        #region delete child
        /// <summary>Удаляет левого сына</summary>
        /// <returns>Возвращает только что удалённый узел</returns>
        ITreeNode<T> DeleteLeftChild();

        /// <summary>Удаляет правого сына</summary>
        /// <returns>Возвращает только что удалённый узел</returns>
        ITreeNode<T> DeleteRightChild();
        #endregion

        #region get children
        /// <summary>Возвращает левого сына. Либо null</summary>
        ITreeNode<T> GetLeftChild();

        /// <summary>Возвращает правого сына. Либо null</summary>
        ITreeNode<T> GetRightChild();
        #endregion

        #region has child
        /// <summary>Есть ли левый сын</summary>
        bool HasLeftChild();

        /// <summary>Есть ли правый сын</summary>
        bool HasRightChild();
        #endregion

        #region CountLeaves
        /// <summary>Подсчитывает количество листьев в данном поддереве</summary>
        int CountLeaves();

        /// <summary>Является ли данный узел листом</summary>
        bool IsLeaf();
        #endregion

        /// <summary>Вычисляет глубину дерева</summary>
        int Depth();

        /// <summary>Создаёт дубликат дерева tree и возвращает корень нового дерева</summary>
        ITreeNode<T> CopyTree();

        /// <summary>Представляет текущий узел и всех его потомков в виде строки через пробел с InOrder обходом</summary>
        string ToString();
    }
}