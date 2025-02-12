using System;
using System.Linq;
using System.Web;

namespace RefactoringToPatterns.ComposeMethod
{
    public class List
    {

        private readonly bool _readOnly;
        private int _size;
        private Object[] _elements;

        public List(bool readOnly)
        {
            _readOnly = readOnly;
            _size = 0;
            _elements = new Object[_size];
        }

        public void Add(Object element)
        {
            if (_readOnly) return;
            CreateNewList(_size + 1);
            AddElement(element);
        }

        private object AddElement(object element)
        {
            return _elements[_size++] = element;
        }

        private void CreateNewList(int newSize)
        {
            if (newSize > _elements.Length)
            {
                Object[] newElements = new Object[_elements.Length + 10];

                for (int i = 0; i < _size; i++)
                    newElements[i] = _elements[i];

                _elements = newElements;
            }
        }

        public object[] Elements()
        {
            return _elements;
        }

    }

}