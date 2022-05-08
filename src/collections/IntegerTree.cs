using Binary_tree_exercises.types;

namespace Binary_tree_exercises
{
    internal class IntegerTree
    {
        private BinaryTree<int> _root;

        public IntegerTree()
        {
            _root = null;
        }

        public BinaryTree<int> Root
        {
            get
            {
                return _root;
            }
        }

        public void Insert(int x)
        {
            if (_root == null)
            {
                _root = new BinaryTree<int>(x);
                return;
            }

            Insert(x, _root);
        }

        private void Insert(int x, BinaryTree<int> r)
        {
            if (r == null)
                return;

            if (x > r.Data)
            {
                if (r.Right == null)
                {
                    r.LinkRight(new BinaryTree<int>(x));
                    return;
                }
                Insert(x, r.Right);
            }
            else
            {
                if (r.Left == null)
                {
                    r.LinkLeft(new BinaryTree<int>(x));
                    return;
                }
                Insert(x, r.Left);
            }
        }
    }
}