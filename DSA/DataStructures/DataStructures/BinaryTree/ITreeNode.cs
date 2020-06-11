namespace DataStructures.BinaryTree
{
    public interface ITreeNode<T>
    {
        #region get children
        /// <summary>Вернуть левого сына</summary>
        ITreeNode<T> getLeftChild();

        /// <summary>Вернуть правого сына</summary>
        ITreeNode<T> getRightChild();
        #endregion

        #region CountLeaves
        /// <summary>Подсчитать количество листьев в данном поддереве</summary>
        int CountLeaves();

        /// <summary>Является ли данный узел листом</summary>
        bool IsLeaf();
        #endregion

        /// <summary>Вычисляет глубину дерева</summary>
        int Depth();

        /// <summary>Создаёт дубликат дерева tree и возвращает корень нового дерева</summary>
        ITreeNode<T> CopyTree();

        string ToString();
    }
}