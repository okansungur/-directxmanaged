using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Microsoft.DirectX.DirectDraw;
using Direct3D = Microsoft.DirectX.Direct3D;
namespace Project1
{

    class hiyerarsi : AllocateHierarchy
    {
        sinif g_orn = null;

        public hiyerarsi(sinif parent)
        {
            g_orn = parent;
        }

        public override Frame CreateFrame(string name)
        {
            d3d_frame frame = new d3d_frame();
            frame.Name = name;
            frame.TransformationMatrix = Matrix.Identity;
            frame.Hareket = Matrix.Identity;

            return frame;
        }



        public override MeshContainer CreateMeshContainer(string isim, MeshData meshdata, ExtendedMaterial[] materyal, EffectInstance[] efekt, GraphicsStream adj, SkinInformation skin)
        {
            
            kap mesh = new kap();

            mesh.Name = isim;

            Direct3D.Device dev = meshdata.Mesh.Device;
            mesh.SetMaterials(materyal);
            mesh.SetAdjacency(adj);
            Texture[] doku = new Texture[materyal.Length];


            for (int i = 0; i < materyal.Length; i++)
            {
                if (materyal[i].TextureFilename != null)
                {
                    doku[i] = TextureLoader.FromFile(dev, materyal[i].TextureFilename);
                }
            }
            mesh.setDoku(doku);
            mesh.MeshData = meshdata;


          

            return mesh;
        }
    }
}
