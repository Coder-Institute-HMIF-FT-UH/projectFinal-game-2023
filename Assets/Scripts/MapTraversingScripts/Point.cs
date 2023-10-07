/*
using System;  // Namespace System digunakan untuk tipe data IEquatable

namespace Map
{
    public class Point : IEquatable<Point>
    {
        public int x;   // Koordinat x dari titik
        public int y;   // Koordinat y dari titik

        public Point(int x, int y)
        {
            this.x = x;  // Menginisialisasi koordinat x
            this.y = y;  // Menginisialisasi koordinat y
        }

        // Implementasi IEquatable untuk membandingkan titik dengan titik lain
        public bool Equals(Point other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return x == other.x && y == other.y;
        }

        // Override metode Equals dari objek dasar untuk membandingkan objek dengan titik lain
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Point)obj);
        }

        // Override metode GetHashCode dari objek dasar untuk menghasilkan kode hash berdasarkan nilai x dan y
        public override int GetHashCode()
        {
            unchecked
            {
                return (x * 397) ^ y;
            }
        }

        // Override metode ToString dari objek dasar untuk menghasilkan representasi string dari titik
        public override string ToString()
        {
            return $"({x}, {y})";  // Menghasilkan representasi string "(x, y)"
        }
    }
}
*/