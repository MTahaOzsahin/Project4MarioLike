using Project4.Abstracts.Inputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project4.Concretes.Inputs
{
    public class PcInputs : IPlayerInputs
    {
        public float Horizontal => Input.GetAxis("Horizontal");
        public float Vertical => Input.GetAxis("Vertical");
    }

}

