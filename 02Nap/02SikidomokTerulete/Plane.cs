using System;

namespace _02SikidomokTerulete
{
    public abstract class Plane : IPlane, IDisplayable
    {
        public string Name { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }

        public abstract double Area();

        public void Show() {

        }
        public void Hide() {
        }

    }
}