using System;
using UnityEngine;

public class MathUtils {
        
        // Function to find the circle on
        // which the given three points lie
        static (Vector2 center, double radius) FindCircle(Vector2 a, Vector2 b, Vector2 c) {
            float x12 = a.x - b.x;
            float x13 = a.x - c.x;
            float y12 = a.y - b.y;
            float y13 = a.y - c.y;
            float y31 = c.y - a.y;
            float y21 = b.y - a.y;
            float x31 = c.x - a.x;
            float x21 = b.x - a.x;
            // a.x^2 - x3^2
            float sx13 = (float)(Math.Pow(a.x, 2) -
                             Math.Pow(c.x, 2));
            // y1^2 - y3^2
            float sy13 = (float)(Math.Pow(a.y, 2) -
                             Math.Pow(c.y, 2));
 
            float sx21 = (float)(Math.Pow(b.x, 2) -
                             Math.Pow(a.x, 2));
                     
            float sy21 = (float)(Math.Pow(b.y, 2) -
                             Math.Pow(a.y, 2));
            float f = ((sx13) * (x12)
                       + (sy13) * (x12)
                       + (sx21) * (x13)
                       + (sy21) * (x13))
                      / (2 * ((y31) * (x12) - (y21) * (x13)));
            float g = ((sx13) * (y12)
                     + (sy13) * (y12)
                     + (sx21) * (y13)
                     + (sy21) * (y13))
                    / (2 * ((x31) * (y12) - (x21) * (y13)));
            float d = -(float)Math.Pow(a.x, 2) - (float)Math.Pow(a.y, 2) -
                      2 * g * a.x - 2 * f * a.y;
            // eqn of circle be x^2 + y^2 + 2*g*x + 2*f*y + c = 0
            // where centre is (h = -g, k = -f) and radius r
            // as r^2 = h^2 + k^2 - c
            float h = -g;
            float k = -f;
            float sqr_of_r = h * h + k * k - d;
            // r is the radius
            double r = Math.Round(Math.Sqrt(sqr_of_r), 5);

            return (new Vector2(h, k), r);
        }

        public void Test() {
            (Vector2 center, double radius) data = FindCircle(Vector2.down, Vector2.left, Vector2.right);
            Console.WriteLine("Centre = (" + data.center.x + "," + data.center.y + ")");
            Console.WriteLine("Radius = " + data.radius);
        }
        
    }