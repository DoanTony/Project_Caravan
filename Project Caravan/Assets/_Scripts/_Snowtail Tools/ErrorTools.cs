using UnityEngine;
using System.Collections;

namespace SnowtailTools
{
    namespace Error
    {
        public class ErrorMessages
        {
            public static void NoManagerFound()
            {
                Debug.LogError("Please add the logic scene to the scene box!");
            }


        }
    }
}
