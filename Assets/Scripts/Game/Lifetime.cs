using System;
using System.Collections;
using UnityEngine;

namespace Game
{
    public class Lifetime : MonoBehaviour
    {
        [SerializeField] private float _lifetime;

        private void Start()
        {
            StartCoroutine(WaitAndDestroy());
        }

        private IEnumerator WaitAndDestroy()
        {
            yield return new WaitForSeconds(_lifetime);
        }
    }
}