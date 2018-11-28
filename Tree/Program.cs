using common;
using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Tree
{
    class Program
    {
        static unsafe void Main(string[] args)
        {

            #region 递归 无极树结构 版本1.0  双亲 表示法
            //1. 双亲表示法 数据结构
            //2. 缺点 要想知道节点的孩子，必须遍历整个结构才行
            var list = DB.Conn().Query<Tree>(@"SELECT TOP (1000) [Id],[data],[parent],[firstchild],[rightsib] FROM [demo].[dbo].[Types]").ToList();
            var root= list.Where(t => t.parent == -1).FirstOrDefault();
            //RecursionTreeType1(root, root.Id, list);
            #endregion

            #region 递归 无极树结构 版本2.0 双亲孩子兄弟 表示法
            var node = RecursionTreeType2(list[0], list[0].Id, null, list);
            #endregion

            #region 2.0 遍历 二叉树
            BinaryTree binaryTree = new BinaryTree();
            binaryTree.data = 'A';

            char B = 'B';
            BinaryTree ltB = new BinaryTree();
            ltB.data = B;
            binaryTree.lchild = &ltB;
            char C = 'C';
            BinaryTree ltC = new BinaryTree();
            ltC.data = C;
            binaryTree.rchild = &ltC;

            char D = 'D';
            BinaryTree ltD = new BinaryTree();
            ltD.data = D;
            ltB.lchild = &ltD;
            char E = 'E';
            BinaryTree ltE = new BinaryTree();
            ltE.data = E;
            ltC.lchild = &ltE;

            char H = 'H';
            BinaryTree ltH = new BinaryTree();
            ltH.data = H;
            ltD.rchild = &ltH;

            char I = 'I';
            BinaryTree ltI = new BinaryTree();
            ltI.data = I;
            ltE.rchild = &ltI;

            char F = 'F';
            BinaryTree ltF = new BinaryTree();
            ltF.data = F;

            ltC.rchild = &ltF;

            char G = 'G';
            BinaryTree ltG = new BinaryTree();
            ltG.data = G;
            ltD.lchild = &ltG;
            TraversingBinaryTree(&binaryTree);
            #endregion

            Console.ReadKey();
            Console.WriteLine("Hello World!");
        }

        /// <summary>
        /// 递归 无极树结构 版本1.0  双亲 表示法
        /// </summary>
        /// <param name="node"></param>
        /// <param name="nodeId"></param>
        static void RecursionTreeType1(Tree node, int nodeId, List<Tree> listTree)
        {
            var trees = listTree.Where(t => t.parent == nodeId).ToList();

            if (trees != null && trees.Count() > 0)
            {
                node.subTrees = trees;
                for (int i = 0; i < trees.Count(); i++)
                {
                    RecursionTreeType1(trees[i], trees[i].Id, listTree);
                }
            }

        }

        /// <summary>
        /// 递归 无极树结构 版本2.0 双亲孩子兄弟 表示法
        /// </summary>
        /// <param name="node"></param>
        /// <param name="nodeId"></param>
        static Tree RecursionTreeType2(Tree node, int nodeId,Tree parentNode, List<Tree> listTree)
        {

            if (node.firstchild != -1)
            {
                var firstchild = listTree[node.firstchild -1];
                if (node.subTrees == null)
                {
                    node.subTrees = new List<Tree>();
                }
                node.subTrees.Add(firstchild);
                RecursionTreeType2(firstchild,  firstchild.Id, node, listTree);

            }
            if (node.rightsib != -1)
            {
                var rightsib = listTree[node.rightsib - 1];

                if (parentNode != null)
                {
                    parentNode.subTrees.Add(rightsib);
                }

                RecursionTreeType2(rightsib, rightsib.Id, parentNode, listTree);
            }
            return node;
        }

        /// <summary>
        /// 遍历 二叉树
        /// </summary>
        static unsafe void TraversingBinaryTree(BinaryTree* binaryTree)
        {
            if (binaryTree == null)
                return;
            var a = *binaryTree;
            Console.WriteLine(a.data);
            TraversingBinaryTree((*binaryTree).lchild);
            TraversingBinaryTree((*binaryTree).rchild);
        }
    }

}
