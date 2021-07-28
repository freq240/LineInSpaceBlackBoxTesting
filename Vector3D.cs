using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineInSpaceBlackBoxTesting
{
    struct Vector3D
    {
        public double dx;
        public double dy;
        public double dz;

        public Vector3D(double xval, double yval, double zval)
        {
            this.dx = xval;
            this.dy = yval;
            this.dz = zval;
        }

        public override string ToString()
        {
            return $"( {this.dx} , {this.dy} , {this.dz} )";
        }
    }
}
