using System;
using System.Collections.Generic;
using System.Text;

namespace Tree
{
    public unsafe struct BinaryTree
    {
        public char data;
        public BinaryTree* lchild;
        public BinaryTree* rchild;
    }
}
