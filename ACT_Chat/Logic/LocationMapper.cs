using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACT_Chat.Logic
{
    public static class LocationMapper
    {
        public static string ToSimpleString(this Point point)
            => $"{point.X},{point.Y}";
        public static Point? ToLocation(this string point)
        {
            if (string.IsNullOrWhiteSpace(point)) return null;
            int x, y;
            var split = point.Split(',');
            if (!int.TryParse(split[0], out x) || !int.TryParse(split[1], out y))
                return null;


            return new Point(x, y);
        }
    }
}
