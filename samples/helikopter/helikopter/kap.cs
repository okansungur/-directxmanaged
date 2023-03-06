using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace helikopter
{
    class kap : MeshContainer
    {
        private string yol;


        public kap(string yol, string isim, MeshData mesh, ExtendedMaterial[] mat,
          EffectInstance[] efekt, GraphicsStream adj, SkinInformation skin)
            
        {
            this.Name = isim;
            this.MeshData = mesh;
            this.SetMaterials(mat);
            


            this.yol = yol;
        }
    }
}
