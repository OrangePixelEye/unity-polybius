/*
using System.Runtime.InteropServices;
using UnityEngine;

public class MouseController
{
    [DllImport("user32.dll")]
    public static extern bool SetCursorPos(int X, int Y);

    [DllImport("user32.dll")]
    public static extern bool GetCursorPos(out Point pos);

    [StructLayout(LayoutKind.Sequential)]
    public struct Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static implicit operator System.Drawing.Point(Point p)
        {
            return new System.Drawing.Point(p.x, p.y);
        }

        public static implicit operator Point(System.Drawing.Point p)
        {
            return new Point(p.X, p.Y);
        }
    }

    public void move(int factor)
    {
        Point cursorPos = new Point();
        GetCursorPos(out cursorPos);
        SetCursorPos(cursorPos.x + factor, cursorPos.y + factor);
    }
}
*/
