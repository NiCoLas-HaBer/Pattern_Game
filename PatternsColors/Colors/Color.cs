﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatternsColors.Levels;

namespace PatternsColors.Colors
{
    public class Color : IEnumerable
    {
        private List<IColors> TheColors;

        public  Type GetElementType
        {
            get
            {
                if (TheColors.Count > 0)
                {
                    Type elementType = TheColors[0].GetType();
                    return elementType;
                }
                return null;
               
            }
        }
        public Color(IEnumerable<IColors> colors)
        {
            TheColors = new List<IColors>(colors);
        }

        public IColors this[int index]
        {
            get
            {
                if (index < 0 || index >= TheColors.Count)
                    throw new IndexOutOfRangeException("Index out of range");

                return TheColors[index];
            }

            set
            {
                if (index < 0 || index >= TheColors.Count)
                    throw new IndexOutOfRangeException("Index out of range");

                TheColors[index] = value;
            }
        }
        public int Counting()
        {
            return TheColors.Count;
        }

        public IEnumerator GetEnumerator()
        {
            return new MyEnumerator<IColors>(TheColors);
        }
    }
}

