namespace DataStructures.BinaryTree
{
    public interface ITreeNode<T>
    {
        #region get children
        /// <summary>Вернуть левого сына</summary>
        ITreeNode<T> GetLeftChild();

        /// <summary>Вернуть правого сына</summary>
        ITreeNode<T> GetRightChild();
        #endregion

        #region has child
        /// <summary>Есть ли левый сын</summary>
        bool HasLeftChild();

        /// <summary>Есть ли правый сын</summary>
        bool HasRightChild();
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

        /// <summary>Представляет текущий узел и всех его потомков в виде строки через пробел с InOrder обходом</summary>
        string ToString();

        /// <summary>Обновляет текущий узел: значение, левого или правого сына</summary>
        /// <returns>Вернуть обновлённый узел</returns>
        TreeNode<T> Update(T data, ITreeNode<T> leftChild = null, ITreeNode<T> rightChild = null);
    }
}