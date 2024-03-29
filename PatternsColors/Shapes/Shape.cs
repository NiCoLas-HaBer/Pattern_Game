﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatternsColors.Shapes;
using PatternsColors.Colors;
using System.Collections;
using PatternsColors.Levels;

namespace PatternsColors
{
    public class Shape: IEnumerable
    {
        private List<IShape> TheShapes;

        public Type GetElementType
        {
            get
            {
                if (TheShapes.Count > 0)
                {
                    // Assuming that all elements implement IColors
                    Type elementType = TheShapes[0].GetType();
                    return elementType;
                }
                return null;

            }
        }

        public Shape(IEnumerable<IShape> item)
        {
            TheShapes = new List<IShape>(item);
        }

        public IShape this[int index]
        {
            get
            {
                if (index < 0 || index >= TheShapes.Count)
                    throw new IndexOutOfRangeException("Index out of range");

                return TheShapes[index];
            }

            set
            {
                if (index < 0 || index >= TheShapes.Count)
                    throw new IndexOutOfRangeException("Index out of range");

                TheShapes[index] = value;
            }
        }
        public int Counting()
        {
            return TheShapes.Count;
        }

        public IEnumerator GetEnumerator()
        {
            return new MyEnumerator<IShape>(TheShapes);
        }

    }
}


