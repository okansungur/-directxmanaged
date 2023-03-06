using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.DirectDraw;
using Microsoft.DirectX.AudioVideoPlayback;
using d3d = Microsoft.DirectX.Direct3D;
using dkey = Microsoft.DirectX.DirectInput;
namespace mvid
{
    class vdd : System.Windows.Forms.Form
    {
     
        
       d3d.Device device = null;
       dkey.Device klavye = null;

        public vdd()
        {
            this.ClientSize = new Size(400, 400);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque, true);
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
                     
            Render();
            
            Invalidate();
        }

        
        static void Main()
        {
            using (vdd frm = new vdd())
            {
                frm.Show();
                frm.Init();
                Application.Run(frm);
            }
        }
        private void Init()
        {
            this.Text = "Video (press-V) ";

            d3d.PresentParameters param = new d3d.PresentParameters();
            param.SwapEffect = d3d.SwapEffect.Discard;
            param.Windowed = true;
            param.EnableAutoDepthStencil = true;
            param.AutoDepthStencilFormat = d3d.DepthFormat.D16;

            device = new d3d.Device(0, d3d.DeviceType.Hardware, this,Microsoft.DirectX.Direct3D.CreateFlags.SoftwareVertexProcessing, param);
            device.DeviceReset += new System.EventHandler(this.OnResetDevice);
 
            OnResetDevice(device, null);

            klavye = new dkey.Device(dkey.SystemGuid.Keyboard);
            klavye.Acquire();
         
          
        }
     
      
        public void OnResetDevice(object sender, EventArgs e)
        {
            device = (d3d.Device)sender;
device.Transform.Projection=Matrix.PerspectiveFovLH((float)Math.PI /5 , 1.0f,1.0f, 500.0f);

}
     private void Render()
        {
            device.Clear(d3d.ClearFlags.ZBuffer | d3d.ClearFlags.Target,
                             Color.FromArgb(0, 0, 129, 179), 1.0f, 0);

         device.BeginScene();
         device.Transform.View = Matrix.LookAtLH(new Vector3(0, 0, -10.0f),
  new Vector3(2,0,2), new Vector3(0, 1, 0));
           klavyemiz();
           
   
          device.EndScene();
          device.Present();
        }
        Audio ses;
        Video film;
         void klavyemiz() { 
            dkey.KeyboardState keys = klavye.GetCurrentKeyboardState();
            
              if (keys[dkey.Key.A]) {
                 this.Text = "mp3";
                 ses = new Audio("x.mp3");
                 ses.Play();
                  
              }
              if (keys[dkey.Key.V])
              {
                  this.Text = "video";
                  film = new Video("a.avi");
                 // film.Fullscreen = true;
                  film.Play();

              }
            }
        
 
   
                                     



    }
}
