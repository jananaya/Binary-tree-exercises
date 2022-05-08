using System.Collections.Generic;

namespace Binary_tree_exercises.types
{
    internal class BinaryTree<E>
    {
        private BinaryTree<E> _right;
        private BinaryTree<E> _left;
        private E _data;

        public BinaryTree(E data)
        {
            _data = data;
            _right = null;
            _left = null;
        }

        public BinaryTree<E> Right
        {
            get
            {
                return _right;
            }
        }

        public BinaryTree<E> Left
        {
            get
            {
                return _left;
            }
        }

        public E Data
        {
            get
            {
                return _data;
            }
        }

        public void LinkRight(BinaryTree<E> r)
        {
            _right = r;
        }

        public void LinkLeft(BinaryTree<E> r)
        {
            _left = r;
        }

        public void Shift(E x)
        {
            _data = x;
        }

        public bool Equal(BinaryTree<E> x)
        {
            return Equal(x, this);
        }

        private bool Equal(BinaryTree<E> x, BinaryTree<E> y)
        {
            if (x == null && y == null)
                return true;

            return x.Data.Equals(y.Data) && Equal(x.Left, y.Left) && Equal(x.Right, y.Right);
        }

        public bool ShapeEqual(BinaryTree<E> x)
        {
            return ShapeEqual(x, this);
        }

        private bool ShapeEqual(BinaryTree<E> x, BinaryTree<E> y)
        {
            if (x == null && y == null)
                return true;

            return ShapeEqualNode(x, y) && ShapeEqual(x.Left, y.Left) && ShapeEqual(x.Right, y.Right);

        }

        private bool ShapeEqualNode(BinaryTree<E> x, BinaryTree<E> y)
        {
            bool shapeEqual;

            if (Exist(x.Left))
                shapeEqual = Exist(y.Left);
            else
                shapeEqual = !Exist(y.Left);

            if (!shapeEqual)
                return false;

            if (Exist(x.Right))
                shapeEqual = Exist(y.Right);
            else
                shapeEqual = !Exist(y.Right);

            return shapeEqual;
        }

        private bool Exist(BinaryTree<E> x)
        {
            return x != null;
        }
    }
}