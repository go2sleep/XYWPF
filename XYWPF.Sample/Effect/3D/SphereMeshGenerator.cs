using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Media3D;

namespace XYWPF.Sample.Effect._3D
{
    public class SphereMeshGenerator
    {
        private int slices = 64;
        private int stacks = 32;
        private Point3D center = new Point3D();
        private double radius = 1;

        public int Slices
        {
            set { slices = value; }
            get { return slices; }
        }

        public int Stacks
        {
            set { stacks = value; }
            get { return stacks; }
        }

        public Point3D Center
        {
            set { center = value; }
            get { return center; }
        }

        public double Radius
        {
            set { radius = value; }
            get { return radius; }
        }

        public MeshGeometry3D Geometry
        {
            get
            {
                MeshGeometry3D mesh = new MeshGeometry3D();

                for (int stack = 0; stack <= Stacks; stack++)
                {
                    double phi = Math.PI / 2 - stack * Math.PI / Stacks;
                    double y = Radius * Math.Sin(phi);
                    double scale = -Radius * Math.Cos(phi);

                    for (int slice = 0; slice <= Slices; slice++)
                    {
                        double theta = slice * 2 * Math.PI / Slices;
                        double x = scale * Math.Sin(theta);
                        double z = scale * Math.Cos(theta);

                        Vector3D normal = new Vector3D(x, y, z);
                        mesh.Normals.Add(normal);
                        mesh.Positions.Add(normal + Center);
                        mesh.TextureCoordinates.Add(new Point((double)slice / Slices, (double)stack / Stacks));
                    }
                }

                for (int stack = 0; stack < Stacks; stack++)
                {
                    int top = (stack + 0) * (Slices + 1);
                    int bot = (stack + 1) * (Slices + 1);

                    for (int slice = 0; slice < Slices; slice++)
                    {
                        if (stack != 0)
                        {
                            mesh.TriangleIndices.Add(top + slice);
                            mesh.TriangleIndices.Add(bot + slice);
                            mesh.TriangleIndices.Add(top + slice + 1);
                        }

                        if (stack != Stacks - 1)
                        {
                            mesh.TriangleIndices.Add(top + slice + 1);
                            mesh.TriangleIndices.Add(bot + slice);
                            mesh.TriangleIndices.Add(bot + slice + 1);
                        }
                    }
                }
                return mesh;
            }
        }

    }
}
