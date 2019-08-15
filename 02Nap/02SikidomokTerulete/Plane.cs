using System;

namespace _02SikidomokTerulete
{
    public abstract class Plane 
    {
        public string Name { get; set; }
        public abstract double Area();

        public void Show() {

        }
        public void Hide() {
        }

    }
}