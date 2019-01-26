using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SnowtailTools.RuntimeSet;

namespace SnowtailTools
{
    namespace Utilities
    {
        public class Utilities
        {
            #region Set Tags and Layers to childs

            public static void SetTags(GameObject _object, string tagName)
            {
                _object.tag = tagName;
                if (_object.transform.childCount > 0)
                {
                    foreach (Transform child in _object.transform)
                    {
                        child.tag = tagName;
                    }
                }
            }
            public static void SetLayer(GameObject _object, int layer)
            {
                _object.layer = layer;
                if (_object.transform.childCount > 0)
                {
                    foreach (Transform child in _object.transform)
                    {
                        child.gameObject.layer = layer;
                    }
                }
            }

            #endregion

            #region List Comparison
            public static bool CompareOrderedList<T>(List<T> _list1, List<T> _list2)
            {
                foreach (T item in _list1)
                {
                    if (item.ToString() != _list2[_list1.IndexOf(item)].ToString())
                    {
                        return false;
                    }
                }
                return true;
            }

            public static bool CompareFinalDataList<T>(List<T> _list1, List<T> _list2)
            {
                //Compare list count
                if (_list1.Count != _list2.Count)
                {
                    return false;
                }
                // Compare both list has the same ordered items
                foreach (T item in _list1)
                {
                    if (item.ToString() != _list2[_list1.IndexOf(item)].ToString())
                    {
                        return false;
                    }
                }
                return true;
            }

            #endregion

          
            public static bool CheckInteractionAnglePossible(float angle1, float angle2)
            {
                if ((angle1 >= angle2 + 45) || (angle1 >= angle2 - 45) || (angle1 == angle2))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

          
        }

        public class Validation
        {
            public static bool ValidateField<T>(T _target, string _message, GameObject _context) {
                if (_target == null)
                {
                    Debug.LogError("<b><color=red>" + _message.ToUpper() + "</color></b>", _context);
                    return false;
                }
                return true;
            }
        }
    }
}

