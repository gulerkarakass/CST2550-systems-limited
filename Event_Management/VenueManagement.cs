using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management
{
    public class VenueManagement<TKey, TValue>
    {
        private class HashNode
        {
            public TKey Key { get; set; }
            public TValue Value { get; set; }
            public HashNode Next { get; set; }
            public HashNode(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }
        }
        private HashNode[] buckets;
        private int size;
        private const int DEFAULT_CAPACITY = 16;
        // LOAD_FACTOR is the threshold for resizing
        private const float LOAD_FACTOR = 0.6f;
        public VenueManagement(int capacity = DEFAULT_CAPACITY)
        {
            if (capacity <= 0)
                capacity = DEFAULT_CAPACITY;

            buckets = new HashNode[capacity];
            size = 0;
        }
        private int GetBucketIndex(TKey key)
        {
            int hashCode = key.GetHashCode();
            return Math.Abs(hashCode % buckets.Length);
        }
        private void Resize()
        {
            int newCapacity = buckets.Length * 2;
            HashNode[] newBuckets = new HashNode[newCapacity];

            foreach (HashNode bucket in buckets)
            {
                HashNode node = bucket;
                while (node != null)
                {
                    int newBucketIndex = Math.Abs(node.Key.GetHashCode() % newCapacity);
                    HashNode newNode = new HashNode(node.Key, node.Value);
                    newNode.Next = newBuckets[newBucketIndex];
                    newBuckets[newBucketIndex] = newNode;
                    node = node.Next;
                }
            }

            buckets = newBuckets;
        }
        public void Put(TKey key, TValue value)
        {
            int bucketIndex = GetBucketIndex(key);
            HashNode newNode = new HashNode(key, value);
            newNode.Next = buckets[bucketIndex];
            buckets[bucketIndex] = newNode;
            size++;
            if (size >= buckets.Length * LOAD_FACTOR)
            {
                Resize();
            }
        }
        public void RemoveVenue(TKey key)
        {
            int bucketIndex = GetBucketIndex(key);
            HashNode node = buckets[bucketIndex];
            HashNode previous = null;

            while (node != null)
            {
                if (node.Key.Equals(key))
                {
                    if (previous == null)
                    {
                        // Delete the first node
                        buckets[bucketIndex] = node.Next;
                    }
                    else
                    {
                        // Cross the current node
                        previous.Next = node.Next;
                    }
                    size--;
                    return;
                }
                previous = node;
                node = node.Next;
            }
        }
        public TValue GetValue(TKey key)
        {
            int bucketIndex = GetBucketIndex(key);
            HashNode node = buckets[bucketIndex];

            while (node != null)
            {
                if (node.Key.Equals(key))
                    return node.Value;
                node = node.Next;
            }
            return default(TValue);
        }
    }
}
