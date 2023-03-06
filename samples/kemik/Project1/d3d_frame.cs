using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Microsoft.DirectX.DirectDraw;
namespace Project1
{
   public class d3d_frame:Frame

    {
       //Bu matris sayesinde teker teker framelere hareket vermekteyiz 
       Matrix hareket_et = Matrix.Identity;
       public Matrix Hareket
            {
                get { return hareket_et; }
                set { hareket_et = value; }
            }
        }
    }

