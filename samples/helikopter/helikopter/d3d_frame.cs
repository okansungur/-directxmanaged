using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace helikopter
{
    class d3d_frame : Frame
    {
        
        //Bu matris sayesinde teker teker framelere hareket vermekteyiz
        private Matrix hareket_et = Matrix.Identity;
        public d3d_frame(string isim)
        {
            this.Name = isim;
        }

        public Matrix Hareket
        {
            get
            {
                return this.hareket_et;
            }

            set
            {
                this.hareket_et = value;
            }
        }
    }
}
