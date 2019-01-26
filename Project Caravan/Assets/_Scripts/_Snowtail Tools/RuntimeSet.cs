using UnityEngine;
using System.Collections.Generic;
using SnowtailTools.ReadOnly;

namespace SnowtailTools
{
    namespace RuntimeSet
    {
        public abstract class RuntimeSet<T> : ScriptableObject
        {   
            [ReadOnly] public List<T> Items = new List<T>();

            public virtual void Add(T t)
            {
                if (!Items.Contains(t))
                {
                    Items.Add(t);
                }
            }

            public virtual void Remove(T t)
            {
                if (Items.Contains(t))
                {
                    Items.Remove(t);
                }
            }

            private void OnEnable()
            {
                Items.Clear();
            }

            private void OnDisable()
            {
                Items.Clear();
            }

        }
    }
}
