using System.Text.RegularExpressions;

namespace DataStructures.BinaryTree
{
    public class TreeNode<T> : ITreeNode<T>
    {
        private ITreeNode<T> leftChild;
        private ITreeNode<T> rightChild;

        public T Data;

        public TreeNode(T data, ITreeNode<T> leftChild = null, ITreeNode<T> rightChild = null)
        {
            Data = data;
            this.leftChild = leftChild;
            this.rightChild = rightChild;
        }

        #region get children
        public ITreeNode<T> getLeftChild() => leftChild;

        public ITreeNode<T> getRightChild() => rightChild;
        #endregion

        #region has child
        public bool hasLeftChild() => leftChild != null;

        public bool hasRightChild() => rightChild != null;
        #endregion

        //#region Обход деревьев
        ///// <summary>Прямое рекурсивное прохождение узлов дерева</summary>
        ///// <param name="tree">Узел дерева для прохождения</param>
        //public void PreOrder(TreeNode<T> tree)
        //{
        //    // рекурсивное прохождение завершается на пустом поддереве
        //    if (tree is null) return;

        //    // посетить узел
        //    visit(tree->data);

        //    // спуститься по левому поддереву
        //    PreOrder(tree.getLeftChild());

        //    // спуститься по правому поддереву
        //    PreOrder(tree.getRightChild());
        //}

        ///// <summary>Симметричное рекурсивное прохождение узлов дерева</summary>
        ///// <param name="tree">Узел дерева для прохождения</param>
        //public void InOrder(TreeNode<T> tree)
        //{
        //    // рекурсивное прохождение завершается на пустом поддереве
        //    if (tree is null) return;

        //    // спуститься по левому поддереву
        //    InOrder(tree.getLeftChild());

        //    // посетить узел
        //    visit(tree->data);

        //    // спуститься по правому поддереву
        //    InOrder(tree.getRightChild());
        //}

        ///// <summary>Обратное рекурсивное прохождение узлов дерева</summary>
        ///// <param name="tree">Узел дерева для прохождения</param>
        //public void PostOrder(TreeNode<T> tree)
        //{
        //    // рекурсивное прохождение завершается на пустом поддереве
        //    if (tree is null) return;

        //    // спуститься по левому поддереву
        //    PostOrder(tree.getLeftChild());

        //    // спуститься по правому поддереву
        //    PostOrder(tree.getRightChild());

        //    // посетить узел
        //    visit(tree->data);
        //}
        //#endregion

        #region CountLeaves
        public int CountLeaves() => CountLeaves(this);

        private int CountLeaves(ITreeNode<T> tree)
        {
            // рекурсивное прохождение завершается на пустом поддереве
            if (tree is null) return 0;

            var treeNode = tree as TreeNode<T>;

            if (treeNode.IsLeaf()) return 1;

            return CountLeaves(treeNode.leftChild) + CountLeaves(treeNode.rightChild);
        }

        public bool IsLeaf() => !hasLeftChild() && !hasRightChild();
        #endregion

        #region Depth
        public int Depth() => Depth(this) - 1; //todo не знаю, как избавиться от лишнего уровня глубины

        private int Depth(ITreeNode<T> tree)
        {
            // рекурсивное прохождение завершается на пустом поддереве
            if (tree is null) return 0;

            var treeNode = tree as TreeNode<T>;

            var depthLeft = Depth(treeNode.leftChild);
            var depthRight = Depth(treeNode.rightChild);
            var depth = 1 + (depthLeft >= depthRight ? depthLeft : depthRight);

            return depth;
        }
        #endregion

        #region CopyTree
        public ITreeNode<T> CopyTree() => CopyTree(this);

        private ITreeNode<T> CopyTree(ITreeNode<T> tree)
        {
            // остановить рекурсивное прохождение при достижении пустого дерева
            if (tree == null) return null;

            // строит новое дерево снизу вверх, сначала создавая двух сыновей, а затем их родителя

            var treeNode = tree as TreeNode<T>;

            var newLeftChild = CopyTree(treeNode.leftChild);

            var newRightChild = CopyTree(treeNode.rightChild);

            var newNode = new TreeNode<T>(treeNode.Data, newLeftChild, newRightChild);

            return newNode;
        }
        #endregion

        #region ToString
        public override string ToString()
        {
            var res = ToStringInOrder(this).Trim();
            return Regex.Replace(res, "[ ]+", " ");
        }

        private string ToStringInOrder(ITreeNode<T> tree)
        {
            // остановить рекурсивное прохождение при достижении пустого дерева
            if (tree == null) return "";

            var result = "";

            var treeNode = tree as TreeNode<T>;

            if (treeNode.hasLeftChild())
                result += ToStringInOrder(treeNode.leftChild);

            result += $"{treeNode.Data.ToString()} ";

            if (treeNode.hasRightChild())
                result += ToStringInOrder(treeNode.rightChild);

            return result;
        }
        #endregion
    }
}