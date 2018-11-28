using System;
using System.Collections.Generic;
using System.Text;

namespace Tree
{
    public class Tree
    {
        public int Id { get; set; }
        public string data { get; set; }
        /// <summary>
        /// 双亲节点
        /// </summary>
        public int parent { get; set; }
        /// <summary>
        /// 长子节点
        /// </summary>
        public int firstchild { get; set; }
        /// <summary>
        /// 右兄弟节点
        /// </summary>
        public int rightsib { get; set; }
        public List<Tree> subTrees { get; set; }
    }
}
