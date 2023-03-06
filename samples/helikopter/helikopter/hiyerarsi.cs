using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace helikopter
{
    class hiyerarsi : AllocateHierarchy
    {
        private string yol;
        public hiyerarsi(string yol)
        {
            this.yol = yol;
        }

        public override Frame CreateFrame(string isim)
        {
            return new d3d_frame(isim);
        }
        
        public override MeshContainer CreateMeshContainer(string name, MeshData meshData,
          ExtendedMaterial[] materials, EffectInstance[] effectInstances, GraphicsStream adjacency,
          SkinInformation skinInfo)
        {
            kap kp = new kap(this.yol, name, meshData, materials,
               effectInstances, adjacency, skinInfo);

            return kp;
        }
    }
}
