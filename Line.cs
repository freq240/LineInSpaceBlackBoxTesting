using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineInSpaceBlackBoxTesting
{
    class Line
    {
        private Point p1, p2;
        private Vector3D p_vec;

        public Line(Point first, Point second)
        {
            this.p1 = first;
            this.p2 = second;
            p_vec = new Vector3D(this.p2.x - this.p1.x, this.p2.y - this.p1.y, this.p2.z - this.p1.z);
        }

        public Vector3D getPVec() { return this.p_vec; }
        public Point getPoint() { return this.p1; }

        public bool isParallelWithX()
        {
            if (this.p_vec.dy == 0 && this.p_vec.dz == 0) return true;
            else return false;
        }
        public bool isParallelWithY()
        {
            if (this.p_vec.dx == 0 && this.p_vec.dz == 0) return true;
            else return false;
        }
        public bool isParallelWithZ()
        {
            if (this.p_vec.dy == 0 && this.p_vec.dx == 0) return true;
            else return false;
        }
        private bool isSharePoint(Line ln)
        {
            Point ln_point = ln.getPoint();
            if (this.p_vec.dx == 0 || this.p_vec.dy == 0 || this.p_vec.dz == 0) return false; //if any denum is 0 -> rations coulndn`t be equal

            double val1 = (ln_point.x - this.p1.x) / this.p_vec.dx;
            double val2 = (ln_point.y - this.p1.y) / this.p_vec.dy;
            double val3 = (ln_point.z - this.p1.z) / this.p_vec.dz;

            if (val1 == val2 && val2 == val3) return true;
            else return false;
        }
        public bool isSkewWithLine(Line ln)
        {
            Point ln_point = ln.getPoint();
            Vector3D ln_vec = ln.getPVec();
            Vector3D MN = new Vector3D(ln_point.x - this.p1.x, ln_point.y - this.p1.y, ln_point.z - this.p1.z);
            double det = this.p_vec.dx * ln_vec.dy * MN.dz; //counts determinant of a mixed vector multiplication
            det -= this.p_vec.dx * ln_vec.dz * MN.dy;
            det -= this.p_vec.dy * ln_vec.dx * MN.dz;
            det += this.p_vec.dz * ln_vec.dx * MN.dy;
            det += this.p_vec.dy * ln_vec.dz * MN.dx;
            det -= this.p_vec.dz * ln_vec.dy * MN.dx;

            // if vectors complanar (det is 0) - lines in the same plane
            // else - they are crossing each otheer
            if (det == 0) return false;
            else return true;
        }

        public bool isParallelWithLine(Line ln)
        {
            if (!isSkewWithLine(ln))
            {
                Vector3D ln_vec = ln.getPVec();

                double rat1 = this.p_vec.dx / ln_vec.dx;
                double rat2 = this.p_vec.dy / ln_vec.dy;
                double rat3 = this.p_vec.dz / ln_vec.dz;

                bool isShare = this.isSharePoint(ln);
                if ((ln_vec.dx == 0 && this.p_vec.dx == 0) && (ln_vec.dy != 0 && ln_vec.dz != 0) && (rat2 == rat3))
                {
                    if (isShare) return false;
                    return true;
                }
                else return false;

                if ((ln_vec.dy == 0 && this.p_vec.dy == 0) && (ln_vec.dx != 0 && ln_vec.dz != 0) && (rat1 == rat3))
                {
                    if (isShare) return false;
                    return true;
                }
                else return false;

                if ((ln_vec.dz == 0 && this.p_vec.dz == 0) && (ln_vec.dy != 0 && ln_vec.dx != 0) && (rat2 == rat1))
                {
                    if (isShare) return false;
                    return true;
                }
                else return false;

                if (rat1 == rat2 && rat2 == rat3)
                {
                    if (isShare) return false; //if it shares point - lines r equal
                    else return true; // if not - parallel
                }
                else return false;
            }
            else return false;
        }

        public bool isIntersectWithLine(Line ln)
        {
            if (!isSkewWithLine(ln))
            {
                Vector3D ln_vec = ln.getPVec();

                double rat1 = this.p_vec.dx / ln_vec.dx;
                double rat2 = this.p_vec.dy / ln_vec.dy;
                double rat3 = this.p_vec.dz / ln_vec.dz;

                if ((ln_vec.dx == 0 && this.p_vec.dx == 0) && (ln_vec.dy != 0 && ln_vec.dz != 0) && (rat2 == rat3)) return false;
                else return true;

                if ((ln_vec.dy == 0 && this.p_vec.dy == 0) && (ln_vec.dx != 0 && ln_vec.dz != 0) && (rat1 == rat3)) return false;
                else return true;

                if ((ln_vec.dz == 0 && this.p_vec.dz == 0) && (ln_vec.dy != 0 && ln_vec.dx != 0) && (rat2 == rat1)) return false;
                else return true;

                if (rat1 == rat2 && rat2 == rat3) return false;
                else return true;
            }
            else return false;
        }

        public bool isPerpendicular(Line ln)
        {
            Vector3D ln_vec = ln.getPVec();
            double scalar_mult = this.p_vec.dx * ln_vec.dx;
            scalar_mult += this.p_vec.dy * ln_vec.dy;
            scalar_mult += this.p_vec.dz * ln_vec.dz;

            if (scalar_mult == 0) return true;
            else return false;
        }

    }
}
