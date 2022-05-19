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

        public LinkedList<LinkedList<E>> Levels()
        {
            LinkedList<LinkedList<E>> result = new LinkedList<LinkedList<E>>();
            int h = Height(this);
            

            for (int i = 1; i <= h; i++)
            {
                Queue<E> currentLevel = GetLevel(i);
                LinkedList<E> level = new LinkedList<E>();

                while (currentLevel.Count > 0)
                {
                    level.AddLast(currentLevel.Dequeue());
                }

                result.AddLast(level);
            }

            return result;
        }

        public Queue<E> GetLevel(int level)
        {
            Queue<E> result = new Queue<E>();

            GetLevel(this, level, result);

            return result;
        }

        private void GetLevel(BinaryTree<E> r, int level, Queue<E> result)
        {
            if (r == null)
            {
                return;
            }

            if (level == 1)
            {
                result.Enqueue(r.Data);
            } 
            else if (level > 1)
            {
                GetLevel(r.Left, level - 1, result);
                GetLevel(r.Right, level - 1, result);
            }
        }

        public int Height()
        {
            return Height(this);
        }

        private int Height(BinaryTree<E> r)
        {
            if (r == null)
            {
                return 0;
            }

            int lHeight = Height(r.Left);
            int rHeight = Height(r.Right);

            if (lHeight > rHeight)
            {
                return lHeight + 1;
            }

            return rHeight + 1;
        }

        private bool Exist(BinaryTree<E> x)
        {
            return x != null;
        }
    }
}