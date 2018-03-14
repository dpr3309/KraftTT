using System;
using UnityEngine;

namespace Kraft
{
    [Serializable]
    public struct ColorWrapper
    {
        public ColorWrapper(float r, float g, float b, float a)
        {
            this.r = this.g = this.b = this.a = 0;
            this.R = r;
            this.G = g;
            this.B = b;
            this.A = a;
        }

        private float r;
        public float R
        {
            get { return r; }
            set { r = CheckValue(value); }
        }

        private float g;
        public  float G
        {
            get { return g; }
            set { g = CheckValue(value); }
        }

        private float b;
        public float B
        {
            get { return b; }
            set { b = CheckValue(value); }
        }

        private float a;
        public float A
        {
            get { return a; }
            set { a = CheckValue(value); }
        }

        private float CheckValue(float value)
        {
            return Mathf.Clamp(value, 0, 255);
        }
            
    }

}


