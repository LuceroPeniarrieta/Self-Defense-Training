using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class TestController : MonoBehaviour
    {
        public string text;
        public GameObject textDisplay;

        public void StoreText()
        {
            if (DataStore.Text == null || DataStore.Text.Equals(string.Empty))
            {
                text = "Ningun movimiento fue detectado. Intentelo de nuevo...";
            }
            else 
            {
                text = DataStore.Text;
            }

            textDisplay.GetComponent<Text>().text = text;
            DataStore.Text = string.Empty;
        }
    }
}
