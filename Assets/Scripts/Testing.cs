using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace lvl_0
{
    public class Testing : MonoBehaviour
    {
        private Grid grid;

        // Start is called before the first frame update
        private void Start()
        {
            grid = new Grid(4, 2, 10f, new Vector3(10, -10));
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                grid.SetValue(Utils.Utils.GetMouseWorldPosition(), 56);
            }
        }
    }

}
