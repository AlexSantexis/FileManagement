using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FIleManagement.Model
{
    internal class DLList<T>
    {
        public GenericNode<T>? Head { get; set; } = null;
        public GenericNode<T>? Tail { get; set; } = null;

        public void InsertFirst(T t)
        {
            GenericNode<T> tmp = new()
            {
                Value = t,
                Count = 1,
                Next = Head,
                Prev = null
            };
            if(isEmpty())
            {
                Tail = tmp;
            }
            Head = tmp;
        }
        public void InsertLast(T t)
        {
            if(Head is null)
            {
                InsertFirst(t);
                return;
            }
            GenericNode<T> tmp = new()
            {
                Value = t,
                Count = 1,
                Next = null,
                Prev = Tail
            };
            Tail!.Next = tmp;
            Tail = tmp;
            
        }

        public void Traverse(int count)
        {
            if(isEmpty())
            {
                Console.WriteLine("List is Empty");
                return;
            }
     
            Console.WriteLine($"TotalChars: {count}");
            for(GenericNode<T> node = Head!; node != null; node = node.Next!)
            {
                Console.WriteLine($"value: {node.Value}," + $"Count:{node.Count}, Frequency: {(double)node.Count / count:P}");
            }
        }
        public GenericNode<T>? GetPosition(T? t)
        {
            if(isEmpty() || t == null)
            {
                return null;
            }
            GenericNode<T>? node = Head;
            while(node != null)
            {
                if(node.Value!.Equals(t))
                {
                    return node;
                }
                node = node.Next;
            }
            return null;
        }
        public void IncreaseCount(GenericNode<T>? node)
        {
            if (node is null) return;
            node.Count++;
        }
        public void IncreaseCount(T? t)
        {
            GenericNode<T>? tmp = GetPosition(t);
            if(tmp is null)
            {
                return;
            }
            tmp.Count++;
        }

        public void SortByValueAsc()
        {
            for(GenericNode<T>? iNode = Head; iNode != null; iNode = iNode.Next)
            {
                T? minVal = iNode.Value;
                GenericNode<T>? minPos = iNode;
                for(GenericNode<T>? jNode = iNode; jNode !=null; jNode = jNode.Next)
                {
                    if(jNode.Value is char)
                    {
                        if(Convert.ToChar(jNode.Value) < Convert.ToChar(minVal))
                        {
                            minVal = jNode.Value;
                            minPos = jNode;
                        }
                    }
                }
                Swap(iNode, minPos);
            }
        }

        public void Swap(GenericNode<T>? iNode,GenericNode<T>? jNode)
        {
            T tmpVal = iNode!.Value!;
            int tmpCount = iNode.Count;

            iNode!.Value = jNode!.Value;
            iNode.Count = jNode.Count;

            jNode.Value = tmpVal;
            jNode!.Count = tmpCount;
        }

        public void SortByFrequencyDesc()
        {
            for(GenericNode<T>? iNode = Head; iNode != null; iNode = iNode.Next)
            {
                int minVal = iNode.Count;
                GenericNode<T>? minPos = iNode;
                for(GenericNode<T>? jNode = iNode; jNode != null; jNode = jNode.Next)
                {
                    if(jNode.Count > minVal)
                    {
                        minVal = jNode.Count;
                        minPos = jNode;
                    }
                }
                Swap(iNode, minPos);
            }
        }

        public bool isEmpty()
        {
            return Head == null && Tail == null;
        }
    }
}
