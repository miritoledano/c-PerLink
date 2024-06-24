using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace preLink
{
    internal  class Node<T>
    {
        public int Id { get; set; }
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(int id, T data)
        {
            Id = id;
            Data = data;
            Next = null;
        }
    }
}
